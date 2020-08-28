/***********************************************************************
 * <copyright file="IStockView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IStockView
    /// </summary>
    public interface IElectricalWorkView : IView
    {

        int ElectricalWorkId { get; set; }
        int  PostedDate { get; set; }
        string ElectricalWorName { get; set; }


    }
}
