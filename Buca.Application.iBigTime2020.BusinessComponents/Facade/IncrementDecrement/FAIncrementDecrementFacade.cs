/***********************************************************************
 * <copyright file="FAIncrementDecrementFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.SqlServer;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementFacade
    /// </summary>
    public class FAIncrementDecrementFacade : FacadeBase
    {
        private static readonly IGeneralLedgerDao GeneralLedgerDao = new SqlServerGeneralLedgerDao();
        private readonly IFAIncrementDecrementDao FAIncrementDecrementDao = new SqlServerFAIncrementDecrementDao();
        private readonly IFAIncrementDecrementDetailDao FAIncrementDecrementDetailDao = new SqlServerFAIncrementDecrementDetailDao();
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        ///     Gets the su increment decrements.
        /// </summary>
        /// <returns></returns>
        public List<FAIncrementDecrementEntity> GetFAIncrementDecrements()
        {
            return FAIncrementDecrementDao.GetFAIncrementDecrements();
        }

        /// <summary>
        ///     Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<FAIncrementDecrementEntity> GetFAIncrementDecrementsByRefTypeId(int refTypeId)
        {
            return FAIncrementDecrementDao.GetFAIncrementDecrementsByRefTypeId(refTypeId);
        }

        /// <summary>
        ///     Gets the ba deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var fAIncrementDecrement = FAIncrementDecrementDao.GetFAIncrementDecrementByRefNo(refNo);
            if (fAIncrementDecrement == null)
                return null;
            if (hasDetail)
                fAIncrementDecrement.FAIncrementDecrementDetails =
                    FAIncrementDecrementDetailDao.GetFAIncrementDecrementDetailsByRefId(fAIncrementDecrement.RefId);
            return fAIncrementDecrement;
        }

        /// <summary>
        ///     Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FAIncrementDecrementEntity GetFAIncrementDecrementByRefId(string refId, bool hasDetail)
        {
            var fAIncrementDecrement = FAIncrementDecrementDao.GetFAIncrementDecrement(refId);

            if (hasDetail && fAIncrementDecrement != null)
            {
                switch (fAIncrementDecrement.RefType)
                {
                    case (int)BuCA.Enum.RefType.FAIncrementDecrement:
                        fAIncrementDecrement.FAIncrementDecrementDetails = FAIncrementDecrementDetailDao.GetFAIncrementDecrementDetailsByRefId(refId);
                        break;
                    default:
                        fAIncrementDecrement.FAIncrementDecrementDetails = FAIncrementDecrementDetailDao.GetFAIncrementDecrementDetailsByRefId(refId);
                        break;
                }
            }
            return fAIncrementDecrement;
        }

        /// <summary>
        ///     Inserts the ba deposit.
        /// </summary>
        /// <param name="fAIncrementDecrementEntity">The b a deposit entity.</param>
        /// <returns></returns>
        public FAIncrementDecrementResponse InsertFAIncrementDecrement(
            FAIncrementDecrementEntity fAIncrementDecrementEntity)
        {
            var response = new FAIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fAIncrementDecrementEntity.Validate())
                {
                    foreach (var error in fAIncrementDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var fAIncrementDecrementByRefNo =
                        FAIncrementDecrementDao.GetFAIncrementDecrementByRefNo(fAIncrementDecrementEntity.RefNo, fAIncrementDecrementEntity.PostedDate);
                    if (fAIncrementDecrementByRefNo != null && fAIncrementDecrementByRefNo.PostedDate.Year == fAIncrementDecrementEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã chứng từ đã tồn tại!";
                        return response;
                    }
                    fAIncrementDecrementEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = FAIncrementDecrementDao.InsertFAIncrementDecrement(fAIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert FAIncrementDecrementDetails

                    //Tạo biến để xác định tài sản đã có không insert vào FixedAssetLedger entity thành dòng mới
                    var fixedAssetId = "";
                    if (fAIncrementDecrementEntity.FAIncrementDecrementDetails != null)
                    {
                        foreach (var fAIncrementDecrementDetailEntity in fAIncrementDecrementEntity.FAIncrementDecrementDetails)
                        {
                            fAIncrementDecrementDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            fAIncrementDecrementDetailEntity.RefId = fAIncrementDecrementEntity.RefId;
                            response.Message =
                                FAIncrementDecrementDetailDao.InsertFAIncrementDecrementDetail(fAIncrementDecrementDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region insert bang GeneralLedger

                            if (fAIncrementDecrementDetailEntity.DebitAccount != null && fAIncrementDecrementDetailEntity.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = fAIncrementDecrementEntity.RefType,
                                    RefNo = fAIncrementDecrementEntity.RefNo,
                                    ProjectId = fAIncrementDecrementDetailEntity.ProjectId,
                                    BudgetSourceId = fAIncrementDecrementDetailEntity.BudgetSourceId,
                                    Description = fAIncrementDecrementDetailEntity.Description,
                                    RefDetailId = fAIncrementDecrementDetailEntity.RefDetailId,
                                    ExchangeRate = 1,
                                    BudgetSubKindItemCode = fAIncrementDecrementDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = fAIncrementDecrementDetailEntity.BudgetKindItemCode,
                                    RefId = fAIncrementDecrementEntity.RefId,
                                    PostedDate = fAIncrementDecrementEntity.PostedDate,
                                    BudgetItemCode = fAIncrementDecrementDetailEntity.BudgetItemCode,
                                    ListItemId = fAIncrementDecrementDetailEntity.ListItemId,
                                    BudgetSubItemCode = fAIncrementDecrementDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = fAIncrementDecrementDetailEntity.BudgetDetailItemCode,
                                    AccountNumber = fAIncrementDecrementDetailEntity.DebitAccount,
                                    CorrespondingAccountNumber = fAIncrementDecrementDetailEntity.CreditAccount,
                                    DebitAmount =
                                        fAIncrementDecrementDetailEntity.DebitAccount == null
                                            ? 0
                                            : fAIncrementDecrementDetailEntity.Amount,
                                    DebitAmountOC =
                                        fAIncrementDecrementDetailEntity.DebitAccount == null
                                            ? 0
                                            : fAIncrementDecrementDetailEntity.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = fAIncrementDecrementDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAIncrementDecrementEntity.JournalMemo,
                                    RefDate = fAIncrementDecrementEntity.RefDate,
                                    SortOrder = fAIncrementDecrementDetailEntity.SortOrder,
                                    AccountingObjectId = fAIncrementDecrementDetailEntity.AccountingObjectId,
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = fAIncrementDecrementDetailEntity.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = fAIncrementDecrementDetailEntity.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = fAIncrementDecrementDetailEntity.Amount;
                                generalLedgerEntity.CreditAmountOC = fAIncrementDecrementDetailEntity.Amount;
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
                                    RefType = fAIncrementDecrementEntity.RefType,
                                    RefNo = fAIncrementDecrementEntity.RefNo,
                                    ProjectId = fAIncrementDecrementDetailEntity.ProjectId,
                                    BudgetSourceId = fAIncrementDecrementDetailEntity.BudgetSourceId,
                                    Description = fAIncrementDecrementDetailEntity.Description,
                                    RefDetailId = fAIncrementDecrementDetailEntity.RefDetailId,
                                    ExchangeRate = 1,
                                    BudgetSubKindItemCode = fAIncrementDecrementDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = fAIncrementDecrementDetailEntity.BudgetKindItemCode,
                                    RefId = fAIncrementDecrementEntity.RefId,
                                    PostedDate = fAIncrementDecrementEntity.PostedDate,
                                    BudgetItemCode = fAIncrementDecrementDetailEntity.BudgetItemCode,
                                    ListItemId = fAIncrementDecrementDetailEntity.ListItemId,
                                    BudgetSubItemCode = fAIncrementDecrementDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = fAIncrementDecrementDetailEntity.BudgetDetailItemCode,
                                    AccountNumber = fAIncrementDecrementDetailEntity.DebitAccount ?? fAIncrementDecrementDetailEntity.CreditAccount,
                                    DebitAmount =
                                        fAIncrementDecrementDetailEntity.DebitAccount == null
                                            ? 0
                                            : fAIncrementDecrementDetailEntity.Amount,
                                    DebitAmountOC =
                                        fAIncrementDecrementDetailEntity.DebitAccount == null
                                            ? 0
                                            : fAIncrementDecrementDetailEntity.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = fAIncrementDecrementDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAIncrementDecrementEntity.JournalMemo,
                                    RefDate = fAIncrementDecrementEntity.RefDate,
                                    SortOrder = fAIncrementDecrementDetailEntity.SortOrder
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
                            // insert bang GeneralLedger
                            //1 tài sản lưu thành 1 dòng, số tiền = tổng số tiền của các dòng cùng tài sản
                            if (fAIncrementDecrementDetailEntity.FixedAssetId != null)
                            {
                                var totalAmount = (from f in fAIncrementDecrementEntity.FAIncrementDecrementDetails where f.FixedAssetId == fAIncrementDecrementDetailEntity.FixedAssetId select f).ToList();
                                if (fixedAssetId != fAIncrementDecrementDetailEntity.FixedAssetId)
                                {
                                    //get fixedAssetInfo
                                    var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(fAIncrementDecrementDetailEntity.FixedAssetId);

                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = fAIncrementDecrementEntity.RefId,
                                        RefType = fAIncrementDecrementEntity.RefType,
                                        RefNo = fAIncrementDecrementEntity.RefNo,
                                        RefDate = fAIncrementDecrementEntity.RefDate,
                                        PostedDate = fAIncrementDecrementEntity.PostedDate,
                                        FixedAssetId = fAIncrementDecrementDetailEntity.FixedAssetId,
                                        DepartmentId = fAIncrementDecrementDetailEntity.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("211") || fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("213") ? totalAmount.Select(c => c.Amount).Sum() : 0,
                                        OrgPriceCreditAmount = fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("211") || fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("213") ? 0 : totalAmount.Select(c => c.Amount).Sum(),
                                        DepreciationAccount = null,
                                        DepreciationDebitAmount = fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("214") ? fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount : 0,
                                        DepreciationCreditAmount = fAIncrementDecrementDetailEntity.DebitAccount.StartsWith("214") ? 0 : fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                        CapitalAccount = fixedAssetEntity.CapitalAccount,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        Quantity = (decimal)fAIncrementDecrementDetailEntity.Quantity,// fixedAssetEntity.Quantity,
                                        //Quantity = fixedAssetEntity.Quantity,
                                        JournalMemo = fAIncrementDecrementEntity.JournalMemo,
                                        Description = fAIncrementDecrementDetailEntity.Description,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
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
                                    fixedAssetId = fAIncrementDecrementDetailEntity.FixedAssetId;
                                }
                            }
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = fAIncrementDecrementEntity.RefType,
                                RefId = fAIncrementDecrementEntity.RefId,
                                JournalMemo = fAIncrementDecrementEntity.JournalMemo,
                                RefDate = fAIncrementDecrementEntity.RefDate,
                                RefNo = fAIncrementDecrementEntity.RefNo,
                                RefDetailId = fAIncrementDecrementDetailEntity.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                AccountingObjectId = fAIncrementDecrementDetailEntity.AccountingObjectId,
                                ActivityId = fAIncrementDecrementDetailEntity.ActivityId,
                                Amount = fAIncrementDecrementDetailEntity.Amount,
                                AmountOC = fAIncrementDecrementDetailEntity.Amount,
                                Approved = true,
                                BankId = null,
                                BudgetChapterCode = fAIncrementDecrementDetailEntity.BudgetChapterCode,
                                BudgetDetailItemCode = fAIncrementDecrementDetailEntity.BudgetDetailItemCode,
                                BudgetItemCode = fAIncrementDecrementDetailEntity.BudgetItemCode,
                                BudgetKindItemCode = fAIncrementDecrementDetailEntity.BudgetKindItemCode,
                                BudgetSourceId = fAIncrementDecrementDetailEntity.BudgetSourceId,
                                BudgetSubItemCode = fAIncrementDecrementDetailEntity.BudgetSubItemCode,
                                BudgetSubKindItemCode = fAIncrementDecrementDetailEntity.BudgetSubKindItemCode,
                                CashWithDrawTypeId = fAIncrementDecrementDetailEntity.CashWithDrawTypeId,
                                CreditAccount = fAIncrementDecrementDetailEntity.CreditAccount,
                                DebitAccount = fAIncrementDecrementDetailEntity.DebitAccount,
                                Description = fAIncrementDecrementDetailEntity.Description,
                                FundStructureId = fAIncrementDecrementDetailEntity.FundStructureId,
                                ProjectActivityId = fAIncrementDecrementDetailEntity.ProjectActivityId,
                                MethodDistributeId = fAIncrementDecrementDetailEntity.MethodDistributeId,
                                ProjectId = fAIncrementDecrementDetailEntity.ProjectId,
                                ToBankId = null,
                                SortOrder = fAIncrementDecrementDetailEntity.SortOrder,
                                PostedDate = fAIncrementDecrementEntity.PostedDate,

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
                        }
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = fAIncrementDecrementEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Updates the ba deposit.
        /// </summary>
        /// <param name="fAIncrementDecrementEntity">The b a deposit entity.</param>
        /// <returns></returns>
        public FAIncrementDecrementResponse UpdateFAIncrementDecrement(FAIncrementDecrementEntity fAIncrementDecrementEntity, bool isconvertDB)
        {
            var response = new FAIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };

            if (fAIncrementDecrementEntity != null && !fAIncrementDecrementEntity.Validate())
            {
                foreach (var error in fAIncrementDecrementEntity.ValidationErrors)
                    response.Message += error + Environment.NewLine;
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            using (var scope = new TransactionScope())
            {
                if (fAIncrementDecrementEntity != null)
                {
                    #region Master
                    var pUInvoiceByRefNo = FAIncrementDecrementDao.GetFAIncrementDecrementByRefNo(fAIncrementDecrementEntity.RefNo, fAIncrementDecrementEntity.PostedDate);
                    if (pUInvoiceByRefNo != null && !pUInvoiceByRefNo.RefId.Equals(fAIncrementDecrementEntity.RefId) && pUInvoiceByRefNo.PostedDate.Year == fAIncrementDecrementEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", fAIncrementDecrementEntity.RefNo);
                        return response;
                    }
                    if (!isconvertDB)//Nếu là insert từ chứng từ
                    {
                        if (string.IsNullOrEmpty(fAIncrementDecrementEntity.RefId))
                        {
                            fAIncrementDecrementEntity.RefId = Guid.NewGuid().ToString();
                            response.Message =
                                FAIncrementDecrementDao.InsertFAIncrementDecrement(fAIncrementDecrementEntity);
                        }
                        else
                        {
                            // Xóa detail
                            response.Message =
                                FAIncrementDecrementDetailDao.DeleteFAIncrementDecrementDetailByRefId(
                                    fAIncrementDecrementEntity.RefId);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;

                            AutoMapper(DeleteGeneralLedger(fAIncrementDecrementEntity.RefId), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;

                            AutoMapper(DeleteOriginalLedger(fAIncrementDecrementEntity.RefId), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;

                            AutoMapper(
                                DeleteFixAssetLedger(fAIncrementDecrementEntity.RefId,
                                    fAIncrementDecrementEntity.RefType), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;

                            response.Message =
                                FAIncrementDecrementDao.UpdateFAIncrementDecrement(fAIncrementDecrementEntity);
                        }
                    }
                    else//Nếu sử dụng chức năng convertDB
                    {
                        if (string.IsNullOrEmpty(fAIncrementDecrementEntity.RefId))
                        {
                            fAIncrementDecrementEntity.RefId = Guid.NewGuid().ToString();
                        }
                        response.Message =
                            FAIncrementDecrementDao.InsertFAIncrementDecrement(fAIncrementDecrementEntity);
                    }
                    if (!string.IsNullOrEmpty(response.Message))
                        goto Error;
                    #endregion

                    #region Detail
                    //Tạo biến để xác định tài sản đã có không insert vào FixedAssetLedger entity thành dòng mới
                    var fixedAssetId = "";
                    if (fAIncrementDecrementEntity.FAIncrementDecrementDetails != null && fAIncrementDecrementEntity.FAIncrementDecrementDetails.Count > 0)
                    {
                        foreach (FAIncrementDecrementDetailEntity entity in fAIncrementDecrementEntity.FAIncrementDecrementDetails)
                        {
                            entity.RefDetailId = Guid.NewGuid().ToString();
                            entity.RefId = fAIncrementDecrementEntity.RefId;
                            response.Message = FAIncrementDecrementDetailDao.InsertFAIncrementDecrementDetail(entity);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;

                            #region General Ledger
                            AutoMapper(InsertGeneralLedger(entity, fAIncrementDecrementEntity), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                            #endregion

                            #region Original Ledger
                            AutoMapper(InsertOriginalLedger(entity, fAIncrementDecrementEntity), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                            #endregion

                            //#region FixedAsset Ledger
                            //AutoMapper(InsertFixAssetLedger(entity, fAIncrementDecrementEntity), pUInvoiceResponse);
                            //if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                            //    goto Error;
                            //#endregion

                            #region Insert FixedAssetLedger
                            // insert bang GeneralLedger
                            //1 tài sản lưu thành 1 dòng, số tiền = tổng số tiền của các dòng cùng tài sản
                            if (entity.FixedAssetId != null)
                            {
                                var totalAmount = (from f in fAIncrementDecrementEntity.FAIncrementDecrementDetails where f.FixedAssetId == entity.FixedAssetId select f).ToList();
                                if (fixedAssetId != entity.FixedAssetId)
                                {
                                    //get fixedAssetInfo
                                    var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);

                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = fAIncrementDecrementEntity.RefId,
                                        RefType = fAIncrementDecrementEntity.RefType,
                                        RefNo = fAIncrementDecrementEntity.RefNo,
                                        RefDate = fAIncrementDecrementEntity.RefDate,
                                        PostedDate = fAIncrementDecrementEntity.PostedDate,
                                        FixedAssetId = entity.FixedAssetId,
                                        DepartmentId = entity.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = entity.DebitAccount.StartsWith("211") || entity.DebitAccount.StartsWith("213") ? totalAmount.Select(c => c.Amount).Sum() : 0,
                                        OrgPriceCreditAmount = entity.DebitAccount.StartsWith("211") || entity.DebitAccount.StartsWith("213") ? 0 : totalAmount.Select(c => c.Amount).Sum(),
                                        DepreciationAccount = null,
                                        DepreciationDebitAmount = entity.DebitAccount.StartsWith("214") ? entity.Amount * (100 - fixedAssetEntity.UsingRatio) / 100 : 0,
                                        DepreciationCreditAmount = entity.CreditAccount.StartsWith("214") ? entity.Amount * (100 - fixedAssetEntity.UsingRatio) / 100 : 0,
                                        CapitalAccount = fixedAssetEntity.CapitalAccount,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        Quantity = (decimal)entity.Quantity,// fixedAssetEntity.Quantity,
                                        JournalMemo = fAIncrementDecrementEntity.JournalMemo,
                                        Description = entity.Description,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        DevaluationDebitAmount = entity.DebitAccount.StartsWith("214") ? entity.Amount * fixedAssetEntity.UsingRatio / 100 : 0,
                                        DevaluationCreditAmount = entity.CreditAccount.StartsWith("214") ? entity.Amount * fixedAssetEntity.UsingRatio / 100 : 0,
                                        EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,

                                    };

                                    response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    fixedAssetId = entity.FixedAssetId;
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Error
                    Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    response.RefId = fAIncrementDecrementEntity.RefId;
                    scope.Complete();
                    #endregion
                }
                return response;
            }
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="fAIncrementDecrementId">The b a deposit identifier.</param>
        /// <returns></returns>
        public FAIncrementDecrementResponse DeleteFAIncrementDecrement(string fAIncrementDecrementId)
        {
            var response = new FAIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };

            using (var scope = new TransactionScope())
            {
                #region Delete
                var fAIncrementDecrementEntity = FAIncrementDecrementDao.GetFAIncrementDecrement(fAIncrementDecrementId);
                if (fAIncrementDecrementEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }

                response.Message = FAIncrementDecrementDao.DeleteFAIncrementDecrement(fAIncrementDecrementEntity);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                response.Message = FAIncrementDecrementDetailDao.DeleteFAIncrementDecrementDetailByRefId(fAIncrementDecrementId);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                AutoMapper(DeleteGeneralLedger(fAIncrementDecrementId), response);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                AutoMapper(DeleteOriginalLedger(fAIncrementDecrementId), response);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                AutoMapper(DeleteFixAssetLedger(fAIncrementDecrementId, fAIncrementDecrementEntity.RefType), response);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;
                #endregion

                #region Error
                Error:
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return response;
                }
                response.RefId = fAIncrementDecrementId;
                scope.Complete();
                #endregion
            }
            return response;
        }
    }
}