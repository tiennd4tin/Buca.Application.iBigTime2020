/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness
{
    public class AutoBusinessPresenter : Presenter<IAutoBusinessView>
    {
        public AutoBusinessPresenter(IAutoBusinessView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category Identifier.
        /// </summary>
        /// <param name="autoBusinessId">The automatic business identifier.</param>
        public void Display(string autoBusinessId)
        {
            if (autoBusinessId == null)
            {
                View.AutoBusinessId = null;
                return;
            }

            var autoBusiness = Model.GetAutoBusiness(autoBusinessId);

            View.AutoBusinessId = autoBusiness.AutoBusinessId;
            View.AutoBusinessCode = autoBusiness.AutoBusinessCode;
            View.AutoBusinessName = autoBusiness.AutoBusinessName;
            View.RefTypeId = autoBusiness.RefTypeId;
            View.DebitAccount = autoBusiness.DebitAccount;
            View.CreditAccount = autoBusiness.CreditAccount;
            View.BudgetSourceId = autoBusiness.BudgetSourceId;
            View.BudgetChapterCode = autoBusiness.BudgetChapterCode;
            View.BudgetKindItemCode = autoBusiness.BudgetKindItemCode;
            View.BudgetSubKindItemCode = autoBusiness.BudgetSubKindItemCode;
            View.BudgetItemCode = autoBusiness.BudgetItemCode;
            View.BudgetSubItemCode = autoBusiness.BudgetSubItemCode;
            View.MethodDistributeId = autoBusiness.MethodDistributeId;
            View.CashWithDrawTypeId = autoBusiness.CashWithDrawTypeId;
            View.Description = autoBusiness.Description;
            View.IsActive = autoBusiness.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var autoBusiness = new AutoBusinessModel()
                {
                    AutoBusinessId = View.AutoBusinessId,
                    AutoBusinessCode = View.AutoBusinessCode,
                    AutoBusinessName = View.AutoBusinessName,
                    RefTypeId = View.RefTypeId,
                    DebitAccount = View.DebitAccount,
                    CreditAccount = View.CreditAccount,
                    BudgetSourceId = View.BudgetSourceId,
                    BudgetChapterCode = View.BudgetChapterCode,
                    BudgetKindItemCode = View.BudgetKindItemCode,
                    BudgetSubKindItemCode = View.BudgetSubKindItemCode,
                    BudgetItemCode = View.BudgetItemCode,
                    BudgetSubItemCode = View.BudgetSubItemCode,
                    MethodDistributeId = View.MethodDistributeId,
                    CashWithDrawTypeId = View.CashWithDrawTypeId,
                    Description = View.Description,
                    IsActive = View.IsActive
                };

            if (View.AutoBusinessId == null)
                return Model.AddAutoBusiness(autoBusiness);
            return Model.UpdateAutoBusiness(autoBusiness);
        }

        /// <summary>
        /// Deletes the specified account category Identifier.
        /// </summary>
        /// <param name="autoBusinessId">The account tranfer Identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string Delete(string autoBusinessId)
        {
            return Model.DeleteAutoBusiness(autoBusinessId);
        }
    }
}
