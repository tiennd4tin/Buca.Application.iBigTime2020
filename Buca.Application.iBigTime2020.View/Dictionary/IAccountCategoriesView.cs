/***********************************************************************
 * <copyright file="IAccountCategoriesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
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
    /// Interface IAccountCategoriesView
    /// </summary>
    public interface IAccountCategoriesView : IView
    {
        /// <summary>
        /// Sets the account categories.
        /// </summary>
        /// <value>The account categories.</value>
        IList<AccountCategoryModel> AccountCategories { set; }
    }
}
