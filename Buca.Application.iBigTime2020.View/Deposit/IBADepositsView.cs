/***********************************************************************
 * <copyright file="ibadepositsview.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 19, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;

namespace Buca.Application.iBigTime2020.View.Deposit
{
    /// <summary>
    ///     IBADepositsView
    /// </summary>
    public interface IBADepositsView : IView
    {
        /// <summary>
        ///     Sets the ba deposits.
        /// </summary>
        /// <value>
        ///     The ba deposits.
        /// </value>
        IList<BADepositModel> BADeposits { set; }
    }
}