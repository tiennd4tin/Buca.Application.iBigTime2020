/***********************************************************************
 * <copyright file="SUIncrementDecrementFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.IncrementDecrement
{
    /// <summary>
    /// SUIncrementDecrementFacade
    /// </summary>
    public class SUIncrementDecrementFacade : FacadeBase
    {
        private readonly ISUIncrementDecrementDao SUIncrementDecrementDao = new SqlServerSUIncrementDecrementDao();
        private readonly ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao = new SqlServerSUIncrementDecrementDetailDao();
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly ISupplyLedgerDao SupplyLedgerDao = DataAccess.DataAccess.SupplyLedgerDao;

        /// <summary>
        /// The general ledger DAO
        /// </summary>
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;

        /// <summary>
        /// Gets the su increment decrements.
        /// </summary>
        /// <returns></returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrements()
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrements();
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrementsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId, DateTime refDate)
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrementsByYearOfRefDate(refTypeId, (short)refDate.Year);
        }

        /// <summary>
        /// Gets the ba deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(refNo);
            if (sUIncrementDecrement == null)
                return null;
            if (hasDetail)
                sUIncrementDecrement.SUIncrementDecrementDetails =
                    SUIncrementDecrementDetailDao.GetSUIncrementDecrementDetailsByRefId(sUIncrementDecrement.RefId);
            return sUIncrementDecrement;
        }

        /// <summary>
        /// Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefId(string refId, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementDao.GetSUIncrementDecrement(refId);
            if (sUIncrementDecrement == null)
                return null;
            if (hasDetail)
                sUIncrementDecrement.SUIncrementDecrementDetails =
                    SUIncrementDecrementDetailDao.GetSUIncrementDecrementDetailsByRefId(sUIncrementDecrement.RefId);
            return sUIncrementDecrement;
        }




        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="sUIncrementDecrementEntity">The b a deposit entity.</param>
        /// <returns></returns>
        public SUIncrementDecrementResponse InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrementEntity, bool isconvertDB)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!sUIncrementDecrementEntity.Validate())
                {
                    foreach (var error in sUIncrementDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var sUIncrementDecrementByRefNo =
                        SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(sUIncrementDecrementEntity.RefNo, sUIncrementDecrementEntity.PostedDate);
                    if (sUIncrementDecrementByRefNo != null && sUIncrementDecrementByRefNo.PostedDate.Year == sUIncrementDecrementEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã chứng từ đã tồn tại!";
                        return response;
                    }
                    sUIncrementDecrementEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = SUIncrementDecrementDao.InsertSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert SUIncrementDecrementDetails

                    if (sUIncrementDecrementEntity.SUIncrementDecrementDetails != null)
                        foreach (var sUIncrementDecrementDetailEntity in sUIncrementDecrementEntity.SUIncrementDecrementDetails)
                        {
                            if (!isconvertDB)//AnhNT: Nếu không phải convert dữ liệu thì mới check số lượng tồn
                            {
                                if (sUIncrementDecrementEntity.RefType == (int) BuCA.Enum.RefType.SUDecrement)
                                {
                                    AutoMapper(
                                        GetUnitsInDepartment(sUIncrementDecrementDetailEntity.InventoryItemId,
                                            sUIncrementDecrementDetailEntity.DepartmentId,
                                            sUIncrementDecrementDetailEntity.Quantity,
                                            sUIncrementDecrementDetailEntity.Description), response);
                                    if (response.Acknowledge == AcknowledgeType.Failure)
                                        return response;
                                }
                            }

                            sUIncrementDecrementDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            sUIncrementDecrementDetailEntity.RefId = sUIncrementDecrementEntity.RefId;
                            response.Message =
                                SUIncrementDecrementDetailDao.InsertSUIncrementDecrementDetail(sUIncrementDecrementDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(sUIncrementDecrementEntity, sUIncrementDecrementDetailEntity);

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = sUIncrementDecrementEntity.RefType,
                                RefId = sUIncrementDecrementEntity.RefId,
                                RefDetailId = sUIncrementDecrementDetailEntity.RefDetailId,
                                RefDate = sUIncrementDecrementEntity.RefDate,
                                RefNo = sUIncrementDecrementEntity.RefNo,
                                Amount = sUIncrementDecrementDetailEntity.Amount,
                                BudgetChapterCode = sUIncrementDecrementDetailEntity.BudgetChapterCode,
                                CreditAccount = sUIncrementDecrementDetailEntity.CreditAccount,
                                DebitAccount = sUIncrementDecrementDetailEntity.DebitAccount,
                                Description = sUIncrementDecrementDetailEntity.Description,
                                JournalMemo = sUIncrementDecrementEntity.JournalMemo,
                                SortOrder = sUIncrementDecrementDetailEntity.SortOrder,
                                PostedDate = sUIncrementDecrementEntity.PostedDate,

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

                            if (sUIncrementDecrementEntity.RefType == 205 || sUIncrementDecrementEntity.RefType == 206)
                            {
                                #region Insert SupplyLedger
                                if (sUIncrementDecrementDetailEntity.InventoryItemId != null)
                                {
                                    var supplyLedgerEntity = new SupplyLedgerEntity
                                    {
                                        SupplyLedgerId = Guid.NewGuid().ToString(),
                                        RefId = sUIncrementDecrementEntity.RefId,
                                        RefType = sUIncrementDecrementEntity.RefType,
                                        RefNo = sUIncrementDecrementEntity.RefNo,
                                        RefDate = sUIncrementDecrementEntity.RefDate,
                                        PostedDate = sUIncrementDecrementEntity.PostedDate,
                                        DepartmentId = sUIncrementDecrementDetailEntity.DepartmentId,
                                        InventoryItemId = sUIncrementDecrementDetailEntity.InventoryItemId,
                                        Unit = null,
                                        UnitPrice = sUIncrementDecrementDetailEntity.UnitPrice,
                                        IncrementQuantity = sUIncrementDecrementEntity.RefType == 205 ? sUIncrementDecrementDetailEntity.Quantity : 0,
                                        DecrementQuantity = sUIncrementDecrementEntity.RefType == 205 ? 0 : sUIncrementDecrementDetailEntity.Quantity,
                                        IncrementAmount = sUIncrementDecrementEntity.RefType == 205 ? sUIncrementDecrementDetailEntity.Amount : 0,
                                        DecrementAmount = sUIncrementDecrementEntity.RefType == 205 ? 0 : sUIncrementDecrementDetailEntity.Amount,
                                        JournalMemo = sUIncrementDecrementEntity.JournalMemo,
                                        Description = sUIncrementDecrementDetailEntity.Description,
                                        AccountNumber = sUIncrementDecrementDetailEntity.DebitAccount,
                                        RefDetailId = sUIncrementDecrementDetailEntity.RefDetailId
                                    };
                                    response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                #endregion
                            }
                        }

                    #endregion

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
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
        /// <param name="sUIncrementDecrementEntity">The b a deposit entity.</param>
        /// <returns></returns>
        public SUIncrementDecrementResponse UpdateSUIncrementDecrement(
            SUIncrementDecrementEntity sUIncrementDecrementEntity)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!sUIncrementDecrementEntity.Validate())
                {
                    foreach (var error in sUIncrementDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var sUIncrementDecrementByRefNo =
                        SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(sUIncrementDecrementEntity.RefNo, sUIncrementDecrementEntity.PostedDate);
                    if (sUIncrementDecrementByRefNo != null && sUIncrementDecrementByRefNo.RefId != sUIncrementDecrementEntity.RefId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã chứng từ đã tồn tại!";
                        return response;
                    }
                    response.Message = SUIncrementDecrementDao.UpdateSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(sUIncrementDecrementEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Delete detail and insert detail

                    // Xóa bảng SUIncrementDecrementDetail
                    response.Message = SUIncrementDecrementDetailDao.DeleteSUIncrementDecrementDetailByRefId(sUIncrementDecrementEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Xóa bảng SupplyLedger
                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(sUIncrementDecrementEntity.RefId, sUIncrementDecrementEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    if (sUIncrementDecrementEntity.SUIncrementDecrementDetails != null)
                        foreach (var sUIncrementDecrementDetailEntity in sUIncrementDecrementEntity.SUIncrementDecrementDetails)
                        {
                            if (sUIncrementDecrementEntity.RefType == (int)BuCA.Enum.RefType.SUDecrement)
                            {
                                AutoMapper(GetUnitsInDepartment(sUIncrementDecrementDetailEntity.InventoryItemId, sUIncrementDecrementDetailEntity.DepartmentId, sUIncrementDecrementDetailEntity.Quantity, sUIncrementDecrementDetailEntity.Description), response);
                                if (response.Acknowledge == AcknowledgeType.Failure)
                                    return response;
                            }

                            sUIncrementDecrementDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            sUIncrementDecrementDetailEntity.RefId = sUIncrementDecrementEntity.RefId;
                            response.Message =
                                SUIncrementDecrementDetailDao.InsertSUIncrementDecrementDetail(sUIncrementDecrementDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(sUIncrementDecrementEntity, sUIncrementDecrementDetailEntity);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            // Xóa bảng OriginalGeneralLedger
                            response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(sUIncrementDecrementEntity.RefId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = sUIncrementDecrementEntity.RefType,
                                RefId = sUIncrementDecrementEntity.RefId,
                                RefDetailId = sUIncrementDecrementDetailEntity.RefDetailId,
                                RefDate = sUIncrementDecrementEntity.RefDate,
                                RefNo = sUIncrementDecrementEntity.RefNo,
                                Amount = sUIncrementDecrementDetailEntity.Amount,
                                BudgetChapterCode = sUIncrementDecrementDetailEntity.BudgetChapterCode,
                                CreditAccount = sUIncrementDecrementDetailEntity.CreditAccount,
                                DebitAccount = sUIncrementDecrementDetailEntity.DebitAccount,
                                Description = sUIncrementDecrementDetailEntity.Description,
                                JournalMemo = sUIncrementDecrementEntity.JournalMemo,
                                SortOrder = sUIncrementDecrementDetailEntity.SortOrder,
                                PostedDate = sUIncrementDecrementEntity.PostedDate,

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

                            if (sUIncrementDecrementEntity.RefType == 205 || sUIncrementDecrementEntity.RefType == 206)
                            {
                                #region Insert SupplyLedger
                                if (sUIncrementDecrementDetailEntity.InventoryItemId != null)
                                {
                                    var supplyLedgerEntity = new SupplyLedgerEntity
                                    {
                                        SupplyLedgerId = Guid.NewGuid().ToString(),
                                        RefId = sUIncrementDecrementEntity.RefId,
                                        RefType = sUIncrementDecrementEntity.RefType,
                                        RefNo = sUIncrementDecrementEntity.RefNo,
                                        RefDate = sUIncrementDecrementEntity.RefDate,
                                        PostedDate = sUIncrementDecrementEntity.PostedDate,
                                        DepartmentId = sUIncrementDecrementDetailEntity.DepartmentId,
                                        InventoryItemId = sUIncrementDecrementDetailEntity.InventoryItemId,
                                        Unit = null,
                                        UnitPrice = sUIncrementDecrementDetailEntity.UnitPrice,
                                        IncrementQuantity = sUIncrementDecrementEntity.RefType == 205 ? sUIncrementDecrementDetailEntity.Quantity : 0,
                                        DecrementQuantity = sUIncrementDecrementEntity.RefType == 205 ? 0 : sUIncrementDecrementDetailEntity.Quantity,
                                        IncrementAmount = sUIncrementDecrementEntity.RefType == 205 ? sUIncrementDecrementDetailEntity.Amount : 0,
                                        DecrementAmount = sUIncrementDecrementEntity.RefType == 205 ? 0 : sUIncrementDecrementDetailEntity.Amount,
                                        JournalMemo = sUIncrementDecrementEntity.JournalMemo,
                                        Description = sUIncrementDecrementDetailEntity.Description,
                                        AccountNumber = sUIncrementDecrementDetailEntity.DebitAccount,
                                        RefDetailId = sUIncrementDecrementDetailEntity.RefDetailId
                                    };
                                    response.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                #endregion
                            }
                        }

                    #endregion

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
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
        /// <param name="sUIncrementDecrementId">The b a deposit identifier.</param>
        /// <returns></returns>
        public SUIncrementDecrementResponse DeleteSUIncrementDecrement(string sUIncrementDecrementId)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var sUIncrementDecrementEntity = SUIncrementDecrementDao.GetSUIncrementDecrement(sUIncrementDecrementId);
                if (sUIncrementDecrementEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {

                    #region Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(sUIncrementDecrementEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    // Xóa bảng SUIncrementDecrement
                    response.Message = SUIncrementDecrementDao.DeleteSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Xóa bảng SupplyLedger
                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(sUIncrementDecrementEntity.RefId, sUIncrementDecrementEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
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
        /// <param name="suIncrementDecrement">The su increment decrement.</param>
        /// <param name="suIncrementDecrementDetail">The su increment decrement detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(SUIncrementDecrementEntity suIncrementDecrement, SUIncrementDecrementDetailEntity suIncrementDecrementDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = suIncrementDecrementDetail.DebitAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = suIncrementDecrement.PostedDate,
                MovementDebitAmountOC = suIncrementDecrementDetail.Amount,
                MovementDebitAmount = suIncrementDecrementDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = suIncrementDecrementDetail.BudgetSourceId,
                BudgetChapterCode = suIncrementDecrementDetail.BudgetChapterCode,
                BudgetKindItemCode = suIncrementDecrementDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = suIncrementDecrementDetail.BudgetSubKindItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="suIncrementDecrement">The su increment decrement.</param>
        /// <param name="suIncrementDecrementDetail">The su increment decrement detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(SUIncrementDecrementEntity suIncrementDecrement, SUIncrementDecrementDetailEntity suIncrementDecrementDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = suIncrementDecrementDetail.CreditAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = suIncrementDecrement.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = suIncrementDecrementDetail.Amount,
                MovementCreditAmount = suIncrementDecrementDetail.Amount,
                BudgetSourceId = suIncrementDecrementDetail.BudgetSourceId,
                BudgetChapterCode = suIncrementDecrementDetail.BudgetChapterCode,
                BudgetKindItemCode = suIncrementDecrementDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = suIncrementDecrementDetail.BudgetSubKindItemCode,
                AccountingObjectId = suIncrementDecrementDetail.AccountingObjectId,
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
        /// <param name="suIncrementDecrement">The su increment decrement.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(SUIncrementDecrementEntity suIncrementDecrement)
        {
            var suIncrementDecrementDetails = SUIncrementDecrementDetailDao.GetSUIncrementDecrementDetailsByRefId(suIncrementDecrement.RefId);
            foreach (var suIncrementDecrementDetail in suIncrementDecrementDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(suIncrementDecrement, suIncrementDecrementDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(suIncrementDecrement, suIncrementDecrementDetail);
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
        /// <param name="suIncrementDecrement">The su increment decrement.</param>
        /// <param name="suIncrementDecrementDetail">The su increment decrement detail.</param>
        public void InsertAccountBalance(SUIncrementDecrementEntity suIncrementDecrement, SUIncrementDecrementDetailEntity suIncrementDecrementDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(suIncrementDecrement, suIncrementDecrementDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(suIncrementDecrement, suIncrementDecrementDetail);
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