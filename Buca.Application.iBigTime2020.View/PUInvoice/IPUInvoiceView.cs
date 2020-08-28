using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.PUInvoice
{
    public interface IPUInvoiceView
    {
        string RefId { get; set; }

        int RefType { get; }

        DateTime RefDate { get; set; }

        DateTime PostedDate { get; set; }
        List<SelectItemModel> Parallels { get; set; }

        string RefNo { get; set; }

        string ParalellRefNo { get; set; }

        string InwardRefNo { get; set; }

        string IncrementRefNo { get; set; }

        string AccountingObjectId { get; set; }

        string AccountingObjectName { set; }

        string AccountingObjectAddress { set; }

        string CompanyTaxCode { set; }

        string AccountingObjectContactName { get; set; }

        string JournalMemo { get; set; }

        decimal TotalAmount { get; set; }

        decimal TotalTaxAmount { get; set; }

        decimal TotalFreightAmount { get; set; }

        decimal TotalInwardAmount { get; set; }

        bool Posted { get; set; }

        int PostVersion { get; set; }

        int EditVersion { get; set; }

        int RefOrder { get; set; }

        decimal TotalFixedAssetAmount { get; set; }

        int FARefOrder { get; set; }

        string CurrencyCode { get; set; }

        decimal ExchangeRate { get; set; }

        decimal TotalAmountOC { get; set; }

        IList<PUInvoiceDetailFixedAssetModel> PUInvoiceDetailFixedAssets { get; set; }
    }
}
