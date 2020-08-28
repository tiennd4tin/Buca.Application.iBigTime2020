/***********************************************************************
 * <copyright file="IPaymentCAReceiptDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{

    /// <summary>
    /// IPaymentCAReceiptDao interface
    /// </summary>
    public interface ICAReceiptDao
    {
        CAReceiptEntity GetCAReceipt(string refId);

        List<CAReceiptEntity> GetCAReceiptByRefTypeID(int refTypeId);
        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;CAReceiptEntity&gt;.</returns>
        CAReceiptEntity GetCAReceiptByRefNo(string refNo);


        /// <summary>
        /// Gets the ca receipt by planWithDrawRefID.
        /// </summary>
        /// <param name="planWithDrawRefID"></param>
        /// <returns>CAReceiptEntity</returns>
        CAReceiptEntity GetCAReceiptByBuPlanWithDrawRefID(string planWithDrawRefID);
       

        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns>CAReceiptEntity.</returns>
        CAReceiptEntity GetCAReceiptByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>List&lt;CAReceiptEntity&gt;.</returns>
        List<CAReceiptEntity> GetCAReceipts();

        /// <summary>
        /// Inserts the ca receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string InsertCAReceipt(CAReceiptEntity receipt);

        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string UpdateCAReceipt(CAReceiptEntity receipt);

        /// <summary>
        /// Deletes the ca receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string DeleteCAReceipt(CAReceiptEntity receipt);

        //string UpdateEmployeePayroll(string orgrefNo,string replaceRefNo, string monthDate);

        //string DeleteEmployeePayroll(string refNo, string postedDate);

        //List<CAReceiptEntity> GetCAReceiptesByRefNoAndRefDate(int refTypeId,DateTime refDate,string refNo,string currencyCode );

        //CAReceiptEntity GetCAReceiptBySalary(int refTypeId, string postedDate, string refNo, string currencyCode);

        //CAReceiptEntity GetCAReceiptForSalaryByRefNo(string refNo);

        //CAReceiptEntity GetCAReceiptForSalaryByDateMonth(DateTime dateMonth);

        //CAReceiptEntity GetCAReceiptByRefType(CAReceiptEntity obCAReceiptEntity);

        //List<CAReceiptEntity> GetCAReceiptesByRefTypeId(int refTypeId, int year);
    }
}
