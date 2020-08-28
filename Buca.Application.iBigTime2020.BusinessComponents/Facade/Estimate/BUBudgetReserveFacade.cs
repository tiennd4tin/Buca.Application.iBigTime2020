/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    /// <summary>
    /// BUBudgetReserveFacade
    /// </summary>
    public class BUBudgetReserveFacade
    {
        /// <summary>
        /// The bu plan receipt DAO
        /// </summary>
        private static readonly IBUBudgetReserveDao BUBudgetReserveDao = DataAccess.DataAccess.BUBudgetReserveDao;
        /// <summary>
        /// The bu plan receipt detail DAO
        /// </summary>
        private static readonly IBUBudgetReserveDetailDao BUBudgetReserveDetailDao = DataAccess.DataAccess.BUBudgetReserveDetailDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// Gets the bu plan receip.
        /// </summary>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReserves()
        {
            return BUBudgetReserveDao.GetBUBudgetReserves();
        }

        /// <summary>
        /// Gets the bu budget reserves by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReservesByRefId(string refId)
        {
            return BUBudgetReserveDao.GetBUBudgetReservesByRefId(refId);
        }

        /// <summary>
        /// Gets the bu plan receipt entity by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUBudgetReservetDetail">if set to <c>true</c> [is included bu plan receipt detail].</param>
        /// <returns></returns>
        public BUBudgetReserveEntity GetBUBudgetReserveByRefId(string refId, bool isIncludedBUBudgetReservetDetail)
        {
            var buPlanReceipt = BUBudgetReserveDao.GetBUBudgetReserveByRefId(refId);
            if (isIncludedBUBudgetReservetDetail && buPlanReceipt != null)
            {
                buPlanReceipt.BudgetReserveDetails = BUBudgetReserveDetailDao.GetBUBudgetReserveDetailsByRefId(buPlanReceipt.RefId);
            }
            return buPlanReceipt;
        }

        /// <summary>
        /// Gets the type of the bu plan receipt by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public List<BUBudgetReserveEntity> GetBUBudgetReservesByRefType(int refType)
        {
            return BUBudgetReserveDao.GetBUBudgetReservesByRefTypeId(refType);
        }

        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public BUBudgetReserveEntity GetBUBudgetReserveByRefId(string refId)
        {
            return BUBudgetReserveDao.GetBUBudgetReserveByRefId(refId);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public BUBudgetReserveResponse InsertBUBudgetReserve(BUBudgetReserveEntity buPlanReceipt)
        {
            var buPlanReceiptResponse = new BUBudgetReserveResponse { Acknowledge = AcknowledgeType.Success };


            if (buPlanReceipt != null && !buPlanReceipt.Validate())
            {
                foreach (var error in buPlanReceipt.ValidationErrors)
                    buPlanReceiptResponse.Message += error + Environment.NewLine;
                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                return buPlanReceiptResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (buPlanReceipt != null)
                {
                    var buPlanReceiptForExisting = BUBudgetReserveDao.GetBUBudgetReserve(buPlanReceipt.RefNo.Trim(), buPlanReceipt.PostedDate);
                    if (buPlanReceiptForExisting != null && buPlanReceiptForExisting.PostedDate.Year == buPlanReceipt.PostedDate.Year)
                    {
                        buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                        buPlanReceiptResponse.Message = @"Số chứng từ '" + buPlanReceipt.RefNo.Trim() + @"' đã tồn tại!";
                        return buPlanReceiptResponse;
                    }

                    buPlanReceipt.RefId = Guid.NewGuid().ToString();
                    buPlanReceiptResponse.Message = BUBudgetReserveDao.InsertBUBudgetReserve(buPlanReceipt);

                    if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                    {
                        buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                        return buPlanReceiptResponse;
                    }

                    foreach (var buPlanReceiptDetail in buPlanReceipt.BudgetReserveDetails)
                    {
                        buPlanReceiptDetail.RefId = buPlanReceipt.RefId;
                        buPlanReceiptDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!buPlanReceiptDetail.Validate())
                        {
                            foreach (var error in buPlanReceiptDetail.ValidationErrors)
                                buPlanReceiptResponse.Message += error + Environment.NewLine;
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanReceiptResponse;
                        }
                        buPlanReceiptResponse.Message =
                            BUBudgetReserveDetailDao.InsertBUBudgetReserveDetail(buPlanReceiptDetail);
                        if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanReceiptResponse;
                        }

                        #region Insert to AccountBalance

                        InsertAccountBalance(buPlanReceipt, buPlanReceiptDetail);

                        #endregion

                        #region Insert into GeneralLedger
                        if (buPlanReceiptDetail.BankAccount != null)
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = buPlanReceipt.RefType,
                                RefNo = buPlanReceipt.RefNo,
                                ProjectId = buPlanReceiptDetail.ProjectId,
                                BudgetSourceId = buPlanReceiptDetail.BudgetSourceId,
                                Description = buPlanReceiptDetail.Description,
                                RefDetailId = buPlanReceiptDetail.RefDetailId,
                                ExchangeRate = buPlanReceipt.ExchangeRate,
                                BudgetSubKindItemCode = buPlanReceiptDetail.BudgetSubKindItemCode,
                                CurrencyCode = buPlanReceipt.CurrencyCode,
                                BudgetKindItemCode = buPlanReceiptDetail.BudgetKindItemCode,
                                RefId = buPlanReceipt.RefId,
                                PostedDate = buPlanReceipt.PostedDate,
                                BudgetItemCode = buPlanReceiptDetail.BudgetItemCode,
                                ListItemId = buPlanReceiptDetail.ListItemId,
                                BudgetSubItemCode = buPlanReceiptDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = buPlanReceiptDetail.BudgetDetailItemCode,
                                //AccountNumber = buPlanReceiptDetail.DebitAccount,
                                //DebitAmount = buPlanReceiptDetail.DebitAccount == null ? 0 : buPlanReceiptDetail.Amount,
                                //DebitAmountOC = buPlanReceiptDetail.DebitAccount == null ? 0 : buPlanReceiptDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = buPlanReceiptDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = buPlanReceipt.JournalMemo,
                                RefDate = buPlanReceipt.RefDate,
                                SortOrder = buPlanReceiptDetail.SortOrder,
                            };

                            buPlanReceiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                            if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                            {
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanReceiptResponse;
                            }
                        }
                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = buPlanReceipt.RefType,
                            RefId = buPlanReceipt.RefId,
                            RefDetailId = buPlanReceiptDetail.RefDetailId,
                            RefDate = buPlanReceipt.RefDate,
                            RefNo = buPlanReceipt.RefNo,
                            Amount = buPlanReceiptDetail.Amount,
                            AmountOC = buPlanReceiptDetail.AmountOC,
                            //BankId = buPlanReceiptDetail.BankId,
                            BudgetChapterCode = buPlanReceipt.BudgetChapterCode,
                            BudgetDetailItemCode = buPlanReceiptDetail.BudgetDetailItemCode,
                            BudgetItemCode = buPlanReceiptDetail.BudgetItemCode,
                            BudgetKindItemCode = buPlanReceiptDetail.BudgetKindItemCode,
                            BudgetSourceId = buPlanReceiptDetail.BudgetSourceId,
                            BudgetSubItemCode = buPlanReceiptDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = buPlanReceiptDetail.BudgetSubKindItemCode,
                            //DebitAccount = buPlanReceiptDetail.DebitAccount,
                            Description = buPlanReceiptDetail.Description,
                            FundStructureId = buPlanReceiptDetail.FundStructureId,
                            JournalMemo = buPlanReceipt.JournalMemo,
                            ProjectId = buPlanReceiptDetail.ProjectId,
                            //ToBankId = buPlanReceiptDetail.BankId,
                            SortOrder = buPlanReceiptDetail.SortOrder,
                            PostedDate = buPlanReceipt.PostedDate,
                            CurrencyCode = buPlanReceipt.CurrencyCode,
                            ExchangeRate = buPlanReceipt.ExchangeRate,
          

                        };
                        buPlanReceiptResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanReceiptResponse;
                        }

                        #endregion
                    }

                    if (buPlanReceiptResponse.Message != null)
                    {
                        buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return buPlanReceiptResponse;
                    }
                    buPlanReceiptResponse.RefId = buPlanReceipt.RefId;
                    scope.Complete();
                }

                return buPlanReceiptResponse;
            }
        }

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="buPlanReceiptEntity">The bu plan receipt entity.</param>
        /// <returns>
        /// CAPaymentResponse.
        /// </returns>
        public BUBudgetReserveResponse UpdateBUBudgetReservet(BUBudgetReserveEntity buPlanReceiptEntity)
        {
            var buPlanReceiptResponse = new BUBudgetReserveResponse { Acknowledge = AcknowledgeType.Success };

            try
            {
                if (buPlanReceiptEntity != null && !buPlanReceiptEntity.Validate())
                {
                    foreach (var error in buPlanReceiptEntity.ValidationErrors)
                        buPlanReceiptResponse.Message += error + Environment.NewLine;
                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                    return buPlanReceiptResponse;
                }

                using (var scope = new TransactionScope())
                {
                    if (buPlanReceiptEntity != null)
                    {
                        var buPlanReceiptForExisting = BUBudgetReserveDao.GetBUBudgetReserve(buPlanReceiptEntity.RefNo.Trim(), buPlanReceiptEntity.PostedDate);
                        if (buPlanReceiptForExisting != null && buPlanReceiptForExisting.PostedDate.Year == buPlanReceiptEntity.PostedDate.Year)
                        {
                            if (buPlanReceiptForExisting.RefId != buPlanReceiptEntity.RefId)
                            {
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                buPlanReceiptResponse.Message = @"Số chứng từ '" + buPlanReceiptEntity.RefNo.Trim() + @"' đã tồn tại!";
                                return buPlanReceiptResponse;
                            }
                        }

                        buPlanReceiptResponse.Message = BUBudgetReserveDao.UpdateBUBudgetReserve(buPlanReceiptEntity);
                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        #region Update account balance
                        //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                        UpdateAccountBalance(buPlanReceiptEntity);
                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        #endregion

                        // Xóa bảng BUBudgetReservetDetail
                        buPlanReceiptResponse.Message = BUBudgetReserveDetailDao.DeleteBUBudgetReserveDetail(buPlanReceiptEntity.RefId);
                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        // Xóa bảng GeneralLedger
                        buPlanReceiptResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(buPlanReceiptEntity.RefId);
                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        // Xóa bảng OriginalGeneralLedger
                        buPlanReceiptResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(buPlanReceiptEntity.RefId);
                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        foreach (var buPlanReceiptDetail in buPlanReceiptEntity.BudgetReserveDetails)
                        {
                            buPlanReceiptDetail.RefId = buPlanReceiptEntity.RefId;
                            buPlanReceiptDetail.RefDetailId = Guid.NewGuid().ToString();

                            if (!buPlanReceiptDetail.Validate())
                            {
                                foreach (string error in buPlanReceiptDetail.ValidationErrors)
                                    buPlanReceiptResponse.Message += error + Environment.NewLine;
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanReceiptResponse;
                            }
                            buPlanReceiptResponse.Message = BUBudgetReserveDetailDao.InsertBUBudgetReserveDetail(buPlanReceiptDetail);
                            if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                            {
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanReceiptResponse;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(buPlanReceiptEntity, buPlanReceiptDetail);
                            if (buPlanReceiptResponse.Message != null)
                            {
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return buPlanReceiptResponse;
                            }

                            #endregion

                            #region Insert into GeneralLedger
                            if (buPlanReceiptDetail.BankAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = buPlanReceiptEntity.RefType,
                                    RefNo = buPlanReceiptEntity.RefNo,
                                    ProjectId = buPlanReceiptDetail.ProjectId,
                                    BudgetSourceId = buPlanReceiptDetail.BudgetSourceId,
                                    Description = buPlanReceiptDetail.Description,
                                    RefDetailId = buPlanReceiptDetail.RefDetailId,
                                    ExchangeRate = buPlanReceiptEntity.ExchangeRate,
                                    BudgetSubKindItemCode = buPlanReceiptDetail.BudgetSubKindItemCode,
                                    CurrencyCode = buPlanReceiptEntity.CurrencyCode,
                                    BudgetKindItemCode = buPlanReceiptDetail.BudgetKindItemCode,
                                    RefId = buPlanReceiptEntity.RefId,
                                    PostedDate = buPlanReceiptEntity.PostedDate,
                                    BudgetItemCode = buPlanReceiptDetail.BudgetItemCode,
                                    ListItemId = buPlanReceiptDetail.ListItemId,
                                    BudgetSubItemCode = buPlanReceiptDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = buPlanReceiptDetail.BudgetDetailItemCode,
                                    //AccountNumber = buPlanReceiptDetail.DebitAccount,
                                    //DebitAmount = buPlanReceiptDetail.DebitAccount == null ? 0 : buPlanReceiptDetail.Amount,
                                    //DebitAmountOC = buPlanReceiptDetail.DebitAccount == null ? 0 : buPlanReceiptDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = buPlanReceiptDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = buPlanReceiptEntity.JournalMemo,
                                    RefDate = buPlanReceiptEntity.RefDate,
                                    SortOrder = buPlanReceiptDetail.SortOrder
                                };

                                buPlanReceiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                                {
                                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return buPlanReceiptResponse;
                                }
                            }
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = buPlanReceiptEntity.RefType,
                                RefId = buPlanReceiptEntity.RefId,
                                RefDetailId = buPlanReceiptDetail.RefDetailId,
                                RefDate = buPlanReceiptEntity.RefDate,
                                RefNo = buPlanReceiptEntity.RefNo,
                                Amount = buPlanReceiptDetail.Amount,
                                AmountOC = buPlanReceiptDetail.AmountOC,
                                //BankId = buPlanReceiptDetail.BankId,
                                BudgetChapterCode = buPlanReceiptEntity.BudgetChapterCode,
                                BudgetDetailItemCode = buPlanReceiptDetail.BudgetDetailItemCode,
                                BudgetItemCode = buPlanReceiptDetail.BudgetItemCode,
                                BudgetKindItemCode = buPlanReceiptDetail.BudgetKindItemCode,
                                BudgetSourceId = buPlanReceiptDetail.BudgetSourceId,
                                BudgetSubItemCode = buPlanReceiptDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = buPlanReceiptDetail.BudgetSubKindItemCode,
                                //DebitAccount = buPlanReceiptDetail.DebitAccount,
                                Description = buPlanReceiptDetail.Description,
                                FundStructureId = buPlanReceiptDetail.FundStructureId,
                                JournalMemo = buPlanReceiptEntity.JournalMemo,
                                ProjectId = buPlanReceiptDetail.ProjectId,
                                //ToBankId = buPlanReceiptDetail.BankId,
                                SortOrder = buPlanReceiptDetail.SortOrder,
                                PostedDate = buPlanReceiptEntity.PostedDate,
                                CurrencyCode = buPlanReceiptEntity.CurrencyCode,
                                ExchangeRate = buPlanReceiptEntity.ExchangeRate,
         

                            };
                            buPlanReceiptResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(buPlanReceiptResponse.Message))
                            {
                                buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanReceiptResponse;
                            }

                            #endregion
                        }

                        if (buPlanReceiptResponse.Message != null)
                        {
                            buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanReceiptResponse;
                        }

                        buPlanReceiptResponse.RefId = buPlanReceiptEntity.RefId;
                    }
                    scope.Complete();
                }

                return buPlanReceiptResponse;
            }
            catch (Exception ex)
            {

                buPlanReceiptResponse.Message = ex.Message;
                return buPlanReceiptResponse;
            }

        }

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// CAPaymentResponse.
        /// </returns>
        public BUBudgetReserveResponse DeleteBUBudgetReservet(string refId)
        {
            var buPlanReceiptResponse = new BUBudgetReserveResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var buPlanReceiptEntityForDelete = BUBudgetReserveDao.GetBUBudgetReserveByRefId(refId);

                #region Update account balance
                // Cập nhật giá trị vào account balance trước khi xóa
                buPlanReceiptResponse.Message = UpdateAccountBalance(buPlanReceiptEntityForDelete);
                if (buPlanReceiptResponse.Message != null)
                {
                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanReceiptResponse;
                }

                #endregion

                buPlanReceiptResponse.Message = BUBudgetReserveDao.DeleteBUBudgetReserve(buPlanReceiptEntityForDelete);
                if (buPlanReceiptResponse.Message != null)
                {
                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanReceiptResponse;
                }

                //Xóa bảng GeneralLedger
                buPlanReceiptResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(buPlanReceiptEntityForDelete.RefId);
                if (buPlanReceiptResponse.Message != null)
                {
                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanReceiptResponse;
                }

                //Xóa bảng OriginalGeneralLedger
                buPlanReceiptResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(buPlanReceiptEntityForDelete.RefId);
                if (buPlanReceiptResponse.Message != null)
                {
                    buPlanReceiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanReceiptResponse;
                }
                scope.Complete();
            }

            return buPlanReceiptResponse;
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <param name="buPlanReceiptDetail">The bu plan receipt detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BUBudgetReserveEntity buPlanReceipt, BUBudgetReserveDetailEntity buPlanReceiptDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                //AccountNumber = buPlanReceiptDetail.DebitAccount,
                CurrencyCode = buPlanReceipt.CurrencyCode,
                ExchangeRate = buPlanReceipt.ExchangeRate,
                BalanceDate = buPlanReceipt.PostedDate,
                MovementDebitAmountOC = buPlanReceiptDetail.AmountOC,
                MovementDebitAmount = buPlanReceiptDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = buPlanReceiptDetail.BudgetSourceId,
                BudgetChapterCode = buPlanReceipt.BudgetChapterCode,
                BudgetKindItemCode = buPlanReceiptDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = buPlanReceiptDetail.BudgetSubKindItemCode,
                BudgetItemCode = buPlanReceiptDetail.BudgetItemCode,
                BudgetSubItemCode = buPlanReceiptDetail.BudgetSubItemCode,
                ProjectId = buPlanReceiptDetail.ProjectId,
                //BankAccount = buPlanReceiptDetail.BankId,
                FundStructureId = buPlanReceiptDetail.FundStructureId,
                BudgetDetailItemCode = buPlanReceiptDetail.BudgetDetailItemCode
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
                if (message != null) return message;
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
                if (message != null) return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BUBudgetReserveEntity buPlanReceipt)
        {
            var buPlanReceiptDetails = BUBudgetReserveDetailDao.GetBUBudgetReserveDetailsByRefId(buPlanReceipt.RefId);
            foreach (var buPlanReceiptDetail in buPlanReceiptDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(buPlanReceipt, buPlanReceiptDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null) return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <param name="buPlanReceiptDetail">The bu plan receipt detail.</param>
        public void InsertAccountBalance(BUBudgetReserveEntity buPlanReceipt, BUBudgetReserveDetailEntity buPlanReceiptDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(buPlanReceipt, buPlanReceiptDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);
        }

        #endregion
    }
}
