/***********************************************************************
 * <copyright file="IBUPlanWithdrawView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, November 1, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, November 1, 2017Author SonTV  Description 
 * 
 * ************************************************************************/


using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    public interface IBUPlanWithdrawView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the cash with draw.
        /// </summary>
        /// <value>The type of the cash with draw.</value>
        int CashWithDrawType { get; set; }

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
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        string TargetProgramId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        string BankId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string JournalMemo { get; set; }

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
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BUPlanWithdrawEntity"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the ibu plan withdraw details.
        /// </summary>
        /// <value>The ibu plan withdraw details.</value>
        IList<BUPlanWithdrawDetailModel> BUPlanWithdrawDetails { get; set; }

        /// <summary>
        /// Gets or sets the accounting object bank identifier.
        /// </summary>
        /// <value>
        /// The accounting object bank identifier.
        /// </value>
        string AccountingObjectBankId { get; set; }

        /// <summary>
        /// Id Liên kết: rút dự toán tiền mặt - phiếu thu từ ngân sách nhà nước
        /// Id Liên kết: rút dự toán tiền gửi - chuyển khoản kho bạc về tài khoản tiền gửi
        /// </summary>
        string CAReceiptRefId { get; set; }

        /// <summary>
        /// Số phiếu liên kết
        /// </summary>
        string LinkRefNo { get; set; }

        /// <summary>
        /// Tài khoản của đơn vị nhận tiền
        /// </summary>
        string BeneficiaryAccount { get; set; }

        /// <summary>
        /// Ngân hàng của đơn vị nhận tiền
        /// </summary>
        string BeneficiaryBank { get; set; }
    }
}
