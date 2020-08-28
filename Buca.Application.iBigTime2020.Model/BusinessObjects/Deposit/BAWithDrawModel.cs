/***********************************************************************
 * <copyright file="BAWithDrawModel.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit
{
    /// <summary>
    ///     BAWithDrawModel
    /// </summary>
    public class BAWithDrawModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BAWithDrawModel" /> class.
        /// </summary>
        public BAWithDrawModel()
        {
            BAWithDrawDetails = new List<BAWithDrawDetailModel>();
            BAWithDrawDetailFixedAssets = new List<BAWithDrawDetailFixedAssetModel>();
            BAWithDrawDetailPurchases = new List<BAWithDrawDetailPurchaseModel>();
            BAWithdrawDetailSalarys = new List<BAWithdrawDetailSalaryModel>();
            BAWithdrawDetailTaxs = new List<BAWithdrawDetailTaxModel>();
        }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        ///     The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the currency code.
        /// </summary>
        /// <value>
        ///     The currency code.
        /// </value>
        public string CurrencyCode { get; set; }
        public string ProjectCode { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiveId { get; set; }
        public DateTime? ReceiveIssueDate { get; set; }
        public string ReceiveIssueLocation { get; set; }

        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the inward reference no.
        /// </summary>
        /// <value>
        ///     The inward reference no.
        /// </value>
        public string InwardRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the increment reference no.
        /// </summary>
        /// <value>
        ///     The increment reference no.
        /// </value>
        public string IncrementRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        ///     The bank identifier.
        /// </value>
        public string BankId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        ///     The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }


        public string AccountingObjectBankAccount { get; set; }


        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        ///     The total amount oc.
        /// </value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        ///     The total tax amount.
        /// </value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total freight amount.
        /// </summary>
        /// <value>
        ///     The total freight amount.
        /// </value>
        public decimal TotalFreightAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total inward amount.
        /// </summary>
        /// <value>
        ///     The total inward amount.
        /// </value>
        public decimal TotalInwardAmount { get; set; }

        /// <summary>
        ///     Gets or sets the reconciled.
        /// </summary>
        /// <value>
        ///     The reconciled.
        /// </value>
        public bool? Reconciled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BAWithDrawEntity" /> is posted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        ///     Gets or sets the reference order.
        /// </summary>
        /// <value>
        ///     The reference order.
        /// </value>
        public int? RefOrder { get; set; }

        /// <summary>
        ///     Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>
        ///     The relation reference identifier.
        /// </value>
        public string RelationRefId { get; set; }

        public int RelationType { get; set; }

        /// <summary>
        ///     Gets or sets the total payment amount.
        /// </summary>
        /// <value>
        ///     The total payment amount.
        /// </value>
        public decimal TotalPaymentAmount { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw details.
        /// </summary>
        /// <value>
        ///     The ba with draw details.
        /// </value>
        public IList<BAWithDrawDetailModel> BAWithDrawDetails { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw detail fixed assets.
        /// </summary>
        /// <value>
        ///     The ba with draw detail fixed assets.
        /// </value>
        public IList<BAWithDrawDetailFixedAssetModel> BAWithDrawDetailFixedAssets { get; set; }

        /// <summary>
        ///     Gets or sets the ba with draw detail purchases.
        /// </summary>
        /// <value>
        ///     The ba with draw detail purchases.
        /// </value>
        public IList<BAWithDrawDetailPurchaseModel> BAWithDrawDetailPurchases { get; set; }

        /// <summary>
        ///     Gets or sets the ba withdraw detail salarys.
        /// </summary>
        /// <value>
        ///     The ba withdraw detail salarys.
        /// </value>
        public IList<BAWithdrawDetailSalaryModel> BAWithdrawDetailSalarys { get; set; }

        /// <summary>
        ///     Gets or sets the ba withdraw detail taxs.
        /// </summary>
        /// <value>
        ///     The ba withdraw detail taxs.
        /// </value>
        public IList<BAWithdrawDetailTaxModel> BAWithdrawDetailTaxs { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw detail parallels.
        /// </summary>
        /// <value>The ba with draw detail parallels.</value>
        public IList<BAWithDrawDetailParallelModel> BAWithDrawDetailParallels { get; set; }
        public List<SelectItemModel> Parallels { get; set; }
    }
}