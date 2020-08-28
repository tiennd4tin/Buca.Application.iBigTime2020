using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;

namespace Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher
{
    public class CAPaymentsPresenter : Presenter<ICAPaymentsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAPaymentsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CAPaymentsPresenter(ICAPaymentsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.CAPayments = Model.GetCAPayment();
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.CAPayments = Model.GetCAPaymentsByRefTypeId(refTypeId);
        }

        public void Display(List<RefTypeModel> listRefType)
        {
            var _bUTransfers = new List<CAPaymentModel>();
            listRefType.ForEach(m => { _bUTransfers.AddRange(Model.GetCAPaymentsByRefTypeId(m.RefTypeId)); });
            View.CAPayments = _bUTransfers;
        }
    }
}
