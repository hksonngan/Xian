/*
 *
 *  Copyright (C) 1994-2004, OFFIS
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
 *  Module:  dcmdata
 *
 *  Author:  Andrew Hewett
 *
 *  Purpose: 
 *
 *  Last Update:      $Author: joergr $
 *  Update Date:      $Date: 2004/02/13 12:45:53 $
 *  CVS/RCS Revision: $Revision: 1.12 $
 *  Status:           $State: Exp $
 *
 *  CVS/RCS Log at end of file
 *
 */

#include "dcdict.h"

/* There is no builtin data dictionary */
const char* dcmBuiltinDictBuildDate = NULL;

void
DcmDataDictionary::loadBuiltinDictionary()
{
    /*
    ** Empty Stub.
    **
    ** We don't want a builtin data dictionary or
    ** it is not yet created.
    ** A complete builtin dictionary can be created 
    ** by mkdictbi (see mkdictbi.cc)
    */
}

/*
 * CVS/RCS Log:
 * $Log: dcdictbi.cc,v $
 * Revision 1.12  2004/02/13 12:45:53  joergr
 * Updated copyright header.
 *
 * Revision 1.5  2001/06/01 15:49:02  meichel
 * Updated copyright header
 *
 * Revision 1.4  2000/04/14 16:14:46  meichel
 * Minor changes for thread safety.
 *
 * Revision 1.3  2000/03/08 16:26:33  meichel
 * Updated copyright header.
 *
 * Revision 1.2  1999/03/31 09:25:24  meichel
 * Updated copyright header in module dcmdata
 *
 *
 */
