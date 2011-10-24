#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using ClearCanvas.Common.Utilities;
using ClearCanvas.ImageViewer.Common;
using ClearCanvas.ImageViewer.Graphics;
using ClearCanvas.ImageViewer.InteractiveGraphics;
using ClearCanvas.ImageViewer.StudyManagement;

namespace ClearCanvas.ImageViewer.AdvancedImaging.Fusion
{
	//TODO (CR Sept 2010): try to separate the frame data and graphic concerns?
	public partial class FusionOverlayFrameData : IDisposable, ILargeObjectContainer, IProgressGraphicProgressProvider
	{
		private readonly object _syncPixelDataLock = new object();
		private IFrameReference _baseFrameReference;
		private IFusionOverlayDataReference _overlayDataReference;

		private FusionOverlayData.OverlayFrameParams _overlayFrameParams;
		private byte[] _overlayPixelData;

		internal FusionOverlayFrameData(IFrameReference baseFrame, IFusionOverlayDataReference overlayData)
		{
			_baseFrameReference = baseFrame;
			_overlayDataReference = overlayData;
			_overlayDataReference.FusionOverlayData.Unloaded += HandleOverlayDataUnloaded;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_baseFrameReference != null)
				{
					_baseFrameReference.Dispose();
					_baseFrameReference = null;
				}

