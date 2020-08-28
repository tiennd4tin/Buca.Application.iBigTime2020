using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice
{
    public class PUInvoiceModel
    {
        public PUInvoiceModel()
        {
            PUInvoiceDetailFixedAssets = new List<PUInvoiceDetailFixedAssetModel>();
        }

        public string RefId { get; set; }

        public int RefType { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }
        public List<SelectItemModel> Parallels { get; set; }

        public string RefNo { get; set; }

        public string ParalellRefNo { get; set; }

        public string InwardRefNo { get; set; }

        public string IncrementRefNo { get; set; }

        public string AccountingObjectId { get; set; }

        public string AccountingObjectName { get; set; }

        public string AccountingObjectAddress { get; set; }

        public string CompanyTaxCode { get; set; }

        public string AccountingObjectContactName { get; set; }

        public string JournalMemo { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalFreightAmount { get; set; }

        public decimal TotalInwardAmount { get; set; }

        public bool Posted { get; set; }

        public int PostVersion { get; set; }

        public int EditVersion { get; set; }

        public int RefOrder { get; set; }

        public decimal TotalFixedAssetAmount { get; set; }

        public int FARefOrder { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal TotalAmountOC { get; set; }

        public IList<PUInvoiceDetailFixedAssetModel> PUInvoiceDetailFixedAssets { get; set; }
    }
}
