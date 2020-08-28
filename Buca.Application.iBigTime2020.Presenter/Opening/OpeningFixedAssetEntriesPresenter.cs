/***********************************************************************
 * <copyright file="OpeningFixedAssetEntriesPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.View.OpeningFixedAssetEntry;

namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// Class OpeningFixedAssetEntriesPresenter.
    /// </summary>
   public class OpeningFixedAssetEntriesPresenter: Presenter<IOpeningFixedAssetEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningFixedAssetEntriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
       public OpeningFixedAssetEntriesPresenter(IOpeningFixedAssetEntriesView view)
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
        public string Save()
        {

            var openingFixedAssetEntries = new List<OpeningFixedAssetEntryModel>();
            foreach (var openingFixedAssetEntry in View.OpeningFixedAssetEntries)
            {
                openingFixedAssetEntries.Add(openingFixedAssetEntry);
            }
            return Model.UpdateOpeningFixedAssetEntriesDetail(openingFixedAssetEntries);
        }
    }
}
