/***********************************************************************
 * <copyright file="S31HModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, November 24, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, November 24, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// Class S31HModel.
    /// </summary>
    public class S31HModel
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }
        /// <summary>
        /// Gets or sets the kind of the account category.
        /// </summary>
        /// <value>The kind of the account category.</value>
        public int AccountCategoryKind { get; set; }
        /// <summary>
        /// Gets or sets the accounting object code.
        /// </summary>
        /// <value>The accounting object code.</value>
        public string AccountingObjectCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName { get; set; }
        /// <summary>
        /// Gets or sets the Budget Source identifier.
        /// </summary>
        /// <value>The Budget Source identifier.</value>
        public string BudgetSourceID { get; set; }
        /// <summary>
        /// Gets or sets the name of the Budget Source.
        /// </summary>
        /// <value>The name of the Budget Source.</value>
        public string BudgetSourceName { get; set; }
        /// <summary>
        /// Gets or sets the Fund Structure identifier.
        /// </summary>
        /// <value>The Fund Structure identifier.</value>
        public string FundStructureID { get; set; }
        /// <summary>
        /// Gets or sets the name of Fund Structure.
        /// </summary>
        /// <value>The name of Fund Structure.</value>
        public string FundStructureName { get; set; }
        /// <summary>
        /// Gets or sets the code of Budget Chapter.
        /// </summary>
        /// <value>The code of Budget Chapter.</value>
        public string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the name of Budget Chapter.
        /// </summary>
        /// <value>The name of Budget Chapter.</value>
        public string BudgetChapterName { get; set; }
        /// <summary>
        /// Gets or sets the code of Budget Kind Item .
        /// </summary>
        /// <value>The code of Budget Kind Item.</value>
        public string BudgetKindItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of Budget Kind Item .
        /// </summary>
        /// <value>The name of Budget Kind Item.</value>
        public string BudgetKindItemName { get; set; }
        /// <summary>
        /// Gets or sets the code of Budget Item.
        /// </summary>
        /// <value>The code of Budget Item.</value>
        public string BudgetItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of Budget Item.
        /// </summary>
        /// <value>The name of Budget Item..</value>
        public string BudgetItemName { get; set; }
        /// <summary>
        /// Gets or sets the Project identifier .
        /// </summary>
        /// <value>The Project identifier.</value>
        public string ProjectID { get; set; }
        /// <summary>
        /// Gets or sets the name of project.
        /// </summary>
        /// <value>The name of project.</value>
        public string ProjectName { get; set; }
        /// <summary>
        /// Gets or sets the Contract indentifier.
        /// </summary>
        /// <value>The Contract indentifier.</value>
        public string ContractID { get; set; }
        /// <summary>
        /// Gets or sets the name of Contract.
        /// </summary>
        /// <value>The name of Contract.</value>
        public string ContractName { get; set; }
        /// <summary>
        /// Gets or sets the Bank identifier .
        /// </summary>
        /// <value>The Bank identifier.</value>
        public string BankID { get; set; }
        /// <summary>
        /// Gets or sets the name of Bank.
        /// </summary>
        /// <value>The name of Bank.</value>
        public string BankName { get; set; }
        /// <summary>
        /// Gets or sets the Activity identifier .
        /// </summary>
        /// <value>The Activity Identifier .</value>
        public string ActivityId { get; set; }
        /// <summary>
        /// Gets or sets the name of Activity .
        /// </summary>
        /// <value>The name of Activity.</value>
        public string ActivityName { get; set; }
        /// <summary>
        /// Gets or sets the Capital Plan identifier.
        /// </summary>
        /// <value>The Capital Plan identifier.</value>
        public string CapitalPlanID { get; set; }
        /// <summary>
        /// Gets or sets the name of Capital Plan.
        /// </summary>
        /// <value>The name of Capital Plan.</value>
        public string CapitalPlanName { get; set; }
        /// <summary>
        /// Gets or sets the code of Currency.
        /// </summary>
        /// <value>The code of Currency.</value>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the FixedAsset idenfitier.
        /// </summary>
        /// <value>The FixedAsset idenfitier.</value>
        public string FixedAssetId { get; set; }
        /// <summary>
        /// Gets or sets the name of FixedAsset.
        /// </summary>
        /// <value>The name of FixedAsset.</value>
        public string FixedAssetName { get; set; }
        /// <summary>
        /// Gets or sets the Inventory Item idenfiter.
        /// </summary>
        /// <value>The Inventory Item idenfiter.</value>
        public string InventoryItemId { get; set; }
        /// <summary>
        /// Gets or sets the name of Inventory Item.
        /// </summary>
        /// <value>The name of Inventory Item.</value>
        public string InventoryItemName { get; set; }
        /// <summary>
        /// Gets or sets the name of Currency.
        /// </summary>
        /// <value>The name of Currency.</value>
        public string CurrencyName { get; set; }
        /// <summary>
        /// Gets or sets the debit amount.
        /// </summary>
        /// <value>The debit amount.</value>
        public decimal DebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the credit amount.
        /// </summary>
        /// <value>The credit amount.</value>
        public decimal CreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the closing debit amount.
        /// </summary>
        /// <value>The closing debit amount.</value>
        public decimal ClosingDebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the closing credit amount.
        /// </summary>
        /// <value>The closing credit amount.</value>
        public decimal ClosingCreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>The type of the order.</value>
        public int OrderType { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public string SortOrder { get; set; }

        public string CorrespondingAccountNumber { get; set; }

        public string Description { get; set; }

    }
}
