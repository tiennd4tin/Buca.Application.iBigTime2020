/***********************************************************************
 * <copyright file="PurchasePurposeFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
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
    ///     PurchasePurposeFacade
    /// </summary>
    public class PurchasePurposeFacade
    {
        /// <summary>
        ///     The purchasePurpose DAO
        /// </summary>
        private static readonly IPurchasePurposeDao PurchasePurposeDao = DataAccess.DataAccess.PurchasePurposeDao;

        /// <summary>
        ///     Gets the purchasePurposes.
        /// </summary>
        /// <returns>
        ///     List&lt;PurchasePurposeEntity&gt;.
        /// </returns>
        public List<PurchasePurposeEntity> GetPurchasePurposes()
        {
            return PurchasePurposeDao.GetPurchasePurposes();
        }

        /// <summary>
        ///     Gets the purchasePurposes by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     List&lt;PurchasePurposeEntity&gt;.
        /// </returns>
        public List<PurchasePurposeEntity> GetPurchasePurposesByIsActive(bool isActive)
        {
            return PurchasePurposeDao.GetPurchasePurposesByIsActive(isActive);
        }

        /// <summary>
        ///     Gets the purchasePurpose by identifier.
        /// </summary>
        /// <param name="purchasePurposeId">The budget chapter identifier.</param>
        /// <returns>
        ///     PurchasePurposeEntity.
        /// </returns>
        public PurchasePurposeEntity GetPurchasePurposeById(string purchasePurposeId)
        {
            return PurchasePurposeDao.GetPurchasePurpose(purchasePurposeId);
        }

        /// <summary>
        ///     Inserts the purchase purpose.
        /// </summary>
        /// <param name="purchasePurposeEntity">The purchase purpose entity.</param>
        /// <returns></returns>
        public PurchasePurposeResponse InsertPurchasePurpose(PurchasePurposeEntity purchasePurposeEntity)
        {
            var response = new PurchasePurposeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!purchasePurposeEntity.Validate())
                {
                    foreach (var error in purchasePurposeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    purchasePurposeEntity.PurchasePurposeId = Guid.NewGuid().ToString();
                    response.Message = PurchasePurposeDao.InsertPurchasePurpose(purchasePurposeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.PurchasePurposeId = purchasePurposeEntity.PurchasePurposeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public PurchasePurposeResponse InsertPurchasePurposeConvert(PurchasePurposeEntity purchasePurposeEntity)
        {
            var response = new PurchasePurposeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!purchasePurposeEntity.Validate())
                {
                    foreach (var error in purchasePurposeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    
                    response.Message = PurchasePurposeDao.InsertPurchasePurpose(purchasePurposeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.PurchasePurposeId = purchasePurposeEntity.PurchasePurposeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Updates the purchase purpose.
        /// </summary>
        /// <param name="purchasePurposeEntity">The purchase purpose entity.</param>
        /// <returns></returns>
        public PurchasePurposeResponse UpdatePurchasePurpose(PurchasePurposeEntity purchasePurposeEntity)
        {
            var response = new PurchasePurposeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!purchasePurposeEntity.Validate())
                {
                    foreach (var error in purchasePurposeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = PurchasePurposeDao.UpdatePurchasePurpose(purchasePurposeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.PurchasePurposeId = purchasePurposeEntity.PurchasePurposeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Deletes the purchase purpose.
        /// </summary>
        /// <param name="purchasePurposeId">The purchase purpose identifier.</param>
        /// <returns></returns>
        public PurchasePurposeResponse DeletePurchasePurpose(string purchasePurposeId)
        {
            var response = new PurchasePurposeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                var purchasePurposeEntity = PurchasePurposeDao.GetPurchasePurpose(purchasePurposeId);
                using (var scope = new TransactionScope())
                {
                    response.Message = PurchasePurposeDao.DeletePurchasePurpose(purchasePurposeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.PurchasePurposeId = purchasePurposeEntity.PurchasePurposeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public PurchasePurposeResponse DeletePurchasePurposeConvert()
        {
            var response = new PurchasePurposeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
                using (var scope = new TransactionScope())
                {
                    response.Message = PurchasePurposeDao.DeletePurchasePurposeConvert();
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
               
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Gets the purchase purpose by code.
        /// </summary>
        /// <param name="purchasePurposeByCode">The purchase purpose by code.</param>
        /// <returns></returns>
        public PurchasePurposeEntity GetPurchasePurposeByCode(string purchasePurposeByCode)
        {
            return PurchasePurposeDao.GetPurchasePurposesByPurchasePurposeCode(purchasePurposeByCode);
        }
    }
}