﻿#region License

// Copyright (c) 2012, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.IO;
using System.Threading;
using System.Xml;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom;
using ClearCanvas.Dicom.ServiceModel.Query;
using ClearCanvas.Common;
using ClearCanvas.Dicom.Utilities.Xml;
using ClearCanvas.ImageViewer.Common.DicomServer;

namespace ClearCanvas.ImageViewer.StudyManagement.Storage
{
    /// <summary>
    /// Class and utilities for finding the directory where a study is stored.
    /// </summary>
    public class StudyLocation
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="studyInstanceUid">The Study Instance UID for the study location.</param>
        public StudyLocation(string studyInstanceUid)
        {
            Study = new Study
                        {
                            StudyInstanceUid = studyInstanceUid
                        };

            StudyFolder = Path.Combine(GetFileStoreDirectory(), studyInstanceUid);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">A message to find the Study location for.</param>
        public StudyLocation(DicomMessageBase message)
        {
            Study = new Study();
            Study.Initialize(message);

            StudyFolder = Path.Combine(GetFileStoreDirectory(), Study.StudyInstanceUid);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The folder where the study is stored.
        /// </summary>
        public string StudyFolder { get; private set; }

        /// <summary>
        /// A Study object.  Note that only the <see cref="StudyIdentifier.StudyInstanceUid"/> field is guarenteed to be filled in.
        /// </summary>
        public Study Study { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the path for a specific SOP Instance UID.
        /// </summary>
        /// <param name="seriesInstanceUid">The Series Instance UID of the SOP.</param>
        /// <param name="sopInstanceUid">The SOP Instance UID.</param>
        /// <returns></returns>
        public string GetSopInstancePath(string seriesInstanceUid, string sopInstanceUid)
        {
            return Path.Combine(StudyFolder,
                string.Format("{0}.{1}", sopInstanceUid, "dcm"));
        }

        /// <summary>
        /// Get the path where the <see cref="StudyXml"/> file is saved for the study.
        /// </summary>
        /// <returns></returns>
        public string GetStudyXmlPath()
        {
            return Path.Combine(StudyFolder, string.Format("{0}.xml", Study.StudyInstanceUid));
        }

        /// <summary>
        /// Load a <see cref="StudyXml"/> file for the <see cref="StudyLocation"/>
        /// </summary>
        /// <returns>The <see cref="StudyXml"/> instance</returns>
        public StudyXml LoadStudyXml()
        {
            var theXml = new StudyXml();

            string streamFile = GetStudyXmlPath();
            if (File.Exists(streamFile))
            {
                using (Stream fileStream = FileStreamOpener.OpenForRead(streamFile, FileMode.Open))
                {
                    var theDoc = new XmlDocument();

                    StudyXmlIo.Read(theDoc, fileStream);

                    theXml.SetMemento(theDoc);

                    fileStream.Close();
                }
            }
            return theXml;
        }

        /// <summary>
        /// Save the <see cref="StudyXml"/> file for a study.
        /// </summary>
        /// <param name="studyXml">The <see cref="StudyXml"/> file to save.</param>
        /// <param name="fileCreated">flag set to true if the file was created</param>
        public void SaveStudyXml(StudyXml studyXml, out bool fileCreated)
        {
            var settings = new StudyXmlOutputSettings
            {
                IncludePrivateValues = StudyXmlTagInclusion.IgnoreTag,
                IncludeUnknownTags = StudyXmlTagInclusion.IgnoreTag,
                IncludeLargeTags = StudyXmlTagInclusion.IncludeTagExclusion,
                MaxTagLength = 2048,
                IncludeSourceFileName = true
            };

            var doc = studyXml.GetMemento(settings);
            string streamFile = GetStudyXmlPath();

            // allocate the random number generator here, in case we need it below
            var rand = new Random();
            string tmpStreamFile = streamFile + "_tmp";
            for (int i = 0; ; i++)
                try
                {
                    if (File.Exists(tmpStreamFile))
                        FileUtils.Delete(tmpStreamFile);

                    using (FileStream xmlStream = FileStreamOpener.OpenForSoleUpdate(tmpStreamFile, FileMode.CreateNew))
                    {
                        StudyXmlIo.Write(doc, xmlStream);
                        xmlStream.Close();
                    }

                    File.Copy(tmpStreamFile, streamFile, true);
                    fileCreated = true;
                    FileUtils.Delete(tmpStreamFile);
                    return;
                }
                catch (IOException)
                {
                    if (i < 5)
                    {
                        Thread.Sleep(rand.Next(5, 50)); // Sleep 5-50 milliseconds
                        continue;
                    }

                    throw;
                }
        }

        #endregion

        #region Private Methods

        private static string GetFileStoreDirectory()
        {
            string directory = null;
            Platform.GetService<IDicomServerConfiguration>(
                s => directory = s.GetConfiguration(new GetDicomServerConfigurationRequest()).Configuration.FileStoreDirectory);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return directory;
        }

        #endregion
    }
}
