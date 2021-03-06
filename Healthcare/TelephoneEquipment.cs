#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections;
using System.Text;

using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare {

    /// <summary>
    /// TelephoneEquipment enumeration - HL7 2.9.55.3
    /// </summary>
    [EnumValueClass(typeof(TelephoneEquipmentEnum))]
    public enum TelephoneEquipment
	{
        /// <summary>
        /// Telephone
        /// </summary>
        [EnumValue("Telephone")]
        PH,

        /// <summary>
        /// Cell phone
        /// </summary>
        [EnumValue("Cellphone")]
        CP,

        /// <summary>
        /// Fax
        /// </summary>
        [EnumValue("Fax")]
        FX,

        /// <summary>
        /// Pager
        /// </summary>
        [EnumValue("Pager")]
        BP
	}
}