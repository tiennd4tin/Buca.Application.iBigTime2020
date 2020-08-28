/***********************************************************************
 * <copyright file="IInventoryItemsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemCategoriesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IInventoryItemCategoriesView : IView
    {
        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        IList<InventoryItemCategoryModel> InventoryItemCategories { set; }
    }
}
