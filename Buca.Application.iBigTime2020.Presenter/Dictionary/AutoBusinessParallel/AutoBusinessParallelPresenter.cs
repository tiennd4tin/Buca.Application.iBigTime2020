/***********************************************************************
 * <copyright file="AutoBusinessParallelEntity.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusinessParallel
{
    public class AutoBusinessParallelPresenter : Presenter<IAutoBusinessParallelView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessParallelPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoBusinessParallelPresenter(IAutoBusinessParallelView view)
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
                View.AutoBusinessParallelId = null;
                return;
            }

            var autoBusinessParallel = Model.GetAutoBusinessParallel(autoBusinessId);

            View.AutoBusinessParallelId = autoBusinessParallel.AutoBusinessParallelId;
            View.AutoBusinessCode = autoBusinessParallel.AutoBusinessCode;
            View.AutoBusinessName = autoBusinessParallel.AutoBusinessName;
            View.Description = autoBusinessParallel.Description;
            View.IsActive = autoBusinessParallel.IsActive;
            View.DebitAccount = autoBusinessParallel.DebitAccount;
            View.CreditAccount = autoBusinessParallel.CreditAccount;
            View.BudgetSourceId = autoBusinessParallel.BudgetSourceId;
            View.BudgetChapterCode = autoBusinessParallel.BudgetChapterCode;
            View.BudgetKindItemCode = autoBusinessParallel.BudgetKindItemCode;
            View.BudgetSubKindItemCode = autoBusinessParallel.BudgetSubKindItemCode;
            View.BudgetItemCode = autoBusinessParallel.BudgetItemCode;
            View.BudgetSubItemCode = autoBusinessParallel.BudgetSubItemCode;
            View.MethodDistributeId = autoBusinessParallel.MethodDistributeId;
            View.CashWithDrawTypeId = autoBusinessParallel.CashWithDrawTypeId;
            View.DebitAccountParallel = autoBusinessParallel.DebitAccountParallel;
            View.CreditAccountParallel = autoBusinessParallel.CreditAccountParallel;
            View.BudgetSourceIdParallel = autoBusinessParallel.BudgetSourceIdParallel;
            View.BudgetChapterCodeParallel = autoBusinessParallel.BudgetChapterCodeParallel;
            View.BudgetKindItemCodeParallel = autoBusinessParallel.BudgetKindItemCodeParallel;
            View.BudgetSubKindItemCodeParallel = autoBusinessParallel.BudgetSubKindItemCodeParallel;
            View.BudgetItemCodeParallel = autoBusinessParallel.BudgetItemCodeParallel;
            View.BudgetSubItemCodeParallel = autoBusinessParallel.BudgetSubItemCodeParallel;
            View.MethodDistributeIdParallel = autoBusinessParallel.MethodDistributeIdParallel;
            View.CashWithDrawTypeIdParallel = autoBusinessParallel.CashWithDrawTypeIdParallel;
            View.SortOrder = autoBusinessParallel.SortOrder;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var autoBusiness = new AutoBusinessParallelModel()
            {
                AutoBusinessParallelId = View.AutoBusinessParallelId,
                AutoBusinessCode = View.AutoBusinessCode,
                AutoBusinessName = View.AutoBusinessName,
                Description = View.Description,
                IsActive = View.IsActive,
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
                DebitAccountParallel = View.DebitAccountParallel,
                CreditAccountParallel = View.CreditAccountParallel,
                BudgetSourceIdParallel = View.BudgetSourceIdParallel,
                BudgetChapterCodeParallel = View.BudgetChapterCodeParallel,
                BudgetKindItemCodeParallel = View.BudgetKindItemCodeParallel,
                BudgetSubKindItemCodeParallel = View.BudgetSubKindItemCodeParallel,
                BudgetItemCodeParallel = View.BudgetItemCodeParallel,
                BudgetSubItemCodeParallel = View.BudgetSubItemCodeParallel,
                MethodDistributeIdParallel = View.MethodDistributeIdParallel,
                CashWithDrawTypeIdParallel = View.CashWithDrawTypeIdParallel,
                SortOrder = View.SortOrder
            };

            return View.AutoBusinessParallelId == null ? Model.AddAutoBusinessParallel(autoBusiness) : Model.UpdateAutoBusinessParallel(autoBusiness);
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
            return Model.DeleteAutoBusinessParallel(autoBusinessId);
        }
    }
}
