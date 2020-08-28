/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IAutoBusinessParallelsView
    /// </summary>
    public interface IAutoBusinessParallelsView : IView
    {
        /// <summary>
        /// Sets the automatic business parallels.
        /// </summary>
        /// <value>The automatic business parallels.</value>
        IList<AutoBusinessParallelModel> AutoBusinessParallels { set; }
    }
}