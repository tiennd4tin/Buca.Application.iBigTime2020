﻿using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface IReceiptVoucherDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        List<ReceiptVoucherDetailEntity> GetReceiptVoucherDetailsByMaster(int receiptVoucherID);
        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="receiptVoucherDetail">The receipt voucher detail.</param>
        /// <returns></returns>
        int InsertReceiptVoucherDetail(ReceiptVoucherDetailEntity receiptVoucherDetail);
        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        string DeleteReceiptVoucherDetailByMaster(int receiptVoucherID);
    }
}
