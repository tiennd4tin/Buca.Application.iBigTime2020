/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerFixedAssetDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.DaoBase" />
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IFixedAssetDao" />
    public class SqlServerFixedAssetDao : DaoBase, IFixedAssetDao
    {
        #region IFixedAsset Members

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetOnFixedAssetIncrement(int fixedAssetId)
        {
            const string sql = @"uspGet_Check_Fa_In_FaIncrementDetail";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetByCode(string fixedAssetCode)
        {
            object[] parms = { "@FixedAssetCode", fixedAssetCode };
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCode";
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetById(string fixedAssetId)
        {
            object[] parms = { "@FixedAssetId", fixedAssetId };
            const string sql = @"uspGet_FixedAsset_ByFixedAssetId";
            return Db.Read(sql, true, Make<FixedAssetEntity>, parms);
        }

        /// <summary>
        /// Gets the fixed asset activity by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetActivityEntity> GetFixedAssetActivityById(string fixedAssetId)
        {
            object[] parms = { "@FixedAssetId", fixedAssetId };
            const string sql = @"uspGet_FixedAssetActivity_ByFixedAssetId";
            return Db.ReadList(sql, true, MakeFixedAssetActivity, parms);
        }

        /// <summary>
        /// Gets the fixed asset by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByCode(string fixedAssetCode)
        {
            object[] parms = { "@FixedAssetCode", fixedAssetCode };
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCode";
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, int refTypeId)
        {
            const string sql = @"uspCheck_FADecrement";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@RefTypeID", refTypeId };
            return Db.Read(sql, true, MakeForDecrementQuantity, parms);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetOpening(int fixedAssetId)
        {
            const string sql = @"uspCheck_FAOpening";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, MakeOnlyFixedAssetId, parms);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, DateTime postedDate)
        {
            const string sql = @"uspGet_FixedAssetDecrement";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@CurrencyCode", currencyCode, "@ToDate", postedDate };
            return Db.Read(sql, true, MakeForDecrement, parms);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, int refTypeId)
        {
            const string sql = @"uspGet_FixedAssetDecrementQuantity";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@CurrencyCode", currencyCode, "@RefTypeID", refTypeId };
            return Db.Read(sql, true, MakeForDecrementQuantity, parms);
        }

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAsset(int fixedAssetId)
        {
            const string sql = @"uspGet_FixedAsset_ByID";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetRemainingQuantity(int fixedAssetId)
        {
            const string sql = @"uspCheck_FixedAsset_RemainingQuantity";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets all fixed assets with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetAllFixedAssetsWithStoreProdure(string storeProdure)
        {
            return Db.ReadList(storeProdure, true, Make);
        }

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssets()
        {
            const string procedures = @"uspGet_All_FixedAsset";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByActive(bool isActive)
        {
            const string sql = @"uspGet_FixedAsset_ByActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        public List<FixedAssetEntity> GetFixedAssetsActiveDecre(bool isActive, string refId)
        {
            const string sql = @"uspGet_FixedAsset_ByActive_Decre";

            object[] parms = { "@IsActive", isActive, "@ReffId", refId };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsForDecrement(bool isActive, DateTime refDate)
        {
            const string sql = @"uspGet_FixedAsset_ForDecrement";
            object[] parms = { "@IsActive", isActive, "@RefDate", refDate };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsForAdjustment(string fixedAssetId, DateTime postedDate, int refType, bool isForceGetOnLedger)
        {
            const string sql = @"usp_PostFixedAsset_GetLastedInfoForPost";
            object[] parms = { "@ListFixedAssetID", fixedAssetId, "@PostedDate", postedDate, "@Reftype", refType, "@IsForceGetOnLedger", isForceGetOnLedger,"@RefId",null };
            return Db.ReadList(sql, true, MakeForAdjusment, parms);
        }

        /// <summary>
        /// Gets the fixed assets by increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByIncrement(string fixedAssetId)
        {
            const string sql = @"uspGet_FixedAsset_ByFixedAssetId_ForIncrement";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed assets by fixed asset category code.
        /// </summary>
        /// <param name="fixedAssetCategoryCode">The fixed asset category code.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryCode(string fixedAssetCategoryCode)
        {
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCategorycode";

            object[] parms = { "@FixedAssetCategoryCode", fixedAssetCategoryCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed assets by fixed asset TMDT.
        /// </summary>
        /// <param name="yearPosted">The year posted.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetTMDT(int yearPosted)
        {
            const string sql = @"uspReport_FixedAssetEsTimate_CarTMDT";

            object[] parms = { "@Year", yearPosted };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed assets by fixed asset category identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryId(int fixedAssetCategoryId)
        {
            const string sql = @"uspGet_FixedAsset_ByFixedAsseyCategoryID";

            object[] parms = { "@FixedAsseyCategoryID", fixedAssetCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fixed asset category.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset category.</param>
        /// <returns></returns>
        public string InsertFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = "uspInsert_FixedAsset";
            return Db.Insert(sql, true, Take(fixedAsset));
        }

        /// <summary>
        /// Inserts the fixed asset activity.
        /// </summary>
        /// <param name="fixedAssetActivity">The fixed asset activity.</param>
        /// <returns></returns>
        public string InsertFixedAssetActivity(FixedAssetActivityEntity fixedAssetActivity)
        {
            const string sql = "uspInsert_FixedAssetActivity";
            return Db.Insert(sql, true, TakeFixAssetActivity(fixedAssetActivity));
        }

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        public string UpdateFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = "uspUpdate_FixedAsset";
            return Db.Update(sql, true, Take(fixedAsset));
        }

        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        public string DeleteFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = @"uspDelete_FixedAsset";
            object[] parms = { "@FixedAssetID", fixedAsset.FixedAssetId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteFixedAssetConvert( )
        {
            const string sql = @"usp_ConvertFixedAsset";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the fixed asset activity.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        public string DeleteFixedAssetActivity(FixedAssetEntity fixedAsset)
        {
            const string sql = @"uspDelete_FixedAssetActivity";
            object[] parms = { "@FixedAssetID", fixedAsset.FixedAssetId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Gets the fixed asset voucher attach by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetVoucherAttachEntity> GetFixedAssetVoucherAttachByFixedAssetId(string fixedAssetId)
        {
            object[] parms = { "@FixedAssetId", fixedAssetId };
            const string sql = @"uspGet_FixedAssetDetailVoucher_ByFixedAssetId";
            return Db.ReadList(sql, true, MakeFixedAssetVoucher, parms); 
        }

        #endregion

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetEntity> Make = reader =>
            new FixedAssetEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsString(),
                FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                Quantity = reader["Quantity"].AsDecimal(),
                Description = reader["Description"].AsString(),
                ProductionYear = reader["ProductionYear"].AsInt(),
                MadeIn = reader["MadeIn"].AsString(),
                SerialNumber = reader["SerialNumber"].AsString(),
                Accessories = reader["Accessories"].AsString(),
                VendorId = reader["VendorID"].AsString(),
                GuaranteeDuration = reader["GuaranteeDuration"].AsString(),
                IsSecondHand = reader["IsSecondHand"].AsBool(),
                LastState = reader["LastState"].AsInt(),
                DisposedDate = reader["DisposedDate"].AsDateTime(),
                DisposedAmount = reader["DisposedAmount"].AsDecimal(),
                DisposedReason = reader["DisposedReason"].AsString(),
                PurchasedDate = reader["PurchasedDate"].AsDateTime(),
                UsedDate = reader["UsedDate"].AsDateTime(),
                DepreciationDate = reader["DepreciationDate"].AsDateTime(),
                IncrementDate = reader["IncrementDate"].AsDateTime(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                DepreciationValueCaculated = reader["DepreciationValueCaculated"].AsDecimal(),
                AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                LifeTime = reader["LifeTime"].AsInt(),
                DepreciationRate = reader["DepreciationRate"].AsDecimal(),
                PeriodDepreciationAmount = reader["PeriodDepreciationAmount"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                RemainingLifeTime = reader["RemainingLifeTime"].AsInt(),
                EndYear = reader["EndYear"].AsInt(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                CapitalAccount = reader["CapitalAccount"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                CreditDepreciationAccount = reader["CreditDepreciationAccount"].AsString(),
                DebitDepreciationAccount = reader["DebitDepreciationAccount"].AsString(),
                IsFixedAssetTransfer = reader["IsFixedAssetTransfer"].AsBool(),
                DepreciationTimeCaculated = reader["DepreciationTimeCaculated"].AsDecimal(),
                Unit = reader["Unit"].AsString(),
                Source = reader["Source"].AsInt(),
                IsActive = reader["IsActive"].AsBool(),
                RevenueAccount = reader["RevenueAccount"].AsString(),
                UsingRatio = reader["UsingRatio"].AsDecimal(),
                DevaluationDate = reader["DevaluationDate"].AsDateTime(),
                DevaluationPeriod = reader["DevaluationPeriod"].AsInt(),
                DevaluationRate = reader["DevaluationRate"].AsDecimal(),
                DevaluationLifeTime = reader["DevaluationLifeTime"].AsDecimal(),
                DevaluationCreditAccount = reader["DevaluationCreditAccount"].AsString(),
                DevaluationDebitAccount = reader["DevaluationDebitAccount"].AsString(),
                AccumDevaluationAmount = reader["AccumDevaluationAmount"].AsDecimal(),
                EndDevaluationDate = reader["EndDevaluationDate"].AsDateTime(),
                PeriodDevaluationAmount = reader["PeriodDevaluationAmount"].AsDecimal(),
                DevaluationAmount = reader["DevaluationAmount"].AsDecimal(),
                FundStructureId = reader["FundStructureId"].AsString(),
            };

        private static readonly Func<IDataReader, FixedAssetEntity> MakeForAdjusment = reader =>
            new FixedAssetEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                LifeTime = reader["LifeTime"].AsInt(),
                DepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
                PeriodDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                Quantity = reader["Quantity"].AsDecimal(),
                RemainingLifeTime = reader["RemainingLifeTime"].AsInt(),
                EndYear = reader["EndYear"].AsInt(),
                DepartmentId = reader["DepartmentID"].AsString(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                DevaluationRate = reader["DevaluationRate"].AsDecimal(),
                PeriodDevaluationAmount = reader["PeriodDevaluationAmount"].AsDecimal(),
                DevaluationAmount = reader["DevaluationAmount"].AsDecimal(),
                EndDevaluationDate = reader["EndDevaluationDate"].AsDateTime(),
                OrgPrice = reader["OrgPriceDebitAmount"].AsDecimal(),
                DebitDepreciationAccount = reader["DepreciationAccount"].AsString(),
                DevaluationLifeTime = reader["RemainingDevaluationLifeTime"].AsDecimal(),
                DevaluationPeriod = reader["DevaluationPeriod"].AsInt(),
                OrgPriceCreditAmount = reader["OrgPriceCreditAmount"].AsDecimal(),
                DepreciationDebitAmount = reader["DepreciationDebitAmount"].AsDecimal(),
                DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                DevaluationDebitAmount = reader["DevaluationDebitAmount"].AsDecimal(),
                DevaluationCreditAmount = reader["DevaluationCreditAmount"].AsDecimal(),
                AccumDepreciationAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                AccumDevaluationAmount = reader["DevaluationCreditAmount"].AsDecimal(),

                //NewAnnualDepreciationAmount = reader["NewAnnualDepreciationAmount"].AsDecimal(),
                //OldAnnualDepreciationAmount = reader["OldAnnualDepreciationAmount"].AsDecimal(),
                //DiffAnnualDepreciationAmount = reader["DiffAnnualDepreciationAmount"].AsDecimal()


                //FixedAssetId = reader["FixedAssetID"].AsString(),
                //FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString(),
                //DepartmentId = reader["DepartmentID"].AsString(),
                //FixedAssetCode = reader["FixedAssetCode"].AsString(),
                //FixedAssetName = reader["FixedAssetName"].AsString(),
                //Quantity = reader["Quantity"].AsDecimal(),
                //Description = reader["Description"].AsString(),
                //ProductionYear = reader["ProductionYear"].AsInt(),
                //MadeIn = reader["MadeIn"].AsString(),
                //SerialNumber = reader["SerialNumber"].AsString(),
                //Accessories = reader["Accessories"].AsString(),
                //VendorId = reader["VendorID"].AsString(),
                //GuaranteeDuration = reader["GuaranteeDuration"].AsString(),
                //IsSecondHand = reader["IsSecondHand"].AsBool(),
                //LastState = reader["LastState"].AsInt(),
                //DisposedDate = reader["DisposedDate"].AsDateTime(),
                //DisposedAmount = reader["DisposedAmount"].AsDecimal(),
                //DisposedReason = reader["DisposedReason"].AsString(),
                //PurchasedDate = reader["PurchasedDate"].AsDateTime(),
                //UsedDate = reader["UsedDate"].AsDateTime(),
                //DepreciationDate = reader["DepreciationDate"].AsDateTime(),
                //IncrementDate = reader["IncrementDate"].AsDateTime(),
                //OrgPrice = reader["OrgPrice"].AsDecimal(),
                //DepreciationValueCaculated = reader["DepreciationValueCaculated"].AsDecimal(),
                //AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                //LifeTime = reader["LifeTime"].AsInt(),
                //DepreciationRate = reader["DepreciationRate"].AsDecimal(),
                //PeriodDepreciationAmount = reader["PeriodDepreciationAmount"].AsDecimal(),
                //RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                //RemainingLifeTime = reader["RemainingLifeTime"].AsInt(),
                //EndYear = reader["EndYear"].AsInt(),
                //OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                //CapitalAccount = reader["CapitalAccount"].AsString(),
                //BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                //BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                //BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                //BudgetItemCode = reader["BudgetItemCode"].AsString(),
                //BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                //CreditDepreciationAccount = reader["CreditDepreciationAccount"].AsString(),
                //DebitDepreciationAccount = reader["DebitDepreciationAccount"].AsString(),
                //IsFixedAssetTransfer = reader["IsFixedAssetTransfer"].AsBool(),
                //DepreciationTimeCaculated = reader["DepreciationTimeCaculated"].AsDecimal(),
                //Unit = reader["Unit"].AsString(),
                //Source = reader["Source"].AsInt(),
                //IsActive = reader["IsActive"].AsBool(),
                //RevenueAccount = reader["RevenueAccount"].AsString(),
                //UsingRatio = reader["UsingRatio"].AsDecimal(),
                //DevaluationDate = reader["DevaluationDate"].AsDateTime(),
                //DevaluationPeriod = reader["DevaluationPeriod"].AsInt(),
                //DevaluationRate = reader["DevaluationRate"].AsDecimal(),
                //DevaluationLifeTime = reader["DevaluationLifeTime"].AsDecimal(),
                //DevaluationCreditAccount = reader["DevaluationCreditAccount"].AsString(),
                //DevaluationDebitAccount = reader["DevaluationDebitAccount"].AsString(),
                //AccumDevaluationAmount = reader["AccumDevaluationAmount"].AsDecimal(),
                //EndDevaluationDate = reader["EndDevaluationDate"].AsDateTime(),
                //PeriodDevaluationAmount = reader["PeriodDevaluationAmount"].AsDecimal(),
                //DevaluationAmount = reader["DevaluationAmount"].AsDecimal(),
            };

        /// <summary>
        /// The make fixed asset activity
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetActivityEntity> MakeFixedAssetActivity = reader =>
            new FixedAssetActivityEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsString(),
                FixedAssetActivityId = reader["FixedAssetActivityID"].AsString(),
                DepreciationValueCaculated = reader["DepreciationValueCaculated"].AsDecimal(),
                CreditDepreciationAccount = reader["CreditDepreciationAccount"].AsString(),
                DebitDepreciationAccount = reader["DebitDepreciationAccount"].AsString(),
            };

        /// <summary>
        /// The make fixed asset voucher
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetVoucherAttachEntity> MakeFixedAssetVoucher = reader =>
            new FixedAssetVoucherAttachEntity
            {
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                DebitAccount = reader["DebitAccount"].AsString(),
                Description = reader["Description"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                AmountOC = reader["AmountOC"].AsDecimal()
            };


        /// <summary>
        /// The make for decrement
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetEntity> MakeForDecrement = reader =>
            new FixedAssetEntity
            {
                //FixedAssetId = reader["FixedAssetID"].AsInt(),
                //OrgPrice = reader["OrgPrice"].AsDecimal(),
                //AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                //OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal(),
                //AccumDepreciationAmountUSD = reader["AccumDepreciationAmountUSD"].AsDecimal(),
                //RemainingOrgPrice = reader["RemainingOrgPrice"].AsDecimal(),
                //RemainingOrgPriceUSD = reader["RemainingOrgPriceUSD"].AsDecimal(),

            };

        /// <summary>
        /// The make for decrement quantity
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetEntity> MakeForDecrementQuantity = reader =>
            new FixedAssetEntity
            {
                //FixedAssetId = reader["FixedAssetID"].AsInt(),
                //Quantity = reader["Quantity"].AsInt(),
                //State = reader["State"].AsInt()
            };

        /// <summary>
        /// The make only fixed asset identifier
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetEntity> MakeOnlyFixedAssetId = reader =>
            new FixedAssetEntity
            {
                //FixedAssetId = reader["FixedAssetID"].AsInt()
            };

        /// <summary>
        /// Takes the specified fixed asset.
        /// </summary>
        /// <param name="fixedAssetEntity">The fixed asset.</param>
        /// <returns></returns>
        private object[] Take(FixedAssetEntity fixedAssetEntity)
        {
            return new object[]
            {
                "@FixedAssetID",fixedAssetEntity.FixedAssetId,
                "@FixedAssetCategoryID",fixedAssetEntity.FixedAssetCategoryId,
                "@DepartmentID",fixedAssetEntity.DepartmentId,
                "@FixedAssetCode",fixedAssetEntity.FixedAssetCode,
                "@FixedAssetName",fixedAssetEntity.FixedAssetName,
                "@Quantity",fixedAssetEntity.Quantity,
                "@Description",fixedAssetEntity.Description,
                "@ProductionYear",fixedAssetEntity.ProductionYear,
                "@MadeIn",fixedAssetEntity.MadeIn,
                "@SerialNumber",fixedAssetEntity.SerialNumber,
                "@Accessories",fixedAssetEntity.Accessories,
                "@VendorID",fixedAssetEntity.VendorId,
                "@GuaranteeDuration",fixedAssetEntity.GuaranteeDuration,
                "@IsSecondHand",fixedAssetEntity.IsSecondHand,
                "@LastState",fixedAssetEntity.LastState,
                "@DisposedDate",fixedAssetEntity.DisposedDate,
                "@DisposedAmount",fixedAssetEntity.DisposedAmount,
                "@DisposedReason",fixedAssetEntity.DisposedReason,
                "@PurchasedDate",fixedAssetEntity.PurchasedDate,
                "@UsedDate",fixedAssetEntity.UsedDate,
                "@DepreciationDate",fixedAssetEntity.DepreciationDate,
                "@IncrementDate",fixedAssetEntity.IncrementDate,
                "@OrgPrice",fixedAssetEntity.OrgPrice,
                "@DepreciationValueCaculated",fixedAssetEntity.DepreciationValueCaculated,
                "@AccumDepreciationAmount",fixedAssetEntity.AccumDepreciationAmount,
                "@LifeTime",fixedAssetEntity.LifeTime,
                "@DepreciationRate",fixedAssetEntity.DepreciationRate,
                "@PeriodDepreciationAmount",fixedAssetEntity.PeriodDepreciationAmount,
                "@RemainingAmount",fixedAssetEntity.RemainingAmount,
                "@RemainingLifeTime",fixedAssetEntity.RemainingLifeTime,
                "@EndYear",fixedAssetEntity.EndYear,
                "@OrgPriceAccount",fixedAssetEntity.OrgPriceAccount,
                "@CapitalAccount",fixedAssetEntity.CapitalAccount,
                "@BudgetChapterCode",fixedAssetEntity.BudgetChapterCode,
                "@BudgetKindItemCode",fixedAssetEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",fixedAssetEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",fixedAssetEntity.BudgetItemCode,
                "@BudgetSubItemCode",fixedAssetEntity.BudgetSubItemCode,
                "@CreditDepreciationAccount",fixedAssetEntity.CreditDepreciationAccount,
                "@DebitDepreciationAccount",fixedAssetEntity.DebitDepreciationAccount,
                "@IsFixedAssetTransfer",fixedAssetEntity.IsFixedAssetTransfer,
                "@DepreciationTimeCaculated",fixedAssetEntity.DepreciationTimeCaculated,
                "@Unit",fixedAssetEntity.Unit,
                "@Source",fixedAssetEntity.Source,
                "@IsActive",fixedAssetEntity.IsActive,
                "@RevenueAccount",fixedAssetEntity.RevenueAccount,
                "@UsingRatio",fixedAssetEntity.UsingRatio,
                "@DevaluationDate",fixedAssetEntity.DevaluationDate,
                "@DevaluationPeriod",fixedAssetEntity.DevaluationPeriod,
                "@DevaluationRate",fixedAssetEntity.DevaluationRate,
                "@DevaluationLifeTime",fixedAssetEntity.DevaluationLifeTime,
                "@DevaluationCreditAccount",fixedAssetEntity.DevaluationCreditAccount,
                "@DevaluationDebitAccount",fixedAssetEntity.DevaluationDebitAccount,
                "@AccumDevaluationAmount",fixedAssetEntity.AccumDevaluationAmount,
                "@EndDevaluationDate",fixedAssetEntity.EndDevaluationDate,
                "@PeriodDevaluationAmount",fixedAssetEntity.PeriodDevaluationAmount,
                "@DevaluationAmount", fixedAssetEntity.DevaluationAmount,
                 "@FundStructureId", fixedAssetEntity.FundStructureId
    };
        }

        /// <summary>
        /// Takes the fix asset activity.
        /// </summary>
        /// <param name="fixedAssetActivityEntity">The fixed asset activity entity.</param>
        /// <returns></returns>
        private object[] TakeFixAssetActivity(FixedAssetActivityEntity fixedAssetActivityEntity)
        {
            return new object[]
            {
                "@FixedAssetID",fixedAssetActivityEntity.FixedAssetId,
                "@FixedAssetActivityID",fixedAssetActivityEntity.FixedAssetActivityId,
                "@CreditDepreciationAccount",fixedAssetActivityEntity.CreditDepreciationAccount,
                "@DebitDepreciationAccount",fixedAssetActivityEntity.DebitDepreciationAccount,
                "@DepreciationValueCaculated",fixedAssetActivityEntity.DepreciationValueCaculated,
            };
        }
    }
}
