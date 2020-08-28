﻿/***********************************************************************
 * <copyright file="FAIncrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAssetIncrement
{
    /// <summary>
    /// Class FAIncrementDetailEntity.
    /// </summary>
    public class FAIncrementDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FAIncrementDetailEntity" /> class.
        /// </summary>
        public FAIncrementDetailEntity()
        {
            AddRule(new ValidateRequired("RefId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FAIncrementDetailEntity" /> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="unitPriceOc">The unit price oc.</param>
        /// <param name="unitPriceExchange">The unit price exchange.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="autoBusinessId">The automatic business identifier.</param>
        public FAIncrementDetailEntity(long refDetailId, long refId, int? fixedAssetId, string description, string accountNumber, string correspondingAccountNumber,
            decimal amountOc, decimal amountExchange, int? voucherTypeId, string budgetSourceCode, int? accountingObjectId, string budgetItemCode, int quantity,
            decimal unitPriceOc, decimal unitPriceExchange,int? departmentId, string budgetChapterCode,string budgetCategoryCode, int? projectId, int? autoBusinessId)
            : this()
        {
            RefDetailId = refDetailId;
            RefId = refId;
            FixedAssetId = fixedAssetId;
            Description = description;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            AmountOC = amountOc;
            AmountExchange = amountExchange;
            VoucherTypeId = voucherTypeId;
            BudgetSourceCode = budgetSourceCode;
            AccountingObjectId = accountingObjectId;
            BudgetItemCode = budgetItemCode;
            Quantity = quantity;
            UnitPriceOC = unitPriceOc;
            UnitPriceExchange = unitPriceExchange;
            DepartmentId = departmentId;
            BudgetChapterCode = budgetChapterCode;
            BudgetCategoryCode = budgetCategoryCode;
            ProjectId = projectId;
            AutoBusinessId = autoBusinessId;
        }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int? FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price oc.
        /// </summary>
        /// <value>
        /// The unit price oc.
        /// </value>
        public decimal UnitPriceOC { get; set; }

        /// <summary>
        /// Gets or sets the unit price exchange.
        /// </summary>
        /// <value>
        /// The unit price exchange.
        /// </value>
        public decimal UnitPriceExchange { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public int? VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int? AutoBusinessId { get; set; }
    }
}
