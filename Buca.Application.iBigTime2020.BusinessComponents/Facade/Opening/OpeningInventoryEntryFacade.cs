/***********************************************************************
 * <copyright file="OpeningInventoryEntryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// OpeningInventoryEntryFacade
    /// </summary>
    public class OpeningInventoryEntryFacade
    {
        private static readonly IOpeningInventoryEntryDao OpeningInventoryEntryDao = DataAccess.DataAccess.OpeningInventoryEntryDao;
        private static readonly IInventoryLedgerDao InventoryLedgerDao = DataAccess.DataAccess.InventoryLedgerDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        /// <summary>
        /// Gets the opening inventory entries.
        /// </summary>
        /// <param name="acccountNumber">The acccount number.</param>
        /// <returns></returns>
        public List<OpeningInventoryEntryEntity> GetOpeningInventoryEntries(string acccountNumber)
        {
            return OpeningInventoryEntryDao.GetOpeningInventoryEntries(acccountNumber);
        }

        /// <summary>
        /// Updates the opening inventory entry.
        /// </summary>
        /// <param name="openingInventoryEntries">The opening inventory entries.</param>
        /// <param name="acccountNumber">The acccount number.</param>
        /// <returns></returns>
        public OpeningInventoryEntryResponse UpdateOpeningInventoryEntry(IList<OpeningInventoryEntryEntity> openingInventoryEntries, string acccountNumber)
        {
            var openingInventoryEntryResponse = new OpeningInventoryEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                // Xóa all đi add lại từ đầu, nông dân quá :(
                openingInventoryEntryResponse.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntries(acccountNumber);
                if (openingInventoryEntryResponse.Message != null)
                {
                    openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingInventoryEntryResponse;
                }
                var i = 0;
                //AnhNT: Xử lý xóa tất cả các vật tư của tài khoản
                if (openingInventoryEntries.Count <= 0)
                {
                    // Xóa bảng InventoryLedger
                    openingInventoryEntryResponse.Message =
                        InventoryLedgerDao.DeleteInventoryLedger(acccountNumber, 1002);
                    if (openingInventoryEntryResponse.Message != null)
                    {
                        openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingInventoryEntryResponse;
                    }
                    // Xóa bảng GeneralLedger
                    openingInventoryEntryResponse.Message =
                        //GeneralLedgerDao.DeleteGeneralLedger(openingAccountEntry.AccountNumber, openingAccountEntry.RefType);
                        GeneralLedgerDao.DeleteGeneralLedger(acccountNumber,
                            1002);
                    if (openingInventoryEntryResponse.Message != null)
                    {
                        openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingInventoryEntryResponse;
                    }
                    openingInventoryEntryResponse.RefId = Guid.NewGuid().ToString();
                }
                if (openingInventoryEntries != null)
                {
                    foreach (var openingInventoryEntry in openingInventoryEntries)
                    {
                        if (!openingInventoryEntry.Validate())
                        {
                            foreach (string error in openingInventoryEntry.ValidationErrors)
                                openingInventoryEntryResponse.Message += error + Environment.NewLine;
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingInventoryEntryResponse;
                        }
                        if (i == 0)
                        {
                            // Xóa bảng InventoryLedger
                            openingInventoryEntryResponse.Message =
                                InventoryLedgerDao.DeleteInventoryLedger(openingInventoryEntry.AccountNumber, openingInventoryEntry.RefType);
                            if (openingInventoryEntryResponse.Message != null)
                            {
                                openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return openingInventoryEntryResponse;
                            }
                            // Xóa bảng GeneralLedger
                            openingInventoryEntryResponse.Message =
                                //GeneralLedgerDao.DeleteGeneralLedger(openingAccountEntry.AccountNumber, openingAccountEntry.RefType);
                                GeneralLedgerDao.DeleteGeneralLedger(openingInventoryEntry.AccountNumber,
                                    openingInventoryEntry.RefType);
                            if (openingInventoryEntryResponse.Message != null)
                            {
                                openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return openingInventoryEntryResponse;
                            }
                        }

                        i = i + 1;

                        //if (string.IsNullOrEmpty(openingInventoryEntry.RefId))
                        openingInventoryEntry.RefId = Guid.NewGuid().ToString();
                        openingInventoryEntryResponse.Message = OpeningInventoryEntryDao.UpdateOpeningInventoryEntry(openingInventoryEntry);
                        openingInventoryEntryResponse.RefId = openingInventoryEntry.RefId;
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingInventoryEntryResponse;
                        }
                        openingInventoryEntryResponse.RefId = openingInventoryEntry.RefId;

                        #region Insert InventoryLedger

                        var inventoryItem = InventoryItemDao.GetInventoryItem(openingInventoryEntry.InventoryItemId);

                        var inventoryLedgerEntity = new InventoryLedgerEntity
                        {
                            InventoryLedgerId = Guid.NewGuid().ToString(),

                            RefId = openingInventoryEntry.RefId,
                            RefType = openingInventoryEntry.RefType,
                            RefNo = "OPN",
                            RefDate = openingInventoryEntry.PostedDate,
                            PostedDate = openingInventoryEntry.PostedDate,
                            StockId = openingInventoryEntry.StockId,
                            InventoryItemId = openingInventoryEntry.InventoryItemId,
                            BudgetSourceId = openingInventoryEntry.BudgetSourceId,
                            RefDetailId = openingInventoryEntry.RefId,
                            UnitPrice = openingInventoryEntry.UnitPrice,
                            InwardQuantity = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.Quantity : 0,
                            InwardAmount = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.Amount : 0,
                            ExpiryDate = openingInventoryEntry.ExpiryDate,
                            LotNo = openingInventoryEntry.LotNo,
                            RefOrder = openingInventoryEntry.RefOrder,
                            SortOrder = openingInventoryEntry.SortOrder,
                            AccountNumber = openingInventoryEntry.AccountNumber,
                            InwardAmountBalance = 0,
                            InwardAmountBalanceAfter = 0,
                            InwardQuantityBalance = 0,
                            UnitPriceBalance = 0,
                            Unit = inventoryItem.Unit,
                            InwardAmountOC = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.AmountOC : 0,
                            CurrencyCode = openingInventoryEntry.CurrencyCode,
                            //  ConfrontingRefId = openingInventoryEntry.ConfrontingRefId,
                        };
                        openingInventoryEntryResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }
                        #endregion

                        #region Insert Ledger

                        // Insert số tiền theo tính chất của tài khoản
                        // Nếu tài khoản có tính chất dư nợ: Insert số tiền vào cột DebitAmount
                        // Nếu tài khoản có tính chất dư có: Insert số tiền vào cột CreditAmount

                        var account = AccountDao.GetAccountByAccountNumber(openingInventoryEntry.AccountNumber);

                        var accountCategoryKind = account.AccountCategoryKind;


                        var inventoryLedgerEntity2 = new GeneralLedgerEntity
                        {
                            RefType = openingInventoryEntry.RefType,
                            RefNo = "OPN",
                            CurrencyCode = openingInventoryEntry.CurrencyCode,
                            ExchangeRate = openingInventoryEntry.ExchangeRate,
                            BudgetChapterCode = openingInventoryEntry.BudgetChapterCode,
                            BudgetSourceId = openingInventoryEntry.BudgetSourceId,
                            RefDetailId = openingInventoryEntry.RefId,
                            BudgetSubKindItemCode = openingInventoryEntry.BudgetSubKindItemCode,
                            BudgetKindItemCode = openingInventoryEntry.BudgetKindItemCode,
                            RefId = openingInventoryEntry.RefId,
                            PostedDate = openingInventoryEntry.PostedDate,
                            BudgetItemCode = openingInventoryEntry.BudgetItemCode,
                            BudgetSubItemCode = openingInventoryEntry.BudgetSubItemCode,
                            AccountNumber = openingInventoryEntry.AccountNumber,
                            DebitAmount = accountCategoryKind != 1 ? openingInventoryEntry.Amount : 0,
                            DebitAmountOC = accountCategoryKind != 1 ? openingInventoryEntry.AmountOC : 0,
                            CreditAmount = accountCategoryKind == 1 ? openingInventoryEntry.Amount : 0,
                            CreditAmountOC = accountCategoryKind == 1 ? openingInventoryEntry.AmountOC : 0,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            RefDate = openingInventoryEntry.PostedDate,
                            
                            
                        };
                        openingInventoryEntryResponse.Message =
                                GeneralLedgerDao.InsertGeneralLedger(inventoryLedgerEntity2);
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }

                        #endregion

                        #region Insert OriginalGeneralLedger

                        // Tạm thời chưa dùng đến đoạn insert vào bảng này

                        //var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        //{
                        //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                        //    RefType = openingAccountEntry.RefType,
                        //    RefId = openingAccountEntry.RefId,
                        //    CurrencyCode = openingAccountEntry.CurrencyId,
                        //    ExchangeRate = openingAccountEntry.ExchangeRate,
                        //    RefDetailId = openingAccountEntry.RefId,
                        //    RefDate = openingAccountEntry.PostedDate,
                        //    RefNo = "OPN",
                        //    AccountingObjectId = openingAccountEntry.AccountingObjectId,
                        //    ActivityId = openingAccountEntry.ActivityId,
                        //    Amount = openingAccountEntry.DebitAmount,
                        //    AmountOC = openingAccountEntry.DebitAmountOC,
                        //    Approved = openingAccountEntry.Approved,
                        //    BudgetChapterCode = openingAccountEntry.BudgetChapterCode,
                        //    BudgetDetailItemCode = openingAccountEntry.BudgetDetailItemCode,
                        //    BudgetItemCode = openingAccountEntry.BudgetItemCode,
                        //    BudgetKindItemCode = openingAccountEntry.BudgetKindItemCode,
                        //    BudgetSourceId = openingAccountEntry.BudgetSourceId,
                        //    BudgetSubItemCode = openingAccountEntry.BudgetSubItemCode,
                        //    BudgetSubKindItemCode = openingAccountEntry.BudgetSubKindItemCode,
                        //    CashWithDrawTypeId = openingAccountEntry.CashWithdrawTypeId,
                        //    DebitAccount = openingAccountEntry.AccountNumber,
                        //    FundStructureId = openingAccountEntry.FundStructureId,
                        //    ProjectActivityId = openingAccountEntry.ProjectActivityId,
                        //    MethodDistributeId = openingAccountEntry.MethodDistributeId,
                        //    ProjectId = openingAccountEntry.ProjectId,
                        //    PostedDate = openingAccountEntry.PostedDate,
                        //};
                        //openingAccountEntryResponse.Message =
                        //    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        //if (!string.IsNullOrEmpty(openingAccountEntryResponse.Message))
                        //{
                        //    openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        //    return openingAccountEntryResponse;
                        //}

                        #endregion
                    }
                }
                scope.Complete();
            }
            return openingInventoryEntryResponse;
        }

        public OpeningInventoryEntryResponse UpdateOpeningInventoryEntryConvertDB(List<OpeningInventoryEntryEntity> openingInventoryEntries)
        {
            var openingInventoryEntryResponse = new OpeningInventoryEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var i = 0;
                if (openingInventoryEntries != null)
                {
                    foreach (var openingInventoryEntry in openingInventoryEntries)
                    {
                        i = i + 1;
                        //if (string.IsNullOrEmpty(openingInventoryEntry.RefId)) 
                        openingInventoryEntry.RefId = Guid.NewGuid().ToString();

                        openingInventoryEntryResponse.Message = OpeningInventoryEntryDao.UpdateOpeningInventoryEntry(openingInventoryEntry);
                        openingInventoryEntryResponse.RefId = openingInventoryEntry.RefId;
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingInventoryEntryResponse;
                        }
                        openingInventoryEntryResponse.RefId = openingInventoryEntry.RefId;

                        #region Insert InventoryLedger

                        var inventoryItem = InventoryItemDao.GetInventoryItem(openingInventoryEntry.InventoryItemId);

                        var inventoryLedgerEntity = new InventoryLedgerEntity
                        {
                            InventoryLedgerId = Guid.NewGuid().ToString(),

                            RefId = openingInventoryEntry.RefId,
                            RefType = openingInventoryEntry.RefType,
                            RefNo = "OPN",
                            RefDate = openingInventoryEntry.PostedDate,
                            PostedDate = openingInventoryEntry.PostedDate,
                            StockId = openingInventoryEntry.StockId,
                            InventoryItemId = openingInventoryEntry.InventoryItemId,
                            BudgetSourceId = openingInventoryEntry.BudgetSourceId,
                            RefDetailId = openingInventoryEntry.RefId,
                            UnitPrice = openingInventoryEntry.UnitPrice,
                            InwardQuantity = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.Quantity : 0,
                            InwardAmount = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.Amount : 0,
                            ExpiryDate = openingInventoryEntry.ExpiryDate,
                            LotNo = openingInventoryEntry.LotNo,
                            RefOrder = openingInventoryEntry.RefOrder,
                            SortOrder = openingInventoryEntry.SortOrder,
                            AccountNumber = openingInventoryEntry.AccountNumber,
                            InwardAmountBalance = 0,
                            InwardAmountBalanceAfter = 0,
                            InwardQuantityBalance = 0,
                            UnitPriceBalance = 0,
                            Unit = inventoryItem.Unit,
                            CurrencyCode = openingInventoryEntry.CurrencyCode,
                            InwardAmountOC = openingInventoryEntry.RefType == 1002 ? openingInventoryEntry.AmountOC : 0,
                            //  ConfrontingRefId = openingInventoryEntry.ConfrontingRefId,
                        };
                        openingInventoryEntryResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }
                        #endregion

                        #region Insert Ledger

                        // Insert số tiền theo tính chất của tài khoản
                        // Nếu tài khoản có tính chất dư nợ: Insert số tiền vào cột DebitAmount
                        // Nếu tài khoản có tính chất dư có: Insert số tiền vào cột CreditAmount

                        var account = AccountDao.GetAccountByAccountNumber(openingInventoryEntry.AccountNumber);

                        var accountCategoryKind = account.AccountCategoryKind;


                        var inventoryLedgerEntity2 = new GeneralLedgerEntity
                        {
                            RefType = openingInventoryEntry.RefType,
                            RefNo = "OPN",
                            CurrencyCode = openingInventoryEntry.CurrencyCode,
                            ExchangeRate = openingInventoryEntry.ExchangeRate,
                            BudgetChapterCode = openingInventoryEntry.BudgetChapterCode,
                            BudgetSourceId = openingInventoryEntry.BudgetSourceId,
                            RefDetailId = openingInventoryEntry.RefId,
                            BudgetSubKindItemCode = openingInventoryEntry.BudgetSubKindItemCode,
                            BudgetKindItemCode = openingInventoryEntry.BudgetKindItemCode,
                            RefId = openingInventoryEntry.RefId,
                            PostedDate = openingInventoryEntry.PostedDate,
                            BudgetItemCode = openingInventoryEntry.BudgetItemCode,
                            BudgetSubItemCode = openingInventoryEntry.BudgetSubItemCode,
                            AccountNumber = openingInventoryEntry.AccountNumber,
                            DebitAmount = accountCategoryKind != 1 ? openingInventoryEntry.Amount : 0,
                            DebitAmountOC = accountCategoryKind != 1 ? openingInventoryEntry.AmountOC : 0,
                            CreditAmount = accountCategoryKind == 1 ? openingInventoryEntry.Amount : 0,
                            CreditAmountOC = accountCategoryKind == 1 ? openingInventoryEntry.AmountOC : 0,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            RefDate = openingInventoryEntry.PostedDate,
                        };
                        openingInventoryEntryResponse.Message =
                                GeneralLedgerDao.InsertGeneralLedger(inventoryLedgerEntity2);
                        if (!string.IsNullOrEmpty(openingInventoryEntryResponse.Message))
                        {
                            openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingInventoryEntryResponse;
                        }

                        #endregion

                        #region Insert OriginalGeneralLedger

                        // Tạm thời chưa dùng đến đoạn insert vào bảng này

                        //var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        //{
                        //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                        //    RefType = openingAccountEntry.RefType,
                        //    RefId = openingAccountEntry.RefId,
                        //    CurrencyCode = openingAccountEntry.CurrencyId,
                        //    ExchangeRate = openingAccountEntry.ExchangeRate,
                        //    RefDetailId = openingAccountEntry.RefId,
                        //    RefDate = openingAccountEntry.PostedDate,
                        //    RefNo = "OPN",
                        //    AccountingObjectId = openingAccountEntry.AccountingObjectId,
                        //    ActivityId = openingAccountEntry.ActivityId,
                        //    Amount = openingAccountEntry.DebitAmount,
                        //    AmountOC = openingAccountEntry.DebitAmountOC,
                        //    Approved = openingAccountEntry.Approved,
                        //    BudgetChapterCode = openingAccountEntry.BudgetChapterCode,
                        //    BudgetDetailItemCode = openingAccountEntry.BudgetDetailItemCode,
                        //    BudgetItemCode = openingAccountEntry.BudgetItemCode,
                        //    BudgetKindItemCode = openingAccountEntry.BudgetKindItemCode,
                        //    BudgetSourceId = openingAccountEntry.BudgetSourceId,
                        //    BudgetSubItemCode = openingAccountEntry.BudgetSubItemCode,
                        //    BudgetSubKindItemCode = openingAccountEntry.BudgetSubKindItemCode,
                        //    CashWithDrawTypeId = openingAccountEntry.CashWithdrawTypeId,
                        //    DebitAccount = openingAccountEntry.AccountNumber,
                        //    FundStructureId = openingAccountEntry.FundStructureId,
                        //    ProjectActivityId = openingAccountEntry.ProjectActivityId,
                        //    MethodDistributeId = openingAccountEntry.MethodDistributeId,
                        //    ProjectId = openingAccountEntry.ProjectId,
                        //    PostedDate = openingAccountEntry.PostedDate,
                        //};
                        //openingAccountEntryResponse.Message =
                        //    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        //if (!string.IsNullOrEmpty(openingAccountEntryResponse.Message))
                        //{
                        //    openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        //    return openingAccountEntryResponse;
                        //}

                        #endregion
                    }
                }
                scope.Complete();
            }
            return openingInventoryEntryResponse;
        }
        /// <summary>
        /// Xóa hết dòng tại số dư đầu kỳ
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public OpeningInventoryEntryResponse DeleteAllRowInGridOpenInventoryEntry(string accountNumber)
        {
            var openingInventoryEntryResponse = new OpeningInventoryEntryResponse { Acknowledge = AcknowledgeType.Success };
            IList<OpeningInventoryEntryEntity> openingInventoryEntriesEntities = OpeningInventoryEntryDao.GetOpeningInventoryEntries(accountNumber);
            if (openingInventoryEntriesEntities != null && openingInventoryEntriesEntities.Any())
                openingInventoryEntryResponse.RefId = openingInventoryEntriesEntities.First().RefId;
            else
                openingInventoryEntryResponse.RefId = Guid.NewGuid().ToString();
            openingInventoryEntryResponse.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntries(accountNumber);

            using (var scope = new TransactionScope())
            {
                if (openingInventoryEntryResponse.Message != null)
                {
                    openingInventoryEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingInventoryEntryResponse;
                }
            }

            return openingInventoryEntryResponse;
        }


        //  private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        //  private static readonly IOpeningInventoryEntryDao OpeningInventoryEntryDao = DataAccess.DataAccess.OpeningInventoryEntryDao;
        ////  private static readonly IOpeningInventoryEntryDetailDao OpeningInventoryEntryDetailDao = DataAccess.DataAccess.OpeningInventoryEntryDetailDao;
        //  private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        //  private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        //  private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        //  /// <summary>
        //  /// Gets the opening account entries.
        //  /// </summary>
        //  /// <param name="request">The request.</param>
        //  /// <returns></returns>
        //  public OpeningInventoryEntryResponse GetOpeningInventoryEntries(OpeningInventoryEntryRequest request) 
        //  {
        //      var response = new OpeningInventoryEntryResponse();
        //      if (request.LoadOptions.Contains("OpeningInventoryEntries"))
        //          response.OpeningInventoryEntries = OpeningInventoryEntryDao.GetOpeningInventoryEntries();
        //      if (request.LoadOptions.Contains("OpeningInventoryEntry"))
        //      {
        //          var openingAccountEntry = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCode(request.AccountNumber) ;//?? new OpeningInventoryEntryEntity();
        //     //     if (request.LoadOptions.Contains("IncludeDetail"))
        //     //         openingAccountEntry.OpeningInventoryEntryDetails = OpeningInventoryEntryDetailDao.GetOpeningInventoryEntryDetailsByRefId(openingAccountEntry.RefId);
        //          response.OpeningInventoryEntries = openingAccountEntry;
        //      }
        //      return response;
        //  }

        //  /// <summary>
        //  /// Sets the opening account entries.
        //  /// </summary>
        //  /// <param name="request">The request.</param>
        //  /// <returns></returns>
        //  public OpeningInventoryEntryResponse SetOpeningInventoryEntries(OpeningInventoryEntryRequest request)
        //  {
        //      OpeningInventoryEntryEntity inventoryEntryEntity = new OpeningInventoryEntryEntity(); 
        //      var response = new OpeningInventoryEntryResponse();
        //      string accountNumber = ""; 
        //      var openingInventoryEntries = request.OpeningInventoryEntries;  
        //      //var auditingLog = new AudittingLogEntity { ComponentName = "SO DU DAU KY CCDC", EventAction = (int)request.Action };
        //      if (request.Action != PersistType.Delete)
        //      {
        //          foreach (var openingInventoryEntryEntity in openingInventoryEntries)
        //          {
        //              inventoryEntryEntity = openingInventoryEntryEntity;
        //              accountNumber = openingInventoryEntryEntity.AccountNumber;
        //              if (!openingInventoryEntryEntity.Validate())
        //              {
        //                  foreach (var error in openingInventoryEntryEntity.ValidationErrors)
        //                      response.Message += error + Environment.NewLine;
        //                  response.Acknowledge = AcknowledgeType.Failure;
        //                  return response;
        //              }
        //          }

        //      }
        //      try
        //      {
        //          switch (request.Action)
        //          {
        //              case PersistType.Insert:
        //                  break;
        //              case PersistType.Update:
        //                  using (var scope = new TransactionScope())
        //                  {
        //                      if (openingInventoryEntries[0].RefTypeId!=8888)
        //                      {

        //                          response.Message =
        //                          JournalEntryAccountDao.DeleteJournalEntryAccountByPostedDateAndRefType(
        //                          openingInventoryEntries[0].PostedDate, openingInventoryEntries[0].RefTypeId);
        //                          if (response.Message != null)
        //                          {
        //                          response.Acknowledge = AcknowledgeType.Failure;
        //                          scope.Dispose();
        //                          return response;
        //                          }




        //                        //  var dtPostedDate = openingInventoryEntries[0].PostedDate;
        //                          //Delete trong bảng JourentryAccount

        //                      //insert or update master openingAccountEntry
        //                      var account = AccountDao.GetAccountByAccountCode(accountNumber);
        //                      var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(account.AccountCode);
        //                      #region
        //                      if (openingAccountEntryForUpdate != null)
        //                      {
        //                          openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountOC = 0;
        //                          openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountOC = 0;
        //                          openingAccountEntryForUpdate.TotalDebitAmountOC = 0;
        //                          openingAccountEntryForUpdate.TotalCreditAmountOC = 0;
        //                          openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountExchange = 0;
        //                          openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountExchange = 0;
        //                          openingAccountEntryForUpdate.TotalDebitAmountExchange = 0;
        //                          openingAccountEntryForUpdate.TotalCreditAmountExchange = 0;

        //                          foreach (var openingInventoryEntryEntity in openingInventoryEntries)//var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
        //                          {
        //                              openingAccountEntryForUpdate.TotalDebitAmountOC += openingInventoryEntryEntity.AmountOc;
        //                              openingAccountEntryForUpdate.TotalDebitAmountExchange += openingInventoryEntryEntity.AmountExchange;
        //                          }
        //                          response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
        //                          if (response.Message != null)
        //                          {
        //                              response.Acknowledge = AcknowledgeType.Failure;
        //                              scope.Dispose();
        //                              return response;
        //                          }
        //                          //    openingAccountEntry.RefId = openingAccountEntryForUpdate.RefId;
        //                      }
        //                      else
        //                      {
        //                          OpeningAccountEntryEntity openingAccountEntry = new OpeningAccountEntryEntity()
        //                          {
        //                              AccountCode = accountNumber,
        //                              AccountId = inventoryEntryEntity.AccountId,
        //                              AccountName = inventoryEntryEntity.AccountName,
        //                              ParentId = inventoryEntryEntity.ParentId,
        //                              PostedDate = inventoryEntryEntity.PostedDate,
        //                              RefId = 0,
        //                              RefNo = inventoryEntryEntity.RefNo,
        //                              RefTypeId = 700,

        //                          };
        //                          foreach (var openingInventoryEntryEntity in openingInventoryEntries)//var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
        //                          {
        //                              openingAccountEntry.TotalDebitAmountOC += openingInventoryEntryEntity.AmountOc;
        //                              openingAccountEntry.TotalDebitAmountExchange += openingInventoryEntryEntity.AmountExchange;
        //                          }
        //                          openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
        //                          if (openingAccountEntry.RefId == 0)
        //                          {
        //                              response.Acknowledge = AcknowledgeType.Failure;
        //                              scope.Dispose();
        //                              return response;
        //                          }
        //                      }
        //                      #endregion


        //                      //Xoa het 
        //                      foreach (var openingInventoryEntryEntity in openingInventoryEntries)
        //                      {
        //                            var openingInventoryEntryForUpdate = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(openingInventoryEntryEntity.AccountNumber);
        //                          if (openingInventoryEntryForUpdate != null)
        //                          {
        //                              response.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntryByAccountCode(openingInventoryEntryForUpdate);
        //                              response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(openingInventoryEntryForUpdate.RefId, openingInventoryEntryForUpdate.RefTypeId);

        //                          }
        //                      }

        //                          foreach (var openingInventoryEntryEntity in openingInventoryEntries)
        //                          {
        //                              //insert or update master
        //                              var openingInventoryEntryForUpdate =
        //                                  OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(
        //                                      openingInventoryEntryEntity.AccountNumber);
        //                              if (openingInventoryEntryForUpdate != null)
        //                              {

        //                                  openingInventoryEntryEntity.RefId =
        //                                      OpeningInventoryEntryDao.InsertOpeningInventoryEntry(
        //                                          openingInventoryEntryEntity);
        //                                  if (openingInventoryEntryEntity.RefId == 0)
        //                                  {
        //                                      response.Acknowledge = AcknowledgeType.Failure;
        //                                      scope.Dispose();
        //                                      return response;
        //                                  }
        //                              }
        //                              else
        //                              {

        //                                  openingInventoryEntryEntity.RefId =
        //                                      OpeningInventoryEntryDao.InsertOpeningInventoryEntry(
        //                                          openingInventoryEntryEntity);
        //                                  if (openingInventoryEntryEntity.RefId == 0)
        //                                  {
        //                                      response.Acknowledge = AcknowledgeType.Failure;
        //                                      scope.Dispose();
        //                                      return response;
        //                                  }
        //                              }
        //                              response.RefId = openingInventoryEntryEntity.RefId;

        //                              //insert JournalEntryAccount
        //                              var journalEntryAccount = AddJournalEntryAccount(openingInventoryEntryEntity);
        //                              if (!journalEntryAccount.Validate())
        //                              {
        //                                  foreach (var error in journalEntryAccount.ValidationErrors)
        //                                      response.Message += error + Environment.NewLine;
        //                                  response.Acknowledge = AcknowledgeType.Failure;
        //                                  return response;
        //                              }
        //                              journalEntryAccount.RefId =
        //                                  JournalEntryAccountDao.InsertJournalEntryAccount(journalEntryAccount);
        //                              if (journalEntryAccount.RefId != 0) continue;
        //                              else
        //                              {
        //                                  response.Acknowledge = AcknowledgeType.Failure;
        //                                  scope.Dispose();
        //                                  return response;
        //                              }

        //                              //}
        //                              //insert log
        //                              //auditingLog.Reference = "Cập nhật CT số dư đầu kỳ cho tài khoản vật tư";
        //                              //auditingLog.Amount = 0;
        //                              //AudittingLogDao.InsertAudittingLog(auditingLog);
        //                          }
        //                      }
        //                      else
        //                      {

        //                          //insert or update master openingAccountEntry
        //                          var account = AccountDao.GetAccountByAccountCode(accountNumber);
        //                          var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(account.AccountCode);
        //                          if (openingAccountEntryForUpdate != null)
        //                          {
        //                              openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountOC = 0;
        //                              openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountOC = 0;
        //                              openingAccountEntryForUpdate.TotalDebitAmountOC = 0;
        //                              openingAccountEntryForUpdate.TotalCreditAmountOC = 0;
        //                              openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountExchange = 0;
        //                              openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountExchange = 0;
        //                              openingAccountEntryForUpdate.TotalDebitAmountExchange = 0;
        //                              openingAccountEntryForUpdate.TotalCreditAmountExchange = 0;                                   
        //                              response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
        //                              if (response.Message != null)
        //                              {
        //                                  response.Acknowledge = AcknowledgeType.Failure;
        //                                  scope.Dispose();
        //                                  return response;
        //                              }
        //                              else
        //                              {
        //                                  response.RefId = 1;//Success SaveData
        //                              }
        //                              //    openingAccountEntry.RefId = openingAccountEntryForUpdate.RefId;
        //                          }
        //                          else
        //                          {
        //                              OpeningAccountEntryEntity openingAccountEntry = new OpeningAccountEntryEntity()
        //                              {
        //                                  AccountCode = accountNumber,
        //                                  AccountId = inventoryEntryEntity.AccountId,
        //                                  AccountName = inventoryEntryEntity.AccountName,
        //                                  ParentId = inventoryEntryEntity.ParentId,
        //                                  PostedDate = inventoryEntryEntity.PostedDate,
        //                                  RefId = 0,
        //                                  RefNo = inventoryEntryEntity.RefNo,
        //                                  RefTypeId = 700,

        //                              };                           
        //                              openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
        //                              if (openingAccountEntry.RefId == 0)
        //                              {
        //                                  response.Acknowledge = AcknowledgeType.Failure;
        //                                  scope.Dispose();
        //                                  return response;
        //                              }
        //                          }

        //                          //Xoa het 
        //                          foreach (var openingInventoryEntryEntity in openingInventoryEntries)
        //                          {
        //                              var openingInventoryEntryForUpdate = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(openingInventoryEntryEntity.AccountNumber);
        //                              if (openingInventoryEntryForUpdate != null)
        //                              {
        //                                  response.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntryByAccountCode(openingInventoryEntryForUpdate);
        //                                  response.Message = JournalEntryAccountDao.DeleteJournalEntryAccountByAcountNumber(openingInventoryEntryEntity.AccountNumber, 701);
        //                                  if (response.Message != null)
        //                                  {
        //                                      response.Acknowledge = AcknowledgeType.Failure;
        //                                      scope.Dispose();
        //                                      return response;
        //                                  }
        //                                  else
        //                                  {
        //                                      response.RefId = 1;//Success SaveData
        //                                  }
        //                              }
        //                              else
        //                              {
        //                                  response.RefId = 1;//Success SaveData
        //                              }
        //                          }

        //                      }
        //                        scope.Complete();
        //                  }
        //                  break;
        //              default:
        //                  using (var scope = new TransactionScope())
        //                  {

        //                      //insert log
        //                      //auditingLog.Reference = "Xóa CT số dư đầu kỳ cho tài khoản vật tư";
        //                      //auditingLog.Amount = 0;
        //                      //AudittingLogDao.InsertAudittingLog(auditingLog);

        //                      scope.Complete();
        //                  }
        //                  break;
        //          }
        //      }
        //      catch (Exception ex)
        //      {
        //          response.Acknowledge = AcknowledgeType.Failure;
        //          response.Message = ex.Message;
        //          return response;
        //      }

        //   //   response.RefId = openingAccountEntry.RefId;
        //      response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
        //      return response;
        //  }

        //  #region private function

        //  /// <summary>
        //  /// Adds the journal entry account.
        //  /// </summary>
        //  /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        //  /// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        //  /// <returns></returns>
        //  public JournalEntryAccountEntity AddJournalEntryAccount(OpeningInventoryEntryEntity openingInventoryEntryEntity)
        //  {
        //      var account = AccountDao.GetAccountByAccountCode(openingInventoryEntryEntity.AccountNumber);
        //      decimal amountOC;
        //      decimal amountExchange;
        //      //switch (account.BalanceSide)
        //      //{
        //      //    case 0:
        //      //        amountOC = openingInventoryEntryEntity.AmountOc;
        //      //        amountExchange = openingInventoryEntryEntity.AmountExchange;
        //      //        break;
        //      //    case 1:
        //      //        amountOC = openingInventoryEntryEntity.AmountOc;
        //      //        amountExchange = openingInventoryEntryEntity.AmountExchange;
        //      //        break;
        //      //    default:
        //      //        amountOC = Math.Abs(openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC);
        //      //        amountExchange = Math.Abs(openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange);
        //      //        break;
        //      //}
        //      //Đầu 1 -> Dư Nợ
        //      amountOC = openingInventoryEntryEntity.AmountOc;
        //      amountExchange = openingInventoryEntryEntity.AmountExchange;
        //      return new JournalEntryAccountEntity
        //      {
        //          RefId = openingInventoryEntryEntity.RefId,
        //          RefTypeId = openingInventoryEntryEntity.RefTypeId,
        //          RefNo = "OPN",
        //          RefDate = openingInventoryEntryEntity.PostedDate,
        //          PostedDate = openingInventoryEntryEntity.PostedDate,
        //          JournalMemo = null,
        //          CurrencyCode = openingInventoryEntryEntity.CurrencyCode,
        //          ExchangeRate = (decimal)openingInventoryEntryEntity.ExchangeRate,
        //          BankAccount = null,
        //          RefDetailId = openingInventoryEntryEntity.RefId, //Lấy RefMaster
        //          AccountNumber = openingInventoryEntryEntity.AccountNumber,
        //          CorrespondingAccountNumber = null,
        //          AmountOc = amountOC,
        //          Description = null,
        //          JournalType = 1,
        //          AmountExchange = amountExchange,
        //          BudgetSourceCode = null,
        //          BudgetItemCode = null,
        //          AccountingObjectId = null,
        //          EmployeeId = null,
        //          CustomerId = null,
        //          VendorId = null,
        //          MergerFundId = null,
        //          VoucherTypeId = null,
        //          ProjectId =null,
        //      };
        //  }

        //  #endregion


    }
}