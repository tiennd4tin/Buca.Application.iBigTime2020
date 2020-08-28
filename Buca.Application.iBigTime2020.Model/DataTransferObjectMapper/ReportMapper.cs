using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.BusinessEntities.Report.SettlementReport;
using Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Settlement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;

namespace Buca.Application.iBigTime2020.Model.DataTransferObjectMapper
{
    /// <summary>
    /// Class ReportMapper.
    /// </summary>
    static class ReportMapper
    {
        static ReportMapper()
        {
            AutoMapper.Mapper.CreateMap<S05HModel, S05HEntity>();
            AutoMapper.Mapper.CreateMap<S05HEntity, S05HModel>();
            AutoMapper.Mapper.CreateMap<B01BCQTModel, B01BCQTEntity>();
            AutoMapper.Mapper.CreateMap<B01BCQTEntity, B01BCQTModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetS24HModel, FixedAssetS24HEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetS24HEntity, FixedAssetS24HModel>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCModel, ReportB04BCTCEntity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCEntity, ReportB04BCTCModel>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail01Model, ReportB04BCTCDetail01Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail01Entity, ReportB04BCTCDetail01Model>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail02Model, ReportB04BCTCDetail02Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail02Entity, ReportB04BCTCDetail02Model>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail03Model, ReportB04BCTCDetail03Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail03Entity, ReportB04BCTCDetail03Model>();
            AutoMapper.Mapper.CreateMap<ReportDataTemplateModel, ReportDataTemplateEntity>();
            AutoMapper.Mapper.CreateMap<ReportDataTemplateEntity, ReportDataTemplateModel>();

        }
        #region FromDataTransferObject

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetDecreaseModel FromDataTransferObject(FixedAssetDecreaseEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetDecreaseModel
            {
                OrgPrice = entity.OrgPrice,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                SerialNumber = entity.SerialNumber,
                MadeIn = entity.MadeIn,
                RemainingAmount = entity.RemainingAmount,
                Unit = entity.Unit,
                Volume = entity.Volume,
                ProductionYear = entity.ProductionYear,
                RemainingRate = entity.RemainingRate,
                UsedDate = entity.UsedDate,
                Quantity = entity.Quantity
            };
        }
        internal static IList<ReportB04BCTCModel> FromDataTransferObjects(IList<ReportB04BCTCEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB04BCTCEntity>, IList<ReportB04BCTCModel>>(entities);
        }

