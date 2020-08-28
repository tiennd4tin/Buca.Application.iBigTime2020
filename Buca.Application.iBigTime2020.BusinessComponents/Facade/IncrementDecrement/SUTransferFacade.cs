/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
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
using Buca.Application.iBigTime2020.BusinessComponents.Message.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.IncrementDecrement
{
    /// <summary>
    /// 
    /// </summary>
    public class SUTransferFacade : FacadeBase
    {
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;
        private readonly ISUTransferDao SUTransferDao = new SqlServerSUTransferDao();
        private readonly ISUTransferDetailDao SUTransferDetailDao = new SqlServerSUTransferDetailDao();
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly ISupplyLedgerDao SupplyLedgerDao = DataAccess.DataAccess.SupplyLedgerDao;

        /// <summary>
        /// Gets the su increment decrements.
        /// </summary>
        /// <returns></returns>
        public List<SUTransferEntity> GetSUTransfers()
        {
            return SUTransferDao.GetSUTransfers();
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<SUTransferEntity> GetSUTransfersByRefTypeId(int refTypeId)
        {
            return SUTransferDao.GetSUTransfersByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<SUTransferEntity> GetSUTransfersByRefTypeId(int refTypeId, DateTime refDate)
        {
            return SUTransferDao.GetSUTransfersByYearOfRefDate(refTypeId, (short)refDate.Year);
        }

        /// <summary>
        /// Gets the ba deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUTransferEntity GetSUTransferByRefNo(string refNo, bool hasDetail)
        {
            var suTransfer = SUTransferDao.GetSUTransferByRefNo(refNo);
            if (suTransfer == null)
                return null;
            if (hasDetail)
                suTransfer.SUTransferDetails = SUTransferDetailDao.GetSUTransferDetailsByRefId(suTransfer.RefId);
            return suTransfer;
        }

        /// <summary>
        /// Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUTransferEntity GetSUTransferByRefId(string refId, bool hasDetail)
        {
            var suTransfer = SUTransferDao.GetSUTransfer(refId);
            if (suTransfer == null)
                return null;
            if (hasDetail)
                suTransfer.SUTransferDetails =
                    SUTransferDetailDao.GetSUTransferDetailsByRefId(suTransfer.RefId);
            return suTransfer;
        }

        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="suTransferEntity">The su transfer entity.</param>
        /// <returns></returns>
        public SUTransferResponse InsertSUTransfer(SUTransferEntity suTransferEntity, bool isconvertDB)
        {
            var response = new SUTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!suTransferEntity.Validate())
                {
                    foreach (var error in suTransferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var suTransfer = SUTransferDao.GetSUTransfer(suTransferEntity.RefNo.Trim(), suTransferEntity.PostedDate);
                    if (suTransfer != null && suTransfer.PostedDate.Year == suTransferEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ " + suTransferEntity.RefNo + @" đã tồn tại !";
                        return response;
                    }

                    suTransferEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = SUTransferDao.InsertSUTransfer(suTransferEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert SUIncrementDecrementDetails

                    if (suTransferEntity.SUTransferDetails != null)
                        foreach (var suTransferDetail in suTransferEntity.SUTransferDetails)
                        {
                            if (!isconvertDB)//Nếu insert từ chứng từ thì check sl tồn
                            {
                                if (suTransferEntity.RefType == (int) BuCA.Enum.RefType.SUTransfer)
                                {
                                    AutoMapper(
                                        GetUnitsInDepartment(suTransferDetail.InventoryItemId,
                                            suTransferDetail.FromDepartmentId, suTransferDetail.Quantity,
                                            suTransferDetail.Description), response);
                                    if (response.Acknowledge == AcknowledgeType.Failure)
                                        return response;
                                }
                            }

                            suTransferDetail.RefDetailId = Guid.NewGuid().ToString();
                            suTransferDetail.RefId = suTransferEntity.RefId;
                            response.Message = SUTransferDetailDao.InsertSUTransferDetail(suTransferDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(suTransferEntity, suTransferDetail);

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = suTransferEntity.RefType,
                                RefId = suTransferEntity.RefId,
                                RefDetailId = suTransferDetail.RefDetailId,
                                RefDate = suTransferEntity.RefDate,
                                RefNo = suTransferEntity.RefNo,
                                Amount = suTransferDetail.Amount,
                                BudgetChapterCode = suTransferDetail.BudgetChapterCode,
                                CreditAccount = suTransferDetail.CreditAccount,
                                DebitAccount = suTransferDetail.DebitAccount,
                                Description = suTransferDetail.Description,
                                JournalMemo = suTransferEntity.JournalMemo,
                                SortOrder = suTransferDetail.SortOrder,
                                PostedDate = suTransferEntity.PostedDate,

                                // Không có Currency trong db : mặc định VNĐ và 1
                                CurrencyCode = "VND",
                                ExchangeRate = 1,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert SupplyLedger
                            // insert bang SupplyLedger
                            if (suTransferDetail.InventoryItemId != null)
                            {
                                var supplyLedgerEntity = new SupplyLedgerEntity
                                {
                                    SupplyLedgerId = Guid.NewGuid().ToString(),
                                    RefId = suTransferEntity.RefId,
                                    RefType = suTransferEntity.RefType,
                                    RefNo = suTransferEntity.RefNo,
                                    RefDate = suTransferEntity.RefDate,
                                    PostedDate = suTransferEntity.PostedDate,
                                    DepartmentId = suTransferDetail.FromDepartmentId,
                                    InventoryItemId = suTransferDetail.InventoryItemId,
                                    Unit = suTransferDetail.Unit,
                                    UnitPrice = suTransferDetail.UnitPrice,
                                    IncrementQuantity = 0,
                                    DecrementQuantity = suTransferDetail.Quantity,
                                    IncrementAmount = 0,
                                    DecrementAmount = suTransferDetail.Amount,
                                    JournalMemo = suTransferEntity.JournalMemo,
                                    Description = suTransferDetail.Description,
                                    AccountNumber = suTransferDetail.DebitAccount,
                                    RefDetailId = suTransferDetail.RefDetailId
                                };
                                response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                supplyLedgerEntity.SupplyLedgerId = Guid.NewGuid().ToString();
                                supplyLedgerEntity.DepartmentId = suTransferDetail.ToDepartmentId;
                                supplyLedgerEntity.AccountNumber = suTransferDetail.CreditAccount;
                                supplyLedgerEntity.IncrementQuantity = suTransferDetail.Quantity;
                                supplyLedgerEntity.DecrementQuantity = 0;
                                supplyLedgerEntity.IncrementAmount = suTransferDetail.Amount;
                                supplyLedgerEntity.DecrementAmount = 0;

                                response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            #endregion
                        }

                    #endregion

                    scope.Complete();
                }
                response.RefId = suTransferEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the ba deposit.
        /// </summary>
        /// <param name="suTransferEntity">The su transfer entity.</param>
        /// <returns></returns>
        public SUTransferResponse UpdateSUTransfer(SUTransferEntity suTransferEntity)
        {
            var response = new SUTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!suTransferEntity.Validate())
                {
                    foreach (var error in suTransferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var suTransfer = SUTransferDao.GetSUTransfer(suTransferEntity.RefNo.Trim(), suTransferEntity.PostedDate);
                    if (suTransfer != null && suTransfer.PostedDate.Year == suTransferEntity.PostedDate.Year)
                    {
                        if (suTransfer.RefId != suTransferEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ " + suTransferEntity.RefNo + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = SUTransferDao.UpdateSUTransfer(suTransferEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(suTransferEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Delete detail and insert detail

                    // Xóa bảng SUTransferDetail
                    response.Message = SUTransferDetailDao.DeleteSUTransferDetailByRefId(suTransferEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(suTransferEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // Xóa bảng SupplyLedger
                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(suTransferEntity.RefId, suTransferEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    if (suTransferEntity.SUTransferDetails != null)
                        foreach (var suTransferDetail in suTransferEntity.SUTransferDetails)
                        {
                            if (suTransferEntity.RefType == (int)BuCA.Enum.RefType.SUTransfer)
                            {
                                AutoMapper(GetUnitsInDepartment(suTransferDetail.InventoryItemId, suTransferDetail.FromDepartmentId, suTransferDetail.Quantity, suTransferDetail.Description), response);
                                if (response.Acknowledge == AcknowledgeType.Failure)
                                    return response;
                            }

                            suTransferDetail.RefDetailId = Guid.NewGuid().ToString();
                            suTransferDetail.RefId = suTransferEntity.RefId;
                            response.Message = SUTransferDetailDao.InsertSUTransferDetail(suTransferDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(suTransferEntity, suTransferDetail);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = suTransferEntity.RefType,
                                RefId = suTransferEntity.RefId,
                                RefDetailId = suTransferDetail.RefDetailId,
                                RefDate = suTransferEntity.RefDate,
                                RefNo = suTransferEntity.RefNo,
                                Amount = suTransferDetail.Amount,
                                BudgetChapterCode = suTransferDetail.BudgetChapterCode,
                                CreditAccount = suTransferDetail.CreditAccount,
                                DebitAccount = suTransferDetail.DebitAccount,
                                Description = suTransferDetail.Description,
                                JournalMemo = suTransferEntity.JournalMemo,
                                SortOrder = suTransferDetail.SortOrder,
                                PostedDate = suTransferEntity.PostedDate,

                                // Không có Currency trong db : mặc định VNĐ và 1
                                CurrencyCode = "VND",
                                ExchangeRate = 1,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert SupplyLedger
                            if (suTransferDetail.InventoryItemId != null)
                            {
                                var supplyLedgerEntity = new SupplyLedgerEntity
                                {
                                    SupplyLedgerId = Guid.NewGuid().ToString(),
                                    RefId = suTransferEntity.RefId,
                                    RefType = suTransferEntity.RefType,
                                    RefNo = suTransferEntity.RefNo,
                                    RefDate = suTransferEntity.RefDate,
                                    PostedDate = suTransferEntity.PostedDate,
                                    DepartmentId = suTransferDetail.FromDepartmentId,
                                    InventoryItemId = suTransferDetail.InventoryItemId,
                                    Unit = suTransferDetail.Unit,
                                    UnitPrice = suTransferDetail.UnitPrice,
                                    IncrementQuantity = 0,
                                    DecrementQuantity = suTransferDetail.Quantity,
                                    IncrementAmount = 0,
                                    DecrementAmount = suTransferDetail.Amount,
                                    JournalMemo = suTransferEntity.JournalMemo,
                                    Description = suTransferDetail.Description,
                                    AccountNumber = suTransferDetail.DebitAccount,
                                    RefDetailId = suTransferDetail.RefDetailId
                                };
                                response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                supplyLedgerEntity.SupplyLedgerId = Guid.NewGuid().ToString();
                                supplyLedgerEntity.AccountNumber = suTransferDetail.CreditAccount;
                                supplyLedgerEntity.DepartmentId = suTransferDetail.ToDepartmentId;
                                supplyLedgerEntity.IncrementQuantity = suTransferDetail.Quantity;
                                supplyLedgerEntity.DecrementQuantity = 0;
                                supplyLedgerEntity.IncrementAmount = suTransferDetail.Amount;
                                supplyLedgerEntity.DecrementAmount = 0;

                                response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            #endregion
                        }

                    #endregion

                    scope.Complete();
                }
                response.RefId = suTransferEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public SUTransferResponse DeleteSUTransfer(string refId)
        {
            var response = new SUTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var suTransferEntity = SUTransferDao.GetSUTransfer(refId);

                if (suTransferEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    #region Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(suTransferEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    #endregion

                    //Xóa bảng SUTransfer
                    response.Message = SUTransferDao.DeleteSUTransfer(suTransferEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //Xóa bảng OriginalGeneralLedgerDao
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(suTransferEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //Xóa bảng SupplyLedger
                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(suTransferEntity.RefId, suTransferEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = suTransferEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <param name="suTransferDetail">The su transfer detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(SUTransferEntity suTransfer, SUTransferDetailEntity suTransferDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = suTransferDetail.DebitAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = suTransfer.PostedDate,
                MovementDebitAmountOC = suTransferDetail.Amount,
                MovementDebitAmount = suTransferDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetChapterCode = suTransferDetail.BudgetChapterCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <param name="suTransferDetail">The su transfer detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(SUTransferEntity suTransfer, SUTransferDetailEntity suTransferDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = suTransferDetail.CreditAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = suTransfer.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = suTransferDetail.Amount,
                MovementCreditAmount = suTransferDetail.Amount,
                BudgetChapterCode = suTransferDetail.BudgetChapterCode
            };
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalanceEntity">The account balance entity.</param>
        /// <param name="movementAmount">The movement amount.</param>
        /// <param name="movementAmountExchange">The movement amount exchange.</param>
        /// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange,
            bool isMovementAmount, int balanceSide)
        {
            string message;
            // cập nhật bên TK nợ
            if (balanceSide == 1)
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount + movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount - movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            else
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount + movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount - movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(SUTransferEntity suTransfer)
        {
            var paymentDetails = SUTransferDetailDao.GetSUTransferDetailsByRefId(suTransfer.RefId);
            foreach (var paymentDetail in paymentDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(suTransfer, paymentDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(suTransfer, paymentDetail);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmount, false, 2);
                    if (message != null)
                        return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <param name="suTransferDetail">The su transfer detail.</param>
        public void InsertAccountBalance(SUTransferEntity suTransfer, SUTransferDetailEntity suTransferDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(suTransfer, suTransferDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(suTransfer, suTransferDetail);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        #endregion
    }
}
