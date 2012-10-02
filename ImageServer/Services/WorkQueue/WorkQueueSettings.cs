﻿#region License

// Copyright (c) 2012, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearCanvas.ImageServer.Services.WorkQueue
{
    internal partial class WorkQueueSettings
    {
        public static WorkQueueSettings Instance
        {
            get
            {
                return WorkQueueSettings.Default;
            }
        }
    }
}
