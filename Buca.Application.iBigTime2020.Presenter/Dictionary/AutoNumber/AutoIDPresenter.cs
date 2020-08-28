/***********************************************************************
 * <copyright file="AutoNumberPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
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

    /// <summary>
    /// Class AutoNumberPresenter.
    /// </summary>
    public class AutoIDPresenter : Presenter<IAutoIDView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoIDPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoIDPresenter(IAutoIDView view)
            : base(view)
        {
        }

        public string Save()
        {
            var autoIDModel = new AutoIDModel()
            {
                RefTypeCategoryId = View.RefTypeCategoryId,
                RefTypeCategoryName = View.RefTypeCategoryName,
                Prefix = View.Prefix,
                Value = (int)View.Value + 1,
                LengthOfValue = View.LengthOfValue,
                Suffix = View.Suffix,
                IsSystem = View.IsSystem
            };
            return Model.UpdateAutoNumbers(new List<AutoIDModel> { autoIDModel });
        }

        /// <summary>
        /// Displays the type of the by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void DisplayByRefType(int refType)
        {
            if (refType == 0) return;

            var autoId = Model.GetAutoIDByRefType(refType);
            if (autoId == null) return;

            View.RefTypeCategoryId = autoId.RefTypeCategoryId;
            View.RefTypeCategoryName = autoId.RefTypeCategoryName;
            View.Prefix = autoId.Prefix;
            View.Value = autoId.Value;
            View.LengthOfValue = autoId.LengthOfValue;
            View.Suffix = autoId.Suffix;
            View.IsSystem = autoId.IsSystem;
        }
    }
}
