using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.TaxItem
{
    public class TaxItemsPresenter : Presenter<ITaxItemsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxItemsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public TaxItemsPresenter(ITaxItemsView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.TaxItems = Model.GetTaxItems();
        }

    }
}
