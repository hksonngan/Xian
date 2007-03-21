using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom.OffisWrapper;
using ClearCanvas.Dicom;
using MySR = ClearCanvas.Dicom.SR;
using System.IO;

namespace ClearCanvas.Dicom.Network
{
    /// <summary>
    /// Main entry point for DICOM networking functionality. Allows the client to 
    /// perform C-ECHO, C-FIND and C-MOVE commands. Both C-FIND and C-MOVE 
    /// implement the Study Root Query/Retrieve Information Model.
    /// </summary>
    public partial class DicomClient : IDisposable
    {
        /// <summary>
        /// Fires when a new SOP Instance has arrived and has been successfully
        /// written to the local filesystem.
        /// </summary>
        private event EventHandler<SopInstanceReceivedEventArgs> _sopInstanceReceivedEvent;
        /// <summary>
        /// Fires when a C-FIND result is received.
        /// </summary>
        private event EventHandler<QueryResultReceivedEventArgs> _queryResultReceivedEvent;
        /// <summary>
        /// Fires when the C-FIND query has completed and all results received.
        /// </summary>
        private event EventHandler<QueryCompletedEventArgs> _queryCompletedEvent;
        // TODO:
        /// <summary>
        /// This event is not yet implemented.
        /// </summary>
        private event EventHandler<SendProgressUpdatedEventArgs> _sendProgressUpdatedEvent;
        /// <summary>
        /// This event is not yet implemented.
        /// </summary>
        private event EventHandler<SeriesCompletedEventArgs> _seriesCompletedEvent;
        /// <summary>
        /// This event is not yet implemented.
        /// </summary>
        private event EventHandler<StudyCompletedEventArgs> _studyCompletedEvent;

        /// <summary>
        /// 
        /// </summary>
        private event EventHandler<RetrieveProgressUpdatedEventArgs> _retrieveProgressUpdatedEvent;

        /// <summary>
        /// Event accessor.
        /// </summary>
        public event EventHandler<SopInstanceReceivedEventArgs> SopInstanceReceived
        {
            add { _sopInstanceReceivedEvent += value; }
            remove { _sopInstanceReceivedEvent -= value; }
        }

        /// <summary>
        /// Event accessor.
        /// </summary>
        public event EventHandler<QueryResultReceivedEventArgs> QueryResultReceived
        {
            add { _queryResultReceivedEvent += value; }
            remove { _queryResultReceivedEvent -= value; }
        }

        /// <summary>
        /// Event accessor.
        /// </summary>
        public event EventHandler<QueryCompletedEventArgs> QueryCompleted
        {
            add { _queryCompletedEvent += value; }
            remove { _queryCompletedEvent -= value; }
        }

        public event EventHandler<SendProgressUpdatedEventArgs> SendProgressUpdated
        {
            add { _sendProgressUpdatedEvent += value; }
            remove { _sendProgressUpdatedEvent -= value; }
        }

        public event EventHandler<RetrieveProgressUpdatedEventArgs> RetrieveProgressUpdated
        {
            add { _retrieveProgressUpdatedEvent += value; }
            remove { _retrieveProgressUpdatedEvent -= value; }
        }

        /// <summary>
        /// Mandatory constructor.
        /// </summary>
        /// <param name="ownAEParameters">The AE parameters of the DICOM client. That is,
        /// the user's AE parameters that will be passed to the server as the source
        /// of the DICOM commands, and will also become the destination for the receiving
        /// of DICOM data.</param>
        public DicomClient(ApplicationEntity ownAEParameters)
        {
            SocketManager.InitializeSockets();

            _myOwnAE = ownAEParameters;

            // TODO:
            // since we want the QueryCallbackHelper object to be able to 
            // modifier data that is instance-related in nature, i.e. 
            // query results, we need to make the callback install itself
            // when this instance is created. This is not thread-safe
            _queryCallbackHelper = new QueryCallbackHelper(this);

            //// same goes for the store callback helper
            // TODO: disable this, because it's competing for Callback with the DicomServer
            //_storeCallbackHelper = new StoreCallbackHelper(this);

            // same goes for the store scu callback helper
			//_storeScuCallbackHelper = new StoreScuCallbackHelper(this);

            // same goes for the retrieve callback helper
			//_retrieveCallbackHelper = new RetrieveCallbackHelper(this);

            _queryResults = new QueryResultList();

            SetGlobalConnectionTimeout(20);    // global timeout is 2 minutes
            SetReverseDnsLookupFlag(false);     // don't do reverse DNS lookup
        }

