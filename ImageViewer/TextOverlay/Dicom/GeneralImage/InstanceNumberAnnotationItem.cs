using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.ImageViewer.Imaging;
using ClearCanvas.Dicom;
using ClearCanvas.Dicom.OffisWrapper;

namespace ClearCanvas.ImageViewer.TextOverlay.Dicom.GeneralImage
{
	internal class InstanceNumberAnnotationItem : DicomStringAnnotationItem
	{
		public InstanceNumberAnnotationItem(IAnnotationItemProvider ownerProvider)
			: base("GeneralImage.InstanceNumber", ownerProvider)
		{
		}

		protected override void GetStoredDicomValue(DicomPresentationImage dicomPresentationImage, out string dicomValue, out bool storedValueExists)
		{
			storedValueExists = true;
			dicomValue = dicomPresentationImage.ImageSop.InstanceNumber;
		}

		protected override DcmTagKey DicomTag
		{
			get { return Dcm.InstanceNumber; }
		}
	}
}