        internal static FixedAssetIncreaseDecreaseModel FromDataTransferObject(FixedAssetIncreaseDecreaseEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetIncreaseDecreaseModel
            {
                DepartmentId = entity.DepartmentId,
                DepartmentName = entity.DepartmentName,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                OpenQty = entity.OpenQty,
                OpenAmount = entity.OpenAmount,
                InwardQty = entity.InwardQty,
                InwardAmount = entity.InwardAmount,
                OutwardQty = entity.OutwardQty,
                OutwardAmount = entity.OutwardAmount,
                FixedAssetCode = entity.FixedAssetCode,
                IsFixedAsset = entity.IsFixedAsset
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InventoryFixedAssetModel FromDataTransferObject(InventoryFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new InventoryFixedAssetModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                BookQuantity = entity.BookQuantity,
                DepartmentCode = entity.DepartmentCode,
                DepartmentName = entity.DepartmentName,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                MadeIn = entity.MadeIn,
                OrgPrice = entity.OrgPrice,
                PostedDate = entity.PostedDate,
                SerialNumber = entity.SerialNumber,
                ToDate = entity.ToDate,
                UserDate = entity.UserDate,
                ReportItemIndex = entity.ReportItemIndex
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>MinutesGetCountFixedAssetModel.</returns>
        internal static MinutesGetCountFixedAssetModel FromDataTransferObject(MinutesGetCountFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new MinutesGetCountFixedAssetModel
            {
                FixedAssetCategoryName = string.IsNullOrEmpty(entity.FixedAssetCategoryName) ? "" : entity.FixedAssetCategoryName,
                FixedAssetCategoryCode = string.IsNullOrEmpty(entity.FixedAssetCategoryCode) ? "" : entity.FixedAssetCategoryCode,
                FixedAssetCategoryId = string.IsNullOrEmpty(entity.FixedAssetCategoryId) ? "" : entity.FixedAssetCategoryId,
                SumFixedAssetCategory = entity.SumFixedAssetCategory,
                ToDate = entity.ToDate,
                MadeIn = entity.MadeIn,
                DepartmentCode = entity.DepartmentCode,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                UsedDate = entity.UsedDate,
                RemainingAmount = entity.RemainingAmount,
                OrgPrice = entity.OrgPrice,
                SerialNumber = entity.SerialNumber,
                FixedAssetId = entity.FixedAssetId,
                DepartmentName = entity.DepartmentName,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                BookQuantity = entity.BookQuantity
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB03HModel FromDataTransferObject(FixedAssetB03HEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetB03HModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                ParentId = entity.ParentId,
                Unit = entity.Unit,
                QuantityOpening = entity.QuantityOpening,
                QuantityIncrement = entity.QuantityIncrement,
                QuantityDecrement = entity.QuantityDecrement,
                QuantityClosing = entity.QuantityClosing,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOpeningUSD = entity.OrgPriceOpeningUSD,
                OrgPriceOpeningCurrencyUSD = entity.OrgPriceOpeningCurrencyUSD,
                TotalOrgPriceOpeningUSD = entity.TotalOrgPriceOpeningUSD,
                OrgPriceIncrement = entity.OrgPriceIncrement,
                OrgPriceIncrementUSD = entity.OrgPriceIncrementUSD,
                OrgPriceIncrementCurrencyUSD = entity.OrgPriceIncrementCurrencyUSD,
                TotalOrgPriceIncrementUSD = entity.TotalOrgPriceIncrementUSD,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementUSD = entity.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = entity.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = entity.TotalOrgPriceDecrementUSD,
                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceClosingUSD = entity.OrgPriceClosingUSD,
                OrgPriceClosingCurrencyUSD = entity.OrgPriceClosingCurrencyUSD,
                TotalOrgPriceClosingUSD = entity.TotalOrgPriceClosingUSD,
                Grade = entity.Grade,
                Sort = entity.Sort
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB01Model FromDataTransferObject(FixedAssetB01Entity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetB01Model
            {
                OrderNumber = 0,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                Description = entity.Description,
                AddressUsing = entity.AddressUsing,
                DepreciationRate = entity.DepreciationRate,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                OrgPrice = entity.OrgPrice,
                QuantityDecrement = entity.QuantityDecrement,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementUSD = entity.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = entity.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = entity.TotalOrgPriceDecrementUSD,
                QuantityAnnualDepreciation = entity.QuantityAnnualDepreciation,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD,
                AnnualDepreciationAmountCurrencyUSD = entity.AnnualDepreciationAmountCurrencyUSD,
                TotalAnnualDepreciationAmountUSD = entity.TotalAnnualDepreciationAmountUSD,
                QuantityRemainingDecrement = entity.QuantityRemainingDecrement,
                RemainingAmountDecrement = entity.RemainingAmountDecrement,
                RemainingAmountDecrementUSD = entity.RemainingAmountDecrementUSD,
                RemainingAmountDecrementCurrencyUSD = entity.RemainingAmountDecrementCurrencyUSD,
                TotalRemainingAmountDecrementUSD = entity.TotalRemainingAmountDecrementUSD,
                Grade = entity.Grade,
                Sort = entity.Sort
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetC55aHDModel FromDataTransferObject(FixedAssetC55aHDEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetC55aHDModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                YearOfUsing = entity.YearOfUsing,
                AddressUsing = entity.AddressUsing,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                QuantityOrgPrice = entity.QuantityOrgPrice,
                OrgPrice = entity.OrgPrice,
                OrgPriceUSD = entity.OrgPriceUSD,
                OrgPriceCurrencyUSD = entity.OrgPriceCurrencyUSD,
                TotalOrgPriceUSD = entity.TotalOrgPriceUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                RemainigAmount = entity.RemainigAmount,
                LifeTime = entity.LifeTime,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                QuantityDepreciation = entity.QuantityDepreciation,
                DepreciationYearAmount = entity.DepreciationYearAmount,
                DepreciationYearAmountUSD = entity.DepreciationYearAmountUSD,
                DepreciationYearAmountCurrencyUSD = entity.DepreciationYearAmountCurrencyUSD,
                TotalDepreciationYearAmountUSD = entity.TotalDepreciationYearAmountUSD
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CashInBankConfirmationBalanceSheetModel.</returns>
        internal static N02_SDKP_DVDT_TT77Model FromDataTransferObject(N02_SDKP_DVDT_TT77Entity entity)
        {
            if (entity == null)
                return null;

            return new N02_SDKP_DVDT_TT77Model
            {
                IsPrintMonth13 = entity.IsPrintMonth13,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetChapterName = entity.BudgetChapterName,
                MethodDistributeId = entity.MethodDistributeId,
                MethodDistributeIdName = entity.MethodDistributeIdName,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceCodeName = entity.BudgetSourceCodeName,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetKindItemCodeName = entity.BudgetKindItemCodeName,
                BudgetSubKindItemCodeName = entity.BudgetSubKindItemCodeName,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemCodeName = entity.BudgetItemCodeName,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubItemCodeName = entity.BudgetSubItemCodeName,
                ProjectCode = entity.ProjectCode,
                ProjectCodeName = entity.ProjectCodeName,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                Col3 = entity.Col3,
                Col4 = entity.Col4,
                Col5 = entity.Col5,
                Col6 = entity.Col6,
                ItemType = entity.ItemType,
                Part = entity.Part
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>N01_SDKP_DVDTModel.</returns>
        internal static N01_SDKP_DVDTModel FromDataTransferObject(N01_SDKP_DVDTEntity entity)
        {
            if (entity == null)
                return null;

            return new N01_SDKP_DVDTModel
            {
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                ProjectId = entity.ProjectId,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                MovementDebitAmount = entity.MovementDebitAmount,
                SumDebit = entity.SumDebit,
                SumCredit = entity.SumCredit,
                EarlySumDebit = entity.EarlySumDebit,
                Commitment = entity.Commitment,
                SumCommitment = entity.SumCommitment,
                Reserved = entity.Reserved,
                UseableAmount = entity.UseableAmount,
                RemainingAmount = entity.RemainingAmount,
                ItemType = entity.ItemType,
                Part = entity.Part
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InventoryItemReportModel FromDataTransferObject(InventoryItemReportEntity entity)
        {
            if (entity == null)
                return null;

            return new InventoryItemReportModel
            {
                OrderNumber = entity.OrderNumber,
                InventoryItemName = entity.InventoryItemName,
                Quantity = entity.Quantity,
                Price = entity.Price,
                AmountOc = entity.AmountOc,
                Unit = entity.Unit

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S23HModel.</returns>
        internal static S23HModel FromDataTransferObject(S23HEntity entity)
        {
            if (entity == null)
                return null;

            return new S23HModel
            {
                AccountNumber = entity.AccountNumber,
                InventoryCategoryId = entity.InventoryCategoryId,
                InventoryCategoryCode = entity.InventoryCategoryCode,
                InventoryCategoryName = entity.InventoryCategoryName,
                InventoryItemId = entity.InventoryItemId,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                OpeningAmount = entity.OpeningAmount,
                InwardAmount = entity.InwardAmount,
                OutwardAmount = entity.OutwardAmount,
                ClosingAmount = entity.ClosingAmount,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>FixedAssetS24HModel.</returns>
        internal static FixedAssetS24HModel FromDataTransferObject(FixedAssetS24HEntity entity)
        {
            if (entity == null)
                return null;

            return new FixedAssetS24HModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                OrgPrice = entity.OrgPrice,
                SerialNumber = entity.SerialNumber,
                MadeIn = entity.MadeIn,
                UsedDate = entity.UsedDate,
                DepartmentName = entity.DepartmentName,
                FixedAssetId = entity.FixedAssetId,
                DepartmentCode = entity.DepartmentCode,
                DecrementQuantity = entity.DecrementQuantity,
                DecrementRefDate = entity.DecrementRefDate,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                DecrementRefId = entity.DecrementRefId,
                DecrementRefNo = entity.DecrementRefNo,
                DecrementRefType = entity.DecrementRefType,
                DepartmentId = entity.DepartmentId,
                DepreciationCreditAmountLastYear = entity.DepreciationCreditAmountLastYear,
                DepreciationCreditAmountThisYear = entity.DepreciationCreditAmountThisYear,
                DevaluationCreditAmountThisYear = entity.DevaluationCreditAmountThisYear,
                DepreciationRate = entity.DepreciationRate,
                DevaluationRate = entity.DevaluationRate,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                IncrementQuantity = entity.IncrementQuantity,
                IncrementRefDate = entity.IncrementRefDate,
                IncrementRefId = entity.IncrementRefId,
                IncrementRefNo = entity.IncrementRefNo,
                IncrementRefType = entity.IncrementRefType,
                JournalMemo = entity.JournalMemo,
                PeriodDepreciationAmount = entity.PeriodDepreciationAmount,
                RemainingFixedAssetAmount = entity.RemainingFixedAssetAmount,
                SortOrder = entity.SortOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S22HModel.</returns>
        internal static S22HModel FromDataTransferObject(S22HEntity entity)
        {
            if (entity == null)
                return null;

            return new S22HModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                AccountNumber = entity.AccountNumber,
                JournalMemo = entity.JournalMemo,
                ClosingAmount = entity.ClosingAmount,
                ClosingQuantity = entity.ClosingQuantity,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemId = entity.InventoryItemId,
                InventoryItemName = entity.InventoryItemName,
                InwardAmount = entity.InwardAmount,
                InwardQuantity = entity.InwardQuantity,
                OrderType = entity.OrderType,
                OutwardAmount = entity.OutwardAmount,
                OutwardQuantity = entity.OutwardQuantity,
                RefOrder = entity.RefOrder,
                StockCode = entity.StockCode,
                StockId = entity.StockId,
                StockName = entity.StockName,
                Unit = entity.Unit,
                UnitPrice = entity.UnitPrice
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S22HModel.</returns>
        internal static S21HModel FromDataTransferObject(S21HEntity entity)
        {
            if (entity == null)
                return null;

            return new S21HModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                AccountNumber = entity.AccountNumber,
                JournalMemo = entity.JournalMemo,
                ClosingQuantity = entity.ClosingQuantity,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemId = entity.InventoryItemId,
                InventoryItemName = entity.InventoryItemName,
                InwardQuantity = entity.InwardQuantity,
                OrderType = entity.OrderType,
                OutwardQuantity = entity.OutwardQuantity,
                RefOrder = entity.RefOrder,
                StockCode = entity.StockCode,
                StockId = entity.StockId,
                StockName = entity.StockName,
                Unit = entity.Unit,
                UnitPrice = entity.UnitPrice,
                Month = entity.Month,
                FromDateInCurrentMonth = entity.FromDateInCurrentMonth,
                ToDateInCurrentMonth = entity.ToDateInCurrentMonth,
                RefTypeOrder = entity.RefTypeOrder,
                InventoryItemDescription = entity.InventoryItemDescription,
                OutwardAmount = entity.OutwardAmount,
                InwardAmount = entity.InwardAmount,
                AccumulatedIn = entity.AccumulatedIn,
                AccumulatedOut = entity.AccumulatedOut

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S26HModel.</returns>
        internal static S26HModel FromDataTransferObject(S26HEntity entity)
        {
            if (entity == null)
                return null;

            return new S26HModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                Unit = entity.Unit,
                UnitPrice = entity.UnitPrice,
                Amount = entity.Amount,
                DecrementAmount = entity.DecrementAmount,
                DecrementDescription = entity.DecrementDescription,
                DecrementQuantity = entity.DecrementQuantity,
                DecrementUnitPrice = entity.DecrementUnitPrice,
                DepartmentCode = entity.DepartmentCode,
                DepartmentName = entity.DepartmentName,
                InventoryCategoryCode = entity.InventoryCategoryCode,
                InventoryCategoryName = entity.InventoryCategoryName,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                Quantity = entity.Quantity,
                RefOrder = entity.RefOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S04HModel.</returns>
        internal static S04HModel FromDataTransferObject(S04HEntity entity)
        {
            if (entity == null)
                return null;

            return new S04HModel
            {
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSourceName = entity.BudgetSourceName,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                Posted = entity.Posted,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                JournalMemo = entity.JournalMemo,
                SortOrder = entity.SortOrder,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S05HModel.</returns>
        internal static S05HModel FromDataTransferObject(S05HEntity entity)
        {
            if (entity == null)
                return null;

            return new S05HModel
            {
                AccountNumber = entity.AccountNumber,
                AccountCategory = entity.AccountCategory,
                AccountCategoryKind = entity.AccountCategoryKind,
                AccountName = entity.AccountName,
                BudgetChapterCode = entity.BudgetChapterCode,
                ClosingCreditAmount = entity.ClosingCreditAmount,
                ClosingDebitAmount = entity.ClosingDebitAmount,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                LKDN_CreditAmount = entity.LKDN_CreditAmount,
                LKDN_DebitAmount = entity.LKDN_DebitAmount,
                MovementCreditAmount = entity.MovementCreditAmount,
                MovementDebitAmount = entity.MovementDebitAmount,
                OpenAjustCreditAmount = entity.OpenAjustCreditAmount,
                OpenAjustDebitAmount = entity.OpenAjustDebitAmount,
                OpenCreditAmount = entity.OpenCreditAmount,
                OpenDebitAmount = entity.OpenDebitAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S31HModel.</returns>
        internal static S31HModel FromDataTransferObject(S31HEntity entity)
        {
            if (entity == null)
                return null;

            return new S31HModel
            {
                BudgetSourceName = entity.BudgetSourceName,
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                AccountNumber = entity.AccountNumber,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                JournalMemo = entity.JournalMemo,
                SortOrder = entity.SortOrder,
                AccountCategoryKind = entity.AccountCategoryKind,
                AccountingObjectCode = entity.AccountingObjectCode,
                AccountingObjectName = entity.AccountingObjectName,
                AccountName = entity.AccountName,
                ClosingCreditAmount = entity.ClosingCreditAmount,
                ClosingDebitAmount = entity.ClosingDebitAmount,
                OrderType = entity.OrderType,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Description = entity.Description,
                ActivityId = entity.ActivityId,
                ActivityName = entity.ActivityName,
                BankID = entity.BankID,
                BankName = entity.BankName,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetChapterName = entity.BudgetChapterName,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetKindItemName = entity.BudgetKindItemName,
                BudgetSourceID = entity.BudgetSourceID,
                CapitalPlanID = entity.CapitalPlanID,
                CapitalPlanName = entity.CapitalPlanName,
                ContractID = entity.ContractID,
                ContractName = entity.ContractName,
                CurrencyCode = entity.CurrencyCode,
                CurrencyName = entity.CurrencyName,
                FundStructureID = entity.FundStructureID,
                FundStructureName = entity.FundStructureName,
                ProjectID = entity.ProjectID,
                ProjectName = entity.ProjectName,
               FixedAssetId= entity.FixedAssetId,
               FixedAssetName= entity.FixedAssetName,
               InventoryItemId= entity.InventoryItemId,
               InventoryItemName= entity.InventoryItemName,
               
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S33HModel FromDataTransferObject(S33HEntity entity)
        {
            if (entity == null)
                return null;

            return new S33HModel
            {
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                JournalMemo = entity.JournalMemo,
                DebitAmountBalance = entity.DebitAmountBalance,
                CreditAmountBalance = entity.CreditAmountBalance,
                DebitAmountOriginal = entity.DebitAmountOriginal,
                CreditAmountOriginal = entity.CreditAmountOriginal,
                FontStyle = entity.FontStyle,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// Froms
        ///  the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static A02LDTLModel FromDataTransferObject(A02LDTLEntity entity)
        {
            if (entity == null)
                return null;

            return new A02LDTLModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                NumberSHP = entity.NumberSHP,
                SHP = entity.SHP,
                PCVS = entity.PCVS,
                PCKiemNhiem = entity.PCKiemNhiem,
                TroCapCT = entity.TroCapCT,
                TongCong = entity.TongCong,
                QuiDoi = entity.QuiDoi,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                CalcDate = entity.CalcDate,
                BaseOfSalary = entity.BaseOfSalary,
                WorkDays = entity.WorkDay
            };
        }

        /// <summary>
        /// Froms
        ///  the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B01_BCTCModel FromDataTransferObject(B01_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B01_BCTCModel
            {
                MasterId = entity.MasterId,
                DetailId = entity.DetailId,
                ColA = entity.ColA,
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemName = entity.ReportItemName,
                ReportItemCode = entity.ReportItemCode,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                SortOrder = entity.SortOrder,
                IsBold = entity.IsBold,
                BudgetChapterCode = entity.BudgetChapterCode,
                Formula = entity.Formula,
                CreatedDate = entity.CreatedDate,
                DayOfDateSystem = entity.DayOfDateSystem,
                MonthOfDateSystem = entity.MonthOfDateSystem,
                YearOfDateSystem = entity.YearOfDateSystem,
                CompanyChiefAccountant = entity.CompanyChiefAccountant,
                CompanyReportPreparer = entity.CompanyReportPreparer,
                CompanyDirector = entity.CompanyDirector,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B03a_BCTCModel.</returns>
        internal static B03a_BCTCModel FromDataTransferObject(B03a_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B03a_BCTCModel
            {
                MasterId = entity.MasterId,
                DetailId = entity.DetailId,
                ColA = entity.ColA,
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemName = entity.ReportItemName,
                ReportItemCode = entity.ReportItemCode,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                SortOrder = entity.SortOrder,
                IsBold = entity.IsBold,
                BudgetChapterCode = entity.BudgetChapterCode,
                Formula = entity.Formula,
                CreatedDate = entity.CreatedDate,
                DayOfDateSystem = entity.DayOfDateSystem,
                MonthOfDateSystem = entity.MonthOfDateSystem,
                YearOfDateSystem = entity.YearOfDateSystem,
                CompanyChiefAccountant = entity.CompanyChiefAccountant,
                CompanyReportPreparer = entity.CompanyReportPreparer,
                CompanyDirector = entity.CompanyDirector,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B03b_BCTCModel FromDataTransferObject(B03b_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B03b_BCTCModel
            {
                ReportItemIndex = entity.ReportItemIndex,
                ReportItemName = entity.ReportItemName,
                ReportItemCode = entity.ReportItemCode,
                Col1 = entity.Col1,
                Col2 = entity.Col2
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B02BCQTModel FromDataTransferObject(B02BCQTEntity entity)
        {
            if (entity == null)
                return null;

            return new B02BCQTModel
            {
                ReportItemIndex = entity.ReportItemIndex,
                ReportItemCode = entity.ReportItemCode,
                ReportItemName = entity.ReportItemName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B03BCQTModel.</returns>
        internal static B03BCQTModel FromDataTransferObject(B03BCQTEntity entity)
        {
            if (entity == null)
                return null;

            return new B03BCQTModel
            {
                ReportItemIndex = entity.ReportItemIndex,
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemCode = entity.ReportItemCode,
                ReportItemName = entity.ReportItemName,
                Grade = entity.Grade,
                BudgetChapterCode = entity.BudgetChapterCode,
                GroupName = entity.GroupName,
                GroupTypeChild = entity.GroupTypeChild,
                GroupType = entity.GroupType,
                IsBold = entity.IsBold,
                IsItalic = entity.IsItalic,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                Col3 = entity.Col3
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>F0101BCQTModel.</returns>
        internal static F0101BCQTModel FromDataTransferObject(F0101BCQTEntity entity)
        {
            if (entity == null)
                return null;

            return new F0101BCQTModel
            {
                BudgetChapterCode = entity.BudgetChapterCode,
                ReportItemName = entity.ReportItemName,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSubKindItemName = entity.BudgetSubKindItemName,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubItemName = entity.BudgetSubItemName,
                TotalAmount = entity.TotalAmount,
                DomesticBudgetAmount = entity.DomesticBudgetAmount,
                AidBudgetAmount = entity.AidBudgetAmount,
                ForeignLoansBudgetAmount = entity.ForeignLoansBudgetAmount,
                DeductibleBudgetAmount = entity.DeductibleBudgetAmount,
                OtherBudgetAmount = entity.OtherBudgetAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B01BCQTModel FromDataTransferObject(B01BCQTEntity entity)
        {
            if (entity == null)
                return null;

            return new B01BCQTModel
            {
                Amount = entity.Amount,
                IsBold = entity.IsBold,
                IsItalic = entity.IsItalic,
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemCode = entity.ReportItemCode,
                ReportItemName = entity.ReportItemName,
                SummaryAmount = entity.SummaryAmount,
                SummaryBudgetKindItemAmount = entity.SummaryBudgetKindItemAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B02_BCTCModel.</returns>
        internal static B02_BCTCModel FromDataTransferObject(B02_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B02_BCTCModel
            {
                MasterId = entity.MasterId,
                DetailId = entity.DetailId,
                ColA = entity.ColA,
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemName = entity.ReportItemName,
                ReportItemCode = entity.ReportItemCode,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                SortOrder = entity.SortOrder,
                IsBold = entity.IsBold,
                BudgetChapterCode = entity.BudgetChapterCode,
                Formula = entity.Formula,
                CreatedDate = entity.CreatedDate,
                DayOfDateSystem = entity.DayOfDateSystem,
                MonthOfDateSystem = entity.MonthOfDateSystem,
                YearOfDateSystem = entity.YearOfDateSystem,
                CompanyChiefAccountant = entity.CompanyChiefAccountant,
                CompanyReportPreparer = entity.CompanyReportPreparer,
                CompanyDirector = entity.CompanyDirector,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B05_BCTCModel.</returns>
        internal static B05_BCTCModel FromDataTransferObject(B05_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B05_BCTCModel
            {
                ReportItemAlias = entity.ReportItemAlias,
                ReportItemName = entity.ReportItemName,
                ReportItemCode = entity.ReportItemCode,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                SortOrder = entity.SortOrder,
                IsBold = entity.IsBold,
                BudgetChapterCode = entity.BudgetChapterCode,
                GroupName = entity.GroupName,
                GroupType = entity.GroupType,
                IsItalic = entity.IsItalic,
                ReportItemIndex = entity.ReportItemIndex,
                Type = entity.Type
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B04_BCTCModel.</returns>
        internal static B04_BCTCModel FromDataTransferObject(B04_BCTCEntity entity)
        {
            if (entity == null)
                return null;

            return new B04_BCTCModel
            {
                MasterId = entity.MasterId,
                DetailId = entity.DetailId,
                ReportItemCode = entity.ReportItemCode,
                ReportItemName = entity.ReportItemName,
                ContentString = entity.ContentString,
                ContentNumber = entity.ContentNumber,
                IsBold = entity.IsBold,
                Type = entity.Type,
                GroupType = entity.GroupType,
                GroupCode = entity.GroupCode,
                SortOrder = entity.SortOrder,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                Col3 = entity.Col3,
                Col4 = entity.Col4,
                Col5 = entity.Col5,
                Col6 = entity.Col6,
                Col7 = entity.Col7,
                Col8 = entity.Col8,
                Col9 = entity.Col9,
                Col10 = entity.Col10,
                Col11 = entity.Col11,
                Col12 = entity.Col12,
                Formula = entity.Formula,
                BudgetChapterCode = entity.BudgetChapterCode,
                CreatedDate = entity.CreatedDate,
                DayOfDateSystem = entity.DayOfDateSystem,
                MonthOfDateSystem = entity.MonthOfDateSystem,
                YearOfDateSystem = entity.YearOfDateSystem,
                CompanyChiefAccountant = entity.CompanyChiefAccountant,
                CompanyReportPreparer = entity.CompanyReportPreparer,
                CompanyDirector = entity.CompanyDirector,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B14QModel FromDataTransferObject(B14QEntity entity)
        {
            if (entity == null)
                return null;

            return new B14QModel
            {
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                Unit = entity.Unit,
                QuantityOpening = entity.QuantityOpening,
                QuantityInwardStock = entity.QuantityInwardStock,
                QuantityOutwardStock = entity.QuantityOutwardStock,
                QuantityClosing = entity.QuantityClosing,

                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceInwardStock = entity.OrgPriceInwardStock,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOutwardStock = entity.OrgPriceOutwardStock,
                CancelQuantity = entity.CancelQuantity,
                FreeQuantity = entity.FreeQuantity,
                TotalQuantity = entity.TotalQuantity
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S03AHModel FromDataTransferObject(S03AHEntity entity)
        {
            if (entity == null)
                return null;

            return new S03AHModel
            {
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                FontStyle = entity.FontStyle,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C22HModel FromDataTransferObject(C22HEntity entity)
        {
            if (entity == null)
                return null;

            return new C22HModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                TotalAmount = entity.TotalAmount,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                Trader = entity.Trader
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C212NSModel.</returns>
        internal static C212NSModel FromDataTransferObject(C212NSEntity entity)
        {
            if (entity == null)
                return null;

            return new C212NSModel
            {
                RefId = entity.RefId,
                ProId = entity.PROID,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                TABMISCode = entity.TABMISCode,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                ContractNo = entity.ContractNo,
                ContractFrameNo = entity.ContractFrameNo,
                BudgetSourceKind = entity.BudgetSourceKind,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                IsForeignCurrency = entity.IsForeignCurrency,
                Description = entity.Description,
                CurrencyCode = entity.CurrencyCode,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetDistributionCode = entity.BudgetDistributionCode,
                BudgetSourcePropertyCode = entity.BudgetSourcePropertyCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                ProjectCode = entity.ProjectCode,
                SortOrder = entity.SortOrder,
                ProjectInvestmentCode = entity.ProjectInvestmentCode,
                ProjectInvestmentName = entity.ProjectInvestmentName,
                SignDate = entity.SignDate,
                ContractAmount = entity.ContractAmount,
                PrevYearCommitmentAmount = entity.PrevYearCommitmentAmount,
                BudgetCode = entity.BudgetCode,
                BankOpen = entity.BankOpen
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C213NSModel.</returns>
        internal static C213NSModel FromDataTransferObject(C213NSEntity entity)
        {
            if (entity == null)
                return null;

            return new C213NSModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                ContractNo = entity.ContractNo,
                ContractFrameNo = entity.ContractFrameNo,
                BudgetSourceKind = entity.BudgetSourceKind,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                IsForeignCurrency = entity.IsForeignCurrency,
                CurrencyCode = entity.CurrencyCode,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetDistributionCode = entity.BudgetDistributionCode,
                BudgetSourcePropertyCode = entity.BudgetSourcePropertyCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                ProjectCode = entity.ProjectCode,
                SortOrder = entity.SortOrder,
                ProjectInvestmentCode = entity.ProjectInvestmentCode,
                ProjectInvestmentName = entity.ProjectInvestmentName,
                SignDate = entity.SignDate,
                AccountingObjectCode = entity.AccountingObjectCode,
                AccountingObjectName = entity.AccountingObjectName,
                AdjustmentProviderBankAccount = entity.AdjustmentProviderBankAccount,
                AdjustmentProviderBankName = entity.AdjustmentProviderBankName,
                BUCommitmentRequestRefNo = entity.BUCommitmentRequestRefNo,
                BudgetYear = entity.BudgetYear,
                DeToAmount = entity.DeToAmount,
                DeToAmountOC = entity.DeToAmountOC,
                IsBlankPart2 = entity.IsBlankPart2,
                IsBlankPart3 = entity.IsBlankPart3,
                IsSuggestAdjustment = entity.IsSuggestAdjustment,
                IsSuggestSupplement = entity.IsSuggestSupplement,
                OrgProviderBankAccount = entity.OrgProviderBankAccount,
                OrgProviderBankName = entity.OrgProviderBankName,
                Part = entity.Part,
                RealContractNo = entity.RealContractNo,
                RefIDSortOrder = entity.RefIDSortOrder,
                RemainAmount = entity.RemainAmount,
                RemainAmountOC = entity.RemainAmountOC,
                ToAmount = entity.ToAmount,
                ToAmountOC = entity.ToAmountOC,
                ToBudgetChapterCode = entity.ToBudgetChapterCode,
                ToBudgetDistributionCode = entity.ToBudgetDistributionCode,
                ToBudgetSourcePropertyCode = entity.ToBudgetSourcePropertyCode,
                ToBudgetSubItemCode = entity.ToBudgetSubItemCode,
                ToBudgetSubKindItemCode = entity.ToBudgetSubKindItemCode,
                ToCurrencyCode = entity.ToCurrencyCode,
                ToProjectCode = entity.ToProjectCode,
                BudgetCode = entity.BudgetCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BankOpen = entity.BankOpen
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C30BB501Model FromDataTransferObject(C30BB501Entity entity)
        {
            if (entity == null)
                return null;

            return new C30BB501Model
            {
                AccountNumber = entity.AccountNumber,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Address = entity.Address,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DocumentInclude = entity.DocumentInclude,
                ExchangeRate = entity.ExchangeRate,
                IsSelect = entity.IsSelect,
                JournalMemo = entity.JournalMemo,
                RefId = entity.RefId,
                TotalAmount = entity.TotalAmount,
                TotalAmountExchange = entity.TotalAmountExchange,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                ContactName = entity.ContactName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns
        /// ></returns>
        internal static C11HModel FromDataTransferObject(C11HEntity entity)
        {
            if (entity == null)
                return null;

            return new C11HModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                //  DebitAccount = entity.DebitAccount,
                CurrencyCode = entity.CurrencyCode,
                TotalAmount = entity.TotalAmount,
                JournalMemo = entity.JournalMemo,
                StockName = entity.StockName,
                Trader = entity.Trader,
                InventoryItems = FromDataTransferObjects(entity.InventoryItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B01HModel FromDataTransferObject(B01HEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new B01HModel
            {
                MovementDebit = entity.MovementDebit,
                ClosingDebit = entity.ClosingDebit,
                OpeningCredit = entity.OpeningCredit,
                ClosingCredit = entity.ClosingCredit,
                MovementAccumDebit = entity.MovementAccumDebit,
                MovementCredit = entity.MovementCredit,
                Grade = entity.Grade,
                OpeningDebit = entity.OpeningDebit,
                MovementAccumCredit = entity.MovementAccumCredit,
                IsPrintMonth13 = entity.IsPrintMonth13,
                AccountNumber = entity.AccountNumber,
                BudgetSourceName = entity.BudgetSourceName,
                AccountGrade = entity.AccountGrade,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                SortOrder = entity.SortOrder,
                BudgetSourceCode = entity.BudgetSourceCode,
                AccountCategoryKind = entity.AccountCategoryKind,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                AccountCategory = entity.AccountCategory,
                AccountName = entity.AccountName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C402CKBModel FromDataTransferObject(C402CKBEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new C402CKBModel
            {
                RefId = entity.RefId,
                Amount = entity.Amount,
                RefNo = entity.RefNo,
                EditVersion = entity.EditVersion,
                RefDate = entity.RefDate,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                Description = entity.Description,
                Tax = entity.Tax,
                DescriptionReplaced = entity.DescriptionReplaced,
                BankAccount = entity.BankAccount,
                AccountInBank = entity.AccountInBank,
                AccountingObjectBankAccount = entity.AccountingObjectBankAccount,
                Payment = entity.Payment,
                ReceiptAccountInBank = entity.ReceiptAccountInBank,
                ReceiptCode = entity.ReceiptCode,
                ReceiptObjectName = entity.ReceiptObjectName,
                ReceiptTargetProgram = entity.ReceiptTargetProgram,
                CurencyCode = entity.CurencyCode,
                RefType = entity.RefType,
                IsOpenInBank = entity.IsOpenInBank,
                BudgetCode = entity.BudgetCode,
                ActivityCode = entity.ActivityCode,
                ActivityGrade = entity.ActivityGrade,
                ReceiveName = entity.ReceiveName,
                ReceiveIssueDate = entity.ReceiveIssueDate,
                ReceiveId = entity.ReceiveId,
                ReceiveIssueLocation = entity.ReceiveIssueLocation,
                OrgRefNo = entity.OrgRefNo,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                ProjectBankName = entity.ProjectBankName,
                ProjectBankAccount = entity.ProjectBankAccount,
                ProjectName = entity.ProjectName,
                Investment = entity.Investment,
                CashWithDrawTypeID = entity.CashWithDrawTypeID
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C41BBModel.</returns>
        internal static C41BBModel FromDataTransferObject(C41BBEntity entity)
        {
            if (entity == null)
                return null;
            return new C41BBModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                InwardRefNo = entity.InwardRefNo,
                AccountingObjectName = entity.AccountingObjectName,
                ContactName = entity.ContactName,
                Address = entity.Address,
                JournalMemo = entity.JournalMemo,
                DocumentIncluded = entity.DocumentIncluded,
                TotalAmount = entity.TotalAmount,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                SortOrder = entity.SortOrder,
                AmountOC = entity.AmountOC,
                TotalAmountOC = entity.TotalAmountOC,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                Receiver = entity.Receiver,
                Payer = entity.Payer
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S12HModel.</returns>
        internal static S12HModel FromDataTransferObject(S12HEntity entity)
        {
            if (entity == null)
                return null;
            return new S12HModel
            {
                RefType = entity.RefType,
                StartOfQuater = entity.StartOfQuater,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                BankId = entity.BankId,
                JournalMemo = entity.JournalMemo,
                BankAccount = entity.BankAccount == null ? "" : entity.BankAccount,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                BankName = entity.BankName,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,
                IsOneBudgetChapterCode = entity.IsOneBudgetChapterCode,
                IsOneBudgetSubKindItemCode = entity.IsOneBudgetSubKindItemCode,
                IsOneBudgetSourceCode = entity.IsOneBudgetSourceCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S12HDetailModel.</returns>
        internal static S12HDetailModel FromDataTransferObject(S12HDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new S12HDetailModel
            {
                RefType = entity.RefType,
                StartOfQuater = entity.StartOfQuater,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                BankId = entity.BankId,
                JournalMemo = entity.JournalMemo,
                BankAccount = entity.BankAccount == null ? "" : entity.BankAccount,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                BankName = entity.BankName,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,
                IsOneBudgetChapterCode = entity.IsOneBudgetChapterCode,
                IsOneBudgetSubKindItemCode = entity.IsOneBudgetSubKindItemCode,
                IsOneBudgetSourceCode = entity.IsOneBudgetSourceCode,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S12HModel.</returns>
        internal static S03HModel FromDataTransferObject(S03HEntity entity)
        {
            if (entity == null)
                return null;
            return new S03HModel
            {
                RefType = entity.RefType,
                StartOfQuater = entity.StartOfQuater,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                // BankId = entity.BankId,
                JournalMemo = entity.JournalMemo,
                //BankAccount = entity.BankAccount,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                CurrencyCode = entity.CurrencyCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                //BankName = entity.BankName,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,
                IsOneBudgetChapterCode = entity.IsOneBudgetChapterCode,
                IsOneBudgetSubKindItemCode = entity.IsOneBudgetSubKindItemCode,
                IsOneBudgetSourceCode = entity.IsOneBudgetSourceCode,
                RefDetailID = entity.RefDetailID,
                GeneralLedgerID = entity.GeneralLedgerID,
                Description = entity.Description,
                AccountNumberLevelOne = entity.AccountNumberLevelOne,
                AccountCategoryKind = entity.AccountCategoryKind,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                OpeningAmount = entity.OpeningAmount

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S01HLedgerModel FromDataTransferObject(S01HLedgerEntity entity)
        {
            if (entity == null)
                return null;
            return new S01HLedgerModel
            {
                RefType = entity.RefType,
                StartOfQuater = entity.StartOfQuater,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                JournalMemo = entity.JournalMemo,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                RowAccountNumber = entity.RowAccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,
                IsOneBudgetChapterCode = entity.IsOneBudgetChapterCode,
                IsOneBudgetSubKindItemCode = entity.IsOneBudgetSubKindItemCode,
                IsOneBudgetSourceCode = entity.IsOneBudgetSourceCode,
                RefDetailId = entity.RefDetailId,
                GeneralLedgerId = entity.GeneralLedgerId,
                Description = entity.Description,
                AccountNumberLevelOne = entity.AccountNumberLevelOne,
                AccountCategoryKind = entity.AccountCategoryKind,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                OpeningAmount = entity.OpeningAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C33BBModel.</returns>
        internal static C33BBModel FromDataTransferObject(C33BBEntity entity)
        {
            if (entity == null)
                return null;
            return new C33BBModel
            {
                Part = entity.Part,
                RefId = entity.RefId,
                AccountingObjectAddress = entity.AccountingObjectAddress == null ? "" : entity.AccountingObjectAddress,
                RefDate = entity.RefDate,
                Description = entity.Description,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName == null ? "" : entity.AccountingObjectName,
                SortOrder = entity.SortOrder,
                Amount = entity.Amount,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                IsBold = entity.IsBold,
                LineDetail = entity.LineDetail
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S11HModel.</returns>
        internal static S11HModel FromDataTransferObject(S11HEntity entity)
        {
            if (entity == null)
                return null;
            return new S11HModel
            {
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                JournalMemo = entity.JournalMemo,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S11HDetailModel.</returns>
        internal static S11HDetailModel FromDataTransferObject(S11HDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new S11HDetailModel
            {
                RefType = entity.RefType,
                StartOfQuater = entity.StartOfQuater,
                RefNo = entity.RefNo,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefId = entity.RefId,
                JournalMemo = entity.JournalMemo,
                Cot3 = entity.Cot3,
                Cot2 = entity.Cot2,
                AccCot2 = entity.AccCot2,
                AccountNumber = entity.AccountNumber,
                BudgetChapterCode = entity.BudgetChapterCode == null ? "" : entity.BudgetChapterCode,
                RefDate = entity.RefDate,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode == null ? "" : entity.BudgetSubKindItemCode,
                OrderType = entity.OrderType,
                StartOfMonth = entity.StartOfMonth,
                AccountName = entity.AccountName,
                AccCot3 = entity.AccCot3,
                BudgetSourceName = entity.BudgetSourceName == null ? "" : entity.BudgetSourceName,
                AccountingObjectName = entity.AccountingObjectName,
                BudgetSourceCode = entity.BudgetSourceCode == null ? "" : entity.BudgetSourceCode,
                Cot1 = entity.Cot1,
                QuyCot2 = entity.QuyCot2,
                QuyCot3 = entity.QuyCot3,
                IsOneBudgetChapterCode = entity.IsOneBudgetChapterCode,
                IsOneBudgetSubKindItemCode = entity.IsOneBudgetSubKindItemCode,
                IsOneBudgetSourceCode = entity.IsOneBudgetSourceCode,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// C408Model.
        /// </returns>
        internal static C408Model FromDataTransferObject(C408Entity entity)
        {
            if (entity == null)
                return null;
            return new C408Model
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                TotalAmount = entity.TotalAmount,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                Receiver = entity.Receiver,
                Payer = entity.Payer,
                C408Details = FromDataTransferObjects(entity.C408Details)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C408DetailModel FromDataTransferObject(C408DetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C408DetailModel
            {
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C21HDModel.</returns>
        internal static C21HDModel FromDataTransferObject(C21HDEntity entity)
        {
            if (entity == null)
                return null;
            return new C21HDModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                Receiver = entity.Receiver,
                Address = entity.Address,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                TotalAmount = entity.TotalAmount,
                DebitAccounts = entity.DebitAccounts,
                CreditAccounts = entity.CreditAccounts,
                StockId = entity.StockId,
                StockName = entity.StockName,
                Details = FromDataTransferObjects(entity.Details),
                ReceiverAddress = entity.ReceiverAddress
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C20HDModel.</returns>
        internal static C20HDModel FromDataTransferObject(C20HDEntity entity)
        {
            if (entity == null)
                return null;
            return new C20HDModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                Receiver = entity.Receiver,
                Address = entity.Address,
                ReceiverAddress = entity.ReceiverAddress,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                TotalAmount = entity.TotalAmount,
                DebitAccounts = entity.DebitAccounts,
                CreditAccounts = entity.CreditAccounts,
                StockId = entity.StockId,
                StockName = entity.StockName,
                Details = FromDataTransferObjects(entity.Details),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C4_09Model.</returns>
        internal static C4_09Model FromDataTransferObject(C4_09Entity entity)
        {
            if (entity == null)
                return null;
            return new C4_09Model
            {
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                AccountingObjectName = entity.AccountingObjectName,
                IdentificationNumber = entity.IdentificationNumber,
                IssueBy = entity.IssueBy,
                IssueDate = entity.IssueDate,
                Details = FromDataTransferObjects(entity.Details),
                Address = entity.Address,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                CurrencyCode = entity.CurrencyCode,
                TotalAmountOC = entity.TotalAmountOC,
                TotalCashAmount = entity.TotalCashAmount,
                TotalCashAmountOC = entity.TotalCashAmountOC,
                RefId = entity.RefId,
                RefType = entity.RefType,
                Payer = entity.Payer
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C4_09Model.</returns>
        internal static C203NSModel FromDataTransferObject(C203NSEntity entity)
        {
            if (entity == null)
                return null;
            return new C203NSModel
            {
                RefID = entity.RefID,
                IsSystemDate = entity.IsSystemDate,
                IsRefDate = entity.IsRefDate,
                ReportNameType = entity.ReportNameType,
                SystemDate = entity.SystemDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                JournalMemo = entity.JournalMemo,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                AdvancePaymentAmount = entity.AdvancePaymentAmount,
                PayAmount = entity.PayAmount,
                PayableAmount = entity.PayableAmount,
                TargetProgramCode = entity.TargetProgramCode,
                TargetProgramName = entity.TargetProgramName,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                Description = entity.Description,
                CheckCashWithDrawType = entity.CheckCashWithDrawType,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                Col3 = entity.Col3,
            };
        }

        /// <summary>
        /// C302
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static C302NSModel FromDataTransferObject(C302NSEntity entity)
        {
            if (entity == null)
                return null;
            return new C302NSModel
            {
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                AdvancePaymentAmount = entity.AdvancePaymentAmount,
                PayAmount = entity.PayAmount,
                PayableAmount = entity.PayableAmount,
                Property = entity.Property,
                TargetProgramCode = entity.TargetProgramCode,
                TargetProgramName = entity.TargetProgramName,
                BudgetDistributionCode = entity.BudgetDistributionCode,
                ProjectName = entity.ProjectName,
                ProjectCode = entity.ProjectCode,
                InvestmentNumber = entity.InvestmentNumber,
                InvestmentDate = entity.InvestmentDate,
                YearPlan = entity.YearPlan,
                CheckCashWithDrawType = entity.CheckCashWithDrawType,
                CreateDate = entity.CreateDate,
                BudgetSourceCode = entity.BudgetSourceCode,
                ProjectBankName = entity.ProjectBankName,
                ProjectBankAccount = entity.ProjectBankAccount
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C2_02a_NSModel.</returns>
        internal static C2_02a_NSModel FromDataTransferObject(C2_02aEntity entity)
        {
            if (entity == null)
                return null;
            return new C2_02a_NSModel
            {
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                ProjectCode = entity.ProjectCode,
                ProjectName = entity.ProjectName,
                AccountingObjectName = entity.AccountingObjectName,
                Address = entity.Address,
                BankAccount_Object = entity.BankAccount_Object,
                BankName_Object = entity.BankName_Object,
                IdentificationNumber = entity.IdentificationNumber,
                IssueDate = entity.IssueDate,
                IssueBy = entity.IssueBy,
                TotalAmount = entity.TotalAmount,
                CashWithDrawType = entity.CashWithDrawType,
                RefType = entity.RefType,
                Employee = entity.Employee,
                Details = FromDataTransferObjects(entity.Details),
                EmployeeAddress = entity.EmployeeAddress,
                EmployeeCode = entity.EmployeeCode,
                EmployeeBankAccount = entity.EmployeeBankAccount,
                EmployeeBankName = entity.EmployeeBankName,
                IsEmployee = entity.IsEmployee,
                JournalMemo = entity.JournalMemo,
                BudgetCode = entity.BudgetCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C21HDDetailModel.</returns>
        internal static C21HDDetailModel FromDataTransferObject(C21HDDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C21HDDetailModel
            {
                PriceUnit = entity.PriceUnit,
                Amount = entity.Amount,
                Unit = entity.Unit,
                InventoryItemName = entity.InventoryItemName,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemId = entity.InventoryItemId,
                Stt = entity.Stt,
                Quantity = entity.Quantity

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C20HDDetailModel.</returns>
        internal static C20HDDetailModel FromDataTransferObject(C20HDDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C20HDDetailModel
            {
                PriceUnit = entity.PriceUnit,
                Amount = entity.Amount,
                Unit = entity.Unit,
                InventoryItemName = entity.InventoryItemName,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemId = entity.InventoryItemId,
                Stt = entity.Stt,
                Quantity = entity.Quantity

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C4_09DetailModel.</returns>
        internal static C4_09DetailModel FromDataTransferObject(C4_09DetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C4_09DetailModel
            {
                Description = entity.Description,
                AmountOC = entity.AmountOC,
                Amount = entity.Amount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>C2_02a_NSDetailModel.</returns>
        internal static C2_02a_NSDetailModel FromDataTransferObject(C2_02aDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C2_02a_NSDetailModel
            {
                Memo = entity.Memo,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                Amount = entity.Amount,
                CashWithDrawType = entity.CashWithDrawType
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S13HModel FromDataTransferObject(S13HEntity entity)
        {
            if (entity == null)
                return null;
            return new S13HModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefTypeCategory = entity.RefTypeCategory,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                JournalMemo = entity.JournalMemo,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                AccountName = entity.AccountName,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DebitAmountOC = entity.DebitAmountOC,
                DebitAmount = entity.DebitAmount,
                CreditAmountOC = entity.CreditAmountOC,
                CreditAmount = entity.CreditAmount,
                ClosingDebitAmountOC = entity.ClosingDebitAmountOC,
                ClosingDebitAmount = entity.ClosingDebitAmount,
                ClosingCreditAmountOC = entity.ClosingCreditAmountOC,
                ClosingCreditAmount = entity.ClosingCreditAmount,
                OrderType = entity.OrderType,
                SortOrder = entity.SortOrder,
                CurrencyCode = entity.CurrencyCode,
                CurrencyName = entity.CurrencyName,
                ExchangeRate = entity.ExchangeRate,
                Cot1 = entity.Cot1,
                Cot1OC = entity.Cot1OC,
                Cot2 = entity.Cot2,
                Cot2OC = entity.Cot2OC,
                Cot3 = entity.Cot3,
                Cot3OC = entity.Cot3OC,
                StartOfMonth = entity.StartOfMonth,
                BankAccount = entity.BankAccount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>FixedAsset30KPart2Model.</returns>
        internal static FixedAsset30KPart2Model FromDataTransferObject(FixedAsset30KPart2Entity entity)
        {
            if (entity == null)
                return null;
            return new FixedAsset30KPart2Model
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                ProductionYear = entity.ProductionYear,
                CountryProduction = entity.CountryProduction,
                DateOfUsing = entity.DateOfUsing,
                OrgPrice = entity.OrgPrice,
                OrgPriceDifference = entity.OrgPriceDifference,
                RemainingAmount = entity.RemainingAmount,
                StateManagement = entity.StateManagement,
                Bussiness = entity.Bussiness,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>FixedAssetCardModel.</returns>
        internal static FixedAssetCardModel FromDataTransferObject(FixedAssetCardEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetCardModel
            {
                FixedAssetId = entity.FixedAssetId,
                OrderNumber = entity.OrderNumber,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                ProductionYear = entity.ProductionYear,
                MadeIn = entity.MadeIn,
                UsedDate = entity.UsedDate,
                PurchasedDate = entity.PurchasedDate,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,
                DepartmentName = entity.DepartmentName,
                EmployeeName = entity.EmployeeName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>FixedAssetB03H30KModel.</returns>
        internal static FixedAssetB03H30KModel FromDataTransferObject(FixedAssetB03H30KEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetB03H30KModel
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetType = entity.FixedAssetType,
                Grade = entity.Grade,
                QuantityOpening = entity.QuantityOpening,
                AreaOpening = entity.AreaOpening,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOpeningDifference = entity.OrgPriceOpeningDifference,
                QuantityIncrement = entity.QuantityIncrement,
                AreaIncrement = entity.AreaIncrement,
                OrgPriceIncrement = entity.OrgPriceIncrement,
                OrgPriceIncrementDifference = entity.OrgPriceIncrementDifference,
                QuantityDecrement = entity.QuantityDecrement,
                AreaDecrement = entity.AreaDecrement,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementDifference = entity.OrgPriceDecrementDifference,
                QuantityClosing = entity.QuantityClosing,
                AreaClosing = entity.AreaClosing,
                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceClosingDifference = entity.OrgPriceClosingDifference
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB02Model FromDataTransferObject(FixedAssetB02Entity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetB02Model
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                AddressUsing = entity.AddressUsing,
                DepreciationRate = entity.DepreciationRate,
                Description = entity.Description,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                CountryProduction = entity.CountryProduction,
                Quantity = entity.Quantity,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,
                Grade = entity.Grade,
                Sort = entity.Sort

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C40BBModel FromDataTransferObject(C30BBEntity entity)
        {
            if (entity == null)
                return null;
            return new C40BBModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                OutwardRefNo = entity.OutwardRefNo,
                AccountingObjectContactName = entity.AccountingObjectContactName,
                JournalMemo = entity.JournalMemo,
                DocumentIncluded = entity.DocumentIncluded,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalCashAmount = entity.TotalCashAmount,
                TotalCashAmountOC = entity.TotalCashAmountOC,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                AmountOC = entity.AmountOC,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                SortOrder = entity.SortOrder,
                Address = entity.Address,
                Payer = entity.Payer
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C40BBDetailModel FromDataTransferObject(C40BBDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C40BBDetailModel
            {
                OrderNo = entity.OrderNo,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode
            };

        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C41BBDetailModel FromDataTransferObject(C41BBDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new C41BBDetailModel
            {
                OrderNo = entity.OrderNo,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode
            };

        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C45_BBModel FromDataTransferObject(C45_BBEntity entity)
        {
            if (entity == null)
                return null;
            return new C45_BBModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                OutwardRefNo = entity.OutwardRefNo,
                AccountingObjectContactName = entity.AccountingObjectContactName,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                Address = entity.Address
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CashReportModel FromDataTransferObject(CashReportEntity entity)
        {
            if (entity == null)
                return null;
            return new CashReportModel
            {
                AccountNumber = entity.AccountNumber,
                AmountType = entity.AmountType,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Description = entity.Description,
                FromDate = entity.FromDate,
                PayAmount = entity.PayAmount,
                PostedDate = entity.PostedDate,
                ReceiptAmount = entity.ReceiptAmount,
                RefNo = entity.RefNo,
                RestAmount = entity.RestAmount,
                ToDate = entity.ToDate,
                AccumulatedPayAmount = entity.AccumulatedPayAmount,
                AccumulatedReceiptAmount = entity.AccumulatedReceiptAmount,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId


            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S03BHModel FromDataTransferObject(S03BHEntity entity)
        {
            if (entity == null)
                return null;
            return new S03BHModel
            {
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Description = entity.Description,
                PostedDate = entity.PostedDate,
                BudgetItemCode = entity.BudgetItemCode,
                AccumulatedAccountNumbber = entity.AccumulatedAccountNumbber,
                AccumulatedCorrAccountNumbber = entity.AccumulatedCorrAccountNumbber,
                AmountAccountNumbber = entity.AmountAccountNumbber,
                AmountCorrAccountNumbber = entity.AmountCorrAccountNumbber,
                AmountOgrAccountNumbber = entity.AmountOgrAccountNumbber,
                AmountOgrCorrAccountNumbber = entity.AmountOgrCorrAccountNumbber,
                RefNo = entity.RefNo,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B03BNGModel FromDataTransferObject(B03BNGEntity entity)
        {
            if (entity == null)
                return null;
            return new B03BNGModel
            {
                AccountingObjectCode = entity.AccountingObjectCode,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectGroup = entity.AccountingObjectGroup,
                OpeningAmount = entity.OpeningAmount,
                ReceiveAdvance = entity.ReceiveAdvance,
                AdvancePayment = entity.AdvancePayment,
                ClosingAmount = entity.ClosingAmount,
                Type = entity.Type
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>F03BNGModel.</returns>
        internal static F03BNGModel FromDataTransferObject(F03BNGEntity entity)
        {
            if (entity == null)
                return null;
            return new F03BNGModel
            {
                AccumulatedAutonomyBudgetAmount = entity.AccumulatedAutonomyBudgetAmount,
                AccumulatedAutonomyOtherAmount = entity.AccumulatedAutonomyOtherAmount,
                AccumulatedNonAutonomyBudgetAmount = entity.AccumulatedNonAutonomyBudgetAmount,
                AccumulatedNonAutonomyOtherAmount = entity.AccumulatedNonAutonomyOtherAmount,
                AccumulatedProjectBudgetAmount = entity.AccumulatedProjectBudgetAmount,
                AccumulatedRegulateOtherAmount = entity.AccumulatedRegulateOtherAmount,
                AccumulatedDiplomaticBudgetAmount = entity.AccumulatedDiplomaticBudgetAmount,
                AccumulatedTotalAmount = entity.AccumulatedTotalAmount,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemId = entity.BudgetItemId,
                BudgetItemType = entity.BudgetItemType,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Content = entity.Content,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                ThisMonthAutonomyBudgetAmount = entity.ThisMonthAutonomyBudgetAmount,
                ThisMonthAutonomyOtherAmount = entity.ThisMonthAutonomyOtherAmount,
                ThisMonthNonAutonomyBudgetAmount = entity.ThisMonthNonAutonomyBudgetAmount,
                ThisMonthNonAutonomyOtherAmount = entity.ThisMonthNonAutonomyOtherAmount,
                ThisMonthProjectBudgetAmount = entity.ThisMonthProjectBudgetAmount,
                ThisMonthRegulateOtherAmount = entity.ThisMonthRegulateOtherAmount,
                ThisMonthDiplomaticBudgetAmount = entity.ThisMonthDiplomaticBudgetAmount,
                ThisMonthTotalAmount = entity.ThisMonthTotalAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>F331BNGModel.</returns>
        internal static F331BNGModel FromDataTransferObject(F331BNGEntity entity)
        {
            if (entity == null)
                return null;
            return new F331BNGModel
            {
                AccumulatedAmount = entity.AccumulatedAmount,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemId = entity.BudgetItemId,
                BudgetItemType = entity.BudgetItemType,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Content = entity.Content,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                ThisMonthAmount = entity.ThisMonthAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>B09BNGModel.</returns>
        internal static B09BNGModel FromDataTransferObject(B09BNGEntity entity)
        {
            if (entity == null)
                return null;
            return new B09BNGModel
            {
                AccumulatedAmount = entity.AccumulatedAmount,
                ItemId = entity.ItemId,
                ItemName = entity.ItemName,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                Amount = entity.Amount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S34H_GL_Detail_SubDetailModel.</returns>
        internal static S34H_GL_Detail_SubDetailModel FromDataTransferObject(S34H_GL_Detail_SubDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new S34H_GL_Detail_SubDetailModel
            {
                AccountNumber = entity.AccountNumber,
                AccountingObjectId = entity.AccountingObjectId,
                RefType = entity.RefType,
                Description = entity.Description,
                AccountCategoryKind = entity.AccountCategoryKind,
                RefId = entity.RefId,
                CreditAmount = entity.CreditAmount,
                DebitAmount = entity.DebitAmount,
                Amount=entity.Amount,
                RefDate = entity.RefDate,
                SortOrder = entity.SortOrder,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                ItemCode = entity.ItemCode,
                JournalMemo = entity.JournalMemo,
                MonthYear = entity.MonthYear
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S34H_GL_Master_LineDetailModel.</returns>
        internal static S34H_GL_Master_LineDetailModel FromDataTransferObject(S34H_GL_Master_LineDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new S34H_GL_Master_LineDetailModel
            {
                ItemCode = entity.ItemCode,
                MonthYear = entity.MonthYear,
                AccountNumber = entity.AccountNumber,
                AccountingObjectId = entity.AccountingObjectId,
                AccountCategoryKind = entity.AccountCategoryKind,
                CreditAmount = entity.CreditAmount,
                DebitAmount = entity.DebitAmount,
                ItemName = entity.ItemName,
                MonthPeriod = entity.MonthPeriod,
                GL_Detail_SubDetail = FromDataTransferObjects(entity.GL_Detail_SubDetail)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S34H_GL_MasterModel.</returns>
        internal static S34H_GL_MasterModel FromDataTransferObject(S34H_GL_MasterEntity entity)
        {
            if (entity == null)
                return null;
            return new S34H_GL_MasterModel
            {
                AccountNumber = entity.AccountNumber,
                AccountingObjectId = entity.AccountingObjectId,
                AccountName = entity.AccountName,
                AccountingObjectName = entity.AccountingObjectName,
                AccountCategoryKind = entity.AccountCategoryKind,
                AccountingObjectCode = entity.AccountingObjectCode,
                ProjectID=entity.ProjectId,
                ProjectName=entity.ProjectName,
                GL_Master_LineDetail = FromDataTransferObjects(entity.GL_Master_LineDetail)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S52H_GL_MasterModel.</returns>
        internal static S52H_GL_MasterModel FromDataTransferObject(S52H_GL_MasterEntity entity)
        {
            if (entity == null)
                return null;
            return new S52H_GL_MasterModel
            {
                AccountNumber = entity.AccountNumber,
                AccountName = entity.AccountName,
                PartName = entity.PartName,
                MonthYear = entity.MonthYear,
                PartId = entity.PartId,
                Amount = entity.Amount,
                BudgetAmount = entity.BudgetAmount,
                ReceiptAmount = entity.ReceiptAmount,
                RevenueAmount = entity.RevenueAmount,
                SuperiorPaymentAmount = entity.SuperiorPaymentAmount,
                OtherPaymentAmount = entity.OtherPaymentAmount,
                GL_Master_Detail = FromDataTransferObjects(entity.GL_Master_Detail)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GL_Master_DetailModel.</returns>
        internal static GL_Master_DetailModel FromDataTransferObject(GL_Master_DetailEntity entity)
        {
            if (entity == null)
                return null;
            return new GL_Master_DetailModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                JournalMemo = entity.JournalMemo,
                AccountNumber = entity.AccountNumber,
                AccountName = entity.AccountName,
                MonthYear = entity.MonthYear,
                DisplayMonth = entity.DisplayMonth,
                DetailType = entity.DetailType,
                Amount = entity.Amount,
                BudgetAmount = entity.BudgetAmount,
                ReceiptAmount = entity.ReceiptAmount,
                RevenueAmount = entity.RevenueAmount,
                SuperiorPaymentAmount = entity.SuperiorPaymentAmount,
                DebitAmount = entity.DebitAmount,
                OpenAmount = entity.OpenAmount,
                SortOrder = entity.SortOrder,
                PartId = entity.PartId,
                OtherPaymentAmount = entity.OtherPaymentAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary.S101HModel.</returns>
        internal static S101HModel FromDataTransferObject(S101HEntity entity)
        {
            if (entity == null)
                return null;
            return new S101HModel
            {
                ItemCode = entity.ItemCode,
                EstimateItemName = entity.EstimateItemName,
                ItemType = entity.ItemType,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                AccountNumber = entity.AccountNumber,
                OrderNumber = entity.OrderNumber,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                PostedDate = entity.PostedDate,
                IsBold = entity.IsBold,
                ItemId = entity.ItemId,
                ParentId = entity.ParentId,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary.S101HPartIIModel.</returns>
        internal static S101HPartIIModel FromDataTransferObject(S101HPartIIEntity entity)
        {
            if (entity == null)
                return null;
            return new S101HPartIIModel
            {
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                AccountNumber = entity.AccountNumber,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                Description = entity.Description,
                ItemId = entity.ItemId,
                ItemCode = entity.ItemCode,
                ItemName = entity.ItemName,
                GroupCode = entity.GroupCode,
                ParentId = entity.ParentId,
                ItemType = entity.ItemType,
                OpeningAmount = entity.OpeningAmount,
                MovementAmount = entity.MovementAmount,
                ClosingAmount = entity.ClosingAmount,
                BalanceAmount = entity.BalanceAmount,
                OrderNumber = entity.OrderNumber,
                IsBold = entity.IsBold,
                BudgetSourceKind = entity.BudgetSourceKind,
                BudgetSourceKindName = entity.BudgetSourceKindName,
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S104HModel FromDataTransferObject(S104HEntity entity)
        {
            if (entity == null)
                return null;
            return new S104HModel
            {
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSubKindItemName = entity.BudgetSubKindItemName,
                BudgetSourceKindName = entity.BudgetSourceKindName,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode,
                ProjectName = entity.ProjectName,
                ItemName = entity.ItemName,
                ItemCode = entity.ItemCode,
                YearPeriod = entity.YearPeriod,
                MonthPeriod = entity.MonthPeriod,
                Col1 = entity.Col1,
                Col2 = entity.Col2,
                Col3 = entity.Col3,
                Col4 = entity.Col4,
                Col5 = entity.Col5,
                Col6 = entity.Col6,
                Col7 = entity.Col7,
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                Description = entity.Description,
                ReportType = entity.ReportType
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S101HPartIIIModel.</returns>
        internal static S101HPartIIIModel FromDataTransferObject(S101HPartIIIEntity entity)
        {
            if (entity == null)
                return null;
            return new S101HPartIIIModel
            {
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                AccountNumber = entity.AccountNumber,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                Description = entity.Description,
                ItemId = entity.ItemId,
                ItemCode = entity.ItemCode,
                ItemName = entity.ItemName,
                GroupCode = entity.GroupCode,
                ParentId = entity.ParentId,
                ItemType = entity.ItemType,
                BudgetAdvanceAmount = entity.BudgetAdvanceAmount,
                BudgetAdvancePaymentAmount = entity.BudgetAdvancePaymentAmount,
                AdvanceBalanceAmount = entity.AdvanceBalanceAmount,
                ActualExpenseAmount = entity.ActualExpenseAmount,
                CashBackAmount = entity.CashBackAmount,
                ActualReceitpAmount = entity.ActualReceitpAmount,
                FinalizationAmount = entity.FinalizationAmount,
                OrderNumber = entity.OrderNumber,
                IsBold = entity.IsBold,
                BudgetSourceKind = entity.BudgetSourceKind,
                BudgetSourceKindName = entity.BudgetSourceKindName,
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S102H1Model.</returns>
        internal static S102H1Model FromDataTransferObject(S102H1Entity entity)
        {
            if (entity == null)
                return null;
            return new S102H1Model
            {
                ItemCode = entity.ItemCode,
                EstimateItemName = entity.EstimateItemName,
                ItemType = entity.ItemType,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                OrderNumber = entity.OrderNumber,
                TotalAmount = entity.TotalAmount,
                PostedDate = entity.PostedDate,
                IsBold = entity.IsBold,
                ItemId = entity.ItemId,
                ParentId = entity.ParentId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S102H2Model.</returns>
        internal static S102H2Model FromDataTransferObject(S102H2Entity entity)
        {
            if (entity == null)
                return null;
            return new S102H2Model
            {
                ItemCode = entity.ItemCode,
                EstimateItemName = entity.EstimateItemName,
                ItemType = entity.ItemType,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                OrderNumber = entity.OrderNumber,
                BudgetAdvanceAmount = entity.BudgetAdvanceAmount,
                BudgetAdvancePaymentAmount = entity.BudgetAdvancePaymentAmount,
                AdvanceBalanceAmount = entity.AdvanceBalanceAmount,
                ActualExpenseAmount = entity.ActualExpenseAmount,
                CashBackAmount = entity.CashBackAmount,
                ActualReceiptAmount = entity.ActualReceiptAmount,
                FinalizationAmount = entity.FinalizationAmount,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                IsBold = entity.IsBold,
                ItemId = entity.ItemId,
                ParentId = entity.ParentId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S105H1Model FromDataTransferObject(S105H1Entity entity)
        {
            if (entity == null)
                return null;
            return new S105H1Model
            {
                PartId = entity.PartId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                SortOrder = entity.SortOrder,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                JournalMemo = entity.JournalMemo,
                MonthYear = entity.MonthYear,
                DisplayMonth = entity.DisplayMonth,
                DetailType = entity.DetailType,
                BudgetExpenseName = entity.BudgetExpenseName,
                BudgetExpenseCode = entity.BudgetExpenseCode,
                RegularAmount = entity.RegularAmount,
                NoRegularAmount = entity.NoRegularAmount,
                //OpeningAmount = entity.OpeningAmount,
                //BeginBalance = entity.BeginBalance,
                //BeginBalance1 = entity.BeginBalance1,
                //BeginBalance2 = entity.BeginBalance2,
            };
        }

        /// <summary>
        /// S106H1
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static S106H1Model FromDataTransferObject(S106H1Entity entity)
        {
            if (entity == null)
                return null;
            return new S106H1Model
            {
                PartId = entity.PartId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                SortOrder = entity.SortOrder,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                JournalMemo = entity.JournalMemo,
                MonthYear = entity.MonthYear,
                DisplayMonth = entity.DisplayMonth,
                DetailType = entity.DetailType,
                BudgetExpenseName = entity.BudgetExpenseName,
                BudgetExpenseCode = entity.BudgetExpenseCode,
                RegularAmount = entity.RegularAmount,
                NoRegularAmount = entity.NoRegularAmount,
                OpeningAmount = entity.OpeningAmount,
                BeginBalance = entity.BeginBalance,
                BeginBalance1 = entity.BeginBalance1,
                BeginBalance2 = entity.BeginBalance2,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static S105H2Model FromDataTransferObject(S105H2Entity entity)
        {
            if (entity == null)
                return null;
            return new S105H2Model
            {
                RefDetailID = entity.RefDetailID,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                //LineDetail = entity.LineDetail,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                //YearPeriod = entity.YearPeriod,
                //MonthYear = entity.MonthYear,
                Name = entity.Name,
                PartID = entity.PartID,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                RefType = entity.RefType,
                RefID = entity.RefID,
                SortOrder = entity.SortOrder,
                Amount = entity.Amount,
                //Amount0141xCol1 = entity.Amount0141xCol1,
                Amount0141xCol2 = entity.Amount0141xCol2,
                Amount0141xCol3 = entity.Amount0141xCol3,
                //Amount0142xCol1 = entity.Amount0142xCol1,
                Amount0142xCol2 = entity.Amount0142xCol2,
                Amount0142xCol3 = entity.Amount0142xCol3,
                //BeginingBalance2 = entity.BeginingBalance2,
                //BeginingBalance3 = entity.BeginingBalance3,
                //BeginingBalance5 = entity.BeginingBalance5,
                //BeginingBalance6 = entity.BeginingBalance6,
                //BeginingBalance1 = entity.BeginingBalance1,
                //BeginingBalance4 = entity.BeginingBalance4,
            };
        }

        /// <summary>
        /// S106H2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static S106H2Model FromDataTransferObject(S106H2Entity entity)
        {
            if (entity == null)
                return null;
            return new S106H2Model
            {
                RefDetailID = entity.RefDetailID,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                LineDetail = entity.LineDetail,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                YearPeriod = entity.YearPeriod,
                MonthYear = entity.MonthYear,
                Name = entity.Name,
                PartID = entity.PartID,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                RefType = entity.RefType,
                RefID = entity.RefID,
                SortOrder = entity.SortOrder,
                Amount = entity.Amount,
                Amount0181 = entity.Amount0181,
                Amount0182 = entity.Amount0182,
                //BeginingBalance1 = entity.BeginingBalance1,
                //BeginingBalance2 = entity.BeginingBalance2,
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetC55HDModel FromDataTransferObject(FixedAssetC55HDEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetC55HDModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                Grade = entity.Grade,
                OriginalPrice = entity.OriginalPrice,
                DepreciationRate = entity.DepreciationRate,
                DepreciationAmount = entity.DepreciationAmount,
                IsFixedAsset = entity.IsFixedAsset,
                IsParent = entity.IsParent,
                IsDetailByFixedAsset = entity.IsDetailByFixedAsset,
                ParentId = entity.ParentId
            };
        }

        #endregion

        #region FromDataTransferObjects

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<FixedAssetDecreaseModel> FromDataTransferObjects(IList<FixedAssetDecreaseEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }



        internal static List<FixedAssetIncreaseDecreaseModel> FromDataTransferObjects(IList<FixedAssetIncreaseDecreaseEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<InventoryFixedAssetModel> FromDataTransferObjects(IList<InventoryFixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;MinutesGetCountFixedAssetModel&gt;.</returns>
        internal static List<MinutesGetCountFixedAssetModel> FromDataTransferObjects(IList<MinutesGetCountFixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;B01HModel&gt;.</returns>
        internal static List<B01HModel> FromDataTransferObjects(IList<B01HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<C402CKBModel> FromDataTransferObjects(IList<C402CKBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C31BBEntity&gt;.</returns>
        internal static List<C41BBModel> FromDataTransferObjects(IList<C41BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S12HModel&gt;.</returns>
        internal static List<S12HModel> FromDataTransferObjects(IList<S12HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S12HDetailModel&gt;.</returns>
        internal static List<S12HDetailModel> FromDataTransferObjects(IList<S12HDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S11HModel&gt;.</returns>
        internal static List<S11HModel> FromDataTransferObjects(IList<S11HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S11HDetailModel&gt;.</returns>
        internal static List<S11HDetailModel> FromDataTransferObjects(IList<S11HDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<C408Model> FromDataTransferObjects(IList<C408Entity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S12HModel&gt;.</returns>
        internal static List<S03HModel> FromDataTransferObjects(IList<S03HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<S01HLedgerModel> FromDataTransferObjects(IList<S01HLedgerEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C33BBModel&gt;.</returns>
        internal static List<C33BBModel> FromDataTransferObjects(IList<C33BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<S13HModel> FromDataTransferObjects(IList<S13HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<C408DetailModel> FromDataTransferObjects(IList<C408DetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C21HDModel&gt;.</returns>
        internal static List<C21HDModel> FromDataTransferObjects(IList<C21HDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C20HDModel&gt;.</returns>
        internal static List<C20HDModel> FromDataTransferObjects(IList<C20HDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C4_09Model&gt;.</returns>
        internal static List<C4_09Model> FromDataTransferObjects(IList<C4_09Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C4_09Model&gt;.</returns>
        internal static List<C203NSModel> FromDataTransferObjects(IList<C203NSEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// C302
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<C302NSModel> FromDataTransferObjects(IList<C302NSEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C21HDDetailModel&gt;.</returns>
        internal static List<C4_09DetailModel> FromDataTransferObjects(IList<C4_09DetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C2_02a_NSModel&gt;.</returns>
        internal static List<C2_02a_NSModel> FromDataTransferObjects(IList<C2_02aEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C2_02a_NSDetailModel&gt;.</returns>
        internal static List<C2_02a_NSDetailModel> FromDataTransferObjects(IList<C2_02aDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C21HDDetailModel&gt;.</returns>
        internal static List<C21HDDetailModel> FromDataTransferObjects(IList<C21HDDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C20HDDetailModel&gt;.</returns>
        internal static List<C20HDDetailModel> FromDataTransferObjects(IList<C20HDDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C22HModel> FromDataTransferObjects(IList<C22HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;C212NSModel&gt;.</returns>
        internal static IList<C212NSModel> FromDataTransferObjects(IList<C212NSEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;C213NSModel&gt;.</returns>
        internal static IList<C213NSModel> FromDataTransferObjects(IList<C213NSEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C40BBModel> FromDataTransferObject(IList<C30BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C45_BBModel> FromDataTransferObject(IList<C45_BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<C40BBDetailModel> FromDataTransferObject(IList<C40BBDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<C41BBDetailModel> FromDataTransferObject(IList<C41BBDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C40BBModel> FromDataTransferObjects(IList<C30BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CashReportModel> FromDataTransferObjects(IList<CashReportEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S03BHModel> FromDataTransferObjects(IList<S03BHEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S03AHModel> FromDataTransferObjects(IList<S03AHEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B14QModel> FromDataTransferObjects(IList<B14QEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<A02LDTLModel> FromDataTransferObjects(IList<A02LDTLEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        internal static IList<B01_BCTCModel> FromDataTransferObjects(IList<B01_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B02_BCTCModel&gt;.</returns>
        internal static IList<B02_BCTCModel> FromDataTransferObjects(IList<B02_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B05_BCTCModel&gt;.</returns>
        internal static IList<B05_BCTCModel> FromDataTransferObjects(IList<B05_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B04_BCTCModel&gt;.</returns>
        internal static IList<B04_BCTCModel> FromDataTransferObjects(IList<B04_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B03a_BCTCModel&gt;.</returns>
        internal static IList<B03a_BCTCModel> FromDataTransferObjects(IList<B03a_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B03b_BCTCModel> FromDataTransferObjects(IList<B03b_BCTCEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B03BCQTModel&gt;.</returns>
        internal static IList<B03BCQTModel> FromDataTransferObjects(IList<B03BCQTEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B02BCQTModel> FromDataTransferObjects(IList<B02BCQTEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList{F0101BCQTEntity}.</returns>
        internal static IList<F0101BCQTModel> FromDataTransferObjects(IList<F0101BCQTEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B01BCQTModel> FromDataTransferObjects(IList<B01BCQTEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C11HModel> FromDataTransferObjects(IList<C11HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S04HModel&gt;.</returns>
        internal static IList<S04HModel> FromDataTransferObjects(IList<S04HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S05HModel&gt;.</returns>
        internal static IList<S05HModel> FromDataTransferObjects(IList<S05HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S31HModel&gt;.</returns>
        internal static IList<S31HModel> FromDataTransferObjects(IList<S31HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        internal static IList<S22HModel> FromDataTransferObjects(IList<S22HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S21HModel&gt;.</returns>
        internal static IList<S21HModel> FromDataTransferObjects(IList<S21HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S26HModel&gt;.</returns>
        internal static IList<S26HModel> FromDataTransferObjects(IList<S26HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S23HModel&gt;.</returns>
        internal static IList<S23HModel> FromDataTransferObjects(IList<S23HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;FixedAssetS24HModel&gt;.</returns>
        internal static IList<FixedAssetS24HModel> FromDataTransferObjects(IList<FixedAssetS24HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CashInBankConfirmationBalanceSheetModel&gt;.</returns>
        internal static IList<N02_SDKP_DVDT_TT77Model> FromDataTransferObjects(IList<N02_SDKP_DVDT_TT77Entity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;N01_SDKP_DVDTModel&gt;.</returns>
        internal static IList<N01_SDKP_DVDTModel> FromDataTransferObjects(IList<N01_SDKP_DVDTEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB03HModel> FromDataTransferObjects(IList<FixedAssetB03HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB01Model> FromDataTransferObjects(IList<FixedAssetB01Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetC55aHDModel> FromDataTransferObjects(IList<FixedAssetC55aHDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;FixedAsset30KPart2Model&gt;.</returns>
        internal static IList<FixedAsset30KPart2Model> FromDataTransferObjects(IList<FixedAsset30KPart2Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;FixedAssetB03H30KModel&gt;.</returns>
        internal static IList<FixedAssetB03H30KModel> FromDataTransferObjects(IList<FixedAssetB03H30KEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB02Model> FromDataTransferObjects(IList<FixedAssetB02Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S33HModel> FromDataTransferObjects(IList<S33HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B03BNGModel> FromDataTransferObjects(IList<B03BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;F03BNGModel&gt;.</returns>
        internal static IList<F03BNGModel> FromDataTransferObjects(IList<F03BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;F331BNGModel&gt;.</returns>
        internal static IList<F331BNGModel> FromDataTransferObjects(IList<F331BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;B09BNGModel&gt;.</returns>
        internal static IList<B09BNGModel> FromDataTransferObjects(IList<B09BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;S34H_GL_MasterModel&gt;.</returns>
        internal static IList<S34H_GL_MasterModel> FromDataTransferObjects(IList<S34H_GL_MasterEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S34H_GL_Detail_SubDetailModel&gt;.</returns>
        internal static List<S34H_GL_Detail_SubDetailModel> FromDataTransferObjects(IList<S34H_GL_Detail_SubDetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;S34H_GL_Master_LineDetailModel&gt;.</returns>
        internal static List<S34H_GL_Master_LineDetailModel> FromDataTransferObjects(IList<S34H_GL_Master_LineDetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S52H_GL_MasterModel}.</returns>
        internal static List<S52H_GL_MasterModel> FromDataTransferObjects(IList<S52H_GL_MasterEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{GL_Master_DetailModel}.</returns>
        internal static List<GL_Master_DetailModel> FromDataTransferObjects(IList<GL_Master_DetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S101HModel}.</returns>
        internal static List<S101HModel> FromDataTransferObjects(IList<S101HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S101HPartIIModel}.</returns>
        internal static List<S101HPartIIModel> FromDataTransferObjects(IList<S101HPartIIEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S101HPartIIModel}.</returns>
        internal static List<S104HModel> FromDataTransferObjects(IList<S104HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S101HPartIIModel}.</returns>
        internal static List<S101HPartIIIModel> FromDataTransferObjects(IList<S101HPartIIIEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S102H1Model}.</returns>
        internal static List<S102H1Model> FromDataTransferObjects(IList<S102H1Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List{S102H2Model}.</returns>
        internal static List<S102H2Model> FromDataTransferObjects(IList<S102H2Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<S105H1Model> FromDataTransferObjects(IList<S105H1Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<S105H2Model> FromDataTransferObjects(IList<S105H2Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// S106H2
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<S106H2Model> FromDataTransferObjects(IList<S106H2Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// S106H1
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<S106H1Model> FromDataTransferObjects(IList<S106H1Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemReportModel> FromDataTransferObjects(IList<InventoryItemReportEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;FixedAssetCardModel&gt;.</returns>
        internal static IList<FixedAssetCardModel> FromDataTransferObjects(IList<FixedAssetCardEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetC55HDModel> FromDataTransferObjects(IList<FixedAssetC55HDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;C2_02a_NSModel&gt;.</returns>
        internal static List<C304NSModel> FromDataTransferObjects(IList<C304NSEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Giấy đề nghị thanh toán vốn đầu tư
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<PaymentPurchaseModel> FromDataTransferObjects(IList<PaymentPurchaseEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<C205aModel> FromDataTransferObjects(IList<C205aEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static List<C206NSModel> FromDataTransferObjects(IList<C206NSEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C304NSModel FromDataTransferObject(C304NSEntity entity)
        {
            if (entity == null)
                return null;
            return new C304NSModel
            {
                RefIDSortOrder = entity.RefIDSortOrder,
                RefID = entity.RefID,
                RefType = entity.RefType,
                IsCash = entity.IsCash,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                BankAccount = entity.BankAccount,
                OpenInBudget = entity.OpenInBudget,
                BankName = entity.BankName,
                ProjectName = entity.ProjectName,
                ProjectCode = entity.ProjectCode,
                BudgetDistributionCode = entity.BudgetDistributionCode,
                ProgramName = entity.ProgramName,
                ProgramCode = entity.ProgramCode,
                TreasuaryBankName = entity.TreasuaryBankName,
                AccountingObjectBankName = entity.AccountingObjectBankName,
                IdentificationNumber = entity.IdentificationNumber,
                IssueDate = entity.IssueDate,
                IssueBy = entity.IssueBy,
                Description = entity.Description,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                GovSourceCode = entity.GovSourceCode,
                Amount = entity.Amount,
                SortOrder = entity.SortOrder,
                Part = entity.Part,
                LineInGroup = entity.LineInGroup,
                MaxRow = entity.MaxRow,
                BudgetSubItemCode = entity.BudgetSubItemCode
            };
        }

        /// <summary>
        /// Giấy đề nghị thanh toán vốn đầu tư
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static PaymentPurchaseModel FromDataTransferObject(PaymentPurchaseEntity entity)
        {
            if (entity == null)
                return null;
            return new PaymentPurchaseModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefType = entity.RefType,
                DomesticArising = entity.DomesticArising,
                ForeignArising = entity.ForeignArising,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Description = entity.Description,
                SortOrder = entity.SortOrder,
                ProjectName = entity.ProjectName,
                ProjectCode = entity.ProjectCode,
                GovSourceCode = entity.GovSourceCode,
                ApprovedQuanlity = entity.ApprovedQuanlity,
                DomesticAccumulated = entity.DomesticAccumulated,
                ForeignAccumulated = entity.ForeignAccumulated,
                EditVersion = entity.EditVersion
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static C206NSModel FromDataTransferObject(C206NSEntity entity)
        {
            if (entity == null)
                return null;
            return new C206NSModel
            {
                RefIDSortOrder = entity.RefIDSortOrder,
                ID = entity.ID,
                BankName = entity.BankName,
                BankAccount = entity.BankAccount,
                TargetProgramID = entity.TargetProgramID,
                TargetProgramCode = entity.TargetProgramCode,
                TargetProgramName = entity.TargetProgramName,
                RefID = entity.RefID,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                JournalMemo = entity.JournalMemo,
                CashWithDrawType = entity.CashWithDrawType,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                AccountingObjectBankAccount = entity.AccountingObjectBankAccount,
                AccountingObjectBankName = entity.AccountingObjectBankName,
                AccountingObjectTargetProgramCode = entity.AccountingObjectTargetProgramCode,
                AccountingObjectTargetProgramName = entity.AccountingObjectTargetProgramName,
                IssueDate = entity.IssueDate,
                IssueBy = entity.IssueBy,
                AreaCode = entity.AreaCode,
                IdentificationNumber = entity.IdentificationNumber,
                BudgetCode = entity.BudgetCode,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                BudgetSourceID = entity.BudgetSourceID,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                Property = entity.Property,
                Description = entity.Description,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                Part = entity.Part,
                LineInGroup = entity.LineInGroup,
                MaxRow = entity.MaxRow,
                OrderType = entity.OrderType,
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static C205aModel FromDataTransferObject(C205aEntity entity)
        {
            if (entity == null)
                return null;
            return new C205aModel
            {
                IsCash = entity.IsCash,
                RefID = entity.RefID,
                RefIDSortOrder = entity.RefIDSortOrder,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefType = entity.RefType,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                JournalMemo = entity.JournalMemo,
                GovSourceCode = entity.GovSourceCode,
                BudgetDistributionCode = entity.BudgetDistributionCode,
                AccountingObjectName = entity.AccountingObjectName,
                Description = entity.Description,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                CurrencyCode = entity.CurrencyCode,
                ProjectCode = entity.ProjectCode,
                ProjectName = entity.ProjectName,
                BudgetType = entity.BudgetType,
                Part = entity.Part,
                LineInGroup = entity.LineInGroup,
                MaxRow = entity.MaxRow,
            };
        }

        #endregion

        #region ReportDataTemplate

        internal static ReportDataTemplateModel FromDataTransferObject(ReportDataTemplateEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportDataTemplateEntity, ReportDataTemplateModel>(entity);
        }

        internal static ReportDataTemplateEntity ToDataTransferObject(ReportDataTemplateModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportDataTemplateModel, ReportDataTemplateEntity>(model);
        }

        internal static IList<ReportDataTemplateModel> FromDataTransferObjects(IList<ReportDataTemplateEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportDataTemplateEntity>, IList<ReportDataTemplateModel>>(entities);
        }

        internal static IList<ReportDataTemplateEntity> ToDataTransferObjects(IList<ReportDataTemplateModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportDataTemplateModel>, IList<ReportDataTemplateEntity>>(models);
        }

        #endregion
        #region ToDataTransferObject
        #endregion

        #region ToDataTransferObjects
        #endregion
    }
}
