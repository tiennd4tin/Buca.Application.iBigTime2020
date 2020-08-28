using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.PUInvoice
{
    public interface IPUInvoicesView : IView
    {
        IList<PUInvoiceModel> PUInvoices { set; }
    }
}
