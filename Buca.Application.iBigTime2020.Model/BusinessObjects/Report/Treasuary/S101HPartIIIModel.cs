﻿/***********************************************************************
 * <copyright file="S101HPartIIIModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, April 17, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary
{
    /// <summary>
    /// Class S101HPartIIIModel.
    /// </summary>
    public class S101HPartIIIModel
    {
        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public string BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>
        /// The item code.
        /// </value>
        public string ItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        /// <value>
        /// The group code.
        /// </value>
        public string GroupCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        public int ItemType { get; set; }

        /// <summary>
        /// Gets or sets the budget advance amount.
        /// </summary>
        /// <value>
        /// The budget advance amount.
        /// </value>
        public decimal BudgetAdvanceAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget advance payment amount.
        /// </summary>
        /// <value>
        /// The budget advance payment amount.
        /// </value>
        public decimal BudgetAdvancePaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the advance balance amount.
        /// </summary>
        /// <value>
        /// The advance balance amount.
        /// </value>
        public decimal AdvanceBalanceAmount { get; set; }

        /// <summary>
        /// Gets or sets the actual expense amount.
        /// </summary>
        /// <value>
        /// The actual expense amount.
        /// </value>
        public decimal ActualExpenseAmount { get; set; }

        /// <summary>
        /// Gets or sets the cash back amount.
        /// </summary>
        /// <value>
        /// The cash back amount.
        /// </value>
        public decimal CashBackAmount { get; set; }

        /// <summary>
        /// Gets or sets the actual receitp amount.
        /// </summary>
        /// <value>
        /// The actual receitp amount.
        /// </value>
        public decimal ActualReceitpAmount { get; set; }

        /// <summary>
        /// Gets or sets the finalization amount.
        /// </summary>
        /// <value>
        /// The finalization amount.
        /// </value>
        public decimal FinalizationAmount { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is bold.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is bold; otherwise, <c>false</c>.
        /// </value>
        public bool IsBold { get; set; }

        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>
        /// The kind of the budget source.
        /// </value>
        public int BudgetSourceKind { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source kind.
        /// </summary>
        /// <value>
        /// The name of the budget source kind.
        /// </value>
        public string BudgetSourceKindName { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        public string ProjectCode { get; set; }
    }
}
