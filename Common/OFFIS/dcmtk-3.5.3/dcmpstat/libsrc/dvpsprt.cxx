/*
 *
 *  Copyright (C) 2000-2004, OFFIS
 *
 *  This software and supporting documentation were developed by
 *
 *    Kuratorium OFFIS e.V.
 *    Healthcare Information and Communication Systems
 *    Escherweg 2
 *    D-26121 Oldenburg, Germany
 *
 *  THIS SOFTWARE IS MADE AVAILABLE,  AS IS,  AND OFFIS MAKES NO  WARRANTY
 *  REGARDING  THE  SOFTWARE,  ITS  PERFORMANCE,  ITS  MERCHANTABILITY  OR
 *  FITNESS FOR ANY PARTICULAR USE, FREEDOM FROM ANY COMPUTER DISEASES  OR
 *  ITS CONFORMITY TO ANY SPECIFICATION. THE ENTIRE RISK AS TO QUALITY AND
 *  PERFORMANCE OF THE SOFTWARE IS WITH THE USER.
 *
 *  Module: dcmpstat
 *
 *  Author: Marco Eichelberg
 *
 *  Purpose:
 *    classes: DVPSPrintSCP
 *
 *  Last Update:      $Author: joergr $
 *  Update Date:      $Date: 2004/02/04 15:57:49 $
 *  CVS/RCS Revision: $Revision: 1.18 $
 *  Status:           $State: Exp $
 *
 *  CVS/RCS Log at end of file
 *
 */

#include "osconfig.h"    /* make sure OS specific configuration is included first */

#include "ofstream.h"
#include "dvpsprt.h"
#include "dvpsdef.h"     /* for constants */
#include "dviface.h"
#include "dvpsfs.h"
#include "dvpssp.h"
#include "dvpshlp.h"
#include "ofdatime.h"

#include "dvpsov.h"      /* for DVPSOverlay, needed by MSVC5 with STL */
#include "dvpsgl.h"      /* for DVPSGraphicLayer, needed by MSVC5 with STL */
#include "dvpsrs.h"      /* for DVPSReferencedSeries, needed by MSVC5 with STL */
#include "dvpsal.h"      /* for DVPSOverlayCurveActivationLayer, needed by MSVC5 with STL */
#include "dvpsga.h"      /* for DVPSGraphicAnnotation, needed by MSVC5 with STL */
#include "dvpscu.h"      /* for DVPSCurve, needed by MSVC5 with STL */
#include "dvpsvl.h"      /* for DVPSVOILUT, needed by MSVC5 with STL */
#include "dvpsvw.h"      /* for DVPSVOIWindow, needed by MSVC5 with STL */
#include "dvpsda.h"      /* for DVPSDisplayedArea, needed by MSVC5 with STL */
#include "dvpssv.h"      /* for DVPSSoftcopyVOI, needed by MSVC5 with STL */
#include "dvpsib.h"      /* for DVPSImageBoxContent, needed by MSVC5 with STL */
#include "dvpsab.h"      /* for DVPSAnnotationContent, needed by MSVC5 with STL */
#include "dvpstx.h"      /* for DVPSTextObject, needed by MSVC5 with STL */
#include "dvpsgr.h"      /* for DVPSGraphicObject, needed by MSVC5 with STL */
#include "dvpsri.h"      /* for DVPSReferencedImage, needed by MSVC5 with STL */

DVPSPrintSCP::DVPSPrintSCP(DVInterface &iface, const char *cfname)
: dviface(iface)
, cfgname(cfname)
, blockMode(DIMSE_BLOCKING)
, timeout(0)
, filmSession(NULL)
, presentationLUTList()
, storedPrintList()
, assoc(NULL)
, studyInstanceUID(DCM_StudyInstanceUID)
, psSeriesInstanceUID(DCM_SeriesInstanceUID)
, imageSeriesInstanceUID(DCM_SeriesInstanceUID)
, logSequence(NULL)
, acseSequence(NULL)
, logPath()
, logstream(&ofConsole)
, verboseMode(OFFalse)
, debugMode(OFFalse)
, dumpMode(OFFalse)
{
}

DVPSPrintSCP::~DVPSPrintSCP()
{
  dropAssociation();
  delete logSequence;
  delete acseSequence;
}

int DVPSPrintSCP::errorCond(OFCondition cond, const char *message)
{
  int result = cond.bad();
  if (result && verboseMode)
  {
    ostream &mycerr = logstream->lockCerr();
    mycerr << message << endl;
    logstream->unlockCerr();    
    DimseCondition::dump(cond, *logstream); // performs it's own locking
  }
  return result;
}


