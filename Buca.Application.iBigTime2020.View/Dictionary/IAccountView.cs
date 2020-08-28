/***********************************************************************
 * <copyright file="IAccountView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms.VisualStyles;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IAccountView
    /// </summary>
    public interface IAccountView : IView
    {
        string AccountId { get; set; }

        string AccountNumber { get; set; }

        string AccountCategoryId { get; set; }

        string ParentId { get; set; }

        string AccountName { get; set; }

        string AccountForeignName { get; set; }

        string Description { get; set; }

        int AccountCategoryKind { get; set; }

        bool DetailByBudgetSource { get; set; }

        bool DetailByBudgetChapter { get; set; }

        bool DetailByBudgetKindItem { get; set; }

        bool DetailByBudgetItem { get; set; }

        bool DetailByBudgetSubItem { get; set; }

        bool DetailByMethodDistribute { get; set; }

        bool DetailByAccountingObject { get; set; }

        bool DetailByActivity { get; set; }

        bool DetailByProject { get; set; }

        bool DetailByTask { get; set; }

        bool DetailBySupply { get; set; }

        bool DetailByInventoryItem { get; set; }

        bool DetailByFixedAsset { get; set; }

        bool DetailByFund { get; set; }

        bool DetailByBankAccount { get; set; }

        bool DetailByProjectActivity { get; set; }

        bool DetailByInvestor { get; set; }

        int Grade { get; set; }

        bool IsParent { get; set; }

        bool IsActive { get; set; }

        bool IsDisplayOnAccountBalanceSheet { get; set; }

        bool IsDisplayBalanceOnReport { get; set; }

        bool DetailByCurrency { get; set; }
        bool DetailByBudgetExpense { get; set; }
        bool DetailByExpense { get; set; }
        bool DetailByContract { get; set; }
        bool DetailByCapitalPlan { get; set; }
    }
}
