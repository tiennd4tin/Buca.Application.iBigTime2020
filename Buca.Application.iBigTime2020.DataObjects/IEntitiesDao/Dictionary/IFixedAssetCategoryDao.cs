﻿/***********************************************************************
 * <copyright file="IFixedAssetCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IFixedAssetCategoryDao
    {
        /// <summary>
        /// Gets the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        FixedAssetCategoryEntity GetFixedAssetCategory(string fixedAssetCategoryId);

        FixedAssetCategoryEntity GetFixedAssetCategorybyCode(string fixedAssetCategoryCode);

        /// <summary>
        /// Gets the fixed asset categorys.
        /// </summary>
        /// <returns></returns>
        List<FixedAssetCategoryEntity> GetFixedAssetCategories();

        //List<FixedAssetCategoryEntity> GetFixedAssetCategoriesComboCheck();

        ///// <summary>
        ///// Gets the fixed asset categorys for combo tree.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns></returns>
        //List<FixedAssetCategoryEntity> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId);

        ///// <summary>
        ///// Gets the fixed asset categorys active.
        ///// </summary>
        ///// <returns></returns>
        //List<FixedAssetCategoryEntity> GetFixedAssetCategoriesActive();

        ///// <summary>
        ///// Inserts the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns></returns>
        string InsertFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory);

        ///// <summary>
        ///// Updates the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns></returns>
        string UpdateFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory);

        ///// <summary>
        ///// Deletes the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns></returns>
        string DeleteFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory);
        string DeleteFixedAssetCategoryConvert();
    }
}
