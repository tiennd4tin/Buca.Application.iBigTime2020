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

using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem
{
    /// <summary>
    /// Class InventoryItemsPresenter.
    /// </summary>
    public class InventoryItemsPresenter : Presenter<IInventoryItemsView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemCategoriesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InventoryItemsPresenter(IInventoryItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.InventoryItems = Model.GetInventoryItems();
        }

        /// <summary>
        /// Displays the by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByIsActive(bool isActive)
        {
            View.InventoryItems = Model.GetInventoryItemsByIsAtive(isActive);
        }

        /// <summary>
        /// Displays the by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        public void DisplayByIsTool(bool isTool)
        {
            View.InventoryItems = Model.GetInventoryItemsByIsTool(isTool);
        }

        /// <summary>
        /// Danh sách các vật tư + công cụ dụng cụ qua kho
        /// </summary>
        public void DisplayByIsToolAndIsStock(bool isActive)
        {
            var inventoryItems = Model.GetInventoryItemsByIsAtive(isActive);
            //View.InventoryItems = inventoryItems.Where(m =>  (m.IsStock.Equals(isStock) && m.IsTool) || (!m.IsTool && string.IsNullOrEmpty(m.DefaultStockId).Equals(!isStock))).ToList();
            View.InventoryItems = inventoryItems.Where(m => !string.IsNullOrEmpty(m.DefaultStockId)).ToList();
        }
        public void DisplayOpening(bool isActive)
        {
            View.InventoryItems  = Model.GetInventoryItemsByIsAtive(isActive);
            //View.InventoryItems = inventoryItems.Where(m =>  (m.IsStock.Equals(isStock) && m.IsTool) || (!m.IsTool && string.IsNullOrEmpty(m.DefaultStockId).Equals(!isStock))).ToList();
        }
        /// <summary>
        /// Displays the by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByIsToolAndIsActive(bool isTool, bool isActive)
        {
            View.InventoryItems = Model.GetInventoryItemsByIsToolAndIsActive(isTool, isActive);
        }

        /// <summary>
        /// Danh sách CCDC và hàng hóa qua kho, sử dụng, mã nhóm
        /// </summary>
        /// <param name="isTool"></param>
        /// <param name="isActive"></param>
        /// <param name="inventoryCategoryCod"></param>
        public void DisplayByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            View.InventoryItems = Model.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive, inventoryCategoryCode);
        }

        /// <summary>
        /// Displaybies the inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        public void DisplaybyInventoryCategoryCode(string inventoryCategoryCode)
        {
            View.InventoryItems = Model.GetInventoryItemsByInventoryCategoryCode(inventoryCategoryCode);
        }

        //public void DisplayByStock(int itemStockId, int refId, string postDate, string currencyCode)
        //{
        //    var postDateCurrent = DateTime.Parse(postDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        //    View.InventoryItems = Model.GetInventoryItemsByStock(itemStockId, refId, postDateCurrent, currencyCode);
        //}

        //public void DisplayByStock(int itemStockId)
        //{
        //    View.InventoryItems = Model.GetInventoryItemsByStock(itemStockId);
        //}

        //public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId) 
        //{
        //    return Model.GetInventoryItemsByStock(itemStockId);
        //}

        //public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId, int refId, string postDate, string currencyCode) 
        //{
        //    var postDateCurrent = DateTime.Parse(postDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        //    return Model.GetInventoryItemsByStock(itemStockId, refId, postDateCurrent, currencyCode);
        //}
    }
}