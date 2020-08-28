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
    public interface IUserProfileView : IView
    {
        string UserProfileId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string FullName { get; set; }
        string JobTitle { get; set; }
        string Description { get; set; }
        bool IsSystem { get; set; }
        bool IsActive { get; set; }
    }
}
