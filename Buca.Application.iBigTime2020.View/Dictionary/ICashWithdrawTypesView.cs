using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    ///     ICashWithdrawTypesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface ICashWithdrawTypesView : IView
    {
        /// <summary>
        ///     Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        ///     The cash withdraw type models.
        /// </value>
        IList<CashWithdrawTypeModel> CashWithdrawTypeModels { set; }

        ///// <summary>
        ///// Sets the cash withdraw type model.
        ///// </summary>
        ///// <value>
        ///// The cash withdraw type model.
        ///// </value>
        //CashWithdrawTypeModel CashWithdrawTypeModel { set; }
    }
}