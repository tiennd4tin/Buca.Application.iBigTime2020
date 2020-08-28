/***********************************************************************
 * <copyright file="C213NSModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, December 21, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, December 21, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    /// <summary>
    /// Class C213NSModel.
    /// </summary>
    public class C213NSModel
    {
        /// <summary>
        /// Gets or sets the reference identifier sort order.
        /// </summary>
        /// <value>The reference identifier sort order.</value>
        public int RefIDSortOrder { get; set; }
        /// <summary>
        /// Gets or sets the budget year.
        /// </summary>
        /// <value>The budget year.</value>
        public int BudgetYear { get; set; }
        /// <summary>
        /// Gets or sets the name of the project investment.
        /// </summary>
        /// <value>The name of the project investment.</value>
        public string ProjectInvestmentName { get; set; }
        /// <summary>
        /// Gets or sets the project investment code.
        /// </summary>
        /// <value>The project investment code.</value>
        public string ProjectInvestmentCode { get; set; }
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
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount { get; set; }
        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName { get; set; }
        /// <summary>
        /// Gets or sets the contract frame no.
        /// </summary>
        /// <value>The contract frame no.</value>
        public string ContractFrameNo { get; set; }
        /// <summary>
        /// Gets or sets the real contract no.
        /// </summary>
        /// <value>The real contract no.</value>
        public string RealContractNo { get; set; }
        /// <summary>
        /// Gets or sets the contract no.
        /// </summary>
        /// <value>The contract no.</value>
        public string ContractNo { get; set; }
        /// <summary>
        /// Gets or sets the sign date.
        /// </summary>
        /// <value>The sign date.</value>
        public DateTime SignDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest adjustment.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest adjustment; otherwise, <c>false</c>.</value>
        public bool IsSuggestAdjustment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest supplement.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest supplement; otherwise, <c>false</c>.</value>
        public bool IsSuggestSupplement { get; set; }
        /// <summary>
        /// Gets or sets the org provider bank account.
        /// </summary>
        /// <value>The org provider bank account.</value>
        public string OrgProviderBankAccount { get; set; }
        /// <summary>
        /// Gets or sets the name of the org provider bank.
        /// </summary>
        /// <value>The name of the org provider bank.</value>
        public string OrgProviderBankName { get; set; }
        /// <summary>
        /// Gets or sets the adjustment provider bank account.
        /// </summary>
        /// <value>The adjustment provider bank account.</value>
        public string AdjustmentProviderBankAccount { get; set; }
        /// <summary>
        /// Gets or sets the name of the adjustment provider bank.
        /// </summary>
        /// <value>The name of the adjustment provider bank.</value>
        public string AdjustmentProviderBankName { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the bu commitment request reference no.
        /// </summary>
        /// <value>The bu commitment request reference no.</value>
        public string BUCommitmentRequestRefNo { get; set; }
        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>The kind of the budget source.</value>
        public int BudgetSourceKind { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign currency.
        /// </summary>
        /// <value><c>true</c> if this instance is foreign currency; otherwise, <c>false</c>.</value>
        public bool IsForeignCurrency { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; set; }
        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }
        /// <summary>
        /// Gets or sets the budget distribution code.
        /// </summary>
        /// <value>The budget distribution code.</value>
        public string BudgetDistributionCode { get; set; }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }
        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>The project code.</value>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Gets or sets the budget source property code.
        /// </summary>
        /// <value>The budget source property code.</value>
        public string BudgetSourcePropertyCode { get; set; }
        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets to budget sub item code.
        /// </summary>
        /// <value>To budget sub item code.</value>
        public string ToBudgetSubItemCode { get; set; }
        /// <summary>
        /// Gets or sets to budget distribution code.
        /// </summary>
        /// <value>To budget distribution code.</value>
        public string ToBudgetDistributionCode { get; set; }
        /// <summary>
        /// Gets or sets to budget chapter code.
        /// </summary>
        /// <value>To budget chapter code.</value>
        public string ToBudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets to budget sub kind item code.
        /// </summary>
        /// <value>To budget sub kind item code.</value>
        public string ToBudgetSubKindItemCode { get; set; }
        /// <summary>
        /// Gets or sets to project code.
        /// </summary>
        /// <value>To project code.</value>
        public string ToProjectCode { get; set; }
        /// <summary>
        /// Gets or sets to budget source property code.
        /// </summary>
        /// <value>To budget source property code.</value>
        public string ToBudgetSourcePropertyCode { get; set; }
        /// <summary>
        /// Gets or sets to currency identifier.
        /// </summary>
        /// <value>To currency identifier.</value>
        public string ToCurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets to amount oc.
        /// </summary>
        /// <value>To amount oc.</value>
        public decimal ToAmountOC { get; set; }
        /// <summary>
        /// Gets or sets to amount.
        /// </summary>
        /// <value>To amount.</value>
        public decimal ToAmount { get; set; }
        /// <summary>
        /// Gets or sets the de to amount oc.
        /// </summary>
        /// <value>The de to amount oc.</value>
        public decimal DeToAmountOC { get; set; }
        /// <summary>
        /// Gets or sets the de to amount.
        /// </summary>
        /// <value>The de to amount.</value>
        public decimal DeToAmount { get; set; }
        /// <summary>
        /// Gets or sets the remain amount oc.
        /// </summary>
        /// <value>The remain amount oc.</value>
        public decimal RemainAmountOC { get; set; }
        /// <summary>
        /// Gets or sets the remain amount.
        /// </summary>
        /// <value>The remain amount.</value>
        public decimal RemainAmount { get; set; }
        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>The part.</value>
        public int Part { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is blank part2.
        /// </summary>
        /// <value><c>true</c> if this instance is blank part2; otherwise, <c>false</c>.</value>
        public bool IsBlankPart2 { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is blank part3.
        /// </summary>
        /// <value><c>true</c> if this instance is blank part3; otherwise, <c>false</c>.</value>
        public bool IsBlankPart3 { get; set; }

        public string BudgetSourceCode { get; set; }

        public string BudgetCode { get; set; }
        public string BankOpen { get; set; }
    }
}
