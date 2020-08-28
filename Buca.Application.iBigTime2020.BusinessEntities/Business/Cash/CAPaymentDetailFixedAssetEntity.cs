/***********************************************************************
 * <copyright file="CAPaymentDetailFixedAssetEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, October 30, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Cash
{
    public class CAPaymentDetailFixedAssetEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAPaymentDetailFixedAssetEntity"/> class.
        /// </summary>
        public CAPaymentDetailFixedAssetEntity()
        {
            AddRule(new ValidateRequired("RefDetailId"));
            AddRule(new ValidateRequired("RefId"));
          //  AddRule(new ValidateRequired("InventoryItemId"));
          //  AddRule(new ValidateRequired("StockId"));
            AddRule(new ValidateRequired("DebitAccount"));
            AddRule(new ValidateRequired("CreditAccount"));
        }
        public string AutoBusinessId { get; set; }
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        public string RefDetailId { get; set; }
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>The fixed asset identifier.</value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>The credit account.</value>
        public string CreditAccount { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
        public decimal AmountOC { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>The tax rate.</value>
        public decimal? TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>The tax amount.</value>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the tax account.
        /// </summary>
        /// <value>The tax account.</value>
        public string TaxAccount { get; set; }

        /// <summary>
        /// Gets or sets the type of the inv.
        /// </summary>
        /// <value>The type of the inv.</value>
        public int? InvType { get; set; }

        /// <summary>
        /// Gets or sets the inv date.
        /// </summary>
        /// <value>The inv date.</value>
        public DateTime? InvDate { get; set; }

        /// <summary>
        /// Gets or sets the inv series.
        /// </summary>
        /// <value>The inv series.</value>
        public string InvSeries { get; set; }

        /// <summary>
        /// Gets or sets the inv no.
        /// </summary>
        /// <value>The inv no.</value>
        public string InvNo { get; set; }

        /// <summary>
        /// Gets or sets the purchase purpose identifier.
        /// </summary>
        /// <value>The purchase purpose identifier.</value>
        public string PurchasePurposeId { get; set; }

        /// <summary>
        /// Gets or sets the freight amount.
        /// </summary>
        /// <value>The freight amount.</value>
        public decimal FreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>The org price.</value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>The cash withdraw type identifier.</value>
        public int? CashWithdrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the fund identifier.
        /// </summary>
        /// <value>The fund identifier.</value>
        public string FundId { get; set; }

        /// <summary>
        /// Gets or sets the project activity identifier.
        /// </summary>
        /// <value>The project activity identifier.</value>
        public string ProjectActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project expense identifier.
        /// </summary>
        /// <value>The project expense identifier.</value>
        public string ProjectExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the list item identifier.
        /// </summary>
        /// <value>The list item identifier.</value>
        public string ListItemId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CAPaymentDetailFixedAssetModel"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>The budget detail item code.</value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        /// Gets or sets the invoice type code.
        /// </summary>
        /// <value>The invoice type code.</value>
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the org reference no.
        /// </summary>
        /// <value>The org reference no.</value>
        public string OrgRefNo { get; set; }

        /// <summary>
        /// Gets or sets the org reference date.
        /// </summary>
        /// <value>The org reference date.</value>
        public DateTime? OrgRefDate { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the project expense ea identifier.
        /// </summary>
        /// <value>The project expense ea identifier.</value>
        public string ProjectExpenseEAId { get; set; }

        /// <summary>
        /// Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>The project activity ea identifier.</value>
        public string ProjectActivityEAId { get; set; }

        public string BudgetExpenseId { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
    }
}