DVPSAssociationNegotiationResult DVPSPrintSCP::negotiateAssociation(T_ASC_Network &net)
{
  DVPSAssociationNegotiationResult result = DVPSJ_success;
  char buf[BUFSIZ];
  OFBool dropAssoc = OFFalse;

  // get AETITLE from config file
  const char *aetitle = dviface.getTargetAETitle(cfgname);
  if (aetitle==NULL) aetitle = dviface.getNetworkAETitle(); // default if AETITLE is missing

  // get MaxPDU from config file
  unsigned long maxPDU = dviface.getTargetMaxPDU(cfgname);
  if (maxPDU == 0) maxPDU = DEFAULT_MAXPDU;
  else if (maxPDU > ASC_MAXIMUMPDUSIZE)
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "warning: max PDU size " << maxPDU << " too big, using default: " << DEFAULT_MAXPDU << endl;
      logstream->unlockCerr();
    }
    maxPDU = DEFAULT_MAXPDU;
  }
  else if (maxPDU < ASC_MINIMUMPDUSIZE)
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "warning: max PDU size " << maxPDU << " too small, using default: " << DEFAULT_MAXPDU << endl;
      logstream->unlockCerr();
    }
    maxPDU = DEFAULT_MAXPDU;
  }

  // check whether we want to support Presentation LUT
  OFBool supportPresentationLUT = dviface.getTargetPrinterSupportsPresentationLUT(cfgname);

  // check whether we want to support Implicit VR only
  OFBool implicitOnly = dviface.getTargetImplicitOnly(cfgname);

  // check whether we're expected to accept TLS associations
  OFBool useTLS = dviface.getTargetUseTLS(cfgname);

  void *associatePDU=NULL;
  unsigned long associatePDUlength=0;
  
  OFCondition cond = ASC_receiveAssociation(&net, &assoc, maxPDU, &associatePDU, &associatePDUlength, useTLS);
  if (errorCond(cond, "Failed to receive association:"))
  {
    dropAssoc = OFTrue;
    result = DVPSJ_error;
  }
  else
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "Association Received (" 
           << assoc->params->DULparams.callingPresentationAddress
           << ":" << assoc->params->DULparams.callingAPTitle << " -> "
           << assoc->params->DULparams.calledAPTitle
           << ") " << OFDateTime::getCurrentDateTime() << endl;
      logstream->unlockCerr();
    }

    if (dumpMode)
    {
      ostream &outstream = logstream->lockCerr();
      outstream << endl << "====================== BEGIN A-ASSOCIATE-RQ =====================" << endl;
      ASC_dumpParameters(assoc->params, outstream);
      outstream << "======================= END A-ASSOCIATE-RQ ======================" << endl << endl << flush;
      logstream->unlockCerr();
    }

    ASC_setAPTitles(assoc->params, NULL, NULL, aetitle);

    /* Application Context Name */
    cond = ASC_getApplicationContextName(assoc->params, buf);
    if (cond.bad() || strcmp(buf, DICOM_STDAPPLICATIONCONTEXT) != 0)
    {
        /* reject: the application context name is not supported */
        if (verboseMode)
        {
          logstream->lockCerr() << "Bad AppContextName: " << buf << endl;
          logstream->unlockCerr();
        }
        cond = refuseAssociation(OFTrue);
        dropAssoc = OFTrue;
        result = DVPSJ_error;
    } else {
      const char *abstractSyntaxes[] =
      {
        UID_VerificationSOPClass,
        UID_BasicGrayscalePrintManagementMetaSOPClass,
        UID_PresentationLUTSOPClass,
        UID_PrivateShutdownSOPClass
      };

      int numAbstractSyntaxes = 3;
      if (supportPresentationLUT) numAbstractSyntaxes = 4;

      const char* transferSyntaxes[] = { NULL, NULL, NULL };
      int numTransferSyntaxes = 0;
      if (implicitOnly)
      {
        transferSyntaxes[0] = UID_LittleEndianImplicitTransferSyntax;
        numTransferSyntaxes = 1;
      } else {
        transferSyntaxes[2] = UID_LittleEndianImplicitTransferSyntax;
        numTransferSyntaxes = 3;

        if (gLocalByteOrder == EBO_LittleEndian) {
          /* we are on a little endian machine */
          transferSyntaxes[0] = UID_LittleEndianExplicitTransferSyntax;
          transferSyntaxes[1] = UID_BigEndianExplicitTransferSyntax;
        } else {
          /* we are on a big endian machine */
          transferSyntaxes[0] = UID_BigEndianExplicitTransferSyntax;
          transferSyntaxes[1] = UID_LittleEndianExplicitTransferSyntax;
        }
      }

      /* accept presentation contexts */
      cond = ASC_acceptContextsWithPreferredTransferSyntaxes(
        assoc->params,
        (const char**)abstractSyntaxes, numAbstractSyntaxes,
        (const char**)transferSyntaxes, numTransferSyntaxes);
      errorCond(cond, "Cannot accept presentation contexts:");

    }

    /* check if we have negotiated the private "shutdown" SOP Class */
    if (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PrivateShutdownSOPClass))
    {
      cond = refuseAssociation(OFFalse);
      dropAssoc = OFTrue;
      result = DVPSJ_terminate;
    }
  } /* receiveAssociation successful */
  if (dropAssoc) dropAssociation();

  if (acseSequence && associatePDU)
  {
    addLogEntry(acseSequence, "A_ASSOCIATE_RQ");
    DcmItem *newItem = new DcmItem();
    if (newItem)
    {
      DcmElement *assocData = new DcmOtherByteOtherWord(PSTAT_DCM_AssociateData);
      if (assocData)
      {
        assocData->putUint8Array((Uint8 *) associatePDU, associatePDUlength);    
        newItem->insert(assocData, OFTrue /*replaceOld*/);
        acseSequence->insert(newItem);
      } else delete newItem;
    }    
  }  
  delete[] (char *)associatePDU;
  return result;
}


OFCondition DVPSPrintSCP::refuseAssociation(OFBool isBadContext)
{
  T_ASC_RejectParameters rej;

  if (isBadContext)
  {
      rej.result = ASC_RESULT_REJECTEDTRANSIENT;
      rej.source = ASC_SOURCE_SERVICEUSER;
      rej.reason = ASC_REASON_SU_APPCONTEXTNAMENOTSUPPORTED;
  } else {
      rej.result = ASC_RESULT_REJECTEDPERMANENT;
      rej.source = ASC_SOURCE_SERVICEUSER;
      rej.reason = ASC_REASON_SU_NOREASON;
  }

  void *associatePDU=NULL;
  unsigned long associatePDUlength=0;

  OFCondition cond = ASC_rejectAssociation(assoc, &rej, &associatePDU, &associatePDUlength);

  if (dumpMode)
  {
    ostream &outstream = logstream->lockCerr();
    outstream << endl << "====================== BEGIN A-ASSOCIATE-RJ =====================" << endl;
    ASC_dumpParameters(assoc->params, outstream);
    outstream << "======================= END A-ASSOCIATE-RJ ======================" << endl << endl << flush;
    logstream->unlockCerr();
  }

  if (acseSequence && associatePDU)
  {
    addLogEntry(acseSequence, "A_ASSOCIATE_RJ");
    DcmItem *newItem = new DcmItem();
    if (newItem)
    {
      DcmElement *assocData = new DcmOtherByteOtherWord(PSTAT_DCM_AssociateData);
      if (assocData)
      {
        assocData->putUint8Array((Uint8 *) associatePDU, associatePDUlength);    
        newItem->insert(assocData, OFTrue /*replaceOld*/);
        acseSequence->insert(newItem);
      } else delete newItem;
    }    
  }  
  delete[] (char *)associatePDU;
  errorCond(cond, "Association Reject Failed:");
  return cond;
}


void DVPSPrintSCP::dropAssociation()
{
  if (assoc == NULL) return;
  OFCondition cond = ASC_dropSCPAssociation(assoc);
  errorCond(cond, "Cannot Drop Association:");
  cond = ASC_destroyAssociation(&assoc);
  errorCond(cond, "Cannot Destroy Association:");
  assoc = NULL;
  return;
}


