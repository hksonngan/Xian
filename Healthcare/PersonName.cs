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

using Iesi.Collections;
using ClearCanvas.Enterprise.Core;


namespace ClearCanvas.Healthcare {


    /// <summary>
    /// Implements a simplified version of the HL7 XPN (Extended Person Name) data type
    /// </summary>
	public partial class PersonName : IFormattable
	{
        private void CustomInitialize()
        {
        }

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
        {
            //TODO: honour format string

            StringBuilder sb = new StringBuilder();
            sb.Append(_familyName).Append(",");

            if (!string.IsNullOrEmpty(_prefix))
                sb.Append(" ").Append(_prefix);

            sb.Append(" ").Append(_givenName);

            if (!string.IsNullOrEmpty(_middleName))
                sb.Append(" ").Append(_middleName);

            if (!string.IsNullOrEmpty(_suffix))
                sb.Append(" ").Append(_suffix);

            return sb.ToString();
        }

        #endregion

        public override string ToString()
        {
            return this.ToString(null, null);
        }
    }
}