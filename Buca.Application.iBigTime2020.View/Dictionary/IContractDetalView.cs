using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface IContractDetalView : IView
    {
        string ContractDetailID { get; set; }
        string ContractID { get; set; }
        string AddendumNo { get; set; } // phụ lục số
        string BudgetName { get; set; } // ngân sách
        string Prices { get; set; } // nguyên tệ( chính là số tiền)
        decimal? ExchangeValue { get; set; } // tỷ giá quy đổi
        decimal? ExchangeRate { get; set; } // tỷ giá
        string Description { get; set; } // mô tả
        DateTime SignDate { get; set; } // ngày ký
        string CurrencyCode { get; set; } // loại tiền
    }
}
