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
    /// AutoBusinessFacade
    /// </summary>
    public class AutoBusinessFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IAutoBusinessDao AutoBusinessDao = DataAccess.DataAccess.AutoBusinessDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AutoBusinessEntity> GetAutoBusinesses()
        {
            return AutoBusinessDao.GetAutoBusinesses();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AutoBusinessEntity> GetAutoBusinessesByActive(bool isActive)
        {
            return AutoBusinessDao.GetAutoBusinessesByActive(isActive);
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AutoBusinessEntity> GetAutoBusinessByRefType(int refTypeId, bool isActive)
        {
            return AutoBusinessDao.GetAutoBusinessByRefType(refTypeId, isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="autoBusinessId">The automatic business identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public AutoBusinessEntity GetAutoBusiness(string autoBusinessId)
        {
            return AutoBusinessDao.GetAutoBusiness(autoBusinessId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="autoBusinessEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AutoBusinessResponse InsertAutoBusiness(AutoBusinessEntity autoBusinessEntity)
        {
            var response = new AutoBusinessResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var autoBusiness = AutoBusinessDao.GetAutoBusinessesByAutoBusinessCode(autoBusinessEntity.AutoBusinessCode.Trim());
                if (autoBusiness != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã định khoản tự động " + autoBusinessEntity.AutoBusinessCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                autoBusinessEntity.AutoBusinessId = Guid.NewGuid().ToString();
                response.Message = AutoBusinessDao.InsertAutoBusiness(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessId = autoBusinessEntity.AutoBusinessId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public AutoBusinessResponse InsertAutoBusinessConvert(AutoBusinessEntity autoBusinessEntity)
        {
            var response = new AutoBusinessResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var autoBusiness = AutoBusinessDao.GetAutoBusinessesByAutoBusinessCode(autoBusinessEntity.AutoBusinessCode.Trim());
                if (autoBusiness != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã định khoản tự động " + autoBusinessEntity.AutoBusinessCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                response.Message = AutoBusinessDao.InsertAutoBusiness(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessId = autoBusinessEntity.AutoBusinessId;
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
        /// <param name="autoBusinessEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AutoBusinessResponse UpdateAutoBusiness(AutoBusinessEntity autoBusinessEntity)
        {
            var response = new AutoBusinessResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var autoBusiness = AutoBusinessDao.GetAutoBusinessesByAutoBusinessCode(autoBusinessEntity.AutoBusinessCode.Trim());
                if (autoBusiness != null)
                {
                    if (autoBusiness.AutoBusinessId != autoBusinessEntity.AutoBusinessId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã định khoản tự động " + autoBusinessEntity.AutoBusinessCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = AutoBusinessDao.UpdateAutoBusiness(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessId = autoBusinessEntity.AutoBusinessId;
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
        /// <param name="accountTransferEId">The account transfer e identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AutoBusinessResponse DeleteAutoBusiness(string accountTransferEId)
        {
            var response = new AutoBusinessResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accountTransferEntity = AutoBusinessDao.GetAutoBusiness(accountTransferEId);
                response.Message = AutoBusinessDao.DeleteAutoBusiness(accountTransferEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessId = accountTransferEntity.AutoBusinessId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public AutoBusinessResponse DeleteAutoBusinessConvert()
        {
            var response = new AutoBusinessResponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                response.Message = AutoBusinessDao.DeleteAutoBusinessConvert();
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
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
