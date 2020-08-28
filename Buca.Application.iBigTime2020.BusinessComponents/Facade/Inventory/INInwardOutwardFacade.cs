/***********************************************************************
 * <copyright file="InventoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 17 April 2014
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
using Buca.Application.iBigTime2020.BusinessComponents.Message.InventoryItem;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;

using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB;
using DevExpress.CodeParser;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Inventory
{
    /// <summary>
    /// InventoryFacade
    /// </summary>
    public class INInwardOutwardFacade
    {
        #region Data Transfer Object
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;
        private static readonly IINInwardOutwardDao INInwardOutwardDao = DataAccess.DataAccess.INInwardOutwardDao;

        private static readonly IINInwardOutwardDetailDao INInwardOutwardDetailDao =
            DataAccess.DataAccess.INInwardOutwardDetailDao;

        private static readonly IInventoryLedgerDao InventoryLedgerDao =
            DataAccess.DataAccess.InventoryLedgerDao;

        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;

        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IINInwardOutwardDetailParallelDao INInwardOutwardDetailParallelDao = DataAccess.DataAccess.IINInwardOutwardDetailParallelDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        #endregion

        /// <summary>
        /// Gets the in inward outwards.
        /// </summary>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        public List<INInwardOutwardEntity> GetINInwardOutwards()
        {
            return INInwardOutwardDao.GetINInwardOutwards();
        }

        /// <summary>
        /// Gets the in inward outward by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>INInwardOutwardEntity.</returns>
        public INInwardOutwardEntity GetINInwardOutwardByRefNo(string refNo)
        {
            return INInwardOutwardDao.GetINInwardOutwardByRefNo(refNo);
        }

        /// <summary>
        /// Gets the in inward outward by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        public List<INInwardOutwardEntity> GetINInwardOutwardByRefTypeId(int refTypeId)
        {
            return INInwardOutwardDao.GetINInwardOutwardByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the in inward outward by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedINInwardOutwardDetail">if set to <c>true</c> [is included in inward outward detail].</param>
        /// <returns>INInwardOutwardEntity.</returns>
        public INInwardOutwardEntity GetINInwardOutwardByRefId(string refId, bool isIncludedINInwardOutwardDetail, bool isIncludedINInwardOutwardDetailParallel)
        {
            var inwardOutward = INInwardOutwardDao.GetINInwardOutward(refId);
            if (isIncludedINInwardOutwardDetail && inwardOutward != null)
            {
                inwardOutward.InwardOutwardDetails =
                    INInwardOutwardDetailDao.GetINInwardOutwardDetailsByRefId(inwardOutward.RefId);
            }
            if (isIncludedINInwardOutwardDetailParallel && inwardOutward != null)
            {
                inwardOutward.INInwardOutwardDetailParallels = INInwardOutwardDetailParallelDao.GetINInwardOutwardDetailParallelbyRefId(inwardOutward.RefId);
            }
            return inwardOutward;
        }

        /// <summary>
        /// Inserts the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutwardEntity">The inwardOutward entity.</param>
        /// <returns>INInwardOutwardResponse.</returns>
        public INInwardOutwardResponse InsertINInwardOutward(INInwardOutwardEntity inwardOutwardEntity, bool isconvertDB)
        {
            var inwardOutwardResponse = new INInwardOutwardResponse { Acknowledge = AcknowledgeType.Success };

            if (inwardOutwardEntity != null && !inwardOutwardEntity.Validate())
            {
                foreach (var error in inwardOutwardEntity.ValidationErrors)
                    inwardOutwardResponse.Message += error + Environment.NewLine;
                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                return inwardOutwardResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (inwardOutwardEntity != null)
                {
                    inwardOutwardEntity.RefId = Guid.NewGuid().ToString();
                    //inwardOutwardEntity.RefType = (int)BuCA.Enum.RefType.INOutward;
                    var inwardOutwardExits = INInwardOutwardDao.GetINInwardOutwardByRefNo(inwardOutwardEntity.RefNo.Trim(), inwardOutwardEntity.PostedDate);
                    if (!isconvertDB)//AnhNT: Nếu chuyển đổi DB thì ko check (theo nghiệp vụ)
                        if (inwardOutwardExits != null && inwardOutwardExits.RefType == inwardOutwardEntity.RefType && inwardOutwardExits.PostedDate.Year == inwardOutwardEntity.PostedDate.Year)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            inwardOutwardResponse.Message = @"Số chứng từ '" + inwardOutwardEntity.RefNo.Trim() + @"' đã tồn tại!";
                            return inwardOutwardResponse;
                        }
                    inwardOutwardResponse.Message = INInwardOutwardDao.InsertINInwardOutward(inwardOutwardEntity);
                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        return inwardOutwardResponse;
                    }

                    foreach (var inwardOutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                    {
                        inwardOutwardDetail.RefId = inwardOutwardEntity.RefId;
                        inwardOutwardDetail.RefDetailId = Guid.NewGuid().ToString();


                        if (!inwardOutwardDetail.Validate())
                        {
                            foreach (var error in inwardOutwardDetail.ValidationErrors)
                                inwardOutwardResponse.Message += error + Environment.NewLine;
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        // Kiểm tra số lượng tồn trong kho
                        if (!isconvertDB)//AnhNT: Nếu thực hiện chuyển đổi dữ liệu từ msa sang thì mới check số lượng tồn
                        {
                            var inventoryModel = InventoryItemDao.GetUnitsInStock(inwardOutwardDetail.InventoryItemId,
                                inwardOutwardDetail.StockId, inwardOutwardEntity.PostedDate);
                            if (inwardOutwardDetail.Quantity > inventoryModel.UnitsInStock &&
                                inwardOutwardEntity.RefType == 202)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                inwardOutwardResponse.Message = string.Format(
                                    @"{0} không đủ số lượng tồn, vui lòng kiểm tra lại." + Environment.NewLine +
                                    "Số lượng còn lại: {1}", inwardOutwardDetail.Description,
                                    string.Format("{0:#,0.####}", inventoryModel.UnitsInStock));
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }
                        }

                        inwardOutwardResponse.Message = INInwardOutwardDetailDao.InsertINInwardOutwardDetail(inwardOutwardDetail);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #region Insert to AccountBalance

                        InsertAccountBalance(inwardOutwardEntity, inwardOutwardDetail);

                        #endregion

                        #region Insert InventoryLedger

                        var inventoryLedgerEntity = new InventoryLedgerEntity
                        {
                            InventoryLedgerId = Guid.NewGuid().ToString(),

                            RefId = inwardOutwardEntity.RefId,
                            RefType = inwardOutwardEntity.RefType,
                            RefNo = inwardOutwardEntity.RefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            StockId = inwardOutwardDetail.StockId,
                            InventoryItemId = inwardOutwardDetail.InventoryItemId,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            Description = inwardOutwardDetail.Description,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            Unit = inwardOutwardDetail.Unit,
                            UnitPrice = inwardOutwardDetail.UnitPrice,
                            InwardQuantity = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Quantity : 0,
                            OutwardQuantity = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Quantity : 0,
                            InwardAmount = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Amount : 0,
                            OutwardAmountOC = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Amount : 0,
                            InwardAmountOC = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.AmountOC : 0,
                            OutwardAmount = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.AmountOC : 0,
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ExpiryDate = inwardOutwardDetail.ExpiryDate,
                            LotNo = inwardOutwardDetail.LotNo,
                            RefOrder = inwardOutwardEntity.RefOrder,
                            SortOrder = inwardOutwardDetail.SortOrder,
                            AccountNumber = inwardOutwardDetail.DebitAccount,
                            CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                            InwardAmountBalance = 0,
                            InwardAmountBalanceAfter = 0,
                            InwardQuantityBalance = 0,
                            UnitPriceBalance = 0,
                            ConfrontingRefId = inwardOutwardDetail.ConfrontingRefId,
                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                        };
                        inwardOutwardResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        //  inventoryLedgerEntity.DebitAmountOC = 0;
                        //generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.AmountOC;

                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }
                        #endregion

                        #region Insert GeneralLedger
                        var generalLedgerEntity = new GeneralLedgerEntity
                        {
                            RefType = inwardOutwardEntity.RefType,
                            RefNo = inwardOutwardEntity.RefNo,
                            AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                            //BankId = inwardOutwardEntity.BankId,
                            BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                            ProjectId = inwardOutwardDetail.ProjectId,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            Description = inwardOutwardDetail.Description,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            ExchangeRate = 1,
                            ActivityId = inwardOutwardDetail.ActivityId,
                            BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                            BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                            RefId = inwardOutwardEntity.RefId,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                            OrgRefNo = inwardOutwardDetail.OrgRefNo,
                            OrgRefDate = inwardOutwardDetail.OrgRefDate,
                            BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                            ListItemId = inwardOutwardDetail.ListItemId,
                            BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                            BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                            CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,

                            AccountNumber = inwardOutwardDetail.DebitAccount,

                            //  AccountNumber = "10",
                            CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                            DebitAmount = inwardOutwardDetail.Amount,
                            DebitAmountOC = inwardOutwardDetail.Amount,
                            CreditAmount = 0,
                            CreditAmountOC = 0,
                            FundStructureId = inwardOutwardDetail.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            RefDate = inwardOutwardEntity.RefDate,
                            BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                            ContractId = inwardOutwardDetail.ContractId,
                            CapitalPlanId = inwardOutwardDetail.CapitalPlanId
                        };
                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        //insert lan 2                        
                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                        generalLedgerEntity.AccountNumber = inwardOutwardDetail.CreditAccount;
                        generalLedgerEntity.CorrespondingAccountNumber = inwardOutwardDetail.DebitAccount;
                        generalLedgerEntity.DebitAmount = 0;
                        generalLedgerEntity.DebitAmountOC = 0;
                        generalLedgerEntity.CreditAmount = inwardOutwardDetail.Amount;
                        generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.Amount;
                        //generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.AmountOC;
                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = inwardOutwardEntity.RefType,
                            RefId = inwardOutwardEntity.RefId,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            OrgRefDate = inwardOutwardDetail.OrgRefDate,
                            OrgRefNo = inwardOutwardDetail.OrgRefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            RefNo = inwardOutwardEntity.RefNo,
                            AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                            ActivityId = inwardOutwardDetail.ActivityId,
                            Amount = inwardOutwardDetail.Amount,
                            Approved = inwardOutwardDetail.Approved,
                            BankId = inwardOutwardDetail.BankId,
                            BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                            BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                            BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                            BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                            CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,
                            CreditAccount = inwardOutwardDetail.CreditAccount,
                            DebitAccount = inwardOutwardDetail.DebitAccount,
                            Description = inwardOutwardDetail.Description,
                            FundStructureId = inwardOutwardDetail.FundStructureId,
                            TaxAmount = inwardOutwardDetail.TaxAmount,
                            ProjectActivityId = inwardOutwardDetail.ProjectActivityId,
                            MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ProjectId = inwardOutwardDetail.ProjectId,
                            ToBankId = inwardOutwardDetail.BankId,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                            ContractId = inwardOutwardDetail.ContractId,
                            // Không có Currency trong db : mặc định VNĐ và 1
                            CurrencyCode = "VND",
                            ExchangeRate = 1,
                        };
                        inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #endregion
                    }

                    inwardOutwardResponse.RefId = inwardOutwardEntity.RefId;
                }

                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                scope.Complete();
            }
            return

            inwardOutwardResponse;

        }
        /// <summary>
        /// Inserts the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutwardEntity">The inwardOutward entity.</param>
        ///  <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        ///   <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        ///  
        /// <returns>INInwardOutwardResponse.</returns>
        public INInwardOutwardResponse InsertINInwardOutward(INInwardOutwardEntity inwardOutwardEntity, bool isconvertDB, bool isAutoGenerateParallel = false, bool IsOutwardNegativeStock=false)
        {
            var inwardOutwardResponse = new INInwardOutwardResponse { Acknowledge = AcknowledgeType.Success };

            if (inwardOutwardEntity != null && !inwardOutwardEntity.Validate())
            {
                foreach (var error in inwardOutwardEntity.ValidationErrors)
                    inwardOutwardResponse.Message += error + Environment.NewLine;
                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                return inwardOutwardResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (inwardOutwardEntity != null)
                {
                    inwardOutwardEntity.RefId = Guid.NewGuid().ToString();
                    //inwardOutwardEntity.RefType = (int)BuCA.Enum.RefType.INOutward;
                    var inwardOutwardExits = INInwardOutwardDao.GetINInwardOutwardByRefNo(inwardOutwardEntity.RefNo.Trim(), inwardOutwardEntity.PostedDate);
                    if (!isconvertDB)//AnhNT: Nếu chuyển đổi DB thì ko check (theo nghiệp vụ)
                        if (inwardOutwardExits != null && inwardOutwardExits.RefType == inwardOutwardEntity.RefType && inwardOutwardExits.PostedDate.Year == inwardOutwardEntity.PostedDate.Year)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            inwardOutwardResponse.Message = @"Số chứng từ '" + inwardOutwardEntity.RefNo.Trim() + @"' đã tồn tại!";
                            return inwardOutwardResponse;
                        }
                    inwardOutwardResponse.Message = INInwardOutwardDao.InsertINInwardOutward(inwardOutwardEntity);

                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        return inwardOutwardResponse;
                    }

                    foreach (var inwardOutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                    {
                        inwardOutwardDetail.RefId = inwardOutwardEntity.RefId;
                        inwardOutwardDetail.RefDetailId = Guid.NewGuid().ToString();


                        if (!inwardOutwardDetail.Validate())
                        {
                            foreach (var error in inwardOutwardDetail.ValidationErrors)
                                inwardOutwardResponse.Message += error + Environment.NewLine;
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        // Kiểm tra số lượng tồn trong kho
                        if (!isconvertDB && !IsOutwardNegativeStock)//AnhNT: Nếu thực hiện chuyển đổi dữ liệu từ msa sang thì mới check số lượng tồn
                        {
                            var inventoryModel = InventoryItemDao.GetUnitsInStock(inwardOutwardDetail.InventoryItemId,
                                inwardOutwardDetail.StockId, inwardOutwardEntity.PostedDate);
                            if (inwardOutwardDetail.Quantity > inventoryModel.UnitsInStock &&
                                inwardOutwardEntity.RefType == 202)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                inwardOutwardResponse.Message = string.Format(
                                    @"{0} không đủ số lượng tồn, vui lòng kiểm tra lại." + Environment.NewLine +
                                    "Số lượng còn lại: {1}", inwardOutwardDetail.Description,
                                    string.Format("{0:#,0.####}", inventoryModel.UnitsInStock));
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }
                        }

                        inwardOutwardResponse.Message = INInwardOutwardDetailDao.InsertINInwardOutwardDetail(inwardOutwardDetail);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #region Insert to AccountBalance

                        InsertAccountBalance(inwardOutwardEntity, inwardOutwardDetail);

                        #endregion

                        #region Insert InventoryLedger

                        var inventoryLedgerEntity = new InventoryLedgerEntity
                        {
                            InventoryLedgerId = Guid.NewGuid().ToString(),

                            RefId = inwardOutwardEntity.RefId,
                            RefType = inwardOutwardEntity.RefType,
                            RefNo = inwardOutwardEntity.RefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            StockId = inwardOutwardDetail.StockId,
                            InventoryItemId = inwardOutwardDetail.InventoryItemId,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            Description = inwardOutwardDetail.Description,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            Unit = inwardOutwardDetail.Unit,
                            UnitPrice = inwardOutwardDetail.UnitPrice,
                            //InwardQuantity = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Quantity : 0,
                            OutwardQuantity = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Quantity : 0,
                            OutwardAmount = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.AmountOC : 0,
                            //InwardAmount = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Amount : 0,
                            OutwardAmountOC = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Amount : 0,
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ExpiryDate = inwardOutwardDetail.ExpiryDate,
                            LotNo = inwardOutwardDetail.LotNo,
                            RefOrder = inwardOutwardEntity.RefOrder,
                            SortOrder = inwardOutwardDetail.SortOrder,
                            AccountNumber = inwardOutwardDetail.DebitAccount,
                            CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                            InwardAmountBalance = 0,
                            InwardAmountBalanceAfter = 0,
                            InwardQuantityBalance = 0,
                            UnitPriceBalance = 0,
                            ConfrontingRefId = inwardOutwardDetail.ConfrontingRefId,

                        };
                        inwardOutwardResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }
                        #endregion

                        #region Insert GeneralLedger
                        if (inwardOutwardDetail.DebitAccount != null && inwardOutwardDetail.CreditAccount != null)
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = inwardOutwardEntity.RefType,
                                RefNo = inwardOutwardEntity.RefNo,
                                AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                                BankId = inwardOutwardDetail.BankId,
                                BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                                ProjectId = inwardOutwardDetail.ProjectId,
                                BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                Description = inwardOutwardDetail.Description,
                                RefDetailId = inwardOutwardDetail.RefDetailId,
                                ActivityId = inwardOutwardDetail.ActivityId,
                                BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                                CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                                RefId = inwardOutwardDetail.RefId,
                                PostedDate = inwardOutwardEntity.PostedDate,
                                MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                                OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                                ListItemId = inwardOutwardDetail.ListItemId,
                                BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                                // CashWithDrawTypeId = inwardOutwardDetail.CashWithdrawTypeId, //AnhNT disable theo yêu cầu của BA
                                AccountNumber = inwardOutwardDetail.DebitAccount,
                                CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                                DebitAmount = inwardOutwardDetail.Amount,
                                DebitAmountOC = 0,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = inwardOutwardDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                RefDate = inwardOutwardEntity.RefDate,
                                SortOrder = inwardOutwardDetail.SortOrder,
                                BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                ContractId = inwardOutwardDetail.ContractId,
                                CapitalPlanId = inwardOutwardDetail.CapitalPlanId

                            };
                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = inwardOutwardDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = inwardOutwardDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = inwardOutwardDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.Amount;
                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }
                        }
                        else //ghi don
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = inwardOutwardEntity.RefType,
                                RefNo = inwardOutwardEntity.RefNo,
                                AccountingObjectId = inwardOutwardEntity.AccountingObjectId,
                                BankId = inwardOutwardDetail.BankId,
                                BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                                ProjectId = inwardOutwardDetail.ProjectId,
                                BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                Description = inwardOutwardDetail.Description,
                                RefDetailId = inwardOutwardDetail.RefDetailId,
                                // ExchangeRate = inwardOutwardDetail.ExchangeRate,
                                ActivityId = inwardOutwardDetail.ActivityId,
                                BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                                CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                                RefId = inwardOutwardEntity.RefId,
                                PostedDate = inwardOutwardEntity.PostedDate,
                                MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                                OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                                ListItemId = inwardOutwardDetail.ListItemId,
                                BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                                //CashWithDrawTypeId = inwardOutwardDetail.CashWithdrawTypeId, //AnhNT disable theo yêu cầu của BA
                                AccountNumber = inwardOutwardDetail.DebitAccount ?? inwardOutwardDetail.CreditAccount,
                                DebitAmount = inwardOutwardDetail.DebitAccount == null ? 0 : inwardOutwardDetail.Amount,
                                DebitAmountOC = inwardOutwardDetail.Amount,
                                CreditAmount = inwardOutwardDetail.CreditAccount == null ? 0 : inwardOutwardDetail.Amount,
                                CreditAmountOC = inwardOutwardDetail.Amount,
                                FundStructureId = inwardOutwardDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                RefDate = inwardOutwardEntity.RefDate,
                                SortOrder = inwardOutwardDetail.SortOrder,
                                BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                ContractId = inwardOutwardDetail.ContractId,
                                CapitalPlanId = inwardOutwardDetail.CapitalPlanId
                            };
                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }
                        }
                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = inwardOutwardEntity.RefType,
                            RefId = inwardOutwardEntity.RefId,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            OrgRefDate = inwardOutwardDetail.OrgRefDate,
                            OrgRefNo = inwardOutwardDetail.OrgRefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            RefNo = inwardOutwardEntity.RefNo,
                            AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                            ActivityId = inwardOutwardDetail.ActivityId,
                            Amount = inwardOutwardDetail.Amount,
                            Approved = inwardOutwardDetail.Approved,
                            BankId = inwardOutwardDetail.BankId,
                            BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                            BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                            BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                            BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                            CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,
                            CreditAccount = inwardOutwardDetail.CreditAccount,
                            DebitAccount = inwardOutwardDetail.DebitAccount,
                            Description = inwardOutwardDetail.Description,
                            FundStructureId = inwardOutwardDetail.FundStructureId,
                            TaxAmount = inwardOutwardDetail.TaxAmount,
                            ProjectActivityId = inwardOutwardDetail.ProjectActivityId,
                            MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ProjectId = inwardOutwardDetail.ProjectId,
                            ToBankId = inwardOutwardDetail.BankId,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                            ContractId = inwardOutwardDetail.ContractId,
                            // Không có Currency trong db : mặc định VNĐ và 1
                            CurrencyCode = "VND",
                            ExchangeRate = 1,
                        };
                        inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #endregion
                    }
                    #region Sinh dinh khoan dong thoi
                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region INInwardInOutwardDetailParallel
                        if (inwardOutwardEntity.INInwardOutwardDetailParallels != null)
                        {
                            foreach (var inInwardOutwardDetailParallel in inwardOutwardEntity.INInwardOutwardDetailParallels)
                            {
                                #region Insert In Inward Outward detail parallel
                                inInwardOutwardDetailParallel.RefId = inwardOutwardEntity.RefId;
                                inInwardOutwardDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                inInwardOutwardDetailParallel.UnitPrice = 0;
                                inInwardOutwardDetailParallel.Quantity = 0;
                                if (!inInwardOutwardDetailParallel.Validate())
                                {
                                    foreach (var error in inInwardOutwardDetailParallel.ValidationErrors)
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }
                                INInwardOutwardDetailParallelDao.InsertINInwardOutwardDetailParallel(inInwardOutwardDetailParallel);
                                if (!String.IsNullOrEmpty(inwardOutwardResponse.Message))
                                {
                                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }
                                #endregion

                                #region Insert GeneralLedger
                                if (inInwardOutwardDetailParallel.DebitAccount != null && inInwardOutwardDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = inwardOutwardEntity.RefType,
                                        RefNo = inwardOutwardEntity.RefNo,
                                        AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                        BankId = inInwardOutwardDetailParallel.BankId,
                                        BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                        ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                        BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                        Description = inInwardOutwardDetailParallel.Description,
                                        RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                        ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                        BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                        RefId = inwardOutwardEntity.RefId,
                                        PostedDate = inwardOutwardEntity.PostedDate,
                                        MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                        OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                        OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                        BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                        ListItemId = inInwardOutwardDetailParallel.ListItemId,
                                        BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = inInwardOutwardDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = inInwardOutwardDetailParallel.CreditAccount,
                                        DebitAmount = inInwardOutwardDetailParallel.Amount,
                                        DebitAmountOC = inInwardOutwardDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = inwardOutwardEntity.JournalMemo,
                                        RefDate = inwardOutwardEntity.RefDate,
                                        BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                        ContractId = inInwardOutwardDetailParallel.ContractId,
                                        CapitalPlanId = inInwardOutwardDetailParallel.CapitalPlanId
                                    };
                                    inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = inInwardOutwardDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = inInwardOutwardDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = inInwardOutwardDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = inInwardOutwardDetailParallel.AmountOC;
                                    inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = inwardOutwardEntity.RefType,
                                        RefNo = inwardOutwardEntity.RefNo,
                                        AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                        BankId = inInwardOutwardDetailParallel.BankId,
                                        BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                        ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                        BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                        Description = inInwardOutwardDetailParallel.Description,
                                        RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                        ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                        BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                        RefId = inwardOutwardEntity.RefId,
                                        PostedDate = inwardOutwardEntity.PostedDate,
                                        MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                        OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                        OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                        BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                        ListItemId = inInwardOutwardDetailParallel.ListItemId,
                                        BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = inInwardOutwardDetailParallel.DebitAccount ?? inInwardOutwardDetailParallel.CreditAccount,
                                        DebitAmount = inInwardOutwardDetailParallel.Amount,
                                        DebitAmountOC = inInwardOutwardDetailParallel.DebitAccount == null ? 0 : inInwardOutwardDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = inInwardOutwardDetailParallel.CreditAccount == null ? 0 : inInwardOutwardDetailParallel.AmountOC,
                                        FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = inwardOutwardEntity.JournalMemo,
                                        RefDate = inwardOutwardEntity.RefDate,
                                        BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                        ContractId = inInwardOutwardDetailParallel.ContractId,
                                        CapitalPlanId = inInwardOutwardDetailParallel.CapitalPlanId
                                    };
                                    inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }
                                }

                                #endregion

                                #region Insert OriginalGeneralLedger
                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = inwardOutwardEntity.RefType,
                                    RefId = inwardOutwardEntity.RefId,
                                    RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                    OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                    OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                    RefDate = inwardOutwardEntity.RefDate,
                                    RefNo = inwardOutwardEntity.RefNo,
                                    AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                    ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                    Amount = inInwardOutwardDetailParallel.Amount,
                                    Approved = inInwardOutwardDetailParallel.Approved,
                                    BankId = inInwardOutwardDetailParallel.BankId,
                                    BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = inInwardOutwardDetailParallel.CreditAccount,
                                    DebitAccount = inInwardOutwardDetailParallel.DebitAccount,
                                    Description = inInwardOutwardDetailParallel.Description,
                                    FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                    ProjectActivityId = inInwardOutwardDetailParallel.ProjectId,
                                    MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                    JournalMemo = inwardOutwardEntity.JournalMemo,
                                    ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                    ToBankId = inInwardOutwardDetailParallel.BankId,
                                    PostedDate = inwardOutwardEntity.PostedDate,
                                    BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                    ContractId = inInwardOutwardDetailParallel.ContractId,
                                    // Không có Currency trong db : mặc định VNĐ và 1
                                    CurrencyCode = "VND",
                                    ExchangeRate = 1,
                                };
                                inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                {
                                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        foreach (var inwardOutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                        {
                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                      inwardOutwardDetail.DebitAccount, inwardOutwardDetail.CreditAccount,
                                      inwardOutwardDetail.BudgetSourceId,
                                      inwardOutwardDetail.BudgetChapterCode, inwardOutwardDetail.BudgetKindItemCode,
                                      inwardOutwardDetail.BudgetSubKindItemCode, inwardOutwardDetail.BudgetItemCode,
                                      inwardOutwardDetail.BudgetSubItemCode,
                                      inwardOutwardDetail.MethodDistributeId, inwardOutwardDetail.CashWithDrawTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBussinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region InwardOutwardDetailParallel

                                    var inwardOutwardDetailParallel = new INInwardOutwardDetailParallelEntity()
                                    {
                                        RefId = inwardOutwardEntity.RefId,
                                        Description = inwardOutwardDetail.Description,
                                        DebitAccount = autoBussinessParallelEntity.DebitAccountParallel,
                                        CreditAccount = autoBussinessParallelEntity.CreditAccountParallel,
                                        Amount = inwardOutwardDetail.Amount,
                                        BudgetSourceId =
                                            autoBussinessParallelEntity.BudgetSourceIdParallel ??
                                            inwardOutwardDetail.BudgetSourceId,
                                        BudgetChapterCode =
                                            autoBussinessParallelEntity.BudgetChapterCodeParallel ??
                                            inwardOutwardDetail.BudgetChapterCode,
                                        BudgetKindItemCode =
                                            autoBussinessParallelEntity.BudgetKindItemCodeParallel ??
                                            inwardOutwardDetail.BudgetKindItemCode,
                                        BudgetSubKindItemCode =
                                            autoBussinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                            inwardOutwardDetail.BudgetSubKindItemCode,
                                        BudgetItemCode =
                                            autoBussinessParallelEntity.BudgetItemCodeParallel ??
                                            inwardOutwardDetail.BudgetItemCode,
                                        BudgetSubItemCode =
                                            autoBussinessParallelEntity.BudgetSubItemCodeParallel ??
                                            inwardOutwardDetail.BudgetSubItemCode,
                                        MethodDistributeId =
                                            autoBussinessParallelEntity.MethodDistributeIdParallel ??
                                            inwardOutwardDetail.MethodDistributeId,
                                        CashWithdrawTypeId =
                                            autoBussinessParallelEntity.CashWithDrawTypeIdParallel ??
                                            inwardOutwardDetail.CashWithDrawTypeId,
                                        AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                                        ActivityId = inwardOutwardDetail.ActivityId,
                                        ProjectId = inwardOutwardDetail.ProjectId,
                                        ListItemId = inwardOutwardDetail.ListItemId,
                                        Approved = true,
                                        SortOrder = inwardOutwardDetail.SortOrder,
                                        OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                        OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                        FundStructureId = inwardOutwardDetail.FundStructureId,
                                        BankId = inwardOutwardDetail.BankId,
                                        BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                        ContractId = inwardOutwardDetail.ContractId,
                                        CapitalPlanId = inwardOutwardDetail.CapitalPlanId,
                                        Quantity = inwardOutwardDetail.Quantity,
                                        UnitPrice = inwardOutwardDetail.UnitPrice,
                                        InventoryItemId= inwardOutwardDetail.InventoryItemId,
                                        AmountOC= inwardOutwardDetail.AmountOC,

                                    };
                                    if (!inwardOutwardDetailParallel.Validate())
                                    {
                                        foreach (var error in inwardOutwardDetailParallel.ValidationErrors)
                                            inwardOutwardResponse.Message += error + Environment.NewLine;
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }
                                    inwardOutwardDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    inwardOutwardResponse.Message =
                                        INInwardOutwardDetailParallelDao.InsertINInwardOutwardDetailParallel(inwardOutwardDetailParallel);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }

                                    #endregion

                                    #region Insert GeneralLedger
                                    if (inwardOutwardDetailParallel.DebitAccount != null && inwardOutwardDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = inwardOutwardEntity.RefType,
                                            RefNo = inwardOutwardEntity.RefNo,
                                            AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                            BankId = inwardOutwardDetailParallel.BankId,
                                            BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                            ProjectId = inwardOutwardDetailParallel.ProjectId,
                                            BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                            Description = inwardOutwardDetailParallel.Description,
                                            RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                            ActivityId = inwardOutwardDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                            BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                            RefId = inwardOutwardEntity.RefId,
                                            PostedDate = inwardOutwardEntity.PostedDate,
                                            MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                            OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                            OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                            BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                            ListItemId = inwardOutwardDetailParallel.ListItemId,
                                            BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = inwardOutwardDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = inwardOutwardDetailParallel.CreditAccount, // Thêm TK Có
                                            DebitAmount = inwardOutwardDetailParallel.Amount,
                                            DebitAmountOC = inwardOutwardDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = inwardOutwardEntity.JournalMemo,
                                            RefDate = inwardOutwardEntity.RefDate,
                                            BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                            ContractId = inwardOutwardDetailParallel.ContractId,
                                            CapitalPlanId = inwardOutwardDetailParallel.CapitalPlanId
                                        };
                                        inwardOutwardResponse.Message =
                                            GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = inwardOutwardDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = inwardOutwardDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = inwardOutwardDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = inwardOutwardDetailParallel.AmountOC;
                                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = inwardOutwardEntity.RefType,
                                            RefNo = inwardOutwardEntity.RefNo,
                                            AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                            BankId = inwardOutwardDetailParallel.BankId,
                                            BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                            ProjectId = inwardOutwardDetailParallel.ProjectId,
                                            BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                            Description = inwardOutwardDetailParallel.Description,
                                            RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                            ActivityId = inwardOutwardDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                            BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                            RefId = inwardOutwardEntity.RefId,
                                            PostedDate = inwardOutwardEntity.PostedDate,
                                            MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                            OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                            OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                            BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                            ListItemId = inwardOutwardDetailParallel.ListItemId,
                                            BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                            inwardOutwardDetailParallel.DebitAccount ??
                                            inwardOutwardDetailParallel.CreditAccount,
                                            DebitAmount =
                                            inwardOutwardDetailParallel.DebitAccount == null
                                                ? 0
                                                : inwardOutwardDetailParallel.Amount,
                                            DebitAmountOC =
                                            inwardOutwardDetailParallel.DebitAccount == null
                                                ? 0
                                                : inwardOutwardDetailParallel.AmountOC,
                                            CreditAmount =
                                            inwardOutwardDetailParallel.CreditAccount == null
                                                ? 0
                                                : inwardOutwardDetailParallel.Amount,
                                            CreditAmountOC =
                                            inwardOutwardDetailParallel.CreditAccount == null
                                                ? 0
                                                : inwardOutwardDetailParallel.AmountOC,
                                            FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = inwardOutwardEntity.JournalMemo,
                                            RefDate = inwardOutwardEntity.RefDate,
                                            BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                            ContractId = inwardOutwardDetailParallel.ContractId,
                                            CapitalPlanId = inwardOutwardDetailParallel.CapitalPlanId
                                        };
                                        inwardOutwardResponse.Message =
                                            GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }
                                    }

                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedger = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = inwardOutwardEntity.RefType,
                                        RefId = inwardOutwardEntity.RefId,
                                        RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                        OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                        OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                        RefDate = inwardOutwardEntity.RefDate,
                                        RefNo = inwardOutwardEntity.RefNo,
                                        AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                        ActivityId = inwardOutwardDetailParallel.ActivityId,
                                        Amount = inwardOutwardDetailParallel.Amount,
                                        Approved = inwardOutwardDetailParallel.Approved,
                                        BankId = inwardOutwardDetailParallel.BankId,
                                        BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = inwardOutwardDetailParallel.CreditAccount,
                                        DebitAccount = inwardOutwardDetailParallel.DebitAccount,
                                        Description = inwardOutwardDetailParallel.Description,
                                        FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                        ProjectActivityId = inwardOutwardDetailParallel.ProjectId,
                                        MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                        JournalMemo = inwardOutwardEntity.JournalMemo,
                                        ProjectId = inwardOutwardDetailParallel.ProjectId,
                                        ToBankId = inwardOutwardDetailParallel.BankId,
                                        PostedDate = inwardOutwardEntity.PostedDate,
                                        BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                        ContractId = inwardOutwardDetailParallel.ContractId,
                                        // Không có Currency trong db : mặc định VNĐ và 1
                                        CurrencyCode = "VND",
                                        ExchangeRate = 1,
                                    };
                                    inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedger);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }

                                    #endregion
                                }
                            }
                            #endregion
                            if (inwardOutwardResponse.Message != null)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }
                        }
                    }
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }
                    inwardOutwardResponse.RefId = inwardOutwardEntity.RefId;
                    scope.Complete();
                }
                return inwardOutwardResponse;
            }
        }
        /// <summary>
        /// Updates the in inward outward.
        /// </summary>
        /// <param name="inwardOutwardEntity">The inward outward entity.</param>
        /// <returns>INInwardOutwardResponse.</returns>
       /* public INInwardOutwardResponse UpdateINInwardOutward(INInwardOutwardEntity inwardOutwardEntity)
        {
            var inwardOutwardResponse = new INInwardOutwardResponse { Acknowledge = AcknowledgeType.Success };

            if (inwardOutwardEntity != null && !inwardOutwardEntity.Validate())
            {
                foreach (var error in inwardOutwardEntity.ValidationErrors)
                    inwardOutwardResponse.Message += error + Environment.NewLine;
                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                return inwardOutwardResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (inwardOutwardEntity != null)
                {
                    var inwardOutwardExits = INInwardOutwardDao.GetINInwardOutwardByRefNo(inwardOutwardEntity.RefNo.Trim(), inwardOutwardEntity.PostedDate);
                    if (inwardOutwardExits != null && inwardOutwardExits.PostedDate.Year == inwardOutwardEntity.PostedDate.Year)
                    {
                        if (inwardOutwardExits.RefId != inwardOutwardEntity.RefId && inwardOutwardExits.RefType == inwardOutwardEntity.RefType)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            inwardOutwardResponse.Message = @"Số chứng từ '" + inwardOutwardEntity.RefNo.Trim() +
                                                            @"' đã tồn tại!";
                            return inwardOutwardResponse;
                        }
                    }
                    inwardOutwardResponse.Message =
                        INInwardOutwardDetailDao.DeleteINInwardOutwardDetailByRefId(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = INInwardOutwardDao.UpdateINInwardOutward(inwardOutwardEntity);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }
                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(inwardOutwardEntity);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    #endregion

                    inwardOutwardResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(inwardOutwardEntity.RefId);
                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        return inwardOutwardResponse;
                    }

                    foreach (var inwardOutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                    {
                        inwardOutwardDetail.RefId = inwardOutwardEntity.RefId;
                        inwardOutwardDetail.RefDetailId = Guid.NewGuid().ToString();

                        if (!inwardOutwardDetail.Validate())
                        {
                            foreach (string error in inwardOutwardDetail.ValidationErrors)
                                inwardOutwardResponse.Message += error + Environment.NewLine;
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        // Kiểm tra số lượng tồn trong kho
                        var inventoryModel = InventoryItemDao.GetUnitsInStock(inwardOutwardDetail.InventoryItemId, inwardOutwardDetail.StockId);
                        if (inwardOutwardDetail.Quantity > inventoryModel.UnitsInStock && inwardOutwardEntity.RefType == 202)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            inwardOutwardResponse.Message = string.Format(@"{0} không đủ số lượng tồn, vui lòng kiểm tra lại." + Environment.NewLine + "Số lượng còn lại: {1}", inwardOutwardDetail.Description, string.Format("{0:#,0.####}", inventoryModel.UnitsInStock));
                            scope.Dispose();
                            return inwardOutwardResponse;
                        }

                        inwardOutwardResponse.Message =
                            INInwardOutwardDetailDao.InsertINInwardOutwardDetail(inwardOutwardDetail);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }
                        #region Insert into AccountBalance

                        // Cộng thêm số tiền mới sau khi sửa chứng từ
                        InsertAccountBalance(inwardOutwardEntity, inwardOutwardDetail);
                        if (inwardOutwardResponse.Message != null)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return inwardOutwardResponse;
                        }

                        #endregion

                        #region Insert InventoryLedger

                        var inventoryLedgerEntity = new InventoryLedgerEntity
                        {
                            InventoryLedgerId = Guid.NewGuid().ToString(),
                            RefId = inwardOutwardEntity.RefId,
                            RefType = inwardOutwardEntity.RefType,
                            RefNo = inwardOutwardEntity.RefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            StockId = inwardOutwardDetail.StockId,
                            InventoryItemId = inwardOutwardDetail.InventoryItemId,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            Description = inwardOutwardDetail.Description,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            Unit = inwardOutwardDetail.Unit,
                            UnitPrice = inwardOutwardDetail.UnitPrice,
                            InwardQuantity = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Quantity : 0,
                            OutwardQuantity = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Quantity : 0,
                            OutwardAmount = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Amount : 0,
                            InwardAmount = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Amount : 0,

                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ExpiryDate = inwardOutwardDetail.ExpiryDate,
                            LotNo = inwardOutwardDetail.LotNo,
                            RefOrder = inwardOutwardEntity.RefOrder,
                            SortOrder = inwardOutwardDetail.SortOrder,
                            AccountNumber = inwardOutwardDetail.DebitAccount,
                            CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                            InwardAmountBalance = 0,
                            InwardAmountBalanceAfter = 0,
                            InwardQuantityBalance = 0,
                            UnitPriceBalance = 0,
                            ConfrontingRefId = inwardOutwardDetail.ConfrontingRefId,
                        };
                        inwardOutwardResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #endregion

                        #region Insert GeneralLedger

                        inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardEntity.RefId);
                        if (inwardOutwardResponse.Message != null)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return inwardOutwardResponse;
                        }
                        var generalLedgerEntity = new GeneralLedgerEntity
                        {
                            RefType = inwardOutwardEntity.RefType,
                            RefNo = inwardOutwardEntity.RefNo,
                            AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                            //BankId = inwardOutwardEntity.BankId,
                            BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                            ProjectId = inwardOutwardDetail.ProjectId,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            Description = inwardOutwardDetail.Description,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            ExchangeRate = 1,
                            ActivityId = inwardOutwardDetail.ActivityId,
                            BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                            BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                            RefId = inwardOutwardEntity.RefId,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                            OrgRefNo = inwardOutwardDetail.OrgRefNo,
                            OrgRefDate = inwardOutwardDetail.OrgRefDate,
                            BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                            ListItemId = inwardOutwardDetail.ListItemId,
                            BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                            BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                            CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,
                            AccountNumber = inwardOutwardDetail.DebitAccount,
                            CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                            DebitAmount = inwardOutwardDetail.Amount,
                            DebitAmountOC = inwardOutwardDetail.Amount,
                            CreditAmount = 0,
                            CreditAmountOC = 0,
                            FundStructureId = inwardOutwardDetail.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            RefDate = inwardOutwardEntity.RefDate,
                            BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                            ContractId = inwardOutwardDetail.ContractId,
                            CapitalPlanId = inwardOutwardDetail.CapitalPlanId
                        };
                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        //insert lan 2
                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                        generalLedgerEntity.AccountNumber = inwardOutwardDetail.CreditAccount;
                        generalLedgerEntity.CorrespondingAccountNumber = inwardOutwardDetail.DebitAccount;
                        generalLedgerEntity.DebitAmount = 0;
                        generalLedgerEntity.DebitAmountOC = 0;
                        generalLedgerEntity.CreditAmount = inwardOutwardDetail.Amount;
                        generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.Amount;
                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #endregion

                        #region Insert OriginalGeneralLedger
                        //inwardOutwardResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(inwardOutwardEntity.RefId);
                        //if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        //{
                        //    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        //    return inwardOutwardResponse;
                        //}
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = inwardOutwardEntity.RefType,
                            RefId = inwardOutwardEntity.RefId,
                            RefDetailId = inwardOutwardDetail.RefDetailId,
                            OrgRefDate = inwardOutwardDetail.OrgRefDate,
                            OrgRefNo = inwardOutwardDetail.OrgRefNo,
                            RefDate = inwardOutwardEntity.RefDate,
                            RefNo = inwardOutwardEntity.RefNo,
                            AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                            ActivityId = inwardOutwardDetail.ActivityId,
                            Amount = inwardOutwardDetail.Amount,
                            Approved = inwardOutwardDetail.Approved,
                            BankId = inwardOutwardDetail.BankId,
                            BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                            BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                            BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                            BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                            BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                            BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                            CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,
                            CreditAccount = inwardOutwardDetail.CreditAccount,
                            DebitAccount = inwardOutwardDetail.DebitAccount,
                            Description = inwardOutwardDetail.Description,
                            FundStructureId = inwardOutwardDetail.FundStructureId,
                            TaxAmount = inwardOutwardDetail.TaxAmount,
                            ProjectActivityId = inwardOutwardDetail.ProjectActivityId,
                            MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                            JournalMemo = inwardOutwardEntity.JournalMemo,
                            ProjectId = inwardOutwardDetail.ProjectId,
                            ToBankId = inwardOutwardDetail.BankId,
                            PostedDate = inwardOutwardEntity.PostedDate,
                            BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                            ContractId = inwardOutwardDetail.ContractId,

                            // Không có Currency trong db : mặc định VNĐ và 1
                            CurrencyCode = "VND",
                            ExchangeRate = 1,
                        };
                        inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            return inwardOutwardResponse;
                        }

                        #endregion

                    }

                    inwardOutwardResponse.RefId = inwardOutwardEntity.RefId;
                }

                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                scope.Complete();
            }

            return inwardOutwardResponse;
        }*/
        /// <summary>
        /// Updates the Inward Outward
        /// </summary>
        /// <param name="inwardOutwardEntity">The InwardOutward entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>INInwardOutwardResponse.</returns>
        public INInwardOutwardResponse UpdateINInwardOutward(INInwardOutwardEntity inwardOutwardEntity, bool isAutoGenerateParallel = false, bool IsOutwardNegativeStock=false)
        {
            var inwardOutwardResponse = new INInwardOutwardResponse { Acknowledge = AcknowledgeType.Success };

            if (inwardOutwardEntity != null && !inwardOutwardEntity.Validate())
            {
                foreach (var error in inwardOutwardEntity.ValidationErrors)
                    inwardOutwardResponse.Message += error + Environment.NewLine;
                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                return inwardOutwardResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (inwardOutwardEntity != null)
                {
                    var inwardOutwardExits = INInwardOutwardDao.GetINInwardOutwardByRefNo(inwardOutwardEntity.RefNo.Trim(), inwardOutwardEntity.PostedDate);
                    if (inwardOutwardExits != null && inwardOutwardExits.PostedDate.Year == inwardOutwardEntity.PostedDate.Year)
                    {
                        if (inwardOutwardExits.RefId != inwardOutwardEntity.RefId && inwardOutwardExits.RefType == inwardOutwardEntity.RefType)
                        {
                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            inwardOutwardResponse.Message = @"Số chứng từ '" + inwardOutwardEntity.RefNo.Trim() +
                                                            @"' đã tồn tại!";
                            return inwardOutwardResponse;
                        }
                    }

                    inwardOutwardResponse.Message = INInwardOutwardDao.UpdateINInwardOutward(inwardOutwardEntity);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }
                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(inwardOutwardEntity);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    #endregion

                    #region Delete table

                    inwardOutwardResponse.Message =
                       INInwardOutwardDetailDao.DeleteINInwardOutwardDetailByRefId(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return inwardOutwardResponse;
                    }

                    inwardOutwardResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(inwardOutwardEntity.RefId);
                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        return inwardOutwardResponse;
                    }
                    // Xóa bảng INInwardOutwardDetailParallel
                    inwardOutwardResponse.Message = INInwardOutwardDetailParallelDao.DeleteINInwardOutwardDetailParallelId(inwardOutwardEntity.RefId);
                    if (inwardOutwardResponse.Message != null)
                    {
                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                        return inwardOutwardResponse;
                    }
                    #endregion

                    if (inwardOutwardEntity.InwardOutwardDetails != null && inwardOutwardEntity.InwardOutwardDetails.Count > 0)
                    {
                        foreach (var inwardOutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                        {
                            inwardOutwardDetail.RefId = inwardOutwardEntity.RefId;
                            inwardOutwardDetail.RefDetailId = Guid.NewGuid().ToString();

                            if (!inwardOutwardDetail.Validate())
                            {
                                foreach (string error in inwardOutwardDetail.ValidationErrors)
                                    inwardOutwardResponse.Message += error + Environment.NewLine;
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }

                            // Kiểm tra số lượng tồn trong kho
                            var inventoryModel = InventoryItemDao.GetUnitsInStock(inwardOutwardDetail.InventoryItemId, inwardOutwardDetail.StockId, inwardOutwardEntity.PostedDate);
                            if (inwardOutwardDetail.Quantity > inventoryModel.UnitsInStock && inwardOutwardEntity.RefType == 202 && !IsOutwardNegativeStock)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                inwardOutwardResponse.Message = string.Format(@"{0} không đủ số lượng tồn, vui lòng kiểm tra lại." + Environment.NewLine + "Số lượng còn lại: {1}", inwardOutwardDetail.Description, string.Format("{0:#,0.####}", inventoryModel.UnitsInStock));
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }

                            inwardOutwardResponse.Message =
                                INInwardOutwardDetailDao.InsertINInwardOutwardDetail(inwardOutwardDetail);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }
                            #region Insert into AccountBalance

                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(inwardOutwardEntity, inwardOutwardDetail);
                            if (inwardOutwardResponse.Message != null)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }

                            #endregion

                            #region Insert InventoryLedger

                            var inventoryLedgerEntity = new InventoryLedgerEntity
                            {
                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = inwardOutwardEntity.RefId,
                                RefType = inwardOutwardEntity.RefType,
                                RefNo = inwardOutwardEntity.RefNo,
                                RefDate = inwardOutwardEntity.RefDate,
                                PostedDate = inwardOutwardEntity.PostedDate,
                                StockId = inwardOutwardDetail.StockId,
                                InventoryItemId = inwardOutwardDetail.InventoryItemId,
                                BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                Description = inwardOutwardDetail.Description,
                                RefDetailId = inwardOutwardDetail.RefDetailId,
                                Unit = inwardOutwardDetail.Unit,
                                UnitPrice = inwardOutwardDetail.UnitPrice,
                                //InwardQuantity = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Quantity : 0,
                                OutwardQuantity = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Quantity : 0,
                                OutwardAmount = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.AmountOC : 0,
                                //InwardAmount = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.AmountOC : 0,
                                OutwardAmountOC = inwardOutwardEntity.RefType == 202 ? inwardOutwardDetail.Amount : 0,
                                //InwardAmountOC = inwardOutwardEntity.RefType == 201 ? inwardOutwardDetail.Amount : 0,

                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                ExpiryDate = inwardOutwardDetail.ExpiryDate,
                                LotNo = inwardOutwardDetail.LotNo,
                                RefOrder = inwardOutwardEntity.RefOrder,
                                SortOrder = inwardOutwardDetail.SortOrder,
                                AccountNumber = inwardOutwardDetail.DebitAccount,
                                CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0,
                                ConfrontingRefId = inwardOutwardDetail.ConfrontingRefId,
                                CurrencyCode = inwardOutwardEntity.CurrencyCode,

                            };
                            inwardOutwardResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }

                            #endregion

                            #region Insert GeneralLedger

                            inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardEntity.RefId);
                            if (inwardOutwardResponse.Message != null)
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return inwardOutwardResponse;
                            }
                            if (inwardOutwardDetail.DebitAccount != null && inwardOutwardDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = inwardOutwardEntity.RefType,
                                    RefNo = inwardOutwardEntity.RefNo,
                                    AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                                    BankId = inwardOutwardDetail.BankId,
                                    BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                                    ProjectId = inwardOutwardDetail.ProjectId,
                                    BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                    Description = inwardOutwardDetail.Description,
                                    RefDetailId = inwardOutwardDetail.RefDetailId,
                                    ActivityId = inwardOutwardDetail.ActivityId,
                                    BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                                    CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                    BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                                    RefId = inwardOutwardDetail.RefId,
                                    PostedDate = inwardOutwardEntity.PostedDate,
                                    MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                                    OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                    OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                    BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                                    ListItemId = inwardOutwardDetail.ListItemId,
                                    BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                                    // CashWithDrawTypeId = inwardOutwardDetail.CashWithdrawTypeId,//AnhNT disable theo yêu cầu của BA
                                    AccountNumber = inwardOutwardDetail.DebitAccount,
                                    CorrespondingAccountNumber = inwardOutwardDetail.CreditAccount,
                                    DebitAmount = inwardOutwardDetail.Amount,
                                    DebitAmountOC = inwardOutwardDetail.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = inwardOutwardDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = inwardOutwardEntity.JournalMemo,
                                    RefDate = inwardOutwardEntity.RefDate,
                                    SortOrder = inwardOutwardDetail.SortOrder,
                                    BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                    ContractId = inwardOutwardDetail.ContractId,
                                    CapitalPlanId = inwardOutwardDetail.CapitalPlanId
                                };
                                inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                {
                                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = inwardOutwardDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = inwardOutwardDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = inwardOutwardDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = inwardOutwardDetail.Amount;
                                inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                {
                                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = inwardOutwardEntity.RefType,
                                    RefNo = inwardOutwardEntity.RefNo,
                                    AccountingObjectId = inwardOutwardEntity.AccountingObjectId,
                                    BankId = inwardOutwardDetail.BankId,
                                    BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                                    ProjectId = inwardOutwardDetail.ProjectId,
                                    BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                    Description = inwardOutwardDetail.Description,
                                    RefDetailId = inwardOutwardDetail.RefDetailId,
                                    // ExchangeRate = inwardOutwardDetail.ExchangeRate,
                                    ActivityId = inwardOutwardDetail.ActivityId,
                                    BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                                    CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                    BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                                    RefId = inwardOutwardEntity.RefId,
                                    PostedDate = inwardOutwardEntity.PostedDate,
                                    MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                                    OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                    OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                    BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                                    ListItemId = inwardOutwardDetail.ListItemId,
                                    BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                                    //CashWithDrawTypeId = inwardOutwardDetail.CashWithdrawTypeId,//AnhNT disable theo yêu cầu của BA
                                    AccountNumber = inwardOutwardDetail.DebitAccount ?? inwardOutwardDetail.CreditAccount,
                                    DebitAmount = inwardOutwardDetail.DebitAccount == null ? 0 : inwardOutwardDetail.Amount,
                                    DebitAmountOC = inwardOutwardDetail.DebitAccount == null ? 0 : inwardOutwardDetail.Amount,
                                    CreditAmount = inwardOutwardDetail.CreditAccount == null ? 0 : inwardOutwardDetail.Amount,
                                    CreditAmountOC = inwardOutwardDetail.CreditAccount == null ? 0 : inwardOutwardDetail.Amount,
                                    FundStructureId = inwardOutwardDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = inwardOutwardEntity.JournalMemo,
                                    RefDate = inwardOutwardEntity.RefDate,
                                    SortOrder = inwardOutwardDetail.SortOrder,
                                    BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                    ContractId = inwardOutwardDetail.ContractId,
                                    CapitalPlanId = inwardOutwardDetail.CapitalPlanId
                                };
                                inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                {
                                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                    return inwardOutwardResponse;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            //inwardOutwardResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(inwardOutwardEntity.RefId);
                            //if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            //{
                            //    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                            //    return inwardOutwardResponse;
                            //}
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = inwardOutwardEntity.RefType,
                                RefId = inwardOutwardEntity.RefId,
                                RefDetailId = inwardOutwardDetail.RefDetailId,
                                OrgRefDate = inwardOutwardDetail.OrgRefDate,
                                OrgRefNo = inwardOutwardDetail.OrgRefNo,
                                RefDate = inwardOutwardEntity.RefDate,
                                RefNo = inwardOutwardEntity.RefNo,
                                AccountingObjectId = inwardOutwardDetail.AccountingObjectId,
                                ActivityId = inwardOutwardDetail.ActivityId,
                                Amount = inwardOutwardDetail.Amount,
                                Approved = inwardOutwardDetail.Approved,
                                BankId = inwardOutwardDetail.BankId,
                                BudgetChapterCode = inwardOutwardDetail.BudgetChapterCode,
                                BudgetDetailItemCode = inwardOutwardDetail.BudgetDetailItemCode,
                                BudgetItemCode = inwardOutwardDetail.BudgetItemCode,
                                BudgetKindItemCode = inwardOutwardDetail.BudgetKindItemCode,
                                BudgetSourceId = inwardOutwardDetail.BudgetSourceId,
                                BudgetSubItemCode = inwardOutwardDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = inwardOutwardDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = inwardOutwardDetail.CashWithDrawTypeId,
                                CreditAccount = inwardOutwardDetail.CreditAccount,
                                DebitAccount = inwardOutwardDetail.DebitAccount,
                                Description = inwardOutwardDetail.Description,
                                FundStructureId = inwardOutwardDetail.FundStructureId,
                                TaxAmount = inwardOutwardDetail.TaxAmount,
                                ProjectActivityId = inwardOutwardDetail.ProjectActivityId,
                                MethodDistributeId = inwardOutwardDetail.MethodDistributeId,
                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                ProjectId = inwardOutwardDetail.ProjectId,
                                ToBankId = inwardOutwardDetail.BankId,
                                PostedDate = inwardOutwardEntity.PostedDate,
                                BudgetExpenseId = inwardOutwardDetail.BudgetExpenseId,
                                ContractId = inwardOutwardDetail.ContractId,

                                // Không có Currency trong db : mặc định VNĐ và 1
                                CurrencyCode = "VND",
                                ExchangeRate = 1,
                            };
                            inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                            {
                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                return inwardOutwardResponse;
                            }

                            #endregion
                        }
                        #region Sinh dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region InInwardOutwardDetailParallel
                            if (inwardOutwardEntity.INInwardOutwardDetailParallels != null)
                            {
                                foreach (var inInwardOutwardDetailParallel in inwardOutwardEntity.INInwardOutwardDetailParallels)
                                {
                                    #region Insert Inward outward detail parallel
                                    inInwardOutwardDetailParallel.RefId = inwardOutwardEntity.RefId;
                                    inInwardOutwardDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    inInwardOutwardDetailParallel.UnitPrice = 0;
                                    inInwardOutwardDetailParallel.Quantity = 0;
                                    if (!inInwardOutwardDetailParallel.Validate())
                                    {
                                        foreach (var error in inInwardOutwardDetailParallel.ValidationErrors)
                                            inwardOutwardResponse.Message += error + Environment.NewLine;
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }
                                    inwardOutwardResponse.Message = INInwardOutwardDetailParallelDao.InsertINInwardOutwardDetailParallel(inInwardOutwardDetailParallel);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }
                                    #endregion

                                    #region Insert GeneralLedger
                                    if (inInwardOutwardDetailParallel.DebitAccount != null && inInwardOutwardDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEnt = new GeneralLedgerEntity
                                        {
                                            RefType = inwardOutwardEntity.RefType,
                                            RefNo = inwardOutwardEntity.RefNo,
                                            AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                            BankId = inInwardOutwardDetailParallel.BankId,
                                            BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                            ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                            BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                            Description = inInwardOutwardDetailParallel.Description,
                                            RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                            ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                            BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                            RefId = inwardOutwardEntity.RefId,
                                            PostedDate = inwardOutwardEntity.PostedDate,
                                            MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                            OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                            OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                            BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                            ListItemId = inInwardOutwardDetailParallel.ListItemId,
                                            BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = inInwardOutwardDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = inInwardOutwardDetailParallel.CreditAccount,
                                            DebitAmount = inInwardOutwardDetailParallel.Amount,
                                            DebitAmountOC = inInwardOutwardDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = inwardOutwardEntity.JournalMemo,
                                            RefDate = inwardOutwardEntity.RefDate,
                                            BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                            ContractId = inInwardOutwardDetailParallel.ContractId,
                                            CapitalPlanId = inInwardOutwardDetailParallel.CapitalPlanId

                                        };
                                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEnt);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEnt.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEnt.AccountNumber = inInwardOutwardDetailParallel.CreditAccount;
                                        generalLedgerEnt.CorrespondingAccountNumber = inInwardOutwardDetailParallel.DebitAccount;
                                        generalLedgerEnt.DebitAmount = 0;
                                        generalLedgerEnt.DebitAmountOC = 0;
                                        generalLedgerEnt.CreditAmount = inInwardOutwardDetailParallel.Amount;
                                        generalLedgerEnt.CreditAmountOC = inInwardOutwardDetailParallel.AmountOC;
                                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEnt);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedger = new GeneralLedgerEntity
                                        {
                                            RefType = inwardOutwardEntity.RefType,
                                            RefNo = inwardOutwardEntity.RefNo,
                                            AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                            BankId = inInwardOutwardDetailParallel.BankId,
                                            BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                            ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                            BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                            Description = inInwardOutwardDetailParallel.Description,
                                            RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                            ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                            BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                            RefId = inwardOutwardEntity.RefId,
                                            PostedDate = inwardOutwardEntity.PostedDate,
                                            MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                            OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                            OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                            BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                            ListItemId = inInwardOutwardDetailParallel.ListItemId,
                                            BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = inInwardOutwardDetailParallel.DebitAccount ?? inInwardOutwardDetailParallel.CreditAccount,
                                            DebitAmount = inInwardOutwardDetailParallel.Amount,
                                            DebitAmountOC = inInwardOutwardDetailParallel.DebitAccount == null ? 0 : inInwardOutwardDetailParallel.AmountOC,
                                            CreditAmount = inInwardOutwardDetailParallel.Amount,
                                            CreditAmountOC = inInwardOutwardDetailParallel.CreditAccount == null ? 0 : inInwardOutwardDetailParallel.AmountOC,
                                            FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = inwardOutwardEntity.JournalMemo,
                                            RefDate = inwardOutwardEntity.RefDate,
                                            BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                            ContractId = inInwardOutwardDetailParallel.ContractId,
                                            CapitalPlanId = inInwardOutwardDetailParallel.CapitalPlanId
                                        };
                                        inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedger);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }

                                    }

                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedger = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = inwardOutwardEntity.RefType,
                                        RefId = inwardOutwardEntity.RefId,
                                        RefDetailId = inInwardOutwardDetailParallel.RefDetailId,
                                        OrgRefDate = inInwardOutwardDetailParallel.OrgRefDate,
                                        OrgRefNo = inInwardOutwardDetailParallel.OrgRefNo,
                                        RefDate = inwardOutwardEntity.RefDate,
                                        RefNo = inwardOutwardEntity.RefNo,
                                        AccountingObjectId = inInwardOutwardDetailParallel.AccountingObjectId,
                                        ActivityId = inInwardOutwardDetailParallel.ActivityId,
                                        Amount = inInwardOutwardDetailParallel.Amount,
                                        Approved = inInwardOutwardDetailParallel.Approved,
                                        BankId = inInwardOutwardDetailParallel.BankId,
                                        BudgetChapterCode = inInwardOutwardDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = inInwardOutwardDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = inInwardOutwardDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = inInwardOutwardDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = inInwardOutwardDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = inInwardOutwardDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = inInwardOutwardDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = inInwardOutwardDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = inInwardOutwardDetailParallel.CreditAccount,
                                        DebitAccount = inInwardOutwardDetailParallel.DebitAccount,
                                        Description = inInwardOutwardDetailParallel.Description,
                                        FundStructureId = inInwardOutwardDetailParallel.FundStructureId,
                                        ProjectActivityId = inInwardOutwardDetailParallel.ProjectId,
                                        MethodDistributeId = inInwardOutwardDetailParallel.MethodDistributeId,
                                        JournalMemo = inwardOutwardEntity.JournalMemo,
                                        ProjectId = inInwardOutwardDetailParallel.ProjectId,
                                        ToBankId = inInwardOutwardDetailParallel.BankId,
                                        PostedDate = inwardOutwardEntity.PostedDate,
                                        BudgetExpenseId = inInwardOutwardDetailParallel.BudgetExpenseId,
                                        ContractId = inInwardOutwardDetailParallel.ContractId,
                                        // Không có Currency trong db : mặc định VNĐ và 1
                                        CurrencyCode = "VND",
                                        ExchangeRate = 1,

                                    };
                                    inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedger);
                                    if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                    {
                                        inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                        return inwardOutwardResponse;
                                    }

                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            foreach (var inwardoutwardDetail in inwardOutwardEntity.InwardOutwardDetails)
                            {
                                //insert dl moi
                                var autoBussinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(inwardoutwardDetail.DebitAccount,
                                    inwardoutwardDetail.CreditAccount,
                                    inwardoutwardDetail.BudgetSourceId,
                                    inwardoutwardDetail.BudgetChapterCode,
                                    inwardoutwardDetail.BudgetKindItemCode,
                                    inwardoutwardDetail.BudgetSubKindItemCode,
                                    inwardoutwardDetail.BudgetItemCode,
                                    inwardoutwardDetail.BudgetSubItemCode,
                                    inwardoutwardDetail.MethodDistributeId,
                                    inwardoutwardDetail.CashWithDrawTypeId);
                                if (autoBussinessParallelEntitys != null)
                                {
                                    foreach (var autoBussinessParallelEntity in autoBussinessParallelEntitys)
                                    {
                                        #region InwardOutwardDetailParallel

                                        var inwardOutwardDetailParallel = new INInwardOutwardDetailParallelEntity()
                                        {
                                            RefId = inwardOutwardEntity.RefId,
                                            Description = inwardoutwardDetail.Description,
                                            DebitAccount = autoBussinessParallelEntity.DebitAccountParallel,
                                            CreditAccount = autoBussinessParallelEntity.CreditAccountParallel,
                                            Amount = inwardoutwardDetail.Amount,
                                            AmountOC= inwardoutwardDetail.AmountOC,
                                            //  AmountOC= inwardoutwardDetail.AmountExchange,
                                            BudgetSourceId =
                                                autoBussinessParallelEntity.BudgetSourceIdParallel ??
                                                inwardoutwardDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                autoBussinessParallelEntity.BudgetChapterCodeParallel ??
                                                inwardoutwardDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                autoBussinessParallelEntity.BudgetKindItemCodeParallel ??
                                                inwardoutwardDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                autoBussinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                inwardoutwardDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                autoBussinessParallelEntity.BudgetItemCodeParallel ??
                                                inwardoutwardDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                autoBussinessParallelEntity.BudgetSubItemCodeParallel ??
                                                inwardoutwardDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                autoBussinessParallelEntity.MethodDistributeIdParallel ??
                                                inwardoutwardDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                autoBussinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                inwardoutwardDetail.CashWithDrawTypeId,
                                            AccountingObjectId = inwardoutwardDetail.AccountingObjectId,
                                            ActivityId = inwardoutwardDetail.ActivityId,
                                            ProjectId = inwardoutwardDetail.ProjectId,
                                            ListItemId = inwardoutwardDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = inwardoutwardDetail.SortOrder,
                                            OrgRefNo = inwardoutwardDetail.OrgRefNo,
                                            OrgRefDate = inwardoutwardDetail.OrgRefDate,
                                            FundStructureId = inwardoutwardDetail.FundStructureId,
                                            BankId = inwardoutwardDetail.BankId,
                                            BudgetExpenseId = inwardoutwardDetail.BudgetExpenseId,
                                            ContractId = inwardoutwardDetail.ContractId,
                                            CapitalPlanId = inwardoutwardDetail.CapitalPlanId,
                                            Quantity = inwardoutwardDetail.Quantity,
                                            UnitPrice = inwardoutwardDetail.UnitPrice,
                                            InventoryItemId= inwardoutwardDetail.InventoryItemId,
                                        };
                                        if (!inwardOutwardDetailParallel.Validate())
                                        {
                                            foreach (var error in inwardOutwardDetailParallel.ValidationErrors)
                                                inwardOutwardResponse.Message += error + Environment.NewLine;
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }
                                        inwardOutwardDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                        inwardOutwardResponse.Message =
                                            INInwardOutwardDetailParallelDao.InsertINInwardOutwardDetailParallel(inwardOutwardDetailParallel);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }

                                        #endregion

                                        #region Insert GeneralLedger
                                        if (inwardOutwardDetailParallel.DebitAccount != null && inwardOutwardDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedger = new GeneralLedgerEntity()
                                            {
                                                RefType = inwardOutwardEntity.RefType,
                                                RefNo = inwardOutwardEntity.RefNo,
                                                AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                                BankId = inwardOutwardDetailParallel.BankId,
                                                BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                                ProjectId = inwardOutwardDetailParallel.ProjectId,
                                                BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                                Description = inwardOutwardDetailParallel.Description,
                                                RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                                ActivityId = inwardOutwardDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                                BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                                RefId = inwardOutwardEntity.RefId,
                                                PostedDate = inwardOutwardEntity.PostedDate,
                                                MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                                OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                                OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                                BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                                ListItemId = inwardOutwardDetailParallel.ListItemId,
                                                BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                inwardOutwardDetailParallel.DebitAccount ?? inwardOutwardDetailParallel.CreditAccount,
                                                CorrespondingAccountNumber = inwardOutwardDetailParallel.CreditAccount, // Thêm TK Có
                                                DebitAmount = inwardOutwardDetailParallel.Amount,
                                                DebitAmountOC = inwardOutwardDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                                RefDate = inwardOutwardEntity.RefDate,
                                                BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                                ContractId = inwardOutwardDetailParallel.ContractId,
                                                CapitalPlanId = inwardOutwardDetailParallel.CapitalPlanId
                                            };
                                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedger);
                                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                            {
                                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                                return inwardOutwardResponse;
                                            }

                                            //insert lan 2
                                            generalLedger.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedger.AccountNumber = inwardOutwardDetailParallel.CreditAccount;
                                            generalLedger.CorrespondingAccountNumber = inwardOutwardDetailParallel.DebitAccount;
                                            generalLedger.DebitAmount = 0;
                                            generalLedger.DebitAmountOC = 0;
                                            generalLedger.CreditAmount = inwardOutwardDetailParallel.Amount;
                                            generalLedger.CreditAmountOC = inwardOutwardDetailParallel.AmountOC;
                                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedger);
                                        }
                                        else
                                        {
                                            var generalLedger = new GeneralLedgerEntity
                                            {
                                                RefType = inwardOutwardEntity.RefType,
                                                RefNo = inwardOutwardEntity.RefNo,
                                                AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                                BankId = inwardOutwardDetailParallel.BankId,
                                                BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                                ProjectId = inwardOutwardDetailParallel.ProjectId,
                                                BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                                Description = inwardOutwardDetailParallel.Description,
                                                RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                                ActivityId = inwardOutwardDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = inwardOutwardEntity.CurrencyCode,
                                                BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                                RefId = inwardOutwardEntity.RefId,
                                                PostedDate = inwardOutwardEntity.PostedDate,
                                                MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                                OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                                OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                                BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                                ListItemId = inwardOutwardDetailParallel.ListItemId,
                                                BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                inwardOutwardDetailParallel.DebitAccount ?? inwardOutwardDetailParallel.CreditAccount,
                                                DebitAmount =
                                                inwardOutwardDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : inwardOutwardDetailParallel.AmountOC,
                                                DebitAmountOC =
                                            inwardOutwardDetailParallel.DebitAccount == null
                                                ? 0
                                                : inwardOutwardDetailParallel.AmountOC,
                                                CreditAmount =
                                                inwardOutwardDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : inwardOutwardDetailParallel.AmountOC,
                                                CreditAmountOC =
                                                inwardOutwardDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : inwardOutwardDetailParallel.AmountOC,
                                                FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = inwardOutwardEntity.JournalMemo,
                                                RefDate = inwardOutwardEntity.RefDate,
                                                BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                                ContractId = inwardOutwardDetailParallel.ContractId,
                                                CapitalPlanId = inwardOutwardDetailParallel.CapitalPlanId
                                            };
                                            inwardOutwardResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedger);
                                            if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                            {
                                                inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                                return inwardOutwardResponse;
                                            }
                                        }

                                        #endregion

                                        #region Insert OriginalGeneralLedger
                                        var originalGeneralLedger = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = inwardOutwardEntity.RefType,
                                            RefId = inwardOutwardEntity.RefId,
                                            RefDetailId = inwardOutwardDetailParallel.RefDetailId,
                                            OrgRefDate = inwardOutwardDetailParallel.OrgRefDate,
                                            OrgRefNo = inwardOutwardDetailParallel.OrgRefNo,
                                            RefDate = inwardOutwardEntity.RefDate,
                                            RefNo = inwardOutwardEntity.RefNo,
                                            AccountingObjectId = inwardOutwardDetailParallel.AccountingObjectId,
                                            ActivityId = inwardOutwardDetailParallel.ActivityId,
                                            Amount = inwardOutwardDetailParallel.Amount,
                                            Approved = inwardOutwardDetailParallel.Approved,
                                            BankId = inwardOutwardDetailParallel.BankId,
                                            BudgetChapterCode = inwardOutwardDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = inwardOutwardDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = inwardOutwardDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = inwardOutwardDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = inwardOutwardDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = inwardOutwardDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = inwardOutwardDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = inwardOutwardDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = inwardOutwardDetailParallel.CreditAccount,
                                            DebitAccount = inwardOutwardDetailParallel.DebitAccount,
                                            Description = inwardOutwardDetailParallel.Description,
                                            FundStructureId = inwardOutwardDetailParallel.FundStructureId,
                                            ProjectActivityId = inwardOutwardDetailParallel.ProjectId,
                                            MethodDistributeId = inwardOutwardDetailParallel.MethodDistributeId,
                                            JournalMemo = inwardOutwardEntity.JournalMemo,
                                            ProjectId = inwardOutwardDetailParallel.ProjectId,
                                            ToBankId = inwardOutwardDetailParallel.BankId,
                                            PostedDate = inwardOutwardEntity.PostedDate,
                                            BudgetExpenseId = inwardOutwardDetailParallel.BudgetExpenseId,
                                            ContractId = inwardOutwardDetailParallel.ContractId,
                                            // Không có Currency trong db : mặc định VNĐ và 1
                                            CurrencyCode = "VND",
                                            ExchangeRate = 1
                                        };
                                        inwardOutwardResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedger);
                                        if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                                        {
                                            inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                                            return inwardOutwardResponse;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    inwardOutwardResponse.RefId = inwardOutwardEntity.RefId;
                }

                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                scope.Complete();
            }

            return inwardOutwardResponse;
        }
        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(INInwardOutwardEntity iNInwardOutwardEntity, INInwardOutwardDetailEntity iNInwardOutwardDetailEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = iNInwardOutwardDetailEntity.DebitAccount,
                //CurrencyCode = iNInwardOutwardEntity.CurrencyCode,
                // ExchangeRate = iNInwardOutwardEntity.ExchangeRate,
                BalanceDate = iNInwardOutwardEntity.PostedDate,
                //  MovementDebitAmountOC = iNInwardOutwardDetailEntity.AmountOC,
                MovementDebitAmount = iNInwardOutwardDetailEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = iNInwardOutwardDetailEntity.BudgetSourceId,
                BudgetChapterCode = iNInwardOutwardDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = iNInwardOutwardDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = iNInwardOutwardDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = iNInwardOutwardDetailEntity.BudgetItemCode,
                BudgetSubItemCode = iNInwardOutwardDetailEntity.BudgetSubItemCode,
                MethodDistributeId = iNInwardOutwardDetailEntity.MethodDistributeId,
                AccountingObjectId = iNInwardOutwardEntity.AccountingObjectId,
                ActivityId = iNInwardOutwardDetailEntity.ActivityId,
                ProjectId = iNInwardOutwardDetailEntity.ProjectId,
                BankAccount = iNInwardOutwardDetailEntity.BankId,
                FundStructureId = iNInwardOutwardDetailEntity.FundStructureId,
                ProjectActivityId = iNInwardOutwardDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = iNInwardOutwardDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(INInwardOutwardEntity iNInwardOutwardEntity, INInwardOutwardDetailEntity iNInwardOutwardDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = iNInwardOutwardDetailEntity.CreditAccount,
                //   CurrencyCode = iNInwardOutwardEntity.CurrencyCode,
                //   ExchangeRate = iNInwardOutwardEntity.ExchangeRate,
                BalanceDate = iNInwardOutwardEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                //   MovementCreditAmountOC = iNInwardOutwardDetailEntity.AmountOC,
                MovementCreditAmount = iNInwardOutwardDetailEntity.Amount,
                BudgetSourceId = iNInwardOutwardDetailEntity.BudgetSourceId,
                BudgetChapterCode = iNInwardOutwardDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = iNInwardOutwardDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = iNInwardOutwardDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = iNInwardOutwardDetailEntity.BudgetItemCode,
                BudgetSubItemCode = iNInwardOutwardDetailEntity.BudgetSubItemCode,
                MethodDistributeId = iNInwardOutwardDetailEntity.MethodDistributeId,
                AccountingObjectId = iNInwardOutwardEntity.AccountingObjectId,
                ActivityId = iNInwardOutwardDetailEntity.ActivityId,
                ProjectId = iNInwardOutwardDetailEntity.ProjectId,
                BankAccount = iNInwardOutwardDetailEntity.BankId,
                FundStructureId = iNInwardOutwardDetailEntity.FundStructureId,
                ProjectActivityId = iNInwardOutwardDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = iNInwardOutwardDetailEntity.BudgetDetailItemCode
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
        public string UpdateAccountBalance(INInwardOutwardEntity iNInwardOutwardEntity)
        {
            var iNInwardOutwardDetails = INInwardOutwardDetailDao.GetINInwardOutwardDetailsByRefId(iNInwardOutwardEntity.RefId);
            foreach (var iNInwardOutwardDetail in iNInwardOutwardDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(iNInwardOutwardEntity, iNInwardOutwardDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(iNInwardOutwardEntity, iNInwardOutwardDetail);
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
        public void InsertAccountBalance(INInwardOutwardEntity iNInwardOutwardEntity, INInwardOutwardDetailEntity iNInwardOutwardDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(iNInwardOutwardEntity, iNInwardOutwardDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(iNInwardOutwardEntity, iNInwardOutwardDetailEntity);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        #endregion

        /// <summary>
        /// Deletes the in inward outward.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>INInwardOutwardResponse.</returns>
        public INInwardOutwardResponse DeleteINInwardOutward(string refId)
        {
            var inwardOutwardResponse = new INInwardOutwardResponse { Acknowledge = AcknowledgeType.Success };

            using (var scope = new TransactionScope())
            {
                var inwardOutwardEntityForDelete = INInwardOutwardDao.GetINInwardOutward(refId);
                inwardOutwardResponse.Message = INInwardOutwardDao.DeleteINInwardOutward(inwardOutwardEntityForDelete);
                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardEntityForDelete.RefId);
                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                inwardOutwardResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(inwardOutwardEntityForDelete.RefId);
                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }

                //Xóa bảng OriginalGeneralLedger
                inwardOutwardResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(inwardOutwardEntityForDelete.RefId);
                if (!string.IsNullOrEmpty(inwardOutwardResponse.Message))
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    return inwardOutwardResponse;
                }

                //inwardOutwardResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(inwardOutwardResponse.RefId);
                //if (inwardOutwardResponse.Message != null)
                //{
                //    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                //    scope.Dispose();
                //    return inwardOutwardResponse;
                //}
                #region Update account balance
                // Cập nhật giá trị vào account balance trước khi xóa
                inwardOutwardResponse.Message = UpdateAccountBalance(inwardOutwardEntityForDelete);
                if (inwardOutwardResponse.Message != null)
                {
                    inwardOutwardResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return inwardOutwardResponse;
                }
                #endregion

                scope.Complete();
            }

            return inwardOutwardResponse;
        }

        public bool CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem)
        {
            var inwardOutwardExits = INInwardOutwardDao.CheckExistVoucher(fromDate, toDate, inventoryItem);
            if (inwardOutwardExits == null || inwardOutwardExits.Count == 0)
                return false;
            return true;
        }
    }
}