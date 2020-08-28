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

using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.View.System;


namespace Buca.Application.iBigTime2020.Presenter.System.Permission
{
    /// <summary>
    /// class PermissionsPresenter
    /// </summary>
    public class FeaturePermisionPresenter : Presenter<IFeaturePermisionView>
    {

        public FeaturePermisionPresenter(IFeaturePermisionView view)
            : base(view)
        {
        }

        public string Save()
        {
            var featurePermision = new FeaturePermisionModel
            {
                FeaturePermisionID = View.FeaturePermisionID,
                UserPermisionID = View.UserPermisionID,
                FeatureID = View.FeatureID,
            };
            return Model.InsertFeaturePermision(featurePermision);
        }
        public string Delete(string featureId)
        {
            return Model.DeleteFeaturePermision(featureId);
        }

    }
}