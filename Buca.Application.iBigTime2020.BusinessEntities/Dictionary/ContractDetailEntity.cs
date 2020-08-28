using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class ContractDetailEntity
    {
        public string ContractDetailID { get; set; }
        public string ContractID { get; set; }
        public string AddendumNo { get; set; } // phụ lục số
        public string BudgetSourceId { get; set; } // nguồn vốn
        public decimal Prices { get; set; } // nguyên tệ( chính là số tiền)
        public decimal ExchangeValue { get; set; } // tỷ giá quy đổi
        public decimal ExchangeRate { get; set; } // tỷ giá
        public string Description { get; set; } // mô tả
        public DateTime SignDate { get; set; } // ngày ký
        public string CurrencyId { get; set; } // loại tiền  
        public int Stt { get; set; }
    }
}
