using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;

namespace Buca.Application.iBigTime2020.View.Cash
{

    public interface ICAPaymentsView : IView
    {
        IList<CAPaymentModel> CAPayments{ set ;}
    }

}