/***********************************************************************
 * <copyright file="IReportListDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReportListDao
    {
        ReportListEntity GetReportListByReportId(string reportId);

        List<ReportListEntity> GetReportListByParentId(string parentId);

        /// <summary>
        /// Gets the B01 h with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<B01HEntity> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate,
                                                  string currencyCode, int amounType);
        /// <summary>
        /// Gets the S03 ah with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<S03AHEntity> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        /// <summary>
        /// Gets the S33 h with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="selectedField">The selected field.</param>
        /// <param name="selectedAllValueField">The selected all value field.</param>
        /// <returns></returns>
        IList<S33HEntity> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate,
                                                          string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField);
        /// <summary>
        /// Gets the B14 q with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="stockIdList">The stock identifier list.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<B14QEntity> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType);


        IList<A02LDTLEntity> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate);


        IList<A02LDTLEntity> Get02LdtlRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee);
        IList<ReportB04BCTCEntity> GetReportB04BCTC(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns></returns>
        List<ReportListEntity> GetReportLists();

        /// <summary>
        /// Gets the reports by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        List<ReportListEntity> GetReportsByIsActive(bool isActive,string loginName);

        /// <summary>
        /// Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        List<ReportListEntity> GetReportsByRefType(int refType);

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns></returns>
        List<ReportListEntity> GetReportListsByReportGroup(int reportGroupId);

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportListId">The report list identifier.</param>
        /// <returns></returns>
        ReportListEntity GetReportListById(string reportListId);

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <param name="reftypeId">The reftype identifier.</param>
        /// <returns></returns>
        IList<AccountingVoucherEntity> GetAccountingVoucher(string storeProdure, string refIdList, int reftypeId);

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<C22HEntity> GetReportC22H(string storeProdure, string refIdList);

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<C11HEntity> GetReportC11H(string storeProdure, string refIdList);

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<InventoryItemReportEntity> GetInventoryItems(string refIdList);

        /// <summary>
        /// Updates the report.
        /// </summary>
        /// <param name="reportListEntity">The report list entity.</param>
        /// <returns></returns>
        string UpdateReport(ReportListEntity reportListEntity);


        #region Estimate Report

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns></returns>
        List<GeneralReceiptEstimateEntity> GetGeneralReceiptEstimates(short yearOfEsitamte);

        /// <summary>
        /// Gets the general payment estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns></returns>
        List<GeneralPaymentEstimateEntity> GetGeneralPaymentEstimates(short yearOfEsitamte);

        /// <summary>
        /// Gets the general estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns></returns>
        List<GeneralEstimateEntity> GetGeneralEstimates(short yearOfEsitamte);

        /// <summary>
        /// Gets the general payment detail estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns></returns>
        List<GeneralPaymentDetailEstimateEntity> GetGeneralPaymentDetailEstimates(short yearOfEsitamte);

        /// <summary>
        /// Gets the employee for estimate report.
        /// </summary>
        /// <returns></returns>
        List<EmployeeForEstimateEntity> GetEmployeeForEstimateReport(bool IsCompanyProfile);

        /// <summary>
        /// Gets the fixed asset for estimate report.
        /// </summary>
        /// <returns></returns>
        List<FixedAssetForEstimateEntity> GetFixedAssetForEstimateReport();

        /// <summary>
        /// Gets the fund stuations.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        List<FundStuationEntity> GetFundStuations(short yearOfEstimate);

        #endregion

        #region Financial Report

        /// <summary>
        /// Gets the report B03 bn gs.
        /// </summary>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<B03BNGEntity> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report F03 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<F03BNGEntity> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report F331 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<F331BNGEntity> GetReportF331BNGs(string storeProcedureName, short amountType, string accountCode, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report B09 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<B09BNGEntity> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);
        #endregion

        #region FixedAsset Report

        /// <summary>
        /// Gets the fixed asset B03 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetB03HEntity> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset B03 h amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetB03HEntity> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset B03 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetB01Entity> GetFixedAssetB01(string fromDate, string toDate, string currencyCode);

        /// <summary>
        /// Gets the fixed asset B03 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetB01Entity> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits);
        /// <summary>
        /// Gets the fixed asset c55a hd.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetC55aHDEntity> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter,
                                                         string faCategoryCode, string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset c55a hd amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetC55aHDEntity> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter,
            string faCategoryCode, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory(string fromDate, string toDate,
                                                                   string currencyCode, int currencyDecimalDigits);

        /// <summary>
        /// Gets the type of the fixed asset fa inventory amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory house.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouse(string fromDate, string toDate,
                                                                   string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset fa inventory house amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory car.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCar(string fromDate, string toDate,
                                                                   string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset fa inventory car amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory3000(string fromDate, string toDate,
                                                                   string currencyCode);

        /// <summary>
        /// Gets the fixed asset fa inventory amount type3000.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FixedAssetB02Entity> GetFixedAssetB02(string fromDate, string toDate,
                                                                   string currencyCode);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        List<FixedAssetB02Entity> GetFixedAssetB02ByAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        List<FixedAssetB03H30KEntity> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits);
        List<FixedAsset30KPart2Entity> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits);

        List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAB01Car(string fromDate, string toDate,
            int currencyDecimalDigits);

        List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAB01House(string fromDate, string toDate,
            int currencyDecimalDigits);

        List<FixedAsset30KPart2Entity> GetFixedAssetFAB0130KPart2(string fromDate, string toDate,
            int currencyDecimalDigits);

        IList<FixedAssetCardEntity> GetFixedAssetCard(string fixedAssetId, int currencyDecimalDigits);
        /// <summary>
        /// Gets the fixed asset S24 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="usePurpose">The use purpose.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="fixedAssetCategoryGrade">The fixed asset category grade.</param>
        /// <param name="printByCondition">if set to <c>true</c> [print by condition].</param>
        /// <param name="printFixedAssetOpening">if set to <c>true</c> [print fixed asset opening].</param>
        /// <param name="printFixedAssetIncrementInYear">if set to <c>true</c> [print fixed asset increment in year].</param>
        /// <param name="printFixedAssetNotIncrement">if set to <c>true</c> [print fixed asset not increment].</param>
        /// <param name="listFixedAssetID">The list fixed asset identifier.</param>
        /// <returns>IList&lt;FixedAssetS24HEntity&gt;.</returns>
        IList<FixedAssetS24HEntity> GetFixedAssetS24H(string fromDate, string toDate, int usePurpose, string departmentId, string fixedAssetCategoryId, int fixedAssetCategoryGrade, bool printByCondition, bool printFixedAssetOpening, bool printFixedAssetIncrementInYear, bool printFixedAssetNotIncrement, string listFixedAssetID, int amountType, string currencyCode);
        #endregion
        IList<S26HEntity> GetReportFixedAssetS26H(DateTime fromDate, DateTime toDate, string departmentId, string inventoryItemCategoryId, int amountType, string currencyCode);

        #region CashReport


        /// <summary>
        /// Cashes the repport list geneal.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <returns></returns>
        List<CashReportEntity> CashRepportListGeneal(string storeProcedure, string fromdate, string toDate, string accountNumber, string currencyCode, int amountType, bool isBank, int? bankId);

        /// <summary>
        /// Cashes the repport list detail.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <returns></returns>
        List<CashReportEntity> CashRepportListDetail(string storeProcedure, string fromdate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType, bool isBank, int? bankId);

        /// <summary>
        /// Gets the S03 bh with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <returns></returns>
        List<S03BHEntity> GetS03BHWithStoreProdure(string storeProcedure, string fromdate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType);


        #endregion

        #region Voucher
        /// <summary>
        /// Gets the report C30 bb.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<C30BBEntity> GetReportC30BB(int year, int refTypeId);

        /// <summary>
        /// Gets the report C30 bb item.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<C30BBEntity> GetReportC30BBItem(int year, int refTypeId);

        /// <summary>
        /// Gets the report receipt voucher.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<C30BB501Entity> GetReportC30BB501(string storeProdure, string refIdList);

        #endregion
    }
}
