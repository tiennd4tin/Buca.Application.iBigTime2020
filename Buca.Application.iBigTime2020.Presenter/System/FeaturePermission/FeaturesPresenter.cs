/***********************************************************************
 * <copyright file="PermissionsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.System;


namespace Buca.Application.iBigTime2020.Presenter.System.Permission
{
    /// <summary>
    /// class PermissionsPresenter
    /// </summary>
    public class FeaturesPresenter : Presenter<IFeaturesView>
    {
 
        public FeaturesPresenter(IFeaturesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
           View.Features = Model.GetFeatures();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(bool isActive)
        {
        //    View.Permissions = Model.GetPermissions(isActive);
        }

        /// <summary>
        /// Dises the play is parent.
        /// </summary>
        public void DisPlayIsParent()
        {
            View.Features = Model.GetFeaturesIsParent();
        }
    }
}