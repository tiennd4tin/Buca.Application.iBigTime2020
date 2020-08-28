/***********************************************************************
 * <copyright file="OpeningFixedAssetEntryPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, April 20, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.View.OpeningFixedAssetEntry;

namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// Class OpeningFixedAssetEntryPresenter.
    /// </summary>
    public class OpeningFixedAssetEntryPresenter : Presenter<IOpeningFixedAssetEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntriesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningFixedAssetEntryPresenter(IOpeningFixedAssetEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.OpeningFixedAssetEntries = Model.GetOpeningFixedAssetEntries();
        }

        /// <summary>
        /// Displays the specified account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        public void Display(string accountNumber)
        {
            var openingFixedAssetEntries = Model.GetOpeningFixedAssetEntriesByAccountNumber(accountNumber);
            View.OpeningFixedAssetEntries = openingFixedAssetEntries == null ? new List<OpeningFixedAssetEntryModel>() : openingFixedAssetEntries;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntries)
        {
            return Model.UpdateOpeningFixedAssetEntries(openingFixedAssetEntries);
           
        }

        public string Save(OpeningFixedAssetEntryModel openingFixedAssetEntry)
        {
               return Model.UpdateOpeningFixedAssetEntry(openingFixedAssetEntry);
        }
    }
}
