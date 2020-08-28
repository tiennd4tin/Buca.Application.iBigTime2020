using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure
{
    public class FundStructuresPresenter : Presenter<IFundStructuresView>
    {
        public FundStructuresPresenter(IFundStructuresView view)
            : base(view)
        {

        }
        public void Display()
        {
            View.FundStructures = Model.GetFundStructures();
        }
        public void DisplayActive(bool isActive)
        {
            View.FundStructures = Model.GetFundStructuresActive(isActive);
        }

    }
}
