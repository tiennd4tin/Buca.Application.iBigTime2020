using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.View.General
{
    public interface IGLPaymentListsView:IView
    {
        IList<GLPaymentListModel> GLPaymentListModel { set; }
    }
}
