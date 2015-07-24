﻿// Copyright (c) Microsoft. All rights reserved.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Devices.IoT
{
    public interface IEmptyEventArgs { }
    public class EmptyEventArgs : IEmptyEventArgs
    {
        static private EmptyEventArgs instance;
        static public EmptyEventArgs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmptyEventArgs();
                }
                return instance;
            }
        }
    }
}
