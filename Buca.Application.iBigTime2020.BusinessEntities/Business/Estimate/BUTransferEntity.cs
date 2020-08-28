/***********************************************************************
 * <copyright file="BUTransferEntity.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate
{
    /// <summary>
    /// Class BUTransferEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BUTransferEntity :BusinessEntities
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        public List<SelectItemEntity> Parallels { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

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
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        public string TargetProgramId { get; set; }

        /// <summary>
        /// Gets or sets the bank information identifier.
        /// </summary>
        /// <value>The bank information identifier.</value>
        public string BankInfoId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>The accounting object address.</value>
        public string AccountingObjectAddress { get; set; }

        /// <summary>
        /// Gets or sets the accounting object bank account.
        /// </summary>
        /// <value>The accounting object bank account.</value>
        public string AccountingObjectBankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object bank.
        /// </summary>
        /// <value>The name of the accounting object bank.</value>
        public string AccountingObjectBankName { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded { get; set; }

        /// <summary>
        /// Gets or sets the inward stock reference no.
        /// </summary>
        /// <value>The inward stock reference no.</value>
        public string InwardStockRefNo { get; set; }

        /// <summary>
        /// Gets or sets the withdraw reference date.
        /// </summary>
        /// <value>The withdraw reference date.</value>
        public DateTime? WithdrawRefDate { get; set; }

        /// <summary>
        /// Gets or sets the withdraw reference no.
        /// </summary>
        /// <value>The withdraw reference no.</value>
        public string WithdrawRefNo { get; set; }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        public string IncrementRefNo { get; set; }

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
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        public decimal TotalFreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        public decimal TotalInwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUTranfersModel" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the total fixed asset amount.
        /// </summary>
        /// <value>The total fixed asset amount.</value>
        public decimal TotalFixedAssetAmount { get; set; }

        public string LinkRefNo { get; set; }

        /// <summary>
        /// Gets or sets the bu transfer details.
        /// </summary>
        /// <value>The bu transfer details.</value>
        public IList<BUTransferDetailEntity> BUTransferDetails { get; set; }
        public IList<BUTransferDetailParallelEntity> BUTransferDetailParallels { get; set; }
        public IList<BUTransferDetailPurchaseEntity> BUTransferDetailPurchases { get; set; }
        public IList<BUTransferDetailFixedAssetEntity> BUTransferDetailFixedAssets { get; set; }

        /// <summary>
        /// Id Liên kết: rút dự toán tiền gửi - chuyển khoản kho bạc về tài khoản tiền gửi
        /// </summary>
        public string BUPlanWithdrawRefId { get; set; }

        public string gLVouchersRefId { get; set; }

    }
}
