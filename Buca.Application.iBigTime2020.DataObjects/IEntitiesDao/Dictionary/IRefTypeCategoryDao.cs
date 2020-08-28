﻿/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IRefTypeCategoryDao
    /// </summary>
    public interface IRefTypeCategoryDao
    {
        /// <summary>
        /// Gets the reference type category by reference type category identifier.
        /// </summary>
        /// <param name="reftypeCategoryId">The reftype category identifier.</param>
        /// <returns>RefTypeCategoryEntity.</returns>
        RefTypeCategoryEntity GetRefTypeCategoryByRefTypeCategoryId(int reftypeCategoryId);
    }
}
