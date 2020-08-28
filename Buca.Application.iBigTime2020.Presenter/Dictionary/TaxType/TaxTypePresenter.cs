using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.TaxType
{
    public class TaxTypePresenter : Presenter<ITaxTypeView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxTypePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public TaxTypePresenter(ITaxTypeView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified tax type identifier.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        public void Display(string taxTypeId)
        {
            if (taxTypeId == null) { View.TaxTypeId = null; return; }
            var taxType = Model.GetTaxType(taxTypeId);
            View.TaxTypeId = taxType.TaxTypeId;
            View.TaxTypeCode = taxType.TaxTypeCode;
            View.TaxTypeName = taxType.TaxTypeName;
            View.IsActive = taxType.IsActive;
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var taxType = new TaxTypeModel
            {
                TaxTypeId = View.TaxTypeId,
                TaxTypeCode = View.TaxTypeCode,
                TaxTypeName = View.TaxTypeName,
                IsActive = View.IsActive

            };

            return View.TaxTypeId == null ? Model.AddTaxType(taxType) : Model.UpdateTaxType(taxType);
        }
        /// <summary>
        /// Deletes the specified tax type identifier.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(string taxTypeId)
        {
            return Model.DeleteTaxType(taxTypeId);
        }
    }
}
