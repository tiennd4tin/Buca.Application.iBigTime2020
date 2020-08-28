/***********************************************************************
 * <copyright file="OpeningAccountEntriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.View.OpeningAccountEntry;
using Buca.Application.iBigTime2020.View.OpeningInventoryEntry;

namespace Buca.Application.iBigTime2020.Presenter.OpeningInventory
{
    /// <summary>
    /// OpeningAccountEntriesPresenter
    /// </summary>
    public class OpeningInventoryEntriesPresenter : Presenter<IOpeningInventoryEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningInventoryEntriesPresenter(IOpeningInventoryEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        //public void Display(string accountCode)
        //{
        //    View.OpeningInventoryEntries = Model.GetOpeningInventoryEntries(accountCode);
        //  //  var openingInventoryEntry = Model.GetOpeningInventoryEntries(accountCode);
        //}
        public void Display(string accountNumber)
        {
            View.OpeningInventoryEntries = Model.GetOpeningInventoryEntries(accountNumber);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns> 
        public string Save(IList<OpeningInventoryEntryModel> openingInventoryEntries, string accountNumber)
        {
            return Model.UpdateOpeningInventoryEntry(openingInventoryEntries, accountNumber);
        }
        public string Save(string accountNumber)
        {
            //.Trường họp xóa hết dòng.  View.OpeningAccountEntries.Count==1
            return Model.DeleteAllRowInGridOpenInventoryEntry(accountNumber);
        }
    }
}
