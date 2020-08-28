/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// VoucherListFacade
    /// </summary>
    public class VoucherListFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IVoucherListDao VoucherListDao = DataAccess.DataAccess.VoucherListDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<VoucherListEntity> GetVoucherLists()
        {
            return VoucherListDao.GetVoucherLists();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<VoucherListEntity> GetVoucherListsByActive()
        {
            return VoucherListDao.GetVoucherLists();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<VoucherListEntity> GetVoucherListByRefType(int refTypeId, bool isActive)
        {
            return VoucherListDao.GetVoucherLists();
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="voucherListId">The automatic business identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public VoucherListEntity GetVoucherList(string voucherListId)
        {
            return VoucherListDao.GetVoucherListById(voucherListId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="voucherListEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public VoucherListResponse InsertVoucherList(VoucherListEntity voucherListEntity)
        {
            var response = new VoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!voucherListEntity.Validate())
                {
                    foreach (string error in voucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var voucherList = VoucherListDao.GetVoucherListsByCode(voucherListEntity.VoucherListCode.Trim());
                if (voucherList != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Số chứng từ ghi sổ " + voucherListEntity.VoucherListCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                voucherListEntity.VoucherListId = Guid.NewGuid().ToString();
                response.Message = VoucherListDao.InsertVoucherList(voucherListEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.VoucherListId = voucherListEntity.VoucherListId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="voucherListEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public VoucherListResponse UpdateVoucherList(VoucherListEntity voucherListEntity)
        {
            var response = new VoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!voucherListEntity.Validate())
                {
                    foreach (string error in voucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var voucherList = VoucherListDao.GetVoucherListsByCode(voucherListEntity.VoucherListCode.Trim());
                if (voucherList != null)
                {
                    if (voucherList.VoucherListId != voucherListEntity.VoucherListId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ ghi sổ " + voucherListEntity.VoucherListCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = VoucherListDao.UpdateVoucherList(voucherListEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.VoucherListId = voucherListEntity.VoucherListId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="voucherListDId">The voucher list d identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public VoucherListResponse DeleteVoucherList(string voucherListDId)
        {
            var response = new VoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var voucherListDEntity = VoucherListDao.GetVoucherListById(voucherListDId);
                response.Message = VoucherListDao.DeleteVoucherList(voucherListDEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.VoucherListId = voucherListDEntity.VoucherListId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

    }
}
