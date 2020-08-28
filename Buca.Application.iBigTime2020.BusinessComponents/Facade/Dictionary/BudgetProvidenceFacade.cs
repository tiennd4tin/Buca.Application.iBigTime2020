/***********************************************************************
 * <copyright file="BudgetProvidenceFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
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
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    ///     BudgetProvidenceFacade
    /// </summary>
    public class BudgetProvidenceFacade
    {
        /// <summary>
        ///     The budgetProvidence DAO
        /// </summary>
        private static readonly IBudgetProvidenceDao BudgetProvidenceDao = new SqlServerBudgetProvidenceDao();

        /// <summary>
        ///     Gets the budgetProvidence entities.
        /// </summary>
        /// <returns></returns>
        public IList<BudgetProvidenceEntity> GetBudgetProvidenceEntities()
        {
            return BudgetProvidenceDao.GetBudgetProvidences();
        }

        /// <summary>
        ///     Gets the employee type entities active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<BudgetProvidenceEntity> GetBudgetProvidenceEntitiesActive(bool isActive)
        {
            return BudgetProvidenceDao.GetBudgetProvidencesByIsActive(isActive);
        }

        /// <summary>
        ///     Gets the budgetProvidence entity.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns></returns>
        public BudgetProvidenceEntity GetBudgetProvidenceEntity(string budgetProvidenceId)
        {
            return BudgetProvidenceDao.GetBudgetProvidence(budgetProvidenceId);
        }

        /// <summary>
        ///     Deletes the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns></returns>
        public BudgetProvidenceResponse DeleteBudgetProvidence(string budgetProvidenceId)
        {
            var response = new BudgetProvidenceResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                var budgetProvidenceEntity = BudgetProvidenceDao.GetBudgetProvidence(budgetProvidenceId);
                if (budgetProvidenceEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = BudgetProvidenceDao.DeleteBudgetProvidence(budgetProvidenceEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.BudgetProvidenceId = budgetProvidenceEntity.BudgetProvideId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Inserts the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceEntity">The budgetProvidence entity.</param>
        /// <returns></returns>
        public BudgetProvidenceResponse InsertBudgetProvidence(BudgetProvidenceEntity budgetProvidenceEntity)
        {
            var response = new BudgetProvidenceResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!budgetProvidenceEntity.Validate())
                {
                    foreach (var error in budgetProvidenceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    budgetProvidenceEntity.BudgetProvideId = Guid.NewGuid().ToString();
                    response.Message = BudgetProvidenceDao.InsertBudgetProvidence(budgetProvidenceEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.BudgetProvidenceId = budgetProvidenceEntity.BudgetProvideId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Updates the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceEntity">The budgetProvidence entity.</param>
        /// <returns></returns>
        public BudgetProvidenceResponse UpdateBudgetProvidence(BudgetProvidenceEntity budgetProvidenceEntity)
        {
            var response = new BudgetProvidenceResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!budgetProvidenceEntity.Validate())
                {
                    foreach (var error in budgetProvidenceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = BudgetProvidenceDao.UpdateBudgetProvidence(budgetProvidenceEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.BudgetProvidenceId = budgetProvidenceEntity.BudgetProvideId;
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