using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.TaxItem
{
    public class TaxItemPresenter : Presenter<ITaxItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public TaxItemPresenter(ITaxItemView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified tax item identifier.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        public void Display(string taxItemId)
        {
            if (taxItemId == null) { View.TaxItemId = null; return; }
            var taxItem = Model.GetTaxItem(taxItemId);
            View.TaxItemId = taxItem.TaxItemId;
            View.TaxItemCode = taxItem.TaxItemCode;
            View.TaxItemName = taxItem.TaxItemName;
            View.IsActive = taxItem.IsActive;
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var taxItem = new TaxItemModel
            {
                TaxItemId = View.TaxItemId,
                TaxItemCode = View.TaxItemCode,
                TaxItemName= View.TaxItemName,
                IsActive = View.IsActive
           
            };

            return View.TaxItemId == null ? Model.AddTaxItem(taxItem) : Model.UpdateTaxItem(taxItem);
        }
        /// <summary>
        /// Deletes the specified tax item identifier.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string taxItemId)
        {
            return Model.DeleteTaxItem(taxItemId);
        }
    }
}
