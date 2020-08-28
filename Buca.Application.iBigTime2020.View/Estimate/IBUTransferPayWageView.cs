/***********************************************************************
 * <copyright file="IBUTransferView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    /// Interface IBUTransferView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBUTransferPayWageView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }
        bool Approved { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        string TargetProgramId { get; set; }

        /// <summary>
        /// Gets or sets the bank information identifier.
        /// </summary>
        /// <value>The bank information identifier.</value>
        string BankInfoId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>The accounting object address.</value>
        string AccountingObjectAddress { get; set; }

        /// <summary>
        /// Gets or sets the accounting object bank account.
        /// </summary>
        /// <value>The accounting object bank account.</value>
        string AccountingObjectBankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object bank.
        /// </summary>
        /// <value>The name of the accounting object bank.</value>
        string AccountingObjectBankName { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        string DocumentIncluded { get; set; }

        /// <summary>
        /// Gets or sets the inward stock reference no.
        /// </summary>
        /// <value>The inward stock reference no.</value>
        string InwardStockRefNo { get; set; }

        /// <summary>
        /// Gets or sets the withdraw reference date.
        /// </summary>
        /// <value>The withdraw reference date.</value>
        DateTime? WithdrawRefDate { get; set; }

        /// <summary>
        /// Gets or sets the withdraw reference no.
        /// </summary>
        /// <value>The withdraw reference no.</value>
        string WithdrawRefNo { get; set; }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        string IncrementRefNo { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        decimal TotalFreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        decimal TotalInwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUTransferModel" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the total fixed asset amount.
        /// </summary>
        /// <value>The total fixed asset amount.</value>
        decimal TotalFixedAssetAmount { get; set; }

        string BUPlanWithdrawRefId { get; set; }


        string gLVouchersRefId { get; set; }

        string LinkRefNo { get; set; }

        /// <summary>
        /// Gets or sets the bu transfer details.
        /// </summary>
        /// <value>The bu transfer details.</value>
        IList<BUTransferDetailModel> BUTransferDetails { get; set; }

        IList<BUTransferDetailParallelModel> BuTransferDetailParallel { get; set; }

        /// <summary>
        /// Chuyển khoản kho bạc mua vật tư hàng hóa
        /// </summary>
        IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }

        /// <summary>
        /// Chuyển khoản kho bạc mua TSCĐ
        /// </summary>
        IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets { get; set; }
    }
}
