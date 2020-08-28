using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLPaymentListsPresenter : Presenter<IGLPaymentListsView>
    {
        public GLPaymentListsPresenter(IGLPaymentListsView view) : base(view)
        {
        }

        public void Display()
        {
            View.GLPaymentListModel = Model.GetGlPaymentList();
        }
    }
}