        /// <summary>
        /// Set the overall connection timeout period in the underlying OFFIS DICOM
        /// library.
        /// </summary>
        /// <param name="timeout">Timeout period in seconds. Default is 120 seconds.</param>
        protected static void SetGlobalConnectionTimeout(int timeout)
        {
            OffisDcm.SetGlobalConnectionTimeout(timeout);
        }

        /// <summary>
        /// Enables or disables the use of reverse DNS lookups for
        /// completing DICOM associations. 
        /// </summary>
        /// <param name="enable">True - turn on, False - turn off. Default is False.</param>
        public static void SetReverseDnsLookupFlag(Boolean enable)
        {
            OffisDcm.SetReverseDnsLookupFlag(enable);
        }

        /// <summary>
        /// Verifies that a remote AE has an operational DICOM implementation using
        /// C-ECHO. Note that a successful verify does not necessarily mean that
        /// the remote AE will be able to perform any particular service, since 
        /// the implementation at this time verifies support for the Verification
        /// Service Class only.
        /// </summary>
        /// <param name="serverAE">The AE parameters of the remote AE server.</param>
        /// <returns></returns>
        public bool Verify(ApplicationEntity serverAE)
        {
            try
            {
                // set appropriate timeouts
                SetGlobalConnectionTimeout(serverAE.ConnectionTimeout);

                T_ASC_Network network = new T_ASC_Network(T_ASC_NetworkRole.NET_REQUESTOR, _myOwnAE.Port, serverAE.OperationTimeout);

                using (network)
                {
                    T_ASC_Parameters associationParameters = new T_ASC_Parameters(_defaultPDUSize, _myOwnAE.AE, serverAE.AE, serverAE.Host, serverAE.Port);

                    using (associationParameters)
                    {
                        associationParameters.ConfigureForVerification();

                        T_ASC_Association association = network.CreateAssociation(associationParameters);

                        using (association)
                        {
                            if (association.SendCEcho(_cEchoRepeats, serverAE.OperationTimeout))
                            {
                                association.Release();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (DicomRuntimeApplicationException e)
            {
                OFCondition condition = e.Condition;
                if (DicomHelper.CompareConditions(condition, OffisDcm.DUL_REQUESTASSOCIATIONFAILED))
                    return false;
                else
                    throw new NetworkDicomException(OffisConditionParser.GetTextString(serverAE, e), e);
            }
        }

        /// <summary>
        /// This variation on the function takes Patient ID and Patient's Name. This query takes 
        /// place at the STUDY level and the the following tags are used as the key:
        /// Query Retrieve Level, Study Date, Study Time, Accession Number, Patient's Name,
        /// Patient ID, Study Instance UID, Modalities In Study, Study Description,
        /// Specific Character Set, Patient's Birth Date, Number Of Study Related Series,
        /// and Number Of Study Related Instances.
        /// </summary>
        /// <overloads>There are currently seven overloads of this function. Query the 
        /// remote AE to determine what studies the server contains using a C-FIND. This 
        /// implementation uses the Study Root Query/Retrieve Information Model.
        /// <example>
        /// <code>
        ///ApplicationEntity myOwnAEParameters = new ApplicationEntity(new HostName("localhost"),
        ///    new AETitle("CCNETTEST"), new ListeningPort(110));
        ///ApplicationEntity serverAE = new ApplicationEntity(new HostName("192.168.0.100"),
        ///    new AETitle("CONQUESTSRV1"), new ListeningPort(5678));
        ///
        ///DicomClient dicomClient = new DicomClient(myOwnAEParameters);
        ///
        ///if (!dicomClient.Verify(serverAE))
        ///    throw new Exception("Target server is not running");
        ///
        ///ReadOnlyQueryResultCollection results = dicomClient.Query(serverAE, new PatientId(""), new PatientsName(""));
        ///
        ///Assert.IsTrue(results.Count > 0);
        ///
        ///foreach (QueryResult qr in results)
        ///{   
        ///    foreach (DicomTag dicomTag in qr.DicomTags)
        ///    {
        ///        Console.WriteLine("{0} - {1}", dicomTag.ToString(), qr[dicomTag]);
        ///    }
        ///
        ///    Console.WriteLine("Patient's Name: {0}", qr.PatientsName);
        ///    Console.WriteLine("Patien ID: {0}", qr.PatientId);
        ///}
        /// </code>
        /// </example>
        /// </overloads>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientId">Key for searching: the relevant Patient ID.</param>
        /// <param name="patientsName">Key for searching: the relevant Patient's Name.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PatientId patientId, PersonName patientsName)
        {
            ReadOnlyQueryResultCollection results = Query(serverAE, patientId, patientsName, new Accession(""));
            return results;
        }

        /// <summary>
        /// This variation on the function takes Patient ID.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientId">Key for searching: the relevant Patient ID.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PatientId patientId)
        {
            ReadOnlyQueryResultCollection results = Query(serverAE, patientId, new PersonName(""));
            return results;
        }

        /// <summary>
        /// This variation on the function takes Patient's Name.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientsName">Key for searching: the relevant Patient's Name.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PersonName patientsName)
        {
            ReadOnlyQueryResultCollection results = Query(serverAE, new PatientId(""), patientsName);
            return results;
        }

        /// <summary>
        /// Overload of the Query method that accepts a Study Instance UID.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="studyInstanceUid">Key for searching: the relevant study's Study Instance UID.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, Uid studyInstanceUid)
        {
            DcmDataset cFindDataset = new DcmDataset();
            InitializeStandardCFindDataset(ref cFindDataset, QRLevel.Study);

            // set the specific query for study instance uid
            cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), studyInstanceUid.ToString());

            ReadOnlyQueryResultCollection results = Query(serverAE, cFindDataset);

            GC.KeepAlive(cFindDataset);
            return results;
        }

        /// <summary>
        /// Overload of the Query method that accepts Patient ID and Accession Number.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientId">Key for searching: The relevant Patient ID.</param>
        /// <param name="accession">Key for searching: The relevant Accession Number.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PatientId patientId, Accession accession)
        {
            ReadOnlyQueryResultCollection results = Query(serverAE, patientId, new PersonName(""), accession);
            return results;
        }

        /// <summary>
        /// Overload of the Query method that accepts Patient's Name and Accession Number.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientsName">Key for searching: The relevant Patient's Name.</param>
        /// <param name="accession">Key for searching: The relevant Accession Number.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PersonName patientsName, Accession accession)
        {
            ReadOnlyQueryResultCollection results = Query(serverAE, new PatientId(""), patientsName, accession);
            return results;
        }

        /// <summary>
        /// This is currently the most generalized version of Query that other versions will call.
        /// Overload of the Query method that accepts Patient ID, Patient's Name and Accession Number.
        /// </summary>
        /// <param name="serverAE">AE parameters of the remote AE server.</param>
        /// <param name="patientId">Key for searching: The relevant Patient ID.</param>
        /// <param name="patientsName">Key for searching: The relevant Patient's Name.</param>
        /// <param name="accession">Key for searching: The relevant Accession Number.</param>
        /// <returns>A read-only version of the <see cref="QueryResultCollection">QueryResultCollection</see>.
        /// Each C-FIND result is represented by one item in the collection, and it is possible to 
        /// enumerate over all the items.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, PatientId patientId, PersonName patientsName, Accession accession)
        {
            DcmDataset cFindDataset = new DcmDataset();
            InitializeStandardCFindDataset(ref cFindDataset, QRLevel.Study);

            // set the specific query keys
            cFindDataset.putAndInsertString(new DcmTag(Dcm.PatientId), patientId.ToString());
            cFindDataset.putAndInsertString(new DcmTag(Dcm.PatientsName), patientsName.ToString());
            cFindDataset.putAndInsertString(new DcmTag(Dcm.AccessionNumber), accession.ToString());

            ReadOnlyQueryResultCollection results = Query(serverAE, cFindDataset);
            TriggerQueryCompletedEvent(results);

            GC.KeepAlive(cFindDataset);
            return results;
        }

        /// <summary>
        /// The general overload for the Query method that allows an almost arbitary list of
        /// tags to be queried for. 
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="key">The set of query keys.</param>
        /// <returns>A collection of studies from the server that satisifes the query key.</returns>
        public ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, QueryKey key)
        {
            DcmDataset cFindDataset = new DcmDataset();
            InitializeStandardCFindDataset(ref cFindDataset, QRLevel.Study);

            // set the specific query keys
            foreach (DicomTag tag in key.DicomTags)
            {
                cFindDataset.putAndInsertString(new DcmTag(tag.Group, tag.Element), key[tag]);
            }
 
            ReadOnlyQueryResultCollection results = Query(serverAE, cFindDataset);
            TriggerQueryCompletedEvent(results);

            GC.KeepAlive(cFindDataset);
            return results;
        }

        /// <summary>
        /// Query for the series that belong to a particular Study. The following tags
        /// are part of the query key at the SERIES level: Query Retrieve Level, 
        /// Modality, Series Instance Uid, Series Description, Series Number and
        /// Number Of Series Related Instances.
        /// </summary>
        /// <param name="serverAE">Server's AE parameters.</param>
        /// <param name="studyInstanceUid">Study Instance UID of the study that 
        /// the user wants to query the series for.</param>
        /// <returns>A read-only collection of query results. Successful results
        /// includes the Study UID, the Series UID, the Series Description and
        /// the Series Number.</returns>
        public ReadOnlyQueryResultCollection QuerySeries(ApplicationEntity serverAE, Uid studyInstanceUid)
        {
            DcmDataset cFindDataset = new DcmDataset();
            InitializeStandardCFindDataset(ref cFindDataset, QRLevel.Series);

            // set the specific query keys
            cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), studyInstanceUid.ToString());

            ReadOnlyQueryResultCollection results = Query(serverAE, cFindDataset);
            TriggerQueryCompletedEvent(results);

            GC.KeepAlive(cFindDataset);
            return results;
        }

