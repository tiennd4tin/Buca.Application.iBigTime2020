/***********************************************************************
 * <copyright file="InventoryItemsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory
{
    /// <summary>
    /// Class InventoryItemsPresenter.
    /// </summary>
    public class InventoryItemCategoriesPresenter : Presenter<IInventoryItemCategoriesView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemCategoriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InventoryItemCategoriesPresenter(IInventoryItemCategoriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        public void DisplayByIsTool(bool isTool)
        {
            View.InventoryItemCategories = Model.GetInventoryItemCategoriesByIsTool(isTool);
        }

        /// <summary>
        /// Displays the by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByIsTool(bool isTool, bool isActive)
        {
            View.InventoryItemCategories = Model.GetInventoryItemCategoriesByIsTool(isTool, isActive);
        }
        public void Display( bool isActive)
        {
            View.InventoryItemCategories = Model.GetInventoryItemCategories(isActive);
        }
    }
}