void DVPSPrintSCP::handleClient()
{
  void *associatePDU=NULL;
  unsigned long associatePDUlength=0;

  OFCondition cond = ASC_acknowledgeAssociation(assoc, &associatePDU, &associatePDUlength);
  if (dumpMode)
  {
    ostream &outstream = logstream->lockCerr();
    outstream << endl << "====================== BEGIN A-ASSOCIATE-AC =====================" << endl;
    ASC_dumpParameters(assoc->params, outstream);
    outstream << "======================= END A-ASSOCIATE-AC ======================" << endl << endl << flush;
    logstream->unlockCerr();
  }  
  if (acseSequence && associatePDU)
  {
    addLogEntry(acseSequence, "A_ASSOCIATE_AC");
    DcmItem *newItem = new DcmItem();
    if (newItem)
    {
      DcmElement *assocData = new DcmOtherByteOtherWord(PSTAT_DCM_AssociateData);
      if (assocData)
      {
        assocData->putUint8Array((Uint8 *) associatePDU, associatePDUlength);    
        newItem->insert(assocData, OFTrue /*replaceOld*/);
        acseSequence->insert(newItem);
      } else delete newItem;
    }    
  }    
  delete[] (char *)associatePDU;

  if (! errorCond(cond, "Cannot acknowledge association:"))
  {

    if (verboseMode)
    {
      ostream &mycerr = logstream->lockCerr();
      mycerr << "Association Acknowledged (Max Send PDV: " << assoc->sendPDVLength << ")" << endl;
      if (ASC_countAcceptedPresentationContexts(assoc->params) == 0) mycerr << "    (but no valid presentation contexts)" << endl;
      logstream->unlockCerr();
    }

    T_DIMSE_Message msg;
    T_ASC_PresentationContextID presID;
    cond = EC_Normal;
    DcmDataset *rawCommandSet=NULL;
    
    /* do real work */
    while (cond.good())
    {
      cond = DIMSE_receiveCommand(assoc, DIMSE_BLOCKING, 0, &presID, &msg, NULL, &rawCommandSet);
      /* did peer release, abort, or do we have a valid message ? */
      
      if (cond.good())
      {
    	addLogEntry(logSequence, "RECEIVE");
        if (rawCommandSet)
        {
          if (logSequence) logSequence->insert(new DcmItem(*rawCommandSet));
          delete rawCommandSet;
          rawCommandSet = NULL;
        } else {
          // should not happen
          if (logSequence) logSequence->insert(new DcmItem());
        }
      }

      if (cond.good())
      {
          /* process command */
          switch (msg.CommandField)
          {
            case DIMSE_C_ECHO_RQ:
              cond = handleCEcho(msg, presID);
              break;
            case DIMSE_N_GET_RQ:
              cond = handleNGet(msg, presID);
              break;
            case DIMSE_N_SET_RQ:
              cond = handleNSet(msg, presID);
              break;
            case DIMSE_N_ACTION_RQ:
              cond = handleNAction(msg, presID);
              break;
            case DIMSE_N_CREATE_RQ:
              cond = handleNCreate(msg, presID);
              break;
            case DIMSE_N_DELETE_RQ:
              cond = handleNDelete(msg, presID);
              break;
            default:
              cond = DIMSE_BADCOMMANDTYPE; /* unsupported command */
              dumpNMessage(msg, NULL, OFFalse);
              if (verboseMode)
              {
                logstream->lockCerr() << "Cannot handle command: 0x" << hex << (unsigned)msg.CommandField << dec << endl;
                logstream->unlockCerr();
              }
              break;
          }
      }
      else 
      {
          /* finish processing loop */
      }
    } /* while */

    if (logSequence) saveDimseLog();

    /* close association */
    if (cond == DUL_PEERREQUESTEDRELEASE)
    {
      if (verboseMode)
      {
        logstream->lockCerr() << "Association Release" << endl;
        logstream->unlockCerr();
      }
      cond = ASC_acknowledgeRelease(assoc);
      errorCond(cond, "Cannot release association:");
    }
    else if (cond == DUL_PEERABORTEDASSOCIATION)
    {
      if (verboseMode)
      {
        logstream->lockCerr() << "Association Aborted" << endl;
        logstream->unlockCerr();
      }
    }
    else
    {
      errorCond(cond, "DIMSE Failure (aborting association):");
      cond = ASC_abortAssociation(assoc);
      errorCond(cond, "Cannot abort association:");
    }
  }
  dropAssociation();
}


OFCondition DVPSPrintSCP::handleCEcho(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  OFCondition cond = DIMSE_sendEchoResponse(assoc, presID, &rq.msg.CEchoRQ, STATUS_Success, NULL);
  return cond;
}

OFCondition DVPSPrintSCP::handleNGet(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  // initialize response message
  T_DIMSE_Message rsp;
  rsp.CommandField = DIMSE_N_GET_RSP;
  rsp.msg.NGetRSP.MessageIDBeingRespondedTo = rq.msg.NGetRQ.MessageID;
  rsp.msg.NGetRSP.AffectedSOPClassUID[0] = 0;
  rsp.msg.NGetRSP.DimseStatus = STATUS_Success;
  rsp.msg.NGetRSP.AffectedSOPInstanceUID[0] = 0;
  rsp.msg.NGetRSP.DataSetType = DIMSE_DATASET_NULL;
  rsp.msg.NGetRSP.opts = 0;

  OFCondition cond = EC_Normal;
  DcmDataset *rspDataset = NULL;

  if (rq.msg.NGetRQ.DataSetType == DIMSE_DATASET_PRESENT)
  {
     DcmDataset *dataset = NULL;
     // should not happen
     cond = DIMSE_receiveDataSetInMemory(assoc, blockMode, timeout, &presID, &dataset, NULL, NULL);
     if (cond.good()) 
     {
       if (logSequence) logSequence->insert(new DcmItem(*dataset));
       dumpNMessage(rq, dataset, OFFalse);
     }
     delete dataset;
     if (cond.bad()) return cond;
  } else {
    dumpNMessage(rq, NULL, OFFalse);
    if (logSequence) logSequence->insert(new DcmItem());
  }

  OFString sopClass(rq.msg.NGetRQ.RequestedSOPClassUID);
  if (sopClass == UID_PrinterSOPClass)
  {
    // Print N-GET
    printerNGet(rq, rsp, rspDataset);
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: N-GET unsupported for SOP class '" << sopClass.c_str() << "'" << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NGetRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
  }
  DcmDataset *rspCommand = NULL;
  addLogEntry(logSequence, "SEND");
  dumpNMessage(rsp, rspDataset, OFTrue);
  cond = DIMSE_sendMessageUsingMemoryData(assoc, presID, &rsp, NULL, rspDataset, NULL, NULL, &rspCommand);
  if (logSequence)
  {
    if (rspCommand) logSequence->insert(new DcmItem(*rspCommand));
    if (rspDataset) logSequence->insert(new DcmItem(*rspDataset));
    else logSequence->insert(new DcmItem());
  }
  delete rspCommand;
  delete rspDataset;
  return cond;
}