				if (_overlayDataReference != null)
				{
					_overlayDataReference.FusionOverlayData.Unloaded -= HandleOverlayDataUnloaded;
					_overlayDataReference.Dispose();
					_overlayDataReference = null;
				}
			}
		}

		public Frame BaseFrame
		{
			get { return _baseFrameReference.Frame; }
		}

		public FusionOverlayData OverlayData
		{
			get { return _overlayDataReference.FusionOverlayData; }
		}

		public string OverlaySourceSeriesInstanceUid
		{
			get { return OverlayData.SourceSeriesInstanceUid; }
		}

		public string OverlayFrameOfReferenceUid
		{
			get { return this.OverlayData.FrameOfReferenceUid; }
		}

		public int OverlayRows
		{
			get
			{
				Load();
				return _overlayFrameParams.Rows;
			}
		}

		public int OverlayColumns
		{
			get
			{
				Load();
				return _overlayFrameParams.Columns;
			}
		}

		public double OverlayRescaleSlope
		{
			get
			{
				Load();
				return _overlayFrameParams.RescaleSlope;
			}
		}

		public double OverlayRescaleIntercept
		{
			get
			{
				Load();
				return _overlayFrameParams.RescaleIntercept;
			}
		}

		protected byte[] OverlayPixelData
		{
			get
			{
				// update the last access time
				_largeObjectData.UpdateLastAccessTime();

				// if the data is already available without blocking, return it immediately
				byte[] pixelData = _overlayPixelData;
				if (pixelData != null)
					return pixelData;

				return this.LoadPixelData();
			}
		}

		//TODO (CR Sept 2010): CreatePixelData?
		private byte[] LoadPixelData()
		{
			// wait for synchronized access
			lock (_syncPixelDataLock)
			{
				// if the data is now available, return it immediately
				// (i.e. we were blocked because we were already reading the data)
				if (_overlayPixelData != null)
					return _overlayPixelData;

				// load the pixel data
				_overlayPixelData = _overlayDataReference.FusionOverlayData.GetOverlay(_baseFrameReference.Frame, out _overlayFrameParams);

				// update our stats
				_largeObjectData.BytesHeldCount = _overlayPixelData.Length;
				_largeObjectData.LargeObjectCount = 1;
				_largeObjectData.UpdateLastAccessTime();

				// regenerating the volume data is easy when the source frames are already in memory!
				_largeObjectData.RegenerationCost = RegenerationCost.Low;

				// register with memory manager
				MemoryManager.Add(this);

				return _overlayPixelData;
			}
		}

		private void UnloadPixelData()
		{
			// wait for synchronized access
			lock (_syncPixelDataLock)
			{
				// dump our data
				_overlayPixelData = null;

				// update our stats
				_largeObjectData.BytesHeldCount = 0;
				_largeObjectData.LargeObjectCount = 0;

				// unregister with memory manager
				MemoryManager.Remove(this);
			}
			this.OnUnloaded();
		}

		//TODO (CR Sept 2010): this method doesn't do much.  Just let client code create a new FusionOverlayImageGraphic.
		public GrayscaleImageGraphic CreateImageGraphic()
		{
			this.LoadPixelData();
			return new FusionOverlayImageGraphic(this);
		}

		private void HandleOverlayDataUnloaded(object sender, EventArgs e)
		{
			this.OnUnloaded();
		}

		#region IProgressGraphicProgressProvider Members

		bool IProgressGraphicProgressProvider.IsRunning(out float progress, out string message)
		{
			return !BeginLoad(out progress, out message);
		}

		#endregion

		#region Asynchronous Loading Support

		private event EventHandler _volumeUnloaded;

		public event EventHandler Unloaded
		{
			add { _volumeUnloaded += value; }
			remove { _volumeUnloaded -= value; }
		}

		protected virtual void OnUnloaded()
		{
			EventsHelper.Fire(_volumeUnloaded, this, EventArgs.Empty);
		}

		public bool IsLoaded
		{
			get { return _overlayDataReference.FusionOverlayData.IsLoaded; }
		}

		public bool BeginLoad(out float progress, out string message)
		{
			// LoadPixelData doesn't take very long if the overlay data is already loaded, so we won't bother asynchronously loading that
			return _overlayDataReference.FusionOverlayData.BeginLoad(out progress, out message);
		}

		public void Load()
		{
			_overlayDataReference.FusionOverlayData.Load();
			this.LoadPixelData();
		}

		public void Unload()
		{
			this.UnloadPixelData();
		}

		#endregion

		#region Memory Management Support

		private readonly LargeObjectContainerData _largeObjectData = new LargeObjectContainerData(Guid.NewGuid());

		Guid ILargeObjectContainer.Identifier
		{
			get { return _largeObjectData.Identifier; }
		}

		int ILargeObjectContainer.LargeObjectCount
		{
			get { return _largeObjectData.LargeObjectCount; }
		}

		long ILargeObjectContainer.BytesHeldCount
		{
			get { return _largeObjectData.BytesHeldCount; }
		}

		DateTime ILargeObjectContainer.LastAccessTime
		{
			get { return _largeObjectData.LastAccessTime; }
		}

		RegenerationCost ILargeObjectContainer.RegenerationCost
		{
			get { return _largeObjectData.RegenerationCost; }
		}

		public bool IsLocked
		{
			get { return _largeObjectData.IsLocked; }
		}

		public void Lock()
		{
			_largeObjectData.Lock();
		}

		public void Unlock()
		{
			_largeObjectData.Unlock();
		}

		void ILargeObjectContainer.Unload()
		{
			this.UnloadPixelData();
		}

		#endregion

		#region FusionOverlayImageGraphic Class

		private byte[] GetPixelData()
		{
			return this.OverlayPixelData;
		}

		[Cloneable]
		private sealed class FusionOverlayImageGraphic : GrayscaleImageGraphic
		{
			[CloneIgnore]
			private IFusionOverlayFrameDataReference _overlayFrameData;

			public FusionOverlayImageGraphic(FusionOverlayFrameData fusionOverlayFrameData)
				: base(fusionOverlayFrameData._overlayFrameParams.Rows, fusionOverlayFrameData._overlayFrameParams.Columns,
				       fusionOverlayFrameData._overlayFrameParams.BitsAllocated, fusionOverlayFrameData._overlayFrameParams.BitsStored, fusionOverlayFrameData._overlayFrameParams.HighBit,
				       fusionOverlayFrameData._overlayFrameParams.IsSigned, fusionOverlayFrameData._overlayFrameParams.IsInverted,
				       fusionOverlayFrameData._overlayFrameParams.RescaleSlope, fusionOverlayFrameData._overlayFrameParams.RescaleIntercept,
				       fusionOverlayFrameData.GetPixelData)
			{
				// this image graphic needs to keep a transient reference on the slice, otherwise it could get disposed before we do!
				_overlayFrameData = fusionOverlayFrameData.CreateTransientReference();
			}

			/// <summary>
			/// Cloning constructor.
			/// </summary>
			/// <param name="source">The source object from which to clone.</param>
			/// <param name="context">The cloning context object.</param>
			private FusionOverlayImageGraphic(FusionOverlayImageGraphic source, ICloningContext context) : base(source, context)
			{
				context.CloneFields(source, this);

				_overlayFrameData = source._overlayFrameData.Clone();
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (_overlayFrameData != null)
					{
						_overlayFrameData.Dispose();
						_overlayFrameData = null;
					}
				}

				base.Dispose(disposing);
			}

			protected override SpatialTransform CreateSpatialTransform()
			{
				return new XSpatialTransform(this);
			}

			#region XSpatialTransform Class

			// ReSharper disable SuggestBaseTypeForParameter
			// ReSharper disable UnusedMember.Local

			[Cloneable]
			private class XSpatialTransform : SpatialTransform
			{
				public XSpatialTransform(FusionOverlayImageGraphic ownerGraphic) : base(ownerGraphic) {}

				/// <summary>
				/// Cloning constructor.
				/// </summary>
				/// <param name="source">The source object from which to clone.</param>
				/// <param name="context">The cloning context object.</param>
				protected XSpatialTransform(XSpatialTransform source, ICloningContext context) : base(source, context)
				{
					context.CloneFields(source, this);
				}

				private new FusionOverlayImageGraphic OwnerGraphic
				{
					get { return (FusionOverlayImageGraphic) base.OwnerGraphic; }
				}

				protected override void UpdateScaleParameters()
				{
					var overlayFrameParams = OwnerGraphic._overlayFrameData.FusionOverlayFrameData._overlayFrameParams;
					ScaleX = overlayFrameParams.CoregistrationScale.X;
					ScaleY = overlayFrameParams.CoregistrationScale.Y;
					TranslationX = overlayFrameParams.CoregistrationOffset.X;
					TranslationY = overlayFrameParams.CoregistrationOffset.Y;
				}
			}

			// ReSharper restore UnusedMember.Local
			// ReSharper restore SuggestBaseTypeForParameter

			#endregion
		}

		#endregion
	}
}