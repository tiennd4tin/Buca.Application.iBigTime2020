/***********************************************************************
 * <copyright file="AccountEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// class AccountEntity
    /// </summary>
    public class AccountEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class.
        /// </summary>
        public AccountEntity()
        {
            AddRule(new ValidateRequired("AccountNumber"));
            AddRule(new ValidateRequired("AccountName"));
        }
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
        public  bool DetailByCurrency { get; set; }
        public bool DetailByBudgetExpense { get; set; }
        public bool DetailByContract { get; set; }
        public bool DetailByExpense { get; set; }
        public bool DetailByCapitalPlan { get; set; }

        public AccountEntity(string accountId, string accountNumber, string accountCategoryId, string parentId, string accountName, string accountForeignName, string description,
            int accountCategoryKind, bool detailByBudgetSource, bool detailByBudgetChapter, bool detailByBudgetKindItem, bool detailByBudgetItem,
            bool detailByBudgetSubItem, bool detailByMethodDistribute, bool detailByAccountingObject, bool detailByActivity, bool detailByProject, 
            bool detailByTask, bool detailBySupply, bool detailByInventoryItem, bool detailByFixedAsset, bool detailByFund, bool detailByBankAccount,
            bool detailByProjectActivity, bool detailByInvestor, int grade, bool isParent, bool isActive, bool isDisplayOnAccountBalanceSheet, 
            bool isDisplayBalanceOnReport): this()
        {
            AccountId = accountId;

            AccountNumber = accountNumber;

            AccountCategoryId = accountCategoryId;

            ParentId = parentId;

            AccountName = accountName;

            AccountForeignName = accountForeignName;

            Description = description;

            AccountCategoryKind = accountCategoryKind;

            DetailByBudgetSource = detailByBudgetSource;

            DetailByBudgetChapter = detailByBudgetChapter;

            DetailByBudgetKindItem = detailByBudgetKindItem;

            DetailByBudgetItem = detailByBudgetItem;

            DetailByBudgetSubItem = detailByBudgetSubItem;

            DetailByMethodDistribute = detailByMethodDistribute;

            DetailByAccountingObject = detailByAccountingObject;

            DetailByActivity = detailByActivity;

            DetailByProject = detailByProject;

            DetailByTask = detailByTask;

            DetailBySupply = detailBySupply;

            DetailByInventoryItem = detailByInventoryItem;

            DetailByFixedAsset = detailByFixedAsset;

            DetailByFund = detailByFund;

            DetailByBankAccount = detailByBankAccount;

            DetailByProjectActivity = detailByProjectActivity;

            DetailByInvestor = detailByInvestor;

            Grade = grade;

            IsParent = isParent;

            IsActive = isActive;

            IsDisplayOnAccountBalanceSheet = isDisplayOnAccountBalanceSheet;

            IsDisplayBalanceOnReport = isDisplayBalanceOnReport;

        }
    }
}
