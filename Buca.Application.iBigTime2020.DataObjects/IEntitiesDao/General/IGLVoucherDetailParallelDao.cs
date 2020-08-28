using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// Interface IGLVoucherDetailParallelDao
    /// </summary>
    public interface IGLVoucherDetailParallelDao
    {
        /// <summary>
        /// Deletes the gl voucher detail parallel by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteGLVoucherDetailParallelById(string refId);

        /// <summary>
        /// Gets the gl voucher detail parallel by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;GLVoucherDetailParallelEntity&gt;.</returns>
        List<GLVoucherDetailParallelEntity> GetGLVoucherDetailParallelByRefId(string refId);

        /// <summary>
        /// Inserts the gl voucher detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string InsertGLVoucherDetailParallel(GLVoucherDetailParallelEntity withDrawDetail);

        /// <summary>
        /// Updates the gl voucher detail parallel.
        /// </summary>
        /// <param name="withDrawDetail">The with draw detail.</param>
        /// <returns>System.String.</returns>
        string UpdateGLVoucherDetailParallel(GLVoucherDetailParallelEntity withDrawDetail);

    }

}