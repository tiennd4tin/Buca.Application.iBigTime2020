using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C4_09Model
    {
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
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }
        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }
        /// <summary>
        /// Gets or sets the identification number.
        /// </summary>
        /// <value>
        /// The identification number.
        /// </value>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        /// /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string BankAccount { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string BankName { get; set; }
        public IList<C4_09DetailModel> Details { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// Địa chỉ
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the JournalMemo.
        /// Lí do thu, nội dung thu
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the TotalAmount.
        /// Tổng tiền đã quy đổi
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the CurrencyCode.
        /// Mã tiền tệ
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the TotalAmountOC.
        /// Tổng tiền chưa quy đổi
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalCashAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalCashAmountOC { get; set; }
        public string RefId { get; set; }
        public int RefType { get; set; }
        public string Payer { get; set; }
    }
}
