using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.System
{
    public class FacadeBase
    {
        DateTime _minDate = new DateTime(1753, 1, 1);
        IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao = DataAccess.DataAccess.OpeningFixedAssetEntryDao;


        string _currencyCode = "VND";

        #region Hạch toán đồng thời
        public enum InsertParallelBy
        {
            Details = 0,
            Purchases = 1,
            FixedAssets = 2,
        }
        IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;
        IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        IBUTransferDetailParallelDao BuTransferDetailParallelDao = DataAccess.DataAccess.BUTransferDetailParallelDao;
        IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// Kiểm tra số lượng tồn trong phòng ban
        /// </summary>
        /// <returns></returns>
        protected ResponseBase GetUnitsInDepartment(string inventoryItemId, string departmentId, decimal quantity, string description)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };

            var inventoryModel = InventoryItemDao.GetUnitsInDepartment(inventoryItemId, departmentId);
            if (quantity > inventoryModel.UnitsInStock)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = string.Format(@"{0} không đủ số lượng tồn, vui lòng kiểm tra lại." + Environment.NewLine + "Số lượng còn lại: {1}", description, string.Format("{0:#,0.####}", inventoryModel.UnitsInStock));
            }
            return response;
        }

        protected TTarget AutoMapper<TSource, TTarget>(TSource aSource, TTarget aTarget)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var srcFields = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                             where aProp.CanRead
                             select new
                             {
                                 Name = aProp.Name,
                                 Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                             }).ToList();
            var trgFields = (from PropertyInfo aProp in aTarget.GetType().GetProperties(flags)
                             where aProp.CanWrite
                             select new
                             {
                                 Name = aProp.Name,
                                 Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                             }).ToList();

            var commonFields = srcFields.Intersect(trgFields).ToList();

            foreach (var aField in commonFields)
            {
                var value = aSource.GetType().GetProperty(aField.Name).GetValue(aSource, null);
                PropertyInfo propertyInfos = aTarget.GetType().GetProperty(aField.Name);
                propertyInfos.SetValue(aTarget, value, null);
            }
            return aTarget;
        }

        /// <summary>
        /// Thêm hạch toán đồng thời
        /// </summary>
        /// <returns></returns>
        protected ResponseBase InsertParallel(BUTransferEntity bUTransfer, InsertParallelBy insertParallelBy)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };

            #region BUTransferDetails
            if (insertParallelBy.Equals(InsertParallelBy.Details) && bUTransfer.BUTransferDetails != null && bUTransfer.BUTransferDetails.Count > 0)
            {
                foreach (BUTransferDetailEntity buTransferDetailEntity in bUTransfer.BUTransferDetails)
                {
                    var sortOrder = 0;


                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                                 buTransferDetailEntity.DebitAccount, buTransferDetailEntity.CreditAccount,
                                                 buTransferDetailEntity.BudgetSourceId, buTransferDetailEntity.BudgetChapterCode,
                                                 buTransferDetailEntity.BudgetKindItemCode, buTransferDetailEntity.BudgetSubKindItemCode,
                                                 buTransferDetailEntity.BudgetItemCode, buTransferDetailEntity.BudgetSubItemCode,
                                                 buTransferDetailEntity.MethodDistributeId, buTransferDetailEntity.CashWithDrawTypeId);

                    if (autoBusinessParallelEntitys != null)
                    {
                        // autoBusinessParallelEntitys = autoBusinessParallelEntitys.Where(w => w.CashWithDrawTypeId == bUTransfer.BUTransferDetails[0].CashWithDrawTypeId).ToList();
                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                        {
                            #region Pararrel

                            var buTransferDetailParallel = new BUTransferDetailParallelEntity()
                            {
                                RefId = bUTransfer.RefId,
                                RefDetailId = Guid.NewGuid().ToString(),
                                Description = buTransferDetailEntity.Description,
                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                Amount = buTransferDetailEntity.Amount,
                                AmountOC = buTransferDetailEntity.AmountOC,
                                BudgetSourceId =
                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                    buTransferDetailEntity.BudgetSourceId,
                                BudgetChapterCode =
                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                    buTransferDetailEntity.BudgetChapterCode,
                                BudgetKindItemCode =
                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                    buTransferDetailEntity.BudgetKindItemCode,
                                BudgetSubKindItemCode =
                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubKindItemCode,
                                BudgetItemCode =
                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                    buTransferDetailEntity.BudgetItemCode,
                                BudgetSubItemCode =
                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubItemCode,
                                MethodDistributeId =
                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                    buTransferDetailEntity.MethodDistributeId,
                                CashWithdrawTypeId =
                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                    buTransferDetailEntity.CashWithDrawTypeId,
                                AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                                ActivityId = buTransferDetailEntity.ActivityId,
                                ProjectId = buTransferDetailEntity.ProjectId,
                                ListItemId = buTransferDetailEntity.ListItemId,
                                BankId = buTransferDetailEntity.BankId,
                                Approved = true,
                                SortOrder = sortOrder,
                                FundStructureId = buTransferDetailEntity.FundStructureId,
                                BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId,
                                ContractId = buTransferDetailEntity.ContractId,
                                CapitalPlanId = buTransferDetailEntity.CapitalPlanId,
                                AdvanceRecovery = buTransferDetailEntity.AdvanceRecovery,
                            };
                            sortOrder++;
                            response.Message =
                                BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);

                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert General Ledger Entity
                            if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bUTransfer.RefType,
                                    RefNo = bUTransfer.RefNo,
                                    AccountingObjectId = bUTransfer.AccountingObjectId,
                                    BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                    ProjectId = buTransferDetailParallel.ProjectId,
                                    BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                    Description = buTransferDetailParallel.Description,
                                    RefDetailId = buTransferDetailParallel.RefDetailId,
                                    ExchangeRate = bUTransfer.ExchangeRate,
                                    ActivityId = buTransferDetailParallel.ActivityId,
                                    BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                    CurrencyCode = bUTransfer.CurrencyCode,
                                    BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                    RefId = bUTransfer.RefId,
                                    PostedDate = bUTransfer.PostedDate,
                                    MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                    OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                    OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                    BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                    ListItemId = buTransferDetailParallel.ListItemId,
                                    BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                    BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                    CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                    AccountNumber =
                                    buTransferDetailParallel.DebitAccount,
                                    CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                    DebitAmount = buTransferDetailParallel.Amount,
                                    DebitAmountOC = buTransferDetailParallel.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = buTransferDetailParallel.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bUTransfer.JournalMemo,
                                    RefDate = bUTransfer.RefDate,
                                    BankId = buTransferDetailParallel.BankId,
                                    BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                                };

                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = buTransferDetailParallel.Amount;
                                generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
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
                                    RefType = bUTransfer.RefType,
                                    RefNo = bUTransfer.RefNo,
                                    AccountingObjectId = bUTransfer.AccountingObjectId,
                                    BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                    ProjectId = buTransferDetailParallel.ProjectId,
                                    BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                    Description = buTransferDetailParallel.Description,
                                    RefDetailId = buTransferDetailParallel.RefDetailId,
                                    ExchangeRate = bUTransfer.ExchangeRate,
                                    ActivityId = buTransferDetailParallel.ActivityId,
                                    BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                    CurrencyCode = bUTransfer.CurrencyCode,
                                    BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                    RefId = bUTransfer.RefId,
                                    PostedDate = bUTransfer.PostedDate,
                                    MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                    OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                    OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                    BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                    ListItemId = buTransferDetailParallel.ListItemId,
                                    BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                    BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                    CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                    AccountNumber =
                                    buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                    DebitAmount =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                    DebitAmountOC =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                    CreditAmount =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                    CreditAmountOC =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                    FundStructureId = buTransferDetailParallel.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bUTransfer.JournalMemo,
                                    RefDate = bUTransfer.RefDate,
                                    BankId = buTransferDetailParallel.BankId,
                                    BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
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
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = buTransferDetailParallel.RefDetailId,
                                OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                ActivityId = buTransferDetailParallel.ActivityId,
                                Amount = buTransferDetailParallel.Amount,
                                AmountOC = buTransferDetailParallel.AmountOC,
                                BankId = buTransferDetailParallel.BankId,
                                BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                CreditAccount = buTransferDetailParallel.CreditAccount,
                                DebitAccount = buTransferDetailParallel.DebitAccount,
                                Description = buTransferDetailParallel.Description,
                                FundStructureId = buTransferDetailParallel.FundStructureId,
                                MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = buTransferDetailParallel.ProjectId,
                                ToBankId = buTransferDetailParallel.BankId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                PostedDate = bUTransfer.PostedDate,
                                BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                            };

                            response.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);

                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion
                        }
                    }
                    #region sinh bút toán đồng thời cho thu hồi tạm ứng năm nay
                    // debit  
                    if (buTransferDetailEntity.AdvanceRecovery != 0)
                    {
                        var buTransferDetailParallelDebit = new BUTransferDetailParallelEntity()
                        {
                            RefId = bUTransfer.RefId,
                            RefDetailId = Guid.NewGuid().ToString(),
                            Description = buTransferDetailEntity.Description,
                            CreditAccount = "00921",
                            DebitAccount = null,
                            Amount = -buTransferDetailEntity.AdvanceRecovery,
                            AmountOC = -buTransferDetailEntity.AdvanceRecovery,
                            BudgetSourceId =
                         buTransferDetailEntity.BudgetSourceId,
                            BudgetChapterCode =
                         buTransferDetailEntity.BudgetChapterCode,
                            BudgetKindItemCode =
                         buTransferDetailEntity.BudgetKindItemCode,
                            BudgetSubKindItemCode =
                         buTransferDetailEntity.BudgetSubKindItemCode,
                            BudgetItemCode =
                         buTransferDetailEntity.BudgetItemCode,
                            BudgetSubItemCode =
                         buTransferDetailEntity.BudgetSubItemCode,
                            MethodDistributeId =
                         buTransferDetailEntity.MethodDistributeId,
                            CashWithdrawTypeId =
                         buTransferDetailEntity.CashWithDrawTypeId,
                            AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                            ActivityId = buTransferDetailEntity.ActivityId,
                            ProjectId = buTransferDetailEntity.ProjectId,
                            ListItemId = buTransferDetailEntity.ListItemId,
                            BankId = buTransferDetailEntity.BankId,
                            Approved = true,
                            SortOrder = sortOrder + 1,
                            FundStructureId = buTransferDetailEntity.FundStructureId,
                            BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId,
                            ContractId = buTransferDetailEntity.ContractId,
                            CapitalPlanId = buTransferDetailEntity.CapitalPlanId,
                            AdvanceRecovery = buTransferDetailEntity.AdvanceRecovery
                        };
                        var buTransferDetailParallelDebit2 = new BUTransferDetailParallelEntity()
                        {
                            RefId = bUTransfer.RefId,
                            RefDetailId = Guid.NewGuid().ToString(),
                            Description = buTransferDetailEntity.Description,
                            CreditAccount = "00922",
                            DebitAccount = null,
                            Amount = buTransferDetailEntity.AdvanceRecovery,
                            AmountOC = buTransferDetailEntity.AdvanceRecovery,
                            BudgetSourceId =
                              buTransferDetailEntity.BudgetSourceId,
                            BudgetChapterCode =
                              buTransferDetailEntity.BudgetChapterCode,
                            BudgetKindItemCode =
                              buTransferDetailEntity.BudgetKindItemCode,
                            BudgetSubKindItemCode =
                              buTransferDetailEntity.BudgetSubKindItemCode,
                            BudgetItemCode =
                              buTransferDetailEntity.BudgetItemCode,
                            BudgetSubItemCode =
                              buTransferDetailEntity.BudgetSubItemCode,
                            MethodDistributeId =
                              buTransferDetailEntity.MethodDistributeId,
                            CashWithdrawTypeId =
                              buTransferDetailEntity.CashWithDrawTypeId,
                            AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                            ActivityId = buTransferDetailEntity.ActivityId,
                            ProjectId = buTransferDetailEntity.ProjectId,
                            ListItemId = buTransferDetailEntity.ListItemId,
                            BankId = buTransferDetailEntity.BankId,
                            Approved = true,
                            SortOrder = sortOrder + 2,
                            FundStructureId = buTransferDetailEntity.FundStructureId,
                            BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId,
                            ContractId = buTransferDetailEntity.ContractId,
                            CapitalPlanId = buTransferDetailEntity.CapitalPlanId,
                            AdvanceRecovery = buTransferDetailEntity.AdvanceRecovery,
                        };
                        response.Message =
                    BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallelDebit);
                        response.Message =
                          BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallelDebit2);
                        var generalLedgerEntity1 = new GeneralLedgerEntity
                        {
                            RefType = bUTransfer.RefType,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = bUTransfer.AccountingObjectId,
                            BudgetChapterCode = buTransferDetailParallelDebit.BudgetChapterCode,
                            ProjectId = buTransferDetailParallelDebit.ProjectId,
                            BudgetSourceId = buTransferDetailParallelDebit.BudgetSourceId,
                            Description = buTransferDetailParallelDebit.Description,
                            RefDetailId = buTransferDetailParallelDebit.RefDetailId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            ActivityId = buTransferDetailParallelDebit.ActivityId,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit.BudgetSubKindItemCode,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit.BudgetKindItemCode,
                            RefId = bUTransfer.RefId,
                            PostedDate = bUTransfer.PostedDate,
                            MethodDistributeId = buTransferDetailParallelDebit.MethodDistributeId,
                            OrgRefNo = buTransferDetailParallelDebit.OrgRefNo,
                            OrgRefDate = buTransferDetailParallelDebit.OrgRefDate,
                            BudgetItemCode = buTransferDetailParallelDebit.BudgetItemCode,
                            ListItemId = buTransferDetailParallelDebit.ListItemId,
                            BudgetSubItemCode = buTransferDetailParallelDebit.BudgetSubItemCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit.BudgetDetailItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit.CashWithdrawTypeId,
                            AccountNumber =
             buTransferDetailParallelDebit.DebitAccount ?? buTransferDetailParallelDebit.CreditAccount,
                            DebitAmount =
             buTransferDetailParallelDebit.DebitAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.Amount,
                            DebitAmountOC =
             buTransferDetailParallelDebit.DebitAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.AmountOC,
                            CreditAmount =
             buTransferDetailParallelDebit.CreditAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.Amount,
                            CreditAmountOC =
             buTransferDetailParallelDebit.CreditAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.AmountOC,
                            FundStructureId = buTransferDetailParallelDebit.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = bUTransfer.JournalMemo,
                            RefDate = bUTransfer.RefDate,
                            BankId = buTransferDetailParallelDebit.BankId,
                            BudgetExpenseId = buTransferDetailParallelDebit.BudgetExpenseId
                        };
                        var generalLedgerEntity2 = new GeneralLedgerEntity
                        {
                            RefType = bUTransfer.RefType,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = bUTransfer.AccountingObjectId,
                            BudgetChapterCode = buTransferDetailParallelDebit2.BudgetChapterCode,
                            ProjectId = buTransferDetailParallelDebit2.ProjectId,
                            BudgetSourceId = buTransferDetailParallelDebit2.BudgetSourceId,
                            Description = buTransferDetailParallelDebit2.Description,
                            RefDetailId = buTransferDetailParallelDebit2.RefDetailId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            ActivityId = buTransferDetailParallelDebit2.ActivityId,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit2.BudgetSubKindItemCode,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit2.BudgetKindItemCode,
                            RefId = bUTransfer.RefId,
                            PostedDate = bUTransfer.PostedDate,
                            MethodDistributeId = buTransferDetailParallelDebit2.MethodDistributeId,
                            OrgRefNo = buTransferDetailParallelDebit2.OrgRefNo,
                            OrgRefDate = buTransferDetailParallelDebit2.OrgRefDate,
                            BudgetItemCode = buTransferDetailParallelDebit2.BudgetItemCode,
                            ListItemId = buTransferDetailParallelDebit2.ListItemId,
                            BudgetSubItemCode = buTransferDetailParallelDebit2.BudgetSubItemCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit2.BudgetDetailItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit2.CashWithdrawTypeId,
                            AccountNumber =
                             buTransferDetailParallelDebit2.DebitAccount ?? buTransferDetailParallelDebit2.CreditAccount,
                            DebitAmount =
                             buTransferDetailParallelDebit2.DebitAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.Amount,
                            DebitAmountOC =
                             buTransferDetailParallelDebit2.DebitAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.AmountOC,
                            CreditAmount =
                             buTransferDetailParallelDebit2.CreditAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.Amount,
                            CreditAmountOC =
                             buTransferDetailParallelDebit2.CreditAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.AmountOC,
                            FundStructureId = buTransferDetailParallelDebit2.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = bUTransfer.JournalMemo,
                            RefDate = bUTransfer.RefDate,
                            BankId = buTransferDetailParallelDebit2.BankId,
                            BudgetExpenseId = buTransferDetailParallelDebit2.BudgetExpenseId
                        };

                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity1);
                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity2);
                        var originalGeneralLedgerEntity1 = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUTransfer.RefType,
                            RefId = bUTransfer.RefId,
                            RefDetailId = buTransferDetailParallelDebit.RefDetailId,
                            OrgRefDate = buTransferDetailParallelDebit.OrgRefDate,
                            OrgRefNo = buTransferDetailParallelDebit.OrgRefNo,
                            RefDate = bUTransfer.RefDate,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = buTransferDetailParallelDebit.AccountingObjectId,
                            ActivityId = buTransferDetailParallelDebit.ActivityId,
                            Amount = buTransferDetailParallelDebit.Amount,
                            AmountOC = buTransferDetailParallelDebit.AmountOC,
                            BankId = buTransferDetailParallelDebit.BankId,
                            BudgetChapterCode = buTransferDetailParallelDebit.BudgetChapterCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit.BudgetDetailItemCode,
                            BudgetItemCode = buTransferDetailParallelDebit.BudgetItemCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit.BudgetKindItemCode,
                            BudgetSourceId = buTransferDetailParallelDebit.BudgetSourceId,
                            BudgetSubItemCode = buTransferDetailParallelDebit.BudgetSubItemCode,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit.BudgetSubKindItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit.CashWithdrawTypeId,
                            CreditAccount = buTransferDetailParallelDebit.CreditAccount,
                            DebitAccount = buTransferDetailParallelDebit.DebitAccount,
                            Description = buTransferDetailParallelDebit.Description,
                            FundStructureId = buTransferDetailParallelDebit.FundStructureId,
                            MethodDistributeId = buTransferDetailParallelDebit.MethodDistributeId,
                            JournalMemo = bUTransfer.JournalMemo,
                            ProjectId = buTransferDetailParallelDebit.ProjectId,
                            ToBankId = buTransferDetailParallelDebit.BankId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            PostedDate = bUTransfer.PostedDate,
                            BudgetExpenseId = buTransferDetailParallelDebit.BudgetExpenseId
                        };
                        var originalGeneralLedgerEntity2 = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUTransfer.RefType,
                            RefId = bUTransfer.RefId,
                            RefDetailId = buTransferDetailParallelDebit2.RefDetailId,
                            OrgRefDate = buTransferDetailParallelDebit2.OrgRefDate,
                            OrgRefNo = buTransferDetailParallelDebit2.OrgRefNo,
                            RefDate = bUTransfer.RefDate,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = buTransferDetailParallelDebit2.AccountingObjectId,
                            ActivityId = buTransferDetailParallelDebit2.ActivityId,
                            Amount = buTransferDetailParallelDebit2.Amount,
                            AmountOC = buTransferDetailParallelDebit2.AmountOC,
                            BankId = buTransferDetailParallelDebit2.BankId,
                            BudgetChapterCode = buTransferDetailParallelDebit2.BudgetChapterCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit2.BudgetDetailItemCode,
                            BudgetItemCode = buTransferDetailParallelDebit2.BudgetItemCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit2.BudgetKindItemCode,
                            BudgetSourceId = buTransferDetailParallelDebit2.BudgetSourceId,
                            BudgetSubItemCode = buTransferDetailParallelDebit2.BudgetSubItemCode,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit2.BudgetSubKindItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit2.CashWithdrawTypeId,
                            CreditAccount = buTransferDetailParallelDebit2.CreditAccount,
                            DebitAccount = buTransferDetailParallelDebit2.DebitAccount,
                            Description = buTransferDetailParallelDebit2.Description,
                            FundStructureId = buTransferDetailParallelDebit2.FundStructureId,
                            MethodDistributeId = buTransferDetailParallelDebit2.MethodDistributeId,
                            JournalMemo = bUTransfer.JournalMemo,
                            ProjectId = buTransferDetailParallelDebit2.ProjectId,
                            ToBankId = buTransferDetailParallelDebit2.BankId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            PostedDate = bUTransfer.PostedDate,
                            BudgetExpenseId = buTransferDetailParallelDebit2.BudgetExpenseId
                        };
                        response.Message =
                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity1);
                        response.Message =
                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity2);
                    }
                    #endregion
                    #region sinh bút toán đồng thời cho thu hồi tạm ứng năm trước
                    // debit  
                    if (buTransferDetailEntity.OldAdvanceRecovery != 0)
                    {
                        var buTransferDetailParallelDebit = new BUTransferDetailParallelEntity()
                        {
                            RefId = bUTransfer.RefId,
                            RefDetailId = Guid.NewGuid().ToString(),
                            Description = buTransferDetailEntity.Description,
                            CreditAccount = "00911",
                            DebitAccount = null,
                            Amount = -buTransferDetailEntity.OldAdvanceRecovery,
                            AmountOC = -buTransferDetailEntity.OldAdvanceRecovery,
                            BudgetSourceId =
                         buTransferDetailEntity.BudgetSourceId,
                            BudgetChapterCode =
                         buTransferDetailEntity.BudgetChapterCode,
                            BudgetKindItemCode =
                         buTransferDetailEntity.BudgetKindItemCode,
                            BudgetSubKindItemCode =
                         buTransferDetailEntity.BudgetSubKindItemCode,
                            BudgetItemCode =
                         buTransferDetailEntity.BudgetItemCode,
                            BudgetSubItemCode =
                         buTransferDetailEntity.BudgetSubItemCode,
                            MethodDistributeId =
                         buTransferDetailEntity.MethodDistributeId,
                            CashWithdrawTypeId =
                         buTransferDetailEntity.CashWithDrawTypeId,
                            AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                            ActivityId = buTransferDetailEntity.ActivityId,
                            ProjectId = buTransferDetailEntity.ProjectId,
                            ListItemId = buTransferDetailEntity.ListItemId,
                            BankId = buTransferDetailEntity.BankId,
                            Approved = true,
                            SortOrder = sortOrder + 3,
                            FundStructureId = buTransferDetailEntity.FundStructureId,
                            BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId,
                            ContractId = buTransferDetailEntity.ContractId,
                            CapitalPlanId = buTransferDetailEntity.CapitalPlanId,
                            AdvanceRecovery = buTransferDetailEntity.AdvanceRecovery
                        };
                        var buTransferDetailParallelDebit2 = new BUTransferDetailParallelEntity()
                        {
                            RefId = bUTransfer.RefId,
                            RefDetailId = Guid.NewGuid().ToString(),
                            Description = buTransferDetailEntity.Description,
                            CreditAccount = "00912",
                            DebitAccount = null,
                            Amount = buTransferDetailEntity.OldAdvanceRecovery,
                            AmountOC = buTransferDetailEntity.OldAdvanceRecovery,
                            BudgetSourceId =
                              buTransferDetailEntity.BudgetSourceId,
                            BudgetChapterCode =
                              buTransferDetailEntity.BudgetChapterCode,
                            BudgetKindItemCode =
                              buTransferDetailEntity.BudgetKindItemCode,
                            BudgetSubKindItemCode =
                              buTransferDetailEntity.BudgetSubKindItemCode,
                            BudgetItemCode =
                              buTransferDetailEntity.BudgetItemCode,
                            BudgetSubItemCode =
                              buTransferDetailEntity.BudgetSubItemCode,
                            MethodDistributeId =
                              buTransferDetailEntity.MethodDistributeId,
                            CashWithdrawTypeId =
                              buTransferDetailEntity.CashWithDrawTypeId,
                            AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                            ActivityId = buTransferDetailEntity.ActivityId,
                            ProjectId = buTransferDetailEntity.ProjectId,
                            ListItemId = buTransferDetailEntity.ListItemId,
                            BankId = buTransferDetailEntity.BankId,
                            Approved = true,
                            SortOrder = sortOrder + 4,
                            FundStructureId = buTransferDetailEntity.FundStructureId,
                            BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId,
                            ContractId = buTransferDetailEntity.ContractId,
                            CapitalPlanId = buTransferDetailEntity.CapitalPlanId,
                            AdvanceRecovery = buTransferDetailEntity.AdvanceRecovery,
                        };
                        response.Message =
                    BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallelDebit);
                        response.Message =
                          BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallelDebit2);
                        var generalLedgerEntity1 = new GeneralLedgerEntity
                        {
                            RefType = bUTransfer.RefType,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = bUTransfer.AccountingObjectId,
                            BudgetChapterCode = buTransferDetailParallelDebit.BudgetChapterCode,
                            ProjectId = buTransferDetailParallelDebit.ProjectId,
                            BudgetSourceId = buTransferDetailParallelDebit.BudgetSourceId,
                            Description = buTransferDetailParallelDebit.Description,
                            RefDetailId = buTransferDetailParallelDebit.RefDetailId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            ActivityId = buTransferDetailParallelDebit.ActivityId,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit.BudgetSubKindItemCode,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit.BudgetKindItemCode,
                            RefId = bUTransfer.RefId,
                            PostedDate = bUTransfer.PostedDate,
                            MethodDistributeId = buTransferDetailParallelDebit.MethodDistributeId,
                            OrgRefNo = buTransferDetailParallelDebit.OrgRefNo,
                            OrgRefDate = buTransferDetailParallelDebit.OrgRefDate,
                            BudgetItemCode = buTransferDetailParallelDebit.BudgetItemCode,
                            ListItemId = buTransferDetailParallelDebit.ListItemId,
                            BudgetSubItemCode = buTransferDetailParallelDebit.BudgetSubItemCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit.BudgetDetailItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit.CashWithdrawTypeId,
                            AccountNumber =
             buTransferDetailParallelDebit.DebitAccount ?? buTransferDetailParallelDebit.CreditAccount,
                            DebitAmount =
             buTransferDetailParallelDebit.DebitAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.Amount,
                            DebitAmountOC =
             buTransferDetailParallelDebit.DebitAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.AmountOC,
                            CreditAmount =
             buTransferDetailParallelDebit.CreditAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.Amount,
                            CreditAmountOC =
             buTransferDetailParallelDebit.CreditAccount == null
                 ? 0
                 : buTransferDetailParallelDebit.AmountOC,
                            FundStructureId = buTransferDetailParallelDebit.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = bUTransfer.JournalMemo,
                            RefDate = bUTransfer.RefDate,
                            BankId = buTransferDetailParallelDebit.BankId,
                            BudgetExpenseId = buTransferDetailParallelDebit.BudgetExpenseId
                        };
                        var generalLedgerEntity2 = new GeneralLedgerEntity
                        {
                            RefType = bUTransfer.RefType,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = bUTransfer.AccountingObjectId,
                            BudgetChapterCode = buTransferDetailParallelDebit2.BudgetChapterCode,
                            ProjectId = buTransferDetailParallelDebit2.ProjectId,
                            BudgetSourceId = buTransferDetailParallelDebit2.BudgetSourceId,
                            Description = buTransferDetailParallelDebit2.Description,
                            RefDetailId = buTransferDetailParallelDebit2.RefDetailId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            ActivityId = buTransferDetailParallelDebit2.ActivityId,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit2.BudgetSubKindItemCode,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit2.BudgetKindItemCode,
                            RefId = bUTransfer.RefId,
                            PostedDate = bUTransfer.PostedDate,
                            MethodDistributeId = buTransferDetailParallelDebit2.MethodDistributeId,
                            OrgRefNo = buTransferDetailParallelDebit2.OrgRefNo,
                            OrgRefDate = buTransferDetailParallelDebit2.OrgRefDate,
                            BudgetItemCode = buTransferDetailParallelDebit2.BudgetItemCode,
                            ListItemId = buTransferDetailParallelDebit2.ListItemId,
                            BudgetSubItemCode = buTransferDetailParallelDebit2.BudgetSubItemCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit2.BudgetDetailItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit2.CashWithdrawTypeId,
                            AccountNumber =
                             buTransferDetailParallelDebit2.DebitAccount ?? buTransferDetailParallelDebit2.CreditAccount,
                            DebitAmount =
                             buTransferDetailParallelDebit2.DebitAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.Amount,
                            DebitAmountOC =
                             buTransferDetailParallelDebit2.DebitAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.AmountOC,
                            CreditAmount =
                             buTransferDetailParallelDebit2.CreditAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.Amount,
                            CreditAmountOC =
                             buTransferDetailParallelDebit2.CreditAccount == null
                                 ? 0
                                 : buTransferDetailParallelDebit2.AmountOC,
                            FundStructureId = buTransferDetailParallelDebit2.FundStructureId,
                            GeneralLedgerId = Guid.NewGuid().ToString(),
                            JournalMemo = bUTransfer.JournalMemo,
                            RefDate = bUTransfer.RefDate,
                            BankId = buTransferDetailParallelDebit2.BankId,
                            BudgetExpenseId = buTransferDetailParallelDebit2.BudgetExpenseId
                        };

                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity1);
                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity2);
                        var originalGeneralLedgerEntity1 = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUTransfer.RefType,
                            RefId = bUTransfer.RefId,
                            RefDetailId = buTransferDetailParallelDebit.RefDetailId,
                            OrgRefDate = buTransferDetailParallelDebit.OrgRefDate,
                            OrgRefNo = buTransferDetailParallelDebit.OrgRefNo,
                            RefDate = bUTransfer.RefDate,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = buTransferDetailParallelDebit.AccountingObjectId,
                            ActivityId = buTransferDetailParallelDebit.ActivityId,
                            Amount = buTransferDetailParallelDebit.Amount,
                            AmountOC = buTransferDetailParallelDebit.AmountOC,
                            BankId = buTransferDetailParallelDebit.BankId,
                            BudgetChapterCode = buTransferDetailParallelDebit.BudgetChapterCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit.BudgetDetailItemCode,
                            BudgetItemCode = buTransferDetailParallelDebit.BudgetItemCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit.BudgetKindItemCode,
                            BudgetSourceId = buTransferDetailParallelDebit.BudgetSourceId,
                            BudgetSubItemCode = buTransferDetailParallelDebit.BudgetSubItemCode,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit.BudgetSubKindItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit.CashWithdrawTypeId,
                            CreditAccount = buTransferDetailParallelDebit.CreditAccount,
                            DebitAccount = buTransferDetailParallelDebit.DebitAccount,
                            Description = buTransferDetailParallelDebit.Description,
                            FundStructureId = buTransferDetailParallelDebit.FundStructureId,
                            MethodDistributeId = buTransferDetailParallelDebit.MethodDistributeId,
                            JournalMemo = bUTransfer.JournalMemo,
                            ProjectId = buTransferDetailParallelDebit.ProjectId,
                            ToBankId = buTransferDetailParallelDebit.BankId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            PostedDate = bUTransfer.PostedDate,
                            BudgetExpenseId = buTransferDetailParallelDebit.BudgetExpenseId
                        };
                        var originalGeneralLedgerEntity2 = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUTransfer.RefType,
                            RefId = bUTransfer.RefId,
                            RefDetailId = buTransferDetailParallelDebit2.RefDetailId,
                            OrgRefDate = buTransferDetailParallelDebit2.OrgRefDate,
                            OrgRefNo = buTransferDetailParallelDebit2.OrgRefNo,
                            RefDate = bUTransfer.RefDate,
                            RefNo = bUTransfer.RefNo,
                            AccountingObjectId = buTransferDetailParallelDebit2.AccountingObjectId,
                            ActivityId = buTransferDetailParallelDebit2.ActivityId,
                            Amount = buTransferDetailParallelDebit2.Amount,
                            AmountOC = buTransferDetailParallelDebit2.AmountOC,
                            BankId = buTransferDetailParallelDebit2.BankId,
                            BudgetChapterCode = buTransferDetailParallelDebit2.BudgetChapterCode,
                            BudgetDetailItemCode = buTransferDetailParallelDebit2.BudgetDetailItemCode,
                            BudgetItemCode = buTransferDetailParallelDebit2.BudgetItemCode,
                            BudgetKindItemCode = buTransferDetailParallelDebit2.BudgetKindItemCode,
                            BudgetSourceId = buTransferDetailParallelDebit2.BudgetSourceId,
                            BudgetSubItemCode = buTransferDetailParallelDebit2.BudgetSubItemCode,
                            BudgetSubKindItemCode = buTransferDetailParallelDebit2.BudgetSubKindItemCode,
                            CashWithDrawTypeId = buTransferDetailParallelDebit2.CashWithdrawTypeId,
                            CreditAccount = buTransferDetailParallelDebit2.CreditAccount,
                            DebitAccount = buTransferDetailParallelDebit2.DebitAccount,
                            Description = buTransferDetailParallelDebit2.Description,
                            FundStructureId = buTransferDetailParallelDebit2.FundStructureId,
                            MethodDistributeId = buTransferDetailParallelDebit2.MethodDistributeId,
                            JournalMemo = bUTransfer.JournalMemo,
                            ProjectId = buTransferDetailParallelDebit2.ProjectId,
                            ToBankId = buTransferDetailParallelDebit2.BankId,
                            ExchangeRate = bUTransfer.ExchangeRate,
                            CurrencyCode = bUTransfer.CurrencyCode,
                            PostedDate = bUTransfer.PostedDate,
                            BudgetExpenseId = buTransferDetailParallelDebit2.BudgetExpenseId
                        };
                        response.Message =
                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity1);
                        response.Message =
                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity2);
                    }
                    #endregion
                }
            }
            #endregion

            #region BUTransferDetailPurchases
            if (insertParallelBy.Equals(InsertParallelBy.Purchases) && bUTransfer.BUTransferDetailPurchases != null && bUTransfer.BUTransferDetailPurchases.Count > 0)
            {
                foreach (BUTransferDetailPurchaseEntity buTransferDetailEntity in bUTransfer.BUTransferDetailPurchases)
                {
                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                                 buTransferDetailEntity.DebitAccount, buTransferDetailEntity.CreditAccount,
                                                 buTransferDetailEntity.BudgetSourceId, buTransferDetailEntity.BudgetChapterCode,
                                                 string.Empty, buTransferDetailEntity.BudgetSubKindItemCode,
                                                 buTransferDetailEntity.BudgetItemCode, buTransferDetailEntity.BudgetSubItemCode,
                                                 buTransferDetailEntity.MethodDistributeId, buTransferDetailEntity.CashWithdrawTypeId);


                    if (autoBusinessParallelEntitys != null)
                    {
                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                        {
                            #region Pararrel

                            var buTransferDetailParallel = new BUTransferDetailParallelEntity()
                            {
                                RefId = bUTransfer.RefId,
                                RefDetailId = Guid.NewGuid().ToString(),
                                Description = buTransferDetailEntity.Description,
                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                Amount = buTransferDetailEntity.Amount * bUTransfer.ExchangeRate,
                                AmountOC = buTransferDetailEntity.Amount,
                                BudgetSourceId =
                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                    buTransferDetailEntity.BudgetSourceId,
                                BudgetChapterCode =
                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                    buTransferDetailEntity.BudgetChapterCode,
                                BudgetKindItemCode =
                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                    buTransferDetailEntity.BudgetKindItemCode, //string.Empty,
                                BudgetSubKindItemCode =
                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubKindItemCode,
                                BudgetItemCode =
                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                    buTransferDetailEntity.BudgetItemCode,
                                BudgetSubItemCode =
                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubItemCode,
                                MethodDistributeId =
                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                    buTransferDetailEntity.MethodDistributeId,
                                CashWithdrawTypeId =
                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                    buTransferDetailEntity.CashWithdrawTypeId,
                                AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                                ActivityId = buTransferDetailEntity.ActivityId,
                                ProjectId = buTransferDetailEntity.ProjectId,
                                ListItemId = string.Empty,
                                Approved = true,
                                SortOrder = buTransferDetailEntity.SortOrder,
                                FundStructureId = string.Empty,
                                BankId = buTransferDetailEntity.BankId,
                                BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId
                            };

                            response.Message =
                                BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert General Ledger Entity

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = bUTransfer.AccountingObjectId,
                                BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                ProjectId = buTransferDetailParallel.ProjectId,
                                BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                Description = buTransferDetailParallel.Description,
                                RefDetailId = buTransferDetailParallel.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = buTransferDetailParallel.ActivityId,
                                BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                ListItemId = buTransferDetailParallel.ListItemId,
                                BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                AccountNumber =
                                    buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                DebitAmount =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                DebitAmountOC =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                CreditAmount =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                CreditAmountOC =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                FundStructureId = buTransferDetailParallel.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BankId = buTransferDetailEntity.BankId,
                                SortOrder = buTransferDetailParallel.SortOrder,
                                BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                            };

                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = buTransferDetailParallel.RefDetailId,
                                OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                ActivityId = buTransferDetailParallel.ActivityId,
                                Amount = buTransferDetailParallel.Amount,
                                AmountOC = buTransferDetailParallel.AmountOC,
                                BankId = buTransferDetailParallel.BankId,
                                BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                CreditAccount = buTransferDetailParallel.CreditAccount,
                                DebitAccount = buTransferDetailParallel.DebitAccount,
                                Description = buTransferDetailParallel.Description,
                                FundStructureId = buTransferDetailParallel.FundStructureId,
                                MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = buTransferDetailParallel.ProjectId,
                                ToBankId = buTransferDetailParallel.BankId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                PostedDate = bUTransfer.PostedDate,
                                SortOrder = buTransferDetailParallel.SortOrder,
                                BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                            };
                            response.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
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
            #endregion

            #region BUTransferDetailFixedAssets
            if (insertParallelBy.Equals(InsertParallelBy.FixedAssets) && bUTransfer.BUTransferDetailFixedAssets != null && bUTransfer.BUTransferDetailFixedAssets.Count > 0)
            {
                foreach (BUTransferDetailFixedAssetEntity buTransferDetailEntity in bUTransfer.BUTransferDetailFixedAssets)
                {
                    var autoBusinessParallelEntitys = new List<AutoBusinessParallelEntity>();
                    if (bUTransfer.Parallels != null && bUTransfer.Parallels.Count > 0)
                    {
                        bUTransfer.Parallels.ForEach(panal =>
                        {
                            var autoBusinessParallelEntity = new AutoBusinessParallelEntity()
                            {
                                DebitAccountParallel = panal.Debit,
                                CreditAccountParallel = panal.Credit
                            };
                            autoBusinessParallelEntitys.Add(autoBusinessParallelEntity);
                        });
                    }
                    else
                    {
                        autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                                   buTransferDetailEntity.DebitAccount, buTransferDetailEntity.CreditAccount,
                                                   buTransferDetailEntity.BudgetSourceId, buTransferDetailEntity.BudgetChapterCode,
                                                   string.Empty, buTransferDetailEntity.BudgetSubKindItemCode,
                                                   buTransferDetailEntity.BudgetItemCode, buTransferDetailEntity.BudgetSubItemCode,
                                                   buTransferDetailEntity.MethodDistributeId, buTransferDetailEntity.CashWithdrawTypeId);
                    }
                    if (autoBusinessParallelEntitys != null)
                    {
                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                        {
                            #region Pararrel

                            var buTransferDetailParallel = new BUTransferDetailParallelEntity()
                            {
                                RefId = bUTransfer.RefId,
                                RefDetailId = Guid.NewGuid().ToString(),
                                Description = buTransferDetailEntity.Description,
                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                Amount = buTransferDetailEntity.Amount * bUTransfer.ExchangeRate,
                                AmountOC = buTransferDetailEntity.Amount,
                                BudgetSourceId =
                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                    buTransferDetailEntity.BudgetSourceId,
                                BudgetChapterCode =
                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                    buTransferDetailEntity.BudgetChapterCode,
                                BudgetKindItemCode = buTransferDetailEntity.BudgetKindItemCode,
                                BudgetSubKindItemCode =
                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubKindItemCode,
                                BudgetItemCode =
                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                    buTransferDetailEntity.BudgetItemCode,
                                BudgetSubItemCode =
                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                    buTransferDetailEntity.BudgetSubItemCode,
                                MethodDistributeId =
                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                    buTransferDetailEntity.MethodDistributeId,
                                CashWithdrawTypeId =
                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                    buTransferDetailEntity.CashWithdrawTypeId,
                                AccountingObjectId = buTransferDetailEntity.AccountingObjectId,
                                ActivityId = buTransferDetailEntity.ActivityId,
                                ProjectId = buTransferDetailEntity.ProjectId,
                                ListItemId = string.Empty,
                                Approved = true,
                                SortOrder = buTransferDetailEntity.SortOrder,
                                FundStructureId = string.Empty,
                                BankId = buTransferDetailEntity.BankId,
                                BudgetExpenseId = buTransferDetailEntity.BudgetExpenseId
                            };

                            response.Message =
                                BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert General Ledger Entity

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = bUTransfer.AccountingObjectId,
                                BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                ProjectId = buTransferDetailParallel.ProjectId,
                                BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                Description = buTransferDetailParallel.Description,
                                RefDetailId = buTransferDetailParallel.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = buTransferDetailParallel.ActivityId,
                                BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                ListItemId = buTransferDetailParallel.ListItemId,
                                BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                AccountNumber =
                                    buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                DebitAmount =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                DebitAmountOC =
                                    buTransferDetailParallel.DebitAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                CreditAmount =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.Amount,
                                CreditAmountOC =
                                    buTransferDetailParallel.CreditAccount == null
                                        ? 0
                                        : buTransferDetailParallel.AmountOC,
                                FundStructureId = buTransferDetailParallel.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BankId = buTransferDetailParallel.BankId,
                                SortOrder = buTransferDetailParallel.SortOrder,
                                BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                            };

                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = buTransferDetailParallel.RefDetailId,
                                OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                ActivityId = buTransferDetailParallel.ActivityId,
                                Amount = buTransferDetailParallel.Amount,
                                AmountOC = buTransferDetailParallel.AmountOC,
                                BankId = buTransferDetailParallel.BankId,
                                BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                CreditAccount = buTransferDetailParallel.CreditAccount,
                                DebitAccount = buTransferDetailParallel.DebitAccount,
                                Description = buTransferDetailParallel.Description,
                                FundStructureId = buTransferDetailParallel.FundStructureId,
                                MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = buTransferDetailParallel.ProjectId,
                                ToBankId = buTransferDetailParallel.BankId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                PostedDate = bUTransfer.PostedDate,
                                SortOrder = buTransferDetailParallel.SortOrder,
                                BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId
                            };
                            response.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
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
            #endregion

            return response;
        }

        #endregion

        #region Original Ledger
        /// <summary>
        /// Delete Original Ledger
        /// </summary>
        /// <returns></returns>
        protected ResponseBase DeleteOriginalLedger(string refId)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(refId);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Delete Original Ledger by Reftype and RefNo
        /// </summary>
        /// <param name="reftype"></param>
        /// <param name="refno"></param>
        /// <returns></returns>
        protected ResponseBase DeleteOriginalLedgerByReftypeRefNo(string reftype, string refno)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedgerByRefTypeRefNo(reftype, refno);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Số dư đầu kì tài sản
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertOriginalLedger(OpeningFixedAssetEntryEntity entity)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
            {
                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                RefType = entity.RefType,
                RefId = entity.FixedAssetId,
                RefDetailId = null,
                OrgRefDate = null,
                OrgRefNo = null,
                RefDate = entity.PostedDate,
                RefNo = fixedAssetEntity.FixedAssetCode,
                AccountingObjectId = null,
                ActivityId = null,
                Amount = entity.OrgPriceDebitAmount,
                AmountOC = entity.OrgPriceDebitAmountOC,
                Approved = null,
                BankId = null,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetDetailItemCode = null,
                BudgetItemCode = null,
                BudgetKindItemCode = null,
                BudgetSourceId = null,
                BudgetSubItemCode = null,
                BudgetSubKindItemCode = null,
                CashWithDrawTypeId = null,
                CreditAccount = entity.DepreciationAccount,
                DebitAccount = entity.OrgPriceAccount,
                Description = null,
                FundStructureId = null,
                ProjectActivityId = null,
                MethodDistributeId = null,
                JournalMemo = null,
                ProjectId = null,
                ToBankId = null,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                PostedDate = entity.PostedDate,
            };
            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityMaster"></param>
        /// <returns></returns>
        protected ResponseBase InsertOriginalLedger(PUInvoiceDetailFixedAssetEntity entity, PUInvoiceEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
            {
                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                RefType = entityMaster.RefType,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                OrgRefDate = entity.OrgRefDate,
                OrgRefNo = entity.OrgRefNo,
                RefDate = entityMaster.RefDate,
                RefNo = entityMaster.RefNo,
                AccountingObjectId = entityMaster.AccountingObjectId,
                ActivityId = entity.ActivityId,
                Amount = entity.Amount,
                AmountOC = entity.Amount,
                Approved = entity.Approved,
                BankId = null,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                CreditAccount = entity.CreditAccount,
                DebitAccount = entity.DebitAccount,
                Description = entity.Description,
                FundStructureId = entity.FundStructureId,
                ProjectActivityId = entity.ProjectActivityId,
                MethodDistributeId = entity.MethodDistributeId,
                JournalMemo = entityMaster.JournalMemo,
                ProjectId = entity.ProjectId,
                ToBankId = null,
                ExchangeRate = entityMaster.ExchangeRate,
                CurrencyCode = entityMaster.CurrencyCode,
                PostedDate = entityMaster.PostedDate,
                BudgetExpenseId = entity.BudgetExpenseId
            };
            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Tăng TSCĐ nhận bằng hiện vật
        /// </summary>
        /// <returns></returns>
        protected ResponseBase InsertOriginalLedger(FAIncrementDecrementDetailEntity entity, FAIncrementDecrementEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
            {
                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                RefType = entityMaster.RefType,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                OrgRefDate = null,
                OrgRefNo = null,
                RefDate = entityMaster.RefDate,
                RefNo = entityMaster.RefNo,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                Amount = entity.Amount,
                AmountOC = entity.Amount,
                Approved = entity.Approved,
                BankId = entity.BankId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                CreditAccount = entity.CreditAccount,
                DebitAccount = entity.DebitAccount,
                Description = entity.Description,
                FundStructureId = entity.FundStructureId,
                ProjectActivityId = entity.ProjectActivityId,
                MethodDistributeId = entity.MethodDistributeId,
                JournalMemo = entityMaster.JournalMemo,
                ProjectId = entity.ProjectId,
                ToBankId = null,
                ExchangeRate = 1,
                CurrencyCode = _currencyCode,
                PostedDate = entityMaster.PostedDate,
                BudgetExpenseId = entity.BudgetExpenseId
            };
            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Mua TSCĐ bằng tiền mặt
        /// </summary>
        /// <returns></returns>
        protected ResponseBase InsertOriginalLedger(CAPaymentDetailFixedAssetEntity entity, CAPaymentEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
            {
                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                RefType = entityMaster.RefType,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                OrgRefDate = entity.OrgRefDate,
                OrgRefNo = entity.OrgRefNo,
                RefDate = entityMaster.RefDate,
                RefNo = entityMaster.RefNo,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                Approved = entity.Approved,
                BankId = entity.BankId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CashWithDrawTypeId = entity.CashWithdrawTypeId,
                CreditAccount = entity.CreditAccount,
                DebitAccount = entity.DebitAccount,
                Description = entity.Description,
                FundStructureId = entity.FundStructureId,
                ProjectActivityId = entity.ProjectActivityId,
                MethodDistributeId = entity.MethodDistributeId,
                JournalMemo = entityMaster.JournalMemo,
                ProjectId = entity.ProjectId,
                ToBankId = null,
                ExchangeRate = 1,
                CurrencyCode = _currencyCode,
                PostedDate = entityMaster.PostedDate,
            };
            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }
        #endregion

        #region General Ledger
        /// <summary>
        /// Delete General Ledger
        /// </summary>
        /// <returns></returns>
        protected ResponseBase DeleteGeneralLedger(string refId)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = GeneralLedgerDao.DeleteGeneralLedger(refId);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Số dư đầu kì tài sản
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertGeneralLedger(OpeningFixedAssetEntryEntity entity)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            // response.Message = GeneralLedgerDao.DeleteGeneralLedger(entity.FixedAssetId);

            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var generalLedgerEntity = new GeneralLedgerEntity
            {
                RefType = entity.RefType,
                RefNo = fixedAssetEntity.FixedAssetCode,
                AccountingObjectId = null,
                BankId = null,
                BudgetChapterCode = entity.BudgetChapterCode,
                ProjectId = null,
                BudgetSourceId = null,
                Description = null,
                RefDetailId = null,
                ExchangeRate = entity.ExchangeRate,
                ActivityId = null,
                BudgetSubKindItemCode = null,
                CurrencyCode = entity.CurrencyCode,
                BudgetKindItemCode = null,
                RefId = entity.FixedAssetId,
                PostedDate = entity.PostedDate,
                MethodDistributeId = null,
                OrgRefNo = null,
                OrgRefDate = null,
                BudgetItemCode = null,
                ListItemId = null,
                BudgetSubItemCode = null,
                BudgetDetailItemCode = null,
                CashWithDrawTypeId = null,
                AccountNumber = entity.OrgPriceAccount,
                CorrespondingAccountNumber = entity.DepreciationAccount,
                DebitAmount = entity.OrgPriceDebitAmount,
                DebitAmountOC = entity.OrgPriceDebitAmountOC,
                CreditAmount = 0,
                CreditAmountOC = 0,
                FundStructureId = null,
                GeneralLedgerId = Guid.NewGuid().ToString(),
                JournalMemo = null,
                RefDate = entity.PostedDate,
                SortOrder = entity.SortOrder,
            };

            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            //insert lan 2
            if (entity.DepreciationAccount != null)
            {
                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                generalLedgerEntity.AccountNumber = entity.DepreciationAccount;
                generalLedgerEntity.RefId = entity.FixedAssetId;
                generalLedgerEntity.CorrespondingAccountNumber = entity.OrgPriceAccount;
                generalLedgerEntity.DebitAmount = 0;
                generalLedgerEntity.DebitAmountOC = 0;
                generalLedgerEntity.CreditAmount = entity.OrgPriceDebitAmount;
                generalLedgerEntity.CreditAmountOC = entity.OrgPriceDebitAmountOC;
                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            }
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertGeneralLedger(PUInvoiceDetailFixedAssetEntity entity, PUInvoiceEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }



            var generalLedgerEntity = new GeneralLedgerEntity
            {
                RefType = entityMaster.RefType,
                RefNo = entityMaster.RefNo,
                AccountingObjectId = entityMaster.AccountingObjectId,
                BankId = null,
                BudgetChapterCode = entity.BudgetChapterCode,
                ProjectId = entity.ProjectId,
                BudgetSourceId = entity.BudgetSourceId,
                Description = entity.Description,
                RefDetailId = entity.RefDetailId,
                ExchangeRate = entityMaster.ExchangeRate,
                ActivityId = entity.ActivityId,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CurrencyCode = entityMaster.CurrencyCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                RefId = entityMaster.RefId,
                PostedDate = entityMaster.PostedDate,
                MethodDistributeId = entity.MethodDistributeId,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate,
                BudgetItemCode = entity.BudgetItemCode,
                ListItemId = null,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountNumber = entity.DebitAccount,
                CorrespondingAccountNumber = entity.CreditAccount,
                DebitAmount = entity.Amount,
                DebitAmountOC = entity.Amount,
                CreditAmount = 0,
                CreditAmountOC = 0,
                FundStructureId = entity.FundStructureId,
                GeneralLedgerId = Guid.NewGuid().ToString(),
                JournalMemo = entityMaster.JournalMemo,
                RefDate = entityMaster.RefDate,
                SortOrder = entity.SortOrder,
                BudgetExpenseId = entity.BudgetExpenseId
            };

            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            //insert lan 2
            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
            generalLedgerEntity.AccountNumber = entity.CreditAccount;
            generalLedgerEntity.CorrespondingAccountNumber = entity.DebitAccount;
            generalLedgerEntity.DebitAmount = 0;
            generalLedgerEntity.DebitAmountOC = 0;
            generalLedgerEntity.CreditAmount = entity.Amount;
            generalLedgerEntity.CreditAmountOC = entity.Amount;
            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Tăng TSCĐ nhận bằng hiện vật
        /// </summary>
        /// <returns></returns>
        protected ResponseBase InsertGeneralLedger(FAIncrementDecrementDetailEntity entity, FAIncrementDecrementEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var generalLedgerEntity = new GeneralLedgerEntity
            {
                RefType = entityMaster.RefType,
                RefNo = entityMaster.RefNo,
                AccountingObjectId = entity.AccountingObjectId,
                BankId = entity.BankId,
                BudgetChapterCode = entity.BudgetChapterCode,
                ProjectId = entity.ProjectId,
                BudgetSourceId = entity.BudgetSourceId,
                Description = entity.Description,
                RefDetailId = entity.RefDetailId,
                ExchangeRate = 1,
                ActivityId = entity.ActivityId,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CurrencyCode = _currencyCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                RefId = entityMaster.RefId,
                PostedDate = entityMaster.PostedDate,
                MethodDistributeId = entity.MethodDistributeId,
                OrgRefNo = null,
                OrgRefDate = null,
                BudgetItemCode = entity.BudgetItemCode,
                ListItemId = null,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountNumber = entity.DebitAccount,
                CorrespondingAccountNumber = entity.CreditAccount,
                DebitAmount = entity.Amount,
                DebitAmountOC = entity.Amount,
                CreditAmount = 0,
                CreditAmountOC = 0,
                FundStructureId = entity.FundStructureId,
                GeneralLedgerId = Guid.NewGuid().ToString(),
                JournalMemo = entityMaster.JournalMemo,
                RefDate = entityMaster.RefDate,
                SortOrder = entity.SortOrder,
                BudgetExpenseId = entity.BudgetExpenseId,
            };

            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            //insert lan 2
            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
            generalLedgerEntity.AccountNumber = entity.CreditAccount;
            generalLedgerEntity.CorrespondingAccountNumber = entity.DebitAccount;
            generalLedgerEntity.DebitAmount = 0;
            generalLedgerEntity.DebitAmountOC = 0;
            generalLedgerEntity.CreditAmount = entity.Amount;
            generalLedgerEntity.CreditAmountOC = entity.Amount;
            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }
        #endregion

        #region FixAsset Ledger
        /// <summary>
        /// Delete FixedAsset
        /// </summary>
        /// <returns></returns>
        protected ResponseBase DeleteFixAssetLedger(string refId, int refType)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(refId, refType);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// DeleteFixAssetLedger603
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        protected ResponseBase DeleteFixAssetLedger603(string fixedassetId, int refType)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByFixedAssetId(fixedassetId, refType);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Số dư đầu kì tài sản
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertFixAssetLedger(OpeningFixedAssetEntryEntity entity)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = Guid.NewGuid().ToString(),
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefNo = fixedAssetEntity.FixedAssetCode,
                RefDate = entity.PostedDate,
                PostedDate = entity.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = fixedAssetEntity.LifeTime,
                AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                OrgPriceAccount = entity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.OrgPriceDebitAmount,
                OrgPriceCreditAmount = 0,
                DepreciationAccount = entity.DepreciationAccount,
                DepreciationDebitAmount = 0,
                DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                CapitalAccount = null,
                CapitalDebitAmount = 0,
                CapitalCreditAmount = 0,
                JournalMemo = null,
                Description = null,
                RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                EndYear = fixedAssetEntity.EndYear,
                DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                Quantity = fixedAssetEntity.Quantity,
            };
            response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertFixAssetLedger(PUInvoiceDetailFixedAssetEntity entity, PUInvoiceEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = Guid.NewGuid().ToString(),
                RefId = entityMaster.RefId,
                RefType = entityMaster.RefType,
                RefNo = entityMaster.RefNo,
                RefDate = entityMaster.RefDate,
                PostedDate = entityMaster.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = fixedAssetEntity.LifeTime,
                AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                OrgPriceAccount = fixedAssetEntity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.Amount,
                OrgPriceCreditAmount = 0,
                DepreciationAccount = null,
                DepreciationDebitAmount = 0,
                DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                CapitalAccount = null,
                CapitalDebitAmount = 0,
                CapitalCreditAmount = 0,
                JournalMemo = entityMaster.JournalMemo,
                Description = entity.Description,
                RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                EndYear = fixedAssetEntity.EndYear,
                DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                Quantity = fixedAssetEntity.Quantity,
            };
            response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Tăng TSCĐ nhận bằng hiện vật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertFixAssetLedger(FAIncrementDecrementDetailEntity entity, FAIncrementDecrementEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = Guid.NewGuid().ToString(),
                RefId = entityMaster.RefId,
                RefType = entityMaster.RefType,
                RefNo = entityMaster.RefNo,
                RefDate = entityMaster.RefDate,
                PostedDate = entityMaster.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = fixedAssetEntity.LifeTime,
                AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                OrgPriceAccount = fixedAssetEntity.OrgPriceAccount,
                OrgPriceDebitAmount = 0,
                OrgPriceCreditAmount = entity.Amount,//AnhNT
                DepreciationAccount = null,
                DepreciationDebitAmount = 0,
                DepreciationCreditAmount = entity.Amount,
                // DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                CapitalAccount = null,
                CapitalDebitAmount = 0,
                CapitalCreditAmount = 0,
                Quantity = fixedAssetEntity.Quantity * (entityMaster.RefType == (int)BuCA.Enum.RefType.FAIncrementDecrement ? 1 : -1), // dùng chung với ghi giảm
                JournalMemo = entityMaster.JournalMemo,
                Description = entity.Description,
                RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                EndYear = fixedAssetEntity.EndYear,
                DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                DecreaseReasonId = Convert.ToInt32(entity.DecreaseReasonId),
            };

            response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        /// <summary>
        /// Mua TSCĐ nhận bằng tiền gửi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected ResponseBase InsertFixAssetLedger(BAWithDrawDetailFixedAssetEntity entity, BAWithDrawEntity entityMaster)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(entity.FixedAssetId);
            if (fixedAssetEntity == null)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }

            var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = Guid.NewGuid().ToString(),
                RefId = entityMaster.RefId,
                RefType = entityMaster.RefType,
                RefNo = entityMaster.RefNo,
                RefDate = entityMaster.RefDate,
                PostedDate = entityMaster.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = fixedAssetEntity.LifeTime,
                AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                OrgPriceAccount = fixedAssetEntity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.Amount,
                OrgPriceCreditAmount = 0,
                DepreciationAccount = null,
                DepreciationDebitAmount = 0,
                DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                CapitalAccount = null,
                CapitalDebitAmount = 0,
                CapitalCreditAmount = 0,
                Quantity = fixedAssetEntity.Quantity,
                JournalMemo = entityMaster.JournalMemo,
                Description = entity.Description,
                RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                EndYear = fixedAssetEntity.EndYear,
                DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                DecreaseReasonId = 0,
            };

            response.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }
        #endregion

        /// <summary>
        /// Delete Opening Fixed Asset Entry
        /// </summary>
        /// <param name="fixedAssetId"></param>
        /// <returns></returns>
        protected ResponseBase DeleteOpeningFixedAssetEntry(string fixedAssetId)
        {
            var response = new ResponseBase { Acknowledge = AcknowledgeType.Success };
            response.Message = OpeningFixedAssetEntryDao.DeleteOpeningFixedAssetEntryByRefFixedAssetId(fixedAssetId);
            if (!string.IsNullOrEmpty(response.Message))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }
    }
}
