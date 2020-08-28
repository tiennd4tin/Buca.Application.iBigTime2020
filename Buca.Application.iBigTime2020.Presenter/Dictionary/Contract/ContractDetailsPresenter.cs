using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Contract
{
    public class ContractDetailsPresenter : Presenter<IContractDetailsView>
    {
        public ContractDetailsPresenter(IContractDetailsView view) : base(view)
        {

        }
        public void Display()
        {
            View.ContractDetails = Model.GetContractDetails();
        }
    }
}
