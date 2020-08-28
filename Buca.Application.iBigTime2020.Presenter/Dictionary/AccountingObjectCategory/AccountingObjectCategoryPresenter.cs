using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory
{
    public class AccountingObjectCategoryPresenter : Presenter<IAccountingObjectCategoryView>
    {
        public AccountingObjectCategoryPresenter(IAccountingObjectCategoryView view)
            : base(view)
        {
        }

        public void Display(string accountingObjectCategoryId)
        {
            if (accountingObjectCategoryId == null)
            {
                View.AccountingObjectCategoryId = null;
                return;
            }
            ;
        }

        public string Save()
        {
            var accountingObject = new AccountingObjectCategoryModel
            {

            };
            if (View.AccountingObjectCategoryId == null)
                return null;
            return null;
        }
    }
}
