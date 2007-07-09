using System;
using System.Collections;
using System.Collections.Generic;

namespace ClearCanvas.ImageServer.Dicom
{
    /// <summary>
    /// This structure contains defines for all DICOM tags.
    /// </summary>
    public struct DicomTags
    {
        /// <summary>
        /// <para>(0000,0002) Affected SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint AffectedSOPClassUID = 2;
        /// <summary>
        /// <para>(0000,0003) Requested SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint RequestedSOPClassUID = 3;
        /// <summary>
        /// <para>(0000,0100) Command Field</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint CommandField = 256;
        /// <summary>
        /// <para>(0000,0110) Message ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MessageID = 272;
        /// <summary>
        /// <para>(0000,0120) Message ID Being Responded To</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MessageIDBeingRespondedTo = 288;
        /// <summary>
        /// <para>(0000,0600) Move Destination</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint MoveDestination = 1536;
        /// <summary>
        /// <para>(0000,0700) Priority</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Priority = 1792;
        /// <summary>
        /// <para>(0000,0800) Data Set Type</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint DataSetType = 2048;
        /// <summary>
        /// <para>(0000,0900) Status</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Status = 2304;
        /// <summary>
        /// <para>(0000,0901) Offending Element</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint OffendingElement = 2305;
        /// <summary>
        /// <para>(0000,0902) Error Comment</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ErrorComment = 2306;
        /// <summary>
        /// <para>(0000,0903) Error ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ErrorID = 2307;
        /// <summary>
        /// <para>(0000,1000) Affected SOP Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint AffectedSOPInstanceUID = 4096;
        /// <summary>
        /// <para>(0000,1001) Requested SOP Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint RequestedSOPInstanceUID = 4097;
        /// <summary>
        /// <para>(0000,1002) Event Type ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint EventTypeID = 4098;
        /// <summary>
        /// <para>(0000,1005) Attribute Identifier List</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint AttributeIdentifierList = 4101;
        /// <summary>
        /// <para>(0000,1008) Action Type ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ActionTypeID = 4104;
        /// <summary>
        /// <para>(0000,1020) Number of Remaining Sub-operations</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofRemainingSuboperations = 4128;
        /// <summary>
        /// <para>(0000,1021) Number of Completed Sub-operations</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofCompletedSuboperations = 4129;
        /// <summary>
        /// <para>(0000,1022) Number of Failed Sub-operations</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofFailedSuboperations = 4130;
        /// <summary>
        /// <para>(0000,1023) Number of Warning Sub-operations</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofWarningSuboperations = 4131;
        /// <summary>
        /// <para>(0000,1030) Move Originator Application Entity Title</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint MoveOriginatorApplicationEntityTitle = 4144;
        /// <summary>
        /// <para>(0000,1031) Move Originator Message ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MoveOriginatorMessageID = 4145;
        /// <summary>
        /// <para>(0002,0000) Group 2 Length</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint Group2Length = 131072;
        /// <summary>
        /// <para>(0002,0001) File Meta Information Version</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint FileMetaInformationVersion = 131073;
        /// <summary>
        /// <para>(0002,0002) Media Storage SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint MediaStorageSOPClassUID = 131074;
        /// <summary>
        /// <para>(0002,0003) Media Storage SOP Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint MediaStorageSOPInstanceUID = 131075;
        /// <summary>
        /// <para>(0002,0010) Transfer Syntax UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint TransferSyntaxUID = 131088;
        /// <summary>
        /// <para>(0002,0012) Implementation Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ImplementationClassUID = 131090;
        /// <summary>
        /// <para>(0002,0013) Implementation Version Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ImplementationVersionName = 131091;
        /// <summary>
        /// <para>(0002,0016) Source Application Entity Title</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint SourceApplicationEntityTitle = 131094;
        /// <summary>
        /// <para>(0002,0100) Private Information Creator UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint PrivateInformationCreatorUID = 131328;
        /// <summary>
        /// <para>(0002,0102) Private Information</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint PrivateInformation = 131330;
        /// <summary>
        /// <para>(0004,1130) File-set ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilesetID = 266544;
        /// <summary>
        /// <para>(0004,1141) File-set Descriptor File ID</para>
        /// <para> VR: CS VM:1-8</para>
        /// </summary>
        public const uint FilesetDescriptorFileID = 266561;
        /// <summary>
        /// <para>(0004,1142) Specific Character Set of File-set Descriptor File</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpecificCharacterSetofFilesetDescriptorFile = 266562;
        /// <summary>
        /// <para>(0004,1200) Offset of the First Directory Record of the Root Directory Entity</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint OffsetoftheFirstDirectoryRecordoftheRootDirectoryEntity = 266752;
        /// <summary>
        /// <para>(0004,1202) Offset of the Last Directory Record of the Root Directory Entity</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint OffsetoftheLastDirectoryRecordoftheRootDirectoryEntity = 266754;
        /// <summary>
        /// <para>(0004,1212) File-set Consistency Flag</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint FilesetConsistencyFlag = 266770;
        /// <summary>
        /// <para>(0004,1220) Directory Record Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DirectoryRecordSequence = 266784;
        /// <summary>
        /// <para>(0004,1400) Offset of the Next Directory Record</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint OffsetoftheNextDirectoryRecord = 267264;
        /// <summary>
        /// <para>(0004,1410) Record In-use Flag</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RecordInuseFlag = 267280;
        /// <summary>
        /// <para>(0004,1420) Offset of Referenced Lower-Level Directory Entity</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint OffsetofReferencedLowerLevelDirectoryEntity = 267296;
        /// <summary>
        /// <para>(0004,1430) Directory Record Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DirectoryRecordType = 267312;
        /// <summary>
        /// <para>(0004,1432) Private Record UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint PrivateRecordUID = 267314;
        /// <summary>
        /// <para>(0004,1500) Referenced File ID</para>
        /// <para> VR: CS VM:1-8</para>
        /// </summary>
        public const uint ReferencedFileID = 267520;
        /// <summary>
        /// <para>(0004,1504) MRDR Directory Record Offset</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MRDRDirectoryRecordOffsetRetired = 267524;
        /// <summary>
        /// <para>(0004,1510) Referenced SOP Class UID in File</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedSOPClassUIDinFile = 267536;
        /// <summary>
        /// <para>(0004,1511) Referenced SOP Instance UID in File</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedSOPInstanceUIDinFile = 267537;
        /// <summary>
        /// <para>(0004,1512) Referenced Transfer Syntax UID in File</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedTransferSyntaxUIDinFile = 267538;
        /// <summary>
        /// <para>(0004,151A) Referenced Related General SOP Class UID in File</para>
        /// <para> VR: UI VM:1-n</para>
        /// </summary>
        public const uint ReferencedRelatedGeneralSOPClassUIDinFile = 267546;
        /// <summary>
        /// <para>(0004,1600) Number of References</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NumberofReferencesRetired = 267776;
        /// <summary>
        /// <para>(0008,0001) Length to End</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LengthtoEndRetired = 524289;
        /// <summary>
        /// <para>(0008,0005) Specific Character Set</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint SpecificCharacterSet = 524293;
        /// <summary>
        /// <para>(0008,0008) Image Type</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ImageType = 524296;
        /// <summary>
        /// <para>(0008,0010) Recognition Code</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint RecognitionCodeRetired = 524304;
        /// <summary>
        /// <para>(0008,0012) Instance Creation Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint InstanceCreationDate = 524306;
        /// <summary>
        /// <para>(0008,0013) Instance Creation Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint InstanceCreationTime = 524307;
        /// <summary>
        /// <para>(0008,0014) Instance Creator UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint InstanceCreatorUID = 524308;
        /// <summary>
        /// <para>(0008,0016) SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint SOPClassUID = 524310;
        /// <summary>
        /// <para>(0008,0018) SOP Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint SOPInstanceUID = 524312;
        /// <summary>
        /// <para>(0008,001A) Related General SOP Class UID</para>
        /// <para> VR: UI VM:1-n</para>
        /// </summary>
        public const uint RelatedGeneralSOPClassUID = 524314;
        /// <summary>
        /// <para>(0008,001B) Original Specialized SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint OriginalSpecializedSOPClassUID = 524315;
        /// <summary>
        /// <para>(0008,0020) Study Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint StudyDate = 524320;
        /// <summary>
        /// <para>(0008,0021) Series Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint SeriesDate = 524321;
        /// <summary>
        /// <para>(0008,0022) Acquisition Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint AcquisitionDate = 524322;
        /// <summary>
        /// <para>(0008,0023) Content Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint ContentDate = 524323;
        /// <summary>
        /// <para>(0008,0024) Overlay Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayDateRetired = 524324;
        /// <summary>
        /// <para>(0008,0025) Curve Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveDateRetired = 524325;
        /// <summary>
        /// <para>(0008,002A) Acquisition Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint AcquisitionDatetime = 524330;
        /// <summary>
        /// <para>(0008,0030) Study Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint StudyTime = 524336;
        /// <summary>
        /// <para>(0008,0031) Series Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint SeriesTime = 524337;
        /// <summary>
        /// <para>(0008,0032) Acquisition Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint AcquisitionTime = 524338;
        /// <summary>
        /// <para>(0008,0033) Content Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ContentTime = 524339;
        /// <summary>
        /// <para>(0008,0034) Overlay Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayTimeRetired = 524340;
        /// <summary>
        /// <para>(0008,0035) Curve Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveTimeRetired = 524341;
        /// <summary>
        /// <para>(0008,0040) Data Set Type</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DataSetTypeRetired = 524352;
        /// <summary>
        /// <para>(0008,0041) Data Set Subtype</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DataSetSubtypeRetired = 524353;
        /// <summary>
        /// <para>(0008,0042) Nuclear Medicine Series Type</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NuclearMedicineSeriesTypeRetired = 524354;
        /// <summary>
        /// <para>(0008,0050) Accession Number</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint AccessionNumber = 524368;
        /// <summary>
        /// <para>(0008,0052) Query/Retrieve Level</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint QueryRetrieveLevel = 524370;
        /// <summary>
        /// <para>(0008,0054) Retrieve AE Title</para>
        /// <para> VR: AE VM:1-n</para>
        /// </summary>
        public const uint RetrieveAETitle = 524372;
        /// <summary>
        /// <para>(0008,0056) Instance Availability</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint InstanceAvailability = 524374;
        /// <summary>
        /// <para>(0008,0058) Failed SOP Instance UID List</para>
        /// <para> VR: UI VM:1-n</para>
        /// </summary>
        public const uint FailedSOPInstanceUIDList = 524376;
        /// <summary>
        /// <para>(0008,0060) Modality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Modality = 524384;
        /// <summary>
        /// <para>(0008,0061) Modalities in Study</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ModalitiesinStudy = 524385;
        /// <summary>
        /// <para>(0008,0062) SOP Classes in Study</para>
        /// <para> VR: UI VM:1-n</para>
        /// </summary>
        public const uint SOPClassesinStudy = 524386;
        /// <summary>
        /// <para>(0008,0064) Conversion Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ConversionType = 524388;
        /// <summary>
        /// <para>(0008,0068) Presentation Intent Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PresentationIntentType = 524392;
        /// <summary>
        /// <para>(0008,0070) Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint Manufacturer = 524400;
        /// <summary>
        /// <para>(0008,0080) Institution Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint InstitutionName = 524416;
        /// <summary>
        /// <para>(0008,0081) Institution Address</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint InstitutionAddress = 524417;
        /// <summary>
        /// <para>(0008,0082) Institution Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint InstitutionCodeSequence = 524418;
        /// <summary>
        /// <para>(0008,0090) Referring Physician’s Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ReferringPhysiciansName = 524432;
        /// <summary>
        /// <para>(0008,0092) Referring Physician's Address</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ReferringPhysiciansAddress = 524434;
        /// <summary>
        /// <para>(0008,0094) Referring Physician’s Telephone Numbers</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint ReferringPhysiciansTelephoneNumbers = 524436;
        /// <summary>
        /// <para>(0008,0096) Referring Physician Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferringPhysicianIdentificationSequence = 524438;
        /// <summary>
        /// <para>(0008,0100) Code Value</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint CodeValue = 524544;
        /// <summary>
        /// <para>(0008,0102) Coding Scheme Designator</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint CodingSchemeDesignator = 524546;
        /// <summary>
        /// <para>(0008,0103) Coding Scheme Version</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint CodingSchemeVersion = 524547;
        /// <summary>
        /// <para>(0008,0104) Code Meaning</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CodeMeaning = 524548;
        /// <summary>
        /// <para>(0008,0105) Mapping Resource</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MappingResource = 524549;
        /// <summary>
        /// <para>(0008,0106) Context Group Version</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ContextGroupVersion = 524550;
        /// <summary>
        /// <para>(0008,0107) Context Group Local Version</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ContextGroupLocalVersion = 524551;
        /// <summary>
        /// <para>(0008,010B) Context Group Extension Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContextGroupExtensionFlag = 524555;
        /// <summary>
        /// <para>(0008,010C) Coding Scheme UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint CodingSchemeUID = 524556;
        /// <summary>
        /// <para>(0008,010D) Context Group Extension Creator UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ContextGroupExtensionCreatorUID = 524557;
        /// <summary>
        /// <para>(0008,010F) Context Identifier</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContextIdentifier = 524559;
        /// <summary>
        /// <para>(0008,0110) Coding Scheme Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CodingSchemeIdentificationSequence = 524560;
        /// <summary>
        /// <para>(0008,0112) Coding Scheme Registry</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CodingSchemeRegistry = 524562;
        /// <summary>
        /// <para>(0008,0114) Coding Scheme External ID</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint CodingSchemeExternalID = 524564;
        /// <summary>
        /// <para>(0008,0115) Coding Scheme Name</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint CodingSchemeName = 524565;
        /// <summary>
        /// <para>(0008,0116) Responsible Organization</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ResponsibleOrganization = 524566;
        /// <summary>
        /// <para>(0008,0201) Timezone Offset From UTC</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint TimezoneOffsetFromUTC = 524801;
        /// <summary>
        /// <para>(0008,1000) Network ID</para>
        /// <para> VR: AE VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NetworkIDRetired = 528384;
        /// <summary>
        /// <para>(0008,1010) Station Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StationName = 528400;
        /// <summary>
        /// <para>(0008,1030) Study Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint StudyDescription = 528432;
        /// <summary>
        /// <para>(0008,1032) Procedure Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ProcedureCodeSequence = 528434;
        /// <summary>
        /// <para>(0008,103E) Series Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SeriesDescription = 528446;
        /// <summary>
        /// <para>(0008,1040) Institutional Department Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint InstitutionalDepartmentName = 528448;
        /// <summary>
        /// <para>(0008,1048) Physician(s) of Record</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint PhysiciansofRecord = 528456;
        /// <summary>
        /// <para>(0008,1049) Physician(s) of Record Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PhysiciansofRecordIdentificationSequence = 528457;
        /// <summary>
        /// <para>(0008,1050) Performing Physician’s Name</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint PerformingPhysiciansName = 528464;
        /// <summary>
        /// <para>(0008,1052) Performing Physician Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformingPhysicianIdentificationSequence = 528466;
        /// <summary>
        /// <para>(0008,1060) Name of  Physician(s) Reading Study</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint NameofPhysiciansReadingStudy = 528480;
        /// <summary>
        /// <para>(0008,1062) Physician(s) Reading Study Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PhysiciansReadingStudyIdentificationSequence = 528482;
        /// <summary>
        /// <para>(0008,1070) Operators’ Name</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint OperatorsName = 528496;
        /// <summary>
        /// <para>(0008,1072) Operator Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OperatorIdentificationSequence = 528498;
        /// <summary>
        /// <para>(0008,1080) Admitting Diagnoses Description</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint AdmittingDiagnosesDescription = 528512;
        /// <summary>
        /// <para>(0008,1084) Admitting Diagnoses Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AdmittingDiagnosesCodeSequence = 528516;
        /// <summary>
        /// <para>(0008,1090) Manufacturer’s Model Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ManufacturersModelName = 528528;
        /// <summary>
        /// <para>(0008,1100) Referenced Results Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedResultsSequenceRetired = 528640;
        /// <summary>
        /// <para>(0008,1110) Referenced Study Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedStudySequence = 528656;
        /// <summary>
        /// <para>(0008,1111) Referenced Performed Procedure Step Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedPerformedProcedureStepSequence = 528657;
        /// <summary>
        /// <para>(0008,1115) Referenced Series Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedSeriesSequence = 528661;
        /// <summary>
        /// <para>(0008,1120) Referenced Patient Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedPatientSequence = 528672;
        /// <summary>
        /// <para>(0008,1125) Referenced Visit Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedVisitSequence = 528677;
        /// <summary>
        /// <para>(0008,1130) Referenced Overlay Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedOverlaySequenceRetired = 528688;
        /// <summary>
        /// <para>(0008,113A) Referenced Waveform Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedWaveformSequence = 528698;
        /// <summary>
        /// <para>(0008,1140) Referenced Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedImageSequence = 528704;
        /// <summary>
        /// <para>(0008,1145) Referenced Curve Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedCurveSequenceRetired = 528709;
        /// <summary>
        /// <para>(0008,114A) Referenced Instance Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedInstanceSequence = 528714;
        /// <summary>
        /// <para>(0008,114B) Referenced Real World Value Mapping Instance Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedRealWorldValueMappingInstanceSequence = 528715;
        /// <summary>
        /// <para>(0008,1150) Referenced SOP Class UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedSOPClassUID = 528720;
        /// <summary>
        /// <para>(0008,1155) Referenced SOP Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedSOPInstanceUID = 528725;
        /// <summary>
        /// <para>(0008,115A) SOP Classes Supported</para>
        /// <para> VR: UI VM:1-n</para>
        /// </summary>
        public const uint SOPClassesSupported = 528730;
        /// <summary>
        /// <para>(0008,1160) Referenced Frame Number</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint ReferencedFrameNumber = 528736;
        /// <summary>
        /// <para>(0008,1195) Transaction UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint TransactionUID = 528789;
        /// <summary>
        /// <para>(0008,1197) Failure Reason</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint FailureReason = 528791;
        /// <summary>
        /// <para>(0008,1198) Failed SOP Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FailedSOPSequence = 528792;
        /// <summary>
        /// <para>(0008,1199) Referenced SOP Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedSOPSequence = 528793;
        /// <summary>
        /// <para>(0008,1200) Studies Containing Other Referenced Instances Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint StudiesContainingOtherReferencedInstancesSequence = 528896;
        /// <summary>
        /// <para>(0008,1250) Related Series Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RelatedSeriesSequence = 528976;
        /// <summary>
        /// <para>(0008,2110) Lossy Image Compression</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LossyImageCompressionRetired = 532752;
        /// <summary>
        /// <para>(0008,2111) Derivation Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint DerivationDescription = 532753;
        /// <summary>
        /// <para>(0008,2112) Source Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceImageSequence = 532754;
        /// <summary>
        /// <para>(0008,2120) Stage Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StageName = 532768;
        /// <summary>
        /// <para>(0008,2122) Stage Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint StageNumber = 532770;
        /// <summary>
        /// <para>(0008,2124) Number of Stages</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofStages = 532772;
        /// <summary>
        /// <para>(0008,2127) View Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ViewName = 532775;
        /// <summary>
        /// <para>(0008,2128) View Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ViewNumber = 532776;
        /// <summary>
        /// <para>(0008,2129) Number of Event Timers</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofEventTimers = 532777;
        /// <summary>
        /// <para>(0008,212A) Number of Views in Stage</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofViewsinStage = 532778;
        /// <summary>
        /// <para>(0008,2130) Event Elapsed Time(s)</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint EventElapsedTimes = 532784;
        /// <summary>
        /// <para>(0008,2132) Event Timer Name(s)</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint EventTimerNames = 532786;
        /// <summary>
        /// <para>(0008,2142) Start Trim</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint StartTrim = 532802;
        /// <summary>
        /// <para>(0008,2143) Stop Trim</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint StopTrim = 532803;
        /// <summary>
        /// <para>(0008,2144) Recommended Display Frame Rate</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RecommendedDisplayFrameRate = 532804;
        /// <summary>
        /// <para>(0008,2200) Transducer Position</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerPositionRetired = 532992;
        /// <summary>
        /// <para>(0008,2204) Transducer Orientation</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerOrientationRetired = 532996;
        /// <summary>
        /// <para>(0008,2208) Anatomic Structure</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AnatomicStructureRetired = 533000;
        /// <summary>
        /// <para>(0008,2218) Anatomic Region Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AnatomicRegionSequence = 533016;
        /// <summary>
        /// <para>(0008,2220) Anatomic Region Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AnatomicRegionModifierSequence = 533024;
        /// <summary>
        /// <para>(0008,2228) Primary Anatomic Structure Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PrimaryAnatomicStructureSequence = 533032;
        /// <summary>
        /// <para>(0008,2229) Anatomic Structure, Space or Region Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AnatomicStructureSpaceorRegionSequence = 533033;
        /// <summary>
        /// <para>(0008,2230) Primary Anatomic Structure Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PrimaryAnatomicStructureModifierSequence = 533040;
        /// <summary>
        /// <para>(0008,2240) Transducer Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerPositionSequenceRetired = 533056;
        /// <summary>
        /// <para>(0008,2242) Transducer Position Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerPositionModifierSequenceRetired = 533058;
        /// <summary>
        /// <para>(0008,2244) Transducer Orientation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerOrientationSequenceRetired = 533060;
        /// <summary>
        /// <para>(0008,2246) Transducer Orientation Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TransducerOrientationModifierSequenceRetired = 533062;
        /// <summary>
        /// <para>(0008,3001) Alternate Representation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AlternateRepresentationSequence = 536577;
        /// <summary>
        /// <para>(0008,3010) Irradiation Event UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint IrradiationEventUID = 536592;
        /// <summary>
        /// <para>(0008,4000) Identifying Comments</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint IdentifyingCommentsRetired = 540672;
        /// <summary>
        /// <para>(0008,9007) Frame Type</para>
        /// <para> VR: CS VM:4</para>
        /// </summary>
        public const uint FrameType = 561159;
        /// <summary>
        /// <para>(0008,9092) Referenced Image Evidence Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedImageEvidenceSequence = 561298;
        /// <summary>
        /// <para>(0008,9121) Referenced Raw Data Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedRawDataSequence = 561441;
        /// <summary>
        /// <para>(0008,9123) Creator-Version UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint CreatorVersionUID = 561443;
        /// <summary>
        /// <para>(0008,9124) Derivation Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DerivationImageSequence = 561444;
        /// <summary>
        /// <para>(0008,9154) Source Image Evidence Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceImageEvidenceSequence = 561492;
        /// <summary>
        /// <para>(0008,9205) Pixel Presentation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PixelPresentation = 561669;
        /// <summary>
        /// <para>(0008,9206) Volumetric Properties</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VolumetricProperties = 561670;
        /// <summary>
        /// <para>(0008,9207) Volume Based Calculation Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VolumeBasedCalculationTechnique = 561671;
        /// <summary>
        /// <para>(0008,9208) Complex Image Component</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ComplexImageComponent = 561672;
        /// <summary>
        /// <para>(0008,9209) Acquisition Contrast</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AcquisitionContrast = 561673;
        /// <summary>
        /// <para>(0008,9215) Derivation Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DerivationCodeSequence = 561685;
        /// <summary>
        /// <para>(0008,9237) Referenced Grayscale Presentation State Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedGrayscalePresentationStateSequence = 561719;
        /// <summary>
        /// <para>(0008,9410) Referenced Other Plane Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedOtherPlaneSequence = 562192;
        /// <summary>
        /// <para>(0008,9458) Frame Display Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameDisplaySequence = 562264;
        /// <summary>
        /// <para>(0008,9459) Recommended Display Frame Rate in Float</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RecommendedDisplayFrameRateinFloat = 562265;
        /// <summary>
        /// <para>(0008,9460) Skip Frame Range Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SkipFrameRangeFlag = 562272;
        /// <summary>
        /// <para>(0010,0010) Patient’s Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint PatientsName = 1048592;
        /// <summary>
        /// <para>(0010,0020) Patient ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientID = 1048608;
        /// <summary>
        /// <para>(0010,0021) Issuer of Patient ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint IssuerofPatientID = 1048609;
        /// <summary>
        /// <para>(0010,0022) Type of Patient ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TypeofPatientID = 1048610;
        /// <summary>
        /// <para>(0010,0030) Patient's Birth Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint PatientsBirthDate = 1048624;
        /// <summary>
        /// <para>(0010,0032) Patient's Birth Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint PatientsBirthTime = 1048626;
        /// <summary>
        /// <para>(0010,0040) Patient's Sex</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientsSex = 1048640;
        /// <summary>
        /// <para>(0010,0050) Patient's Insurance Plan Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientsInsurancePlanCodeSequence = 1048656;
        /// <summary>
        /// <para>(0010,0101) Patient’s Primary Language Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientsPrimaryLanguageCodeSequence = 1048833;
        /// <summary>
        /// <para>(0010,0102) Patient’s Primary Language Code Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientsPrimaryLanguageCodeModifierSequence = 1048834;
        /// <summary>
        /// <para>(0010,1000) Other Patient IDs</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint OtherPatientIDs = 1052672;
        /// <summary>
        /// <para>(0010,1001) Other Patient Names</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint OtherPatientNames = 1052673;
        /// <summary>
        /// <para>(0010,1002) Other Patient IDs Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OtherPatientIDsSequence = 1052674;
        /// <summary>
        /// <para>(0010,1005) Patient's Birth Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint PatientsBirthName = 1052677;
        /// <summary>
        /// <para>(0010,1010) Patient's Age</para>
        /// <para> VR: AS VM:1</para>
        /// </summary>
        public const uint PatientsAge = 1052688;
        /// <summary>
        /// <para>(0010,1020) Patient's Size</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PatientsSize = 1052704;
        /// <summary>
        /// <para>(0010,1030) Patient's Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PatientsWeight = 1052720;
        /// <summary>
        /// <para>(0010,1040) Patient's Address</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientsAddress = 1052736;
        /// <summary>
        /// <para>(0010,1050) Insurance Plan Identification</para>
        /// <para> VR: LO VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InsurancePlanIdentificationRetired = 1052752;
        /// <summary>
        /// <para>(0010,1060) Patient's Mother's Birth Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint PatientsMothersBirthName = 1052768;
        /// <summary>
        /// <para>(0010,1080) Military Rank</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint MilitaryRank = 1052800;
        /// <summary>
        /// <para>(0010,1081) Branch of Service</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint BranchofService = 1052801;
        /// <summary>
        /// <para>(0010,1090) Medical Record Locator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint MedicalRecordLocator = 1052816;
        /// <summary>
        /// <para>(0010,2000) Medical Alerts</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint MedicalAlerts = 1056768;
        /// <summary>
        /// <para>(0010,2110) Contrast Allergies</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint ContrastAllergies = 1057040;
        /// <summary>
        /// <para>(0010,2150) Country of Residence</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CountryofResidence = 1057104;
        /// <summary>
        /// <para>(0010,2152) Region of Residence</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RegionofResidence = 1057106;
        /// <summary>
        /// <para>(0010,2154) Patient’s Telephone Numbers</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint PatientsTelephoneNumbers = 1057108;
        /// <summary>
        /// <para>(0010,2160) Ethnic Group</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint EthnicGroup = 1057120;
        /// <summary>
        /// <para>(0010,2180) Occupation</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint Occupation = 1057152;
        /// <summary>
        /// <para>(0010,21A0) Smoking Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SmokingStatus = 1057184;
        /// <summary>
        /// <para>(0010,21B0) Additional Patient History</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint AdditionalPatientHistory = 1057200;
        /// <summary>
        /// <para>(0010,21C0) Pregnancy Status</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PregnancyStatus = 1057216;
        /// <summary>
        /// <para>(0010,21D0) Last Menstrual Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint LastMenstrualDate = 1057232;
        /// <summary>
        /// <para>(0010,21F0) Patient's Religious Preference</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientsReligiousPreference = 1057264;
        /// <summary>
        /// <para>(0010,2201) Patient Species Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientSpeciesDescription = 1057281;
        /// <summary>
        /// <para>(0010,2202) Patient Species Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientSpeciesCodeSequence = 1057282;
        /// <summary>
        /// <para>(0010,2203) Patient’s Sex Neutered</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientsSexNeutered = 1057283;
        /// <summary>
        /// <para>(0010,2292) Patient Breed Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientBreedDescription = 1057426;
        /// <summary>
        /// <para>(0010,2293) Patient Breed Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientBreedCodeSequence = 1057427;
        /// <summary>
        /// <para>(0010,2294) Breed Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BreedRegistrationSequence = 1057428;
        /// <summary>
        /// <para>(0010,2295) Breed Registration Number</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint BreedRegistrationNumber = 1057429;
        /// <summary>
        /// <para>(0010,2296) Breed Registry Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BreedRegistryCodeSequence = 1057430;
        /// <summary>
        /// <para>(0010,2297) Responsible Person</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ResponsiblePerson = 1057431;
        /// <summary>
        /// <para>(0010,2298) Responsible Person Role</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ResponsiblePersonRole = 1057432;
        /// <summary>
        /// <para>(0010,2299) Responsible Organization</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint NewResponsibleOrganization = 1057433;
        /// <summary>
        /// <para>(0010,4000) Patient Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint PatientComments = 1064960;
        /// <summary>
        /// <para>(0010,9431) Examined Body Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint ExaminedBodyThickness = 1086513;
        /// <summary>
        /// <para>(0012,0010) Clinical Trial Sponsor Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialSponsorName = 1179664;
        /// <summary>
        /// <para>(0012,0020) Clinical Trial Protocol ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialProtocolID = 1179680;
        /// <summary>
        /// <para>(0012,0021) Clinical Trial Protocol Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialProtocolName = 1179681;
        /// <summary>
        /// <para>(0012,0030) Clinical Trial Site ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialSiteID = 1179696;
        /// <summary>
        /// <para>(0012,0031) Clinical Trial Site Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialSiteName = 1179697;
        /// <summary>
        /// <para>(0012,0040) Clinical Trial Subject ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialSubjectID = 1179712;
        /// <summary>
        /// <para>(0012,0042) Clinical Trial Subject Reading ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialSubjectReadingID = 1179714;
        /// <summary>
        /// <para>(0012,0050) Clinical Trial Time Point ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialTimePointID = 1179728;
        /// <summary>
        /// <para>(0012,0051) Clinical Trial Time Point Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ClinicalTrialTimePointDescription = 1179729;
        /// <summary>
        /// <para>(0012,0060) Clinical Trial Coordinating Center Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ClinicalTrialCoordinatingCenterName = 1179744;
        /// <summary>
        /// <para>(0012,0062) Patient Identity Removed</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientIdentityRemoved = 1179746;
        /// <summary>
        /// <para>(0012,0063) De-identification Method</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint DeidentificationMethod = 1179747;
        /// <summary>
        /// <para>(0012,0064) De-identification Method Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DeidentificationMethodCodeSequence = 1179748;
        /// <summary>
        /// <para>(0018,0010) Contrast/Bolus Agent</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgent = 1572880;
        /// <summary>
        /// <para>(0018,0012) Contrast/Bolus Agent Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgentSequence = 1572882;
        /// <summary>
        /// <para>(0018,0014) Contrast/Bolus Administration Route Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContrastBolusAdministrationRouteSequence = 1572884;
        /// <summary>
        /// <para>(0018,0015) Body Part Examined</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BodyPartExamined = 1572885;
        /// <summary>
        /// <para>(0018,0020) Scanning Sequence</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ScanningSequence = 1572896;
        /// <summary>
        /// <para>(0018,0021) Sequence Variant</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint SequenceVariant = 1572897;
        /// <summary>
        /// <para>(0018,0022) Scan Options</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ScanOptions = 1572898;
        /// <summary>
        /// <para>(0018,0023) MR Acquisition Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MRAcquisitionType = 1572899;
        /// <summary>
        /// <para>(0018,0024) Sequence Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint SequenceName = 1572900;
        /// <summary>
        /// <para>(0018,0025) Angio Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AngioFlag = 1572901;
        /// <summary>
        /// <para>(0018,0026) Intervention Drug Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint InterventionDrugInformationSequence = 1572902;
        /// <summary>
        /// <para>(0018,0027) Intervention Drug Stop Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint InterventionDrugStopTime = 1572903;
        /// <summary>
        /// <para>(0018,0028) Intervention Drug Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint InterventionDrugDose = 1572904;
        /// <summary>
        /// <para>(0018,0029) Intervention Drug Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint InterventionDrugSequence = 1572905;
        /// <summary>
        /// <para>(0018,002A) Additional Drug Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AdditionalDrugSequence = 1572906;
        /// <summary>
        /// <para>(0018,0030) Radionuclide</para>
        /// <para> VR: LO VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint RadionuclideRetired = 1572912;
        /// <summary>
        /// <para>(0018,0031) Radiopharmaceutical</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint Radiopharmaceutical = 1572913;
        /// <summary>
        /// <para>(0018,0032) Energy Window Centerline</para>
        /// <para> VR: DS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint EnergyWindowCenterlineRetired = 1572914;
        /// <summary>
        /// <para>(0018,0033) Energy Window Total Width</para>
        /// <para> VR: DS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint EnergyWindowTotalWidthRetired = 1572915;
        /// <summary>
        /// <para>(0018,0034) Intervention Drug Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint InterventionDrugName = 1572916;
        /// <summary>
        /// <para>(0018,0035) Intervention Drug Start Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint InterventionDrugStartTime = 1572917;
        /// <summary>
        /// <para>(0018,0036) Intervention Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint InterventionSequence = 1572918;
        /// <summary>
        /// <para>(0018,0037) Therapy Type</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TherapyTypeRetired = 1572919;
        /// <summary>
        /// <para>(0018,0038) Intervention Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint InterventionStatus = 1572920;
        /// <summary>
        /// <para>(0018,0039) Therapy Description</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TherapyDescriptionRetired = 1572921;
        /// <summary>
        /// <para>(0018,003A) Intervention Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint InterventionDescription = 1572922;
        /// <summary>
        /// <para>(0018,0040) Cine Rate </para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CineRate = 1572928;
        /// <summary>
        /// <para>(0018,0050) Slice Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SliceThickness = 1572944;
        /// <summary>
        /// <para>(0018,0060) KVP</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint KVP = 1572960;
        /// <summary>
        /// <para>(0018,0070) Counts Accumulated</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CountsAccumulated = 1572976;
        /// <summary>
        /// <para>(0018,0071) Acquisition Termination Condition</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AcquisitionTerminationCondition = 1572977;
        /// <summary>
        /// <para>(0018,0072) Effective Duration</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EffectiveDuration = 1572978;
        /// <summary>
        /// <para>(0018,0073) Acquisition Start Condition</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AcquisitionStartCondition = 1572979;
        /// <summary>
        /// <para>(0018,0074) Acquisition Start Condition Data</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint AcquisitionStartConditionData = 1572980;
        /// <summary>
        /// <para>(0018,0075) Acquisition Termination Condition Data</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint AcquisitionTerminationConditionData = 1572981;
        /// <summary>
        /// <para>(0018,0080) Repetition Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RepetitionTime = 1572992;
        /// <summary>
        /// <para>(0018,0081) Echo Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EchoTime = 1572993;
        /// <summary>
        /// <para>(0018,0082) Inversion Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint InversionTime = 1572994;
        /// <summary>
        /// <para>(0018,0083) Number of Averages</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint NumberofAverages = 1572995;
        /// <summary>
        /// <para>(0018,0084) Imaging Frequency</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ImagingFrequency = 1572996;
        /// <summary>
        /// <para>(0018,0085) Imaged Nucleus</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ImagedNucleus = 1572997;
        /// <summary>
        /// <para>(0018,0086) Echo Number(s)</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint EchoNumbers = 1572998;
        /// <summary>
        /// <para>(0018,0087) Magnetic Field Strength</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint MagneticFieldStrength = 1572999;
        /// <summary>
        /// <para>(0018,0088) Spacing Between Slices</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SpacingBetweenSlices = 1573000;
        /// <summary>
        /// <para>(0018,0089) Number of Phase Encoding Steps</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPhaseEncodingSteps = 1573001;
        /// <summary>
        /// <para>(0018,0090) Data Collection Diameter</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DataCollectionDiameter = 1573008;
        /// <summary>
        /// <para>(0018,0091) Echo Train Length</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint EchoTrainLength = 1573009;
        /// <summary>
        /// <para>(0018,0093) Percent Sampling</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PercentSampling = 1573011;
        /// <summary>
        /// <para>(0018,0094) Percent Phase Field of View</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PercentPhaseFieldofView = 1573012;
        /// <summary>
        /// <para>(0018,0095) Pixel Bandwidth</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PixelBandwidth = 1573013;
        /// <summary>
        /// <para>(0018,1000) Device Serial Number</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DeviceSerialNumber = 1576960;
        /// <summary>
        /// <para>(0018,1002) Device UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint DeviceUID = 1576962;
        /// <summary>
        /// <para>(0018,1003) Device ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DeviceID = 1576963;
        /// <summary>
        /// <para>(0018,1004) Plate ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PlateID = 1576964;
        /// <summary>
        /// <para>(0018,1005) Generator ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint GeneratorID = 1576965;
        /// <summary>
        /// <para>(0018,1006) Grid ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint GridID = 1576966;
        /// <summary>
        /// <para>(0018,1007) Cassette ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CassetteID = 1576967;
        /// <summary>
        /// <para>(0018,1008) Gantry ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint GantryID = 1576968;
        /// <summary>
        /// <para>(0018,1010) Secondary Capture Device ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SecondaryCaptureDeviceID = 1576976;
        /// <summary>
        /// <para>(0018,1011) Hardcopy Creation Device ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HardcopyCreationDeviceID = 1576977;
        /// <summary>
        /// <para>(0018,1012) Date of Secondary Capture</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint DateofSecondaryCapture = 1576978;
        /// <summary>
        /// <para>(0018,1014) Time of Secondary Capture</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint TimeofSecondaryCapture = 1576980;
        /// <summary>
        /// <para>(0018,1016) Secondary Capture Device Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SecondaryCaptureDeviceManufacturer = 1576982;
        /// <summary>
        /// <para>(0018,1017) Hardcopy Device Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HardcopyDeviceManufacturer = 1576983;
        /// <summary>
        /// <para>(0018,1018) Secondary Capture Device Manufacturer’s Model Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SecondaryCaptureDeviceManufacturersModelName = 1576984;
        /// <summary>
        /// <para>(0018,1019) Secondary Capture Device Software Version(s)</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint SecondaryCaptureDeviceSoftwareVersions = 1576985;
        /// <summary>
        /// <para>(0018,101A) Hardcopy Device Software Version</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint HardcopyDeviceSoftwareVersion = 1576986;
        /// <summary>
        /// <para>(0018,101B) Hardcopy Device Manufacturer's Model Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HardcopyDeviceManufacturersModelName = 1576987;
        /// <summary>
        /// <para>(0018,1020) Software Version(s)</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint SoftwareVersions = 1576992;
        /// <summary>
        /// <para>(0018,1022) Video Image Format Acquired</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint VideoImageFormatAcquired = 1576994;
        /// <summary>
        /// <para>(0018,1023) Digital Image Format Acquired</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DigitalImageFormatAcquired = 1576995;
        /// <summary>
        /// <para>(0018,1030) Protocol Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ProtocolName = 1577008;
        /// <summary>
        /// <para>(0018,1040) Contrast/Bolus Route</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ContrastBolusRoute = 1577024;
        /// <summary>
        /// <para>(0018,1041) Contrast/Bolus Volume</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ContrastBolusVolume = 1577025;
        /// <summary>
        /// <para>(0018,1042) Contrast/Bolus Start Time </para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ContrastBolusStartTime = 1577026;
        /// <summary>
        /// <para>(0018,1043) Contrast/Bolus Stop Time </para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ContrastBolusStopTime = 1577027;
        /// <summary>
        /// <para>(0018,1044) Contrast/Bolus Total Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ContrastBolusTotalDose = 1577028;
        /// <summary>
        /// <para>(0018,1045) Syringe Counts</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint SyringeCounts = 1577029;
        /// <summary>
        /// <para>(0018,1046) Contrast Flow Rate</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint ContrastFlowRate = 1577030;
        /// <summary>
        /// <para>(0018,1047) Contrast Flow Duration</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint ContrastFlowDuration = 1577031;
        /// <summary>
        /// <para>(0018,1048) Contrast/Bolus Ingredient</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContrastBolusIngredient = 1577032;
        /// <summary>
        /// <para>(0018,1049) Contrast/Bolus Ingredient Concentration</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ContrastBolusIngredientConcentration = 1577033;
        /// <summary>
        /// <para>(0018,1050) Spatial Resolution</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SpatialResolution = 1577040;
        /// <summary>
        /// <para>(0018,1060) Trigger Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TriggerTime = 1577056;
        /// <summary>
        /// <para>(0018,1061) Trigger Source or Type</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TriggerSourceorType = 1577057;
        /// <summary>
        /// <para>(0018,1062) Nominal Interval</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NominalInterval = 1577058;
        /// <summary>
        /// <para>(0018,1063) Frame Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FrameTime = 1577059;
        /// <summary>
        /// <para>(0018,1064) Framing Type</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FramingType = 1577060;
        /// <summary>
        /// <para>(0018,1065) Frame Time Vector</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FrameTimeVector = 1577061;
        /// <summary>
        /// <para>(0018,1066) Frame Delay</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FrameDelay = 1577062;
        /// <summary>
        /// <para>(0018,1067) Image Trigger Delay</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ImageTriggerDelay = 1577063;
        /// <summary>
        /// <para>(0018,1068) Multiplex Group Time Offset</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint MultiplexGroupTimeOffset = 1577064;
        /// <summary>
        /// <para>(0018,1069) Trigger Time Offset</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TriggerTimeOffset = 1577065;
        /// <summary>
        /// <para>(0018,106A) Synchronization Trigger</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SynchronizationTrigger = 1577066;
        /// <summary>
        /// <para>(0018,106C) Synchronization Channel</para>
        /// <para> VR: US VM:2</para>
        /// </summary>
        public const uint SynchronizationChannel = 1577068;
        /// <summary>
        /// <para>(0018,106E) Trigger Sample Position</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint TriggerSamplePosition = 1577070;
        /// <summary>
        /// <para>(0018,1070) Radiopharmaceutical Route</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalRoute = 1577072;
        /// <summary>
        /// <para>(0018,1071) Radiopharmaceutical Volume</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalVolume = 1577073;
        /// <summary>
        /// <para>(0018,1072) Radiopharmaceutical Start Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalStartTime = 1577074;
        /// <summary>
        /// <para>(0018,1073) Radiopharmaceutical Stop Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalStopTime = 1577075;
        /// <summary>
        /// <para>(0018,1074) Radionuclide Total Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadionuclideTotalDose = 1577076;
        /// <summary>
        /// <para>(0018,1075) Radionuclide Half Life</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadionuclideHalfLife = 1577077;
        /// <summary>
        /// <para>(0018,1076) Radionuclide Positron Fraction</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadionuclidePositronFraction = 1577078;
        /// <summary>
        /// <para>(0018,1077) Radiopharmaceutical Specific Activity</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalSpecificActivity = 1577079;
        /// <summary>
        /// <para>(0018,1078) Radiopharmaceutical Start Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalStartDatetime = 1577080;
        /// <summary>
        /// <para>(0018,1079) Radiopharmaceutical Stop Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalStopDatetime = 1577081;
        /// <summary>
        /// <para>(0018,1080) Beat Rejection Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BeatRejectionFlag = 1577088;
        /// <summary>
        /// <para>(0018,1081) Low R-R Value</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint LowRRValue = 1577089;
        /// <summary>
        /// <para>(0018,1082) High R-R Value</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint HighRRValue = 1577090;
        /// <summary>
        /// <para>(0018,1083) Intervals Acquired</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint IntervalsAcquired = 1577091;
        /// <summary>
        /// <para>(0018,1084) Intervals Rejected</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint IntervalsRejected = 1577092;
        /// <summary>
        /// <para>(0018,1085) PVC Rejection</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PVCRejection = 1577093;
        /// <summary>
        /// <para>(0018,1086) Skip Beats</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint SkipBeats = 1577094;
        /// <summary>
        /// <para>(0018,1088) Heart Rate</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint HeartRate = 1577096;
        /// <summary>
        /// <para>(0018,1090) Cardiac Number of Images</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CardiacNumberofImages = 1577104;
        /// <summary>
        /// <para>(0018,1094) Trigger Window</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint TriggerWindow = 1577108;
        /// <summary>
        /// <para>(0018,1100) Reconstruction Diameter</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ReconstructionDiameter = 1577216;
        /// <summary>
        /// <para>(0018,1110) Distance Source to Detector</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DistanceSourcetoDetector = 1577232;
        /// <summary>
        /// <para>(0018,1111) Distance Source to Patient</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DistanceSourcetoPatient = 1577233;
        /// <summary>
        /// <para>(0018,1114) Estimated Radiographic Magnification Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EstimatedRadiographicMagnificationFactor = 1577236;
        /// <summary>
        /// <para>(0018,1120) Gantry/Detector Tilt</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GantryDetectorTilt = 1577248;
        /// <summary>
        /// <para>(0018,1121) Gantry/Detector Slew</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GantryDetectorSlew = 1577249;
        /// <summary>
        /// <para>(0018,1130) Table Height</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableHeight = 1577264;
        /// <summary>
        /// <para>(0018,1131) Table Traverse</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTraverse = 1577265;
        /// <summary>
        /// <para>(0018,1134) Table Motion</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TableMotion = 1577268;
        /// <summary>
        /// <para>(0018,1135) Table Vertical Increment</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint TableVerticalIncrement = 1577269;
        /// <summary>
        /// <para>(0018,1136) Table Lateral Increment</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint TableLateralIncrement = 1577270;
        /// <summary>
        /// <para>(0018,1137) Table Longitudinal Increment</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint TableLongitudinalIncrement = 1577271;
        /// <summary>
        /// <para>(0018,1138) Table Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableAngle = 1577272;
        /// <summary>
        /// <para>(0018,113A) Table Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TableType = 1577274;
        /// <summary>
        /// <para>(0018,1140) Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RotationDirection = 1577280;
        /// <summary>
        /// <para>(0018,1141) Angular Position</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint AngularPosition = 1577281;
        /// <summary>
        /// <para>(0018,1142) Radial Position</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint RadialPosition = 1577282;
        /// <summary>
        /// <para>(0018,1143) Scan Arc</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ScanArc = 1577283;
        /// <summary>
        /// <para>(0018,1144) Angular Step</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint AngularStep = 1577284;
        /// <summary>
        /// <para>(0018,1145) Center of Rotation Offset</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CenterofRotationOffset = 1577285;
        /// <summary>
        /// <para>(0018,1146) Rotation Offset</para>
        /// <para> VR: DS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint RotationOffsetRetired = 1577286;
        /// <summary>
        /// <para>(0018,1147) Field of View Shape</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FieldofViewShape = 1577287;
        /// <summary>
        /// <para>(0018,1149) Field of View Dimension(s)</para>
        /// <para> VR: IS VM:1-2</para>
        /// </summary>
        public const uint FieldofViewDimensions = 1577289;
        /// <summary>
        /// <para>(0018,1150) Exposure Time</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ExposureTime = 1577296;
        /// <summary>
        /// <para>(0018,1151) X-ray Tube Current</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint XrayTubeCurrent = 1577297;
        /// <summary>
        /// <para>(0018,1152) Exposure </para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint Exposure = 1577298;
        /// <summary>
        /// <para>(0018,1153) Exposure in uAs</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ExposureinuAs = 1577299;
        /// <summary>
        /// <para>(0018,1154) Average Pulse Width</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint AveragePulseWidth = 1577300;
        /// <summary>
        /// <para>(0018,1155) Radiation Setting</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RadiationSetting = 1577301;
        /// <summary>
        /// <para>(0018,1156)  Rectification Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RectificationType = 1577302;
        /// <summary>
        /// <para>(0018,115A) Radiation Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RadiationMode = 1577306;
        /// <summary>
        /// <para>(0018,115E) Image and Fluoroscopy Area Dose Product</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ImageandFluoroscopyAreaDoseProduct = 1577310;
        /// <summary>
        /// <para>(0018,1160) Filter Type</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint FilterType = 1577312;
        /// <summary>
        /// <para>(0018,1161) Type of Filters</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint TypeofFilters = 1577313;
        /// <summary>
        /// <para>(0018,1162) Intensifier Size</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint IntensifierSize = 1577314;
        /// <summary>
        /// <para>(0018,1164) Imager Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint ImagerPixelSpacing = 1577316;
        /// <summary>
        /// <para>(0018,1166) Grid</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint Grid = 1577318;
        /// <summary>
        /// <para>(0018,1170) Generator Power</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint GeneratorPower = 1577328;
        /// <summary>
        /// <para>(0018,1180) Collimator/grid Name </para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint CollimatorgridName = 1577344;
        /// <summary>
        /// <para>(0018,1181) Collimator Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CollimatorType = 1577345;
        /// <summary>
        /// <para>(0018,1182) Focal Distance</para>
        /// <para> VR: IS VM:1-2</para>
        /// </summary>
        public const uint FocalDistance = 1577346;
        /// <summary>
        /// <para>(0018,1183) X Focus Center</para>
        /// <para> VR: DS VM:1-2</para>
        /// </summary>
        public const uint XFocusCenter = 1577347;
        /// <summary>
        /// <para>(0018,1184) Y Focus Center</para>
        /// <para> VR: DS VM:1-2</para>
        /// </summary>
        public const uint YFocusCenter = 1577348;
        /// <summary>
        /// <para>(0018,1190) Focal Spot(s)</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FocalSpots = 1577360;
        /// <summary>
        /// <para>(0018,1191) Anode Target Material</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AnodeTargetMaterial = 1577361;
        /// <summary>
        /// <para>(0018,11A0) Body Part Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BodyPartThickness = 1577376;
        /// <summary>
        /// <para>(0018,11A2) Compression Force</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CompressionForce = 1577378;
        /// <summary>
        /// <para>(0018,1200) Date of Last Calibration</para>
        /// <para> VR: DA VM:1-n</para>
        /// </summary>
        public const uint DateofLastCalibration = 1577472;
        /// <summary>
        /// <para>(0018,1201) Time of Last Calibration</para>
        /// <para> VR: TM VM:1-n</para>
        /// </summary>
        public const uint TimeofLastCalibration = 1577473;
        /// <summary>
        /// <para>(0018,1210) Convolution Kernel</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint ConvolutionKernel = 1577488;
        /// <summary>
        /// <para>(0018,1240) Upper/Lower Pixel Values</para>
        /// <para> VR: IS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint UpperLowerPixelValuesRetired = 1577536;
        /// <summary>
        /// <para>(0018,1242) Actual Frame Duration</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ActualFrameDuration = 1577538;
        /// <summary>
        /// <para>(0018,1243) Count Rate</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CountRate = 1577539;
        /// <summary>
        /// <para>(0018,1244) Preferred Playback Sequencing</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PreferredPlaybackSequencing = 1577540;
        /// <summary>
        /// <para>(0018,1250) Receive Coil Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ReceiveCoilName = 1577552;
        /// <summary>
        /// <para>(0018,1251) Transmit Coil Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint TransmitCoilName = 1577553;
        /// <summary>
        /// <para>(0018,1260) Plate Type</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PlateType = 1577568;
        /// <summary>
        /// <para>(0018,1261) Phosphor Type</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PhosphorType = 1577569;
        /// <summary>
        /// <para>(0018,1300) Scan Velocity</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ScanVelocity = 1577728;
        /// <summary>
        /// <para>(0018,1301) Whole Body Technique</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint WholeBodyTechnique = 1577729;
        /// <summary>
        /// <para>(0018,1302) Scan Length</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ScanLength = 1577730;
        /// <summary>
        /// <para>(0018,1310) Acquisition Matrix</para>
        /// <para> VR: US VM:4</para>
        /// </summary>
        public const uint AcquisitionMatrix = 1577744;
        /// <summary>
        /// <para>(0018,1312) In-plane Phase Encoding Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint InplanePhaseEncodingDirection = 1577746;
        /// <summary>
        /// <para>(0018,1314) Flip Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FlipAngle = 1577748;
        /// <summary>
        /// <para>(0018,1315) Variable Flip Angle Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VariableFlipAngleFlag = 1577749;
        /// <summary>
        /// <para>(0018,1316) SAR</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SAR = 1577750;
        /// <summary>
        /// <para>(0018,1318) dB/dt</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint dBdt = 1577752;
        /// <summary>
        /// <para>(0018,1400) Acquisition Device Processing Description </para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AcquisitionDeviceProcessingDescription = 1577984;
        /// <summary>
        /// <para>(0018,1401) Acquisition Device Processing Code</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AcquisitionDeviceProcessingCode = 1577985;
        /// <summary>
        /// <para>(0018,1402) Cassette Orientation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CassetteOrientation = 1577986;
        /// <summary>
        /// <para>(0018,1403) Cassette Size</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CassetteSize = 1577987;
        /// <summary>
        /// <para>(0018,1404) Exposures on Plate</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ExposuresonPlate = 1577988;
        /// <summary>
        /// <para>(0018,1405) Relative X-ray Exposure</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RelativeXrayExposure = 1577989;
        /// <summary>
        /// <para>(0018,1450) Column Angulation</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ColumnAngulation = 1578064;
        /// <summary>
        /// <para>(0018,1460) Tomo Layer Height</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TomoLayerHeight = 1578080;
        /// <summary>
        /// <para>(0018,1470) Tomo Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TomoAngle = 1578096;
        /// <summary>
        /// <para>(0018,1480) Tomo Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TomoTime = 1578112;
        /// <summary>
        /// <para>(0018,1490) Tomo Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TomoType = 1578128;
        /// <summary>
        /// <para>(0018,1491) Tomo Class</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TomoClass = 1578129;
        /// <summary>
        /// <para>(0018,1495) Number of Tomosynthesis Source Images</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofTomosynthesisSourceImages = 1578133;
        /// <summary>
        /// <para>(0018,1500) Positioner Motion</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PositionerMotion = 1578240;
        /// <summary>
        /// <para>(0018,1508) Positioner Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PositionerType = 1578248;
        /// <summary>
        /// <para>(0018,1510) Positioner Primary Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PositionerPrimaryAngle = 1578256;
        /// <summary>
        /// <para>(0018,1511) Positioner Secondary Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PositionerSecondaryAngle = 1578257;
        /// <summary>
        /// <para>(0018,1520) Positioner Primary Angle Increment</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint PositionerPrimaryAngleIncrement = 1578272;
        /// <summary>
        /// <para>(0018,1521) Positioner Secondary Angle Increment</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint PositionerSecondaryAngleIncrement = 1578273;
        /// <summary>
        /// <para>(0018,1530) Detector Primary Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorPrimaryAngle = 1578288;
        /// <summary>
        /// <para>(0018,1531) Detector Secondary Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorSecondaryAngle = 1578289;
        /// <summary>
        /// <para>(0018,1600) Shutter Shape</para>
        /// <para> VR: CS VM:1-3</para>
        /// </summary>
        public const uint ShutterShape = 1578496;
        /// <summary>
        /// <para>(0018,1602) Shutter Left Vertical Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ShutterLeftVerticalEdge = 1578498;
        /// <summary>
        /// <para>(0018,1604) Shutter Right Vertical Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ShutterRightVerticalEdge = 1578500;
        /// <summary>
        /// <para>(0018,1606) Shutter Upper Horizontal Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ShutterUpperHorizontalEdge = 1578502;
        /// <summary>
        /// <para>(0018,1608) Shutter Lower Horizontal Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ShutterLowerHorizontalEdge = 1578504;
        /// <summary>
        /// <para>(0018,1610) Center of Circular Shutter</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint CenterofCircularShutter = 1578512;
        /// <summary>
        /// <para>(0018,1612) Radius of Circular Shutter</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RadiusofCircularShutter = 1578514;
        /// <summary>
        /// <para>(0018,1620) Vertices of the Polygonal Shutter</para>
        /// <para> VR: IS VM:2-2n</para>
        /// </summary>
        public const uint VerticesofthePolygonalShutter = 1578528;
        /// <summary>
        /// <para>(0018,1622) Shutter Presentation Value</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ShutterPresentationValue = 1578530;
        /// <summary>
        /// <para>(0018,1623) Shutter Overlay Group</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ShutterOverlayGroup = 1578531;
        /// <summary>
        /// <para>(0018,1624) Shutter Presentation Color CIELab Value</para>
        /// <para> VR: US VM:3</para>
        /// </summary>
        public const uint ShutterPresentationColorCIELabValue = 1578532;
        /// <summary>
        /// <para>(0018,1700) Collimator Shape</para>
        /// <para> VR: CS VM:1-3</para>
        /// </summary>
        public const uint CollimatorShape = 1578752;
        /// <summary>
        /// <para>(0018,1702) Collimator Left Vertical Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CollimatorLeftVerticalEdge = 1578754;
        /// <summary>
        /// <para>(0018,1704) Collimator Right Vertical Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CollimatorRightVerticalEdge = 1578756;
        /// <summary>
        /// <para>(0018,1706) Collimator Upper Horizontal Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CollimatorUpperHorizontalEdge = 1578758;
        /// <summary>
        /// <para>(0018,1708) Collimator Lower Horizontal Edge</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CollimatorLowerHorizontalEdge = 1578760;
        /// <summary>
        /// <para>(0018,1710) Center of Circular Collimator</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint CenterofCircularCollimator = 1578768;
        /// <summary>
        /// <para>(0018,1712) Radius of Circular Collimator</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RadiusofCircularCollimator = 1578770;
        /// <summary>
        /// <para>(0018,1720) Vertices of the Polygonal Collimator</para>
        /// <para> VR: IS VM:2-2n</para>
        /// </summary>
        public const uint VerticesofthePolygonalCollimator = 1578784;
        /// <summary>
        /// <para>(0018,1800) Acquisition Time Synchronized</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AcquisitionTimeSynchronized = 1579008;
        /// <summary>
        /// <para>(0018,1801) Time Source</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint TimeSource = 1579009;
        /// <summary>
        /// <para>(0018,1802) Time Distribution Protocol</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TimeDistributionProtocol = 1579010;
        /// <summary>
        /// <para>(0018,1803) NTP Source Address</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint NTPSourceAddress = 1579011;
        /// <summary>
        /// <para>(0018,2001) Page Number Vector</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint PageNumberVector = 1581057;
        /// <summary>
        /// <para>(0018,2002) Frame Label Vector</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint FrameLabelVector = 1581058;
        /// <summary>
        /// <para>(0018,2003) Frame Primary Angle Vector</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FramePrimaryAngleVector = 1581059;
        /// <summary>
        /// <para>(0018,2004) Frame Secondary Angle Vector</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FrameSecondaryAngleVector = 1581060;
        /// <summary>
        /// <para>(0018,2005) Slice Location Vector</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint SliceLocationVector = 1581061;
        /// <summary>
        /// <para>(0018,2006) Display Window Label Vector</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint DisplayWindowLabelVector = 1581062;
        /// <summary>
        /// <para>(0018,2010) Nominal Scanned Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint NominalScannedPixelSpacing = 1581072;
        /// <summary>
        /// <para>(0018,2020) Digitizing Device Transport Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DigitizingDeviceTransportDirection = 1581088;
        /// <summary>
        /// <para>(0018,2030) Rotation of Scanned Film</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RotationofScannedFilm = 1581104;
        /// <summary>
        /// <para>(0018,3100) IVUS Acquisition</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint IVUSAcquisition = 1585408;
        /// <summary>
        /// <para>(0018,3101) IVUS Pullback Rate</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint IVUSPullbackRate = 1585409;
        /// <summary>
        /// <para>(0018,3102) IVUS Gated Rate</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint IVUSGatedRate = 1585410;
        /// <summary>
        /// <para>(0018,3103) IVUS Pullback Start Frame Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint IVUSPullbackStartFrameNumber = 1585411;
        /// <summary>
        /// <para>(0018,3104) IVUS Pullback Stop Frame Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint IVUSPullbackStopFrameNumber = 1585412;
        /// <summary>
        /// <para>(0018,3105) Lesion Number </para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint LesionNumber = 1585413;
        /// <summary>
        /// <para>(0018,4000) Acquisition Comments</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AcquisitionCommentsRetired = 1589248;
        /// <summary>
        /// <para>(0018,5000) Output Power</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint OutputPower = 1593344;
        /// <summary>
        /// <para>(0018,5010) Transducer Data</para>
        /// <para> VR: LO VM:3</para>
        /// </summary>
        public const uint TransducerData = 1593360;
        /// <summary>
        /// <para>(0018,5012) Focus Depth</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FocusDepth = 1593362;
        /// <summary>
        /// <para>(0018,5020) Processing Function</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ProcessingFunction = 1593376;
        /// <summary>
        /// <para>(0018,5021) Postprocessing Function</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PostprocessingFunction = 1593377;
        /// <summary>
        /// <para>(0018,5022) Mechanical Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint MechanicalIndex = 1593378;
        /// <summary>
        /// <para>(0018,5024) Bone Thermal Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BoneThermalIndex = 1593380;
        /// <summary>
        /// <para>(0018,5026) Cranial Thermal Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CranialThermalIndex = 1593382;
        /// <summary>
        /// <para>(0018,5027) Soft Tissue Thermal Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SoftTissueThermalIndex = 1593383;
        /// <summary>
        /// <para>(0018,5028) Soft Tissue-focus Thermal Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SoftTissuefocusThermalIndex = 1593384;
        /// <summary>
        /// <para>(0018,5029) Soft Tissue-surface Thermal Index</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SoftTissuesurfaceThermalIndex = 1593385;
        /// <summary>
        /// <para>(0018,5030) Dynamic Range</para>
        /// <para> VR: DS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DynamicRangeRetired = 1593392;
        /// <summary>
        /// <para>(0018,5040) Total Gain</para>
        /// <para> VR: DS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TotalGainRetired = 1593408;
        /// <summary>
        /// <para>(0018,5050) Depth of Scan Field</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint DepthofScanField = 1593424;
        /// <summary>
        /// <para>(0018,5100) Patient Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientPosition = 1593600;
        /// <summary>
        /// <para>(0018,5101) View Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ViewPosition = 1593601;
        /// <summary>
        /// <para>(0018,5104) Projection Eponymous Name Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ProjectionEponymousNameCodeSequence = 1593604;
        /// <summary>
        /// <para>(0018,5210) Image Transformation Matrix</para>
        /// <para> VR: DS VM:6</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageTransformationMatrixRetired = 1593872;
        /// <summary>
        /// <para>(0018,5212) Image Translation Vector</para>
        /// <para> VR: DS VM:3</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageTranslationVectorRetired = 1593874;
        /// <summary>
        /// <para>(0018,6000) Sensitivity</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint Sensitivity = 1597440;
        /// <summary>
        /// <para>(0018,6011) Sequence of Ultrasound Regions</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SequenceofUltrasoundRegions = 1597457;
        /// <summary>
        /// <para>(0018,6012) Region Spatial Format</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RegionSpatialFormat = 1597458;
        /// <summary>
        /// <para>(0018,6014) Region Data Type</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RegionDataType = 1597460;
        /// <summary>
        /// <para>(0018,6016) Region Flags</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint RegionFlags = 1597462;
        /// <summary>
        /// <para>(0018,6018) Region Location Min X0</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint RegionLocationMinX0 = 1597464;
        /// <summary>
        /// <para>(0018,601A) Region Location Min Y0</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint RegionLocationMinY0 = 1597466;
        /// <summary>
        /// <para>(0018,601C) Region Location Max X1</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint RegionLocationMaxX1 = 1597468;
        /// <summary>
        /// <para>(0018,601E) Region Location Max Y1</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint RegionLocationMaxY1 = 1597470;
        /// <summary>
        /// <para>(0018,6020) Reference Pixel X0</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint ReferencePixelX0 = 1597472;
        /// <summary>
        /// <para>(0018,6022) Reference Pixel Y0</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint ReferencePixelY0 = 1597474;
        /// <summary>
        /// <para>(0018,6024) Physical Units X Direction</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PhysicalUnitsXDirection = 1597476;
        /// <summary>
        /// <para>(0018,6026) Physical Units Y Direction</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PhysicalUnitsYDirection = 1597478;
        /// <summary>
        /// <para>(0018,6028) Reference Pixel Physical Value X</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ReferencePixelPhysicalValueX = 1597480;
        /// <summary>
        /// <para>(0018,602A) Reference Pixel Physical Value Y</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ReferencePixelPhysicalValueY = 1597482;
        /// <summary>
        /// <para>(0018,602C) Physical Delta X</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint PhysicalDeltaX = 1597484;
        /// <summary>
        /// <para>(0018,602E) Physical Delta Y</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint PhysicalDeltaY = 1597486;
        /// <summary>
        /// <para>(0018,6030) Transducer Frequency</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint TransducerFrequency = 1597488;
        /// <summary>
        /// <para>(0018,6031) Transducer Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TransducerType = 1597489;
        /// <summary>
        /// <para>(0018,6032) Pulse Repetition Frequency</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint PulseRepetitionFrequency = 1597490;
        /// <summary>
        /// <para>(0018,6034) Doppler Correction Angle</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint DopplerCorrectionAngle = 1597492;
        /// <summary>
        /// <para>(0018,6036) Steering Angle</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint SteeringAngle = 1597494;
        /// <summary>
        /// <para>(0018,6038) Doppler Sample Volume X Position</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DopplerSampleVolumeXPositionRetired = 1597496;
        /// <summary>
        /// <para>(0018,6039) Doppler Sample Volume X Position</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint DopplerSampleVolumeXPosition = 1597497;
        /// <summary>
        /// <para>(0018,603A) Doppler Sample Volume Y Position</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DopplerSampleVolumeYPositionRetired = 1597498;
        /// <summary>
        /// <para>(0018,603B) Doppler Sample Volume Y Position</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint DopplerSampleVolumeYPosition = 1597499;
        /// <summary>
        /// <para>(0018,603C) TM-Line Position X0</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TMLinePositionX0Retired = 1597500;
        /// <summary>
        /// <para>(0018,603D) TM-Line Position X0</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint TMLinePositionX0 = 1597501;
        /// <summary>
        /// <para>(0018,603E) TM-Line Position Y0</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TMLinePositionY0Retired = 1597502;
        /// <summary>
        /// <para>(0018,603F) TM-Line Position Y0</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint TMLinePositionY0 = 1597503;
        /// <summary>
        /// <para>(0018,6040) TM-Line Position X1</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TMLinePositionX1Retired = 1597504;
        /// <summary>
        /// <para>(0018,6041) TM-Line Position X1</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint TMLinePositionX1 = 1597505;
        /// <summary>
        /// <para>(0018,6042) TM-Line Position Y1</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TMLinePositionY1Retired = 1597506;
        /// <summary>
        /// <para>(0018,6043) TM-Line Position Y1</para>
        /// <para> VR: SL VM:1</para>
        /// </summary>
        public const uint TMLinePositionY1 = 1597507;
        /// <summary>
        /// <para>(0018,6044) Pixel Component Organization</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PixelComponentOrganization = 1597508;
        /// <summary>
        /// <para>(0018,6046) Pixel Component Mask</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint PixelComponentMask = 1597510;
        /// <summary>
        /// <para>(0018,6048) Pixel Component Range Start</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint PixelComponentRangeStart = 1597512;
        /// <summary>
        /// <para>(0018,604A) Pixel Component Range Stop</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint PixelComponentRangeStop = 1597514;
        /// <summary>
        /// <para>(0018,604C) Pixel Component Physical Units</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PixelComponentPhysicalUnits = 1597516;
        /// <summary>
        /// <para>(0018,604E) Pixel Component Data Type</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PixelComponentDataType = 1597518;
        /// <summary>
        /// <para>(0018,6050) Number of Table Break Points</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint NumberofTableBreakPoints = 1597520;
        /// <summary>
        /// <para>(0018,6052) Table of X Break Points</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint TableofXBreakPoints = 1597522;
        /// <summary>
        /// <para>(0018,6054) Table of Y Break Points</para>
        /// <para> VR: FD VM:1-n</para>
        /// </summary>
        public const uint TableofYBreakPoints = 1597524;
        /// <summary>
        /// <para>(0018,6056) Number of Table Entries</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint NumberofTableEntries = 1597526;
        /// <summary>
        /// <para>(0018,6058) Table of Pixel Values</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint TableofPixelValues = 1597528;
        /// <summary>
        /// <para>(0018,605A) Table of Parameter Values</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint TableofParameterValues = 1597530;
        /// <summary>
        /// <para>(0018,6060) R Wave Time Vector</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint RWaveTimeVector = 1597536;
        /// <summary>
        /// <para>(0018,7000) Detector Conditions Nominal Flag </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DetectorConditionsNominalFlag = 1601536;
        /// <summary>
        /// <para>(0018,7001) Detector Temperature</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorTemperature = 1601537;
        /// <summary>
        /// <para>(0018,7004) Detector Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DetectorType = 1601540;
        /// <summary>
        /// <para>(0018,7005) Detector Configuration</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DetectorConfiguration = 1601541;
        /// <summary>
        /// <para>(0018,7006) Detector Description</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint DetectorDescription = 1601542;
        /// <summary>
        /// <para>(0018,7008) Detector Mode</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint DetectorMode = 1601544;
        /// <summary>
        /// <para>(0018,700A) Detector ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint DetectorID = 1601546;
        /// <summary>
        /// <para>(0018,700C) Date of Last Detector Calibration </para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint DateofLastDetectorCalibration = 1601548;
        /// <summary>
        /// <para>(0018,700E) Time of Last Detector Calibration</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint TimeofLastDetectorCalibration = 1601550;
        /// <summary>
        /// <para>(0018,7010) Exposures on Detector Since Last Calibration </para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ExposuresonDetectorSinceLastCalibration = 1601552;
        /// <summary>
        /// <para>(0018,7011) Exposures on Detector Since Manufactured </para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ExposuresonDetectorSinceManufactured = 1601553;
        /// <summary>
        /// <para>(0018,7012) Detector Time Since Last Exposure </para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorTimeSinceLastExposure = 1601554;
        /// <summary>
        /// <para>(0018,7014) Detector Active Time </para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorActiveTime = 1601556;
        /// <summary>
        /// <para>(0018,7016) Detector Activation Offset From Exposure</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DetectorActivationOffsetFromExposure = 1601558;
        /// <summary>
        /// <para>(0018,701A) Detector Binning </para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint DetectorBinning = 1601562;
        /// <summary>
        /// <para>(0018,7020) Detector Element Physical Size</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint DetectorElementPhysicalSize = 1601568;
        /// <summary>
        /// <para>(0018,7022) Detector Element Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint DetectorElementSpacing = 1601570;
        /// <summary>
        /// <para>(0018,7024) Detector Active Shape</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DetectorActiveShape = 1601572;
        /// <summary>
        /// <para>(0018,7026) Detector Active Dimension(s)</para>
        /// <para> VR: DS VM:1-2</para>
        /// </summary>
        public const uint DetectorActiveDimensions = 1601574;
        /// <summary>
        /// <para>(0018,7028) Detector Active Origin</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint DetectorActiveOrigin = 1601576;
        /// <summary>
        /// <para>(0018,702A) Detector Manufacturer Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DetectorManufacturerName = 1601578;
        /// <summary>
        /// <para>(0018,702B) Detector Manufacturer’s Model Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DetectorManufacturersModelName = 1601579;
        /// <summary>
        /// <para>(0018,7030) Field of View Origin</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint FieldofViewOrigin = 1601584;
        /// <summary>
        /// <para>(0018,7032) Field of View Rotation</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FieldofViewRotation = 1601586;
        /// <summary>
        /// <para>(0018,7034) Field of View Horizontal Flip</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FieldofViewHorizontalFlip = 1601588;
        /// <summary>
        /// <para>(0018,7040) Grid Absorbing Material</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint GridAbsorbingMaterial = 1601600;
        /// <summary>
        /// <para>(0018,7041) Grid Spacing Material</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint GridSpacingMaterial = 1601601;
        /// <summary>
        /// <para>(0018,7042) Grid Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GridThickness = 1601602;
        /// <summary>
        /// <para>(0018,7044) Grid Pitch</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GridPitch = 1601604;
        /// <summary>
        /// <para>(0018,7046) Grid Aspect Ratio</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint GridAspectRatio = 1601606;
        /// <summary>
        /// <para>(0018,7048) Grid Period</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GridPeriod = 1601608;
        /// <summary>
        /// <para>(0018,704C) Grid Focal Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GridFocalDistance = 1601612;
        /// <summary>
        /// <para>(0018,7050) Filter Material</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint FilterMaterial = 1601616;
        /// <summary>
        /// <para>(0018,7052) Filter Thickness Minimum</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FilterThicknessMinimum = 1601618;
        /// <summary>
        /// <para>(0018,7054) Filter Thickness Maximum</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint FilterThicknessMaximum = 1601620;
        /// <summary>
        /// <para>(0018,7060) Exposure Control Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExposureControlMode = 1601632;
        /// <summary>
        /// <para>(0018,7062) Exposure Control Mode Description</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint ExposureControlModeDescription = 1601634;
        /// <summary>
        /// <para>(0018,7064) Exposure Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExposureStatus = 1601636;
        /// <summary>
        /// <para>(0018,7065) Phototimer Setting</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PhototimerSetting = 1601637;
        /// <summary>
        /// <para>(0018,8150) Exposure Time in S</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ExposureTimeinS = 1605968;
        /// <summary>
        /// <para>(0018,8151) X-Ray Tube Current in A</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint XRayTubeCurrentinA = 1605969;
        /// <summary>
        /// <para>(0018,9004) Content Qualification</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContentQualification = 1609732;
        /// <summary>
        /// <para>(0018,9005) Pulse Sequence Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PulseSequenceName = 1609733;
        /// <summary>
        /// <para>(0018,9006) MR Imaging Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRImagingModifierSequence = 1609734;
        /// <summary>
        /// <para>(0018,9008) Echo Pulse Sequence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint EchoPulseSequence = 1609736;
        /// <summary>
        /// <para>(0018,9009) Inversion Recovery</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint InversionRecovery = 1609737;
        /// <summary>
        /// <para>(0018,9010) Flow Compensation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FlowCompensation = 1609744;
        /// <summary>
        /// <para>(0018,9011) Multiple Spin Echo</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MultipleSpinEcho = 1609745;
        /// <summary>
        /// <para>(0018,9012) Multi-planar Excitation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MultiplanarExcitation = 1609746;
        /// <summary>
        /// <para>(0018,9014) Phase Contrast</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PhaseContrast = 1609748;
        /// <summary>
        /// <para>(0018,9015) Time of Flight Contrast</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TimeofFlightContrast = 1609749;
        /// <summary>
        /// <para>(0018,9016) Spoiling</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Spoiling = 1609750;
        /// <summary>
        /// <para>(0018,9017) Steady State Pulse Sequence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SteadyStatePulseSequence = 1609751;
        /// <summary>
        /// <para>(0018,9018) Echo Planar Pulse Sequence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint EchoPlanarPulseSequence = 1609752;
        /// <summary>
        /// <para>(0018,9019) Tag Angle First Axis</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TagAngleFirstAxis = 1609753;
        /// <summary>
        /// <para>(0018,9020) Magnetization Transfer</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MagnetizationTransfer = 1609760;
        /// <summary>
        /// <para>(0018,9021) T2 Preparation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint T2Preparation = 1609761;
        /// <summary>
        /// <para>(0018,9022) Blood Signal Nulling</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BloodSignalNulling = 1609762;
        /// <summary>
        /// <para>(0018,9024) Saturation Recovery</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SaturationRecovery = 1609764;
        /// <summary>
        /// <para>(0018,9025) Spectrally Selected Suppression</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpectrallySelectedSuppression = 1609765;
        /// <summary>
        /// <para>(0018,9026) Spectrally Selected Excitation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpectrallySelectedExcitation = 1609766;
        /// <summary>
        /// <para>(0018,9027) Spatial Pre-saturation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpatialPresaturation = 1609767;
        /// <summary>
        /// <para>(0018,9028) Tagging</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Tagging = 1609768;
        /// <summary>
        /// <para>(0018,9029) Oversampling Phase</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OversamplingPhase = 1609769;
        /// <summary>
        /// <para>(0018,9030) Tag Spacing First Dimension</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TagSpacingFirstDimension = 1609776;
        /// <summary>
        /// <para>(0018,9032) Geometry of k-Space Traversal</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GeometryofkSpaceTraversal = 1609778;
        /// <summary>
        /// <para>(0018,9033) Segmented k-Space Traversal</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SegmentedkSpaceTraversal = 1609779;
        /// <summary>
        /// <para>(0018,9034) Rectilinear Phase Encode Reordering</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RectilinearPhaseEncodeReordering = 1609780;
        /// <summary>
        /// <para>(0018,9035) Tag Thickness</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TagThickness = 1609781;
        /// <summary>
        /// <para>(0018,9036) Partial Fourier Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PartialFourierDirection = 1609782;
        /// <summary>
        /// <para>(0018,9037) Cardiac Synchronization Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CardiacSynchronizationTechnique = 1609783;
        /// <summary>
        /// <para>(0018,9041) Receive Coil Manufacturer Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ReceiveCoilManufacturerName = 1609793;
        /// <summary>
        /// <para>(0018,9042) MR Receive Coil Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRReceiveCoilSequence = 1609794;
        /// <summary>
        /// <para>(0018,9043) Receive Coil Type </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReceiveCoilType = 1609795;
        /// <summary>
        /// <para>(0018,9044) Quadrature Receive Coil </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint QuadratureReceiveCoil = 1609796;
        /// <summary>
        /// <para>(0018,9045) Multi-Coil Definition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MultiCoilDefinitionSequence = 1609797;
        /// <summary>
        /// <para>(0018,9046) Multi-Coil Configuration </para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint MultiCoilConfiguration = 1609798;
        /// <summary>
        /// <para>(0018,9047) Multi-Coil Element Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint MultiCoilElementName = 1609799;
        /// <summary>
        /// <para>(0018,9048) Multi-Coil Element Used</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MultiCoilElementUsed = 1609800;
        /// <summary>
        /// <para>(0018,9049) MR Transmit Coil Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRTransmitCoilSequence = 1609801;
        /// <summary>
        /// <para>(0018,9050) Transmit Coil Manufacturer Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TransmitCoilManufacturerName = 1609808;
        /// <summary>
        /// <para>(0018,9051) Transmit Coil Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TransmitCoilType = 1609809;
        /// <summary>
        /// <para>(0018,9052) Spectral Width</para>
        /// <para> VR: FD VM:1-2</para>
        /// </summary>
        public const uint SpectralWidth = 1609810;
        /// <summary>
        /// <para>(0018,9053) Chemical Shift Reference</para>
        /// <para> VR: FD VM:1-2</para>
        /// </summary>
        public const uint ChemicalShiftReference = 1609811;
        /// <summary>
        /// <para>(0018,9054) Volume Localization Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VolumeLocalizationTechnique = 1609812;
        /// <summary>
        /// <para>(0018,9058) MR Acquisition Frequency Encoding Steps</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MRAcquisitionFrequencyEncodingSteps = 1609816;
        /// <summary>
        /// <para>(0018,9059) De-coupling</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Decoupling = 1609817;
        /// <summary>
        /// <para>(0018,9060) De-coupled Nucleus</para>
        /// <para> VR: CS VM:1-2</para>
        /// </summary>
        public const uint DecoupledNucleus = 1609824;
        /// <summary>
        /// <para>(0018,9061) De-coupling Frequency</para>
        /// <para> VR: FD VM:1-2</para>
        /// </summary>
        public const uint DecouplingFrequency = 1609825;
        /// <summary>
        /// <para>(0018,9062) De-coupling Method</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DecouplingMethod = 1609826;
        /// <summary>
        /// <para>(0018,9063) De-coupling Chemical Shift Reference</para>
        /// <para> VR: FD VM:1-2</para>
        /// </summary>
        public const uint DecouplingChemicalShiftReference = 1609827;
        /// <summary>
        /// <para>(0018,9064) k-space Filtering</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint kspaceFiltering = 1609828;
        /// <summary>
        /// <para>(0018,9065) Time Domain Filtering</para>
        /// <para> VR: CS VM:1-2</para>
        /// </summary>
        public const uint TimeDomainFiltering = 1609829;
        /// <summary>
        /// <para>(0018,9066) Number of Zero fills</para>
        /// <para> VR: US VM:1-2</para>
        /// </summary>
        public const uint NumberofZerofills = 1609830;
        /// <summary>
        /// <para>(0018,9067) Baseline Correction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BaselineCorrection = 1609831;
        /// <summary>
        /// <para>(0018,9069) Parallel Reduction Factor In-plane</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ParallelReductionFactorInplane = 1609833;
        /// <summary>
        /// <para>(0018,9070) Cardiac R-R Interval Specified</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint CardiacRRIntervalSpecified = 1609840;
        /// <summary>
        /// <para>(0018,9073) Acquisition Duration</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint AcquisitionDuration = 1609843;
        /// <summary>
        /// <para>(0018,9074) Frame Acquisition Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint FrameAcquisitionDatetime = 1609844;
        /// <summary>
        /// <para>(0018,9075) Diffusion Directionality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DiffusionDirectionality = 1609845;
        /// <summary>
        /// <para>(0018,9076) Diffusion Gradient Direction Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DiffusionGradientDirectionSequence = 1609846;
        /// <summary>
        /// <para>(0018,9077) Parallel Acquisition</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ParallelAcquisition = 1609847;
        /// <summary>
        /// <para>(0018,9078) Parallel Acquisition Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ParallelAcquisitionTechnique = 1609848;
        /// <summary>
        /// <para>(0018,9079) Inversion Times</para>
        /// <para> VR: FD VM:1-n</para>
        /// </summary>
        public const uint InversionTimes = 1609849;
        /// <summary>
        /// <para>(0018,9080) Metabolite Map Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint MetaboliteMapDescription = 1609856;
        /// <summary>
        /// <para>(0018,9081) Partial Fourier</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PartialFourier = 1609857;
        /// <summary>
        /// <para>(0018,9082) Effective Echo Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint EffectiveEchoTime = 1609858;
        /// <summary>
        /// <para>(0018,9083) Metabolite Map Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MetaboliteMapCodeSequence = 1609859;
        /// <summary>
        /// <para>(0018,9084) Chemical Shift Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChemicalShiftSequence = 1609860;
        /// <summary>
        /// <para>(0018,9085) Cardiac Signal Source</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CardiacSignalSource = 1609861;
        /// <summary>
        /// <para>(0018,9087) Diffusion b-value</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint Diffusionbvalue = 1609863;
        /// <summary>
        /// <para>(0018,9089) Diffusion Gradient Orientation</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint DiffusionGradientOrientation = 1609865;
        /// <summary>
        /// <para>(0018,9090) Velocity Encoding Direction</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint VelocityEncodingDirection = 1609872;
        /// <summary>
        /// <para>(0018,9091) Velocity Encoding Minimum Value</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint VelocityEncodingMinimumValue = 1609873;
        /// <summary>
        /// <para>(0018,9093) Number of k-Space Trajectories</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofkSpaceTrajectories = 1609875;
        /// <summary>
        /// <para>(0018,9094) Coverage of k-Space</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CoverageofkSpace = 1609876;
        /// <summary>
        /// <para>(0018,9095) Spectroscopy Acquisition Phase Rows</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint SpectroscopyAcquisitionPhaseRows = 1609877;
        /// <summary>
        /// <para>(0018,9098) Transmitter Frequency</para>
        /// <para> VR: FD VM:1-2</para>
        /// </summary>
        public const uint TransmitterFrequency = 1609880;
        /// <summary>
        /// <para>(0018,9100) Resonant Nucleus</para>
        /// <para> VR: CS VM:1-2</para>
        /// </summary>
        public const uint ResonantNucleus = 1609984;
        /// <summary>
        /// <para>(0018,9101) Frequency Correction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FrequencyCorrection = 1609985;
        /// <summary>
        /// <para>(0018,9103) MR Spectroscopy FOV/Geometry Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRSpectroscopyFOVGeometrySequence = 1609987;
        /// <summary>
        /// <para>(0018,9104) Slab Thickness</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint SlabThickness = 1609988;
        /// <summary>
        /// <para>(0018,9105) Slab Orientation</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint SlabOrientation = 1609989;
        /// <summary>
        /// <para>(0018,9106) Mid Slab Position</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint MidSlabPosition = 1609990;
        /// <summary>
        /// <para>(0018,9107) MR Spatial Saturation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRSpatialSaturationSequence = 1609991;
        /// <summary>
        /// <para>(0018,9112) MR Timing and Related Parameters Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRTimingandRelatedParametersSequence = 1610002;
        /// <summary>
        /// <para>(0018,9114) MR Echo Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MREchoSequence = 1610004;
        /// <summary>
        /// <para>(0018,9115) MR Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRModifierSequence = 1610005;
        /// <summary>
        /// <para>(0018,9117) MR Diffusion Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRDiffusionSequence = 1610007;
        /// <summary>
        /// <para>(0018,9118) Cardiac Trigger Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CardiacTriggerSequence = 1610008;
        /// <summary>
        /// <para>(0018,9119) MR Averages Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRAveragesSequence = 1610009;
        /// <summary>
        /// <para>(0018,9125) MR FOV/Geometry Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRFOVGeometrySequence = 1610021;
        /// <summary>
        /// <para>(0018,9126) Volume Localization Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint VolumeLocalizationSequence = 1610022;
        /// <summary>
        /// <para>(0018,9127) Spectroscopy Acquisition Data Columns</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint SpectroscopyAcquisitionDataColumns = 1610023;
        /// <summary>
        /// <para>(0018,9147) Diffusion Anisotropy Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DiffusionAnisotropyType = 1610055;
        /// <summary>
        /// <para>(0018,9151) Frame Reference Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint FrameReferenceDatetime = 1610065;
        /// <summary>
        /// <para>(0018,9152) MR Metabolite Map Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRMetaboliteMapSequence = 1610066;
        /// <summary>
        /// <para>(0018,9155) Parallel Reduction Factor out-of-plane</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ParallelReductionFactoroutofplane = 1610069;
        /// <summary>
        /// <para>(0018,9159) Spectroscopy Acquisition Out-of-plane Phase Steps</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint SpectroscopyAcquisitionOutofplanePhaseSteps = 1610073;
        /// <summary>
        /// <para>(0018,9166) Bulk Motion Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BulkMotionStatus = 1610086;
        /// <summary>
        /// <para>(0018,9168) Parallel Reduction Factor Second In-plane</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ParallelReductionFactorSecondInplane = 1610088;
        /// <summary>
        /// <para>(0018,9169) Cardiac Beat Rejection Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CardiacBeatRejectionTechnique = 1610089;
        /// <summary>
        /// <para>(0018,9170) Respiratory Motion Compensation Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RespiratoryMotionCompensationTechnique = 1610096;
        /// <summary>
        /// <para>(0018,9171) Respiratory Signal Source</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RespiratorySignalSource = 1610097;
        /// <summary>
        /// <para>(0018,9172) Bulk Motion Compensation Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BulkMotionCompensationTechnique = 1610098;
        /// <summary>
        /// <para>(0018,9173) Bulk Motion Signal Source</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BulkMotionSignalSource = 1610099;
        /// <summary>
        /// <para>(0018,9174) Applicable Safety Standard Agency</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ApplicableSafetyStandardAgency = 1610100;
        /// <summary>
        /// <para>(0018,9175) Applicable Safety Standard Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ApplicableSafetyStandardDescription = 1610101;
        /// <summary>
        /// <para>(0018,9176) Operating Mode Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OperatingModeSequence = 1610102;
        /// <summary>
        /// <para>(0018,9177) Operating Mode Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OperatingModeType = 1610103;
        /// <summary>
        /// <para>(0018,9178) Operating Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OperatingMode = 1610104;
        /// <summary>
        /// <para>(0018,9179) Specific Absorption Rate Definition</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpecificAbsorptionRateDefinition = 1610105;
        /// <summary>
        /// <para>(0018,9180) Gradient Output Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GradientOutputType = 1610112;
        /// <summary>
        /// <para>(0018,9181) Specific Absorption Rate Value</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint SpecificAbsorptionRateValue = 1610113;
        /// <summary>
        /// <para>(0018,9182) Gradient Output</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint GradientOutput = 1610114;
        /// <summary>
        /// <para>(0018,9183) Flow Compensation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FlowCompensationDirection = 1610115;
        /// <summary>
        /// <para>(0018,9184) Tagging Delay</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TaggingDelay = 1610116;
        /// <summary>
        /// <para>(0018,9185) Respiratory Motion Compensation Technique Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint RespiratoryMotionCompensationTechniqueDescription = 1610117;
        /// <summary>
        /// <para>(0018,9186) Respiratory Signal Source ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RespiratorySignalSourceID = 1610118;
        /// <summary>
        /// <para>(0018,9195) Chemical Shifts Minimum Integration Limit in Hz</para>
        /// <para> VR: FD VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ChemicalShiftsMinimumIntegrationLimitinHzRetired = 1610133;
        /// <summary>
        /// <para>(0018,9196) Chemical Shifts Maximum Integration Limit in Hz</para>
        /// <para> VR: FD VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ChemicalShiftsMaximumIntegrationLimitinHzRetired = 1610134;
        /// <summary>
        /// <para>(0018,9197) MR Velocity Encoding Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRVelocityEncodingSequence = 1610135;
        /// <summary>
        /// <para>(0018,9198) First Order Phase Correction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FirstOrderPhaseCorrection = 1610136;
        /// <summary>
        /// <para>(0018,9199) Water Referenced Phase Correction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint WaterReferencedPhaseCorrection = 1610137;
        /// <summary>
        /// <para>(0018,9200) MR Spectroscopy Acquisition Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MRSpectroscopyAcquisitionType = 1610240;
        /// <summary>
        /// <para>(0018,9214) Respiratory Cycle Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RespiratoryCyclePosition = 1610260;
        /// <summary>
        /// <para>(0018,9217) Velocity Encoding Maximum Value</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint VelocityEncodingMaximumValue = 1610263;
        /// <summary>
        /// <para>(0018,9218) Tag Spacing Second Dimension</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TagSpacingSecondDimension = 1610264;
        /// <summary>
        /// <para>(0018,9219) Tag Angle Second Axis</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint TagAngleSecondAxis = 1610265;
        /// <summary>
        /// <para>(0018,9220) Frame Acquisition Duration</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint FrameAcquisitionDuration = 1610272;
        /// <summary>
        /// <para>(0018,9226) MR Image Frame Type Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRImageFrameTypeSequence = 1610278;
        /// <summary>
        /// <para>(0018,9227) MR Spectroscopy Frame Type Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MRSpectroscopyFrameTypeSequence = 1610279;
        /// <summary>
        /// <para>(0018,9231) MR Acquisition Phase Encoding Steps in-plane</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MRAcquisitionPhaseEncodingStepsinplane = 1610289;
        /// <summary>
        /// <para>(0018,9232) MR Acquisition Phase Encoding Steps out-of-plane</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MRAcquisitionPhaseEncodingStepsoutofplane = 1610290;
        /// <summary>
        /// <para>(0018,9234) Spectroscopy Acquisition Phase Columns</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint SpectroscopyAcquisitionPhaseColumns = 1610292;
        /// <summary>
        /// <para>(0018,9236) Cardiac Cycle Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CardiacCyclePosition = 1610294;
        /// <summary>
        /// <para>(0018,9239) Specific Absorption Rate Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SpecificAbsorptionRateSequence = 1610297;
        /// <summary>
        /// <para>(0018,9240) RF Echo Train Length</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RFEchoTrainLength = 1610304;
        /// <summary>
        /// <para>(0018,9241) Gradient Echo Train Length</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint GradientEchoTrainLength = 1610305;
        /// <summary>
        /// <para>(0018,9295) Chemical Shifts Minimum Integration Limit in ppm</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ChemicalShiftsMinimumIntegrationLimitinppm = 1610389;
        /// <summary>
        /// <para>(0018,9296) Chemical Shifts Maximum Integration Limit in ppm</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ChemicalShiftsMaximumIntegrationLimitinppm = 1610390;
        /// <summary>
        /// <para>(0018,9301) CT Acquisition Type Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTAcquisitionTypeSequence = 1610497;
        /// <summary>
        /// <para>(0018,9302) Acquisition Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AcquisitionType = 1610498;
        /// <summary>
        /// <para>(0018,9303) Tube Angle</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TubeAngle = 1610499;
        /// <summary>
        /// <para>(0018,9304) CT Acquisition Details Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTAcquisitionDetailsSequence = 1610500;
        /// <summary>
        /// <para>(0018,9305) Revolution Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RevolutionTime = 1610501;
        /// <summary>
        /// <para>(0018,9306) Single Collimation Width</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint SingleCollimationWidth = 1610502;
        /// <summary>
        /// <para>(0018,9307) Total Collimation Width</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TotalCollimationWidth = 1610503;
        /// <summary>
        /// <para>(0018,9308) CT Table Dynamics Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTTableDynamicsSequence = 1610504;
        /// <summary>
        /// <para>(0018,9309) Table Speed</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TableSpeed = 1610505;
        /// <summary>
        /// <para>(0018,9310) Table Feed per Rotation</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TableFeedperRotation = 1610512;
        /// <summary>
        /// <para>(0018,9311) Spiral Pitch Factor</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint SpiralPitchFactor = 1610513;
        /// <summary>
        /// <para>(0018,9312) CT Geometry Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTGeometrySequence = 1610514;
        /// <summary>
        /// <para>(0018,9313) Data Collection Center (Patient)</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint DataCollectionCenterPatient = 1610515;
        /// <summary>
        /// <para>(0018,9314) CT Reconstruction Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTReconstructionSequence = 1610516;
        /// <summary>
        /// <para>(0018,9315) Reconstruction Algorithm</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReconstructionAlgorithm = 1610517;
        /// <summary>
        /// <para>(0018,9316) Convolution Kernel Group</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ConvolutionKernelGroup = 1610518;
        /// <summary>
        /// <para>(0018,9317) Reconstruction Field of View</para>
        /// <para> VR: FD VM:2</para>
        /// </summary>
        public const uint ReconstructionFieldofView = 1610519;
        /// <summary>
        /// <para>(0018,9318) Reconstruction Target Center (Patient)</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint ReconstructionTargetCenterPatient = 1610520;
        /// <summary>
        /// <para>(0018,9319) Reconstruction Angle</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ReconstructionAngle = 1610521;
        /// <summary>
        /// <para>(0018,9320) Image Filter</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ImageFilter = 1610528;
        /// <summary>
        /// <para>(0018,9321) CT Exposure Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTExposureSequence = 1610529;
        /// <summary>
        /// <para>(0018,9322) Reconstruction Pixel Spacing </para>
        /// <para> VR: FD VM:2</para>
        /// </summary>
        public const uint ReconstructionPixelSpacing = 1610530;
        /// <summary>
        /// <para>(0018,9323) Exposure Modulation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExposureModulationType = 1610531;
        /// <summary>
        /// <para>(0018,9324) Estimated Dose Saving</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint EstimatedDoseSaving = 1610532;
        /// <summary>
        /// <para>(0018,9325) CT X-ray Details Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTXrayDetailsSequence = 1610533;
        /// <summary>
        /// <para>(0018,9326) CT Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTPositionSequence = 1610534;
        /// <summary>
        /// <para>(0018,9327) Table Position</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint TablePosition = 1610535;
        /// <summary>
        /// <para>(0018,9328) Exposure Time in ms</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ExposureTimeinms = 1610536;
        /// <summary>
        /// <para>(0018,9329) CT Image Frame Type Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CTImageFrameTypeSequence = 1610537;
        /// <summary>
        /// <para>(0018,9330) X-Ray Tube Current in mA</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint XRayTubeCurrentinmA = 1610544;
        /// <summary>
        /// <para>(0018,9332) Exposure in mAs</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ExposureinmAs = 1610546;
        /// <summary>
        /// <para>(0018,9333) Constant Volume Flag </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ConstantVolumeFlag = 1610547;
        /// <summary>
        /// <para>(0018,9334) Fluoroscopy Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FluoroscopyFlag = 1610548;
        /// <summary>
        /// <para>(0018,9335) Distance Source to Data Collection Center</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint DistanceSourcetoDataCollectionCenter = 1610549;
        /// <summary>
        /// <para>(0018,9337) Contrast/Bolus Agent Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgentNumber = 1610551;
        /// <summary>
        /// <para>(0018,9338) Contrast/Bolus Ingredient Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContrastBolusIngredientCodeSequence = 1610552;
        /// <summary>
        /// <para>(0018,9340) Contrast Administration Profile Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContrastAdministrationProfileSequence = 1610560;
        /// <summary>
        /// <para>(0018,9341) Contrast/Bolus Usage Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContrastBolusUsageSequence = 1610561;
        /// <summary>
        /// <para>(0018,9342) Contrast/Bolus Agent Administered</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgentAdministered = 1610562;
        /// <summary>
        /// <para>(0018,9343) Contrast/Bolus Agent Detected</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgentDetected = 1610563;
        /// <summary>
        /// <para>(0018,9344) Contrast/Bolus Agent Phase</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContrastBolusAgentPhase = 1610564;
        /// <summary>
        /// <para>(0018,9345) CTDIvol</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint CTDIvol = 1610565;
        /// <summary>
        /// <para>(0018,9401) Projection Pixel Calibration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ProjectionPixelCalibrationSequence = 1610753;
        /// <summary>
        /// <para>(0018,9402) Distance Source to Isocenter</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint DistanceSourcetoIsocenter = 1610754;
        /// <summary>
        /// <para>(0018,9403) Distance Object to Table Top</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint DistanceObjecttoTableTop = 1610755;
        /// <summary>
        /// <para>(0018,9404) Object Pixel Spacing in Center of Beam</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint ObjectPixelSpacinginCenterofBeam = 1610756;
        /// <summary>
        /// <para>(0018,9405) Positioner Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PositionerPositionSequence = 1610757;
        /// <summary>
        /// <para>(0018,9406) Table Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint TablePositionSequence = 1610758;
        /// <summary>
        /// <para>(0018,9407) Collimator Shape Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CollimatorShapeSequence = 1610759;
        /// <summary>
        /// <para>(0018,9412) XA/XRF Frame Characteristics Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint XAXRFFrameCharacteristicsSequence = 1610770;
        /// <summary>
        /// <para>(0018,9417) Frame Acquisition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameAcquisitionSequence = 1610775;
        /// <summary>
        /// <para>(0018,9420) X-Ray Receptor Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint XRayReceptorType = 1610784;
        /// <summary>
        /// <para>(0018,9423) Acquisition Protocol Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AcquisitionProtocolName = 1610787;
        /// <summary>
        /// <para>(0018,9424) Acquisition Protocol Description</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint AcquisitionProtocolDescription = 1610788;
        /// <summary>
        /// <para>(0018,9425) Contrast/Bolus Ingredient Opaque</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContrastBolusIngredientOpaque = 1610789;
        /// <summary>
        /// <para>(0018,9426) Distance Receptor Plane to Detector Housing</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint DistanceReceptorPlanetoDetectorHousing = 1610790;
        /// <summary>
        /// <para>(0018,9427) Intensifier Active Shape</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint IntensifierActiveShape = 1610791;
        /// <summary>
        /// <para>(0018,9428) Intensifier Active Dimension(s)</para>
        /// <para> VR: FL VM:1-2</para>
        /// </summary>
        public const uint IntensifierActiveDimensions = 1610792;
        /// <summary>
        /// <para>(0018,9429) Physical Detector Size</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint PhysicalDetectorSize = 1610793;
        /// <summary>
        /// <para>(0018,9430) Position of Isocenter Projection</para>
        /// <para> VR: US VM:2</para>
        /// </summary>
        public const uint PositionofIsocenterProjection = 1610800;
        /// <summary>
        /// <para>(0018,9432) Field of View Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FieldofViewSequence = 1610802;
        /// <summary>
        /// <para>(0018,9433) Field of View Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FieldofViewDescription = 1610803;
        /// <summary>
        /// <para>(0018,9434) Exposure Control Sensing Regions Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionsSequence = 1610804;
        /// <summary>
        /// <para>(0018,9435) Exposure Control Sensing Region Shape</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionShape = 1610805;
        /// <summary>
        /// <para>(0018,9436) Exposure Control Sensing Region Left Vertical Edge</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionLeftVerticalEdge = 1610806;
        /// <summary>
        /// <para>(0018,9437) Exposure Control Sensing Region Right Vertical Edge</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionRightVerticalEdge = 1610807;
        /// <summary>
        /// <para>(0018,9438) Exposure Control Sensing Region Upper Horizontal Edge</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionUpperHorizontalEdge = 1610808;
        /// <summary>
        /// <para>(0018,9439) Exposure Control Sensing Region Lower Horizontal Edge</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint ExposureControlSensingRegionLowerHorizontalEdge = 1610809;
        /// <summary>
        /// <para>(0018,9440) Center of Circular Exposure Control Sensing Region</para>
        /// <para> VR: SS VM:2</para>
        /// </summary>
        public const uint CenterofCircularExposureControlSensingRegion = 1610816;
        /// <summary>
        /// <para>(0018,9441) Radius of Circular Exposure Control Sensing Region</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RadiusofCircularExposureControlSensingRegion = 1610817;
        /// <summary>
        /// <para>(0018,9442) Vertices of the Polygonal Exposure Control Sensing Region</para>
        /// <para> VR: SS VM:2-n</para>
        /// </summary>
        public const uint VerticesofthePolygonalExposureControlSensingRegion = 1610818;
        /// <summary>
        /// <para>(0018,9447) Column Angulation (Patient)</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint ColumnAngulationPatient = 1610823;
        /// <summary>
        /// <para>(0018,9449) Beam Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint BeamAngle = 1610825;
        /// <summary>
        /// <para>(0018,9451) Frame Detector Parameters Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameDetectorParametersSequence = 1610833;
        /// <summary>
        /// <para>(0018,9452) Calculated Anatomy Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CalculatedAnatomyThickness = 1610834;
        /// <summary>
        /// <para>(0018,9455) Calibration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CalibrationSequence = 1610837;
        /// <summary>
        /// <para>(0018,9456) Object Thickness Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ObjectThicknessSequence = 1610838;
        /// <summary>
        /// <para>(0018,9457) Plane Identification</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PlaneIdentification = 1610839;
        /// <summary>
        /// <para>(0018,9461) Field of View Dimension(s) in Float</para>
        /// <para> VR: FL VM:1-2</para>
        /// </summary>
        public const uint FieldofViewDimensionsinFloat = 1610849;
        /// <summary>
        /// <para>(0018,9462) Isocenter Reference System Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IsocenterReferenceSystemSequence = 1610850;
        /// <summary>
        /// <para>(0018,9463) Positioner Isocenter Primary Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint PositionerIsocenterPrimaryAngle = 1610851;
        /// <summary>
        /// <para>(0018,9464) Positioner Isocenter Secondary Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint PositionerIsocenterSecondaryAngle = 1610852;
        /// <summary>
        /// <para>(0018,9465) Positioner Isocenter Detector Rotation Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint PositionerIsocenterDetectorRotationAngle = 1610853;
        /// <summary>
        /// <para>(0018,9466) Table X Position to Isocenter</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableXPositiontoIsocenter = 1610854;
        /// <summary>
        /// <para>(0018,9467) Table Y Position to Isocenter</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableYPositiontoIsocenter = 1610855;
        /// <summary>
        /// <para>(0018,9468) Table Z Position to Isocenter</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableZPositiontoIsocenter = 1610856;
        /// <summary>
        /// <para>(0018,9469) Table Horizontal Rotation Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableHorizontalRotationAngle = 1610857;
        /// <summary>
        /// <para>(0018,9470) Table Head Tilt Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableHeadTiltAngle = 1610864;
        /// <summary>
        /// <para>(0018,9471) Table Cradle Tilt Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableCradleTiltAngle = 1610865;
        /// <summary>
        /// <para>(0018,9472) Frame Display Shutter Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameDisplayShutterSequence = 1610866;
        /// <summary>
        /// <para>(0018,9473) Acquired Image Area Dose Product</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint AcquiredImageAreaDoseProduct = 1610867;
        /// <summary>
        /// <para>(0018,9474) C-arm Positioner Tabletop Relationship</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CarmPositionerTabletopRelationship = 1610868;
        /// <summary>
        /// <para>(0018,9476) X-Ray Geometry Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint XRayGeometrySequence = 1610870;
        /// <summary>
        /// <para>(0018,9477) Irradiation Event Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IrradiationEventIdentificationSequence = 1610871;
        /// <summary>
        /// <para>(0018,A001) Contributing Equipment Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContributingEquipmentSequence = 1613825;
        /// <summary>
        /// <para>(0018,A002) Contribution Date Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ContributionDateTime = 1613826;
        /// <summary>
        /// <para>(0018,A003) Contribution Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ContributionDescription = 1613827;
        /// <summary>
        /// <para>(0020,000D) Study Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint StudyInstanceUID = 2097165;
        /// <summary>
        /// <para>(0020,000E) Series Instance UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint SeriesInstanceUID = 2097166;
        /// <summary>
        /// <para>(0020,0010) Study ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StudyID = 2097168;
        /// <summary>
        /// <para>(0020,0011) Series Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint SeriesNumber = 2097169;
        /// <summary>
        /// <para>(0020,0012) Acquisition Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint AcquisitionNumber = 2097170;
        /// <summary>
        /// <para>(0020,0013) Instance Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint InstanceNumber = 2097171;
        /// <summary>
        /// <para>(0020,0014) Isotope Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint IsotopeNumberRetired = 2097172;
        /// <summary>
        /// <para>(0020,0015) Phase Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PhaseNumberRetired = 2097173;
        /// <summary>
        /// <para>(0020,0016) Interval Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint IntervalNumberRetired = 2097174;
        /// <summary>
        /// <para>(0020,0017) Time Slot Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TimeSlotNumberRetired = 2097175;
        /// <summary>
        /// <para>(0020,0018) Angle Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AngleNumberRetired = 2097176;
        /// <summary>
        /// <para>(0020,0019) Item Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ItemNumber = 2097177;
        /// <summary>
        /// <para>(0020,0020) Patient Orientation</para>
        /// <para> VR: CS VM:2</para>
        /// </summary>
        public const uint PatientOrientation = 2097184;
        /// <summary>
        /// <para>(0020,0022) Overlay Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayNumberRetired = 2097186;
        /// <summary>
        /// <para>(0020,0024) Curve Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveNumberRetired = 2097188;
        /// <summary>
        /// <para>(0020,0026) Lookup Table Number</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LookupTableNumberRetired = 2097190;
        /// <summary>
        /// <para>(0020,0030) Image Position</para>
        /// <para> VR: DS VM:3</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImagePositionRetired = 2097200;
        /// <summary>
        /// <para>(0020,0032) Image Position (Patient)</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint ImagePositionPatient = 2097202;
        /// <summary>
        /// <para>(0020,0035) Image Orientation</para>
        /// <para> VR: DS VM:6</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageOrientationRetired = 2097205;
        /// <summary>
        /// <para>(0020,0037) Image Orientation (Patient)</para>
        /// <para> VR: DS VM:6</para>
        /// </summary>
        public const uint ImageOrientationPatient = 2097207;
        /// <summary>
        /// <para>(0020,0050) Location</para>
        /// <para> VR: DS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LocationRetired = 2097232;
        /// <summary>
        /// <para>(0020,0052) Frame of Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint FrameofReferenceUID = 2097234;
        /// <summary>
        /// <para>(0020,0060) Laterality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Laterality = 2097248;
        /// <summary>
        /// <para>(0020,0062) Image Laterality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageLaterality = 2097250;
        /// <summary>
        /// <para>(0020,0070) Image Geometry Type</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageGeometryTypeRetired = 2097264;
        /// <summary>
        /// <para>(0020,0080) Masking Image</para>
        /// <para> VR: CS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MaskingImageRetired = 2097280;
        /// <summary>
        /// <para>(0020,0100) Temporal Position Identifier</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint TemporalPositionIdentifier = 2097408;
        /// <summary>
        /// <para>(0020,0105) Number of Temporal Positions</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofTemporalPositions = 2097413;
        /// <summary>
        /// <para>(0020,0110) Temporal Resolution</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TemporalResolution = 2097424;
        /// <summary>
        /// <para>(0020,0200) Synchronization Frame of Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint SynchronizationFrameofReferenceUID = 2097664;
        /// <summary>
        /// <para>(0020,1000) Series in Study</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint SeriesinStudyRetired = 2101248;
        /// <summary>
        /// <para>(0020,1001) Acquisitions in Series</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AcquisitionsinSeriesRetired = 2101249;
        /// <summary>
        /// <para>(0020,1002) Images in Acquisition</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ImagesinAcquisition = 2101250;
        /// <summary>
        /// <para>(0020,1003) Images in Series</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImagesinSeriesRetired = 2101251;
        /// <summary>
        /// <para>(0020,1004) Acquisitions in Study</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AcquisitionsinStudyRetired = 2101252;
        /// <summary>
        /// <para>(0020,1005) Images in Study</para>
        /// <para> VR: IS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImagesinStudyRetired = 2101253;
        /// <summary>
        /// <para>(0020,1020) Reference</para>
        /// <para> VR: CS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferenceRetired = 2101280;
        /// <summary>
        /// <para>(0020,1040) Position Reference Indicator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PositionReferenceIndicator = 2101312;
        /// <summary>
        /// <para>(0020,1041) Slice Location</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SliceLocation = 2101313;
        /// <summary>
        /// <para>(0020,1070) Other Study Numbers</para>
        /// <para> VR: IS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OtherStudyNumbersRetired = 2101360;
        /// <summary>
        /// <para>(0020,1200) Number of Patient Related Studies</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPatientRelatedStudies = 2101760;
        /// <summary>
        /// <para>(0020,1202) Number of Patient Related Series</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPatientRelatedSeries = 2101762;
        /// <summary>
        /// <para>(0020,1204) Number of Patient Related Instances</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPatientRelatedInstances = 2101764;
        /// <summary>
        /// <para>(0020,1206) Number of Study Related Series</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofStudyRelatedSeries = 2101766;
        /// <summary>
        /// <para>(0020,1208) Number of Study Related Instances</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofStudyRelatedInstances = 2101768;
        /// <summary>
        /// <para>(0020,1209) Number of Series Related Instances</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofSeriesRelatedInstances = 2101769;
        /// <summary>
        /// <para>(0020,3100 to 31FF) Source Image IDs</para>
        /// <para> VR: CS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint SourceImageIDsRetired = 2109696;
        /// <summary>
        /// <para>(0020,3401) Modifying Device ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifyingDeviceIDRetired = 2110465;
        /// <summary>
        /// <para>(0020,3402) Modified Image ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifiedImageIDRetired = 2110466;
        /// <summary>
        /// <para>(0020,3403) Modified Image Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifiedImageDateRetired = 2110467;
        /// <summary>
        /// <para>(0020,3404) Modifying Device Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifyingDeviceManufacturerRetired = 2110468;
        /// <summary>
        /// <para>(0020,3405) Modified Image Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifiedImageTimeRetired = 2110469;
        /// <summary>
        /// <para>(0020,3406) Modified Image Description</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ModifiedImageDescriptionRetired = 2110470;
        /// <summary>
        /// <para>(0020,4000) Image Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint ImageComments = 2113536;
        /// <summary>
        /// <para>(0020,5000) Original Image Identification</para>
        /// <para> VR: AT VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OriginalImageIdentificationRetired = 2117632;
        /// <summary>
        /// <para>(0020,5002) Original Image Identification Nomenclature</para>
        /// <para> VR: CS VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OriginalImageIdentificationNomenclatureRetired = 2117634;
        /// <summary>
        /// <para>(0020,9056) Stack ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StackID = 2134102;
        /// <summary>
        /// <para>(0020,9057) In-Stack Position Number</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint InStackPositionNumber = 2134103;
        /// <summary>
        /// <para>(0020,9071) Frame Anatomy Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameAnatomySequence = 2134129;
        /// <summary>
        /// <para>(0020,9072) Frame Laterality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FrameLaterality = 2134130;
        /// <summary>
        /// <para>(0020,9111) Frame Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameContentSequence = 2134289;
        /// <summary>
        /// <para>(0020,9113) Plane Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PlanePositionSequence = 2134291;
        /// <summary>
        /// <para>(0020,9116) Plane Orientation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PlaneOrientationSequence = 2134294;
        /// <summary>
        /// <para>(0020,9128) Temporal Position Index</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint TemporalPositionIndex = 2134312;
        /// <summary>
        /// <para>(0020,9153) Cardiac Trigger Delay Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint CardiacTriggerDelayTime = 2134355;
        /// <summary>
        /// <para>(0020,9156) Frame Acquisition Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint FrameAcquisitionNumber = 2134358;
        /// <summary>
        /// <para>(0020,9157) Dimension Index Values</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint DimensionIndexValues = 2134359;
        /// <summary>
        /// <para>(0020,9158) Frame Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint FrameComments = 2134360;
        /// <summary>
        /// <para>(0020,9161) Concatenation UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ConcatenationUID = 2134369;
        /// <summary>
        /// <para>(0020,9162) In-concatenation Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint InconcatenationNumber = 2134370;
        /// <summary>
        /// <para>(0020,9163) In-concatenation Total Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint InconcatenationTotalNumber = 2134371;
        /// <summary>
        /// <para>(0020,9164) Dimension Organization UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint DimensionOrganizationUID = 2134372;
        /// <summary>
        /// <para>(0020,9165) Dimension Index Pointer</para>
        /// <para> VR: AT VM:1</para>
        /// </summary>
        public const uint DimensionIndexPointer = 2134373;
        /// <summary>
        /// <para>(0020,9167) Functional Group Pointer</para>
        /// <para> VR: AT VM:1</para>
        /// </summary>
        public const uint FunctionalGroupPointer = 2134375;
        /// <summary>
        /// <para>(0020,9213) Dimension Index Private Creator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DimensionIndexPrivateCreator = 2134547;
        /// <summary>
        /// <para>(0020,9221) Dimension Organization Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DimensionOrganizationSequence = 2134561;
        /// <summary>
        /// <para>(0020,9222) Dimension Index Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DimensionIndexSequence = 2134562;
        /// <summary>
        /// <para>(0020,9228) Concatenation Frame Offset Number</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint ConcatenationFrameOffsetNumber = 2134568;
        /// <summary>
        /// <para>(0020,9238) Functional Group Private Creator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FunctionalGroupPrivateCreator = 2134584;
        /// <summary>
        /// <para>(0020,9251) R – R Interval Time Measured</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RRIntervalTimeMeasured = 2134609;
        /// <summary>
        /// <para>(0020,9253) Respiratory Trigger Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RespiratoryTriggerSequence = 2134611;
        /// <summary>
        /// <para>(0020,9254) Respiratory Interval Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RespiratoryIntervalTime = 2134612;
        /// <summary>
        /// <para>(0020,9255) Respiratory Trigger Delay Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RespiratoryTriggerDelayTime = 2134613;
        /// <summary>
        /// <para>(0020,9256) Respiratory Trigger Delay Threshold</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RespiratoryTriggerDelayThreshold = 2134614;
        /// <summary>
        /// <para>(0020,9421) Dimension Description Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DimensionDescriptionLabel = 2135073;
        /// <summary>
        /// <para>(0020,9450) Patient Orientation in Frame Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientOrientationinFrameSequence = 2135120;
        /// <summary>
        /// <para>(0020,9453) Frame Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FrameLabel = 2135123;
        /// <summary>
        /// <para>(0022,0001) Light Path Filter Pass-Through Wavelength</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint LightPathFilterPassThroughWavelength = 2228225;
        /// <summary>
        /// <para>(0022,0002) Light Path Filter Pass Band</para>
        /// <para> VR: US VM:2</para>
        /// </summary>
        public const uint LightPathFilterPassBand = 2228226;
        /// <summary>
        /// <para>(0022,0003) Image Path Filter Pass-Through Wavelength</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImagePathFilterPassThroughWavelength = 2228227;
        /// <summary>
        /// <para>(0022,0004) Image Path Filter Pass Band</para>
        /// <para> VR: US VM:2</para>
        /// </summary>
        public const uint ImagePathFilterPassBand = 2228228;
        /// <summary>
        /// <para>(0022,0005) Patient Eye Movement Commanded</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientEyeMovementCommanded = 2228229;
        /// <summary>
        /// <para>(0022,0006) Patient Eye Movement Command Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientEyeMovementCommandCodeSequence = 2228230;
        /// <summary>
        /// <para>(0022,0007) Spherical Lens Power</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint SphericalLensPower = 2228231;
        /// <summary>
        /// <para>(0022,0008) Cylinder Lens Power</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CylinderLensPower = 2228232;
        /// <summary>
        /// <para>(0022,0009) Cylinder Axis</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CylinderAxis = 2228233;
        /// <summary>
        /// <para>(0022,000A) Emmetropic Magnification</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint EmmetropicMagnification = 2228234;
        /// <summary>
        /// <para>(0022,000B) Intra Ocular Pressure</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IntraOcularPressure = 2228235;
        /// <summary>
        /// <para>(0022,000C) Horizontal Field of View</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint HorizontalFieldofView = 2228236;
        /// <summary>
        /// <para>(0022,000D) Pupil Dilated</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PupilDilated = 2228237;
        /// <summary>
        /// <para>(0022,000E) Degree of Dilation</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint DegreeofDilation = 2228238;
        /// <summary>
        /// <para>(0022,0010) Stereo Baseline Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint StereoBaselineAngle = 2228240;
        /// <summary>
        /// <para>(0022,0011) Stereo Baseline Displacement</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint StereoBaselineDisplacement = 2228241;
        /// <summary>
        /// <para>(0022,0012) Stereo Horizontal Pixel Offset</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint StereoHorizontalPixelOffset = 2228242;
        /// <summary>
        /// <para>(0022,0013) Stereo Vertical Pixel Offset</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint StereoVerticalPixelOffset = 2228243;
        /// <summary>
        /// <para>(0022,0014) Stereo Rotation</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint StereoRotation = 2228244;
        /// <summary>
        /// <para>(0022,0015) Acquisition Device Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AcquisitionDeviceTypeCodeSequence = 2228245;
        /// <summary>
        /// <para>(0022,0016) Illumination Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IlluminationTypeCodeSequence = 2228246;
        /// <summary>
        /// <para>(0022,0017) Light Path Filter Type Stack Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint LightPathFilterTypeStackCodeSequence = 2228247;
        /// <summary>
        /// <para>(0022,0018) Image Path Filter Type Stack Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ImagePathFilterTypeStackCodeSequence = 2228248;
        /// <summary>
        /// <para>(0022,0019) Lenses Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint LensesCodeSequence = 2228249;
        /// <summary>
        /// <para>(0022,001A) Channel Description Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelDescriptionCodeSequence = 2228250;
        /// <summary>
        /// <para>(0022,001B) Refractive State Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RefractiveStateSequence = 2228251;
        /// <summary>
        /// <para>(0022,001C) Mydriatic Agent Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MydriaticAgentCodeSequence = 2228252;
        /// <summary>
        /// <para>(0022,001D) Relative Image Position Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RelativeImagePositionCodeSequence = 2228253;
        /// <summary>
        /// <para>(0022,0020) Stereo Pairs Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint StereoPairsSequence = 2228256;
        /// <summary>
        /// <para>(0022,0021) Left Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint LeftImageSequence = 2228257;
        /// <summary>
        /// <para>(0022,0022) Right Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RightImageSequence = 2228258;
        /// <summary>
        /// <para>(0028,0002) Samples per Pixel</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint SamplesperPixel = 2621442;
        /// <summary>
        /// <para>(0028,0003) Samples per Pixel Used</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint SamplesperPixelUsed = 2621443;
        /// <summary>
        /// <para>(0028,0004) Photometric Interpretation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PhotometricInterpretation = 2621444;
        /// <summary>
        /// <para>(0028,0005) Image Dimensions</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageDimensionsRetired = 2621445;
        /// <summary>
        /// <para>(0028,0006) Planar Configuration</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PlanarConfiguration = 2621446;
        /// <summary>
        /// <para>(0028,0008) Number of Frames</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofFrames = 2621448;
        /// <summary>
        /// <para>(0028,0009) Frame Increment Pointer</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint FrameIncrementPointer = 2621449;
        /// <summary>
        /// <para>(0028,000A) Frame Dimension Pointer</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint FrameDimensionPointer = 2621450;
        /// <summary>
        /// <para>(0028,0010) Rows</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Rows = 2621456;
        /// <summary>
        /// <para>(0028,0011) Columns</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Columns = 2621457;
        /// <summary>
        /// <para>(0028,0012) Planes</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Planes = 2621458;
        /// <summary>
        /// <para>(0028,0014) Ultrasound Color Data Present</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint UltrasoundColorDataPresent = 2621460;
        /// <summary>
        /// <para>(0028,0030) Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint PixelSpacing = 2621488;
        /// <summary>
        /// <para>(0028,0031) Zoom Factor</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint ZoomFactor = 2621489;
        /// <summary>
        /// <para>(0028,0032) Zoom Center</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint ZoomCenter = 2621490;
        /// <summary>
        /// <para>(0028,0034) Pixel Aspect Ratio</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint PixelAspectRatio = 2621492;
        /// <summary>
        /// <para>(0028,0040) Image Format</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageFormatRetired = 2621504;
        /// <summary>
        /// <para>(0028,0050) Manipulated Image</para>
        /// <para> VR: LO VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ManipulatedImageRetired = 2621520;
        /// <summary>
        /// <para>(0028,0051) Corrected Image</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint CorrectedImage = 2621521;
        /// <summary>
        /// <para>(0028,0060) Compression Code</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CompressionCodeRetired = 2621536;
        /// <summary>
        /// <para>(0028,0100) Bits Allocated</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint BitsAllocated = 2621696;
        /// <summary>
        /// <para>(0028,0101) Bits Stored</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint BitsStored = 2621697;
        /// <summary>
        /// <para>(0028,0102) High Bit</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint HighBit = 2621698;
        /// <summary>
        /// <para>(0028,0103) Pixel Representation</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PixelRepresentation = 2621699;
        /// <summary>
        /// <para>(0028,0104) Smallest Valid Pixel Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint SmallestValidPixelValueRetired = 2621700;
        /// <summary>
        /// <para>(0028,0105) Largest Valid Pixel Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LargestValidPixelValueRetired = 2621701;
        /// <summary>
        /// <para>(0028,0106) Smallest Image Pixel Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint SmallestImagePixelValue = 2621702;
        /// <summary>
        /// <para>(0028,0107) Largest Image Pixel Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint LargestImagePixelValue = 2621703;
        /// <summary>
        /// <para>(0028,0108) Smallest Pixel Value in Series</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint SmallestPixelValueinSeries = 2621704;
        /// <summary>
        /// <para>(0028,0109) Largest Pixel Value in Series</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint LargestPixelValueinSeries = 2621705;
        /// <summary>
        /// <para>(0028,0110) Smallest Image Pixel Value in Plane</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint SmallestImagePixelValueinPlane = 2621712;
        /// <summary>
        /// <para>(0028,0111) Largest Image Pixel Value in Plane</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint LargestImagePixelValueinPlane = 2621713;
        /// <summary>
        /// <para>(0028,0120) Pixel Padding Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint PixelPaddingValue = 2621728;
        /// <summary>
        /// <para>(0028,0200) Image Location</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageLocationRetired = 2621952;
        /// <summary>
        /// <para>(0028,0300) Quality Control Image</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint QualityControlImage = 2622208;
        /// <summary>
        /// <para>(0028,0301) Burned In Annotation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BurnedInAnnotation = 2622209;
        /// <summary>
        /// <para>(0028,0402) Pixel Spacing Calibration Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PixelSpacingCalibrationType = 2622466;
        /// <summary>
        /// <para>(0028,0404) Pixel Spacing Calibration Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PixelSpacingCalibrationDescription = 2622468;
        /// <summary>
        /// <para>(0028,1040) Pixel Intensity Relationship</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PixelIntensityRelationship = 2625600;
        /// <summary>
        /// <para>(0028,1041) Pixel Intensity Relationship Sign</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint PixelIntensityRelationshipSign = 2625601;
        /// <summary>
        /// <para>(0028,1050) Window Center</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint WindowCenter = 2625616;
        /// <summary>
        /// <para>(0028,1051) Window Width</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint WindowWidth = 2625617;
        /// <summary>
        /// <para>(0028,1052) Rescale Intercept</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RescaleIntercept = 2625618;
        /// <summary>
        /// <para>(0028,1053) Rescale Slope</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RescaleSlope = 2625619;
        /// <summary>
        /// <para>(0028,1054) Rescale Type</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RescaleType = 2625620;
        /// <summary>
        /// <para>(0028,1055) Window Center & Width Explanation</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint WindowCenterWidthExplanation = 2625621;
        /// <summary>
        /// <para>(0028,1056) VOI LUT Function</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VOILUTFunction = 2625622;
        /// <summary>
        /// <para>(0028,1080) Gray Scale</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint GrayScaleRetired = 2625664;
        /// <summary>
        /// <para>(0028,1090) Recommended Viewing Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RecommendedViewingMode = 2625680;
        /// <summary>
        /// <para>(0028,1100) Gray Lookup Table Descriptor </para>
        /// <para> VR: US or SS VM:3</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint GrayLookupTableDescriptorRetired = 2625792;
        /// <summary>
        /// <para>(0028,1101) Red Palette Color Lookup Table Descriptor </para>
        /// <para> VR: US or SS VM:3</para>
        /// </summary>
        public const uint RedPaletteColorLookupTableDescriptor = 2625793;
        /// <summary>
        /// <para>(0028,1102) Green Palette Color Lookup Table Descriptor </para>
        /// <para> VR: US or SS VM:3</para>
        /// </summary>
        public const uint GreenPaletteColorLookupTableDescriptor = 2625794;
        /// <summary>
        /// <para>(0028,1103) Blue Palette Color Lookup Table Descriptor </para>
        /// <para> VR: US or SS VM:3</para>
        /// </summary>
        public const uint BluePaletteColorLookupTableDescriptor = 2625795;
        /// <summary>
        /// <para>(0028,1199) Palette Color Lookup Table UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint PaletteColorLookupTableUID = 2625945;
        /// <summary>
        /// <para>(0028,1200) Gray Lookup Table Data</para>
        /// <para> VR: US or SSor OW VM:1-n1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint GrayLookupTableDataRetired = 2626048;
        /// <summary>
        /// <para>(0028,1201) Red Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint RedPaletteColorLookupTableData = 2626049;
        /// <summary>
        /// <para>(0028,1202) Green Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint GreenPaletteColorLookupTableData = 2626050;
        /// <summary>
        /// <para>(0028,1203) Blue Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint BluePaletteColorLookupTableData = 2626051;
        /// <summary>
        /// <para>(0028,1221) Segmented Red Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint SegmentedRedPaletteColorLookupTableData = 2626081;
        /// <summary>
        /// <para>(0028,1222) Segmented Green Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint SegmentedGreenPaletteColorLookupTableData = 2626082;
        /// <summary>
        /// <para>(0028,1223) Segmented Blue Palette Color Lookup Table Data</para>
        /// <para> VR: OW VM:1</para>
        /// </summary>
        public const uint SegmentedBluePaletteColorLookupTableData = 2626083;
        /// <summary>
        /// <para>(0028,1300) Implant Present</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImplantPresent = 2626304;
        /// <summary>
        /// <para>(0028,1350) Partial View</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PartialView = 2626384;
        /// <summary>
        /// <para>(0028,1351) Partial View Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint PartialViewDescription = 2626385;
        /// <summary>
        /// <para>(0028,1352) Partial View Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PartialViewCodeSequence = 2626386;
        /// <summary>
        /// <para>(0028,135A) Spatial Locations Preserved</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SpatialLocationsPreserved = 2626394;
        /// <summary>
        /// <para>(0028,2000) ICC Profile</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint ICCProfile = 2629632;
        /// <summary>
        /// <para>(0028,2110) Lossy Image Compression</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint LossyImageCompression = 2629904;
        /// <summary>
        /// <para>(0028,2112) Lossy Image Compression Ratio</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint LossyImageCompressionRatio = 2629906;
        /// <summary>
        /// <para>(0028,2114) Lossy Image Compression Method</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint LossyImageCompressionMethod = 2629908;
        /// <summary>
        /// <para>(0028,3000) Modality LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ModalityLUTSequence = 2633728;
        /// <summary>
        /// <para>(0028,3002) LUT Descriptor</para>
        /// <para> VR: US or SS VM:3</para>
        /// </summary>
        public const uint LUTDescriptor = 2633730;
        /// <summary>
        /// <para>(0028,3003) LUT Explanation</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint LUTExplanation = 2633731;
        /// <summary>
        /// <para>(0028,3004) Modality LUT Type</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ModalityLUTType = 2633732;
        /// <summary>
        /// <para>(0028,3006) LUT Data</para>
        /// <para> VR: US or SSor OW VM:1-n1</para>
        /// </summary>
        public const uint LUTData = 2633734;
        /// <summary>
        /// <para>(0028,3010) VOI LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint VOILUTSequence = 2633744;
        /// <summary>
        /// <para>(0028,3110) Softcopy VOI LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SoftcopyVOILUTSequence = 2634000;
        /// <summary>
        /// <para>(0028,4000) Image Presentation Comments</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImagePresentationCommentsRetired = 2637824;
        /// <summary>
        /// <para>(0028,5000) Bi-Plane Acquisition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BiPlaneAcquisitionSequence = 2641920;
        /// <summary>
        /// <para>(0028,6010) Representative Frame Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RepresentativeFrameNumber = 2646032;
        /// <summary>
        /// <para>(0028,6020) Frame Numbers of Interest (FOI) </para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint FrameNumbersofInterestFOI = 2646048;
        /// <summary>
        /// <para>(0028,6022) Frame(s) of Interest Description</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint FramesofInterestDescription = 2646050;
        /// <summary>
        /// <para>(0028,6023) Frame of Interest Type</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint FrameofInterestType = 2646051;
        /// <summary>
        /// <para>(0028,6030) Mask Pointer(s)</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MaskPointersRetired = 2646064;
        /// <summary>
        /// <para>(0028,6040) R Wave Pointer</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint RWavePointer = 2646080;
        /// <summary>
        /// <para>(0028,6100) Mask Subtraction Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MaskSubtractionSequence = 2646272;
        /// <summary>
        /// <para>(0028,6101) Mask Operation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MaskOperation = 2646273;
        /// <summary>
        /// <para>(0028,6102) Applicable Frame Range</para>
        /// <para> VR: US VM:2-2n</para>
        /// </summary>
        public const uint ApplicableFrameRange = 2646274;
        /// <summary>
        /// <para>(0028,6110) Mask Frame Numbers</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint MaskFrameNumbers = 2646288;
        /// <summary>
        /// <para>(0028,6112) Contrast Frame Averaging</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ContrastFrameAveraging = 2646290;
        /// <summary>
        /// <para>(0028,6114) Mask Sub-pixel Shift</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint MaskSubpixelShift = 2646292;
        /// <summary>
        /// <para>(0028,6120) TID Offset</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint TIDOffset = 2646304;
        /// <summary>
        /// <para>(0028,6190) Mask Operation Explanation</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint MaskOperationExplanation = 2646416;
        /// <summary>
        /// <para>(0028,7FE0) Pixel Data Provider URL</para>
        /// <para> VR: UT VM:1</para>
        /// </summary>
        public const uint PixelDataProviderURL = 2654176;
        /// <summary>
        /// <para>(0028,9001) Data Point Rows</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint DataPointRows = 2658305;
        /// <summary>
        /// <para>(0028,9002) Data Point Columns</para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint DataPointColumns = 2658306;
        /// <summary>
        /// <para>(0028,9003) Signal Domain Columns</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SignalDomainColumns = 2658307;
        /// <summary>
        /// <para>(0028,9099) Largest Monochrome Pixel Value</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint LargestMonochromePixelValueRetired = 2658457;
        /// <summary>
        /// <para>(0028,9108) Data Representation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DataRepresentation = 2658568;
        /// <summary>
        /// <para>(0028,9110) Pixel Measures Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PixelMeasuresSequence = 2658576;
        /// <summary>
        /// <para>(0028,9132) Frame VOI LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameVOILUTSequence = 2658610;
        /// <summary>
        /// <para>(0028,9145) Pixel Value Transformation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PixelValueTransformationSequence = 2658629;
        /// <summary>
        /// <para>(0028,9235) Signal Domain Rows</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SignalDomainRows = 2658869;
        /// <summary>
        /// <para>(0028,9411) Display Filter Percentage</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint DisplayFilterPercentage = 2659345;
        /// <summary>
        /// <para>(0028,9415) Frame Pixel Shift Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FramePixelShiftSequence = 2659349;
        /// <summary>
        /// <para>(0028,9416) Subtraction Item ID</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint SubtractionItemID = 2659350;
        /// <summary>
        /// <para>(0028,9422) Pixel Intensity Relationship LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PixelIntensityRelationshipLUTSequence = 2659362;
        /// <summary>
        /// <para>(0028,9443) Frame Pixel Data Properties Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FramePixelDataPropertiesSequence = 2659395;
        /// <summary>
        /// <para>(0028,9444) Geometrical Properties</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GeometricalProperties = 2659396;
        /// <summary>
        /// <para>(0028,9445) Geometric Maximum Distortion</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint GeometricMaximumDistortion = 2659397;
        /// <summary>
        /// <para>(0028,9446) Image Processing Applied</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ImageProcessingApplied = 2659398;
        /// <summary>
        /// <para>(0028,9454) Mask Selection Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MaskSelectionMode = 2659412;
        /// <summary>
        /// <para>(0028,9474) LUT Function</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint LUTFunction = 2659444;
        /// <summary>
        /// <para>(0032,000A) Study Status ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyStatusIDRetired = 3276810;
        /// <summary>
        /// <para>(0032,000C) Study Priority ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyPriorityIDRetired = 3276812;
        /// <summary>
        /// <para>(0032,0012) Study ID Issuer</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyIDIssuerRetired = 3276818;
        /// <summary>
        /// <para>(0032,0032) Study Verified Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyVerifiedDateRetired = 3276850;
        /// <summary>
        /// <para>(0032,0033) Study Verified Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyVerifiedTimeRetired = 3276851;
        /// <summary>
        /// <para>(0032,0034) Study Read Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyReadDateRetired = 3276852;
        /// <summary>
        /// <para>(0032,0035) Study Read Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyReadTimeRetired = 3276853;
        /// <summary>
        /// <para>(0032,1000) Scheduled Study Start Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyStartDateRetired = 3280896;
        /// <summary>
        /// <para>(0032,1001) Scheduled Study Start Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyStartTimeRetired = 3280897;
        /// <summary>
        /// <para>(0032,1010) Scheduled Study Stop Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyStopDateRetired = 3280912;
        /// <summary>
        /// <para>(0032,1011) Scheduled Study Stop Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyStopTimeRetired = 3280913;
        /// <summary>
        /// <para>(0032,1020) Scheduled Study Location</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyLocationRetired = 3280928;
        /// <summary>
        /// <para>(0032,1021) Scheduled Study Location AE Title</para>
        /// <para> VR: AE VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledStudyLocationAETitleRetired = 3280929;
        /// <summary>
        /// <para>(0032,1030) Reason for Study</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReasonforStudyRetired = 3280944;
        /// <summary>
        /// <para>(0032,1031) Requesting Physician Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RequestingPhysicianIdentificationSequence = 3280945;
        /// <summary>
        /// <para>(0032,1032) Requesting Physician</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint RequestingPhysician = 3280946;
        /// <summary>
        /// <para>(0032,1033) Requesting Service</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RequestingService = 3280947;
        /// <summary>
        /// <para>(0032,1040) Study Arrival Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyArrivalDateRetired = 3280960;
        /// <summary>
        /// <para>(0032,1041) Study Arrival Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyArrivalTimeRetired = 3280961;
        /// <summary>
        /// <para>(0032,1050) Study Completion Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyCompletionDateRetired = 3280976;
        /// <summary>
        /// <para>(0032,1051) Study Completion Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyCompletionTimeRetired = 3280977;
        /// <summary>
        /// <para>(0032,1055) Study Component Status ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint StudyComponentStatusIDRetired = 3280981;
        /// <summary>
        /// <para>(0032,1060) Requested Procedure Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RequestedProcedureDescription = 3280992;
        /// <summary>
        /// <para>(0032,1064) Requested Procedure Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RequestedProcedureCodeSequence = 3280996;
        /// <summary>
        /// <para>(0032,1070) Requested Contrast Agent</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RequestedContrastAgent = 3281008;
        /// <summary>
        /// <para>(0032,4000) Study Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint StudyComments = 3293184;
        /// <summary>
        /// <para>(0038,0004) Referenced Patient Alias Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedPatientAliasSequence = 3670020;
        /// <summary>
        /// <para>(0038,0008) Visit Status ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VisitStatusID = 3670024;
        /// <summary>
        /// <para>(0038,0010) Admission ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AdmissionID = 3670032;
        /// <summary>
        /// <para>(0038,0011) Issuer of Admission ID</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint IssuerofAdmissionID = 3670033;
        /// <summary>
        /// <para>(0038,0016) Route of Admissions</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RouteofAdmissions = 3670038;
        /// <summary>
        /// <para>(0038,001A) Scheduled Admission Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledAdmissionDateRetired = 3670042;
        /// <summary>
        /// <para>(0038,001B) Scheduled Admission Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledAdmissionTimeRetired = 3670043;
        /// <summary>
        /// <para>(0038,001C) Scheduled Discharge Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledDischargeDateRetired = 3670044;
        /// <summary>
        /// <para>(0038,001D) Scheduled Discharge Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledDischargeTimeRetired = 3670045;
        /// <summary>
        /// <para>(0038,001E) Scheduled Patient Institution Residence</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ScheduledPatientInstitutionResidenceRetired = 3670046;
        /// <summary>
        /// <para>(0038,0020) Admitting Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint AdmittingDate = 3670048;
        /// <summary>
        /// <para>(0038,0021) Admitting Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint AdmittingTime = 3670049;
        /// <summary>
        /// <para>(0038,0030) Discharge Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DischargeDateRetired = 3670064;
        /// <summary>
        /// <para>(0038,0032) Discharge Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DischargeTimeRetired = 3670066;
        /// <summary>
        /// <para>(0038,0040) Discharge Diagnosis Description</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DischargeDiagnosisDescriptionRetired = 3670080;
        /// <summary>
        /// <para>(0038,0044) Discharge Diagnosis Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DischargeDiagnosisCodeSequenceRetired = 3670084;
        /// <summary>
        /// <para>(0038,0050) Special Needs</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SpecialNeeds = 3670096;
        /// <summary>
        /// <para>(0038,0100) Pertinent Documents Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PertinentDocumentsSequence = 3670272;
        /// <summary>
        /// <para>(0038,0300) Current Patient Location</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CurrentPatientLocation = 3670784;
        /// <summary>
        /// <para>(0038,0400) Patient’s Institution Residence</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientsInstitutionResidence = 3671040;
        /// <summary>
        /// <para>(0038,0500) Patient State</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientState = 3671296;
        /// <summary>
        /// <para>(0038,0502) Patient Clinical Trial Participation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientClinicalTrialParticipationSequence = 3671298;
        /// <summary>
        /// <para>(0038,4000) Visit Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint VisitComments = 3686400;
        /// <summary>
        /// <para>(003A,0004) Waveform Originality</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint WaveformOriginality = 3801092;
        /// <summary>
        /// <para>(003A,0005) Number of Waveform Channels </para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofWaveformChannels = 3801093;
        /// <summary>
        /// <para>(003A,0010) Number of Waveform Samples </para>
        /// <para> VR: UL VM:1</para>
        /// </summary>
        public const uint NumberofWaveformSamples = 3801104;
        /// <summary>
        /// <para>(003A,001A) Sampling Frequency </para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SamplingFrequency = 3801114;
        /// <summary>
        /// <para>(003A,0020) Multiplex Group Label </para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint MultiplexGroupLabel = 3801120;
        /// <summary>
        /// <para>(003A,0200) Channel Definition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelDefinitionSequence = 3801600;
        /// <summary>
        /// <para>(003A,0202) Waveform Channel Number </para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint WaveformChannelNumber = 3801602;
        /// <summary>
        /// <para>(003A,0203) Channel Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ChannelLabel = 3801603;
        /// <summary>
        /// <para>(003A,0205) Channel Status</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint ChannelStatus = 3801605;
        /// <summary>
        /// <para>(003A,0208) Channel Source Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelSourceSequence = 3801608;
        /// <summary>
        /// <para>(003A,0209) Channel Source Modifiers Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelSourceModifiersSequence = 3801609;
        /// <summary>
        /// <para>(003A,020A) Source Waveform Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceWaveformSequence = 3801610;
        /// <summary>
        /// <para>(003A,020C) Channel Derivation Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ChannelDerivationDescription = 3801612;
        /// <summary>
        /// <para>(003A,0210) Channel Sensitivity </para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelSensitivity = 3801616;
        /// <summary>
        /// <para>(003A,0211) Channel Sensitivity Units Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelSensitivityUnitsSequence = 3801617;
        /// <summary>
        /// <para>(003A,0212) Channel Sensitivity Correction Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelSensitivityCorrectionFactor = 3801618;
        /// <summary>
        /// <para>(003A,0213) Channel Baseline </para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelBaseline = 3801619;
        /// <summary>
        /// <para>(003A,0214) Channel Time Skew</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelTimeSkew = 3801620;
        /// <summary>
        /// <para>(003A,0215) Channel Sample Skew</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelSampleSkew = 3801621;
        /// <summary>
        /// <para>(003A,0218) Channel Offset</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelOffset = 3801624;
        /// <summary>
        /// <para>(003A,021A) Waveform Bits Stored</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint WaveformBitsStored = 3801626;
        /// <summary>
        /// <para>(003A,0220) Filter Low Frequency</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FilterLowFrequency = 3801632;
        /// <summary>
        /// <para>(003A,0221) Filter High Frequency</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FilterHighFrequency = 3801633;
        /// <summary>
        /// <para>(003A,0222) Notch Filter Frequency</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint NotchFilterFrequency = 3801634;
        /// <summary>
        /// <para>(003A,0223) Notch Filter Bandwidth</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint NotchFilterBandwidth = 3801635;
        /// <summary>
        /// <para>(003A,0300) Multiplexed Audio Channels Description Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MultiplexedAudioChannelsDescriptionCodeSequence = 3801856;
        /// <summary>
        /// <para>(003A,0301) Channel Identification Code</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ChannelIdentificationCode = 3801857;
        /// <summary>
        /// <para>(003A,0302) Channel Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ChannelMode = 3801858;
        /// <summary>
        /// <para>(0040,0001) Scheduled Station AE Title</para>
        /// <para> VR: AE VM:1-n</para>
        /// </summary>
        public const uint ScheduledStationAETitle = 4194305;
        /// <summary>
        /// <para>(0040,0002) Scheduled Procedure Step Start Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepStartDate = 4194306;
        /// <summary>
        /// <para>(0040,0003) Scheduled Procedure Step Start Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepStartTime = 4194307;
        /// <summary>
        /// <para>(0040,0004) Scheduled Procedure Step End Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepEndDate = 4194308;
        /// <summary>
        /// <para>(0040,0005) Scheduled Procedure Step End Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepEndTime = 4194309;
        /// <summary>
        /// <para>(0040,0006) Scheduled Performing Physician’s Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ScheduledPerformingPhysiciansName = 4194310;
        /// <summary>
        /// <para>(0040,0007) Scheduled Procedure Step Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepDescription = 4194311;
        /// <summary>
        /// <para>(0040,0008) Scheduled Protocol Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledProtocolCodeSequence = 4194312;
        /// <summary>
        /// <para>(0040,0009) Scheduled Procedure Step ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepID = 4194313;
        /// <summary>
        /// <para>(0040,000A) Stage Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint StageCodeSequence = 4194314;
        /// <summary>
        /// <para>(0040,000B) Scheduled Performing Physician Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledPerformingPhysicianIdentificationSequence = 4194315;
        /// <summary>
        /// <para>(0040,0010) Scheduled Station Name</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint ScheduledStationName = 4194320;
        /// <summary>
        /// <para>(0040,0011) Scheduled Procedure Step Location</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepLocation = 4194321;
        /// <summary>
        /// <para>(0040,0012) Pre-Medication</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PreMedication = 4194322;
        /// <summary>
        /// <para>(0040,0020) Scheduled Procedure Step Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepStatus = 4194336;
        /// <summary>
        /// <para>(0040,0100) Scheduled Procedure Step Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepSequence = 4194560;
        /// <summary>
        /// <para>(0040,0220) Referenced Non-Image Composite SOP Instance Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedNonImageCompositeSOPInstanceSequence = 4194848;
        /// <summary>
        /// <para>(0040,0241) Performed Station AE Title</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint PerformedStationAETitle = 4194881;
        /// <summary>
        /// <para>(0040,0242) Performed Station Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PerformedStationName = 4194882;
        /// <summary>
        /// <para>(0040,0243) Performed Location</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PerformedLocation = 4194883;
        /// <summary>
        /// <para>(0040,0244) Performed Procedure Step Start Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepStartDate = 4194884;
        /// <summary>
        /// <para>(0040,0245) Performed Procedure Step Start Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepStartTime = 4194885;
        /// <summary>
        /// <para>(0040,0250) Performed Procedure Step End Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepEndDate = 4194896;
        /// <summary>
        /// <para>(0040,0251) Performed Procedure Step End Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepEndTime = 4194897;
        /// <summary>
        /// <para>(0040,0252) Performed Procedure Step Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepStatus = 4194898;
        /// <summary>
        /// <para>(0040,0253) Performed Procedure Step ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepID = 4194899;
        /// <summary>
        /// <para>(0040,0254) Performed Procedure Step Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepDescription = 4194900;
        /// <summary>
        /// <para>(0040,0255) Performed Procedure Type Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PerformedProcedureTypeDescription = 4194901;
        /// <summary>
        /// <para>(0040,0260) Performed Protocol Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedProtocolCodeSequence = 4194912;
        /// <summary>
        /// <para>(0040,0270) Scheduled Step Attributes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledStepAttributesSequence = 4194928;
        /// <summary>
        /// <para>(0040,0275) Request Attributes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RequestAttributesSequence = 4194933;
        /// <summary>
        /// <para>(0040,0280) Comments on the Performed Procedure Step</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint CommentsonthePerformedProcedureStep = 4194944;
        /// <summary>
        /// <para>(0040,0281) Performed Procedure Step Discontinuation Reason Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedProcedureStepDiscontinuationReasonCodeSequence = 4194945;
        /// <summary>
        /// <para>(0040,0293) Quantity Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint QuantitySequence = 4194963;
        /// <summary>
        /// <para>(0040,0294) Quantity</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint Quantity = 4194964;
        /// <summary>
        /// <para>(0040,0295) Measuring Units Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MeasuringUnitsSequence = 4194965;
        /// <summary>
        /// <para>(0040,0296) Billing Item Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BillingItemSequence = 4194966;
        /// <summary>
        /// <para>(0040,0300) Total Time of Fluoroscopy</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint TotalTimeofFluoroscopy = 4195072;
        /// <summary>
        /// <para>(0040,0301) Total Number of Exposures</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint TotalNumberofExposures = 4195073;
        /// <summary>
        /// <para>(0040,0302) Entrance Dose</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint EntranceDose = 4195074;
        /// <summary>
        /// <para>(0040,0303) Exposed Area</para>
        /// <para> VR: US VM:1-2</para>
        /// </summary>
        public const uint ExposedArea = 4195075;
        /// <summary>
        /// <para>(0040,0306) Distance Source to Entrance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DistanceSourcetoEntrance = 4195078;
        /// <summary>
        /// <para>(0040,0307) Distance Source to Support</para>
        /// <para> VR: DS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DistanceSourcetoSupportRetired = 4195079;
        /// <summary>
        /// <para>(0040,030E) Exposure Dose Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ExposureDoseSequence = 4195086;
        /// <summary>
        /// <para>(0040,0310) Comments on Radiation Dose</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint CommentsonRadiationDose = 4195088;
        /// <summary>
        /// <para>(0040,0312) X-Ray Output</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint XRayOutput = 4195090;
        /// <summary>
        /// <para>(0040,0314) Half Value Layer</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint HalfValueLayer = 4195092;
        /// <summary>
        /// <para>(0040,0316) Organ Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint OrganDose = 4195094;
        /// <summary>
        /// <para>(0040,0318) Organ Exposed</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OrganExposed = 4195096;
        /// <summary>
        /// <para>(0040,0320) Billing Procedure Step Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BillingProcedureStepSequence = 4195104;
        /// <summary>
        /// <para>(0040,0321) Film Consumption Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FilmConsumptionSequence = 4195105;
        /// <summary>
        /// <para>(0040,0324) Billing Supplies and Devices Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BillingSuppliesandDevicesSequence = 4195108;
        /// <summary>
        /// <para>(0040,0330) Referenced Procedure Step Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedProcedureStepSequenceRetired = 4195120;
        /// <summary>
        /// <para>(0040,0340) Performed Series Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedSeriesSequence = 4195136;
        /// <summary>
        /// <para>(0040,0400) Comments on the Scheduled Procedure Step</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint CommentsontheScheduledProcedureStep = 4195328;
        /// <summary>
        /// <para>(0040,0440) Protocol Context Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ProtocolContextSequence = 4195392;
        /// <summary>
        /// <para>(0040,0441) Content Item Modifier Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContentItemModifierSequence = 4195393;
        /// <summary>
        /// <para>(0040,050A) Specimen Accession Number</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SpecimenAccessionNumber = 4195594;
        /// <summary>
        /// <para>(0040,0550) Specimen Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SpecimenSequence = 4195664;
        /// <summary>
        /// <para>(0040,0551) Specimen Identifier</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SpecimenIdentifier = 4195665;
        /// <summary>
        /// <para>(0040,0555) Acquisition Context Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AcquisitionContextSequence = 4195669;
        /// <summary>
        /// <para>(0040,0556) Acquisition Context Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint AcquisitionContextDescription = 4195670;
        /// <summary>
        /// <para>(0040,059A) Specimen Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SpecimenTypeCodeSequence = 4195738;
        /// <summary>
        /// <para>(0040,06FA) Slide Identifier</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SlideIdentifier = 4196090;
        /// <summary>
        /// <para>(0040,071A) Image Center Point Coordinates Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ImageCenterPointCoordinatesSequence = 4196122;
        /// <summary>
        /// <para>(0040,072A) X offset in Slide Coordinate System</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint XoffsetinSlideCoordinateSystem = 4196138;
        /// <summary>
        /// <para>(0040,073A) Y offset in Slide Coordinate System</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint YoffsetinSlideCoordinateSystem = 4196154;
        /// <summary>
        /// <para>(0040,074A) Z offset in Slide Coordinate System</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ZoffsetinSlideCoordinateSystem = 4196170;
        /// <summary>
        /// <para>(0040,08D8) Pixel Spacing Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PixelSpacingSequence = 4196568;
        /// <summary>
        /// <para>(0040,08DA) Coordinate System Axis Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CoordinateSystemAxisCodeSequence = 4196570;
        /// <summary>
        /// <para>(0040,08EA) Measurement Units Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MeasurementUnitsCodeSequence = 4196586;
        /// <summary>
        /// <para>(0040,1001) Requested Procedure ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RequestedProcedureID = 4198401;
        /// <summary>
        /// <para>(0040,1002) Reason for the Requested Procedure</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ReasonfortheRequestedProcedure = 4198402;
        /// <summary>
        /// <para>(0040,1003) Requested Procedure Priority </para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RequestedProcedurePriority = 4198403;
        /// <summary>
        /// <para>(0040,1004) Patient Transport Arrangements</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientTransportArrangements = 4198404;
        /// <summary>
        /// <para>(0040,1005) Requested Procedure Location</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RequestedProcedureLocation = 4198405;
        /// <summary>
        /// <para>(0040,1006) Placer Order Number / Procedure</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PlacerOrderNumberProcedureRetired = 4198406;
        /// <summary>
        /// <para>(0040,1007) Filler Order Number / Procedure</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint FillerOrderNumberProcedureRetired = 4198407;
        /// <summary>
        /// <para>(0040,1008) Confidentiality Code</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ConfidentialityCode = 4198408;
        /// <summary>
        /// <para>(0040,1009) Reporting Priority</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ReportingPriority = 4198409;
        /// <summary>
        /// <para>(0040,100A) Reason for Requested Procedure Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReasonforRequestedProcedureCodeSequence = 4198410;
        /// <summary>
        /// <para>(0040,1010) Names of Intended Recipients of Results</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint NamesofIntendedRecipientsofResults = 4198416;
        /// <summary>
        /// <para>(0040,1011) Intended Recipients of Results Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IntendedRecipientsofResultsIdentificationSequence = 4198417;
        /// <summary>
        /// <para>(0040,1101) Person Identification Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PersonIdentificationCodeSequence = 4198657;
        /// <summary>
        /// <para>(0040,1102) Person’s Address</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint PersonsAddress = 4198658;
        /// <summary>
        /// <para>(0040,1103) Person’s Telephone Numbers</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint PersonsTelephoneNumbers = 4198659;
        /// <summary>
        /// <para>(0040,1400) Requested Procedure Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint RequestedProcedureComments = 4199424;
        /// <summary>
        /// <para>(0040,2001) Reason for the Imaging Service Request</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReasonfortheImagingServiceRequestRetired = 4202497;
        /// <summary>
        /// <para>(0040,2004) Issue Date of Imaging Service Request</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint IssueDateofImagingServiceRequest = 4202500;
        /// <summary>
        /// <para>(0040,2005) Issue Time of Imaging Service Request</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint IssueTimeofImagingServiceRequest = 4202501;
        /// <summary>
        /// <para>(0040,2006) Placer Order Number / Imaging Service Request</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PlacerOrderNumberImagingServiceRequestRetired = 4202502;
        /// <summary>
        /// <para>(0040,2007) Filler Order Number / Imaging Service Request</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint FillerOrderNumberImagingServiceRequestRetired = 4202503;
        /// <summary>
        /// <para>(0040,2008) Order Entered By</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint OrderEnteredBy = 4202504;
        /// <summary>
        /// <para>(0040,2009) Order Enterer’s Location</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint OrderEnterersLocation = 4202505;
        /// <summary>
        /// <para>(0040,2010) Order Callback Phone Number</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint OrderCallbackPhoneNumber = 4202512;
        /// <summary>
        /// <para>(0040,2016) Placer Order Number / Imaging Service Request</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PlacerOrderNumberImagingServiceRequest = 4202518;
        /// <summary>
        /// <para>(0040,2017) Filler Order Number / Imaging Service Request</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FillerOrderNumberImagingServiceRequest = 4202519;
        /// <summary>
        /// <para>(0040,2400) Imaging Service Request Comments</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint ImagingServiceRequestComments = 4203520;
        /// <summary>
        /// <para>(0040,3001) Confidentiality Constraint on Patient Data Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ConfidentialityConstraintonPatientDataDescription = 4206593;
        /// <summary>
        /// <para>(0040,4001) General Purpose Scheduled Procedure Step Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GeneralPurposeScheduledProcedureStepStatus = 4210689;
        /// <summary>
        /// <para>(0040,4002) General Purpose Performed Procedure Step Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GeneralPurposePerformedProcedureStepStatus = 4210690;
        /// <summary>
        /// <para>(0040,4003) General Purpose Scheduled Procedure Step Priority</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GeneralPurposeScheduledProcedureStepPriority = 4210691;
        /// <summary>
        /// <para>(0040,4004) Scheduled Processing Applications Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledProcessingApplicationsCodeSequence = 4210692;
        /// <summary>
        /// <para>(0040,4005) Scheduled Procedure Step Start Date and Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepStartDateandTime = 4210693;
        /// <summary>
        /// <para>(0040,4006) Multiple Copies Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MultipleCopiesFlag = 4210694;
        /// <summary>
        /// <para>(0040,4007) Performed Processing Applications Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedProcessingApplicationsCodeSequence = 4210695;
        /// <summary>
        /// <para>(0040,4009) Human Performer Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HumanPerformerCodeSequence = 4210697;
        /// <summary>
        /// <para>(0040,4010) Scheduled Procedure Step Modification Date and Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ScheduledProcedureStepModificationDateandTime = 4210704;
        /// <summary>
        /// <para>(0040,4011) Expected Completion Date and Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ExpectedCompletionDateandTime = 4210705;
        /// <summary>
        /// <para>(0040,4015) Resulting General Purpose Performed Procedure Steps Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ResultingGeneralPurposePerformedProcedureStepsSequence = 4210709;
        /// <summary>
        /// <para>(0040,4016) Referenced General Purpose Scheduled Procedure Step Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedGeneralPurposeScheduledProcedureStepSequence = 4210710;
        /// <summary>
        /// <para>(0040,4018) Scheduled Workitem Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledWorkitemCodeSequence = 4210712;
        /// <summary>
        /// <para>(0040,4019) Performed Workitem Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedWorkitemCodeSequence = 4210713;
        /// <summary>
        /// <para>(0040,4020) Input Availability Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint InputAvailabilityFlag = 4210720;
        /// <summary>
        /// <para>(0040,4021) Input Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint InputInformationSequence = 4210721;
        /// <summary>
        /// <para>(0040,4022) Relevant Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RelevantInformationSequence = 4210722;
        /// <summary>
        /// <para>(0040,4023) Referenced General Purpose Scheduled Procedure Step Transaction UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedGeneralPurposeScheduledProcedureStepTransactionUID = 4210723;
        /// <summary>
        /// <para>(0040,4025) Scheduled Station Name Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledStationNameCodeSequence = 4210725;
        /// <summary>
        /// <para>(0040,4026) Scheduled Station Class Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledStationClassCodeSequence = 4210726;
        /// <summary>
        /// <para>(0040,4027) Scheduled Station Geographic Location Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledStationGeographicLocationCodeSequence = 4210727;
        /// <summary>
        /// <para>(0040,4028) Performed Station Name Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedStationNameCodeSequence = 4210728;
        /// <summary>
        /// <para>(0040,4029) Performed Station Class Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedStationClassCodeSequence = 4210729;
        /// <summary>
        /// <para>(0040,4030) Performed Station Geographic Location Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedStationGeographicLocationCodeSequence = 4210736;
        /// <summary>
        /// <para>(0040,4031) Requested Subsequent Workitem Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RequestedSubsequentWorkitemCodeSequence = 4210737;
        /// <summary>
        /// <para>(0040,4032) Non-DICOM Output Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint NonDICOMOutputCodeSequence = 4210738;
        /// <summary>
        /// <para>(0040,4033) Output Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OutputInformationSequence = 4210739;
        /// <summary>
        /// <para>(0040,4034) Scheduled Human Performers Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ScheduledHumanPerformersSequence = 4210740;
        /// <summary>
        /// <para>(0040,4035) Actual Human Performers Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ActualHumanPerformersSequence = 4210741;
        /// <summary>
        /// <para>(0040,4036) Human Performer’s Organization</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HumanPerformersOrganization = 4210742;
        /// <summary>
        /// <para>(0040,4037) Human Performer’s Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint HumanPerformersName = 4210743;
        /// <summary>
        /// <para>(0040,8302) Entrance Dose in mGy</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EntranceDoseinmGy = 4227842;
        /// <summary>
        /// <para>(0040,9094) Referenced Image Real World Value Mapping Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedImageRealWorldValueMappingSequence = 4231316;
        /// <summary>
        /// <para>(0040,9096) Real World Value Mapping Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RealWorldValueMappingSequence = 4231318;
        /// <summary>
        /// <para>(0040,9098) Pixel Value Mapping Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PixelValueMappingCodeSequence = 4231320;
        /// <summary>
        /// <para>(0040,9210) LUT Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint LUTLabel = 4231696;
        /// <summary>
        /// <para>(0040,9211) Real World Value Last Value Mapped</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint RealWorldValueLastValueMapped = 4231697;
        /// <summary>
        /// <para>(0040,9212) Real World Value LUT Data</para>
        /// <para> VR: FD VM:1-n</para>
        /// </summary>
        public const uint RealWorldValueLUTData = 4231698;
        /// <summary>
        /// <para>(0040,9216) Real World Value First Value Mapped</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint RealWorldValueFirstValueMapped = 4231702;
        /// <summary>
        /// <para>(0040,9224) Real World Value Intercept</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RealWorldValueIntercept = 4231716;
        /// <summary>
        /// <para>(0040,9225) Real World Value Slope</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint RealWorldValueSlope = 4231717;
        /// <summary>
        /// <para>(0040,A010) Relationship Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RelationshipType = 4235280;
        /// <summary>
        /// <para>(0040,A027) Verifying Organization</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint VerifyingOrganization = 4235303;
        /// <summary>
        /// <para>(0040,A030) Verification Date Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint VerificationDateTime = 4235312;
        /// <summary>
        /// <para>(0040,A032) Observation Date Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ObservationDateTime = 4235314;
        /// <summary>
        /// <para>(0040,A040) Value Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ValueType = 4235328;
        /// <summary>
        /// <para>(0040,A043) Concept Name Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ConceptNameCodeSequence = 4235331;
        /// <summary>
        /// <para>(0040,A050) Continuity Of Content</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContinuityOfContent = 4235344;
        /// <summary>
        /// <para>(0040,A073) Verifying Observer Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint VerifyingObserverSequence = 4235379;
        /// <summary>
        /// <para>(0040,A075) Verifying Observer Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint VerifyingObserverName = 4235381;
        /// <summary>
        /// <para>(0040,A078) Author Observer Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AuthorObserverSequence = 4235384;
        /// <summary>
        /// <para>(0040,A07A) Participant Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ParticipantSequence = 4235386;
        /// <summary>
        /// <para>(0040,A07C) Custodial Organization Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CustodialOrganizationSequence = 4235388;
        /// <summary>
        /// <para>(0040,A080) Participation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ParticipationType = 4235392;
        /// <summary>
        /// <para>(0040,A082) Participation Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint ParticipationDatetime = 4235394;
        /// <summary>
        /// <para>(0040,A084) Observer Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ObserverType = 4235396;
        /// <summary>
        /// <para>(0040,A088) Verifying Observer Identification Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint VerifyingObserverIdentificationCodeSequence = 4235400;
        /// <summary>
        /// <para>(0040,A090) Equivalent CDA Document Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint EquivalentCDADocumentSequenceRetired = 4235408;
        /// <summary>
        /// <para>(0040,A0B0) Referenced Waveform Channels</para>
        /// <para> VR: US VM:2-2n</para>
        /// </summary>
        public const uint ReferencedWaveformChannels = 4235440;
        /// <summary>
        /// <para>(0040,A120) DateTime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint DateTime = 4235552;
        /// <summary>
        /// <para>(0040,A121) Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint Date = 4235553;
        /// <summary>
        /// <para>(0040,A122) Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint Time = 4235554;
        /// <summary>
        /// <para>(0040,A123) Person Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint PersonName = 4235555;
        /// <summary>
        /// <para>(0040,A124) UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint UID = 4235556;
        /// <summary>
        /// <para>(0040,A130) Temporal Range Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TemporalRangeType = 4235568;
        /// <summary>
        /// <para>(0040,A132) Referenced Sample Positions</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint ReferencedSamplePositions = 4235570;
        /// <summary>
        /// <para>(0040,A136) Referenced Frame Numbers</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint ReferencedFrameNumbers = 4235574;
        /// <summary>
        /// <para>(0040,A138) Referenced Time Offsets</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint ReferencedTimeOffsets = 4235576;
        /// <summary>
        /// <para>(0040,A13A) Referenced Datetime </para>
        /// <para> VR: DT VM:1-n</para>
        /// </summary>
        public const uint ReferencedDatetime = 4235578;
        /// <summary>
        /// <para>(0040,A160) Text Value</para>
        /// <para> VR: UT VM:1</para>
        /// </summary>
        public const uint TextValue = 4235616;
        /// <summary>
        /// <para>(0040,A168) Concept Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ConceptCodeSequence = 4235624;
        /// <summary>
        /// <para>(0040,A170) Purpose of Reference Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PurposeofReferenceCodeSequence = 4235632;
        /// <summary>
        /// <para>(0040,A180) Annotation Group Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint AnnotationGroupNumber = 4235648;
        /// <summary>
        /// <para>(0040,A195) Modifier Code Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ModifierCodeSequence = 4235669;
        /// <summary>
        /// <para>(0040,A300) Measured Value Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MeasuredValueSequence = 4236032;
        /// <summary>
        /// <para>(0040,A301) Numeric Value Qualifier Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint NumericValueQualifierCodeSequence = 4236033;
        /// <summary>
        /// <para>(0040,A30A) Numeric Value</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint NumericValue = 4236042;
        /// <summary>
        /// <para>(0040,A360) Predecessor Documents Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PredecessorDocumentsSequence = 4236128;
        /// <summary>
        /// <para>(0040,A370) Referenced Request Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedRequestSequence = 4236144;
        /// <summary>
        /// <para>(0040,A372) Performed Procedure Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerformedProcedureCodeSequence = 4236146;
        /// <summary>
        /// <para>(0040,A375) Current Requested Procedure Evidence Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CurrentRequestedProcedureEvidenceSequence = 4236149;
        /// <summary>
        /// <para>(0040,A385) Pertinent Other Evidence Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PertinentOtherEvidenceSequence = 4236165;
        /// <summary>
        /// <para>(0040,A390) HL7 Structured Document Reference Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HL7StructuredDocumentReferenceSequence = 4236176;
        /// <summary>
        /// <para>(0040,A491) Completion Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CompletionFlag = 4236433;
        /// <summary>
        /// <para>(0040,A492) Completion Flag Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint CompletionFlagDescription = 4236434;
        /// <summary>
        /// <para>(0040,A493) Verification Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VerificationFlag = 4236435;
        /// <summary>
        /// <para>(0040,A504) Content Template Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContentTemplateSequence = 4236548;
        /// <summary>
        /// <para>(0040,A525) Identical Documents Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IdenticalDocumentsSequence = 4236581;
        /// <summary>
        /// <para>(0040,A730) Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContentSequence = 4237104;
        /// <summary>
        /// <para>(0040,B020) Annotation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AnnotationSequence = 4239392;
        /// <summary>
        /// <para>(0040,DB00) Template Identifier</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TemplateIdentifier = 4250368;
        /// <summary>
        /// <para>(0040,DB06) Template Version</para>
        /// <para> VR: DT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TemplateVersionRetired = 4250374;
        /// <summary>
        /// <para>(0040,DB07) Template Local Version</para>
        /// <para> VR: DT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TemplateLocalVersionRetired = 4250375;
        /// <summary>
        /// <para>(0040,DB0B) Template Extension Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TemplateExtensionFlagRetired = 4250379;
        /// <summary>
        /// <para>(0040,DB0C) Template Extension Organization UID</para>
        /// <para> VR: UI VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TemplateExtensionOrganizationUIDRetired = 4250380;
        /// <summary>
        /// <para>(0040,DB0D) Template Extension Creator UID</para>
        /// <para> VR: UI VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TemplateExtensionCreatorUIDRetired = 4250381;
        /// <summary>
        /// <para>(0040,DB73) Referenced Content Item Identifier</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint ReferencedContentItemIdentifier = 4250483;
        /// <summary>
        /// <para>(0040,E001) HL7 Instance Identifier </para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint HL7InstanceIdentifier = 4251649;
        /// <summary>
        /// <para>(0040,E004) HL7 Document Effective Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint HL7DocumentEffectiveTime = 4251652;
        /// <summary>
        /// <para>(0040,E006) HL7 Document Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HL7DocumentTypeCodeSequence = 4251654;
        /// <summary>
        /// <para>(0040,E010) Retrieve URI </para>
        /// <para> VR: UT VM:1</para>
        /// </summary>
        public const uint RetrieveURI = 4251664;
        /// <summary>
        /// <para>(0042,0010) Document Title</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint DocumentTitle = 4325392;
        /// <summary>
        /// <para>(0042,0011) Encapsulated Document</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint EncapsulatedDocument = 4325393;
        /// <summary>
        /// <para>(0042,0012) MIME Type of Encapsulated Document</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint MIMETypeofEncapsulatedDocument = 4325394;
        /// <summary>
        /// <para>(0042,0013) Source Instance Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceInstanceSequence = 4325395;
        /// <summary>
        /// <para>(0050,0004) Calibration Image</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CalibrationImage = 5242884;
        /// <summary>
        /// <para>(0050,0010) Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DeviceSequence = 5242896;
        /// <summary>
        /// <para>(0050,0014) Device Length</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeviceLength = 5242900;
        /// <summary>
        /// <para>(0050,0016) Device Diameter</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeviceDiameter = 5242902;
        /// <summary>
        /// <para>(0050,0017) Device Diameter Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DeviceDiameterUnits = 5242903;
        /// <summary>
        /// <para>(0050,0018) Device Volume</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeviceVolume = 5242904;
        /// <summary>
        /// <para>(0050,0019) Intermarker Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint IntermarkerDistance = 5242905;
        /// <summary>
        /// <para>(0050,0020) Device Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DeviceDescription = 5242912;
        /// <summary>
        /// <para>(0054,0010) Energy Window Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint EnergyWindowVector = 5505040;
        /// <summary>
        /// <para>(0054,0011) Number of Energy Windows</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofEnergyWindows = 5505041;
        /// <summary>
        /// <para>(0054,0012) Energy Window Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint EnergyWindowInformationSequence = 5505042;
        /// <summary>
        /// <para>(0054,0013) Energy Window Range Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint EnergyWindowRangeSequence = 5505043;
        /// <summary>
        /// <para>(0054,0014) Energy Window Lower Limit</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EnergyWindowLowerLimit = 5505044;
        /// <summary>
        /// <para>(0054,0015) Energy Window Upper Limit</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EnergyWindowUpperLimit = 5505045;
        /// <summary>
        /// <para>(0054,0016) Radiopharmaceutical Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalInformationSequence = 5505046;
        /// <summary>
        /// <para>(0054,0017) Residual Syringe Counts</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ResidualSyringeCounts = 5505047;
        /// <summary>
        /// <para>(0054,0018) Energy Window Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint EnergyWindowName = 5505048;
        /// <summary>
        /// <para>(0054,0020) Detector Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint DetectorVector = 5505056;
        /// <summary>
        /// <para>(0054,0021) Number of Detectors</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofDetectors = 5505057;
        /// <summary>
        /// <para>(0054,0022) Detector Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DetectorInformationSequence = 5505058;
        /// <summary>
        /// <para>(0054,0030) Phase Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint PhaseVector = 5505072;
        /// <summary>
        /// <para>(0054,0031) Number of Phases</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofPhases = 5505073;
        /// <summary>
        /// <para>(0054,0032) Phase Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PhaseInformationSequence = 5505074;
        /// <summary>
        /// <para>(0054,0033) Number of Frames in Phase</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofFramesinPhase = 5505075;
        /// <summary>
        /// <para>(0054,0036) Phase Delay</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint PhaseDelay = 5505078;
        /// <summary>
        /// <para>(0054,0038) Pause Between Frames</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint PauseBetweenFrames = 5505080;
        /// <summary>
        /// <para>(0054,0039) Phase Description</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PhaseDescription = 5505081;
        /// <summary>
        /// <para>(0054,0050) Rotation Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint RotationVector = 5505104;
        /// <summary>
        /// <para>(0054,0051) Number of Rotations</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofRotations = 5505105;
        /// <summary>
        /// <para>(0054,0052) Rotation Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RotationInformationSequence = 5505106;
        /// <summary>
        /// <para>(0054,0053) Number of Frames in Rotation</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofFramesinRotation = 5505107;
        /// <summary>
        /// <para>(0054,0060) R-R Interval Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint RRIntervalVector = 5505120;
        /// <summary>
        /// <para>(0054,0061) Number of R-R Intervals</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofRRIntervals = 5505121;
        /// <summary>
        /// <para>(0054,0062) Gated Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint GatedInformationSequence = 5505122;
        /// <summary>
        /// <para>(0054,0063) Data Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DataInformationSequence = 5505123;
        /// <summary>
        /// <para>(0054,0070) Time Slot Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint TimeSlotVector = 5505136;
        /// <summary>
        /// <para>(0054,0071) Number of Time Slots</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofTimeSlots = 5505137;
        /// <summary>
        /// <para>(0054,0072) Time Slot Information Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint TimeSlotInformationSequence = 5505138;
        /// <summary>
        /// <para>(0054,0073) Time Slot Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TimeSlotTime = 5505139;
        /// <summary>
        /// <para>(0054,0080) Slice Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint SliceVector = 5505152;
        /// <summary>
        /// <para>(0054,0081) Number of Slices</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofSlices = 5505153;
        /// <summary>
        /// <para>(0054,0090) Angular View Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint AngularViewVector = 5505168;
        /// <summary>
        /// <para>(0054,0100) Time Slice Vector</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint TimeSliceVector = 5505280;
        /// <summary>
        /// <para>(0054,0101) Number of Time Slices</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofTimeSlices = 5505281;
        /// <summary>
        /// <para>(0054,0200) Start Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint StartAngle = 5505536;
        /// <summary>
        /// <para>(0054,0202) Type of Detector Motion</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TypeofDetectorMotion = 5505538;
        /// <summary>
        /// <para>(0054,0210) Trigger Vector</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint TriggerVector = 5505552;
        /// <summary>
        /// <para>(0054,0211) Number of Triggers in Phase</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofTriggersinPhase = 5505553;
        /// <summary>
        /// <para>(0054,0220) View Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ViewCodeSequence = 5505568;
        /// <summary>
        /// <para>(0054,0222) View Modifier Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ViewModifierCodeSequence = 5505570;
        /// <summary>
        /// <para>(0054,0300) Radionuclide Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RadionuclideCodeSequence = 5505792;
        /// <summary>
        /// <para>(0054,0302) Administration Route Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AdministrationRouteCodeSequence = 5505794;
        /// <summary>
        /// <para>(0054,0304) Radiopharmaceutical Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RadiopharmaceuticalCodeSequence = 5505796;
        /// <summary>
        /// <para>(0054,0306) Calibration Data Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CalibrationDataSequence = 5505798;
        /// <summary>
        /// <para>(0054,0308) Energy Window Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint EnergyWindowNumber = 5505800;
        /// <summary>
        /// <para>(0054,0400) Image ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ImageID = 5506048;
        /// <summary>
        /// <para>(0054,0410) Patient Orientation Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientOrientationCodeSequence = 5506064;
        /// <summary>
        /// <para>(0054,0412) Patient Orientation Modifier Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientOrientationModifierCodeSequence = 5506066;
        /// <summary>
        /// <para>(0054,0414) Patient Gantry Relationship Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientGantryRelationshipCodeSequence = 5506068;
        /// <summary>
        /// <para>(0054,0500) Slice Progression Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SliceProgressionDirection = 5506304;
        /// <summary>
        /// <para>(0054,1000) Series Type</para>
        /// <para> VR: CS VM:2</para>
        /// </summary>
        public const uint SeriesType = 5509120;
        /// <summary>
        /// <para>(0054,1001) Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Units = 5509121;
        /// <summary>
        /// <para>(0054,1002) Counts Source</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CountsSource = 5509122;
        /// <summary>
        /// <para>(0054,1004) Reprojection Method</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReprojectionMethod = 5509124;
        /// <summary>
        /// <para>(0054,1100) Randoms Correction Method</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RandomsCorrectionMethod = 5509376;
        /// <summary>
        /// <para>(0054,1101) Attenuation Correction Method</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AttenuationCorrectionMethod = 5509377;
        /// <summary>
        /// <para>(0054,1102) Decay Correction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DecayCorrection = 5509378;
        /// <summary>
        /// <para>(0054,1103) Reconstruction Method</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ReconstructionMethod = 5509379;
        /// <summary>
        /// <para>(0054,1104) Detector Lines of Response Used</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DetectorLinesofResponseUsed = 5509380;
        /// <summary>
        /// <para>(0054,1105) Scatter Correction Method</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ScatterCorrectionMethod = 5509381;
        /// <summary>
        /// <para>(0054,1200) Axial Acceptance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint AxialAcceptance = 5509632;
        /// <summary>
        /// <para>(0054,1201) Axial Mash</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint AxialMash = 5509633;
        /// <summary>
        /// <para>(0054,1202) Transverse Mash</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint TransverseMash = 5509634;
        /// <summary>
        /// <para>(0054,1203) Detector Element Size</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint DetectorElementSize = 5509635;
        /// <summary>
        /// <para>(0054,1210) Coincidence Window Width</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CoincidenceWindowWidth = 5509648;
        /// <summary>
        /// <para>(0054,1220) Secondary Counts Type</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint SecondaryCountsType = 5509664;
        /// <summary>
        /// <para>(0054,1300) Frame Reference Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FrameReferenceTime = 5509888;
        /// <summary>
        /// <para>(0054,1310) Primary (Prompts) Counts Accumulated</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint PrimaryPromptsCountsAccumulated = 5509904;
        /// <summary>
        /// <para>(0054,1311) Secondary Counts Accumulated</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint SecondaryCountsAccumulated = 5509905;
        /// <summary>
        /// <para>(0054,1320) Slice Sensitivity Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SliceSensitivityFactor = 5509920;
        /// <summary>
        /// <para>(0054,1321) Decay Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DecayFactor = 5509921;
        /// <summary>
        /// <para>(0054,1322) Dose Calibration Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DoseCalibrationFactor = 5509922;
        /// <summary>
        /// <para>(0054,1323) Scatter Fraction Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ScatterFractionFactor = 5509923;
        /// <summary>
        /// <para>(0054,1324) Dead Time Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeadTimeFactor = 5509924;
        /// <summary>
        /// <para>(0054,1330) Image Index</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageIndex = 5509936;
        /// <summary>
        /// <para>(0054,1400) Counts Included</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint CountsIncluded = 5510144;
        /// <summary>
        /// <para>(0054,1401) Dead Time Correction Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DeadTimeCorrectionFlag = 5510145;
        /// <summary>
        /// <para>(0060,3000) Histogram Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HistogramSequence = 6303744;
        /// <summary>
        /// <para>(0060,3002) Histogram Number of Bins</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint HistogramNumberofBins = 6303746;
        /// <summary>
        /// <para>(0060,3004) Histogram First Bin Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint HistogramFirstBinValue = 6303748;
        /// <summary>
        /// <para>(0060,3006) Histogram Last Bin Value</para>
        /// <para> VR: US or SS VM:1</para>
        /// </summary>
        public const uint HistogramLastBinValue = 6303750;
        /// <summary>
        /// <para>(0060,3008) Histogram Bin Width</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint HistogramBinWidth = 6303752;
        /// <summary>
        /// <para>(0060,3010) Histogram Explanation</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HistogramExplanation = 6303760;
        /// <summary>
        /// <para>(0060,3020) Histogram Data</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint HistogramData = 6303776;
        /// <summary>
        /// <para>(0062,0001) Segmentation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SegmentationType = 6422529;
        /// <summary>
        /// <para>(0062,0002) Segment Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SegmentSequence = 6422530;
        /// <summary>
        /// <para>(0062,0003) Segmented Property Category Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SegmentedPropertyCategoryCodeSequence = 6422531;
        /// <summary>
        /// <para>(0062,0004) Segment Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint SegmentNumber = 6422532;
        /// <summary>
        /// <para>(0062,0005) Segment Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SegmentLabel = 6422533;
        /// <summary>
        /// <para>(0062,0006) Segment Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint SegmentDescription = 6422534;
        /// <summary>
        /// <para>(0062,0008) Segment Algorithm Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SegmentAlgorithmType = 6422536;
        /// <summary>
        /// <para>(0062,0009) Segment Algorithm Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SegmentAlgorithmName = 6422537;
        /// <summary>
        /// <para>(0062,000A) Segment Identification Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SegmentIdentificationSequence = 6422538;
        /// <summary>
        /// <para>(0062,000B) Referenced Segment Number</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint ReferencedSegmentNumber = 6422539;
        /// <summary>
        /// <para>(0062,000C) Recommended Display Grayscale Value</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint RecommendedDisplayGrayscaleValue = 6422540;
        /// <summary>
        /// <para>(0062,000D) Recommended Display CIELab Value</para>
        /// <para> VR: US VM:3</para>
        /// </summary>
        public const uint RecommendedDisplayCIELabValue = 6422541;
        /// <summary>
        /// <para>(0062,000E) Maximum Fractional Value</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MaximumFractionalValue = 6422542;
        /// <summary>
        /// <para>(0062,000F) Segmented Property Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SegmentedPropertyTypeCodeSequence = 6422543;
        /// <summary>
        /// <para>(0062,0010) Segmentation Fractional Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SegmentationFractionalType = 6422544;
        /// <summary>
        /// <para>(0064,0002) Deformable Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DeformableRegistrationSequence = 6553602;
        /// <summary>
        /// <para>(0064,0003) Source Frame of Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint SourceFrameofReferenceUID = 6553603;
        /// <summary>
        /// <para>(0064,0005) Deformable Registration Grid Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DeformableRegistrationGridSequence = 6553605;
        /// <summary>
        /// <para>(0064,0007) Grid Dimensions</para>
        /// <para> VR: UL VM:3</para>
        /// </summary>
        public const uint GridDimensions = 6553607;
        /// <summary>
        /// <para>(0064,0008) Grid Resolution</para>
        /// <para> VR: FD VM:3</para>
        /// </summary>
        public const uint GridResolution = 6553608;
        /// <summary>
        /// <para>(0064,0009) Vector Grid Data</para>
        /// <para> VR: OF VM:1</para>
        /// </summary>
        public const uint VectorGridData = 6553609;
        /// <summary>
        /// <para>(0064,000F) Pre Deformation Matrix Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PreDeformationMatrixRegistrationSequence = 6553615;
        /// <summary>
        /// <para>(0064,0010) Post Deformation Matrix Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PostDeformationMatrixRegistrationSequence = 6553616;
        /// <summary>
        /// <para>(0070,0001) Graphic Annotation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint GraphicAnnotationSequence = 7340033;
        /// <summary>
        /// <para>(0070,0002) Graphic Layer</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GraphicLayer = 7340034;
        /// <summary>
        /// <para>(0070,0003) Bounding Box Annotation Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BoundingBoxAnnotationUnits = 7340035;
        /// <summary>
        /// <para>(0070,0004) Anchor Point Annotation Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AnchorPointAnnotationUnits = 7340036;
        /// <summary>
        /// <para>(0070,0005) Graphic Annotation Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GraphicAnnotationUnits = 7340037;
        /// <summary>
        /// <para>(0070,0006) Unformatted Text Value</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint UnformattedTextValue = 7340038;
        /// <summary>
        /// <para>(0070,0008) Text Object Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint TextObjectSequence = 7340040;
        /// <summary>
        /// <para>(0070,0009) Graphic Object Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint GraphicObjectSequence = 7340041;
        /// <summary>
        /// <para>(0070,0010) Bounding Box Top Left Hand Corner</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint BoundingBoxTopLeftHandCorner = 7340048;
        /// <summary>
        /// <para>(0070,0011) Bounding Box Bottom Right Hand Corner</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint BoundingBoxBottomRightHandCorner = 7340049;
        /// <summary>
        /// <para>(0070,0012) Bounding Box Text Horizontal Justification</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BoundingBoxTextHorizontalJustification = 7340050;
        /// <summary>
        /// <para>(0070,0014) Anchor Point</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint AnchorPoint = 7340052;
        /// <summary>
        /// <para>(0070,0015) Anchor Point Visibility</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AnchorPointVisibility = 7340053;
        /// <summary>
        /// <para>(0070,0020) Graphic Dimensions </para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint GraphicDimensions = 7340064;
        /// <summary>
        /// <para>(0070,0021) Number of Graphic Points</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofGraphicPoints = 7340065;
        /// <summary>
        /// <para>(0070,0022) Graphic Data</para>
        /// <para> VR: FL VM:2-n</para>
        /// </summary>
        public const uint GraphicData = 7340066;
        /// <summary>
        /// <para>(0070,0023) Graphic Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GraphicType = 7340067;
        /// <summary>
        /// <para>(0070,0024) Graphic Filled</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GraphicFilled = 7340068;
        /// <summary>
        /// <para>(0070,0041) Image Horizontal Flip</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageHorizontalFlip = 7340097;
        /// <summary>
        /// <para>(0070,0042) Image Rotation </para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageRotation = 7340098;
        /// <summary>
        /// <para>(0070,0052) Displayed Area Top Left Hand Corner</para>
        /// <para> VR: SL VM:2</para>
        /// </summary>
        public const uint DisplayedAreaTopLeftHandCorner = 7340114;
        /// <summary>
        /// <para>(0070,0053) Displayed Area Bottom Right Hand Corner</para>
        /// <para> VR: SL VM:2</para>
        /// </summary>
        public const uint DisplayedAreaBottomRightHandCorner = 7340115;
        /// <summary>
        /// <para>(0070,005A) Displayed Area Selection Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DisplayedAreaSelectionSequence = 7340122;
        /// <summary>
        /// <para>(0070,0060) Graphic Layer Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint GraphicLayerSequence = 7340128;
        /// <summary>
        /// <para>(0070,0062) Graphic Layer Order</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint GraphicLayerOrder = 7340130;
        /// <summary>
        /// <para>(0070,0066) Graphic Layer Recommended Display Grayscale Value</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint GraphicLayerRecommendedDisplayGrayscaleValue = 7340134;
        /// <summary>
        /// <para>(0070,0067) Graphic Layer Recommended Display RGB Value</para>
        /// <para> VR: US VM:3</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint GraphicLayerRecommendedDisplayRGBValueRetired = 7340135;
        /// <summary>
        /// <para>(0070,0068) Graphic Layer Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint GraphicLayerDescription = 7340136;
        /// <summary>
        /// <para>(0070,0080) Content Label</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContentLabel = 7340160;
        /// <summary>
        /// <para>(0070,0081) Content Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ContentDescription = 7340161;
        /// <summary>
        /// <para>(0070,0082) Presentation Creation Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint PresentationCreationDate = 7340162;
        /// <summary>
        /// <para>(0070,0083) Presentation Creation Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint PresentationCreationTime = 7340163;
        /// <summary>
        /// <para>(0070,0084) Content Creator’s Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ContentCreatorsName = 7340164;
        /// <summary>
        /// <para>(0070,0086) Content Creator’s Identification Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContentCreatorsIdentificationCodeSequence = 7340166;
        /// <summary>
        /// <para>(0070,0100) Presentation Size Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PresentationSizeMode = 7340288;
        /// <summary>
        /// <para>(0070,0101) Presentation Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint PresentationPixelSpacing = 7340289;
        /// <summary>
        /// <para>(0070,0102) Presentation Pixel Aspect Ratio</para>
        /// <para> VR: IS VM:2</para>
        /// </summary>
        public const uint PresentationPixelAspectRatio = 7340290;
        /// <summary>
        /// <para>(0070,0103) Presentation Pixel Magnification Ratio</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint PresentationPixelMagnificationRatio = 7340291;
        /// <summary>
        /// <para>(0070,0306) Shape Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShapeType = 7340806;
        /// <summary>
        /// <para>(0070,0308) Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RegistrationSequence = 7340808;
        /// <summary>
        /// <para>(0070,0309) Matrix Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MatrixRegistrationSequence = 7340809;
        /// <summary>
        /// <para>(0070,030A) Matrix Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MatrixSequence = 7340810;
        /// <summary>
        /// <para>(0070,030C) Frame of Reference Transformation Matrix Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FrameofReferenceTransformationMatrixType = 7340812;
        /// <summary>
        /// <para>(0070,030D) Registration Type Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RegistrationTypeCodeSequence = 7340813;
        /// <summary>
        /// <para>(0070,030F) Fiducial Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint FiducialDescription = 7340815;
        /// <summary>
        /// <para>(0070,0310) Fiducial Identifier</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint FiducialIdentifier = 7340816;
        /// <summary>
        /// <para>(0070,0311) Fiducial Identifier Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FiducialIdentifierCodeSequence = 7340817;
        /// <summary>
        /// <para>(0070,0312) Contour Uncertainty Radius</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ContourUncertaintyRadius = 7340818;
        /// <summary>
        /// <para>(0070,0314) Used Fiducials Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint UsedFiducialsSequence = 7340820;
        /// <summary>
        /// <para>(0070,0318) Graphic Coordinates Data Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint GraphicCoordinatesDataSequence = 7340824;
        /// <summary>
        /// <para>(0070,031A) Fiducial UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint FiducialUID = 7340826;
        /// <summary>
        /// <para>(0070,031C) Fiducial Set Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FiducialSetSequence = 7340828;
        /// <summary>
        /// <para>(0070,031E) Fiducial Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FiducialSequence = 7340830;
        /// <summary>
        /// <para>(0070,0401) Graphic Layer Recommended Display CIELab Value</para>
        /// <para> VR: US VM:3</para>
        /// </summary>
        public const uint GraphicLayerRecommendedDisplayCIELabValue = 7341057;
        /// <summary>
        /// <para>(0070,0402) Blending Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BlendingSequence = 7341058;
        /// <summary>
        /// <para>(0070,0403) Relative Opacity</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RelativeOpacity = 7341059;
        /// <summary>
        /// <para>(0070,0404) Referenced Spatial Registration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedSpatialRegistrationSequence = 7341060;
        /// <summary>
        /// <para>(0070,0405) Blending Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BlendingPosition = 7341061;
        /// <summary>
        /// <para>(0072,0002) Hanging Protocol Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint HangingProtocolName = 7471106;
        /// <summary>
        /// <para>(0072,0004) Hanging Protocol Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HangingProtocolDescription = 7471108;
        /// <summary>
        /// <para>(0072,0006) Hanging Protocol Level</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint HangingProtocolLevel = 7471110;
        /// <summary>
        /// <para>(0072,0008) Hanging Protocol Creator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HangingProtocolCreator = 7471112;
        /// <summary>
        /// <para>(0072,000A) Hanging Protocol Creation Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint HangingProtocolCreationDatetime = 7471114;
        /// <summary>
        /// <para>(0072,000C) Hanging Protocol Definition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HangingProtocolDefinitionSequence = 7471116;
        /// <summary>
        /// <para>(0072,000E) Hanging Protocol User Identification Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint HangingProtocolUserIdentificationCodeSequence = 7471118;
        /// <summary>
        /// <para>(0072,0010) Hanging Protocol User Group Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint HangingProtocolUserGroupName = 7471120;
        /// <summary>
        /// <para>(0072,0012) Source Hanging Protocol Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceHangingProtocolSequence = 7471122;
        /// <summary>
        /// <para>(0072,0014) Number of Priors Referenced</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofPriorsReferenced = 7471124;
        /// <summary>
        /// <para>(0072,0020) Image Sets Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ImageSetsSequence = 7471136;
        /// <summary>
        /// <para>(0072,0022) Image Set Selector Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ImageSetSelectorSequence = 7471138;
        /// <summary>
        /// <para>(0072,0024) Image Set Selector Usage Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageSetSelectorUsageFlag = 7471140;
        /// <summary>
        /// <para>(0072,0026) Selector Attribute</para>
        /// <para> VR: AT VM:1</para>
        /// </summary>
        public const uint SelectorAttribute = 7471142;
        /// <summary>
        /// <para>(0072,0028) Selector Value Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint SelectorValueNumber = 7471144;
        /// <summary>
        /// <para>(0072,0030) Time Based Image Sets Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint TimeBasedImageSetsSequence = 7471152;
        /// <summary>
        /// <para>(0072,0032) Image Set Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageSetNumber = 7471154;
        /// <summary>
        /// <para>(0072,0034) Image Set Selector Category</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageSetSelectorCategory = 7471156;
        /// <summary>
        /// <para>(0072,0038) Relative Time</para>
        /// <para> VR: US VM:2</para>
        /// </summary>
        public const uint RelativeTime = 7471160;
        /// <summary>
        /// <para>(0072,003A) Relative Time Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RelativeTimeUnits = 7471162;
        /// <summary>
        /// <para>(0072,003C) Abstract Prior Value</para>
        /// <para> VR: SS VM:2</para>
        /// </summary>
        public const uint AbstractPriorValue = 7471164;
        /// <summary>
        /// <para>(0072,003E) Abstract Prior Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint AbstractPriorCodeSequence = 7471166;
        /// <summary>
        /// <para>(0072,0040) Image Set Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ImageSetLabel = 7471168;
        /// <summary>
        /// <para>(0072,0050) Selector Attribute VR</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SelectorAttributeVR = 7471184;
        /// <summary>
        /// <para>(0072,0052) Selector Sequence Pointer</para>
        /// <para> VR: AT VM:1</para>
        /// </summary>
        public const uint SelectorSequencePointer = 7471186;
        /// <summary>
        /// <para>(0072,0054) Selector Sequence Pointer Private Creator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SelectorSequencePointerPrivateCreator = 7471188;
        /// <summary>
        /// <para>(0072,0056) Selector Attribute Private Creator</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SelectorAttributePrivateCreator = 7471190;
        /// <summary>
        /// <para>(0072,0060) Selector AT Value</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint SelectorATValue = 7471200;
        /// <summary>
        /// <para>(0072,0062) Selector CS Value</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint SelectorCSValue = 7471202;
        /// <summary>
        /// <para>(0072,0064) Selector IS Value</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint SelectorISValue = 7471204;
        /// <summary>
        /// <para>(0072,0066) Selector LO Value</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint SelectorLOValue = 7471206;
        /// <summary>
        /// <para>(0072,0068) Selector LT Value</para>
        /// <para> VR: LT VM:1-n</para>
        /// </summary>
        public const uint SelectorLTValue = 7471208;
        /// <summary>
        /// <para>(0072,006A) Selector PN Value</para>
        /// <para> VR: PN VM:1-n</para>
        /// </summary>
        public const uint SelectorPNValue = 7471210;
        /// <summary>
        /// <para>(0072,006C) Selector SH Value</para>
        /// <para> VR: SH VM:1-n</para>
        /// </summary>
        public const uint SelectorSHValue = 7471212;
        /// <summary>
        /// <para>(0072,006E) Selector ST Value</para>
        /// <para> VR: ST VM:1-n</para>
        /// </summary>
        public const uint SelectorSTValue = 7471214;
        /// <summary>
        /// <para>(0072,0070) Selector UT Value</para>
        /// <para> VR: UT VM:1-n</para>
        /// </summary>
        public const uint SelectorUTValue = 7471216;
        /// <summary>
        /// <para>(0072,0072) Selector DS Value</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint SelectorDSValue = 7471218;
        /// <summary>
        /// <para>(0072,0074) Selector FD Value</para>
        /// <para> VR: FD VM:1-n</para>
        /// </summary>
        public const uint SelectorFDValue = 7471220;
        /// <summary>
        /// <para>(0072,0076) Selector FL Value</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint SelectorFLValue = 7471222;
        /// <summary>
        /// <para>(0072,0078) Selector UL Value</para>
        /// <para> VR: UL VM:1-n</para>
        /// </summary>
        public const uint SelectorULValue = 7471224;
        /// <summary>
        /// <para>(0072,007A) Selector US Value</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint SelectorUSValue = 7471226;
        /// <summary>
        /// <para>(0072,007C) Selector SL Value</para>
        /// <para> VR: SL VM:1-n</para>
        /// </summary>
        public const uint SelectorSLValue = 7471228;
        /// <summary>
        /// <para>(0072,007E) Selector SS Value</para>
        /// <para> VR: SS VM:1-n</para>
        /// </summary>
        public const uint SelectorSSValue = 7471230;
        /// <summary>
        /// <para>(0072,0080) Selector Code Sequence Value</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SelectorCodeSequenceValue = 7471232;
        /// <summary>
        /// <para>(0072,0100) Number of Screens</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofScreens = 7471360;
        /// <summary>
        /// <para>(0072,0102) Nominal Screen Definition Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint NominalScreenDefinitionSequence = 7471362;
        /// <summary>
        /// <para>(0072,0104) Number of Vertical Pixels</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofVerticalPixels = 7471364;
        /// <summary>
        /// <para>(0072,0106) Number of Horizontal Pixels</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NumberofHorizontalPixels = 7471366;
        /// <summary>
        /// <para>(0072,0108) Display Environment Spatial Position</para>
        /// <para> VR: FD VM:4</para>
        /// </summary>
        public const uint DisplayEnvironmentSpatialPosition = 7471368;
        /// <summary>
        /// <para>(0072,010A) Screen Minimum Grayscale Bit Depth</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ScreenMinimumGrayscaleBitDepth = 7471370;
        /// <summary>
        /// <para>(0072,010C) Screen Minimum Color Bit Depth</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ScreenMinimumColorBitDepth = 7471372;
        /// <summary>
        /// <para>(0072,010E) Application Maximum Repaint Time</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ApplicationMaximumRepaintTime = 7471374;
        /// <summary>
        /// <para>(0072,0200) Display Sets Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DisplaySetsSequence = 7471616;
        /// <summary>
        /// <para>(0072,0202) Display Set Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint DisplaySetNumber = 7471618;
        /// <summary>
        /// <para>(0072,0203) Display Set Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DisplaySetLabel = 7471619;
        /// <summary>
        /// <para>(0072,0204) Display Set Presentation Group</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint DisplaySetPresentationGroup = 7471620;
        /// <summary>
        /// <para>(0072,0206) Display Set Presentation Group Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DisplaySetPresentationGroupDescription = 7471622;
        /// <summary>
        /// <para>(0072,0208) Partial Data Display Handling</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PartialDataDisplayHandling = 7471624;
        /// <summary>
        /// <para>(0072,0210) Synchronized Scrolling Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SynchronizedScrollingSequence = 7471632;
        /// <summary>
        /// <para>(0072,0212) Display Set Scrolling Group</para>
        /// <para> VR: US VM:2-n</para>
        /// </summary>
        public const uint DisplaySetScrollingGroup = 7471634;
        /// <summary>
        /// <para>(0072,0214) Navigation Indicator Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint NavigationIndicatorSequence = 7471636;
        /// <summary>
        /// <para>(0072,0216) Navigation Display Set </para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint NavigationDisplaySet = 7471638;
        /// <summary>
        /// <para>(0072,0218) Reference Display Sets</para>
        /// <para> VR: US VM:1-n</para>
        /// </summary>
        public const uint ReferenceDisplaySets = 7471640;
        /// <summary>
        /// <para>(0072,0300) Image Boxes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ImageBoxesSequence = 7471872;
        /// <summary>
        /// <para>(0072,0302) Image Box Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxNumber = 7471874;
        /// <summary>
        /// <para>(0072,0304) Image Box Layout Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageBoxLayoutType = 7471876;
        /// <summary>
        /// <para>(0072,0306) Image Box Tile Horizontal Dimension</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxTileHorizontalDimension = 7471878;
        /// <summary>
        /// <para>(0072,0308) Image Box Tile Vertical Dimension</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxTileVerticalDimension = 7471880;
        /// <summary>
        /// <para>(0072,0310) Image Box Scroll Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageBoxScrollDirection = 7471888;
        /// <summary>
        /// <para>(0072,0312) Image Box Small Scroll Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageBoxSmallScrollType = 7471890;
        /// <summary>
        /// <para>(0072,0314) Image Box Small Scroll Amount</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxSmallScrollAmount = 7471892;
        /// <summary>
        /// <para>(0072,0316) Image Box Large Scroll Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ImageBoxLargeScrollType = 7471894;
        /// <summary>
        /// <para>(0072,0318) Image Box Large Scroll Amount</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxLargeScrollAmount = 7471896;
        /// <summary>
        /// <para>(0072,0320) Image Box Overlap Priority</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageBoxOverlapPriority = 7471904;
        /// <summary>
        /// <para>(0072,0330) Cine Relative to Real-Time</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint CineRelativetoRealTime = 7471920;
        /// <summary>
        /// <para>(0072,0400) Filter Operations Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FilterOperationsSequence = 7472128;
        /// <summary>
        /// <para>(0072,0402) Filter-by Category</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilterbyCategory = 7472130;
        /// <summary>
        /// <para>(0072,0404) Filter-by Attribute Presence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilterbyAttributePresence = 7472132;
        /// <summary>
        /// <para>(0072,0406) Filter-by Operator</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilterbyOperator = 7472134;
        /// <summary>
        /// <para>(0072,0500) Blending Operation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BlendingOperationType = 7472384;
        /// <summary>
        /// <para>(0072,0510) Reformatting Operation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReformattingOperationType = 7472400;
        /// <summary>
        /// <para>(0072,0512) Reformatting Thickness</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ReformattingThickness = 7472402;
        /// <summary>
        /// <para>(0072,0514) Reformatting Interval</para>
        /// <para> VR: FD VM:1</para>
        /// </summary>
        public const uint ReformattingInterval = 7472404;
        /// <summary>
        /// <para>(0072,0516) Reformatting Operation Initial View Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReformattingOperationInitialViewDirection = 7472406;
        /// <summary>
        /// <para>(0072,0520) 3D Rendering Type</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint Tag3DRenderingType = 7472416;
        /// <summary>
        /// <para>(0072,0600) Sorting Operations Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SortingOperationsSequence = 7472640;
        /// <summary>
        /// <para>(0072,0602) Sort-by Category</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SortbyCategory = 7472642;
        /// <summary>
        /// <para>(0072,0604) Sorting Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SortingDirection = 7472644;
        /// <summary>
        /// <para>(0072,0700) Display Set Patient Orientation</para>
        /// <para> VR: CS VM:2</para>
        /// </summary>
        public const uint DisplaySetPatientOrientation = 7472896;
        /// <summary>
        /// <para>(0072,0702) VOI Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint VOIType = 7472898;
        /// <summary>
        /// <para>(0072,0704) Pseudo-color Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PseudocolorType = 7472900;
        /// <summary>
        /// <para>(0072,0706) Show Grayscale Inverted</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShowGrayscaleInverted = 7472902;
        /// <summary>
        /// <para>(0072,0710) Show Image True Size Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShowImageTrueSizeFlag = 7472912;
        /// <summary>
        /// <para>(0072,0712) Show Graphic Annotation Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShowGraphicAnnotationFlag = 7472914;
        /// <summary>
        /// <para>(0072,0714) Show Patient Demographics Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShowPatientDemographicsFlag = 7472916;
        /// <summary>
        /// <para>(0072,0716) Show Acquisition Techniques Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShowAcquisitionTechniquesFlag = 7472918;
        /// <summary>
        /// <para>(0072,0717) Display Set Horizontal Justification </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DisplaySetHorizontalJustification = 7472919;
        /// <summary>
        /// <para>(0072,0718) Display Set Vertical Justification</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DisplaySetVerticalJustification = 7472920;
        /// <summary>
        /// <para>(0088,0130) Storage Media File-set ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StorageMediaFilesetID = 8913200;
        /// <summary>
        /// <para>(0088,0140) Storage Media File-set UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint StorageMediaFilesetUID = 8913216;
        /// <summary>
        /// <para>(0088,0200) Icon Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IconImageSequence = 8913408;
        /// <summary>
        /// <para>(0088,0904) Topic Title</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TopicTitle = 8915204;
        /// <summary>
        /// <para>(0088,0906) Topic Subject</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint TopicSubject = 8915206;
        /// <summary>
        /// <para>(0088,0910) Topic Author</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TopicAuthor = 8915216;
        /// <summary>
        /// <para>(0088,0912) Topic Keywords</para>
        /// <para> VR: LO VM:1-32</para>
        /// </summary>
        public const uint TopicKeywords = 8915218;
        /// <summary>
        /// <para>(0100,0410) SOP Instance Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SOPInstanceStatus = 16778256;
        /// <summary>
        /// <para>(0100,0420) SOP Authorization Date and Time</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint SOPAuthorizationDateandTime = 16778272;
        /// <summary>
        /// <para>(0100,0424) SOP Authorization Comment</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint SOPAuthorizationComment = 16778276;
        /// <summary>
        /// <para>(0100,0426) Authorization Equipment Certification Number</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AuthorizationEquipmentCertificationNumber = 16778278;
        /// <summary>
        /// <para>(0400,0005) MAC ID Number</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MACIDNumber = 67108869;
        /// <summary>
        /// <para>(0400,0010) MAC Calculation Transfer Syntax UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint MACCalculationTransferSyntaxUID = 67108880;
        /// <summary>
        /// <para>(0400,0015) MAC Algorithm</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MACAlgorithm = 67108885;
        /// <summary>
        /// <para>(0400,0020) Data Elements Signed</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint DataElementsSigned = 67108896;
        /// <summary>
        /// <para>(0400,0100) Digital Signature UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint DigitalSignatureUID = 67109120;
        /// <summary>
        /// <para>(0400,0105) Digital Signature DateTime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint DigitalSignatureDateTime = 67109125;
        /// <summary>
        /// <para>(0400,0110) Certificate Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CertificateType = 67109136;
        /// <summary>
        /// <para>(0400,0115) Certificate of Signer</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint CertificateofSigner = 67109141;
        /// <summary>
        /// <para>(0400,0120) Signature</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint Signature = 67109152;
        /// <summary>
        /// <para>(0400,0305) Certified Timestamp Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CertifiedTimestampType = 67109637;
        /// <summary>
        /// <para>(0400,0310) Certified Timestamp</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint CertifiedTimestamp = 67109648;
        /// <summary>
        /// <para>(0400,0401) Digital Signature Purpose Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DigitalSignaturePurposeCodeSequence = 67109889;
        /// <summary>
        /// <para>(0400,0402) Referenced Digital Signature Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedDigitalSignatureSequence = 67109890;
        /// <summary>
        /// <para>(0400,0403) Referenced SOP Instance MAC Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedSOPInstanceMACSequence = 67109891;
        /// <summary>
        /// <para>(0400,0404) MAC</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint MAC = 67109892;
        /// <summary>
        /// <para>(0400,0500) Encrypted Attributes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint EncryptedAttributesSequence = 67110144;
        /// <summary>
        /// <para>(0400,0510) Encrypted Content Transfer Syntax UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint EncryptedContentTransferSyntaxUID = 67110160;
        /// <summary>
        /// <para>(0400,0520) Encrypted Content</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint EncryptedContent = 67110176;
        /// <summary>
        /// <para>(0400,0550) Modified Attributes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ModifiedAttributesSequence = 67110224;
        /// <summary>
        /// <para>(0400,0561) Original Attributes Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OriginalAttributesSequence = 67110241;
        /// <summary>
        /// <para>(0400,0562) Attribute Modification Datetime</para>
        /// <para> VR: DT VM:1</para>
        /// </summary>
        public const uint AttributeModificationDatetime = 67110242;
        /// <summary>
        /// <para>(0400,0563) Modifying System</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ModifyingSystem = 67110243;
        /// <summary>
        /// <para>(0400,0564) Source of Previous Values</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SourceofPreviousValues = 67110244;
        /// <summary>
        /// <para>(0400,0565) Reason for the Attribute Modification</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReasonfortheAttributeModification = 67110245;
        /// <summary>
        /// <para>(2000,0010) Number of Copies</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofCopies = 536870928;
        /// <summary>
        /// <para>(2000,001E) Printer Configuration Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PrinterConfigurationSequence = 536870942;
        /// <summary>
        /// <para>(2000,0020) Print Priority</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PrintPriority = 536870944;
        /// <summary>
        /// <para>(2000,0030) Medium Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MediumType = 536870960;
        /// <summary>
        /// <para>(2000,0040) Film Destination</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilmDestination = 536870976;
        /// <summary>
        /// <para>(2000,0050) Film Session Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FilmSessionLabel = 536870992;
        /// <summary>
        /// <para>(2000,0060) Memory Allocation</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint MemoryAllocation = 536871008;
        /// <summary>
        /// <para>(2000,0061) Maximum Memory Allocation</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint MaximumMemoryAllocation = 536871009;
        /// <summary>
        /// <para>(2000,0062) Color Image Printing Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ColorImagePrintingFlagRetired = 536871010;
        /// <summary>
        /// <para>(2000,0063) Collation Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CollationFlagRetired = 536871011;
        /// <summary>
        /// <para>(2000,0065) Annotation Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AnnotationFlagRetired = 536871013;
        /// <summary>
        /// <para>(2000,0067) Image Overlay Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageOverlayFlagRetired = 536871015;
        /// <summary>
        /// <para>(2000,0069) Presentation LUT Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PresentationLUTFlagRetired = 536871017;
        /// <summary>
        /// <para>(2000,006A) Image Box Presentation LUT Flag</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageBoxPresentationLUTFlagRetired = 536871018;
        /// <summary>
        /// <para>(2000,00A0) Memory Bit Depth</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MemoryBitDepth = 536871072;
        /// <summary>
        /// <para>(2000,00A1) Printing Bit Depth</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint PrintingBitDepth = 536871073;
        /// <summary>
        /// <para>(2000,00A2) Media Installed Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MediaInstalledSequence = 536871074;
        /// <summary>
        /// <para>(2000,00A4) Other Media Available Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint OtherMediaAvailableSequence = 536871076;
        /// <summary>
        /// <para>(2000,00A8) Supported Image Display Formats Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SupportedImageDisplayFormatsSequence = 536871080;
        /// <summary>
        /// <para>(2000,0500) Referenced Film Box Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedFilmBoxSequence = 536872192;
        /// <summary>
        /// <para>(2000,0510) Referenced Stored Print  Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedStoredPrintSequence = 536872208;
        /// <summary>
        /// <para>(2010,0010) Image Display Format</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ImageDisplayFormat = 537919504;
        /// <summary>
        /// <para>(2010,0030) Annotation Display Format ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AnnotationDisplayFormatID = 537919536;
        /// <summary>
        /// <para>(2010,0040) Film Orientation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilmOrientation = 537919552;
        /// <summary>
        /// <para>(2010,0050) Film Size ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FilmSizeID = 537919568;
        /// <summary>
        /// <para>(2010,0052) Printer Resolution ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PrinterResolutionID = 537919570;
        /// <summary>
        /// <para>(2010,0054) Default Printer Resolution ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DefaultPrinterResolutionID = 537919572;
        /// <summary>
        /// <para>(2010,0060) Magnification Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint MagnificationType = 537919584;
        /// <summary>
        /// <para>(2010,0080) Smoothing Type  </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SmoothingType = 537919616;
        /// <summary>
        /// <para>(2010,00A6) Default Magnification Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DefaultMagnificationType = 537919654;
        /// <summary>
        /// <para>(2010,00A7) Other Magnification Types Available</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint OtherMagnificationTypesAvailable = 537919655;
        /// <summary>
        /// <para>(2010,00A8) Default Smoothing Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DefaultSmoothingType = 537919656;
        /// <summary>
        /// <para>(2010,00A9) Other Smoothing Types Available</para>
        /// <para> VR: CS VM:1-n</para>
        /// </summary>
        public const uint OtherSmoothingTypesAvailable = 537919657;
        /// <summary>
        /// <para>(2010,0100) Border Density</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BorderDensity = 537919744;
        /// <summary>
        /// <para>(2010,0110) Empty Image Density</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint EmptyImageDensity = 537919760;
        /// <summary>
        /// <para>(2010,0120) Min Density</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MinDensity = 537919776;
        /// <summary>
        /// <para>(2010,0130) Max Density</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint MaxDensity = 537919792;
        /// <summary>
        /// <para>(2010,0140) Trim</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Trim = 537919808;
        /// <summary>
        /// <para>(2010,0150) Configuration Information</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ConfigurationInformation = 537919824;
        /// <summary>
        /// <para>(2010,0152) Configuration Information Description</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint ConfigurationInformationDescription = 537919826;
        /// <summary>
        /// <para>(2010,0154) Maximum Collated Films</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint MaximumCollatedFilms = 537919828;
        /// <summary>
        /// <para>(2010,015E) Illumination</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint Illumination = 537919838;
        /// <summary>
        /// <para>(2010,0160) Reflected Ambient Light</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ReflectedAmbientLight = 537919840;
        /// <summary>
        /// <para>(2010,0376) Printer Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint PrinterPixelSpacing = 537920374;
        /// <summary>
        /// <para>(2010,0500) Referenced Film Session Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedFilmSessionSequence = 537920768;
        /// <summary>
        /// <para>(2010,0510) Referenced Image Box Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedImageBoxSequence = 537920784;
        /// <summary>
        /// <para>(2010,0520) Referenced Basic Annotation Box Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedBasicAnnotationBoxSequence = 537920800;
        /// <summary>
        /// <para>(2020,0010) Image Position</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImagePosition = 538968080;
        /// <summary>
        /// <para>(2020,0020) Polarity</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint Polarity = 538968096;
        /// <summary>
        /// <para>(2020,0030) Requested Image Size</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RequestedImageSize = 538968112;
        /// <summary>
        /// <para>(2020,0040) Requested Decimate/Crop Behavior</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RequestedDecimateCropBehavior = 538968128;
        /// <summary>
        /// <para>(2020,0050) Requested Resolution ID</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RequestedResolutionID = 538968144;
        /// <summary>
        /// <para>(2020,00A0) Requested Image Size Flag</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RequestedImageSizeFlag = 538968224;
        /// <summary>
        /// <para>(2020,00A2) Decimate/Crop Result</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DecimateCropResult = 538968226;
        /// <summary>
        /// <para>(2020,0110) Basic Grayscale Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BasicGrayscaleImageSequence = 538968336;
        /// <summary>
        /// <para>(2020,0111) Basic Color Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BasicColorImageSequence = 538968337;
        /// <summary>
        /// <para>(2020,0130) Referenced Image Overlay Box Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedImageOverlayBoxSequenceRetired = 538968368;
        /// <summary>
        /// <para>(2020,0140) Referenced VOI LUT Box Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedVOILUTBoxSequenceRetired = 538968384;
        /// <summary>
        /// <para>(2030,0010) Annotation Position</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint AnnotationPosition = 540016656;
        /// <summary>
        /// <para>(2030,0020) Text String</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TextString = 540016672;
        /// <summary>
        /// <para>(2040,0010) Referenced Overlay Plane Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedOverlayPlaneSequenceRetired = 541065232;
        /// <summary>
        /// <para>(2040,0011) Referenced Overlay Plane Groups</para>
        /// <para> VR: US VM:1-99</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedOverlayPlaneGroupsRetired = 541065233;
        /// <summary>
        /// <para>(2040,0020) Overlay Pixel Data Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayPixelDataSequenceRetired = 541065248;
        /// <summary>
        /// <para>(2040,0060) Overlay Magnification Type</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayMagnificationTypeRetired = 541065312;
        /// <summary>
        /// <para>(2040,0070) Overlay Smoothing Type</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlaySmoothingTypeRetired = 541065328;
        /// <summary>
        /// <para>(2040,0072) Overlay or Image Magnification</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayorImageMagnificationRetired = 541065330;
        /// <summary>
        /// <para>(2040,0074) Magnify to Number of Columns</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MagnifytoNumberofColumnsRetired = 541065332;
        /// <summary>
        /// <para>(2040,0080) Overlay Foreground Density</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayForegroundDensityRetired = 541065344;
        /// <summary>
        /// <para>(2040,0082) Overlay Background Density</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayBackgroundDensityRetired = 541065346;
        /// <summary>
        /// <para>(2040,0090) Overlay Mode</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayModeRetired = 541065360;
        /// <summary>
        /// <para>(2040,0100) Threshold Density</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ThresholdDensityRetired = 541065472;
        /// <summary>
        /// <para>(2040,0500) Referenced Image Box Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedImageBoxSequenceRetired = 541066496;
        /// <summary>
        /// <para>(2050,0010) Presentation LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PresentationLUTSequence = 542113808;
        /// <summary>
        /// <para>(2050,0020) Presentation LUT Shape</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PresentationLUTShape = 542113824;
        /// <summary>
        /// <para>(2050,0500) Referenced Presentation  LUT Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedPresentationLUTSequence = 542115072;
        /// <summary>
        /// <para>(2100,0010) Print Job ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PrintJobID = 553648144;
        /// <summary>
        /// <para>(2100,0020) Execution Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExecutionStatus = 553648160;
        /// <summary>
        /// <para>(2100,0030) Execution Status Info</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ExecutionStatusInfo = 553648176;
        /// <summary>
        /// <para>(2100,0040) Creation Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint CreationDate = 553648192;
        /// <summary>
        /// <para>(2100,0050) Creation Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint CreationTime = 553648208;
        /// <summary>
        /// <para>(2100,0070) Originator</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint Originator = 553648240;
        /// <summary>
        /// <para>(2100,0140) Destination AE</para>
        /// <para> VR: AE VM:1</para>
        /// </summary>
        public const uint DestinationAE = 553648448;
        /// <summary>
        /// <para>(2100,0160) Owner ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint OwnerID = 553648480;
        /// <summary>
        /// <para>(2100,0170) Number of Films</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofFilms = 553648496;
        /// <summary>
        /// <para>(2100,0500) Referenced Print Job Sequence (Pull Stored Print)</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedPrintJobSequencePullStoredPrintRetired = 553649408;
        /// <summary>
        /// <para>(2110,0010) Printer Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PrinterStatus = 554696720;
        /// <summary>
        /// <para>(2110,0020) Printer Status Info</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PrinterStatusInfo = 554696736;
        /// <summary>
        /// <para>(2110,0030) Printer Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PrinterName = 554696752;
        /// <summary>
        /// <para>(2110,0099) Print Queue ID</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PrintQueueIDRetired = 554696857;
        /// <summary>
        /// <para>(2120,0010) Queue Status</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint QueueStatusRetired = 555745296;
        /// <summary>
        /// <para>(2120,0050) Print Job Description Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PrintJobDescriptionSequenceRetired = 555745360;
        /// <summary>
        /// <para>(2120,0070) Referenced Print Job Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedPrintJobSequenceRetired = 555745392;
        /// <summary>
        /// <para>(2130,0010) Print Management Capabilities Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PrintManagementCapabilitiesSequenceRetired = 556793872;
        /// <summary>
        /// <para>(2130,0015) Printer Characteristics Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PrinterCharacteristicsSequenceRetired = 556793877;
        /// <summary>
        /// <para>(2130,0030) Film Box Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint FilmBoxContentSequenceRetired = 556793904;
        /// <summary>
        /// <para>(2130,0040) Image Box Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageBoxContentSequenceRetired = 556793920;
        /// <summary>
        /// <para>(2130,0050) Annotation Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AnnotationContentSequenceRetired = 556793936;
        /// <summary>
        /// <para>(2130,0060) Image Overlay Box Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImageOverlayBoxContentSequenceRetired = 556793952;
        /// <summary>
        /// <para>(2130,0080) Presentation LUT Content Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PresentationLUTContentSequenceRetired = 556793984;
        /// <summary>
        /// <para>(2130,00A0) Proposed Study Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ProposedStudySequenceRetired = 556794016;
        /// <summary>
        /// <para>(2130,00C0) Original Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OriginalImageSequenceRetired = 556794048;
        /// <summary>
        /// <para>(2200,0001) Label Using Information Extracted From Instances</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint LabelUsingInformationExtractedFromInstances = 570425345;
        /// <summary>
        /// <para>(2200,0002) Label Text</para>
        /// <para> VR: UT VM:1</para>
        /// </summary>
        public const uint LabelText = 570425346;
        /// <summary>
        /// <para>(2200,0003) Label Style Selection</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint LabelStyleSelection = 570425347;
        /// <summary>
        /// <para>(2200,0004) Media Disposition</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint MediaDisposition = 570425348;
        /// <summary>
        /// <para>(2200,0005) Barcode Value</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint BarcodeValue = 570425349;
        /// <summary>
        /// <para>(2200,0006) Barcode Symbology</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BarcodeSymbology = 570425350;
        /// <summary>
        /// <para>(2200,0007) Allow Media Splitting</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AllowMediaSplitting = 570425351;
        /// <summary>
        /// <para>(2200,0008) Include Non-DICOM Objects</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint IncludeNonDICOMObjects = 570425352;
        /// <summary>
        /// <para>(2200,0009) Include Display Application</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint IncludeDisplayApplication = 570425353;
        /// <summary>
        /// <para>(2200,000A) Preserve Composite Instances After Media Creation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PreserveCompositeInstancesAfterMediaCreation = 570425354;
        /// <summary>
        /// <para>(2200,000B) Total Number of Pieces of Media Created</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint TotalNumberofPiecesofMediaCreated = 570425355;
        /// <summary>
        /// <para>(2200,000C) Requested Media Application Profile</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RequestedMediaApplicationProfile = 570425356;
        /// <summary>
        /// <para>(2200,000D) Referenced Storage Media Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedStorageMediaSequence = 570425357;
        /// <summary>
        /// <para>(2200,000E) Failure Attributes</para>
        /// <para> VR: AT VM:1-n</para>
        /// </summary>
        public const uint FailureAttributes = 570425358;
        /// <summary>
        /// <para>(2200,000F) Allow Lossy Compression</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint AllowLossyCompression = 570425359;
        /// <summary>
        /// <para>(2200,0020) Request Priority</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RequestPriority = 570425376;
        /// <summary>
        /// <para>(3002,0002) RT Image Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RTImageLabel = 805437442;
        /// <summary>
        /// <para>(3002,0003) RT Image Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RTImageName = 805437443;
        /// <summary>
        /// <para>(3002,0004) RT Image Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint RTImageDescription = 805437444;
        /// <summary>
        /// <para>(3002,000A) Reported Values Origin</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ReportedValuesOrigin = 805437450;
        /// <summary>
        /// <para>(3002,000C) RT Image Plane</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTImagePlane = 805437452;
        /// <summary>
        /// <para>(3002,000D) X-Ray Image Receptor Translation</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint XRayImageReceptorTranslation = 805437453;
        /// <summary>
        /// <para>(3002,000E) X-Ray Image Receptor Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint XRayImageReceptorAngle = 805437454;
        /// <summary>
        /// <para>(3002,0010) RT Image Orientation</para>
        /// <para> VR: DS VM:6</para>
        /// </summary>
        public const uint RTImageOrientation = 805437456;
        /// <summary>
        /// <para>(3002,0011) Image Plane Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint ImagePlanePixelSpacing = 805437457;
        /// <summary>
        /// <para>(3002,0012) RT Image Position</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint RTImagePosition = 805437458;
        /// <summary>
        /// <para>(3002,0020) Radiation Machine Name</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RadiationMachineName = 805437472;
        /// <summary>
        /// <para>(3002,0022) Radiation Machine SAD</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadiationMachineSAD = 805437474;
        /// <summary>
        /// <para>(3002,0024) Radiation Machine SSD</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RadiationMachineSSD = 805437476;
        /// <summary>
        /// <para>(3002,0026) RT Image SID</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint RTImageSID = 805437478;
        /// <summary>
        /// <para>(3002,0028) Source to Reference Object Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoReferenceObjectDistance = 805437480;
        /// <summary>
        /// <para>(3002,0029) Fraction Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint FractionNumber = 805437481;
        /// <summary>
        /// <para>(3002,0030) Exposure Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ExposureSequence = 805437488;
        /// <summary>
        /// <para>(3002,0032) Meterset Exposure</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint MetersetExposure = 805437490;
        /// <summary>
        /// <para>(3002,0034) Diaphragm Position</para>
        /// <para> VR: DS VM:4</para>
        /// </summary>
        public const uint DiaphragmPosition = 805437492;
        /// <summary>
        /// <para>(3002,0040) Fluence Map Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FluenceMapSequence = 805437504;
        /// <summary>
        /// <para>(3002,0041) Fluence Data Source</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FluenceDataSource = 805437505;
        /// <summary>
        /// <para>(3002,0042) Fluence Data Scale</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FluenceDataScale = 805437506;
        /// <summary>
        /// <para>(3004,0001) DVH Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DVHType = 805568513;
        /// <summary>
        /// <para>(3004,0002) Dose Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DoseUnits = 805568514;
        /// <summary>
        /// <para>(3004,0004) Dose Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DoseType = 805568516;
        /// <summary>
        /// <para>(3004,0006) Dose Comment</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DoseComment = 805568518;
        /// <summary>
        /// <para>(3004,0008) Normalization Point</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint NormalizationPoint = 805568520;
        /// <summary>
        /// <para>(3004,000A) Dose Summation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DoseSummationType = 805568522;
        /// <summary>
        /// <para>(3004,000C) Grid Frame Offset Vector</para>
        /// <para> VR: DS VM:2-n</para>
        /// </summary>
        public const uint GridFrameOffsetVector = 805568524;
        /// <summary>
        /// <para>(3004,000E) Dose Grid Scaling</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DoseGridScaling = 805568526;
        /// <summary>
        /// <para>(3004,0010) RT Dose ROI Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTDoseROISequence = 805568528;
        /// <summary>
        /// <para>(3004,0012) Dose Value</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DoseValue = 805568530;
        /// <summary>
        /// <para>(3004,0014) Tissue Heterogeneity Correction</para>
        /// <para> VR: CS VM:1-3</para>
        /// </summary>
        public const uint TissueHeterogeneityCorrection = 805568532;
        /// <summary>
        /// <para>(3004,0040) DVH Normalization Point</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint DVHNormalizationPoint = 805568576;
        /// <summary>
        /// <para>(3004,0042) DVH Normalization Dose Value</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DVHNormalizationDoseValue = 805568578;
        /// <summary>
        /// <para>(3004,0050) DVH Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DVHSequence = 805568592;
        /// <summary>
        /// <para>(3004,0052) DVH Dose Scaling</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DVHDoseScaling = 805568594;
        /// <summary>
        /// <para>(3004,0054) DVH Volume Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DVHVolumeUnits = 805568596;
        /// <summary>
        /// <para>(3004,0056) DVH Number of Bins</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint DVHNumberofBins = 805568598;
        /// <summary>
        /// <para>(3004,0058) DVH Data</para>
        /// <para> VR: DS VM:2-2n</para>
        /// </summary>
        public const uint DVHData = 805568600;
        /// <summary>
        /// <para>(3004,0060) DVH Referenced ROI Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DVHReferencedROISequence = 805568608;
        /// <summary>
        /// <para>(3004,0062) DVH ROI Contribution Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DVHROIContributionType = 805568610;
        /// <summary>
        /// <para>(3004,0070) DVH Minimum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DVHMinimumDose = 805568624;
        /// <summary>
        /// <para>(3004,0072) DVH Maximum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DVHMaximumDose = 805568626;
        /// <summary>
        /// <para>(3004,0074) DVH Mean Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DVHMeanDose = 805568628;
        /// <summary>
        /// <para>(3006,0002) Structure Set Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint StructureSetLabel = 805699586;
        /// <summary>
        /// <para>(3006,0004) Structure Set Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint StructureSetName = 805699588;
        /// <summary>
        /// <para>(3006,0006) Structure Set Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint StructureSetDescription = 805699590;
        /// <summary>
        /// <para>(3006,0008) Structure Set Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint StructureSetDate = 805699592;
        /// <summary>
        /// <para>(3006,0009) Structure Set Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint StructureSetTime = 805699593;
        /// <summary>
        /// <para>(3006,0010) Referenced Frame of Reference Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedFrameofReferenceSequence = 805699600;
        /// <summary>
        /// <para>(3006,0012) RT Referenced Study Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTReferencedStudySequence = 805699602;
        /// <summary>
        /// <para>(3006,0014) RT Referenced Series Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTReferencedSeriesSequence = 805699604;
        /// <summary>
        /// <para>(3006,0016) Contour Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContourImageSequence = 805699606;
        /// <summary>
        /// <para>(3006,0020) Structure Set ROI Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint StructureSetROISequence = 805699616;
        /// <summary>
        /// <para>(3006,0022) ROI Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ROINumber = 805699618;
        /// <summary>
        /// <para>(3006,0024) Referenced Frame of Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint ReferencedFrameofReferenceUID = 805699620;
        /// <summary>
        /// <para>(3006,0026) ROI Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ROIName = 805699622;
        /// <summary>
        /// <para>(3006,0028) ROI Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ROIDescription = 805699624;
        /// <summary>
        /// <para>(3006,002A) ROI Display Color</para>
        /// <para> VR: IS VM:3</para>
        /// </summary>
        public const uint ROIDisplayColor = 805699626;
        /// <summary>
        /// <para>(3006,002C) ROI Volume</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ROIVolume = 805699628;
        /// <summary>
        /// <para>(3006,0030) RT Related ROI Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTRelatedROISequence = 805699632;
        /// <summary>
        /// <para>(3006,0033) RT ROI Relationship</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTROIRelationship = 805699635;
        /// <summary>
        /// <para>(3006,0036) ROI Generation Algorithm</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ROIGenerationAlgorithm = 805699638;
        /// <summary>
        /// <para>(3006,0038) ROI Generation Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ROIGenerationDescription = 805699640;
        /// <summary>
        /// <para>(3006,0039) ROI Contour Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ROIContourSequence = 805699641;
        /// <summary>
        /// <para>(3006,0040) Contour Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ContourSequence = 805699648;
        /// <summary>
        /// <para>(3006,0042) Contour Geometric Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ContourGeometricType = 805699650;
        /// <summary>
        /// <para>(3006,0044) Contour Slab Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ContourSlabThickness = 805699652;
        /// <summary>
        /// <para>(3006,0045) Contour Offset Vector</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint ContourOffsetVector = 805699653;
        /// <summary>
        /// <para>(3006,0046) Number of Contour Points</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofContourPoints = 805699654;
        /// <summary>
        /// <para>(3006,0048) Contour Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ContourNumber = 805699656;
        /// <summary>
        /// <para>(3006,0049) Attached Contours</para>
        /// <para> VR: IS VM:1-n</para>
        /// </summary>
        public const uint AttachedContours = 805699657;
        /// <summary>
        /// <para>(3006,0050) Contour Data</para>
        /// <para> VR: DS VM:3-3n</para>
        /// </summary>
        public const uint ContourData = 805699664;
        /// <summary>
        /// <para>(3006,0080) RT ROI Observations Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTROIObservationsSequence = 805699712;
        /// <summary>
        /// <para>(3006,0082) Observation Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ObservationNumber = 805699714;
        /// <summary>
        /// <para>(3006,0084) Referenced ROI Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedROINumber = 805699716;
        /// <summary>
        /// <para>(3006,0085) ROI Observation Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ROIObservationLabel = 805699717;
        /// <summary>
        /// <para>(3006,0086) RT ROI Identification Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RTROIIdentificationCodeSequence = 805699718;
        /// <summary>
        /// <para>(3006,0088) ROI Observation Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ROIObservationDescription = 805699720;
        /// <summary>
        /// <para>(3006,00A0) Related RT ROI Observations Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RelatedRTROIObservationsSequence = 805699744;
        /// <summary>
        /// <para>(3006,00A4) RT ROI Interpreted Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTROIInterpretedType = 805699748;
        /// <summary>
        /// <para>(3006,00A6) ROI Interpreter</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ROIInterpreter = 805699750;
        /// <summary>
        /// <para>(3006,00B0) ROI Physical Properties Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ROIPhysicalPropertiesSequence = 805699760;
        /// <summary>
        /// <para>(3006,00B2) ROI Physical Property</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ROIPhysicalProperty = 805699762;
        /// <summary>
        /// <para>(3006,00B4) ROI Physical Property Value</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ROIPhysicalPropertyValue = 805699764;
        /// <summary>
        /// <para>(3006,00C0) Frame of Reference Relationship Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FrameofReferenceRelationshipSequence = 805699776;
        /// <summary>
        /// <para>(3006,00C2) Related Frame of Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint RelatedFrameofReferenceUID = 805699778;
        /// <summary>
        /// <para>(3006,00C4) Frame of Reference Transformation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FrameofReferenceTransformationType = 805699780;
        /// <summary>
        /// <para>(3006,00C6) Frame of Reference Transformation Matrix</para>
        /// <para> VR: DS VM:16</para>
        /// </summary>
        public const uint FrameofReferenceTransformationMatrix = 805699782;
        /// <summary>
        /// <para>(3006,00C8) Frame of Reference Transformation Comment</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FrameofReferenceTransformationComment = 805699784;
        /// <summary>
        /// <para>(300A,0002) RT Plan Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RTPlanLabel = 805961730;
        /// <summary>
        /// <para>(300A,0003) RT Plan Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RTPlanName = 805961731;
        /// <summary>
        /// <para>(300A,0004) RT Plan Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint RTPlanDescription = 805961732;
        /// <summary>
        /// <para>(300A,0006) RT Plan Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint RTPlanDate = 805961734;
        /// <summary>
        /// <para>(300A,0007) RT Plan Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint RTPlanTime = 805961735;
        /// <summary>
        /// <para>(300A,0009) Treatment Protocols</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint TreatmentProtocols = 805961737;
        /// <summary>
        /// <para>(300A,000A) Plan Intent</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PlanIntent = 805961738;
        /// <summary>
        /// <para>(300A,000B) Treatment Sites</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint TreatmentSites = 805961739;
        /// <summary>
        /// <para>(300A,000C) RT Plan Geometry</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTPlanGeometry = 805961740;
        /// <summary>
        /// <para>(300A,000E) Prescription Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint PrescriptionDescription = 805961742;
        /// <summary>
        /// <para>(300A,0010) Dose Reference Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DoseReferenceSequence = 805961744;
        /// <summary>
        /// <para>(300A,0012) Dose Reference Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint DoseReferenceNumber = 805961746;
        /// <summary>
        /// <para>(300A,0013) Dose Reference UID</para>
        /// <para> VR: UI VM:1</para>
        /// </summary>
        public const uint DoseReferenceUID = 805961747;
        /// <summary>
        /// <para>(300A,0014) Dose Reference Structure Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DoseReferenceStructureType = 805961748;
        /// <summary>
        /// <para>(300A,0015) Nominal Beam Energy Unit</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint NominalBeamEnergyUnit = 805961749;
        /// <summary>
        /// <para>(300A,0016) Dose Reference Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint DoseReferenceDescription = 805961750;
        /// <summary>
        /// <para>(300A,0018) Dose Reference Point Coordinates</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint DoseReferencePointCoordinates = 805961752;
        /// <summary>
        /// <para>(300A,001A) Nominal Prior Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint NominalPriorDose = 805961754;
        /// <summary>
        /// <para>(300A,0020) Dose Reference Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint DoseReferenceType = 805961760;
        /// <summary>
        /// <para>(300A,0021) Constraint Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ConstraintWeight = 805961761;
        /// <summary>
        /// <para>(300A,0022) Delivery Warning Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeliveryWarningDose = 805961762;
        /// <summary>
        /// <para>(300A,0023) Delivery Maximum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DeliveryMaximumDose = 805961763;
        /// <summary>
        /// <para>(300A,0025) Target Minimum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TargetMinimumDose = 805961765;
        /// <summary>
        /// <para>(300A,0026) Target Prescription Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TargetPrescriptionDose = 805961766;
        /// <summary>
        /// <para>(300A,0027) Target Maximum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TargetMaximumDose = 805961767;
        /// <summary>
        /// <para>(300A,0028) Target Underdose Volume Fraction</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TargetUnderdoseVolumeFraction = 805961768;
        /// <summary>
        /// <para>(300A,002A) Organ at Risk Full-volume Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint OrganatRiskFullvolumeDose = 805961770;
        /// <summary>
        /// <para>(300A,002B) Organ at Risk Limit Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint OrganatRiskLimitDose = 805961771;
        /// <summary>
        /// <para>(300A,002C) Organ at Risk Maximum Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint OrganatRiskMaximumDose = 805961772;
        /// <summary>
        /// <para>(300A,002D) Organ at Risk Overdose Volume Fraction</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint OrganatRiskOverdoseVolumeFraction = 805961773;
        /// <summary>
        /// <para>(300A,0040) Tolerance Table Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ToleranceTableSequence = 805961792;
        /// <summary>
        /// <para>(300A,0042) Tolerance Table Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ToleranceTableNumber = 805961794;
        /// <summary>
        /// <para>(300A,0043) Tolerance Table Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ToleranceTableLabel = 805961795;
        /// <summary>
        /// <para>(300A,0044) Gantry Angle Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GantryAngleTolerance = 805961796;
        /// <summary>
        /// <para>(300A,0046) Beam Limiting Device Angle Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BeamLimitingDeviceAngleTolerance = 805961798;
        /// <summary>
        /// <para>(300A,0048) Beam Limiting Device Tolerance Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BeamLimitingDeviceToleranceSequence = 805961800;
        /// <summary>
        /// <para>(300A,004A) Beam Limiting Device Position Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BeamLimitingDevicePositionTolerance = 805961802;
        /// <summary>
        /// <para>(300A,004B) Snout Position Tolerance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint SnoutPositionTolerance = 805961803;
        /// <summary>
        /// <para>(300A,004C) Patient Support Angle Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PatientSupportAngleTolerance = 805961804;
        /// <summary>
        /// <para>(300A,004E) Table Top Eccentric Angle Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopEccentricAngleTolerance = 805961806;
        /// <summary>
        /// <para>(300A,004F) Table Top Pitch Angle Tolerance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableTopPitchAngleTolerance = 805961807;
        /// <summary>
        /// <para>(300A,0050) Table Top Roll Angle Tolerance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableTopRollAngleTolerance = 805961808;
        /// <summary>
        /// <para>(300A,0051) Table Top Vertical Position Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopVerticalPositionTolerance = 805961809;
        /// <summary>
        /// <para>(300A,0052) Table Top Longitudinal Position Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLongitudinalPositionTolerance = 805961810;
        /// <summary>
        /// <para>(300A,0053) Table Top Lateral Position Tolerance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLateralPositionTolerance = 805961811;
        /// <summary>
        /// <para>(300A,0055) RT Plan Relationship</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTPlanRelationship = 805961813;
        /// <summary>
        /// <para>(300A,0070) Fraction Group Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FractionGroupSequence = 805961840;
        /// <summary>
        /// <para>(300A,0071) Fraction Group Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint FractionGroupNumber = 805961841;
        /// <summary>
        /// <para>(300A,0072) Fraction Group Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint FractionGroupDescription = 805961842;
        /// <summary>
        /// <para>(300A,0078) Number of Fractions Planned</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofFractionsPlanned = 805961848;
        /// <summary>
        /// <para>(300A,0079) Number of Fraction Pattern Digits Per Day</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofFractionPatternDigitsPerDay = 805961849;
        /// <summary>
        /// <para>(300A,007A) Repeat Fraction Cycle Length</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RepeatFractionCycleLength = 805961850;
        /// <summary>
        /// <para>(300A,007B) Fraction Pattern</para>
        /// <para> VR: LT VM:1</para>
        /// </summary>
        public const uint FractionPattern = 805961851;
        /// <summary>
        /// <para>(300A,0080) Number of Beams</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofBeams = 805961856;
        /// <summary>
        /// <para>(300A,0082) Beam Dose Specification Point</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint BeamDoseSpecificationPoint = 805961858;
        /// <summary>
        /// <para>(300A,0084) Beam Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BeamDose = 805961860;
        /// <summary>
        /// <para>(300A,0086) Beam Meterset</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BeamMeterset = 805961862;
        /// <summary>
        /// <para>(300A,0088) Beam Dose Point Depth</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint BeamDosePointDepth = 805961864;
        /// <summary>
        /// <para>(300A,0089) Beam Dose Point Equivalent Depth</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint BeamDosePointEquivalentDepth = 805961865;
        /// <summary>
        /// <para>(300A,008A) Beam Dose Point SSD</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint BeamDosePointSSD = 805961866;
        /// <summary>
        /// <para>(300A,00A0) Number of Brachy Application Setups</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofBrachyApplicationSetups = 805961888;
        /// <summary>
        /// <para>(300A,00A2) Brachy Application Setup Dose Specification Point</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint BrachyApplicationSetupDoseSpecificationPoint = 805961890;
        /// <summary>
        /// <para>(300A,00A4) Brachy Application Setup Dose</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BrachyApplicationSetupDose = 805961892;
        /// <summary>
        /// <para>(300A,00B0) Beam Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BeamSequence = 805961904;
        /// <summary>
        /// <para>(300A,00B2) Treatment Machine Name </para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint TreatmentMachineName = 805961906;
        /// <summary>
        /// <para>(300A,00B3) Primary Dosimeter Unit</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PrimaryDosimeterUnit = 805961907;
        /// <summary>
        /// <para>(300A,00B4) Source-Axis Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceAxisDistance = 805961908;
        /// <summary>
        /// <para>(300A,00B6) Beam Limiting Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BeamLimitingDeviceSequence = 805961910;
        /// <summary>
        /// <para>(300A,00B8) RT Beam Limiting Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RTBeamLimitingDeviceType = 805961912;
        /// <summary>
        /// <para>(300A,00BA) Source to Beam Limiting Device Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoBeamLimitingDeviceDistance = 805961914;
        /// <summary>
        /// <para>(300A,00BB) Isocenter to Beam Limiting Device Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoBeamLimitingDeviceDistance = 805961915;
        /// <summary>
        /// <para>(300A,00BC) Number of Leaf/Jaw Pairs</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofLeafJawPairs = 805961916;
        /// <summary>
        /// <para>(300A,00BE) Leaf Position Boundaries</para>
        /// <para> VR: DS VM:3-n</para>
        /// </summary>
        public const uint LeafPositionBoundaries = 805961918;
        /// <summary>
        /// <para>(300A,00C0) Beam Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint BeamNumber = 805961920;
        /// <summary>
        /// <para>(300A,00C2) Beam Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint BeamName = 805961922;
        /// <summary>
        /// <para>(300A,00C3) Beam Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint BeamDescription = 805961923;
        /// <summary>
        /// <para>(300A,00C4) Beam Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BeamType = 805961924;
        /// <summary>
        /// <para>(300A,00C6) Radiation Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RadiationType = 805961926;
        /// <summary>
        /// <para>(300A,00C7) High-Dose Technique Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint HighDoseTechniqueType = 805961927;
        /// <summary>
        /// <para>(300A,00C8) Reference Image Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferenceImageNumber = 805961928;
        /// <summary>
        /// <para>(300A,00CA) Planned Verification Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PlannedVerificationImageSequence = 805961930;
        /// <summary>
        /// <para>(300A,00CC) Imaging Device-Specific Acquisition Parameters</para>
        /// <para> VR: LO VM:1-n</para>
        /// </summary>
        public const uint ImagingDeviceSpecificAcquisitionParameters = 805961932;
        /// <summary>
        /// <para>(300A,00CE) Treatment Delivery Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TreatmentDeliveryType = 805961934;
        /// <summary>
        /// <para>(300A,00D0) Number of Wedges</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofWedges = 805961936;
        /// <summary>
        /// <para>(300A,00D1) Wedge Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint WedgeSequence = 805961937;
        /// <summary>
        /// <para>(300A,00D2) Wedge Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint WedgeNumber = 805961938;
        /// <summary>
        /// <para>(300A,00D3) Wedge Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint WedgeType = 805961939;
        /// <summary>
        /// <para>(300A,00D4) Wedge ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint WedgeID = 805961940;
        /// <summary>
        /// <para>(300A,00D5) Wedge Angle</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint WedgeAngle = 805961941;
        /// <summary>
        /// <para>(300A,00D6) Wedge Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint WedgeFactor = 805961942;
        /// <summary>
        /// <para>(300A,00D7) Total Wedge Tray Water-Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TotalWedgeTrayWaterEquivalentThickness = 805961943;
        /// <summary>
        /// <para>(300A,00D8) Wedge Orientation</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint WedgeOrientation = 805961944;
        /// <summary>
        /// <para>(300A,00D9) Isocenter to Wedge Tray Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoWedgeTrayDistance = 805961945;
        /// <summary>
        /// <para>(300A,00DA) Source to Wedge Tray Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoWedgeTrayDistance = 805961946;
        /// <summary>
        /// <para>(300A,00DB) Wedge Thin Edge Position</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint WedgeThinEdgePosition = 805961947;
        /// <summary>
        /// <para>(300A,00DC) Bolus ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint BolusID = 805961948;
        /// <summary>
        /// <para>(300A,00DD) Bolus Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint BolusDescription = 805961949;
        /// <summary>
        /// <para>(300A,00E0) Number of Compensators</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofCompensators = 805961952;
        /// <summary>
        /// <para>(300A,00E1) Material ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint MaterialID = 805961953;
        /// <summary>
        /// <para>(300A,00E2) Total Compensator Tray Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TotalCompensatorTrayFactor = 805961954;
        /// <summary>
        /// <para>(300A,00E3) Compensator Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint CompensatorSequence = 805961955;
        /// <summary>
        /// <para>(300A,00E4) Compensator Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CompensatorNumber = 805961956;
        /// <summary>
        /// <para>(300A,00E5) Compensator ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint CompensatorID = 805961957;
        /// <summary>
        /// <para>(300A,00E6) Source to Compensator Tray Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoCompensatorTrayDistance = 805961958;
        /// <summary>
        /// <para>(300A,00E7) Compensator Rows</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CompensatorRows = 805961959;
        /// <summary>
        /// <para>(300A,00E8) Compensator Columns</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint CompensatorColumns = 805961960;
        /// <summary>
        /// <para>(300A,00E9) Compensator Pixel Spacing</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint CompensatorPixelSpacing = 805961961;
        /// <summary>
        /// <para>(300A,00EA) Compensator Position</para>
        /// <para> VR: DS VM:2</para>
        /// </summary>
        public const uint CompensatorPosition = 805961962;
        /// <summary>
        /// <para>(300A,00EB) Compensator Transmission Data</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint CompensatorTransmissionData = 805961963;
        /// <summary>
        /// <para>(300A,00EC) Compensator Thickness Data</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint CompensatorThicknessData = 805961964;
        /// <summary>
        /// <para>(300A,00ED) Number of Boli</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofBoli = 805961965;
        /// <summary>
        /// <para>(300A,00EE) Compensator Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CompensatorType = 805961966;
        /// <summary>
        /// <para>(300A,00F0) Number of Blocks</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofBlocks = 805961968;
        /// <summary>
        /// <para>(300A,00F2) Total Block Tray Factor</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TotalBlockTrayFactor = 805961970;
        /// <summary>
        /// <para>(300A,00F3) Total Block Tray Water-Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TotalBlockTrayWaterEquivalentThickness = 805961971;
        /// <summary>
        /// <para>(300A,00F4) Block Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BlockSequence = 805961972;
        /// <summary>
        /// <para>(300A,00F5) Block Tray ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint BlockTrayID = 805961973;
        /// <summary>
        /// <para>(300A,00F6) Source to Block Tray Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoBlockTrayDistance = 805961974;
        /// <summary>
        /// <para>(300A,00F7) Isocenter to Block Tray Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoBlockTrayDistance = 805961975;
        /// <summary>
        /// <para>(300A,00F8) Block Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BlockType = 805961976;
        /// <summary>
        /// <para>(300A,00F9) Accessory Code</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint AccessoryCode = 805961977;
        /// <summary>
        /// <para>(300A,00FA) Block Divergence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BlockDivergence = 805961978;
        /// <summary>
        /// <para>(300A,00FB) Block Mounting Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BlockMountingPosition = 805961979;
        /// <summary>
        /// <para>(300A,00FC) Block Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint BlockNumber = 805961980;
        /// <summary>
        /// <para>(300A,00FE) Block Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint BlockName = 805961982;
        /// <summary>
        /// <para>(300A,0100) Block Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BlockThickness = 805961984;
        /// <summary>
        /// <para>(300A,0102) Block Transmission</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BlockTransmission = 805961986;
        /// <summary>
        /// <para>(300A,0104) Block Number of Points</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint BlockNumberofPoints = 805961988;
        /// <summary>
        /// <para>(300A,0106) Block Data</para>
        /// <para> VR: DS VM:2-2n</para>
        /// </summary>
        public const uint BlockData = 805961990;
        /// <summary>
        /// <para>(300A,0107) Applicator Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ApplicatorSequence = 805961991;
        /// <summary>
        /// <para>(300A,0108) Applicator ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ApplicatorID = 805961992;
        /// <summary>
        /// <para>(300A,0109) Applicator Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ApplicatorType = 805961993;
        /// <summary>
        /// <para>(300A,010A) Applicator Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ApplicatorDescription = 805961994;
        /// <summary>
        /// <para>(300A,010C) Cumulative Dose Reference Coefficient</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CumulativeDoseReferenceCoefficient = 805961996;
        /// <summary>
        /// <para>(300A,010E) Final Cumulative Meterset Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FinalCumulativeMetersetWeight = 805961998;
        /// <summary>
        /// <para>(300A,0110) Number of Control Points</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofControlPoints = 805962000;
        /// <summary>
        /// <para>(300A,0111) Control Point Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ControlPointSequence = 805962001;
        /// <summary>
        /// <para>(300A,0112) Control Point Index</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ControlPointIndex = 805962002;
        /// <summary>
        /// <para>(300A,0114) Nominal Beam Energy</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint NominalBeamEnergy = 805962004;
        /// <summary>
        /// <para>(300A,0115) Dose Rate Set</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint DoseRateSet = 805962005;
        /// <summary>
        /// <para>(300A,0116) Wedge Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint WedgePositionSequence = 805962006;
        /// <summary>
        /// <para>(300A,0118) Wedge Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint WedgePosition = 805962008;
        /// <summary>
        /// <para>(300A,011A) Beam Limiting Device Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BeamLimitingDevicePositionSequence = 805962010;
        /// <summary>
        /// <para>(300A,011C) Leaf/Jaw Positions</para>
        /// <para> VR: DS VM:2-2n</para>
        /// </summary>
        public const uint LeafJawPositions = 805962012;
        /// <summary>
        /// <para>(300A,011E) Gantry Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint GantryAngle = 805962014;
        /// <summary>
        /// <para>(300A,011F) Gantry Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GantryRotationDirection = 805962015;
        /// <summary>
        /// <para>(300A,0120) Beam Limiting Device Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BeamLimitingDeviceAngle = 805962016;
        /// <summary>
        /// <para>(300A,0121) Beam Limiting Device Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BeamLimitingDeviceRotationDirection = 805962017;
        /// <summary>
        /// <para>(300A,0122) Patient Support Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PatientSupportAngle = 805962018;
        /// <summary>
        /// <para>(300A,0123) Patient Support Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientSupportRotationDirection = 805962019;
        /// <summary>
        /// <para>(300A,0124) Table Top Eccentric Axis Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopEccentricAxisDistance = 805962020;
        /// <summary>
        /// <para>(300A,0125) Table Top Eccentric Angle</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopEccentricAngle = 805962021;
        /// <summary>
        /// <para>(300A,0126) Table Top Eccentric Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TableTopEccentricRotationDirection = 805962022;
        /// <summary>
        /// <para>(300A,0128) Table Top Vertical Position</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopVerticalPosition = 805962024;
        /// <summary>
        /// <para>(300A,0129) Table Top Longitudinal Position</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLongitudinalPosition = 805962025;
        /// <summary>
        /// <para>(300A,012A) Table Top Lateral Position</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLateralPosition = 805962026;
        /// <summary>
        /// <para>(300A,012C) Isocenter Position</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint IsocenterPosition = 805962028;
        /// <summary>
        /// <para>(300A,012E) Surface Entry Point</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint SurfaceEntryPoint = 805962030;
        /// <summary>
        /// <para>(300A,0130) Source to Surface Distance</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourcetoSurfaceDistance = 805962032;
        /// <summary>
        /// <para>(300A,0134) Cumulative Meterset Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CumulativeMetersetWeight = 805962036;
        /// <summary>
        /// <para>(300A,0140) Table Top Pitch Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableTopPitchAngle = 805962048;
        /// <summary>
        /// <para>(300A,0142) Table Top Pitch Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TableTopPitchRotationDirection = 805962050;
        /// <summary>
        /// <para>(300A,0144) Table Top Roll Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TableTopRollAngle = 805962052;
        /// <summary>
        /// <para>(300A,0146) Table Top Roll Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint TableTopRollRotationDirection = 805962054;
        /// <summary>
        /// <para>(300A,0148) Head Fixation Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint HeadFixationAngle = 805962056;
        /// <summary>
        /// <para>(300A,014A) Gantry Pitch Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint GantryPitchAngle = 805962058;
        /// <summary>
        /// <para>(300A,014C) Gantry Pitch Rotation Direction</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint GantryPitchRotationDirection = 805962060;
        /// <summary>
        /// <para>(300A,014E) Gantry Pitch Angle Tolerance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint GantryPitchAngleTolerance = 805962062;
        /// <summary>
        /// <para>(300A,0180) Patient Setup Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PatientSetupSequence = 805962112;
        /// <summary>
        /// <para>(300A,0182) Patient Setup Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint PatientSetupNumber = 805962114;
        /// <summary>
        /// <para>(300A,0183) Patient Setup Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientSetupLabel = 805962115;
        /// <summary>
        /// <para>(300A,0184) Patient Additional Position</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientAdditionalPosition = 805962116;
        /// <summary>
        /// <para>(300A,0190) Fixation Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint FixationDeviceSequence = 805962128;
        /// <summary>
        /// <para>(300A,0192) Fixation Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint FixationDeviceType = 805962130;
        /// <summary>
        /// <para>(300A,0194) Fixation Device Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint FixationDeviceLabel = 805962132;
        /// <summary>
        /// <para>(300A,0196) Fixation Device Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint FixationDeviceDescription = 805962134;
        /// <summary>
        /// <para>(300A,0198) Fixation Device Position</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint FixationDevicePosition = 805962136;
        /// <summary>
        /// <para>(300A,0199) Fixation Device Pitch Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint FixationDevicePitchAngle = 805962137;
        /// <summary>
        /// <para>(300A,019A) Fixation Device Roll Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint FixationDeviceRollAngle = 805962138;
        /// <summary>
        /// <para>(300A,01A0) Shielding Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ShieldingDeviceSequence = 805962144;
        /// <summary>
        /// <para>(300A,01A2) Shielding Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ShieldingDeviceType = 805962146;
        /// <summary>
        /// <para>(300A,01A4) Shielding Device Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ShieldingDeviceLabel = 805962148;
        /// <summary>
        /// <para>(300A,01A6) Shielding Device Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint ShieldingDeviceDescription = 805962150;
        /// <summary>
        /// <para>(300A,01A8) Shielding Device Position</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ShieldingDevicePosition = 805962152;
        /// <summary>
        /// <para>(300A,01B0) Setup Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SetupTechnique = 805962160;
        /// <summary>
        /// <para>(300A,01B2) Setup Technique Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint SetupTechniqueDescription = 805962162;
        /// <summary>
        /// <para>(300A,01B4) Setup Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SetupDeviceSequence = 805962164;
        /// <summary>
        /// <para>(300A,01B6) Setup Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SetupDeviceType = 805962166;
        /// <summary>
        /// <para>(300A,01B8) Setup Device Label</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint SetupDeviceLabel = 805962168;
        /// <summary>
        /// <para>(300A,01BA) Setup Device Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint SetupDeviceDescription = 805962170;
        /// <summary>
        /// <para>(300A,01BC) Setup Device Parameter</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SetupDeviceParameter = 805962172;
        /// <summary>
        /// <para>(300A,01D0) Setup Reference Description</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint SetupReferenceDescription = 805962192;
        /// <summary>
        /// <para>(300A,01D2) Table Top Vertical Setup Displacement</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopVerticalSetupDisplacement = 805962194;
        /// <summary>
        /// <para>(300A,01D4) Table Top Longitudinal Setup Displacement</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLongitudinalSetupDisplacement = 805962196;
        /// <summary>
        /// <para>(300A,01D6) Table Top Lateral Setup Displacement</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TableTopLateralSetupDisplacement = 805962198;
        /// <summary>
        /// <para>(300A,0200) Brachy Treatment Technique</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BrachyTreatmentTechnique = 805962240;
        /// <summary>
        /// <para>(300A,0202) Brachy Treatment Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BrachyTreatmentType = 805962242;
        /// <summary>
        /// <para>(300A,0206) Treatment Machine Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint TreatmentMachineSequence = 805962246;
        /// <summary>
        /// <para>(300A,0210) Source Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SourceSequence = 805962256;
        /// <summary>
        /// <para>(300A,0212) Source Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint SourceNumber = 805962258;
        /// <summary>
        /// <para>(300A,0214) Source Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SourceType = 805962260;
        /// <summary>
        /// <para>(300A,0216) Source Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SourceManufacturer = 805962262;
        /// <summary>
        /// <para>(300A,0218) Active Source Diameter</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ActiveSourceDiameter = 805962264;
        /// <summary>
        /// <para>(300A,021A) Active Source Length</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ActiveSourceLength = 805962266;
        /// <summary>
        /// <para>(300A,0222) Source Encapsulation Nominal Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceEncapsulationNominalThickness = 805962274;
        /// <summary>
        /// <para>(300A,0224) Source Encapsulation Nominal Transmission</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceEncapsulationNominalTransmission = 805962276;
        /// <summary>
        /// <para>(300A,0226) Source Isotope Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SourceIsotopeName = 805962278;
        /// <summary>
        /// <para>(300A,0228) Source Isotope Half Life</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceIsotopeHalfLife = 805962280;
        /// <summary>
        /// <para>(300A,0229) Source Strength Units</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SourceStrengthUnits = 805962281;
        /// <summary>
        /// <para>(300A,022A) Reference Air Kerma Rate</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ReferenceAirKermaRate = 805962282;
        /// <summary>
        /// <para>(300A,022B) Source Strength</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceStrength = 805962283;
        /// <summary>
        /// <para>(300A,022C) Source Strength Reference Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint SourceStrengthReferenceDate = 805962284;
        /// <summary>
        /// <para>(300A,022E) Source Strength Reference Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint SourceStrengthReferenceTime = 805962286;
        /// <summary>
        /// <para>(300A,0230) Application Setup Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ApplicationSetupSequence = 805962288;
        /// <summary>
        /// <para>(300A,0232) Application Setup Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ApplicationSetupType = 805962290;
        /// <summary>
        /// <para>(300A,0234) Application Setup Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ApplicationSetupNumber = 805962292;
        /// <summary>
        /// <para>(300A,0236) Application Setup Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ApplicationSetupName = 805962294;
        /// <summary>
        /// <para>(300A,0238) Application Setup Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ApplicationSetupManufacturer = 805962296;
        /// <summary>
        /// <para>(300A,0240) Template Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint TemplateNumber = 805962304;
        /// <summary>
        /// <para>(300A,0242) Template Type</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint TemplateType = 805962306;
        /// <summary>
        /// <para>(300A,0244) Template Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint TemplateName = 805962308;
        /// <summary>
        /// <para>(300A,0250) Total Reference Air Kerma</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TotalReferenceAirKerma = 805962320;
        /// <summary>
        /// <para>(300A,0260) Brachy Accessory Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceSequence = 805962336;
        /// <summary>
        /// <para>(300A,0262) Brachy Accessory Device Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceNumber = 805962338;
        /// <summary>
        /// <para>(300A,0263) Brachy Accessory Device ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceID = 805962339;
        /// <summary>
        /// <para>(300A,0264) Brachy Accessory Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceType = 805962340;
        /// <summary>
        /// <para>(300A,0266) Brachy Accessory Device Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceName = 805962342;
        /// <summary>
        /// <para>(300A,026A) Brachy Accessory Device Nominal Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceNominalThickness = 805962346;
        /// <summary>
        /// <para>(300A,026C) Brachy Accessory Device Nominal Transmission</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint BrachyAccessoryDeviceNominalTransmission = 805962348;
        /// <summary>
        /// <para>(300A,0280) Channel Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelSequence = 805962368;
        /// <summary>
        /// <para>(300A,0282) Channel Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ChannelNumber = 805962370;
        /// <summary>
        /// <para>(300A,0284) Channel Length</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelLength = 805962372;
        /// <summary>
        /// <para>(300A,0286) Channel Total Time</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelTotalTime = 805962374;
        /// <summary>
        /// <para>(300A,0288) Source Movement Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SourceMovementType = 805962376;
        /// <summary>
        /// <para>(300A,028A) Number of Pulses</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPulses = 805962378;
        /// <summary>
        /// <para>(300A,028C) Pulse Repetition Interval</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint PulseRepetitionInterval = 805962380;
        /// <summary>
        /// <para>(300A,0290) Source Applicator Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorNumber = 805962384;
        /// <summary>
        /// <para>(300A,0291) Source Applicator ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint SourceApplicatorID = 805962385;
        /// <summary>
        /// <para>(300A,0292) Source Applicator Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorType = 805962386;
        /// <summary>
        /// <para>(300A,0294) Source Applicator Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SourceApplicatorName = 805962388;
        /// <summary>
        /// <para>(300A,0296) Source Applicator Length</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorLength = 805962390;
        /// <summary>
        /// <para>(300A,0298) Source Applicator Manufacturer</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint SourceApplicatorManufacturer = 805962392;
        /// <summary>
        /// <para>(300A,029C) Source Applicator Wall Nominal Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorWallNominalThickness = 805962396;
        /// <summary>
        /// <para>(300A,029E) Source Applicator Wall Nominal Transmission</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorWallNominalTransmission = 805962398;
        /// <summary>
        /// <para>(300A,02A0) Source Applicator Step Size</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint SourceApplicatorStepSize = 805962400;
        /// <summary>
        /// <para>(300A,02A2) Transfer Tube Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint TransferTubeNumber = 805962402;
        /// <summary>
        /// <para>(300A,02A4) Transfer Tube Length</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint TransferTubeLength = 805962404;
        /// <summary>
        /// <para>(300A,02B0) Channel Shield Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ChannelShieldSequence = 805962416;
        /// <summary>
        /// <para>(300A,02B2) Channel Shield Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ChannelShieldNumber = 805962418;
        /// <summary>
        /// <para>(300A,02B3) Channel Shield ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ChannelShieldID = 805962419;
        /// <summary>
        /// <para>(300A,02B4) Channel Shield Name</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint ChannelShieldName = 805962420;
        /// <summary>
        /// <para>(300A,02B8) Channel Shield Nominal Thickness</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelShieldNominalThickness = 805962424;
        /// <summary>
        /// <para>(300A,02BA) Channel Shield Nominal Transmission</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ChannelShieldNominalTransmission = 805962426;
        /// <summary>
        /// <para>(300A,02C8) Final Cumulative Time Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint FinalCumulativeTimeWeight = 805962440;
        /// <summary>
        /// <para>(300A,02D0) Brachy Control Point Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BrachyControlPointSequence = 805962448;
        /// <summary>
        /// <para>(300A,02D2) Control Point Relative Position</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ControlPointRelativePosition = 805962450;
        /// <summary>
        /// <para>(300A,02D4) Control Point 3D Position</para>
        /// <para> VR: DS VM:3</para>
        /// </summary>
        public const uint ControlPoint3DPosition = 805962452;
        /// <summary>
        /// <para>(300A,02D6) Cumulative Time Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint CumulativeTimeWeight = 805962454;
        /// <summary>
        /// <para>(300A,02E0) Compensator Divergence</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CompensatorDivergence = 805962464;
        /// <summary>
        /// <para>(300A,02E1) Compensator Mounting Position</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint CompensatorMountingPosition = 805962465;
        /// <summary>
        /// <para>(300A,02E2) Source to Compensator Distance</para>
        /// <para> VR: DS VM:1-n</para>
        /// </summary>
        public const uint SourcetoCompensatorDistance = 805962466;
        /// <summary>
        /// <para>(300A,02E3) Total Compensator Tray Water-Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint TotalCompensatorTrayWaterEquivalentThickness = 805962467;
        /// <summary>
        /// <para>(300A,02E4) Isocenter to Compensator Tray Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoCompensatorTrayDistance = 805962468;
        /// <summary>
        /// <para>(300A,02E5) Compensator Column Offset</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CompensatorColumnOffset = 805962469;
        /// <summary>
        /// <para>(300A,02E6) Isocenter to Compensator Distances</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint IsocentertoCompensatorDistances = 805962470;
        /// <summary>
        /// <para>(300A,02E7) Compensator Relative Stopping Power Ratio</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CompensatorRelativeStoppingPowerRatio = 805962471;
        /// <summary>
        /// <para>(300A,02E8) Compensator Milling Tool Diameter</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint CompensatorMillingToolDiameter = 805962472;
        /// <summary>
        /// <para>(300A,02EA) Ion Range Compensator Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonRangeCompensatorSequence = 805962474;
        /// <summary>
        /// <para>(300A,0302) Radiation Mass Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RadiationMassNumber = 805962498;
        /// <summary>
        /// <para>(300A,0304) Radiation Atomic Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RadiationAtomicNumber = 805962500;
        /// <summary>
        /// <para>(300A,0306) Radiation Charge State</para>
        /// <para> VR: SS VM:1</para>
        /// </summary>
        public const uint RadiationChargeState = 805962502;
        /// <summary>
        /// <para>(300A,0308) Scan Mode</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ScanMode = 805962504;
        /// <summary>
        /// <para>(300A,030A) Virtual Source-Axis Distances</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint VirtualSourceAxisDistances = 805962506;
        /// <summary>
        /// <para>(300A,030C) Snout Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SnoutSequence = 805962508;
        /// <summary>
        /// <para>(300A,030D) Snout Position</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint SnoutPosition = 805962509;
        /// <summary>
        /// <para>(300A,030F) Snout ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint SnoutID = 805962511;
        /// <summary>
        /// <para>(300A,0312) Number of Range Shifters</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofRangeShifters = 805962514;
        /// <summary>
        /// <para>(300A,0314) Range Shifter Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RangeShifterSequence = 805962516;
        /// <summary>
        /// <para>(300A,0316) Range Shifter Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RangeShifterNumber = 805962518;
        /// <summary>
        /// <para>(300A,0318) Range Shifter ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RangeShifterID = 805962520;
        /// <summary>
        /// <para>(300A,0320) Range Shifter Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RangeShifterType = 805962528;
        /// <summary>
        /// <para>(300A,0322) Range Shifter Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RangeShifterDescription = 805962530;
        /// <summary>
        /// <para>(300A,0330) Number of Lateral Spreading Devices</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofLateralSpreadingDevices = 805962544;
        /// <summary>
        /// <para>(300A,0332) Lateral Spreading Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceSequence = 805962546;
        /// <summary>
        /// <para>(300A,0334) Lateral Spreading Device Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceNumber = 805962548;
        /// <summary>
        /// <para>(300A,0336) Lateral Spreading Device ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceID = 805962550;
        /// <summary>
        /// <para>(300A,0338) Lateral Spreading Device Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceType = 805962552;
        /// <summary>
        /// <para>(300A,033A) Lateral Spreading Device Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceDescription = 805962554;
        /// <summary>
        /// <para>(300A,033C) Lateral Spreading Device Water Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceWaterEquivalentThickness = 805962556;
        /// <summary>
        /// <para>(300A,0340) Number of Range Modulators</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofRangeModulators = 805962560;
        /// <summary>
        /// <para>(300A,0342) Range Modulator Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RangeModulatorSequence = 805962562;
        /// <summary>
        /// <para>(300A,0344) Range Modulator Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint RangeModulatorNumber = 805962564;
        /// <summary>
        /// <para>(300A,0346) Range Modulator ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint RangeModulatorID = 805962566;
        /// <summary>
        /// <para>(300A,0348) Range Modulator Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint RangeModulatorType = 805962568;
        /// <summary>
        /// <para>(300A,034A) Range Modulator Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RangeModulatorDescription = 805962570;
        /// <summary>
        /// <para>(300A,034C) Beam Current Modulation ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint BeamCurrentModulationID = 805962572;
        /// <summary>
        /// <para>(300A,0350) Patient Support Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint PatientSupportType = 805962576;
        /// <summary>
        /// <para>(300A,0352) Patient Support ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint PatientSupportID = 805962578;
        /// <summary>
        /// <para>(300A,0354) Patient Support Accessory Code</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint PatientSupportAccessoryCode = 805962580;
        /// <summary>
        /// <para>(300A,0356) Fixation Light Azimuthal Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint FixationLightAzimuthalAngle = 805962582;
        /// <summary>
        /// <para>(300A,0358) Fixation Light Polar Angle</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint FixationLightPolarAngle = 805962584;
        /// <summary>
        /// <para>(300A,035A) Meterset Rate</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint MetersetRate = 805962586;
        /// <summary>
        /// <para>(300A,0360) Range Shifter Settings Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RangeShifterSettingsSequence = 805962592;
        /// <summary>
        /// <para>(300A,0362) Range Shifter Setting</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint RangeShifterSetting = 805962594;
        /// <summary>
        /// <para>(300A,0364) Isocenter to Range Shifter Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoRangeShifterDistance = 805962596;
        /// <summary>
        /// <para>(300A,0366) Range Shifter Water Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RangeShifterWaterEquivalentThickness = 805962598;
        /// <summary>
        /// <para>(300A,0370) Lateral Spreading Device Settings Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceSettingsSequence = 805962608;
        /// <summary>
        /// <para>(300A,0372) Lateral Spreading Device Setting</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint LateralSpreadingDeviceSetting = 805962610;
        /// <summary>
        /// <para>(300A,0374) Isocenter to Lateral Spreading Device Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoLateralSpreadingDeviceDistance = 805962612;
        /// <summary>
        /// <para>(300A,0380) Range Modulator Settings Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint RangeModulatorSettingsSequence = 805962624;
        /// <summary>
        /// <para>(300A,0382) Range Modulator Gating Start Value</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RangeModulatorGatingStartValue = 805962626;
        /// <summary>
        /// <para>(300A,0384) Range Modulator Gating Stop Value</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RangeModulatorGatingStopValue = 805962628;
        /// <summary>
        /// <para>(300A,0386) Range Modulator Gating Start Water Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RangeModulatorGatingStartWaterEquivalentThickness = 805962630;
        /// <summary>
        /// <para>(300A,0388) Range Modulator Gating Stop Water Equivalent Thickness</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint RangeModulatorGatingStopWaterEquivalentThickness = 805962632;
        /// <summary>
        /// <para>(300A,038A) Isocenter to Range Modulator Distance</para>
        /// <para> VR: FL VM:1</para>
        /// </summary>
        public const uint IsocentertoRangeModulatorDistance = 805962634;
        /// <summary>
        /// <para>(300A,0390) Scan Spot Tune ID</para>
        /// <para> VR: SH VM:1</para>
        /// </summary>
        public const uint ScanSpotTuneID = 805962640;
        /// <summary>
        /// <para>(300A,0392) Number of Scan Spot Positions</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofScanSpotPositions = 805962642;
        /// <summary>
        /// <para>(300A,0394) Scan Spot Position Map</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint ScanSpotPositionMap = 805962644;
        /// <summary>
        /// <para>(300A,0396) Scan Spot Meterset Weights</para>
        /// <para> VR: FL VM:1-n</para>
        /// </summary>
        public const uint ScanSpotMetersetWeights = 805962646;
        /// <summary>
        /// <para>(300A,0398) Scanning Spot Size</para>
        /// <para> VR: FL VM:2</para>
        /// </summary>
        public const uint ScanningSpotSize = 805962648;
        /// <summary>
        /// <para>(300A,039A) Number of Paintings</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofPaintings = 805962650;
        /// <summary>
        /// <para>(300A,03A0) Ion Tolerance Table Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonToleranceTableSequence = 805962656;
        /// <summary>
        /// <para>(300A,03A2) Ion Beam Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonBeamSequence = 805962658;
        /// <summary>
        /// <para>(300A,03A4) Ion Beam Limiting Device Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonBeamLimitingDeviceSequence = 805962660;
        /// <summary>
        /// <para>(300A,03A6) Ion Block Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonBlockSequence = 805962662;
        /// <summary>
        /// <para>(300A,03A8) Ion Control Point Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonControlPointSequence = 805962664;
        /// <summary>
        /// <para>(300A,03AA) Ion Wedge Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonWedgeSequence = 805962666;
        /// <summary>
        /// <para>(300A,03AC) Ion Wedge Position Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint IonWedgePositionSequence = 805962668;
        /// <summary>
        /// <para>(300A,0401) Referenced Setup Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedSetupImageSequence = 805962753;
        /// <summary>
        /// <para>(300A,0402) Setup Image Comment</para>
        /// <para> VR: ST VM:1</para>
        /// </summary>
        public const uint SetupImageComment = 805962754;
        /// <summary>
        /// <para>(300A,0410) Motion Synchronization Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MotionSynchronizationSequence = 805962768;
        /// <summary>
        /// <para>(300C,0002) Referenced RT Plan Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedRTPlanSequence = 806092802;
        /// <summary>
        /// <para>(300C,0004) Referenced Beam Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedBeamSequence = 806092804;
        /// <summary>
        /// <para>(300C,0006) Referenced Beam Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedBeamNumber = 806092806;
        /// <summary>
        /// <para>(300C,0007) Referenced Reference Image Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedReferenceImageNumber = 806092807;
        /// <summary>
        /// <para>(300C,0008) Start Cumulative Meterset Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint StartCumulativeMetersetWeight = 806092808;
        /// <summary>
        /// <para>(300C,0009) End Cumulative Meterset Weight</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint EndCumulativeMetersetWeight = 806092809;
        /// <summary>
        /// <para>(300C,000A) Referenced Brachy Application Setup Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedBrachyApplicationSetupSequence = 806092810;
        /// <summary>
        /// <para>(300C,000C) Referenced Brachy Application Setup Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedBrachyApplicationSetupNumber = 806092812;
        /// <summary>
        /// <para>(300C,000E) Referenced Source Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedSourceNumber = 806092814;
        /// <summary>
        /// <para>(300C,0020) Referenced Fraction Group Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedFractionGroupSequence = 806092832;
        /// <summary>
        /// <para>(300C,0022) Referenced Fraction Group Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedFractionGroupNumber = 806092834;
        /// <summary>
        /// <para>(300C,0040) Referenced Verification Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedVerificationImageSequence = 806092864;
        /// <summary>
        /// <para>(300C,0042) Referenced Reference Image Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedReferenceImageSequence = 806092866;
        /// <summary>
        /// <para>(300C,0050) Referenced Dose Reference Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedDoseReferenceSequence = 806092880;
        /// <summary>
        /// <para>(300C,0051) Referenced Dose Reference Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedDoseReferenceNumber = 806092881;
        /// <summary>
        /// <para>(300C,0055) Brachy Referenced Dose Reference Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint BrachyReferencedDoseReferenceSequence = 806092885;
        /// <summary>
        /// <para>(300C,0060) Referenced Structure Set Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedStructureSetSequence = 806092896;
        /// <summary>
        /// <para>(300C,006A) Referenced Patient Setup Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedPatientSetupNumber = 806092906;
        /// <summary>
        /// <para>(300C,0080) Referenced Dose Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedDoseSequence = 806092928;
        /// <summary>
        /// <para>(300C,00A0) Referenced Tolerance Table Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedToleranceTableNumber = 806092960;
        /// <summary>
        /// <para>(300C,00B0) Referenced Bolus Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedBolusSequence = 806092976;
        /// <summary>
        /// <para>(300C,00C0) Referenced Wedge Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedWedgeNumber = 806092992;
        /// <summary>
        /// <para>(300C,00D0) Referenced Compensator Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedCompensatorNumber = 806093008;
        /// <summary>
        /// <para>(300C,00E0) Referenced Block Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedBlockNumber = 806093024;
        /// <summary>
        /// <para>(300C,00F0) Referenced Control Point Index</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedControlPointIndex = 806093040;
        /// <summary>
        /// <para>(300C,00F2) Referenced Control Point Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint ReferencedControlPointSequence = 806093042;
        /// <summary>
        /// <para>(300C,00F4) Referenced Start Control Point Index</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedStartControlPointIndex = 806093044;
        /// <summary>
        /// <para>(300C,00F6) Referenced Stop Control Point Index</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedStopControlPointIndex = 806093046;
        /// <summary>
        /// <para>(300C,0100) Referenced Range Shifter Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedRangeShifterNumber = 806093056;
        /// <summary>
        /// <para>(300C,0102) Referenced Lateral Spreading Device Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedLateralSpreadingDeviceNumber = 806093058;
        /// <summary>
        /// <para>(300C,0104) Referenced Range Modulator Number</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ReferencedRangeModulatorNumber = 806093060;
        /// <summary>
        /// <para>(300E,0002) Approval Status</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint ApprovalStatus = 806223874;
        /// <summary>
        /// <para>(300E,0004) Review Date</para>
        /// <para> VR: DA VM:1</para>
        /// </summary>
        public const uint ReviewDate = 806223876;
        /// <summary>
        /// <para>(300E,0005) Review Time</para>
        /// <para> VR: TM VM:1</para>
        /// </summary>
        public const uint ReviewTime = 806223877;
        /// <summary>
        /// <para>(300E,0008) Reviewer Name</para>
        /// <para> VR: PN VM:1</para>
        /// </summary>
        public const uint ReviewerName = 806223880;
        /// <summary>
        /// <para>(4000,0010) Arbitrary</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ArbitraryRetired = 1073741840;
        /// <summary>
        /// <para>(4000,4000) Text Comments</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TextCommentsRetired = 1073758208;
        /// <summary>
        /// <para>(4008,0040) Results ID</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ResultsIDRetired = 1074266176;
        /// <summary>
        /// <para>(4008,0042) Results ID Issuer</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ResultsIDIssuerRetired = 1074266178;
        /// <summary>
        /// <para>(4008,0050) Referenced Interpretation Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencedInterpretationSequenceRetired = 1074266192;
        /// <summary>
        /// <para>(4008,0100) Interpretation Recorded Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationRecordedDateRetired = 1074266368;
        /// <summary>
        /// <para>(4008,0101) Interpretation Recorded Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationRecordedTimeRetired = 1074266369;
        /// <summary>
        /// <para>(4008,0102) Interpretation Recorder</para>
        /// <para> VR: PN VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationRecorderRetired = 1074266370;
        /// <summary>
        /// <para>(4008,0103) Reference to Recorded Sound</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ReferencetoRecordedSoundRetired = 1074266371;
        /// <summary>
        /// <para>(4008,0108) Interpretation Transcription Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationTranscriptionDateRetired = 1074266376;
        /// <summary>
        /// <para>(4008,0109) Interpretation Transcription Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationTranscriptionTimeRetired = 1074266377;
        /// <summary>
        /// <para>(4008,010A) Interpretation Transcriber</para>
        /// <para> VR: PN VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationTranscriberRetired = 1074266378;
        /// <summary>
        /// <para>(4008,010B) Interpretation Text</para>
        /// <para> VR: ST VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationTextRetired = 1074266379;
        /// <summary>
        /// <para>(4008,010C) Interpretation Author</para>
        /// <para> VR: PN VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationAuthorRetired = 1074266380;
        /// <summary>
        /// <para>(4008,0111) Interpretation Approver Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationApproverSequenceRetired = 1074266385;
        /// <summary>
        /// <para>(4008,0112) Interpretation Approval Date</para>
        /// <para> VR: DA VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationApprovalDateRetired = 1074266386;
        /// <summary>
        /// <para>(4008,0113) Interpretation Approval Time</para>
        /// <para> VR: TM VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationApprovalTimeRetired = 1074266387;
        /// <summary>
        /// <para>(4008,0114) Physician Approving Interpretation</para>
        /// <para> VR: PN VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint PhysicianApprovingInterpretationRetired = 1074266388;
        /// <summary>
        /// <para>(4008,0115) Interpretation Diagnosis Description</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationDiagnosisDescriptionRetired = 1074266389;
        /// <summary>
        /// <para>(4008,0117) Interpretation Diagnosis Code Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationDiagnosisCodeSequenceRetired = 1074266391;
        /// <summary>
        /// <para>(4008,0118) Results Distribution List Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ResultsDistributionListSequenceRetired = 1074266392;
        /// <summary>
        /// <para>(4008,0119) Distribution Name</para>
        /// <para> VR: PN VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DistributionNameRetired = 1074266393;
        /// <summary>
        /// <para>(4008,011A) Distribution Address</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DistributionAddressRetired = 1074266394;
        /// <summary>
        /// <para>(4008,0200) Interpretation ID</para>
        /// <para> VR: SH VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationIDRetired = 1074266624;
        /// <summary>
        /// <para>(4008,0202) Interpretation ID Issuer</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationIDIssuerRetired = 1074266626;
        /// <summary>
        /// <para>(4008,0210) Interpretation Type ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationTypeIDRetired = 1074266640;
        /// <summary>
        /// <para>(4008,0212) Interpretation Status ID</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint InterpretationStatusIDRetired = 1074266642;
        /// <summary>
        /// <para>(4008,0300) Impressions</para>
        /// <para> VR: ST VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ImpressionsRetired = 1074266880;
        /// <summary>
        /// <para>(4008,4000) Results Comments</para>
        /// <para> VR: ST VM:1 </para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint ResultsCommentsRetired = 1074282496;
        /// <summary>
        /// <para>(4FFE,0001) MAC Parameters Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint MACParametersSequence = 1342046209;
        /// <summary>
        /// <para>(5000,0005) Curve Dimensions </para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveDimensionsRetired = 1342177285;
        /// <summary>
        /// <para>(5000,0010) Number of Points </para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NumberofPointsRetired = 1342177296;
        /// <summary>
        /// <para>(5000,0020) Type of Data</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TypeofDataRetired = 1342177312;
        /// <summary>
        /// <para>(5000,0022) Curve Description</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveDescriptionRetired = 1342177314;
        /// <summary>
        /// <para>(5000,0030) Axis Units </para>
        /// <para> VR: SH VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AxisUnitsRetired = 1342177328;
        /// <summary>
        /// <para>(5000,0040) Axis Labels </para>
        /// <para> VR: SH VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AxisLabelsRetired = 1342177344;
        /// <summary>
        /// <para>(5000,0103) Data Value Representation </para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint DataValueRepresentationRetired = 1342177539;
        /// <summary>
        /// <para>(5000,0104) Minimum Coordinate Value </para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MinimumCoordinateValueRetired = 1342177540;
        /// <summary>
        /// <para>(5000,0105) Maximum Coordinate Value </para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint MaximumCoordinateValueRetired = 1342177541;
        /// <summary>
        /// <para>(5000,0106) Curve Range</para>
        /// <para> VR: SH VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveRangeRetired = 1342177542;
        /// <summary>
        /// <para>(5000,0110) Curve Data Descriptor</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveDataDescriptorRetired = 1342177552;
        /// <summary>
        /// <para>(5000,0112) Coordinate Start Value</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CoordinateStartValueRetired = 1342177554;
        /// <summary>
        /// <para>(5000,0114) Coordinate Step Value</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CoordinateStepValueRetired = 1342177556;
        /// <summary>
        /// <para>(5000,1001) Curve Activation Layer </para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveActivationLayerRetired = 1342181377;
        /// <summary>
        /// <para>(5000,2000) Audio Type</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AudioTypeRetired = 1342185472;
        /// <summary>
        /// <para>(5000,2002) Audio Sample Format</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AudioSampleFormatRetired = 1342185474;
        /// <summary>
        /// <para>(5000,2004) Number of Channels</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NumberofChannelsRetired = 1342185476;
        /// <summary>
        /// <para>(5000,2006) Number of Samples</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint NumberofSamplesRetired = 1342185478;
        /// <summary>
        /// <para>(5000,2008) Sample Rate</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint SampleRateRetired = 1342185480;
        /// <summary>
        /// <para>(5000,200A) Total Time</para>
        /// <para> VR: UL VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint TotalTimeRetired = 1342185482;
        /// <summary>
        /// <para>(5000,200C) Audio Sample Data</para>
        /// <para> VR: OW or OB VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AudioSampleDataRetired = 1342185484;
        /// <summary>
        /// <para>(5000,200E) Audio Comments</para>
        /// <para> VR: LT VM:1 </para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint AudioCommentsRetired = 1342185486;
        /// <summary>
        /// <para>(5000,2500) Curve Label</para>
        /// <para> VR: LO VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveLabelRetired = 1342186752;
        /// <summary>
        /// <para>(5000,2600) Curve Referenced Overlay Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveReferencedOverlaySequenceRetired = 1342187008;
        /// <summary>
        /// <para>(5000,2610) Curve Referenced Overlay Group</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveReferencedOverlayGroupRetired = 1342187024;
        /// <summary>
        /// <para>(5000,3000) Curve Data</para>
        /// <para> VR: OW or OB VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint CurveDataRetired = 1342189568;
        /// <summary>
        /// <para>(5200,9229) Shared Functional Groups Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint SharedFunctionalGroupsSequence = 1375769129;
        /// <summary>
        /// <para>(5200,9230) Per-frame Functional Groups Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint PerframeFunctionalGroupsSequence = 1375769136;
        /// <summary>
        /// <para>(5400,0100) Waveform Sequence </para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint WaveformSequence = 1409286400;
        /// <summary>
        /// <para>(5400,0110) Channel Minimum Value </para>
        /// <para> VR: OB or OW VM:1</para>
        /// </summary>
        public const uint ChannelMinimumValue = 1409286416;
        /// <summary>
        /// <para>(5400,0112) Channel Maximum Value </para>
        /// <para> VR: OB or OW VM:1</para>
        /// </summary>
        public const uint ChannelMaximumValue = 1409286418;
        /// <summary>
        /// <para>(5400,1004) Waveform Bits Allocated</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint WaveformBitsAllocated = 1409290244;
        /// <summary>
        /// <para>(5400,1006) Waveform Sample Interpretation</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint WaveformSampleInterpretation = 1409290246;
        /// <summary>
        /// <para>(5400,100A) Waveform Padding Value</para>
        /// <para> VR: OB or OW VM:1</para>
        /// </summary>
        public const uint WaveformPaddingValue = 1409290250;
        /// <summary>
        /// <para>(5400,1010) Waveform Data </para>
        /// <para> VR: OB or OW VM:1</para>
        /// </summary>
        public const uint WaveformData = 1409290256;
        /// <summary>
        /// <para>(5600,0010) First Order Phase Correction Angle</para>
        /// <para> VR: OF VM:1</para>
        /// </summary>
        public const uint FirstOrderPhaseCorrectionAngle = 1442840592;
        /// <summary>
        /// <para>(5600,0020) Spectroscopy Data</para>
        /// <para> VR: OF VM:1</para>
        /// </summary>
        public const uint SpectroscopyData = 1442840608;
        /// <summary>
        /// <para>(6000,0010) Overlay Rows</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayRows = 1610612752;
        /// <summary>
        /// <para>(6000,0011) Overlay Columns</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayColumns = 1610612753;
        /// <summary>
        /// <para>(6000,0012) Overlay Planes</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayPlanes = 1610612754;
        /// <summary>
        /// <para>(6000,0015) Number of Frames in Overlay</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint NumberofFramesinOverlay = 1610612757;
        /// <summary>
        /// <para>(6000,0022) Overlay Description</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint OverlayDescription = 1610612770;
        /// <summary>
        /// <para>(6000,0040) Overlay Type</para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OverlayType = 1610612800;
        /// <summary>
        /// <para>(6000,0045) Overlay Subtype</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint OverlaySubtype = 1610612805;
        /// <summary>
        /// <para>(6000,0050) Overlay Origin</para>
        /// <para> VR: SS VM:2</para>
        /// </summary>
        public const uint OverlayOrigin = 1610612816;
        /// <summary>
        /// <para>(6000,0051) Image Frame Origin</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint ImageFrameOrigin = 1610612817;
        /// <summary>
        /// <para>(6000,0052) Overlay Plane Origin</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayPlaneOrigin = 1610612818;
        /// <summary>
        /// <para>(6000,0060) Overlay Compression Code</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayCompressionCodeRetired = 1610612832;
        /// <summary>
        /// <para>(6000,0100) Overlay Bits Allocated</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayBitsAllocated = 1610612992;
        /// <summary>
        /// <para>(6000,0102) Overlay Bit Position</para>
        /// <para> VR: US VM:1</para>
        /// </summary>
        public const uint OverlayBitPosition = 1610612994;
        /// <summary>
        /// <para>(6000,0110) Overlay Format</para>
        /// <para> VR: CS VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayFormatRetired = 1610613008;
        /// <summary>
        /// <para>(6000,0200) Overlay Location</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayLocationRetired = 1610613248;
        /// <summary>
        /// <para>(6000,1001) Overlay Activation Layer </para>
        /// <para> VR: CS VM:1</para>
        /// </summary>
        public const uint OverlayActivationLayer = 1610616833;
        /// <summary>
        /// <para>(6000,1100) Overlay Descriptor – Gray</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayDescriptorGrayRetired = 1610617088;
        /// <summary>
        /// <para>(6000,1101) Overlay Descriptor – Red</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayDescriptorRedRetired = 1610617089;
        /// <summary>
        /// <para>(6000,1102) Overlay Descriptor – Green</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayDescriptorGreenRetired = 1610617090;
        /// <summary>
        /// <para>(6000,1103) Overlay Descriptor – Blue</para>
        /// <para> VR: US VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayDescriptorBlueRetired = 1610617091;
        /// <summary>
        /// <para>(6000,1200) Overlays- Gray</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlaysGrayRetired = 1610617344;
        /// <summary>
        /// <para>(6000,1201) Overlays – Red</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlaysRedRetired = 1610617345;
        /// <summary>
        /// <para>(6000,1202) Overlays – Green</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlaysGreenRetired = 1610617346;
        /// <summary>
        /// <para>(6000,1203) Overlays- Blue</para>
        /// <para> VR: US VM:1-n</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlaysBlueRetired = 1610617347;
        /// <summary>
        /// <para>(6000,1301) ROI Area</para>
        /// <para> VR: IS VM:1</para>
        /// </summary>
        public const uint ROIArea = 1610617601;
        /// <summary>
        /// <para>(6000,1302) ROI Mean</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ROIMean = 1610617602;
        /// <summary>
        /// <para>(6000,1303) ROI Standard Deviation</para>
        /// <para> VR: DS VM:1</para>
        /// </summary>
        public const uint ROIStandardDeviation = 1610617603;
        /// <summary>
        /// <para>(6000,1500) Overlay Label</para>
        /// <para> VR: LO VM:1</para>
        /// </summary>
        public const uint OverlayLabel = 1610618112;
        /// <summary>
        /// <para>(6000,3000) Overlay Data</para>
        /// <para> VR: OB or OW VM:1</para>
        /// </summary>
        public const uint OverlayData = 1610625024;
        /// <summary>
        /// <para>(6000,4000) Overlay Comments</para>
        /// <para> VR: LT VM:1</para>
        /// <para>This tag has been retired.</para>
        /// </summary>
        public const uint OverlayCommentsRetired = 1610629120;
        /// <summary>
        /// <para>(7FE0,0010) Pixel Data</para>
        /// <para> VR: OW or OB VM:1</para>
        /// </summary>
        public const uint PixelData = 2145386512;
        /// <summary>
        /// <para>(FFFA,FFFA) Digital Signatures Sequence</para>
        /// <para> VR: SQ VM:1</para>
        /// </summary>
        public const uint DigitalSignaturesSequence = 4294639610;
        /// <summary>
        /// <para>(FFFC,FFFC) Data Set Trailing Padding</para>
        /// <para> VR: OB VM:1</para>
        /// </summary>
        public const uint DataSetTrailingPadding = 4294770684;
    }
}
