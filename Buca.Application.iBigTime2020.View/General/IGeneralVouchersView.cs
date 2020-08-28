/***********************************************************************
 * <copyright file="IGeneralVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;


namespace Buca.Application.iBigTime2020.View.General
{
    /// <summary>
    /// interface IGeneralVouchersView
    /// </summary>
    public interface IGeneralVouchersView
    {
        IList<GeneralVocherModel> GeneralVouchers { set; }
        IList<GeneralVoucherDetailModel> GeneralVoucherDetails { set; }
    }
}
