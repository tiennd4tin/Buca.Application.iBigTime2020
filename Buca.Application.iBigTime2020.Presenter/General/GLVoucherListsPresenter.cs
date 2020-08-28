using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    public class GLVoucherListsPresenter:Presenter<IGLVoucherListsView>
    {
        public GLVoucherListsPresenter(IGLVoucherListsView view) : base(view)
        {
        }

        public void Display()
        {
            View.GlVoucherListModel = Model.GetGlVoucherList();
        }
    }
}
