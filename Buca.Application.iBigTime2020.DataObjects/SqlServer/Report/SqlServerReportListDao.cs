/***********************************************************************
 * <copyright file="SqlServerReportListDao.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlServer ReportList Dao
    /// </summary>
    public class SqlServerReportListDao : DaoBase, IReportListDao
    {
        #region IReportListDao Members
        public ReportListEntity GetReportListByReportId(string reportId)
        {
            const string procedures = @"uspGet_ReportList_ByReportID";
            var param = new object[] { "@ReportID", reportId };
            return Db.Read(procedures, true, Make<ReportListEntity>, param);
        }

        public List<ReportListEntity> GetReportListByParentId(string parentId)
        {
            const string procedures = @"uspGet_ReportList_ByParentID";
            var param = new object[] { "@ParentID", parentId };
            return Db.ReadList(procedures, true, Make<ReportListEntity>, param);
        }

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns>
        /// List&lt;ReportListEntity&gt;.
        /// </returns>
        public List<ReportListEntity> GetReportLists()
        {
            const string procedures = @"uspGet_All_ReportList";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the reports by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        public List<ReportListEntity> GetReportsByIsActive(bool isActive, string loginName)
        {
            const string procedures = @"uspGet_ReportList_ByIsActive";
            var param = new object[] { "@IsActive", isActive, "@UserName",loginName };
            return Db.ReadList(procedures, true, Make, param);
        }

        /// <summary>
        /// Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        public List<ReportListEntity> GetReportsByRefType(int refType)
        {
            const string procedures = @"uspGet_ReportList_ByRefType";
            var param = new object[] { "@RefType", refType };
            return Db.ReadList(procedures, true, Make, param);
        }

        /// <summary>
        /// Updates the report list.
        /// </summary>
        /// <param name="reportListEntity">The report list entity.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string UpdateReportList(ReportListEntity reportListEntity)
        {

            object[] parms = { "@ReportID", reportListEntity.ReportId, "@PrintVoucherDefault", reportListEntity.PrintVoucherDefault };
            const string procedures = @"uspGet_All_ReportList";
            return Db.Update(procedures, true, parms);
        }

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns>
        /// List&lt;ReportListEntity&gt;.
        /// </returns>
        public List<ReportListEntity> GetReportListsByReportGroup(int reportGroupId)
        {
            const string sql = @"uspGet_ReportList_ByReportGroupID";

            object[] parms = { "@ReportGroupID", reportGroupId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportListId">The report list identifier.</param>
        /// <returns>
        /// ReportListEntity.
        /// </returns>
        public ReportListEntity GetReportListById(string reportListId)
        {
            const string sql = @"uspGet_ReportList_ByID";

            object[] parms = { "@ReportListID", reportListId };
            return Db.Read(sql, true, Make, parms);
        }

        #endregion

        #region Reports

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns>
        /// IList&lt;C22HEntity&gt;.
        /// </returns>
        public IList<C22HEntity> GetReportC22H(string storeProdure, string refIdList)
        {
            IList<C22HEntity> list = new List<C22HEntity>();
            foreach (var refId in refIdList.Split(';'))
            {

                object[] parms = { "@RefID", refId };
                var obj = Db.Read(storeProdure, true, MakeC22HD, parms);
                if (obj != null)
                {
                    list.Add(obj);
                }

            }
            return list;// Db.ReadList(sql, true, MakeC22HD, parms);
        }


        public IList<A02LDTLEntity> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate)
        {

            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate)
                };
            return Db.ReadList(storeProdure, true, Make02Ldt, parms);


        }

        public IList<A02LDTLEntity> Get02LdtlRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee)
        {
            object[] parms =
                {
                    "@FromDate", fromDate,
                    "@ToDate", toDate,
                    "@WhereClause",whereClause,
                    "@IsEmployee",isEmployee
                };

            return Db.ReadList(storeProdure, true, Make02Ldt, parms);
        }


        /// <summary>
        /// The make02 LDT
        /// </summary>
        private static readonly Func<IDataReader, A02LDTLEntity> Make02Ldt = reader =>
         new A02LDTLEntity
         {
             OrderNumber = reader["OrderNumber"].AsInt(),
             EmployeeName = reader["EmployeeName"].AsString(),
             JobCandidateName = reader["JobCandidateName"].AsString(),
             NumberSHP = reader["NumberSHP"].AsDecimal(),
             SHP = reader["SHP"].AsDecimal(),
             PCVS = reader["PCVS"].AsDecimal(),
             PCKiemNhiem = reader["PCKiemNhiem"].AsDecimal(),
             TroCapCT = reader["TroCapCT"].AsDecimal(),
             TongCong = reader["TongCong"].AsDecimal(),
             QuiDoi = reader["QuiDoi"].AsDecimal(),
             ExchangeRate = reader["ExchangeRate"].AsDecimal(),
             CurrencyCode = reader["CurrencyCode"].AsString(),
             CalcDate = reader["CalcDate"].AsDateTime(),
             BaseOfSalary = reader["BaseOfSalary"].AsDecimal(),
             WorkDay = reader["WorkDay"].AsInt(),

         };

        /// <summary>
        /// The make S03 ah
        /// </summary>
        private static readonly Func<IDataReader, S03AHEntity> MakeS03AH = reader =>
        new S03AHEntity
        {
            PostedDate = reader["PostedDate"].AsDateTimeForNull(),
            RefDate = reader["RefDate"].AsDateTimeForNull(),
            RefNo = reader["RefNo"].AsString(),
            Description = reader["Description"].AsString(),
            AccountNumber = reader["AccountNumber"].AsString(),
            DebitAmount = reader["DebitAmount"].AsDecimal(),
            CreditAmount = reader["CreditAmount"].AsDecimal(),
            FontStyle = reader["FontStyle"].AsString(),
            RefId = reader["RefID"].AsInt(),
            RefTypeId = reader["RefTypeID"].AsInt()

        };

        /// <summary>
        /// The make accounting voucher
        /// </summary>
        private static readonly Func<IDataReader, AccountingVoucherEntity> MakeAccountingVoucher = reader =>
       new AccountingVoucherEntity
       {
           CurrencyCode = reader["CurrencyCode"].AsString(),
           PostedDate = reader["PostedDate"].AsDateTimeForNull(),
           RefDate = reader["RefDate"].AsDateTimeForNull(),
           RefNo = reader["RefNo"].AsString(),
           Description = reader["Description"].AsString(),
           AccountNumber = reader["AccountNumber"].AsString(),
           //AmountOC = reader["AmountOC"].AsDecimal(),
           OrderNumber = reader["OrderNumber"].AsInt(),
           CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
       };


        /// <summary>
        /// Gets the S03 ah with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns>
        /// IList&lt;S03AHEntity&gt;.
        /// </returns>
        public IList<S03AHEntity> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                     "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeS03AH, parms);
        }

        /// <summary>
        /// The make S33 h
        /// </summary>
        private static readonly Func<IDataReader, S33HEntity> MakeS33H = reader =>
      new S33HEntity
      {
          PostedDate = reader["PostedDate"].AsDateTimeForNull(),
          RefDate = reader["RefDate"].AsDateTimeForNull(),
          RefNo = reader["RefNo"].AsString(),
          Description = reader["Description"].AsString(),
          CreditAmountBalance = reader["CreditAmountBalance"].AsDecimal(),
          DebitAmountBalance = reader["DebitAmountBalance"].AsDecimal(),
          JournalMemo = reader["JournalMemo"].AsString(),
          FontStyle = reader["FontStyle"].AsString(),
          CreditAmountOriginal = reader["CreditAmountOriginal"].AsDecimal(),
          DebitAmountOriginal = reader["DebitAmountOriginal"].AsDecimal(),
          RefId = reader["RefID"].AsInt(),
          RefTypeId = reader["RefTypeID"].AsInt(),
      };

        /// <summary>
        /// Lấy dữ liệu chi tiết tài khoản
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
        public IList<S33HEntity> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField)
        {
            try
            {
                object[] parms =
                {
                    "@pAccountNumber", accountNumber,
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType,
                    "@WhereClause",  whereClause,
                    "@BudgetGroupCode",budgetGroupCode,
                    "@FixedassetCode",fixedAssetCode,
                    "@DepartmentCode",departmentCode,
                    "@SelectedField",selectedField,
                    "@SelectedAllValueField",selectedAllValueField,
                };
                return Db.ReadList(storeProdure, true, MakeS33H, parms);
            }

            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// The make B14 q
        /// </summary>
        private static readonly Func<IDataReader, B14QEntity> MakeB14Q = reader =>
      new B14QEntity
      {
          InventoryItemCode = reader["InventoryItemCode"].AsString(),
          InventoryItemName = reader["InventoryItemName"].AsString(),
          Unit = reader["Unit"].AsString(),
          QuantityOpening = reader["QuantityOpening"].AsInt(),
          QuantityInwardStock = reader["QuantityInwardStock"].AsInt(),
          QuantityOutwardStock = reader["QuantityOutwardStock"].AsInt(),
          QuantityClosing = reader["QuantityClosing"].AsInt(),

          OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
          OrgPriceInwardStock = reader["OrgPriceInwardStock"].AsDecimal(),
          OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
          OrgPriceOutwardStock = reader["OrgPriceOutwardStock"].AsDecimal(),
          CancelQuantity = reader["CancelQuantity"].AsInt(),
          TotalQuantity = reader["TotalQuantity"].AsInt(),
          FreeQuantity = reader["FreeQuantity"].AsInt()

      };

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
        /// <returns>
        /// IList&lt;B14QEntity&gt;.
        /// </returns>
        public IList<B14QEntity> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AccountNumber",  accountnumber,
                    "@PStockID",  stockIdList,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB14Q, parms);
        }

        /// <summary>
        /// The make B01 h
        /// </summary>
        private static readonly Func<IDataReader, B01HEntity> MakeB01H = reader =>
        new B01HEntity
        {
            //AccountCode = reader["AccountNumber"].AsString(),
            //AccountName = reader["AccountName"].AsString(),
            //OpeningCredit = reader["OpeningCredit"].AsDecimal(),
            //OpeningDebit = reader["OpeningDebit"].AsDecimal(),
            //MovementCredit = reader["MovementCredit"].AsDecimal(),
            //MovementDebit = reader["MovementDebit"].AsDecimal(),
            //MovementAccumCredit = reader["MovementAccumCredit"].AsDecimal(),

            //MovementAccumDebit = reader["MovementAccumDebit"].AsDecimal(),
            //ClosingCredit = reader["ClosingCredit"].AsDecimal(),
            //ClosingDebit = reader["ClosingDebit"].AsDecimal(),
            //IsDetail = reader["IsDetail"].AsBool(),
            //Grade = reader["Grade"].AsInt()
        };

        /// <summary>
        /// Gets the B01 h with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns>
        /// IList&lt;B01HEntity&gt;.
        /// </returns>
        public IList<B01HEntity> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB01H, parms);
        }
        #endregion

        #region Estimate Report

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns>
        /// List&lt;GeneralReceiptEstimateEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GeneralReceiptEstimateEntity> GetGeneralReceiptEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralReceiptEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralReceiptEstimate, parms);
        }

        /// <summary>
        /// Gets the general payment estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns>
        /// List&lt;GeneralPaymentEstimateEntity&gt;.
        /// </returns>
        public List<GeneralPaymentEstimateEntity> GetGeneralPaymentEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralPaymentEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralPaymentEstimate, parms);
        }

        /// <summary>
        /// Gets the general estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns>
        /// List&lt;GeneralEstimateEntity&gt;.
        /// </returns>
        public List<GeneralEstimateEntity> GetGeneralEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralEstimate, parms);
        }

        /// <summary>
        /// Gets the general payment detail estimates.
        /// </summary>
        /// <param name="yearOfEsitamte">The year of esitamte.</param>
        /// <returns>
        /// List&lt;GeneralPaymentDetailEstimateEntity&gt;.
        /// </returns>
        public List<GeneralPaymentDetailEstimateEntity> GetGeneralPaymentDetailEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralPaymentDetailEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralPaymentDetailEstimate, parms);
        }

        /// <summary>
        /// Gets the employee for estimate report.
        /// </summary>
        /// <returns>
        /// List&lt;EmployeeForEstimateEntity&gt;.
        /// </returns>
        public List<EmployeeForEstimateEntity> GetEmployeeForEstimateReport(bool IsCompanyProfile)
        {
            string sql;
            if (IsCompanyProfile)
            {
                sql = @"uspGet_EmployeeFor_EstimateReportByCompanyProfile";
            }
            else
            {
                sql = @"uspGet_EmployeeFor_EstimateReport";
            }


            return Db.ReadList(sql, true, MakeEmployee);
        }

        /// <summary>
        /// Gets the fixed asset for estimate report.
        /// </summary>
        /// <returns>
        /// List&lt;FixedAssetForEstimateEntity&gt;.
        /// </returns>
        public List<FixedAssetForEstimateEntity> GetFixedAssetForEstimateReport()
        {
            const string sql = @"uspGet_FixedAsset_ForEstimateReport";
            return Db.ReadList(sql, true, MakeFixedAsset);
        }

        /// <summary>
        /// Gets the fund stuations.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns>
        /// List&lt;FundStuationEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FundStuationEntity> GetFundStuations(short yearOfEstimate)
        {
            const string sql = @"uspReport_FundStuation";

            object[] parms = { "@YearOfEstimate", yearOfEstimate };
            return Db.ReadList(sql, true, MakeFundStuation, parms);
        }

        #endregion

        #region Financial Report

        /// <summary>
        /// Gets the report B03 bn gs.
        /// </summary>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;B03BNGEntity&gt;.
        /// </returns>
        public List<B03BNGEntity> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"uspReport_B03BNG";

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeB03BNG, parms);
        }

        /// <summary>
        /// Gets the report F03 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;F03BNGEntity&gt;.
        /// </returns>
        public List<F03BNGEntity> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeF03BNG, parms);
        }
        public IList<ReportB04BCTCEntity> GetReportB04BCTC(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var reportB04s = new List<ReportB04BCTCEntity>();
            var reportB04 = new ReportB04BCTCEntity();

            // object[] parms = { "@pStartDate", fromDate, "@pFromDate", fromDate, "@pToDate", toDate, "@CurrencyCode", currencyCode, "@AmountType", amountType, "@Option", 1, "@pBudgetChapter", };
            object[] parms =
            {
                "@pStartDate", fromDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", true,
                "@pIsGetFromGLFIRSetting",false,
                "@pMasterID",null,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@Option", 1
            };

            reportB04.Table01 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table01.Sum(s => s.BeginAmount) == 0 && reportB04.Table01.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table01 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 2;
            reportB04.Table02 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table02.Sum(s => s.BeginAmount) == 0 && reportB04.Table02.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table02 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 3;
            reportB04.Table03 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table03.Sum(s => s.BeginAmount) == 0 && reportB04.Table03.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table03 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 4;
            reportB04.Table04 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail02, parms);
            if (reportB04.Table04.Sum(s => s.TangibleFixedAssets) == 0 && reportB04.Table04.Sum(s => s.IntangibleFixedAssets) == 0 && reportB04.Table04.Sum(s => s.TotalAmount) == 0)
            {
                reportB04.Table04 = new List<ReportB04BCTCDetail02Entity>();
            }

            parms[9] = 5;
            reportB04.Table05 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table05.Sum(s => s.BeginAmount) == 0 && reportB04.Table05.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table05 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 6;
            reportB04.Table06 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table06.Sum(s => s.BeginAmount) == 0 && reportB04.Table06.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table06 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 7;
            reportB04.Table07 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table07.Sum(s => s.BeginAmount) == 0 && reportB04.Table07.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table07 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 8;
            reportB04.Table08 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table08.Sum(s => s.BeginAmount) == 0 && reportB04.Table08.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table08 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 9;
            reportB04.Table09 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table09.Sum(s => s.BeginAmount) == 0 && reportB04.Table09.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table09 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 10;
            reportB04.Table10 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table10.Sum(s => s.BeginAmount) == 0 && reportB04.Table10.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table10 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 11;
            reportB04.Table11 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table11.Sum(s => s.BeginAmount) == 0 && reportB04.Table11.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table11 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 12;
            reportB04.Table12 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table12.Sum(s => s.BeginAmount) == 0 && reportB04.Table12.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table12 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 13;
            reportB04.Table13 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table13.Sum(s => s.BeginAmount) == 0 && reportB04.Table13.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table13 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 14;
            reportB04.Table14 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table14.Sum(s => s.BeginAmount) == 0 && reportB04.Table14.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table14 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 15;
            reportB04.Table15 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail03, parms);
            if (reportB04.Table15.Sum(s => s.ExchangeRateDifference) == 0 && reportB04.Table15.Sum(s => s.AccumulatedSurplus) == 0)
            {
                reportB04.Table15 = new List<ReportB04BCTCDetail03Entity>();
            }

            parms[9] = 16;
            reportB04.Table16 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table16.Sum(s => s.BeginAmount) == 0 && reportB04.Table16.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table16 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 17;
            reportB04.Table17 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table17.Sum(s => s.BeginAmount) == 0 && reportB04.Table17.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table17 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 18;
            reportB04.Table18 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table18.Sum(s => s.BeginAmount) == 0 && reportB04.Table18.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table18 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 19;
            reportB04.Table19 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table19.Sum(s => s.BeginAmount) == 0 && reportB04.Table19.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table19 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 20;
            reportB04.Table20 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table20.Sum(s => s.BeginAmount) == 0 && reportB04.Table20.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table20 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 21;
            reportB04.Table21 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table21.Sum(s => s.BeginAmount) == 0 && reportB04.Table21.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table21 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 22;
            reportB04.Table22 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table22.Sum(s => s.BeginAmount) == 0 && reportB04.Table22.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table22 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 23;
            reportB04.Table23 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table23.Sum(s => s.BeginAmount) == 0 && reportB04.Table23.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table23 = new List<ReportB04BCTCDetail01Entity>();
            }

            reportB04.Table24 = new List<ReportB04BCTCDetail01Entity>()
            {
                new ReportB04BCTCDetail01Entity()
            };

            reportB04s.Add(reportB04);
            return reportB04s;
        }

        private static readonly Func<IDataReader, ReportB04BCTCDetail01Entity> MakeReportB04BCTCDetail01 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail01Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.EndAmount = reader["EndYear"].AsDecimal();
            reportB04.BeginAmount = reader["BeginYear"].AsDecimal();
            return reportB04;
        };
        private static readonly Func<IDataReader, ReportB04BCTCDetail02Entity> MakeReportB04BCTCDetail02 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail02Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.TotalAmount = reader["Total"].AsDecimal();
            reportB04.TangibleFixedAssets = reader["TangibleFixedAssets"].AsDecimal();
            reportB04.IntangibleFixedAssets = reader["IntangibleFixedAssets"].AsDecimal();
            return reportB04;
        };

        private static readonly Func<IDataReader, ReportB04BCTCDetail03Entity> MakeReportB04BCTCDetail03 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail03Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.BusinessCapital = reader["BusinessCapital"].AsDecimal();
            reportB04.ExchangeRateDifference = reader["ExchangeRateDifference"].AsDecimal();
            reportB04.AccumulatedSurplus = reader["AccumulatedSurplus"].AsDecimal();
            reportB04.Funds = reader["Funds"].AsDecimal();
            reportB04.SourceWageReform = reader["SourceWageReform"].AsDecimal();
            reportB04.Other = reader["Other"].AsDecimal();
            reportB04.TotalAmount = reader["Total"].AsDecimal();
            return reportB04;
        };
        /// <summary>
        /// Gets the report F331 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;F331BNGEntity&gt;.
        /// </returns>
        public List<F331BNGEntity> GetReportF331BNGs(string storeProcedureName, short amountType, string accountCode, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@AccountCode", accountCode, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeF331BNG, parms);
        }

        /// <summary>
        /// Gets the report B09 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;B09BNGEntity&gt;.
        /// </returns>
        public List<B09BNGEntity> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeB09BNG, parms);
        }
        #endregion

        #region CashRepport


        /// <summary>
        /// Cashes the repport list geneal.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <returns>
        /// List&lt;CashReportEntity&gt;.
        /// </returns>
        public List<CashReportEntity> CashRepportListGeneal(string storeProcedure, string fromDate, string toDate, string accountNumber, string currencyCode, int amountType, bool isBank, int? bankId)
        {
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@AccountCode", accountNumber, "@CurrencyCode", currencyCode, "@AmountType", amountType, "@IsBank", isBank, "@BankID", bankId };
            return Db.ReadList(storeProcedure, true, MakeS11AH, parms);
        }


        /// <summary>
        /// Cashes the repport list detail.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <returns>
        /// List&lt;CashReportEntity&gt;.
        /// </returns>
        public List<CashReportEntity> CashRepportListDetail(string storeProcedure, string fromDate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType, bool isBank, int? bankId)
        {
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@AccountCode", accountNumber, "@CorrespondingAccountNumber", correspondingAccountNumber, "@CurrencyCode", currencyCode, "@AmountType", amountType, "@IsBank", isBank, "@BankID", bankId };
            return Db.ReadList(storeProcedure, true, MakeS11AH, parms);
        }


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
        /// <returns>
        /// List&lt;S03BHEntity&gt;.
        /// </returns>
        public List<S03BHEntity> GetS03BHWithStoreProdure(string storeProcedure, string fromdate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType)
        {
            object[] parms = { "@FromDate", DateTime.Parse(fromdate), "@ToDate", DateTime.Parse(toDate), "@AccountCode", accountNumber, "@CorrespondingAccountNumber", correspondingAccountNumber, "@CurrencyCode", currencyCode, "@AmountType", amountType };
            return Db.ReadList(storeProcedure, true, MakeS03BH, parms);
        }

        #endregion

        #region Voucher
        /// <summary>
        /// Gets the report C30 bb.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList&lt;C30BBEntity&gt;.
        /// </returns>
        public IList<C30BBEntity> GetReportC30BB(int year, int refTypeId)
        {
            const string sql = @"uspReport_C30BB";
            object[] parms = { "@Year", year, "@RefTypeId", refTypeId };
            return Db.ReadList(sql, true, MakeC30BB, parms);
        }

        /// <summary>
        /// Gets the report C30 bb item .
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList&lt;C30BBEntity&gt;.
        /// </returns>
        public IList<C30BBEntity> GetReportC30BBItem(int year, int refTypeId)
        {
            const string sql = @"uspReport_C30BBItem";
            object[] parms = { "@Year", year, "@RefTypeId", refTypeId };
            return Db.ReadList(sql, true, MakeC30BB, parms);
        }

        /// <summary>
        /// Gets the report receipt voucher.
        /// </summary>
        /// <param name="storeProdure"></param>
        /// <param name="refIdList"></param>
        /// <returns></returns>
        public IList<C30BB501Entity> GetReportC30BB501(string storeProdure, string refIdList)
        {
            IList<C30BB501Entity> list = new List<C30BB501Entity>();
            foreach (var refId in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refId };
                var c30Bb501List = Db.Read(storeProdure, true, MakeReceiveVoucher, parms);
                if (c30Bb501List != null)
                {
                    list.Add(c30Bb501List);
                }

            }
            return list;
        }
        #endregion

        #region Report FixedAsset
        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// List&lt;FixedAssetB03HEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetB03HEntity> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B03H";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB03H, parms);
        }

        /// <summary>
        /// Gets the type of the fixed asset B03 h amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        public List<FixedAssetB03HEntity> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B03H_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB03H, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// List&lt;FixedAssetB03HEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetB01Entity> GetFixedAssetB01(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B01";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB01, parms);
        }

        /// <summary>
        /// Gets the fixed asset B03 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits"></param>
        /// <returns></returns>
        public List<FixedAssetB01Entity> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B01_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB01, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// List&lt;FixedAssetC55aHDEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetC55aHDEntity> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter, string faCategoryCode, string currencyCode)
        {
            const string sql = @"uspReport_C55a_HD";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@FixedAssetParameter", faParameter, "@FixedAssetCategoryID", faCategoryCode, "@CurrencyCode", currencyCode };

            return Db.ReadList(sql, true, MakeFixedAssetC55aHD, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyDecimalDigits"></param>
        /// <returns>
        /// List&lt;FixedAssetC55aHDEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetC55aHDEntity> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter, string faCategoryCode, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_C55a_HD_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@FixedAssetParameter", faParameter, "@FixedAssetCategoryID", faCategoryCode, "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetC55aHD, parms);
        }
        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDecimalDigits"></param>
        /// <returns>
        /// List&lt;FixedAssetFAInventoryEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory(string fromDate, string toDate, string currencyCode, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode, "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns>
        /// List&lt;FixedAssetFAInventoryEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Gets the fixed asset fa inventory house.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouse(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventory_House";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        /// <summary>
        /// Gets the type of the fixed asset fa inventory house amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_House_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        /// <summary>
        /// Gets the fixed asset fa inventory car.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCar(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventoryCar";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns>
        /// List&lt;FixedAssetFAInventoryCarEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_Car_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }
        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// List&lt;FixedAssetFAInventoryEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory3000(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventory3000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;FixedAssetFAInventoryEntity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate)
        {
            const string sql = @"uspReport_FAInventory_AmountType30000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate) };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>
        /// List&lt;FixedAssetB02Entity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetB02Entity> GetFixedAssetB02(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B02";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB02, parms);
        }

        /// <summary>
        /// Gets the general receipt estimates.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits"></param>
        /// <returns>
        /// List&lt;FixedAssetB02Entity&gt;.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FixedAssetB02Entity> GetFixedAssetB02ByAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B02_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB02, parms);
        }


        public List<FixedAssetB03H30KEntity> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B03H_3000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB03H30K, parms);
        }

        public List<FixedAsset30KPart2Entity> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_30000Part2";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAsset30KPart2, parms);
        }

        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAB01Car(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_Car_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }

        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAB01House(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_House_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        public List<FixedAsset30KPart2Entity> GetFixedAssetFAB0130KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_30000Part2";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAsset30KPart2, parms);
        }

        public IList<FixedAssetCardEntity> GetFixedAssetCard(string fixedAssetIdList, int currencyDecimalDigits)
        {
            IList<FixedAssetCardEntity> list = new List<FixedAssetCardEntity>();
            foreach (var fixedAssetId in fixedAssetIdList.Split(';'))
            {
                object[] parms = { "@FixedAssetID", fixedAssetId, "@Roud", currencyDecimalDigits };
                var fixedAssetCardList = Db.Read(@"uspReport_FixedAsset", true, MakeFixedAssetCard, parms);
                if (fixedAssetCardList != null)
                {
                    list.Add(fixedAssetCardList);
                }

            }
            return list;
        }

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
        public IList<FixedAssetS24HEntity> GetFixedAssetS24H(string fromDate, string toDate, int usePurpose, string departmentId, string fixedAssetCategoryId, int fixedAssetCategoryGrade, bool printByCondition, bool printFixedAssetOpening, bool printFixedAssetIncrementInYear, bool printFixedAssetNotIncrement, string listFixedAssetID, int amountType, string currencyCode)
        {
            string sql = "uspReport_FixedAssetS24H";
            Func<IDataReader, FixedAssetS24HEntity> MakeFixedAssetS24HReport = reader =>
           new FixedAssetS24HEntity
           {
               FixedAssetCode = reader["FixedAssetCode"].AsString(),
               FixedAssetName = reader["FixedAssetName"].AsString(),
               OrgPrice = reader["OrgPrice"].AsString().AsDecimalForNull(),
               SerialNumber = reader["SerialNumber"].AsString(),
               MadeIn = reader["MadeIn"].AsString(),
               UsedDate = reader["UsedDate"].AsString().AsDateTimeForNull(),
               DepartmentName = reader["DepartmentName"].AsString(),
               FixedAssetId = reader["FixedAssetID"].AsString(),
               DepartmentCode = reader["DepartmentCode"].AsString(),
               DecrementRefId = reader["DecrementRefID"].AsString(),
               DecrementRefDate = reader["DecrementRefDate"].AsString().AsDateTimeForNull(),
               DecrementRefType = reader["DecrementRefType"].AsString().AsIntForNull(),
               DepreciationCreditAmountLastYear =
                    reader["DepreciationCreditAmountLastYear"].AsString().AsDecimalForNull(),
               IncrementQuantity = reader["IncrementQuantity"].AsInt(),
               FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
               DecrementQuantity = reader["DecrementQuantity"].AsInt(),
               IncrementRefDate = reader["IncrementRefDate"].AsString().AsDateTimeForNull(),
               IncrementRefId = reader["IncrementRefID"].AsString(),
               FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
               PeriodDepreciationAmount = reader["PeriodDepreciationAmount"].AsString().AsDecimalForNull(),
               IncrementRefNo = reader["IncrementRefNo"].AsString(),
               IncrementRefType = reader["IncrementRefType"].AsString().AsIntForNull(),
               RemainingFixedAssetAmount = reader["RemainingFixedAssetAmount"].AsString().AsDecimalForNull(),
               DecrementRefNo = reader["DecrementRefNo"].AsString(),
               DepreciationRate = reader["DepreciationRate"].AsString().AsDecimalForNull(),
               DevaluationRate = reader["DevaluationRate"].AsString().AsDecimalForNull(),
               SortOrder = reader["SortOrder"].AsString(),
               DepreciationCreditAmountThisYear =
                    reader["DepreciationCreditAmountThisYear"].AsString().AsDecimalForNull(),
               DevaluationCreditAmountThisYear =
                   reader["DevaluationCreditAmountThisYear"].AsString().AsDecimalForNull(),
               JournalMemo = reader["JournalMemo"].AsString(),
               DepartmentId = reader["DepartmentID"].AsString(),
               FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString()
           };

            object[] parms = 
                { 
                "@FromDate", Convert.ToDateTime(fromDate), 
                "@ToDate", Convert.ToDateTime(toDate), 
                "@IsSummaryDepartment", String.IsNullOrEmpty(departmentId)? true:false, 
                "@DepartmentID", departmentId,
                "@FixedAssetCategoryID", fixedAssetCategoryId, 
                "@FixedAssetCategoryGrade",fixedAssetCategoryGrade, 
                "@PrintByCondition",printByCondition,
                "@PrintFixedAssetOpening",printFixedAssetOpening, 
                "@PrintFixedAssetIncrementInYear",printFixedAssetIncrementInYear,
                "@PrintFixedAssetNotIncrement",printFixedAssetNotIncrement, 
                "@ListFixedAssetID",listFixedAssetID,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode,};

            return Db.ReadList(sql, true, MakeFixedAssetS24HReport, parms);
        }

        #endregion


        public IList<S26HEntity> GetReportFixedAssetS26H(DateTime fromDate, DateTime toDate, string departmentId, string fixedAssetCategoryId, int amountType, string currencyCode)
        {
            const string sql = @"uspReport_GetReportFixedAssetS26H";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@DepartmentID", departmentId,
                "@FixedAssetCategoryID", fixedAssetCategoryId,
                "@AmountType",  amountType,
                "@CurrencyCode",  currencyCode,

            };
            Func<IDataReader, S26HEntity> makeS26H = reader =>
             new S26HEntity
             {
                 DepartmentName = reader["DepartmentName"].AsString(),
                 DepartmentCode = reader["DepartmentCode"].AsString(),
                 InventoryCategoryName = reader["FixedAssetCategoryName"].AsString(),
                 InventoryCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                 PostedDate = reader["PostedDate"].AsDateTimeForNull(),
                 RefId = reader["RefId"].AsString(),
                 RefType = reader["RefType"].AsInt(),
                 RefNo = reader["RefNo"].AsString(),
                 RefDate = reader["RefDate"].AsDateTimeForNull(),
                 InventoryItemCode = reader["FixedAssetCode"].AsString(),
                 InventoryItemName = reader["FixedAssetName"].AsString(),
                 Unit = reader["Unit"].AsString(),
                 Amount = reader["Amount"].AsDecimal(),
                 Quantity = reader["Quantity"].AsDecimal(),
                 UnitPrice = reader["UnitPrice"].AsDecimal(),
                 DecrementQuantity = reader["DecrementQuantity"].AsDecimal(),
                 DecrementAmount = reader["DecrementAmount"].AsDecimal(),

                 DecrementUnitPrice = reader["DecrementUnitPrice"].AsDecimal(),
                 DecrementDescription = reader["DecrementDescription"].AsString(),
                 RefOrder = reader["RefOrder"].AsInt(),

             };

            return Db.ReadList(sql, true, makeS26H, parms);
        }

        #region Make
        private static readonly Func<IDataReader, FixedAssetB03H30KEntity> MakeFixedAssetB03H30K = reader =>
            new FixedAssetB03H30KEntity
            {
                FixedAssetId = 0,
                FixedAssetCategoryCode = "",
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetType = reader["FixedAssetType"].AsString(),
                Grade = reader["Grade"].AsInt(),
                QuantityOpening = reader["QuantityOpening"].AsInt(),
                AreaOpening = reader["AreaOpening"].AsDecimal(),
                OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
                OrgPriceOpeningDifference = reader["OrgPriceOpeningDifference"].AsDecimal(),
                QuantityIncrement = reader["QuantityIncrement"].AsInt(),
                AreaIncrement = reader["AreaIncrement"].AsDecimal(),
                OrgPriceIncrement = reader["OrgPriceIncrement"].AsDecimal(),
                OrgPriceIncrementDifference = reader["OrgPriceIncrementDifference"].AsDecimal(),
                QuantityDecrement = reader["QuantityDecrement"].AsInt(),
                AreaDecrement = reader["AreaDecrement"].AsDecimal(),
                OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
                OrgPriceDecrementDifference = reader["OrgPriceDecrementDifference"].AsDecimal(),
                QuantityClosing = reader["QuantityClosing"].AsInt(),
                AreaClosing = reader["AreaClosing"].AsDecimal(),
                OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
                OrgPriceClosingDifference = reader["OrgPriceClosingDifference"].AsDecimal()
            };

        private static readonly Func<IDataReader, FixedAsset30KPart2Entity> MakeFixedAsset30KPart2 = reader =>
            new FixedAsset30KPart2Entity
            {
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                ProductionYear = reader["ProductionYear"].AsInt(),
                CountryProduction = reader["CountryProduction"].AsString(),
                DateOfUsing = reader["DateOfUsing"].AsDateTime(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                StateManagement = reader["StateManagement"].AsString(),
                Bussiness = reader["Bussiness"].AsString(),
                Description = reader["Description"].AsString()
            };

        private static readonly Func<IDataReader, FixedAssetCardEntity> MakeFixedAssetCard = reader =>
            new FixedAssetCardEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                OrderNumber = reader["OrderNumber"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                ProductionYear = reader["ProductionYear"].AsInt(),
                MadeIn = reader["MadeIn"].AsString(),
                UsedDate = reader["UsedDate"].AsDateTime(),
                PurchasedDate = reader["PurchasedDate"].AsDateTime(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
                TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),
                DepartmentName = reader["DepartmentName"].AsString(),
                EmployeeName = reader["EmployeeName"].AsString()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ReportListEntity> Make = reader =>
            new ReportListEntity
            {
                ReportId = reader["ReportID"].AsString(),
                ReportName = reader["ReportName"].AsString(),
                Description = reader["Description"].AsString(),
                ReportFile = reader["ReportFile"].AsString(),
                OutputAssembly = reader["OutputAssembly"].AsString(),
                InputTypeName = reader["InputTypeName"].AsString(),
                FunctionReportName = reader["FunctionReportName"].AsString(),
                ProcedureName = reader["ProcedureName"].AsString(),
                TableName = reader["TableName"].AsString(),
                TrackType = reader["TrackType"].AsInt(),
                ProcNameByLot = reader["ProcNameByLot"].AsString(),
                ProcNameVoucherList = reader["ProcNameVoucherList"].AsString(),
                Inactive = reader["Inactive"].AsBool(),
                PrintVoucherDefault = reader["PrintVoucherDefault"].AsBool(),
                LicenceType = reader["LicenceType"].AsInt(),
                RefType = reader["RefType"].AsInt(),
                Particularity = reader["Particularity"].AsInt(),
                SortOrder = reader["SortOrder"].AsString(),
                IsReportBeConfigured = reader["IsReportBeConfigured"].AsBool(),
                Standard = reader["Standard"].AsBool(),
                AllowBatchPrinting = reader["AllowBatchPrinting"].AsBool(),
                GetParamFromDialog = reader["GetParamFromDialog"].AsBool(),
                DataBandSortReportId = reader["DataBandSortReportID"].AsString(),
                ReportType = reader["ReportType"].AsInt(),
                ParentId = reader["ParentID"].AsString(),
                Level = reader["Level"].AsInt(),
                Visible = reader["Visible"].AsBool()
            };

        /// <summary>
        /// The make C22 hd
        /// </summary>
        private static readonly Func<IDataReader, C22HEntity> MakeC22HD = reader =>
           new C22HEntity
           {
               RefId = reader["RefID"].AsLong(),
               RefNo = reader["RefNo"].AsString(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               AccountingObjectName = reader["AccountingObjectName"].AsString(),
               AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               DocumentInclude = reader["DocumentInclude"].AsString(),
               CreditAccount = Db.RemoveDuplicateWords(reader["CreditAccount"].AsString()),
               DebitAccount = Db.RemoveDuplicateWords(reader["DebitAccount"].AsString()),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               ExchangeRate = reader["ExchangeRate"].AsFloat(),
               TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
               Trader = reader["Trader"].AsString(),
           };

        /// <summary>
        /// The make C22 hd
        /// </summary>
        private static readonly Func<IDataReader, C11HEntity> MakeC11HD = reader =>
           new C11HEntity
           {
               RefId = reader["RefID"].AsLong(),
               RefNo = reader["RefNo"].AsString(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               AccountingObjectName = reader["AccountingObjectName"].AsString(),
               AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               StockName = reader["StockName"].AsString(),
               Trader = reader["Trader"].AsString()
           };


        /// <summary>
        /// The make general receipt estimate
        /// </summary>
        private static readonly Func<IDataReader, GeneralReceiptEstimateEntity> MakeGeneralReceiptEstimate = reader =>
           new GeneralReceiptEstimateEntity
           {
               Id = reader["ID"].AsInt(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetItemName = reader["BudgetItemName"].AsString(),
               PreviousYearOfTotalEstimateAmount = reader["PreviousYearOfTotalEstimateAmount"].AsDecimal(),
               YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
               NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
               Description = reader["Description"].AsString(),
               ItemCodeList = reader["ItemCodeList"].AsString(),
               NumberOrder = reader["NumberOrder"].AsString(),
               FontStyle = reader["FontStyle"].AsString(),
               IsParent = reader["IsParent"].AsBool()
           };

        /// <summary>
        /// The make general payment estimate
        /// </summary>
        private static readonly Func<IDataReader, GeneralPaymentEstimateEntity> MakeGeneralPaymentEstimate = reader =>
           new GeneralPaymentEstimateEntity
           {
               BudgetItemId = reader["BudgetItemID"].AsInt(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetItemName = reader["BudgetItemName"].AsString(),
               ParentId = reader["ParentID"].AsString().AsIntForNull(),
               Grade = reader["Grade"].AsShort(),
               TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
               YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
               NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
               AutonomyBudget = reader["AutonomyBudget"].AsDecimal(),
               NonAutonomyBudget = reader["NonAutonomyBudget"].AsDecimal(),
               TotalNextYearOfEstimateAmount = reader["TotalNextYearOfEstimateAmount"].AsDecimal(),
               Description = reader["Description"].AsString(),
               BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString()
           };

        /// <summary>
        /// The make general estimate
        /// </summary>
        private static readonly Func<IDataReader, GeneralEstimateEntity> MakeGeneralEstimate = reader =>
          new GeneralEstimateEntity
          {
              BudgetItemName = reader["BudgetItemName"].AsString(),
              PreviousYearOfTotalEstimateAmount = reader["PreviousYearOfTotalEstimateAmount"].AsDecimal(),
              YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
              NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
              Description = reader["Description"].AsString()
          };

        /// <summary>
        /// The make general payment detail estimate
        /// </summary>
        private static readonly Func<IDataReader, GeneralPaymentDetailEstimateEntity> MakeGeneralPaymentDetailEstimate = reader =>
           new GeneralPaymentDetailEstimateEntity
           {
               BudgetItemId = reader["BudgetItemID"].AsInt(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetItemName = reader["BudgetItemName"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               ParentId = reader["ParentID"].AsString().AsIntForNull(),
               Grade = reader["Grade"].AsShort(),
               TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
               YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
               NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
               AutonomyBudget = reader["AutonomyBudget"].AsDecimal(),
               NonAutonomyBudget = reader["NonAutonomyBudget"].AsDecimal(),
               TotalNextYearOfEstimateAmount = reader["TotalNextYearOfEstimateAmount"].AsDecimal(),
               Description = reader["Description"].AsString(),
               BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString(),
           };

        /// <summary>
        /// The make fund stuation
        /// </summary>
        private static readonly Func<IDataReader, FundStuationEntity> MakeFundStuation = reader =>
            new FundStuationEntity
            {
                BudgetItemId = reader["BudgetItemID"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemName = reader["BudgetItemName"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                Grade = reader["Grade"].AsShort(),
                Sort = reader["Sort"].AsString(),
                BudgetItemType = reader["BudgetItemType"].AsShort(),
                PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal(),
                PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal(),
                TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
                YearOfAutonomyBudget = reader["YearOfAutonomyBudget"].AsDecimal(),
                YearOfNonAutonomyBudget = reader["YearOfNonAutonomyBudget"].AsDecimal(),
                YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
                SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal(),
                SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal(),
                TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal(),
                SixMonthEndingAutonomyBudget = reader["SixMonthEndingAutonomyBudget"].AsDecimal(),
                SixMonthEndingNonAutonomyBudget = reader["SixMonthEndingNonAutonomyBudget"].AsDecimal(),
                TotalAmountSixMonthEnding = reader["TotalAmountSixMonthEnding"].AsDecimal(),
                YearOfAmountAutonomyBudget = reader["YearOfAmountAutonomyBudget"].AsDecimal(),
                YearOfAmountNonAutonomyBudget = reader["YearOfAmountNonAutonomyBudget"].AsDecimal(),
                YearOfTotalAmount = reader["YearOfTotalAmount"].AsDecimal(),
                YearOfDifferenceAmountAutonomyBudget = reader["YearOfDifferenceAmountAutonomyBudget"].AsDecimal(),
                YearOfDifferenceAmountNonAutonomyBudget = reader["YearOfDifferenceAmountNonAutonomyBudget"].AsDecimal(),
                YearOfDifferenceTotalAmount = reader["YearOfDifferenceTotalAmount"].AsDecimal(),
                Description = reader["Description"].AsString(),
                BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString()
            };

        /// <summary>
        /// The make fixed asset B03 h
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetB03HEntity> MakeFixedAssetB03H = reader =>
            new FixedAssetB03HEntity
            {
                FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsInt(),
                FixedAssetCategoryCode = reader["OrderNumber"].AsString(),
                FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                Unit = reader["Unit"].AsString(),
                QuantityOpening = reader["QuantityOpening"].AsInt(),
                QuantityIncrement = reader["QuantityIncrement"].AsInt(),
                QuantityDecrement = reader["QuantityDecrement"].AsInt(),
                QuantityClosing = reader["QuantityClosing"].AsInt(),
                OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
                OrgPriceOpeningUSD = reader["OrgPriceOpeningUSD"].AsDecimal(),
                OrgPriceOpeningCurrencyUSD = reader["OrgPriceOpeningCurrencyUSD"].AsDecimal(),
                TotalOrgPriceOpeningUSD = reader["TotalOrgPriceOpeningUSD"].AsDecimal(),
                OrgPriceIncrement = reader["OrgPriceIncrement"].AsDecimal(),
                OrgPriceIncrementUSD = reader["OrgPriceIncrementUSD"].AsDecimal(),
                OrgPriceIncrementCurrencyUSD = reader["OrgPriceIncrementCurrencyUSD"].AsDecimal(),
                TotalOrgPriceIncrementUSD = reader["TotalOrgPriceIncrementUSD"].AsDecimal(),
                OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
                OrgPriceDecrementUSD = reader["OrgPriceDecrementUSD"].AsDecimal(),
                OrgPriceDecrementCurrencyUSD = reader["OrgPriceDecrementCurrencyUSD"].AsDecimal(),
                TotalOrgPriceDecrementUSD = reader["TotalOrgPriceDecrementUSD"].AsDecimal(),
                OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
                OrgPriceClosingUSD = reader["OrgPriceClosingUSD"].AsDecimal(),
                OrgPriceClosingCurrencyUSD = reader["OrgPriceClosingCurrencyUSD"].AsDecimal(),
                TotalOrgPriceClosingUSD = reader["TotalOrgPriceClosingUSD"].AsDecimal(),
                Grade = reader["Grade"].AsInt(),
                Sort = reader["OrderNumber"].AsString()
            };

        /// <summary>
        /// The make fixed asset c55a hd
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetC55aHDEntity> MakeFixedAssetC55aHD = reader =>
            new FixedAssetC55aHDEntity
            {
                OrderNumber = reader["OrderNumber"].AsInt(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                YearOfUsing = reader["YearOfUsing"].AsInt(),
                AddressUsing = reader["AddressUsing"].AsString(),
                Unit = reader["Unit"].AsString(),
                SerialNumber = reader["SerialNumber"].AsString(),
                QuantityOrgPrice = reader["QuantityOrgPrice"].AsInt(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal(),
                OrgPriceCurrencyUSD = reader["OrgPriceCurrencyUSD"].AsDecimal(),
                TotalOrgPriceUSD = reader["TotalOrgPriceUSD"].AsDecimal(),
                AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                RemainigAmount = reader["RemainigAmount"].AsDecimal(),
                LifeTime = reader["LifeTime"].AsInt(),
                AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
                QuantityDepreciation = reader["QuantityDepreciation"].AsInt(),
                DepreciationYearAmount = reader["DepreciationYearAmount"].AsDecimal(),
                DepreciationYearAmountUSD = reader["DepreciationYearAmountUSD"].AsDecimal(),
                DepreciationYearAmountCurrencyUSD = reader["DepreciationYearAmountCurrencyUSD"].AsDecimal(),
                TotalDepreciationYearAmountUSD = reader["TotalDepreciationYearAmountUSD"].AsDecimal()
            };

        /// <summary>
        /// The make fixed asset fa inventory
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetFAInventoryEntity> MakeFixedAssetFAInventory = reader =>
            new FixedAssetFAInventoryEntity
            {
                OrderNumber = 0,
                FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                YearOfUsing = reader["YearOfUsing"].AsInt(),
                Description = reader["Description"].AsString(),
                Unit = reader["Unit"].AsString(),
                DepreciationRate = reader["DepreciationRate"].AsDecimal(),
                SerialNumber = reader["SerialNumber"].AsString(),
                CountryProduction = reader["CountryProduction"].AsString(),
                Quantity = reader["Quantity"].AsInt(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
                OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
                TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),

                QuantityInvetory = reader["QuantityInvetory"].AsInt(),
                OrgPriceInvetory = reader["OrgPriceInvetory"].AsDecimal(),
                OrgPriceCurrencyInvetoryUsd = reader["OrgPriceCurrencyInvetoryUSD"].AsDecimal(),
                OrgPriceInvetoryUsd = reader["OrgPriceInvetoryUSD"].AsDecimal(),
                TotalOrgPriceInvetoryUsd = reader["TotalOrgPriceInvetoryUSD"].AsDecimal(),

                QuantityDifference = reader["QuantityDifference"].AsInt(),
                OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
                OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
                OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
                TotalOrgPriceDifferenceUsd = reader["TotalOrgPriceDifferenceUSD"].AsDecimal(),

                Grade = reader["Grade"].AsInt(),
                Sort = reader["OrderNumber"].AsString()
            };

        /// <summary>
        /// The make fixed asset fa inventory
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetFAInventoryHouseEntity> MakeFixedAssetFAInventoryHouse = reader =>
            new FixedAssetFAInventoryHouseEntity
            {
                OrderNumber = 0,
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                NumberOfFloor = reader["NumberOfFloor"].AsInt(),
                UsedDate = reader["UsedDate"].AsDateTime(),
                ProductionYear = reader["ProductionYear"].AsInt(),
                GradeHouse = reader["GradeHouse"].AsString(),
                AreaOfBuilding = reader["AreaOfBuilding"].AsDecimal(),
                WorkingArea = reader["WorkingArea"].AsDecimal(),
                AreaOfFloor = reader["AreaOfFloor"].AsDecimal(),
                GuestHouseArea = reader["GuestHouseArea"].AsDecimal(),
                HousingArea = reader["HousingArea"].AsDecimal(),
                OtherArea = reader["OtherArea"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
                OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
                OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
                OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
                OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
                Description = reader["Description"].AsString(),
            };

        /// <summary>
        /// The make fixed asset fa inventory
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetFAInventoryCarEntity> MakeFixedAssetFAInventoryCar = reader =>
            new FixedAssetFAInventoryCarEntity
            {
                OrderNumber = reader["OrderNumber"].AsInt(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                CountryProduction = reader["CountryProduction"].AsString(),
                SerialNumber = reader["SerialNumber"].AsString(),
                Brand = reader["Brand"].AsString(),
                ControlPlate = reader["ControlPlate"].AsString(),
                NumberOfSeat = reader["NumberOfSeat"].AsInt(),
                ProductionYear = reader["ProductionYear"].AsInt(),
                UsedDate = reader["UsedDate"].AsDateTime(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
                OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
                OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
                OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
                OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                Car1 = reader["Car1"].AsString(),
                Car2 = reader["Car2"].AsString(),
                Car = reader["Car"].AsString()
            };

        /// <summary>
        /// The make fixed asset B02
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetB02Entity> MakeFixedAssetB02 = reader =>
           new FixedAssetB02Entity
           {
               OrderNumber = 0,
               FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
               FixedAssetId = reader["FixedAssetID"].AsInt(),
               FixedAssetCode = reader["FixedAssetCode"].AsString(),
               FixedAssetName = reader["FixedAssetName"].AsString(),
               ParentId = reader["ParentID"].AsInt(),
               YearOfUsing = reader["YearOfUsing"].AsInt(),
               AddressUsing = reader["AddressUsing"].AsString(),
               DepreciationRate = reader["DepreciationRate"].AsDecimal(),
               Description = reader["Description"].AsString(),
               Unit = reader["Unit"].AsString(),
               SerialNumber = reader["SerialNumber"].AsString(),
               CountryProduction = reader["CountryProduction"].AsString(),
               Quantity = reader["Quantity"].AsInt(),
               OrgPrice = reader["OrgPrice"].AsDecimal(),
               OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
               OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
               TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),
               Grade = reader["Grade"].AsInt(),
               Sort = reader["OrderNumber"].AsString()
           };

        /// <summary>
        /// The make fixed asset B01
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetB01Entity> MakeFixedAssetB01 = reader =>
           new FixedAssetB01Entity
           {
               OrderNumber = 0,
               FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
               FixedAssetId = reader["FixedAssetID"].AsInt(),
               FixedAssetCode = reader["FixedAssetCode"].AsString(),
               FixedAssetName = reader["FixedAssetName"].AsString(),
               //ParentId = reader["ParentID"].AsInt(),
               YearOfUsing = reader["YearOfUsing"].AsInt(),
               Description = reader["Description"].AsString(),
               DepreciationRate = reader["DepreciationRate"].AsDecimal(),
               AddressUsing = reader["AddressUsing"].AsString(),
               Unit = reader["Unit"].AsString(),
               SerialNumber = reader["SerialNumber"].AsString(),
               OrgPrice = reader["OrgPrice"].AsDecimal(),
               OrgPriceDecrementUSD = reader["OrgPriceDecrementUSD"].AsDecimal(),
               OrgPriceDecrementCurrencyUSD = reader["OrgPriceDecrementCurrencyUSD"].AsDecimal(),
               TotalOrgPriceDecrementUSD = reader["TotalOrgPriceDecrementUSD"].AsDecimal(),
               QuantityDecrement = reader["QuantityDecrement"].AsInt(),
               OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
               QuantityAnnualDepreciation = reader["QuantityAnnualDepreciation"].AsInt(),
               AnnualDepreciationAmountUSD = reader["AnnualDepreciationAmountUSD"].AsDecimal(),
               AnnualDepreciationAmountCurrencyUSD = reader["AnnualDepreciationAmountCurrencyUSD"].AsDecimal(),
               TotalAnnualDepreciationAmountUSD = reader["TotalAnnualDepreciationAmountUSD"].AsDecimal(),
               AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
               QuantityRemainingDecrement = reader["QuantityRemainingDecrement"].AsInt(),
               RemainingAmountDecrement = reader["RemainingAmountDecrement"].AsDecimal(),
               RemainingAmountDecrementUSD = reader["RemainingAmountDecrementUSD"].AsDecimal(),
               RemainingAmountDecrementCurrencyUSD = reader["RemainingAmountDecrementCurrencyUSD"].AsDecimal(),
               TotalRemainingAmountDecrementUSD = reader["TotalRemainingAmountDecrementUSD"].AsDecimal(),
               Grade = reader["Grade"].AsInt(),
               Sort = reader["OrderNumber"].AsString()
           };


        /// <summary>
        /// The make C30 bb
        /// </summary>
        private static readonly Func<IDataReader, C30BBEntity> MakeC30BB = reader =>
           new C30BBEntity
           {
               //RefNo = reader["RefNo"].AsString(),
               //RefType  = reader["RefID"].AsInt(),
               //PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
               //AccountNumber = reader["AccountNumber"].AsString() == "" ? "" : Db.RemoveDuplicateWords(reader["AccountNumber"].AsString()),
               //Address = reader["Address"].AsString(),
               //CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString() == "" ? "" : Db.RemoveDuplicateWords(reader["CorrespondingAccountNumber"].AsString()),
               //DocumentInclude = reader["DocumentInclude"].AsString(),
               //ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               //IsSelect = reader["IsSelect"].AsBool(),
               //JournalMemo = reader["JournalMemo"].AsString(),
               //TotalAmount = reader["TotalAmount"].AsDecimal(),
               //TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
               //Trader = reader["Trader"].AsString(),
               //CurrencyCode = reader["CurrencyCode"].AsString(),
               //ContactName = reader["ContactName"].ToString()
           };

        /// <summary>
        /// The make receive voucher
        /// </summary>
        private static readonly Func<IDataReader, C30BB501Entity> MakeReceiveVoucher = reader =>
           new C30BB501Entity
           {
               RefNo = reader["RefNo"].AsString(),
               RefId = reader["RefID"].AsLong(),
               PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
               Address = reader["AccountingObjectAddress"].AsString(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               JournalMemo = reader["JournalMemo"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               ContactName = reader["AccountingObjectName"].ToString(),
               Trader = reader["AccountingObjectName"].ToString(),
               AccountNumber = reader["AccountNumber"].ToString(),
               CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].ToString()
           };

        /// <summary>
        /// The make S11 ah
        /// </summary>
        private static readonly Func<IDataReader, CashReportEntity> MakeS11AH = reader =>
           new CashReportEntity
           {
               RefNo = reader["RefNo"].AsString(),
               CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
               PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
               Description = reader["Description"].AsString(),
               PayAmount = reader["PayAmount"].AsDecimal(),
               ReceiptAmount = reader["ReceiptAmount"].AsDecimal(),
               RestAmount = reader["RestAmount"].AsDecimal(),
               AccumulatedReceiptAmount = reader["AccumulatedReceiptAmount"].AsDecimal(),
               AccumulatedPayAmount = reader["AccumulatedPayAmount"].AsDecimal(),
               RefId = reader["RefID"].AsInt(),
               RefTypeId = reader["RefTypeID"].AsInt()

           };


        /// <summary>
        /// The make S03 bh
        /// </summary>
        private static readonly Func<IDataReader, S03BHEntity> MakeS03BH = reader =>
           new S03BHEntity
           {
               RefNo = reader["RefNo"].AsString(),
               CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
               PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
               Description = reader["Description"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               AccountNumber = reader["BudgetItemCode"].AsString(),
               AccumulatedAccountNumbber = reader["AccumulatedAccountNumbber"].AsDecimal(),
               AccumulatedCorrAccountNumbber = reader["AccumulatedCorrAccountNumbber"].AsDecimal(),
               AmountAccountNumbber = reader["AmountAccountNumbber"].AsDecimal(),
               AmountCorrAccountNumbber = reader["AmountCorrAccountNumbber"].AsDecimal(),
               AmountOgrAccountNumbber = reader["AmountOgrAccountNumbber"].AsDecimal(),
               AmountOgrCorrAccountNumbber = reader["AmountOgrCorrAccountNumbber"].AsDecimal(),
               RefId = reader["RefID"].AsInt(),
               RefTypeId = reader["RefTypeID"].AsInt()
           };


        /// <summary>
        /// The make B03 BNG
        /// </summary>
        private static readonly Func<IDataReader, B03BNGEntity> MakeB03BNG = reader =>
            new B03BNGEntity
            {
                AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                AccountingObjectGroup = reader["AccountingObjectGroup"].AsString(),
                OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                ReceiveAdvance = reader["ReceiveAdvance"].AsDecimal(),
                AdvancePayment = reader["AdvancePayment"].AsDecimal(),
                ClosingAmount = reader["ClosingAmount"].AsDecimal(),
                Type = reader["Type"].AsShort()
            };

        /// <summary>
        /// The make F03 BNG
        /// </summary>
        private static readonly Func<IDataReader, F03BNGEntity> MakeF03BNG = reader =>
            new F03BNGEntity
            {
                AccumulatedAutonomyBudgetAmount = reader["AccumulatedAutonomyBudgetAmount"].AsDecimal(),
                AccumulatedAutonomyOtherAmount = reader["AccumulatedAutonomyOtherAmount"].AsDecimal(),
                AccumulatedNonAutonomyBudgetAmount = reader["AccumulatedNonAutonomyBudgetAmount"].AsDecimal(),
                AccumulatedNonAutonomyOtherAmount = reader["AccumulatedNonAutonomyOtherAmount"].AsDecimal(),
                AccumulatedProjectBudgetAmount = reader["AccumulatedProjectBudgetAmount"].AsDecimal(),
                AccumulatedRegulateOtherAmount = reader["AccumulatedRegulateOtherAmount"].AsDecimal(),
                AccumulatedDiplomaticBudgetAmount = reader["AccumulatedDiplomaticBudgetAmount"].AsDecimal(),
                AccumulatedTotalAmount = reader["AccumulatedTotalAmount"].AsDecimal(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemId = reader["BudgetItemId"].AsString(),
                BudgetItemType = reader["BudgetItemType"].AsByte(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                Content = reader["Content"].AsString(),
                FontStyle = reader["FontStyle"].AsString(),
                Grade = reader["Grade"].AsInt(),
                ParentId = reader["ParentId"].AsString(),
                ThisMonthAutonomyBudgetAmount = reader["ThisMonthAutonomyBudgetAmount"].AsDecimal(),
                ThisMonthAutonomyOtherAmount = reader["ThisMonthAutonomyOtherAmount"].AsDecimal(),
                ThisMonthNonAutonomyBudgetAmount = reader["ThisMonthNonAutonomyBudgetAmount"].AsDecimal(),
                ThisMonthNonAutonomyOtherAmount = reader["ThisMonthNonAutonomyOtherAmount"].AsDecimal(),
                ThisMonthProjectBudgetAmount = reader["ThisMonthProjectBudgetAmount"].AsDecimal(),
                ThisMonthRegulateOtherAmount = reader["ThisMonthRegulateOtherAmount"].AsDecimal(),
                ThisMonthDiplomaticBudgetAmount = reader["ThisMonthDiplomaticBudgetAmount"].AsDecimal(),
                ThisMonthTotalAmount = reader["ThisMonthTotalAmount"].AsDecimal()
            };

        /// <summary>
        /// The make F331 BNG
        /// </summary>
        private static readonly Func<IDataReader, F331BNGEntity> MakeF331BNG = reader =>
            new F331BNGEntity
            {
                AccumulatedAmount = reader["AccumulatedAmount"].AsDecimal(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemId = reader["BudgetItemId"].AsString(),
                BudgetItemType = reader["BudgetItemType"].AsByte(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                Content = reader["Content"].AsString(),
                FontStyle = reader["FontStyle"].AsString(),
                Grade = reader["Grade"].AsInt(),
                ParentId = reader["ParentId"].AsString(),
                ThisMonthAmount = reader["ThisMonthAmount"].AsDecimal(),
            };

        /// <summary>
        /// The make B09 BNG
        /// </summary>
        private static readonly Func<IDataReader, B09BNGEntity> MakeB09BNG = reader =>
            new B09BNGEntity
            {
                AccumulatedAmount = reader["AccumulatedAmount"].AsDecimal(),
                ItemId = reader["ItemId"].AsString(),
                ItemName = reader["ItemName"].AsString(),
                FontStyle = reader["FontStyle"].AsString(),
                Grade = reader["Grade"].AsInt(),
                ParentId = reader["ParentId"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                QuarterB09 = reader["QuarterB09"].AsInt()
            };

        /// <summary>
        /// The make employee
        /// </summary>
        private static readonly Func<IDataReader, EmployeeForEstimateEntity> MakeEmployee = reader =>
           new EmployeeForEstimateEntity
           {
               OrderNumber = reader["ID"].AsInt(),
               EmployeeName = reader["EmployeeName"].AsString(),
               JobCandidateName = reader["JobCandidateName"].AsString(),
               Description = reader["Description"].AsString(),
               SubsitenceFee = reader["SubsitenceFee"].AsFloat(),
               WomenAllowance = reader["WomenAllowance"].AsFloat(),
               PluralityAllowance = reader["PluralityAllowance"].AsFloat(),
               StartedDate = reader["StartedDate"].AsDateTime(),
               FinishedDate = reader["FinishedDate"].AsDateTime(),
           };

        /// <summary>
        /// The make fixed asset
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetForEstimateEntity> MakeFixedAsset = reader =>
           new FixedAssetForEstimateEntity
           {
               OrderNumber = reader["ID"].AsInt(),
               EmployeeName = reader["EmployeeName"].AsString(),
               JobCandidateName = reader["JobCandidateName"].AsString(),
               Description = reader["Description"].AsString(),
               Address = reader["Address"].AsString(),
               UsingOfArea = reader["UsingOfArea"].AsFloat()
           };

        #endregion

        /// <summary>
        /// The make C22 hd
        /// </summary>
        private static readonly Func<IDataReader, InventoryItemReportEntity> MakeInventoryItemReport = reader =>
           new InventoryItemReportEntity
           {
               OrderNumber = reader["OrderNumber"].AsInt(),
               InventoryItemName = reader["InventoryItemName"].AsString(),
               Quantity = reader["Quantity"].AsInt(),
               Price = reader["Price"].AsDecimal(),
               AmountOc = reader["AmountOc"].AsDecimal(),
               Unit = reader["Unit"].AsString()

           };
        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns>
        /// IList&lt;C11HEntity&gt;.
        /// </returns>
        public IList<C11HEntity> GetReportC11H(string storeProdure, string refIdList)
        {
            string sql = storeProdure;
            IList<C11HEntity> list = new List<C11HEntity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                C11HEntity obj = Db.Read(sql, true, MakeC11HD, parms);

                object[] parmsDetails = { "@RefID", refID };
                IList<InventoryItemReportEntity> listDetail = Db.ReadList("uspGet_Report_C11HD_InventoryItemDetailList", true, MakeInventoryItemReport, parmsDetails);
                obj.InventoryItems = listDetail;
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public IList<InventoryItemReportEntity> GetInventoryItems(string refIdList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <param name="reftypeId">The reftype identifier.</param>
        /// <returns>
        /// IList&lt;AccountingVoucherEntity&gt;.
        /// </returns>
        public IList<AccountingVoucherEntity> GetAccountingVoucher(string storeProdure, string refIdList, int reftypeId)
        {
            IList<AccountingVoucherEntity> list = new List<AccountingVoucherEntity>();
            int stt = 1;
            foreach (var refID in refIdList.Split(';'))
            {

                object[] parms = { "@RefID", refID, "@RefType", reftypeId };
                var listobj = Db.ReadList(storeProdure, true, MakeAccountingVoucher, parms);
                foreach (var accountingVoucherEntity in listobj)
                {
                    accountingVoucherEntity.OrderNumber = stt;
                    stt = stt + 1;
                    list.Add(accountingVoucherEntity);
                }

            }
            return list;
        }

        /// <summary>
        /// Updates the report.
        /// </summary>
        /// <param name="reportListEntity">The report list entity.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string UpdateReport(ReportListEntity reportListEntity)
        {
            const string procedures = @"uspUpdate_ReportList";
            return Db.Update(procedures, true, Take(reportListEntity));
        }

        /// <summary>
        /// Takes the specified report list.
        /// </summary>
        /// <param name="reportList">The report list.</param>
        /// <returns>
        /// System.Object[].
        /// </returns>
        private object[] Take(ReportListEntity reportList)
        {
            return new object[]
             {
                 "@ReportID",reportList.ReportId,
                 "@PrintVoucherDefault",reportList.PrintVoucherDefault
             };
        }
    }
}