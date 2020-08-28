using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory
{
    public class AccountingObjectCategoriesPresenter : Presenter<IAccountingObjectCategoriesView>
    {
        public AccountingObjectCategoriesPresenter(IAccountingObjectCategoriesView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AccountingObjectCategories = Model.GetAccountingObjectCategories();
        }
    }
}
