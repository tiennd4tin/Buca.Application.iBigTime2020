/***********************************************************************
 * <copyright file="BudgetSourceFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thurday, September 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
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
    /// BudgetSourceCategoryFacade
    /// </summary>
    public class BudgetSourceCategoryFacade
    {
        /// <summary>
        /// The budget source category DAO
        /// </summary>
        private static readonly IBudgetSourceCategoryDao BudgetSourceCategoryDao = DataAccess.DataAccess.BudgetSourceCategoryDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategories()
        {
            return BudgetSourceCategoryDao.GetBudgetSourceCategories();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourcesCategoryByIsActive(bool isActive)
        {
            return BudgetSourceCategoryDao.GetBudgetSourceCategoriesByActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public BudgetSourceCategoryEntity GetBudgetSourceCategoryById(string budgetSourceCategoryId)
        {
            return BudgetSourceCategoryDao.GetBudgetSourceCategory(budgetSourceCategoryId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetSourceCategoryEntity">The budget source category entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceCategoryResponse InsertBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategoryEntity)
        {
            var response = new BudgetSourceCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetSourceCategoryEntity.Validate())
                {
                    foreach (string error in budgetSourceCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetSourceCategory = BudgetSourceCategoryDao.GetBudgetSourceCategoriesByBudgetSourceCategoryCode(budgetSourceCategoryEntity.BudgetSourceCategoryCode);
                if (budgetSourceCategory.Count > 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã loại nguồn vốn " + budgetSourceCategoryEntity.BudgetSourceCategoryCode + @" đã tồn tại !";
                    return response;
                }

                budgetSourceCategoryEntity.BudgetSourceCategoryId = BudgetSourceCategoryDao.InsertBudgetSourceCategory(budgetSourceCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceCategoryId = budgetSourceCategoryEntity.BudgetSourceCategoryId;
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
        /// <param name="budgetSourceCategoryEntity">The budget source category entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceCategoryResponse UpdateBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategoryEntity)
        {
            var response = new BudgetSourceCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetSourceCategoryEntity.Validate())
                {
                    foreach (string error in budgetSourceCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetSourceCategory = BudgetSourceCategoryDao.GetBudgetSourceCategoriesByBudgetSourceCategoryCode(budgetSourceCategoryEntity.BudgetSourceCategoryCode);
                if (budgetSourceCategory.Count > 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã loại nguồn vốn " + budgetSourceCategoryEntity.BudgetSourceCategoryCode + @" đã tồn tại !";
                    return response;
                }

                response.Message = BudgetSourceCategoryDao.UpdateBudgetSourceCategory(budgetSourceCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceCategoryId = budgetSourceCategoryEntity.BudgetSourceCategoryId;
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
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceCategoryResponse DeleteBudgetSourceCategory(string budgetSourceCategoryId)
        {
            var response = new BudgetSourceCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetSourceCategoryEntity = BudgetSourceCategoryDao.GetBudgetSourceCategory(budgetSourceCategoryId);
                response.Message = BudgetSourceCategoryDao.DeleteBudgetSourceCategory(budgetSourceCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceCategoryId = budgetSourceCategoryEntity.BudgetSourceCategoryId;
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