OFCondition DVPSPrintSCP::handleNSet(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  // initialize response message
  T_DIMSE_Message rsp;
  rsp.CommandField = DIMSE_N_SET_RSP;
  rsp.msg.NSetRSP.MessageIDBeingRespondedTo = rq.msg.NSetRQ.MessageID;
  rsp.msg.NSetRSP.AffectedSOPClassUID[0] = 0;
  rsp.msg.NSetRSP.DimseStatus = STATUS_Success;
  rsp.msg.NSetRSP.AffectedSOPInstanceUID[0] = 0;
  rsp.msg.NSetRSP.DataSetType = DIMSE_DATASET_NULL;
  rsp.msg.NSetRSP.opts = 0;

  OFCondition cond = EC_Normal;
  DcmDataset *rqDataset = NULL;
  DcmDataset *rspDataset = NULL;

  if (rq.msg.NSetRQ.DataSetType == DIMSE_DATASET_PRESENT)
  {
     cond = DIMSE_receiveDataSetInMemory(assoc, blockMode, timeout, &presID, &rqDataset, NULL, NULL);
     if (cond.bad()) return cond;
     if (logSequence && rqDataset) logSequence->insert(new DcmItem(*rqDataset));
  } else if (logSequence) logSequence->insert(new DcmItem());

  dumpNMessage(rq, rqDataset, OFFalse);

  OFString sopClass(rq.msg.NSetRQ.RequestedSOPClassUID);
  if (sopClass == UID_BasicFilmSessionSOPClass)
  {
    // BFS N-SET
    filmSessionNSet(rq, rqDataset, rsp, rspDataset);
  } else if (sopClass == UID_BasicFilmBoxSOPClass)
  {
    // BFB N-SET
    filmBoxNSet(rq, rqDataset, rsp, rspDataset);
  } else if (sopClass == UID_BasicGrayscaleImageBoxSOPClass)
  {
    // BGIB N-SET
    imageBoxNSet(rq, rqDataset, rsp, rspDataset);
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: N-SET unsupported for SOP class '" << sopClass.c_str() << "'" << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NSetRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
  }

  DcmDataset *rspCommand = NULL;
  addLogEntry(logSequence, "SEND");
  dumpNMessage(rsp, rspDataset, OFTrue);
  cond = DIMSE_sendMessageUsingMemoryData(assoc, presID, &rsp, NULL, rspDataset, NULL, NULL, &rspCommand);
  if (logSequence)
  {
    if (rspCommand) logSequence->insert(new DcmItem(*rspCommand));
    if (rspDataset) logSequence->insert(new DcmItem(*rspDataset));
    else logSequence->insert(new DcmItem());
  }
  delete rspCommand;
  delete rqDataset;
  delete rspDataset;
  return cond;
}


OFCondition DVPSPrintSCP::handleNAction(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  // initialize response message
  T_DIMSE_Message rsp;
  rsp.CommandField = DIMSE_N_ACTION_RSP;
  rsp.msg.NActionRSP.MessageIDBeingRespondedTo = rq.msg.NActionRQ.MessageID;
  rsp.msg.NActionRSP.AffectedSOPClassUID[0] = 0;
  rsp.msg.NActionRSP.DimseStatus = STATUS_Success;
  rsp.msg.NActionRSP.AffectedSOPInstanceUID[0] = 0;
  rsp.msg.NActionRSP.ActionTypeID = rq.msg.NActionRQ.ActionTypeID;
  rsp.msg.NActionRSP.DataSetType = DIMSE_DATASET_NULL;
  rsp.msg.NActionRSP.opts = O_NACTION_ACTIONTYPEID;

  OFCondition cond = EC_Normal;
  DcmDataset *rqDataset = NULL;

  if (rq.msg.NActionRQ.DataSetType == DIMSE_DATASET_PRESENT)
  {
     cond = DIMSE_receiveDataSetInMemory(assoc, blockMode, timeout, &presID, &rqDataset, NULL, NULL);
     if (cond.bad()) return cond;
     if (logSequence && rqDataset) logSequence->insert(new DcmItem(*rqDataset));
  } else if (logSequence) logSequence->insert(new DcmItem());

  dumpNMessage(rq, rqDataset, OFFalse);

  OFString sopClass(rq.msg.NActionRQ.RequestedSOPClassUID);
  if (sopClass == UID_BasicFilmSessionSOPClass)
  {
    // BFS N-ACTION
    filmSessionNAction(rq, rsp);
  } else if (sopClass == UID_BasicFilmBoxSOPClass)
  {
    // BFB N-ACTION
    filmBoxNAction(rq, rsp);
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: N-ACTION unsupported for SOP class '" << sopClass.c_str() << "'" << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NActionRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
  }

  DcmDataset *rspCommand = NULL;
  addLogEntry(logSequence, "SEND");
  dumpNMessage(rsp, NULL, OFTrue);
  cond = DIMSE_sendMessageUsingMemoryData(assoc, presID, &rsp, NULL, NULL, NULL, NULL, &rspCommand);
  if (logSequence)
  {
    if (rspCommand) logSequence->insert(new DcmItem(*rspCommand));
    logSequence->insert(new DcmItem());
  }
  delete rspCommand;
  delete rqDataset;
  return cond;
}


