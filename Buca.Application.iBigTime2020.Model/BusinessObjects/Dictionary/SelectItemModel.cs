using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    public class SelectItemModel
    {
        public SelectItemModel(string debit,string credit)
        {
            Debit = debit;
            Credit = credit;

        }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
}
