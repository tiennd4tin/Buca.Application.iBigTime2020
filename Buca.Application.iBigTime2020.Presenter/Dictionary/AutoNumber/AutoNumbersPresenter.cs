/***********************************************************************
 * <copyright file="AutoNumbersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AutoNumber
{
    public class AutoNumbersPresenter : Presenter<IAutoNumbersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoNumbersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoNumbersPresenter(IAutoNumbersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AutoNumbers = Model.GetAutoIds();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Save()
        {
            var autoNumbers = View.AutoNumbers;
            return Model != null ? Model.UpdateAutoNumbers((List<AutoIDModel>)autoNumbers) : null;
        }
    }
}
