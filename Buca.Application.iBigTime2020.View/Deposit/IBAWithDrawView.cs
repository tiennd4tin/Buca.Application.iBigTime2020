/***********************************************************************
 * <copyright file="IBAWithDrawView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.View.Deposit
{
    /// <summary>
    ///     IBAWithDrawView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBAWithDrawView : IView
    {
        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        string RefId { get; set; }
        List<SelectItemModel> Parallels { get; set; }

        /// <summary>
        ///     Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        ///     The type of the reference.
        /// </value>
        int RefType { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the currency code.
        /// </summary>
        /// <value>
        ///     The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the inward reference no.
        /// </summary>
        /// <value>
        ///     The inward reference no.
        /// </value>
        string InwardRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the increment reference no.
        /// </summary>
        /// <value>
        ///     The increment reference no.
        /// </value>
        string IncrementRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        ///     The bank identifier.
        /// </value>
        string BankId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        ///     The name of the bank.
        /// </value>
        string BankName { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        string AccountingObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        ///     The total amount oc.
        /// </value>
        decimal TotalAmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        ///     The total tax amount.
        /// </value>
        decimal TotalTaxAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total freight amount.
        /// </summary>
        /// <value>
        ///     The total freight amount.
        /// </value>
        decimal TotalFreightAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total inward amount.
        /// </summary>
        /// <value>
        ///     The total inward amount.
        /// </value>
        decimal TotalInwardAmount { get; set; }

        /// <summary>
        ///     Gets or sets the reconciled.
        /// </summary>
        /// <value>
        ///     The reconciled.
        /// </value>
        bool? Reconciled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBAWithDrawView"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        bool Posted { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>
        int? PostVersion { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        int? EditVersion { get; set; }

        /// <summary>
        ///     Gets or sets the reference order.
        /// </summary>
        /// <value>
        ///     The reference order.
        /// </value>
        int? RefOrder { get; set; }

        /// <summary>
        ///     Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>
        ///     The relation reference identifier.
        /// </value>
        string RelationRefId { get; set; }
        int RelationType { get; set; }
        /// <summary>
        ///     Gets or sets the total payment amount.
        /// </summary>
        /// <value>
        ///     The total payment amount.
        /// </value>
        decimal TotalPaymentAmount { get; set; }
        string ReceiveName { get; set; }
        string ReceiveId { get; set; }
        DateTime? ReceiveIssueDate { get; set; }
        string ReceiveIssueLocation { get; set; }
        string AccountingObjectBankAccount { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw details.
        /// </summary>
        /// <value>
        ///     The ba with draw details.
        /// </value>
        IList<BAWithDrawDetailModel> BAWithDrawDetails { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw detail fixed assets.
        /// </summary>
        /// <value>
        ///     The ba with draw detail fixed assets.
        /// </value>
        IList<BAWithDrawDetailFixedAssetModel> BAWithDrawDetailFixedAssets { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw detail purchases.
        /// </summary>
        /// <value>
        ///     The ba with draw detail purchases.
        /// </value>
        IList<BAWithDrawDetailPurchaseModel> BAWithDrawDetailPurchases { get; set; }
         
        /// <summary>
        ///     Gets or sets the ba withdraw detail salarys.
        /// </summary>
        /// <value>
        ///     The ba withdraw detail salarys.
        /// </value>
        IList<BAWithdrawDetailSalaryModel> BAWithdrawDetailSalarys { get; set; }

        /// <summary>
        ///     Gets or sets the ba withdraw detail taxs.
        /// </summary>
        /// <value>
        ///     The ba withdraw detail taxs.
        /// </value>
        IList<BAWithdrawDetailTaxModel> BAWithdrawDetailTaxs { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw detail parallels.
        /// </summary>
        /// <value>The ba with draw detail parallels.</value>
        IList<BAWithDrawDetailParallelModel> BAWithDrawDetailParallels { get; set; }  
    }
}