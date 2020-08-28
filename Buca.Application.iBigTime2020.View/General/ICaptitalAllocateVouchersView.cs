﻿/***********************************************************************
 * <copyright file="GeneralVouchersCapitalAllocate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 17 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;


namespace Buca.Application.iBigTime2020.View.General
{
    public interface ICaptitalAllocateVouchersView
    {
        /// <summary>
        /// Sets the get captital allocate vouchers for update or insert.
        /// </summary>
        /// <value>
        /// The get captital allocate vouchers for update or insert.
        /// </value>
        IList<CaptitalAllocateVoucherModel> GetCaptitalAllocateVouchersForUpdateOrInsert { set; }


        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
          string CurrencyCode { get; set; }

          /// <summary>
          /// Gets or sets from date.
          /// </summary>
          /// <value>
          /// From date.
          /// </value>
         DateTime FromDate { get; set; }

         /// <summary>
         /// Gets or sets to date.
         /// </summary>
         /// <value>
         /// To date.
         /// </value>
         DateTime ToDate { get; set; }

         int ActivityId { get; set; }
    }
}
