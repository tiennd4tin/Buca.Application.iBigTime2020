/***********************************************************************
 * <copyright file="BUPlanWithdrawFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 25/9/2014    LinhMC  Them dieu kien kiem tra trung so chung tu: neu la chuyen doi du lieu thi khong check
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Cash;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    /// <summary>
    /// BUPlanWithdrawFacade class
    /// </summary>
    public class BUPlanWithdrawFacade
    {
        #region Data Transfer Object

        private static readonly IBUPlanWithdrawDao BUPlanWithdrawDao = DataAccess.DataAccess.BUPlanWithdrawDao;
        private static readonly IBUPlanWithdrawDetailDao BUPlanWithdrawDetailDao = DataAccess.DataAccess.BUPlanWithdrawDetailDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly ICAReceiptDao CAReceiptDao = DataAccess.DataAccess.CAReceiptDao;
        /// <summary>
        /// The original general ledger DAO
        /// </summary>
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;


        //private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;

        //private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;

        //private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        #endregion

        //public List<BUPlanWithdrawEntity> GetBUPlanWithdrawesByRefTypeId(int refTypeId, int year)
        //{
        //    return BUPlanWithdrawDao.GetBUPlanWithdrawesByRefTypeId(refTypeId, year);
        //}

        //public BUPlanWithdrawEntity GetBUPlanWithdrawByDateMonth(DateTime dateMonth)
        //{
        //    return BUPlanWithdrawDao.GetBUPlanWithdrawForSalaryByDateMonth(dateMonth);
        //}

        /// <summary>
        /// Gets the ca planWithdraws.
        /// </summary>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        public IList<BUPlanWithdrawEntity> GetBUPlanWithdraws()
        {
            return BUPlanWithdrawDao.GetBUPlanWithdraws();
        }

        /// <summary>
        /// Gets the ca planWithdraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        public BUPlanWithdrawEntity GetBUPlanWithdrawByRefNo(string refNo)
        {
            return BUPlanWithdrawDao.GetBUPlanWithdrawByRefNo(refNo);
        }
        /// <summary>
        /// Gets the bu plan withdraw by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        public IList<BUPlanWithdrawEntity> GetBUPlanWithdrawByRefTypeId(int refTypeId)
        {
            return BUPlanWithdrawDao.GetBUPlanWithdrawByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ca planWithdraw by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUPlanWithdrawDetail">if set to <c>true</c> [is included ca planWithdraw detail].</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        public BUPlanWithdrawEntity GetBUPlanWithdrawByRefId(string refId, bool isIncludedBUPlanWithdrawDetail)
        {
            var planWithdraw = BUPlanWithdrawDao.GetBUPlanWithdraw(refId);
            if (isIncludedBUPlanWithdrawDetail && planWithdraw != null)
            {
                planWithdraw.BUPlanWithdrawDetails = BUPlanWithdrawDetailDao.GetBUPlanWithdrawDetailsByRefId(planWithdraw.RefId);
            }
            return planWithdraw;
        }

        /// <summary>
        /// Inserts the ca planWithdraw.
        /// </summary>
        /// <param name="planWithdrawEntity">The planWithdraw entity.</param>
        /// <returns>BUPlanWithdrawResponse.</returns>
        public BUPlanWithdrawResponse InsertBUPlanWithdraw(BUPlanWithdrawEntity planWithdrawEntity)
        {
            var planWithdrawResponse = new BUPlanWithdrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (planWithdrawEntity != null && !planWithdrawEntity.Validate())
                {
                    foreach (var error in planWithdrawEntity.ValidationErrors)
                        planWithdrawResponse.Message += error + Environment.NewLine;
                    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                    return planWithdrawResponse;
                }

                using (var scope = new TransactionScope())
                {
                    if (planWithdrawEntity != null)
                    {
                        //check ma trung
                        var planWithdrawEntityExisted = BUPlanWithdrawDao.GetBUPlanWithdrawByRefNoRefType(planWithdrawEntity.RefNo.Trim(), planWithdrawEntity.RefType, planWithdrawEntity.PostedDate);
                        if (planWithdrawEntityExisted != null && planWithdrawEntityExisted.PostedDate.Year == planWithdrawEntity.PostedDate.Year)
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            planWithdrawResponse.Message = @"Số chứng từ '" + planWithdrawEntity.RefNo + @"' đã tồn tại!";
                            return planWithdrawResponse;
                        }

                        planWithdrawEntity.RefId = Guid.NewGuid().ToString();
                        planWithdrawResponse.Message = BUPlanWithdrawDao.InsertBUPlanWithdraw(planWithdrawEntity);

                        if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            return planWithdrawResponse;
                        }

                        foreach (var planWithdrawDetail in planWithdrawEntity.BUPlanWithdrawDetails)
                        {
                            planWithdrawDetail.RefId = planWithdrawEntity.RefId;
                            planWithdrawDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!planWithdrawDetail.Validate())
                            {
                                foreach (var error in planWithdrawDetail.ValidationErrors)
                                    planWithdrawResponse.Message += error + Environment.NewLine;
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }
                            planWithdrawResponse.Message = BUPlanWithdrawDetailDao.InsertBUPlanWithdrawDetail(planWithdrawDetail);
                            if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                            {
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = planWithdrawEntity.RefType,
                                RefId = planWithdrawEntity.RefId,
                                RefDetailId = planWithdrawDetail.RefDetailId,
                                OrgRefDate = planWithdrawDetail.OrgRefDate,
                                OrgRefNo = planWithdrawDetail.OrgRefNo,
                                RefDate = planWithdrawEntity.RefDate,
                                RefNo = planWithdrawEntity.RefNo,
                                Amount = planWithdrawDetail.Amount,
                                AmountOC = planWithdrawDetail.AmountOC,
                                BudgetChapterCode = planWithdrawDetail.BudgetChapterCode,
                                BudgetDetailItemCode = planWithdrawDetail.BudgetDetailItemCode,
                                BudgetItemCode = planWithdrawDetail.BudgetItemCode,
                                BudgetKindItemCode = planWithdrawDetail.BudgetKindItemCode,
                                BudgetSourceId = planWithdrawDetail.BudgetSourceId,
                                BudgetSubItemCode = planWithdrawDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = planWithdrawDetail.BudgetSubKindItemCode,
                                CreditAccount = planWithdrawDetail.CreditAccount,
                                Description = planWithdrawDetail.Description,
                                FundStructureId = planWithdrawDetail.FundStructureId,
                                //       TaxAmount = planWithdrawDetail.TaxAmount,
                                JournalMemo = planWithdrawEntity.JournalMemo,
                                ProjectId = planWithdrawDetail.ProjectId,
                                PostedDate = planWithdrawEntity.PostedDate,
                                CurrencyCode = planWithdrawEntity.CurrencyCode,
                                ExchangeRate = planWithdrawEntity.ExchangeRate,
                            };
                            planWithdrawResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                            {
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }

                            #endregion


                            //// insert bang JourentryAccount
                            //var jourentryAccount = journalEntryAccounts[i];
                            //jourentryAccount.RefId = planWithdrawDetail.RefId;
                            //jourentryAccount.RefDetailId = iBUPlanWithdrawDetailId;
                            //#region " jourentryAccount: thay đổi thông tin theo đối tượng Master"
                            //int accountingObjectType = planWithdrawEntity.AccountingObjectType == null ? 0 : int.Parse(planWithdrawEntity.AccountingObjectType.ToString());
                            //switch (accountingObjectType)
                            //{
                            //    case 0:
                            //        jourentryAccount.VendorId = planWithdrawEntity.VendorId;
                            //        break;
                            //    case 1:
                            //        jourentryAccount.EmployeeId = planWithdrawEntity.EmployeeId;
                            //        break;
                            //    case 2:
                            //        jourentryAccount.AccountingObjectId = planWithdrawEntity.AccountingObjectId;
                            //        break;
                            //    case 3:
                            //        jourentryAccount.CustomerId = planWithdrawEntity.CustomerId;
                            //        break;
                            //}

                            ////LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                            //if (jourentryAccount.AccountingObjectId == null)
                            //{
                            //    jourentryAccount.AccountingObjectId = planWithdrawDetail.AccountingObjectId;
                            //}
                            //#endregion

                            //if (!jourentryAccount.Validate())
                            //{
                            //    foreach (string error in jourentryAccount.ValidationErrors)
                            //        planWithdrawResponse.Message += error + Environment.NewLine;
                            //    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            //    return planWithdrawResponse;
                            //}
                            //JournalEntryAccountDao.InsertDoubleJournalEntryAccount(jourentryAccount);
                            //i = i + 1;
                        }

                        //foreach (var buPlanDrawDetail in planWithdrawEntity.BUPlanWithdrawDetails)
                        //{
                        //    var generalLedgerEntity = new GeneralLedgerEntity
                        //    {
                        //        RefType = planWithdrawEntity.RefType,
                        //        RefNo = planWithdrawEntity.RefNo,
                        //        // AccountingObjectId = buPlanReceiptEntity.AccountingObjectId,
                        //        //BankId = buPlanReceiptEntity.BankId,
                        //        // BudgetChapterCode = buPlanReceiptDetail.BudgetChapterCode,
                        //        ProjectId = buPlanDrawDetail.ProjectId,
                        //        BudgetSourceId = buPlanDrawDetail.BudgetSourceId,
                        //        Description = buPlanDrawDetail.Description,
                        //        RefDetailId = buPlanDrawDetail.RefDetailId,
                        //        ExchangeRate = planWithdrawEntity.ExchangeRate,
                        //        // ActivityId = buPlanReceiptDetail.ActivityId,
                        //        BudgetSubKindItemCode = buPlanDrawDetail.BudgetSubKindItemCode,
                        //        CurrencyCode = planWithdrawEntity.CurrencyCode,
                        //        BudgetKindItemCode = buPlanDrawDetail.BudgetKindItemCode,
                        //        RefId = planWithdrawEntity.RefId,
                        //        PostedDate = planWithdrawEntity.PostedDate,
                        //        //MethodDistributeId = buPlanReceiptDetail.MethodDistributeId,
                        //        //OrgRefNo = buPlanReceiptDetail.OrgRefNo,
                        //        // OrgRefDate = buPlanReceiptDetail.OrgRefDate,
                        //        BudgetItemCode = buPlanDrawDetail.BudgetItemCode,
                        //        ListItemId = buPlanDrawDetail.ListItemId,
                        //        BudgetSubItemCode = buPlanDrawDetail.BudgetSubItemCode,
                        //        BudgetDetailItemCode = buPlanDrawDetail.BudgetDetailItemCode,
                        //        //CashWithDrawTypeId = buPlanReceiptDetail.CashWithDrawTypeId,
                        //        //AccountNumber = buPlanDrawDetail.DebitAccount,
                        //        CorrespondingAccountNumber = buPlanDrawDetail.CreditAccount,
                        //        DebitAmount = buPlanDrawDetail.Amount,
                        //        DebitAmountOC = buPlanDrawDetail.AmountOC,
                        //        CreditAmount = 0,
                        //        CreditAmountOC = 0,
                        //        FundStructureId = buPlanDrawDetail.FundStructureId,
                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                        //        JournalMemo = planWithdrawEntity.JournalMemo,
                        //        RefDate = planWithdrawEntity.RefDate
                        //    };
                        //    planWithdrawResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                        //    if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        //    {
                        //        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        //        return planWithdrawResponse;
                        //    }

                        //    //insert lan 2
                        //    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                        //     generalLedgerEntity.AccountNumber = buPlanDrawDetail.CreditAccount;
                        //    //generalLedgerEntity.CorrespondingAccountNumber = buPlanDrawDetail.DebitAccount;
                        //    generalLedgerEntity.DebitAmount = 0;
                        //    generalLedgerEntity.DebitAmountOC = 0;
                        //    generalLedgerEntity.CreditAmount = buPlanDrawDetail.Amount;
                        //    generalLedgerEntity.CreditAmountOC = buPlanDrawDetail.AmountOC;
                        //    planWithdrawResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                        //    if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        //    {
                        //        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        //        return planWithdrawResponse;
                        //    }
                        //}



                        planWithdrawResponse.RefId = planWithdrawEntity.RefId;
                        // Kiểm tra đã tồn tại trong bảng Account Balance
                        //foreach (var accountBalanceEntity in accountBalances)
                        //{
                        //    var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                        //    if (obAccoutBalanceExit != null)
                        //    {
                        //        // cập nhật bên TK nợ
                        //        if (accountBalanceEntity.MovementCreditAmountOC == 0)
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementDebitAmountExchange =
                        //                obAccoutBalanceExit.MovementDebitAmountExchange +
                        //                accountBalanceEntity.MovementDebitAmountExchange;
                        //            obAccoutBalanceExit.MovementDebitAmountOC =
                        //                obAccoutBalanceExit.MovementDebitAmountOC +
                        //                accountBalanceEntity.MovementDebitAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //        else
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementCreditAmountExchange =
                        //                obAccoutBalanceExit.MovementCreditAmountExchange +
                        //                accountBalanceEntity.MovementCreditAmountExchange;
                        //            obAccoutBalanceExit.MovementCreditAmountOC =
                        //                obAccoutBalanceExit.MovementCreditAmountOC +
                        //                accountBalanceEntity.MovementCreditAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                        //    }
                        //}
                        //var autoNumber = AutoNumberDao.GetAutoNumberByRefType(planWithdrawEntity.RefType);
                        //autoNumber.Value += 1;
                        //if (planWithdrawEntity.RefType != 600)//Khong cap nhat khi la chung tu luong
                        //{
                        //    planWithdrawResponse.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                        //}
                    }

                    if (planWithdrawResponse.Message != null)
                    {
                        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return planWithdrawResponse;
                    }
                    scope.Complete();
                }
                return planWithdrawResponse;
            }
            catch (Exception ex)
            {
                planWithdrawResponse.Message = ex.Message;
                return planWithdrawResponse;
            }
        }

        /// <summary>
        /// Updates the ca planWithdraw.
        /// </summary>
        /// <param name="planWithdrawEntity">The planWithdraw entity.</param>
        /// <returns>BUPlanWithdrawResponse.</returns>
        public BUPlanWithdrawResponse UpdateBUPlanWithdraw(BUPlanWithdrawEntity planWithdrawEntity)
        {
            var planWithdrawResponse = new BUPlanWithdrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (planWithdrawEntity != null && !planWithdrawEntity.Validate())
                {
                    foreach (var error in planWithdrawEntity.ValidationErrors)
                        planWithdrawResponse.Message += error + Environment.NewLine;
                    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                    return planWithdrawResponse;
                }

                using (var scope = new TransactionScope())
                {
                    // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                    //accountBalances.Clear();
                    if (planWithdrawEntity != null)
                    {
                        //accountBalances = GetListAccountBalanceOlder(planWithdrawEntity.RefId);
                        //foreach (var accountBalanceEntity in accountBalances)
                        //{
                        //    var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                        //    if (obAccoutBalanceExit != null)
                        //    {
                        //        obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                        //        // cập nhật bên TK nợ
                        //        if (accountBalanceEntity.MovementCreditAmountOC == 0)
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementDebitAmountExchange =
                        //                obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                        //            obAccoutBalanceExit.MovementDebitAmountOC =
                        //                obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //        else
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementCreditAmountExchange =
                        //                obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                        //            obAccoutBalanceExit.MovementCreditAmountOC =
                        //                obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //    }

                        //}
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        //accountBalances.Clear();
                        //accountBalances = GetListAccountBalance(planWithdrawEntity);
                        //foreach (var accountBalanceEntity in accountBalances)
                        //{
                        //    var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                        //    if (obAccoutBalanceExit != null)
                        //    {
                        //        obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                        //        // cập nhật bên TK nợ
                        //        if (accountBalanceEntity.MovementCreditAmountOC == 0)
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementDebitAmountExchange =
                        //                obAccoutBalanceExit.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                        //            obAccoutBalanceExit.MovementDebitAmountOC =
                        //                obAccoutBalanceExit.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //        else
                        //        {
                        //            obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                        //            obAccoutBalanceExit.MovementCreditAmountExchange =
                        //                obAccoutBalanceExit.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                        //            obAccoutBalanceExit.MovementCreditAmountOC =
                        //                obAccoutBalanceExit.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                        //            AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                        //    }
                        //}
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        //AccountBalanceDao.DeleteAccountBalance();

                        //check ma trung
                        var planWithdrawEntityExisted = BUPlanWithdrawDao.GetBUPlanWithdrawByRefNoRefType(planWithdrawEntity.RefNo.Trim(), planWithdrawEntity.RefType, planWithdrawEntity.PostedDate);
                        if (planWithdrawEntityExisted != null && planWithdrawEntityExisted.RefId != planWithdrawEntity.RefId && planWithdrawEntityExisted.PostedDate.Year == planWithdrawEntity.PostedDate.Year)
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            planWithdrawResponse.Message = @"Số chứng từ '" + planWithdrawEntity.RefNo + @"' đã tồn tại!";
                            return planWithdrawResponse;
                        }


                        planWithdrawResponse.Message = BUPlanWithdrawDetailDao.DeleteBUPlanWithdrawDetailByRefId(planWithdrawEntity.RefId);
                        if (planWithdrawResponse.Message != null)
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return planWithdrawResponse;
                        }

                        #region Delete OriginalGeneralLedger
                        if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            return planWithdrawResponse;
                        }
                        planWithdrawResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(planWithdrawEntity.RefId);
                        #endregion

                        //if (planWithdrawEntity.RefTypeId == 600)
                        //{
                        //    //Update Lại các mục Khoản lương
                        //    //Lấy lại số chứng từ cũ thay the số chứng từ mới
                        //    var objBUPlanWithdraw = BUPlanWithdrawDao.GetBUPlanWithdraw(planWithdrawEntity.RefId);
                        //    planWithdrawResponse.Message = BUPlanWithdrawDao.UpdateEmployeePayroll(objBUPlanWithdraw.RefNo, planWithdrawEntity.RefNo, planWithdrawEntity.PostedDate.Month + "/" + planWithdrawEntity.PostedDate.Day + "/" + planWithdrawEntity.PostedDate.Year);
                        //}
                        planWithdrawResponse.Message = BUPlanWithdrawDao.UpdateBUPlanWithdraw(planWithdrawEntity);
                        if (planWithdrawResponse.Message != null)
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return planWithdrawResponse;
                        }
                        //var jourentryAccount = journalEntryAccounts[0];
                        //planWithdrawResponse.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(jourentryAccount);
                        //if (planWithdrawResponse.Message != null)
                        //{
                        //    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        //    scope.Dispose();
                        //    return planWithdrawResponse;
                        //}
                        foreach (var planWithdrawDetail in planWithdrawEntity.BUPlanWithdrawDetails)
                        {
                            planWithdrawDetail.RefId = planWithdrawEntity.RefId;
                            planWithdrawDetail.RefDetailId = Guid.NewGuid().ToString();

                            if (!planWithdrawDetail.Validate())
                            {
                                foreach (string error in planWithdrawDetail.ValidationErrors)
                                    planWithdrawResponse.Message += error + Environment.NewLine;
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }
                            planWithdrawResponse.Message = BUPlanWithdrawDetailDao.InsertBUPlanWithdrawDetail(planWithdrawDetail);
                            if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                            {
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = planWithdrawEntity.RefType,
                                RefId = planWithdrawEntity.RefId,
                                RefDetailId = planWithdrawDetail.RefDetailId,
                                OrgRefDate = planWithdrawDetail.OrgRefDate,
                                OrgRefNo = planWithdrawDetail.OrgRefNo,
                                RefDate = planWithdrawEntity.RefDate,
                                RefNo = planWithdrawEntity.RefNo,
                                Amount = planWithdrawDetail.Amount,
                                AmountOC = planWithdrawDetail.AmountOC,
                                BudgetChapterCode = planWithdrawDetail.BudgetChapterCode,
                                BudgetDetailItemCode = planWithdrawDetail.BudgetDetailItemCode,
                                BudgetItemCode = planWithdrawDetail.BudgetItemCode,
                                BudgetKindItemCode = planWithdrawDetail.BudgetKindItemCode,
                                BudgetSourceId = planWithdrawDetail.BudgetSourceId,
                                BudgetSubItemCode = planWithdrawDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = planWithdrawDetail.BudgetSubKindItemCode,
                                CreditAccount = planWithdrawDetail.CreditAccount,
                                Description = planWithdrawDetail.Description,
                                FundStructureId = planWithdrawDetail.FundStructureId,
                                //       TaxAmount = planWithdrawDetail.TaxAmount,
                                JournalMemo = planWithdrawEntity.JournalMemo,
                                ProjectId = planWithdrawDetail.ProjectId,
                                PostedDate = planWithdrawEntity.PostedDate,
                                CurrencyCode = planWithdrawEntity.CurrencyCode,
                                ExchangeRate = planWithdrawEntity.ExchangeRate,
                            };
                            planWithdrawResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                            {
                                planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                                return planWithdrawResponse;
                            }

                            #endregion
                            //// Insert into JourentryAcocunt
                            //jourentryAccount = journalEntryAccounts[i];
                            //jourentryAccount.RefId = planWithdrawDetail.RefId;
                            //jourentryAccount.RefDetailId = planWithdrawDetail.RefDetailId;
                            //#region " jourentryAccount: thay đổi thông tin theo đối tượng Master"
                            //int accountingObjectType = planWithdrawEntity.AccountingObjectType == null ? 0 : int.Parse(planWithdrawEntity.AccountingObjectType.ToString());
                            //switch (accountingObjectType)
                            //{
                            //    case 0:
                            //        jourentryAccount.VendorId = planWithdrawEntity.VendorId;
                            //        break;
                            //    case 1:
                            //        jourentryAccount.EmployeeId = planWithdrawEntity.EmployeeId;
                            //        break;
                            //    case 2:
                            //        jourentryAccount.AccountingObjectId = planWithdrawEntity.AccountingObjectId;
                            //        break;
                            //    case 3:
                            //        jourentryAccount.CustomerId = planWithdrawEntity.CustomerId;
                            //        break;
                            //}
                            //#endregion


                            //if (!jourentryAccount.Validate())
                            //{
                            //    foreach (string error in jourentryAccount.ValidationErrors)
                            //        planWithdrawResponse.Message += error + Environment.NewLine;
                            //    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            //    return planWithdrawResponse;
                            //}
                            //JournalEntryAccountDao.InsertDoubleJournalEntryAccount(jourentryAccount);
                            //i = i + 1;
                        }


                        //foreach (var buPlanDrawDetail in planWithdrawEntity.BUPlanWithdrawDetails)
                        //{
                        //    var generalLedgerEntity = new GeneralLedgerEntity
                        //    {
                        //        RefType = planWithdrawEntity.RefType,
                        //        RefNo = planWithdrawEntity.RefNo,
                        //        // AccountingObjectId = buPlanReceiptEntity.AccountingObjectId,
                        //        //BankId = buPlanReceiptEntity.BankId,
                        //        // BudgetChapterCode = buPlanReceiptDetail.BudgetChapterCode,
                        //        ProjectId = buPlanDrawDetail.ProjectId,
                        //        BudgetSourceId = buPlanDrawDetail.BudgetSourceId,
                        //        Description = buPlanDrawDetail.Description,
                        //        RefDetailId = buPlanDrawDetail.RefDetailId,
                        //        ExchangeRate = planWithdrawEntity.ExchangeRate,
                        //        // ActivityId = buPlanReceiptDetail.ActivityId,
                        //        BudgetSubKindItemCode = buPlanDrawDetail.BudgetSubKindItemCode,
                        //        CurrencyCode = planWithdrawEntity.CurrencyCode,
                        //        BudgetKindItemCode = buPlanDrawDetail.BudgetKindItemCode,
                        //        RefId = planWithdrawEntity.RefId,
                        //        PostedDate = planWithdrawEntity.PostedDate,
                        //        //MethodDistributeId = buPlanReceiptDetail.MethodDistributeId,
                        //        //OrgRefNo = buPlanReceiptDetail.OrgRefNo,
                        //        // OrgRefDate = buPlanReceiptDetail.OrgRefDate,
                        //        BudgetItemCode = buPlanDrawDetail.BudgetItemCode,
                        //        ListItemId = buPlanDrawDetail.ListItemId,
                        //        BudgetSubItemCode = buPlanDrawDetail.BudgetSubItemCode,
                        //        BudgetDetailItemCode = buPlanDrawDetail.BudgetDetailItemCode,
                        //        //CashWithDrawTypeId = buPlanReceiptDetail.CashWithDrawTypeId,
                        //        //AccountNumber = buPlanDrawDetail.DebitAccount,
                        //        CorrespondingAccountNumber = buPlanDrawDetail.CreditAccount,
                        //        DebitAmount = buPlanDrawDetail.Amount,
                        //        DebitAmountOC = buPlanDrawDetail.AmountOC,
                        //        CreditAmount = 0,
                        //        CreditAmountOC = 0,
                        //        FundStructureId = buPlanDrawDetail.FundStructureId,
                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                        //        JournalMemo = planWithdrawEntity.JournalMemo,
                        //        RefDate = planWithdrawEntity.RefDate
                        //    };
                        //    planWithdrawResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                        //    if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        //    {
                        //        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        //        return planWithdrawResponse;
                        //    }

                        ////insert lan 2
                        //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                        //generalLedgerEntity.AccountNumber = buPlanDrawDetail.CreditAccount;
                        ////generalLedgerEntity.CorrespondingAccountNumber = buPlanDrawDetail.DebitAccount;
                        //generalLedgerEntity.DebitAmount = 0;
                        //generalLedgerEntity.DebitAmountOC = 0;
                        //generalLedgerEntity.CreditAmount = buPlanDrawDetail.Amount;
                        //generalLedgerEntity.CreditAmountOC = buPlanDrawDetail.AmountOC;
                        //planWithdrawResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                        if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                        {
                            planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                            return planWithdrawResponse;
                        }
                        //}

                        planWithdrawResponse.RefId = planWithdrawEntity.RefId;
                    }
                    if (planWithdrawResponse.Message != null)
                    {
                        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return planWithdrawResponse;
                    }
                    scope.Complete();
                }

                return planWithdrawResponse;
            }
            catch (Exception ex)
            {
                planWithdrawResponse.Message = ex.Message;
                return planWithdrawResponse;
            }
        }

        public BUPlanWithdrawResponse DeleteBUPlanWithdraw(string refId)
        {
            var planWithdrawResponse = new BUPlanWithdrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                //IList<AccountBalanceEntity> accountBalances = new List<AccountBalanceEntity>();
                //var jourentryAccount = new JournalEntryAccountEntity();

                var planWithdrawEntityForDelete = BUPlanWithdrawDao.GetBUPlanWithdraw(refId);
                if (planWithdrawEntityForDelete == null)
                {
                    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                    planWithdrawResponse.Message = "Dữ liệu cần xóa không tồn tại!";
                    return planWithdrawResponse;
                }
                using (var scope = new TransactionScope())
                {

                    planWithdrawResponse.Message = BUPlanWithdrawDao.DeleteBUPlanWithdraw(planWithdrawEntityForDelete);


                    //.Kiểm tra Rút dự toán này có sinh chứng từ khác không???
                    //var caReceiptEntity = CAReceiptDao.GetCAReceiptByBuPlanWithDrawRefID(refId);
                    //if (caReceiptEntity != null)
                    //{
                    //    planWithdrawResponse.Message = "Phiếu dự toán đã được liên kết với chứng từ khác.";
                    //    //planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                    //    //scope.Dispose();
                    //    //return planWithdrawResponse;
                    //}

                    //if (planWithdrawResponse.Message != null)
                    //{
                    //    if (planWithdrawResponse.Message.Contains("BUPlanWithdrawRefID"))
                    //    {
                    //        planWithdrawResponse.Message = "Phiếu rút dự toán đã được liên kết với chứng từ khác. Bạn không thể xóa!";

                    //        //Lấy ra phiếu thu NSNN được sinh ra từ Rút dự toán tiền mặt này.
                    //        //var caReceiptEntity = CAReceiptDao.GetCAReceiptByBuPlanWithDrawRefID(refId);
                    //    }

                    //    planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                    //    scope.Dispose();
                    //    return planWithdrawResponse;
                    //}

                    #region Delete OriginalGeneralLedger
                    if (!string.IsNullOrEmpty(planWithdrawResponse.Message))
                    {
                        planWithdrawResponse.Acknowledge = AcknowledgeType.Failure;
                        return planWithdrawResponse;
                    }
                    planWithdrawResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(planWithdrawEntityForDelete.RefId);
                    #endregion
                    scope.Complete();
                    // Xóa bảng JourentryAccount
                    //jourentryAccount.RefId = planWithdrawEntityForDelete.RefId;
                    //jourentryAccount.RefTypeId = planWithdrawEntityForDelete.RefTypeId;
                    //jourentryAccount.RefNo = planWithdrawEntityForDelete.RefNo;
                    //planWithdrawResponse.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(jourentryAccount);
                    // Cập nhật lại dữ liệu vào bảng cân đối tài khoản

                    //accountBalances.Clear();
                    //var planWithdrawDetails = BUPlanWithdrawDetailDao.GetBUPlanWithdrawDetailsByRefId(refId);
                    //var planWithdrawEntity = planWithdrawEntityForDelete;
                    //planWithdrawEntity.BUPlanWithdrawDetails = planWithdrawDetails;
                    //accountBalances = GetListAccountBalance(planWithdrawEntity);
                    //foreach (var accountBalanceEntity in accountBalances)
                    //{
                    //    var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                    //    if (obAccoutBalanceExit == null) continue;
                    //    obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;
                    //    // cập nhật bên TK nợ
                    //    if (accountBalanceEntity.MovementCreditAmountOC == 0)
                    //    {
                    //        obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                    //        obAccoutBalanceExit.MovementDebitAmountExchange =
                    //            obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                    //        obAccoutBalanceExit.MovementDebitAmountOC =
                    //            obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                    //        AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                    //    }
                    //    else
                    //    {
                    //        obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                    //        obAccoutBalanceExit.MovementCreditAmountExchange =
                    //            obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                    //        obAccoutBalanceExit.MovementCreditAmountOC =
                    //            obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                    //        AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                    //    }
                    //}
                    // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                    //AccountBalanceDao.DeleteAccountBalance();
                    // Xóa thông tin lương nhân viên đã tính
                    //if (planWithdrawEntityForDelete.RefTypeId == 600)
                    //{
                    //    planWithdrawResponse.Message = BUPlanWithdrawDao.DeleteEmployeePayroll(planWithdrawEntityForDelete.RefNo,
                    //       planWithdrawEntityForDelete.PostedDate.Month + "/" + planWithdrawEntityForDelete.PostedDate.Day + "/" + planWithdrawEntityForDelete.PostedDate.Year);
                    //}

                    // scope.Complete();
                }
                planWithdrawResponse.RefId = planWithdrawEntityForDelete.RefId;
                return planWithdrawResponse;
            }
            catch (Exception ex)
            {
                planWithdrawResponse.Message = ex.Message;
                return planWithdrawResponse;
            }
        }
    }
}