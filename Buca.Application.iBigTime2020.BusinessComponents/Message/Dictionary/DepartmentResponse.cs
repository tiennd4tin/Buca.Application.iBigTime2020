﻿/***********************************************************************
 * <copyright file="DepartmentResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, September 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    /// <summary>
    ///     DepartmentResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class DepartmentResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the department entity.
        /// </summary>
        /// <value>
        ///     The department entity.
        /// </value>
        public DepartmentEntity DepartmentEntity { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        public string DepartmentId { get; set; }
    }
}