/***********************************************************************
 * <copyright file="IUserProfileView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 30 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.System
{
    /// <summary>
    /// IUserProfileView
    /// </summary>
    public interface IUserFeaturePermisionView : IView
    {
        string UserFeaturePermisionID { get; set; }
        string UserProfileID { get; set; }
        string UserPermisionID { get; set; }
        string FeatureID { get; set; }
        bool IsActive { get; set; }
    }
}
