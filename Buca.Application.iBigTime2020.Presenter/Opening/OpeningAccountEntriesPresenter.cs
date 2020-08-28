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
using Buca.Application.iBigTime2020.View.OpeningAccountEntry;


namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// OpeningAccountEntriesPresenter
    /// </summary>
    public class OpeningAccountEntriesPresenter : Presenter<IOpeningAccountEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningAccountEntriesPresenter(IOpeningAccountEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.OpeningAccountEntries = Model.GetOpeningAccountEntries();
        }
        public void Display(string accountNumber)
        {
            var openingAccountEntries = Model.GetOpeningAccountEntriesByAccountNumber(accountNumber);
            View.OpeningAccountEntries = openingAccountEntries==null?new List<OpeningAccountEntryModel>() : openingAccountEntries;
        }

        public string Save()
        {

            var openingAccountEntries = new List<OpeningAccountEntryModel>();
            if (View.OpeningAccountEntries.Count > 0)
            {
                foreach (var OpeningAccountEntry in View.OpeningAccountEntries)
                {
                    openingAccountEntries.Add(OpeningAccountEntry);
                }
            }
            return Model.UpdateOpeningAccountEntries(openingAccountEntries);
        }

        public string Save(string accountNumber)
        {
            //.Trường họp xóa hết dòng.  View.OpeningAccountEntries.Count==1
            var openingAccountEntryModel = Model.GetOpeningAccountEntriesByAccountNumber(accountNumber);
            return Model.DeleteOpeningAccountEntries(accountNumber);
        }
    }
}
