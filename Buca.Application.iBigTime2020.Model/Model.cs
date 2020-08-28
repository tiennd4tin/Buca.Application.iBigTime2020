/***********************************************************************
 * <copyright file="Model.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014 
 * Usage:  
 * 
 * RevisionHistory: 
 * Date: 19/05/2014  Author: ThangND   Description: Thêm các region, mọi người code cho hẳn hoi chút tạo các phần mục theo chuẩn để code không bị lẫn lộn
 * Date: 30/05/2014  Author: LinhMC    Description: Thêm hàm lấy mã ID theo code của bất kỳ bảng nào phụ thuộc vào tham số truyền vào.
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Cash;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Deposit;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.FixedAsset;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.General;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Inventory;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Report;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.ExportXml;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using BuCA.Enum;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.PUInvoice;
using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.BusinessComponents.Facade;
using Buca.Application.iBigTime2020.BusinessEntities.Report.ExportXml;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.Report;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Windows.Forms;

namespace Buca.Application.iBigTime2020.Model
{
    /// <summary>
    /// </summary>
    public class Model : IModel
    {
        /// <summary>
        /// Gets the options for database information.
        /// </summary>
        /// <returns></returns>
        public List<DBOptionModel> GetOptionsForDbInfo()
        {
            var options = DBOptionClient.GetOptionsForDbInfo();
            return Mapper.FromDataTransferObjects(options).ToList();
        }

        /// <summary>
        ///     The is convert data
        ///     Biến này để xác định nếu là chuyển đổi dữ liệu từ Foxpro lên
        ///     thì không kiểm tra trùng số chứng từ, do ở Foxpro ko bắt lỗi
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is convert data]; otherwise, <c>false</c>.
        /// </value>
        public bool IsConvertData { get; set; }

        /// <summary>
        ///     Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCodeIncludeParentCode">The budget kind item code.</param>
        /// <returns></returns>
        public BudgetKindItemModel GetBudgetKindItemsByCodeIncludeParentCode(string budgetKindItemCode)
        {
            var budgetKindItem = BudgetKindItemClient.GetBudgetKindItemsByCodeIncludeParentCode(budgetKindItemCode);
            return Mapper.FromDataTransferObject(budgetKindItem);
        }

        /// <summary>
        ///     Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        public BudgetKindItemModel GetBudgetKindItemsByCode(string budgetKindItemCode)
        {
            var budgetKindItem = BudgetKindItemClient.GetBudgetKindItemsByCode(budgetKindItemCode);
            return Mapper.FromDataTransferObject(budgetKindItem);
        }

        /// <summary>
        ///     Adds the fixed asset.
        /// </summary>
        /// <param name="fixedAssetModel">The fixed asset model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddFixedAsset(FixedAssetModel fixedAssetModel)
        {
            var fixassetentity = Mapper.ToDataTransferObject(fixedAssetModel);
            var response = FixedAssetClient.InsertFixedAsset(fixassetentity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FixedAssetId;
        }

        #region AccountingObjectCategory

        /// <summary>
        ///     Gets the accounting object categories.
        /// </summary>
        /// <returns></returns>
        public IList<AccountingObjectCategoryModel> GetAccountingObjectCategories()
        {
            var accountingObjectCategory = AccountingObjectCategoryClient.GetAccountingObjectCategories();
            return Mapper.FromDataTransferObjects(accountingObjectCategory);
        }

        #endregion

        //#region ReportList

        /// <summary>
        ///     Gets the report lists.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;ReportListModel&gt;.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<ReportListModel> GetReportListsByIsActive(bool isActive,string loginName)
        {
            var reports = ReportListClient.GetReportsByIsActive(isActive, loginName);
            return Mapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListModel&gt;.</returns>
        public List<ReportListModel> GetReportsByRefType(int refType)
        {
            var reports = ReportListClient.GetReportsByRefType(refType);
            return Mapper.FromDataTransferObjects(reports);
        }

        public List<ReportListModel> GetReportListsByParentId(string parentId)
        {
            var reports = ReportListClient.GetReportListByParentId(parentId);
            return Mapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Gets the payment fixedAssetArmortizations.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<OpeningAccountEntryModel> GetOpeningAccountEntries()
        {
            var accounts = OpeningAccountEntryClient.GetOpeningAccountEntries();
            return Mapper.FromDataTransferObjects(accounts);
        }

        public IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries(string accountNumber)
        {
            var inventories = OpeningInventoryEntryClient.GetOpeningInventoryEntries(accountNumber);
            return Mapper.FromDataTransferObjects(inventories);
            //return null;
        }

        /// <summary>
        ///     Gets the opening account entry.
        /// </summary>
        /// <param name="accountNumber">The account code.</param>
        /// <returns></returns>
        public IList<OpeningAccountEntryModel> GetOpeningAccountEntriesByAccountNumber(string accountNumber)
        {
            var accounts = OpeningAccountEntryClient.GetOpeningAccountEntriesByAccountNumber(accountNumber);
            return Mapper.FromDataTransferObjects(accounts);
        }

        /// <summary>
        ///     Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public string UpdateOpeningAccountEntry(OpeningAccountEntryModel openingAccountEntry)
        {
            //var accountEntity = Mapper.ToDataTransferObject(openingAccountEntry);
            //var response = AccountClient.UpdateAccount(accountEntity);
            //if (response.Acknowledge != AcknowledgeType.Success)
            //    throw new ApplicationException(response.Message);
            // return response.AccountId;
            return "a";
            //return response.RefId;
        }

        /// <summary>
        ///     Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateOpeningAccountEntries(IList<OpeningAccountEntryModel> openingAccountEntryDetails)
        {
            var openingAccountEntriesEntity = Mapper.ToDataTransferObjects(openingAccountEntryDetails);
            var response = OpeningAccountEntryClient.UpdateOpeningAccountEntry(openingAccountEntriesEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        /// <summary>
        ///     Delete the opening account entry.
        /// </summary>
        /// <param name="accountNumber">The opening account number.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteOpeningAccountEntries(string accountNumber)
        {
            var response = OpeningAccountEntryClient.DeleteOpeningAccountEntry(accountNumber);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        ///     Gets the feature entities is parent.
        /// </summary>
        /// <returns></returns>
        public IList<FeaturesModel> GetFeaturesIsParent()
        {
            var featuresModels = FeatureClient.GetFeatureEntitiesIsParent();
            return Mapper.FromDataTransferObjects(featuresModels);
        }

        /// <summary>
        ///     Gets the feature permisions by user profile identifier and feature identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionModel> GetUserFeaturePermisionsByUserProfileIdAndFeatureId(
            string userProfileId, string featureId)
        {
            var userFeaturePermisions =
                UserFeaturePermisionClient.GetUserFeaturePermisionEntitiesByUserProfileIdAndFeatureId(userProfileId,
                    featureId);
            return Mapper.FromDataTransferObjects(userFeaturePermisions);
        }

        /// <summary>
        ///     Gets the name of the user profile by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public UserProfileModel GetUserProfileByUserName(string userName)
        {
            var userProfile = UserProfileClient.GetUserProfileByUserName(userName);
            return Mapper.AutoMapper(userProfile, new UserProfileModel());
            //return Mapper.FromDataTransferObject(userProfile);
        }

        /// <summary>
        ///     Gets the name of the user feature permision entities by user profile identifier and form.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionModel> GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(
            string userProfileId, string formName)
        {
            var userFeaturePermisions =
                UserFeaturePermisionClient.GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(userProfileId,
                    formName);
            return Mapper.FromDataTransferObjects(userFeaturePermisions);
        }

        /// <summary>
        ///     Inserts the features.
        /// </summary>
        /// <param name="features">The features.</param>
        /// <returns></returns>
        public string InsertFeatures(IList<FeaturesModel> features)
        {
            return FeatureClient.InsertFeatures(Mapper.ToDataTransferObjects(features));
        }

        #region Settlement Report

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
        public IList<B02BCQTModel> GetReportB02BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13)
        {
            var b02BCQT = SettlementReportFacade.GetReportB02BCQT(startDate, fromDate, toDate, budgetChapterCode,
                isSummaryChapter, isPrintMonth13, isAddDataMonth13);
            return ReportMapper.FromDataTransferObjects(b02BCQT);
        }

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
        public IList<B03BCQTModel> GetReportB03BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13)
        {
            var b03BCQT = SettlementReportFacade.GetReportB03BCQT(startDate, fromDate, toDate, budgetChapterCode,
                isSummaryChapter, isPrintMonth13, isAddDataMonth13);
            return ReportMapper.FromDataTransferObjects(b03BCQT);
        }
        public IList<ReportB04BCTCModel> GetB04BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B04BCTC" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.B04BCTC);
        }

        /// <summary>
        ///     Gets the report B04 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B04_BCTCModel&gt;.</returns>
        public IList<B04_BCTCModel> GetReportB04_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId)
        {
            var b04_BCTC = FinacialReportFacade.GetReportB04_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId);
            return ReportMapper.FromDataTransferObjects(b04_BCTC);
        }

        /// <summary>
        ///     Gets the report F01001 BCQT.
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
        public IList<F0101BCQTModel> GetReportF01001BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string CurrencyCode)
        {
            var f010BCQT = SettlementReportFacade.GetReportF01001BCQT(startDate, fromDate, toDate, budgetSourceCode,
                budgetChapterCode, budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                isSummaryBudgetSubKindItem, amountType, CurrencyCode);
            return ReportMapper.FromDataTransferObjects(f010BCQT);
        }


        public DataSet GetReportF0102BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, string listprojectID, int methodDistribute, bool isMethodDistribute, bool isProject)
        {
            var f0102BCQT = SettlementReportFacade.GetReportF0102BCQT(startDate, fromDate, toDate, budgetSourceCode,
                budgetChapterCode, budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                isSummaryBudgetSubKindItem, listprojectID, methodDistribute, isMethodDistribute, isProject);
            return f0102BCQT;
        }

        /// <summary>
        ///     Gets the report B01 BCQT.
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
        public DataSet GetReportB01BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string currencyCode)
        {
            var b01BCQT = SettlementReportFacade.GetReportB01BCQT(startDate, fromDate, toDate, budgetSourceCode,
                budgetChapterCode, budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                isSummaryBudgetSubKindItem, amountType, currencyCode);
            return b01BCQT;
        }

        #endregion

        #region Statics

        private static readonly BudgetExpenseFacade BudgetExpenseClient = new BudgetExpenseFacade();

        /// <summary>
        ///     The cash withdraw type facade
        /// </summary>
        private static readonly CashWithdrawTypeFacade CashWithdrawTypeFacade = new CashWithdrawTypeFacade();

        //private static readonly SalaryFacade SalaryFacadeClient = new SalaryFacade();
        /// <summary>
        ///     The budget source client
        /// </summary>
        private static readonly BudgetSourceFacade BudgetSourceClient = new BudgetSourceFacade();

        /// <summary>
        ///     The budget chapter client
        /// </summary>
        private static readonly BudgetChapterFacade BudgetChapterClient = new BudgetChapterFacade();

        /// <summary>
        /// The budget group item client
        /// </summary>
        private static readonly BudgetGroupItemFacade BudgetGroupItemClient = new BudgetGroupItemFacade();

        /// <summary>
        ///     The account client
        /// </summary>
        private static readonly AccountFacade AccountClient = new AccountFacade();

        private static readonly UserControlMainDesktopFacade UserControl = new UserControlMainDesktopFacade();

        //private static readonly BudgetCategoryFacade BudgetCategoryClient = new BudgetCategoryFacade();
        //private static readonly MergerFundFacade MergerFundClient = new MergerFundFacade();
        private static readonly AutoIDFacade AutoIDClient = new AutoIDFacade();

        /// <summary>
        ///     The department client
        /// </summary>
        private static readonly DepartmentFacade DepartmentClient = new DepartmentFacade();

        /// <summary>
        ///     The employee type client
        /// </summary>
        private static readonly EmployeeTypeFacade EmployeeTypeClient = new EmployeeTypeFacade();

        /// <summary>
        ///     The budget providence client
        /// </summary>
        private static readonly BudgetProvidenceFacade BudgetProvidenceClient = new BudgetProvidenceFacade();

        /// <summary>
        ///     The budget item client
        /// </summary>
        private static readonly BudgetItemFacade BudgetItemClient = new BudgetItemFacade();

        /// <summary>
        ///     The budget kind item client
        /// </summary>
        private static readonly BudgetKindItemFacade BudgetKindItemClient = new BudgetKindItemFacade();

        private static readonly FeatureFacade FeatureClient = new FeatureFacade();

        private static readonly UserPermisionFacade UserPermisionClient = new UserPermisionFacade();

        private static readonly FeaturePermisionFacade FeaturePermisionClient = new FeaturePermisionFacade();
        private static readonly LockFacade LockClient = new LockFacade();

        private static readonly UserFeaturePermisionFacade UserFeaturePermisionClient = new UserFeaturePermisionFacade()
            ;

        /// <summary>
        ///     The account category client
        /// </summary>
        private static readonly AccountCategoryFacade AccountCategoryClient = new AccountCategoryFacade();

        /// <summary>
        ///     The fixed asset category client
        /// </summary>
        private static readonly FixedAssetCategoryFacade FixedAssetCategoryClient = new FixedAssetCategoryFacade();

        /// <summary>
        ///     The activity client
        /// </summary>
        private static readonly ActivityFacade ActivityClient = new ActivityFacade();

        /// <summary>
        ///     The fixed asset client
        /// </summary>
        private static readonly FixedAssetFacade FixedAssetClient = new FixedAssetFacade();

        /// <summary>
        ///     The fixed asset detail accessory facade
        /// </summary>
        private static readonly FixedAssetDetailAccessoryFacade fixedAssetDetailAccessoryClient =
            new FixedAssetDetailAccessoryFacade();

        //private static readonly PayItemFacade PayItemClient = new PayItemFacade();
        //private static readonly CustomerFacade CustomerClient = new CustomerFacade();
        //private static readonly VendorFacade VendorClient = new VendorFacade();
        /// <summary>
        ///     The accounting object client
        /// </summary>
        private static readonly AccountingObjectFacade AccountingObjectClient = new AccountingObjectFacade();

        /// <summary>
        ///     The accounting object category client
        /// </summary>
        private static readonly AccountingObjectCategoryFacade AccountingObjectCategoryClient =
            new AccountingObjectCategoryFacade();

        /// <summary>
        ///     The voucher list client
        /// </summary>
        private static readonly VoucherListFacade VoucherListClient = new VoucherListFacade();

        //private static readonly EmployeeFacade EmployeeClient = new EmployeeFacade();
        /// <summary>
        ///     The currency client
        /// </summary>
        private static readonly CurrencyFacade CurrencyClient = new CurrencyFacade();

        //private static readonly PlanTemplateListFacade PlanTemplateListClient = new PlanTemplateListFacade();
        //private static readonly PlanTemplateItemFacade PlanTemplateItemClient = new PlanTemplateItemFacade();
        /// <summary>
        ///     The stock client
        /// </summary>
        private static readonly StockFacade StockClient = new StockFacade();

        /// <summary>
        ///     The bank client
        /// </summary>
        private static readonly BankFacade BankClient = new BankFacade();

        /// <summary>
        ///     The inventory item client
        /// </summary>
        private static readonly InventoryItemFacade InventoryItemClient = new InventoryItemFacade();

        /// <summary>
        ///     The inventory item category client
        /// </summary>
        private static readonly InventoryItemCategoryFacade InventoryItemCategoryClient =
            new InventoryItemCategoryFacade();

        //private static readonly CapitalAllocateFacade CapitalAllocateClient = new CapitalAllocateFacade();
        //private static readonly BankFacade BankClient = new BankFacade();
        /// <summary>
        ///     The account transfer client
        /// </summary>
        private static readonly AccountTransferFacade AccountTransferClient = new AccountTransferFacade();

        /// <summary>
        ///     The tax type client
        /// </summary>
        private static readonly TaxTypeFacade TaxTypeClient = new TaxTypeFacade();

        /// <summary>
        ///     The tax item client
        /// </summary>
        private static readonly TaxItemFacade TaxItemClient = new TaxItemFacade();

        /// <summary>
        ///     The database option client
        /// </summary>
        private static readonly DBOptionFacade DBOptionClient = new DBOptionFacade();

        /// <summary>
        ///     The report list client
        /// </summary>
        private static readonly ReportListFacade ReportListClient = new ReportListFacade();

        /// <summary>
        ///     The voucher report client
        /// </summary>
        private static readonly VoucherReportFacade VoucherReportClient = new VoucherReportFacade();

        /// <summary>
        ///     The deposit report client
        /// </summary>
        private static readonly DepositReportFacade DepositReportClient = new DepositReportFacade();

        /// <summary>
        ///     The ledger accounting client
        /// </summary>
        private static readonly ReportLedgerAccountingFacade ReportLedgerAccountingClient =
            new ReportLedgerAccountingFacade();

        private static readonly TreasuaryReportFacade TreasuaryReportClient =
            new TreasuaryReportFacade();

        //private static readonly ReportGroupFacade ReportGroupClient = new ReportGroupFacade();
        private static readonly AudittingLogFacade AudittingLogClient = new AudittingLogFacade();

        //private static readonly EstimateFacade EstimateClient = new EstimateFacade();
        /// <summary>
        ///     The ba deposit facade
        /// </summary>
        private static readonly BADepositFacade BADepositFacade = new BADepositFacade();

        private static readonly GeneralLedgerFacade GeneralLedgerClient = new GeneralLedgerFacade();

        private static readonly FixedAssetLedgerFacade FixedAssetLedgerClient = new FixedAssetLedgerFacade();

        /// <summary>
        ///     The ca receipt client
        /// </summary>
        private static readonly CAReceiptFacade CAReceiptClient = new CAReceiptFacade();

        /// <summary>
        ///     The in inward outward client
        /// </summary>
        private static readonly INInwardOutwardFacade INInwardOutwardClient = new INInwardOutwardFacade();

        /// <summary>
        ///     The ca payment client
        /// </summary>
        private static readonly CAPaymentFacade CaPaymentClient = new CAPaymentFacade();

        /// <summary>
        ///     The ba bank transfer client
        /// </summary>
        private static readonly BABankTransferFacade BABankTransferClient = new BABankTransferFacade();

        //private static readonly VoucherTypeFacade VoucherTypeClient = new VoucherTypeFacade();
        /// <summary>
        ///     The automatic business client
        /// </summary>
        private static readonly AutoBusinessFacade AutoBusinessClient = new AutoBusinessFacade();

        /// <summary>
        ///     The automatic business parallel client
        /// </summary>
        private static readonly AutoBusinessParallelFacade AutoBusinessParallelClient = new AutoBusinessParallelFacade()
            ;

        /// <summary>
        ///     The reference type client
        /// </summary>
        private static readonly RefTypeFacade RefTypeClient = new RefTypeFacade();

        /// <summary>
        ///     The project client
        /// </summary>
        private static readonly ProjectFacade ProjectClient = new ProjectFacade();

        private static readonly CapitalPlanFacade CapitalPlanClient = new CapitalPlanFacade();

        /// <summary>
        /// 
        /// </summary>
        private static readonly ContractFacade ContractClient = new ContractFacade();


        /// <summary>
        ///     The fund structure client
        /// </summary>
        private static readonly FundStructureFacade FundStructureClient = new FundStructureFacade();

        /// <summary>
        ///     The invoice form number client
        /// </summary>
        private static readonly InvoiceFormNumberFacade InvoiceFormNumberClient = new InvoiceFormNumberFacade();

        /// <summary>
        ///     The invoice form number category client
        /// </summary>
        private static readonly InvoiceTypeFacade InvoiceTypeClient = new InvoiceTypeFacade();

        private static readonly OpeningAccountEntryFacade OpeningAccountEntryClient = new OpeningAccountEntryFacade();

        private static readonly OpeningInventoryEntryFacade OpeningInventoryEntryClient =
            new OpeningInventoryEntryFacade();

        private static readonly OpeningFixedAssetEntryFacade OpeningFixedAssetEntryClient =
            new OpeningFixedAssetEntryFacade();

        /// <summary>
        ///     The budget source category client
        /// </summary>
        private static readonly BudgetSourceCategoryFacade BudgetSourceCategoryClient = new BudgetSourceCategoryFacade()
            ;

        /// <summary>
        ///     The purchase purpose client
        /// </summary>
        private static readonly PurchasePurposeFacade PurchasePurposeClient = new PurchasePurposeFacade();

        /// <summary>
        ///     The ba with draw facade
        /// </summary>
        private static readonly BAWithDrawFacade BAWithDrawFacade = new BAWithDrawFacade();
        private static readonly CAPaymentFacade CAPaymentFacade = new CAPaymentFacade();

        /// <summary>
        ///     The su increment decrement facade
        /// </summary>
        private static readonly SUIncrementDecrementFacade SUIncrementDecrementFacade = new SUIncrementDecrementFacade()
            ;

        /// <summary>
        ///     The su transfer client
        /// </summary>
        private static readonly SUTransferFacade SUTransferClient = new SUTransferFacade();

        /// <summary>
        ///     The fa increment decrement facade
        /// </summary>
        private static readonly FAIncrementDecrementFacade FAIncrementDecrementFacade = new FAIncrementDecrementFacade()
            ;

        private static readonly FAAdjustmentFacade FAAdjustmentFacade = new FAAdjustmentFacade();
        /// <summary>
        ///     The fa depreciation client
        /// </summary>
        private static readonly FADepreciationFacade FADepreciationClient = new FADepreciationFacade();

        private static readonly BUPlanWithdrawFacade BUPlanWithdrawClient = new BUPlanWithdrawFacade();
        private static readonly BUPlanReceiptFacade BUPlanReceiptClient = new BUPlanReceiptFacade();
        private static readonly BUPlanAdjustmentFacade BuPlanAdjustmentClient = new BUPlanAdjustmentFacade();
        private static readonly GLVoucherFacade GLVoucherClient = new GLVoucherFacade();
        private static readonly GLVoucherListFacade GlVoucherListClient = new GLVoucherListFacade();
        private static readonly InventoryReportFacade InventoryReportClient = new InventoryReportFacade();
        private static readonly FixedAssetReportFacade FixedAssetReportClient = new FixedAssetReportFacade();

        private static readonly ToolIncrementDecrementFacade ToolIncrementDecrementClient =
            new ToolIncrementDecrementFacade();

        private static readonly BUCommitmentRequestFacade BUCommitmentRequestClient = new BUCommitmentRequestFacade();

        private static readonly BUCommitmentAdjustmentFacade BUCommitmentAdjustmentClient =
            new BUCommitmentAdjustmentFacade();

        private static readonly OpeningCommitmentFacade OpeningCommitmentClient = new OpeningCommitmentFacade();
        private static readonly BUTransferFacade BUTransferClient = new BUTransferFacade();
        private static readonly BUVoucherListFacade BUVoucherListClient = new BUVoucherListFacade();

        private static readonly BUBudgetReserveFacade BUBudgetReserveClient = new BUBudgetReserveFacade();
        private static readonly FinacialReportFacade FinacialReportFacade = new FinacialReportFacade();
        private static readonly SettlementReportFacade SettlementReportFacade = new SettlementReportFacade();

        private static readonly OpeningSupplyEntryFacade OpeningSupplyEntryClient = new OpeningSupplyEntryFacade();
        private static readonly ReportDataTemplateFacade ReportDataTemplateClient = new ReportDataTemplateFacade();

        /// <summary>
        ///     The cash report client
        /// </summary>
        private static readonly CashReportFacade CashReportClient = new CashReportFacade();

        private static readonly GLVoucherListReportFacade GlVoucherListReportClient = new GLVoucherListReportFacade();
        private static readonly OriginalGeneralLedgerFacade OriginalGeneralLedgerClient = new OriginalGeneralLedgerFacade();
        private static readonly ConvertDBFacade ConvertDbFacade = new ConvertDBFacade();
        private static readonly ExportXmlFacade ExportXmlClient = new ExportXmlFacade();
        private static readonly CalculateClosingFacade CalculateClosingClient = new CalculateClosingFacade();
        /// <summary>
        ///     Adds RequestId, ClientTag, and AccessToken to all request types.
        /// </summary>
        /// <returns>
        ///     Fully prepared request, ready to use.
        /// </returns>
        /// <exception cref="ApplicationException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSources()
        {
            var budgetSources = BudgetSourceClient.GetBudgetSource();
            return Mapper.FromDataTransferObjects(budgetSources);
        }

        /// <summary>
        ///     Gets the budget sources for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesForComboTree(int budgetCategoryId)
        {
            throw new Exception();
        }

        /// <summary>
        ///     Gets the budget sources by fund.
        /// </summary>
        /// <returns>
        ///     IList{BudgetSourceModel}.
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesByFund()
        {
            throw new Exception();
        }

        /// <summary>
        ///     Gets the budget sources active.
        /// </summary>
        /// <returns>
        ///     IList{BudgetSourceModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesActive()
        {
            const bool isActive = true;
            var budgetSources = BudgetSourceClient.GetBudgetSourcesByIsActive(isActive);
            return Mapper.FromDataTransferObjects(budgetSources);
        }

        /// <summary>
        ///     Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesIsParent(bool isParent)
        {
            throw new Exception();
        }

        /// <summary>
        ///     Gets the budget source.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetSourceModel GetBudgetSource(string budgetCategoryId)
        {
            var budgetSource = BudgetSourceClient.GetBudgetSourceById(budgetCategoryId);
            return Mapper.FromDataTransferObject(budgetSource);
        }

        /// <summary>
        ///     Adds the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBudgetSource(BudgetSourceModel budgetSource)
        {
            var budgetSourceEntity = Mapper.ToDataTransferObject(budgetSource);
            var response = BudgetSourceClient.InsertBudgetSource(budgetSourceEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetSourceId;
        }

        /// <summary>
        ///     Updates the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetSource(BudgetSourceModel budgetSource)
        {
            var budgetSourceEntity = Mapper.ToDataTransferObject(budgetSource);
            var response = BudgetSourceClient.UpdateBudgetSource(budgetSourceEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetSourceId;
        }

        /// <summary>
        ///     Deletes the budget source.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetSource(string budgetCategoryId)
        {
            var response = BudgetSourceClient.DeleteBudgetSource(budgetCategoryId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetSourceId;
        }

        #endregion

        #region Finacial

        /// <summary>
        ///     Gets the report B01 h.
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
        public IList<B01HModel> GetReportB01H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceId,
            string budgetChapterCode, string budgetSubKindItem, int iAccountGrade, bool isSummarySource,
            bool isSummaryChapter,
            bool isSummarySubKindItem, bool pIsPrintMonth13, bool pIsAddDataMonth13,
            bool pIsPrintAccountDetailByBudgetSource,
            bool pIsPrintAccountDecided,
            int amountType,
            string currencyCode)
        {
            var b01H = FinacialReportFacade.GetReportB01H(startDate, fromDate, toDate, budgetSourceId,
                budgetChapterCode, budgetSubKindItem, iAccountGrade, isSummarySource, isSummaryChapter,
                isSummarySubKindItem, pIsPrintMonth13, pIsAddDataMonth13, pIsPrintAccountDetailByBudgetSource,
                pIsPrintAccountDecided, amountType, currencyCode);
            return ReportMapper.FromDataTransferObjects(b01H);
        }

        /// <summary>
        ///     Gets the report B01 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        public IList<B01_BCTCModel> GetReportB01_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int AmountType, string CurrencyCode)
        {
            var b01_BCTC = FinacialReportFacade.GetReportB01_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId, AmountType, CurrencyCode);
            return ReportMapper.FromDataTransferObjects(b01_BCTC);
        }

        /// <summary>
        ///     Gets the report B01 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        public IList<B02_BCTCModel> GetReportB02_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int amountType, string currencyCode)
        {
            var b02_BCTC = FinacialReportFacade.GetReportB02_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId, amountType, currencyCode);
            return ReportMapper.FromDataTransferObjects(b02_BCTC);
        }

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
        /// <returns>
        /// IList&lt;B01_BCTCModel&gt;.
        /// </returns>
        public IList<B03a_BCTCModel> GetReportB03a_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int amountType, string currencyCode)
        {
            var b01_BCTC = FinacialReportFacade.GetReportB03a_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId, amountType, currencyCode);
            return ReportMapper.FromDataTransferObjects(b01_BCTC);
        }

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
        public IList<B03b_BCTCModel> GetReportB03b_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter,int amountType, string currencyCode)
        {
            var b01_BCTC = FinacialReportFacade.GetReportB03b_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, amountType, currencyCode);
            return ReportMapper.FromDataTransferObjects(b01_BCTC);
        }


        /// <summary>
        ///     Gets the report B05 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <returns>IList&lt;B05_BCTCModel&gt;.</returns>
        public IList<B05_BCTCModel> GetReportB05_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter)
        {
            var b05_BCTC = FinacialReportFacade.GetReportB05_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter);
            return ReportMapper.FromDataTransferObjects(b05_BCTC);
        }

        #endregion

        #region OpeningFixedAssetEntry

        public IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries()
        {
            var accounts = OpeningFixedAssetEntryClient.GetOpeningFixedAssetEntries();
            return Mapper.FromDataTransferObjects(accounts);
        }

        public IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntriesByAccountNumber(string accountNumber)
        {
            var accounts = OpeningFixedAssetEntryClient.GetOpeningFixedAssetEntriesByAccountNumber(accountNumber);
            return Mapper.FromDataTransferObjects(accounts);
        }

        public string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingFixedAssetEntry)
        {
            var _openingFixedAssetEntity = Mapper.AutoMapper(openingFixedAssetEntry, new OpeningFixedAssetEntryEntity());
            var response = OpeningFixedAssetEntryClient.UpdateOpeningFixedAssetEntry(_openingFixedAssetEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntryDetails)
        {
            var openingFixedAssetEntry = Mapper.ToDataTransferObjects(openingFixedAssetEntryDetails);
            var response = OpeningFixedAssetEntryClient.UpdateOpeningFixedAssetEntry(openingFixedAssetEntry);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Gets the opening fixed asset entries.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns>IList{OpeningFixedAssetEntryModel}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries(string accountCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingAccountEntryDetails)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingAccountEntries,
            int fixedAssetId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates the opening fixed asset entries detail.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateOpeningFixedAssetEntriesDetail(IList<OpeningFixedAssetEntryModel> openingAccountEntries)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Inserts the opening fixed asset entries.
        /// </summary>
        /// <param name="openingFixedAssetEntry">The opening fixed asset entry.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntry)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteOpeningFixedAssetEntry(int departmentId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BudgetChapter

        /// <summary>
        ///     Gets the budget chapters.
        /// </summary>
        /// <returns>
        ///     IList{BudgetChapterModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetChapterModel> GetBudgetChapters()
        {
            var budgetChapters = BudgetChapterClient.GetBudgetChapters();
            return Mapper.FromDataTransferObjects(budgetChapters);
        }

        /// <summary>
        ///     Gets the budget chapters active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{BudgetChapterModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetChapterModel> GetBudgetChaptersByIsActive(bool isActive)
        {
            var budgetChapters = BudgetChapterClient.GetBudgetChaptersByIsActive(isActive);
            return Mapper.FromDataTransferObjects(budgetChapters);
        }

        /// <summary>
        ///     Gets the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>
        ///     BudgetChapterModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetChapterModel GetBudgetChapter(string budgetChapterId)
        {
            var budgetChapter = BudgetChapterClient.GetBudgetChapterById(budgetChapterId);
            return Mapper.FromDataTransferObject(budgetChapter);
        }

        /// <summary>
        ///     Adds the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBudgetChapter(BudgetChapterModel budgetChapter)
        {
            var budgetChapterEntity = Mapper.ToDataTransferObject(budgetChapter);
            var response = BudgetChapterClient.InsertBudgetChapter(budgetChapterEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetChapterId;
        }

        /// <summary>
        ///     Updates the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetChapter(BudgetChapterModel budgetChapter)
        {
            var budgetChapterEntity = Mapper.ToDataTransferObject(budgetChapter);
            var response = BudgetChapterClient.UpdateBudgetChapter(budgetChapterEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetChapterId;
        }

        /// <summary>
        ///     Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetChapter(string budgetChapterId)
        {
            var response = BudgetChapterClient.DeleteBudgetChapter(budgetChapterId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetChapterId;
        }

        #endregion

        #region CashWithdrawType

        /// <summary>
        ///     Gets the cash withdraw type model.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cash withdraw type identifier.</param>
        /// <returns></returns>
        public CashWithdrawTypeModel GetCashWithdrawTypeModel(int cashWithdrawTypeId)
        {
            var cashWithdrawType = CashWithdrawTypeFacade.GetCashWithdrawTypeEntity(cashWithdrawTypeId);
            return cashWithdrawType == null ? null : Mapper.FromDataTransferObject(cashWithdrawType);
        }

        /// <summary>
        ///     Gets the cash withdraw type models.
        /// </summary>
        /// <returns></returns>
        public IList<CashWithdrawTypeModel> GetCashWithdrawTypeModels()
        {
            var cashWithdrawTypes = CashWithdrawTypeFacade.GetCashWithdrawTypeEntities();
            return cashWithdrawTypes.Any() ? Mapper.FromDataTransferObjects(cashWithdrawTypes) : null;
        }

        #endregion

        #region BUBudgetReserve

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        public IList<BUBudgetReserveModel> GetBUBudgetReserves()
        {
            var buBudgetReserves = BUBudgetReserveClient.GetBUBudgetReserves();

            return Mapper.FromDataTransferObjects(buBudgetReserves);
        }

        /// <summary>
        ///     Gets the bu plan receipby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<BUBudgetReserveModel> GetBUBudgetReservesByRefId(string refId)
        {
            var buBudgetReserves = BUBudgetReserveClient.GetBUBudgetReservesByRefId(refId);
            return Mapper.FromDataTransferObjects(buBudgetReserves);
        }

        /// <summary>
        ///     Gets the bu plan receipby reference type identifier.
        /// </summary>
        /// <param name="refType">The reference type identifier.</param>
        /// <returns></returns>
        public IList<BUBudgetReserveModel> GetBUBudgetReservesByRefType(int refType)
        {
            var buBudgetReserves = BUBudgetReserveClient.GetBUBudgetReservesByRefType(refType);
            return Mapper.FromDataTransferObjects(buBudgetReserves);
        }

        /// <summary>
        ///     Gets the bu budget reserve by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUBudgetReserveDetail">if set to <c>true</c> [is included bu budget reserve detail].</param>
        /// <returns></returns>
        public BUBudgetReserveModel GetBUBudgetReserveByRefId(string refId, bool isIncludedBUBudgetReserveDetail)
        {
            var buBudgetReserve =
                BUBudgetReserveClient.GetBUBudgetReserveByRefId(refId, isIncludedBUBudgetReserveDetail);
            return Mapper.FromDataTransferObject(buBudgetReserve);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUBudgetReserve(BUBudgetReserveModel buBudgetReserve)
        {
            var buBudgetReserveEntity = Mapper.ToDataTransferObject(buBudgetReserve);
            var response = BUBudgetReserveClient.InsertBUBudgetReserve(buBudgetReserveEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUBudgetReserve(BUBudgetReserveModel buBudgetReserve)
        {
            var buBudgetReserveEntity = Mapper.ToDataTransferObject(buBudgetReserve);
            var response = BUBudgetReserveClient.UpdateBUBudgetReservet(buBudgetReserveEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUBudgetReserve(string refId)
        {
            var response = BUBudgetReserveClient.DeleteBUBudgetReservet(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region Account

        /// <summary>
        ///     Gets the accounts.
        /// </summary>
        /// <returns></returns>
        public IList<AccountModel> GetAccounts()
        {
            var accounts = AccountClient.GetAccounts();
            return Mapper.FromDataTransferObjects(accounts);
        }

        /// <summary>
        ///     Gets the accounts by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<AccountModel> GetAccountsByIsActive(bool isActive)
        {
            var accounts = AccountClient.GetAccountByIsActive(isActive);
            return Mapper.FromDataTransferObjects(accounts);
        }

        /// <summary>
        ///     Gets the accounts by is detail.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        public IList<AccountModel> GetAccountsByIsDetail(bool isDetail)
        {
            var accounts = AccountClient.GetAccountsIsDetail(isDetail);
            return Mapper.FromDataTransferObjects(accounts);
        }

        /// <summary>
        ///     Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public IList<AccountModel> GetAccountsForComboTree(string accountId)
        {
            var accounts = AccountClient.GetAccountsForComboTree(accountId);
            return Mapper.FromDataTransferObjects(accounts);
        }

        /// <summary>
        ///     Gets the accountby account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        public AccountModel GetAccountbyAccountNumber(string accountNumber)
        {
            var account = AccountClient.GetAccountbyAccountNumber(accountNumber);
            return Mapper.FromDataTransferObject(account);
        }


        public IList<UserControlMainDesktopModel> GetUserControlModel(int year)
        {
            var usercontrol = UserControl.GetUserControlMainDesktop(year);
            return Mapper.FromDataTransferObjects(usercontrol);
        }
        public IList<DashBoardBudgetModel> GetDashBoardBudgetModels(int year)
        {
            var dashboard = UserControl.GetDashBoardBudget(year);
            return Mapper.FromDataTransferObjects(dashboard);
        }

        public IList<DashBoardCashModel> GetDashBoardCashModels(int month, int year)
        {
            var dashboard = UserControl.GetDashBoardCash(month, year);
            return Mapper.FromDataTransferObjects(dashboard);
        }
        public IList<DashBoardAcitityModel> GetDashBoardAcitityModels(int year)
        {
            var dashboard = UserControl.GetDashBoardActivity(year);
            return Mapper.FromDataTransferObjects(dashboard);
        }
        /// <summary>
        ///     Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public AccountModel GetAccount(string accountId)
        {
            var account = AccountClient.GetAccountById(accountId);
            return Mapper.FromDataTransferObject(account);
        }

        /// <summary>
        ///     Adds the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAccount(AccountModel account)
        {
            var accountEntity = Mapper.ToDataTransferObject(account);
            var response = AccountClient.InsertAccount(accountEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountId;
        }

        /// <summary>
        ///     Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAccount(AccountModel account)
        {
            var accountEntity = Mapper.ToDataTransferObject(account);
            var response = AccountClient.UpdateAccount(accountEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountId;
        }

        /// <summary>
        ///     Deletes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAccount(string account)
        {
            var response = AccountClient.DeleteAccount(account);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountId;
        }

        #endregion

        #region AccountCategory

        /// <summary>
        ///     Gets the account categories.
        /// </summary>
        /// <returns>
        ///     IList{AccountCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountCategoryModel> GetAccountCategories()
        {
            var accountCategories = AccountCategoryClient.GetAccountCategories();
            return Mapper.FromDataTransferObjects(accountCategories);
        }

        /// <summary>
        ///     Gets the account categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{AccountCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountCategoryModel> GetAccountCategoriesByIsActive(bool isActive)
        {
            var accountCategories = AccountCategoryClient.GetAccountCategoriesByIsActive(isActive);
            return Mapper.FromDataTransferObjects(accountCategories);
        }

        /// <summary>
        ///     Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        ///     AccountCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountCategoryModel GetAccountCategory(string accountCategoryId)
        {
            var accountCategory = AccountCategoryClient.GetAccountCategoryById(accountCategoryId);
            return Mapper.FromDataTransferObject(accountCategory);
        }

        /// <summary>
        ///     Adds the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAccountCategory(AccountCategoryModel accountCategory)
        {
            var accountCategoryEntity = Mapper.ToDataTransferObject(accountCategory);
            var response = AccountCategoryClient.InsertAccountCategory(accountCategoryEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountCategoryId;
        }

        /// <summary>
        ///     Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAccountCategory(AccountCategoryModel accountCategory)
        {
            var accountCategoryEntity = Mapper.ToDataTransferObject(accountCategory);
            var response = AccountCategoryClient.UpdateAccountCategory(accountCategoryEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountCategoryId;
        }

        /// <summary>
        ///     Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAccountCategory(string accountCategoryId)
        {
            var response = AccountCategoryClient.DeleteAccountCategory(accountCategoryId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountCategoryId;
        }

        #endregion

        #region BudgetExpense

        /// <summary>
        ///     Gets the account categories.
        /// </summary>
        /// <returns>
        ///     IList{BudgetExpenseModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetExpenseModel> GetBudgetExpenses()
        {
            var budgetExpenses = BudgetExpenseClient.GetBudgetExpenses();
            return Mapper.FromDataTransferObjects(budgetExpenses);
        }

        /// <summary>
        ///     Gets the account categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{BudgetExpenseModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetExpenseModel> GetBudgetExpensesByIsActive(bool isActive)
        {
            var budgetExpenses = BudgetExpenseClient.GetBudgetExpensesByIsActive(isActive);
            return Mapper.FromDataTransferObjects(budgetExpenses);
        }

        /// <summary>
        ///     Gets the account category.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        /// <returns>
        ///     BudgetExpenseModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetExpenseModel GetBudgetExpense(string budgetExpenseId)
        {
            var budgetExpense = BudgetExpenseClient.GetBudgetExpenseById(budgetExpenseId);
            return Mapper.FromDataTransferObject(budgetExpense);
        }

        /// <summary>
        ///     Adds the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBudgetExpense(BudgetExpenseModel budgetExpense)
        {
            var budgetExpenseEntity = Mapper.ToDataTransferObject(budgetExpense);
            var response = BudgetExpenseClient.InsertBudgetExpense(budgetExpenseEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetExpenseId;
        }

        /// <summary>
        ///     Updates the account category.
        /// </summary>
        /// <param name="budgetExpense">The account category.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetExpense(BudgetExpenseModel budgetExpense)
        {
            var budgetExpenseEntity = Mapper.ToDataTransferObject(budgetExpense);
            var response = BudgetExpenseClient.UpdateBudgetExpense(budgetExpenseEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetExpenseId;
        }

        /// <summary>
        ///     Deletes the account category.
        /// </summary>
        /// <param name="budgetExpenseId">The account category identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetExpense(string budgetExpenseId)
        {
            var response = BudgetExpenseClient.DeleteBudgetExpense(budgetExpenseId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetExpenseId;
        }

        #endregion

        #region AutoID

        /// <summary>
        ///     Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public AutoIDModel GetAutoIDByRefType(int refTypeId)
        {
            var autoID = AutoIDClient.GetAutoIDByRefType(refTypeId);
            return Mapper.FromDataTransferObject(autoID);
        }

        /// <summary>
        ///     Gets the automatic ids.
        /// </summary>
        /// <returns>IList&lt;AutoIDModel&gt;.</returns>
        public IList<AutoIDModel> GetAutoIds()
        {
            var autoIds = AutoIDClient.GetAutoIDs();
            return Mapper.FromDataTransferObjects(autoIds);
        }

        /// <summary>
        ///     Updates the automatic numbers.
        /// </summary>
        /// <param name="autoIDModels">The automatic identifier models.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAutoNumbers(List<AutoIDModel> autoIDModels)
        {
            var autoIds = new List<AutoIDEntity>();
            autoIDModels.ForEach(a => autoIds.Add(Mapper.ToDataTransferObject(a)));
            var response = AutoIDClient.UpdateAutoIDs(autoIds);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoIDId;
        }

        #endregion

        #region Department

        /// <summary>
        ///     Gets the departments.
        /// </summary>
        /// <returns>
        ///     IList{DepartmentModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DepartmentModel> GetDepartments()
        {
            var departmentEntities = DepartmentClient.GetDepartmentEntities();

            return departmentEntities == null ? null : Mapper.FromDataTransferObjects(departmentEntities);
        }

        ///// <summary>
        ///// Gets the departments active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<DepartmentModel> GetDepartmentsActive()
        //{
        //    var request = PrepareRequest(new DepartmentRequest());
        //    request.LoadOptions = new[] { "Departments", "IsActive" };

        //    var response = DepartmentClient.GetDepartments(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.Departments);
        //}

        ///// <summary>
        ///// Gets the departments non active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<DepartmentModel> GetDepartmentsNonActive()
        //{
        //    var request = PrepareRequest(new DepartmentRequest());
        //    request.LoadOptions = new[] { "Departments", "NonActive" };

        //    var response = DepartmentClient.GetDepartments(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.Departments);
        //}

        /// <summary>
        ///     Gets the department by code.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <returns>DepartmentModel.</returns>
        public DepartmentModel GetDepartmentByCode(string departmentCode)
        {
            var department = DepartmentClient.GetDepartmentEntityByCode(departmentCode);
            return department == null ? null : Mapper.FromDataTransferObject(department);
        }

        /// <summary>
        ///     Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        ///     DepartmentModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public DepartmentModel GetDepartment(string departmentId)
        {
            var departmentEntity = DepartmentClient.GetDepartmentEntity(departmentId);

            return departmentEntity == null ? null : Mapper.FromDataTransferObject(departmentEntity);
        }

        /// <summary>
        ///     Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertDepartment(DepartmentModel department)
        {
            var departmentEntity = Mapper.ToDataTransferObject(department);
            var response = DepartmentClient.InsertDepartment(departmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.DepartmentId;
        }

        /// <summary>
        ///     Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateDepartment(DepartmentModel department)
        {
            var departmentEntity = Mapper.ToDataTransferObject(department);
            var response = DepartmentClient.UpdateDepartment(departmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.DepartmentId;
        }

        /// <summary>
        ///     Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteDepartment(string departmentId)
        {
            var response = DepartmentClient.DeleteDepartment(departmentId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.DepartmentId;
        }

        #endregion

        #region EmployeeType

        /// <summary>
        ///     Gets the employeeTypes.
        /// </summary>
        /// <returns>
        ///     IList{EmployeeTypeModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeTypeModel> GetEmployeeTypes()
        {
            var employeeTypeEntities = EmployeeTypeClient.GetEmployeeTypeEntities();

            return employeeTypeEntities == null ? null : Mapper.FromDataTransferObjects(employeeTypeEntities);
        }

        ///// <summary>
        ///// Gets the employeeTypes active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<EmployeeTypeModel> GetEmployeeTypesActive()
        //{
        //    var request = PrepareRequest(new EmployeeTypeRequest());
        //    request.LoadOptions = new[] { "EmployeeTypes", "IsActive" };

        //    var response = EmployeeTypeClient.GetEmployeeTypes(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.EmployeeTypes);
        //}

        ///// <summary>
        ///// Gets the employeeTypes non active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<EmployeeTypeModel> GetEmployeeTypesNonActive()
        //{
        //    var request = PrepareRequest(new EmployeeTypeRequest());
        //    request.LoadOptions = new[] { "EmployeeTypes", "NonActive" };

        //    var response = EmployeeTypeClient.GetEmployeeTypes(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.EmployeeTypes);
        //}

        /// <summary>
        ///     Gets the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns>
        ///     EmployeeTypeModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public EmployeeTypeModel GetEmployeeType(string employeeTypeId)
        {
            var employeeTypeEntity = EmployeeTypeClient.GetEmployeeTypeEntity(employeeTypeId);

            return employeeTypeEntity == null ? null : Mapper.FromDataTransferObject(employeeTypeEntity);
        }

        /// <summary>
        ///     Adds the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertEmployeeType(EmployeeTypeModel employeeType)
        {
            var employeeTypeEntity = Mapper.ToDataTransferObject(employeeType);
            var response = EmployeeTypeClient.InsertEmployeeType(employeeTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.EmployeeTypeId;
        }

        /// <summary>
        ///     Updates the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateEmployeeType(EmployeeTypeModel employeeType)
        {
            var employeeTypeEntity = Mapper.ToDataTransferObject(employeeType);
            var response = EmployeeTypeClient.UpdateEmployeeType(employeeTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.EmployeeTypeId;
        }

        /// <summary>
        ///     Deletes the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteEmployeeType(string employeeTypeId)
        {
            var response = EmployeeTypeClient.DeleteEmployeeType(employeeTypeId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EmployeeTypeId;
        }

        #endregion

        #region BudgetProvidence

        /// <summary>
        ///     Gets the budgetProvidences.
        /// </summary>
        /// <returns>
        ///     IList{BudgetProvidenceModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetProvidenceModel> GetBudgetProvidences()
        {
            var budgetProvidenceEntities = BudgetProvidenceClient.GetBudgetProvidenceEntities();

            return budgetProvidenceEntities == null ? null : Mapper.FromDataTransferObjects(budgetProvidenceEntities);
        }

        ///// <summary>
        ///// Gets the budgetProvidences active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<BudgetProvidenceModel> GetBudgetProvidencesActive()
        //{
        //    var request = PrepareRequest(new BudgetProvidenceRequest());
        //    request.LoadOptions = new[] { "BudgetProvidences", "IsActive" };

        //    var response = BudgetProvidenceClient.GetBudgetProvidences(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.BudgetProvidences);
        //}

        ///// <summary>
        ///// Gets the budgetProvidences non active.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.ApplicationException"></exception>
        //public IList<BudgetProvidenceModel> GetBudgetProvidencesNonActive()
        //{
        //    var request = PrepareRequest(new BudgetProvidenceRequest());
        //    request.LoadOptions = new[] { "BudgetProvidences", "NonActive" };

        //    var response = BudgetProvidenceClient.GetBudgetProvidences(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.BudgetProvidences);
        //}

        /// <summary>
        ///     Gets the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns>
        ///     BudgetProvidenceModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetProvidenceModel GetBudgetProvidence(string budgetProvidenceId)
        {
            var budgetProvidenceEntity = BudgetProvidenceClient.GetBudgetProvidenceEntity(budgetProvidenceId);

            return budgetProvidenceEntity == null ? null : Mapper.FromDataTransferObject(budgetProvidenceEntity);
        }

        /// <summary>
        ///     Adds the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBudgetProvidence(BudgetProvidenceModel budgetProvidence)
        {
            var budgetProvidenceEntity = Mapper.ToDataTransferObject(budgetProvidence);
            var response = BudgetProvidenceClient.InsertBudgetProvidence(budgetProvidenceEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetProvidenceId;
        }

        /// <summary>
        ///     Updates the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidence">The budgetProvidence.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetProvidence(BudgetProvidenceModel budgetProvidence)
        {
            var budgetProvidenceEntity = Mapper.ToDataTransferObject(budgetProvidence);
            var response = BudgetProvidenceClient.UpdateBudgetProvidence(budgetProvidenceEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetProvidenceId;
        }

        /// <summary>
        ///     Deletes the budgetProvidence.
        /// </summary>
        /// <param name="budgetProvidenceId">The budgetProvidence identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetProvidence(string budgetProvidenceId)
        {
            var response = BudgetProvidenceClient.DeleteBudgetProvidence(budgetProvidenceId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetProvidenceId;
        }

        #endregion

        #region BudgetItem

        /// <summary>
        ///     Gets the budget items.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItems()
        {
            var budgetItems = BudgetItemClient.GetBudgetItems();
            return Mapper.FromDataTransferObjects(budgetItems);
        }

        /// <summary>
        ///     Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<BudgetItemModel> GetBudgetItemsByIsActive(bool isActive)
        {
            var budgetItems = BudgetItemClient.GetBudgetItemsByIsActive(isActive);
            return Mapper.FromDataTransferObjects(budgetItems);
        }

        /// <summary>
        ///     Gets the budget items.
        /// </summary>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <returns></returns>
        public BudgetItemModel GetBudgetItemByCode(string budgetItemCode)
        {
            var budgetItems = BudgetItemClient.GetBudgetItemByCode(budgetItemCode);
            return Mapper.FromDataTransferObject(budgetItems);
        }

        /// <summary>
        ///     Gets the bud
        ///     get items by group.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByGroup()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by group item.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByGroupItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by kind item.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByKindItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by item.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by budget item receipt.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByReceipt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items capital allocate.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsCapitalAllocate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items pay voucher.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsPayVoucher()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by receipt for estimate.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByReceiptForEstimate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by budget item payment.
        /// </summary>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByPayment()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by budget item payment.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByPaymentForEstimate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the budget items by payment.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemAndSubItem(int budgetItemType, bool isActive)
        {
            var budgetItems = BudgetItemClient.GetBudgetItemsByBudgetItemType(budgetItemType, isActive);

            return Mapper.FromDataTransferObjects(budgetItems);
        }

        /// <summary>
        ///     Gets the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        ///     BudgetItemModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetItemModel GetBudgetItem(string budgetItemId)
        {
            var budgetItem = BudgetItemClient.GetBudgetItemById(budgetItemId);

            return Mapper.FromDataTransferObject(budgetItem);
        }

        /// <summary>
        ///     Adds the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBudgetItem(BudgetItemModel budgetItem)
        {
            var budgetItemEntity = Mapper.ToDataTransferObject(budgetItem);
            var response = BudgetItemClient.InsertBudgetItem(budgetItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetItemId;
        }

        /// <summary>
        ///     Updates the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetItem(BudgetItemModel budgetItem)
        {
            var budgetItemEntity = Mapper.ToDataTransferObject(budgetItem);
            var response = BudgetItemClient.UpdateBudgetItem(budgetItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetItemId;
        }

        /// <summary>
        ///     Deletes the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetItem(string budgetItemId)
        {
            var response = BudgetItemClient.DeleteBudgetItem(budgetItemId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetItemId;
        }

        #endregion

        #region BudgetGroupItem
        /// <summary>
        /// Gets the budget group items.
        /// </summary>
        /// <returns></returns>
        public IList<BudgetGroupItemModel> GetBudgetGroupItems()
        {
            var budetgGroupItems = BudgetGroupItemClient.GetBudgetGroupItems();
            return Mapper.FromDataTransferObjects(budetgGroupItems);
        }
        #endregion

        #region User_Feature_Permission

        /// <summary>
        ///     Gets the features.
        /// </summary>
        /// <returns></returns>
        public IList<FeaturesModel> GetFeatures()
        {
            var Features = FeatureClient.GetFeatures();
            return Mapper.FromDataTransferObjects(Features).OrderBy(o=>o.SortOrder).ToList();
        }

        /// <summary>
        ///     Gets the user permisions.
        /// </summary>
        /// <returns></returns>
        public IList<UserPermisionModel> GetUserPermisions()
        {
            var UserPermisions = UserPermisionClient.GetUserPermisions();
            return Mapper.FromDataTransferObjects(UserPermisions);
        }


        /// <summary>
        ///     Gets the user permisions by feature.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        public IList<UserPermisionModel> GetUserPermisionsByFeature(string Feature, string UserProfileID)
        {
            var UserPermisions = UserPermisionClient.GetUserPermisionsByFeature(Feature, UserProfileID);
            return Mapper.FromDataTransferObjects(UserPermisions);
        }


        /// <summary>
        ///     Inserts the feature permision.
        /// </summary>
        /// <param name="featurePermision">The feature permision.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string InsertFeaturePermision(FeaturePermisionModel featurePermision)
        {
            var featurePermisionEntity = Mapper.ToDataTransferObject(featurePermision);
            var response = FeaturePermisionClient.InsertFeaturePermision(featurePermisionEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FeaturePermisionID;
        }

        /// <summary>
        ///     Deletes the feature permision.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string DeleteFeaturePermision(string Feature)
        {
            var response = FeaturePermisionClient.DeleteFeaturePermision(Feature);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FeaturePermisionID;
        }

        /// <summary>
        ///     Inserts the user feature permision.
        /// </summary>
        /// <param name="userFeaturePermisionModels">The user feature permision models.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string InsertUserFeaturePermision(IList<UserFeaturePermisionModel> userFeaturePermisionModels)
        {
            var userFeaturePermisionEntities = Mapper.ToDataTransferObjects(userFeaturePermisionModels);
            var response = UserFeaturePermisionClient.InsertUserFeaturePermision(userFeaturePermisionEntities);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.UserFeaturePermisionID;
        }

        /// <summary>
        ///     Deletes the user feature permision.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string DeleteUserFeaturePermision(string Feature, string UserProfileID)
        {
            var response = UserFeaturePermisionClient.DeleteUserFeaturePermision(Feature, UserProfileID);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.UserFeaturePermisionID;
        }

        /// <summary>
        ///     Gets the user permision by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserPermisionModel> GetUserPermisionByFeatureId(string featureId)
        {
            var userPermisions = UserPermisionClient.GetUserPermisionByFeatureId(featureId);
            return Mapper.FromDataTransferObjects(userPermisions);
        }

        #endregion

        #region BudgetKindItem

        /// <summary>
        ///     Gets the budget items.
        /// </summary>
        /// <returns>
        ///     IList{BudgetKindItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<BudgetKindItemModel> GetBudgetKindItems()
        {
            var budgetKindItems = BudgetKindItemClient.GetBudgetKindItems();
            return Mapper.FromDataTransferObjects(budgetKindItems);
        }

        /// <summary>
        ///     Gets the budget items by receipt.
        /// </summary>
        /// <returns>
        ///     IList{BudgetKindItemModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<BudgetKindItemModel> GetBudgetKindItemsByActive()
        {
            var budgetKindItems = BudgetKindItemClient.GetBudgetKindItemsByIsActive(true);
            return Mapper.FromDataTransferObjects(budgetKindItems);
        }

        /// <summary>
        ///     Gets the budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        ///     BudgetKindItemModel.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public BudgetKindItemModel GetBudgetKindItem(string budgetKindItemId)
        {
            var budgetKindItems = BudgetKindItemClient.GetBudgetKindItemById(budgetKindItemId);
            return Mapper.FromDataTransferObject(budgetKindItems);
        }

        /// <summary>
        ///     Adds the budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public string AddBudgetKindItem(BudgetKindItemModel budgetKindItem)
        {
            var budgetKindItemEntity = Mapper.ToDataTransferObject(budgetKindItem);
            var response = BudgetKindItemClient.InsertBudgetKindItem(budgetKindItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetKindItemId;
        }

        /// <summary>
        ///     Updates the budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateBudgetKindItem(BudgetKindItemModel budgetKindItem)
        {
            var budgetKindItemEntity = Mapper.ToDataTransferObject(budgetKindItem);
            var response = BudgetKindItemClient.UpdateBudgetKindItem(budgetKindItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetKindItemId;
        }

        /// <summary>
        ///     Deletes the budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetKindItem(string budgetKindItemId)
        {
            var response = BudgetKindItemClient.DeleteBudgetKindItem(budgetKindItemId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetKindItemId;
        }

        #endregion

        #region FixedAssetCategory

        ///// <summary>
        ///// Gets the fixed asset category.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Gets the fixed asset categories.
        /// </summary>
        /// <returns></returns>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategories()
        {
            var fixedAssetCategories = FixedAssetCategoryClient.GetFixedAssetCategories();
            return Mapper.FromDataTransferObjects(fixedAssetCategories);
        }

        /// <summary>
        ///     Gets the fixed asset categories combo check.
        /// </summary>
        /// <returns></returns>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesComboCheck()
        {
            //var request = PrepareRequest(new FixedAssetCategoryRequest());
            //request.LoadOptions = new[] { "FixedAssetCategorys", "ForComboCheck" };
            //var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            //if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            //return Mapper.FromDataTransferObjects(response.FixedAssetCategories);
            return null;
        }

        ///// <summary>
        ///// Gets the fixed asset categorys for combo tree.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Gets the fixed asset categories for combo tree.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId)
        {
            //var request = PrepareRequest(new FixedAssetCategoryRequest());
            //request.LoadOptions = new[] { "FixedAssetCategorys", "IsActive", "ForComboTree" };
            //request.FixedAssetCategoryId = fixedAssetCategoryId;

            //var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            //if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            //return Mapper.FromDataTransferObjects(response.FixedAssetCategories);
            return null;
        }

        ///// <summary>
        ///// Gets the fixed asset categorys active.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetCategoryModel}.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Gets the fixed asset categories active.
        /// </summary>
        /// <returns></returns>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesActive()
        {
            //var request = PrepareRequest(new FixedAssetCategoryRequest());
            //request.LoadOptions = new[] { "FixedAssetCategorys", "IsActive" };

            //var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            //if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            //return Mapper.FromDataTransferObjects(response.FixedAssetCategories);
            return null;
        }

        ///// <summary>
        ///// Gets the fixed asset category by identifier.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// FixedAssetCategoryModel.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Gets the fixed asset category by identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public FixedAssetCategoryModel GetFixedAssetCategoryById(string fixedAssetCategoryId)
        {
            var response = FixedAssetCategoryClient.GetFixedAssetCategoryId(fixedAssetCategoryId);
            return Mapper.FromDataTransferObject(response);
        }

        ///// <summary>
        ///// Adds the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Inserts the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory)
        {
            //var request = PrepareRequest(new FixedAssetCategoryRequest());
            //request.Action = PersistType.Insert;
            var request = Mapper.ToDataTransferObject(fixedAssetCategory);

            var response = FixedAssetCategoryClient.InsertFixedAssetCategory(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.fixedAssetCategoryId;
            //return 0;
        }

        ///// <summary>
        ///// Updates the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategory">The fixed asset category.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Updates the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory)
        {
            //var request = PrepareRequest(new FixedAssetCategoryRequest());
            //request.Action = PersistType.Update;
            var request = Mapper.ToDataTransferObject(fixedAssetCategory);

            var response = FixedAssetCategoryClient.UpdateFixedAssetCategory(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.fixedAssetCategoryId;
        }

        ///// <summary>
        ///// Deletes the fixed asset category.
        ///// </summary>
        ///// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        ///// <returns>
        ///// System.Int32.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Deletes the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteFixedAssetCategory(string fixedAssetCategoryId)
        {
            var response = FixedAssetCategoryClient.DeleteFixedAssetCategory(fixedAssetCategoryId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.fixedAssetCategoryId;
        }

        #endregion

        #region FixedAsset

        ///// <summary>
        ///// Gets the fixed asset.
        ///// </summary>
        ///// <returns>
        ///// IList{FixedAssetModel}.
        ///// </returns>
        ///// <exception cref="System.ApplicationException"></exception>
        /// <summary>
        ///     Gets the fixed assets.
        /// </summary>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssets()
        {
            var fixedAsset = FixedAssetClient.GetFixedAssets();
            return Mapper.FromDataTransferObjects(fixedAsset);
        }

        /// <summary>
        ///     Gets the fixed assets active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssetsActive(bool isActive)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetsActive();
            return Mapper.FromDataTransferObjects(fixedAsset);
        }
        public IList<FixedAssetModel> GetFixedAssetsActiveDecre(bool isActive, string refId)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetsActiveDecre(isActive, refId);
            return Mapper.FromDataTransferObjects(fixedAsset);
        }
        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssetsForDecrement(bool isActive, DateTime refDate)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetsForDecrement(isActive, refDate);
            return Mapper.FromDataTransferObjects(fixedAsset);
        }

        /// <summary>
        /// Gets the fixed assets by increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssetsByIncrement(string fixedAssetId)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetsByIncrement(fixedAssetId);
            return Mapper.FromDataTransferObjects(fixedAsset);
        }

        /// <summary>
        /// Gets the fixed assets for adjustment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssetsForAdjustment(string fixedAssetId, DateTime postedDate, int refType, bool isForceGetOnLedger)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetsForAdjustment(fixedAssetId, postedDate, refType, isForceGetOnLedger);
            return Mapper.FromDataTransferObjects(fixedAsset);
        }

        /// <summary>
        ///     Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedassetid">The fixedassetid.</param>
        /// <returns></returns>
        public FixedAssetModel GetFixedAssetById(string fixedassetid)
        {
            var fixedAsset = FixedAssetClient.GetFixedAssetByAssetid(fixedassetid);
            return Mapper.FromDataTransferObject(fixedAsset);
        }

        /// <summary>
        ///     Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateFixedAsset(FixedAssetModel fixedAsset, DateTime systemDate)
        {
            var fixassetentity = Mapper.ToDataTransferObject(fixedAsset);
            var response = FixedAssetClient.UpdateFixedAsset(fixassetentity, systemDate);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FixedAssetId;
        }

        /// <summary>
        ///     Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteFixedAsset(string fixedAssetId, DateTime systemDate)
        {
            var response = FixedAssetClient.DeleteFixedAsset(fixedAssetId, systemDate);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }

        #endregion

        #region AccountingObject

        /// <summary>
        ///     Gets the account categories.
        /// </summary>
        /// <returns>
        ///     IList{AccountCategoryModel}.
        /// </returns>
        public IList<AccountingObjectModel> GetAccountingObjects()
        {
            var accountingObject = AccountingObjectClient.GetAccountingObjects();
            return Mapper.FromDataTransferObjects(accountingObject);
        }

        /// <summary>
        ///     Gets the account categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{AccountCategoryModel}.
        /// </returns>
        /// s
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountingObjectModel> GetAccountingObjectsByIsActive(bool isActive)
        {
            var accountCategories = AccountingObjectClient.GetAccountObjectByIsActive(isActive);
            return Mapper.FromDataTransferObjects(accountCategories);
        }

        public IList<AccountingObjectModel> GetAccountingObjectsByDepartment(string departmentid)
        {
            var accountCategories = AccountingObjectClient.GetAccountObjectByDepartmentId(departmentid);
            return Mapper.FromDataTransferObjects(accountCategories);
        }

        /// <summary>
        ///     Gets the account category.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns>
        ///     AccountCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountingObjectModel GetAccountingObject(string accountingObjectId)
        {
            var accountingObject = AccountingObjectClient.GetAccountingObjectById(accountingObjectId);
            return Mapper.FromDataTransferObject(accountingObject);
        }

        /// <summary>
        ///     Gets the accounting objects by accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        /// <returns></returns>
        public IList<AccountingObjectModel> GetAccountingObjectsByAccountingObjectCategoryId(
            string accountingObjectCategoryId)
        {
            var accountingObject =
                AccountingObjectClient.GetAccountingObjectsByAccountingObjectCategoryId(accountingObjectCategoryId);
            return Mapper.FromDataTransferObjects(accountingObject);
        }

        /// <summary>
        ///     Gets the accounting objects by is employee.
        /// </summary>
        /// <param name="isEmployee">if set to <c>true</c> [is employee].</param>
        /// <returns>
        ///     IList&lt;AccountingObjectModel&gt;.
        /// </returns>
        public IList<AccountingObjectModel> GetAccountingObjectsByIsEmployee(bool isEmployee)
        {
            var accountingObject = AccountingObjectClient.GetAccountingObjectsByIsEmployee(isEmployee);
            return Mapper.FromDataTransferObjects(accountingObject);
        }


        /// <summary>
        ///     Gets the accounting objects by is customer vendor.
        /// </summary>
        /// <param name="isCustomerVendor">if set to <c>true</c> [is customer vendor].</param>
        /// <returns>
        ///     IList&lt;AccountingObjectModel&gt;.
        /// </returns>
        public IList<AccountingObjectModel> GetAccountingObjectsByIsCustomerVendor(bool isCustomerVendor)
        {
            var accountingObject = AccountingObjectClient.GetAccountingObjectsByIsCustomerVendor(isCustomerVendor);
            return Mapper.FromDataTransferObjects(accountingObject);
        }

        /// <summary>
        ///     Adds the account category.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAccountingObject(AccountingObjectModel accountingObject)
        {
            var accountingObjectEntity = Mapper.ToDataTransferObject(accountingObject);
            var response = AccountingObjectClient.InsertAccountObject(accountingObjectEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountingObjectId;
        }

        /// <summary>
        ///     Updates the account category.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAccountingObject(AccountingObjectModel accountingObject)
        {
            var accountingObjectEntity = Mapper.ToDataTransferObject(accountingObject);
            var response = AccountingObjectClient.UpdateAccountingObject(accountingObjectEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountingObjectId;
        }

        /// <summary>
        ///     Deletes the account category.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAccountingObject(string accountingObjectId)
        {
            var response = AccountingObjectClient.DeleteAccountingObject(accountingObjectId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountingObjectId;
        }

        #endregion

        #region VoucherList

        /// <summary>
        ///     Gets the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        ///     VoucherListModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public VoucherListModel GetVoucherList(string voucherListId)
        {
            var voucherLists = VoucherListClient.GetVoucherList(voucherListId);
            return Mapper.FromDataTransferObject(voucherLists);
        }

        /// <summary>
        ///     Gets the voucher lists.
        /// </summary>
        /// <returns>
        ///     IList{VoucherListModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<VoucherListModel> GetVoucherLists()
        {
            var voucherLists = VoucherListClient.GetVoucherLists();
            return Mapper.FromDataTransferObjects(voucherLists);
        }

        /// <summary>
        ///     Gets the voucher lists by active.
        /// </summary>
        /// <returns></returns>
        public IList<VoucherListModel> GetVoucherListsByActive()
        {
            var voucherLists = VoucherListClient.GetVoucherListsByActive();
            return Mapper.FromDataTransferObjects(voucherLists);
        }

        /// <summary>
        ///     Inserts the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertVoucherList(VoucherListModel voucherList)
        {
            var voucherListEntity = Mapper.ToDataTransferObject(voucherList);
            var response = VoucherListClient.InsertVoucherList(voucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VoucherListId;
        }

        /// <summary>
        ///     Updates the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateVoucherList(VoucherListModel voucherList)
        {
            var voucherListEntity = Mapper.ToDataTransferObject(voucherList);
            var response = VoucherListClient.UpdateVoucherList(voucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VoucherListId;
        }

        /// <summary>
        ///     Deletes the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteVoucherList(string voucherListId)
        {
            var response = VoucherListClient.DeleteVoucherList(voucherListId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.VoucherListId;
        }

        #region InvoiceFormNumber

        /// <summary>
        ///     <summary>
        ///         Gets the payment voucher.
        ///     </summary>
        ///     <param name="refId">The reference identifier.</param>
        ///     <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        ///     <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        ///     <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        ///     <param name="isIncludedDetailFixedAsset">if set to <c>true</c> [is included detail fixed asset].</param>
        ///     <returns>CAPaymentModel.</returns>
        ///     Gets the voucher lists.
        /// </summary>
        /// <returns>
        ///     IList{VoucherListModel}.
        /// </returns>
        public IList<InvoiceTypeModel> GetInvoiceTypies()
        {
            var invoiceTypies = InvoiceTypeClient.GetInvoiceTypies();
            return Mapper.FromDataTransferObjects(invoiceTypies);
        }

        #endregion

        #region InvoiceFormNumber

        /// <summary>
        ///     Gets the voucher list.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        ///     VoucherListModel.
        /// </returns>
        public InvoiceFormNumberModel GetInvoiceFormNumber(string invoiceFormNumberId)
        {
            var invoiceFormNumbers = InvoiceFormNumberClient.GetInvoiceFormNumber(invoiceFormNumberId);
            return Mapper.FromDataTransferObject(invoiceFormNumbers);
        }

        /// <summary>
        ///     Gets the voucher lists.
        /// </summary>
        /// <returns>
        ///     IList{VoucherListModel}.
        /// </returns>
        public IList<InvoiceFormNumberModel> GetInvoiceFormNumbers()
        {
            var invoiceFormNumbers = InvoiceFormNumberClient.GetInvoiceFormNumbers();
            return Mapper.FromDataTransferObjects(invoiceFormNumbers);
        }

        /// <summary>
        ///     Gets the voucher lists by active.
        /// </summary>
        /// <returns></returns>
        public IList<InvoiceFormNumberModel> GetInvoiceFormNumbersByActive()
        {
            var invoiceFormNumbers = InvoiceFormNumberClient.GetInvoiceFormNumbersByActive();
            return Mapper.FromDataTransferObjects(invoiceFormNumbers);
        }

        /// <summary>
        ///     Inserts the specified voucher list.
        /// </summary>
        /// <param name="invoiceFormNumber">The invoice form number.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertInvoiceFormNumber(InvoiceFormNumberModel invoiceFormNumber)
        {
            var invoiceFormNumberEntity = Mapper.ToDataTransferObject(invoiceFormNumber);
            var response = InvoiceFormNumberClient.InsertInvoiceFormNumber(invoiceFormNumberEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InvoiceFormNumberId;
        }

        /// <summary>
        ///     Updates the specified voucher list.
        /// </summary>
        /// <param name="invoiceFormNumber">The invoice form number.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateInvoiceFormNumber(InvoiceFormNumberModel invoiceFormNumber)
        {
            var invoiceFormNumberEntity = Mapper.ToDataTransferObject(invoiceFormNumber);
            var response = InvoiceFormNumberClient.UpdateInvoiceFormNumber(invoiceFormNumberEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InvoiceFormNumberId;
        }

        /// <summary>
        ///     Deletes the voucher list.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteInvoiceFormNumber(string invoiceFormNumberId)
        {
            var response = InvoiceFormNumberClient.DeleteInvoiceFormNumber(invoiceFormNumberId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InvoiceFormNumberId;
        }

        #endregion

        #endregion

        #region CAReceipt

        /// <summary>
        ///     Gets the ca receipts.
        /// </summary>
        /// <returns>
        ///     IList&lt;CAReceiptModel&gt;.
        /// </returns>
        public IList<CAReceiptModel> GetCAReceipts()
        {
            var receipts = CAReceiptClient.GetCAReceipts();
            return Mapper.FromDataTransferObjects(receipts);
        }

        public CAReceiptModel GetCAReceiptsByBUPlanWithdrawRefID(string BUPlanWithdrawRefID)
        {
            var receipts = CAReceiptClient.GetCAReceiptsByBUPlanWithdrawRefID(BUPlanWithdrawRefID);
            return Mapper.FromDataTransferObject(receipts);
        }

        /// <summary>
        ///     Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public IList<CAReceiptModel> GetCAReceiptByRefTypeId(int refTypeId)
        {
            var receips = CAReceiptClient.GetCAReceiptByRefTypeID(refTypeId);
            return Mapper.FromDataTransferObjects(receips);
        }

        /// <summary>
        ///     Gets the ca receipt by reference type identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>
        ///     IList&lt;CAReceiptModel&gt;.
        /// </returns>
        public CAReceiptModel GetReceiptVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax)
        {
            var receiptModel = CAReceiptClient.GetCAReceiptByRefId(refId, isIncludedDetail, isIncludedDetailTax);
            return Mapper.FromDataTransferObject(receiptModel);
        }


        /// <summary>
        ///     Gets the receipt voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAReceiptModel.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CAReceiptModel GetReceiptVoucher(string refId)
        {
            var receiptModel = CAReceiptClient.GetCAReceiptByRefId(refId, true);
            return Mapper.FromDataTransferObject(receiptModel);
        }

        /// <summary>
        ///     Adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>
        ///     CAReceiptResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddCAReceipt(CAReceiptModel receiptModel)
        {
            var receiptEntity = Mapper.ToDataTransferObject(receiptModel);
            var response = CAReceiptClient.InsertCAReceipt(receiptEntity, IsConvertData);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Adds the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>CAReceiptResponse.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddCAReceipt(CAReceiptModel receiptModel, bool isAutoGenerateParallel)
        {
            var receiptEntity = Mapper.ToDataTransferObject(receiptModel);
            var response = CAReceiptClient.InsertCAReceipt(receiptEntity, IsConvertData, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <returns>
        ///     CAReceiptResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateCAReceipt(CAReceiptModel receiptModel)
        {
            var receiptEntity = Mapper.ToDataTransferObject(receiptModel);
            var response = CAReceiptClient.UpdateCAReceipt(receiptEntity, IsConvertData);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ca receipt.
        /// </summary>
        /// <param name="receiptModel">The receipt model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateCAReceipt(CAReceiptModel receiptModel, bool isAutoGenerateParallel)
        {
            var receiptEntity = Mapper.ToDataTransferObject(receiptModel);
            var response = CAReceiptClient.UpdateCAReceipt(receiptEntity, IsConvertData, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ca receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAReceiptResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteCAReceipt(string refId)
        {
            var response = CAReceiptClient.DeleteCAReceipt(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }
        /// <summary>
        /// Delete the ca receipt by BUPlanWithdrawRefID
        /// </summary>
        /// <param name="BUPlanWithdrawRefID"></param>
        /// <returns></returns>

        public string DeleteCAReceiptByBUPlanWithdrawRefID(string BUPlanWithdrawRefID)
        {
            var response = CAReceiptClient.DeleteCAReceiptByBUPlanWithdrawRefID(BUPlanWithdrawRefID);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region BUCommitmentRequest

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public BUCommitmentRequestModel GetBUCommitmentRequestbyRefId(string refId)
        {
            var bUCommitmentRequest = BUCommitmentRequestClient.GetBUCommitmentRequestbyRefId(refId);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public BUCommitmentRequestModel GetBUCommitmentRequestVoucher(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest =
                BUCommitmentRequestClient.GetBUCommitmentRequestVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        public IList<BUCommitmentRequestModel> GetBUCommitmentRequest()
        {
            var bUCommitmentRequests = BUCommitmentRequestClient.GetBUCommitmentRequest();
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        public IList<BUCommitmentRequestModel> GetBUCommitmentRequest(string refTypeId)
        {
            var bUCommitmentRequests = BUCommitmentRequestClient.GetBUCommitmentRequest(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        public IList<BUCommitmentRequestModel> GetBUCommitmentRequestsByRefTypeId(int refTypeId)
        {
            var bUCommitmentRequests = BUCommitmentRequestClient.GetBUCommitmentRequestsByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUCommitmentRequest(BUCommitmentRequestModel bUCommitmentRequest)
        {
            var bUCommitmentRequestEntity = Mapper.ToDataTransferObject(bUCommitmentRequest);
            var response = BUCommitmentRequestClient.InsertBUCommitmentRequest(bUCommitmentRequestEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUCommitmentRequest(BUCommitmentRequestModel bUCommitmentRequest)
        {
            var bUCommitmentRequestEntity = Mapper.ToDataTransferObject(bUCommitmentRequest);
            var response = BUCommitmentRequestClient.UpdateBUCommitmentRequest(bUCommitmentRequestEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUCommitmentRequest(string refId)
        {
            var response = BUCommitmentRequestClient.DeleteBUCommitmentRequest(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region BUCommitmentAdjustment

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public BUCommitmentAdjustmentModel GetBUCommitmentAdjustmentbyRefId(string refId)
        {
            var bUCommitmentRequest = BUCommitmentAdjustmentClient.GetBUCommitmentAdjustmentbyRefId(refId);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentAdjustmentModel.</returns>
        public BUCommitmentAdjustmentModel GetBUCommitmentAdjustmentVoucher(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest =
                BUCommitmentAdjustmentClient.GetBUCommitmentAdjustmentVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentAdjustmentModel&gt;.</returns>
        public IList<BUCommitmentAdjustmentModel> GetBUCommitmentAdjustment()
        {
            var bUCommitmentRequests = BUCommitmentAdjustmentClient.GetBUCommitmentAdjustment();
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentModel&gt;.</returns>
        public IList<BUCommitmentAdjustmentModel> GetBUCommitmentAdjustmentsByRefTypeId(int refTypeId)
        {
            var bUCommitmentRequests = BUCommitmentAdjustmentClient.GetBUCommitmentAdjustmentsByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUCommitmentAdjustment(BUCommitmentAdjustmentModel openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObject(openingCommitment);
            var response = BUCommitmentAdjustmentClient.InsertBUCommitmentAdjustment(openingCommitmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUCommitmentAdjustment(BUCommitmentAdjustmentModel openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObject(openingCommitment);
            var response = BUCommitmentAdjustmentClient.UpdateBUCommitmentAdjustment(openingCommitmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUCommitmentAdjustment(string refId)
        {
            var response = BUCommitmentAdjustmentClient.DeleteBUCommitmentAdjustment(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }        

        #endregion

        #region OpeningCommitment

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public OpeningCommitmentModel GetOpeningCommitmentbyRefId(string refId)
        {
            var bUCommitmentRequest = OpeningCommitmentClient.GetOpeningCommitmentbyRefId(refId);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>OpeningCommitmentModel.</returns>
        public OpeningCommitmentModel GetOpeningCommitmentVoucher(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest =
                OpeningCommitmentClient.GetOpeningCommitmentVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningCommitmentModel&gt;.</returns>
        public IList<OpeningCommitmentModel> GetOpeningCommitment()
        {
            var bUCommitmentRequests = OpeningCommitmentClient.GetOpeningCommitment();
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningCommitmentModel&gt;.</returns>
        public IList<OpeningCommitmentModel> GetOpeningCommitmentsByRefTypeId(int refTypeId)
        {
            var bUCommitmentRequests = OpeningCommitmentClient.GetOpeningCommitmentsByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertOpeningCommitment(OpeningCommitmentModel openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObject(openingCommitment);
            var response = OpeningCommitmentClient.InsertOpeningCommitment(openingCommitmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateOpeningCommitment(OpeningCommitmentModel openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObject(openingCommitment);
            var response = OpeningCommitmentClient.UpdateOpeningCommitment(openingCommitmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteOpeningCommitment(string refId)
        {
            var response = OpeningCommitmentClient.DeleteOpeningCommitment(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region OpeningSupplyEntry

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public OpeningSupplyEntryModel GetOpeningSupplyEntrybyRefId(string refId)
        {
            var bUCommitmentRequest = OpeningSupplyEntryClient.GetOpeningSupplyEntrybyRefId(refId);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>OpeningSupplyEntryModel.</returns>
        public OpeningSupplyEntryModel GetOpeningSupplyEntryVoucher(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest =
                OpeningSupplyEntryClient.GetOpeningSupplyEntryVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningSupplyEntryModel&gt;.</returns>
        public IList<OpeningSupplyEntryModel> GetOpeningSupplyEntry()
        {
            var bUCommitmentRequests = OpeningSupplyEntryClient.GetOpeningSupplyEntry();
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningSupplyEntryModel&gt;.</returns>
        public IList<OpeningSupplyEntryModel> GetOpeningSupplyEntrysByRefTypeId(int refTypeId)
        {
            var bUCommitmentRequests = OpeningSupplyEntryClient.GetOpeningSupplyEntrysByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertOpeningSupplyEntry(OpeningSupplyEntryModel openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObject(openingCommitment);
            var response = OpeningSupplyEntryClient.InsertOpeningSupplyEntry(openingCommitmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryModel> openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObjects(openingCommitment);

            var response = OpeningSupplyEntryClient.UpdateOpeningSupplyEntry(openingCommitmentEntity);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string UpdateOpeningInventoryEntry(IList<OpeningInventoryEntryModel> openingInventoryEntries,
            string accountNumber)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObjects(openingInventoryEntries);

            var response =
                OpeningInventoryEntryClient.UpdateOpeningInventoryEntry(openingCommitmentEntity, accountNumber);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Xóa hết dòng tại số dư đầu kỳ với tài khoản 152(vật tư)
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public string DeleteAllRowInGridOpenInventoryEntry(string accountNumber)
        {
            var response =
                OpeningInventoryEntryClient.DeleteAllRowInGridOpenInventoryEntry(accountNumber);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteOpeningSupplyEntry(string refId)
        {
            var response = OpeningSupplyEntryClient.DeleteOpeningSupplyEntry(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region BUVoucherList

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="includeDetail">if set to <c>true</c> [include detail].</param>
        /// <param name="includeDetailParallel">if set to <c>true</c> [include detail parallel].</param>
        /// <param name="includeDetailTransfer">if set to <c>true</c> [include detail transfer].</param>
        /// <returns>
        ///     BUCommitmentRequestModel.
        /// </returns>
        public BUVoucherListModel GetBUVoucherList(string refId, bool includeDetail, bool includeDetailParallel,
            bool includeDetailTransfer)
        {
            var bUVoucherList = BUVoucherListClient.GetBUVoucherListEntity(refId, includeDetail, includeDetailParallel,
                includeDetailTransfer);
            return Mapper.FromDataTransferObject(bUVoucherList);
        }

        /// <summary>
        ///     Checks the bu voucher list reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUVoucherListModel GetBUVoucherListByRefNo(string refNo)
        {
            var bUVoucherList = BUVoucherListClient.GetBUVoucherListByRefNo(refNo);
            return Mapper.FromDataTransferObject(bUVoucherList);
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>
        ///     List&lt;BUCommitmentRequestModel&gt;.
        /// </returns>
        public IList<BUVoucherListModel> GetBUVoucherList()
        {
            var bUVoucherLists = BUVoucherListClient.GetBUVoucherListEntities();
            return Mapper.FromDataTransferObjects(bUVoucherLists);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List&lt;BUCommitmentRequestModel&gt;.
        /// </returns>
        public IList<BUVoucherListModel> GetBUVoucherListsByRefTypeId(int refTypeId)
        {
            var bUVoucherLists = BUVoucherListClient.GetBUVoucherListEntitiesByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUVoucherLists);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUVoucherList">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string InsertBUVoucherList(BUVoucherListModel bUVoucherList)
        {
            var bUVoucherListEntity = Mapper.ToDataTransferObject(bUVoucherList);
            var response = BUVoucherListClient.InsertBUVoucherList(bUVoucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u transfer.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string UpdateBUVoucherList(BUVoucherListModel bUVoucherList)
        {
            var bUVoucherListEntity = Mapper.ToDataTransferObject(bUVoucherList);
            var response = BUVoucherListClient.UpdateBUVoucherList(bUVoucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBUVoucherList(string refId)
        {
            var response = BUVoucherListClient.DeleteBUVoucherList(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Gets the original general ledger not in bu voucher list detail by cash withdraw no.
        /// </summary>
        /// <param name="cashWithdrawNo">The cash withdraw no.</param>
        /// <returns></returns>
        public List<BUVoucherListDetailModel> GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(
            string cashWithdrawNo)
        {
            var bUVoucherListDetails =
                BUVoucherListClient.GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(cashWithdrawNo);
            return Mapper.FromDataTransferObjects(bUVoucherListDetails);
        }

        #endregion

        #region BUTransfer

        /// <summary>
        ///     Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        public BUTransferModel GetBUTransferbyRefId(string refId)
        {
            var bUCommitmentRequest = BUTransferClient.GetBUTransferbyRefId(refId);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        /// Gets the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="BUPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public BUTransferModel GetBUTransferByBUPlanWithdrawRefId(string buPlanWithdrawRefId)
        {
            var bUCommitmentRequest = BUTransferClient.GetBUTransferByBUPlanWithdrawRefId(buPlanWithdrawRefId)
            ;
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        /// <summary>
        ///     Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUTransferModel.</returns>
        public BUTransferModel GetBUTransferVoucher(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest = BUTransferClient.GetBUTransferVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }
        public BUTransferModel GetBUTransferVoucherFixedAccess(string refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest = BUTransferClient.CAPaymentFixedAsset(refId, isIncludedDetail);
            return Mapper.FromDataTransferObjectBU(bUCommitmentRequest);
        }
        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUTransferModel&gt;.</returns>
        public IList<BUTransferModel> GetBUTransfer()
        {
            var bUCommitmentRequests = BUTransferClient.GetBUTransfer();
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUTransferModel&gt;.</returns>
        public IList<BUTransferModel> GetBUTransfersByRefTypeId(int refTypeId)
        {
            var bUCommitmentRequests = BUTransferClient.GetBUTransfersByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUCommitmentRequests);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUTransfer(BUTransferModel bUTransfer, bool isAutoGenerateParallel)
        {
            var bUTransferEntity = Mapper.ToDataTransferObject(bUTransfer);
            var response = BUTransferClient.InsertBUTransfer(bUTransferEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUTransfer(BUTransferModel bUTransfer, bool isAutoGenerateParallel)
        {
            var bUTransferEntity = Mapper.ToDataTransferObject(bUTransfer);
            var response = BUTransferClient.UpdateBUTransfer(bUTransferEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUTransfer(string refId)
        {
            var response = BUTransferClient.DeleteBUTransfer(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Deletes the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUTransferByBUPlanWithdrawRefId(string buPlanWithdrawRefId)
        {
            var response = BUTransferClient.DeleteBUTransferByBUPlanWithdrawRefId(buPlanWithdrawRefId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region INInwardOutward

        /// <summary>
        ///     Gets the ca receipts.
        /// </summary>
        /// <returns>
        ///     IList&lt;INInwardOutwardModel&gt;.
        /// </returns>
        public IList<INInwardOutwardModel> GetINInwardOutwards()
        {
            var inwardOutwards = INInwardOutwardClient.GetINInwardOutwards();
            return Mapper.FromDataTransferObjects(inwardOutwards);
        }

        /// <summary>
        ///     Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public IList<INInwardOutwardModel> GetINInwardOutwardByRefTypeId(int refTypeId)
        {
            var inwardOutwards = INInwardOutwardClient.GetINInwardOutwardByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(inwardOutwards);
        }

        /// <summary>
        ///     Gets the ca receipt by reference type identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>
        ///     IList&lt;INInwardOutwardModel&gt;.
        /// </returns>
        public INInwardOutwardModel GetINInwardOutward(string refId, bool isIncludedDetail, bool isIncludeDetailParallel)
        {
            var inwardOutwards = INInwardOutwardClient.GetINInwardOutwardByRefId(refId, isIncludedDetail, isIncludeDetailParallel);
            return Mapper.FromDataTransferObject(inwardOutwards);
        }

        /// <summary>
        ///     Gets the receipt voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     INInwardOutwardModel.
        /// </returns>
        public INInwardOutwardModel GetInwardOutwardVoucher(string refId)
        {
            var inwardOutwards = INInwardOutwardClient.GetINInwardOutwardByRefId(refId, false,false);
            return Mapper.FromDataTransferObject(inwardOutwards);
        }

        /// <summary>
        ///     Adds the ca receipt.
        /// </summary> 
        /// <param name="inwardOutwardModel">The inward outward model.</param>
        /// <returns>
        ///     INInwardOutwardResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddINInwardOutward(INInwardOutwardModel inwardOutwardModel)
        {
            var inwardOutwardEntity = Mapper.ToDataTransferObject(inwardOutwardModel);
            var response = INInwardOutwardClient.InsertINInwardOutward(inwardOutwardEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        /// <summary>
        ///     Adds the receiptModel.
        /// </summary>
        /// <param name="receiptModel">The receipt Model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string AddINInwardOutward(INInwardOutwardModel inwardOutwardModel, bool isAutoGenerateParallel,bool IsOutwardNegativeStock)
        {
            var inwardOutwardEntity = Mapper.ToDataTransferObject(inwardOutwardModel);
            var response = INInwardOutwardClient.InsertINInwardOutward(inwardOutwardEntity, IsConvertData, isAutoGenerateParallel, IsOutwardNegativeStock);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        /// <summary>
        ///     Update the receiptModel.
        /// </summary>
        /// <param name="receiptModel">The receipt Model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateINInwardOutward(INInwardOutwardModel inwardOutwardModel, bool isAutoGenerateParallel,bool IsOutwardNegativeStock)
        {
            var inwardOutwardEntity = Mapper.ToDataTransferObject(inwardOutwardModel);
            var response = INInwardOutwardClient.UpdateINInwardOutward(inwardOutwardEntity, isAutoGenerateParallel, IsOutwardNegativeStock);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        /// <summary>
        ///     Updates the ca receipt.
        /// </summary>
        /// <param name="inwardOutwardModel">The inward outward model.</param>
        /// <returns>
        ///     INInwardOutwardResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateINInwardOutward(INInwardOutwardModel inwardOutwardModel)
        {
            var inwardOutwardEntity = Mapper.ToDataTransferObject(inwardOutwardModel);
            var response = INInwardOutwardClient.UpdateINInwardOutward(inwardOutwardEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ca receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     INInwardOutwardResponse.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteINInwardOutward(string refId)
        {
            var response = INInwardOutwardClient.DeleteINInwardOutward(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public bool CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem)
        {
            return INInwardOutwardClient.CheckExistVoucher(fromDate, toDate, inventoryItem);
        }

        #endregion

        #region BUPlanWithdraw

        /// <summary>
        ///     Gets the bu plan withdraws.
        /// </summary>
        /// <returns>List&lt;BUPlanWithdrawModel&gt;.</returns>
        public IList<BUPlanWithdrawModel> GetBUPlanWithdraws()
        {
            var bUPlanWithdraw = BUPlanWithdrawClient.GetBUPlanWithdraws();
            return Mapper.FromDataTransferObjects(bUPlanWithdraw);
        }

        /// <summary>
        ///     Gets the bu plan withdraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUPlanWithdrawModel.</returns>
        public BUPlanWithdrawModel GetBUPlanWithdrawByRefNo(string refNo)
        {
            var bUPlanWithdraw = BUPlanWithdrawClient.GetBUPlanWithdrawByRefNo(refNo);
            return Mapper.FromDataTransferObject(bUPlanWithdraw);
        }

        /// <summary>
        ///     Gets the bu plan withdraw by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawModel&gt;.</returns>
        public IList<BUPlanWithdrawModel> GetBUPlanWithdrawByRefTypeId(int refTypeId)
        {
            var bUPlanWithdraw = BUPlanWithdrawClient.GetBUPlanWithdrawByRefTypeId(refTypeId);
            return Mapper.FromDataTransferObjects(bUPlanWithdraw);
        }

        /// <summary>
        ///     Gets the bu plan withdraw by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUPlanWithdrawDetail">if set to <c>true</c> [is included bu plan withdraw detail].</param>
        /// <returns>BUPlanWithdrawModel.</returns>
        public BUPlanWithdrawModel GetBUPlanWithdrawByRefId(string refId, bool isIncludedBUPlanWithdrawDetail)
        {
            var bUPlanWithdraw = BUPlanWithdrawClient.GetBUPlanWithdrawByRefId(refId, isIncludedBUPlanWithdrawDetail);
            return Mapper.FromDataTransferObject(bUPlanWithdraw);
        }

        /// <summary>
        ///     Inserts the bu plan withdraw.
        /// </summary>
        /// <param name="planWithdrawModel">The plan withdraw model.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUPlanWithdraw(BUPlanWithdrawModel planWithdrawModel)
        {
            var planWithdrawEntity = Mapper.ToDataTransferObject(planWithdrawModel);
            var response = BUPlanWithdrawClient.InsertBUPlanWithdraw(planWithdrawEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan withdraw.
        /// </summary>
        /// <param name="planWithdrawEModel">The plan withdraw e model.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUPlanWithdraw(BUPlanWithdrawModel planWithdrawEModel)
        {
            var planWithdrawEntity = Mapper.ToDataTransferObject(planWithdrawEModel);
            var response = BUPlanWithdrawClient.UpdateBUPlanWithdraw(planWithdrawEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan withdraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUPlanWithdraw(string refId)
        {
            var response = BUPlanWithdrawClient.DeleteBUPlanWithdraw(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }
        /// <summary>
        ///     Deletes the bu plan withdraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="deleteVoucherRef">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUPlanWithdraw(string refId, bool deleteVoucherRef)
        {
            var response = BUPlanWithdrawClient.DeleteBUPlanWithdraw(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }
        #endregion

        #region CAPayment

        /// <summary>
        ///     Gets the ca payment.
        /// </summary>
        /// <returns>
        ///     IList&lt;CAPaymentModel&gt;.
        /// </returns>
        public IList<CAPaymentModel> GetCAPayment()
        {
            var payment = CaPaymentClient.GetCAPayment();
            return Mapper.FromDataTranferObjects(payment);
        }

        /// <summary>
        ///     Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList&lt;CAPaymentModel&gt;.
        /// </returns>
        public IList<CAPaymentModel> GetCAPaymentsByRefTypeId(int refTypeId)
        {
            var caPayments = CaPaymentClient.GetCAPaymentsByRefTypeId(refTypeId);
            return Mapper.FromDataTranferObjects(caPayments);
        }

        /// <summary>
        ///     Gets the payment voucher detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public CAPaymentModel GetPaymentVoucherDetailPurchase(string refId)
        {
            var paymentModel = CaPaymentClient.GetPaymentVoucherDetailPurchase(refId);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher detail fixes asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        public CAPaymentModel GetPaymentVoucherDetailFixesAsset(string refId)
        {
            var paymentModel = CaPaymentClient.GetPaymentVoucherDetailFixedAsset(refId);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public CAPaymentModel GetPaymentVoucher(string refId)
        {
            var paymentModel = CaPaymentClient.GetCAPaymentByRefId(refId, true);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax)
        {
            var paymentModel = CaPaymentClient.GetCAPaymentByRefId(refId, isIncludedDetail, isIncludedDetailTax);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax,
            bool isIncludedDetailPurchase)
        {
            var paymentModel = CaPaymentClient.GetCAPaymentByRefId(refId, isIncludedDetail, isIncludedDetailTax,
                isIncludedDetailPurchase);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <param name="isIncludedDetailFixedAsset">if set to <c>true</c> [is included detail fixed asset].</param>
        /// <returns></returns>
        public CAPaymentModel GetPaymentVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax,
            bool isIncludedDetailPurchase, bool isIncludedDetailFixedAsset)
        {
            var paymentModel = CaPaymentClient.GetCAPaymentByRefId(refId, isIncludedDetail, isIncludedDetailTax,
                isIncludedDetailPurchase, isIncludedDetailFixedAsset);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Inserts the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertCAPayment(CAPaymentModel paymentModel)
        {
            var paymentEntity = Mapper.ToDataTransferObject(paymentModel);
            var response = CaPaymentClient.InsertCAPayment(paymentEntity, IsConvertData);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Inserts the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string InsertCAPayment(CAPaymentModel paymentModel, bool isAutoGenerateParallel)
        {
            var paymentEntity = Mapper.ToDataTransferObject(paymentModel);
            var response = CaPaymentClient.InsertCAPayment(paymentEntity, IsConvertData, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateCAPayment(CAPaymentModel paymentModel)
        {
            var paymentEntity = Mapper.ToDataTransferObject(paymentModel);
            var response = CaPaymentClient.UpdateCAPayment(paymentEntity, IsConvertData);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ca payment.
        /// </summary>
        /// <param name="paymentModel">The payment model.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateCAPayment(CAPaymentModel paymentModel, bool isAutoGenerateParallel)
        {
            var paymentEntity = Mapper.ToDataTransferObject(paymentModel);
            var response = CaPaymentClient.UpdateCAPayment(paymentEntity, IsConvertData, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteCAPayment(string refId)
        {
            var response = CaPaymentClient.DeleteCAPayment(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region GLVoucher

        /// <summary>
        ///     Gets the ca payment.
        /// </summary>
        /// <returns>
        ///     IList&lt;CAPaymentModel&gt;.
        /// </returns>
        public IList<GLVoucherModel> GetGLVouchers()
        {
            var payment = GLVoucherClient.GetGLVouchers();
            return Mapper.FromDataTranferObjects(payment);
        }

        /// <summary>
        ///     Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList&lt;CAPaymentModel&gt;.
        /// </returns>
        public IList<GLVoucherModel> GetGLVouchersByRefTypeId(int refTypeId)
        {
            var caPayments = GLVoucherClient.GetGLVouchersByRefTypeId(refTypeId);
            return Mapper.FromDataTranferObjects(caPayments);
        }

        /// <summary>
        /// Gets the gl vouchers last year by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public IList<GLVoucherModel> GetGLVouchersLastYearByRefTypeId(int refTypeId)
        {
            var caPayments = GLVoucherClient.GetGLVoucherLastYearsByRefTypeId(refTypeId);
            return Mapper.FromDataTranferObjects(caPayments);
        }

        /// <summary>
        ///     Gets the payment voucher detail purchase.
        /// </summary>
        /// <summary>
        /// Gets the gl vouchers last year by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public GLVoucherModel GetGLVoucherDetail(string refId)
        {
            var paymentModel = GLVoucherClient.GetGLVoucherByRefId(refId, true, true);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher detail fixes asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentModel.</returns>
        public GLVoucherModel GetGLVoucherDetailTax(string refId)
        {
            var paymentModel = GLVoucherClient.GetGLVoucherByRefId(refId, true, true);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public GLVoucherModel GetGLVoucher(string refId)
        {
            var paymentModel = GLVoucherClient.GetGLVoucherByRefId(refId, true, true);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        ///     Gets the payment voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns>
        ///     CAPaymentModel.
        /// </returns>
        public GLVoucherModel GetGLVoucher(string refId, bool isIncludedDetail, bool isIncludedDetailTax)
        {
            var paymentModel = GLVoucherClient.GetGLVoucherByRefId(refId, isIncludedDetail, isIncludedDetailTax);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        /// Gets the gl voucher tranfer.
        /// </summary>
        /// <param name="Reftype">The reftype.</param>
        /// <param name="sysDate">The system date.</param>
        /// <param name="isIncludedDetailTax">if set to <c>true</c> [is included detail tax].</param>
        /// <returns></returns>
        public GLVoucherModel GetGLVoucherTranfer(int Reftype, DateTime sysDate, bool isIncludedDetailTax, string projectIds = null)
        {
            var paymentModel = GLVoucherClient.GetGLVoucherTransfer(Reftype, sysDate, isIncludedDetailTax, projectIds);
            return Mapper.FromDataTransferObject(paymentModel);
        }

        /// <summary>
        /// Gets the bu transfer by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        public GLVoucherModel GetGLVoucherByBUTransferRefId(string buTransferRefId)
        {
            var buTransfer = GLVoucherClient.GetGLVoucherByBUTransferRefId(buTransferRefId);
            return Mapper.FromDataTransferObject(buTransfer);
        }

        /// <summary>
        ///     Inserts the ca payment.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertGLVoucher(GLVoucherModel glVoucher)
        {
            var glVoucherEntity = Mapper.ToDataTransferObject(glVoucher);
            var response = GLVoucherClient.InsertGLVoucher(glVoucherEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Inserts the gl voucher.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string InsertGLVoucher(GLVoucherModel glVoucher, bool isAutoGenerateParallel)
        {
            var glVoucherEntity = Mapper.ToDataTransferObject(glVoucher);
            var response = GLVoucherClient.InsertGLVoucher(glVoucherEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ca payment.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateGLVoucher(GLVoucherModel glVoucher)
        {
            var glVoucherEntity = Mapper.ToDataTransferObject(glVoucher);
            var response = GLVoucherClient.UpdateGlVoucher(glVoucherEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the gl voucher.
        /// </summary>
        /// <param name="glVoucher">The gl voucher.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateGLVoucher(GLVoucherModel glVoucher, bool isAutoGenerateParallel)
        {
            var glVoucherEntity = Mapper.ToDataTransferObject(glVoucher);
            var response = GLVoucherClient.UpdateGlVoucher(glVoucherEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteGLVoucher(string refId)
        {
            var response = GLVoucherClient.DeleteGLVoucher(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public string DeleteGLVoucherByBUTransferRefId(string buTransferRefId)
        {
            var response = GLVoucherClient.DeleteGLVoucherByBUTransferRefId(buTransferRefId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region GLVoucherList

        public GLVoucherListModel GetGLVoucherListByRefId(string refId)
        {
            var glVoucherListModel = GlVoucherListClient.GetVoucherLisbyRefId(refId);
            return Mapper.FromDataTransferObject(glVoucherListModel);
        }

        public GLPaymentListModel GetGLPaymentListByRefId(string refId)
        {
            var glPaymentListModel = GlVoucherListClient.GetPaymentLisbyRefId(refId);
            return Mapper.FromDataTransferObject(glPaymentListModel);
        }

        public IList<GLVoucherListModel> GetGlVoucherList()
        {
            var glVoucherList = GlVoucherListClient.GetGLVoucherList();
            return Mapper.FromDataTranferObjects(glVoucherList);
        }

        public IList<GLPaymentListModel> GetGlPaymentList()
        {
            var glPaymentList = GlVoucherListClient.GetGLPaymentList();
            return Mapper.FromDataTranferObjects(glPaymentList);
        }

        public GLVoucherListModel GetGLVoucherListDetail(string refId)
        {
            var glVoucherListModel = GlVoucherListClient.GetVoucherLisbyRefId(refId);
            return Mapper.FromDataTransferObject(glVoucherListModel);
        }

        public IList<GLVoucherListParamaterModel> GlVoucherListParamater(int type)
        {
            var glVoucherListModel = GlVoucherListClient.GetVoucherListParamater(type);
            return Mapper.FromDataTranferObjects(glVoucherListModel);
        }

        public string InsertGLVoucherList(GLVoucherListModel glVoucherList)
        {
            var glVoucherListEntity = Mapper.ToDataTransferObject(glVoucherList);
            var response = GlVoucherListClient.InsertGLVoucherList(glVoucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string InsertGLPaymentList(GLPaymentListModel glPaymentList)
        {
            var glPaymentListEntity = Mapper.ToDataTransferObject(glPaymentList);
            var response = GlVoucherListClient.InsertGLPaymentList(glPaymentListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string UpDateGLVoucherList(GLVoucherListModel glVoucherList)
        {
            var glVoucherListEntity = Mapper.ToDataTransferObject(glVoucherList);
            var response = GlVoucherListClient.UpdateGlVoucherList(glVoucherListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string UpDateGLPaymentList(GLPaymentListModel glPaymentList)
        {
            var glPaymentListEntity = Mapper.ToDataTransferObject(glPaymentList);
            var response = GlVoucherListClient.UpdateGlPaymentList(glPaymentListEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string DeleteGLVoucherList(string refId)
        {
            var response = GlVoucherListClient.DeleteGLVoucherList(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public string DeleteGLPaymentList(string refId)
        {
            var response = GlVoucherListClient.DeleteGLPaymentList(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region Currency

        /// <summary>
        ///     Gets the currencies is main.
        /// </summary>
        /// <returns></returns>
        public IList<CurrencyModel> GetCurrenciesIsMain()
        {
            var currency = CurrencyClient.GetCurrenciesByIsMain(true);
            return Mapper.FromDataTransferObjects(currency);
        }


        /// <summary>
        ///     Gets the currencies.
        /// </summary>
        /// <returns></returns>
        public IList<CurrencyModel> GetCurrencies()
        {
            var currency = CurrencyClient.GetCurrencies();
            return Mapper.FromDataTransferObjects(currency);
        }

        /// <summary>
        ///     Gets the currencies active.
        /// </summary>
        /// <returns></returns>
        public IList<CurrencyModel> GetCurrenciesActive()
        {
            var currency = CurrencyClient.GetCurrenciesByIsActive(true);
            return Mapper.FromDataTransferObjects(currency);
        }

        /// <summary>
        ///     Gets the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns></returns>
        public CurrencyModel GetCurrency(string currencyId)
        {
            var currency = CurrencyClient.GetCurrencyById(currencyId);
            return Mapper.FromDataTransferObject(currency);
        }


        /// <summary>
        ///     Gets the currency by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public CurrencyModel GetCurrencyByCurrencyCode(string currencyCode)
        {
            var currency = CurrencyClient.GetCurrencyByCode(currencyCode);
            return Mapper.FromDataTransferObject(currency);
        }

        /// <summary>
        ///     Adds the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddCurrency(CurrencyModel currency)
        {
            var currencyEntity = Mapper.ToDataTransferObject(currency);
            var response = CurrencyClient.InsertCurrency(currencyEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CurrencyId;
        }

        /// <summary>
        ///     Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateCurrency(CurrencyModel currency)
        {
            var currencyEntity = Mapper.ToDataTransferObject(currency);
            var response = CurrencyClient.UpdateCurrency(currencyEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CurrencyId;
        }


        /// <summary>
        ///     Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteCurrency(string currencyId)
        {
            var response = CurrencyClient.DeleteCurrency(currencyId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CurrencyId;
        }

        #endregion

        #region Stock

        /// <summary>
        ///     Gets the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        ///     StockModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public StockModel GetStock(string stockId)
        {
            var stock = StockClient.GetStockById(stockId);
            return Mapper.FromDataTransferObject(stock);
        }

        /// <summary>
        ///     Getses this instance.
        /// </summary>
        /// <returns>
        ///     IList{StockModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<StockModel> GetStocks()
        {
            var stocks = StockClient.GetStocks();
            return Mapper.FromDataTransferObjects(stocks);
        }

        /// <summary>
        ///     Gets the stock by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{StockModel}.
        /// </returns>
        public IList<StockModel> GetStocksByIsActive(bool isActive)
        {
            var stocks = StockClient.GetStocksByIsActive(isActive);
            return Mapper.FromDataTransferObjects(stocks);
        }

        /// <summary>
        ///     Inserts the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertStock(StockModel stock)
        {
            var stockEntity = Mapper.ToDataTransferObject(stock);
            var response = StockClient.InsertStock(stockEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.StockId;
        }

        /// <summary>
        ///     Updates the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateStock(StockModel stock)
        {
            var stockEntity = Mapper.ToDataTransferObject(stock);
            var response = StockClient.UpdateStock(stockEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.StockId;
        }

        /// <summary>
        ///     Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteStock(string stockId)
        {
            var response = StockClient.DeleteStock(stockId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.StockId;
        }

        #endregion

        #region PurchasePurpose

        /// <summary>
        ///     Gets the specified purchasePurpose identifier.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns>
        ///     PurchasePurposeModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public PurchasePurposeModel GetPurchasePurpose(string purchasePurposeId)
        {
            var purchasePurpose = PurchasePurposeClient.GetPurchasePurposeById(purchasePurposeId);
            return Mapper.FromDataTransferObject(purchasePurpose);
        }

        /// <summary>
        ///     Getses this instance.
        /// </summary>
        /// <returns>
        ///     IList{PurchasePurposeModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PurchasePurposeModel> GetPurchasePurposes()
        {
            var purchasePurposes = PurchasePurposeClient.GetPurchasePurposes();
            return Mapper.FromDataTransferObjects(purchasePurposes);
        }

        /// <summary>
        ///     Gets the purchasePurpose by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList{PurchasePurposeModel}.
        /// </returns>
        public IList<PurchasePurposeModel> GetPurchasePurposesByIsActive(bool isActive)
        {
            var purchasePurposes = PurchasePurposeClient.GetPurchasePurposesByIsActive(isActive);
            return Mapper.FromDataTransferObjects(purchasePurposes);
        }

        /// <summary>
        ///     Inserts the specified purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertPurchasePurpose(PurchasePurposeModel purchasePurpose)
        {
            var purchasePurposeEntity = Mapper.ToDataTransferObject(purchasePurpose);
            var response = PurchasePurposeClient.InsertPurchasePurpose(purchasePurposeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.PurchasePurposeId;
        }

        /// <summary>
        ///     Updates the specified purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdatePurchasePurpose(PurchasePurposeModel purchasePurpose)
        {
            var purchasePurposeEntity = Mapper.ToDataTransferObject(purchasePurpose);
            var response = PurchasePurposeClient.UpdatePurchasePurpose(purchasePurposeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.PurchasePurposeId;
        }

        /// <summary>
        ///     Deletes the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeletePurchasePurpose(string purchasePurposeId)
        {
            var response = PurchasePurposeClient.DeletePurchasePurpose(purchasePurposeId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.PurchasePurposeId;
        }

        /// <summary>
        ///     Gets the purchase purpose model by code.
        /// </summary>
        /// <param name="purchasePurposeCode">The purchase purpose code.</param>
        /// <returns></returns>
        public PurchasePurposeModel GetPurchasePurposeByCode(string purchasePurposeCode)
        {
            var purchasePurpose = PurchasePurposeClient.GetPurchasePurposeByCode(purchasePurposeCode);
            return purchasePurpose != null ? Mapper.FromDataTransferObject(purchasePurpose) : null;
        }

        #endregion

        #region InventoryItem

        /// <summary>
        ///     Gets the inventory item.
        /// </summary>
        /// <returns>
        ///     InventoryItemModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<InventoryItemModel> GetInventoryItems()
        {
            var inventoryItems = InventoryItemClient.GetInventoryItems();
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        ///     Gets the inventory items.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList&lt;InventoryItemModel&gt;.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<InventoryItemModel> GetInventoryItemsByIsAtive(bool isActive)
        {
            var inventoryItems = InventoryItemClient.GetInventoryItemsByIsAtive(isActive);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        ///     Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>
        ///     IList&lt;InventoryItemModel&gt;.
        /// </returns>
        public IList<InventoryItemModel> GetInventoryItemsByIsTool(bool isTool)
        {
            var inventoryItems = InventoryItemClient.GetInventoryItemsByIsTool(isTool);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        ///     Gets the inventory items by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<InventoryItemModel> GetInventoryItemsByIsToolAndIsActive(bool isTool, bool isActive)
        {
            var inventoryItems = InventoryItemClient.GetInventoryItemsByIsToolAndIsActive(isTool, isActive);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        /// Gets the inventory items by is stock and is active and category code.
        /// </summary>
        /// <param name="isStock">if set to <c>true</c> [is stock].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        public IList<InventoryItemModel> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock,
            bool isActive, string inventoryCategoryCode)
        {
            var inventoryItems =
                InventoryItemClient.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive,
                    inventoryCategoryCode);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        ///     Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        ///     InventoryItemModel.
        /// </returns>
        public InventoryItemModel GetInventoryItem(string inventoryItemId)
        {
            var inventoryItem = InventoryItemClient.GetInventoryItem(inventoryItemId);
            return Mapper.FromDataTransferObject(inventoryItem);
        }

        /// <summary>
        ///     Inserts the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertInventoryItem(InventoryItemModel inventoryItem)
        {
            var inventoryItemEntity = Mapper.ToDataTransferObject(inventoryItem);
            var response = InventoryItemClient.InsertInventoryItem(inventoryItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InventoryItemId;
        }

        /// <summary>
        ///     Updates the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateInventoryItem(InventoryItemModel inventoryItem)
        {
            var inventoryItemEntity = Mapper.ToDataTransferObject(inventoryItem);
            var response = InventoryItemClient.UpdateInventoryItem(inventoryItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InventoryItemId;
        }

        /// <summary>
        ///     Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string Delete(string inventoryItemId)
        {
            var response = InventoryItemClient.DeleteInventoryItem(inventoryItemId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InventoryItemId;
        }

        /// <summary>
        ///     Gets the inventory items by inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        public IList<InventoryItemModel> GetInventoryItemsByInventoryCategoryCode(string inventoryCategoryCode)
        {
            var inventoryItems = InventoryItemClient.GetInventoryItemsByInventoryCategoryCode(inventoryCategoryCode);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        /// Gets the inventory items by inventory itemdestinations.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="RefDate">The reference date.</param>
        /// <param name="RefOrder">The reference order.</param>
        /// <param name="UnitPriceDecimalDigitNumber">The unit price decimal digit number.</param>
        /// <returns></returns>
        public IList<InventoryItemdestinationModel> GetInventoryItemsByInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber)
        {
            var inventoryItems = InventoryItemClient.GetInventoryItemsByInventoryItemdestinations(inventoryItemId, RefDate, RefOrder, UnitPriceDecimalDigitNumber);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        ///     Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        public InventoryItemModel GetUnitsInStock(string inventoryItemId, string stockId, DateTime Todate)
        {
            var inventoryItem = InventoryItemClient.GetUnitsInStock(inventoryItemId, stockId, Todate);
            return Mapper.FromDataTransferObject(inventoryItem);
        }

        /// <summary>
        ///     Calculates the outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        public string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            return InventoryItemClient.CalculateOutwardPrice(fromDate, toDate, inventoryItemId);
        }

        #endregion

        #region InventoryItemCategory

        /// <summary>
        ///     Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>
        ///     IList&lt;InventoryItemModel&gt;.
        /// </returns>
        public IList<InventoryItemCategoryModel> GetInventoryItemCategoriesByIsTool(bool isTool)
        {
            var inventoryItemCategories = InventoryItemCategoryClient.GetInventoryItemCategoriesByIsTool(isTool);
            return Mapper.FromDataTransferObjects(inventoryItemCategories);
        }

        /// <summary>
        ///     Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">The is tool.</param>
        /// <param name="isActive">The is active.</param>
        /// <returns>
        ///     System.Collections.Generic.IList&lt;
        ///     Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary.InventoryItemCategoryModel&gt;.
        /// </returns>
        public IList<InventoryItemCategoryModel> GetInventoryItemCategoriesByIsTool(bool isTool, bool isActive)
        {
            var inventoryItemCategories =
                InventoryItemCategoryClient.GetInventoryItemCategoriesByIsTool(isTool, isActive);
            return Mapper.FromDataTransferObjects(inventoryItemCategories);
        }

        public IList<InventoryItemCategoryModel> GetInventoryItemCategories(bool isActive)
        {
            var inventoryItemCategories =
                InventoryItemCategoryClient.GetInventoryItemCategories(isActive);
            return Mapper.FromDataTransferObjects(inventoryItemCategories);
        }

        #endregion

        #region Bank

        /// <summary>
        ///     Gets the banks.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        ///     BankModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BankModel GetBank(string bankId)
        {
            var bank = BankClient.GetBanks(bankId);
            return Mapper.FromDataTransferObject(bank);
        }

        /// <summary>
        ///     Gets the banks.
        /// </summary>
        /// <returns>
        ///     IList{BankModel}.
        /// </returns>
        public IList<BankModel> GetBanks()
        {
            var banks = BankClient.GetBanks();
            return Mapper.FromDataTransferObjects(banks);
        }

        public IList<AudittingLogModel> GetAudittingLogs()
        {
            var AudittingLog = AudittingLogClient.GetAudittingLogs();
            return Mapper.FromDataTransferObjects(AudittingLog);
        }

        //public IList<GeneralLedgerModel> GetSearchVoucher()
        //{
        //    //var GeneralLedger = GeneralLedgerClient.GetSearchVoucher();
        //    //return Mapper.FromDataTransferObjects(GeneralLedger);
        //}
        /// <summary>
        ///     Gets the banks active.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>
        ///     IList{BankModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        /// 

        public IList<FixedAssetLedgerModel> GetFixedAssetLedgerById(string fixedAssetId)
        {
            var fixedAssetLedger = FixedAssetLedgerClient.GetFixedAssetLedgersbyID(fixedAssetId);
            return Mapper.FromDataTransferObjects(fixedAssetLedger);

        }


        public IList<BankModel> GetBanksActive(bool isActive)
        {
            var banks = BankClient.GetBankByActive(isActive);
            return Mapper.FromDataTransferObjects(banks);
        }
        public IList<BankModel> GetProjectBank(string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                return new List<BankModel>();
            }
            var banks = BankClient.GetProjectBank(projectId);
            return Mapper.FromDataTransferObjects(banks);
        }

        /// <summary>
        ///     Gets the banks non active.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BankModel> GetBanksByBankAccount(string bankAccount)
        {
            var banks = BankClient.GetBanksByBankAccount(bankAccount);
            return Mapper.FromDataTransferObjects(banks);
        }

        /// <summary>
        ///     Adds the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBank(BankModel bank)
        {
            var bankEntity = Mapper.ToDataTransferObject(bank);
            var response = BankClient.InsertBank(bankEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BankId;
        }

        public string AddAuditingLog(AudittingLogModel AddAuditingLog)
        {
            var AddAuditingLogEntity = Mapper.ToDataTransferObjectAu(AddAuditingLog);
            var response = AudittingLogClient.InsertAudittingLog(AddAuditingLogEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.EventId;
        }

        /// <summary>
        ///     Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBank(BankModel bank)
        {
            var bankEntity = Mapper.ToDataTransferObject(bank);
            var response = BankClient.UpdateBank(bankEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BankId;
        }


        /// <summary>
        ///     Deletes the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBank(string bankId)
        {
            var response = BankClient.DeleteBank(bankId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BankId;
        }

        #endregion

        #region Activity

        /// <summary>
        ///     Gets the activity.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <returns></returns>
        public ActivityModel GetActivity(string activityId)
        {
            var activity = ActivityClient.GetActivitys(activityId);
            return Mapper.FromDataTransferObject(activity);
        }

        /// <summary>
        ///     Gets the activitys.
        /// </summary>
        /// <returns></returns>
        public IList<ActivityModel> GetActivitys()
        {
            var activitys = ActivityClient.GetActivitys();
            return Mapper.FromDataTransferObjects(activitys);
        }

        /// <summary>
        ///     Gets the activitys active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<ActivityModel> GetActivitysActive(bool isActive)
        {
            var activitys = ActivityClient.GetActivityByActive(isActive);
            return Mapper.FromDataTransferObjects(activitys);
        }

        /// <summary>
        ///     Adds the activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddActivity(ActivityModel activity)
        {
            var activityEntity = Mapper.ToDataTransferObject(activity);
            var response = ActivityClient.InsertActivity(activityEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        /// <summary>
        ///     Updates the activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateActivity(ActivityModel activity)
        {
            var activityEntity = Mapper.ToDataTransferObject(activity);
            var response = ActivityClient.UpdateActivity(activityEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        /// <summary>
        ///     Deletes the activity.
        /// </summary>
        /// <param name="activityId">The activity identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteActivity(string activityId)
        {
            var response = ActivityClient.DeleteActivity(activityId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        #endregion

        #region AccountTranfer

        /// <summary>
        ///     Gets the account tranfers.
        /// </summary>
        /// <returns>
        ///     IList{AccountTransferModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTransferModel> GetAccountTransfers()
        {
            var accountTranfers = AccountTransferClient.GetAccountTransfers();
            return Mapper.FromDataTransferObjects(accountTranfers);
        }

        /// <summary>
        ///     Gets the account tranfers active.
        /// </summary>
        /// <returns>
        ///     IList{AccountTransferModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTransferModel> GetAccountTransfersActive()
        {
            const bool isActive = true;
            var accountTranfers = AccountTransferClient.GetAccountTransfersByIsActive(isActive);
            return Mapper.FromDataTransferObjects(accountTranfers);
        }

        /// <summary>
        ///     Gets the account tranfers non active.
        /// </summary>
        /// <returns>
        ///     IList{AccountTransferModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTransferModel> GetAccountTransfersNonActive()
        {
            const bool isActive = false;
            var accountTranfers = AccountTransferClient.GetAccountTransfersByIsActive(isActive);
            return Mapper.FromDataTransferObjects(accountTranfers);
        }

        /// <summary>
        ///     Gets the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountTransferModel GetAccountTransfer(string accountTranferId)
        {
            var accountTranfer = AccountTransferClient.GetAccountTransferById(accountTranferId);
            return Mapper.FromDataTransferObject(accountTranfer);
        }

        /// <summary>
        ///     Adds the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAccountTransfer(AccountTransferModel accountTranfer)
        {
            var accountTranferEntity = Mapper.ToDataTransferObject(accountTranfer);
            var response = AccountTransferClient.InsertAccountTransfer(accountTranferEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountTransferId;
        }

        /// <summary>
        ///     Updates the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAccountTransfer(AccountTransferModel accountTranfer)
        {
            var accountTranferEntity = Mapper.ToDataTransferObject(accountTranfer);
            var response = AccountTransferClient.UpdateAccountTransfer(accountTranferEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountTransferId;
        }

        /// <summary>
        ///     Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAccountTransfer(string accountTranferId)
        {
            var response = AccountTransferClient.DeleteAccountTransfer(accountTranferId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountTransferId;
        }

        #endregion

        #region DBOption

        /// <summary>
        ///     Gets the database option.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <returns></returns>
        public DBOptionModel GetDBOption(string optionId)
        {
            var dbOption = DBOptionClient.GetDBOption(optionId);
            return Mapper.FromDataTransferObject(dbOption);
        }

        /// <summary>
        ///     Gets the database options.
        /// </summary>
        /// <returns>
        ///     IList{DBOptionModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptions()
        {
            var dbOptions = DBOptionClient.GetDBOptions();
            return Mapper.FromDataTransferObjects(dbOptions);
        }

        /// <summary>
        ///     Gets the database options system.
        /// </summary>
        /// <returns>
        ///     IList{DBOptionModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsSystem()
        {
            var dbOptions = DBOptionClient.GetDBOptionsBySystem(true);
            return Mapper.FromDataTransferObjects(dbOptions);
        }

        /// <summary>
        ///     Gets the database options is string.
        /// </summary>
        /// <returns>
        ///     IList{DBOptionModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsString()
        {
            var dbOptions = DBOptionClient.GetDBOptionsByValueType(1);
            return Mapper.FromDataTransferObjects(dbOptions);
        }

        /// <summary>
        ///     Gets the database options is numeric.
        /// </summary>
        /// <returns>
        ///     IList{DBOptionModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsNumeric()
        {
            var dbOptions = DBOptionClient.GetDBOptionsByValueType(0);
            return Mapper.FromDataTransferObjects(dbOptions);
        }

        /// <summary>
        ///     Gets the database options is boolean.
        /// </summary>
        /// <returns>
        ///     IList{DBOptionModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsBoolean()
        {
            var dbOptions = DBOptionClient.GetDBOptionsByValueType(3);
            return Mapper.FromDataTransferObjects(dbOptions);
        }

        /// <summary>
        ///     Updates the database option.
        /// </summary>
        /// <param name="dbOption">The database option.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateDBOption(DBOptionModel dbOption)
        {
            var dbOptionEntity = Mapper.ToDataTransferObject(dbOption);
            var response = DBOptionClient.UpdateDBOption(dbOptionEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.OptionId;
        }

        /// <summary>
        ///     Updates the database option.
        /// </summary>
        /// <param name="dbOptions">The database options.</param>
        /// <returns></returns>
        public string UpdateDBOption(List<DBOptionModel> dbOptions)
        {
            var dbOptionEntities = new List<DBOptionEntity>();
            foreach (var dbOption in dbOptions)
            {
                var dbOptionEntity = Mapper.ToDataTransferObject(dbOption);
                dbOptionEntities.Add(dbOptionEntity);
            }
            var response = DBOptionClient.UpdateDBOption(dbOptionEntities);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.OptionId;
        }

        #endregion

        #region SUIncrementDecrement

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{SUIncrementDecrementModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrements()
        {
            var sUIncrementDecrements = SUIncrementDecrementFacade.GetSUIncrementDecrements();
            return sUIncrementDecrements.Any()
                ? Mapper.FromDataTransferObjects(sUIncrementDecrements)
                : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByYearOfPostDate(int refTypeId,
            DateTime refDate)
        {
            var sUIncrementDecrements =
                SUIncrementDecrementFacade.GetSUIncrementDecrementsByRefTypeId(refTypeId, refDate);
            return sUIncrementDecrements.Any()
                ? Mapper.FromDataTransferObjects(sUIncrementDecrements)
                : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{SUIncrementDecrementModel}.
        /// </returns>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            var sUIncrementDecrements = SUIncrementDecrementFacade.GetSUIncrementDecrementsByRefTypeId(refTypeId);
            return sUIncrementDecrements.Any()
                ? Mapper.FromDataTransferObjects(sUIncrementDecrements)
                : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementModel GetSUIncrementDecrement(string refId, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementFacade.GetSUIncrementDecrementByRefId(refId, hasDetail);
            return sUIncrementDecrement != null ? Mapper.FromDataTransferObject(sUIncrementDecrement) : null;
        }
        public FAAdjustmentModel GetFAAdjustmentByRefId(string refId)
        {
            var fAAdjustment = FAAdjustmentFacade.GetFAAdjustmentByRefId(refId);
            return fAAdjustment != null ? Mapper.FromDataTransferObjectFA(fAAdjustment) : null;
        }
        public FAAdjustmentModel GetFAAdjustmentByRefId(string refId, bool hasDetail, bool hasDetailParallel)
        {
            var fAAdjustment = FAAdjustmentFacade.GetFAAdjustmentByRefId(refId, hasDetail, hasDetailParallel);
            return fAAdjustment != null ? Mapper.FromDataTransferObjectFA(fAAdjustment) : null;
        }

        /// <summary>
        ///     Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementModel GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementFacade.GetSUIncrementDecrementByRefNo(refNo, hasDetail);
            return sUIncrementDecrement != null ? Mapper.FromDataTransferObject(sUIncrementDecrement) : null;
        }

        /// <summary>
        ///     Adds the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement)
        {
            var sUIncrementDecrementEntity = Mapper.ToDataTransferObject(sUIncrementDecrement);
            var response = SUIncrementDecrementFacade.InsertSUIncrementDecrement(sUIncrementDecrementEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement)
        {
            var sUIncrementDecrementEntity = Mapper.ToDataTransferObject(sUIncrementDecrement);
            var response = SUIncrementDecrementFacade.UpdateSUIncrementDecrement(sUIncrementDecrementEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteSUIncrementDecrement(string refId)
        {
            var response = SUIncrementDecrementFacade.DeleteSUIncrementDecrement(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion


        #region FAAdjustment

        public IList<FAAdjustmentModel> GetFAAdjustments()
        {
            var fAIncrementDecrements = FAAdjustmentFacade.GetFAAdjustments();
            return fAIncrementDecrements.Any()
                ? Mapper.FromDataTransferObjects(fAIncrementDecrements)
                : new List<FAAdjustmentModel>();
        }
        #endregion



        #region FAIncrementDecrement

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{FAIncrementDecrementModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FAIncrementDecrementModel> GetFAIncrementDecrements()
        {
            var fAIncrementDecrements = FAIncrementDecrementFacade.GetFAIncrementDecrements();
            return fAIncrementDecrements.Any()
                ? Mapper.FromDataTransferObjects(fAIncrementDecrements)
                : new List<FAIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the fAIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{FAIncrementDecrementModel}.
        /// </returns>


        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>


        /// <summary>
        ///     Gets the fAIncrementDecrement.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FAIncrementDecrementModel GetFAIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var fAIncrementDecrement = FAIncrementDecrementFacade.GetFAIncrementDecrementByRefNo(refNo, hasDetail);
            return fAIncrementDecrement != null ? Mapper.FromDataTransferObject(fAIncrementDecrement) : null;
        }

        /// <summary>
        ///     Adds the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>


        /// <summary>
        ///     Updates the fAIncrementDecrement.
        /// </summary>
        /// <param name="fAIncrementDecrement">The fAIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateFAIncrementDecrement(FAIncrementDecrementModel fAIncrementDecrement)
        {
            var fAIncrementDecrementEntity = Mapper.ToDataTransferObject(fAIncrementDecrement);
            var response = FAIncrementDecrementFacade.UpdateFAIncrementDecrement(fAIncrementDecrementEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>


        #endregion

        #region SUTransfer

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{SUTransferModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<SUTransferModel> GetSUTransfers()
        {
            var suTransfers = SUTransferClient.GetSUTransfers();
            return suTransfers.Any() ? Mapper.FromDataTransferObjects(suTransfers) : new List<SUTransferModel>();
        }

        /// <summary>
        ///     Gets the SUTransfers by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<SUTransferModel> GetSUTransfersByYearOfPostDate(int refTypeId, DateTime refDate)
        {
            var suTransfers = SUTransferClient.GetSUTransfersByRefTypeId(refTypeId, refDate);
            return suTransfers.Any() ? Mapper.FromDataTransferObjects(suTransfers) : new List<SUTransferModel>();
        }

        /// <summary>
        ///     Gets the SUTransfers by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{SUTransferModel}.
        /// </returns>
        public IList<SUTransferModel> GetSUTransfersByRefTypeId(int refTypeId)
        {
            var suTransfers = SUTransferClient.GetSUTransfersByRefTypeId(refTypeId);
            return suTransfers.Any() ? Mapper.FromDataTransferObjects(suTransfers) : new List<SUTransferModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUTransferModel GetSUTransfer(string refId, bool hasDetail)
        {
            var suTransfers = SUTransferClient.GetSUTransferByRefId(refId, hasDetail);
            return suTransfers != null ? Mapper.FromDataTransferObject(suTransfers) : null;
        }

        /// <summary>
        ///     Gets the SUTransfer.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUTransferModel GetSUTransferByRefNo(string refNo, bool hasDetail)
        {
            var suTransfers = SUTransferClient.GetSUTransferByRefNo(refNo, hasDetail);
            return suTransfers != null ? Mapper.FromDataTransferObject(suTransfers) : null;
        }

        /// <summary>
        ///     Adds the SUTransfer.
        /// </summary>
        /// <param name="suTransfer">The su transfer.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddSUTransfer(SUTransferModel suTransfer)
        {
            var suTransferEntity = Mapper.ToDataTransferObject(suTransfer);
            var response = SUTransferClient.InsertSUTransfer(suTransferEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the SUTransfer.
        /// </summary>
        /// <param name="suTransfers">The su transfers.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateSUTransfer(SUTransferModel suTransfers)
        {
            var suTransferEntity = Mapper.ToDataTransferObject(suTransfers);
            var response = SUTransferClient.UpdateSUTransfer(suTransferEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteSUTransfer(string refId)
        {
            var response = SUTransferClient.DeleteSUTransfer(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region FADepreciation

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{FADepreciationModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FADepreciationModel> GetFADepreciations()
        {
            var faDepreciations = FADepreciationClient.GetFADepreciations();
            return faDepreciations.Any()
                ? Mapper.FromDataTransferObjects(faDepreciations)
                : new List<FADepreciationModel>();
        }

        /// <summary>
        ///     Gets the FADepreciations by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<FADepreciationModel> GetFADepreciationsByYearOfPostDate(int refTypeId, DateTime refDate)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciationsByRefTypeId(refTypeId, refDate);
            return faDepreciations.Any()
                ? Mapper.FromDataTransferObjects(faDepreciations)
                : new List<FADepreciationModel>();
        }

        /// <summary>
        /// Gets the fa depreciations by year of post date.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public IList<FADepreciationModel> GetFADepreciationsByRefDateAndPeriodType(int refType, DateTime refDate, int periodType)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciationsByRefTypeAndPeriodType(refType, refDate, periodType);
            return faDepreciations.Any()
                ? Mapper.FromDataTransferObjects(faDepreciations)
                : new List<FADepreciationModel>();
        }

        /// <summary>
        ///     Gets the FADepreciations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{FADepreciationModel}.
        /// </returns>
        public IList<FADepreciationModel> GetFADepreciationsByRefTypeId(int refTypeId)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciationsByRefTypeId(refTypeId);
            return faDepreciations.Any()
                ? Mapper.FromDataTransferObjects(faDepreciations)
                : new List<FADepreciationModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationModel GetFADepreciation(string refId, bool hasDetail)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciationByRefId(refId, hasDetail);
            return faDepreciations != null ? Mapper.FromDataTransferObject(faDepreciations) : null;
        }

        /// <summary>
        /// Gets the fa devaluation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationModel GetFADevaluation(string refId, bool hasDetail)
        {
            var faDepreciations = FADepreciationClient.GetFADevaluationByRefId(refId, hasDetail);
            return faDepreciations != null ? Mapper.FromDataTransferObject(faDepreciations) : null;
        }

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">if set to <c>true</c> [has detail].</param>
        /// <param name="toDate">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationModel GetFADepreciation(string refId, DateTime fromDate, DateTime toDate)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciation(refId, fromDate, toDate);
            return faDepreciations != null ? Mapper.FromDataTransferObject(faDepreciations) : null;
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public FADepreciationModel GetFADepreciation(string refId, DateTime fromDate, DateTime toDate, int periodType)
        {
            var faDepreciations = FADepreciationClient.GetFADepreciation(refId, fromDate, toDate, periodType);
            return faDepreciations != null ? Mapper.FromDataTransferObject(faDepreciations) : null;
        }

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public IList<FADepreciationModel> GetFADevaluations(int refType, DateTime refDate, int periodType)
        {
            var faDepreciations = FADepreciationClient.GetFADevaluations(refType, refDate, periodType);
            return faDepreciations != null ? Mapper.FromDataTransferObjects(faDepreciations) : null;
        }

        /// <summary>
        ///     Gets the FADepreciation.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public FADepreciationModel GetFADepreciationByRefNo(string refNo, bool hasDetail)
        {
            return null;
        }

        /// <summary>
        ///     Adds the FADepreciation.
        /// </summary>
        /// <param name="faDepreciations">The fa depreciations.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddFADepreciation(FADepreciationModel faDepreciations)
        {
            var faDepreciationEntity = Mapper.ToDataTransferObject(faDepreciations);
            var response = FADepreciationClient.InsertFADepreciation(faDepreciationEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the FADepreciation.
        /// </summary>
        /// <param name="faDepreciations">The fa depreciations.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateFADepreciation(FADepreciationModel faDepreciations)
        {
            var faDepreciationEntity = Mapper.ToDataTransferObject(faDepreciations);
            var response = FADepreciationClient.UpdateFADepreciation(faDepreciationEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteFADepreciation(string refId)
        {
            var response = FADepreciationClient.DeleteFADepreciation(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region BADeposit

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{BADepositModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BADepositModel> GetBADeposits()
        {
            var bADeposits = BADepositFacade.GetBADeposits();
            return bADeposits.Any() ? Mapper.FromDataTransferObjects(bADeposits) : new List<BADepositModel>();
        }

        /// <summary>
        ///     Gets the bADeposits by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<BADepositModel> GetBADepositsByYearOfPostDate(int refTypeId, DateTime refDate)
        {
            var bADeposits = BADepositFacade.GetBADepositsByRefTypeId(refTypeId, refDate);
            return bADeposits.Any() ? Mapper.FromDataTransferObjects(bADeposits) : new List<BADepositModel>();
        }

        /// <summary>
        ///     Gets the bADeposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{BADepositModel}.
        /// </returns>
        public IList<BADepositModel> GetBADepositsByRefTypeId(int refTypeId)
        {
            var bADeposits = BADepositFacade.GetBADepositsByRefTypeId(refTypeId);
            return bADeposits.Any() ? Mapper.FromDataTransferObjects(bADeposits) : new List<BADepositModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasSale">if set to <c>true</c> [has sale].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BADepositModel GetBADeposit(string refId, bool hasDetail, bool hasFixedAsset, bool hasSale, bool hasTax)
        {
            var bADeposit = BADepositFacade.GetBADepositByRefId(refId, hasDetail, hasFixedAsset, hasSale, hasTax);
            return bADeposit != null ? Mapper.FromDataTransferObject(bADeposit) : null;
        }

        /// <summary>
        ///     Gets the ba deposit for salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BADepositModel GetBADepositForSalary(DateTime dateMonth)
        {
            var bADeposit = BADepositFacade.GetBADepositByDateMonth(dateMonth);
            return bADeposit != null ? Mapper.FromDataTransferObject(bADeposit) : null;
        }

        /// <summary>
        ///     Adds the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBADeposit(BADepositModel bADeposit)
        {
            var bADepositEntity = Mapper.ToDataTransferObject(bADeposit);
            var response = BADepositFacade.InsertBADeposit(bADepositEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Adds the ba deposit.
        /// </summary>
        /// <param name="bADeposit">The b a deposit.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string AddBADeposit(BADepositModel bADeposit, bool isAutoGenerateParallel)
        {
            var bADepositEntity = Mapper.ToDataTransferObject(bADeposit);
            var response = BADepositFacade.InsertBADeposit(bADepositEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBADeposit(BADepositModel bADeposit)
        {
            var bADepositEntity = Mapper.ToDataTransferObject(bADeposit);
            var response = BADepositFacade.UpdateBADeposit(bADepositEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ba deposit.
        /// </summary>
        /// <param name="bADeposit">The b a deposit.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateBADeposit(BADepositModel bADeposit, bool isAutoGenerateParallel)
        {
            var bADepositEntity = Mapper.ToDataTransferObject(bADeposit);
            var response = BADepositFacade.UpdateBADeposit(bADepositEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBADeposit(string refId)
        {
            var response = BADepositFacade.DeleteBADeposit(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region BAWithDraw

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{BAWithDrawModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BAWithDrawModel> GetBAWithDraws()
        {
            var bAWithDraws = BAWithDrawFacade.GetBAWithDraws();
            return bAWithDraws.Any() ? Mapper.FromDataTransferObjects(bAWithDraws) : new List<BAWithDrawModel>();
        }


        /// <summary>
        ///     Gets the bAWithDraws by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<BAWithDrawModel> GetBAWithDrawsByYearOfPostDate(int refTypeId, DateTime refDate)
        {
            var bAWithDraws = BAWithDrawFacade.GetBAWithDrawsByRefTypeId(refTypeId, refDate);
            return bAWithDraws.Any() ? Mapper.FromDataTransferObjects(bAWithDraws) : new List<BAWithDrawModel>();
        }

        /// <summary>
        ///     Gets the bAWithDraws by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{BAWithDrawModel}.
        /// </returns>
        public IList<BAWithDrawModel> GetBAWithDrawsByRefTypeId(int refTypeId)
        {
            var bAWithDraws = BAWithDrawFacade.GetBAWithDrawsByRefTypeId(refTypeId);
            return bAWithDraws.Any() ? Mapper.FromDataTransferObjects(bAWithDraws) : new List<BAWithDrawModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BAWithDrawModel GetBAWithDraw(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax)
        {
            var bAWithDraw =
                BAWithDrawFacade.GetBAWithDrawByRefId(refId, hasDetail, hasFixedAsset, hasPurchase, hasSalary, hasTax);
            return bAWithDraw != null ? Mapper.FromDataTransferObject(bAWithDraw) : null;
        }
        public BAWithDrawModel GetBAWithDrawFixedAccess(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
        bool hasSalary, bool hasTax)
        {
            var bAWithDraw =
                CAPaymentFacade.GetCAPaymentByRefId(refId, true);
            return bAWithDraw != null ? Mapper.FromDataTransferObjectCA(bAWithDraw) : null;
        }

        /// <summary>
        ///     Gets the bAWithDraw.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BAWithDrawModel GetBAWithDrawByRefNo(string refNo, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax)
        {
            var bAWithDraw =
                BAWithDrawFacade.GetBAWithDrawByRefNo(refNo, hasDetail, hasFixedAsset, hasPurchase, hasSalary, hasTax);
            return bAWithDraw != null ? Mapper.FromDataTransferObject(bAWithDraw) : null;
        }

        /// <summary>
        ///     Gets the ba deposit for salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BAWithDrawModel GetBAWithDrawForSalary(DateTime dateMonth)
        {
            var bAWithDraw = BAWithDrawFacade.GetBAWithDrawByDateMonth(dateMonth);
            return bAWithDraw != null ? Mapper.FromDataTransferObject(bAWithDraw) : null;
        }

        /// <summary>
        ///     Adds the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBAWithDraw(BAWithDrawModel bAWithDraw)
        {
            var bAWithDrawEntity = Mapper.ToDataTransferObject(bAWithDraw);
            var response = BAWithDrawFacade.InsertBAWithDraw(bAWithDrawEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Adds the ba with draw.
        /// </summary>
        /// <param name="bAWithDraw">The b a with draw.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string AddBAWithDraw(BAWithDrawModel bAWithDraw, bool isAutoGenerateParallel)
        {
            var bAWithDrawEntity = Mapper.ToDataTransferObject(bAWithDraw);
            var response = BAWithDrawFacade.InsertBAWithDraw(bAWithDrawEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBAWithDraw(BAWithDrawModel bAWithDraw)
        {
            var bAWithDrawEntity = Mapper.ToDataTransferObject(bAWithDraw);
            var response = BAWithDrawFacade.UpdateBAWithDraw(bAWithDrawEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ba with draw.
        /// </summary>
        /// <param name="bAWithDraw">The b a with draw.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateBAWithDraw(BAWithDrawModel bAWithDraw, bool isAutoGenerateParallel)
        {
            var bAWithDrawEntity = Mapper.ToDataTransferObject(bAWithDraw);
            var response = BAWithDrawFacade.UpdateBAWithDraw(bAWithDrawEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBAWithDraw(string refId)
        {
            var response = BAWithDrawFacade.DeleteBAWithDraw(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        #region BABankTransfer

        /// <summary>
        ///     Gets the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public BABankTransferModel GetBABankTransfer(string refId)
        {
            var bABankTransfer = BABankTransferClient.GetCAReceiptByRefId(refId, true);
            return Mapper.FromDataTransferObject(bABankTransfer);
        }

        /// <summary>
        ///     Gets the ba bank transfers.
        /// </summary>
        /// <returns></returns>
        public IList<BABankTransferModel> GetBABankTransfers()
        {
            var bABankTransfers = BABankTransferClient.GetBABankTransfers();
            return Mapper.FromDataTransferObjects(bABankTransfers);
        }

        /// <summary>
        ///     Gets the ba bank transfer by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BABankTransferModel GetBABankTransferByRefNo(string refNo)
        {
            var bABankTransfers = BABankTransferClient.GetBABankTransferByRefNo(refNo);
            return Mapper.FromDataTransferObject(bABankTransfers);
        }

        /// <summary>
        ///     Inserts the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBABankTransfer(BABankTransferModel bABankTransfer)
        {
            var bABankTransferEntity = Mapper.ToDataTransferObject(bABankTransfer);
            var response = BABankTransferClient.InsertBABankTransfer(bABankTransferEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }


        /// <summary>
        ///     Inserts the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBABankTransfer(BABankTransferModel bABankTransfer, bool isAutoGenerateParallel)
        {
            var bABankTransferEntity = Mapper.ToDataTransferObject(bABankTransfer);
            var response = BABankTransferClient.InsertBABankTransfer(bABankTransferEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBABankTransfer(BABankTransferModel bABankTransfer)
        {
            var bABankTransferEntity = Mapper.ToDataTransferObject(bABankTransfer);
            var response = BABankTransferClient.UpdateBABankTransfer(bABankTransferEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBABankTransfer(BABankTransferModel bABankTransfer, bool isAutoGenerateParallel)
        {
            var bABankTransferEntity = Mapper.ToDataTransferObject(bABankTransfer);
            var response = BABankTransferClient.UpdateBABankTransfer(bABankTransferEntity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBABankTransfer(string refId)
        {
            var response = BABankTransferClient.DeleteBABankTransfer(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        //List<BABankTransferDetailModel> GetBABankTransferDetailsByRefId(string refId);
        //string InsertBABankTransferDetail(BABankTransferDetailModel bABankTransferDetailEntity);
        //string DeleteBABankTransferDetailByRefId(string refId);

        #endregion

        #region AutoBusiness

        /// <summary>
        ///     Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinesses()
        {
            var autoBusinesses = AutoBusinessClient.GetAutoBusinesses();
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinessesActive()
        {
            const bool isActive = true;
            var autoBusinesses = AutoBusinessClient.GetAutoBusinessesByActive(isActive);
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinessesNonActive()
        {
            const bool isActive = false;
            var autoBusinesses = AutoBusinessClient.GetAutoBusinessesByActive(isActive);
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        ///     AutoBusinessModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AutoBusinessModel GetAutoBusiness(string autoBusinessId)
        {
            var autoBusiness = AutoBusinessClient.GetAutoBusiness(autoBusinessId);
            return Mapper.FromDataTransferObject(autoBusiness);
        }

        /// <summary>
        ///     Gets the type of the automatic business by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinessByRefType(int refTypeId, bool isActive)
        {
            var autoBusiness = AutoBusinessClient.GetAutoBusinessByRefType(refTypeId, isActive);
            return Mapper.FromDataTransferObjects(autoBusiness);
        }

        /// <summary>
        ///     Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAutoBusiness(AutoBusinessModel autoBusiness)
        {
            var autoBusinessEntity = Mapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessClient.InsertAutoBusiness(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessId;
        }

        /// <summary>
        ///     Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAutoBusiness(AutoBusinessModel autoBusiness)
        {
            var autoBusinessEntity = Mapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessClient.UpdateAutoBusiness(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessId;
        }

        /// <summary>
        ///     Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAutoBusiness(string autoBusinessId)
        {
            var response = AutoBusinessClient.DeleteAutoBusiness(autoBusinessId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AutoBusinessId;
        }

        #endregion

        #region AutoBusinessParallel

        /// <summary>
        ///     Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessParallelModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessParallelModel> GetAutoBusinessParallels()
        {
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallels();
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessParallelModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessParallelModel> GetAutoBusinessParallelsActive()
        {
            const bool isActive = true;
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallelsByActive(isActive);
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        ///     IList{AutoBusinessParallelModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessParallelModel> GetAutoBusinessParallelsNonActive()
        {
            const bool isActive = false;
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallelsByActive(isActive);
            return Mapper.FromDataTransferObjects(autoBusinesses);
        }

        /// <summary>
        ///     Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        ///     AutoBusinessParallelModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AutoBusinessParallelModel GetAutoBusinessParallel(string autoBusinessId)
        {
            var autoBusiness = AutoBusinessParallelClient.GetAutoBusinessParallel(autoBusinessId);
            return Mapper.FromDataTransferObject(autoBusiness);
        }

        /// <summary>
        ///     Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddAutoBusinessParallel(AutoBusinessParallelModel autoBusiness)
        {
            var autoBusinessEntity = Mapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessParallelClient.InsertAutoBusinessParallel(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessParallelId;
        }

        /// <summary>
        ///     Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAutoBusinessParallel(AutoBusinessParallelModel autoBusiness)
        {
            var autoBusinessEntity = Mapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessParallelClient.UpdateAutoBusinessParallel(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessParallelId;
        }

        /// <summary>
        ///     Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteAutoBusinessParallel(string autoBusinessId)
        {
            var response = AutoBusinessParallelClient.DeleteAutoBusinessParallel(autoBusinessId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AutoBusinessParallelId;
        }

        #endregion


        #region RefType

        /// <summary>
        ///     Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<RefTypeModel> GetRefTypes()
        {
            var refTypes = RefTypeClient.GetRefTypes();
            return Mapper.FromDataTransferObjects(refTypes);
        }

        /// <summary>
        ///     Gets the reference type model.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public RefTypeModel GetRefTypeModel(int refTypeId)
        {
            var refType = RefTypeClient.GetRefType(refTypeId);
            return refType == null ? null : Mapper.FromDataTransferObject(refType);
        }

        /// <summary>
        ///     Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeModel">The reference type model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateRefType(RefTypeModel refTypeModel)
        {
            var refTypeEntity = Mapper.ToDataTransferObject(refTypeModel);
            var response = RefTypeClient.UpdateRefType(refTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefTypeId.ToString();
        }

        ///// <summary>
        ///// Gets the voucher types search.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.NotImplementedException"></exception>

        //public IList<RefTypeModel> GetRefTypesSearch()
        //{
        //    var request = PrepareRequest(new RefTypeRequest());
        //    request.LoadOptions = new[] { "RefTypeSearch" };

        //    var response = RefTypeClient.GetRefTypes(request);
        //    if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

        //    return Mapper.FromDataTransferObjects(response.RefTypes);
        //}


        //public IList<ProjectModel> GetSearchVoucher(string af, string sv, string dd, string ađâs)
        //{
        //    var project = VoucherListClient.GetProjects();
        //    return Mapper.FromDataTransferObjects(project);
        //}

        #endregion

        #region Project

        /// <summary>
        ///     Gets the projects.
        /// </summary>
        /// <returns>
        ///     IList{ProjectModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ProjectModel> GetProjects()
        {
            var project = ProjectClient.GetProjects();
            return Mapper.FromDataTransferObjects(project);
        }

        /// <summary>
        ///     Gets the projects active.
        /// </summary>
        /// <param name="isAcitve">if set to <c>true</c> [is acitve].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ProjectModel> GetProjectsActive(bool isAcitve)
        {
            var project = ProjectClient.GetProjectsByActive(isAcitve);
            return Mapper.FromDataTransferObjects(project);
        }

        /// <summary>
        ///     Gets the type of the projects by object.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public IList<ProjectModel> GetProjectsByObjectType(string objectType)
        {
            var projects = ProjectClient.GetProjectsByObjectType(objectType);
            return Mapper.FromDataTransferObjects(projects);
        }

        /// <summary>
        ///     Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        ///     ProjectModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public ProjectModel GetProject(string projectId)
        {
            var project = ProjectClient.GetProject(projectId);
            return Mapper.FromDataTransferObject(project);
        }

        /// <summary>
        ///     Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddProject(ProjectModel project)
        {
            var projectEntity = Mapper.ToDataTransferObject(project);
            var response = ProjectClient.InsertProject(projectEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ProjectId;
        }

        /// <summary>
        ///     Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateProject(ProjectModel project, bool editBank = false)
        {
            var projectEntity = Mapper.ToDataTransferObject(project);
            var response = ProjectClient.UpdateProject(projectEntity,editBank);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ProjectId;
        }

        /// <summary>
        ///     Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteProject(string projectId)
        {
            var response = ProjectClient.DeleteProject(projectId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ProjectId;
        }

        #endregion


        #region TaxItem

        /// <summary>
        ///     Gets the tax items.
        /// </summary>
        /// <returns>
        ///     IList&lt;TaxItemModel&gt;.
        /// </returns>
        public IList<TaxItemModel> GetTaxItems()
        {
            var taxItem = TaxItemClient.GetTaxItems();
            return Mapper.FromDataTransferObjects(taxItem);
        }

        /// <summary>
        ///     Gets the tax items active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList&lt;TaxItemModel&gt;.
        /// </returns>
        public IList<TaxItemModel> GetTaxItemsActive(bool isActive)
        {
            var taxItem = TaxItemClient.GetTaxItemsByActive(isActive);
            return Mapper.FromDataTransferObjects(taxItem);
        }

        /// <summary>
        ///     Gets the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>
        ///     TaxItemModel.
        /// </returns>
        public TaxItemModel GetTaxItem(string taxItemId)
        {
            var taxItem = TaxItemClient.GetTaxItem(taxItemId);
            return Mapper.FromDataTransferObject(taxItem);
        }

        /// <summary>
        ///     Adds the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddTaxItem(TaxItemModel taxItem)
        {
            var taxItemEntity = Mapper.ToDataTransferObject(taxItem);
            var response = TaxItemClient.InsertTaxItem(taxItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.TaxItemId;
        }

        /// <summary>
        ///     Updates the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateTaxItem(TaxItemModel taxItem)
        {
            var taxItemEntity = Mapper.ToDataTransferObject(taxItem);
            var response = TaxItemClient.UpdateTaxItem(taxItemEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.TaxItemId;
        }

        /// <summary>
        ///     Deletes the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteTaxItem(string taxItemId)
        {
            var response = TaxItemClient.DeleteTaxItem(taxItemId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.TaxItemId;
        }

        #endregion

        #region TaxType

        /// <summary>
        ///     Gets the tax types.
        /// </summary>
        /// <returns>
        ///     IList&lt;TaxTypeModel&gt;.
        /// </returns>
        public IList<TaxTypeModel> GetTaxTypes()
        {
            var taxType = TaxTypeClient.GetTaxTypes();
            return Mapper.FromDataTransferObjects(taxType);
        }

        /// <summary>
        ///     Gets the tax types active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList&lt;TaxTypeModel&gt;.
        /// </returns>
        public IList<TaxTypeModel> GetTaxTypesActive(bool isActive)
        {
            var taxType = TaxTypeClient.GetTaxTypesByActive(isActive);
            return Mapper.FromDataTransferObjects(taxType);
        }

        /// <summary>
        ///     Gets the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>
        ///     TaxTypeModel.
        /// </returns>
        public TaxTypeModel GetTaxType(string taxTypeId)
        {
            var taxType = TaxTypeClient.GetTaxType(taxTypeId);
            return Mapper.FromDataTransferObject(taxType);
        }

        /// <summary>
        ///     Adds the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddTaxType(TaxTypeModel taxType)
        {
            var taxTypeEntity = Mapper.ToDataTransferObject(taxType);
            var response = TaxTypeClient.InsertTaxType(taxTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.TaxTypeId;
        }

        /// <summary>
        ///     Updates the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateTaxType(TaxTypeModel taxType)
        {
            var taxTypeEntity = Mapper.ToDataTransferObject(taxType);
            var response = TaxTypeClient.UpdateTaxType(taxTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.TaxTypeId;
        }

        /// <summary>
        ///     Deletes the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteTaxType(string taxTypeId)
        {
            var response = TaxTypeClient.DeleteTaxType(taxTypeId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.TaxTypeId;
        }

        #endregion

        #region FundStructure

        /// <summary>
        ///     Gets the fund structures.
        /// </summary>
        /// <returns>
        ///     IList&lt;FundStructureModel&gt;.
        /// </returns>
        public IList<FundStructureModel> GetFundStructures()
        {
            var fundStructure = FundStructureClient.GetFundStructures();
            return Mapper.FromDataTransferObjects(fundStructure);
        }


        /// <summary>
        ///     Gets the fund structures active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     IList&lt;FundStructureModel&gt;.
        /// </returns>
        public IList<FundStructureModel> GetFundStructuresActive(bool isActive)
        {
            var fundStructure = FundStructureClient.GetProjectsByActive(isActive);
            return Mapper.FromDataTransferObjects(fundStructure);
        }


        /// <summary>
        ///     Gets the fund structure.
        /// </summary>
        /// <param name="fundStructureId">The fund structure identifier.</param>
        /// <returns>
        ///     FundStructureModel.
        /// </returns>
        public FundStructureModel GetFundStructure(string fundStructureId)
        {
            var fundStructure = FundStructureClient.GetFundStructure(fundStructureId);
            return Mapper.FromDataTransferObject(fundStructure);
        }


        /// <summary>
        ///     Adds the fund structure.
        /// </summary>
        /// <param name="fundStructure">The fund structure.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddFundStructure(FundStructureModel fundStructure)
        {
            var fundStructureEntity = Mapper.ToDataTransferObject(fundStructure);
            var response = FundStructureClient.InsertFundStructure(fundStructureEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FundStructureId;
        }


        /// <summary>
        ///     Updates the fund structure.
        /// </summary>
        /// <param name="fundStructure">The fund structure.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateFundStructure(FundStructureModel fundStructure)
        {
            var fundStructureEntity = Mapper.ToDataTransferObject(fundStructure);
            var response = FundStructureClient.UpdateFundStructure(fundStructureEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.FundStructureId;
        }


        /// <summary>
        ///     Deletes the fund structure.
        /// </summary>
        /// <param name="fundStructureId">The fund structure identifier.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteFundStructure(string fundStructureId)
        {
            var response = FundStructureClient.DeleteFundStructure(fundStructureId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FundStructureId;
        }

        #endregion

        #region BudgetSourceCategory

        /// <summary>
        ///     Gets the budget source categories.
        /// </summary>
        /// <returns>
        ///     IList{BudgetSourceCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategories()
        {
            var budgetSourceCategories = BudgetSourceCategoryClient.GetBudgetSourceCategories();
            return Mapper.FromDataTransferObjects(budgetSourceCategories);
        }

        /// <summary>
        ///     Gets the budget source categories active.
        /// </summary>
        /// <returns>
        ///     IList{BudgetSourceCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesActive()
        {
            const bool isAcvtive = true;
            var budgetSourceCategories = BudgetSourceCategoryClient.GetBudgetSourcesCategoryByIsActive(isAcvtive);
            return Mapper.FromDataTransferObjects(budgetSourceCategories);
        }

        /// <summary>
        ///     Gets the budget source categories non active.
        /// </summary>
        /// <returns>
        ///     IList{BudgetSourceCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesNonActive()
        {
            const bool isAcvtive = false;
            var budgetSourceCategories = BudgetSourceCategoryClient.GetBudgetSourcesCategoryByIsActive(isAcvtive);
            return Mapper.FromDataTransferObjects(budgetSourceCategories);
        }

        /// <summary>
        ///     Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        ///     BudgetSourceCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetSourceCategoryModel GetBudgetSourceCategory(string budgetSourceCategoryId)
        {
            var budgetSourceCategory = BudgetSourceCategoryClient.GetBudgetSourceCategoryById(budgetSourceCategoryId);
            return Mapper.FromDataTransferObject(budgetSourceCategory);
        }

        /// <summary>
        ///     Adds the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory)
        {
            var budgetSourceCategoryEntity = Mapper.ToDataTransferObject(budgetSourceCategory);
            var response = BudgetSourceCategoryClient.InsertBudgetSourceCategory(budgetSourceCategoryEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetSourceCategoryId;
        }

        /// <summary>
        ///     Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory)
        {
            var budgetSourceCategoryEntity = Mapper.ToDataTransferObject(budgetSourceCategory);
            var response = BudgetSourceCategoryClient.UpdateBudgetSourceCategory(budgetSourceCategoryEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.BudgetSourceCategoryId;
        }

        /// <summary>
        ///     Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBudgetSourceCategory(string budgetSourceCategoryId)
        {
            var response = BudgetSourceCategoryClient.DeleteBudgetSourceCategory(budgetSourceCategoryId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetSourceCategoryId;
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        public IList<BUPlanReceiptModel> GetBUPlanReceipt()
        {
            var buPlanReceipt = BUPlanReceiptClient.GetBUPlanReceip();

            return Mapper.FromDataTransferObjects(buPlanReceipt);
        }

        /// <summary>
        ///     Gets the bu plan receipby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<BUPlanReceiptModel> GetBUPlanReceiptbyRefId(string refId)
        {
            var buPlanReceipt = BUPlanReceiptClient.GetBUPlanReceiptEntitybyRefId(refId);

            return Mapper.FromDataTransferObjects(buPlanReceipt);
        }

        /// <summary>
        ///     Gets the bu plan receipby reference type identifier.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public IList<BUPlanReceiptModel> GetBUPlanReceiptbyRefType(int refType)
        {
            var buPlanReceipt = BUPlanReceiptClient.GetBUPlanReceiptByRefType(refType);

            return Mapper.FromDataTransferObjects(buPlanReceipt);
        }

        /// <summary>
        ///     Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string InsertBUPlanReceipt(BUPlanReceiptModel buPlanReceipt)
        {
            var buPlanReceiptEntity = Mapper.ToDataTransferObject(buPlanReceipt);
            var response = BUPlanReceiptClient.InsertBUPlanReceipt(buPlanReceiptEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateBUPlanReceipt(BUPlanReceiptModel buPlanReceipt)
        {
            var buPlanReceiptEntity = Mapper.ToDataTransferObject(buPlanReceipt);
            var response = BUPlanReceiptClient.UpdateBUPlanReceipt(buPlanReceiptEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteBUPlanReceipt(string refId)
        {
            var response = BUPlanReceiptClient.DeleteBUPlanReceipt(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        ///     Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAReceiptDetail">if set to <c>true</c> [is included ca receipt detail].</param>
        /// <returns></returns>
        public BUPlanReceiptModel GetBUPlanReceiptVoucherByRefId(string refId, bool isIncludedCAReceiptDetail)
        {
            var buPlanReceipt = BUPlanReceiptClient.GetBUPlanReceiptVoucherByRefId(refId, isIncludedCAReceiptDetail);

            return Mapper.FromDataTransferObject(buPlanReceipt);
        }

        public IList<BUPlanAdjustmentModel> GetBuPlanAdjustment()
        {
            var buPlanAdjustment = BuPlanAdjustmentClient.GetBuPlanAdjustment();

            return Mapper.FromDataTranferObjects(buPlanAdjustment);
        }

        public IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentbyRefNo(string refNo)
        {
            var buPlanAdjustment = BuPlanAdjustmentClient.GetBUPlanReceiptVoucherByRefId(refNo);

            return Mapper.FromDataTranferObjects(buPlanAdjustment);
        }

        public IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentbyRefTypeId(string refTypeId)
        {
            var buPlanAdjustment = BuPlanAdjustmentClient.GetBUPlanReceiptVoucherByRefId(refTypeId);

            return Mapper.FromDataTranferObjects(buPlanAdjustment);
        }

        public string InsertBUPlanAdjustment(BUPlanAdjustmentModel buPlanAdjustment)
        {
            var buPlanAdjustmentEntity = Mapper.ToDataTransferObject(buPlanAdjustment);
            var response = BuPlanAdjustmentClient.InsertBuPlanAdjustment(buPlanAdjustmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string UpdateBUPlanAdjustment(BUPlanAdjustmentModel buPlanAdjustment)
        {
            var buPlanAdjustmentEntity = Mapper.ToDataTransferObject(buPlanAdjustment);
            var response = BuPlanAdjustmentClient.UpdateBUPlanAdjustment(buPlanAdjustmentEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string DeleteBUPlanAdjustment(string refId)
        {
            var response = BuPlanAdjustmentClient.DeleteBuPlanAdjustment(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public IList<BUPlanAdjustmentModel> GetBUPlanAdjustmentVoucherbyRefId(string refId)
        {
            var buPlanAdjustment = BuPlanAdjustmentClient.GetBUPlanReceiptVoucherByRefId(refId);

            return Mapper.FromDataTranferObjects(buPlanAdjustment);
        }

        public BUPlanAdjustmentModel GetBuPlanAdjustmentbyRefId(string refId)
        {
            var buPlanAdjustment = BuPlanAdjustmentClient.GetBuPlanAdjustmentbyRefId(refId);

            return Mapper.FromDataTransferObject(buPlanAdjustment);
        }

        #endregion

        #region Voucher Reports

        /// <summary>
        ///     Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentC41BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashPaymentC41BB(refId);
            var reportDetails = VoucherReportClient.ReportCashRPaymentC41BBDetails(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C41BBDetails = reportDetails == null
                        ? new List<C41BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;
        }

        /// <summary>
        ///     Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashDepositC41BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashDepositC41BB(refId);
            var reportDetails = VoucherReportClient.ReportCashRPaymentC41BBDetails(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C41BBDetails = reportDetails == null
                        ? new List<C41BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;
        }

        /// <summary>
        ///     Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentFixedAssetC41BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashPaymentFixedAssetC41BB(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
            var reportDetails = VoucherReportClient.ReportCashPaymentFixedAssetC41BBDetails(refId);
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C41BBDetails = reportDetails == null
                        ? new List<C41BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;
        }

        /// <summary>
        ///     Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentGetFromBADeposit(string refId)
        {
            var reports = VoucherReportClient.ReportCashPaymentGetFromBADeposit(refId);
            var reportDetails = VoucherReportClient.ReportCashRPaymentC41BBDetails(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C41BBDetails = reportDetails == null
                        ? new List<C41BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;
        }

        /// <summary>
        ///     Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentPurchaseC41BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashPaymentPurchaseC41BB(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
            var reportDetails = VoucherReportClient.ReportCashPaymentPurchaseC41BBDetails(refId);
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C41BBDetails = reportDetails == null
                        ? new List<C41BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;

        }

        /// <summary>
        ///     Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C40BBModel> ReportCashReceiptC30BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashRecepitC30BB(refId);
            var reportDetails = VoucherReportClient.ReportCashRecepitC40BBDetails(refId);
            var reportModels = reports == null ? null : ReportMapper.FromDataTransferObject(reports.ToList());
            if (reportModels != null)
                foreach (var reportModel in reportModels)
                    reportModel.C40Details = reportDetails == null
                        ? new List<C40BBDetailModel>()
                        : ReportMapper.FromDataTransferObject(reportDetails.ToList());
            return reportModels;
        }

        /// <summary>
        ///     Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C45_BBModel> ReportCashRecepitC45BB(string refId)
        {
            var reports = VoucherReportClient.ReportCashRecepitC45BB(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObject(reports.ToList());
        }


        /// <summary>
        ///     Reports the cash payment C4 09.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C4_09Model&gt;.</returns>
        public IList<C4_09Model> ReportCAReceipt_C4_09(string refId, RefType refType = RefType.CAReceipt)
        {
            var reports = VoucherReportClient.ReportCAReceipt_C4_09(refId, refType);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="StartDate"></param>
        /// <param name="FiscalStartDate"></param>
        /// <param name="BudgetSourceKind"></param>
        /// <param name="TargetProgramID"></param>
        /// <param name="BankInfoID"></param>
        /// <param name="BudgetSourceID"></param>
        /// <param name="BudgetChapterCode"></param>
        /// <param name="BudgetSubKindItemCode"></param>
        /// <param name="MethodDistributeID"></param>
        /// <param name="BudgetItemCodeList"></param>
        /// <param name="IsActiveTemplate"></param>
        /// <param name="SystemDate"></param>
        /// <param name="IsSystemDate"></param>
        /// <param name="IsRefDate"></param>
        /// <param name="CheckCashWithDrawType"></param>
        /// <returns></returns>
        public IList<C203NSModel> ReportC203NSTT77(string refId, DateTime StartDate, DateTime FiscalStartDate,
            string BudgetSourceKind, string TargetProgramID, string BankInfoID, string BudgetSourceID,
            string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, bool IsActiveTemplate, DateTime SystemDate, bool IsSystemDate, bool IsRefDate,
            bool CheckCashWithDrawType)
        {
            var reports = VoucherReportClient.ReportC203NSTT77(refId, StartDate, FiscalStartDate,
                BudgetSourceKind, TargetProgramID, BankInfoID, BudgetSourceID,
                BudgetChapterCode, BudgetSubKindItemCode, MethodDistributeID,
                BudgetItemCodeList, IsActiveTemplate, SystemDate, IsSystemDate, IsRefDate,
                CheckCashWithDrawType);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        public IList<C302NSModel> GetReportC302NS(string refId, DateTime StartDate, int PayType, string TargetProgramID,
            string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, string InvestmentNumber, DateTime InvestmentDate, string YearPlan,
            bool CheckCashWithDrawType)
        {
            var reports = VoucherReportClient.GetReportC302NS(refId, StartDate, PayType,
                TargetProgramID,
                BudgetSourceID, BudgetChapterCode, BudgetSubKindItemCode, MethodDistributeID,
                BudgetItemCodeList, InvestmentNumber, InvestmentDate, YearPlan,
                CheckCashWithDrawType);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }


        public IList<C2_02a_NSModel> ReportBUPlanWithDraw(string refId, int IsGroupDetail, int IsShowDuplicate,
            int content, RefType refType = RefType.BUPlanWithDrawCash)
        {
            var reports = VoucherReportClient.ReportBUPlanWithDraw(refId, IsGroupDetail, IsShowDuplicate, content, refType);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        /// <summary>
        ///     Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDModel&gt;.</returns>
        public IList<C21HDModel> ReportCashReceiptSaleOutwardStock(string refId)
        {
            var reports = VoucherReportClient.ReportCashReceiptSaleOutwardStock(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailModel&gt;.</returns>
        public IList<C21HDDetailModel> ReportCashReceiptSaleOutwardStockDetail(string refId)
        {
            var reports = VoucherReportClient.ReportCashReceiptSaleOutwardStockDetail(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C20HDModel&gt;.</returns>
        public IList<C20HDModel> ReportCashReceiptSaleC20HD(string refId, int refType)
        {
            var reports = VoucherReportClient.ReportCashReceiptSaleC20HD(refId, refType);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Reports the cash payment_ C4_08.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C408Model> ReportCashPaymentC408(int refType, string refId)
        {
            var reports = VoucherReportClient.ReportCashPaymentC408(refType, refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Reports the C402 CKB.
        /// </summary>
        /// <param name="storeProceduce">The store proceduce.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C402CKBModel> ReportC402CKB(string storeProceduce, string refId)
        {
            var reports = VoucherReportClient.ReportC402CKB(storeProceduce, refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }
        public IList<C402CKBModel> ReportC205ANS(string storeProceduce, string refId)
        {
            var reports = VoucherReportClient.ReportC205ANS(storeProceduce, refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Reports the C409.
        /// </summary>
        /// <param name="storeProceduce">The store proceduce.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C4_09Model> ReportC409(string storeProceduce, string refId)
        {
            var reports = VoucherReportClient.ReportC409(storeProceduce, refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        public IList<VoucherModel> GetVoucherData(string refId, int reftype)
        {
            var reports = VoucherReportClient.GetVoucherData(refId, reftype);
            return reports == null ? null : Mapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSModel&gt;.</returns>
        public IList<C212NSModel> GetC212NS(string refId)
        {
            var reports = VoucherReportClient.GetC212NS(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        /// <summary>
        ///     Gets the C213 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C213NSModel&gt;.</returns>
        public IList<C213NSModel> GetC213NS(string refId)
        {
            var reports = VoucherReportClient.GetC213NS(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports);
        }

        #endregion

        #region Deposit Reports

        /// <summary>
        ///     Reports the S12 h.
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
        public IList<S12HModel> ReportS12H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter,
            bool summaryBudgetSubKindItem, bool IsDetail, int amountType, string currencyCode)
        {
            var reports = DepositReportClient.ReportS12H(startDate, fromDate, toDate, budgetChapterCode,
                budgetSubKindItemCode, accountNumber, bankId,
                summaryBankId, isSummaryBudgetChapter, summaryBudgetSubKindItem, IsDetail, amountType, currencyCode);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        /// <summary>
        ///     Reports the S12 h detail.
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
        public IList<S12HDetailModel> ReportS12HDetail(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter,
            bool summaryBudgetSubKindItem)
        {
            var reports = DepositReportClient.ReportS12HDetail(startDate, fromDate, toDate, budgetChapterCode,
                budgetSubKindItemCode, accountNumber, bankId,
                summaryBankId, isSummaryBudgetChapter, summaryBudgetSubKindItem);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        /// <summary>
        ///     Reports the S11 h.
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
        public IList<S11HModel> ReportS11H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, bool isSummarySource,
            bool showAccountingObjectInfo, string budgetSourceId, bool IsDetail, bool IsDetailMonth, int amountType, string currencyCode)
        {
            var reports = DepositReportClient.ReportS11H(startDate, fromDate, toDate, budgetChapterCode,
                budgetSubKindItemCode,
                accountNumber, isSummaryBudgetChapter, summaryBudgetSubKindItem, isSummarySource,
                showAccountingObjectInfo, budgetSourceId, IsDetail, IsDetailMonth, amountType, currencyCode);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        public IList<S11HDetailModel> ReportS11HDetail(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, string budgetSubKindItemCode, string accountNumber, bool isSummaryBudgetChapter,
            bool summaryBudgetSubKindItem)
        {
            var reports = DepositReportClient.ReportS11HDetail(startDate, fromDate, toDate, budgetChapterCode,
                budgetSubKindItemCode, accountNumber,
                isSummaryBudgetChapter, summaryBudgetSubKindItem);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        public IList<C301NSModel> ReportC301NS(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            var reports = VoucherReportClient.ReportC301NS(refId, refTypeId, isDetail, isParent, mH);
            return reports?.Select(m => Mapper.AutoMapper(m, new C301NSModel())).ToList();
        }

        public IList<C301NSDetailModel> ReportC301NSDetail(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            var reports = VoucherReportClient.ReportC301NSDetail(refId, refTypeId, isDetail, isParent, mH);
            return reports?.Select(m => Mapper.AutoMapper(m, new C301NSDetailModel())).ToList();
        }
        public IList<C301NSDetail2Model> ReportC301NSDetail2(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            var reports = VoucherReportClient.ReportC301NSDetail2(refId, refTypeId, isDetail, isParent, mH);
            return reports?.Select(m => Mapper.AutoMapper(m, new C301NSDetail2Model())).ToList();
        }
        public IList<C304NSModel> ReportC304NS(string refId)
        {
            var reports = VoucherReportClient.ReportC304NS(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        /// <summary>
        /// Giấy rút tiền mặt
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="isDetail"></param>
        /// <returns></returns>
        public IList<C409KBModel> GetReportC409KB(string refId, bool isDetail)
        {
            var reports = VoucherReportClient.ReportC409KB(refId, isDetail);
            return reports?.Select(m => Mapper.AutoMapper(m, new C409KBModel())).ToList();
        }
        public IList<C409KBDetailsModel> GetReportC409KBDetail(string refId, bool isDetail)
        {
            var reports = VoucherReportClient.ReportC409KBDetail(refId, isDetail);
            return reports?.Select(m => Mapper.AutoMapper(m, new C409KBDetailsModel())).ToList();
        }

        public IList<PaymentPurchaseModel> ReportPaymentPurchase(string refId)
        {
            var reports = VoucherReportClient.ReportPaymentPurchase(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        public IList<C205aModel> ReportC205A(string refId)
        {
            var reports = VoucherReportClient.ReportC205A(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        public IList<C206NSModel> ReportC206NS(string refId)
        {
            var reports = VoucherReportClient.ReportC206NS(refId);
            return reports == null ? null : ReportMapper.FromDataTransferObjects(reports.ToList());
        }

        #endregion

        #region ReportLedgerAccounting


        public IList<S27Model> GetReportS27(DateTime fromDate, DateTime toDate, string accountCode, string currencyCode,
            string budgetSourceId, string projectId, int amountType)
        {
            var result = ReportLedgerAccountingClient.GetReportS27(fromDate, toDate, accountCode, currencyCode,
                budgetSourceId, projectId, amountType);
            return result?.Select(m => Mapper.AutoMapper(m, new S27Model())).ToList();
        }

        /// <summary>
        ///     Gets the report S04 h.
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
        public IList<S04HModel> GetReportS04H(DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, int amountType, string currencyCode)
        {
            var reportS04H = ReportLedgerAccountingClient.GetReportS04H(fromDate, toDate, addSameEntry,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetSource,
                isSummaryBudgetChapter, summaryBudgetSubKindItem, amountType, currencyCode);
            return reportS04H == null ? null : ReportMapper.FromDataTransferObjects(reportS04H.ToList());
        }

        /// <summary>
        ///     Gets the report S05 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <returns>IList&lt;S05HModel&gt;.</returns>
        public IList<S05HModel> GetReportS05H(DateTime fromDate, DateTime toDate, string budgetChapterCode,
            bool isSummaryBudgetChapter, bool amounttype, string currencycode)
        {
            var reportS05H =
                ReportLedgerAccountingClient.GetReportS05H(fromDate, toDate, budgetChapterCode, isSummaryBudgetChapter, amounttype, currencycode);
            return reportS05H == null ? null : ReportMapper.FromDataTransferObjects(reportS05H.ToList());
        }

        /// <summary>
        ///     Gets the report S31 h.
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
        public IList<S31HModel> GetReportS31H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string accountNumber, int amountType, string currencyCode,string CorrespondingAccountNumber, string AccountingObjectID, string BudgetSourceID, string FundStructureID, string BudgetChapterCode, string BudgetKindItemCode, string BudgetItemCode, string ProjectID, string ContractID, string BankID, string ActivityId, string CapitalPlanID, bool IsAccountingObjectID, bool IsGroupBudgetSourceID, bool IsGroupFundStructureID, bool IsGroupBudgetChapterCode, bool IsGroupBudgetKindItemCode, bool IsGroupBudgetItemCode, bool IsGroupProjectID, bool IsGroupContractID, bool IsGroupBankID, bool IsGroupActivityId, bool IsGroupCapitalPlanID, bool IsGroupCurrencyCode, bool ISCustomer, bool ISVendor, bool ISEmployee, string CustomerID, string VendorID, string EmployeeID, string FixedAssetId, string InventoryItemId, bool IsGroupFixedAssetId, bool IsGroupInventoryItemId)
        {
            var reportS31H = ReportLedgerAccountingClient.GetReportS31H(startDate, fromDate, toDate, accountNumber, amountType, currencyCode,CorrespondingAccountNumber, AccountingObjectID, BudgetSourceID, FundStructureID, BudgetChapterCode, BudgetKindItemCode, BudgetItemCode, ProjectID, ContractID, BankID, ActivityId, CapitalPlanID,IsAccountingObjectID, IsGroupBudgetSourceID, IsGroupFundStructureID, IsGroupBudgetChapterCode, IsGroupBudgetKindItemCode, IsGroupBudgetItemCode, IsGroupProjectID, IsGroupContractID, IsGroupBankID, IsGroupActivityId, IsGroupCapitalPlanID, IsGroupCurrencyCode, ISCustomer, ISVendor, ISEmployee, CustomerID, VendorID, EmployeeID,FixedAssetId,InventoryItemId,IsGroupFixedAssetId,IsGroupInventoryItemId);
            return reportS31H == null ? null : ReportMapper.FromDataTransferObjects(reportS31H.ToList());
        }


        //public IList<S31HNoAccoutingObjectModel> GetReportS31HNoAccoutingObject(DateTime startDate, DateTime fromDate, DateTime toDate,
        // string accountNumber, string budgetSourceID,
        // bool isSumaryGroupBudgetSource, string budgetChapterCode, string budgetSubKindItemCode,
        // bool isSumaryGroupBudgetChapterCode, bool isSumaryGroupBudgetSubKindItemCode, int amountType, string currencyCode)
        //{
        //    var reportS31HNoAccountingObject = ReportLedgerAccountingClient.GetReportS31HNoAccountingObject(startDate, fromDate, toDate, accountNumber, budgetSourceID, isSumaryGroupBudgetSource, budgetChapterCode,
        //        budgetSubKindItemCode, isSumaryGroupBudgetChapterCode, isSumaryGroupBudgetSubKindItemCode, amountType, currencyCode);
        //    return reportS31HNoAccountingObject == null ? null : ReportMapper.FromDataTransferObject(reportS31HNoAccountingObject.ToList());
        //}

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
        public IList<S03HModel> GetReportS03H(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, int amountType, string currencyCode, bool isDetail)
        {
            var reportS03H = ReportLedgerAccountingClient.GetReportS03H(startDate, fromDate, toDate, addSameEntry,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13, amountType, currencyCode, isDetail);
            ;
            return reportS03H == null ? null : ReportMapper.FromDataTransferObjects(reportS03H.ToList());
        }

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
        public IList<S03HModel> GetReportS02CH(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, bool IsForeincurrency, int AmountType, string CurrencyCode)
        {
            var reportS03H = ReportLedgerAccountingClient.GetReportS02CH(startDate, fromDate, toDate, addSameEntry,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13, IsForeincurrency, AmountType, CurrencyCode);
            ;
            return reportS03H == null ? null : ReportMapper.FromDataTransferObjects(reportS03H.ToList());
        }

        /// <summary>
        ///     Gets the C33 bb.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="accountingObjectList">The accounting object list.</param>
        /// <returns>IList&lt;C33BBModel&gt;.</returns>
        public IList<C33BBModel> GetC33BB(DateTime fromdate, DateTime todate, string departmentId,
            string accountingObjectList)
        {
            var reportC33BB =
                ReportLedgerAccountingClient.GetC33BB(fromdate, todate, departmentId, accountingObjectList);
            return reportC33BB == null ? null : ReportMapper.FromDataTransferObjects(reportC33BB.ToList());
        }

        /// <summary>
        ///     Gets the S34 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns>IList&lt;S34H_GL_MasterModel&gt;.</returns>
        public IList<S34H_GL_MasterModel> GetS34H(DateTime startdate, DateTime fromDate, DateTime toDate,
            string accountnumber, string correspondingAccount,
            string AccountingObjectList, string ProjectList, bool issumaccount, bool groupsameitem, bool IsDetail, int amountType, string currencyCode)
        {
            var reportS34 = ReportLedgerAccountingClient.GetS34H(startdate, fromDate, toDate, accountnumber, correspondingAccount,
                AccountingObjectList,ProjectList, issumaccount, groupsameitem, IsDetail,amountType,currencyCode);
            return reportS34 == null ? null : ReportMapper.FromDataTransferObjects(reportS34.ToList());
        }

        /// <summary>
        ///     Gets the report S13 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accounts">The accounts.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>IList&lt;S13HModel&gt;.</returns>
        public IList<S13HModel> GetReportS13H(DateTime startDate, DateTime fromDate, DateTime toDate, string accounts,
            string currencyCode, bool isDetail, bool isDetailMonth, string bankAccount)
        {
            var reportS13H =
                ReportLedgerAccountingClient.GetReportS13H(startDate, fromDate, toDate, accounts, currencyCode,
                    isDetail, isDetailMonth, bankAccount);
            ;
            return reportS13H == null ? null : ReportMapper.FromDataTransferObjects(reportS13H.ToList());
        }

        /// <summary>
        ///     Gets the report S01 h.
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
        public DataTable GetReportS01H(DateTime fromDate, DateTime toDate, bool isViewOutAccount, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem)
        {
            return ReportLedgerAccountingClient.GetReportS01H(fromDate, toDate, isViewOutAccount, addSameEntry,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem);
        }

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
        public IList<S01HLedgerModel> GetReportS01HLedger(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,
            string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13)
        {
            var reportS01HLedger = ReportLedgerAccountingClient.GetReportS01HLedger(startDate, fromDate, toDate, addSameEntry,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13);
            ;
            return reportS01HLedger == null ? null : ReportMapper.FromDataTransferObjects(reportS01HLedger.ToList());
        }
        #endregion

        #region Treasury Reports

        /// <summary>
        ///     Gets the S52 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns>IList&lt;S52H_GL_MasterModel&gt;.</returns>
        public IList<S52H_GL_MasterModel> GetS52H(DateTime startdate, DateTime fromDate, DateTime toDate,
            string accountnumber, bool issumaccount, bool groupsameitem)
        {
            var reportS52 = TreasuaryReportClient.GetS52H(startdate, fromDate, toDate, accountnumber,
                issumaccount, groupsameitem);
            return reportS52 == null ? null : ReportMapper.FromDataTransferObjects(reportS52.ToList());
        }

        /// <summary>
        ///     Gets the report S101 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="?">The ?.</param>
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
        /// <returns>IList{B01HModel}.</returns>
        public IList<S101HModel> GetReportS101H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            var s101H = TreasuaryReportClient.GetS101H(startDate, fromDate, toDate, currencyCode, accountNumber,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode,
                budgetItemCode,
                isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem,
                isSummaryProject, isSummaryBudgetSourceCategory);
            return s101H == null ? null : ReportMapper.FromDataTransferObjects(s101H.ToList());
        }

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
        public DataSet GetReportS101HPartI(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportClient.GetS101HPartI(startDate, fromDate, toDate, currencyCode, accountNumber,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode,
                budgetItemCode,
                isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem,
                isSummaryProject, isSummaryBudgetSourceCategory);
        }

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
        public DataTable GetReportS101H1(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            string projectCode, string budgetSourceCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportClient.GetS101H1(startDate, fromDate, toDate, currencyCode, accountNumber,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode,
                budgetItemCode,
                isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem,
                isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        ///     Gets the report S101 h part ii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
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
        /// <returns>IList{S101HPartIIModel}.</returns>
        public IList<S101HPartIIModel> GetReportS101HPartII(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode, string accountNumber,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode,
            int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            var s101H = TreasuaryReportClient.GetS101HPartII(startDate, fromDate, toDate, currencyCode, accountNumber,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind,
                budgetItemCode,
                isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem,
                isSummaryProject, isSummaryBudgetSourceCategory);
            return s101H == null ? null : ReportMapper.FromDataTransferObjects(s101H.ToList());
        }

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
        public IList<S104HModel> GetReportS104H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            string budgetSourceCategoryCode, string budgetItemCode, string projectCode, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            var s101HPartII = TreasuaryReportClient.GetReportS104H(startDate, fromDate, toDate, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, budgetSourceCategoryCode, budgetItemCode, projectCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
            return s101HPartII == null ? null : ReportMapper.FromDataTransferObjects(s101HPartII.ToList());
        }

        /// <summary>
        /// Gets the report S101 h part iii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">The is summary account number.</param>
        /// <param name="isSummaryBudgetSource">The is summary budget source.</param>
        /// <param name="isSummaryBudgetChapter">The is summary budget chapter.</param>
        /// <param name="isSummaryBudgetSubKindItem">The is summary budget sub kind item.</param>
        /// <param name="isSummaryProject">The is summary project.</param>
        /// <param name="isSummaryBudgetSourceCategory">The is summary budget source category.</param>
        /// <returns>
        /// System.Collections.Generic.IList{Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary.S101HPartIIIModel}.
        /// </returns>
        public IList<S101HPartIIIModel> GetReportS101HPartIII(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode, string accountNumber,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode,
            int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            var s101HPartIII = TreasuaryReportClient.GetS101HPartIII(startDate, fromDate, toDate, currencyCode, accountNumber,
                budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind,
                budgetItemCode,
                isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem,
                isSummaryProject, isSummaryBudgetSourceCategory);
            return s101HPartIII == null ? null : ReportMapper.FromDataTransferObjects(s101HPartIII.ToList());
        }

        /// <summary>
        ///     Gets the report S102 h1.
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
        /// <returns>IList{S102H1Model}.</returns>
        public IList<S102H1Model> GetReportS102H1(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode,
            string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem,
            bool isSummaryProject)
        {
            var s102H1 = TreasuaryReportClient.GetS102H1(startDate, fromDate, toDate, currencyCode, budgetSourceCode,
                budgetChapterCode, budgetSubKindItemCode, projectCode, budgetItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
            return s102H1 == null ? null : ReportMapper.FromDataTransferObjects(s102H1.ToList());
        }

        /// <summary>
        ///     Gets the report S102 h2.
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
        public IList<S102H2Model> GetReportS102H2(DateTime startDate, DateTime fromDate, DateTime toDate,
            string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode,
            string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem,
            bool isSummaryProject)
        {
            var s102H2 = TreasuaryReportClient.GetS102H2(startDate, fromDate, toDate, currencyCode, budgetSourceCode,
                budgetChapterCode, budgetSubKindItemCode, projectCode, budgetItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
            return s102H2 == null ? null : ReportMapper.FromDataTransferObjects(s102H2.ToList());
        }

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
        public IList<S105H1Model> GetReportS105H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList)
        {
            var s105H1 = TreasuaryReportClient.GetS105H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetExpenseList);
            return s105H1 == null ? null : ReportMapper.FromDataTransferObjects(s105H1.ToList());
        }

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
        public IList<S105H2Model> GetReportS105H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode)
        {
            var s105H2 = TreasuaryReportClient.GetS105H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetItemCode);
            return s105H2 == null ? null : ReportMapper.FromDataTransferObjects(s105H2.ToList());
        }

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
        public IList<S106H2Model> GetReportS106H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode)
        {
            var s106H2 = TreasuaryReportClient.GetS106H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetItemCode);
            return s106H2 == null ? null : ReportMapper.FromDataTransferObjects(s106H2.ToList());
        }
        /// <summary>
        /// S106H1
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
        /// <param name="budgetExpenseList"></param>
        /// <returns></returns>
        public IList<S106H1Model> GetReportS106H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList)
        {
            var s106H1 = TreasuaryReportClient.GetS106H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetExpenseList);
            return s106H1 == null ? null : ReportMapper.FromDataTransferObjects(s106H1.ToList());
        }
        #endregion

        #region Inventory Report

        /// <summary>
        ///     Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        public IList<S22HModel> GetReportS22H(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds, string accountNumber, int amountType, string currencyCode)
        {
            var reportS22H =
                InventoryReportClient.GetReportS22H(fromDate, toDate, stockId, inventoryItemIds, accountNumber, amountType, currencyCode);
            return reportS22H == null ? null : ReportMapper.FromDataTransferObjects(reportS22H.ToList());
        }

        #region sổ kho s21H

        /// <summary>
        ///     Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        public IList<S21HModel> GetReportS21H(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds, bool IsDetailMonth)
        {
            var reportS21H = InventoryReportClient.GetReportS21H(fromDate, toDate, stockId, inventoryItemIds, IsDetailMonth);
            return reportS21H == null ? null : ReportMapper.FromDataTransferObjects(reportS21H.ToList());
        }

        #endregion

        #region Báo cáo tồn kho

        /// <summary>
        ///     Gets the report S22 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="inventoryItemIds">The inventory item ids.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        public IList<InventoryBookModel> GetInventoryBook(DateTime fromDate, DateTime toDate, string stockId,
            string inventoryItemIds)
        {
            var inventoryBook = InventoryReportClient.GetInventoryBook(fromDate, toDate, stockId, inventoryItemIds);
            return inventoryBook == null ? null : Mapper.FromDataTransferObjects(inventoryBook.ToList());
        }

        #endregion

        public IList<S23HModel> GetReportS23H(DateTime fromDate, DateTime toDate, string inventoryItemIds,
            string accountNumber)
        {
            var reportS23H = InventoryReportClient.GetReportS23H(fromDate, toDate, inventoryItemIds, accountNumber);
            return reportS23H == null ? null : ReportMapper.FromDataTransferObjects(reportS23H.ToList());
        }

        #region Báo cáo tăng giảm công cụ dụng cụ

        public IList<ToolIncrementDecrementModel> ReportToolIncrementDecrement(DateTime fromDate, DateTime toDate,
            string departmentId, string inventoryItemId)
        {
            var reportTool =
                ToolIncrementDecrementClient.ReportToolIncrementDecrementEntitiesToolIncrementDecrement(fromDate,
                    toDate,
                    departmentId, inventoryItemId);
            return reportTool == null ? null : Mapper.FromDataTransferObjects(reportTool.ToList());
        }

        #endregion

        #region S26-H: Sổ theo dõi tài sản cố định tại nơi sử dụng

        /// <summary>
        ///     Gets the report S26 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="inventoryItemCategoryId">The inventory item category identifier.</param>
        /// <returns>IList&lt;S26HModel&gt;.</returns>
        public IList<S26HModel> GetReportS26H(DateTime fromDate, DateTime toDate,
            string inventoryItemCategoryId, string inventoryItemIds, int amountType, string currencyCode)
        {
            var reportS26H =
                InventoryReportClient.GetReportS26H(fromDate, toDate, inventoryItemCategoryId, inventoryItemIds,amountType,currencyCode);
            return reportS26H == null ? null : ReportMapper.FromDataTransferObjects(reportS26H.ToList());
        }

        #endregion

        #region Biên bản kiểm kê công cụ dụng cụ

        /// <summary>
        ///     Gets the minutes inventory tool.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="minutesEuqalBook">if set to <c>true</c> [minutes euqal book].</param>
        /// <param name="inventoryCategoryId">The inventory category identifier.</param>
        /// <param name="sumInventoryCategory">if set to <c>true</c> [sum inventory category].</param>
        /// <returns>IList&lt;MinutesInventoryToolModel&gt;.</returns>
        public IList<MinutesInventoryToolModel> GetMinutesInventoryTool(DateTime fromDate, DateTime toDate,
            string departmentId, bool minutesEuqalBook, string inventoryCategoryId, bool sumInventoryCategory)
        {
            var reportMinutesInventoryTool = InventoryReportClient.GetMinutesInventoryTool(fromDate, toDate,
                departmentId, minutesEuqalBook, inventoryCategoryId, sumInventoryCategory);
            return reportMinutesInventoryTool == null
                ? null
                : Mapper.FromDataTransferObjects(reportMinutesInventoryTool.ToList());
        }

        #endregion

        #endregion

        #region FixedAsset Report

        /// <summary>
        ///     Gets the fixed asset S24 h.
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
        public IList<FixedAssetS24HModel> GetFixedAssetS24H(string fromDate, string toDate, int usePurpose,
            string departmentId, string fixedAssetCategoryId, int fixedAssetCategoryGrade, bool printByCondition,
            bool printFixedAssetOpening, bool printFixedAssetIncrementInYear, bool printFixedAssetNotIncrement,
            string listFixedAssetID, int amountType, string currencyCode)
        {
            var fixedAssetS24H = FixedAssetReportClient.GetFixedAssetS24H(fromDate, toDate, usePurpose, departmentId,
                fixedAssetCategoryId, fixedAssetCategoryGrade, printByCondition, printFixedAssetOpening,
                printFixedAssetIncrementInYear, printFixedAssetNotIncrement, listFixedAssetID, amountType, currencyCode);
            return fixedAssetS24H == null ? null : ReportMapper.FromDataTransferObjects(fixedAssetS24H.ToList());
        }

        public IList<S26HModel> GetReportFixedAssetS26H(DateTime fromDate, DateTime toDate, string departmentId,
     string inventoryItemCategoryId, int amountType, string currencyCode)
        {
            var reportS26H =
                FixedAssetReportClient.GetReportFixedAssetS26H(fromDate, toDate, departmentId, inventoryItemCategoryId, amountType, currencyCode);
            return reportS26H == null ? null : ReportMapper.FromDataTransferObjects(reportS26H.ToList());
        }

        /// <summary>
        ///     Reports the inventory fixed asset entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isPrintBookQuantity">if set to <c>true</c> [is print book quantity].</param>
        /// <returns></returns>
        public IList<InventoryFixedAssetModel> ReportInventoryFixedAssetEntities(DateTime fromDate, DateTime toDate,
            bool isPrintBookQuantity)
        {
            var inventoryFixedAsset =
                FixedAssetReportClient.ReportInventoryFixedAssetEntities(fromDate, toDate, isPrintBookQuantity);
            return inventoryFixedAsset == null ? null : ReportMapper.FromDataTransferObjects(inventoryFixedAsset);
        }

        /// <summary>
        /// Gets the C55 hd.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isDetailByFixedAsset">if set to <c>true</c> [is detail by fixed asset].</param>
        /// <returns></returns>
        public IList<FixedAssetC55HDModel> GetC55HDReport(DateTime fromDate, DateTime toDate, bool isDetailByFixedAsset)
        {
            var c55HD = FixedAssetReportClient.GetC55HDReport(fromDate, toDate, isDetailByFixedAsset);
            return c55HD == null ? null : ReportMapper.FromDataTransferObjects(c55HD);
        }

        #endregion

        #region Cash Report

        #region Bảng xác nhận số dư tài khoản tiền gửi tại KBNN

        /// <summary>
        ///     Gets the cash in bank confirmation balance sheet.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="BankAccount">The bank account.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList&lt;CashInBankConfirmationBalanceSheetModel&gt;.</returns>
        public IList<CashInBankConfirmationBalanceSheetModel> GetCashInBankConfirmationBalanceSheet(DateTime fromDate,
            DateTime toDate, string BankAccount, string projectId, bool isSummaryProject)
        {
            var reportCashInBankConfirmationBalanceSheet =
                CashReportClient.GetCashInBankConfirmationBalanceSheet(fromDate, toDate, BankAccount, projectId,
                    isSummaryProject);
            return reportCashInBankConfirmationBalanceSheet == null
                ? null
                : Mapper.FromDataTransferObjects(reportCashInBankConfirmationBalanceSheet.ToList());
        }

        #endregion

        #region bảng đối chiếu tình hình sử dụng ngân sách tại kho bạc

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
        /// <returns>
        /// IList&lt;N02_SDKP_DVDT_TT77Model&gt;.
        /// </returns>
        public IList<N02_SDKP_DVDT_TT77Model> GetN02_SDKP_DVDT_TT77(DateTime dbStartdate, DateTime startDate,
            DateTime fromDate, DateTime toDate,
            string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId,
            string pBudgetSourceKind,
            string pBankAccount, bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem,
            bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13)
        {
            var reportN02 = CashReportClient.GetN02_SDKP_DVDT_TT77(dbStartdate, startDate,
                fromDate, toDate,
                pBudgetSourceId, pBudgetChapterCode, pBudgetSubKindItemCode, pMethodDistributeId, pBudgetSourceKind,
                pBankAccount, pSummaryBudgetSource, pSummaryBudgetChapter, pSummaryBudgetSubKindItem,
                pSummaryMethodDistribute, pIsAdjustTemplete, pIsPrintMonth13, pIsPrintAllYearAndMonth13);
            return reportN02 == null ? null : ReportMapper.FromDataTransferObjects(reportN02.ToList());
        }

        #endregion

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
        public IList<N01_SDKP_DVDTModel> GetN01_SDKP_DVDT(DateTime dbStartdate, DateTime startDate, DateTime fromDate,
            DateTime toDate,
            string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId,
            string pBudgetSourceKind,
            bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem,
            bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13, bool isStateTreasury)
        {
            var reportN01 = CashReportClient.GetN01_SDKP_DVDT(dbStartdate, startDate, fromDate, toDate,
                pBudgetSourceId, pBudgetChapterCode, pBudgetSubKindItemCode, pMethodDistributeId, pBudgetSourceKind,
                pSummaryBudgetSource, pSummaryBudgetChapter, pSummaryBudgetSubKindItem,
                pSummaryMethodDistribute, pIsAdjustTemplete, pIsPrintMonth13, pIsPrintAllYearAndMonth13, isStateTreasury);
            return reportN01 == null ? null : ReportMapper.FromDataTransferObjects(reportN01.ToList());
        }

        #region Chứng từ ghi sổ

        /// <summary>
        /// Reports the gl voucher list detail.
        /// </summary>
        /// <param name="RefId">The reference identifier.</param>
        /// <param name="IsShowSameRow">if set to <c>true</c> [is show same row].</param>
        /// <param name="IsShowOriginalCurrency">if set to <c>true</c> [is show original currency].</param>
        /// <returns></returns>
        public IList<GLVoucherListDetailModel> ReportGlVoucherListDetail(string RefId, bool IsShowSameRow,
            bool IsShowOriginalCurrency)
        {
            var reportGLVoucherList =
                GlVoucherListReportClient.ReportGlVoucherListDetail(RefId, IsShowSameRow, IsShowOriginalCurrency);
            return reportGLVoucherList == null ? null : Mapper.FromDataTranferObjects(reportGLVoucherList.ToList());
        }

        /// <summary>
        /// BC chứng từ kế toán
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        public IList<AccountingVoucherModel> ReportAccountingVoucher(string refId, int refType)
        {
            var resutl =
                GlVoucherListReportClient.ReportAccountingVoucher(refId, refType);
            return resutl?.Select(m => Mapper.AutoMapper(m, new AccountingVoucherModel())).ToList();
        }

        /// <summary>
        /// Reports the gl voucher list.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public IList<GLVoucherListModel> ReportGlVoucherList(DateTime fromDate, DateTime toDate, bool isNotShowSignAccount, int amountType, string currencyCode)
        {
            var reportGLVoucherList = GlVoucherListReportClient.ReportGlVoucherList(fromDate, toDate, isNotShowSignAccount, amountType, currencyCode);
            return reportGLVoucherList == null ? null : Mapper.FromDataTranferObjects(reportGLVoucherList.ToList());
        }

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
        public IList<GLVoucherListLedgerModel> ReportGLVoucherListLedger(DateTime fromDate, DateTime toDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList)
        {
            var reportGLVoucherListLedger = GlVoucherListReportClient.ReportGLVoucherListLedger(fromDate, toDate,
                budgetSourceId, budgetChapterCode,
                budgetSubKindItemCode, isSummarrySource, isSummaryChapter, isSummarySubKindItem, accountList);
            return reportGLVoucherListLedger == null
                ? null
                : Mapper.FromDataTranferObjects(reportGLVoucherListLedger.ToList());
        }

        /// <summary>
        /// Reports the S02 ch.
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
        public IList<S02CHModel> ReportS02CH(DateTime fromDate, DateTime toDate, DateTime startDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList)
        {
            var s02CH = GlVoucherListReportClient.ReportS02CH(fromDate, toDate, startDate,
                budgetSourceId, budgetChapterCode,
                budgetSubKindItemCode, isSummarrySource, isSummaryChapter, isSummarySubKindItem, accountList);
            return s02CH == null
                ? null
                : Mapper.FromDataTranferObjects(s02CH.ToList());
        }

        /// <summary>
        /// Reports the S02 ch.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="isSummaryInventory">if set to <c>true</c> [is summary inventory].</param>
        /// <param name="isSummaryActivity">if set to <c>true</c> [is summary activity].</param>
        /// <returns></returns>
        public IList<S51HModel> ReportS51H(DateTime fromDate, DateTime toDate, DateTime startDate,
            string inventoryItemId, string activityId, bool isSummaryInventory, bool isSummaryActivity)
        {
            var s551H = GlVoucherListReportClient.ReportS51H(fromDate, toDate, startDate,
                inventoryItemId, activityId, isSummaryInventory, isSummaryActivity);
            return s551H == null
                ? null
                : Mapper.FromDataTranferObjects(s551H.ToList());
        }

        /// <summary>
        ///     Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="decreaseReasonId">The decrease reason identifier.</param>
        /// <returns></returns>
        public IList<FixedAssetDecreaseModel> ReportFixedAssetDecreaseListEntities(DateTime fromDate, DateTime toDate,
            int decreaseReasonId)
        {
            var fixedAssetDecrease =
                FixedAssetReportClient.ReportFixedAssetDecreaseListEntities(fromDate, toDate, decreaseReasonId);
            return fixedAssetDecrease == null ? null : ReportMapper.FromDataTransferObjects(fixedAssetDecrease);
        }

        public IList<FixedAssetIncreaseDecreaseModel> ReportFixedAssetIncreaseDecrease(DateTime fromDate, DateTime toDate)
        {
            var fixedAssetDecrease =
                FixedAssetReportClient.ReportFixedAssetIncreaseDecrease(fromDate, toDate);
            return fixedAssetDecrease == null ? null : ReportMapper.FromDataTransferObjects(fixedAssetDecrease);
        }

        /// <summary>
        ///     Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="sumFixedAssetCategory">if set to <c>true</c> [sum fixed asset category].</param>
        /// <returns>IList&lt;MinutesGetCountFixedAssetModel&gt;.</returns>
        public IList<MinutesGetCountFixedAssetModel> GetReportMinutesGetCountFixedAsset(DateTime fromDate,
            DateTime toDate, string departmentId, string fixedAssetCategoryId, bool sumFixedAssetCategory)
        {
            var minutesInventoryFixedAsset = FixedAssetReportClient.GetReportMinutesGetCountFixedAsset(fromDate, toDate,
                departmentId, fixedAssetCategoryId, sumFixedAssetCategory);
            return minutesInventoryFixedAsset == null
                ? null
                : ReportMapper.FromDataTransferObjects(minutesInventoryFixedAsset.ToList());
        }

        #endregion

        #endregion

        #region UserProfile

        /// <summary>
        ///     The user profile client
        /// </summary>
        private static readonly UserProfileFacade UserProfileClient = new UserProfileFacade();

        /// <summary>
        ///     The bu transfer detail purchase client
        /// </summary>
        private static readonly BUTransferDetailPurchaseFacade BUTransferDetailPurchaseClient =
            new BUTransferDetailPurchaseFacade();

        /// <summary>
        ///     Gets the user profiles.
        /// </summary>
        /// <returns></returns>
        public IList<UserProfileModel> GetUserProfiles()
        {
            var userProfiles = UserProfileClient.GetUserProfiles();
            return userProfiles?.Select(m => Mapper.AutoMapper(m, new UserProfileModel())).ToList();
        }

        /// <summary>
        ///     Gets the user profile.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public UserProfileModel GetUserProfile(string userProfileId)
        {
            var userProfile = UserProfileClient.GetUserProfile(userProfileId);
            return Mapper.AutoMapper(userProfile, new UserProfileModel());
            //return Mapper.FromDataTransferObject(userProfile);
        }

        /// <summary>
        ///     Updates the user profile.
        /// </summary>
        /// <param name="userProfile">The user profile.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string UpdateUserProfile(UserProfileModel userProfile)
        {
            var userProfileEntity = Mapper.AutoMapper(userProfile, new UserProfileEntity());
            var response = UserProfileClient.UpdateUserProfile(userProfileEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the user profile.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public string DeleteUserProfile(string userProfileId)
        {
            var response = UserProfileClient.DeleteUserProfile(userProfileId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Gets the bu transfer detail purchases by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<BUTransferDetailPurchaselModel> GetBUTransferDetailPurchasesByRefId(string refId)
        {
            var userProfiles = BUTransferDetailPurchaseClient.GetBUTransferDetailPurchasesByRefId(refId);
            return userProfiles?.Select(m => Mapper.AutoMapper(m, new BUTransferDetailPurchaselModel())).ToList();
        }

        #endregion
       
        #region Mua TSCĐ chưa thanh toán
        PUInvoiceFacade PUInvoiceClient = new PUInvoiceFacade();
        public IList<PUInvoiceModel> GetPUInvoicesByRefTypeId(int refTypeId)
        {
            var requests = PUInvoiceClient.GetPUInvoicesByRefTypeId(refTypeId);
            return requests.Select(m => Mapper.AutoMapper(m, new PUInvoiceModel())).ToList();
        }

        public PUInvoiceModel GetPUInvoice(string refId, bool isIncludedDetail)
        {
            var request = PUInvoiceClient.GetPUInvoice(refId, isIncludedDetail) ?? new PUInvoiceEntity();
            var model = Mapper.AutoMapper(request, new PUInvoiceModel());
            model.PUInvoiceDetailFixedAssets = request.PUInvoiceDetailFixedAssets.Select(m => Mapper.AutoMapper(m, new PUInvoiceDetailFixedAssetModel())).ToList();
            return model;
        }

        public string UpdatePUInvoice(PUInvoiceModel pUInvoice)
        {
            var entity = Mapper.AutoMapper(pUInvoice, new PUInvoiceEntity());
            entity.PUInvoiceDetailFixedAssets = pUInvoice.PUInvoiceDetailFixedAssets.Select(m => Mapper.AutoMapper(m, new PUInvoiceDetailFixedAssetEntity())).ToList();
            entity.ParallelEntities = pUInvoice.Parallels.Select(m => Mapper.AutoMapper(m, new SelectItemEntity())).ToList();
            var response = PUInvoiceClient.UpdatePUInvoice(entity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string DeletePUInvoice(string refId, int refType)
        {
            var response = PUInvoiceClient.DeletePUInvoice(refId, refType);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        public DataSet GetDataSet(string storeProcedure, object[] parms)
        {
            return VoucherReportClient.GetDataSet(storeProcedure, parms);
        }
        #endregion

        #region Tăng TSCĐ nhận bằng hiện vật
        public IList<FAIncrementDecrementModel> GetFAIncrementDecrementsByRefTypeId(int refTypeId)
        {
            var requests = FAIncrementDecrementFacade.GetFAIncrementDecrementsByRefTypeId(refTypeId);
            return requests.Select(m => Mapper.AutoMapper(m, new FAIncrementDecrementModel())).ToList();
        }

        public string DeleteFAIncrementDecrement(string refId)
        {
            var response = FAIncrementDecrementFacade.DeleteFAIncrementDecrement(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public FAIncrementDecrementModel GetFAIncrementDecrement(string refId, bool hasDetail)
        {
            var fAIncrementDecrement = FAIncrementDecrementFacade.GetFAIncrementDecrementByRefId(refId, hasDetail) ?? new FAIncrementDecrementEntity();
            var model = Mapper.AutoMapper(fAIncrementDecrement, new FAIncrementDecrementModel());
            model.FAIncrementDecrementDetails = fAIncrementDecrement.FAIncrementDecrementDetails.Select(m => Mapper.AutoMapper(m, new FAIncrementDecrementDetailModel())).ToList();
            return model;
        }

        public string AddFAIncrementDecrement(FAIncrementDecrementModel fAIncrementDecrement)
        {
            var entity = Mapper.AutoMapper(fAIncrementDecrement, new FAIncrementDecrementEntity());
            entity.FAIncrementDecrementDetails = fAIncrementDecrement.FAIncrementDecrementDetails.Select(m => Mapper.AutoMapper(m, new FAIncrementDecrementDetailEntity())).ToList();

            var response = FAIncrementDecrementFacade.UpdateFAIncrementDecrement(entity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }


        public string AddFAAdjustment(FAAdjustmentModel fAAdjustmentModel, bool isAutoGenerateParallel)
        {
            var entity = Mapper.AutoMapper(fAAdjustmentModel, new FAAdjustmentEntity());
            entity.FAAdjustmentDetails = fAAdjustmentModel.FAAdjustmentDetails.Select(m => Mapper.AutoMapper(m, new FAAdjustmentDetailEntity())).ToList();
            entity.FAAdjustmentDetailParallels = fAAdjustmentModel.FAAdjustmentDetailParallels.Select(m => Mapper.AutoMapper(m, new FAAdjustmentDetailParallelEntity())).ToList();
            var response = FAAdjustmentFacade.InsertFAAdjustment(entity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        public string UpdateFAAdjustment(FAAdjustmentModel fAAdjustmentModel, bool isAutoGenerateParallel)
        {
            var entity = Mapper.AutoMapper(fAAdjustmentModel, new FAAdjustmentEntity());
            entity.FAAdjustmentDetails = fAAdjustmentModel.FAAdjustmentDetails.Select(m => Mapper.AutoMapper(m, new FAAdjustmentDetailEntity())).ToList();
            entity.FAAdjustmentDetailParallels = fAAdjustmentModel.FAAdjustmentDetailParallels.Select(m => Mapper.AutoMapper(m, new FAAdjustmentDetailParallelEntity())).ToList();

            var response = FAAdjustmentFacade.UpdateFAAdjustment(entity, isAutoGenerateParallel);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        public string DeleteFAAdjustment(string refId)
        {
            var response = FAAdjustmentFacade.DeleteFAAdjustment(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }



        #endregion

        #region

        public DataTable GetAttributionDepreciationFA(DateTime fromDate, DateTime toDate, string FixedAssetId,
            int IsPeriod, int IsType)
        {
            return FixedAssetReportClient.GetAttributionDepreciationFA(fromDate, toDate, FixedAssetId, IsPeriod, IsType);
        }
        #endregion

        #region Report List
        public ReportListModel GetReportListByReportId(string reportId)
        {
            var reportList = ReportListClient.GetReportListByReportId(reportId) ?? new BusinessEntities.Report.ReportListEntity();
            var model = Mapper.AutoMapper(reportList, new ReportListModel());
            return model;
        }

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<OriginalGeneralLedgerModel> GetSearchVoucher(string whereClause)
        {
            var originalGeneralLedger = OriginalGeneralLedgerClient.GetSearchVoucher(whereClause);
            return Mapper.FromDataTransferObjects(originalGeneralLedger);
        }


        #endregion

        #region ConvertDB

        public string ConvertDB(string connectionString, string action)
        {
            return ConvertDbFacade.ConvertDB(connectionString, action);
        }
        #endregion


        #region CapitalPlan
        public IList<CapitalPlanModel> GetCapitalPlans()
        {
            var result = CapitalPlanClient.GetCapitalPlans();
            result = result.Count <= 0 ? null : result;
            return result?.Select(m => Mapper.AutoMapper(m, new CapitalPlanModel())).ToList();
        }
        public CapitalPlanModel GetCapitalPlan(string capitalplanId)
        {
            var result = CapitalPlanClient.GetCapitalPlan(capitalplanId) ?? new CapitalPlanEntity();
            return Mapper.AutoMapper(result, new CapitalPlanModel());
        }
        public string AddCapitalPlan(CapitalPlanModel capitalplan)
        {
            var entity = Mapper.AutoMapper(capitalplan, new CapitalPlanEntity());
            var response = CapitalPlanClient.InsertCapitalPlan(entity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CapitalPlanId;
        }
        public string UpdateCapitalPlan(CapitalPlanModel capitalplan)
        {
            var entity = Mapper.AutoMapper(capitalplan, new CapitalPlanEntity());
            var response = CapitalPlanClient.UpdateCapitalPlan(entity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CapitalPlanId;
        }
        public string DeleteCapitalPlan(string capitalplanId)
        {
            var response = CapitalPlanClient.DeleteCapitalPlan(capitalplanId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CapitalPlanId;
        }
        #endregion


        public IList<ExportXmlModel> GetExportXml()
        {
            var exportXml = ExportXmlClient.GetExportXmlEntities();
            return exportXml.Select(m => Mapper.AutoMapper(m, new ExportXmlModel())).ToList();
        }


        public IList<ExportXmlDetailModel> GetExportXmlDetail(string refType)
        {
            var exportXml = ExportXmlClient.GetExportXmlDetailEntities(refType);
            return exportXml.Select(m => Mapper.AutoMapper(m, new ExportXmlDetailModel())).ToList();
        }


        #region Xuất khẩu xml báo cáo tài chính
        public IList<ExportXmlBCTCModel> GetExportXmlBCTC()
        {
            var exportXml = ExportXmlClient.GetExportXmlBCTCEntities();
            return exportXml.Select(m => Mapper.AutoMapper(m, new ExportXmlBCTCModel())).ToList();
        }


        public IList<ExportXmlBCTCBudgetSourceModel> GetExportXmlBCTCBudgetSource()
        {
            var exportXml = ExportXmlClient.GetExportXmlBCTCBudgetSourceEntities();
            return exportXml.Select(m => Mapper.AutoMapper(m, new ExportXmlBCTCBudgetSourceModel())).ToList();
        }

        public string Delete_BudgetSourceMappingToExport()
        {
            var response = ExportXmlClient.Delete_BudgetSourceMappingToExport();
            return null;
        }

        public string InsertBudgetSourceMappingToExport(ExportXmlBCTCBudgetSourceModel budgetSourceModel)
        {
            var entity = Mapper.AutoMapper(budgetSourceModel, new ExportXmlBCTCBudgetSourceEntity());
            var response = ExportXmlClient.InsertBudgetSourceMappingToExport(entity);
            //if (response.Acknowledge != AcknowledgeType.Success)
            //    throw new ApplicationException(response.Message);
            //return response.RefId;
            return null;
        }

        #endregion

        #region Nhóm báo cáo xuất XML Báo cáo tài chính
        /// <summary>
        /// B01/BCQT: Báo cáo quyết toán kinh phí hoạt động
        /// </summary>
        public DataSet GetReportB01BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, bool isSummarySXKD)
        {
            var b01BCQT = SettlementReportFacade.GetReportB01BCQT_XmlBCTC(startDate, fromDate, toDate, procedureName, isSummarySXKD);
            return b01BCQT;
        }

        public DataSet GetReportB03BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var b03BCQT = SettlementReportFacade.GetReportB03BCQT_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return b03BCQT;
        }

        public DataSet GetReportBCTC01_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, string budgetChapterCode, bool isSummaryBudgetChapter)
        {
            var b01BCTC = SettlementReportFacade.GetReportBCTC01_XmlBCTC(startDate, fromDate, toDate, procedureName, budgetChapterCode, isSummaryBudgetChapter);
            return b01BCTC;
        }

        public DataSet GetReportBCTC02_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var b02BCTC = SettlementReportFacade.GetReportBCTC02_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return b02BCTC;
        }

        /// <summary>
        /// B04/BCTC: Thuyết minh báo cáo tài chính
        /// </summary>
        public DataSet GetReportBCTC04_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var b04BCTC = SettlementReportFacade.GetReportBCTC04_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return b04BCTC;
        }

        /// <summary>
        /// B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
        /// </summary>
        public DataSet GetReportB03bBCTC_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var b04BCTC = SettlementReportFacade.GetReportB03bBCTC_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return b04BCTC;
        }

        /// <summary>
        /// B05/BCTC: Báo cáo tài chính mẫu đơn giản
        /// </summary>
        public DataSet GetReportBCTC05_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var b05BCTC = SettlementReportFacade.GetReportBCTC05_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return b05BCTC;
        }

        /// <summary>
        /// F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
        /// </summary>
        public DataSet GetReportF0101BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var f01BCQT = SettlementReportFacade.GetReportF0101BCQT_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return f01BCQT;
        }

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP1_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var freport = SettlementReportFacade.GetReportF0102BCQTP1_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return freport;
        }

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP2_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            var freport = SettlementReportFacade.GetReportF0102BCQTP2_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return freport;
        }

        /// <summary>
        /// B01/BSTT: Báo cáo bổ sung thông tin tài chính
        /// </summary>
        public DataSet GetReportB01BSTT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            return SettlementReportFacade.GetReportB01BSTT_XmlBCTC(startDate, fromDate, toDate, procedureName);
        }
        #endregion

        #region Nhóm xuất khẩu BC gửi kho bạc nhà nước
        /// <summary>
        /// B01/BCTC
        /// </summary>
        public DataSet GetSumReportB01BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB01BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B02/BCTC
        /// </summary>
        public DataSet GetSumReportB02BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB02BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B03a/BCTC
        /// </summary>
        public DataSet GetSumReportB03aBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB03aBCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B03b/BCTC
        /// </summary>
        public DataSet GetSumReportB03bBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB03bBCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B04/BCTC
        /// </summary>
        public DataSet GetSumReportB04BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB04BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B01BSTT
        /// </summary>
        public DataSet GetSumReportB01BSTT_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return SettlementReportFacade.GetSumReportB01BSTT_XmlToTreasury(startDate, fromDate, toDate);
        }

        #endregion

        /// <summary>
        /// S05H: Bảng cân đối số phát sinh
        /// </summary>
        public DataSet GetReportS05H_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            return SettlementReportFacade.GetReportS05H_XmlBCTC(startDate, fromDate, toDate, procedureName);
        }

        #region Contract

        /// <summary>
        ///     Gets the Contracts.
        /// </summary>
        /// <returns>
        ///     IList{ContractModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ContractModel> GetContracts()
        {
            var Contract = ContractClient.GetContracts();
            return Mapper.FromDataTransferObjects(Contract);
        }
        public IList<ContractDetailsModel> GetContractDetails()
        {
            var ContractDetail = ContractClient.GetContractDetails();
            return Mapper.FromDataTransferObjects(ContractDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<ContractModel> GetContractsActive(bool isActive)
        {
            var Contract = ContractClient.GetContractsActive(isActive);
            return Mapper.FromDataTransferObjects(Contract);
        }

        /// <summary>
        ///     Gets the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns>
        ///     ContractModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public ContractModel GetContract(string ContractId)
        {
            var Contract = ContractClient.GetContract(ContractId);
            return Mapper.FromDataTransferObject(Contract);
        }
        public List<ContractDetailsModel> GetContractDetail(string contractId)
        {
            var ContractDetail = ContractClient.GetContractDetail(contractId);
            return Mapper.FromDataTransferObject(ContractDetail);
        }
        public ContractModel GetContractByContractNo(string contractNo)
        {
            var Contract = ContractClient.GetContractByContractNo(contractNo);
            return Mapper.FromDataTransferObject(Contract);
        }

        public IList<ContractModel> GetContractByProjectId(string projectId)
        {
            var Contract = ContractClient.GetContractByProjectId(projectId);
            return Mapper.FromDataTransferObjects(Contract);
        }

        /// <summary>
        ///     Adds the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string AddContract(ContractModel Contract)
        {
            var ContractEntity = Mapper.ToDataTransferObject(Contract);
            var response = ContractClient.InsertContract(ContractEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ContractId;
        }

        /// <summary>
        ///     Updates the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateContract(ContractModel Contract)
        {
            var ContractEntity = Mapper.ToDataTransferObject(Contract);
            var response = ContractClient.UpdateContract(ContractEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ContractId;
        }

        /// <summary>
        ///     Deletes the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteContract(string ContractId)
        {
            var response = ContractClient.DeleteContract(ContractId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ContractId;
        }
        public string DeleteContractDetail(string ContractDetailId)
        {
            return ContractClient.DeleteContractDetail(ContractDetailId);
        }

        #endregion

        private static T PrepareRequest<T>(T request) where T : RequestBase
        {
            return request;
        }


        #region Lock book

        public LockModel GetLock()
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "Get" };
            var response = LockClient.GetLock(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }

        public string SaveLock(LockModel model)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "ExcuteLock" };
            request.Lock = Mapper.ToDataTransferObject(model);
            var response = LockClient.SetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public LockModel CheckLock(string refId, int refTypeId, DateTime refDate)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "CheckPostedDate" };
            request.RefId = refId;
            request.RefTypeId = refTypeId;
            request.RefDate = refDate;
            var response = LockClient.GetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }

        public LockModel CheckLock(string refId, int refTypeId)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "CheckRefID" };
            request.RefId = refId;
            request.RefTypeId = refTypeId;
            var response = LockClient.GetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }
        #endregion Lock book

        public long InsertOrUpdateReportDataTemplate(ReportDataTemplateModel reportDataTemplate)
        {
            var reportDataTemplateEntity = ReportMapper.ToDataTransferObject(reportDataTemplate);
            var response = ReportDataTemplateClient.InsertOrUpdateReportDataTemplate(reportDataTemplateEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Index;
        }
        public ReportDataTemplateModel GetReportDataTemplate(string dataTemplateCode)
        {
            var reportDataTemplate = ReportDataTemplateClient.GetReportDataTemplate(dataTemplateCode);
            return ReportMapper.FromDataTransferObject(reportDataTemplate);
        }

        public string CheckExistAccountNumber(string account,string accountNumber)
        {
            var response = AccountClient.CheckExistAccountNumber(account,accountNumber);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Message;
        }

        #region CalculateClosing

        public CalculateClosingModel GetCalculateClosing(string creditAccount, string currencyCode, DateTime todate,string RefID, int RefTypeId)
        {
            var request = PrepareRequest(new CalculateClosingRequest());
            request.LoadOptions = new[] { "CalculateClosing" };
            request.PaymentAccountId = creditAccount;
            request.CurrencyCode = currencyCode;
            request.ToDate = todate;
            request.RefId = RefID;
            request.RefTypeId = RefTypeId;
            var response = CalculateClosingClient.GetCalculateClosing(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.CalculateClosing);
        }

        #endregion
    }
}
