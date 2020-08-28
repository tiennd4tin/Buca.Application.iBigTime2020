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
    public class FAAdjustmentFacade : FacadeBase
    {
        private static readonly IGeneralLedgerDao GeneralLedgerDao = new SqlServerGeneralLedgerDao();

        private readonly IFAAdjustmentDao FAAdjustmentDao = new SqlServerFAAdjustmentDao();

        private readonly IFAAdjustmentDetailDao FAAdjustmentDetailDao = new SqlServerFAAdjustmentDetailDao();
        private readonly IFAAdjustmentDetailParallelDao FAAdjustmentDetailParallelDao = new SqlServerFAAdjustmentDetailParallelDao();
        private readonly IFAIncrementDecrementDetailDao FAIncrementDecrementDetailDao = new SqlServerFAIncrementDecrementDetailDao();
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        public List<FAAdjustmentEntity> GetFAAdjustments()
        {
            return FAAdjustmentDao.GetFAAdjustments();
        }
        public FAAdjustmentEntity GetFAAdjustmentByRefId(string RefId)
        {
            var fAAdjustment = FAAdjustmentDao.GetFAAdjustmentbyRefId(RefId);
            var fAAdjustmentDetail = FAAdjustmentDetailDao.GetFAAdjustmentDetailsByRefId(RefId);
            var fAAdjustmentDetailParallel = FAAdjustmentDetailParallelDao.GetFAAdjustmentDetailParallelsByRefId(fAAdjustment.RefId);
            if (fAAdjustment == null)
                return null;
            else
            {
                if (fAAdjustmentDetail != null)
                {
                    fAAdjustment.FAAdjustmentDetails = fAAdjustmentDetail;
                }
                if (fAAdjustmentDetailParallel != null)
                {
                    fAAdjustment.FAAdjustmentDetailParallels = fAAdjustmentDetailParallel;
                }
            }
            return fAAdjustment;
        }
        public FAAdjustmentEntity GetFAAdjustmentByRefId(string RefId, bool hasDetail, bool hasDetailParallel)
        {
            var fAAdjustment = FAAdjustmentDao.GetFAAdjustmentbyRefId(RefId);
            if (fAAdjustment == null)
                return null;
            if (hasDetail)
                fAAdjustment.FAAdjustmentDetails = FAAdjustmentDetailDao.GetFAAdjustmentDetailsByRefId(fAAdjustment.RefId);
            if (hasDetailParallel)
                //default get fAAdjustmentDetailParallel
                fAAdjustment.FAAdjustmentDetailParallels = FAAdjustmentDetailParallelDao.GetFAAdjustmentDetailParallelsByRefId(fAAdjustment.RefId);
            return fAAdjustment;
        }

        public FAAdjustmentResponse InsertFAAdjustment(FAAdjustmentEntity fAAdjustmentEntity, bool isAutoGenerateParallel)
        {
            var response = new FAAdjustmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fAAdjustmentEntity.Validate())
                {
                    foreach (var error in fAAdjustmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    //var fAIncrementDecrementByRefNo =
                    //    FAIncrementDecrementDao.GetFAIncrementDecrementByRefNo(fAAdjustmentEntity.RefNo);
                    //if (fAIncrementDecrementByRefNo != null)
                    //{
                    //    response.Acknowledge = AcknowledgeType.Failure;
                    //    response.Message = "Mã chứng từ đã tồn tại!";
                    //    return response;
                    //}
                    fAAdjustmentEntity.RefId = Guid.NewGuid().ToString();

                    response.Message = FAAdjustmentDao.InsertFAAdjustment(fAAdjustmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    fAAdjustmentEntity.RefDetailId = Guid.NewGuid().ToString();
                    response.Message = FAAdjustmentDao.InsertFAAdjustmentDetailFA(fAAdjustmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    #region insert FADepreciationDetails
                    //Tạo biến để xác định tài sản đã có không insert vào FixedAssetLedger entity thành dòng mới
                    var fixedAssetId = "";
                    if (fAAdjustmentEntity.FAAdjustmentDetails != null)
                        foreach (var item in fAAdjustmentEntity.FAAdjustmentDetails)
                        {
                            item.RefDetailId = Guid.NewGuid().ToString();
                            item.RefId = fAAdjustmentEntity.RefId;

                            response.Message = FAAdjustmentDetailDao.InsertFAAdjustmentDetail(item);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            var fixedAsset = FixedAssetDao.GetFixedAssetById(fAAdjustmentEntity.FixedAssetId);
                            #region Insert to AccountBalance

                            //InsertAccountBalance(fAAdjustmentEntity, fAAdjustmentDetail);

                            #endregion

                            #region insert bang GeneralLedger

                            if (item.DebitAccount != null && item.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = fAAdjustmentEntity.RefType,
                                    RefNo = fAAdjustmentEntity.RefNo,
                                    ProjectId = item.ProjectId,
                                    BankId = item.BankId,
                                    BudgetSourceId = item.BudgetSourceId,
                                    Description = item.Description,
                                    RefDetailId = item.RefDetailId,
                                    ExchangeRate = 1,
                                    BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = item.BudgetKindItemCode,
                                    RefId = fAAdjustmentEntity.RefId,
                                    PostedDate = fAAdjustmentEntity.PostedDate,
                                    BudgetItemCode = item.BudgetItemCode,
                                    ListItemId = item.ListItemId,
                                    BudgetSubItemCode = item.BudgetSubItemCode,
                                    BudgetDetailItemCode = item.BudgetDetailItemCode,
                                    AccountNumber = item.DebitAccount,
                                    CorrespondingAccountNumber = item.CreditAccount,
                                    DebitAmount =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    DebitAmountOC =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = item.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                    RefDate = fAAdjustmentEntity.RefDate,
                                    SortOrder = item.SortOrder,
                                    BudgetExpenseId = item.BudgetExpenseId,
                                    AccountingObjectId = item.AccountingObjectId,
                                    ContractId = item.ContractId,
                                    CapitalPlanId = item.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = item.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = item.Amount;
                                generalLedgerEntity.CreditAmountOC = item.Amount;
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
                                    RefType = fAAdjustmentEntity.RefType,
                                    RefNo = fAAdjustmentEntity.RefNo,
                                    ProjectId = item.ProjectId,
                                    BudgetSourceId = item.BudgetSourceId,
                                    BankId = item.BankId,
                                    Description = item.Description,
                                    RefDetailId = item.RefDetailId,
                                    ExchangeRate = 1,
                                    AccountingObjectId = item.AccountingObjectId,
                                    BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = item.BudgetKindItemCode,
                                    RefId = fAAdjustmentEntity.RefId,
                                    PostedDate = fAAdjustmentEntity.PostedDate,
                                    BudgetItemCode = item.BudgetItemCode,
                                    ListItemId = item.ListItemId,
                                    BudgetSubItemCode = item.BudgetSubItemCode,
                                    BudgetDetailItemCode = item.BudgetDetailItemCode,
                                    AccountNumber = item.DebitAccount ?? item.CreditAccount,
                                    DebitAmount =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    DebitAmountOC =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = item.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                    RefDate = fAAdjustmentEntity.RefDate,
                                    SortOrder = item.SortOrder,
                                    ContractId = item.ContractId,
                                    CapitalPlanId = item.CapitalPlanId
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
                            if (fAAdjustmentEntity.FixedAssetId != null)
                            {
                                var totalAmount = (from f in fAAdjustmentEntity.FAAdjustmentDetails select f).ToList();
                                if (fixedAssetId != fAAdjustmentEntity.FixedAssetId)
                                {
                                    //get fixedAssetInfo
                                    var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(fAAdjustmentEntity.FixedAssetId);

                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = fAAdjustmentEntity.RefId,
                                        RefType = fAAdjustmentEntity.RefType,
                                        RefNo = fAAdjustmentEntity.RefNo,
                                        RefDate = fAAdjustmentEntity.RefDate,
                                        PostedDate = fAAdjustmentEntity.PostedDate,
                                        FixedAssetId = fAAdjustmentEntity.FixedAssetId,
                                        DepartmentId = fixedAsset.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fAAdjustmentEntity.NewAnnualDepreciationAmount / fixedAssetEntity.RemainingLifeTime,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = fAAdjustmentEntity.DiffOrgPrice >= 0 ? fAAdjustmentEntity.DiffOrgPrice : 0,//AnhNT
                                        OrgPriceCreditAmount = fAAdjustmentEntity.DiffOrgPrice < 0 ? -fAAdjustmentEntity.DiffOrgPrice : 0,//AnhNT
                                        DepreciationAccount = null,
                                        //DepreciationDebitAmount = 0,
                                        //DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                        CapitalAccount = null,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        //Quantity = fixedAssetEntity.Quantity * (-1), //AnhtNT: Đoạn này sao lại vậy ?
                                        Quantity = fAAdjustmentEntity.NewQuantity,
                                        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        Description = item.Description,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        DevaluationAmount = fAAdjustmentEntity.NewDevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                        DevaluationCreditAmount = fAAdjustmentEntity.DiffAccumDepreciationAmount >= 0 ? fAAdjustmentEntity.DiffAccumDepreciationAmount : 0,
                                        DevaluationDebitAmount = fAAdjustmentEntity.DiffAccumDepreciationAmount < 0 ? -fAAdjustmentEntity.DiffAccumDepreciationAmount : 0,
                                        DepreciationCreditAmount = fAAdjustmentEntity.DiffAccumDevaluationAmount >= 0 ? fAAdjustmentEntity.DiffAccumDevaluationAmount : 0,
                                        DepreciationDebitAmount = fAAdjustmentEntity.DiffAccumDevaluationAmount < 0 ? -fAAdjustmentEntity.DiffAccumDevaluationAmount : 0,
                                    };

                                    response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    fixedAssetId = fAAdjustmentEntity.FixedAssetId;
                                }
                            }
                            #endregion
                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = fAAdjustmentEntity.RefType,
                                RefId = fAAdjustmentEntity.RefId,
                                JournalMemo = fAAdjustmentEntity.JournalMemo,
                                RefDate = fAAdjustmentEntity.RefDate,
                                RefNo = fAAdjustmentEntity.RefNo,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                Approved = true,
                                BankId = null,
                                BudgetChapterCode = item.BudgetChapterCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithDrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                FundStructureId = item.FundStructureId,
                                ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                ProjectId = item.ProjectId,
                                ToBankId = null,
                                SortOrder = item.SortOrder,
                                PostedDate = fAAdjustmentEntity.PostedDate,
                                // Không có Currency trong db : mặc định VNĐ và 1
                                CurrencyCode = "VND",
                                ExchangeRate = 1,
                                BudgetExpenseId = item.BudgetExpenseId,
                                ContractId = item.ContractId,
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

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region FAAdjustmentDetaiParallel

                        if (fAAdjustmentEntity.FAAdjustmentDetailParallels != null)
                        {
                            //insert dl moi
                            foreach (var FAAdjustmentDetaiParallel in fAAdjustmentEntity.FAAdjustmentDetailParallels)
                            {
                                #region Insert FAAdjustmentDetaiParallel

                                FAAdjustmentDetaiParallel.RefId = fAAdjustmentEntity.RefId;
                                FAAdjustmentDetaiParallel.RefDetailId = Guid.NewGuid().ToString();
                                if (!FAAdjustmentDetaiParallel.Validate())
                                {
                                    foreach (var error in FAAdjustmentDetaiParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                response.Message = FAAdjustmentDetailParallelDao.InsertFAAdjustmentDetailParallel(FAAdjustmentDetaiParallel);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                //#region Insert General Ledger Entity
                                //if (FAAdjustmentDetaiParallel.DebitAccount != null & FAAdjustmentDetaiParallel.CreditAccount != null) //định khoản kép lưu thành 2 dòng
                                //{
                                //    var exchangeRate = fAAdjustmentEntity.ExchangeRate == null ? 0 : (decimal)fAAdjustmentEntity.ExchangeRate;
                                //    var generalLedgerEntity = new GeneralLedgerEntity
                                //    {
                                //        RefType = fAAdjustmentEntity.RefType,
                                //        RefNo = fAAdjustmentEntity.RefNo,
                                //        AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                //        BankId = FAAdjustmentDetaiParallel.BankId,
                                //        BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                //        ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                //        BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                //        Description = FAAdjustmentDetaiParallel.Description,
                                //        RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                //        ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                //        ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                //        BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                //        CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                //        BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                //        RefId = fAAdjustmentEntity.RefId,
                                //        PostedDate = fAAdjustmentEntity.PostedDate,
                                //        MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                //        OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                //        OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                //        BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                //        ListItemId = FAAdjustmentDetaiParallel.ListItemId,
                                //        BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                //        BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                //        CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                //        AccountNumber = FAAdjustmentDetaiParallel.DebitAccount,
                                //        CorrespondingAccountNumber = FAAdjustmentDetaiParallel.CreditAccount,
                                //        DebitAmount = FAAdjustmentDetaiParallel.Amount * exchangeRate,
                                //        DebitAmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                //        CreditAmount = 0,
                                //        CreditAmountOC = 0,
                                //        FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                //        RefDate = fAAdjustmentEntity.RefDate,
                                //        BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                //        ContractId = FAAdjustmentDetaiParallel.ContractId,
                                //        CapitalPlanId = FAAdjustmentDetaiParallel.CapitalPlanId,
                                        
                                //    };
                                //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //    if (!string.IsNullOrEmpty(response.Message))
                                //    {
                                //        response.Acknowledge = AcknowledgeType.Failure;
                                //        return response;
                                //    }

                                //    ////insert lan 2
                                //    //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                //    //generalLedgerEntity.AccountNumber = FAAdjustmentDetaiParallel.CreditAccount;
                                //    //generalLedgerEntity.CorrespondingAccountNumber = FAAdjustmentDetaiParallel.DebitAccount;
                                //    //generalLedgerEntity.DebitAmount = 0;
                                //    //generalLedgerEntity.DebitAmountOC = 0;
                                //    //generalLedgerEntity.CreditAmount = FAAdjustmentDetaiParallel.Amount * exchangeRate;
                                //    //generalLedgerEntity.CreditAmountOC = FAAdjustmentDetaiParallel.AmountOC;
                                //    //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                //    //if (!string.IsNullOrEmpty(response.Message))
                                //    //{
                                //    //    response.Acknowledge = AcknowledgeType.Failure;
                                //    //    return response;
                                //    //}
                                //}
                                //else // ghi đơn lưu 1 dòng
                                //{
                                //    var exchangeRate = fAAdjustmentEntity.ExchangeRate == null ? 1 : (decimal)fAAdjustmentEntity.ExchangeRate;
                                //    var generalLedgerEntity = new GeneralLedgerEntity
                                //    {
                                //        RefType = fAAdjustmentEntity.RefType,
                                //        RefNo = fAAdjustmentEntity.RefNo,
                                //        AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                //        BankId = FAAdjustmentDetaiParallel.BankId,
                                //        BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                //        ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                //        BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                //        Description = FAAdjustmentDetaiParallel.Description,
                                //        RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                //        ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                //        ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                //        BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                //        CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                //        BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                //        RefId = fAAdjustmentEntity.RefId,
                                //        PostedDate = fAAdjustmentEntity.PostedDate,
                                //        MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                //        OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                //        OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                //        BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                //        ListItemId = FAAdjustmentDetaiParallel.ListItemId,
                                //        BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                //        BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                //        CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                //        AccountNumber = FAAdjustmentDetaiParallel.DebitAccount ?? FAAdjustmentDetaiParallel.CreditAccount,
                                //        DebitAmount = FAAdjustmentDetaiParallel.DebitAccount == null ? 0 : FAAdjustmentDetaiParallel.Amount * exchangeRate,
                                //        DebitAmountOC = FAAdjustmentDetaiParallel.DebitAccount == null ? 0 : FAAdjustmentDetaiParallel.Amount,
                                //        CreditAmount = FAAdjustmentDetaiParallel.CreditAccount == null ? 0 : FAAdjustmentDetaiParallel.Amount * exchangeRate,
                                //        CreditAmountOC = FAAdjustmentDetaiParallel.CreditAccount == null ? 0 : FAAdjustmentDetaiParallel.Amount,
                                //        FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                //        RefDate = fAAdjustmentEntity.RefDate,
                                //        BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                //        ContractId = FAAdjustmentDetaiParallel.ContractId,
                                //        CapitalPlanId = FAAdjustmentDetaiParallel.CapitalPlanId
                                //    };
                                //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //    if (!string.IsNullOrEmpty(response.Message))
                                //    {
                                //        response.Acknowledge = AcknowledgeType.Failure;
                                //        return response;
                                //    }
                                //}


                                //#endregion

                                //#region Insert OriginalGeneralLedger

                                //var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                //{
                                //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                //    RefType = fAAdjustmentEntity.RefType,
                                //    RefId = fAAdjustmentEntity.RefId,
                                //    RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                //    OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                //    OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                //    RefDate = fAAdjustmentEntity.RefDate,
                                //    RefNo = fAAdjustmentEntity.RefNo,
                                //    AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                //    ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                //    Amount = FAAdjustmentDetaiParallel.Amount,
                                //    AmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                //    Approved = FAAdjustmentDetaiParallel.Approved,
                                //    BankId = FAAdjustmentDetaiParallel.BankId,
                                //    BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                //    BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                //    BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                //    BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                //    BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                //    BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                //    BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                //    CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                //    CreditAccount = FAAdjustmentDetaiParallel.CreditAccount,
                                //    DebitAccount = FAAdjustmentDetaiParallel.DebitAccount,
                                //    Description = FAAdjustmentDetaiParallel.Description,
                                //    FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                //    //ProjectActivityId = FAAdjustmentDetaiParallel.ProjectActivityId,
                                //    MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                //    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                //    ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                //    ToBankId = FAAdjustmentDetaiParallel.BankId,
                                //    ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                //    CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                //    PostedDate = fAAdjustmentEntity.PostedDate,
                                //    BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                //    ContractId = FAAdjustmentDetaiParallel.ContractId,
                                //};
                                //response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                //if (!string.IsNullOrEmpty(response.Message))
                                //{
                                //    response.Acknowledge = AcknowledgeType.Failure;
                                //    return response;
                                //}

                                //#endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (fAAdjustmentEntity.FAAdjustmentDetails != null)
                        {
                            var exchangeRate = fAAdjustmentEntity.ExchangeRate == null ? 0 : (decimal)fAAdjustmentEntity.ExchangeRate;

                            foreach (var FAAdjustmentDetai in fAAdjustmentEntity.FAAdjustmentDetails)
                            {
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        FAAdjustmentDetai.DebitAccount, FAAdjustmentDetai.CreditAccount,
                                        FAAdjustmentDetai.BudgetSourceId,
                                        FAAdjustmentDetai.BudgetChapterCode, FAAdjustmentDetai.BudgetKindItemCode,
                                        FAAdjustmentDetai.BudgetSubKindItemCode, FAAdjustmentDetai.BudgetItemCode,
                                        FAAdjustmentDetai.BudgetSubItemCode,
                                        FAAdjustmentDetai.MethodDistributeId, FAAdjustmentDetai.CashWithDrawTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region FAAdjustmentDetaiParallel

                                        var FAAdjustmentDetaiParallel = new FAAdjustmentDetailParallelEntity()
                                        {
                                            RefId = fAAdjustmentEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = FAAdjustmentDetai.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                            Amount = FAAdjustmentDetai.Amount,
                                            AmountOC = FAAdjustmentDetai.AmountOC,
                                            BudgetSourceId =
                                                autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                FAAdjustmentDetai.BudgetSourceId,
                                            BudgetChapterCode =
                                                autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                FAAdjustmentDetai.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                FAAdjustmentDetai.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                FAAdjustmentDetai.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                FAAdjustmentDetai.BudgetItemCode,
                                            BudgetSubItemCode =
                                                autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                FAAdjustmentDetai.BudgetSubItemCode,
                                            MethodDistributeId =
                                                autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                FAAdjustmentDetai.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                FAAdjustmentDetai.CashWithDrawTypeId,
                                            AccountingObjectId = FAAdjustmentDetai.AccountingObjectId,
                                            ActivityId = FAAdjustmentDetai.ActivityId,
                                            ProjectId = FAAdjustmentDetai.ProjectId,
                                            ListItemId = FAAdjustmentDetai.ListItemId,
                                            Approved = true,
                                            SortOrder = FAAdjustmentDetai.SortOrder,
                                            //OrgRefNo = FAAdjustmentDetai.OrgRefNo,
                                            //OrgRefDate = FAAdjustmentDetai.OrgRefDate,
                                            FundStructureId = FAAdjustmentDetai.FundStructureId,
                                            BudgetExpenseId = FAAdjustmentDetai.BudgetExpenseId,
                                            BankId = FAAdjustmentDetai.BankId
                                            //FAAdjustmentDetaiParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                            //FAAdjustmentDetaiParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                        };
                                        if (!FAAdjustmentDetaiParallel.Validate())
                                        {
                                            foreach (var error in FAAdjustmentDetaiParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        response.Message =
                                            FAAdjustmentDetailParallelDao.InsertFAAdjustmentDetailParallel(
                                                FAAdjustmentDetaiParallel);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        //#region Insert General Ledger Entity
                                        //if (string.IsNullOrEmpty(FAAdjustmentDetaiParallel.DebitAccount) && string.IsNullOrEmpty(FAAdjustmentDetaiParallel.CreditAccount))
                                        //{
                                        //    var generalLedgerEntity = new GeneralLedgerEntity
                                        //    {
                                        //        RefType = fAAdjustmentEntity.RefType,
                                        //        RefNo = fAAdjustmentEntity.RefNo,
                                        //        AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                        //        BankId = FAAdjustmentDetaiParallel.BankId,
                                        //        BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                        //        ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                        //        BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                        //        Description = FAAdjustmentDetaiParallel.Description,
                                        //        RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                        //        ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                        //        ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                        //        BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                        //        CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                        //        BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                        //        RefId = fAAdjustmentEntity.RefId,
                                        //        PostedDate = fAAdjustmentEntity.PostedDate,
                                        //        MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                        //        OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                        //        OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                        //        BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                        //        ListItemId = FAAdjustmentDetaiParallel.ListItemId,
                                        //        BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                        //        BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                        //        CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,

                                        //        AccountNumber =
                                        //                                                    FAAdjustmentDetaiParallel.DebitAccount,
                                        //        CorrespondingAccountNumber =
                                        //                                                    FAAdjustmentDetaiParallel.CreditAccount,
                                        //        DebitAmount = FAAdjustmentDetaiParallel.Amount * exchangeRate,
                                        //        DebitAmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                        //        CreditAmount = 0,
                                        //        CreditAmountOC = 0,
                                        //        FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //        RefDate = fAAdjustmentEntity.RefDate,
                                        //        BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                        //        ContractId = FAAdjustmentDetaiParallel.ContractId,
                                        //        CapitalPlanId = FAAdjustmentDetaiParallel.CapitalPlanId
                                        //    };
                                        //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        //    if (!string.IsNullOrEmpty(response.Message))
                                        //    {
                                        //        response.Acknowledge = AcknowledgeType.Failure;
                                        //        return response;
                                        //    }

                                        //    ////insert lan 2
                                        //    //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        //    //generalLedgerEntity.AccountNumber = FAAdjustmentDetaiParallel.CreditAccount;
                                        //    //generalLedgerEntity.CorrespondingAccountNumber = FAAdjustmentDetaiParallel.DebitAccount;
                                        //    //generalLedgerEntity.DebitAmount = 0;
                                        //    //generalLedgerEntity.DebitAmountOC = 0;
                                        //    //generalLedgerEntity.CreditAmount = FAAdjustmentDetaiParallel.AmountOC * exchangeRate;
                                        //    //generalLedgerEntity.CreditAmountOC = FAAdjustmentDetaiParallel.AmountOC;
                                        //    //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        //    //if (!string.IsNullOrEmpty(response.Message))
                                        //    //{
                                        //    //    response.Acknowledge = AcknowledgeType.Failure;
                                        //    //    return response;
                                        //    //}
                                        //}

                                        //else
                                        //{
                                        //    var generalLedgerEntity1 = new GeneralLedgerEntity
                                        //    {
                                        //        RefType = fAAdjustmentEntity.RefType,
                                        //        RefNo = fAAdjustmentEntity.RefNo,
                                        //        AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                        //        BankId = FAAdjustmentDetaiParallel.BankId,
                                        //        BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                        //        ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                        //        BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                        //        Description = FAAdjustmentDetaiParallel.Description,
                                        //        RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                        //        ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                        //        ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                        //        BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                        //        CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                        //        BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                        //        RefId = fAAdjustmentEntity.RefId,
                                        //        PostedDate = fAAdjustmentEntity.PostedDate,
                                        //        MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                        //        OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                        //        OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                        //        BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                        //        ListItemId = FAAdjustmentDetaiParallel.ListItemId,
                                        //        BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                        //        BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                        //        CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                        //        AccountNumber = FAAdjustmentDetaiParallel.DebitAccount ?? FAAdjustmentDetaiParallel.CreditAccount,
                                        //        DebitAmount = FAAdjustmentDetaiParallel.DebitAccount == null ? 0 : FAAdjustmentDetaiParallel.AmountOC * exchangeRate,
                                        //        DebitAmountOC =
                                        //                                                    FAAdjustmentDetaiParallel.DebitAccount == null
                                        //                                                        ? 0
                                        //                                                        : FAAdjustmentDetaiParallel.AmountOC,
                                        //        CreditAmount =
                                        //                                                    FAAdjustmentDetaiParallel.CreditAccount == null
                                        //                                                        ? 0
                                        //                                                        : FAAdjustmentDetaiParallel.AmountOC * exchangeRate,
                                        //        CreditAmountOC =
                                        //                                                    FAAdjustmentDetaiParallel.CreditAccount == null
                                        //                                                        ? 0
                                        //                                                        : FAAdjustmentDetaiParallel.AmountOC,
                                        //        FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //        RefDate = fAAdjustmentEntity.RefDate,
                                        //        BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                        //        ContractId = FAAdjustmentDetaiParallel.ContractId,
                                        //        CapitalPlanId = FAAdjustmentDetaiParallel.CapitalPlanId
                                        //    };
                                        //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity1);
                                        //    if (!string.IsNullOrEmpty(response.Message))
                                        //    {
                                        //        response.Acknowledge = AcknowledgeType.Failure;
                                        //        return response;
                                        //    }
                                        //}


                                        //#endregion

                                        //#region Insert OriginalGeneralLedger

                                        //var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        //{
                                        //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        //    RefType = fAAdjustmentEntity.RefType,
                                        //    RefId = fAAdjustmentEntity.RefId,
                                        //    RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                        //    OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                        //    OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                        //    RefDate = fAAdjustmentEntity.RefDate,
                                        //    RefNo = fAAdjustmentEntity.RefNo,
                                        //    AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                        //    ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                        //    Amount = FAAdjustmentDetaiParallel.Amount,
                                        //    AmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                        //    Approved = FAAdjustmentDetaiParallel.Approved,
                                        //    BankId = FAAdjustmentDetaiParallel.BankId,
                                        //    BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                        //    BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                        //    BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                        //    BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                        //    BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                        //    BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                        //    BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                        //    CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                        //    CreditAccount = FAAdjustmentDetaiParallel.CreditAccount,
                                        //    DebitAccount = FAAdjustmentDetaiParallel.DebitAccount,
                                        //    Description = FAAdjustmentDetaiParallel.Description,
                                        //    FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                        //    //ProjectActivityId = FAAdjustmentDetaiParallel.ProjectActivityId,
                                        //    MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                        //    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //    ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                        //    ToBankId = FAAdjustmentDetaiParallel.BankId,
                                        //    ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                        //    CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                        //    PostedDate = fAAdjustmentEntity.PostedDate,
                                        //    BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                        //    ContractId = FAAdjustmentDetaiParallel.ContractId,

                                        //};
                                        //response.Message =
                                        //    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                        //        originalGeneralLedgerEntity);
                                        //if (!string.IsNullOrEmpty(response.Message))
                                        //{
                                        //    response.Acknowledge = AcknowledgeType.Failure;
                                        //    return response;
                                        //}

                                        //#endregion


                                    }
                                }
                            }
                        }

                        scope.Complete();
                    }
                    response.RefId = fAAdjustmentEntity.RefId;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public FAAdjustmentResponse UpdateFAAdjustment(FAAdjustmentEntity fAAdjustmentEntity, bool isAutoGenerateParallel)
        {
            var response = new FAAdjustmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fAAdjustmentEntity.Validate())
                {
                    foreach (var error in fAAdjustmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = FAAdjustmentDao.DeleteFAAdjustmentDetailFA(fAAdjustmentEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    response.Message = FAAdjustmentDetailDao.DeleteFAAdjustmentDetail(fAAdjustmentEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    response.Message = FAAdjustmentDetailParallelDao.DeleteFAAdjustmentDetailParallelByRefId(fAAdjustmentEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(fAAdjustmentEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByFixedAssetId(fAAdjustmentEntity.FixedAssetId, fAAdjustmentEntity.RefType);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(fAAdjustmentEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    fAAdjustmentEntity.RefDetailId = Guid.NewGuid().ToString();
                    response.Message = FAAdjustmentDao.InsertFAAdjustmentDetailFA(fAAdjustmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert FAAdjustmentDetails

                    //Tạo biến để xác định tài sản đã có không insert vào FixedAssetLedger entity thành dòng mới
                    var fixedAssetId = "";
                    if (fAAdjustmentEntity.FAAdjustmentDetails != null)

                    {
                        foreach (var item in fAAdjustmentEntity.FAAdjustmentDetails)
                        {
                            item.RefDetailId = Guid.NewGuid().ToString();
                            item.RefId = fAAdjustmentEntity.RefId;
                            response.Message = FAAdjustmentDetailDao.InsertFAAdjustmentDetail(item);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            var fixedAsset = FixedAssetDao.GetFixedAssetById(fAAdjustmentEntity.FixedAssetId);

                            #region insert bang GeneralLedger

                            if (item.DebitAccount != null && item.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = fAAdjustmentEntity.RefType,
                                    RefNo = fAAdjustmentEntity.RefNo,
                                    ProjectId = item.ProjectId,
                                    BudgetSourceId = item.BudgetSourceId,
                                    BankId = item.BankId,
                                    Description = item.Description,
                                    RefDetailId = item.RefDetailId,
                                    ExchangeRate = 1,
                                    AccountingObjectId = item.AccountingObjectId,
                                    BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = item.BudgetKindItemCode,
                                    RefId = fAAdjustmentEntity.RefId,
                                    PostedDate = fAAdjustmentEntity.PostedDate,
                                    BudgetItemCode = item.BudgetItemCode,
                                    ListItemId = item.ListItemId,
                                    BudgetSubItemCode = item.BudgetSubItemCode,
                                    BudgetDetailItemCode = item.BudgetDetailItemCode,
                                    AccountNumber = item.DebitAccount,
                                    CorrespondingAccountNumber = item.CreditAccount,
                                    DebitAmount =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    DebitAmountOC =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = item.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                    RefDate = fAAdjustmentEntity.RefDate,
                                    SortOrder = item.SortOrder,
                                    BudgetExpenseId = item.BudgetExpenseId,
                                    ContractId = item.ContractId,
                                    CapitalPlanId = item.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = item.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = item.Amount;
                                generalLedgerEntity.CreditAmountOC = item.Amount;
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
                                    RefType = fAAdjustmentEntity.RefType,
                                    RefNo = fAAdjustmentEntity.RefNo,
                                    ProjectId = item.ProjectId,
                                    BudgetSourceId = item.BudgetSourceId,
                                    Description = item.Description,
                                    RefDetailId = item.RefDetailId,
                                    ExchangeRate = 1,
                                    AccountingObjectId = item.AccountingObjectId,
                                    BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                    CurrencyCode = "VND",
                                    BudgetKindItemCode = item.BudgetKindItemCode,
                                    RefId = fAAdjustmentEntity.RefId,
                                    PostedDate = fAAdjustmentEntity.PostedDate,
                                    BudgetItemCode = item.BudgetItemCode,
                                    ListItemId = item.ListItemId,
                                    BudgetSubItemCode = item.BudgetSubItemCode,
                                    BudgetDetailItemCode = item.BudgetDetailItemCode,
                                    AccountNumber = item.DebitAccount ?? item.CreditAccount,
                                    DebitAmount =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    DebitAmountOC =
                                        item.DebitAccount == null
                                            ? 0
                                            : item.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = item.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                    RefDate = fAAdjustmentEntity.RefDate,
                                    SortOrder = item.SortOrder,
                                    ContractId = item.ContractId,
                                    CapitalPlanId = item.CapitalPlanId
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
                            if (fAAdjustmentEntity.FixedAssetId != null)
                            {
                                var totalAmount = (from f in fAAdjustmentEntity.FAAdjustmentDetails select f).ToList();
                                if (fixedAssetId != fAAdjustmentEntity.FixedAssetId)
                                {
                                    //get fixedAssetInfo
                                    var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(fAAdjustmentEntity.FixedAssetId);

                                    var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = fAAdjustmentEntity.RefId,
                                        RefType = fAAdjustmentEntity.RefType,
                                        RefNo = fAAdjustmentEntity.RefNo,
                                        RefDate = fAAdjustmentEntity.RefDate,
                                        PostedDate = fAAdjustmentEntity.PostedDate,
                                        FixedAssetId = fAAdjustmentEntity.FixedAssetId,
                                        DepartmentId = fixedAsset.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = null,
                                        OrgPriceDebitAmount = fAAdjustmentEntity.DiffOrgPrice >= 0 ? fAAdjustmentEntity.DiffOrgPrice : 0, //totalAmount.Select(c => c.Amount).Sum() :0,//AnhNT
                                        OrgPriceCreditAmount = fAAdjustmentEntity.DiffOrgPrice < 0 ? -fAAdjustmentEntity.DiffOrgPrice : 0,//AnhNT
                                        DepreciationAccount = null,
                                        //DepreciationDebitAmount = 0,
                                        //DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                        CapitalAccount = null,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        //Quantity = fixedAssetEntity.Quantity * (-1), //AnhtNT: Đoạn này sao lại vậy ?
                                        Quantity = fAAdjustmentEntity.NewQuantity,
                                        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        Description = item.Description,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        DevaluationAmount = fAAdjustmentEntity.NewDevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                        DevaluationCreditAmount = fAAdjustmentEntity.DiffAccumDepreciationAmount >= 0 ? fAAdjustmentEntity.DiffAccumDepreciationAmount : 0,
                                        DevaluationDebitAmount = fAAdjustmentEntity.DiffAccumDepreciationAmount < 0 ? -fAAdjustmentEntity.DiffAccumDepreciationAmount : 0,
                                        DepreciationCreditAmount = fAAdjustmentEntity.DiffAccumDevaluationAmount >= 0 ? fAAdjustmentEntity.DiffAccumDevaluationAmount : 0,
                                        DepreciationDebitAmount = fAAdjustmentEntity.DiffAccumDevaluationAmount < 0 ? -fAAdjustmentEntity.DiffAccumDevaluationAmount : 0,
                                    };

                                    response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    fixedAssetId = fAAdjustmentEntity.FixedAssetId;
                                }
                            }
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = fAAdjustmentEntity.RefType,
                                RefId = fAAdjustmentEntity.RefId,
                                JournalMemo = fAAdjustmentEntity.JournalMemo,
                                RefDate = fAAdjustmentEntity.RefDate,
                                RefNo = fAAdjustmentEntity.RefNo,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                Approved = true,
                                BankId = null,
                                BudgetChapterCode = item.BudgetChapterCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithDrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                FundStructureId = item.FundStructureId,
                                ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                ProjectId = item.ProjectId,
                                ToBankId = null,
                                SortOrder = item.SortOrder,
                                PostedDate = fAAdjustmentEntity.PostedDate,

                                // Không có Currency trong db : mặc định VNĐ và 1
                                CurrencyCode = "VND",
                                ExchangeRate = 1,
                                BudgetExpenseId = item.BudgetExpenseId,
                                ContractId = item.ContractId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                            if (!isAutoGenerateParallel)
                            {
                                #region FAAdjustmentDetaiParallel

                                if (fAAdjustmentEntity.FAAdjustmentDetailParallels != null)
                                {
                                    //insert dl moi
                                    foreach (var FAAdjustmentDetaiParallel in fAAdjustmentEntity.FAAdjustmentDetailParallels)
                                    {
                                        #region Insert FAAdjustmentDetaiParallel

                                        FAAdjustmentDetaiParallel.RefId = fAAdjustmentEntity.RefId;
                                        FAAdjustmentDetaiParallel.RefDetailId = Guid.NewGuid().ToString();
                                        if (!FAAdjustmentDetaiParallel.Validate())
                                        {
                                            foreach (var error in FAAdjustmentDetaiParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        response.Message = FAAdjustmentDetailParallelDao.InsertFAAdjustmentDetailParallel(FAAdjustmentDetaiParallel);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        //#region insert bang GeneralLedger

                                        //if (item.DebitAccount != null && item.CreditAccount != null)
                                        //{
                                        //    var generalLedgerEntity = new GeneralLedgerEntity
                                        //    {
                                        //        RefType = fAAdjustmentEntity.RefType,
                                        //        RefNo = fAAdjustmentEntity.RefNo,
                                        //        ProjectId = item.ProjectId,
                                        //        BudgetSourceId = item.BudgetSourceId,
                                        //        Description = item.Description,
                                        //        BankId = item.BankId,
                                        //        RefDetailId = item.RefDetailId,
                                        //        ExchangeRate = 1,
                                        //        BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                        //        CurrencyCode = "VND",
                                        //        BudgetKindItemCode = item.BudgetKindItemCode,
                                        //        RefId = fAAdjustmentEntity.RefId,
                                        //        PostedDate = fAAdjustmentEntity.PostedDate,
                                        //        BudgetItemCode = item.BudgetItemCode,
                                        //        ListItemId = item.ListItemId,
                                        //        BudgetSubItemCode = item.BudgetSubItemCode,
                                        //        BudgetDetailItemCode = item.BudgetDetailItemCode,
                                        //        AccountNumber = item.DebitAccount,
                                        //        CorrespondingAccountNumber = item.CreditAccount,
                                        //        DebitAmount =
                                        //            item.DebitAccount == null
                                        //                ? 0
                                        //                : item.Amount,
                                        //        DebitAmountOC =
                                        //            item.DebitAccount == null
                                        //                ? 0
                                        //                : item.Amount,
                                        //        CreditAmount = 0,
                                        //        CreditAmountOC = 0,
                                        //        FundStructureId = item.FundStructureId,
                                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //        RefDate = fAAdjustmentEntity.RefDate,
                                        //        SortOrder = item.SortOrder,
                                        //        BudgetExpenseId = item.BudgetExpenseId,
                                        //        AccountingObjectId = item.AccountingObjectId,
                                        //        ContractId = item.ContractId,
                                        //        CapitalPlanId = item.CapitalPlanId
                                        //    };
                                        //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        //    if (!string.IsNullOrEmpty(response.Message))
                                        //    {
                                        //        response.Acknowledge = AcknowledgeType.Failure;
                                        //        return response;
                                        //    }
                                        //    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        //    generalLedgerEntity.AccountNumber = item.CreditAccount;
                                        //    generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                                        //    generalLedgerEntity.DebitAmount = 0;
                                        //    generalLedgerEntity.DebitAmountOC = 0;
                                        //    generalLedgerEntity.CreditAmount = item.Amount;
                                        //    generalLedgerEntity.CreditAmountOC = item.Amount;
                                        //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        //    if (!string.IsNullOrEmpty(response.Message))
                                        //    {
                                        //        response.Acknowledge = AcknowledgeType.Failure;
                                        //        return response;
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    var generalLedgerEntity = new GeneralLedgerEntity
                                        //    {
                                        //        RefType = fAAdjustmentEntity.RefType,
                                        //        RefNo = fAAdjustmentEntity.RefNo,
                                        //        ProjectId = item.ProjectId,
                                        //        BudgetSourceId = item.BudgetSourceId,
                                        //        BankId = item.BankId,
                                        //        Description = item.Description,
                                        //        RefDetailId = item.RefDetailId,
                                        //        ExchangeRate = 1,
                                        //        AccountingObjectId = item.AccountingObjectId,
                                        //        BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                        //        CurrencyCode = "VND",
                                        //        BudgetKindItemCode = item.BudgetKindItemCode,
                                        //        RefId = fAAdjustmentEntity.RefId,
                                        //        PostedDate = fAAdjustmentEntity.PostedDate,
                                        //        BudgetItemCode = item.BudgetItemCode,
                                        //        ListItemId = item.ListItemId,
                                        //        BudgetSubItemCode = item.BudgetSubItemCode,
                                        //        BudgetDetailItemCode = item.BudgetDetailItemCode,
                                        //        AccountNumber = item.DebitAccount ?? item.CreditAccount,
                                        //        DebitAmount =
                                        //            item.DebitAccount == null
                                        //                ? 0
                                        //                : item.Amount,
                                        //        DebitAmountOC =
                                        //            item.DebitAccount == null
                                        //                ? 0
                                        //                : item.Amount,
                                        //        CreditAmount = 0,
                                        //        CreditAmountOC = 0,
                                        //        FundStructureId = item.FundStructureId,
                                        //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //        RefDate = fAAdjustmentEntity.RefDate,
                                        //        SortOrder = item.SortOrder,
                                        //        ContractId = item.ContractId,
                                        //        CapitalPlanId = item.CapitalPlanId
                                        //    };
                                        //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        //    if (!string.IsNullOrEmpty(response.Message))
                                        //    {
                                        //        response.Acknowledge = AcknowledgeType.Failure;
                                        //        return response;
                                        //    }
                                        //}

                                        //#endregion

                                        //#region Insert OriginalGeneralLedger

                                        //originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        //{
                                        //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        //    RefType = fAAdjustmentEntity.RefType,
                                        //    RefId = fAAdjustmentEntity.RefId,
                                        //    RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                        //    OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                        //    OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                        //    RefDate = fAAdjustmentEntity.RefDate,
                                        //    RefNo = fAAdjustmentEntity.RefNo,
                                        //    AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                        //    ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                        //    Amount = FAAdjustmentDetaiParallel.Amount,
                                        //    AmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                        //    Approved = FAAdjustmentDetaiParallel.Approved,
                                        //    BankId = FAAdjustmentDetaiParallel.BankId,
                                        //    BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                        //    BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                        //    BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                        //    BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                        //    BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                        //    BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                        //    BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                        //    CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                        //    CreditAccount = FAAdjustmentDetaiParallel.CreditAccount,
                                        //    DebitAccount = FAAdjustmentDetaiParallel.DebitAccount,
                                        //    Description = FAAdjustmentDetaiParallel.Description,
                                        //    FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                        //    //ProjectActivityId = FAAdjustmentDetaiParallel.ProjectActivityId,
                                        //    MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                        //    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                        //    ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                        //    ToBankId = FAAdjustmentDetaiParallel.BankId,
                                        //    ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                        //    CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                        //    PostedDate = fAAdjustmentEntity.PostedDate,
                                        //    BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                        //    ContractId = FAAdjustmentDetaiParallel.ContractId,
                                        //};
                                        //response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                        //if (!string.IsNullOrEmpty(response.Message))
                                        //{
                                        //    response.Acknowledge = AcknowledgeType.Failure;
                                        //    return response;
                                        //}

                                        //#endregion
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                if (fAAdjustmentEntity.FAAdjustmentDetails != null)
                                {
                                    var exchangeRate = fAAdjustmentEntity.ExchangeRate == null ? 0 : (decimal)fAAdjustmentEntity.ExchangeRate;

                                    foreach (var FAAdjustmentDetai in fAAdjustmentEntity.FAAdjustmentDetails)
                                    {
                                        //insert dl moi
                                        var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                                FAAdjustmentDetai.DebitAccount, FAAdjustmentDetai.CreditAccount,
                                                FAAdjustmentDetai.BudgetSourceId,
                                                FAAdjustmentDetai.BudgetChapterCode, FAAdjustmentDetai.BudgetKindItemCode,
                                                FAAdjustmentDetai.BudgetSubKindItemCode, FAAdjustmentDetai.BudgetItemCode,
                                                FAAdjustmentDetai.BudgetSubItemCode,
                                                FAAdjustmentDetai.MethodDistributeId, FAAdjustmentDetai.CashWithDrawTypeId
                                               );

                                        if (autoBusinessParallelEntitys != null)
                                        {
                                            foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                            {
                                                #region FAAdjustmentDetaiParallel

                                                var FAAdjustmentDetaiParallel = new FAAdjustmentDetailParallelEntity()
                                                {
                                                    RefId = fAAdjustmentEntity.RefId,
                                                    RefDetailId = Guid.NewGuid().ToString(),
                                                    Description = FAAdjustmentDetai.Description,
                                                    DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                    CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                    Amount = FAAdjustmentDetai.Amount,
                                                    AmountOC = FAAdjustmentDetai.AmountOC,
                                                    BudgetSourceId =
                                                        autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                        FAAdjustmentDetai.BudgetSourceId,
                                                    BudgetChapterCode =
                                                        autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                        FAAdjustmentDetai.BudgetChapterCode,
                                                    BudgetKindItemCode =
                                                        autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                        FAAdjustmentDetai.BudgetKindItemCode,
                                                    BudgetSubKindItemCode =
                                                        autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                        FAAdjustmentDetai.BudgetSubKindItemCode,
                                                    BudgetItemCode =
                                                        autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                        FAAdjustmentDetai.BudgetItemCode,
                                                    BudgetSubItemCode =
                                                        autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                        FAAdjustmentDetai.BudgetSubItemCode,
                                                    MethodDistributeId =
                                                        autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                        FAAdjustmentDetai.MethodDistributeId,
                                                    CashWithdrawTypeId =
                                                        autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                        FAAdjustmentDetai.CashWithDrawTypeId,
                                                    AccountingObjectId = FAAdjustmentDetai.AccountingObjectId,
                                                    ActivityId = FAAdjustmentDetai.ActivityId,
                                                    ProjectId = FAAdjustmentDetai.ProjectId,
                                                    ListItemId = FAAdjustmentDetai.ListItemId,
                                                    Approved = true,
                                                    SortOrder = FAAdjustmentDetai.SortOrder,
                                                    //OrgRefNo = FAAdjustmentDetai.OrgRefNo,
                                                    //OrgRefDate = FAAdjustmentDetai.OrgRefDate,
                                                    FundStructureId = FAAdjustmentDetai.FundStructureId,
                                                    BudgetExpenseId = FAAdjustmentDetai.BudgetExpenseId,
                                                    BankId = FAAdjustmentDetai.BankId
                                                    //FAAdjustmentDetaiParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                    //FAAdjustmentDetaiParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                                };
                                                if (!FAAdjustmentDetaiParallel.Validate())
                                                {
                                                    foreach (var error in FAAdjustmentDetaiParallel.ValidationErrors)
                                                        response.Message += error + Environment.NewLine;
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }
                                                response.Message =
                                                    FAAdjustmentDetailParallelDao.InsertFAAdjustmentDetailParallel(
                                                        FAAdjustmentDetaiParallel);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                #endregion

                                                //#region insert bang GeneralLedger

                                                //if (item.DebitAccount != null && item.CreditAccount != null)
                                                //{
                                                //    var generalLedgerEntity = new GeneralLedgerEntity
                                                //    {
                                                //        RefType = fAAdjustmentEntity.RefType,
                                                //        RefNo = fAAdjustmentEntity.RefNo,
                                                //        BankId = item.BankId,
                                                //        ProjectId = item.ProjectId,
                                                //        BudgetSourceId = item.BudgetSourceId,
                                                //        Description = item.Description,
                                                //        RefDetailId = item.RefDetailId,
                                                //        ExchangeRate = 1,
                                                //        BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                                //        CurrencyCode = "VND",
                                                //        BudgetKindItemCode = item.BudgetKindItemCode,
                                                //        RefId = fAAdjustmentEntity.RefId,
                                                //        PostedDate = fAAdjustmentEntity.PostedDate,
                                                //        BudgetItemCode = item.BudgetItemCode,
                                                //        ListItemId = item.ListItemId,
                                                //        BudgetSubItemCode = item.BudgetSubItemCode,
                                                //        BudgetDetailItemCode = item.BudgetDetailItemCode,
                                                //        AccountNumber = item.DebitAccount,
                                                //        CorrespondingAccountNumber = item.CreditAccount,
                                                //        DebitAmount =
                                                //            item.DebitAccount == null
                                                //                ? 0
                                                //                : item.Amount,
                                                //        DebitAmountOC =
                                                //            item.DebitAccount == null
                                                //                ? 0
                                                //                : item.Amount,
                                                //        CreditAmount = 0,
                                                //        CreditAmountOC = 0,
                                                //        FundStructureId = item.FundStructureId,
                                                //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                                //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                                //        RefDate = fAAdjustmentEntity.RefDate,
                                                //        SortOrder = item.SortOrder,
                                                //        BudgetExpenseId = item.BudgetExpenseId,
                                                //        AccountingObjectId = item.AccountingObjectId,
                                                //        ContractId = item.ContractId,
                                                //        CapitalPlanId = item.CapitalPlanId
                                                //    };
                                                //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                //    if (!string.IsNullOrEmpty(response.Message))
                                                //    {
                                                //        response.Acknowledge = AcknowledgeType.Failure;
                                                //        return response;
                                                //    }
                                                //    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                //    generalLedgerEntity.AccountNumber = item.CreditAccount;
                                                //    generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                                                //    generalLedgerEntity.DebitAmount = 0;
                                                //    generalLedgerEntity.DebitAmountOC = 0;
                                                //    generalLedgerEntity.CreditAmount = item.Amount;
                                                //    generalLedgerEntity.CreditAmountOC = item.Amount;
                                                //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                //    if (!string.IsNullOrEmpty(response.Message))
                                                //    {
                                                //        response.Acknowledge = AcknowledgeType.Failure;
                                                //        return response;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    var generalLedgerEntity = new GeneralLedgerEntity
                                                //    {
                                                //        RefType = fAAdjustmentEntity.RefType,
                                                //        RefNo = fAAdjustmentEntity.RefNo,
                                                //        ProjectId = item.ProjectId,
                                                //        BudgetSourceId = item.BudgetSourceId,
                                                //        BankId = item.BankId,
                                                //        Description = item.Description,
                                                //        RefDetailId = item.RefDetailId,
                                                //        ExchangeRate = 1,
                                                //        AccountingObjectId = item.AccountingObjectId,
                                                //        BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                                //        CurrencyCode = "VND",
                                                //        BudgetKindItemCode = item.BudgetKindItemCode,
                                                //        RefId = fAAdjustmentEntity.RefId,
                                                //        PostedDate = fAAdjustmentEntity.PostedDate,
                                                //        BudgetItemCode = item.BudgetItemCode,
                                                //        ListItemId = item.ListItemId,
                                                //        BudgetSubItemCode = item.BudgetSubItemCode,
                                                //        BudgetDetailItemCode = item.BudgetDetailItemCode,
                                                //        AccountNumber = item.DebitAccount ?? item.CreditAccount,
                                                //        DebitAmount =
                                                //            item.DebitAccount == null
                                                //                ? 0
                                                //                : item.Amount,
                                                //        DebitAmountOC =
                                                //            item.DebitAccount == null
                                                //                ? 0
                                                //                : item.Amount,
                                                //        CreditAmount = 0,
                                                //        CreditAmountOC = 0,
                                                //        FundStructureId = item.FundStructureId,
                                                //        GeneralLedgerId = Guid.NewGuid().ToString(),
                                                //        JournalMemo = fAAdjustmentEntity.JournalMemo,
                                                //        RefDate = fAAdjustmentEntity.RefDate,
                                                //        SortOrder = item.SortOrder,
                                                //        ContractId = item.ContractId,
                                                //        CapitalPlanId = item.CapitalPlanId
                                                //    };
                                                //    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                //    if (!string.IsNullOrEmpty(response.Message))
                                                //    {
                                                //        response.Acknowledge = AcknowledgeType.Failure;
                                                //        return response;
                                                //    }
                                                //}

                                                //#endregion
                                                //#region Insert OriginalGeneralLedger

                                                //originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                                //{
                                                //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                //    RefType = fAAdjustmentEntity.RefType,
                                                //    RefId = fAAdjustmentEntity.RefId,
                                                //    RefDetailId = FAAdjustmentDetaiParallel.RefDetailId,
                                                //    OrgRefDate = FAAdjustmentDetaiParallel.OrgRefDate,
                                                //    OrgRefNo = FAAdjustmentDetaiParallel.OrgRefNo,
                                                //    RefDate = fAAdjustmentEntity.RefDate,
                                                //    RefNo = fAAdjustmentEntity.RefNo,
                                                //    AccountingObjectId = FAAdjustmentDetaiParallel.AccountingObjectId,
                                                //    ActivityId = FAAdjustmentDetaiParallel.ActivityId,
                                                //    Amount = FAAdjustmentDetaiParallel.Amount,
                                                //    AmountOC = FAAdjustmentDetaiParallel.AmountOC,
                                                //    Approved = FAAdjustmentDetaiParallel.Approved,
                                                //    BankId = FAAdjustmentDetaiParallel.BankId,
                                                //    BudgetChapterCode = FAAdjustmentDetaiParallel.BudgetChapterCode,
                                                //    BudgetDetailItemCode = FAAdjustmentDetaiParallel.BudgetDetailItemCode,
                                                //    BudgetItemCode = FAAdjustmentDetaiParallel.BudgetItemCode,
                                                //    BudgetKindItemCode = FAAdjustmentDetaiParallel.BudgetKindItemCode,
                                                //    BudgetSourceId = FAAdjustmentDetaiParallel.BudgetSourceId,
                                                //    BudgetSubItemCode = FAAdjustmentDetaiParallel.BudgetSubItemCode,
                                                //    BudgetSubKindItemCode = FAAdjustmentDetaiParallel.BudgetSubKindItemCode,
                                                //    CashWithDrawTypeId = FAAdjustmentDetaiParallel.CashWithdrawTypeId,
                                                //    CreditAccount = FAAdjustmentDetaiParallel.CreditAccount,
                                                //    DebitAccount = FAAdjustmentDetaiParallel.DebitAccount,
                                                //    Description = FAAdjustmentDetaiParallel.Description,
                                                //    FundStructureId = FAAdjustmentDetaiParallel.FundStructureId,
                                                //    //ProjectActivityId = FAAdjustmentDetaiParallel.ProjectActivityId,
                                                //    MethodDistributeId = FAAdjustmentDetaiParallel.MethodDistributeId,
                                                //    JournalMemo = fAAdjustmentEntity.JournalMemo,
                                                //    ProjectId = FAAdjustmentDetaiParallel.ProjectId,
                                                //    ToBankId = FAAdjustmentDetaiParallel.BankId,
                                                //    ExchangeRate = fAAdjustmentEntity.ExchangeRate,
                                                //    CurrencyCode = fAAdjustmentEntity.CurrencyCode,
                                                //    PostedDate = fAAdjustmentEntity.PostedDate,
                                                //    BudgetExpenseId = FAAdjustmentDetaiParallel.BudgetExpenseId,
                                                //    ContractId = FAAdjustmentDetaiParallel.ContractId,

                                                //};
                                                //response.Message =
                                                //    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                                //if (!string.IsNullOrEmpty(response.Message))
                                                //{
                                                //    response.Acknowledge = AcknowledgeType.Failure;
                                                //    return response;
                                                //}

                                                //#endregion


                                            }
                                        }
                                    }
                                }

                                scope.Complete();
                            }

                        }
                    }
                    #endregion
                    response.RefId = fAAdjustmentEntity.RefId;
                    return response;
                }
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
        /// <param name="fAAdjustmentEntity">The b a deposit entity.</param>
        /// <returns></returns>
        //public FAIncrementDecrementResponse UpdateFAIncrementDecrement(fAAdjustmentEntity fAAdjustmentEntity)
        //{
        //    var pUInvoiceResponse = new FAIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };

        //    if (fAAdjustmentEntity != null && !fAAdjustmentEntity.Validate())
        //    {
        //        foreach (var error in fAAdjustmentEntity.ValidationErrors)
        //            pUInvoiceResponse.Message += error + Environment.NewLine;
        //        pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
        //        return pUInvoiceResponse;
        //    }

        //    using (var scope = new TransactionScope())
        //    {
        //        if (fAAdjustmentEntity != null)
        //        {
        //            #region Master
        //            var pUInvoiceByRefNo = FAIncrementDecrementDao.GetFAIncrementDecrementByRefNo(fAAdjustmentEntity.RefNo);
        //            if (pUInvoiceByRefNo != null && !pUInvoiceByRefNo.RefId.Equals(fAAdjustmentEntity.RefId))
        //            {
        //                pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
        //                pUInvoiceResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", fAAdjustmentEntity.RefNo);
        //                return pUInvoiceResponse;
        //            }

        //            if (string.IsNullOrEmpty(fAAdjustmentEntity.RefId))
        //            {
        //                fAAdjustmentEntity.RefId = Guid.NewGuid().ToString();
        //                pUInvoiceResponse.Message = FAIncrementDecrementDao.InsertFAIncrementDecrement(fAAdjustmentEntity);
        //            }
        //            else
        //            {
        //                // Xóa detail
        //                pUInvoiceResponse.Message = FAIncrementDecrementDetailDao.DeleteFAIncrementDecrementDetailByRefId(fAAdjustmentEntity.RefId);
        //                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                    goto Error;

        //                AutoMapper(DeleteGeneralLedger(fAAdjustmentEntity.RefId), pUInvoiceResponse);
        //                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                    goto Error;

        //                AutoMapper(DeleteOriginalLedger(fAAdjustmentEntity.RefId), pUInvoiceResponse);
        //                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                    goto Error;

        //                AutoMapper(DeleteFixAssetLedger(fAAdjustmentEntity.RefId, fAAdjustmentEntity.RefType), pUInvoiceResponse);
        //                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                    goto Error;

        //                pUInvoiceResponse.Message = FAIncrementDecrementDao.UpdateFAIncrementDecrement(fAAdjustmentEntity);
        //            }

        //            if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                goto Error;
        //            #endregion

        //            #region Detail
        //            if (fAAdjustmentEntity.FAIncrementDecrementDetails != null && fAAdjustmentEntity.FAIncrementDecrementDetails.Count > 0)
        //            {
        //                foreach (item entity in fAAdjustmentEntity.FAIncrementDecrementDetails)
        //                {
        //                    entity.RefDetailId = Guid.NewGuid().ToString();
        //                    entity.RefId = fAAdjustmentEntity.RefId;
        //                    pUInvoiceResponse.Message = FAIncrementDecrementDetailDao.InsertFAIncrementDecrementDetail(entity);
        //                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                        goto Error;

        //                    #region General Ledger
        //                    AutoMapper(InsertGeneralLedger(entity, fAAdjustmentEntity), pUInvoiceResponse);
        //                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                        goto Error;
        //                    #endregion

        //                    #region Original Ledger
        //                    AutoMapper(InsertOriginalLedger(entity, fAAdjustmentEntity), pUInvoiceResponse);
        //                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                        goto Error;
        //                    #endregion

        //                    #region FixedAsset Ledger
        //                    AutoMapper(InsertFixAssetLedger(entity, fAAdjustmentEntity), pUInvoiceResponse);
        //                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //                        goto Error;
        //                    #endregion
        //                }
        //            }
        //            #endregion

        //            #region Error
        //            Error:
        //            if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
        //            {
        //                pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
        //                scope.Dispose();
        //                return pUInvoiceResponse;
        //            }
        //            pUInvoiceResponse.RefId = fAAdjustmentEntity.RefId;
        //            scope.Complete();
        //            #endregion
        //        }
        //        return pUInvoiceResponse;
        //    }
        //}

        public FAAdjustmentResponse DeleteFAAdjustment(string fAAdjustmentId)
        {
            var response = new FAAdjustmentResponse { Acknowledge = AcknowledgeType.Success };

            using (var scope = new TransactionScope())
            {
                #region Delete
                var fAAdjustmentEntity = FAAdjustmentDao.GetFAAdjustment_fordelete_byRefId(fAAdjustmentId);
                if (fAAdjustmentEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }

                response.Message = FAAdjustmentDao.DeleteFAAdjustment(fAAdjustmentEntity);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                response.Message = FAIncrementDecrementDetailDao.DeleteFAIncrementDecrementDetailByRefId(fAAdjustmentId);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(fAAdjustmentEntity.RefId, fAAdjustmentEntity.RefType);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                response.Message = GeneralLedgerDao.DeleteGeneralLedger(fAAdjustmentEntity.RefId);
                if (!string.IsNullOrEmpty(response.Message))
                    goto Error;

                response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(fAAdjustmentEntity.RefId);
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
                response.RefId = fAAdjustmentId;
                scope.Complete();
                #endregion
            }
            return response;
        }
    }
}
