/***********************************************************************
 * <copyright file="RefTypeFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// RefTypeFacade
    /// </summary>
    public class RefTypeFacade
    {
        private static readonly IRefTypeDao RefTypeDao = DataAccess.DataAccess.RefTypeDao;

        /// <summary>
        /// Gets the account transfers.
        /// </summary>
        /// <returns></returns>
        public List<RefTypeEntity> GetRefTypes()
        {
            return RefTypeDao.GetRefTypes();
        }

        /// <summary>
        /// Gets the type of the reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public RefTypeEntity GetRefType(int refTypeId)
        {
            return RefTypeDao.GetRefType(refTypeId);
        }

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeEntity">The reference type entity.</param>
        /// <returns></returns>
        public RefTypeResponse UpdateRefType(RefTypeEntity refTypeEntity)
        {
            var response = new RefTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!refTypeEntity.Validate())
                {
                    foreach (var error in refTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = RefTypeDao.UpdateRefType(refTypeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefTypeId = refTypeEntity.RefTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public RefTypeResponse DeleteAccountDefault()
        {
            var response = new RefTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                response.Message = RefTypeDao.DeleteRefTypeConvert();
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

        public RefTypeResponse InsertAccountDefaultConvert(RefTypeEntity refTypeEntity)
        {
            var response = new RefTypeResponse() { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!refTypeEntity.Validate())
                {
                    foreach (string error in refTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var accountDefault = RefTypeDao.GetRefType(refTypeEntity.RefTypeId);
                if (accountDefault != null)
                {
                    if (accountDefault.RefTypeId == refTypeEntity.RefTypeId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Tài khoản " + refTypeEntity.RefTypeName.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }
                response.Message = RefTypeDao.InsertReftype(refTypeEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.RefTypeId = refTypeEntity.RefTypeId;
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
