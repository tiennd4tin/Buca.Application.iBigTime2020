/***********************************************************************
 * <copyright file="IPermissionsView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;


namespace Buca.Application.iBigTime2020.View.System
{
    /// <summary>
    /// IPermissionsView
    /// </summary>
    public interface IFeaturesView : IView
    {
 
        IList<FeaturesModel> Features { set; }
    }
}
