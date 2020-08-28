/***********************************************************************
 * <copyright file="OpeningAccountEntryPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.View.OpeningAccountEntry;


namespace Buca.Application.iBigTime2020.Presenter.Opening
{
    /// <summary>
    /// class OpeningAccountEntryPresenter
    /// </summary>
    public class OpeningAccountEntryPresenter : Presenter<IOpeningAccountEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningAccountEntryPresenter(IOpeningAccountEntryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        //public string Save()
        //{
        //    var openingAccountEntryModel = new OpeningAccountEntryModel
        //    {
        //        RefID = View.RefID,
        //        RefType = View.RefType,
        //        PostedDate = View.PostedDate,
        //        CurrencyId = View.CurrencyId,
        //        ExchangeRate = View.ExchangeRate,
        //        AccountNumber = View.AccountNumber,
        //        AccBeginningDebitAmountOC = View.AccBeginningDebitAmountOC,
        //        AccBeginningDebitAmount = View.AccBeginningDebitAmount,
        //        AccBeginningCreditAmountOC = View.AccBeginningCreditAmountOC,
        //        AccBeginningCreditAmount = View.AccBeginningCreditAmount,
        //        DebitAmountOC = View.DebitAmountOC,
        //        DebitAmount = View.DebitAmount,
        //        CreditAmountOC = View.CreditAmountOC,
        //        CreditAmount = View.CreditAmount,
        //        BudgetSourceId = View.BudgetSourceId,
        //        BudgetChapterCode = View.BudgetChapterCode,
        //        BudgetKindItemCode = View.BudgetKindItemCode,
        //        BudgetSubKindItemCode = View.BudgetSubKindItemCode,
        //        BudgetItemCode = View.BudgetItemCode,
        //        BudgetSubItemCode = View.BudgetSubItemCode,
        //        MethodDistributeId = View.MethodDistributeId,
        //        CashWithdrawTypeId = View.CashWithdrawTypeId,
        //        AccountingObjectId = View.AccountingObjectId,
        //        ActivityId = View.ActivityId,
        //        ProjectId = View.ProjectId,
        //        TaskId = View.TaskId,
        //        BankId = View.BankId,
        //        Approved = View.Approved,
        //        SortOrder = View.SortOrder,
        //        BudgetDetailItemCode = View.BudgetDetailItemCode,
        //        ProjectActivityId = View.ProjectActivityId,
        //        ApprovedDate = View.ApprovedDate,
        //        FundStructureId = View.FundStructureId,
        //        ProjectActivityEAID = View.ProjectActivityEAID,
        //        BudgetProvideCode = View.BudgetProvideCode,

        //    };
        //    if (View.RefID == null)
        //        return Model.AddOpeningAccountEntry(openingAccountEntry);
        //    return Model.UpdateOpeningAccountEntry(openingAccountEntry);
        //}

        /// <summary>
        /// Displays the specified account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void Display(string accountCode)
        {
            //var openingAccountEntry = Model.GetOpeningAccountEntry(accountCode);

            //View.RefId = openingAccountEntry.RefId;
            //View.RefTypeId = openingAccountEntry.RefTypeId;
            //View.PostedDate = openingAccountEntry.PostedDate;
            //View.AccountCode = openingAccountEntry.AccountCode;
            //View.TotalAccountBeginningDebitAmountOC = openingAccountEntry.TotalAccountBeginningDebitAmountOC;
            //View.TotalAccountBeginningCreditAmountOC = openingAccountEntry.TotalAccountBeginningCreditAmountOC;
            //View.TotalDebitAmountOC = openingAccountEntry.TotalDebitAmountOC;
            //View.TotalCreditAmountOC = openingAccountEntry.TotalCreditAmountOC;
            //View.TotalAccountBeginningDebitAmountExchange = openingAccountEntry.TotalAccountBeginningDebitAmountExchange;
            //View.TotalAccountBeginningCreditAmountExchange = openingAccountEntry.TotalAccountBeginningCreditAmountExchange;
            //View.TotalDebitAmountExchange = openingAccountEntry.TotalDebitAmountExchange;
            //View.TotalCreditAmountExchange = openingAccountEntry.TotalCreditAmountExchange;
            //View.OpeningAccountEntryDetails = openingAccountEntry.OpeningAccountEntryDetails;
        }
    }
}
