using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Cash
{

    /// <summary>
    /// Class CAPaymentModel.
    /// </summary>
    public class CAPaymentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAPaymentModel"/> class.
        /// </summary>
        public CAPaymentModel()
        {
            CAPaymentDetails = new List<CAPaymentDetailModel>();
            CaPaymentDetailTaxes = new List<CAPaymentDetailTaxModel>();
            CAPaymentDetailPurchases = new List<CAPaymentDetailPurchaseModel>();
            CAPaymentDetailFixedAssets = new List<CAPaymentDetailFixedAssetModel>();
            CAPaymentDetailParallels = new List<CAPaymentDetailParallelModel>();
        }
        /// <summary>
        /// Gets or sets the ca payment details.
        /// </summary>
        /// <value>The ca payment details.</value>
        public IList<CAPaymentDetailModel> CAPaymentDetails { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the ca payment detail taxes.
        /// </summary>
        /// <value>
        /// The ca payment detail taxes.
        /// </value>
        public IList<CAPaymentDetailTaxModel> CaPaymentDetailTaxes { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail purchase.
        /// </summary>
        /// <value>The ca payment detail purchase.</value>
        public IList<CAPaymentDetailPurchaseModel> CAPaymentDetailPurchases { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail fixed assets.
        /// </summary>
        /// <value>The ca payment detail fixed assets.</value>
        public IList<CAPaymentDetailFixedAssetModel> CAPaymentDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail parallels.
        /// </summary>
        /// <value>The ca payment detail parallels.</value>
        public IList<CAPaymentDetailParallelModel> CAPaymentDetailParallels { get; set; }
        public List<SelectItemModel> Parallels { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

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
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        public string IncrementRefNo { get; set; }

        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>The inward reference no.</value>
        public string InwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }
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
        /// Gets or sets a value indicating whether this <see cref="CAPaymentModel"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the total payment amount.
        /// </summary>
        /// <value>The total payment amount.</value>
        public decimal TotalPaymentAmount { get; set; }

        public string Receiver { get; set; }
    }

}