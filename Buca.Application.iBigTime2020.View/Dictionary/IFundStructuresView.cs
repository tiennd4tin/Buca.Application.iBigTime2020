using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface IFundStructuresView : IView
    {
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        IList<FundStructureModel> FundStructures { set; }
    }
}