OFCondition DVPSPrintSCP::handleNCreate(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  // initialize response message
  T_DIMSE_Message rsp;
  rsp.CommandField = DIMSE_N_CREATE_RSP;
  rsp.msg.NCreateRSP.MessageIDBeingRespondedTo = rq.msg.NCreateRQ.MessageID;
  rsp.msg.NCreateRSP.AffectedSOPClassUID[0] = 0;
  rsp.msg.NCreateRSP.DimseStatus = STATUS_Success;
  if (rq.msg.NCreateRQ.opts & O_NCREATE_AFFECTEDSOPINSTANCEUID)
  {
    // instance UID is provided by SCU
    strncpy(rsp.msg.NCreateRSP.AffectedSOPInstanceUID, rq.msg.NCreateRQ.AffectedSOPInstanceUID, sizeof(DIC_UI));
  } else {
    // we generate our own instance UID
    dcmGenerateUniqueIdentifier(rsp.msg.NCreateRSP.AffectedSOPInstanceUID);
  }
  rsp.msg.NCreateRSP.DataSetType = DIMSE_DATASET_NULL;
  OFBool omitFlag = dviface.getTargetPrintSCPOmitSOPClassUIDFromCreateResponse(cfgname);
  if (omitFlag)
  {
    rsp.msg.NCreateRSP.opts = O_NCREATE_AFFECTEDSOPINSTANCEUID;
  } else {
    strncpy(rsp.msg.NCreateRSP.AffectedSOPClassUID, rq.msg.NCreateRQ.AffectedSOPClassUID, sizeof(DIC_UI));
    rsp.msg.NCreateRSP.opts = O_NCREATE_AFFECTEDSOPINSTANCEUID | O_NCREATE_AFFECTEDSOPCLASSUID;
  }

  OFCondition cond = EC_Normal;
  DcmDataset *rqDataset = NULL;
  DcmDataset *rspDataset = NULL;

  if (rq.msg.NCreateRQ.DataSetType == DIMSE_DATASET_PRESENT)
  {
     cond = DIMSE_receiveDataSetInMemory(assoc, blockMode, timeout, &presID, &rqDataset, NULL, NULL);
     if (cond.bad()) return cond;
     if (logSequence && rqDataset) logSequence->insert(new DcmItem(*rqDataset));
  } else if (logSequence) logSequence->insert(new DcmItem());

  dumpNMessage(rq, rqDataset, OFFalse);

  OFString sopClass(rq.msg.NCreateRQ.AffectedSOPClassUID);
  if (sopClass == UID_BasicFilmSessionSOPClass)
  {
    // BFS N-CREATE
    filmSessionNCreate(rqDataset, rsp, rspDataset);
  } else if (sopClass == UID_BasicFilmBoxSOPClass)
  {
    // BFB N-CREATE
    filmBoxNCreate(rqDataset, rsp, rspDataset);
  } else if (sopClass == UID_PresentationLUTSOPClass)
  {
    // P-LUT N-CREATE
    presentationLUTNCreate(rqDataset, rsp, rspDataset);
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: N-CREATE unsupported for SOP class '" << sopClass.c_str() << "'" << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NCreateRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
    rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
  }

  DcmDataset *rspCommand = NULL;
  addLogEntry(logSequence, "SEND");
  dumpNMessage(rsp, rspDataset, OFTrue);
  cond = DIMSE_sendMessageUsingMemoryData(assoc, presID, &rsp, NULL, rspDataset, NULL, NULL, &rspCommand);
  if (logSequence)
  {
    if (rspCommand) logSequence->insert(new DcmItem(*rspCommand));
    if (rspDataset) logSequence->insert(new DcmItem(*rspDataset));
    else logSequence->insert(new DcmItem());
  }
  delete rspCommand;
  delete rqDataset;
  delete rspDataset;
  return cond;
}

OFCondition DVPSPrintSCP::handleNDelete(T_DIMSE_Message& rq, T_ASC_PresentationContextID presID)
{
  // initialize response message
  T_DIMSE_Message rsp;
  rsp.CommandField = DIMSE_N_DELETE_RSP;
  rsp.msg.NDeleteRSP.MessageIDBeingRespondedTo = rq.msg.NDeleteRQ.MessageID;
  rsp.msg.NDeleteRSP.AffectedSOPClassUID[0] = 0;
  rsp.msg.NDeleteRSP.DimseStatus = STATUS_Success;
  rsp.msg.NDeleteRSP.AffectedSOPInstanceUID[0] = 0;
  rsp.msg.NDeleteRSP.DataSetType = DIMSE_DATASET_NULL;
  rsp.msg.NDeleteRSP.opts = 0;

  OFCondition cond = EC_Normal;
  if (rq.msg.NDeleteRQ.DataSetType == DIMSE_DATASET_PRESENT)
  {
     // should not happen
     DcmDataset *dataset = NULL;
     cond = DIMSE_receiveDataSetInMemory(assoc, blockMode, timeout, &presID, &dataset, NULL, NULL);
     if (cond.good()) 
     {
       if (logSequence) logSequence->insert(new DcmItem(*dataset));
       dumpNMessage(rq, dataset, OFFalse);
     }
     delete dataset;
     if (cond.bad()) return cond;
  } else {
     if (logSequence) logSequence->insert(new DcmItem());
     dumpNMessage(rq, NULL, OFFalse);
  }

  OFString sopClass(rq.msg.NDeleteRQ.RequestedSOPClassUID);
  if (sopClass == UID_BasicFilmSessionSOPClass)
  {
    // BFS N-DELETE
    filmSessionNDelete(rq, rsp);
  } else if (sopClass == UID_BasicFilmBoxSOPClass)
  {
    // BFB N-DELETE
    filmBoxNDelete(rq, rsp);
  } else if (sopClass == UID_PresentationLUTSOPClass)
  {
    // P-LUT N-DELETE
    presentationLUTNDelete(rq, rsp);
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: N-DELETE unsupported for SOP class '" << sopClass.c_str() << "'" << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NDeleteRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
  }

  DcmDataset *rspCommand = NULL;
  addLogEntry(logSequence, "SEND");
  dumpNMessage(rsp, NULL, OFTrue);
  cond = DIMSE_sendMessageUsingMemoryData(assoc, presID, &rsp, NULL, NULL, NULL, NULL, &rspCommand);
  if (logSequence)
  {
    if (rspCommand) logSequence->insert(new DcmItem(*rspCommand));
    logSequence->insert(new DcmItem());
  }
  delete rspCommand;
  return cond;
}


void DVPSPrintSCP::printerNGet(T_DIMSE_Message& rq, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  OFString printerInstance(UID_PrinterSOPInstance);
  if (printerInstance == rq.msg.NGetRQ.RequestedSOPInstanceUID)
  {
    OFBool result = OFTrue;
    rspDataset = new DcmDataset;
    if (rspDataset == NULL)
    {
      rsp.msg.NGetRSP.DimseStatus = STATUS_N_ProcessingFailure;
      result = OFFalse;
    }

    int i=0;
    DIC_US group=0;
    DIC_US element=0;
    while (i+1 < rq.msg.NGetRQ.ListCount)
    {
      group = rq.msg.NGetRQ.AttributeIdentifierList[i++];
      element = rq.msg.NGetRQ.AttributeIdentifierList[i++];
      if ((group == 0x2110)&&(element == 0x0010))
      {
       if (EC_Normal != DVPSHelper::putStringValue(rspDataset, DCM_PrinterStatus, DEFAULT_printerStatus)) result = OFFalse;
      }
      else if  ((group == 0x2110)&&(element == 0x0020))
      {
       if (EC_Normal != DVPSHelper::putStringValue(rspDataset, DCM_PrinterStatusInfo, DEFAULT_printerStatusInfo)) result = OFFalse;
      }
      else if (element == 0x0000)
      {
      	/* group length */
      }
      else
      {
        if (verboseMode)
        {
          char buf[20];
          sprintf(buf, "(%04x,%04x)", (int)group, (int)element);
          logstream->lockCerr() << "error: cannot retrieve printer information: unsupported attribute " << buf << " in attribute list." << endl;
          logstream->unlockCerr();
        }
        rsp.msg.NGetRSP.DimseStatus = STATUS_N_NoSuchAttribute;
        result = OFFalse;
      }
    }

    if (rq.msg.NGetRQ.ListCount == 0)
    {
     if (EC_Normal != DVPSHelper::putStringValue(rspDataset, DCM_PrinterStatus, DEFAULT_printerStatus)) result = OFFalse;
     if (EC_Normal != DVPSHelper::putStringValue(rspDataset, DCM_PrinterStatusInfo, DEFAULT_printerStatusInfo)) result = OFFalse;
    }

    if (result)
    {
      rsp.msg.NSetRSP.DataSetType = DIMSE_DATASET_PRESENT;
    } else {
      delete rspDataset;
      rspDataset = NULL;
      if (rsp.msg.NGetRSP.DimseStatus == 0) rsp.msg.NGetRSP.DimseStatus = STATUS_N_ProcessingFailure;
      result = OFFalse;
    }
  } else {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot retrieve printer information, instance UID is not well-known printer SOP instance UID." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NGetRSP.DimseStatus = STATUS_N_NoSuchObjectInstance;
  }
}

