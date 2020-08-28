/***********************************************************************
 * <copyright file="SiteEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.System
{
    /// <summary>
    /// SiteEntity
    /// </summary>
    public class LockEntity : BusinessEntities
    {
        public LockEntity()
        {
        }


        public LockEntity(string content, string lockDate, bool isLock)
            : this()
        {
            Content = content;
            LockDate = lockDate;
            IsLock = isLock;

        }

        public string Content { get; set; }

        public string LockDate { get; set; }

        public bool IsLock { get; set; }

      
    }
}
