/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.FixedAsset;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.FixedAsset
{
    /// <summary>
    /// FADepreciationFacade
    /// </summary>
    public class FADepreciationFacade
    {
        private readonly IFADepreciationDao FADepreciationDao = new SqlServerFADepreciationDao();
        private readonly IFADepreciationDetailDao FADepreciationDetailDao = new SqlServerFADepreciationDetailDao();
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// Gets the su increment decrements.
        /// </summary>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciations()
        {
            return FADepreciationDao.GetFADepreciations();
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId)
        {
            return FADepreciationDao.GetFADepreciationsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId, DateTime refDate)
        {
            return FADepreciationDao.GetFADepreciationsByRefTypeId(refTypeId, (short)refDate.Year);
        }

        /// <summary>
        /// Gets the type of the fa depreciations by reference type and period.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADepreciationsByRefTypeAndPeriodType(int refTypeId, DateTime refDate, int periodType)
        {
            return FADepreciationDao.GetFADepreciationsByRefTypeAndPeriodType(refTypeId, refDate, periodType);
        }

        /// <summary>
        /// Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADepreciationByRefId(string refId, bool hasDetail)
        {
            var faDepreciation = FADepreciationDao.GetFADepreciation(refId);
            if (faDepreciation == null)
                return null;
            if (hasDetail)
                faDepreciation.FADepreciationDetails =
                    FADepreciationDetailDao.GetFADepreciationDetailsByFADepreciation(faDepreciation.RefId);
            return faDepreciation;
        }

        /// <summary>
        /// Gets the fa devaluation by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADevaluationByRefId(string refId, bool hasDetail)
        {
            var faDepreciation = FADepreciationDao.GetFADepreciation(refId);
            if (faDepreciation == null)
                return null;
            if (hasDetail)
                faDepreciation.FADepreciationDetails =
                    FADepreciationDetailDao.GetFADevaluationDetailsByFADepreciation(faDepreciation.RefId);
            return faDepreciation;
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADepreciation(string refId, DateTime fromDate, DateTime toDate)
        {
            var faDepreciation = new FADepreciationEntity
            {
                RefDate = toDate,
                PostedDate = toDate,
                RefId = null,
                RefType = 255,
                RefNo = "HM",
                JournalMemo = "Hao mòn tài sản cố định",
                TotalAmount = 0
            };
            faDepreciation.FADepreciationDetails =
                FADepreciationDetailDao.GetFADepreciationDetailsByFADepreciation(fromDate, toDate);
            return faDepreciation;
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public FADepreciationEntity GetFADepreciation(string refId, DateTime fromDate, DateTime toDate, int periodType)
        {
            var faDepreciation = new FADepreciationEntity
            {
                RefDate = toDate,
                PostedDate = toDate,
                RefId = null,
                RefType = 419,
                RefNo = "KH",
                JournalMemo = "Khấu hao tài sản cố định",
                TotalAmount = 0
            };
            faDepreciation.FADepreciationDetails =
                FADepreciationDetailDao.GetFADepreciationDetailsByFADepreciation(fromDate, toDate, periodType);
            return faDepreciation;
        }
        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public List<FADepreciationEntity> GetFADevaluations(int refTypeId, DateTime refDate, int periodType)
        {
            return FADepreciationDao.GetFADevaluationsByRefDateAndPeriodType(refTypeId, refDate, periodType); ;
        }

        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="faDepreciationEntity">The fa depreciation entity.</param>
        /// <returns></returns>
        public FADepreciationResponse InsertFADepreciation(FADepreciationEntity faDepreciationEntity)
        {
            var response = new FADepreciationResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!faDepreciationEntity.Validate())
                {
                    foreach (var error in faDepreciationEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = FADepreciationDao.GetFADepreciation(faDepreciationEntity.RefNo.Trim(), faDepreciationEntity.PostedDate);
                    if (faDepreciation != null && faDepreciation.PostedDate.Year == faDepreciationEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ " + faDepreciationEntity.RefNo + @" đã tồn tại !";
                        return response;
                    }

                    faDepreciationEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = FADepreciationDao.InsertFADepreciation(faDepreciationEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert FADepreciationDetails
                    //Lấy MainCurrencyID mặc định trong DBOption
                    DataTable dbOptionValue = GeneralLedgerDao.GetMainCurrencyIDFromDBOption("MainCurrencyID");

                    if (faDepreciationEntity.FADepreciationDetails != null)
                        foreach (var faDepreciationDetail in faDepreciationEntity.FADepreciationDetails)
                        {
                            faDepreciationDetail.RefDetailId = Guid.NewGuid().ToString();
                            faDepreciationDetail.RefId = faDepreciationEntity.RefId;
                            response.Message = FADepreciationDetailDao.InsertFADepreciationDetail(faDepreciationDetail); 
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(faDepreciationEntity, faDepreciationDetail);

                            #endregion

                            #region Insert Ledger
                            // insert bang GeneralLedger
                            if (faDepreciationDetail.DebitAccount != null && faDepreciationDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = faDepreciationEntity.RefType,
                                    RefNo = faDepreciationEntity.RefNo,
                                    AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                    BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                    ProjectId = faDepreciationDetail.ProjectId,
                                    BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                    Description = faDepreciationDetail.Description,
                                    RefDetailId = faDepreciationDetail.RefDetailId,
                                    ActivityId = faDepreciationDetail.ActivityId,
                                    BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                    RefId = faDepreciationEntity.RefId,
                                    PostedDate = faDepreciationEntity.PostedDate,
                                    MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                    BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                    ListItemId = faDepreciationDetail.ListItemId,
                                    BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                    AccountNumber = faDepreciationDetail.DebitAccount,
                                    CorrespondingAccountNumber = faDepreciationDetail.CreditAccount,
                                    DebitAmount = faDepreciationDetail.Amount,
                                    DebitAmountOC = faDepreciationDetail.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = faDepreciationDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = faDepreciationEntity.JournalMemo,
                                    RefDate = faDepreciationEntity.RefDate,
                                    SortOrder = faDepreciationDetail.SortOrder,
                                    CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                    ExchangeRate = 1,
                                    BudgetExpenseId = faDepreciationDetail.BudgetExpenseId,
                                    ContractId = faDepreciationDetail.ContractId,
                                    CapitalPlanId = faDepreciationDetail.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = faDepreciationDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = faDepreciationDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = faDepreciationDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = faDepreciationDetail.Amount;
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
                                    RefType = faDepreciationEntity.RefType,
                                    RefNo = faDepreciationEntity.RefNo,
                                    AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                    BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                    ProjectId = faDepreciationDetail.ProjectId,
                                    BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                    Description = faDepreciationDetail.Description,
                                    RefDetailId = faDepreciationDetail.RefDetailId,
                                    ActivityId = faDepreciationDetail.ActivityId,
                                    BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                    RefId = faDepreciationEntity.RefId,
                                    PostedDate = faDepreciationEntity.PostedDate,
                                    MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                    BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                    ListItemId = faDepreciationDetail.ListItemId,
                                    BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                    AccountNumber = faDepreciationDetail.DebitAccount ?? faDepreciationDetail.CreditAccount,
                                    DebitAmount = faDepreciationDetail.DebitAccount == null ? 0 : faDepreciationDetail.Amount,
                                    DebitAmountOC = faDepreciationDetail.DebitAccount == null ? 0 : faDepreciationDetail.Amount,
                                    CreditAmount = faDepreciationDetail.CreditAccount == null ? 0 : faDepreciationDetail.Amount,
                                    CreditAmountOC = faDepreciationDetail.CreditAccount == null ? 0 : faDepreciationDetail.Amount,
                                    FundStructureId = faDepreciationDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = faDepreciationEntity.JournalMemo,
                                    RefDate = faDepreciationEntity.RefDate,
                                    SortOrder = faDepreciationDetail.SortOrder,
                                    CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                    ExchangeRate = 1,
                                    ContractId = faDepreciationDetail.ContractId,
                                    CapitalPlanId = faDepreciationDetail.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region Insert FixedAssetLedger
                            if (faDepreciationDetail.FixedAssetId != null)
                            {
                                //get fixedAssetInfo
                                var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(faDepreciationDetail.FixedAssetId);
                                if (faDepreciationDetail.CreditAccount != null && faDepreciationDetail.CreditAccount.StartsWith("214"))
                                {
                                    decimal DepreciationCreditAmountTemp = faDepreciationEntity.RefType == 255 ? faDepreciationDetail.Amount : 0;
                                    decimal DevaluationCreditAmounttemp = faDepreciationEntity.RefType == 419 ? faDepreciationDetail.Amount : 0;
                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = faDepreciationEntity.RefId,
                                        RefType = faDepreciationEntity.RefType,
                                        RefNo = faDepreciationEntity.RefNo,
                                        RefDate = faDepreciationEntity.RefDate,
                                        PostedDate = faDepreciationEntity.PostedDate,
                                        FixedAssetId = faDepreciationDetail.FixedAssetId,
                                        DepartmentId = fixedAssetEntity.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = 0,
                                        OrgPriceCreditAmount = 0,
                                        DepreciationAccount = null,
                                        DepreciationDebitAmount = 0,
                                        DepreciationCreditAmount = DepreciationCreditAmountTemp,//faDepreciationDetail.Amount
                                        CapitalAccount = null,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        JournalMemo = faDepreciationEntity.JournalMemo,
                                        Description = null,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        FARefOrder = 2,
                                        FixedAssetOrder = 0,
                                        Quantity = fixedAssetEntity.Quantity,
                                        DifferenceQuantity = 0,
                                        FixedAssetCode = fixedAssetEntity.FixedAssetCode,
                                        FixedAssetName = fixedAssetEntity.FixedAssetName,
                                        DevaluationRate = faDepreciationEntity.RefType == 419 ? faDepreciationDetail.AnnualDepreciationRate : 0,
                                        DevaluationDebitAmount = 0,
                                        DevaluationCreditAmount = DevaluationCreditAmounttemp,
                                        RemainingDevaluationLifeTime = 0,
                                        DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount
                                    };
                                    response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = faDepreciationEntity.RefType,
                                RefId = faDepreciationEntity.RefId,
                                JournalMemo = faDepreciationEntity.JournalMemo,
                                RefDate = faDepreciationEntity.RefDate,
                                PostedDate = faDepreciationEntity.PostedDate,
                                RefNo = faDepreciationEntity.RefNo,
                                RefDetailId = faDepreciationDetail.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                ActivityId = faDepreciationDetail.ActivityId,
                                Amount = faDepreciationDetail.Amount,
                                AmountOC = faDepreciationDetail.Amount,
                                Approved = true,
                                BankId = null,
                                BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                CreditAccount = faDepreciationDetail.CreditAccount,
                                DebitAccount = faDepreciationDetail.DebitAccount,
                                Description = faDepreciationDetail.Description,
                                FundStructureId = faDepreciationDetail.FundStructureId,
                                ProjectActivityId = faDepreciationDetail.ProjectActivityId,
                                MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                ProjectId = faDepreciationDetail.ProjectId,
                                ToBankId = null,
                                SortOrder = faDepreciationDetail.SortOrder,
                                CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                ExchangeRate = 1,
                                BudgetExpenseId = faDepreciationDetail.BudgetExpenseId
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

                    scope.Complete();
                }
                response.RefId = faDepreciationEntity.RefId;
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
        /// <param name="faDepreciationEntity">The fa depreciation entity.</param>
        /// <returns></returns>
        public FADepreciationResponse UpdateFADepreciation(FADepreciationEntity faDepreciationEntity)
        {
            var response = new FADepreciationResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!faDepreciationEntity.Validate())
                {
                    foreach (var error in faDepreciationEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = FADepreciationDao.GetFADepreciation(faDepreciationEntity.RefNo.Trim(), faDepreciationEntity.PostedDate);
                    if (faDepreciation != null && faDepreciation.PostedDate.Year == faDepreciationEntity.PostedDate.Year)
                    {
                        if (faDepreciation.RefId != faDepreciationEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ " + faDepreciationEntity.RefNo + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = FADepreciationDao.UpdateFADepreciation(faDepreciationEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(faDepreciationEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Delete detail and insert detail

                    response.Message = FADepreciationDetailDao.DeleteFADepreciationDetailByFADepreciationId(faDepreciationEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //Xóa bảng FixedAssetLedger
                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDepreciationEntity.RefId, faDepreciationEntity.RefType);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // insert bang GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(faDepreciationEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(faDepreciationEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    //Lấy MainCurrencyID mặc định trong DBOption
                    DataTable dbOptionValue = GeneralLedgerDao.GetMainCurrencyIDFromDBOption("MainCurrencyID");

                    if (faDepreciationEntity.FADepreciationDetails != null)
                        foreach (var faDepreciationDetail in faDepreciationEntity.FADepreciationDetails)
                        {
                            faDepreciationDetail.RefDetailId = Guid.NewGuid().ToString();
                            faDepreciationDetail.RefId = faDepreciationEntity.RefId;
                            response.Message = FADepreciationDetailDao.InsertFADepreciationDetail(faDepreciationDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(faDepreciationEntity, faDepreciationDetail);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            #endregion

                            #region Insert FixedAssetLedger
                            if (faDepreciationDetail.FixedAssetId != null)
                            {
                                //get fixedAssetInfo
                                var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(faDepreciationDetail.FixedAssetId);
                                if (faDepreciationDetail.CreditAccount != null && faDepreciationDetail.CreditAccount.StartsWith("214"))
                                    {
                                    decimal DepreciationCreditAmountTemp = faDepreciationEntity.RefType == 255 ? faDepreciationDetail.Amount : 0;
                                    decimal DevaluationCreditAmounttemp = faDepreciationEntity.RefType == 419 ? faDepreciationDetail.Amount : 0;
                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = faDepreciationEntity.RefId,
                                        RefType = faDepreciationEntity.RefType,
                                        RefNo = faDepreciationEntity.RefNo,
                                        RefDate = faDepreciationEntity.RefDate,
                                        PostedDate = faDepreciationEntity.PostedDate,
                                        FixedAssetId = faDepreciationDetail.FixedAssetId,
                                        DepartmentId = fixedAssetEntity.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = 0,
                                        OrgPriceCreditAmount = 0,
                                        DepreciationAccount = null,
                                        DepreciationDebitAmount = 0,
                                        DepreciationCreditAmount = DepreciationCreditAmountTemp,//faDepreciationDetail.Amount
                                        CapitalAccount = null,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        JournalMemo = faDepreciationEntity.JournalMemo,
                                        Description = null,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        FARefOrder = 2,
                                        FixedAssetOrder = 0,
                                        Quantity = fixedAssetEntity.Quantity,
                                        DifferenceQuantity = 0,
                                        FixedAssetCode = fixedAssetEntity.FixedAssetCode,
                                        FixedAssetName = fixedAssetEntity.FixedAssetName,
                                        DevaluationRate = faDepreciationEntity.RefType == 419 ? faDepreciationDetail.AnnualDepreciationRate : 0,
                                        DevaluationDebitAmount = 0,
                                        DevaluationCreditAmount = DevaluationCreditAmounttemp,
                                        RemainingDevaluationLifeTime = 0,
                                        DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount
                                    };
                                    response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                            }

                            #endregion

                            #region Insert GeneralLedger

                            if (faDepreciationDetail.DebitAccount != null && faDepreciationDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = faDepreciationEntity.RefType,
                                    RefNo = faDepreciationEntity.RefNo,
                                    AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                    BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                    ProjectId = faDepreciationDetail.ProjectId,
                                    BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                    Description = faDepreciationDetail.Description,
                                    RefDetailId = faDepreciationDetail.RefDetailId,
                                    ActivityId = faDepreciationDetail.ActivityId,
                                    BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                    RefId = faDepreciationEntity.RefId,
                                    PostedDate = faDepreciationEntity.PostedDate,
                                    MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                    BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                    ListItemId = faDepreciationDetail.ListItemId,
                                    BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                    AccountNumber = faDepreciationDetail.DebitAccount,
                                    CorrespondingAccountNumber = faDepreciationDetail.CreditAccount,
                                    DebitAmount = faDepreciationDetail.Amount,
                                    DebitAmountOC = faDepreciationDetail.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = faDepreciationDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = faDepreciationEntity.JournalMemo,
                                    RefDate = faDepreciationEntity.RefDate,
                                    SortOrder = faDepreciationDetail.SortOrder,
                                    CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                    ExchangeRate = 1,
                                    BudgetExpenseId = faDepreciationDetail.BudgetExpenseId

                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = faDepreciationDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = faDepreciationDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = faDepreciationDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = faDepreciationDetail.Amount;
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
                                    RefType = faDepreciationEntity.RefType,
                                    RefNo = faDepreciationEntity.RefNo,
                                    AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                    BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                    ProjectId = faDepreciationDetail.ProjectId,
                                    BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                    Description = faDepreciationDetail.Description,
                                    RefDetailId = faDepreciationDetail.RefDetailId,
                                    ActivityId = faDepreciationDetail.ActivityId,
                                    BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                    BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                    RefId = faDepreciationEntity.RefId,
                                    PostedDate = faDepreciationEntity.PostedDate,
                                    MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                    BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                    ListItemId = faDepreciationDetail.ListItemId,
                                    BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                    AccountNumber = faDepreciationDetail.DebitAccount ?? faDepreciationDetail.CreditAccount,
                                    DebitAmount = faDepreciationDetail.DebitAccount == null ? 0 : faDepreciationDetail.Amount,
                                    DebitAmountOC = faDepreciationDetail.DebitAccount == null ? 0 : faDepreciationDetail.Amount,
                                    CreditAmount = faDepreciationDetail.CreditAccount == null ? 0 : faDepreciationDetail.Amount,
                                    CreditAmountOC = faDepreciationDetail.CreditAccount == null ? 0 : faDepreciationDetail.Amount,
                                    FundStructureId = faDepreciationDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = faDepreciationEntity.JournalMemo,
                                    RefDate = faDepreciationEntity.RefDate,
                                    SortOrder = faDepreciationDetail.SortOrder,
                                    CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                    ExchangeRate = 1
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
                                RefType = faDepreciationEntity.RefType,
                                RefId = faDepreciationEntity.RefId,
                                JournalMemo = faDepreciationEntity.JournalMemo,
                                RefDate = faDepreciationEntity.RefDate,
                                PostedDate = faDepreciationEntity.PostedDate,
                                RefNo = faDepreciationEntity.RefNo,
                                RefDetailId = faDepreciationDetail.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                                ActivityId = faDepreciationDetail.ActivityId,
                                Amount = faDepreciationDetail.Amount,
                                AmountOC = faDepreciationDetail.Amount,
                                Approved = true,
                                BankId = null,
                                BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                                BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode,
                                BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                                BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                                BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                                BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = faDepreciationDetail.CashWithDrawTypeId,
                                CreditAccount = faDepreciationDetail.CreditAccount,
                                DebitAccount = faDepreciationDetail.DebitAccount,
                                Description = faDepreciationDetail.Description,
                                FundStructureId = faDepreciationDetail.FundStructureId,
                                ProjectActivityId = faDepreciationDetail.ProjectActivityId,
                                MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                                ProjectId = faDepreciationDetail.ProjectId,
                                ToBankId = null,
                                SortOrder = faDepreciationDetail.SortOrder,
                                CurrencyCode = dbOptionValue.Rows.Count > 0 ? dbOptionValue.Rows[0]["OptionValue"].ToString() : "VND",
                                ExchangeRate = 1,
                                BudgetExpenseId = faDepreciationDetail.BudgetExpenseId
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

                    scope.Complete();
                }
                response.RefId = faDepreciationEntity.RefId;
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
        public FADepreciationResponse DeleteFADepreciation(string refId)
        {
            var response = new FADepreciationResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var faDepreciationEntity = FADepreciationDao.GetFADepreciation(refId);
                if (faDepreciationEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    #region Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(faDepreciationEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    #endregion

                    //Xóa bảng GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(faDepreciationEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //Xóa bảng OriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(faDepreciationEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //Xóa bảng FixedAssetLedger
                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDepreciationEntity.RefId, faDepreciationEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //Xóa bảng FADepreciation
                    response.Message = FADepreciationDao.DeleteFADepreciation(faDepreciationEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = faDepreciationEntity.RefId;
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
        /// <param name="faDepreciation">The fa depreciation.</param>
        /// <param name="faDepreciationDetail">The fa depreciation detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(FADepreciationEntity faDepreciation, FADepreciationDetailEntity faDepreciationDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = faDepreciationDetail.DebitAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = faDepreciation.PostedDate,
                MovementDebitAmountOC = faDepreciationDetail.Amount,
                MovementDebitAmount = faDepreciationDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                ActivityId = faDepreciationDetail.ActivityId,
                ProjectId = faDepreciationDetail.ProjectId,
                FundStructureId = faDepreciationDetail.FundStructureId,
                ProjectActivityId = faDepreciationDetail.ProjectActivityId,
                BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="faDepreciation">The fa depreciation.</param>
        /// <param name="faDepreciationDetail">The fa depreciation detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(FADepreciationEntity faDepreciation, FADepreciationDetailEntity faDepreciationDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = faDepreciationDetail.CreditAccount,
                CurrencyCode = "VND",
                ExchangeRate = 1,
                BalanceDate = faDepreciation.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = faDepreciationDetail.Amount,
                MovementCreditAmount = faDepreciationDetail.Amount,
                BudgetSourceId = faDepreciationDetail.BudgetSourceId,
                BudgetChapterCode = faDepreciationDetail.BudgetChapterCode,
                BudgetKindItemCode = faDepreciationDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = faDepreciationDetail.BudgetSubKindItemCode,
                BudgetItemCode = faDepreciationDetail.BudgetItemCode,
                BudgetSubItemCode = faDepreciationDetail.BudgetSubItemCode,
                MethodDistributeId = faDepreciationDetail.MethodDistributeId,
                AccountingObjectId = faDepreciationDetail.AccountingObjectId,
                ActivityId = faDepreciationDetail.ActivityId,
                ProjectId = faDepreciationDetail.ProjectId,
                FundStructureId = faDepreciationDetail.FundStructureId,
                ProjectActivityId = faDepreciationDetail.ProjectActivityId,
                BudgetDetailItemCode = faDepreciationDetail.BudgetDetailItemCode
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
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(FADepreciationEntity caPaymentEntity)
        {
            var paymentDetails = FADepreciationDetailDao.GetFADepreciationDetailsByFADepreciation(caPaymentEntity.RefId);
            foreach (var paymentDetail in paymentDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, paymentDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, paymentDetail);
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
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        public void InsertAccountBalance(FADepreciationEntity caPaymentEntity, FADepreciationDetailEntity paymentDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, paymentDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, paymentDetail);
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
