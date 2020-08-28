using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    public class BUPlanAdjustmentFacade
    {
        private static readonly IBUPlanAdjustmentDao BuPlanAdjustmentDao = DataAccess.DataAccess.BuPlanAdjustmentDao;
        private static readonly IBUPlanAdjustmentDetailDao BuPlanAdjustmentDetailDao = DataAccess.DataAccess.BuPlanAdjustmentDetailDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao =
            DataAccess.DataAccess.OriginalGeneralLedgerDao;

        public List<BUPlanAdjustmentEntity> GetBuPlanAdjustment()
        {
            return BuPlanAdjustmentDao.GetBuPlanAdjustment();
        }

        public List<BUPlanAdjustmentEntity> GetBUPlanReceiptVoucherByRefId(string refId)
        {
            return BuPlanAdjustmentDao.GetBuPlanAdjustmentVoucherbyRefId(refId);
        }

        public BUPlanAdjustmentEntity GetBuPlanAdjustmentbyRefId(string refId)
        {
            var buPlanAdjustment = BuPlanAdjustmentDao.GetBuPlanAdjustmentEntitybyRefId(refId);
            if (buPlanAdjustment != null)
            {
                buPlanAdjustment.BUPlanAdjustmentDetails = BuPlanAdjustmentDetailDao.GetBUPlanAdjustmentDetailbyRefId(buPlanAdjustment.RefId);
            }
            return buPlanAdjustment;
        }

        public BUPlanAdjustmentResponse InsertBuPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            var buPlanAdjustmentResponse = new BUPlanAdjustmentResponse { Acknowledge = AcknowledgeType.Success };


            if (buPlanAdjustment != null && !buPlanAdjustment.Validate())
            {
                foreach (var error in buPlanAdjustment.ValidationErrors)
                    buPlanAdjustmentResponse.Message += error + Environment.NewLine;
                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                return buPlanAdjustmentResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (buPlanAdjustment != null)
                {
                    var buPlanReceiptForExisting = BuPlanAdjustmentDao.GetBuPlanAdjustmentEntitybyRefNo(buPlanAdjustment.RefNo.Trim(), buPlanAdjustment.PostedDate);
                    if (buPlanReceiptForExisting != null && buPlanReceiptForExisting.PostedDate.Year == buPlanAdjustment.PostedDate.Year)
                    {
                        buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                        buPlanAdjustmentResponse.Message = @"Số chứng từ '" + buPlanAdjustment.RefNo.Trim() + @"' đã tồn tại!";
                        return buPlanAdjustmentResponse;
                    }

                    buPlanAdjustment.RefId = Guid.NewGuid().ToString();
                    buPlanAdjustmentResponse.Message = BuPlanAdjustmentDao.InsertBUPlanAdjustment(buPlanAdjustment);

                    if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                    {
                        buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                        return buPlanAdjustmentResponse;
                    }

                    foreach (var buPlanAdjustmentDetail in buPlanAdjustment.BUPlanAdjustmentDetails)
                    {
                        buPlanAdjustmentDetail.RefId = buPlanAdjustment.RefId;
                        buPlanAdjustmentDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!buPlanAdjustmentDetail.Validate())
                        {
                            foreach (var error in buPlanAdjustmentDetail.ValidationErrors)
                                buPlanAdjustmentResponse.Message += error + Environment.NewLine;
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanAdjustmentResponse;
                        }
                        buPlanAdjustmentResponse.Message =
                            BuPlanAdjustmentDetailDao.InsertBUPlanAdjustmentDetail(buPlanAdjustmentDetail);
                        if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanAdjustmentResponse;
                        }

                        #region Insert to AccountBalance

                        InsertAccountBalance(buPlanAdjustment, buPlanAdjustmentDetail);

                        #endregion

                        #region Insert into GeneralLedger
                        if (buPlanAdjustmentDetail.DebitAccount != null)
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = buPlanAdjustment.RefType,
                                RefNo = buPlanAdjustment.RefNo,
                                ProjectId = buPlanAdjustmentDetail.ProjectId,
                                ActivityId = buPlanAdjustmentDetail.ActivityId,
                                BudgetSourceId = buPlanAdjustmentDetail.BudgetSourceId,
                                Description = buPlanAdjustmentDetail.ItemName,
                                RefDetailId = buPlanAdjustmentDetail.RefDetailId,
                                ExchangeRate = buPlanAdjustment.ExchangeRate,
                                BudgetSubKindItemCode = buPlanAdjustmentDetail.BudgetSubKindItemCode,
                                CurrencyCode = buPlanAdjustment.CurrencyCode,
                                BudgetKindItemCode = buPlanAdjustmentDetail.BudgetKindItemCode,
                                RefId = buPlanAdjustment.RefId,
                                PostedDate = buPlanAdjustment.PostedDate,
                                BudgetItemCode = buPlanAdjustmentDetail.BudgetItemCode,
                                ListItemId = buPlanAdjustmentDetail.ListItemId,
                                BudgetSubItemCode = buPlanAdjustmentDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = buPlanAdjustmentDetail.BudgetDetailItemCode,
                                AccountNumber = buPlanAdjustmentDetail.DebitAccount,
                                DebitAmount = (buPlanAdjustmentDetail.DebitAccount == null ? 0 : buPlanAdjustmentDetail.AdjustmentAmount) / (buPlanAdjustment.ExchangeRate == null || buPlanAdjustment.ExchangeRate == 0 ? 1 : buPlanAdjustment.ExchangeRate),
                                DebitAmountOC = buPlanAdjustmentDetail.DebitAccount == null ? 0 : buPlanAdjustmentDetail.AdjustmentAmount,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = buPlanAdjustmentDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = buPlanAdjustment.JournalMemo,
                                RefDate = buPlanAdjustment.RefDate,
                                SortOrder = buPlanAdjustmentDetail.SortOrder,
                                CashWithDrawTypeId = 28,
                                ContractId = buPlanAdjustmentDetail.ContractId,
                                CapitalPlanId = buPlanAdjustmentDetail.CapitalPlanId,
                                BudgetChapterCode = buPlanAdjustmentDetail.BudgetChapterCode
                            };

                            buPlanAdjustmentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                            if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                            {
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanAdjustmentResponse;
                            }
                        }
                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = buPlanAdjustment.RefType,
                            RefId = buPlanAdjustment.RefId,
                            RefDetailId = buPlanAdjustmentDetail.RefDetailId,
                            RefDate = buPlanAdjustment.RefDate,
                            RefNo = buPlanAdjustment.RefNo,
                            Amount = buPlanAdjustmentDetail.AdjustmentAmount,
                            AmountOC = buPlanAdjustmentDetail.AdjustmentAmount,
                            BankId = buPlanAdjustmentDetail.BankAccount,
                            BudgetChapterCode = buPlanAdjustmentDetail.BudgetChapterCode,
                            BudgetDetailItemCode = buPlanAdjustmentDetail.BudgetDetailItemCode,
                            BudgetItemCode = buPlanAdjustmentDetail.BudgetItemCode,
                            BudgetKindItemCode = buPlanAdjustmentDetail.BudgetKindItemCode,
                            BudgetSourceId = buPlanAdjustmentDetail.BudgetSourceId,
                            BudgetSubItemCode = buPlanAdjustmentDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = buPlanAdjustmentDetail.BudgetSubKindItemCode,
                            DebitAccount = buPlanAdjustmentDetail.DebitAccount,
                            Description = buPlanAdjustmentDetail.ItemName,
                            FundStructureId = buPlanAdjustmentDetail.FundStructureId,
                            JournalMemo = buPlanAdjustment.JournalMemo,
                            ProjectId = buPlanAdjustmentDetail.ProjectId,
                            ActivityId = buPlanAdjustmentDetail.ActivityId,
                            //ToBankId = buPlanAdjustmentDetail.BankAccount,
                            SortOrder = buPlanAdjustmentDetail.SortOrder,
                            PostedDate = buPlanAdjustment.PostedDate,
                            CurrencyCode = buPlanAdjustment.CurrencyCode,
                            ExchangeRate = buPlanAdjustment.ExchangeRate,
                            CashWithDrawTypeId = 28,
                            ContractId = buPlanAdjustmentDetail.ContractId,
                        };
                        buPlanAdjustmentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return buPlanAdjustmentResponse;
                        }

                        #endregion
                    }

                    if (buPlanAdjustmentResponse.Message != null)
                    {
                        buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return buPlanAdjustmentResponse;
                    }
                    buPlanAdjustmentResponse.RefId = buPlanAdjustment.RefId;
                    scope.Complete();
                }

                return buPlanAdjustmentResponse;
            }

        }
        public BUPlanAdjustmentResponse UpdateBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            var buPlanAdjustmentResponse = new BUPlanAdjustmentResponse { Acknowledge = AcknowledgeType.Success };

            try
            {
                if (buPlanAdjustment != null && !buPlanAdjustment.Validate())
                {
                    foreach (var error in buPlanAdjustment.ValidationErrors)
                        buPlanAdjustmentResponse.Message += error + Environment.NewLine;
                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                    return buPlanAdjustmentResponse;
                }

                using (var scope = new TransactionScope())
                {
                    if (buPlanAdjustment != null)
                    {
                        var buPlanReceiptForExisting = BuPlanAdjustmentDao.GetBuPlanAdjustmentEntitybyRefNo(buPlanAdjustment.RefNo.Trim(), buPlanAdjustment.PostedDate);
                        if (buPlanReceiptForExisting != null && buPlanReceiptForExisting.PostedDate.Year == buPlanAdjustment.PostedDate.Year)
                        {
                            if (buPlanReceiptForExisting.RefId != buPlanAdjustment.RefId)
                            {
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                buPlanAdjustmentResponse.Message = @"Số chứng từ '" + buPlanAdjustment.RefNo.Trim() + @"' đã tồn tại!";
                                return buPlanAdjustmentResponse;
                            }
                        }

                        buPlanAdjustmentResponse.Message = BuPlanAdjustmentDao.UpdateBUPlanAdjustment(buPlanAdjustment);
                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }

                        #region Update account balance
                        //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                        UpdateAccountBalance(buPlanAdjustment);
                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }

                        #endregion

                        // Xóa bảng BUPlanReceiptDetail
                        buPlanAdjustmentResponse.Message = BuPlanAdjustmentDetailDao.DeleteBUPlanAdjustmentDetail(buPlanAdjustment.RefId);
                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }
                        #region
                        // Xóa bảng GeneralLedger
                        buPlanAdjustmentResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(buPlanAdjustment.RefId);
                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }

                        //Xóa bảng OriginalGeneralLedger
                        buPlanAdjustmentResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(buPlanAdjustment.RefId);
                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }
                        #endregion
                        foreach (var buPlanAdjustmentDetail in buPlanAdjustment.BUPlanAdjustmentDetails)
                        {
                            buPlanAdjustmentDetail.RefId = buPlanAdjustment.RefId;
                            buPlanAdjustmentDetail.RefDetailId = Guid.NewGuid().ToString();

                            if (!buPlanAdjustmentDetail.Validate())
                            {
                                foreach (string error in buPlanAdjustmentDetail.ValidationErrors)
                                    buPlanAdjustmentResponse.Message += error + Environment.NewLine;
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanAdjustmentResponse;
                            }
                            buPlanAdjustmentResponse.Message = BuPlanAdjustmentDetailDao.InsertBUPlanAdjustmentDetail(buPlanAdjustmentDetail);
                            if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                            {
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanAdjustmentResponse;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(buPlanAdjustment, buPlanAdjustmentDetail);
                            if (buPlanAdjustmentResponse.Message != null)
                            {
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return buPlanAdjustmentResponse;
                            }

                            #endregion

                            #region Insert into GeneralLedger
                            if (buPlanAdjustmentDetail.DebitAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = buPlanAdjustment.RefType,
                                    RefNo = buPlanAdjustment.RefNo,
                                    ProjectId = buPlanAdjustmentDetail.ProjectId,
                                    ActivityId = buPlanAdjustmentDetail.ActivityId,
                                    BudgetSourceId = buPlanAdjustmentDetail.BudgetSourceId,
                                    Description = buPlanAdjustmentDetail.ItemName,
                                    RefDetailId = buPlanAdjustmentDetail.RefDetailId,
                                    ExchangeRate = buPlanAdjustment.ExchangeRate,
                                    BudgetSubKindItemCode = buPlanAdjustmentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = buPlanAdjustment.CurrencyCode,
                                    BudgetKindItemCode = buPlanAdjustmentDetail.BudgetKindItemCode,
                                    RefId = buPlanAdjustment.RefId,
                                    PostedDate = buPlanAdjustment.PostedDate,
                                    BudgetItemCode = buPlanAdjustmentDetail.BudgetItemCode,
                                    ListItemId = buPlanAdjustmentDetail.ListItemId,
                                    BudgetSubItemCode = buPlanAdjustmentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = buPlanAdjustmentDetail.BudgetDetailItemCode,
                                    AccountNumber = buPlanAdjustmentDetail.DebitAccount,
                                    DebitAmount = buPlanAdjustmentDetail.DebitAccount == null ? 0 : buPlanAdjustmentDetail.AdjustmentAmount * buPlanAdjustment.ExchangeRate,
                                    DebitAmountOC = buPlanAdjustmentDetail.DebitAccount == null ? 0 : buPlanAdjustmentDetail.AdjustmentAmount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = buPlanAdjustmentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = buPlanAdjustment.JournalMemo,
                                    RefDate = buPlanAdjustment.RefDate,
                                    SortOrder = buPlanAdjustmentDetail.SortOrder,
                                    BankId = buPlanAdjustmentDetail.BankAccount,
                                    CashWithDrawTypeId = 28,
                                    ContractId = buPlanAdjustmentDetail.ContractId,
                                    CapitalPlanId = buPlanAdjustmentDetail.CapitalPlanId,
                                    BudgetChapterCode = buPlanAdjustmentDetail.BudgetChapterCode
                                };

                                buPlanAdjustmentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                                {
                                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return buPlanAdjustmentResponse;
                                }
                            }
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = buPlanAdjustment.RefType,
                                RefId = buPlanAdjustment.RefId,
                                RefDetailId = buPlanAdjustmentDetail.RefDetailId,
                                RefDate = buPlanAdjustment.RefDate,
                                RefNo = buPlanAdjustment.RefNo,
                                Amount = buPlanAdjustmentDetail.AdjustmentAmount * buPlanAdjustment.ExchangeRate,
                                AmountOC = buPlanAdjustmentDetail.AdjustmentAmount,
                                BankId = buPlanAdjustmentDetail.BankAccount,
                                BudgetChapterCode = buPlanAdjustmentDetail.BudgetChapterCode,
                                BudgetDetailItemCode = buPlanAdjustmentDetail.BudgetDetailItemCode,
                                BudgetItemCode = buPlanAdjustmentDetail.BudgetItemCode,
                                BudgetKindItemCode = buPlanAdjustmentDetail.BudgetKindItemCode,
                                BudgetSourceId = buPlanAdjustmentDetail.BudgetSourceId,
                                BudgetSubItemCode = buPlanAdjustmentDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = buPlanAdjustmentDetail.BudgetSubKindItemCode,
                                DebitAccount = buPlanAdjustmentDetail.DebitAccount,
                                Description = buPlanAdjustmentDetail.ItemName,
                                FundStructureId = buPlanAdjustmentDetail.FundStructureId,
                                JournalMemo = buPlanAdjustment.JournalMemo,
                                ProjectId = buPlanAdjustmentDetail.ProjectId,
                                ActivityId = buPlanAdjustmentDetail.ActivityId,
                                //ToBankId = buPlanAdjustmentDetail.BankAccount,
                                SortOrder = buPlanAdjustmentDetail.SortOrder,
                                PostedDate = buPlanAdjustment.PostedDate,
                                CurrencyCode = buPlanAdjustment.CurrencyCode,
                                ExchangeRate = buPlanAdjustment.ExchangeRate,
                                CashWithDrawTypeId = 28,
                                ContractId = buPlanAdjustmentDetail.ContractId,
                            };
                            buPlanAdjustmentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(buPlanAdjustmentResponse.Message))
                            {
                                buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                                return buPlanAdjustmentResponse;
                            }

                            #endregion
                        }

                        if (buPlanAdjustmentResponse.Message != null)
                        {
                            buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return buPlanAdjustmentResponse;
                        }

                        buPlanAdjustmentResponse.RefId = buPlanAdjustment.RefId;
                    }
                    scope.Complete();
                }

                return buPlanAdjustmentResponse;
            }
            catch (Exception ex)
            {

                buPlanAdjustmentResponse.Message = ex.Message;
                return buPlanAdjustmentResponse;
            }

        }

        public BUPlanAdjustmentResponse DeleteBuPlanAdjustment(string refId)
        {
            var buPlanAdjustmentResponse = new BUPlanAdjustmentResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var buPlanAdjustmentEntityForDelete = BuPlanAdjustmentDao.GetBuPlanAdjustmentEntitybyRefId(refId);

                #region Update account balance
                // Cập nhật giá trị vào account balance trước khi xóa
                buPlanAdjustmentResponse.Message = UpdateAccountBalance(buPlanAdjustmentEntityForDelete);
                if (buPlanAdjustmentResponse.Message != null)
                {
                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanAdjustmentResponse;
                }

                #endregion

                buPlanAdjustmentResponse.Message = BuPlanAdjustmentDao.DeleteBUPlanAdjustment(buPlanAdjustmentEntityForDelete);
                if (buPlanAdjustmentResponse.Message != null)
                {
                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanAdjustmentResponse;
                }

                //Xóa bảng GeneralLedger
                buPlanAdjustmentResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(buPlanAdjustmentEntityForDelete.RefId);
                if (buPlanAdjustmentResponse.Message != null)
                {
                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanAdjustmentResponse;
                }

                ////Xóa bảng OriginalGeneralLedger
                buPlanAdjustmentResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(buPlanAdjustmentEntityForDelete.RefId);
                if (buPlanAdjustmentResponse.Message != null)
                {
                    buPlanAdjustmentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return buPlanAdjustmentResponse;
                }
                scope.Complete();
            }

            return buPlanAdjustmentResponse;
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <param name="buPlanReceiptDetail">The bu plan receipt detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BUPlanAdjustmentEntity buPlanAdjustment, BUPlanAdjustmentDetailEntity buPlanAdjustmentDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = buPlanAdjustmentDetail.DebitAccount,
                // CurrencyCode = buPlanAdjustment.CurrencyCode,
                //ExchangeRate = buPlanAdjustment.ExchangeRate,
                BalanceDate = buPlanAdjustment.PostedDate,
                MovementDebitAmountOC = buPlanAdjustmentDetail.AdjustmentAmount,
                //MovementDebitAmount = buPlanAdjustmentDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = buPlanAdjustmentDetail.BudgetSourceId,
                BudgetChapterCode = buPlanAdjustmentDetail.BudgetChapterCode,
                BudgetKindItemCode = buPlanAdjustmentDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = buPlanAdjustmentDetail.BudgetSubKindItemCode,
                BudgetItemCode = buPlanAdjustmentDetail.BudgetItemCode,
                BudgetSubItemCode = buPlanAdjustmentDetail.BudgetSubItemCode,
                ProjectId = buPlanAdjustmentDetail.ProjectId,
                ActivityId = buPlanAdjustmentDetail.ActivityId,
                BankAccount = buPlanAdjustmentDetail.BankAccount,
                FundStructureId = buPlanAdjustmentDetail.FundStructureId,
                BudgetDetailItemCode = buPlanAdjustmentDetail.BudgetDetailItemCode
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
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BUPlanAdjustmentEntity buPlanAdjustment)
        {
            var buPlanAdjustmentDetail = BuPlanAdjustmentDetailDao.GetBUPlanAdjustmentDetailbyRefId(buPlanAdjustment.RefId);
            foreach (var buPlanAdjustmentDetails in buPlanAdjustmentDetail)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(buPlanAdjustment, buPlanAdjustmentDetails);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <param name="buPlanReceiptDetail">The bu plan receipt detail.</param>
        public void InsertAccountBalance(BUPlanAdjustmentEntity buPlanAdjustment, BUPlanAdjustmentDetailEntity buPlanAdjustmentDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(buPlanAdjustment, buPlanAdjustmentDetail);
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
