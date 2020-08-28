using Buca.Application.iBigTime2020.View.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Deposit
{
    public class BABankTransfersPresenter : Presenter<IBABankTransfersView>
    {
        public BABankTransfersPresenter(IBABankTransfersView view)
            : base(view)
        {
        }
        public void Display()
        {
            View.BABankTransfers = Model.GetBABankTransfers();
        }
    }
}
