/***********************************************************************
 * <copyright file="AccountModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class AccountModel.
    /// </summary>
    public class AccountModel
    {

        public string AccountId { get; set; }

        public string AccountNumber { get; set; }

        public string AccountCategoryId { get; set; }

        public string ParentId { get; set; }

        public string AccountName { get; set; }

        public string AccountForeignName { get; set; }

        public string Description { get; set; }

        public int AccountCategoryKind { get; set; }

        public bool DetailByBudgetSource { get; set; }

        public bool DetailByBudgetChapter { get; set; }

        public bool DetailByBudgetKindItem { get; set; }

        public bool DetailByBudgetItem { get; set; }

        public bool DetailByBudgetSubItem { get; set; }

        public bool DetailByMethodDistribute { get; set; }

        public bool DetailByAccountingObject { get; set; }

        public bool DetailByActivity { get; set; }

        public bool DetailByProject { get; set; }

        public bool DetailByTask { get; set; }

        public bool DetailBySupply { get; set; }

        public bool DetailByInventoryItem { get; set; }

        public bool DetailByFixedAsset { get; set; }

        public bool DetailByFund { get; set; }

        public bool DetailByBankAccount { get; set; }

        public bool DetailByProjectActivity { get; set; }

        public bool DetailByInvestor { get; set; }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public bool IsActive { get; set; }

        public bool IsDisplayOnAccountBalanceSheet { get; set; }

        public bool IsDisplayBalanceOnReport { get; set; }

        public bool DetailByCurrency { get; set; }

        public bool DetailByBudgetExpense { get; set; }
        public bool DetailByContract { get; set; }
        public bool DetailByExpense { get; set; }
        public bool DetailByCapitalPlan { get; set; }

    }
}
