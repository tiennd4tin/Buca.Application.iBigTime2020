﻿/***********************************************************************
 * <copyright file="ISiteView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 24 october 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.View.System
{

    public interface ILockView
    {
        string Content { get; set; }

        string LockDate { get; set; }

        bool IsLock { get; set; }
    }
}
