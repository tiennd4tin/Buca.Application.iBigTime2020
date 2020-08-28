/***********************************************************************
 * <copyright file="IOpeningFixedAssetEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: 12 December 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;

namespace Buca.Application.iBigTime2020.View.OpeningFixedAssetEntry
{
    /// <summary>
    /// interface IOpeningFixedAssetEntryView
    /// </summary>
    public interface IOpeningFixedAssetEntryView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>The fixed asset identifier.</value>
        string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>The org price account.</value>
        string OrgPriceAccount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount oc.
        /// </summary>
        /// <value>The org price debit amount oc.</value>
        decimal OrgPriceDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>The org price debit amount.</value>
        decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>The depreciation account.</value>
        string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount oc.
        /// </summary>
        /// <value>The depreciation credit amount oc.</value>
        decimal DepreciationCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>The depreciation credit amount.</value>
        decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>The capital account.</value>
        string CapitalAccount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount oc.
        /// </summary>
        /// <value>The capital credit amount oc.</value>
        decimal CapitalCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount.
        /// </summary>
        /// <value>The capital credit amount.</value>
        decimal CapitalCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the devaluation credit amount.
        /// </summary>
        /// <value>The devaluation credit amount.</value>
        decimal DevaluationCreditAmount { get; set; }

        /// <summary>
        ///     Gets or sets the opening fixed asset entries.
        /// </summary>
        /// <value>
        ///     The opening fixed asset entries.
        /// </value>
        IList<OpeningFixedAssetEntryModel> OpeningFixedAssetEntries { get; set; }
    }
}