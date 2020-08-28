/***********************************************************************
 * <copyright file="EmployeeTypeResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, September 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    /// <summary>
    ///     EmployeeTypeResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class EmployeeTypeResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the department entity.
        /// </summary>
        /// <value>
        ///     The department entity.
        /// </value>
        public EmployeeTypeEntity EmployeeTypeEntity { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }
    }
}