void DVPSPrintSCP::filmSessionNSet(T_DIMSE_Message& rq, DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  if (filmSession && (filmSession->isInstance(rq.msg.NSetRQ.RequestedSOPInstanceUID)))
  {
    OFBool usePLUTinFilmSession = OFFalse;
    if (assoc && (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass))) 
    {
      if (dviface.getTargetPrinterPresentationLUTinFilmSession(cfgname)) usePLUTinFilmSession = OFTrue;
    }

    DVPSFilmSession *newSession = new DVPSFilmSession(*filmSession);
    if (newSession)
    {
      if (newSession->printSCPSet(dviface, cfgname, rqDataset, rsp, rspDataset, usePLUTinFilmSession, presentationLUTList, storedPrintList))
      {
        delete filmSession;
        filmSession = newSession;
      } else delete newSession;
    } else {
      if (verboseMode)
      {
        logstream->lockCerr() << "error: cannot update film session, out of memory." << endl;
        logstream->unlockCerr();
      }
      rsp.msg.NSetRSP.DimseStatus = STATUS_N_ProcessingFailure;
    }
  } else {
    // film session does not exist or wrong instance UID
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot update film session, object not found." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NSetRSP.DimseStatus = STATUS_N_NoSuchObjectInstance;
  }
}

void DVPSPrintSCP::filmBoxNSet(T_DIMSE_Message& rq, DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  OFBool usePLUTinFilmBox = OFFalse;
  if (assoc && (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass))) 
  {
    if (! dviface.getTargetPrinterPresentationLUTinFilmSession(cfgname)) usePLUTinFilmBox = OFTrue;
  }
  storedPrintList.printSCPBasicFilmBoxSet(dviface, cfgname, rq, rqDataset, rsp, rspDataset, usePLUTinFilmBox, presentationLUTList);
}

void DVPSPrintSCP::filmSessionNAction(T_DIMSE_Message& rq, T_DIMSE_Message& rsp)
{
  if (filmSession && (filmSession->isInstance(rq.msg.NActionRQ.RequestedSOPInstanceUID)))
  {
    storedPrintList.printSCPBasicFilmSessionAction(dviface, cfgname, rsp, presentationLUTList);
  } else {
    // film session does not exist or wrong instance UID
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot print film session, object not found." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NActionRSP.DimseStatus = STATUS_N_NoSuchObjectInstance;
  }
}

void DVPSPrintSCP::filmBoxNAction(T_DIMSE_Message& rq, T_DIMSE_Message& rsp)
{
  storedPrintList.printSCPBasicFilmBoxAction(dviface, cfgname, rq, rsp, presentationLUTList);
}

void DVPSPrintSCP::filmSessionNCreate(DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  if (filmSession)
  {
    // film session exists already, refuse n-create
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot create two film sessions concurrently." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NCreateRSP.DimseStatus = STATUS_N_DuplicateSOPInstance;
    rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
  } else {
    OFBool usePLUTinFilmSession = OFFalse;
    if (assoc && (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass))) 
    {
      if (dviface.getTargetPrinterPresentationLUTinFilmSession(cfgname)) usePLUTinFilmSession = OFTrue;
    }
    
    DVPSFilmSession *newSession = new DVPSFilmSession(DEFAULT_illumination, DEFAULT_reflectedAmbientLight);
    if (newSession)
    {
      newSession->setLog(logstream, verboseMode, debugMode);
      DIC_AE peerTitle;
      peerTitle[0]=0;
      ASC_getAPTitles(assoc->params, peerTitle, NULL, NULL);
      if (newSession->printSCPCreate(dviface, cfgname, rqDataset, rsp, rspDataset, 
          peerTitle, usePLUTinFilmSession, presentationLUTList)) 
          filmSession = newSession;
      char uid[100];
      studyInstanceUID.putString(dcmGenerateUniqueIdentifier(uid, SITE_STUDY_UID_ROOT));
      psSeriesInstanceUID.putString(dcmGenerateUniqueIdentifier(uid, SITE_SERIES_UID_ROOT));
      imageSeriesInstanceUID.putString(dcmGenerateUniqueIdentifier(uid));
    } else {
      if (verboseMode)
      {
        logstream->lockCerr() << "error: cannot create film session, out of memory." << endl;
        logstream->unlockCerr();
      }
      rsp.msg.NCreateRSP.DimseStatus = STATUS_N_ProcessingFailure;
      rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
    }
  }
}

