/***********************************************************************
 * <copyright file="IDaoFactory.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.ExportXml;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;

namespace Buca.Application.iBigTime2020.DataAccess
{
    /// <summary>
    /// interface IDaoFactory
    /// </summary>
    public interface IDaoFactory
    {
        #region FixedAssetReportDao

        /// <summary>
        /// Gets the fixed asset report DAO.
        /// </summary>
        /// <value>
        /// The fixed asset report DAO.
        /// </value>
        IFixedAssetReportDao FixedAssetReportDao { get; }

        #endregion

        #region FinacialReportDao

        /// <summary>
        /// Gets the finacial report DAO.
        /// </summary>
        /// <value>
        /// The finacial report DAO.
        /// </value>
        IFinacialReportDao FinacialReportDao { get; }

        #endregion

        #region SettlememtReport

        /// <summary>
        /// Gets the settlement report DAO.
        /// </summary>
        /// <value>
        /// The settlement report DAO.
        /// </value>
        ISettlementReportDao SettlememtReportDao { get; }

        #endregion

        #region Dictionary
        /// Gets the Calculate Closing Dao.
        /// </summary>
        /// <value>The Calculate Closing Dao.</value>
        ICalculateClosingDao CalculateClosingDao { get; }
        /// <summary>
        /// Gets the budget providence DAO.
        /// </summary>
        /// <value>The budget providence DAO.</value>
        IBudgetProvidenceDao BudgetProvidenceDao { get; }

        /// <summary>
        /// Gets the budget providence DAO.
        /// </summary>
        /// <value>The budget providence DAO.</value>
        IBudgetExpenseDao BudgetExpenseDao { get; }

        /// <summary>
        /// Gets the cash withdraw type DAO.
        /// </summary>
        /// <value>
        /// The cash withdraw type DAO.
        /// </value>
        ICashWithdrawTypeDao CashWithdrawTypeDao { get; }

        /// <summary>
        /// Gets the account DAO.
        /// </summary>
        /// <value>
        /// The account DAO.
        /// </value>
        IAccountDao AccountDao { get; }

        /// <summary>
        /// Gets the automatic identifier DAO.
        /// </summary>
        /// <value>The automatic identifier DAO.</value>
        IAutoIDDao AutoIDDao { get; }

        IActivityDao ActivityDao { get; }
        ICapitalPlanDao CapitalPlanDao { get; }

        IAudittingLogDao AudittingLogDao { get; }

        //IMutualDao MutualDao { get; }

        ///// <summary>
        ///// Gets the exchange rate DAO.
        ///// </summary>
        ///// <value>
        ///// The exchange rate DAO.
        ///// </value>
        //IExchangeRateDao ExchangeRateDao { get; }

        //IAutoNumberListDao AutoNumberListDao { get; }

        ///// <summary>
        ///// Gets the Calculate Closing Dao.
        ///// </summary>
        ///// <value>
        ///// The Calculate Closing Dao.
        ///// </value>
        //ICalculateClosingDao CalculateClosingDao { get; }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        IDepartmentDao DepartmentDao { get; }

        /// <summary>
        /// Gets the employee type DAO.
        /// </summary>
        /// <value>
        /// The employee type DAO.
        /// </value>
        IEmployeeTypeDao EmployeeTypeDao { get; }

        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        IAccountCategoryDao AccountCategoryDao { get; }
        IAccountingObjectCategoryDao AccountingObjectCategoryDao { get; }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        IBudgetItemDao BudgetItemDao { get; }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        IBudgetKindItemDao BudgetKindItemDao { get; }

        IFeatureDao FeatureDao { get; }
        IFeaturePermisionDao FeaturePermisionDao { get; }


        IUserFeaturePermisionDao UserFeaturePermisionDao { get; }
        IUserControlMainDesktopDao UserControlMainDesktopDao { get; }

        IUserPermisionDao UserPermisionDao { get; }

        ///// <summary>
        ///// Gets the customer DAO.
        ///// </summary>
        ///// <value>
        ///// The customer DAO.
        ///// </value>
        //ICustomerDao CustomerDao { get; }

        ///// <summary>
        ///// Gets the vendor DAO.
        ///// </summary>
        ///// <value>
        ///// The vendor DAO.
        ///// </value>
        //IVendorDao VendorDao { get; }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        IAccountingObjectDao AccountingObjectDao { get; }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        IVoucherListDao VoucherListDao { get; }

        ///// <summary>
        ///// Gets the other accouting object DAO.
        ///// </summary>
        ///// <value>
        ///// The other accouting object DAO.
        ///// </value>
        //IAccountingObjectDao OtherAccoutingObjectDao { get; }

        ///// <summary>
        ///// Gets the fixed asset category DAO.
        ///// </summary>
        ///// <value>
        ///// The fixed asset category DAO.
        ///// </value>
        IFixedAssetCategoryDao FixedAssetCategoryDao { get; }

        ///// <summary>
        ///// Gets the fixed asset DAO.
        ///// </summary>
        ///// <value>
        ///// The fixed asset DAO.
        ///// </value>
        IFixedAssetDao FixedAssetDao { get; }

        /// <summary>
        /// Gets the fund structure DAO.
        /// </summary>
        /// <value>The fund structure DAO.</value>
        IFundStructureDao FundStructureDao { get; }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        IBudgetChapterDao BudgetChapterDao { get; }

        /// <summary>
        /// Gets the budget group item DAO.
        /// </summary>
        /// <value>
        /// The budget group item DAO.
        /// </value>
        IBudgetGroupItemDao BudgetGroupItemDao { get; }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        IBudgetSourceDao BudgetSourceDao { get; }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        IStockDao StockDao { get; }

        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        IInventoryItemDao InventoryItemDao { get; }

        /// <summary>
        /// Gets the inventory item category DAO.
        /// </summary>
        /// <value>The inventory item category DAO.</value>
        IInventoryItemCategoryDao InventoryItemCategoryDao { get; }

        /// <summary>
        /// Gets the currency DAO.
        /// </summary>
        /// <value>
        /// The currency DAO.
        /// </value>
        ICurrencyDao CurrencyDao { get; }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        IBankDao BankDao { get; }

        /// <summary>
        /// Gets the account transfer DAO.
        /// </summary>
        /// <value>The account transfer DAO.</value>
        IAccountTransferDao AccountTransferDao { get; }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        IDBOptionDao DBOptionDao { get; }

        /// <summary>
        /// Gets the report list DAO.
        /// </summary>
        /// <value>The report list DAO.</value>
        IReportListDao ReportListDao { get; }

        /// <summary>
        /// Gets the voucher report DAO.
        /// </summary>
        /// <value>The voucher report DAO.</value>
        IVoucherReportDao VoucherReportDao { get; }

        /// <summary>
        /// Gets the deposit report DAO.
        /// </summary>
        /// <value>The deposit report DAO.</value>
        IDepositReportDao DepositReportDao { get; }

        /// <summary>
        /// Gets the report ledger accounting DAO.
        /// </summary>
        /// <value>The report ledger accounting DAO.</value>
        IReportLedgerAccountingDao ReportLedgerAccountingDao { get; }

        /// <summary>
        /// Gets the treasuary report DAO.
        /// </summary>
        /// <value>The treasuary report DAO.</value>
        ITreasuaryReportDao TreasuaryReportDao { get; }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>The automatic business DAO.</value>
        IAutoBusinessDao AutoBusinessDao { get; }

        /// <summary>
        /// Gets the automatic business parallel DAO.
        /// </summary>
        /// <value>The automatic business parallel DAO.</value>
        IAutoBusinessParallelDao AutoBusinessParallelDao { get; }

        /// <summary>
        /// Gets the reference type DAO.
        /// </summary>
        /// <value>
        /// The reference type DAO.
        /// </value>
        IRefTypeDao RefTypeDao { get; }

        /// <summary>
        /// Gets the reference type category DAO.
        /// </summary>
        /// <value>The reference type category DAO.</value>
        IRefTypeCategoryDao RefTypeCategoryDao { get; }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        IProjectDao ProjectDao { get; }
        IContractDao ContractDao { get; }

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>
        /// The budget source category.
        /// </value>
        IBudgetSourceCategoryDao BudgetSourceCategory { get; }



        #endregion

        /// <summary>
        /// Gets the bu voucher list DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list DAO.
        /// </value>
        IBUVoucherListDao BUVoucherListDao { get; }
        ILockDao LockDao { get; }
        /// <summary>
        /// Gets the bu voucher list detail DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail DAO.
        /// </value>
        IBUVoucherListDetailDao BUVoucherListDetailDao { get; }

        /// <summary>
        /// Gets the bu voucher list detail parallel DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail parallel DAO.
        /// </value>
        IBUVoucherListDetailParallelDao BUVoucherListDetailParallelDao { get; }

        /// <summary>
        /// Gets the bu voucher list detail transfer DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail transfer DAO.
        /// </value>
        IBUVoucherListDetailTransferDao BUVoucherListDetailTransferDao { get; }

        /// <summary>
        /// Gets or sets the fa increment decrement DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement DAO.
        /// </value>
        IFAIncrementDecrementDao FAIncrementDecrementDao { get; }

        /// <summary>
        /// Gets or sets the fa increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement detail DAO.
        /// </value>
        IFAIncrementDecrementDetailDao FAIncrementDecrementDetailDao { get; }

        /// <summary>
        /// Gets the su increment decrement DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement DAO.
        /// </value>
        ISUIncrementDecrementDao SUIncrementDecrementDao { get; }

        /// <summary>
        /// Gets the su increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement detail DAO.
        /// </value>
        ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao { get; }

        /// <summary>
        /// Gets the su transfer DAO.
        /// </summary>
        /// <value>
        /// The su transfer DAO.
        /// </value>
        ISUTransferDao SUTransferDao { get; }

        /// <summary>
        /// Gets the su transfer detail DAO.
        /// </summary>
        /// <value>
        /// The su transfer detail DAO.
        /// </value>
        ISUTransferDetailDao SUTransferDetailDao { get; }

        /// <summary>
        /// Gets the fa depreciation DAO.
        /// </summary>
        /// <value>
        /// The fa depreciation DAO.
        /// </value>
        IFADepreciationDao FADepreciationDao { get; }

        /// <summary>
        /// Gets the fa depreciation detail DAO.
        /// </summary>
        /// <value>
        /// The fa depreciation detail DAO.
        /// </value>
        IFADepreciationDetailDao FADepreciationDetailDao { get; }

        /// <summary>
        /// Gets the ba with draw DAO.
        /// </summary>
        /// <value>
        /// The ba with draw DAO.
        /// </value>
        IBAWithDrawDao BAWithDrawDao { get; }

        /// <summary>
        /// Gets the ba with draw detail DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail DAO.
        /// </value>
        IBAWithDrawDetailDao BAWithDrawDetailDao { get; }

        /// <summary>
        /// Gets the ba with draw detail fixed asset fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail fixed asset fixed asset DAO.
        /// </value>
        IBAWithDrawDetailFixedAssetDao BAWithDrawDetailFixedAssetDao { get; }

        /// <summary>
        /// Gets the ba with draw detail purchase DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail purchase DAO.
        /// </value>
        IBAWithDrawDetailPurchaseDao BAWithDrawDetailPurchaseDao { get; }

        /// <summary>
        /// Gets the ba withdraw detail salary DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail salary DAO.
        /// </value>
        IBAWithdrawDetailSalaryDao BAWithdrawDetailSalaryDao { get; }

        /// <summary>
        /// Gets the ba withdraw detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail tax DAO.
        /// </value>
        IBAWithdrawDetailTaxDao BAWithdrawDetailTaxDao { get; }

        /// <summary>
        /// Gets the ba deposit DAO.
        /// </summary>
        /// <value>
        /// The ba deposit DAO.
        /// </value>
        IBADepositDao BADepositDao { get; }

        /// <summary>
        /// Gets the ba deposit detail DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail DAO.
        /// </value>
        IBADepositDetailDao BADepositDetailDao { get; }

        /// <summary>
        /// Gets the ba deposit detail fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail fixed asset DAO.
        /// </value>
        IBADepositDetailFixedAssetDao BADepositDetailFixedAssetDao { get; }

        /// <summary>
        /// Gets the ba deposit detail sale sale DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail sale sale DAO.
        /// </value>
        IBADepositDetailSaleDao BADepositDetailSaleDao { get; }

        /// <summary>
        /// Gets the ba deposit detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail tax DAO.
        /// </value>
        IBADepositDetailTaxDao BADepositDetailTaxDao { get; }


        /// <summary>
        /// Gets the bu commitment request DAO.
        /// </summary>
        /// <value>The bu commitment request DAO.</value>
        IBUCommitmentRequestDao BUCommitmentRequestDao { get; }
        /// <summary>
        /// Gets the bu commitment request detail DAO.
        /// </summary>
        /// <value>The bu commitment request detail DAO.</value>
        IBUCommitmentRequestDetailDao BUCommitmentRequestDetailDao { get; }

        /// <summary>
        /// Gets the bu commitment adjustment DAO.
        /// </summary>
        /// <value>The bu commitment adjustment DAO.</value>
        IBUCommitmentAdjustmentDao BUCommitmentAdjustmentDao { get; }
        /// <summary>
        /// Gets the bu commitment adjustment detail DAO.
        /// </summary>
        /// <value>The bu commitment adjustment detail DAO.</value>
        IBUCommitmentAdjustmentDetailDao BUCommitmentAdjustmentDetailDao { get; }

        /// <summary>
        /// Gets the opening commitment detail DAO.
        /// </summary>
        /// <value>The opening commitment detail DAO.</value>
        IOpeningCommitmentDetailDao OpeningCommitmentDetailDao { get; }

        /// <summary>
        /// Gets the opening commitment DAO.
        /// </summary>
        /// <value>The opening commitment DAO.</value>
        IOpeningCommitmentDao OpeningCommitmentDao { get; }

        /// <summary>
        /// Gets the bu transfer DAO.
        /// </summary>
        /// <value>The bu transfer DAO.</value>
        IBUTransferDao BUTransferDao { get; }
        /// <summary>
        /// Gets the bu transfer detail DAO.
        /// </summary>
        /// <value>The bu transfer detail DAO.</value>
        IBUTransferDetailDao BUTransferDetailDao { get; }
        /// <summary>
        /// Gets the bu transfer parallel detail DAO.
        /// </summary>
        /// <value>The bu transfer detail DAO.</value>
        IBUTransferDetailParallelDao BUTransferDetailParallelDao { get; }
        IBUTransferDetailPurchaseDao BUTransferDetailPurchaseDao { get; }
        /// <summary>
        /// Gets the ba bank transfer DAO.
        /// </summary>
        /// <value>
        /// The ba bank transfer DAO.
        /// </value>

        IBABankTransferDao BABankTransferDao { get; }

        /// <summary>
        /// Gets the ba bank transfer detail DAO.
        /// </summary>
        /// <value>
        /// The ba bank transfer detail DAO.
        /// </value>
        IBABankTransferDetailDao BABankTransferDetailDao { get; }

        /// <summary>
        /// Gets the inventory report DAO.
        /// </summary>
        /// <value>The inventory report DAO.</value>
        IInventoryReportDao InventoryReportDao { get; }

        /// <summary>
        /// Gets the tool increment decrement DAO.
        /// </summary>
        /// <value>The tool increment decrement DAO.</value>
        IToolIncrementDecrementDao ToolIncrementDecrementDao { get; }

        /// <summary>
        /// Gets the purchase purpose DAO.
        /// </summary>
        /// <value>
        /// The purchase purpose DAO.
        /// </value>
        IPurchasePurposeDao PurchasePurposeDao { get; }

        /// <summary>
        /// Gets the tax item DAO.
        /// </summary>
        /// <value>The tax item DAO.</value>
        ITaxItemDao TaxItemDao { get; }

        /// <summary>
        /// Gets the tax type DAO.
        /// </summary>
        /// <value>The tax type DAO.</value>
        ITaxTypeDao TaxTypeDao { get; }

        /// <summary>
        /// Gets the invoice form number DAO.
        /// </summary>
        /// <value>
        /// The invoice form number DAO.
        /// </value>
        IInvoiceFormNumberDao InvoiceFormNumberDao { get; }

        /// <summary>
        /// Gets the invoice form number category DAO.
        /// </summary>
        /// <value>
        /// The invoice form number category DAO.
        /// </value>
        IInvoiceTypeDao InvoiceTypeDao { get; }

        /// <summary>
        /// Gets the journal entry account DAO.
        /// </summary>
        /// <value>
        /// The journal entry account DAO.
        /// </value>
        IGeneralLedgerDao GeneralLedgerDao { get; }

        /// <summary>
        /// Gets the original general ledger DAO.
        /// </summary>
        /// <value>The original general ledger DAO.</value>
        IOriginalGeneralLedgerDao OriginalGeneralLedgerDao { get; }

        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        IAccountBalanceDao AccountBalanceDao { get; }

        /// <summary>
        /// Gets the bu plan withdraw DAO.
        /// </summary>
        /// <value>The bu plan withdraw DAO.</value>
        IBUPlanWithdrawDao BUPlanWithdrawDao { get; }

        /// <summary>
        /// Gets the bu plan withdraw detail DAO.
        /// </summary>
        /// <value>The bu plan withdraw detail DAO.</value>
        IBUPlanWithdrawDetailDao BUPlanWithdrawDetailDao { get; }

        /// <summary>
        /// Gets the ca receipt DAO.
        /// </summary>
        /// <value>The ca receipt DAO.</value>
        ICAReceiptDao CAReceiptDao { get; }

        /// <summary>
        /// Gets the ca receipt detail DAO.
        /// </summary>
        /// <value>The ca receipt detail DAO.</value>
        ICAReceiptDetailDao CAReceiptDetailDao { get; }

        /// <summary>
        /// Gets the ca receipt detail tax DAO.
        /// </summary>
        /// <value>The ca receipt detail tax DAO.</value>
        ICAReceiptDetailTaxDao CAReceiptDetailTaxDao { get; }

        /// <summary>
        /// Gets the ca payment detail tax DAO.
        /// </summary>
        /// <value>The ca payment detail tax DAO.</value>
        ICAPaymentDetailTaxDao CaPaymentDetailTaxDao { get; }

        /// <summary>
        /// Gets the ca payment DAO.
        /// </summary>
        /// <value>The ca payment DAO.</value>
        ICAPaymentDao CAPaymentDao { get; }

        /// <summary>
        /// Gets the ca payment detail DAO.
        /// </summary>
        /// <value>The ca payment detail DAO.</value>
        ICAPaymentDetailDao CAPaymentDetailDao { get; }

        /// <summary>
        /// Gets or sets the ca payment detail purchase.
        /// </summary>
        /// <value>The ca payment detail purchase.</value>
        ICAPaymentDetailPurchaseDao CAPaymentDetailPurchaseDao { get; }

        /// <summary>
        /// Gets the ca payment detail fixed asset DAO.
        /// </summary>
        /// <value>The ca payment detail fixed asset DAO.</value>
        ICAPaymentDetailFixedAssetDao CAPaymentDetailFixedAssetDao { get; }

        /// <summary>
        /// Gets the in inward outward DAO.
        /// </summary>
        /// <value>The in inward outward DAO.</value>
        IINInwardOutwardDao INInwardOutwardDao { get; }

        /// <summary>
        /// Gets the in inward outward detail DAO.
        /// </summary>
        /// <value>The in inward outward detail DAO.</value>
        IINInwardOutwardDetailDao INInwardOutwardDetailDao { get; }
        ///<summary>
        ///Gets the inward outward detail Parallel dao
        /// </summary>
        /// <value>
        /// the inward outward detail Parallel dao
        /// </value>
        IINInwardOutwardDetailParallelDao IINInwardOutwardDetailParallelDao { get; }
        /// <summary>
        /// Gets the inventory ledger DAO.
        /// </summary>
        /// <value>
        /// The inventory ledger DAO.
        /// </value>
        IInventoryLedgerDao InventoryLedgerDao { get; }

        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        ISupplyLedgerDao SupplyLedgerDao { get; }

        /// <summary>
        /// Gets the bu plan receipt detail DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt detail DAO.
        /// </value>
        IBUPlanReceiptDetailDao BUPlanReceiptDetailDao { get; }

        /// <summary>
        /// Gets the bu plan receipt DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt DAO.
        /// </value>
        IBUPlanReceiptDao BUPlanReceiptDao { get; }

        /// <summary>
        /// Gets the bu plan adjustment DAO.
        /// </summary>
        /// <value>The bu plan adjustment DAO.</value>
        IBUPlanAdjustmentDao BUPlanAdjustmentDao { get; }

        /// <summary>
        /// Gets the bu plan adjustment detail DAO.
        /// </summary>
        /// <value>The bu plan adjustment detail DAO.</value>
        IBUPlanAdjustmentDetailDao BuPlanAdjustmentDetailDao { get; }

        /// <summary>
        /// Gets the gl voucher list detail DAO.
        /// </summary>
        /// <value>The gl voucher list detail DAO.</value>
        IGLVoucherListDetailDao GlVoucherListDetailDao { get; }

        /// <summary>
        /// Gets the gl voucher list DAO.
        /// </summary>
        /// <value>The gl voucher list DAO.</value>
        IGLVoucherListDao GlVoucherListDao { get; }

        /// <summary>
        /// Gets the gl voucher list paramater DAO.
        /// </summary>
        /// <value>The gl voucher list paramater DAO.</value>
        IGLVoucherListParamaterDao GlVoucherListParamaterDao { get; }

        /// <summary>
        /// Gets the bu budget reserve DAO.
        /// </summary>
        /// <value>
        /// The bu budget reserve DAO.
        /// </value>
        IBUBudgetReserveDao BUBudgetReserveDao { get; }

        /// <summary>
        /// Gets the bu budget reserve detail.
        /// </summary>
        /// <value>
        /// The bu budget reserve detail.
        /// </value>
        IBUBudgetReserveDetailDao BUBudgetReserveDetail { get; }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        IFixedAssetLedgerDao FixedAssetLedgerDao { get; }

        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        IOpeningAccountEntryDao OpeningAccountEntryDao { get; }

        IOpeningInventoryEntryDao OpeningInventoryEntryDao { get; }

        /// <summary>
        /// Gets the opening fixed asset entry DAO.
        /// </summary>
        /// <value>The opening fixed asset entry DAO.</value>
        IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao { get; }

        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        IOpeningSupplyEntryDao OpeningSupplyEntryDao { get; }

        /// <summary>
        /// Gets the gl voucher DAO.
        /// </summary>
        /// <value>
        /// The gl voucher DAO.
        /// </value>
        IGLVoucherDao GLVoucherDao { get; }

        /// <summary>
        /// Gets the gl voucher detail DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail DAO.
        /// </value>
        IGLVoucherDetailDao GLVoucherDetailDao { get; }

        /// <summary>
        /// Gets the gl voucher detail tax DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail tax DAO.
        /// </value>
        IGLVoucherDetailTaxDao GLVoucherDetailTaxDao { get; }

        /// <summary>
        /// Gets the cash report DAO.
        /// </summary>
        /// <value>The cash report DAO.</value>
        ICashReportDao CashReportDao { get; }

        /// <summary>
        /// Gets the gl voucher list report DAO.
        /// </summary>
        /// <value>The gl voucher list report DAO.</value>
        IGLVoucherListReportDao GLVoucherListReportDao { get; }

        /// <summary>
        /// Gets the ca payment detail parallel DAO.
        /// </summary>
        /// <value>The ca payment detail parallel DAO.</value>
        ICAPaymentDetailParallelDao CAPaymentDetailParallelDao { get; }

        /// <summary>
        /// Gets the ca receipt detail parallel DAO.
        /// </summary>
        /// <value>The ca receipt detail parallel DAO.</value>
        ICAReceiptDetailParallelDao CAReceiptDetailParallelDao { get; }

        /// <summary>
        /// Gets the ba deposit detail parallel DAO.
        /// </summary>
        /// <value>The ba deposit detail parallel DAO.</value>
        IBADepositDetailParallelDao BADepositDetailParallelDao { get; }

        /// <summary>
        /// Gets the ba with draw detail parallel DAO.
        /// </summary>
        /// <value>The ba with draw detail parallel DAO.</value>
        IBAWithDrawDetailParallelDao BAWithDrawDetailParallelDao { get; }

        /// <summary>
        /// Gets the gl voucher detail parallel DAO.
        /// </summary>
        /// <value>The gl voucher detail parallel DAO.</value>
        IGLVoucherDetailParallelDao GLVoucherDetailParallelDao { get; }

        /// <summary>
        /// Gets the ba bank transfer detail parallel DAO.
        /// </summary>
        /// <value>The ba bank transfer detail parallel DAO.</value>
        IBABankTransferDetailParallelDao BABankTransferDetailParallelDao { get; }

        /// <summary>
        /// Gets the fixed asset detail accessory DAO.
        /// </summary>
        /// <value>
        /// The fixed asset detail accessory DAO.
        /// </value>
        IFixedAssetDetailAccessoryDao FixedAssetDetailAccessoryDao { get; }

        IUserProfileDao UserProfileDao { get; }

        IPUInvoiceDao PUInvoiceDao { get; }
        IPUInvoiceDetailFixedAssetDao PUInvoiceDetailFixedAssetDao { get; }

        IFAAdjustmentDetailFADao FAAdjustmentDetailFADao { get; }

        IExportXmlDao ExportXmlDao { get; }
        IReportDataTemplateDao ReportDataTemplateDao { get; }
    }
}