/***********************************************************************
 * <copyright file="BudgetExpenseFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class BudgetExpenseFacade.
    /// </summary>
    public class BudgetExpenseFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IBudgetExpenseDao BudgetExpenseDao = DataAccess.DataAccess.BudgetExpenseDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        public List<BudgetExpenseEntity> GetBudgetExpenses()
        {
            return BudgetExpenseDao.GetBudgetExpenses();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;BudgetExpenseEntity&gt;.</returns>
        public List<BudgetExpenseEntity> GetBudgetExpensesByIsActive(bool isActive)
        {
            return BudgetExpenseDao.GetBudgetExpensesByIsActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        public BudgetExpenseEntity GetBudgetExpenseById(string accountCategoryId)
        {
            return BudgetExpenseDao.GetBudgetExpense(accountCategoryId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category entity.</param>
        /// <returns>BudgetExpenseResponse.</returns>
        public BudgetExpenseResponse InsertBudgetExpense(BudgetExpenseEntity budgetExpense)
        {
            var response = new BudgetExpenseResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetExpense.Validate())
                {
                    foreach (string error in budgetExpense.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var budgetExpenseExited = BudgetExpenseDao.GetBudgetExpenseByBudgetExpenseCode(budgetExpense.BudgetExpenseCode);
                if (budgetExpenseExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format("Mã phí, lệ phí {0}, đã tồn tại!", budgetExpenseExited.BudgetExpenseCode);
                    return response;
                }

                budgetExpense.BudgetExpenseId = Guid.NewGuid().ToString();
                response.Message = BudgetExpenseDao.InsertBudgetExpense(budgetExpense);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetExpenseId = budgetExpense.BudgetExpenseId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public BudgetExpenseResponse InsertBudgetExpenseConvert(BudgetExpenseEntity budgetExpense)
        {
            var response = new BudgetExpenseResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetExpense.Validate())
                {
                    foreach (string error in budgetExpense.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var budgetExpenseExited = BudgetExpenseDao.GetBudgetExpenseByBudgetExpenseCode(budgetExpense.BudgetExpenseCode);
                if (budgetExpenseExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format("Mã phí, lệ phí {0}, đã tồn tại!", budgetExpenseExited.BudgetExpenseCode);
                    return response;
                }

             
                response.Message = BudgetExpenseDao.InsertBudgetExpense(budgetExpense);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetExpenseId = budgetExpense.BudgetExpenseId;
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
        /// Updates the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category entity.</param>
        /// <returns>BudgetExpenseResponse.</returns>
        public BudgetExpenseResponse UpdateBudgetExpense(BudgetExpenseEntity budgetExpense)
        {
            var response = new BudgetExpenseResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetExpense.Validate())
                {
                    foreach (string error in budgetExpense.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var budgetExpenseExited = BudgetExpenseDao.GetBudgetExpenseByBudgetExpenseCode(budgetExpense.BudgetExpenseCode);
                if (budgetExpenseExited != null && budgetExpense.BudgetExpenseId != budgetExpenseExited.BudgetExpenseId)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format("Mã phí, lệ phí {0}, đã tồn tại!", budgetExpenseExited.BudgetExpenseCode);
                    return response;
                }

                response.Message = BudgetExpenseDao.UpdateBudgetExpense(budgetExpense);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetExpenseId = budgetExpense.BudgetExpenseId;
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
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>BudgetExpenseResponse.</returns>
        public BudgetExpenseResponse DeleteBudgetExpense(string accountCategoryId)
        {
            var response = new BudgetExpenseResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetExpense = BudgetExpenseDao.GetBudgetExpense(accountCategoryId);
                response.Message = BudgetExpenseDao.DeleteBudgetExpense(budgetExpense);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BABankTransferDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_BADepositDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_BAWithDrawDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_BUTransferDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_CAPaymentDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_CAReceiptDetailParallel_BudgetExpenseID") ||
                        response.Message.Contains("FK_GeneralLedger_BudgetExpense") ||
                        response.Message.Contains("FK_GLVoucherDetailParallel_BudgetExpenseID"))
                        response.Message = @"Bạn không thể xóa phí, lệ phí mã " + budgetExpense.BudgetExpenseCode + " vì đã phát sinh tại các nghiệp vụ liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.BudgetExpenseId = budgetExpense.BudgetExpenseId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public BudgetExpenseResponse DeleteBudgetExpenseConvert( )
        {
            var response = new BudgetExpenseResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
                response.Message = BudgetExpenseDao.DeleteBudgetExpenseConvert();

                if (!string.IsNullOrEmpty(response.Message))
                {
                  
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
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
    }
}

