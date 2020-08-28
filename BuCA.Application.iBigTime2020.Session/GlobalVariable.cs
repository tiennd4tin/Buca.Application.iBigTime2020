/***********************************************************************
 * <copyright file="GlobalVariable.cs" company="BUCA JSC">
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
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.View.Dictionary;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Session
{
    /// <summary>
    /// GlobalVariable
    /// </summary>
    public static class GlobalVariable
    {
        //private uint _PropertyName;
        private static IModel Model { get; set; }

        #region Options

        public static string PathXML { get; set; }
        /// <summary>
        /// Gets or sets the financial month.
        /// </summary>
        /// <value>
        /// The financial month.
        /// </value>
        public static string FinancialMonth { get; set; }

        /// <summary>
        /// Gets or sets the financial end of date.
        /// </summary>
        /// <value>
        /// The financial end of date.
        /// </value>
        public static string FinancialEndOfDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is post to parent account].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is post to parent account]; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPostToParentAccount { get; set; }

        /// <summary>
        /// Gets or sets the base of salary.
        /// </summary>
        /// <value>
        /// The base of salary.
        /// </value>
        public static decimal BaseOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the currency code of salary.
        /// </summary>
        /// <value>
        /// The currency code of salary.
        /// </value>
        public static string CurrencyCodeOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the currency accounting.
        /// </summary>
        /// <value>
        /// The currency accounting.
        /// </value>
        public static string MainCurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency accounting usd.
        /// </summary>
        /// <value>
        /// The currency accounting usd.
        /// </value>
        public static string CurrencyLocal { get; set; }

        /// <summary>
        /// Gets or sets the job title company director.
        /// </summary>
        /// <value>
        /// The job title company director.
        /// </value>
        public static string JobTitleCompanyDirector { get; set; }

        /// <summary>
        /// Gets or sets the job title company director.
        /// </summary>
        /// <value>
        /// The job title company director.
        /// </value>
        public static string JobTitleCompanyStoreKeeper { get; set; }

        /// <summary>
        /// Gets or sets the job title company accountant.
        /// </summary>
        /// <value>
        /// The job title company accountant.
        /// </value>
        public static string CompanyAccountantTitle { get; set; }

        /// <summary>
        /// Gets or sets the job title company accountant.
        /// </summary>
        /// <value>
        /// The job title company accountant.
        /// </value>
        public static string JobTitleCompanyReportPreparer { get; set; }

        /// <summary>
        /// Gets or sets the job title company cashier.
        /// </summary>
        /// <value>
        /// The job title company cashier.
        /// </value>
        public static string JobTitleCompanyCashier { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>
        /// The currency symbol.
        /// </value>
        public static string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol in report.
        /// </summary>
        /// <value>The currency symbol in report.</value>
        public static string CurrencySymbolInReport { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits.
        /// </summary>
        /// <value>
        /// The currency decimal digits.
        /// </value>
        public static int CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits in report.
        /// </summary>
        /// <value>The currency decimal digits in report.</value>
        public static int CurrencyDecimalDigitsInReport { get; set; }

        /// <summary>
        /// Gets or sets the currency negative pattern in report.
        /// </summary>
        /// <value>The currency negative pattern in report.</value>
        public static int CurrencyNegativePatternInReport { get; set; }

        /// <summary>
        /// Gets or sets the currency positive pattern in report.
        /// </summary>
        /// <value>The currency positive pattern in report.</value>
        public static int CurrencyPositivePatternInReport { get; set; }

        /// <summary>
        /// Gets or sets the number decimal digits.
        /// </summary>
        /// <value>
        /// The number decimal digits.
        /// </value>
        public static string NumberDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the number decimal digits.
        /// </summary>
        /// <value>
        /// The number decimal digits.
        /// </value>
        public static string UnitPriceDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the percent decimal digits.
        /// </summary>
        /// <value>
        /// The percent decimal digits.
        /// </value>
        public static string PercentDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the currency positive pattern.
        /// </summary>
        /// <value>
        /// The currency positive pattern.
        /// </value>
        public static int CurrencyPositivePattern { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate decimal digits.
        /// </summary>
        /// <value>
        /// The exchange rate decimal digits.
        /// </value>
        public static string ExchangeRateDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the currency negative pattern.
        /// </summary>
        /// <value>
        /// The currency negative pattern.
        /// </value>
        public static int CurrencyNegativePattern { get; set; }

        /// <summary>
        /// Gets or sets the current culture information.
        /// </summary>
        /// <value>
        /// The current culture information.
        /// </value>
        public static CultureInfo CurrentCultureInfo { get; set; }

        /// <summary>
        /// Gets or sets the chapter font.
        /// </summary>
        /// <value>
        /// The chapter font.
        /// </value>
        public static string ChapterFont { get; set; }

        /// <summary>
        /// Gets or sets the company address font.
        /// </summary>
        /// <value>
        /// The company address font.
        /// </value>
        public static string CompanyAddressFont { get; set; }

        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        /// <value>
        /// The company address.
        /// </value>
        public static string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the company bank account no.
        /// </summary>
        /// <value>
        /// The company bank account no.
        /// </value>
        public static string CompanyBankAccountNo { get; set; }

        /// <summary>
        /// Gets or sets the company bank adrress.
        /// </summary>
        /// <value>
        /// The company bank adrress.
        /// </value>
        public static string CompanyBankAdrress { get; set; }

        /// <summary>
        /// Gets or sets the name of the company bank.
        /// </summary>
        /// <value>
        /// The name of the company bank.
        /// </value>
        public static string CompanyBankName { get; set; }

        /// <summary>
        /// Gets or sets the company cashier.
        /// </summary>
        /// <value>
        /// The company cashier.
        /// </value>
        public static string CompanyCashier { get; set; }

        /// <summary>
        /// Gets or sets the company cashier title.
        /// </summary>
        /// <value>
        /// The company cashier title.
        /// </value>
        public static string CompanyCashierTitle { get; set; }

        /// <summary>
        /// Gets or sets the company accountant.
        /// </summary>
        /// <value>
        /// The company accountant.
        /// </value>
        public static string CompanyAccountant { get; set; }

        /// <summary>
        /// Gets or sets the company chief accountant title.
        /// </summary>
        /// <value>
        /// The company chief accountant title.
        /// </value>
        public static string CompanyChiefAccountantTitle { get; set; }

        /// <summary>
        /// Gets or sets the company chief accountant.
        /// </summary>
        /// <value>The company chief accountant.</value>
        public static string CompanyChiefAccountant { get; set; }

        /// <summary>
        /// Gets or sets the company city.
        /// </summary>
        /// <value>
        /// The company city.
        /// </value>
        public static string CompanyCity { get; set; }

        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <value>
        /// The company code.
        /// </value>
        public static string CompanyCode { get; set; }

        /// <summary>
        /// Gets or sets the company code font.
        /// </summary>
        /// <value>
        /// The company code font.
        /// </value>
        public static string CompanyCodeFont { get; set; }

        /// <summary>
        /// Gets or sets the company director.
        /// </summary>
        /// <value>
        /// The company director.
        /// </value>
        public static string CompanyDirector { get; set; }

        /// <summary>
        /// Gets or sets the company director title.
        /// </summary>
        /// <value>
        /// The company director title.
        /// </value>
        public static string CompanyDirectorTitle { get; set; }

        /// <summary>
        /// Gets or sets the company district.
        /// </summary>
        /// <value>
        /// The company district.
        /// </value>
        public static string CompanyDistrict { get; set; }

        /// <summary>
        /// Gets or sets the company email.
        /// </summary>
        /// <value>
        /// The company email.
        /// </value>
        public static string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company fax.
        /// </summary>
        /// <value>
        /// The company fax.
        /// </value>
        public static string CompanyFax { get; set; }

        /// <summary>
        /// Gets or sets the company in charge.
        /// </summary>
        /// <value>
        /// The company in charge.
        /// </value>
        public static string CompanyInCharge { get; set; }

        /// <summary>
        /// Gets or sets the company in charge font.
        /// </summary>
        /// <value>
        /// The company in charge font.
        /// </value>
        public static string CompanyInChargeFont { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public static string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company owner.
        /// </summary>
        /// <value>
        /// The company owner.
        /// </value>
        public static string CompanyOwner { get; set; }

        /// <summary>
        /// Gets or sets the license number.
        /// </summary>
        /// <value>
        /// The license number.
        /// </value>
        public static string LicenseNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid license.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid license; otherwise, <c>false</c>.
        /// </value>
        public static bool IsValidLicense { get; set; }

        /// <summary>
        /// Gets or sets the company name font.
        /// </summary>
        /// <value>
        /// The company name font.
        /// </value>
        public static string CompanyNameFont { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        /// <value>
        /// The company phone.
        /// </value>
        public static string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the company province.
        /// </summary>
        /// <value>
        /// The company province.
        /// </value>
        public static string CompanyProvince { get; set; }

        /// <summary>
        /// Gets or sets the company report preparer.
        /// </summary>
        /// <value>
        /// The company report preparer.
        /// </value>
        public static string CompanyReportPreparer { get; set; }


        /// <summary>
        /// Gets or sets the company report preparer title.
        /// </summary>
        /// <value>
        /// The company report preparer title.
        /// </value>
        public static string CompanyReportPreparerTitle { get; set; }

        /// <summary>
        /// Gets or sets the company store keeper.
        /// </summary>
        /// <value>
        /// The company store keeper.
        /// </value>
        public static string CompanyStoreKeeper { get; set; }

        /// <summary>
        /// Gets or sets the company store keeper title.
        /// </summary>
        /// <value>
        /// The company store keeper title.
        /// </value>
        public static string CompanyStoreKeeperTitle { get; set; }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public static string CompanyTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the company in charge sort order on report.
        /// </summary>
        /// <value>
        /// The company in charge sort order on report.
        /// </value>
        public static int CompanyInChargeSortOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company adrress order on report.
        /// </summary>
        /// <value>
        /// The company adrress order on report.
        /// </value>
        public static int CompanyAdrressOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company name sort order on report.
        /// </summary>
        /// <value>
        /// The company name sort order on report.
        /// </value>
        public static int CompanyNameSortOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company code order on report.
        /// </summary>
        /// <value>
        /// The company code order on report.
        /// </value>
        public static int CompanyCodeOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the chapter order on report.
        /// </summary>
        /// <value>
        /// The chapter order on report.
        /// </value>
        public static int ChapterOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the currency unit price digits.
        /// </summary>
        /// <value>
        /// The currency unit price digits.
        /// </value>
        public static int CurrencyUnitPriceDigits { get; set; }

        /// <summary>
        /// Gets or sets the currency unit price digits in report.
        /// </summary>
        /// <value>The currency unit price digits in report.</value>
        public static int CurrencyUnitPriceDigitsInReport { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate digits.
        /// </summary>
        /// <value>
        /// The exchange rate digits.
        /// </value>
        public static int ExchangeRateDigits { get; set; }

        /// <summary>
        /// Gets or sets the quantity digits.
        /// </summary>
        /// <value>
        /// The quantity digits.
        /// </value>
        public static int QuantityDigits { get; set; }

        /// <summary>
        /// Gets or sets the general decimal separator.
        /// </summary>
        /// <value>
        /// The general decimal separator.
        /// </value>
        public static string GeneralDecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the general group separator.
        /// </summary>
        /// <value>
        /// The general group separator.
        /// </value>
        public static string GeneralGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets the display vourcher mode.
        /// </summary>
        /// <value>
        /// The display vourcher mode.
        /// </value>
        public static int DisplayVourcherMode { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public static string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the started date.
        /// </summary>
        /// <value>
        /// The started date.
        /// </value>
        public static string StartedDate { get; set; }

        public static string DBStartDate { get; set; }

        /// <summary>
        /// Gets or sets the system date.
        /// </summary>
        /// <value>
        /// The system date.
        /// </value>
        public static string SystemDate { get; set; }

        /// <summary>
        /// Gets or sets the print system date.
        /// </summary>
        /// <value>The print system date.</value>
        public static int PrintSystemDate { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public static DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public static DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the index of the date range selected.
        /// </summary>
        /// <value>
        /// The index of the date range selected.
        /// </value>
        public static int DateRangeSelectedIndex { get; set; }
        public static string DateRangeSelected { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public static string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public static string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public static string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static string FullName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// The assembly path
        /// </summary>
        private static readonly string AssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\", StringComparison.Ordinal));

        /// <summary>
        /// The path
        /// </summary>
        private static readonly string Path = AssemblyPath.Substring(0, AssemblyPath.LastIndexOf(@"\", StringComparison.Ordinal));

        /// <summary>
        /// The report path
        /// </summary>
        public static string ReportPath = Path + @"\Report\";

        /// <summary>
        /// The combo path layout
        /// </summary>
        public static string DataPath = Path + @"\DATA\";

        /// <summary>
        /// The template path
        /// </summary>
        public static string TemplatePath = "";

        /// <summary>
        /// The bin path
        /// </summary>
        public static string BinPath = "";

        /// <summary>
        /// The type path
        /// </summary>
        public static string TypePath = "";

        /// <summary>
        /// The produc name
        /// </summary>
        public static string ProducName = "A-BIGTIME.NET 2018";

        /// <summary>
        /// The application name
        /// </summary>
        public static string ApplicationName = "A-BIGTIME.NET 2018";

        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>
        /// The report list.
        /// </value>
        public static ReportListModel ReportList { get; set; }

        /// <summary>
        /// Gets or sets the name of the store procedure.
        /// </summary>
        /// <value>
        /// The name of the store procedure.
        /// </value>
        public static string StoreProcedureName { get; set; }

        /// <summary>
        /// Gets or sets the drill down parram.
        /// </summary>
        /// <value>
        /// The drill down parram.
        /// </value>
        public static object[] DrillDownParram { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is drill down report.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is drill down report; otherwise, <c>false</c>.
        /// </value>
        public static bool IsDrillDownReport { get; set; }

        /// <summary>
        /// The currency main
        /// </summary>
        public static string CurrencyMain = "USD";

        /// <summary>
        /// Gets or sets the currency view report.
        /// </summary>
        /// <value>
        /// The currency view report.
        /// </value>
        public static string CurrencyViewReport { get; set; }

        /// <summary>
        /// Gets or sets the amount type view report.
        /// </summary>
        /// <value>
        /// The amount type view report.
        /// </value>
        public static int AmountTypeViewReport { get; set; }

        /// <summary>
        /// The currency display string
        /// </summary>
        public static string CurrencyDisplayString = "{0:c}";

        /// <summary>
        /// The numeric display string
        /// </summary>
        public static string NumericDisplayString = "{0:n}";

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public static int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public static long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier list.
        /// </summary>
        /// <value>
        /// The reference identifier list.
        /// </value>
        public static string RefIdList { get; set; }

        /// <summary>
        /// Gets or sets the daily backup path.
        /// </summary>
        /// <value>
        /// The daily backup path.
        /// </value>
        public static string DailyBackupPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is daily backup.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is daily backup; otherwise, <c>false</c>.
        /// </value>
        public static bool IsDailyBackup { get; set; }

        /// <summary>
        /// Cho phép chi tiền gửi khi quỹ âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deposite negavtive fund; otherwise, <c>false</c>.
        /// </value>
        public static bool IsDepositeNegavtiveFund { get; set; }

        /// <summary>
        /// Cho phép xuất khi hết hàng
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is outward negative stock; otherwise, <c>false</c>.
        /// </value>

        public static bool IsOutwardNegativeStock { get; set; }

        /// <summary>
        /// Cho phép chi tiền mặt theo nguồn âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is payment negative budget source; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPaymentNegativeBudgetSource { get; set; }

        /// <summary>
        /// Cho phép chi tiền mặt quĩ âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is payment negative fund; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPaymentNegativeFund { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner company.
        /// </summary>
        /// <value>The name of the owner company.</value>
        public static string OwnerCompanyName { get; set; }


        public static string Version { get; set; }

        public static string VersionControl { get; set; }


        public static string TitleConsulManager { get; set; }

        public static string ConsulManager { get; set; }

        public static int AccountingBooksType { get; set; }

        public static bool AutoBackup { get; set; }

        //phương pháp tính giá xuất kho
        public static int DefaultCostMethod { get; set; }

        /// <summary>
        /// Nguồn ngầm định
        /// </summary>
        public static string DefaultBudgetSourceID { get; set; }

        /// <summary>
        /// Chương ngầm định
        /// </summary>
        public static string DefaultBudgetChapterCode { get; set; }

        /// <summary>
        /// Loại khoản ngầm định
        /// </summary>
        public static string DefaultBudgetKindItemCode { get; set; }

        /// <summary>
        /// Khoản ngầm định
        /// </summary>
        public static string DefaultBudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Nghiệp vụ ngầm định
        /// </summary>
        public static int DefaultCashWithDrawTypeID { get; set; }

        /// <summary>
        /// Cấp phát ngầm định
        /// </summary>
        public static int DefaultMethodDistributeID { get; set; }

        /// <summary>
        /// Gets or sets the devaluation period.
        /// </summary>
        /// <value>
        /// The devaluation period.
        /// </value>
        public static int DevaluationPeriod { get; set; }

        public static string LockVoucherSeason { get; set; } //Kỳ khóa sổ
        public static string LockVoucherDateFrom { get; set; } 
        public static string LockVoucherDateTo { get; set; }
        public static int IsLockVoucher { get; set; } // Trạng thái khóa sổ

        /// <summary>
        /// Gets or sets the is display new license information.
        /// </summary>
        /// <value>The is display new license information.</value>
        public static bool IsDisplayNewLicenseInfo { get; set; }
        public static string EmployeeIDDetailForm { get; set; }//Cán bộ
        public static string ProjectIDAccountingObjectDetailForm { get; set; }//Dự án
        public static string ContractIDDetailForm { get; set; }// Hợp đồng
        public static string FixedAssetCategoryDetailForm { get; set; }//Nhóm tscd
        public static string BudgetChapterIDAccountingObjectDetailForm { get; set; }//Chương
        public static string BudgetItemDetailAccountingObjectDetailForm { get; set; }
        public static string DepartmentIDEmployeeDetailForm { get; set; }//phòng ban
        public static string AccountingObjectIDInventoryItemDetailForm { get; set; }//Đối tượng
        public static string StockIDInventoryItemDetailForm { get; set; }//Kho
        public static string BankIDProjectDetailForm { get; set; }//Ngân hàng
        public static string TargetProgramIDTargetProgamForm { get; set; }//chương trình mục tiêu
        public static string BudgetSourceIDAccountTransferForm { get; set; }//Nguồn vốn
        public static string AccountIDAccountTransferForm { get; set; }//Tài khoản
        public static string BudgetKindItemIDAutoBusinessForm { get; set; }
        public static string ActivityDtailIDActivityForm { get; set; }
        public static string FundStructDetailIDFundStructForm { get; set; }
        /// <summary>
        /// Thời gian hết hạn phần mềm
        /// </summary>
        public static DateTime TimeExpried { get; set; }
        public static bool IsViewVoucher { get; set; }//AnhNT: check xem đã view chứng từ từ BC chưa. Tránh chứng từ bị view nhiều lần
       
        #endregion

        #region Server
        //Link check new version
        public static string LinkServerUpdate = "http://10.0.0.241:1001/IBigTimeTT79/AutoUpdate.xml";//Enagle dòng này khi build bản release
        //public static readonly string LinkServerUpdate = @"\\anhnt\TestAutoUpdate\AutoUpdate.xml";

        public static Version LicenseLimit = new Version("9.9.9");//License limit for user

        public static bool IsAutoUpdateSQL;
        public static string FileListSQLUpdate;

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public static Server Server { get; set; }

        /// <summary>
        /// Gets or sets the server connection.
        /// </summary>
        /// <value>
        /// The server connection.
        /// </value>
        public static ServerConnection ServerConnection { get; set; }

        #endregion

        #region Encode & Decode

        public static string Enc(string text)
        {
            string EncryptionKey = "BuCA";
            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return text;
        }
        public static string Dec(string text)
        {
            string EncryptionKey = "BuCA";
            text = text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    text = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return text;
        }
        #endregion

        /// <summary>
        /// Registers this instance.
        /// </summary>
        public static void Register()

        {
            var value = Model.GetDBOptions();

            if (value == null)
                return;

            //chu ky
            CompanyAccountant = (from dbOption in value where dbOption.OptionId == "CompanyAccountant" select dbOption.OptionValue).First();
            CompanyAccountantTitle = (from dbOption in value where dbOption.OptionId == "CompanyAccountantTitle" select dbOption.OptionValue).First();
            CompanyCashier = (from dbOption in value where dbOption.OptionId == "CompanyCashier" select dbOption.OptionValue).First();
            CompanyCashierTitle = (from dbOption in value where dbOption.OptionId == "CompanyCashierTitle" select dbOption.OptionValue).First();
            CompanyChiefAccountant = (from dbOption in value where dbOption.OptionId == "CompanyChiefAccountant" select dbOption.OptionValue).First();
            CompanyChiefAccountantTitle = (from dbOption in value where dbOption.OptionId == "CompanyChiefAccountantTitle" select dbOption.OptionValue).First();
            CompanyDirector = (from dbOption in value where dbOption.OptionId == "CompanyDirector" select dbOption.OptionValue).First();
            CompanyDirectorTitle = (from dbOption in value where dbOption.OptionId == "CompanyDirectorTitle" select dbOption.OptionValue).First();
            CompanyReportPreparer = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparer" select dbOption.OptionValue).First();
            CompanyReportPreparerTitle = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparerTitle" select dbOption.OptionValue).First();
            CompanyStoreKeeper = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeper" select dbOption.OptionValue).First();
            CompanyStoreKeeperTitle = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeperTitle" select dbOption.OptionValue).First();

            var optionModel = value.FirstOrDefault(v => v.OptionId == "DBStartDate");
            StartedDate = optionModel == null ? null : optionModel.OptionValue;
            DBStartDate = optionModel == null ? null : optionModel.OptionValue;

            CompanyNameFont = (from dbOption in value where dbOption.OptionId == "CompanyNameFont" select dbOption.OptionValue).First();
            CompanyAddressFont = (from dbOption in value where dbOption.OptionId == "CompanyAddressFont" select dbOption.OptionValue).First();

            var lockVoucherDate = value.FirstOrDefault(v => v.OptionId == "LockVoucher");
            if (lockVoucherDate != null)
            {
                if(!string.IsNullOrEmpty(lockVoucherDate.OptionValue))
                {
                    string dateLock = lockVoucherDate.OptionValue ?? "";
                    LockVoucherDateFrom = dateLock.Substring(0, 10);
                    LockVoucherDateTo = dateLock.Substring(dateLock.Length - 10, 10);
                    LockVoucherSeason = lockVoucherDate.Description;
                    //LockVoucherDate = lockVoucherDate.OptionValue ?? "";
                    IsLockVoucher = lockVoucherDate.ValueType;
                }    

            }

            ////ThoDD thêm thông tin kiểm kê
            //JobOfInventory1 = (from dbOption in value where dbOption.OptionId == "JobOfInventory1" select dbOption.OptionValue).First();
            //JobOfInventory2 = (from dbOption in value where dbOption.OptionId == "JobOfInventory2" select dbOption.OptionValue).First();
            //JobOfInventory3 = (from dbOption in value where dbOption.OptionId == "JobOfInventory3" select dbOption.OptionValue).First();
            //NameOfInventory1 = (from dbOption in value where dbOption.OptionId == "NameOfInventory1" select dbOption.OptionValue).First();
            //NameOfInventory2 = (from dbOption in value where dbOption.OptionId == "NameOfInventory2" select dbOption.OptionValue).First();
            //NameOfInventory3 = (from dbOption in value where dbOption.OptionId == "NameOfInventory3" select dbOption.OptionValue).First();
            //DateOfInventory = (from dbOption in value where dbOption.OptionId == "DateOfInventory" select dbOption.OptionValue).First();
            //HourOfInventory = (from dbOption in value where dbOption.OptionId == "HourOfInventory" select dbOption.OptionValue).First();
            //MinuteOfInventory = (from dbOption in value where dbOption.OptionId == "MinuteOfInventory" select dbOption.OptionValue).First();
            ////END
            //JobTitleCompanyDirector = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyDirector" select dbOption.OptionValue).First();
            //CompanyAccountantTitle = (from dbOption in value where dbOption.OptionId == "CompanyAccountantTitle" select dbOption.OptionValue).First();
            //JobTitleCompanyReportPreparer = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyReportPreparer" select dbOption.OptionValue).First();
            //JobTitleCompanyCashier = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyCashier" select dbOption.OptionValue).First();
            //JobTitleCompanyStoreKeeper = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyStoreKeeper" select dbOption.OptionValue).First();
            //CompanyCity = (from dbOption in value where dbOption.OptionId == "CompanyCity" select dbOption.OptionValue).First();
            CompanyProvince = (from dbOption in value where dbOption.OptionId == "CompanyProvince" select dbOption.OptionValue).First();

            // Chưa biết lí do sao comment company code lại

            CompanyCode = (from dbOption in value where dbOption.OptionId == "CompanyCode" select dbOption.OptionValue).First();

            //currency format
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyDecimalDigits");
            CurrencyDecimalDigits = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyNegativePattern");
            CurrencyNegativePattern = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyPositivePattern");
            CurrencyPositivePattern = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencySymbol");
            CurrencySymbol = optionModel == null ? "" : optionModel.OptionValue;
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyUnitPriceDigits");
            CurrencyUnitPriceDigits = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "GeneralDecimalSeparator");
            GeneralDecimalSeparator = optionModel == null ? "." : optionModel.OptionValue;
            optionModel = value.FirstOrDefault(v => v.OptionId == "GeneralGroupSeparator");
            GeneralGroupSeparator = optionModel == null ? "." : optionModel.OptionValue;

            //currency format for report
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyDecimalDigitsInReport");
            CurrencyDecimalDigitsInReport = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyNegativePatternInReport");
            CurrencyNegativePatternInReport = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyPositivePatternInReport");
            CurrencyPositivePatternInReport = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);
            CurrencySymbolInReport = (from dbOption in value where dbOption.OptionId == "CurrencySymbolInReport" select dbOption.OptionValue).First();
            optionModel = value.FirstOrDefault(v => v.OptionId == "CurrencyUnitPriceDigitsInReport");
            CurrencyUnitPriceDigitsInReport = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);

            optionModel = value.FirstOrDefault(v => v.OptionId == "OwnerCompanyName");
            OwnerCompanyName = optionModel == null ? "" : optionModel.OptionValue;

            //other
            optionModel = value.FirstOrDefault(v => v.OptionId == "AccountingBooksType");
            AccountingBooksType = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);

            optionModel = value.FirstOrDefault(v => v.OptionId == "DefaultCostMethod");
            DefaultCostMethod = optionModel == null ? 0 : int.Parse(optionModel.OptionValue);

            optionModel = value.FirstOrDefault(v => v.OptionId == "PathXML");
            PathXML = optionModel == null ? "" : optionModel.OptionValue;


            // Số chữ số sau dấu phẩy của số lượng
            NumberDecimalDigits = (from dbOption in value where dbOption.OptionId == "NumberDecimalDigits" select dbOption.OptionValue).First();
            //PercentDecimalDigits = (from dbOption in value where dbOption.OptionId == "PercentDecimalDigits" select dbOption.OptionValue).First();
            //UnitPriceDecimalDigits = (from dbOption in value where dbOption.OptionId == "UnitPriceDecimalDigits" select dbOption.OptionValue).First();

            //DisplayVourcherMode = int.Parse((from dbOption in value where dbOption.OptionId == "DisplayVourcherMode" select dbOption.OptionValue).First());
            optionModel = value.FirstOrDefault(v => v.OptionId == "DBPostedDate");
            PostedDate = optionModel == null ? null : optionModel.OptionValue;
            //FinancialEndOfDate = (from dbOption in value where dbOption.OptionId == "FinancialEndOfDate" select dbOption.OptionValue).First();
            //CurrencyCodeOfSalary = (from dbOption in value where dbOption.OptionId == "CurrencyCodeOfSalary" select dbOption.OptionValue).First();
            optionModel = value.FirstOrDefault(v => v.OptionId == "MainCurrencyID");
            MainCurrencyId = optionModel == null ? null : optionModel.OptionValue;
            SystemDate = (from dbOption in value where dbOption.OptionId == "DBStartDate" select dbOption.OptionValue).First();
            //BaseOfSalary = decimal.Parse((from dbOption in value where dbOption.OptionId == "BaseOfSalary" select dbOption.OptionValue).First());
            ExchangeRateDecimalDigits = (from dbOption in value where dbOption.OptionId == "ExchangeRateDecimalDigits" select dbOption.OptionValue).First();
            //FinancialMonth = (from dbOption in value where dbOption.OptionId == "FinancialMonth" select dbOption.OptionValue).First();

            //IsDailyBackup = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDailyBackup" select dbOption.OptionValue).First());
            AutoBackup = bool.Parse((from dbOption in value where dbOption.OptionId == "AutoBackup" select dbOption.OptionValue).First());
            DailyBackupPath = (from dbOption in value where dbOption.OptionId == "PathBackup" select dbOption.OptionValue).First();
            ////ThangNK bổ sung=============================
            IsPostToParentAccount = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPostToParentAccount" select dbOption.OptionValue).First());
            IsDepositeNegavtiveFund = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDepositeNegavtiveFund" select dbOption.OptionValue).First());
            IsOutwardNegativeStock = bool.Parse((from dbOption in value where dbOption.OptionId == "IsOutwardNegativeStock" select dbOption.OptionValue).First());
            //IsPaymentNegativeBudgetSource = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeBudgetSource" select dbOption.OptionValue).First());
            IsPaymentNegativeFund = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeFund" select dbOption.OptionValue).First());

            ////ThoDD thêm để quản lý phiên bản sử dụng 
            //Version = (from dbOption in value where dbOption.OptionId == "Version" select dbOption.OptionValue).First();
            //VersionControl = (from dbOption in value where dbOption.OptionId == "VersionControl" select dbOption.OptionValue).First();
            //TitleConsulManager = (from dbOption in value where dbOption.OptionId == "TitleConsulManager" select dbOption.OptionValue).FirstOrDefault();
            //ConsulManager = (from dbOption in value where dbOption.OptionId == "ConsulManager" select dbOption.OptionValue).FirstOrDefault();

            // Danh mục ngầm định
            DefaultBudgetSourceID = (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultBudgetSourceID)) select dbOption.OptionValue).First();
            DefaultBudgetChapterCode = (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultBudgetChapterCode)) select dbOption.OptionValue).First();
            DefaultBudgetKindItemCode = (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultBudgetKindItemCode)) select dbOption.OptionValue).First();
            DefaultBudgetSubKindItemCode = (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultBudgetSubKindItemCode)) select dbOption.OptionValue).First();
            DefaultCashWithDrawTypeID = int.Parse((from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultCashWithDrawTypeID)) select dbOption.OptionValue).First() == null ? "0" : (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultCashWithDrawTypeID)) select dbOption.OptionValue).First());
            DefaultMethodDistributeID = int.Parse((from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultMethodDistributeID)) select dbOption.OptionValue).First() == null ? "0" : (from dbOption in value where dbOption.OptionId.Equals(nameof(DefaultMethodDistributeID)) select dbOption.OptionValue).First());
        }

        public static void GetVersion()
        {
            var value = Model.GetDBOptions();

            if (value == null)
                return;
            Version = value.Where(p => p.OptionId.ToUpper().Equals("VERSION")).FirstOrDefault().OptionValue;

            //
            try
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length <= 1) return;
                string argdec = Dec(args[1]);
                if (!File.Exists(argdec.Split(';')[1])) return;
                FileListSQLUpdate = argdec;
                IsAutoUpdateSQL = true;
            }
            catch { }

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalVariable" /> class.
        /// </summary>
        static GlobalVariable()
        {
            Model = new Model();
            //_dbOptionsPresenter = new DBOptionsPresenter(this);
        }
    }
}