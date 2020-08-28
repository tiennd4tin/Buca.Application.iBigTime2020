/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.General;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.General;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.General
{
    public class GLVoucherFacade
    {
        private readonly IGLVoucherDao gLVoucher = new SqlServerGLVoucherDao();
        private readonly IGLVoucherDetailDao glVoucherDetailDao = new SqlServerGLVoucherDetailDao();
        private readonly IGLVoucherDetailParallelDao GLVoucherDetailParallelDao = DataAccess.DataAccess.GLVoucherDetailParallelDao;
        private readonly IGLVoucherDetailTaxDao glVoucherDetailTaxDao = new SqlServerGLVoucherDetailTaxDao();
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        /// <summary>
        /// Gets the su increment decrements.
        /// </summary>
        /// <returns></returns>
        public List<GLVoucherEntity> GetGLVouchers()
        {
            return gLVoucher.GetGLVouchers();
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<GLVoucherEntity> GetGLVouchersByRefTypeId(int refTypeId)
        {
            return gLVoucher.GetGLVouchersByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the gl voucher last years by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<GLVoucherEntity> GetGLVoucherLastYearsByRefTypeId(int refTypeId)
        {
            return gLVoucher.GetGLVouchersLastYearByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public GLVoucherEntity GetGLVoucherByRefId(string refId, bool hasDetail, bool hasTax)
        {
            var glVoucher = gLVoucher.GetGLVoucherByRefId(refId);
            if (glVoucher == null)
                return new GLVoucherEntity();
            if (hasDetail) glVoucher.GLVoucherDetails = glVoucherDetailDao.GetGLVoucherDetailsByRefId(glVoucher.RefId);


            if (hasTax) glVoucher.GLVoucherDetailTaxes = glVoucherDetailTaxDao.GetGLVoucherDetailTaxesByGLVoucher(glVoucher.RefId);

            //default get GLVoucherDetailParallel
            glVoucher.GLVoucherDetailParallels = GLVoucherDetailParallelDao.GetGLVoucherDetailParallelByRefId(glVoucher.RefId);

            return glVoucher;
        }

        /// <summary>
        /// Gets the bu transfer by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        public GLVoucherEntity GetGLVoucherByBUTransferRefId(string buTransferRefId)
        {
            return gLVoucher.GetGLVoucherByBUTransferRefId(buTransferRefId);
        }

        public GLVoucherEntity GetGLVoucherTransfer(int RefType, DateTime Systemdate, bool hasTax, string projectIds = null)
        {
            var glVoucher = new GLVoucherEntity();

            if (RefType == (int)BuCA.Enum.RefType.GLVoucherEarlyYear) glVoucher.GLVoucherDetails = glVoucherDetailDao.GetGLVoucherExpensesWaitingSettlement(Systemdate, projectIds);
            if (RefType == (int)BuCA.Enum.RefType.GLVoucherLastYear) glVoucher.GLVoucherDetails = glVoucherDetailDao.GetGLSettlementOfCompletedProjects(Systemdate, projectIds);
            if (RefType == (int)BuCA.Enum.RefType.GLVoucherPerformanceResults) glVoucher.GLVoucherDetails = glVoucherDetailDao.GetGLVoucherDetailsPerformanceResults(Systemdate);

            //if (hasTax) glVoucher.GLVoucherDetailTaxes = glVoucherDetailTaxDao.GetGLVoucherDetailTaxesByGLVoucher(glVoucher.RefId);

            ////default get GLVoucherDetailParallel
            //glVoucher.GLVoucherDetailParallels = GLVoucherDetailParallelDao.GetGLVoucherDetailParallelByRefId(glVoucher.RefId);

            return glVoucher;
        }

        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="glVoucherEntity">The gl voucher entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>GLVoucherResponse.</returns>
        public GLVoucherResponse InsertGLVoucher(GLVoucherEntity glVoucherEntity, bool isAutoGenerateParallel)
        {
            var response = new GLVoucherResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherEntity.Validate())
                {
                    foreach (var error in glVoucherEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = gLVoucher.GetGLVoucher(glVoucherEntity.RefNo.Trim(), glVoucherEntity.PostedDate);
                    if (faDepreciation != null && faDepreciation.PostedDate.Year == glVoucherEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ " + glVoucherEntity.RefNo + @" đã tồn tại !";
                        return response;
                    }

                    glVoucherEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = gLVoucher.InsertGLVoucher(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert FADepreciationDetails

                    if (glVoucherEntity.GLVoucherDetails != null)
                        foreach (var glVoucherDetail in glVoucherEntity.GLVoucherDetails)
                        {
                            glVoucherDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherDetail.RefId = glVoucherEntity.RefId;

                            response.Message = glVoucherDetailDao.InsertGLVoucherDetail(glVoucherDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(glVoucherEntity, glVoucherDetail);

                            #endregion

                            #region Insert Ledger
                            // insert bang GeneralLedger

                            if (!string.IsNullOrEmpty(glVoucherDetail.DebitAccount) && !string.IsNullOrEmpty(glVoucherDetail.CreditAccount))
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = glVoucherEntity.RefType,
                                    RefNo = glVoucherEntity.RefNo,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                    BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                    ProjectId = glVoucherDetail.ProjectId,
                                    BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                    Description = glVoucherDetail.Description,
                                    RefDetailId = glVoucherDetail.RefDetailId,
                                    ActivityId = glVoucherDetail.ActivityId,
                                    BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                    RefId = glVoucherEntity.RefId,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                    BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                    ListItemId = glVoucherDetail.ListItemId,
                                    BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                    AccountNumber = glVoucherDetail.DebitAccount,
                                    CorrespondingAccountNumber = glVoucherDetail.CreditAccount,
                                    DebitAmount = glVoucherDetail.Amount,
                                    DebitAmountOC = glVoucherDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = glVoucherDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    RefDate = glVoucherEntity.RefDate,
                                    OrgRefDate = glVoucherDetail.OrgRefDate,
                                    OrgRefNo = glVoucherDetail.OrgRefNo,
                                    BankId = glVoucherDetail.BankId,
                                    BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                    ContractId = glVoucherDetail.ContractId,
                                    CapitalPlanId = glVoucherDetail.CapitalPlanId,

                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = glVoucherDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = glVoucherDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = glVoucherDetail.AmountOC;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = glVoucherEntity.RefType,
                                    RefNo = glVoucherEntity.RefNo,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                    BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                    ProjectId = glVoucherDetail.ProjectId,
                                    BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                    Description = glVoucherDetail.Description,
                                    RefDetailId = glVoucherDetail.RefDetailId,
                                    ActivityId = glVoucherDetail.ActivityId,
                                    BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                    RefId = glVoucherEntity.RefId,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                    BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                    ListItemId = glVoucherDetail.ListItemId,
                                    BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                    AccountNumber = !string.IsNullOrEmpty(glVoucherDetail.DebitAccount) ? glVoucherDetail.DebitAccount : glVoucherDetail.CreditAccount,
                                    DebitAmount = string.IsNullOrEmpty(glVoucherDetail.DebitAccount) ? 0 : glVoucherDetail.Amount,
                                    DebitAmountOC = string.IsNullOrEmpty(glVoucherDetail.DebitAccount) ? 0 : glVoucherDetail.AmountOC,
                                    CreditAmount = string.IsNullOrEmpty(glVoucherDetail.CreditAccount) ? 0 : glVoucherDetail.Amount,
                                    CreditAmountOC = string.IsNullOrEmpty(glVoucherDetail.CreditAccount) ? 0 : glVoucherDetail.AmountOC,
                                    FundStructureId = glVoucherDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    RefDate = glVoucherEntity.RefDate,
                                    BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                    BankId = glVoucherDetail.BankId,
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = glVoucherEntity.RefType,
                                RefId = glVoucherEntity.RefId,
                                CurrencyCode = glVoucherEntity.CurrencyCode,
                                ExchangeRate = glVoucherEntity.ExchangeRate,
                                RefDetailId = glVoucherDetail.RefDetailId,
                                OrgRefDate = glVoucherDetail.OrgRefDate,
                                OrgRefNo = glVoucherDetail.OrgRefNo,
                                RefDate = glVoucherEntity.RefDate,
                                RefNo = glVoucherEntity.RefNo,
                                AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                ActivityId = glVoucherDetail.ActivityId,
                                Amount = glVoucherDetail.Amount,
                                AmountOC = glVoucherDetail.AmountOC,
                                Approved = glVoucherDetail.Approved,
                                BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                CreditAccount = glVoucherDetail.CreditAccount,
                                DebitAccount = glVoucherDetail.DebitAccount,
                                Description = glVoucherDetail.Description,
                                FundStructureId = glVoucherDetail.FundStructureId,
                                ProjectActivityId = glVoucherDetail.ProjectActivityId,
                                MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                JournalMemo = glVoucherEntity.JournalMemo,
                                ProjectId = glVoucherDetail.ProjectId,
                                PostedDate = glVoucherEntity.PostedDate,
                                BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                ContractId = glVoucherDetail.ContractId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion
                        }

                    #endregion

                    #region insert FADepreciationDetailTaxs

                    if (glVoucherEntity.GLVoucherDetailTaxes != null)
                        foreach (var glVoucherDetailTax in glVoucherEntity.GLVoucherDetailTaxes)
                        {
                            glVoucherDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherDetailTax.RefId = glVoucherEntity.RefId;
                            response.Message = glVoucherDetailTaxDao.InsertGLVoucherDetailTax(glVoucherDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }




                    #endregion

                    #region Sinh dinh khoan dong thoi

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region GLVoucherDetailParallel

                        if (glVoucherEntity.GLVoucherDetailParallels != null)
                        {
                            var exchangeRate = glVoucherEntity.ExchangeRate == null ? 0 : (decimal)glVoucherEntity.ExchangeRate;

                            //insert dl moi
                            foreach (var glVoucherDetailParallel in glVoucherEntity.GLVoucherDetailParallels)
                            {
                                #region Insert GLVoucherDetailParallel

                                glVoucherDetailParallel.RefId = glVoucherEntity.RefId;
                                glVoucherDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                glVoucherDetailParallel.Amount = glVoucherDetailParallel.Amount;

                                if (!glVoucherDetailParallel.Validate())
                                {
                                    foreach (var error in glVoucherDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                response.Message = GLVoucherDetailParallelDao.InsertGLVoucherDetailParallel(glVoucherDetailParallel);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (glVoucherDetailParallel.DebitAccount != null & glVoucherDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = glVoucherEntity.RefType,
                                        RefNo = glVoucherEntity.RefNo,
                                        AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                        //BankId = glVoucherEntity.BankId,
                                        BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                        ProjectId = glVoucherDetailParallel.ProjectId,
                                        BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                        Description = glVoucherDetailParallel.Description,
                                        RefDetailId = glVoucherDetailParallel.RefDetailId,
                                        ExchangeRate = glVoucherEntity.ExchangeRate,
                                        ActivityId = glVoucherDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = glVoucherEntity.CurrencyCode,
                                        BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                        RefId = glVoucherEntity.RefId,
                                        PostedDate = glVoucherEntity.PostedDate,
                                        MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                        OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                        OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                        BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                        ListItemId = glVoucherDetailParallel.ListItemId,
                                        BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = glVoucherDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = glVoucherDetailParallel.CreditAccount,
                                        DebitAmount = glVoucherDetailParallel.Amount,
                                        DebitAmountOC = glVoucherDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = glVoucherDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = glVoucherEntity.JournalMemo,
                                        RefDate = glVoucherEntity.RefDate,
                                        BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                        ContractId = glVoucherDetailParallel.ContractId,
                                        CapitalPlanId = glVoucherDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = glVoucherDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = glVoucherDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = glVoucherDetailParallel.AmountOC;
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = glVoucherEntity.RefType,
                                        RefNo = glVoucherEntity.RefNo,
                                        AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                        //BankId = glVoucherEntity.BankId,
                                        BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                        ProjectId = glVoucherDetailParallel.ProjectId,
                                        BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                        Description = glVoucherDetailParallel.Description,
                                        RefDetailId = glVoucherDetailParallel.RefDetailId,
                                        ExchangeRate = glVoucherEntity.ExchangeRate,
                                        ActivityId = glVoucherDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = glVoucherEntity.CurrencyCode,
                                        BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                        RefId = glVoucherEntity.RefId,
                                        PostedDate = glVoucherEntity.PostedDate,
                                        MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                        OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                        OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                        BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                        ListItemId = glVoucherDetailParallel.ListItemId,
                                        BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = glVoucherDetailParallel.DebitAccount ?? glVoucherDetailParallel.CreditAccount,
                                        DebitAmount = glVoucherDetailParallel.DebitAccount == null ? 0 : glVoucherDetailParallel.Amount,
                                        DebitAmountOC = glVoucherDetailParallel.DebitAccount == null ? 0 : glVoucherDetailParallel.AmountOC,
                                        CreditAmount = glVoucherDetailParallel.CreditAccount == null ? 0 : glVoucherDetailParallel.Amount,
                                        CreditAmountOC = glVoucherDetailParallel.CreditAccount == null ? 0 : glVoucherDetailParallel.AmountOC,
                                        FundStructureId = glVoucherDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = glVoucherEntity.JournalMemo,
                                        RefDate = glVoucherEntity.RefDate,
                                        BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                        ContractId = glVoucherDetailParallel.ContractId,
                                        CapitalPlanId = glVoucherDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }


                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = glVoucherEntity.RefType,
                                    RefId = glVoucherEntity.RefId,
                                    RefDetailId = glVoucherDetailParallel.RefDetailId,
                                    OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                    OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                    RefDate = glVoucherEntity.RefDate,
                                    RefNo = glVoucherEntity.RefNo,
                                    AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                    ActivityId = glVoucherDetailParallel.ActivityId,
                                    Amount = glVoucherDetailParallel.Amount,
                                    AmountOC = glVoucherDetailParallel.AmountOC,
                                    //Approved = receiptDetail.Approved,
                                    BankId = glVoucherDetailParallel.BankId,
                                    BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = glVoucherDetailParallel.CreditAccount,
                                    DebitAccount = glVoucherDetailParallel.DebitAccount,
                                    Description = glVoucherDetailParallel.Description,
                                    FundStructureId = glVoucherDetailParallel.FundStructureId,
                                    //ProjectActivityId = glVoucherDetailParallel.ProjectActivityId,
                                    MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    ProjectId = glVoucherDetailParallel.ProjectId,
                                    ToBankId = glVoucherDetailParallel.BankId,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                    ContractId = glVoucherDetailParallel.ContractId,
                                };
                                response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (glVoucherEntity.GLVoucherDetails != null)
                        {
                            var exchangeRate = glVoucherEntity.ExchangeRate == null ? 0 : (decimal)glVoucherEntity.ExchangeRate;

                            foreach (var glVoucherDetail in glVoucherEntity.GLVoucherDetails)
                            {
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        glVoucherDetail.DebitAccount, glVoucherDetail.CreditAccount,
                                        glVoucherDetail.BudgetSourceId,
                                        glVoucherDetail.BudgetChapterCode, glVoucherDetail.BudgetKindItemCode,
                                        glVoucherDetail.BudgetSubKindItemCode, glVoucherDetail.BudgetItemCode,
                                        glVoucherDetail.BudgetSubItemCode,
                                        glVoucherDetail.MethodDistributeId, glVoucherDetail.CashWithDrawTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region GLVoucherDetailParallel

                                        var glVoucherDetailParallel = new GLVoucherDetailParallelEntity()
                                        {
                                            RefId = glVoucherEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = glVoucherDetail.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                            Amount = glVoucherDetail.Amount,
                                            AmountOC = glVoucherDetail.AmountOC,
                                            BudgetSourceId =
                                                autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                glVoucherDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                glVoucherDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                glVoucherDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                glVoucherDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                glVoucherDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                glVoucherDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                glVoucherDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                glVoucherDetail.CashWithDrawTypeId,
                                            AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                            ActivityId = glVoucherDetail.ActivityId,
                                            ProjectId = glVoucherDetail.ProjectId,
                                            ListItemId = glVoucherDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = glVoucherDetail.SortOrder,
                                            OrgRefNo = glVoucherDetail.OrgRefNo,
                                            OrgRefDate = glVoucherDetail.OrgRefDate,
                                            FundStructureId = glVoucherDetail.FundStructureId,
                                            BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                            BankId = glVoucherDetail.BankId
                                            //glVoucherDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                            //glVoucherDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                        };
                                        if (!glVoucherDetailParallel.Validate())
                                        {
                                            foreach (var error in glVoucherDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        response.Message =
                                            GLVoucherDetailParallelDao.InsertGLVoucherDetailParallel(
                                                glVoucherDetailParallel);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity

                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = glVoucherEntity.RefType,
                                            RefNo = glVoucherEntity.RefNo,
                                            AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                            BankId = glVoucherDetailParallel.BankId,
                                            BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                            ProjectId = glVoucherDetailParallel.ProjectId,
                                            BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                            Description = glVoucherDetailParallel.Description,
                                            RefDetailId = glVoucherDetailParallel.RefDetailId,
                                            ExchangeRate = glVoucherEntity.ExchangeRate,
                                            ActivityId = glVoucherDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = glVoucherEntity.CurrencyCode,
                                            BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                            RefId = glVoucherEntity.RefId,
                                            PostedDate = glVoucherEntity.PostedDate,
                                            MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                            OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                            OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                            BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                            ListItemId = glVoucherDetailParallel.ListItemId,
                                            BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                            
                                            AccountNumber =
                                                glVoucherDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber =
                                                glVoucherDetailParallel.CreditAccount,
                                                DebitAmount = glVoucherDetailParallel.Amount,
                                                DebitAmountOC = glVoucherDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = glVoucherDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = glVoucherEntity.JournalMemo,
                                                RefDate = glVoucherEntity.RefDate,
                                                BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                                ContractId = glVoucherDetailParallel.ContractId,
                                                CapitalPlanId = glVoucherDetailParallel.CapitalPlanId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = glVoucherDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = glVoucherDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = glVoucherDetailParallel.AmountOC;
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        else
                                        {
                                            var generalLedgerEntity1 = new GeneralLedgerEntity
                                            {
                                                RefType = glVoucherEntity.RefType,
                                                RefNo = glVoucherEntity.RefNo,
                                                AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                                BankId = glVoucherDetailParallel.BankId,
                                                BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                                ProjectId = glVoucherDetailParallel.ProjectId,
                                                BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                                Description = glVoucherDetailParallel.Description,
                                                RefDetailId = glVoucherDetailParallel.RefDetailId,
                                                ExchangeRate = glVoucherEntity.ExchangeRate,
                                                ActivityId = glVoucherDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = glVoucherEntity.CurrencyCode,
                                                BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                                RefId = glVoucherEntity.RefId,
                                                PostedDate = glVoucherEntity.PostedDate,
                                                MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                                OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                                OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                                BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                                ListItemId = glVoucherDetailParallel.ListItemId,
                                                BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = glVoucherDetailParallel.DebitAccount ?? glVoucherDetailParallel.CreditAccount,
                                                DebitAmount = glVoucherDetailParallel.DebitAccount == null
                                                                                                ? 0
                                                                                                : glVoucherDetailParallel.Amount,
                                                DebitAmountOC =
                                                                                            glVoucherDetailParallel.DebitAccount == null
                                                                                                ? 0
                                                                                                : glVoucherDetailParallel.AmountOC,
                                                CreditAmount =
                                                                                            glVoucherDetailParallel.CreditAccount == null
                                                                                                ? 0
                                                                                                : glVoucherDetailParallel.Amount,
                                                CreditAmountOC =
                                                                                            glVoucherDetailParallel.CreditAccount == null
                                                                                                ? 0
                                                                                                : glVoucherDetailParallel.AmountOC,
                                                FundStructureId = glVoucherDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = glVoucherEntity.JournalMemo,
                                                RefDate = glVoucherEntity.RefDate,
                                                BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                                ContractId = glVoucherDetailParallel.ContractId,
                                                CapitalPlanId = glVoucherDetailParallel.CapitalPlanId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity1);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        }


                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = glVoucherEntity.RefType,
                                            RefId = glVoucherEntity.RefId,
                                            RefDetailId = glVoucherDetailParallel.RefDetailId,
                                            OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                            OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                            RefDate = glVoucherEntity.RefDate,
                                            RefNo = glVoucherEntity.RefNo,
                                            AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                            ActivityId = glVoucherDetailParallel.ActivityId,
                                            Amount = glVoucherDetailParallel.Amount,
                                            AmountOC = glVoucherDetailParallel.AmountOC,
                                            //Approved = receiptDetail.Approved,
                                            BankId = glVoucherDetailParallel.BankId,
                                            BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = glVoucherDetailParallel.CreditAccount,
                                            DebitAccount = glVoucherDetailParallel.DebitAccount,
                                            Description = glVoucherDetailParallel.Description,
                                            FundStructureId = glVoucherDetailParallel.FundStructureId,
                                            //ProjectActivityId = glVoucherDetailParallel.ProjectActivityId,
                                            MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                            JournalMemo = glVoucherEntity.JournalMemo,
                                            ProjectId = glVoucherDetailParallel.ProjectId,
                                            ToBankId = glVoucherDetailParallel.BankId,
                                            ExchangeRate = glVoucherEntity.ExchangeRate,
                                            CurrencyCode = glVoucherEntity.CurrencyCode,
                                            PostedDate = glVoucherEntity.PostedDate,
                                            BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                            ContractId = glVoucherDetailParallel.ContractId,

                                        };
                                        response.Message =
                                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message + "" + ex.StackTrace;
                return response;
            }
        }

        /// <summary>
        /// Updates the ba deposit.
        /// </summary>
        /// <param name="glVoucherEntity">The gl voucher entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>GLVoucherResponse.</returns>
        public GLVoucherResponse UpdateGlVoucher(GLVoucherEntity glVoucherEntity, bool isAutoGenerateParallel)
        {
            var response = new GLVoucherResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherEntity.Validate())
                {
                    foreach (var error in glVoucherEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = gLVoucher.GetGLVoucher(glVoucherEntity.RefNo.Trim(), glVoucherEntity.PostedDate);
                    if (faDepreciation != null && faDepreciation.PostedDate.Year == glVoucherEntity.PostedDate.Year)
                    {
                        if (faDepreciation.RefId != glVoucherEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ " + glVoucherEntity.RefNo + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = gLVoucher.UpdateGLVoucher(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(glVoucherEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Delete detail and insert detail & ledger
                    // Xóa bảng glVoucherDetail
                    response.Message = glVoucherDetailDao.DeleteGLVoucherDetailByRefId(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Xóa bảng GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(glVoucherEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(glVoucherEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    if (glVoucherEntity.GLVoucherDetails != null)
                        foreach (var glVoucherDetail in glVoucherEntity.GLVoucherDetails)
                        {
                            glVoucherDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherDetail.RefId = glVoucherEntity.RefId;
                            response.Message = glVoucherDetailDao.InsertGLVoucherDetail(glVoucherDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(glVoucherEntity, glVoucherDetail);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            #endregion

                            #region Insert Ledger
                            // insert bang GeneralLedger
                            //response.Message = GeneralLedgerDao.DeleteGeneralLedger(glVoucherEntity.RefId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            if (glVoucherDetail.DebitAccount != null && glVoucherDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = glVoucherEntity.RefType,
                                    RefNo = glVoucherEntity.RefNo,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                    BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                    ProjectId = glVoucherDetail.ProjectId,
                                    BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                    Description = glVoucherDetail.Description,
                                    RefDetailId = glVoucherDetail.RefDetailId,
                                    ActivityId = glVoucherDetail.ActivityId,
                                    BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                    RefId = glVoucherEntity.RefId,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                    BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                    ListItemId = glVoucherDetail.ListItemId,
                                    BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                    AccountNumber = glVoucherDetail.DebitAccount,
                                    CorrespondingAccountNumber = glVoucherDetail.CreditAccount,
                                    DebitAmount = glVoucherDetail.Amount,
                                    DebitAmountOC = glVoucherDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = glVoucherDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    RefDate = glVoucherEntity.RefDate,
                                    BankId = glVoucherDetail.BankId,
                                    ContractId = glVoucherDetail.ContractId,
                                    BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = glVoucherDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = glVoucherDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = glVoucherDetail.AmountOC;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = glVoucherEntity.RefType,
                                    RefNo = glVoucherEntity.RefNo,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                    BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                    ProjectId = glVoucherDetail.ProjectId,
                                    BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                    Description = glVoucherDetail.Description,
                                    RefDetailId = glVoucherDetail.RefDetailId,
                                    ActivityId = glVoucherDetail.ActivityId,
                                    BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                    RefId = glVoucherEntity.RefId,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                    BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                    ListItemId = glVoucherDetail.ListItemId,
                                    BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                    AccountNumber = !string.IsNullOrEmpty(glVoucherDetail.DebitAccount) ? glVoucherDetail.DebitAccount : glVoucherDetail.CreditAccount,
                                    DebitAmount = glVoucherDetail.DebitAccount == null ? 0 : glVoucherDetail.Amount,
                                    DebitAmountOC = glVoucherDetail.DebitAccount == null ? 0 : glVoucherDetail.AmountOC,
                                    CreditAmount = glVoucherDetail.CreditAccount == null ? 0 : glVoucherDetail.Amount,
                                    CreditAmountOC = glVoucherDetail.CreditAccount == null ? 0 : glVoucherDetail.AmountOC,
                                    FundStructureId = glVoucherDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    RefDate = glVoucherEntity.RefDate,
                                    BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                    BankId = glVoucherDetail.BankId,
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = glVoucherEntity.RefType,
                                RefId = glVoucherEntity.RefId,
                                CurrencyCode = glVoucherEntity.CurrencyCode,
                                ExchangeRate = glVoucherEntity.ExchangeRate,
                                RefDetailId = glVoucherDetail.RefDetailId,
                                OrgRefDate = glVoucherDetail.OrgRefDate,
                                OrgRefNo = glVoucherDetail.OrgRefNo,
                                RefDate = glVoucherEntity.RefDate,
                                RefNo = glVoucherEntity.RefNo,
                                AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                ActivityId = glVoucherDetail.ActivityId,
                                Amount = glVoucherDetail.Amount,
                                AmountOC = glVoucherDetail.AmountOC,
                                Approved = glVoucherDetail.Approved,
                                BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                                BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode,
                                BudgetItemCode = glVoucherDetail.BudgetItemCode,
                                BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                                BudgetSourceId = glVoucherDetail.BudgetSourceId,
                                BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = glVoucherDetail.CashWithDrawTypeId,
                                CreditAccount = glVoucherDetail.CreditAccount,
                                DebitAccount = glVoucherDetail.DebitAccount,
                                Description = glVoucherDetail.Description,
                                FundStructureId = glVoucherDetail.FundStructureId,
                                ProjectActivityId = glVoucherDetail.ProjectActivityId,
                                MethodDistributeId = glVoucherDetail.MethodDistributeId,
                                JournalMemo = glVoucherEntity.JournalMemo,
                                ProjectId = glVoucherDetail.ProjectId,
                                PostedDate = glVoucherEntity.PostedDate,
                                BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                ContractId = glVoucherDetail.ContractId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion
                        }

                    #endregion

                    #region Delete detail tax and insert detail tax

                    response.Message = glVoucherDetailTaxDao.DeleteGLVoucherDetailTaxByRefId(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (glVoucherEntity.GLVoucherDetailTaxes != null)
                        foreach (var glVoucherDetailTax in glVoucherEntity.GLVoucherDetailTaxes)
                        {
                            glVoucherDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherDetailTax.RefId = glVoucherEntity.RefId;
                            response.Message = glVoucherDetailTaxDao.InsertGLVoucherDetailTax(glVoucherDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region Sinh dinh khoan dong thoi

                    // delete bang GLVoucherDetailParallel
                    response.Message = GLVoucherDetailParallelDao.DeleteGLVoucherDetailParallelById(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region GLVoucherDetailParallel

                        if (glVoucherEntity.GLVoucherDetailParallels != null)
                        {
                            var exchangeRate = glVoucherEntity.ExchangeRate == null ? 0 : (decimal)glVoucherEntity.ExchangeRate;

                            //insert dl moi
                            foreach (var glVoucherDetailParallel in glVoucherEntity.GLVoucherDetailParallels)
                            {
                                #region Insert GLVoucherDetailParallel

                                glVoucherDetailParallel.RefId = glVoucherEntity.RefId;
                                glVoucherDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                glVoucherDetailParallel.Amount = glVoucherDetailParallel.Amount;

                                if (!glVoucherDetailParallel.Validate())
                                {
                                    foreach (var error in glVoucherDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                response.Message = GLVoucherDetailParallelDao.InsertGLVoucherDetailParallel(glVoucherDetailParallel);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (glVoucherDetailParallel.DebitAccount != null && glVoucherDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = glVoucherEntity.RefType,
                                        RefNo = glVoucherEntity.RefNo,
                                        AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                        //BankId = glVoucherEntity.BankId,
                                        BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                        ProjectId = glVoucherDetailParallel.ProjectId,
                                        BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                        Description = glVoucherDetailParallel.Description,
                                        RefDetailId = glVoucherDetailParallel.RefDetailId,
                                        ExchangeRate = glVoucherEntity.ExchangeRate,
                                        ActivityId = glVoucherDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = glVoucherEntity.CurrencyCode,
                                        BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                        RefId = glVoucherEntity.RefId,
                                        PostedDate = glVoucherEntity.PostedDate,
                                        MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                        OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                        OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                        BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                        ListItemId = glVoucherDetailParallel.ListItemId,
                                        BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = glVoucherDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = glVoucherDetailParallel.CreditAccount,
                                        DebitAmount = glVoucherDetailParallel.Amount,
                                        DebitAmountOC = glVoucherDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = glVoucherDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = glVoucherEntity.JournalMemo,
                                        RefDate = glVoucherEntity.RefDate,
                                        BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = glVoucherDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = glVoucherDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = glVoucherDetailParallel.AmountOC;
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = glVoucherEntity.RefType,
                                        RefNo = glVoucherEntity.RefNo,
                                        AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                        //BankId = glVoucherEntity.BankId,
                                        BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                        ProjectId = glVoucherDetailParallel.ProjectId,
                                        BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                        Description = glVoucherDetailParallel.Description,
                                        RefDetailId = glVoucherDetailParallel.RefDetailId,
                                        ExchangeRate = glVoucherEntity.ExchangeRate,
                                        ActivityId = glVoucherDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = glVoucherEntity.CurrencyCode,
                                        BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                        RefId = glVoucherEntity.RefId,
                                        PostedDate = glVoucherEntity.PostedDate,
                                        MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                        OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                        OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                        BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                        ListItemId = glVoucherDetailParallel.ListItemId,
                                        BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = glVoucherDetailParallel.DebitAccount ?? glVoucherDetailParallel.CreditAccount,
                                        DebitAmount = glVoucherDetailParallel.DebitAccount == null ? 0 : glVoucherDetailParallel.Amount,
                                        DebitAmountOC = glVoucherDetailParallel.DebitAccount == null ? 0 : glVoucherDetailParallel.AmountOC,
                                        CreditAmount = glVoucherDetailParallel.CreditAccount == null ? 0 : glVoucherDetailParallel.Amount,
                                        CreditAmountOC = glVoucherDetailParallel.CreditAccount == null ? 0 : glVoucherDetailParallel.AmountOC,
                                        FundStructureId = glVoucherDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = glVoucherEntity.JournalMemo,
                                        RefDate = glVoucherEntity.RefDate,
                                        BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }


                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = glVoucherEntity.RefType,
                                    RefId = glVoucherEntity.RefId,
                                    RefDetailId = glVoucherDetailParallel.RefDetailId,
                                    OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                    OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                    RefDate = glVoucherEntity.RefDate,
                                    RefNo = glVoucherEntity.RefNo,
                                    AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                    ActivityId = glVoucherDetailParallel.ActivityId,
                                    Amount = glVoucherDetailParallel.Amount,
                                    AmountOC = glVoucherDetailParallel.AmountOC,
                                    Approved = glVoucherDetailParallel.Approved,
                                    BankId = glVoucherDetailParallel.BankId,
                                    BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = glVoucherDetailParallel.CreditAccount,
                                    DebitAccount = glVoucherDetailParallel.DebitAccount,
                                    Description = glVoucherDetailParallel.Description,
                                    FundStructureId = glVoucherDetailParallel.FundStructureId,
                                    //ProjectActivityId = glVoucherDetailParallel.ProjectActivityId,
                                    MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                    JournalMemo = glVoucherEntity.JournalMemo,
                                    ProjectId = glVoucherDetailParallel.ProjectId,
                                    ToBankId = glVoucherDetailParallel.BankId,
                                    ExchangeRate = glVoucherEntity.ExchangeRate,
                                    CurrencyCode = glVoucherEntity.CurrencyCode,
                                    PostedDate = glVoucherEntity.PostedDate,
                                    BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                    ContractId = glVoucherDetailParallel.ContractId
                                };
                                response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (glVoucherEntity.GLVoucherDetails != null)
                        {
                            var exchangeRate = glVoucherEntity.ExchangeRate == null ? 0 : (decimal)glVoucherEntity.ExchangeRate;

                            foreach (var glVoucherDetail in glVoucherEntity.GLVoucherDetails)
                            {
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        glVoucherDetail.DebitAccount, glVoucherDetail.CreditAccount,
                                        glVoucherDetail.BudgetSourceId,
                                        glVoucherDetail.BudgetChapterCode, glVoucherDetail.BudgetKindItemCode,
                                        glVoucherDetail.BudgetSubKindItemCode, glVoucherDetail.BudgetItemCode,
                                        glVoucherDetail.BudgetSubItemCode,
                                        glVoucherDetail.MethodDistributeId, glVoucherDetail.CashWithDrawTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region GLVoucherDetailParallel

                                        var glVoucherDetailParallel = new GLVoucherDetailParallelEntity()
                                        {
                                            RefId = glVoucherEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = glVoucherDetail.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                            Amount = glVoucherDetail.Amount,
                                            AmountOC = glVoucherDetail.AmountOC,
                                            BudgetSourceId =
                                                autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                glVoucherDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                glVoucherDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                glVoucherDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                glVoucherDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                glVoucherDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                glVoucherDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                glVoucherDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                glVoucherDetail.CashWithDrawTypeId,
                                            AccountingObjectId = glVoucherDetail.AccountingObjectId,
                                            ActivityId = glVoucherDetail.ActivityId,
                                            ProjectId = glVoucherDetail.ProjectId,
                                            ListItemId = glVoucherDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = glVoucherDetail.SortOrder,
                                            OrgRefNo = glVoucherDetail.OrgRefNo,
                                            OrgRefDate = glVoucherDetail.OrgRefDate,
                                            FundStructureId = glVoucherDetail.FundStructureId,
                                            BudgetExpenseId = glVoucherDetail.BudgetExpenseId,
                                            BankId = glVoucherDetail.BankId
                                            //glVoucherDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                            //glVoucherDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                        };
                                        if (!glVoucherDetailParallel.Validate())
                                        {
                                            foreach (var error in glVoucherDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        response.Message =
                                            GLVoucherDetailParallelDao.InsertGLVoucherDetailParallel(
                                                glVoucherDetailParallel);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity
                                        if (glVoucherDetailParallel.DebitAccount != null && glVoucherDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = glVoucherEntity.RefType,
                                                RefNo = glVoucherEntity.RefNo,
                                                AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                                BankId = glVoucherDetailParallel.BankId,
                                                BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                                ProjectId = glVoucherDetailParallel.ProjectId,
                                                BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                                Description = glVoucherDetailParallel.Description,
                                                RefDetailId = glVoucherDetailParallel.RefDetailId,
                                                ExchangeRate = glVoucherEntity.ExchangeRate,
                                                ActivityId = glVoucherDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = glVoucherEntity.CurrencyCode,
                                                BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                                RefId = glVoucherEntity.RefId,
                                                PostedDate = glVoucherEntity.PostedDate,
                                                MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                                OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                                OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                                BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                                ListItemId = glVoucherDetailParallel.ListItemId,
                                                BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = glVoucherDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber = glVoucherDetailParallel.CreditAccount,
                                                DebitAmount = glVoucherDetailParallel.Amount,
                                                DebitAmountOC = glVoucherDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = glVoucherDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = glVoucherEntity.JournalMemo,
                                                RefDate = glVoucherEntity.RefDate,
                                                BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = glVoucherDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = glVoucherDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = glVoucherDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = glVoucherDetailParallel.AmountOC;
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        }
                                        else
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = glVoucherEntity.RefType,
                                                RefNo = glVoucherEntity.RefNo,
                                                AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                                BankId = glVoucherDetailParallel.BankId,
                                                BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                                ProjectId = glVoucherDetailParallel.ProjectId,
                                                BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                                Description = glVoucherDetailParallel.Description,
                                                RefDetailId = glVoucherDetailParallel.RefDetailId,
                                                ExchangeRate = glVoucherEntity.ExchangeRate,
                                                ActivityId = glVoucherDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = glVoucherEntity.CurrencyCode,
                                                BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                                RefId = glVoucherEntity.RefId,
                                                PostedDate = glVoucherEntity.PostedDate,
                                                MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                                OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                                OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                                BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                                ListItemId = glVoucherDetailParallel.ListItemId,
                                                BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = glVoucherDetailParallel.DebitAccount ?? glVoucherDetailParallel.CreditAccount,
                                                DebitAmount =
                                                glVoucherDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : glVoucherDetailParallel.Amount,
                                                DebitAmountOC =
                                                glVoucherDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : glVoucherDetailParallel.AmountOC,
                                                CreditAmount =
                                                glVoucherDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : glVoucherDetailParallel.Amount,
                                                CreditAmountOC =
                                                glVoucherDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : glVoucherDetailParallel.AmountOC,
                                                FundStructureId = glVoucherDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = glVoucherEntity.JournalMemo,
                                                RefDate = glVoucherEntity.RefDate,
                                                BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        }


                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = glVoucherEntity.RefType,
                                            RefId = glVoucherEntity.RefId,
                                            RefDetailId = glVoucherDetailParallel.RefDetailId,
                                            OrgRefDate = glVoucherDetailParallel.OrgRefDate,
                                            OrgRefNo = glVoucherDetailParallel.OrgRefNo,
                                            RefDate = glVoucherEntity.RefDate,
                                            RefNo = glVoucherEntity.RefNo,
                                            AccountingObjectId = glVoucherDetailParallel.AccountingObjectId,
                                            ActivityId = glVoucherDetailParallel.ActivityId,
                                            Amount = glVoucherDetailParallel.Amount,
                                            AmountOC = glVoucherDetailParallel.AmountOC,
                                            Approved = glVoucherDetailParallel.Approved,
                                            BankId = glVoucherDetailParallel.BankId,
                                            BudgetChapterCode = glVoucherDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = glVoucherDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = glVoucherDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = glVoucherDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = glVoucherDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = glVoucherDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = glVoucherDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = glVoucherDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = glVoucherDetailParallel.CreditAccount,
                                            DebitAccount = glVoucherDetailParallel.DebitAccount,
                                            Description = glVoucherDetailParallel.Description,
                                            FundStructureId = glVoucherDetailParallel.FundStructureId,
                                            //ProjectActivityId = glVoucherDetailParallel.ProjectActivityId,
                                            MethodDistributeId = glVoucherDetailParallel.MethodDistributeId,
                                            JournalMemo = glVoucherEntity.JournalMemo,
                                            ProjectId = glVoucherDetailParallel.ProjectId,
                                            ToBankId = glVoucherDetailParallel.BankId,
                                            ExchangeRate = glVoucherEntity.ExchangeRate,
                                            CurrencyCode = glVoucherEntity.CurrencyCode,
                                            PostedDate = glVoucherEntity.PostedDate,
                                            BudgetExpenseId = glVoucherDetailParallel.BudgetExpenseId,
                                            ContractId = glVoucherDetailParallel.ContractId,
                                        };
                                        response.Message =
                                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
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
        public GLVoucherResponse DeleteGLVoucher(string refId)
        {
            var response = new GLVoucherResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var glVoucherEntity = gLVoucher.GetGLVoucherByRefId(refId);
                if (glVoucherEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    #region Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(glVoucherEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    response.Message = gLVoucher.DeleteGLVoucher(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }


                    // delete bang GLVoucherDetailParallel
                    response.Message = GLVoucherDetailParallelDao.DeleteGLVoucherDetailParallelById(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(glVoucherEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the gl voucher by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        public GLVoucherResponse DeleteGLVoucherByBUTransferRefId(string buTransferRefId)
        {
            var response = new GLVoucherResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var glVoucherEntity = gLVoucher.GetGLVoucherByBUTransferRefId(buTransferRefId);
                if (glVoucherEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    #region Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(glVoucherEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    response.Message = gLVoucher.DeleteGLVoucher(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }


                    // delete bang GLVoucherDetailParallel
                    response.Message = GLVoucherDetailParallelDao.DeleteGLVoucherDetailParallelById(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(glVoucherEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
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
        /// <param name="glVoucher">The gl voucher.</param>
        /// <param name="glVoucherDetail">The gl voucher detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(GLVoucherEntity glVoucher, GLVoucherDetailEntity glVoucherDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = glVoucherDetail.DebitAccount,
                CurrencyCode = glVoucher.CurrencyCode,
                ExchangeRate = glVoucher.ExchangeRate,
                BalanceDate = glVoucher.PostedDate,
                MovementDebitAmountOC = glVoucherDetail.AmountOC,
                MovementDebitAmount = glVoucherDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = glVoucherDetail.BudgetSourceId,
                BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                BudgetItemCode = glVoucherDetail.BudgetItemCode,
                BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                MethodDistributeId = glVoucherDetail.MethodDistributeId,
                ActivityId = glVoucherDetail.ActivityId,
                ProjectId = glVoucherDetail.ProjectId,
                FundStructureId = glVoucherDetail.FundStructureId,
                ProjectActivityId = glVoucherDetail.ProjectActivityId,
                BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <param name="glVoucherDetail">The gl voucher detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(GLVoucherEntity glVoucher, GLVoucherDetailEntity glVoucherDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = glVoucherDetail.CreditAccount,
                CurrencyCode = glVoucher.CurrencyCode,
                ExchangeRate = glVoucher.ExchangeRate,
                BalanceDate = glVoucher.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = glVoucherDetail.AmountOC,
                MovementCreditAmount = glVoucherDetail.Amount,
                BudgetSourceId = glVoucherDetail.BudgetSourceId,
                BudgetChapterCode = glVoucherDetail.BudgetChapterCode,
                BudgetKindItemCode = glVoucherDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = glVoucherDetail.BudgetSubKindItemCode,
                BudgetItemCode = glVoucherDetail.BudgetItemCode,
                BudgetSubItemCode = glVoucherDetail.BudgetSubItemCode,
                MethodDistributeId = glVoucherDetail.MethodDistributeId,
                ActivityId = glVoucherDetail.ActivityId,
                ProjectId = glVoucherDetail.ProjectId,
                FundStructureId = glVoucherDetail.FundStructureId,
                ProjectActivityId = glVoucherDetail.ProjectActivityId,
                BudgetDetailItemCode = glVoucherDetail.BudgetDetailItemCode
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
        /// <param name="glVoucher">The gl voucher.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(GLVoucherEntity glVoucher)
        {
            var paymentDetails = glVoucherDetailDao.GetGLVoucherDetailsByRefId(glVoucher.RefId);
            foreach (var paymentDetail in paymentDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(glVoucher, paymentDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null) return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(glVoucher, paymentDetail);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmount, false, 2);
                    if (message != null) return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <param name="glVoucherDetail">The gl voucher detail.</param>
        public void InsertAccountBalance(GLVoucherEntity glVoucher, GLVoucherDetailEntity glVoucherDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(glVoucher, glVoucherDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(glVoucher, glVoucherDetail);
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
