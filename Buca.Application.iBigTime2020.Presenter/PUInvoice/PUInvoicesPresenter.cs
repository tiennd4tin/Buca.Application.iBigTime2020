using Buca.Application.iBigTime2020.View.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.PUInvoice
{
    public class PUInvoicesPresenter : Presenter<IPUInvoicesView>
    {
        public PUInvoicesPresenter(IPUInvoicesView view) : base(view)
        {

        }

        public void Display(int refTypeId)
        {
            View.PUInvoices = Model.GetPUInvoicesByRefTypeId(refTypeId);
        }
    }
}
