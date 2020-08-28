﻿using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface IReceiptVoucherDao
    {
        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        ReceiptVoucherEntity GetReceiptVoucher(int receiptVoucherID);
        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <returns></returns>
        List<ReceiptVoucherEntity> GetReceiptVouchers();
        /// <summary>
        /// Inserts the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        int InsertReceiptVoucher(ReceiptVoucherEntity receiptVoucher);
        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        string UpdateReceiptVoucher(ReceiptVoucherEntity receiptVoucher);
        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        string DeleteReceiptVoucher(ReceiptVoucherEntity receiptVoucher);
    }
}