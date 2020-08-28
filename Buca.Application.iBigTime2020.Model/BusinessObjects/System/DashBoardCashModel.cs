using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.System
{
    public class DashBoardCashModel
    {
        public decimal PrevCash { get; set; }
        public decimal PrevCashInBank { get; set; }
        public decimal PrevCashInTransit { get; set; }
        public DateTime PrevTime { get; set; }
        public decimal ThisCash { get; set; }
        public decimal ThisCashInBank { get; set; }
        public decimal ThisCashInTransit { get; set; }
        public DateTime ThisTime { get; set; }
        public decimal NextCash { get; set; }
        public decimal NextCashInBank { get; set; }
        public decimal NextCashInTransit { get; set; }
        public DateTime NextTime { get; set; }
    }
}
