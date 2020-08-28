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
    public class InventoryItemdestinationsPresenter : Presenter<IInventoryItemsdestinationView>
    {

        /// <summary>
 
        /// <param name="view">The view.</param>
        public InventoryItemdestinationsPresenter(IInventoryItemsdestinationView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
   
        public void DisplaybyInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber)
        {
            View.InventoryItemdestinations = Model.GetInventoryItemsByInventoryItemdestinations(inventoryItemId, RefDate, RefOrder, UnitPriceDecimalDigitNumber);
        }

      
    }
}