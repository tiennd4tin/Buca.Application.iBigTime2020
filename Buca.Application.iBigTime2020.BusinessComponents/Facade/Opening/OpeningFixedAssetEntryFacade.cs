/***********************************************************************
 * <copyright file="OpeningFixedAssetEntryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, April 20, 2018
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
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Opening;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// class OpeningFixedAssetEntryFacade
    /// </summary>
    public class OpeningFixedAssetEntryFacade : FacadeBase
    {
        /// <summary>
        /// The opening account entry DAO
        /// </summary>
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao =
            DataAccess.DataAccess.OpeningAccountEntryDao;

        /// <summary>
        /// The opening fixed asset entry DAO
        /// </summary>
        private static readonly IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao =
            DataAccess.DataAccess.OpeningFixedAssetEntryDao;

        /// <summary>
        /// The fixed asset ledger DAO
        /// </summary>
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;

        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;

        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao =
            DataAccess.DataAccess.OriginalGeneralLedgerDao;

        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;

        /// <summary>
        /// Gets the opening fixed asset entries.
        /// </summary>
        /// <returns>List{OpeningFixedAssetEntryEntity}.</returns>
        public List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntries()
        {
            return OpeningFixedAssetEntryDao.GetOpeningAccountEntries();
        }

        /// <summary>
        /// Gets the opening fixed asset entries by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>List{OpeningFixedAssetEntryEntity}.</returns>
        public List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntriesByAccountNumber(string accountNumber)
        {
            return OpeningFixedAssetEntryDao.GetOpeningFixedAssetEntryEntityByAccountCode(accountNumber);
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryDetails">The opening account entry details.</param>
        /// <returns>OpeningAccountEntryReponse.</returns>
        public OpeningFixedAssetResponse UpdateOpeningFixedAssetEntry(
            IList<OpeningFixedAssetEntryEntity> openingFixedAssetEntryDetails)
        {
            var openingFixedAssetEntryResponse = new OpeningFixedAssetResponse {Acknowledge = AcknowledgeType.Success};

            using (var scope = new TransactionScope())
            {
                if (openingFixedAssetEntryDetails != null)
                {
                   
                    //openingFixedAssetEntryResponse.Message = OpeningFixedAssetEntryDao.de(openingFixedAssetEntryDetails.First().RefId);
                    var fixedAssetEntity =
                        FixedAssetDao.GetFixedAssetById(openingFixedAssetEntryDetails.First().FixedAssetId);

                    //.Delete OpeningFixedEntry by FixedAssetId
                    AutoMapper(DeleteOpeningFixedAssetEntry(openingFixedAssetEntryDetails.First().FixedAssetId),
                        openingFixedAssetEntryResponse);
                    string account = "";
                    decimal orgAmount = 0;
                    decimal orgAmountOC = 0;
                    decimal depreciationAmount = 0;
                    decimal depreciationAmountOC = 0;
                    decimal devaluationAmount = 0;
                    var generalLedgerEntity = new List<FixedAssetLedgerEntity>();
                    //Xóa số dư đầu kỳ tài sản cố định trong bảng General Ledger

                    GeneralLedgerDao.DeleteGeneralLedger(openingFixedAssetEntryDetails.First().FixedAssetId);

                    //AnhNT: Xóa theo cách mới (phù hợp với kiểu lưu mới)
                    AutoMapper(
                        DeleteOriginalLedgerByReftypeRefNo(openingFixedAssetEntryDetails.First().RefType.ToString(),
                            openingFixedAssetEntryDetails.First().FixedAssetCode), openingFixedAssetEntryResponse);
                    //AnhNT: Xóa theo cách cũ (dành cho DB của khách hàng đang hoạt động)
                    AutoMapper(DeleteOriginalLedger(openingFixedAssetEntryDetails.First().FixedAssetId),
                        openingFixedAssetEntryResponse);

                    foreach (var openingFixedAssetEntry in openingFixedAssetEntryDetails)
                    {                        

                        if (string.IsNullOrEmpty(openingFixedAssetEntry.RefId))
                            openingFixedAssetEntry.RefId = Guid.NewGuid().ToString();
                        else
                        {
                            //openingFixedAssetEntry.RefId = Guid.NewGuid().ToString();
                            var fixedAssetLedger =
                                FixedAssetLedgerDao.GetFixedAssetLedgerByFixedAssetId(openingFixedAssetEntry.FixedAssetId,
                                    openingFixedAssetEntry.RefType);

                            if (fixedAssetLedger != null)
                                AutoMapper(DeleteFixAssetLedger(fixedAssetLedger.RefId, openingFixedAssetEntry.RefType),
                                    openingFixedAssetEntryResponse);

                            //AutoMapper(DeleteGeneralLedger(openingFixedAssetEntry.RefId), openingFixedAssetEntryResponse);
                            //AutoMapper(DeleteOriginalLedger(openingFixedAssetEntry.RefId), openingFixedAssetEntryResponse);
                            //AutoMapper(DeleteOriginalLedger(openingFixedAssetEntry.RefId), openingFixedAssetEntryResponse);
                            //if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            //    goto Error;

                            AutoMapper(DeleteFixAssetLedger(openingFixedAssetEntry.RefId, openingFixedAssetEntry.RefType),
                                openingFixedAssetEntryResponse);
                            if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                                goto Error;


                            if (!openingFixedAssetEntry.Validate())
                            {
                                foreach (string error in openingFixedAssetEntry.ValidationErrors)
                                    openingFixedAssetEntryResponse.Message += error + Environment.NewLine;

                                openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingFixedAssetEntryResponse;

                            }

                            openingFixedAssetEntryResponse.Message =
                                OpeningFixedAssetEntryDao.InsertOpeningFixedAssetEntry(openingFixedAssetEntry);
                            if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            {
                                openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingFixedAssetEntryResponse;
                            }

                            #region Insert FixAsset Ledger

                            if (openingFixedAssetEntry.OrgPriceAccount != null)
                            {
                                if (account != openingFixedAssetEntry.FixedAssetId)
                                {
                                    orgAmount = openingFixedAssetEntryDetails.Sum(c => c.OrgPriceDebitAmount);
                                    depreciationAmount = openingFixedAssetEntryDetails.Sum(c => c.DepreciationCreditAmount);
                                    devaluationAmount = openingFixedAssetEntryDetails.Sum(c => c.DevaluationCreditAmount);
                                    var creditAccount = openingFixedAssetEntryDetails
                                        .Where(c => c.DepreciationAccount != null).ToList();
                                    var orgAccount = openingFixedAssetEntryDetails.First().OrgPriceAccount;
                                    var depreciationAccount = creditAccount.First().DepreciationAccount;

                                    var voucher = new FixedAssetLedgerEntity
                                    {
                                        FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                        RefId = openingFixedAssetEntry.FixedAssetId,
                                        RefType = openingFixedAssetEntry.RefType,
                                        RefNo = "OPN",
                                        RefDate = openingFixedAssetEntry.PostedDate,
                                        PostedDate = openingFixedAssetEntry.PostedDate,
                                        FixedAssetId = openingFixedAssetEntry.FixedAssetId,
                                        DepartmentId = openingFixedAssetEntry.DepartmentId,
                                        LifeTime = fixedAssetEntity.LifeTime,
                                        AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                        AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                        OrgPriceAccount = orgAccount,
                                        OrgPriceDebitAmount = orgAmount,
                                        OrgPriceCreditAmount = 0,
                                        DepreciationAccount = depreciationAccount,
                                        DepreciationDebitAmount = 0,
                                        DepreciationCreditAmount = depreciationAmount, //openingFixedAssetEntry.DepreciationCreditAmount, //depreciationAmount,
                                        CapitalAccount = null,
                                        CapitalDebitAmount = 0,
                                        CapitalCreditAmount = 0,
                                        JournalMemo = @"Dư đầu kỳ tài sản " + fixedAssetEntity.FixedAssetCode,
                                        Description = @"Dư đầu kỳ tài sản " + fixedAssetEntity.FixedAssetCode,
                                        RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                        EndYear = fixedAssetEntity.EndYear,
                                        DevaluationDebitAmount = 0,
                                        DevaluationCreditAmount = devaluationAmount, //openingFixedAssetEntry.DevaluationCreditAmount,
                                        DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                        DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                        EndDevaluationDate =
                                            fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01)
                                                ? fixedAssetEntity.DevaluationDate.AddMonths(
                                                    (int)fixedAssetEntity.DevaluationLifeTime)
                                                : fixedAssetEntity.EndDevaluationDate,
                                        PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                        Quantity = fixedAssetEntity.Quantity,
                                    };
                                    account = openingFixedAssetEntry.FixedAssetId;
                                    generalLedgerEntity.Add(voucher);
                                }
                            }

                            #region Insert OriginalLedger

                            if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                                goto Error;
                            AutoMapper(InsertOriginalLedger(openingFixedAssetEntry), openingFixedAssetEntryResponse);
                            if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            {
                                openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingFixedAssetEntryResponse;
                            }

                            #endregion
                        }

                        #endregion

                        #region Insert General Ledger

                        AutoMapper(InsertGeneralLedger(openingFixedAssetEntry), openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        {
                            openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingFixedAssetEntryResponse;
                        }

                        #endregion
                        
                        
                    }

                    #region Insert FixAsset Ledger

                    foreach (var item in generalLedgerEntity)
                    {
                        var voucher = new FixedAssetLedgerEntity
                        {
                            FixedAssetLedgerId = item.FixedAssetLedgerId,
                            RefId = item.RefId,
                            RefType = item.RefType,
                            RefNo = item.RefNo,
                            RefDate = item.PostedDate,
                            PostedDate = item.PostedDate,
                            FixedAssetId = item.FixedAssetId,
                            DepartmentId = item.DepartmentId,
                            LifeTime = item.LifeTime,
                            AnnualDepreciationRate = item.AnnualDepreciationRate,
                            AnnualDepreciationAmount = item.AnnualDepreciationAmount,
                            OrgPriceAccount = item.OrgPriceAccount,
                            OrgPriceDebitAmount = item.OrgPriceDebitAmount,
                            OrgPriceCreditAmount = item.OrgPriceCreditAmount,
                            DepreciationAccount = item.DepreciationAccount,
                            DepreciationDebitAmount = item.DepreciationDebitAmount,
                            DepreciationCreditAmount = item.DepreciationCreditAmount,
                            CapitalAccount = item.CapitalAccount,
                            CapitalDebitAmount = item.CapitalDebitAmount,
                            CapitalCreditAmount = item.CapitalCreditAmount,
                            JournalMemo = item.JournalMemo,
                            Description = item.Description,
                            RemainingLifeTime = item.RemainingLifeTime,
                            EndYear = item.EndYear,
                            DevaluationDebitAmount = item.DevaluationDebitAmount,
                            DevaluationCreditAmount = item.DevaluationCreditAmount,
                            DevaluationAmount = item.DevaluationAmount,
                            DevaluationPeriod = item.DevaluationPeriod,
                            EndDevaluationDate = item.EndDevaluationDate,
                            PeriodDevaluationAmount = item.PeriodDevaluationAmount,
                            Quantity = item.Quantity
                        };

                        openingFixedAssetEntryResponse.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(voucher);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        {
                            openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingFixedAssetEntryResponse;
                        }
                    }

                #endregion

                Error:
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.RefId = openingFixedAssetEntryDetails.First().RefId;
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingFixedAssetEntryResponse;
                    }
                    openingFixedAssetEntryResponse.RefId = openingFixedAssetEntryDetails.First().RefId;
                }
                scope.Complete();
            }
            return openingFixedAssetEntryResponse;
        }

        public OpeningFixedAssetResponse UpdateOpeningFixedAssetEntry(
            OpeningFixedAssetEntryEntity openingFixedAssetEntity)
        {
            var openingFixedAssetEntryResponse = new OpeningFixedAssetResponse {Acknowledge = AcknowledgeType.Success};
            using (var scope = new TransactionScope())
            {
                if (openingFixedAssetEntity != null)
                {
                    //.Delete OpeningFixedEntry by FixedAssetId
                    AutoMapper(DeleteOpeningFixedAssetEntry(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    //AutoMapper(DeleteFixAssetLedger(openingFixedAssetEntity.RefId, openingFixedAssetEntity.RefType), openingFixedAssetEntryResponse);
                    //AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);

                    #region Insert Entity

                    if (string.IsNullOrEmpty(openingFixedAssetEntity.RefId))
                        openingFixedAssetEntity.RefId = Guid.NewGuid().ToString();
                    else
                    {
                        AutoMapper(DeleteGeneralLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;

                        AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;

                        AutoMapper(DeleteFixAssetLedger(openingFixedAssetEntity.RefId, openingFixedAssetEntity.RefType),
                            openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;
                    }

                    if (!openingFixedAssetEntity.Validate())
                    {
                        foreach (string error in openingFixedAssetEntity.ValidationErrors)
                            openingFixedAssetEntryResponse.Message += error + Environment.NewLine;
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingFixedAssetEntryResponse;
                    }

                    openingFixedAssetEntryResponse.Message =
                        OpeningFixedAssetEntryDao.InsertOpeningFixedAssetEntry(openingFixedAssetEntity);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingFixedAssetEntryResponse;
                    }
                    openingFixedAssetEntryResponse.RefId = openingFixedAssetEntity.RefId;

                    #endregion

                    #region Insert OriginalLedger

                    //AnhNT: Xóa theo cách mới (phù hợp với kiểu lưu mới)
                    AutoMapper(
                        DeleteOriginalLedgerByReftypeRefNo(openingFixedAssetEntity.RefType.ToString(),
                            openingFixedAssetEntity.FixedAssetCode), openingFixedAssetEntryResponse);
                    //AnhNT: Xóa theo cách cũ (dành cho DB của khách hàng đang hoạt động)
                    AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;
                    AutoMapper(InsertOriginalLedger(openingFixedAssetEntity), openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingFixedAssetEntryResponse;
                    }

                    #endregion

                    #region Insert General Ledger

                    AutoMapper(DeleteGeneralLedger(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;
                    AutoMapper(InsertGeneralLedger(openingFixedAssetEntity), openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingFixedAssetEntryResponse;
                    }

                    #endregion

                    #region Insert FixAsset Ledger

                    AutoMapper(
                        DeleteFixAssetLedger603(openingFixedAssetEntity.FixedAssetId, openingFixedAssetEntity.RefType),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;
                    AutoMapper(InsertFixAssetLedger(openingFixedAssetEntity), openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingFixedAssetEntryResponse;
                    }

                    #endregion

                    #region Error

                    Error:
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.RefId = openingFixedAssetEntity.RefId;
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingFixedAssetEntryResponse;
                    }
                    scope.Complete();

                    #endregion
                }
            }
            return openingFixedAssetEntryResponse;
        }


        public OpeningFixedAssetResponse DeleteOpeningFixedAssetEntry(
            OpeningFixedAssetEntryEntity openingFixedAssetEntity)
        {
            var openingFixedAssetEntryResponse = new OpeningFixedAssetResponse {Acknowledge = AcknowledgeType.Success};
            using (var scope = new TransactionScope())
            {
                if (openingFixedAssetEntity != null)
                {
                    //.Delete OpeningFixedEntry by FixedAssetId
                    AutoMapper(DeleteOpeningFixedAssetEntry(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    //AutoMapper(DeleteFixAssetLedger(openingFixedAssetEntity.RefId, openingFixedAssetEntity.RefType), openingFixedAssetEntryResponse);
                    //AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);

                    #region Delete Entity
                    
                        AutoMapper(DeleteGeneralLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;

                        AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.RefId), openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;

                        AutoMapper(DeleteFixAssetLedger(openingFixedAssetEntity.RefId, openingFixedAssetEntity.RefType),
                            openingFixedAssetEntryResponse);
                        if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                            goto Error;

                    #endregion

                    #region Delete OriginalLedger

                    //AnhNT: Xóa theo cách mới (phù hợp với kiểu lưu mới)
                    AutoMapper(
                        DeleteOriginalLedgerByReftypeRefNo(openingFixedAssetEntity.RefType.ToString(),
                            openingFixedAssetEntity.FixedAssetCode), openingFixedAssetEntryResponse);
                    //AnhNT: Xóa theo cách cũ (dành cho DB của khách hàng đang hoạt động)
                    AutoMapper(DeleteOriginalLedger(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;

                    #endregion

                    #region Delete General Ledger

                    AutoMapper(DeleteGeneralLedger(openingFixedAssetEntity.FixedAssetId),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;

                    #endregion

                    #region Delete FixAsset Ledger

                    AutoMapper(
                        DeleteFixAssetLedger603(openingFixedAssetEntity.FixedAssetId, openingFixedAssetEntity.RefType),
                        openingFixedAssetEntryResponse);
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                        goto Error;

                    #endregion

                    #region Error

                    Error:
                    if (!string.IsNullOrEmpty(openingFixedAssetEntryResponse.Message))
                    {
                        openingFixedAssetEntryResponse.RefId = openingFixedAssetEntity.RefId;
                        openingFixedAssetEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingFixedAssetEntryResponse;
                    }
                    scope.Complete();

                    #endregion
                }
            }

            return openingFixedAssetEntryResponse;
        }
    }
}
