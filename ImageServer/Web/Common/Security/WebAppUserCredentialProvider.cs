#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.ImageServer.Web.Common.Security
{
    /// <summary>
    /// Class implementing <see cref="IUserCredentialsProvider"/> to provide information about
    /// the current user in the web application.
    /// </summary>
    public class WebAppUserCredentialProvider : IUserCredentialsProvider
    {
        #region IUserCredentialsProvider Members

        public string UserName
        {
            get
            {
                if (Thread.CurrentPrincipal is DefaultPrincipal)
                    return Thread.CurrentPrincipal.Identity.Name;

                return SessionManager.Current.User.Identity.Name;
            }
        }

        public string SessionTokenId
        {
            get
            {
                if (Thread.CurrentPrincipal is DefaultPrincipal)
                    return (Thread.CurrentPrincipal as DefaultPrincipal).SessionToken.Id;
                return SessionManager.Current.Credentials.SessionToken.Id;
            }
        }

        #endregion
    }
}