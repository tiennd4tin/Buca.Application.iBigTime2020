/***********************************************************************
 * <copyright file="openingsupplyentrypresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.View.OpeningSupplyEntry;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;

namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// Class OpeningSupplyEntryPresenter.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.OpeningSupplyEntry.IOpeningSupplyEntryView}" />
    public class OpeningSupplyEntryPresenter : Presenter<IOpeningSupplyEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSupplyEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningSupplyEntryPresenter(IOpeningSupplyEntryView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(string refId)
        {
            var openingSupplyEntry = Model.GetOpeningSupplyEntryVoucher(refId, true) ?? new OpeningSupplyEntryModel();
            View.RefId = openingSupplyEntry.RefId;
            View.RefType = openingSupplyEntry.RefType;
            View.PostedDate = openingSupplyEntry.PostedDate;
            View.CurrencyCode = openingSupplyEntry.CurrencyCode;
            View.ExchangeRate = openingSupplyEntry.ExchangeRate;
            View.AccountNumber = openingSupplyEntry.AccountNumber;
            View.InventoryItemId = openingSupplyEntry.InventoryItemId;
            View.DepartmentId = openingSupplyEntry.DepartmentId;
            View.BudgetChapterCode = openingSupplyEntry.BudgetChapterCode;
            View.Quantity = openingSupplyEntry.Quantity;
            View.UnitPriceOC = openingSupplyEntry.UnitPriceOC;
            View.UnitPrice = openingSupplyEntry.UnitPrice;
            View.AmountOC = openingSupplyEntry.AmountOC;
            View.Amount = openingSupplyEntry.Amount;
            View.PostVersion = openingSupplyEntry.PostVersion;
            View.EditVersion = openingSupplyEntry.EditVersion;
            View.SortOrder = openingSupplyEntry.SortOrder;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string refId)
        {
            return Model.DeleteOpeningSupplyEntry(refId);
        }

    }
}