        /// <summary>
        /// Perform a query at the Composite Object Instance ("IMAGE") level. Can be used to determine
        /// the number of Sop Instances that are in a given Study, if the server does not support querying
        /// for the Number Of Study Related Instances tag. The following tags are part of this query: SOP Class UID
        /// and SOP Instance UID.
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="studyInstanceUid">The relevant Study's Study Instance Uid.</param>
        /// <returns>A read-only collection of query results that will include the SOP Class UID and
        /// SOP Instance UID. Use the Count property to determine the number of results returned.</returns>
        public ReadOnlyQueryResultCollection QuerySopInstance(ApplicationEntity serverAE, Uid studyInstanceUid)
        {
            DcmDataset cFindDataset = new DcmDataset();
            InitializeStandardCFindDataset(ref cFindDataset, QRLevel.CompositeObjectInstance);

            // set the specific query keys
            cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), studyInstanceUid.ToString());

            ReadOnlyQueryResultCollection results = Query(serverAE, cFindDataset);
            TriggerQueryCompletedEvent(results);

            GC.KeepAlive(cFindDataset);
            return results;
        }

        /// <summary>
        /// Performs a DICOM retrieve using C-MOVE with the Study Root Query/Retrieve Information Model.
        /// A DICOM listener will automatically be created to receive the incoming DICOM data. The listener's
        /// AE parameters are defined by the ApplicationEntity used in the construction of the 
        /// <see cref="DicomClient">DicomClient</see>.
        /// </summary>
        /// <param name="serverAE">AE parameters of the server who will provided the C-MOVE service.</param>
        /// <param name="studyInstanceUid">Study Instance UID of the study to be retrieved.</param>
        /// <param name="saveDirectory">A path to a directory on the local filesystem that will receive
        /// the incoming DICOM data objects.</param>
        /// <example>
        /// <code>
        /// ApplicationEntity myOwnAEParameters = new ApplicationEntity(new HostName("localhost"),
        ///     new AETitle("CCNETTEST"), new ListeningPort(4000));
        /// ApplicationEntity serverAE = new ApplicationEntity(new HostName("localhost"),
        ///     new AETitle("CONQUESTSRV1"), new ListeningPort(5678));
        ///
        /// DicomClient dicomClient = new DicomClient(myOwnAEParameters);
        ///
        /// if (!dicomClient.Verify(serverAE))
        ///     throw new Exception("Target server is not running");
        ///
        /// dicomClient.SopInstanceReceivedEvent += SopInstanceReceivedEventHandler;
        /// dicomClient.Retrieve(serverAE, new Uid("1.3.46.670589.5.2.10.2156913941.892665384.993397"), "C:\\temp\\");
        /// dicomClient.SopInstanceReceivedEvent -= SopInstanceReceivedEventHandler;
        /// </code>
        /// </example>
        public void Retrieve(ApplicationEntity serverAE, Uid studyInstanceUid, System.String saveDirectory)
        {
            string normalizedSaveDirectory = DicomHelper.NormalizeDirectory(saveDirectory);

            DcmDataset cMoveDataset = new DcmDataset();

            // set the specific query for study instance uid
            InitializeStandardCMoveDataset(ref cMoveDataset, QRLevel.Study);
            cMoveDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), studyInstanceUid.ToString());

            Retrieve(serverAE, cMoveDataset, normalizedSaveDirectory.ToString());

            // fire event to indicate successful retrieval
            return;
        }
        
        /// <summary>
        /// Retrieves a series from the server.
        /// </summary>
        /// <param name="serverAE">Server's AE parameters.</param>
        /// <param name="seriesInstanceUid">The Series Instance UID of the series that the
        /// user wants to retrieve.</param>
        /// <param name="saveDirectory">The path to where the incoming images are stored.</param>
        public void RetrieveSeries(ApplicationEntity serverAE, Uid seriesInstanceUid, System.String saveDirectory)
        {
            string normalizedSaveDirectory = DicomHelper.NormalizeDirectory(saveDirectory);

            DcmDataset cMoveDataset = new DcmDataset();

            // set the specific query for study instance uid
            InitializeStandardCMoveDataset(ref cMoveDataset, QRLevel.Series);
            cMoveDataset.putAndInsertString(new DcmTag(Dcm.SeriesInstanceUID), seriesInstanceUid.ToString());

            Retrieve(serverAE, cMoveDataset, normalizedSaveDirectory.ToString());

            // fire event to indicate successful retrieval
            return;
        }

        /// <summary>
        /// Performs a C-STORE, i.e. send, an object to a target AE.
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="directory">The folder/directory from which the objects to be sent will be obtained.</param>
        /// <param name="recursivelyDescend">Whether the search for objects from the 'directory' location will 
        /// descend recursively or not.</param>
        public void Store(ApplicationEntity serverAE, String directory, Boolean recursivelyDescend)
        {
            String normalizedDirectory = DicomHelper.NormalizeDirectory(directory);

            string[] fileList = Directory.GetFiles(directory,
                "*",
                recursivelyDescend ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            Store(serverAE, fileList);
        }

        /// <summary>
        /// Overload of the Store function, that allows you to specify a list of files to send,
        /// rather than specifying a root location. The SOP Classes of the files will be 
        /// determined automatically by parsing the headers of all the files.
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="files">The list of files in any collection that implements the
        /// IEnumerable interface.</param>
        public void Store(ApplicationEntity serverAE, IEnumerable<String> files)
        {
            string[] sopClassUids = { };
            Store(serverAE, files, sopClassUids);
        }

        /// <summary>
        /// Overload of the Store function, that allows you to specify a list of files to send,
        /// rather than specifying a root location. The SOP Classes of the files is also provided.
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="files">The list of files in any collection that implements the
        /// IEnumerable interface.</param>
        /// <param name="sopClassUids">The list of SOP Classes in any collection that implements
        /// the IEnumerable interface. The list should be normalized to maximize efficiency, i.e.
        /// there should be no duplicate entries.</param>
        public void Store(ApplicationEntity serverAE, IEnumerable<String> files, IEnumerable<String> sopClassUids)
        {
            string[] transferSyntaxUids = { };
            Store(serverAE, files, sopClassUids, transferSyntaxUids);
        }

        /// <summary>
        /// Overload of the Store function, that allows you to specify a list of files to send,
        /// rather than specifying a root location. The SOP Classes of the files is also provided, along
        /// with the Transfer Syntaxes of the stored objects. This is the most efficient version of the 
        /// method as it avoids parsing of every file's DICOM header.
        /// </summary>
        /// <param name="serverAE">The target AE.</param>
        /// <param name="files">The list of files in any collection that implements the
        /// IEnumerable interface.</param>
        /// <param name="sopClassUids">The list of SOP Classes in any collection that implements
        /// the IEnumerable interface. The list should be normalized to maximize efficiency, i.e.
        /// there should be no duplicate entries.</param>
        /// <param name="transferSyntaxUids">The list of Transfer Syntaxes in any collection that implements
        /// the IEnumerable interface. The list should be normalized to maximize efficiency, i.e.
        /// there should be no duplicate entries.</param>
        public void Store(ApplicationEntity serverAE, IEnumerable<String> files, IEnumerable<String> sopClassUids, IEnumerable<String> transferSyntaxUids)
        {
            // TODO:
            if (null == files)
            {
                throw new System.ArgumentNullException("files cannot be null");
            }

            try
            {
                SetGlobalConnectionTimeout(serverAE.ConnectionTimeout);
                T_ASC_Network network = new T_ASC_Network(T_ASC_NetworkRole.NET_REQUESTOR, _myOwnAE.Port, serverAE.OperationTimeout);

                using (network)
                {
                    T_ASC_Parameters associationParameters = new T_ASC_Parameters(_defaultPDUSize, _myOwnAE.AE, serverAE.AE, serverAE.Host, serverAE.Port);

                    using (associationParameters)
                    {
                        #region Interop-specific code
                        // copy over file list
                        OFStringVector interopFilenameList = new OFStringVector();
                        foreach (String filename in files)
                        {
                            interopFilenameList.Add(filename);
                        }

                        // copy over sop class list
                        OFStringVector interopSopClassUid = new OFStringVector();
                        foreach (String sopClass in sopClassUids)
                        {
                            interopSopClassUid.Add(sopClass);
                        }

                        // copy over syntax list
                        OFStringVector interopTransferSyntaxUid = new OFStringVector();
                        foreach (String syntax in transferSyntaxUids)
                        {
                            interopTransferSyntaxUid.Add(syntax);
                        }
                        #endregion

                        associationParameters.ConfigureForCStore(interopFilenameList, interopSopClassUid, interopTransferSyntaxUid);

                        T_ASC_Association association = network.CreateAssociation(associationParameters);

                        using (association)
                        {
                            if (association.SendCStore(interopFilenameList))
                                association.Release();

                            return;
                        }
                    }
                }
            }
            catch (DicomRuntimeApplicationException e)
            {
                throw new NetworkDicomException(OffisConditionParser.GetTextString(serverAE, e), e);
            }
        }

        #region Protected members

        /// <summary>
        /// Specifies the query level to be executed on a C-FIND (<see cref="Query">Query</see>) or C-MOVE
        /// (<see cref="Retrieve">Retrieve</see>) commands.
        /// </summary>
        protected enum QRLevel
        {
            /// <summary>
            /// Query at the Patient level, will return for example Patient's Name, Patient's Birthdate,
            /// one result per patient that matches search keys.
            /// </summary>
            Patient,
            /// <summary>
            /// Query at the Study level, will return for example, Study Date, Study Description, 
            /// one result per study that matches search keys.
            /// </summary>
            Study,
            /// <summary>
            /// Query at the Series level, will return for example, Modality, Series Description,
            /// one result per series that matches search keys.
            /// </summary>
            Series,
            /// <summary>
            /// Query at the Composite Object Instance level, will return for example Bits Allocated, 
            /// Planar Configuration, one result per SOP Instance that matches search keys.
            /// </summary>
            CompositeObjectInstance
        }

        /// <summary>
        /// The low-level version of Retrieve that just takes in a dataset that has already been
        /// properly initialized with the appropriate tags for the C-MOVE command.
        /// </summary>
        /// <param name="serverAE">The application entity that will serve our Retrieve request.</param>
        /// <param name="cMoveDataset">The dataset containing the parameters for this Retrieve.</param>
        /// <param name="saveDirectory">The path on the local filesystem that will store the
        /// DICOM objects that are received.</param>
        protected void Retrieve(ApplicationEntity serverAE, DcmDataset cMoveDataset, System.String saveDirectory)
        {
            try
            {
                SetGlobalConnectionTimeout(serverAE.ConnectionTimeout);
                T_ASC_Network network = new T_ASC_Network(T_ASC_NetworkRole.NET_ACCEPTORREQUESTOR, _myOwnAE.Port, serverAE.OperationTimeout);

                using (network)
                {
                    T_ASC_Parameters associationParameters = new T_ASC_Parameters(_defaultPDUSize, _myOwnAE.AE, serverAE.AE, serverAE.Host, serverAE.Port);

                    using (associationParameters)
                    {
                        associationParameters.ConfigureForCMoveStudyRootQuery();

                        T_ASC_Association association = network.CreateAssociation(associationParameters);

                        using (association)
                        {
                            if (association.SendCMoveStudyRootQuery(cMoveDataset, network, serverAE.OperationTimeout, saveDirectory))
                                association.Release();
                        }
                    }
                }

                return;
            }
            catch (DicomRuntimeApplicationException e)
            {
                throw new NetworkDicomException(OffisConditionParser.GetTextString(serverAE, e), e);
            }
        }

        /// <summary>
        /// The low-level version of Query that just takes in a dataset that has been properly 
        /// initialized and set to use tags that are appropriate for the C-FIND command.
        /// </summary>
        /// <param name="serverAE">The application entity that will serve our Query request.</param>
        /// <param name="cFindDataset">The dataset containing the parameters for this Query.</param>
        /// <returns>A read-only collection of matching results from the server in response to our Query.</returns>
        protected ReadOnlyQueryResultCollection Query(ApplicationEntity serverAE, DcmDataset cFindDataset)
        {
            InitializeQueryState();

            try
            {
                SetGlobalConnectionTimeout(serverAE.ConnectionTimeout);
                T_ASC_Network network = new T_ASC_Network(T_ASC_NetworkRole.NET_REQUESTOR, _myOwnAE.Port, serverAE.OperationTimeout);

                using (network)
                {
                    T_ASC_Parameters associationParameters = new T_ASC_Parameters(_defaultPDUSize, _myOwnAE.AE, serverAE.AE, serverAE.Host, serverAE.Port);

                    using (associationParameters)
                    {
                        associationParameters.ConfigureForStudyRootQuery();

                        T_ASC_Association association = network.CreateAssociation(associationParameters);

                        using (association)
                        {
                            if (association.SendCFindStudyRootQuery(cFindDataset))
                            {
                                association.Release();
                                return new ReadOnlyQueryResultCollection(_queryResults);
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (DicomRuntimeApplicationException e)
            {
                throw new NetworkDicomException(OffisConditionParser.GetTextString(serverAE, e), e);
            }
        }

        /// <summary>
        /// Initializes a dataset with the required tags to ensure the C-FIND will work.
        /// </summary>
        /// <param name="cFindDataset">Dataset to be filled with certain required tags</param>
        /// <param name="level">Query/Retrieve level</param>
        protected static void InitializeStandardCFindDataset(ref DcmDataset cFindDataset, QRLevel level)
        {
            if (null == cFindDataset)
                throw new System.ArgumentNullException("level", MySR.ExceptionDicomFindDatasetNull);
            switch (level)
            {
                case QRLevel.Patient:
                    throw new System.ArgumentOutOfRangeException("level", MySR.ExceptionDicomPatientLevelQueryInvalid);
               
                case QRLevel.Study:
                    // set the Query Retrieve Level
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "STUDY");

                    // set the other tags we want to retrieve
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyDate), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyTime), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.AccessionNumber), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.PatientsName), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.PatientId), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.ModalitiesInStudy), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.StudyDescription), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SpecificCharacterSet), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.PatientsBirthDate), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.NumberOfStudyRelatedSeries), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.NumberOfStudyRelatedInstances), "");
                    break;
                case QRLevel.Series:
                    // set the Query Retrieve Level
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "SERIES");

                    // set the other tags we want to retrieve
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.Modality), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SeriesInstanceUID), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SeriesDescription), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SeriesNumber), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.NumberOfSeriesRelatedInstances), "");
                    break;
                case QRLevel.CompositeObjectInstance:
                    // set the Query Retrieve Level
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "IMAGE");

                    // set the other tags we want to retrieve
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SOPClassUID), "");
                    cFindDataset.putAndInsertString(new DcmTag(Dcm.SOPInstanceUID), "");
                    break;
            }
        }
        
        /// <summary>
        /// Initializes a dataset with the required tags to ensure the C-MOVE will work.
        /// </summary>
        /// <param name="cMoveDataset">Dataset to be filled with certain required tags</param>
        /// <param name="level">Query/Retrieve level</param>
        protected static void InitializeStandardCMoveDataset(ref DcmDataset cMoveDataset, QRLevel level)
        {
            if (null == cMoveDataset)
                throw new System.ArgumentNullException("cMoveDataset", MySR.ExceptionDicomMoveDatasetNull);

            switch (level)
            {
                case QRLevel.Patient:
                    throw new System.ArgumentOutOfRangeException("level", MySR.ExceptionDicomPatientLevelQueryInvalid);
                    
                case QRLevel.Study:
                    // set the Query Retrieve Level
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "STUDY");
                    // set the other tags we want to retrieve
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.StudyInstanceUID), "");
                    break;
                case QRLevel.Series:
                    // set the Query Retrieve Level
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "SERIES");
                    // set the other tags we want to retrieve
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.SeriesInstanceUID), "");
                    break;
                case QRLevel.CompositeObjectInstance:
                    // set the Query Retrieve Level
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.QueryRetrieveLevel), "IMAGE");
                    // set the other tags we want to retrieve
                    cMoveDataset.putAndInsertString(new DcmTag(Dcm.SOPInstanceUID), "");
                    break;
            }
        }

        /// <summary>
        /// Instantiates a new list object, so that any old results will be left
        /// available (as long as it hasn't be GC'd).
        /// </summary>
        protected void InitializeQueryState()
        {
            _queryResults = new QueryResultList();
        }

        /// <summary>
        /// Invoke the event firing helper 
        /// </summary>
        /// <param name="results">Collection of query results or null if no results.
        /// were returned</param>
        protected void TriggerQueryCompletedEvent(ReadOnlyQueryResultCollection results)
        {
            QueryCompletedEventArgs args = new QueryCompletedEventArgs(results);
            OnQueryCompletedEvent(args);
        }
 
        protected void OnSopInstanceReceivedEvent(SopInstanceReceivedEventArgs e)
        {
            EventsHelper.Fire(_sopInstanceReceivedEvent, this, e);
        }

        protected void OnStudyCompletedEvent(StudyCompletedEventArgs e)
        {
            EventsHelper.Fire(_studyCompletedEvent, this, e);
        }

        protected void OnSeriesCompletedEvent(SeriesCompletedEventArgs e)
        {
            EventsHelper.Fire(_seriesCompletedEvent, this, e);
        }

        protected void OnQueryResultReceivedEvent(QueryResultReceivedEventArgs e)
        {
            EventsHelper.Fire(_queryResultReceivedEvent, this, e);
        }

        protected void OnQueryCompletedEvent(QueryCompletedEventArgs e)
        {
            EventsHelper.Fire(_queryCompletedEvent, this, e);
        }

        protected void OnSendProgressUpdatedEvent(SendProgressUpdatedEventArgs e)
        {
            EventsHelper.Fire(_sendProgressUpdatedEvent, this, e);
        }

        protected void OnRetrieveProgressUpdatedEvent(RetrieveProgressUpdatedEventArgs e)
        {
            EventsHelper.Fire(_retrieveProgressUpdatedEvent, this, e);
        }

        #endregion

        #region Private members
        
        private QueryCallbackHelper _queryCallbackHelper;
        //private StoreCallbackHelper _storeCallbackHelper;
        private StoreScuCallbackHelper _storeScuCallbackHelper;
        private RetrieveCallbackHelper _retrieveCallbackHelper;
        private QueryResultList _queryResults;
        private ApplicationEntity _myOwnAE;
        private int _defaultPDUSize = 16384;
        private int _cEchoRepeats = 7;

        private const ushort STATUS_Success = 0x0000;
        private const ushort STATUS_Pending = 0xff00;
        private const ushort STATUS_Warning = 0xb000;

        private static bool DICOM_PENDING_STATUS(ushort status) { return (((status)&STATUS_Pending) == 0xff00); }
        private static bool DICOM_WARNING_STATUS(ushort status) { return (((status)&STATUS_Warning) == 0xb000); }
        private static bool DICOM_SUCCESS_STATUS(ushort status) { return ( (status) == STATUS_Success ); }
        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            SocketManager.DeinitializeSockets();
            _queryCallbackHelper.Dispose();
            //_storeCallbackHelper.Dispose();
        }

        #endregion
    }
}
