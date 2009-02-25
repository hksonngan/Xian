#region License

// Copyright (c) 2006-2009, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.ImageServer.Common;
using ClearCanvas.ImageServer.Enterprise;
using ClearCanvas.ImageServer.Model.EntityBrokers;
using Alert=ClearCanvas.ImageServer.Model.Alert;

namespace ClearCanvas.ImageServer.Services.ServiceLock.PurgeAlerts
{
	class PurgeAlertsItemProcessor: BaseServiceLockItemProcessor, IServiceLockItemProcessor
	{
		
		private static void UpdateFilesystemKey(Model.ServiceLock item)
		{
			IPersistentStore store = PersistentStoreRegistry.GetDefaultStore();
			using (IUpdateContext ctx = store.OpenUpdateContext(UpdateContextSyncMode.Flush))
			{
				ServiceLockUpdateColumns columns = new ServiceLockUpdateColumns();
				columns.FilesystemKey = item.FilesystemKey;

				IServiceLockEntityBroker broker = ctx.GetBroker<IServiceLockEntityBroker>();
				broker.Update(item.Key, columns);
				ctx.Commit();
			}
		}

		public void Process(Model.ServiceLock item)
		{
			ServiceLockSettings settings = ServiceLockSettings.Default;

			ServerFilesystemInfo archiveFilesystem = null;

			if (item.FilesystemKey != null)
			{
				archiveFilesystem = FilesystemMonitor.Instance.GetFilesystemInfo(item.FilesystemKey);
				if (archiveFilesystem == null)
				{
					Platform.Log(LogLevel.Warn,"Filesystem for archiving alerts is no longer valid.  Assigning new filesystem.");
					item.FilesystemKey = null;
					UpdateFilesystemKey(item);
				}
			}

			if (archiveFilesystem == null)
			{
				ServerFilesystemInfo selectedFs = null;
				foreach (ServerFilesystemInfo fs in FilesystemMonitor.Instance.GetFilesystems())
				{
					if (selectedFs == null)
						selectedFs = fs;
					else if (fs.Filesystem.FilesystemTierEnum.Enum > selectedFs.Filesystem.FilesystemTierEnum.Enum)
						selectedFs = fs; // Lower tier
					else if ((fs.Filesystem.FilesystemTierEnum.Enum == selectedFs.Filesystem.FilesystemTierEnum.Enum)
					         &&(fs.FreeBytes > selectedFs.FreeBytes))
						selectedFs = fs; // same tier
				}
				if (selectedFs == null)
				{
					Platform.Log(LogLevel.Info, "No writable filesystems for archiving logs, delaying archival.");
					UnlockServiceLock(item, true, Platform.Time.AddHours(2));
					return;
				}
				item.FilesystemKey = selectedFs.Filesystem.Key;
				archiveFilesystem = selectedFs;
				UpdateFilesystemKey(item);
			}
		

			DateTime scheduledTime;
			if (!archiveFilesystem.Writeable)
			{
				Platform.Log(LogLevel.Info, "Filesystem {0} is not writeable. Unable to archive Alert log files.", archiveFilesystem.Filesystem.Description);
				scheduledTime = Platform.Time.AddMinutes(settings.AlertRecheckDelay);
			}
			else
			{
				Platform.Log(LogLevel.Info, "Checking for Alert logs to purge to: {0}",
				             archiveFilesystem.Filesystem.Description);
				if (!ArchiveLogs(archiveFilesystem))
					scheduledTime = Platform.Time.AddMinutes(settings.AlertRecheckDelay);
				else
				{
					DateTime tomorrow = Platform.Time.Date.AddDays(1);
					// Set for 12:01 tomorrow morning
					scheduledTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 0, 1, 0);
					Platform.Log(LogLevel.Info, "Completed archival of Alert logs, rescheduling log archive for {0}",
								  scheduledTime.ToLongTimeString());
				}
			}

			UnlockServiceLock(item, true, scheduledTime);     
		}

		private bool ArchiveLogs(ServerFilesystemInfo archiveFs)
		{
			string archivePath = Path.Combine(archiveFs.Filesystem.FilesystemPath, "AlertLog");

			DateTime cutOffTime = Platform.Time.Date.AddDays(ServiceLockSettings.Default.AlertCachedDays*-1);
			AlertSelectCriteria criteria = new AlertSelectCriteria();
			criteria.InsertTime.LessThan(cutOffTime);
			criteria.InsertTime.SortAsc(0);

			IAlertEntityBroker broker = ReadContext.GetBroker<IAlertEntityBroker>();

			ImageServerLogWriter<Alert> writer = new ImageServerLogWriter<Alert>(archivePath, "Alert");
		
			List<ServerEntityKey> keyList = new List<ServerEntityKey>(500);
			try
			{
				broker.Find(criteria, delegate(Alert result)
				                      	{
				                      		keyList.Add(result.Key);

											// If configured, don't flush to disk.  We just delete the contents of keyList below.
											if (!ServiceLockSettings.Default.AlertDelete)
											{
												if (writer.WriteLog(result, result.InsertTime))
												{
													// The logs been flushed, delete the log entries cached.
													using (
														IUpdateContext update =
															PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
													{
														IApplicationLogEntityBroker updateBroker = update.GetBroker<IApplicationLogEntityBroker>();
														foreach (ServerEntityKey key in keyList)
															updateBroker.Delete(key);
														update.Commit();
													}
													keyList = new List<ServerEntityKey>();
												}
											}
				                      	});

				writer.FlushLog();

				if (keyList.Count > 0)
				{
					using (
						IUpdateContext update =
							PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
					{
						IAlertEntityBroker updateBroker = update.GetBroker<IAlertEntityBroker>();
						foreach (ServerEntityKey key in keyList)
							updateBroker.Delete(key);
						update.Commit();
					}
				}
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Unexpected exception when purging Alert log files.");
				writer.Dispose();
				return false;
			}
			writer.Dispose();

			return true;
		}
	}
}