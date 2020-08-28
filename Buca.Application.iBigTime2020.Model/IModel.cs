/***********************************************************************
/***********************************************************************
 * <copyright file="IModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Thangnk
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date: 19/05/2014  Author: ThangND   Description: Thêm các region, mọi người code cho hẳn hoi chút tạo các phần mục theo chuẩn để code không bị lẫn lộn
 * 
* ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Settlement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;

namespace Buca.Application.iBigTime2020.Model
{
    /// <summary>
    /// Interface IModel
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets the options for database information.
        /// </summary>
        /// <returns></returns>
        List<DBOptionModel> GetOptionsForDbInfo();
        #region CalculateClosing

        CalculateClosingModel GetCalculateClosing(string creditAccount, string currencyCode, DateTime todate,string RefID,int RefTypeId);

        #endregion CalculateClosing
        /// <summary>
        /// Gets the user permision by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        IList<UserPermisionModel> GetUserPermisionByFeatureId(string featureId);

        /// <summary>
        /// Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCodeIncludeParentCode">The budget kind item code.</param>
        /// <returns></returns>
        BudgetKindItemModel GetBudgetKindItemsByCodeIncludeParentCode(string budgetKindItemCode);

        /// <summary>
        /// Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        BudgetKindItemModel GetBudgetKindItemsByCode(string budgetKindItemCode);

        /// <summary>
        /// The is convert data
        /// Biến này để xác định nếu là chuyển đổi dữ liệu từ Foxpro lên
        /// thì không kiểm tra trùng số chứng từ, do ở Foxpro ko bắt lỗi
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is convert data]; otherwise, <c>false</c>.
        /// </value>
        bool IsConvertData { get; set; }

        /// <summary>
        /// Gets the report B01 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="iAccountGrade">The i account grade.</param>
        /// <param name="isSummarySource">if set to <c>true</c> [is summary source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsAddDataMonth13">if set to <c>true</c> [p is add data month13].</param>
        /// <param name="pIsPrintAccountDetailByBudgetSource">if set to <c>true</c> [p is print account detail by budget source].</param>
        /// <param name="pIsPrintAccountDecided">if set to <c>true</c> [p is print account decided].</param>
        /// <returns></returns>
        IList<B01HModel> GetReportB01H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceId,
            string budgetChapterCode, string budgetSubKindItem, int iAccountGrade, bool isSummarySource,
            bool isSummaryChapter,
            bool isSummarySubKindItem, bool pIsPrintMonth13, bool pIsAddDataMonth13,
            bool pIsPrintAccountDetailByBudgetSource,
            bool pIsPrintAccountDecided,
            int amountType,
            string currencyCode);

        /// <summary>
        /// Gets the report B01 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        IList<B01_BCTCModel> GetReportB01_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int AmountType, string CurrencyCode);

        /// <summary>
        /// Gets the report B02 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B02_BCTCModel&gt;.</returns>
        IList<B02_BCTCModel> GetReportB02_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId,int amountType,string currencyCode);

        /// <summary>
        /// Gets the report B04 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B04_BCTCModel&gt;.</returns>
        IList<ReportB04BCTCModel> GetB04BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        /// <summary>
        /// Gets the report B04 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B04_BCTCModel&gt;.</returns>
        IList<B04_BCTCModel> GetReportB04_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId);

        /// <summary>
        /// Gets the report b03a BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        IList<B03a_BCTCModel> GetReportB03a_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId,int amountType,string currencyCode);

        /// <summary>
        /// Gets the report B03B BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        IList<B03b_BCTCModel> GetReportB03b_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter,int amountType, string currencyCode);

        /// <summary>
        /// Gets the report B05 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <returns>IList&lt;B05_BCTCModel&gt;.</returns>
        IList<B05_BCTCModel> GetReportB05_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter);

        #region SettlememtReport

        /// <summary>
        /// Gets the report B02 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isAddDataMonth13">if set to <c>true</c> [is add data month13].</param>
        /// <returns></returns>
        IList<B02BCQTModel> GetReportB02BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13);

        /// <summary>
        /// Gets the report B03 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isAddDataMonth13">if set to <c>true</c> [is add data month13].</param>
        /// <returns></returns>
        IList<B03BCQTModel> GetReportB03BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13);

        /// <summary>
        /// Gets the report F01001 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <returns>IList{B03BCQTModel}.</returns>
        IList<F0101BCQTModel> GetReportF01001BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string CurrencyCode);

       
        DataSet GetReportF0102BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, string listprojectID, int methodDistribute, bool isMethodDistribute, bool isProject);
        /// <summary>
        /// Gets the report B01 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <returns></returns>
        DataSet GetReportB01BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string currencyCode);
        #endregion
        ReportDataTemplateModel GetReportDataTemplate(string dataTemplateCode);
        long InsertOrUpdateReportDataTemplate(ReportDataTemplateModel reportDataTemplate);
        #region Currency

        /// <summary>
        /// Gets the currencies is main.
        /// </summary>
        /// <returns>IList&lt;CurrencyModel&gt;.</returns>
        IList<CurrencyModel> GetCurrenciesIsMain();

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns>IList&lt;CurrencyModel&gt;.</returns>
        IList<CurrencyModel> GetCurrencies();

        /// <summary>
        /// Gets the currencies active.
        /// </summary>
        /// <returns>IList&lt;CurrencyModel&gt;.</returns>
        IList<CurrencyModel> GetCurrenciesActive();

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>CurrencyModel.</returns>
        CurrencyModel GetCurrency(string currencyId);

        /// <summary>
        /// Gets the currency by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>CurrencyModel.</returns>
        CurrencyModel GetCurrencyByCurrencyCode(string currencyCode);

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        string AddCurrency(CurrencyModel currency);

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        string UpdateCurrency(CurrencyModel currency);

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCurrency(string currencyId);

        #endregion

        #region BugdetSource

        /// <summary>
        /// Gets the budget sources.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSources();

        /// <summary>
        /// Gets the budget source.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// BudgetSourceModel.
        /// </returns>
        BudgetSourceModel GetBudgetSource(string budgetSourceId);

        /// <summary>
        /// Gets the budget sources for combo tree.
        /// </summary>
        /// <param name="budgetSourcePropertyId">The budget source property identifier.</param>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesForComboTree(int budgetSourcePropertyId);

        /// <summary>
        /// Gets the budget sources active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesActive();

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        IList<BudgetSourceModel> GetBudgetSourcesIsParent(bool isParent);

        /// <summary>
        /// Gets the budget sources by fund.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesByFund();

        /// <summary>
        /// Adds the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddBudgetSource(BudgetSourceModel budgetSource);

        /// <summary>
        /// Updates the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBudgetSource(BudgetSourceModel budgetSource);

        /// <summary>
        /// Deletes the budget source.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBudgetSource(string budgetSourceId);

        #endregion

        #region BudgetChapter

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        IList<BudgetChapterModel> GetBudgetChapters();

        /// <summary>
        /// Gets the budget chapters active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList{BudgetChapterModel}.</returns>
        IList<BudgetChapterModel> GetBudgetChaptersByIsActive(bool isActive);

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>BudgetChapterModel.</returns>
        BudgetChapterModel GetBudgetChapter(string budgetChapterId);

        /// <summary>
        /// Adds the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.Int32.</returns>
        string AddBudgetChapter(BudgetChapterModel budgetChapter);

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.Int32.</returns>
        string UpdateBudgetChapter(BudgetChapterModel budgetChapter);

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>System.Int32.</returns>
        string DeleteBudgetChapter(string budgetChapterId);

        #endregion

        //#region BudgetCategory

        ///// <summary>
        ///// Gets the budget categories.
        ///// </summary>
        ///// <returns>
        ///// IList{BudgetCategoryModel}.
        ///// </returns>
        //IList<BudgetCategoryModel> GetBudgetCategories();

        ///// <summary>
        ///// Gets the budget category.
        ///// </summary>
        ///// <param name="budgetCategoryId">The budget category identifier.</param>
        ///// <returns>
        ///// BudgetCategoryModel.
        ///// </returns>
        //BudgetCategoryModel GetBudgetCategory(int budgetCategoryId);

        ///// <summary>
        ///// Gets the budget categories for combo tree.
        ///// </summary>
        ///// <param name="budgetCategoryId">The budget category identifier.</param>
        ///// <returns>
        ///// IList{BudgetCategoryModel}.
        ///// </returns>
        //IList<BudgetCategoryModel> GetBudgetCategoriesForComboTree(int budgetCategoryId);

        ///// <summary>
        ///// Gets the budget categories active.
        ///// </summary>
        ///// <returns>
        ///// IList{BudgetCategoryModel}.
        ///// </returns>
        //IList<BudgetCategoryModel> GetBudgetCategoriesActive();

        ///// <summary>
        ///// Adds the budget category.
        ///// </summary>
        ///// <param name="budgetCategory">The budget category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddBudgetCategory(BudgetCategoryModel budgetCategory);

        ///// <summary>
        ///// Updates the budget category.
        ///// </summary>
        ///// <param name="budgetCategory">The budget category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateBudgetCategory(BudgetCategoryModel budgetCategory);

        ///// <summary>
        ///// Deletes the budget category.
        ///// </summary>
        ///// <param name="budgetCategoryId">The budget category identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteBudgetCategory(int budgetCategoryId);

        //#endregion

        //#region MergerFund

        ///// <summary>
        ///// Gets the merger funds.
        ///// </summary>
        ///// <returns>
        ///// IList{MergerFundModel}.
        ///// </returns>
        //IList<MergerFundModel> GetMergerFunds();

        ///// <summary>
        ///// Gets the merger fund.
        ///// </summary>
        ///// <param name="mergerFundId">The merger fund identifier.</param>
        ///// <returns>
        ///// MergerFundModel.
        ///// </returns>
        //MergerFundModel GetMergerFund(int mergerFundId);

        ///// <summary>
        ///// Gets the merger funds for combo tree.
        ///// </summary>
        ///// <param name="mergerFundId">The merger fund identifier.</param>
        ///// <returns>
        ///// IList{MergerFundModel}.
        ///// </returns>
        //IList<MergerFundModel> GetMergerFundsForComboTree(int mergerFundId);

        ///// <summary>
        ///// Gets the merger funds active.
        ///// </summary>
        ///// <returns>
        ///// IList{MergerFundModel}.
        ///// </returns>
        //IList<MergerFundModel> GetMergerFundsActive();

        ///// <summary>
        ///// Adds the merger fund.
        ///// </summary>
        ///// <param name="mergerFund">The merger fund.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddMergerFund(MergerFundModel mergerFund);

        ///// <summary>
        ///// Updates the merger fund.
        ///// </summary>
        ///// <param name="mergerFund">The merger fund.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateMergerFund(MergerFundModel mergerFund);

        ///// <summary>
        ///// Deletes the merger fund.
        ///// </summary>
        ///// <param name="mergerFundId">The merger fund identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteMergerFund(int mergerFundId);

        //#endregion

        #region BUVoucherList

        /// <summary>
        /// Checks the bu voucher list reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BUVoucherListModel GetBUVoucherListByRefNo(string refNo);

        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="includeDetail">if set to <c>true</c> [include detail].</param>
        /// <param name="includeDetailParallel">if set to <c>true</c> [include detail parallel].</param>
        /// <param name="includeDetailTransfer">if set to <c>true</c> [include detail transfer].</param>
        /// <returns>
        /// BUCommitmentRequestModel.
        /// </returns>
        BUVoucherListModel GetBUVoucherList(string refId, bool includeDetail, bool includeDetailParallel, bool includeDetailTransfer);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>
        /// List&lt;BUCommitmentRequestModel&gt;.
        /// </returns>
        IList<BUVoucherListModel> GetBUVoucherList();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// List&lt;BUCommitmentRequestModel&gt;.
        /// </returns>
        IList<BUVoucherListModel> GetBUVoucherListsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherList">The b u voucher list.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string InsertBUVoucherList(BUVoucherListModel bUVoucherList);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherList">The b u voucher list.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string UpdateBUVoucherList(BUVoucherListModel bUVoucherList);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string DeleteBUVoucherList(string refId);

        /// <summary>
        /// Gets the original general ledger not in bu voucher list detail by cash withdraw no.
        /// </summary>
        /// <param name="cashWithdrawNo">The cash withdraw no.</param>
        /// <returns></returns>
        List<BUVoucherListDetailModel> GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(
            string cashWithdrawNo);
        #endregion
        #region OriginalGeneralLedger
        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        List<OriginalGeneralLedgerModel> GetSearchVoucher(string whereClause);
        #endregion

        #region Account

        IList<AccountModel> GetAccounts();


        IList<AccountModel> GetAccountsByIsActive(bool isActive);
        IList<AccountModel> GetAccountsForComboTree(string accountId);
        IList<AccountModel> GetAccountsByIsDetail(bool isDetail);

        AccountModel GetAccount(string accountId);
        AccountModel GetAccountbyAccountNumber(string accountNumber);

        IList<UserControlMainDesktopModel> GetUserControlModel(int year);
        IList<DashBoardBudgetModel> GetDashBoardBudgetModels(int year);
        IList<DashBoardCashModel> GetDashBoardCashModels(int month, int year);
        IList<DashBoardAcitityModel> GetDashBoardAcitityModels(int year);

        string AddAuditingLog(AudittingLogModel audittingLog);

        IList<AudittingLogModel> GetAudittingLogs();

        string AddAccount(AccountModel account);


        string UpdateAccount(AccountModel account);


        string DeleteAccount(string accountId);
        string CheckExistAccountNumber(string accountId, string accountNumber);


        #endregion

        #region AccountCategory

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountCategoryModel> GetAccountCategories();

        /// <summary>
        /// Gets the account categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList{AccountCategoryModel}.</returns>
        IList<AccountCategoryModel> GetAccountCategoriesByIsActive(bool isActive);

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryModel.</returns>
        AccountCategoryModel GetAccountCategory(string accountCategoryId);

        /// <summary>
        /// Adds the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddAccountCategory(AccountCategoryModel accountCategory);

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateAccountCategory(AccountCategoryModel accountCategory);

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteAccountCategory(string accountCategoryId);

        #endregion

        #region BudgetExpense

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// IList{BudgetExpenseModel}.
        /// </returns>
        IList<BudgetExpenseModel> GetBudgetExpenses();

        /// <summary>
        /// Gets the account categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList{BudgetExpenseModel}.</returns>
        IList<BudgetExpenseModel> GetBudgetExpensesByIsActive(bool isActive);

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        /// <returns>BudgetExpenseModel.</returns>
        BudgetExpenseModel GetBudgetExpense(string budgetExpenseId);

        /// <summary>
        /// Adds the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddBudgetExpense(BudgetExpenseModel budgetExpense);

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBudgetExpense(BudgetExpenseModel budgetExpense);

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBudgetExpense(string budgetExpenseId);

        #endregion

        #region BUPlanWithdraw
        /// <summary>
        /// Gets the bu plan withdraws.
        /// </summary>
        /// <returns>List&lt;BUPlanWithdrawModel&gt;.</returns>
        IList<BUPlanWithdrawModel> GetBUPlanWithdraws();
        /// <summary>
        /// Gets the bu plan withdraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUPlanWithdrawModel.</returns>
        BUPlanWithdrawModel GetBUPlanWithdrawByRefNo(string refNo);
        /// <summary>
        /// Gets the bu plan withdraw by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawModel&gt;.</returns>
        IList<BUPlanWithdrawModel> GetBUPlanWithdrawByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the bu plan withdraw by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUPlanWithdrawDetail">if set to <c>true</c> [is included bu plan withdraw detail].</param>
        /// <returns>BUPlanWithdrawModel.</returns>
        BUPlanWithdrawModel GetBUPlanWithdrawByRefId(string refId, bool isIncludedBUPlanWithdrawDetail);
        /// <summary>
        /// Inserts the bu plan withdraw.
        /// </summary>
        /// <param name="planWithdrawEntity">The plan withdraw entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <returns>System.String.</returns>
        string InsertBUPlanWithdraw(BUPlanWithdrawModel planWithdrawModel);
        /// <summary>
        /// Updates the bu plan withdraw.
        /// </summary>
        /// <param name="planWithdrawEntity">The plan withdraw entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <returns>System.String.</returns>
        string UpdateBUPlanWithdraw(BUPlanWithdrawModel planWithdrawEModel);

        /// <summary>
        /// Deletes the bu plan withdraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUPlanWithdraw(string refId);

        /// <summary>
        /// Deletes the bu plan withdraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="deleteVoucherRef">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUPlanWithdraw(string refId, bool deleteVoucherRef);
        #endregion

        #region CAReceipt

        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>IList&lt;CAReceiptModel&gt;.</returns>
        IList<CAReceiptModel> GetCAReceipts();

        /// <summary>
        /// Gets the ca receipts by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="BUPlanWithdrawRefID">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        CAReceiptModel GetCAReceiptsByBUPlanWithdrawRefID(string BUPlanWithdrawRefID);

        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<CAReceiptModel> GetCAReceiptByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the ca receipt by reference type identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>IList&lt;CAReceiptModel&gt;.</returns>
        CAReceiptModel GetReceiptVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax);

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAReceiptModel.</returns>
        CAReceiptModel GetReceiptVoucher(string refId);

        /// <summary>
        /// Adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>CAReceiptResponse.</returns>
        string AddCAReceipt(CAReceiptModel receiptModel);

        /// <summary>
        /// Adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string AddCAReceipt(CAReceiptModel receiptModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>CAReceiptResponse.</returns>
        string UpdateCAReceipt(CAReceiptModel receiptModel);

        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateCAReceipt(CAReceiptModel receiptModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ca receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAReceiptResponse.</returns>
        string DeleteCAReceipt(string refId);
        /// <summary>
        /// Delete the ca receipt by BUPlanWithdrawRefID
        /// </summary>
        /// <param name="BUPlanWithdrawRefID"></param>
        /// <returns></returns>
        string DeleteCAReceiptByBUPlanWithdrawRefID(string BUPlanWithdrawRefID);
        #endregion

        #region BUCommitmentRequest
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUCommitmentRequestModel GetBUCommitmentRequestbyRefId(string refId);


        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUCommitmentRequestModel GetBUCommitmentRequestVoucher(string refId, bool isIncludedDetail);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUCommitmentRequestModel> GetBUCommitmentRequest();

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUCommitmentRequestModel> GetBUCommitmentRequest(string refTypeId);

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUCommitmentRequestModel> GetBUCommitmentRequestsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string InsertBUCommitmentRequest(BUCommitmentRequestModel bUCommitmentRequest);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string UpdateBUCommitmentRequest(BUCommitmentRequestModel bUCommitmentRequest);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string DeleteBUCommitmentRequest(string refId);
        #endregion

        #region BUCommitmentAdjustments
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUCommitmentAdjustmentModel GetBUCommitmentAdjustmentbyRefId(string refId);


        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUCommitmentAdjustmentModel GetBUCommitmentAdjustmentVoucher(string refId, bool isIncludedDetail);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUCommitmentAdjustmentModel> GetBUCommitmentAdjustment();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUCommitmentAdjustmentModel> GetBUCommitmentAdjustmentsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string InsertBUCommitmentAdjustment(BUCommitmentAdjustmentModel bUCommitmentAdjustment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string UpdateBUCommitmentAdjustment(BUCommitmentAdjustmentModel bUCommitmentAdjustment);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string DeleteBUCommitmentAdjustment(string refId);
        #endregion

        #region OpeningCommitment
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        OpeningCommitmentModel GetOpeningCommitmentbyRefId(string refId);


        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        OpeningCommitmentModel GetOpeningCommitmentVoucher(string refId, bool isIncludedDetail);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<OpeningCommitmentModel> GetOpeningCommitment();


        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<OpeningCommitmentModel> GetOpeningCommitmentsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string InsertOpeningCommitment(OpeningCommitmentModel openingCommitment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string UpdateOpeningCommitment(OpeningCommitmentModel openingCommitment);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningCommitment(string refId);
        #endregion

        #region OpeningSupplyEntry

        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        OpeningSupplyEntryModel GetOpeningSupplyEntrybyRefId(string refId);


        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        OpeningSupplyEntryModel GetOpeningSupplyEntryVoucher(string refId, bool isIncludedDetail);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<OpeningSupplyEntryModel> GetOpeningSupplyEntry();


        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<OpeningSupplyEntryModel> GetOpeningSupplyEntrysByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string InsertOpeningSupplyEntry(OpeningSupplyEntryModel openingCommitment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryModel> openingCommitment);
        string UpdateOpeningInventoryEntry(IList<OpeningInventoryEntryModel> openingInventoryEntries, string accountNumber);
        /// <summary>
        /// Xóa hết dòng tại số dư đầu kỳ với tài khoản 152
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        string DeleteAllRowInGridOpenInventoryEntry(string accountNumber);
        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningSupplyEntry(string refId);

        #endregion

        #region BUTransfer
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUTransferModel GetBUTransferbyRefId(string refId);

        /// <summary>
        /// Gets the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="BUPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        BUTransferModel GetBUTransferByBUPlanWithdrawRefId(string BUPlanWithdrawRefId);

        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        BUTransferModel GetBUTransferVoucher(string refId, bool isIncludedDetail);
        BUTransferModel GetBUTransferVoucherFixedAccess(string refId, bool isIncludedDetail);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUTransferModel> GetBUTransfer();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<BUTransferModel> GetBUTransfersByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string InsertBUTransfer(BUTransferModel bUTransfer, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string UpdateBUTransfer(BUTransferModel bUTransfer, bool isAutoGenerateParallel);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        string DeleteBUTransfer(string refId);

        /// <summary>
        /// Deletes the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        string DeleteBUTransferByBUPlanWithdrawRefId (string buPlanWithdrawRefId);
        #endregion

        #region INInwardOutward

        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>IList&lt;INInwardOutwardModel&gt;.</returns>
        IList<INInwardOutwardModel> GetINInwardOutwards();

        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<INInwardOutwardModel> GetINInwardOutwardByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the ca receipt by reference type identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>IList&lt;INInwardOutwardModel&gt;.</returns>
        INInwardOutwardModel GetINInwardOutward(string refId, bool isIncludedDetail,bool isIncludedDetailParaller);

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>INInwardOutwardModel.</returns>
        INInwardOutwardModel GetInwardOutwardVoucher(string refId);

        /// <summary>
        /// Adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>INInwardOutwardResponse.</returns>
        string AddINInwardOutward(INInwardOutwardModel receiptModel);

        /// <summary>
        /// adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt Model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string AddINInwardOutward(INInwardOutwardModel receiptModel, bool isAutoGenerateParallel,bool IsOutwardNegativeStock);

        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>INInwardOutwardResponse.</returns>
        string UpdateINInwardOutward(INInwardOutwardModel receiptModel);
        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt Model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateINInwardOutward(INInwardOutwardModel receiptModel, bool isAutoGenerateParallel,bool IsOutwardNegativeStock);
        /// <summary>
        /// Deletes the ca receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>INInwardOutwardResponse.</returns>
        string DeleteINInwardOutward(string refId);

        /// <summary>
        /// Checks the exist voucher.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItem">The inventory item ledger.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem);

        #endregion

        #region CAPayment

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        IList<CAPaymentModel> GetCAPayment();
        /// <summary>
        /// Gets the ca payment by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        IList<CAPaymentModel> GetCAPaymentsByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucher(string refId);

        /// <summary>
        /// Gets the payment voucher detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucherDetailPurchase(string refId);

        /// <summary>
        /// Gets the payment voucher detail fixes asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucherDetailFixesAsset(string refId);

        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax);

        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax, bool isIncludedDetailPurchase);

        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <param name="isIncludedDetailFixedAsset">if set to <c>true</c> [is included detail fixed asset].</param>
        /// <returns>CAPaymentModel.</returns>
        CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax, bool isIncludedDetailPurchase, bool isIncludedDetailFixedAsset);

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <returns>System.String.</returns>
        string InsertCAPayment(CAPaymentModel paymentModel);

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string InsertCAPayment(CAPaymentModel paymentModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <returns>System.String.</returns>
        string UpdateCAPayment(CAPaymentModel paymentModel);

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateCAPayment(CAPaymentModel paymentModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAPayment(string refId);

        #endregion

        #region GLVoucher

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        IList<GLVoucherModel> GetGLVouchers();

        /// <summary>
        /// Gets the ca payment by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        IList<GLVoucherModel> GetGLVouchersByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the gl vouchers last year by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<GLVoucherModel> GetGLVouchersLastYearByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        GLVoucherModel GetGLVoucher(string refId);

        /// <summary>
        /// Gets the payment voucher detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        GLVoucherModel GetGLVoucherDetail(string refId);

        /// <summary>
        /// Gets the payment voucher detail fixes asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        GLVoucherModel GetGLVoucherDetailTax(string refId);

        /// <summary>
        /// Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>CAPaymentModel.</returns>
        GLVoucherModel GetGLVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax);

        GLVoucherModel GetGLVoucherTranfer(int Reftype, DateTime sysDate, bool isIncludedDetailTax,string projectIds = null);

        /// <summary>
        /// Gets the bu transfer by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        GLVoucherModel GetGLVoucherByBUTransferRefId(string buTransferRefId);

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="glVoucherModel">The gl voucher model.</param>
        /// <returns>System.String.</returns>
        string InsertGLVoucher(GLVoucherModel glVoucherModel);

        /// <summary>
        /// Inserts the feature permision.
        /// </summary>
        /// <param name="featurePermision">The feature permision.</param>
        /// <returns></returns>
        string InsertFeaturePermision(FeaturePermisionModel featurePermision);

        /// <summary>
        /// Inserts the user feature permision.
        /// </summary>
        /// <param name="userFeaturePermisionModels">The user feature permision models.</param>
        /// <returns></returns>
        string InsertUserFeaturePermision(IList<UserFeaturePermisionModel> userFeaturePermisionModels);

        /// <summary>
        /// Gets the feature permisions by user profile identifier and feature identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        IList<UserFeaturePermisionModel> GetUserFeaturePermisionsByUserProfileIdAndFeatureId(string userProfileId,
            string featureId);

        /// <summary>
        /// Deletes the feature permision.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <returns></returns>
        string DeleteFeaturePermision(string Feature);

        string DeleteUserFeaturePermision(string Feature, string UserProfileID);
        /// <summary>
        /// Inserts the gl voucher.
        /// </summary>
        /// <param name="glVoucherModel">The gl voucher model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string InsertGLVoucher(GLVoucherModel glVoucherModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the gl voucher.
        /// </summary>
        /// <param name="glVoucherModel">The gl voucher model.</param>
        /// <returns>System.String.</returns>
        string UpdateGLVoucher(GLVoucherModel glVoucherModel);

        /// <summary>
        /// Updates the gl voucher.
        /// </summary>
        /// <param name="glVoucherModel">The gl voucher model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateGLVoucher(GLVoucherModel glVoucherModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteGLVoucher(string refId);

        /// <summary>
        /// Deletes the gl voucher by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        string DeleteGLVoucherByBUTransferRefId(string buTransferRefId);

        /// <summary>
        /// Gets the gl voucher list by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>GLVoucherListModel.</returns>
        GLVoucherListModel GetGLVoucherListByRefId(string refId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        GLPaymentListModel GetGLPaymentListByRefId(string refId);

        /// <summary>
        /// Gets the gl voucher list.
        /// </summary>
        /// <returns>IList&lt;GLVoucherListModel&gt;.</returns>
        IList<GLVoucherListModel> GetGlVoucherList();

        /// <summary>
        /// Gets the gl voucher list.
        /// </summary>
        /// <returns>IList&lt;GLVoucherListModel&gt;.</returns>
        IList<GLPaymentListModel> GetGlPaymentList();

        /// <summary>
        /// Gets the gl voucher list detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>GLVoucherListModel.</returns>
        GLVoucherListModel GetGLVoucherListDetail(string refId);

        /// <summary>
        /// Gls the voucher list paramater.
        /// </summary>
        /// <returns>IList&lt;GLVoucherListParamaterModel&gt;.</returns>
        IList<GLVoucherListParamaterModel> GlVoucherListParamater(int type);

        /// <summary>
        /// Inserts the gl voucher list.
        /// </summary>
        /// <param name="glVoucherList">The gl voucher list.</param>
        /// <returns>System.String.</returns>
        string InsertGLVoucherList(GLVoucherListModel glVoucherList);

        /// <summary>
        /// Inserts the gl voucher list.
        /// </summary>
        /// <param name="glVoucherList">The gl voucher list.</param>
        /// <returns>System.String.</returns>
        string InsertGLPaymentList(GLPaymentListModel glPaymentList);

        /// <summary>
        /// Ups the date gl voucher list.
        /// </summary>
        /// <param name="glVoucherList">The gl voucher list.</param>
        /// <returns>System.String.</returns>
        string UpDateGLVoucherList(GLVoucherListModel glVoucherList);
        string UpDateGLPaymentList(GLPaymentListModel glPaymentList);

        /// <summary>
        /// Deletes the gl voucher list.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteGLVoucherList(string refId);
        string DeleteGLPaymentList(string refId);

        #endregion

        #region BUPlanReceipt

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        IList<BUPlanReceiptModel> GetBUPlanReceipt();

        /// <summary>
        /// Gets the bu plan receipby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<BUPlanReceiptModel> GetBUPlanReceiptbyRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipby reference type identifier.
        /// </summary>
        /// <param name="refType">The reference type identifier.</param>
        /// <returns></returns>
        IList<BUPlanReceiptModel> GetBUPlanReceiptbyRefType(int refType);

        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAReceiptDetail">if set to <c>true</c> [is included ca receipt detail].</param>
        /// <returns></returns>
        BUPlanReceiptModel GetBUPlanReceiptVoucherByRefId(string refId, bool isIncludedCAReceiptDetail);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string InsertBUPlanReceipt(BUPlanReceiptModel buPlanReceipt);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string UpdateBUPlanReceipt(BUPlanReceiptModel buPlanReceipt);

        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBUPlanReceipt(string refId);

        #endregion

        #region BUplanAdjustment
        IList<BUPlanAdjustmentModel> GetBuPlanAdjustment();
        IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentVoucherbyRefId(string refId);
        BUPlanAdjustmentModel GetBuPlanAdjustmentbyRefId(string refId);

        IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentbyRefNo(string refNo);
        IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentbyRefTypeId(string refTypeId);
        string InsertBUPlanAdjustment(BUPlanAdjustmentModel buPlanAdjustment);


        string UpdateBUPlanAdjustment(BUPlanAdjustmentModel buPlanAdjustment);


        string DeleteBUPlanAdjustment(string refId);
        #endregion

        #region CashWithdrawType

        /// <summary>
        /// Gets the cash withdraw type model.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cash withdraw type identifier.</param>
        /// <returns></returns>
        CashWithdrawTypeModel GetCashWithdrawTypeModel(int cashWithdrawTypeId);

        /// <summary>
        /// Gets the cash withdraw type models.
        /// </summary>
        /// <returns></returns>
        IList<CashWithdrawTypeModel> GetCashWithdrawTypeModels();

        #endregion

        #region BUBudgetReserve

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        IList<BUBudgetReserveModel> GetBUBudgetReserves();

        /// <summary>
        /// Gets the bu plan receipby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<BUBudgetReserveModel> GetBUBudgetReservesByRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipby reference type identifier.
        /// </summary>
        /// <param name="refType">The reference type identifier.</param>
        /// <returns></returns>
        IList<BUBudgetReserveModel> GetBUBudgetReservesByRefType(int refType);

        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUBudgetReserveDetail">if set to <c>true</c> [is included bu budget reserve detail].</param>
        /// <returns></returns>
        BUBudgetReserveModel GetBUBudgetReserveByRefId(string refId, bool isIncludedBUBudgetReserveDetail);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        string InsertBUBudgetReserve(BUBudgetReserveModel buBudgetReserve);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        string UpdateBUBudgetReserve(BUBudgetReserveModel buBudgetReserve);

        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBUBudgetReserve(string refId);

        #endregion

        #region AutoID

        /// <summary>
        /// Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>AutoNumberModel.</returns>
        AutoIDModel GetAutoIDByRefType(int refTypeId);

        /// <summary>
        /// Gets the automatic ids.
        /// </summary>
        /// <returns>IList&lt;AutoIDModel&gt;.</returns>
        IList<AutoIDModel> GetAutoIds();

        ///// <summary>
        ///// Gets the automatic numbers.
        ///// </summary>
        ///// <returns></returns>
        //IList<AutoNumberModel> GetAutoNumbers();

        ///// <summary>
        ///// Gets the automatic numbers.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<AutoNumberModel> GetAutoNumbersByIsActive(bool isActive);

        ///// <summary>
        ///// Gets the account number.
        ///// </summary>
        ///// <param name="accountTransferId">The account transfer identifier.</param>
        ///// <returns></returns>
        //AutoNumberModel GetAccountNumber(string accountTransferId);

        ///// <summary>
        ///// Updates the automatic numbers.
        ///// </summary>
        ///// <param name="autoNumbers">The automatic numbers.</param>
        ///// <returns></returns>
        //string InsertAutoNumbers(List<AutoNumberModel> autoNumbers);

        /// <summary>
        /// Updates the automatic numbers.
        /// </summary>
        /// <param name="autoIDModels">The automatic identifier models.</param>
        /// <returns>System.String.</returns>
        string UpdateAutoNumbers(List<AutoIDModel> autoIDModels);

        ///// <summary>
        ///// Updates the automatic numbers.
        ///// </summary>
        ///// <param name="autoNumbers">The automatic numbers.</param>
        ///// <returns></returns>
        //string DeleteAutoNumbers(List<AutoNumberModel> autoNumbers);

        #endregion

        #region Department

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns>
        /// IList{DepartmentModel}.
        /// </returns>
        IList<DepartmentModel> GetDepartments();

        /// <summary>
        /// Gets the department by code.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <returns>DepartmentModel.</returns>
        DepartmentModel GetDepartmentByCode(string departmentCode);

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// DepartmentModel.
        /// </returns>
        DepartmentModel GetDepartment(string departmentId);

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertDepartment(DepartmentModel department);

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateDepartment(DepartmentModel department);

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteDepartment(string departmentId);

        #endregion

        #region EmployeeType

        /// <summary>
        /// Gets the employeeTypes.
        /// </summary>
        /// <returns>
        /// IList{EmployeeTypeModel}.
        /// </returns>
        IList<EmployeeTypeModel> GetEmployeeTypes();

        ///// <summary>
        ///// Gets the employeeTypes active.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeTypeModel}.
        ///// </returns>
        //IList<EmployeeTypeModel> GetEmployeeTypesActive();

        ///// <summary>
        ///// Gets the employeeTypes non active.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeTypeModel}.
        ///// </returns>
        //IList<EmployeeTypeModel> GetEmployeeTypesNonActive();

        /// <summary>
        /// Gets the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns>
        /// EmployeeTypeModel.
        /// </returns>
        EmployeeTypeModel GetEmployeeType(string employeeTypeId);

        /// <summary>
        /// Adds the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertEmployeeType(EmployeeTypeModel employeeType);

        /// <summary>
        /// Updates the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateEmployeeType(EmployeeTypeModel employeeType);

        /// <summary>
        /// Deletes the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteEmployeeType(string employeeTypeId);

        #endregion

        #region BudgetProvidence

        /// <summary>
        /// Gets the budgetProvidences.
        /// </summary>
        /// <returns>
        /// IList{BudgetProvidenceModel}.
        /// </returns>
        IList<BudgetProvidenceModel> GetBudgetProvidences();

        ///// <summary>
        ///// Gets the budgetProvidences active.
        ///// </summary>
        ///// <returns>
        ///// IList{BudgetProvidenceModel}.
        ///// </returns>
        //IList<BudgetProvidenceModel> GetBudgetProvidencesActive();

        ///// <summary>
        ///// Gets the budgetProvidences non active.
        ///// </summary>
        ///// <returns>
        ///// IList{BudgetProvidenceModel}.
        ///// </returns>
        //IList<BudgetProvidenceModel> GetBudgetProvidencesNonActive();

        /// <summary>
        /// Gets the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns>
        /// BudgetProvidenceModel.
        /// </returns>
        BudgetProvidenceModel GetBudgetProvidence(string budgetProvidenceId);

        /// <summary>
        /// Adds the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertBudgetProvidence(BudgetProvidenceModel budgetProvidence);

        /// <summary>
        /// Updates the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBudgetProvidence(BudgetProvidenceModel budgetProvidence);

        /// <summary>
        /// Deletes the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBudgetProvidence(string budgetProvidenceId);

        #endregion

        #region BudgetItem

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItems();

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsByIsActive(bool isActive);

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <returns></returns>
        BudgetItemModel GetBudgetItemByCode(string budgetItemCode);

        /// <summary>
        /// Gets the budget items by group.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByGroup();

        /// <summary>
        /// Gets the budget items by group item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByGroupItem();

        /// <summary>
        /// Gets the budget items by kind item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByKindItem();

        /// <summary>
        /// Gets the budget items by item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByItem();

        /// <summary>
        /// Gets the budget items by receipt.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByReceipt();

        /// <summary>
        /// Gets the budget items capital allocate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsCapitalAllocate();

        /// <summary>
        /// Gets the budget items pay voucher.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsPayVoucher();

        /// <summary>
        /// Gets the budget items by receipt for estimate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsByReceiptForEstimate();

        /// <summary>
        /// Gets the budget items by payment.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByPayment();

        /// <summary>
        /// Gets the budget items by payment for estimate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsByPaymentForEstimate();

        /// <summary>
        /// Gets the budget item and sub item.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemAndSubItem(int budgetItemType, bool isActive);

        /// <summary>
        /// Gets the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        /// BudgetItemModel.
        /// </returns>
        BudgetItemModel GetBudgetItem(string budgetItemId);

        /// <summary>
        /// Adds the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddBudgetItem(BudgetItemModel budgetItem);

        /// <summary>
        /// Updates the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBudgetItem(BudgetItemModel budgetItem);

        /// <summary>
        /// Deletes the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBudgetItem(string budgetItemId);

        #endregion
        #region BudgetGroupItem

        /// <summary>
        /// Gets the budget group items.
        /// </summary>
        /// <returns></returns>
        IList<BudgetGroupItemModel> GetBudgetGroupItems();

        #endregion
        #region BudgetKindItem

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>
        /// IList{BudgetKindItemModel}.
        /// </returns>
        IList<BudgetKindItemModel> GetBudgetKindItems();

        /// <summary>
        /// Gets the budget items by receipt.
        /// </summary>
        /// <returns>
        /// IList{BudgetKindItemModel}.
        /// </returns>
        IList<BudgetKindItemModel> GetBudgetKindItemsByActive();

        /// <summary>
        /// Gets the budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        /// BudgetKindItemModel.
        /// </returns>
        BudgetKindItemModel GetBudgetKindItem(string budgetKindItemId);

        /// <summary>
        /// Adds the budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddBudgetKindItem(BudgetKindItemModel budgetKindItem);

        /// <summary>
        /// Updates the budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBudgetKindItem(BudgetKindItemModel budgetKindItem);

        /// <summary>
        /// Deletes the budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBudgetKindItem(string budgetKindItemId);

        #endregion

        //#region FixedAssetCategory

        ///// <summary>
        ///// Gets the fixed asset category.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        IList<FixedAssetCategoryModel> GetFixedAssetCategories();

        //IList<FixedAssetCategoryModel> GetFixedAssetCategoriesComboCheck();

        ///// <summary>
        ///// Gets the fixed asset categorys for combo tree.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        IList<FixedAssetCategoryModel> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId);

        ///// <summary>
        ///// Gets the fixed asset categorys active.
        ///// </summary>
        ///// <returns> 
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        //IList<FixedAssetCategoryModel> GetFixedAssetCategoriesActive();

        ///// <summary>
        ///// Gets the fixed asset category by identifier.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// FixedAssetCategoryModel.
        ///// </returns>
        FixedAssetCategoryModel GetFixedAssetCategoryById(string fixedAssetCategoryId);

        /// <summary>
        /// Gets the features.
        /// </summary>
        /// <returns></returns>
        IList<FeaturesModel> GetFeatures();

        /// <summary>
        /// Gets the feature entities is parent.
        /// </summary>
        /// <returns></returns>
        IList<FeaturesModel> GetFeaturesIsParent();

        /// <summary>
        /// Gets the user permisions.
        /// </summary>
        /// <returns></returns>
        IList<UserPermisionModel> GetUserPermisions();

        /// <summary>
        /// Inserts the features.
        /// </summary>
        /// <param name="features">The features.</param>
        /// <returns></returns>
        string InsertFeatures(IList<FeaturesModel> features);

        IList<UserPermisionModel> GetUserPermisionsByFeature(string Feature, string UserProfileID);

        ///// <summary> 
        ///// Adds the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string InsertFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory);

        ///// <summary>
        ///// Updates the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string UpdateFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory);

        ///// <summary>
        ///// Deletes the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string DeleteFixedAssetCategory(string fixedAssetCategoryId);

        //#endregion

        #region FixedAsset

        ///// <summary>
        ///// Gets the fixed asset.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetModel}.
        ///// </returns>
        IList<FixedAssetModel> GetFixedAssets();

        ///// <summary>
        ///// Gets the fixed assets active.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns>
        ///// IList{FixedAssetModel}.
        ///// </returns>
        IList<FixedAssetModel> GetFixedAssetsActive(bool isActive);
        IList<FixedAssetModel> GetFixedAssetsActiveDecre(bool isActive,string refId);

        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<FixedAssetModel> GetFixedAssetsForDecrement(bool isActive, DateTime refDate);

        /// <summary>
        /// Gets the fixed assets for adjustment.
        /// </summary>
        /// <param name="FixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        IList<FixedAssetModel> GetFixedAssetsForAdjustment(string FixedAssetId, DateTime postedDate, int refType,   bool isForceGetOnLedger);

        /// <summary>
        /// Gets the fixed assets by increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        IList<FixedAssetModel> GetFixedAssetsByIncrement(string fixedAssetId);

        ///// <summary>
        ///// Gets the fixed assets active with fixed asset currency.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<FixedAssetModel> GetFixedAssetsActiveWithFixedAssetCurrency(bool isActive);

        ///// <summary>
        ///// Gets all fixed assets with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <returns>
        ///// IList{FixedAssetModel}.
        ///// </returns>
        //IList<FixedAssetModel> GetAllFixedAssetsWithStoreProdure(string storeProdure);

        ///// <summary>
        ///// Gets the fixed asset by identifier.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns>
        ///// FixedAssetModel.
        ///// </returns>
        FixedAssetModel GetFixedAssetById(string fixedAssetId);

        ///// <summary>
        ///// Gets the fixed asset by identifier.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns>
        ///// FixedAssetModel.
        ///// </returns>
        //FixedAssetModel GetFixedAssetRemainingQuantity(int fixedAssetId);


        ///// <summary>
        ///// Gets the fixed asset by fa increment.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetByFaIncrement(int fixedAssetId);

        ///// <summary>
        ///// Gets the fixed asset by fa decrement.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, int refTypeId);

        ///// <summary>
        ///// Gets the fixed asset by fa decrement.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetByFaOpening(int fixedAssetId);

        ///// <summary>
        ///// Gets the fixed asset by fa decrement.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="postedDate">The posted date.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, string postedDate);

        ///// <summary>
        ///// Gets the fixed asset by fa decrement quantity.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, int refTypeId);

        ///// <summary>
        ///// Adds the fixed asset.
        ///// </summary>
        ///// <param name="fixedAsset">The fixed asset.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string AddFixedAsset(FixedAssetModel fixedAsset);

        ///// <summary>
        ///// Updates the fixed asset.
        ///// </summary>
        ///// <param name="fixedAsset">The fixed asset.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string UpdateFixedAsset(FixedAssetModel fixedAsset, DateTime systemDate);

        ///// <summary>
        ///// Adds the fixed asset.
        ///// </summary>
        ///// <param name="fixedAsset">The fixed asset.</param>
        ///// <param name="replication">The replication.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddFixedAssetReplication(FixedAssetModel fixedAsset, int replication);

        ///// <summary>
        ///// Updates the fixed asset.
        ///// </summary>
        ///// <param name="fixedAsset">The fixed asset.</param>
        ///// <param name="replication">The replication.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateFixedAssetReplication(FixedAssetModel fixedAsset, int replication);
        ///// <summary>
        ///// Deletes the fixed asset.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        string DeleteFixedAsset(string fixedAssetId, DateTime systemDate);

        #endregion

        //#region PayItem

        ///// <summary>
        ///// Gets the pay items.
        ///// </summary>
        ///// <returns>
        ///// IList{PayItemModel}.
        ///// </returns>
        //IList<PayItemModel> GetPayItems();

        ///// <summary>
        ///// Gets the pay items active.
        ///// </summary>
        ///// <returns>
        ///// IList{PayItemModel}.
        ///// </returns>
        //IList<PayItemModel> GetPayItemsActive();




        ///// <summary>
        ///// Gets the pay item.
        ///// </summary>
        ///// <param name="payItemId">The pay item identifier.</param>
        ///// <returns>
        ///// PayItemModel.
        ///// </returns>
        //PayItemModel GetPayItem(int payItemId);

        ///// <summary>
        ///// Adds the pay item.
        ///// </summary>
        ///// <param name="payItem">The pay item.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddPayItem(PayItemModel payItem);

        ///// <summary>
        ///// Updates the pay item.
        ///// </summary>
        ///// <param name="payItem">The pay item.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdatePayItem(PayItemModel payItem);

        ///// <summary>
        ///// Deletes the pay item.
        ///// </summary>
        ///// <param name="payItemId">The pay item identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeletePayItem(int payItemId);

        //#endregion

        //#region Customer

        ///// <summary>
        ///// Gets the customer.
        ///// </summary>
        ///// <param name="customerId">The customer identifier.</param>
        ///// <returns>
        ///// CustomerModel.
        ///// </returns>
        //CustomerModel GetCustomer(int customerId);

        ///// <summary>
        ///// Getses this instance.
        ///// </summary>
        ///// <returns>
        ///// List{CustomerModel}.
        ///// </returns>
        //List<CustomerModel> GetCustomers();

        ///// <summary>
        ///// Gets the by actives.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns>
        ///// List{CustomerModel}.
        ///// </returns>
        //List<CustomerModel> GetCustomersByActive(bool isActive);

        ///// <summary>
        ///// Inserts the specified customer.
        ///// </summary>
        ///// <param name="customer">The customer.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int InsertCustomer(CustomerModel customer);

        ///// <summary>
        ///// Updates the specified customer.
        ///// </summary>
        ///// <param name="customer">The customer.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateCustomer(CustomerModel customer);

        ///// <summary>
        ///// Deletes the customer.
        ///// </summary>
        ///// <param name="customerId">The customer identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteCustomer(int customerId);
        //#endregion

        //#region Vendor
        ///// <summary>
        ///// Gets the vendor.
        ///// </summary>
        ///// <param name="vendorId">The vendor identifier.</param>
        ///// <returns>
        ///// VendorModel.
        ///// </returns>
        //VendorModel GetVendor(int vendorId);

        ///// <summary>
        ///// Getses this instance.
        ///// </summary>
        ///// <returns>
        ///// List{VendorModel}.
        ///// </returns>
        //List<VendorModel> GetVendors();

        ///// <summary>
        ///// Gets the vendors by active.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //List<VendorModel> GetVendorsByActive(bool isActive);

        ///// <summary>
        ///// Inserts the specified vendor.
        ///// </summary>
        ///// <param name="vendor">The vendor.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int InsertVendor(VendorModel vendor);

        ///// <summary>
        ///// Updates the specified vendor.
        ///// </summary>
        ///// <param name="vendor">The vendor.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateVendor(VendorModel vendor);

        ///// <summary>
        ///// Deletes the specified object.
        ///// </summary>
        ///// <param name="vendorId">The vendor identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteVendor(int vendorId);

        //#endregion

        #region AccountingObjectCategory
        IList<AccountingObjectCategoryModel> GetAccountingObjectCategories();
        #endregion

        #region AccountingObject
        /// <summary>
        /// Gets the account categories.
        /// </summary>  
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountingObjectModel> GetAccountingObjects();

        /// <summary>
        /// Gets the account categories active.
        /// </summary>s
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountingObjectModel> GetAccountingObjectsByIsActive(bool isActive);

        /// <summary>
        /// Gets the accounting objects by is employee.
        /// </summary>
        /// <retusrns></returns>
        IList<AccountingObjectModel> GetAccountingObjectsByIsEmployee(bool isEmployee);

        IList<AccountingObjectModel> GetAccountingObjectsByDepartment(string departmentid);

        /// <summary>
        /// Gets the accounting objects by is customer vendor.
        /// </summary>
        /// <param name="isCustomerVendor">if set to <c>true</c> [is customer vendor].</param>
        /// <returns></returns>
        IList<AccountingObjectModel> GetAccountingObjectsByIsCustomerVendor(bool isCustomerVendor);
        /// <summary>
        /// Gets the accounting objects by accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        /// <returns></returns>
        IList<AccountingObjectModel> GetAccountingObjectsByAccountingObjectCategoryId(string accountingObjectCategoryId);

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns>
        /// AccountCategoryModel.
        /// </returns>
        AccountingObjectModel GetAccountingObject(string accountingObjectId);

        /// <summary>
        /// Adds the account category.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddAccountingObject(AccountingObjectModel accountingObject);

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateAccountingObject(AccountingObjectModel accountingObject);

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteAccountingObject(string accountingObjectId);

        #endregion

        #region VoucherList

        /// <summary>
        /// Gets the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        /// VoucherListModel.
        /// </returns>
        VoucherListModel GetVoucherList(string voucherListId);

        /// <summary>
        /// Gets the voucher lists.
        /// </summary>
        /// <returns>
        /// IList{VoucherListModel}.
        /// </returns>
        IList<VoucherListModel> GetVoucherLists();

        /// <summary>
        /// Gets the voucher lists by active.
        /// </summary>
        /// <returns></returns>
        IList<VoucherListModel> GetVoucherListsByActive();

        /// <summary>
        /// Inserts the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertVoucherList(VoucherListModel voucherList);

        /// <summary>
        /// Updates the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateVoucherList(VoucherListModel voucherList);

        /// <summary>
        /// Deletes the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteVoucherList(string voucherListId);
        #endregion

        #region InvoiceFormNumber

        /// <summary>
        /// Gets the voucher list.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        /// VoucherListModel.
        /// </returns>
        InvoiceFormNumberModel GetInvoiceFormNumber(string invoiceFormNumberId);

        /// <summary>
        /// Gets the voucher lists.
        /// </summary>
        /// <returns>
        /// IList{VoucherListModel}.
        /// </returns>
        IList<InvoiceFormNumberModel> GetInvoiceFormNumbers();

        /// <summary>
        /// Gets the voucher lists by active.
        /// </summary>
        /// <returns></returns>
        IList<InvoiceFormNumberModel> GetInvoiceFormNumbersByActive();

        /// <summary>
        /// Inserts the specified voucher list.
        /// </summary>
        /// <param name="invoiceFormNumber">The invoice form number.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertInvoiceFormNumber(InvoiceFormNumberModel invoiceFormNumber);

        /// <summary>
        /// Updates the specified voucher list.
        /// </summary>
        /// <param name="invoiceFormNumber">The invoice form number.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateInvoiceFormNumber(InvoiceFormNumberModel invoiceFormNumber);

        /// <summary>
        /// Deletes the voucher list.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteInvoiceFormNumber(string invoiceFormNumberId);
        #endregion

        #region InvoiceFormNumber
        /// <summary>
        /// Gets the invoice form numbers.
        /// </summary>
        /// <returns></returns>
        IList<InvoiceTypeModel> GetInvoiceTypies();
        #endregion

        //#region Employee

        ///// <summary>
        ///// Gets the employees.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeModel}.
        ///// </returns>
        //IList<EmployeeModel> GetEmployees();

        ///// <summary>
        ///// Gets the employees by department identifier.
        ///// </summary>
        ///// <param name="departmentId">The department identifier.</param>
        ///// <returns>
        ///// IList{EmployeeModel}.
        ///// </returns>
        //IList<EmployeeModel> GetEmployeesByDepartmentId(int departmentId);

        ///// <summary>
        ///// Gets the active employees by department identifier.
        ///// </summary>
        ///// <param na

        /// me="departmentId">The department identifier.
        ///// <returns></returns>
        //IList<EmployeeModel> GetActiveEmployeesByDepartmentId(int departmentId);

        ///// <summary>
        ///// Gets the employees by department identifier.
        ///// </summary>
        ///// <param name="refdate">The refdate.</param>
        ///// <returns></returns>
        //IList<EmployeeModel> GetEmployeesByRefdateSalary(DateTime refdate);

        ///// <summary>
        ///// Gets the employees by department identifier.
        ///// </summary>
        ///// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        ///// <param name="departmentId">The department identifier.</param>
        ///// <returns></returns>
        //IList<EmployeeModel> GetEmployeesByDepartmentId(bool isListDepartment, string departmentId);

        ////ThangNK Add 
        //IList<EmployeeModel> GetEmployeesByDepartmentIdAndMonth(bool isListDepartment, string departmentId, string strDate, int salaryOptionType, int salaryCalcType);
        //IList<EmployeeModel> GetEmployeesByMonthDateAndRefNo(string strDate, string refNo);

        ///// <summary>
        ///// Gets the employees active.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeModel}.
        ///// </returns>
        //IList<EmployeeModel> GetEmployeesActive();

        ///// <summary>
        ///// Gets the employee.
        ///// </summary>
        ///// <param name="employeeId">The employee identifier.</param>
        ///// <returns>
        ///// EmployeeModel.
        ///// </returns>
        //EmployeeModel GetEmployee(int employeeId);

        ///// <summary>
        ///// Gets the employee for edit.
        ///// </summary>
        ///// <param name="employeeId">The employee identifier.</param>
        ///// <returns></returns>
        //EmployeeModel GetEmployeeForEdit(int employeeId);

        ///// <summary>
        ///// Gets the employee for view salary.
        ///// </summary>
        ///// <param name="employeeId">The employee identifier.</param>
        ///// <param name="refDate">The reference date.</param>
        ///// <returns></returns>
        //EmployeeModel GetEmployeeForViewSalary(int employeeId, DateTime refDate);


        ///// <summary>
        ///// Adds the employee.
        ///// </summary>
        ///// <param name="employee">The employee.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddEmployee(EmployeeModel employee);

        ///// <summary>
        ///// Updates the employee.
        ///// </summary>
        ///// <param name="employee">The employee.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateEmployee(EmployeeModel employee);

        ///// <summary>
        ///// Deletes the employee.
        ///// </summary>
        ///// <param name="employeeId">The employee identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteEmployee(int employeeId);


        //IList<EmployeeModel> GetEmployeesIsRetail(string monthDate, bool isRetail);

        //#endregion

        //#region PlanTemplateList

        ///// <summary>
        ///// Gets the plan template lists.
        ///// </summary>
        ///// <returns>
        ///// IList{PlanTemplateListModel}.
        ///// </returns>
        //IList<PlanTemplateListModel> GetPlanTemplateLists();

        ///// <summary>
        ///// Gets the plan template lists by receipt.
        ///// </summary>
        ///// <returns>
        ///// IList{PlanTemplateListModel}.
        ///// </returns>
        //IList<PlanTemplateListModel> GetPlanTemplateListsByReceipt();

        ///// <summary>
        ///// Gets the plan template lists by payment.
        ///// </summary>
        ///// <returns>
        ///// IList{PlanTemplateListModel}.
        ///// </returns>
        //IList<PlanTemplateListModel> GetPlanTemplateListsByPayment();

        ///// <summary>
        ///// Gets the plan template list.
        ///// </summary>
        ///// <param name="planTemplateListId">The plan template list identifier.</param>
        ///// <returns>
        ///// PlanTemplateListModel.
        ///// </returns>
        //PlanTemplateListModel GetPlanTemplateList(int planTemplateListId);

        ///// <summary>
        ///// Adds the plan template list.
        ///// </summary>
        ///// <param name="planTemplateList">The plan template list.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddPlanTemplateList(PlanTemplateListModel planTemplateList);

        ///// <summary>
        ///// Updates the plan template list.
        ///// </summary>
        ///// <param name="planTemplateList">The plan template list.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdatePlanTemplateList(PlanTemplateListModel planTemplateList);

        ///// <summary>
        ///// Deletes the plan template list.
        ///// </summary>
        ///// <param name="planTemplateListId">The plan template list identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeletePlanTemplateList(int planTemplateListId);

        ///// <summary>
        ///// LinhMC add
        ///// Checks the constraint plan template list.
        ///// </summary>
        ///// <param name="planTemplateListId">The plan template list identifier.</param>
        ///// <returns></returns>
        //bool CheckConstraintPlanTemplateList(int planTemplateListId);

        //#endregion

        //#region PlanTemplateItem

        ///// <summary>
        ///// Gets the plan template items.
        ///// </summary>
        ///// <returns>
        ///// IList{PlanTemplateItemModel}.
        ///// </returns>
        //IList<PlanTemplateItemModel> GetPlanTemplateItems();

        ///// <summary>
        ///// Gets the plan template items.
        ///// </summary>
        ///// <param name="planTemplateListId">The plan template list identifier.</param>
        ///// <returns>
        ///// IList{PlanTemplateItemModel}.
        ///// </returns>
        //IList<PlanTemplateItemModel> GetPlanTemplateItemsByPlanTemplateListId(int planTemplateListId);

        ///// <summary>
        ///// Gets the plan template items.
        ///// </summary>
        ///// <param name="planTemplateListId">The plan template list identifier.</param>
        ///// <param name="planYear">The plan template list identifier.</param>
        ///// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        ///// <returns>IList{PlanTemplateItemModel}.</returns>
        //IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId);

        //IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId, int option);

        //#endregion

        #region Stock

        /// <summary>
        /// Gets the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>StockModel.</returns>
        StockModel GetStock(string stockId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// IList{StockModel}.
        /// </returns>
        IList<StockModel> GetStocks();

        /// <summary>
        /// Gets the stocks by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;StockModel&gt;.</returns>
        IList<StockModel> GetStocksByIsActive(bool isActive);

        /// <summary>
        /// Inserts the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertStock(StockModel stock);

        /// <summary>
        /// Updates the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateStock(StockModel stock);

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteStock(string stockId);

        #endregion

        #region PurchasePurpose

        /// <summary>
        /// Gets the specified purchasePurpose identifier.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns>PurchasePurposeModel.</returns>
        PurchasePurposeModel GetPurchasePurpose(string purchasePurposeId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// IList{PurchasePurposeModel}.
        /// </returns>
        IList<PurchasePurposeModel> GetPurchasePurposes();

        /// <summary>
        /// Gets the purchasePurposes by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;PurchasePurposeModel&gt;.</returns>
        IList<PurchasePurposeModel> GetPurchasePurposesByIsActive(bool isActive);

        /// <summary>
        /// Inserts the specified purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertPurchasePurpose(PurchasePurposeModel purchasePurpose);

        /// <summary>
        /// Updates the specified purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdatePurchasePurpose(PurchasePurposeModel purchasePurpose);

        /// <summary>
        /// Deletes the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeletePurchasePurpose(string purchasePurposeId);

        /// <summary>
        /// Gets the purchase purpose model by code.
        /// </summary>
        /// <param name="purchasePurposeCode">The purchase purpose code.</param>
        /// <returns></returns>
        PurchasePurposeModel GetPurchasePurposeByCode(string purchasePurposeCode);

        #endregion

        #region  InventoryItem

        /// <summary>
        /// Gets the inventory items by stock.
        /// </summary>
        /// <returns>IList&lt;InventoryItemModel&gt;.</returns>
        IList<InventoryItemModel> GetInventoryItems();

        /// <summary>
        /// Gets the inventory items by is ative.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItemsByIsAtive(bool isActive);

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>IList&lt;InventoryItemModel&gt;.</returns>
        IList<InventoryItemModel> GetInventoryItemsByIsTool(bool isTool);

        /// <summary>
        /// Gets the inventory items by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItemsByIsToolAndIsActive(bool isTool, bool isActive);
        IList<InventoryItemModel> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode);

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// InventoryItemModel.
        /// </returns>
        InventoryItemModel GetInventoryItem(string inventoryItemId);

        /// <summary>
        /// Inserts the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertInventoryItem(InventoryItemModel inventoryItem);

        /// <summary>
        /// Updates the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateInventoryItem(InventoryItemModel inventoryItem);

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string Delete(string inventoryItemId);

        /// <summary>
        /// Gets the inventory items by inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItemsByInventoryCategoryCode(string inventoryCategoryCode);

        IList<InventoryItemdestinationModel> GetInventoryItemsByInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber);

        /// <summary>
        /// Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        InventoryItemModel GetUnitsInStock(string inventoryItemId, string stockId, DateTime Todate);

        string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId);
        #endregion

        #region  InventoryItemCategory

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>IList&lt;InventoryItemModel&gt;.</returns>
        IList<InventoryItemCategoryModel> GetInventoryItemCategoriesByIsTool(bool isTool);

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;InventoryItemCategoryModel&gt;.</returns>
        IList<InventoryItemCategoryModel> GetInventoryItemCategoriesByIsTool(bool isTool, bool isActive);
        IList<InventoryItemCategoryModel> GetInventoryItemCategories(bool isActive);

        #endregion

        #region Bank

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetBanks();

        /// <summary>
        /// Gets the banks active.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetBanksActive(bool isActive);

        /// <summary>
        /// Gets the banks of project.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetProjectBank(string projectId);
        

        /// <summary>
        /// Gets the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        /// BankModel.
        /// </returns>
        BankModel GetBank(string bankId);

        /// <summary>
        /// Adds the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddBank(BankModel bank);

        /// <summary>
        /// Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateBank(BankModel bank);

        /// <summary>
        /// Deletes the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteBank(string bankId);

        #endregion

        #region Activity
        IList<ActivityModel> GetActivitys();
        IList<ActivityModel> GetActivitysActive(bool isActive);
        ActivityModel GetActivity(string activityId);
        string AddActivity(ActivityModel activity);
        string UpdateActivity(ActivityModel activity);
        string DeleteActivity(string activityId);
        #endregion

        #region AccountTransfer

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns>
        /// IList{AccountTransferModel}.
        /// </returns>
        IList<AccountTransferModel> GetAccountTransfers();

        /// <summary>
        /// Gets the account tranfers active.
        /// </summary>
        /// <returns>
        /// IList{AccountTransferModel}.
        /// </returns>
        IList<AccountTransferModel> GetAccountTransfersActive();

        /// <summary>
        /// Gets the account tranfers non active.
        /// </summary>
        /// <returns>
        /// IList{AccountTransferModel}.
        /// </returns>
        IList<AccountTransferModel> GetAccountTransfersNonActive();

        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <returns>
        /// AccountTransferModel.
        /// </returns>
        AccountTransferModel GetAccountTransfer(string accountTransferId);

        /// <summary>
        /// Adds the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account transfer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddAccountTransfer(AccountTransferModel accountTransfer);

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account transfer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateAccountTransfer(AccountTransferModel accountTransfer);

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteAccountTransfer(string accountTransferId);

        #endregion

        #region DBOption

        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <returns></returns>
        DBOptionModel GetDBOption(string optionId);

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptions();

        /// <summary>
        /// Gets the database options system.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsSystem();

        /// <summary>
        /// Gets the database options is string.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsString();

        /// <summary>
        /// Gets the database options is numeric.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsNumeric();

        /// <summary>
        /// Gets the database options is boolean.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsBoolean();

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dbOption">The database option.</param>
        /// <returns>System.String.</returns>
        string UpdateDBOption(DBOptionModel dbOption);

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dbOptions">The database options.</param>
        /// <returns></returns>
        string UpdateDBOption(List<DBOptionModel> dbOptions);

        #endregion



        #region Report List
        ReportListModel GetReportListByReportId(string reportId);

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns>
        /// List{ReportListModel}.
        /// </returns>
        List<ReportListModel> GetReportListsByIsActive(bool isActive,string loginName);

        /// <summary>
        /// Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListModel&gt;.</returns>
        List<ReportListModel> GetReportsByRefType(int refType);

        List<ReportListModel> GetReportListsByParentId(string parentId);

        #endregion

        #region SUIncrementDecrement

        /// <summary>
        /// Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>
        /// IList{SUIncrementDecrementModel}.
        /// </returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrements();

        /// <summary>
        /// Gets the sUIncrementDecrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{SUIncrementDecrementModel}.
        /// </returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUIncrementDecrementModel GetSUIncrementDecrement(string refId, bool hasDetail);
        FAAdjustmentModel GetFAAdjustmentByRefId(string refId);
        FAAdjustmentModel GetFAAdjustmentByRefId(string refId, bool hasDetail, bool hasDetailParallel);
        /// <summary>
        /// Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUIncrementDecrementModel GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail);

        /// <summary>
        /// Adds the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string AddSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement);

        /// <summary>
        /// Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string UpdateSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteSUIncrementDecrement(string refId);

        #endregion

        #region FAIncrementDecrement

        /// <summary>
        /// Gets the fAIncrementDecrements.
        /// </summary>
        /// <returns>
        /// IList{FAIncrementDecrementModel}.
        /// </returns>
        IList<FAIncrementDecrementModel> GetFAIncrementDecrements();

        IList<FAAdjustmentModel> GetFAAdjustments();
        /// <summary>
 
        /// <returns></returns>
        FAIncrementDecrementModel GetFAIncrementDecrementByRefNo(string refNo, bool hasDetail);

        /// <summary>
        /// Adds the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string AddFAIncrementDecrement(FAIncrementDecrementModel fAIncrementDecrement);

        string AddFAAdjustment(FAAdjustmentModel fAAdjustmentModel, bool isAutoGenerateParallel);
        string UpdateFAAdjustment(FAAdjustmentModel fAAdjustmentModel, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string UpdateFAIncrementDecrement(FAIncrementDecrementModel fAIncrementDecrement);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>


        #endregion

        #region SUTransfer

        /// <summary>
        /// Gets the SUTransfers.
        /// </summary>
        /// <returns>
        /// IList{SUTransferModel}.
        /// </returns>
        IList<SUTransferModel> GetSUTransfers();

        /// <summary>
        /// Gets the SUTransfers by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<SUTransferModel> GetSUTransfersByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the SUTransfers by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{SUTransferModel}.
        /// </returns>
        IList<SUTransferModel> GetSUTransfersByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUTransferModel GetSUTransfer(string refId, bool hasDetail);


        /// <summary>
        /// Gets the SUTransfer.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUTransferModel GetSUTransferByRefNo(string refNo, bool hasDetail);

        /// <summary>
        /// Adds the SUTransfer.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string AddSUTransfer(SUTransferModel suTransfer);

        /// <summary>
        /// Updates the SUTransfer.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string UpdateSUTransfer(SUTransferModel suTransfer);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteSUTransfer(string refId);

        #endregion

        #region FADepreciation

        /// <summary>
        /// Gets the FADepreciations.
        /// </summary>
        /// <returns>
        /// IList{FADepreciationModel}.
        /// </returns>
        IList<FADepreciationModel> GetFADepreciations();

        /// <summary>
        /// Gets the FADepreciations by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<FADepreciationModel> GetFADepreciationsByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the fa depreciations by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        IList<FADepreciationModel> GetFADepreciationsByRefDateAndPeriodType(int refTypeId, DateTime refDate, int periodType);

        /// <summary>
        /// Gets the FADepreciations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{FADepreciationModel}.
        /// </returns>
        IList<FADepreciationModel> GetFADepreciationsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        FADepreciationModel GetFADepreciation(string refId, bool hasDetail);

        /// <summary>
        /// Gets the fa devaluation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        FADepreciationModel GetFADevaluation(string refId, bool hasDetail);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">if set to <c>true</c> [has detail].</param>
        /// /// <param name="toDate">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        FADepreciationModel GetFADepreciation(string refId, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        FADepreciationModel GetFADepreciation(string refId, DateTime fromDate, DateTime toDate, int periodType);

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        IList<FADepreciationModel> GetFADevaluations(int refTypeId, DateTime refDate, int periodType);

        /// <summary>
        /// Gets the FADepreciation.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        FADepreciationModel GetFADepreciationByRefNo(string refNo, bool hasDetail);

        /// <summary>
        /// Adds the FADepreciation.
        /// </summary>
        /// <param name="faDepreciation">The fa depreciation.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string AddFADepreciation(FADepreciationModel faDepreciation);

        /// <summary>
        /// Updates the FADepreciation.
        /// </summary>
        /// <param name="faDepreciation">The fa depreciation.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string UpdateFADepreciation(FADepreciationModel faDepreciation);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteFADepreciation(string refId);

        #endregion

        #region BADeposit

        /// <summary>
        /// Gets the bADeposits.
        /// </summary>
        /// <returns>
        /// IList{BADepositModel}.
        /// </returns>
        IList<BADepositModel> GetBADeposits();

        /// <summary>
        /// Gets the bADeposits by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<BADepositModel> GetBADepositsByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the bADeposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{BADepositModel}.
        /// </returns>
        IList<BADepositModel> GetBADepositsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasSale">if set to <c>true</c> [has sale].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        BADepositModel GetBADeposit(string refId, bool hasDetail, bool hasFixedAsset, bool hasSale, bool hasTax);

        /// <summary>
        /// Gets the ba deposit for salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        BADepositModel GetBADepositForSalary(DateTime dateMonth);

        /// <summary>
        /// Adds the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string AddBADeposit(BADepositModel bADeposit);

        /// <summary>
        /// Adds the ba deposit.
        /// </summary>
        /// <param name="bADeposit">The b a deposit.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string AddBADeposit(BADepositModel bADeposit, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        string UpdateBADeposit(BADepositModel bADeposit);

        /// <summary>
        /// Updates the ba deposit.
        /// </summary>
        /// <param name="bADeposit">The b a deposit.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateBADeposit(BADepositModel bADeposit, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBADeposit(string refId);

        #endregion

        #region BAWithDraw

        /// <summary>
        /// Gets the bADeposits.
        /// </summary>
        /// <returns>
        /// IList{BAWithDrawModel}.
        /// </returns>
        IList<BAWithDrawModel> GetBAWithDraws();

        /// <summary>
        /// Gets the bADeposits by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<BAWithDrawModel> GetBAWithDrawsByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the bADeposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{BAWithDrawModel}.
        /// </returns>
        IList<BAWithDrawModel> GetBAWithDrawsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        BAWithDrawModel GetBAWithDraw(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax);
        BAWithDrawModel GetBAWithDrawFixedAccess(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax);
        /// <summary>
        /// Gets the ba deposit for salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        BAWithDrawModel GetBAWithDrawForSalary(DateTime dateMonth);

        /// <summary>
        /// Gets the bADeposit.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        BAWithDrawModel GetBAWithDrawByRefNo(string refNo, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax);

        /// <summary>
        /// Adds the bADeposit.
        /// </summary>
        /// <param name="withDraw">The with draw.</param>
        /// <returns>System.Int64.</returns>
        string AddBAWithDraw(BAWithDrawModel withDraw);

        /// <summary>
        /// Adds the ba with draw.
        /// </summary>
        /// <param name="withDraw">The with draw.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string AddBAWithDraw(BAWithDrawModel withDraw, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the bADeposit.
        /// </summary>
        /// <param name="withDraw">The with draw.</param>
        /// <returns>System.Int64.</returns>
        string UpdateBAWithDraw(BAWithDrawModel withDraw);

        /// <summary>
        /// Updates the ba with draw.
        /// </summary>
        /// <param name="withDraw">The with draw.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateBAWithDraw(BAWithDrawModel withDraw, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBAWithDraw(string refId);

        #endregion

        #region BABankTransfer
        /// <summary>
        /// Gets the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        BABankTransferModel GetBABankTransfer(string refId);

        /// <summary>
        /// Gets the ba bank transfers.
        /// </summary>
        /// <returns></returns>
        IList<BABankTransferModel> GetBABankTransfers();

        /// <summary>
        /// Gets the ba bank transfer by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BABankTransferModel GetBABankTransferByRefNo(string refNo);

        /// <summary>
        /// Inserts the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <returns></returns>
        string InsertBABankTransfer(BABankTransferModel bABankTransfer);

        /// <summary>
        /// Inserts the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string InsertBABankTransfer(BABankTransferModel bABankTransfer, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <returns>System.String.</returns>
        string UpdateBABankTransfer(BABankTransferModel bABankTransfer);

        /// <summary>
        /// Updates the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        string UpdateBABankTransfer(BABankTransferModel bABankTransfer, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBABankTransfer(string refId);

        #endregion

        //#region Salary

        ///// <summary>
        ///// Gets the state of the cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //SalaryModel GetCalSalaryState(SalaryModel model);
        ///// <summary>
        ///// Gets the salary by moth.
        ///// </summary>
        ///// <returns></returns>
        //List<SalaryModel> GetSalaryByMoth();

        ///// <summary>
        ///// Checks the state of the cal salary posted.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //bool CheckCalSalaryPostedState(SalaryModel model);
        ///// <summary>
        ///// Checks the state of the cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //bool CheckCalSalaryState(SalaryModel model);
        ///// <summary>
        ///// Saves the cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int SaveCalSalary(SalaryModel model);
        ///// <summary>
        ///// Saves all cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int SaveAllCalSalary(SalaryModel model);
        ///// <summary>
        ///// Deletes the cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int DeleteCalSalary(SalaryModel model);
        ///// <summary>
        ///// Deletes all cal salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int DeleteAllCalSalary(SalaryModel model);
        ///// <summary>
        ///// Saves the posted all salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int SavePostedAllSalary(SalaryModel model);
        ///// <summary>
        ///// Saves the posted salary.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //int SavePostedSalary(SalaryModel model);
        ///// <summary>
        ///// Gets the reference no salary.
        ///// </summary>
        ///// <param name="currDate">The curr date.</param>
        ///// <returns></returns>
        //string GetRefNoSalary(string currDate, string currencyCode);

        //string GetRefNoInEmployeePayroll(string currDate);

        //string SararyExistRefNoInDay(string currDate, string refNo);


        //#endregion

        //#region VoucherType

        ///// <summary>
        ///// Gets the voucher types.
        ///// </summary>
        ///// <returns></returns>
        //IList<VoucherTypeModel> GetVoucherTypes();

        ///// <summary>
        ///// Gets the voucher types active.
        ///// </summary>
        ///// <returns></returns>
        //IList<VoucherTypeModel> GetVoucherTypesActive();

        //#endregion

        #region AutoBusiness

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinesses();

        /// <summary>
        /// Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinessesActive();

        /// <summary>
        /// Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinessesNonActive();

        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// AutoBusinessModel.
        /// </returns>
        AutoBusinessModel GetAutoBusiness(string autoBusinessId);

        /// <summary>
        /// Gets the type of the automatic business by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<AutoBusinessModel> GetAutoBusinessByRefType(int refTypeId, bool isActive);

        /// <summary>
        /// Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddAutoBusiness(AutoBusinessModel autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateAutoBusiness(AutoBusinessModel autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteAutoBusiness(string autoBusinessId);

        #endregion

        #region AutoBusinessParallel

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallels();

        /// <summary>
        /// Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallelsActive();

        /// <summary>
        /// Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallelsNonActive();

        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// AutoBusinessParallelModel.
        /// </returns>
        AutoBusinessParallelModel GetAutoBusinessParallel(string autoBusinessId);

        /// <summary>
        /// Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddAutoBusinessParallel(AutoBusinessParallelModel autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateAutoBusinessParallel(AutoBusinessParallelModel autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteAutoBusinessParallel(string autoBusinessId);

        #endregion

        #region RefType

        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        IList<RefTypeModel> GetRefTypes();

        /// <summary>
        /// Gets the reference type model.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        RefTypeModel GetRefTypeModel(int refTypeId);

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeModel">The reference type model.</param>
        /// <returns></returns>
        string UpdateRefType(RefTypeModel refTypeModel);

        ///// <summary>
        ///// Gets the reference types search.
        ///// </summary>
        ///// <returns></returns>
        //IList<RefTypeModel> GetRefTypesSearch();

        #endregion

        #region Project

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns>
        /// IList{ProjectModel}.
        /// </returns>
        IList<ProjectModel> GetProjects();

        /// <summary>
        /// Gets the projects active.
        /// </summary>
        /// <returns>
        /// IList{ProjectModel}.
        /// </returns>
        IList<ProjectModel> GetProjectsActive(bool isActive);

        IList<ProjectModel> GetProjectsByObjectType(string objectType);
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// ProjectModel.
        /// </returns>
        ProjectModel GetProject(string projectId);

        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddProject(ProjectModel project);

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateProject(ProjectModel project, bool editBank = false);

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteProject(string projectId);

        #endregion

        #region TaxItem
        /// <summary>
        /// Gets the tax items.
        /// </summary>
        /// <returns>IList&lt;TaxItemModel&gt;.</returns>
        IList<TaxItemModel> GetTaxItems();

        /// <summary>
        /// Gets the tax items active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;TaxItemModel&gt;.</returns>
        IList<TaxItemModel> GetTaxItemsActive(bool isActive);

        /// <summary>
        /// Gets the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>TaxItemModel.</returns>
        TaxItemModel GetTaxItem(string taxItemId);
        /// <summary>
        /// Adds the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>System.String.</returns>
        string AddTaxItem(TaxItemModel taxItem);
        /// <summary>
        /// Updates the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>System.String.</returns>
        string UpdateTaxItem(TaxItemModel taxItem);
        /// <summary>
        /// Deletes the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteTaxItem(string taxItemId);
        #endregion

        #region TaxType
        /// <summary>
        /// Gets the tax types.
        /// </summary>
        /// <returns>IList&lt;TaxTypeModel&gt;.</returns>
        IList<TaxTypeModel> GetTaxTypes();
        /// <summary>
        /// Gets the tax types active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;TaxTypeModel&gt;.</returns>
        IList<TaxTypeModel> GetTaxTypesActive(bool isActive);
        /// <summary>
        /// Gets the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>TaxTypeModel.</returns>
        TaxTypeModel GetTaxType(string taxTypeId);
        /// <summary>
        /// Adds the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>System.String.</returns>
        string AddTaxType(TaxTypeModel taxType);
        /// <summary>
        /// Updates the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>System.String.</returns>
        string UpdateTaxType(TaxTypeModel taxType);
        /// <summary>
        /// Deletes the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteTaxType(string taxTypeId);
        #endregion

        #region FundStructure

        /// <summary>
        /// Gets the fund structures.
        /// </summary>
        /// <returns>IList&lt;FundStructureModel&gt;.</returns>
        IList<FundStructureModel> GetFundStructures();


        /// <summary>
        /// Gets the fund structures active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>IList&lt;FundStructureModel&gt;.</returns>
        IList<FundStructureModel> GetFundStructuresActive(bool isActive);


        /// <summary>
        /// Gets the fund structure.
        /// </summary>
        /// <param name="fundStructureId">The fund structure identifier.</param>
        /// <returns>FundStructureModel.</returns>
        FundStructureModel GetFundStructure(string fundStructureId);



        /// <summary>
        /// Adds the fund structure.
        /// </summary>
        /// <param name="fundStructure">The fund structure.</param>
        /// <returns>System.String.</returns>
        string AddFundStructure(FundStructureModel fundStructure);


        /// <summary>
        /// Updates the fund structure.
        /// </summary>
        /// <param name="fundStructure">The fund structure.</param>
        /// <returns>System.String.</returns>
        string UpdateFundStructure(FundStructureModel fundStructure);


        /// <summary>
        /// Deletes the fund structure.
        /// </summary>
        /// <param name="fundStructureId">The fund structure identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteFundStructure(string fundStructureId);
        #endregion

        #region Contract

        /// <summary>
        /// Gets the Contracts.
        /// </summary>
        /// <returns>
        /// IList{ContractModel}.
        /// </returns>
        IList<ContractModel> GetContracts();
        IList<ContractDetailsModel> GetContractDetails();

        /// <summary>
        /// Gets the Contracts active.
        /// </summary>
        /// <returns>
        /// IList{ContractModel}.
        /// </returns>
        IList<ContractModel> GetContractsActive(bool isActive);

        /// <summary>
        /// Gets the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns>
        /// ContractModel.
        /// </returns>
        ContractModel GetContract(string ContractId);
        List<ContractDetailsModel> GetContractDetail(string ContractId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractNo"></param>
        /// <returns></returns>
        ContractModel GetContractByContractNo(string contractNo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractNo"></param>
        /// <returns></returns>
        IList<ContractModel> GetContractByProjectId(string projectId);

        /// <summary>
        /// Adds the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string AddContract(ContractModel Contract);

        /// <summary>
        /// Updates the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string UpdateContract(ContractModel Contract);

        /// <summary>
        /// Deletes the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteContract(string ContractId);
        string DeleteContractDetail(string ContractDetailId);

        #endregion


        #region CapitalPlan

        IList<CapitalPlanModel> GetCapitalPlans();

        CapitalPlanModel GetCapitalPlan(string capitalplanId);

        string AddCapitalPlan(CapitalPlanModel capitalplan);

        string UpdateCapitalPlan(CapitalPlanModel capitalplan);

        string DeleteCapitalPlan(string capitalplanId);

        #endregion CapitalPlan

        //#region CompanyProfile

        ///// <summary>
        ///// Gets the companyProfiles.
        ///// </summary>
        ///// <returns>
        ///// IList{CompanyProfileModel}.
        ///// </returns>
        //IList<CompanyProfileModel> GetCompanyProfiles();

        ///// <summary>
        ///// Gets the companyProfile.
        ///// </summary>
        ///// <param name="companyProfileId">The companyProfile identifier.</param>
        ///// <returns>
        ///// CompanyProfileModel.
        ///// </returns>
        //CompanyProfileModel GetCompanyProfile(int companyProfileId);

        ///// <summary>
        ///// Adds the companyProfile.
        ///// </summary>
        ///// <param name="companyProfile">The companyProfile.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddCompanyProfile(CompanyProfileModel companyProfile);

        ///// <summary>
        ///// Updates the companyProfile.
        ///// </summary>
        ///// <param name="companyProfile">The companyProfile.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateCompanyProfile(CompanyProfileModel companyProfile);

        ///// <summary>
        ///// Deletes the companyProfile.
        ///// </summary>
        ///// <param name="companyProfileId">The companyProfile identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteCompanyProfile(int companyProfileId);

        //#endregion

        //#region Report

        //#region Estiamte Report //chỉ giành cho báo cáo dự toán 

        ///// <summary>
        ///// Gets the general receipt estimate.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <returns></returns>
        //IList<GeneralReceiptEstimateModel> GetGeneralReceiptEstimate(short yearOfEstimate);

        ///// <summary>
        ///// Gets the general payment estimate.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <returns></returns>
        //IList<GeneralPaymentEstimateModel> GetGeneralPaymentEstimate(short yearOfEstimate);

        ///// <summary>
        ///// Gets the general estimate.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <returns></returns>
        //IList<GeneralEstimateModel> GetGeneralEstimate(short yearOfEstimate);

        ///// <summary>
        ///// Gets the general payment detail estimate.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <returns></returns>
        //IList<GeneralPaymentDetailEstimateModel> GetGeneralPaymentDetailEstimate(short yearOfEstimate);

        ///// <summary>
        ///// Gets the estimate detail statement.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <param name="isCompanyProfile">if set to <c>true</c> [is company profile].</param>
        ///// <returns></returns>
        //EstimateDetailStatementModel GetEstimateDetailStatement(short yearOfEstimate, bool isCompanyProfile);

        ///// <summary>
        ///// Gets the fund stuations.
        ///// </summary>
        ///// <param name="yearOfEstimate">The year of estimate.</param>
        ///// <returns></returns>
        //IList<FundStuationModel> GetFundStuations(short yearOfEstimate);

        //#endregion

        //#region Financial Report //chỉ giành cho báo cáo tài chính

        ///// <summary>
        ///// Gets the report B03 bn gs.
        ///// </summary>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<B03BNGModel> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        ///// <summary>
        ///// Gets the report F03 bn gs.
        ///// </summary>
        ///// <param name="storeProcedureName">Name of the store procedure.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<F03BNGModel> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        ///// <summary>
        ///// Gets the report F331 bn gs.
        ///// </summary>
        ///// <param name="storeProcedureName">Name of the store procedure.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountsCode">The accounts code.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<F331BNGModel> GetReportF331BNGs(string storeProcedureName, short amountType, string accountsCode, string currencyCode, DateTime fromDate, DateTime toDate);

        ///// <summary>
        ///// Gets the report B09 bn gs.
        ///// </summary>
        ///// <param name="storeProcedureName">Name of the store procedure.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<B09BNGModel> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        //#endregion

        ///// <summary>
        ///// Get02s the LDTL with store produre.
        ///// </summary>
        ///// <param name="whereClause">The where clause.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="departmentCode">The department code.</param>
        ///// <param name="fixedAssetCode">The fixed asset code.</param>
        ///// <param name="BudgetGroupCode">The budget group code.</param>
        ///// <returns></returns>
        //IList<SearchModel> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode, string departmentCode, string fixedAssetCode, string BudgetGroupCode);

        ///// <summary>
        ///// Gets the B01 h with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="amounType">Type of the amoun.</param>
        ///// <returns></returns>
        //IList<B01HModel> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        ///// <summary>
        ///// Gets the C22 h.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="paymentVoucherIdList">The payment voucher identifier list.</param>
        ///// <returns></returns>
        //IList<C22HModel> GetC22H(string storeProdure, string paymentVoucherIdList);

        ///// <summary>
        ///// Gets the C22 h.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="refIdList">The reference identifier list.</param>
        ///// <param name="reftypeId">The reftype identifier.</param>
        ///// <returns></returns>
        //IList<AccountingVoucherModel> AccountingVoucherModel(string storeProdure, string refIdList, int reftypeId);

        ///// <summary>
        ///// Gets the C22 h.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="itemTransactionVoucherIdList">The item transaction voucher identifier list.</param>
        ///// <returns></returns>
        //IList<C11HModel> GetC11H(string storeProdure, string itemTransactionVoucherIdList);

        ///// <summary>
        ///// Get02s the LDTL with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<A02LDTLModel> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate);


        //IList<A02LDTLModel> Get02LdtlIsRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee);

        ///// <summary>
        ///// Gets the S03 ah model with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="amounType">Type of the amoun.</param>
        ///// <returns></returns>
        //IList<S03AHModel> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        ///// <summary>
        ///// Gets the S03 ah model with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="budgetGroupCode">The budget group code.</param>
        ///// <param name="fixedassetCode">The fixedasset code.</param>
        ///// <param name="departmentCode">The department code.</param>
        ///// <param name="amounType">Type of the amoun.</param>
        ///// <param name="whereClause">The where clause.</param>
        ///// <returns></returns>
        //IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedassetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField);

        ///// <summary>
        ///// Gets the S33 h with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="budgetGroupCode">The budget group code.</param>
        ///// <param name="fixedassetCode">The fixedasset code.</param>
        ///// <param name="departmentCode">The department code.</param>
        ///// <param name="amounType">Type of the amoun.</param>
        ///// <param name="whereClause">The where clause.</param>
        ///// <returns></returns>
        //IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedassetCode, string departmentCode, int amounType, string whereClause);

        ///// <summary>
        ///// Gets the C30 bb with store produre.
        ///// </summary>
        ///// <param name="year">The year.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //IList<C30BBModel> GetC30BBWithStoreProdure(int year, int refTypeId);

        ///// <summary>
        ///// Gets the C30 bb item with store produre.
        ///// </summary>
        ///// <param name="year">The year.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //IList<C30BBModel> GetC30BBItemWithStoreProdure(int year, int refTypeId);



        ///// <summary>
        ///// Gets the cash S11 h with store produre.
        ///// </summary>
        ///// <param name="storeProcedure">The store procedure.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<CashReportModel> GetCashS11HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber,
        //                             string currencyCode);

        ///// <summary>
        ///// Gets the cash S12 h with store produre.
        ///// </summary>
        ///// <param name="storeProcedure">The store procedure.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<CashReportModel> GetCashS12HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string currencyCode, bool isBank, int? bankId);

        ///// <summary>
        ///// Gets the cash S11 ah with store produre.
        ///// </summary>
        ///// <param name="storeProcedure">The store procedure.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="correspondingAccountNumber">The corresponding account number.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<CashReportModel> GetCashS11AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
        //                                     string currencyCode);


        ///// <summary>
        ///// Gets the cash S12 ah with store produre.
        ///// </summary>
        ///// <param name="storeProcedure">The store procedure.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="correspondingAccountNumber">The corresponding account number.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<CashReportModel> GetCashS12AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
        //                             string currencyCode, bool isBank, int? bankId);


        ///// <summary>
        ///// Gets the S03 bh with store produre.
        ///// </summary>
        ///// <param name="storeProcedure">The store procedure.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="amountType">Type of the amount.</param>
        ///// <param name="accountNumber">The account number.</param>
        ///// <param name="correspondingAccountNumber">The corresponding account number.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<S03BHModel> GetS03BHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
        //                             string currencyCode);


        ///// <summary>
        ///// Gets the B14 q with store produre.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="accountnumber">The accountnumber.</param>
        ///// <param name="stockIdList">The stock identifier list.</param>
        ///// <param name="amounType">Type of the amoun.</param>
        ///// <returns></returns>
        //IList<B14QModel> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType);

        ///// <summary>
        ///// Gets the general payment detail estimate.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetB03HModel> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode);

        ///// <summary>
        ///// Gets the type of the fixed asset B03 h amount.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetB03HModel> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits);
        ///// <summary>
        ///// Gets the general payment detail estimate.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetB01Model> GetFixedAssetB01(string fromDate, string toDate, string currencyCode);

        ///// <summary>
        ///// Gets the type of the fixed asset B01 amount.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetB01Model> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the fixed asset c55a hd.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="faParameter">The fa parameter.</param>
        ///// <param name="faCategoryCode">The fa category code.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetC55aHDModel> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter,
        //                                                 string faCategoryCode, string currencyCode);

        ///// <summary>
        ///// Gets the fixed asset c55a hd.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="faParameter">The fa parameter.</param>
        ///// <param name="faCategoryCode">The fa category code.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetC55aHDModel> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter,
        //                                                 string faCategoryCode, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the fixed assets by code.
        ///// </summary>
        ///// <param name="fixedAssetCode">The fixed asset code.</param>
        ///// <returns></returns>
        //FixedAssetModel GetFixedAssetsByCode(string fixedAssetCode);

        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory(string fromDate, string toDate,
        //                                                           string currencyCode, int currencyDecimalDigits);
        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouse(string fromDate, string toDate,
        //                                                           string currencyCode);
        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCar(string fromDate, string toDate,
        //                                                           string currencyCode);
        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory3000(string fromDate, string toDate,
        //                                                           string currencyCode);
        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate);


        ///// <summary>
        ///// Gets the fixed asset S31 h.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="faParameter">The fa parameter.</param>
        ///// <param name="faCategoryCode">The fa category code.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetS31HModel> GetFixedAssetS31H(string fromDate, string toDate, string faParameter, string faCategoryCode,
        //                                             string currencyCode);

        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetB02Model> GetFixedAssetB02(string fromDate, string toDate,
        //                                                           string currencyCode);

        //IList<FixedAssetB03H30KModel> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits);

        //IList<FixedAsset30KPart2Model> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits);

        //IList<FixedAssetCardModel> GetFixedAssetCard(string strFixedAssetId, int currencyDecimalDigits);

        //IList<FixedAsset30KPart2Model> GetFixedAssetFAB0130KPart2(string fromDate, string toDate,
        //    int currencyDecimalDigits);

        //IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAB01Car(string fromDate, string toDate,
        //    int currencyDecimalDigits);

        //IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAB01House(string fromDate, string toDate,
        //    int currencyDecimalDigits);
        ///// <summary>
        ///// Gets the fixed asset fa inventory.
        ///// </summary>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <returns></returns>
        //IList<FixedAssetB02Model> GetFixedAssetB02AmountType(string fromDate, string toDate, int currencyDecimalDigits);

        ///// <summary>
        ///// Gets the C30 b B501.
        ///// </summary>
        ///// <param name="storeProdure">The store produre.</param>
        ///// <param name="receiptVoucherIdList">The receipt voucher identifier list.</param>
        ///// <returns></returns>
        //IList<C30BB501Model> GetC30BB501(string storeProdure, string receiptVoucherIdList);
        //#endregion

        //#region FixedAssetArmortization

        ///// <summary>
        ///// Gets the fixed asset armortizations.
        ///// </summary>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations();

        ///// <summary>
        ///// Gets the fixed asset armortizations include detail.
        ///// </summary>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail();

        ///// <summary>
        ///// Gets the fixed asset armortizations include detail.
        ///// </summary>
        ///// <param name="refDate">The reference date.</param>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail(string refDate);

        ///// <summary>
        ///// Gets the f armortization by fa increments.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationDetailModel> GetFArmortizationByFAIncrements(long refId);

        ///// <summary>
        ///// Gets the fixed asset armortizations.
        ///// </summary>
        ///// <param name="refDate">The reference date.</param>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate);

        ///// <summary>
        ///// Gets the fixed asset armortizations.
        ///// </summary>
        ///// <param name="refDate">The reference date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate, string currencyCode);

        ///// <summary>
        ///// Gets the payment fixedAssetArmortization.
        ///// </summary>
        ///// <param name="fixedAssetArmortizationId">The payment fixedAssetArmortization identifier.</param>
        ///// <returns></returns>
        //FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId);

        ///// <summary>
        ///// Gets the fixed asset armortization.
        ///// </summary>
        ///// <param name="fixedAssetArmortizationId">The fixed asset armortization identifier.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="yearOfDepreciation">The year of depreciation.</param>
        ///// <returns></returns>
        //FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId, string currencyCode, int yearOfDepreciation);

        ///// <summary>
        ///// Adds the fixedAssetArmortization.
        ///// </summary>
        ///// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        ///// <returns></returns>
        //long AddFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization);

        ///// <summary>
        ///// Updates the fixedAssetArmortization.
        ///// </summary>
        ///// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        ///// <returns></returns>
        //long UpdateFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization);

        ///// <summary>
        ///// Deletes the fixedAssetArmortization.
        ///// </summary>
        ///// <param name="fixedAssetArmortizationId">The fixedAssetArmortization identifier.</param>
        ///// <returns></returns>
        //long DeleteFixedAssetArmortization(long fixedAssetArmortizationId);

        //#endregion

        //#region FixedAssetDecrement

        ///// <summary>
        ///// Gets the fixed asset decrements.
        ///// </summary>
        ///// <returns></returns>
        //IList<FixedAssetDecrementModel> GetFixedAssetDecrements();

        ///// <summary>
        ///// Gets the fa decrement by fa increments.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //IList<FixedAssetDecrementDetailModel> GetFADecrementByFAIncrements(long refId);
        ///// <summary>
        ///// Gets the fixed asset decrements by year of post date.
        ///// </summary>
        ///// <param name="refDate">The reference date.</param>
        ///// <returns></returns>
        //IList<FixedAssetDecrementModel> GetFixedAssetDecrementsByYearOfPostDate(string refDate);

        ///// <summary>
        ///// Gets the fixed asset decrement.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //FixedAssetDecrementModel GetFixedAssetDecrement(long refId);

        ///// <summary>
        ///// Adds the fixed asset decrement.
        ///// </summary>
        ///// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        ///// <returns></returns>
        //long AddFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement);

        ///// <summary>
        ///// Adds the fixed asset decrements.
        ///// </summary>
        ///// <param name="fixedAssetDecrements">The fixed asset decrements.</param>
        ///// <returns></returns>
        //long AddFixedAssetDecrements(IList<FixedAssetDecrementModel> fixedAssetDecrements);

        ///// <summary>
        ///// Updates the fixed asset decrement.
        ///// </summary>
        ///// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        ///// <returns></returns>
        //long UpdateFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement);

        ///// <summary>
        ///// Deletes the fixed asset decrement.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //long DeleteFixedAssetDecrement(long refId);

        //#endregion

        //#region FixedAssetIncrement

        ///// <summary>
        ///// Gets the fixed asset decrements.
        ///// </summary>
        ///// <returns></returns>
        //IList<FixedAssetIncrementModel> GetFixedAssetIncrements();

        ///// <summary>
        ///// Gets the fixed asset decrements by year of post date.
        ///// </summary>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <param name="refDate">The reference date.</param>
        ///// <returns></returns>
        //IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByYearOfPostDate(int refTypeId, string refDate);

        ///// <summary>
        ///// Gets the fixed asset decrement.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //FixedAssetIncrementModel GetFixedAssetIncrement(long refId);

        ///// <summary>
        ///// Gets the deposits by reference type identifier.
        ///// </summary>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns>
        ///// IList{DepositModel}.
        ///// </returns>
        //IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByRefTypeId(long refTypeId);

        ///// <summary>
        ///// Gets the fixed asset increment.
        ///// </summary>
        ///// <param name="refNo">The reference no.</param>
        ///// <returns></returns>
        //FixedAssetIncrementModel GetFixedAssetIncrementByRefNo(string refNo);
        ///// <summary>
        ///// Adds the fixed asset decrement.
        ///// </summary>
        ///// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        ///// <returns></returns>
        //long AddFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement);

        ///// <summary>
        ///// Adds the fixed asset increments.
        ///// </summary>
        ///// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        ///// <returns></returns>
        //long AddFixedAssetIncrements(IList<FixedAssetIncrementModel> fixedAssetIncrement);


        ///// <summary>
        ///// Updates the fixed asset decrement.
        ///// </summary>
        ///// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        ///// <returns></returns>
        //long UpdateFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement);

        ///// <summary>
        ///// Deletes the fixed asset decrement.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //long DeleteFixedAssetIncrement(long refId);

        //#endregion

        //#region FixedAssetLedger

        ///// <summary>
        ///// Gets the fixed asset decrements.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns></returns>
        IList<FixedAssetLedgerModel> GetFixedAssetLedgerById(string fixedAssetId);
        //#endregion

        //#region FixedAssetVoucher

        ///// <summary>
        ///// Gets the fixed asset decrements.
        ///// </summary>
        ///// <param name="fixedAssetId">The fixed asset identifier.</param>
        ///// <returns></returns>
        //IList<FixedAssetVoucherModel> GetFixedAssetVoucherByFixedAssets(int fixedAssetId);
        //#endregion

        //#region GeneralVoucher

        ///// <summary>
        ///// Gets the genver voucher by reference type identifier.
        ///// </summary>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //IList<GeneralVocherModel> GetGenverVoucherByRefTypeId(int refTypeId);

        ///// <summary>
        ///// Gets the general voucher.
        ///// </summary>
        ///// <param name="generalVoucherId">The general voucher identifier.</param>
        ///// <returns></returns>
        //GeneralVocherModel GetGeneralVoucher(long generalVoucherId);

        ///// <summary>
        ///// Adds the general voucher.
        ///// </summary>
        ///// <param name="generalVoucher">The general voucher.</param>
        ///// <returns></returns>
        //long AddGeneralVoucher(GeneralVocherModel generalVoucher);


        ///// <summary>
        ///// Updates the general voucher.
        ///// </summary>
        ///// <param name="generalVoucher">The general voucher.</param>
        ///// <returns></returns>
        //long UpdateGeneralVoucher(GeneralVocherModel generalVoucher);


        ///// <summary>
        ///// Deletes the general voucher.
        ///// </summary>
        ///// <param name="generalVoucherId">The general voucher identifier.</param>
        ///// <returns></returns>
        //long DeleteGeneralVoucher(long generalVoucherId);

        ///// <summary>
        ///// Gets the genver voucher by is capital allocate.
        ///// </summary>
        ///// <returns></returns>
        //IList<GeneralVocherModel> GetGenverVoucherByIsCapitalAllocate();

        //#endregion

        //#region CaptitalAllocateVoucher


        ///// <summary>
        ///// Deletes the captital allocate voucher.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //long DeleteCaptitalAllocateVoucher(long refId);

        ///// <summary>
        ///// Adds the g captital allocate voucher.
        ///// </summary>
        ///// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        ///// <returns></returns>
        //long AddGCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher);

        ///// <summary>
        ///// Updates the captital allocate voucher.
        ///// </summary>
        ///// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        ///// <returns></returns>
        //long UpdateCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher);


        ///// <summary>
        ///// Captitals the allocate vouchers to date to from date.
        ///// </summary>
        ///// <param name="toDate">To date.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="activityId">The activity identifier.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDate(DateTime toDate, DateTime fromDate, int activityId, string currencyCode);


        ///// <summary>
        ///// Captitals the allocate vouchers to date to from date for update.
        ///// </summary>
        ///// <param name="toDate">To date.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="activityId">The activity identifier.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDateForUpdate(DateTime toDate, DateTime fromDate, string currencyCode, int activityId, int refTypeId, long refId);

        ///// <summary>
        ///// Captitals the allocate vouchers by reference identifier.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersByRefId(long refId);



        //#endregion

        //#region "AccountTransfer"

        ///// <summary>
        ///// Deletes the account tranfer voucher.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //long DeleteAccountTransferVoucher(long refId);

        ///// <summary>
        ///// Adds the account tranfer voucher.
        ///// </summary>
        ///// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        ///// <returns></returns>
        //long AddAccountTransferVoucher(AccountTransferVourcherModel captitalAllocateVoucher);

        ///// <summary>
        ///// Accounts the tranfer vouchers by posted date and currency code.
        ///// </summary>
        ///// <param name="postedDate">The posted date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <returns></returns>
        //IList<AccountTransferVourcherModel> AccountTransferVouchersByPostedDateAndCurrencyCode(DateTime postedDate, string currencyCode);

        ///// <summary>
        ///// Accounts the tranfer vouchers by edit.
        ///// </summary>
        ///// <param name="postedDate">The posted date.</param>
        ///// <param name="currencyCode">The currency code.</param>
        ///// <param name="refTypeId">The reference type identifier.</param>
        ///// <returns></returns>
        //IList<AccountTransferVourcherModel> AccountTransferVouchersByEdit(DateTime postedDate, string currencyCode, int refTypeId);

        ///// <summary>
        ///// Accounts the tranfer vouchers by reference identifier.
        ///// </summary>
        ///// <param name="refId">The reference identifier.</param>
        ///// <returns></returns>
        //IList<AccountTransferVourcherModel> AccountTransferVouchersByRefId(long refId);

        //#endregion

        //#region OpeningAccountEntry

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        IList<OpeningAccountEntryModel> GetOpeningAccountEntries();
        IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries(string accountNumber);
        /// <summary>
        /// Gets the opening account entry.
        /// </summary>
        /// <param name="accountNumber">The account code.</param>
        /// <returns></returns>
        IList<OpeningAccountEntryModel> GetOpeningAccountEntriesByAccountNumber(string accountNumber);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        string UpdateOpeningAccountEntry(OpeningAccountEntryModel openingAccountEntry);
        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        string UpdateOpeningAccountEntries(IList<OpeningAccountEntryModel> openingAccountEntryDetails);


        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="accountNumber">The opening account entry id.</param>
        /// <returns></returns>
        string DeleteOpeningAccountEntries(string accountNumber);

        //#endregion

        //#region OpeningAccountEntryDetail

        ///// <summary>
        ///// Gets the opening account entry details.
        ///// </summary>
        ///// <param name="accountCode">The account code.</param>
        ///// <returns></returns>
        //IList<OpeningAccountEntryDetailModel> GetOpeningAccountEntryDetails(string accountCode);

        ///// <summary>
        ///// Adds the opening account entry details.
        ///// </summary>
        ///// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        ///// <returns></returns>
        //long AddOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails);

        ///// <summary>
        ///// Updates the opening account entry details.
        ///// </summary>
        ///// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        ///// <returns></returns>
        //long UpdateOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails);



        //#endregion

        #region OpeningFixedAssetEntry

        /// <summary>
        /// Gets the opening fixed asset entries.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries(string accountCode);

        /// <summary>
        /// Gets the opening fixed asset entries.
        /// </summary>
        /// <returns></returns>
        IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries();
        /// <summary>
        /// Adds the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        string InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingAccountEntryDetails);

        /// <summary>
        /// Gets the opening fixed asset entries by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>IList{OpeningFixedAssetEntryModel}.</returns>
        IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntriesByAccountNumber(string accountNumber);

        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        string UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingAccountEntries, int fixedAssetId);

        /// <summary>
        /// Updates the opening account entry
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <returns></returns>
        string UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingAccountEntries);
        /// <summary>
        /// Updates the opening fixed asset entries detail.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <returns></returns>
        string UpdateOpeningFixedAssetEntriesDetail(IList<OpeningFixedAssetEntryModel> openingAccountEntries);

        /// <summary>
        /// Inserts the opening fixed asset entries.
        /// </summary>
        /// <param name="openingFixedAssetEntry">The opening fixed asset entry.</param>
        /// <returns></returns>
        string InsertOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntry);
        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string DeleteOpeningFixedAssetEntry(int departmentId);

        #endregion

        //#region Common

        ///// <summary>
        ///// Gets the identifier by code.
        ///// </summary>
        ///// <param name="query">The query.</param>
        ///// <returns></returns>
        //int? GetIdByCode(string query);

        ///// <summary>
        ///// Gets the identifier by code.
        ///// </summary>
        ///// <param name="tableName">Name of the table.</param>
        ///// <param name="idFieldName">Name of the identifier field.</param>
        ///// <param name="codeFieldName">Name of the code field.</param>
        ///// <param name="codeValueField">The code value field.</param>
        ///// <returns></returns>
        //int? GetIdByCode(string tableName, string idFieldName, string codeFieldName, string codeValueField);

        ///// <summary>
        ///// Resets the automatic increment.
        ///// </summary>
        ///// <param name="tableName">Name of the table.</param>
        ///// <param name="startIncrementNumber">The start increment number.</param>
        ///// <returns></returns>
        //bool ResetAutoIncrement(string tableName, int startIncrementNumber);

        ///// <summary>
        ///// Updates the amount exchange.
        ///// </summary>
        ///// <param name="exchangeRate">The exchange rate.</param>
        ///// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        ///// <param name="fromDate">From date.</param>
        ///// <param name="toDate">To date.</param>
        ///// <returns></returns>
        //int UpdateAmountExchange(decimal exchangeRate, short currencyDecimalDigits, DateTime fromDate, DateTime toDate);

        //#endregion

        //#region Role

        ///// <summary>
        ///// Department
        ///// Gets the roles.
        ///// </summary>
        ///// <returns>
        ///// IList{RoleModel}.
        ///// </returns>
        //IList<RoleModel> GetRoles();

        ///// <summary>
        ///// Gets the roles.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<RoleModel> GetRoles(bool isActive);

        ///// <summary>
        ///// Gets the role.
        ///// </summary>
        ///// <param name="roleId">The role identifier.</param>
        ///// <returns>
        ///// RoleModel.
        ///// </returns>
        //RoleModel GetRole(int roleId);

        ///// <summary>
        ///// Adds the role.
        ///// </summary>
        ///// <param name="role">The role.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddRole(RoleModel role);

        ///// <summary>
        ///// Updates the role.
        ///// </summary>
        ///// <param name="role">The role.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateRole(RoleModel role);

        ///// <summary>
        ///// Deletes the role.
        ///// </summary>
        ///// <param name="roleId">The role identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteRole(int roleId);

        //#endregion

        //#region Site

        ///// <summary>
        ///// Department
        ///// Gets the sites.
        ///// </summary>
        ///// <returns>
        ///// IList{SiteModel}.
        ///// </returns>
        //IList<SiteModel> GetSites();

        ///// <summary>
        ///// Gets the sites.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<SiteModel> GetSites(bool isActive);

        ///// <summary>
        ///// Gets the site.
        ///// </summary>
        ///// <param name="siteId">The site identifier.</param>
        ///// <returns>
        ///// SiteModel.
        ///// </returns>
        //SiteModel GetSite(int siteId);

        ///// <summary>
        ///// Adds the site.
        ///// </summary>
        ///// <param name="site">The site.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddSite(SiteModel site);

        ///// <summary>
        ///// Updates the site.
        ///// </summary>
        ///// <param name="site">The site.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateSite(SiteModel site);

        ///// <summary>
        ///// Deletes the site.
        ///// </summary>
        ///// <param name="siteId">The site identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteSite(int siteId);

        //#endregion

        //#region Permission

        ///// <summary>
        ///// Department
        ///// Gets the permissions.
        ///// </summary>
        ///// <returns>
        ///// IList{PermissionModel}.
        ///// </returns>
        //IList<PermissionModel> GetPermissions();

        ///// <summary>
        ///// Gets the permissions.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<PermissionModel> GetPermissions(bool isActive);

        ///// <summary>
        ///// Gets the permission.
        ///// </summary>
        ///// <param name="permissionId">The permission identifier.</param>
        ///// <returns>
        ///// PermissionModel.
        ///// </returns>
        //PermissionModel GetPermission(int permissionId);

        ///// <summary>
        ///// Adds the permission.
        ///// </summary>
        ///// <param name="permission">The permission.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddPermission(PermissionModel permission);

        ///// <summary>
        ///// Updates the permission.
        ///// </summary>
        ///// <param name="permission">The permission.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdatePermission(PermissionModel permission);

        ///// <summary>
        ///// Deletes the permission.
        ///// </summary>
        ///// <param name="permissionId">The permission identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeletePermission(int permissionId);

        //#endregion

        //#region UserProfile

        ///// <summary>
        ///// Department
        ///// Gets the userProfiles.
        ///// </summary>
        ///// <returns>
        ///// IList{UserProfileModel}.
        ///// </returns>
        //IList<UserProfileModel> GetUserProfiles();

        ///// <summary>
        ///// Gets the userProfiles.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //IList<UserProfileModel> GetUserProfiles(bool isActive);

        ///// <summary>
        ///// Gets the userProfile.
        ///// </summary>
        ///// <param name="userProfileId">The userProfile identifier.</param>
        ///// <returns>
        ///// UserProfileModel.
        ///// </returns>
        //UserProfileModel GetUserProfile(int userProfileId);

        ///// <summary>
        ///// Gets the name of the user profile by user profile.
        ///// </summary>
        ///// <param name="userProfileName">Name of the user profile.</param>
        ///// <param name="password">The password.</param>
        ///// <returns></returns>
        //UserProfileModel GetUserProfileByUserProfileName(string userProfileName, string password);

        ///// <summary>
        ///// Adds the userProfile.
        ///// </summary>
        ///// <param name="userProfile">The userProfile.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddUserProfile(UserProfileModel userProfile);

        ///// <summary>
        ///// Updates the userProfile.
        ///// </summary>
        ///// <param name="userProfile">The userProfile.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateUserProfile(UserProfileModel userProfile);

        ///// <summary>
        ///// Deletes the userProfile.
        ///// </summary>
        ///// <param name="userProfileId">The userProfile identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteUserProfile(int userProfileId);

        ///// <summary>
        ///// Changes the password.
        ///// </summary>
        ///// <param name="userProfileName">Name of the user profile.</param>
        ///// <param name="oldPassword">The old password.</param>
        ///// <param name="newPassword">The new password.</param>
        ///// <returns></returns>
        //int ChangePassword(string userProfileName, string oldPassword, string newPassword);

        //#endregion

        //#region OpeningInventoryEntry

        ///// <summary>
        ///// Gets the opening account entries.
        ///// </summary>
        ///// <returns></returns>
        //IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries();

        ///// <summary>
        ///// Gets the opening account entry.
        ///// </summary>
        ///// <param name="accountCode">The account code.</param>
        ///// <returns></returns>
        //IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries(string accountCode);

        ///// <summary>
        ///// Updates the opening account entry.
        ///// </summary>
        ///// <param name="openingInventoryEntry">The opening account entry.</param>
        ///// <returns></returns>
        //long UpdateOpeningInventoryEntry(List<OpeningInventoryEntryModel> openingInventoryEntry);



        //#endregion

        //#region EmployeeLeasing

        ///// <summary>
        ///// Gets the employeeLeasings.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeLeasingModel}.
        ///// </returns>
        //IList<EmployeeLeasingModel> GetEmployeeLeasings();

        ///// <summary>
        ///// Gets the employee leasings.
        ///// </summary>
        ///// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        ///// <returns></returns>
        //IList<EmployeeLeasingModel> GetEmployeeLeasings(bool isLeasing);

        ///// <summary>
        ///// Gets the employeeLeasings active.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeLeasingModel}.
        ///// </returns>
        //IList<EmployeeLeasingModel> GetEmployeeLeasingsActive();

        ///// <summary>
        ///// Gets the employeeLeasings non active.
        ///// </summary>
        ///// <returns>
        ///// IList{EmployeeLeasingModel}.
        ///// </returns>
        //IList<EmployeeLeasingModel> GetEmployeeLeasingsNonActive();

        ///// <summary>
        ///// Gets the employeeLeasing.
        ///// </summary>
        ///// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        ///// <returns>
        ///// EmployeeLeasingModel.
        ///// </returns>
        //EmployeeLeasingModel GetEmployeeLeasing(int employeeLeasingId);

        ///// <summary>
        ///// Adds the employeeLeasing.
        ///// </summary>
        ///// <param name="employeeLeasing">The employeeLeasing.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddEmployeeLeasing(EmployeeLeasingModel employeeLeasing);

        ///// <summary>
        ///// Updates the employeeLeasing.
        ///// </summary>
        ///// <param name="employeeLeasing">The employeeLeasing.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateEmployeeLeasing(EmployeeLeasingModel employeeLeasing);

        ///// <summary>
        ///// Deletes the employeeLeasing.
        ///// </summary>
        ///// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteEmployeeLeasing(int employeeLeasingId);

        //#endregion

        //#region Building

        ///// <summary>
        ///// Gets the buildings.
        ///// </summary>
        ///// <returns>
        ///// IList{BuildingModel}.
        ///// </returns>
        //IList<BuildingModel> GetBuildings();

        ///// <summary>
        ///// Gets the buildings active.
        ///// </summary>
        ///// <returns>
        ///// IList{BuildingModel}.
        ///// </returns>
        //IList<BuildingModel> GetBuildingsActive();

        ///// <summary>
        ///// Gets the buildings non active.
        ///// </summary>
        ///// <returns>
        ///// IList{BuildingModel}.
        ///// </returns>
        //IList<BuildingModel> GetBuildingsNonActive();

        ///// <summary>
        ///// Gets the building.
        ///// </summary>
        ///// <param name="buildingId">The building identifier.</param>
        ///// <returns>
        ///// BuildingModel.
        ///// </returns>
        //BuildingModel GetBuilding(int buildingId);

        ///// <summary>
        ///// Adds the building.
        ///// </summary>
        ///// <param name="building">The building.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddBuilding(BuildingModel building);

        ///// <summary>
        ///// Updates the building.
        ///// </summary>
        ///// <param name="building">The building.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateBuilding(BuildingModel building);

        ///// <summary>
        ///// Deletes the building.
        ///// </summary>
        ///// <param name="buildingId">The building identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteBuilding(int buildingId);

        //#endregion

        #region BudgetSourceCategory

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategories();

        /// <summary>
        /// Gets the budgetSourceCategories active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesActive();

        /// <summary>
        /// Gets the budgetSourceCategories non active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesNonActive();

        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// BudgetSourceCategoryModel.
        /// </returns>
        BudgetSourceCategoryModel GetBudgetSourceCategory(string budgetSourceCategoryId);

        /// <summary>
        /// Adds the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        string AddBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory);

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        string UpdateBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory);

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        string DeleteBudgetSourceCategory(string budgetSourceCategoryId);

        #endregion

        //#region EstimateDetailStatementInfo

        ///// <summary>
        ///// Gets the payment estimates.
        ///// </summary>
        ///// <returns></returns>
        //IList<EstimateDetailStatementInfoModel> GetEstimateDetailStatementInfos();

        ///// <summary>
        ///// Gets the payment estimate.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //EstimateDetailStatementInfoModel GetEstimateDetailStatementInfo(bool isActive);

        ///// <summary>
        ///// Gets the company profile information.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns></returns>
        //EstimateDetailStatementInfoModel GetCompanyProfileInfo(bool isActive);

        ///// <summary>
        ///// Adds the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatement">The estimate detail statement.</param>
        ///// <returns></returns>
        //int AddEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement);

        ///// <summary>
        ///// Updates the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatement">The estimate detail statement.</param>
        ///// <returns></returns>
        //int UpdateEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement);

        ///// <summary>
        ///// Deletes the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatementId">The estimate detail statement identifier.</param>
        ///// <returns></returns>
        //long DeleteEstimateDetailStatementInfo(int estimateDetailStatementId);

        //#endregion

        //#region EstimateDetailStatementPartB

        ///// <summary>
        ///// Gets the payment estimates.
        ///// </summary>
        ///// <returns></returns>
        //IList<EstimateDetailStatementPartBModel> GetEstimateDetailStatementPartBs();

        ///// <summary>
        ///// Adds the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        ///// <returns></returns>
        //int AddEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB);

        ///// <summary>
        ///// Updates the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        ///// <returns></returns>
        //int UpdateEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB);

        //#endregion

        //#region EstimateDetailStatementFixedAsset

        ///// <summary>
        ///// Gets the payment estimates.
        ///// </summary>
        ///// <returns></returns>
        //IList<EstimateDetailStatementFixedAssetModel> GetEstimateDetailStatementFixedAssets();

        ///// <summary>
        ///// Adds the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        ///// <returns></returns>
        //int AddEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementPartB);

        ///// <summary>
        ///// Updates the estimate.
        ///// </summary>
        ///// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        ///// <returns></returns>
        //int UpdateEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementPartB);

        //#endregion

        //#region FixedAssetHousingReport

        ///// <summary>
        ///// Gets the budget chapters.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetHousingReportModel}.
        ///// </returns>
        //IList<FixedAssetHousingReportModel> GetFixedAssetHousingReports();

        ///// <summary>
        ///// Gets the budget chapters active.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetHousingReportModel}.
        ///// </returns>
        //IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsActive();

        ///// <summary>
        ///// Gets the budget chapters non active.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetHousingReportModel}.
        ///// </returns>
        //IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsNonActive();

        ///// <summary>
        ///// Gets the budget chapter.
        ///// </summary>
        ///// <param name="isActive">if set to <c>true</c> [is active].</param>
        ///// <returns>
        ///// FixedAssetHousingReportModel.
        ///// </returns>
        //FixedAssetHousingReportModel GetFixedAssetHousingReport(bool isActive);
        ///// <summary>
        ///// Adds the budget chapter.
        ///// </summary>
        ///// <param name="fixedAssetHousingReport">The budget source property.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int AddFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport);

        ///// <summary>
        ///// Updates the budget chapter.
        ///// </summary>
        ///// <param name="fixedAssetHousingReport">The budget source property.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int UpdateFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport);

        ///// <summary>
        ///// Deletes the budget chapter.
        ///// </summary>
        ///// <param name="fixedAssetHousingReportId">The budget source property identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        //int DeleteFixedAssetHousingReport(int fixedAssetHousingReportId);

        //#endregion

        //#region ElectricalWork

        //ElectricalWorkModel GetElectricalWork(int postedDate);
        //int UpdateInsertElectricalWork(ElectricalWorkModel electricalWorkModel);

        //#endregion

        //#region Mutual
        //IList<MutualModel> GetMutuals();
        //MutualModel GetMutual(int mutualId);

        //List<MutualModel> GetMutualByIsActive(bool isActive);
        //List<MutualModel> GetMutualByMutualCode(string mutualCode);

        //int AddMutual(MutualModel mutual);

        //int UpdateMutual(MutualModel mutual);

        //int DeleteMutual(int mutualId);

        //#endregion

        //#region AutoNumberList
        //IList<AutoNumberListModel> GetAutoNumberLists();
        //AutoNumberListModel GetAutoNumberList(string tableCode);
        //string UpdateAutoNumberList(List<AutoNumberListModel> autoNumberLists);
        //#endregion

        //#region SalaryVoucher

        //List<SalaryVoucherModel> SalaryVoucherByMonthDate(string monthDate);

        //List<SalaryVoucherModel> SalaryVoucherByMonthDateIsPostedDate(string monthDate);

        //List<SalaryVoucherModel> SalaryVoucherByMonthDateIsRetail(string monthDate, bool isRetail, int refTypeId);

        //string SaveSalaryVoucher(string postedDate, string refNo, int refTypeId);

        //string CancelCalc(string postedDate, string refNo, int refTypeId);

        //string CancelSalaryVoucher(string postedDate, string refNo, int refTypeId);

        //string SalaryVoucherByCash(string postedDate, string refNo, int refTypeId);

        //string SalaryVoucherByDeposit(string postedDate, string refNo, int refTypeId);

        //#endregion

        #region lock

        LockModel GetLock();

        string SaveLock(LockModel model);

        LockModel CheckLock(string refId, int refTypeId, DateTime refDate);

        LockModel CheckLock(string refId, int refTypeId);

        #endregion

        #region Voucher Reports

        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        IList<C41BBModel> ReportCashPaymentC41BB(string refId);

        /// <summary>
        /// Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        IList<C41BBModel> ReportCashPaymentFixedAssetC41BB(string refId);

        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        IList<C41BBModel> ReportCashDepositC41BB(string refId);

        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        IList<C41BBModel> ReportCashPaymentGetFromBADeposit(string refId);

        /// <summary>
        /// Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        IList<C41BBModel> ReportCashPaymentPurchaseC41BB(string refId);

        /// <summary>
        /// Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C40BBModel> ReportCashReceiptC30BB(string refId);
        /// <summary>
        /// Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>

        IList<C45_BBModel> ReportCashRecepitC45BB(string refId);

        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDModel&gt;.</returns>
        IList<C21HDModel> ReportCashReceiptSaleOutwardStock(string refId);

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailModel&gt;.</returns>
        IList<C21HDDetailModel> ReportCashReceiptSaleOutwardStockDetail(string refId);

        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C20HDModel&gt;.</returns>
        IList<C20HDModel> ReportCashReceiptSaleC20HD(string refId, int refType);

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C4_09Model&gt;.</returns>
        IList<C4_09Model> ReportCAReceipt_C4_09(string refId, BuCA.Enum.RefType refType = BuCA.Enum.RefType.CAReceipt);


        IList<C203NSModel> ReportC203NSTT77(string refId, DateTime StartDate, DateTime FiscalStartDate, string BudgetSourceKind, string TargetProgramID, string BankInfoID, string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID, string BudgetItemCodeList, bool IsActiveTemplate, DateTime SystemDate, bool IsSystemDate, bool IsRefDate, bool CheckCashWithDrawType);

        IList<C302NSModel> GetReportC302NS(string refId, DateTime StartDate, int PayType, string TargetProgramID, string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID, string BudgetItemCodeList, string InvestmentNumber, DateTime InvestmentDate, string YearPlan, bool CheckCashWithDrawType);
        IList<C2_02a_NSModel> ReportBUPlanWithDraw(string refId, int IsGroupDetail, int IsShowDuplicate, int content, BuCA.Enum.RefType refType = BuCA.Enum.RefType.BUPlanWithDrawCash);

        /// <summary>
        /// Reports the cash payment_ C4_08.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C408Model> ReportCashPaymentC408(int refType, string refId);

        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="storeProceduce">The store proceduce.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C402CKBModel> ReportC402CKB(string storeProceduce, string refId);

        IList<C402CKBModel> ReportC205ANS(string storeProceduce, string refId);

        /// <summary>
        /// Reports the C409 CKB.
        /// </summary>
        /// <param name="storeProceduce">The store proceduce.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C4_09Model> ReportC409(string storeProceduce, string refId);

        /// <summary>
        /// Gets the voucher data.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="reftype">The reftype.</param>
        /// <returns></returns>
        IList<VoucherModel> GetVoucherData(string refId, int reftype);

        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSModel&gt;.</returns>
        IList<C212NSModel> GetC212NS(string refId);

        /// <summary>
        /// Gets the C213 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C213NSModel&gt;.</returns>
        IList<C213NSModel> GetC213NS(string refId);

        /// <summary>
        /// Reports the gl voucher list detail.
        /// </summary>
        /// <param name="RefId">The reference identifier.</param>
        /// <param name="IsShowSameRow">if set to <c>true</c> [is show same row].</param>
        /// <param name="IsShowOriginalCurrency">if set to <c>true</c> [is show original currency].</param>
        /// <returns></returns>
        IList<GLVoucherListDetailModel> ReportGlVoucherListDetail(string RefId, bool IsShowSameRow, bool IsShowOriginalCurrency);

        IList<AccountingVoucherModel> ReportAccountingVoucher(string refId, int refType);

        /// <summary>
        /// Reports the gl voucher list.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<GLVoucherListModel> ReportGlVoucherList(DateTime fromDate, DateTime toDate, bool isNotShowSignAccount, int amountType, string currencyCode);

        /// <summary>
        /// Reports the gl voucher list ledger.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummarrySource">if set to <c>true</c> [is summarry source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="accountList">The account list.</param>
        /// <returns></returns>
        IList<GLVoucherListLedgerModel> ReportGLVoucherListLedger(DateTime fromDate, DateTime toDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList);

        /// <summary>
        /// Reports the S02 ch.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummarrySource">if set to <c>true</c> [is summarry source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="accountList">The account list.</param>
        /// <returns></returns>
        IList<S02CHModel> ReportS02CH(DateTime fromDate, DateTime toDate, DateTime startDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList);

        /// <summary>
        /// Reports the S51 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="isSummaryInventory">if set to <c>true</c> [is summary inventory].</param>
        /// <param name="isSummaryActivity">if set to <c>true</c> [is summary activity].</param>
        /// <returns></returns>
        IList<S51HModel> ReportS51H(DateTime fromDate, DateTime toDate, DateTime startDate,
            string inventoryItemId, string activityId, bool isSummaryInventory, bool isSummaryActivity);

        #endregion

        #region Deposit Reports

        /// <summary>
        /// Reports the S12 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="summaryBankId">if set to <c>true</c> [summary bank identifier].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>IList&lt;S12HModel&gt;.</returns>
        IList<S12HModel> ReportS12H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,bool IsDetail, int amountType, string currencyCode);

        /// <summary>
        /// Reports the S12 h detail.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="summaryBankId">if set to <c>true</c> [summary bank identifier].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>IList&lt;S12HDetailModel&gt;.</returns>
        IList<S12HDetailModel> ReportS12HDetail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem);

        /// <summary>
        /// Reports the S11 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="isSummarySource">if set to <c>true</c> [is summary source].</param>
        /// <param name="showAccountingObjectInfo">if set to <c>true</c> [show accounting object information].</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>IList&lt;S11HModel&gt;.</returns>
        IList<S11HModel> ReportS11H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                           string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, bool isSummarySource, bool showAccountingObjectInfo, string budgetSourceId,bool IsDetail, bool IsDetailMonth, int amountType, string currencyCode);
        IList<S11HDetailModel> ReportS11HDetail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
           string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem);

        IList<C301NSModel> ReportC301NS(string refId, int refTypeId, bool isDetail, bool isParent, int mH);
        IList<C301NSDetailModel> ReportC301NSDetail(string refId, int refTypeId, bool isDetail, bool isParent, int mH);
        IList<C301NSDetail2Model> ReportC301NSDetail2(string refId, int refTypeId, bool isDetail, bool isParent, int mH);

        IList<C304NSModel> ReportC304NS(string refId);
        IList<C409KBModel> GetReportC409KB(string refId, bool isDetail);
        IList<C409KBDetailsModel> GetReportC409KBDetail(string refId, bool isDetail);
        IList<PaymentPurchaseModel> ReportPaymentPurchase(string refId);

        IList<C205aModel> ReportC205A(string refId);
        IList<C206NSModel> ReportC206NS(string refId);
        #endregion

        #region ReportLedgerAccounting

        IList<S27Model> GetReportS27(DateTime fromDate, DateTime toDate, string accountCode, string currencyCode, string budgetSourceId, string projectId, int amountType);

        /// <summary>
        /// Gets the report S04 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>IList&lt;S04HModel&gt;.</returns>
        IList<S04HModel> GetReportS04H(DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                          bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, int amountType, string currencyCode);
        /// <summary>
        /// Gets the report S05 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <returns>IList&lt;S05HModel&gt;.</returns>
        IList<S05HModel> GetReportS05H(DateTime fromDate, DateTime toDate, string budgetChapterCode, bool isSummaryBudgetChapter, bool amounttype, string currencycode);
        /// <summary>
        /// Gets the report S31 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="accountingObjectID">The accounting object identifier.</param>
        /// <param name="budgetSourceID">The budget source identifier.</param>
        /// <param name="isSumaryGroupBudgetSource">if set to <c>true</c> [is sumary group budget source].</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSumaryGroupBudgetChapterCode">if set to <c>true</c> [is sumary group budget chapter code].</param>
        /// <param name="isSumaryGroupBudgetSubKindItemCode">if set to <c>true</c> [is sumary group budget sub kind item code].</param>
        /// <returns>IList&lt;S31HModel&gt;.</returns>
        IList<S31HModel> GetReportS31H(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber,int amountType,string currencyCode, string CorrespondingAccountNumber, string AccountingObjectID, string BudgetSourceID, string FundStructureID, string BudgetChapterCode, string BudgetKindItemCode, string BudgetItemCode, string ProjectID, string ContractID, string BankID, string ActivityId, string CapitalPlanID, bool IsAccountingObjectID, bool IsGroupBudgetSourceID, bool IsGroupFundStructureID, bool IsGroupBudgetChapterCode, bool IsGroupBudgetKindItemCode, bool IsGroupBudgetItemCode, bool IsGroupProjectID, bool IsGroupContractID, bool IsGroupBankID, bool IsGroupActivityId, bool IsGroupCapitalPlanID, bool IsGroupCurrencyCode,bool ISCustomer, bool ISVendor, bool ISEmployee,string CustomerID, string VendorID, string EmployeeID, string FixedAssetId, string InventoryItemId, bool IsGroupFixedAssetId, bool IsGroupInventoryItemId);


        /// <summary>
        /// Gets the report S31 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceID">The budget source identifier.</param>
        /// <param name="isSumaryGroupBudgetSource">if set to <c>true</c> [is sumary group budget source].</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSumaryGroupBudgetChapterCode">if set to <c>true</c> [is sumary group budget chapter code].</param>
        /// <param name="isSumaryGroupBudgetSubKindItemCode">if set to <c>true</c> [is sumary group budget sub kind item code].</param>
        /// <returns>IList&lt;S31HModel&gt;.</returns>
        //IList<S31HNoAccoutingObjectModel> GetReportS31HNoAccoutingObject(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber,string budgetSourceID,
        //                              bool isSumaryGroupBudgetSource, string budgetChapterCode, string budgetSubKindItemCode, bool isSumaryGroupBudgetChapterCode, bool isSumaryGroupBudgetSubKindItemCode, int amountType, string currencyCode);

        /// <summary>
        /// Gets the report S03 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        IList<S03HModel> GetReportS03H(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, int amountType, string currencyCode, bool isDetail);

        /// <summary>
        /// Gets the report S02 ch.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        IList<S03HModel> GetReportS02CH(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, bool IsForeignCurrency, int AmountType, string CurrencyCode);

        /// <summary>
        /// Gets the C33 bb.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="accountingObjectList">The accounting object list.</param>
        /// <returns>IList&lt;C33BBModel&gt;.</returns>
        IList<C33BBModel> GetC33BB(DateTime fromdate, DateTime todate, string departmentId,
            string accountingObjectList);

        /// <summary>
        /// Gets the S34 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns>IList&lt;S34H_GL_MasterModel&gt;.</returns>
        IList<S34H_GL_MasterModel> GetS34H(DateTime startdate, DateTime fromDate, DateTime toDate,
            string accountnumber, string correspondingAccount,
            string AccountingObjectList, string ProjectList,bool issumaccount, bool groupsameitem, bool IsDetail, int amountType, string currencyCode);

        /// <summary>
        /// Gets the report S13 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accounts">The accounts.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<S13HModel> GetReportS13H(DateTime startDate, DateTime fromDate, DateTime toDate, string accounts,
                                       string currencyCode, bool isDetail,bool isDetailMonth, string bankAccount);

        /// <summary>
        /// Gets the report S01 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isViewOutAccount">if set to <c>true</c> [is view out account].</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>DataTable.</returns>
        DataTable GetReportS01H(DateTime fromDate, DateTime toDate, bool isViewOutAccount, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem);

        /// <summary>
        /// Gets the report S01 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        IList<S01HLedgerModel> GetReportS01HLedger(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13);

        #endregion

        #region Inventory Report
        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        IList<S22HModel> GetReportS22H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds, string accountNumber, int amountType, string currencyCode);

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        IList<S21HModel> GetReportS21H(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds,bool IsDetailMonth);

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        IList<InventoryBookModel> GetInventoryBook(DateTime fromDate, DateTime toDate, string stockId, string inventoryItemIds);
        IList<S23HModel> GetReportS23H(DateTime fromDate, DateTime toDate, string inventoryItemIds, string accountNumber);

        /// <summary>
        /// Reports the tool increment decrement.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>IList&lt;ToolIncrementDecrementModel&gt;.</returns>
        IList<ToolIncrementDecrementModel> ReportToolIncrementDecrement(DateTime fromDate, DateTime toDate,
            string departmentId, string inventoryItemId);
        /// <summary>
        /// Gets the report S26 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryItemCategoryId">The inventory item category identifier.</param>
        /// <returns>IList&lt;S26HModel&gt;.</returns>
        IList<S26HModel> GetReportS26H(DateTime fromDate, DateTime toDate, string inventoryItemCategoryId, string inventoryItemIds, int amountType, string currencyCode);

        /// <summary>
        /// Gets the minutes inventory tool.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="minutesEuqalBook">if set to <c>true</c> [minutes euqal book].</param>
        /// <param name="inventoryCategoryId">The inventory category identifier.</param>
        /// <param name="sumInventoryCategory">if set to <c>true</c> [sum inventory category].</param>
        /// <returns>IList&lt;MinutesInventoryToolModel&gt;.</returns>
        IList<MinutesInventoryToolModel> GetMinutesInventoryTool(DateTime fromDate, DateTime toDate, string departmentId, bool minutesEuqalBook, string inventoryCategoryId, bool sumInventoryCategory);

        #endregion

        #region FixedAsset Report
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
        /// <returns>IList&lt;FixedAssetS24HModel&gt;.</returns>
        IList<FixedAssetS24HModel> GetFixedAssetS24H(string fromDate, string toDate, int usePurpose, string departmentId, string fixedAssetCategoryId, int fixedAssetCategoryGrade, bool printByCondition, bool printFixedAssetOpening, bool printFixedAssetIncrementInYear, bool printFixedAssetNotIncrement, string listFixedAssetID, int amountType, string currencyCode);

        /// <summary>
        /// Reports the inventory fixed asset entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isPrintBookQuantity">if set to <c>true</c> [is print book quantity].</param>
        /// <returns></returns>
        IList<InventoryFixedAssetModel> ReportInventoryFixedAssetEntities(DateTime fromDate, DateTime toDate,
            bool isPrintBookQuantity);


        IList<S26HModel> GetReportFixedAssetS26H(DateTime fromDate, DateTime toDate, string departmentId,
         string inventoryItemCategoryId, int amountType, string currencyCode);
        /// <summary>
        /// Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="decreaseReasonId">The decrease reason identifier.</param>
        /// <returns></returns>
        IList<FixedAssetDecreaseModel> ReportFixedAssetDecreaseListEntities(DateTime fromDate, DateTime toDate,
            int decreaseReasonId);

        /// <summary>
        /// Tang giam tscd
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="decreaseReasonId"></param>
        /// <returns></returns>
        IList<FixedAssetIncreaseDecreaseModel> ReportFixedAssetIncreaseDecrease(DateTime fromDate, DateTime toDate);


        /// <summary>
        /// Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="sumFixedAssetCategory">if set to <c>true</c> [sum fixed asset category].</param>
        /// <returns>IList&lt;MinutesGetCountFixedAssetModel&gt;.</returns>
        IList<MinutesGetCountFixedAssetModel> GetReportMinutesGetCountFixedAsset(DateTime fromDate, DateTime toDate,
            string departmentId, string fixedAssetCategoryId, bool sumFixedAssetCategory);

        /// <summary>
        /// Gets the C55 hd.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isDetailByFixedAsset">if set to <c>true</c> [is detail by fixed asset].</param>
        /// <returns></returns>
        IList<FixedAssetC55HDModel> GetC55HDReport(DateTime fromDate, DateTime toDate, bool isDetailByFixedAsset);

        #endregion

        #region Cash Report
        // Bảng xác nhận số dư tài khoản tiền gửi tại KBNN
        /// <summary>
        /// Gets the cash in bank confirmation balance sheet.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="BankAccount">The bank account.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList&lt;CashInBankConfirmationBalanceSheetModel&gt;.</returns>
        IList<CashInBankConfirmationBalanceSheetModel> GetCashInBankConfirmationBalanceSheet(DateTime fromDate, DateTime toDate, string BankAccount, string projectId, bool isSummaryProject);

        /// <summary>
        /// Gets the N02 SDKP DVDT t T77.
        /// </summary>
        /// <param name="dbStartdate">The database startdate.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="pBudgetSourceId">The p budget source identifier.</param>
        /// <param name="pBudgetChapterCode">The p budget chapter code.</param>
        /// <param name="pBudgetSubKindItemCode">The p budget sub kind item code.</param>
        /// <param name="pMethodDistributeId">The p method distribute identifier.</param>
        /// <param name="pBudgetSourceKind">Kind of the p budget source.</param>
        /// <param name="pBankAccount">The p bank account.</param>
        /// <param name="pSummaryBudgetSource">if set to <c>true</c> [p summary budget source].</param>
        /// <param name="pSummaryBudgetChapter">if set to <c>true</c> [p summary budget chapter].</param>
        /// <param name="pSummaryBudgetSubKindItem">if set to <c>true</c> [p summary budget sub kind item].</param>
        /// <param name="pSummaryMethodDistribute">if set to <c>true</c> [p summary method distribute].</param>
        /// <param name="pIsAdjustTemplete">if set to <c>true</c> [p is adjust templete].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsPrintAllYearAndMonth13">if set to <c>true</c> [p is print all year and month13].</param>
        /// <returns>IList&lt;N02_SDKP_DVDT_TT77Model&gt;.</returns>
        IList<N02_SDKP_DVDT_TT77Model> GetN02_SDKP_DVDT_TT77(DateTime dbStartdate, DateTime startDate,
            DateTime fromDate, DateTime toDate,
            string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId,
            string pBudgetSourceKind,
            string pBankAccount, bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem,
            bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13);
        /// <summary>
        /// Gets the N01 SDKP DVDT.
        /// </summary>
        /// <param name="dbStartdate">The database startdate.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="pBudgetSourceId">The p budget source identifier.</param>
        /// <param name="pBudgetChapterCode">The p budget chapter code.</param>
        /// <param name="pBudgetSubKindItemCode">The p budget sub kind item code.</param>
        /// <param name="pMethodDistributeId">The p method distribute identifier.</param>
        /// <param name="pBudgetSourceKind">Kind of the p budget source.</param>
        /// <param name="pSummaryBudgetSource">if set to <c>true</c> [p summary budget source].</param>
        /// <param name="pSummaryBudgetChapter">if set to <c>true</c> [p summary budget chapter].</param>
        /// <param name="pSummaryBudgetSubKindItem">if set to <c>true</c> [p summary budget sub kind item].</param>
        /// <param name="pSummaryMethodDistribute">if set to <c>true</c> [p summary method distribute].</param>
        /// <param name="pIsAdjustTemplete">if set to <c>true</c> [p is adjust templete].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsPrintAllYearAndMonth13">if set to <c>true</c> [p is print all year and month13].</param>
        /// <param name="isStateTreasury">if set to <c>true</c> [is state treasury].</param>
        /// <returns>
        /// IList&lt;N01_SDKP_DVDTModel&gt;.
        /// </returns>
        IList<N01_SDKP_DVDTModel> GetN01_SDKP_DVDT(DateTime dbStartdate, DateTime startDate,
          DateTime fromDate, DateTime toDate,
          string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId,
          string pBudgetSourceKind,
          bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem,
          bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13, bool isStateTreasury);

        #endregion

        #region Treasury Reports

        /// <summary>
        /// Gets the S52 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns>IList&lt;S52H_GL_MasterModel&gt;.</returns>
        IList<S52H_GL_MasterModel> GetS52H(DateTime startdate, DateTime fromDate, DateTime toDate,
            string accountnumber, bool issumaccount, bool groupsameitem);

        /// <summary>
        /// Gets the report S101 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>IList{B01HModel}.</returns>
        IList<S101HModel> GetReportS101H(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the report S101 h part i.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        DataSet GetReportS101HPartI(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the report S101 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        DataTable GetReportS101H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the report S101 h part ii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>
        /// IList{S101HPartIIModel}.
        /// </returns>
        IList<S101HPartIIModel> GetReportS101HPartII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,string accountNumber,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);


        /// <summary>
        /// Gets the report S104 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        IList<S104HModel> GetReportS104H(DateTime startDate, DateTime fromDate, DateTime toDate,
         string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string budgetSourceCategoryCode, string budgetItemCode, string projectCode,
         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);


        /// <summary>
        /// Gets the report S101 h part iii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>
        /// IList{S101HPartIIIModel}.
        /// </returns>
        IList<S101HPartIIIModel> GetReportS101HPartIII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,string accountNumber,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the report S102 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList{S102H1Model}.</returns>
        IList<S102H1Model> GetReportS102H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject);

        /// <summary>
        /// Gets the report S102 h2.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList{S102H2Model}.</returns>
        IList<S102H2Model> GetReportS102H2(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject);

        /// <summary>
        /// Gets the report S105 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isSameSummary">if set to <c>true</c> [is same summary].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="budgetExpenseList">The budget expense list.</param>
        /// <returns></returns>
        IList<S105H1Model> GetReportS105H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, 
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList);


        /// <summary>
        /// Gets the report S105 h2.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="isSameSummary"></param>
        /// <param name="budgetSourceCode"></param>
        /// <param name="budgetChapterCode"></param>
        /// <param name="budgetSubKindItemCode"></param>
        /// <param name="isSummaryBudgetChapter"></param>
        /// <param name="isSummaryBudgetSubKindItem"></param>
        /// <param name="budgetItemCode"></param>
        /// <returns></returns>
        IList<S105H2Model> GetReportS105H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode);

        /// <summary>
        /// S106H2
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="isSameSummary"></param>
        /// <param name="budgetSourceCode"></param>
        /// <param name="budgetChapterCode"></param>
        /// <param name="budgetSubKindItemCode"></param>
        /// <param name="isSummaryBudgetChapter"></param>
        /// <param name="isSummaryBudgetSubKindItem"></param>
        /// <param name="budgetItemCode"></param>
        /// <returns></returns>
        IList<S106H2Model> GetReportS106H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode);

        /// <summary>
        /// Gets the report S106 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isSameSummary">if set to <c>true</c> [is same summary].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="budgetExpenseList">The budget expense list.</param>
        /// <returns></returns>
        IList<S106H1Model> GetReportS106H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList);


        #endregion

        #region UserProfile
        /// <summary>
        /// Gets the user profiles.
        /// </summary>
        /// <returns></returns>
        IList<UserProfileModel> GetUserProfiles();

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        UserProfileModel GetUserProfile(string userProfileId);

        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        string UpdateUserProfile(UserProfileModel stock);

        /// <summary>
        /// Deletes the user profile.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        string DeleteUserProfile(string userProfileId);

        /// <summary>
        /// Gets the name of the user profile by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        UserProfileModel GetUserProfileByUserName(string userName);
        #endregion

        /// <summary>
        /// Gets the bu transfer detail purchases by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<BUTransferDetailPurchaselModel> GetBUTransferDetailPurchasesByRefId(string refId);

        /// <summary>
        /// Gets the name of the user feature permision entities by user profile identifier and form.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        IList<UserFeaturePermisionModel> GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(
            string userProfileId, string formName);

        #region Số dư đầu kì tài sản
        string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingAccountEntry);
        #endregion

        #region Mua TSCĐ chưa thanh toán
        IList<PUInvoiceModel> GetPUInvoicesByRefTypeId(int refTypeId);
        //string DeleteBUTransfer(string refId);
        PUInvoiceModel GetPUInvoice(string refId, bool isIncludedDetail);
        string UpdatePUInvoice(PUInvoiceModel pUInvoice);
        string DeletePUInvoice(string refId, int refType);

        DataSet GetDataSet(string storeProcedure, object[] parms);
        #endregion

        #region Tăng TSCĐ nhận bằng hiện vật
        IList<FAIncrementDecrementModel> GetFAIncrementDecrementsByRefTypeId(int refTypeId);
        string DeleteFAIncrementDecrement(string refId);
        FAIncrementDecrementModel GetFAIncrementDecrement(string refId, bool hasDetail);

        string DeleteFAAdjustment(string refId);
        #endregion

        #region Tính và phân bổ khấu hao TSCĐ

        DataTable GetAttributionDepreciationFA(DateTime fromDate, DateTime toDate, string FixedAssetId,
            int IsPeriod, int IsType);
        #endregion

        string ConvertDB(string  connectionString,string action);

        IList<ExportXmlModel> GetExportXml();
        IList<ExportXmlDetailModel> GetExportXmlDetail(string refType);

        #region Xuất khẩu báo cáo tài chính
        IList<ExportXmlBCTCModel> GetExportXmlBCTC();
        IList<ExportXmlBCTCBudgetSourceModel> GetExportXmlBCTCBudgetSource();
        string Delete_BudgetSourceMappingToExport();

        /// <summary>
        /// B01/BCQT: Báo cáo quyết toán kinh phí hoạt động
        /// </summary>
        DataSet GetReportB01BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName,
            bool isSummarySXKD);

        /// <summary>
        /// B03/BCQT: Thuyết minh báo cáo quyết toán
        /// </summary>
        DataSet GetReportB03BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// BCTC01: Báo cáo tình hình tài chính
        /// </summary>
        DataSet GetReportBCTC01_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName,
            string budgetChapterCode, bool isSummaryBudgetChapter);

        /// <summary>
        /// BCTC02: Báo cáo kết quả hoạt động
        /// </summary>
        DataSet GetReportBCTC02_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// B04/BCTC: Thuyết minh báo cáo tài chính
        /// </summary>
        DataSet GetReportBCTC04_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);


        /// <summary>
        /// B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
        /// </summary>
        DataSet GetReportB03bBCTC_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);


        /// <summary>
        /// B05/BCTC: Báo cáo tài chính mẫu đơn giản
        /// </summary>
        DataSet GetReportBCTC05_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
        /// </summary>
        DataSet GetReportF0101BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        DataSet GetReportF0102BCQTP1_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        DataSet GetReportF0102BCQTP2_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// B01/BSTT: Báo cáo bổ sung thông tin tài chính
        /// </summary>
        DataSet GetReportB01BSTT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);
        #endregion

        #region Nhóm xuất khẩu BC gửi kho bạc nhà nước

        /// <summary>
        /// B01/BCTC
        /// </summary>
        DataSet GetSumReportB01BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B02/BCTC
        /// </summary>
        DataSet GetSumReportB02BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B03a/BCTC
        /// </summary>
        DataSet GetSumReportB03aBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B03b/BCTC
        /// </summary>
        DataSet GetSumReportB03bBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B04/BCTC
        /// </summary>
        DataSet GetSumReportB04BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B01BSTT
        /// </summary>
        DataSet GetSumReportB01BSTT_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        #endregion


        /// <summary>
        /// S05H: Bảng cân đối số phát sinh
        /// </summary>
        DataSet GetReportS05H_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        

    }
}