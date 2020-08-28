using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;


namespace Buca.Application.iBigTime2020.View.General
{
    public interface IGLVoucherListsView :IView
    {
        IList<GLVoucherListModel> GlVoucherListModel { set; }
    }
}
