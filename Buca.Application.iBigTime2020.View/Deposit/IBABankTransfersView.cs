using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Deposit
{
    public interface IBABankTransfersView
    {
        IList<BABankTransferModel> BABankTransfers { set; }
    }
}
