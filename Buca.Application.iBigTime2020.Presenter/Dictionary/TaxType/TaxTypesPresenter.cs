using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.TaxType
{
    public class TaxTypesPresenter : Presenter<ITaxTypesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxTypesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public TaxTypesPresenter(ITaxTypesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.TaxTypes = Model.GetTaxTypes();
        }

    }
}
