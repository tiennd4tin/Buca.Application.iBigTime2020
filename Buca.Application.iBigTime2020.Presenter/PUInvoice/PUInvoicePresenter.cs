using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.View.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.PUInvoice
{
    public class PUInvoicePresenter : Presenter<IPUInvoiceView>
    {
        public PUInvoicePresenter(IPUInvoiceView view) : base(view)
        {

        }

        public void Display(string refId)
        {
            var pUInvoice = Model.GetPUInvoice(refId, true) ?? new PUInvoiceModel();

            // Tính tiền
            View.TotalAmount = pUInvoice.TotalAmount;
            View.TotalAmountOC = pUInvoice.TotalAmountOC;

            View.RefId = pUInvoice.RefId;
            View.RefDate = pUInvoice.RefDate;
            View.PostedDate = pUInvoice.PostedDate;
            View.RefNo = pUInvoice.RefNo;
            View.IncrementRefNo = pUInvoice.IncrementRefNo;
            View.AccountingObjectId = pUInvoice.AccountingObjectId;
            View.ParalellRefNo = pUInvoice.CompanyTaxCode;
            View.JournalMemo = pUInvoice.AccountingObjectContactName;
            View.JournalMemo = pUInvoice.JournalMemo;
            View.PUInvoiceDetailFixedAssets = pUInvoice.PUInvoiceDetailFixedAssets;
            //View.CompanyTaxCode = pUInvoice.CompanyTaxCode;
            View.AccountingObjectContactName = pUInvoice.AccountingObjectContactName;
            View.CurrencyCode = pUInvoice.CurrencyCode;
            View.ExchangeRate = pUInvoice.ExchangeRate;
        }

        public string Save()
        {
            var pUInvoice = new PUInvoiceModel()
            {
                PUInvoiceDetailFixedAssets = View.PUInvoiceDetailFixedAssets, // Để trên cùng để set số tiền

                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                IncrementRefNo = View.IncrementRefNo,
                AccountingObjectId = View.AccountingObjectId,
                //CompanyTaxCode = View.CompanyTaxCode,
                AccountingObjectContactName = View.AccountingObjectContactName,
                JournalMemo = View.JournalMemo,
                TotalAmount = View.TotalAmount,
                TotalTaxAmount = View.TotalTaxAmount,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOC = View.TotalAmountOC, 
                Parallels = View.Parallels
            };

            return Model.UpdatePUInvoice(pUInvoice);
        }

        public string Delete(string refId, int refType)
        {
            return Model.DeletePUInvoice(refId, refType);
        }
    }
}