void DVPSPrintSCP::filmBoxNCreate(DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  if (filmSession)
  {
    if (storedPrintList.haveFilmBoxInstance(rsp.msg.NCreateRSP.AffectedSOPInstanceUID))
    {
      if (verboseMode)
      {
        logstream->lockCerr() << "error: cannot create film box, requested SOP instance UID already in use." << endl;
        logstream->unlockCerr();
      }
      rsp.msg.NCreateRSP.DimseStatus = STATUS_N_DuplicateSOPInstance;
      rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
    } else {
      DVPSStoredPrint *newSPrint = new DVPSStoredPrint(DEFAULT_illumination, DEFAULT_reflectedAmbientLight);
      if (newSPrint)
      {
        newSPrint->setLog(logstream, verboseMode, debugMode);

        if (assoc) newSPrint->setOriginator(assoc->params->DULparams.callingAPTitle);

        // get AETITLE from config file
        const char *aetitle = dviface.getTargetAETitle(cfgname);
        if (aetitle==NULL) aetitle = dviface.getNetworkAETitle(); // default if AETITLE is missing
        newSPrint->setDestination(aetitle);          
        newSPrint->setPrinterName(cfgname);                  
        
        OFBool usePLUTinFilmBox = OFFalse;
        OFBool usePLUTinFilmSession = OFFalse;
        if (assoc && (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass))) 
        {
          if (dviface.getTargetPrinterPresentationLUTinFilmSession(cfgname)) usePLUTinFilmSession = OFTrue;
          else usePLUTinFilmBox = OFTrue;
        }
        if (newSPrint->printSCPCreate(dviface, cfgname, rqDataset, rsp, rspDataset, usePLUTinFilmBox,
          presentationLUTList, filmSession->getUID(), studyInstanceUID, psSeriesInstanceUID, imageSeriesInstanceUID))
        {
          if (usePLUTinFilmSession)
          {
            filmSession->copyPresentationLUTSettings(*newSPrint); // update P-LUT settings from film session
          }
          storedPrintList.insert(newSPrint);
        } else delete newSPrint;
      } else {
        if (verboseMode)
        {
          logstream->lockCerr() << "error: cannot create film box, out of memory." << endl;
          logstream->unlockCerr();
        }
        rsp.msg.NCreateRSP.DimseStatus = STATUS_N_ProcessingFailure;
        rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
      }
    }
  } else {
    // no film session, refuse n-create
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot create film box without film session." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NCreateRSP.DimseStatus = STATUS_N_InvalidObjectInstance;
    rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
  }
}

void DVPSPrintSCP::presentationLUTNCreate(DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  if ((assoc==NULL) || (0 == ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass)))
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot create presentation LUT, not negotiated." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NCreateRSP.DimseStatus = STATUS_N_NoSuchSOPClass;
    rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
  }
  else if (presentationLUTList.findPresentationLUT(rsp.msg.NCreateRSP.AffectedSOPInstanceUID))
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot create presentation LUT, requested SOP instance UID already in use." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NCreateRSP.DimseStatus = STATUS_N_DuplicateSOPInstance;
    rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
  } else {
    DVPSPresentationLUT *newPLut = new DVPSPresentationLUT();
    if (newPLut)
    {
      newPLut->setLog(logstream, verboseMode, debugMode);
      OFBool matchRequired = dviface.getTargetPrinterPresentationLUTMatchRequired(cfgname);
      OFBool supports12Bit = dviface.getTargetPrinterSupports12BitTransmission(cfgname);
      if (newPLut->printSCPCreate(rqDataset, rsp, rspDataset, matchRequired, supports12Bit))
      {
        presentationLUTList.insert(newPLut);
      } else delete newPLut;
    } else {
      if (verboseMode)
      {
        logstream->lockCerr() << "error: cannot create presentation LUT, out of memory." << endl;
        logstream->unlockCerr();
      }
      rsp.msg.NCreateRSP.DimseStatus = STATUS_N_ProcessingFailure;
      rsp.msg.NCreateRSP.opts = 0;  // don't include affected SOP instance UID
    }
  }
}

void DVPSPrintSCP::filmSessionNDelete(T_DIMSE_Message& rq, T_DIMSE_Message& rsp)
{
  if (filmSession && (filmSession->isInstance(rq.msg.NDeleteRQ.RequestedSOPInstanceUID)))
  {
    // delete film box hierarchy and film session object
    storedPrintList.clear();
    delete filmSession;
    filmSession = NULL;
  } else {
    // film session does not exist or wrong instance UID
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot delete film session with instance UID '" << rq.msg.NDeleteRQ.RequestedSOPInstanceUID << "': object does not exist." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NDeleteRSP.DimseStatus = STATUS_N_NoSuchObjectInstance;
  }
}

void DVPSPrintSCP::filmBoxNDelete(T_DIMSE_Message& rq, T_DIMSE_Message& rsp)
{
  storedPrintList.printSCPBasicFilmBoxDelete(rq, rsp);
}

void DVPSPrintSCP::presentationLUTNDelete(T_DIMSE_Message& rq, T_DIMSE_Message& rsp)
{
  // check whether references to this object exist. In this case, don't delete
  if (storedPrintList.usesPresentationLUT(rq.msg.NDeleteRQ.RequestedSOPInstanceUID))
  {
    if (verboseMode)
    {
      logstream->lockCerr() << "error: cannot delete presentation LUT '" << rq.msg.NDeleteRQ.RequestedSOPInstanceUID << "': object still in use." << endl;
      logstream->unlockCerr();
    }
    rsp.msg.NDeleteRSP.DimseStatus = STATUS_N_ProcessingFailure;
  } else {
    presentationLUTList.printSCPDelete(rq, rsp);
  }
}

void DVPSPrintSCP::imageBoxNSet(T_DIMSE_Message& rq, DcmDataset *rqDataset, T_DIMSE_Message& rsp, DcmDataset *& rspDataset)
{
  OFBool usePLUT = OFFalse;
  if (assoc && (0 != ASC_findAcceptedPresentationContextID(assoc, UID_PresentationLUTSOPClass))) usePLUT = OFTrue;
  storedPrintList.printSCPBasicGrayscaleImageBoxSet(dviface, cfgname, rq, rqDataset, rsp, rspDataset, usePLUT);
}

void DVPSPrintSCP::setLog(OFConsole *stream, OFBool verbMode, OFBool dbgMode, OFBool dmpMode)
{
  if (stream) logstream = stream; else logstream = &ofConsole;
  verboseMode = verbMode;
  debugMode = dbgMode;
  dumpMode = dmpMode;
  dviface.setLog(logstream, verbMode, dbgMode);
  presentationLUTList.setLog(logstream, verbMode, dbgMode);
  storedPrintList.setLog(logstream, verbMode, dbgMode);
  if (filmSession) filmSession->setLog(logstream, verbMode, dbgMode);
}


void DVPSPrintSCP::addLogEntry(DcmSequenceOfItems *seq, const char *text)
{
  if ((!seq)||(!text)) return;

  DcmItem *newItem = new DcmItem();
  if (!newItem) return;
  
  OFString aString;
  DcmElement *logEntryType = new DcmCodeString(PSTAT_DCM_LogEntryType);
  if (logEntryType)
  {
    logEntryType->putString(text);
    newItem->insert(logEntryType, OFTrue /*replaceOld*/);
  }

  DVPSHelper::currentDate(aString);
  DcmElement *logDate = new DcmDate(PSTAT_DCM_LogDate);
  if (logDate)
  {
    logDate->putString(aString.c_str());
    newItem->insert(logDate, OFTrue /*replaceOld*/);
  }

  DVPSHelper::currentTime(aString);
  DcmElement *logTime = new DcmTime(PSTAT_DCM_LogTime);
  if (logTime)
  {
    logTime->putString(aString.c_str());
    newItem->insert(logTime, OFTrue /*replaceOld*/);
  }
  seq->insert(newItem);
}


