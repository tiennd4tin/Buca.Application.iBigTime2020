using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.View.Cash
{

    /// <summary>
    /// ICAPaymentView
    /// </summary>
    public interface ICAPaymentView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        int RefType { get; set; }
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>
        /// The increment reference no.
        /// </value>
        string IncrementRefNo { get; set; }

        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>
        /// The inward reference no.
        /// </value>
        string InwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>
        /// The document included.
        /// </value>
        string DocumentIncluded { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        string BankId { get; set; }
        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        
        decimal TotalAmountOC { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        /// The total tax amount.
        /// </value>
        decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>
        /// The total freight amount.
        /// </value>
        decimal TotalFreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>
        /// The total inward amount.
        /// </value>
        decimal TotalInwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
        /// </value>
        bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>
        /// The reference order.
        /// </value>
        int RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>
        /// The relation reference identifier.
        /// </value>
        string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the total payment amount.
        /// </summary>
        /// <value>
        /// The total payment amount.
        /// </value>
        decimal TotalPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the ca payment details.
        /// </summary>
        /// <value>
        /// The ca payment details.
        /// </value>
        List<CAPaymentDetailModel> CaPaymentDetails { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail taxes.
        /// </summary>
        /// <value>
        /// The ca payment detail taxes.
        /// </value>
        List<CAPaymentDetailTaxModel> CaPaymentDetailTaxes { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail purchases.
        /// </summary>
        /// <value>The ca payment detail purchases.</value>
        List<CAPaymentDetailPurchaseModel> CAPaymentDetailPurchases { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail fixed assets.
        /// </summary>
        /// <value>The ca payment detail fixed assets.</value>
        List<CAPaymentDetailFixedAssetModel> CAPaymentDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail parallels.
        /// </summary>
        /// <value>The ca payment detail parallels.</value>
        List<CAPaymentDetailParallelModel> CAPaymentDetailParallels { get; set; }
        List<SelectItemModel> Parallels { get; set; }

        string Receiver { get; set; }
    }
}