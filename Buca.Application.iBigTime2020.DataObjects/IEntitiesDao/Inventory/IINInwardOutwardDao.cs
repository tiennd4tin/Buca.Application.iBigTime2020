/***********************************************************************
 * <copyright file="IPaymentINInwardOutwardDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory
{

    /// <summary>
    /// IPaymentINInwardOutwardDao interface
    /// </summary>
    public interface IINInwardOutwardDao
    {
        /// <summary>
        /// Gets the in inward outward.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>INInwardOutwardEntity.</returns>
        INInwardOutwardEntity GetINInwardOutward(string refId);

        List<INInwardOutwardEntity> GetINInwardOutwardByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ca inwardOutward by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        INInwardOutwardEntity GetINInwardOutwardByRefNo(string refNo);

        /// <summary>
        /// Gets the ca inwardOutward by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        INInwardOutwardEntity GetINInwardOutwardByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the ca inwardOutwards.
        /// </summary>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        List<INInwardOutwardEntity> GetINInwardOutwards();

        /// <summary>
        /// Inserts the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        string InsertINInwardOutward(INInwardOutwardEntity inwardOutward);

        /// <summary>
        /// Updates the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        string UpdateINInwardOutward(INInwardOutwardEntity inwardOutward);

        /// <summary>
        /// Deletes the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        string DeleteINInwardOutward(INInwardOutwardEntity inwardOutward);

        List<INInwardOutwardEntity> CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem);
        
        //string UpdateEmployeePayroll(string orgrefNo,string replaceRefNo, string monthDate);

        //string DeleteEmployeePayroll(string refNo, string postedDate);

        //List<INInwardOutwardEntity> GetINInwardOutwardesByRefNoAndRefDate(int refTypeId,DateTime refDate,string refNo,string currencyCode );

        //INInwardOutwardEntity GetINInwardOutwardBySalary(int refTypeId, string postedDate, string refNo, string currencyCode);

        //INInwardOutwardEntity GetINInwardOutwardForSalaryByRefNo(string refNo);

        //INInwardOutwardEntity GetINInwardOutwardForSalaryByDateMonth(DateTime dateMonth);

        //INInwardOutwardEntity GetINInwardOutwardByRefType(INInwardOutwardEntity obINInwardOutwardEntity);

        //List<INInwardOutwardEntity> GetINInwardOutwardesByRefTypeId(int refTypeId, int year);
    }
}