void DVPSPrintSCP::setDimseLogPath(const char *fname)
{
  if (fname)
  {
    logPath = fname;
    if (logSequence == NULL) logSequence = new DcmSequenceOfItems(PSTAT_DCM_LogSequence);
    if (acseSequence == NULL) acseSequence = new DcmSequenceOfItems(PSTAT_DCM_AcseSequence);
  } else {
    logPath.clear();
    delete logSequence;
    logSequence = NULL;
  }
}

void DVPSPrintSCP::saveDimseLog()
{
  if (logSequence == NULL) return;

  DcmFileFormat fformat;
  DcmDataset *dset = fformat.getDataset();  
  if (! dset) return;

  dset->insert(logSequence, OFTrue /*replaceOld*/);  
  logSequence = NULL;
  if (acseSequence) dset->insert(acseSequence, OFTrue /*replaceOld*/);
  acseSequence = NULL;

  char uid[80];
  OFString aString;

  const char *aetitle = dviface.getTargetAETitle(cfgname);
  if (aetitle==NULL) aetitle = dviface.getNetworkAETitle(); // default if AETITLE is missing
  aString = OFFIS_DTK_IMPLEMENTATION_VERSION_NAME;
  aString += " ";
  aString += aetitle;

  DcmElement *logReserve = new DcmLongString(PSTAT_DCM_LogReservation);
  if (logReserve)
  {
    logReserve->putString(aString.c_str());
    dset->insert(logReserve, OFTrue /*replaceOld*/);
  }
    
  DVPSHelper::putStringValue(dset, DCM_SOPClassUID, PSTAT_DIMSE_LOG_STORAGE_UID);
  DVPSHelper::putStringValue(dset, DCM_SOPInstanceUID, dcmGenerateUniqueIdentifier(uid));  
  DVPSHelper::currentDate(aString);
  DVPSHelper::putStringValue(dset, DCM_InstanceCreationDate, aString.c_str());
  DVPSHelper::currentTime(aString);
  DVPSHelper::putStringValue(dset, DCM_InstanceCreationTime, aString.c_str());

  OFCondition cond = DVPSHelper::saveFileFormat(logPath.c_str(), &fformat, OFTrue);
  if (verboseMode)
  {
    if (cond == EC_Normal)
    {
      logstream->lockCerr() << "DIMSE communication log stored in in DICOM file '" << logPath.c_str() << "'." << endl;
      logstream->unlockCerr();
    } else {
      logstream->lockCerr() << "warning: unable to store DIMSE communication log in file '" << logPath.c_str() << "'." << endl;
      logstream->unlockCerr();
    }
  }

  logPath.clear();
}

void DVPSPrintSCP::dumpNMessage(T_DIMSE_Message &msg, DcmItem *dataset, OFBool outgoing)
{
    if (! dumpMode) return;

    ostream &outstream = logstream->lockCerr();
    if (outgoing)
    {
      outstream << endl << "===================== OUTGOING DIMSE MESSAGE ====================" << endl;
    } else {
      outstream << endl << "===================== INCOMING DIMSE MESSAGE ====================" << endl;
    }
    DIMSE_printMessage(outstream, msg, dataset);
    outstream << "======================= END DIMSE MESSAGE =======================" << endl << endl << flush;
    logstream->unlockCerr();
    return;
}

/*
 *  $Log: dvpsprt.cc,v $
 *  Revision 1.18  2004/02/04 15:57:49  joergr
 *  Removed acknowledgements with e-mail addresses from CVS log.
 *
 *  Revision 1.17  2003/09/05 10:38:34  meichel
 *  Print SCP now supports TLS connections and the Verification Service Class.
 *
 *  Revision 1.16  2003/06/04 12:30:28  meichel
 *  Added various includes needed by MSVC5 with STL
 *
 *  Revision 1.15  2002/04/16 14:02:22  joergr
 *  Added configurable support for C++ ANSI standard includes (e.g. streams).
 *
 *  Revision 1.14  2002/04/11 13:13:45  joergr
 *  Replaced direct call of system routines by new standard date and time
 *  functions.
 *
 *  Revision 1.13  2002/01/08 10:38:56  joergr
 *  Corrected spelling of function dcmGenerateUniqueIdentifier().
 *  Changed prefix of UIDs created for series and studies (now using constants
 *  SITE_SERIES_UID_ROOT and SITE_STUDY_UID_ROOT which are supposed to be used
 *  in these cases).
 *
 *  Revision 1.12  2001/11/28 13:56:59  joergr
 *  Check return value of DcmItem::insert() statements where appropriate to
 *  avoid memory leaks when insert procedure fails.
 *
 *  Revision 1.11  2001/10/12 13:46:56  meichel
 *  Adapted dcmpstat to OFCondition based dcmnet module (supports strict mode).
 *
 *  Revision 1.10  2001/09/28 13:49:37  joergr
 *  Added "#include <iomanip.h>" to keep gcc 3.0 quiet.
 *
 *  Revision 1.9  2001/09/26 15:36:30  meichel
 *  Adapted dcmpstat to class OFCondition
 *
 *  Revision 1.8  2001/06/01 15:50:35  meichel
 *  Updated copyright header
 *
 *  Revision 1.7  2001/05/25 10:07:58  meichel
 *  Corrected some DIMSE error status codes for Print SCP
 *
 *  Revision 1.6  2000/09/06 08:55:38  meichel
 *  Updated Print SCP to accept and silently ignore group length attributes.
 *
 *  Revision 1.5  2000/07/12 16:39:42  meichel
 *  Print SCP now writes PrinterCharacteristicsSequence when saving Stored Prints.
 *
 *  Revision 1.4  2000/06/08 10:44:36  meichel
 *  Implemented Referenced Presentation LUT Sequence on Basic Film Session level.
 *    Empty film boxes (pages) are not written to file anymore.
 *
 *  Revision 1.3  2000/06/07 13:17:28  meichel
 *  added binary and textual log facilities to Print SCP.
 *
 *  Revision 1.2  2000/06/02 16:01:04  meichel
 *  Adapted all dcmpstat classes to use OFConsole for log and error output
 *
 *  Revision 1.1  2000/05/31 12:58:12  meichel
 *  Added initial Print SCP support
 *
 *
 */
