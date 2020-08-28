/***********************************************************************
 * <copyright file="SqlServerDaoFactory.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.ExportXml;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.General;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Inventory;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Report;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.ExportXml;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.PUInvoice;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// class SqlServerDaoFactory
    /// </summary>
    public class SqlServerDaoFactory : IDaoFactory
    {
        #region FinacialReportDao

        /// <summary>
        /// Gets the finacial report DAO.
        /// </summary>
        /// <value>
        /// The finacial report DAO.
        /// </value>
        public IFinacialReportDao FinacialReportDao
        {
            get { return new SqlServerFinacialReportDao(); }
        }

        public ILockDao LockDao
        {
            get { return new SqlServerLockDateDao(); }
        }


        public IAudittingLogDao AudittingLogDao
        {
            get { return new SqlServerAudittingLogDao(); }
        }

        public IGeneralLedgerDao GeneralLedgerDao
        {
            get { return new SqlServerGeneralLedgerDao(); }
        }

        #endregion

        #region SettlementReportDao

        /// <summary>
        /// Gets the finacial report DAO.
        /// </summary>
        /// <value>
        /// The finacial report DAO.
        /// </value>
        public ISettlementReportDao SettlememtReportDao
        {
            get { return new SqlServerSettlementReportDao(); }
        }

        #endregion

        #region Dictionary
        public ICalculateClosingDao CalculateClosingDao
        {
            get { return new SqlServerCalculateClosingDao(); }
        }
        /// <summary>
        /// Gets the budget providence DAO.
        /// </summary>
        /// <value>The budget providence DAO.</value>
        public IBudgetExpenseDao BudgetExpenseDao
        {
            get { return new SqlServerBudgetExpenseDao(); }
        }
        public ICapitalPlanDao CapitalPlanDao
        {
            get { return new SqlServerCapitalPlanDao(); }
        }

        /// <summary>
        /// Gets the budget providence DAO.
        /// </summary>
        /// <value>
        /// The budget providence DAO.
        /// </value>
        public IBudgetProvidenceDao BudgetProvidenceDao
        {
            get { return new SqlServerBudgetProvidenceDao(); }
        }

        /// <summary>
        /// Gets the cash withdraw type DAO.
        /// </summary>
        /// <value>
        /// The cash withdraw type DAO.
        /// </value>
        public ICashWithdrawTypeDao CashWithdrawTypeDao
        {
            get { return new SqlServerCashWithdrawTypeDao(); }
        }

        ///// <summary>
        ///// Gets the account DAO.
        ///// </summary>
        ///// <value>
        ///// The account DAO.
        ///// </value>
        public IAccountDao AccountDao
        {
            get { return new SqlServerAccountDao(); }
        }

        /// <summary>
        /// Gets the automatic number DAO.
        /// </summary>
        /// <value>
        /// The automatic number DAO.
        /// </value>
        public IAutoIDDao AutoIDDao
        {
            get { return new SqlServerAutoIDDao(); }
        }

        /// <summary>
        /// Gets the account tranfer DAO.
        /// </summary>
        /// <value>
        /// The account tranfer DAO.
        /// </value>
        public IAccountTransferDao AccountTransferDao
        {
            get { return new SqlServerAccountTransferDao(); }
        }

        /// <summary>
        /// Gets the invoice form number DAO.
        /// </summary>
        /// <value>
        /// The invoice form number DAO.
        /// </value>
        public IInvoiceFormNumberDao InvoiceFormNumberDao
        {
            get { return new SqlServerInvoiceFormNumberDao(); }
        }

        /// <summary>
        /// Gets the invoice form number category DAO.
        /// </summary>
        /// <value>
        /// The invoice form number category DAO.
        /// </value>
        public IInvoiceTypeDao InvoiceTypeDao
        {
            get { return new SqlServerInvoiceTypeDao(); }
        }

        ///// <summary>
        ///// Gets the currency DAO.
        ///// </summary>
        ///// <value>
        ///// The currency DAO.
        ///// </value>
        public ICurrencyDao CurrencyDao
        {
            get { return new SqlServerCurrencyDao(); }
        }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        public IBankDao BankDao
        {
            get { return new SqlServerBankDao(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public IContractDao ContractDao
        {
            get { return new SqlServerContractDao(); }
        }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        public IDepartmentDao DepartmentDao
        {
            get { return new SqlServerDepartmentDao(); }
        }

        /// <summary>
        /// Gets the employee type DAO.
        /// </summary>
        /// <value>
        /// The employee type DAO.
        /// </value>
        public IEmployeeTypeDao EmployeeTypeDao
        {
            get { return new SqlServerEmployeeTypeDao(); }
        }

        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        public IAccountCategoryDao AccountCategoryDao
        {
            get { return new SqlServerAccountCategoryDao(); }
        }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        public IBudgetItemDao BudgetItemDao
        {
            get { return new SqlServerBudgetItemDao(); }
        }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>The budget item DAO.</value>
        public IBudgetKindItemDao BudgetKindItemDao
        {
            get { return new SqlServerBudgetKindItemDao(); }
        }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        public IBudgetChapterDao BudgetChapterDao
        {
            get { return new SqlServerBudgetChapterDao(); }
        }

        /// <summary>
        /// Gets the budget group item DAO.
        /// </summary>
        /// <value>
        /// The budget group item DAO.
        /// </value>
        public IBudgetGroupItemDao BudgetGroupItemDao
        {
            get { return new SqlServerBudgetGroupItemDao(); }
        }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        public IBudgetSourceDao BudgetSourceDao
        {
            get { return new SqlServerBudgetSourceDao(); }
        }

        ///// <summary>
        ///// Gets the fixed asset DAO.
        ///// </summary>
        ///// <value>
        ///// The fixed asset DAO.
        ///// </value>
        public IFixedAssetDao FixedAssetDao
        {
            get { return new SqlServerFixedAssetDao(); }
        }

        ///// <summary>
        ///// Gets the fixed asset category DAO.
        ///// </summary>
        ///// <value>
        ///// The fixed asset category DAO.
        ///// </value>
        public IFixedAssetCategoryDao FixedAssetCategoryDao
        {
            get { return new SqlServerFixedAssetCategoryDao(); }
            //get { return null; }
        }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        public IAccountingObjectDao AccountingObjectDao
        {
            get { return new SqlServerAccountingObjectDao(); }
        }
        /// <summary>
        /// Gets the accounting object category DAO.
        /// </summary>
        /// <value>The accounting object category DAO.</value>
        public IAccountingObjectCategoryDao AccountingObjectCategoryDao
        {
            get { return new SqlAccountingObjectCategoryDao(); }
        }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        public IVoucherListDao VoucherListDao
        {
            get { return new SqlServerVoucherListDao(); }
        }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        public IStockDao StockDao
        {
            get { return new SqlserverStockDao(); }
        }

        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        public IInventoryItemDao InventoryItemDao
        {
            get { return new SqlServerInventoryItemDao(); }
        }

        public IInventoryItemCategoryDao InventoryItemCategoryDao
        {
            get { return new SqlServerInventoryItemCategoryDao(); }
        }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        public IDBOptionDao DBOptionDao
        {
            get { return new SqlServerDBOptionDao(); }
        }

        /// <summary>
        /// Gets the report list DAO.
        /// </summary>
        /// <value>
        /// The report list DAO.
        /// </value>
        public IReportListDao ReportListDao
        {
            get { return new SqlServerReportListDao(); }
        }

        /// <summary>
        /// Gets the voucher report DAO.
        /// </summary>
        /// <value>The voucher report DAO.</value>
        public IVoucherReportDao VoucherReportDao
        {
            get { return new SqlServerVoucherReportDao(); }
        }

        /// <summary>
        /// Gets the deposit report DAO.
        /// </summary>
        /// <value>The deposit report DAO.</value>
        public IDepositReportDao DepositReportDao
        {
            get { return new SqlServerDepositReportDao(); }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public IAutoBusinessDao AutoBusinessDao
        {
            get { return new SqlServerAutoBusinessDao(); }
        }

        /// <summary>
        /// Gets the automatic business parallel DAO.
        /// </summary>
        /// <value>The automatic business parallel DAO.</value>
        public IAutoBusinessParallelDao AutoBusinessParallelDao
        {
            get { return new SqlServerAutoBusinessParallelDao(); }
        }

        /// <summary>
        /// Gets the reference type DAO.
        /// </summary>
        /// <value>
        /// The reference type DAO.
        /// </value>
        public IRefTypeDao RefTypeDao
        {
            get { return new SqlServerRefTypeDao(); }
        }

        public IUserControlMainDesktopDao UserControlMainDesktopDao
        {
            get { return new UserControlMainDesktopDao(); }
        }
        /// <summary>
        /// Gets the reference type category DAO.
        /// </summary>
        /// <value>The reference type category DAO.</value>
        public IRefTypeCategoryDao RefTypeCategoryDao
        {
            get { return new SqlServerRefTypeCategoryDao(); }
        }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        public IProjectDao ProjectDao
        {
            get { return new SqlServerProjectDao(); }
        }

        ///// <summary>
        ///// Gets the fixed asset currency DAO.
        ///// </summary>
        ///// <value>
        ///// The fixed asset currency DAO.
        ///// </value>
        //public IFixedAssetCurrencyDao FixedAssetCurrencyDao
        //{
        //    get { return new SqlServerFixedAssetCurrencyDao(); }
        //}

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>
        /// The budget source category.
        /// </value>
        public IBudgetSourceCategoryDao BudgetSourceCategory
        {
            get { return new SqlServerBudgetSourceCategoryDao(); }
        }

        /// <summary>
        /// Gets the bu voucher list DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list DAO.
        /// </value>
        public IBUVoucherListDao BUVoucherListDao { get { return new SqlServerBUVoucherListDao(); } }

        /// <summary>
        /// Gets the bu voucher list detail DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail DAO.
        /// </value>
        public IBUVoucherListDetailDao BUVoucherListDetailDao { get { return new SqlServerBUVoucherListDetailDao(); } }

        /// <summary>
        /// Gets the bu voucher list detail parallel DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail parallel DAO.
        /// </value>
        public IBUVoucherListDetailParallelDao BUVoucherListDetailParallelDao { get { return new SqlServerBUVoucherListDetailParallelDao(); } }

        /// <summary>
        /// Gets the bu voucher list detail transfer DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail transfer DAO.
        /// </value>
        public IBUVoucherListDetailTransferDao BUVoucherListDetailTransferDao
        {
            get
            {
                return new SqlServerBUVoucherListDetailTransferDao();
            }
        }

        /// <summary>
        /// Gets the su increment decrement DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement DAO.
        /// </value>
        public ISUIncrementDecrementDao SUIncrementDecrementDao { get { return new SqlServerSUIncrementDecrementDao(); } }

        /// <summary>
        /// Gets the su increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement detail DAO.
        /// </value>
        public ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao { get { return new SqlServerSUIncrementDecrementDetailDao(); } }

        /// <summary>
        /// Gets the su transfer DAO.
        /// </summary>
        /// <value>
        /// The su transfer DAO.
        /// </value>
        public ISUTransferDao SUTransferDao { get { return new SqlServerSUTransferDao(); } }

        /// <summary>
        /// Gets the su transfer detail DAO.
        /// </summary>
        /// <value>
        /// The su transfer detail DAO.
        /// </value>
        public ISUTransferDetailDao SUTransferDetailDao { get { return new SqlServerSUTransferDetailDao(); } }

        /// <summary>
        /// Gets the fa depreciation DAO.
        /// </summary>
        /// <value>
        /// The fa depreciation DAO.
        /// </value>
        public IFADepreciationDao FADepreciationDao { get { return new SqlServerFADepreciationDao(); } }

        /// <summary>
        /// Gets the fa depreciation detail DAO.
        /// </summary>
        /// <value>
        /// The fa depreciation detail DAO.
        /// </value>
        public IFADepreciationDetailDao FADepreciationDetailDao { get { return new SqlServerFADepreciationDetailDao(); } }

        /// <summary>
        /// Gets the ba with draw DAO.
        /// </summary>
        /// <value>
        /// The ba with draw DAO.
        /// </value>
        public IBAWithDrawDao BAWithDrawDao
        {
            get
            {
                return new SqlServerBAWithDrawDao();

            }
        }

        /// <summary>
        /// Gets the ba with draw detail DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail DAO.
        /// </value>
        public IBAWithDrawDetailDao BAWithDrawDetailDao
        {
            get
            {
                return new SqlServerBAWithDrawDetailDao();

            }
        }

        /// <summary>
        /// Gets the ba with draw detail fixed asset fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail fixed asset fixed asset DAO.
        /// </value>
        public IBAWithDrawDetailFixedAssetDao BAWithDrawDetailFixedAssetDao
        {
            get
            {
                return new SqlServerBAWithDrawDetailFixedAssetDao();

            }
        }

        /// <summary>
        /// Gets the ba with draw detail purchase DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail purchase DAO.
        /// </value>
        public IBAWithDrawDetailPurchaseDao BAWithDrawDetailPurchaseDao
        {
            get
            {
                return new SqlServerBAWithDrawDetailPurchaseDao();

            }
        }

        /// <summary>
        /// Gets the ba withdraw detail salary DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail salary DAO.
        /// </value>
        public IBAWithdrawDetailSalaryDao BAWithdrawDetailSalaryDao
        {
            get
            {
                return new SqlServerBAWithdrawDetailSalaryDao();

            }
        }

        /// <summary>
        /// Gets the ba withdraw detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail tax DAO.
        /// </value>
        public IBAWithdrawDetailTaxDao BAWithdrawDetailTaxDao
        {
            get
            {
                return new SqlServerBAWithdrawDetailTaxDao();

            }
        }

        /// <summary>
        /// Gets the fixed asset detail accessory DAO.
        /// </summary>
        /// <value>
        /// The fixed asset detail accessory DAO.
        /// </value>
        public IFixedAssetDetailAccessoryDao FixedAssetDetailAccessoryDao
        {
            get { return new SqlServerFixedAssetDetailAccessoryDao(); }
        }

        ///// <summary>
        ///// Gets the captital allocate voucher DAO.
        ///// </summary>
        ///// <value>
        ///// The captital allocate voucher DAO.
        ///// </value>
        //public ISearchDao SearchDao
        //{
        //    get { return new SqlServerSearchDao(); }
        //}

        ///// <summary>
        ///// Gets the employee leasing DAO.
        ///// </summary>
        ///// <value>
        ///// The employee leasing DAO.
        ///// </value>
        //public IEmployeeLeasingDao EmployeeLeasingDao
        //{
        //    get { return new SqlServerEmployeeLeasingDao(); }
        //}

        ///// <summary>
        ///// Gets the building DAO.
        ///// </summary>
        ///// <value>
        ///// The building DAO.
        ///// </value>
        //public IBuildingDao BuildingDao
        //{
        //    get { return new SqlServerBuildingDao(); }
        //}

        ///// <summary>
        ///// Gets the company profile DAO.
        ///// </summary>
        ///// <value>
        ///// The company profile DAO.
        ///// </value>
        //public ICompanyProfileDao CompanyProfileDao
        //{
        //    get { return new SqlServerCompanyProfileDao(); }
        //}

        #endregion

        #region Bussiness

        /// <summary>
        /// Gets the gl voucher DAO.
        /// </summary>
        /// <value>
        /// The gl voucher DAO.
        /// </value>
        public IGLVoucherDao GLVoucherDao
        {
            get { return new SqlServerGLVoucherDao(); }
        }

        /// <summary>
        /// Gets the gl voucher detail DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail DAO.
        /// </value>
        public IGLVoucherDetailDao GLVoucherDetailDao
        {
            get { return new SqlServerGLVoucherDetailDao(); }
        }

        /// <summary>
        /// Gets the gl voucher detail tax DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail tax DAO.
        /// </value>
        public IGLVoucherDetailTaxDao GLVoucherDetailTaxDao
        {
            get { return new SqlServerGLVoucherDetailTaxDao(); }
        }

        /// <summary>
        /// Gets or sets the fa increment decrement DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement DAO.
        /// </value>
        public IFAIncrementDecrementDao FAIncrementDecrementDao
        {
            get { return new SqlServerFAIncrementDecrementDao(); }
        }

        /// <summary>
        /// Gets or sets the fa increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement detail DAO.
        /// </value>
        public IFAIncrementDecrementDetailDao FAIncrementDecrementDetailDao
        {
            get { return new SqlServerFAIncrementDecrementDetailDao(); }
        }

        /// <summary>
        /// Gets the ba deposit detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail tax DAO.
        /// </value>
        public IBADepositDetailTaxDao BADepositDetailTaxDao { get { return new SqlServerBADepositDetailTaxDao(); } }

        /// <summary>
        /// Gets the ba deposit detail sale sale DAO.
        /// </summary>
        /// <value>The ba deposit detail sale sale DAO.</value>
        public IBADepositDetailSaleDao BADepositDetailSaleDao { get { return new SqlServerBADepositDetailSaleDao(); } }

        /// <summary>
        /// Gets the purchase purpose DAO.
        /// </summary>
        /// <value>
        /// The purchase purpose DAO.
        /// </value>
        public IPurchasePurposeDao PurchasePurposeDao
        {
            get { return new SqlServerPurchasePurposeDao(); }
        }

        /// <summary>
        /// Gets the ba deposit DAO.
        /// </summary>
        /// <value>
        /// The ba deposit DAO.
        /// </value>
        public IBADepositDao BADepositDao
        {
            get { return new SqlServerBADepositDao(); }
        }

        /// <summary>
        /// Gets the ba deposit detail DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail DAO.
        /// </value>
        public IBADepositDetailDao BADepositDetailDao
        {
            get { return new SqlServerBADepositDetailDao(); }
        }

        /// <summary>
        /// Gets the ba bank transfer DAO.
        /// </summary>
        /// <value>The ba bank transfer DAO.</value>
        public IBABankTransferDao BABankTransferDao
        {
            get { return new SqlServerBABankTransferDao(); }
        }

        public IBABankTransferDetailDao BABankTransferDetailDao
        {
            get { return new SqlServerBABankTransferDetailDao(); }
        }
        /// <summary>
        /// Gets the ba deposit detail fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail fixed asset DAO.
        /// </value>
        public IBADepositDetailFixedAssetDao BADepositDetailFixedAssetDao { get { return new SqlServerBADepositDetailFixedAssetFixedAssetDao(); } }

        /// <summary>
        /// Gets the ba deposit detail sale sale DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail sale sale DAO.
        /// </value>
        public IBADepositDetailSaleDao BADepositDetailSaleSaleDao { get { return new SqlServerBADepositDetailSaleDao(); } }

        /// <summary>
        /// Gets the bu commitment request DAO.
        /// </summary>
        /// <value>The bu commitment request DAO.</value>
        public IBUCommitmentRequestDao BUCommitmentRequestDao
        {
            get
            {
                return new SqlServerBUCommitmentRequestDao();
            }
        }
        /// <summary>
        /// Gets the bu commitment request detail DAO.
        /// </summary>
        /// <value>The bu commitment request detail DAO.</value>
        public IBUCommitmentRequestDetailDao BUCommitmentRequestDetailDao
        {
            get
            {
                return new SqlServerBUCommitmentRequestDetailDao();
            }
        }
        /// <summary>
        /// Gets the bu transfer DAO.
        /// </summary>
        /// <value>The bu transfer DAO.</value>
        public IBUTransferDao BUTransferDao
        {
            get
            {
                return new SqlServerBUTrasferDao();
            }
        }

        /// <summary>
        /// Gets the bu transfer detail DAO.
        /// </summary>
        /// <value>The bu transfer detail DAO.</value>
        public IBUTransferDetailDao BUTransferDetailDao
        {
            get
            {
                return new SqlServerBUTransferDetailDao();
            }
        }

        public IBUTransferDetailParallelDao BUTransferDetailParallelDao
        {
            get
            {
                return new SqlServerBUTransferDetailParallelDao();
            }
        }
        /// <summary>
        /// Gets the bu commitment adjustment DAO.
        /// </summary>
        /// <value>The bu commitment adjustment DAO.</value>
        public IBUCommitmentAdjustmentDao BUCommitmentAdjustmentDao
        {
            get
            {
                return new SqlServerBUCommitmentAdjustmentDao();
            }
        }

        /// <summary>
        /// Gets the bu commitment adjustment detail DAO.
        /// </summary>
        /// <value>The bu commitment adjustment detail DAO.</value>
        public IBUCommitmentAdjustmentDetailDao BUCommitmentAdjustmentDetailDao
        {
            get
            {
                return new SqlServerBUCommitmentAdjustmentDetailDao();
            }
        }

        /// <summary>
        /// Gets the opening commitment DAO.
        /// </summary>
        /// <value>The opening commitment DAO.</value>
        public IOpeningCommitmentDao OpeningCommitmentDao
        {
            get
            {
                return new SqlServerOpeningCommitmentDao();
            }
        }

        /// <summary>
        /// Gets the opening commitment detail DAO.
        /// </summary>
        /// <value>The opening commitment detail DAO.</value>
        public IOpeningCommitmentDetailDao OpeningCommitmentDetailDao
        {
            get
            {
                return new SqlServerOpeningCommitmentDetailDao();
            }
        }

        /// <summary>
        /// Gets the journal entry account.
        /// </summary>
        /// <value>
        /// The journal entry account.
        /// </value>
    //    public IGeneralLedgerDao GeneralLedgerDao { get { return new SqlServerGeneralLedgerDao(); } }

        /// <summary>
        /// Gets the original general ledger DAO.
        /// </summary>
        /// <value>The original general ledger DAO.</value>
        public IOriginalGeneralLedgerDao OriginalGeneralLedgerDao { get { return new SqlServerOriginalGeneralLedgerDao(); } }

        /// <summary>
        /// <summary>
        /// Gets the ca payment detail DAO.
        /// </summary>
        /// <value>The ca payment detail DAO.</value>
        /// Gets the general ledger DAO.
        /// </summary>
        /// <value>
        /// The general ledger DAO.
        /// </value>
        public ITaxTypeDao TaxTypeDao { get { return new SqlServerTaxTypeDao(); } }

        /// <summary>
        /// Gets the general ledger DAO.
        /// </summary>
        /// <value>
        /// The general ledger DAO.
        /// </value>
        public ITaxItemDao TaxItemDao { get { return new SqlServerTaxItemDao(); } }

        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        public IAccountBalanceDao AccountBalanceDao { get { return new SqlServerAccountBalanceDao(); } }

        /// <summary>
        /// Gets the bu plan withdraw DAO.
        /// </summary>
        /// <value>The bu plan withdraw DAO.</value>
        public IBUPlanWithdrawDao BUPlanWithdrawDao { get { return new SqlServerBUPlanWithdrawDao(); } }

        /// <summary>
        /// Gets the bu plan withdraw detail DAO.
        /// </summary>
        /// <value>The bu plan withdraw detail DAO.</value>
        public IBUPlanWithdrawDetailDao BUPlanWithdrawDetailDao { get { return new SqlServerBUPlanWithdrawDetailDao(); } }

        /// <summary>
        /// Gets the bu plan receipt detail DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt detail DAO.
        /// </value>
        public IBUPlanReceiptDetailDao BUPlanReceiptDetailDao { get { return new SqlServerBUPlanReceipDetailDao(); } }

        /// <summary>
        /// Gets the bu plan receipt DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt DAO.
        /// </value>
        public IBUPlanReceiptDao BUPlanReceiptDao { get { return new SqlServerBUPlanReceiptDao(); } }

        /// <summary>
        /// Gets the bu budget reserve DAO.
        /// </summary>
        /// <value>
        /// The bu budget reserve DAO.
        /// </value>
        public IBUBudgetReserveDao BUBudgetReserveDao { get { return new SqlServerBUBudgetReserveDao(); } }

        public IBUBudgetReserveDetailDao BUBudgetReserveDetail { get { return new SqlServerBUBudgetReserveDetailDao(); } }

        /// <summary>
        /// Gets the bu budget reserve detail DAO.
        /// </summary>
        /// <value>
        /// The bu budget reserve detail DAO.
        /// </value>
        public IBUBudgetReserveDetailDao BUBudgetReserveDetailDao { get { return new SqlServerBUBudgetReserveDetailDao(); } }

        /// <summary>
        /// Gets the ca receipt DAO.
        /// </summary>
        /// <value>The ca receipt DAO.</value>
        public ICAReceiptDao CAReceiptDao { get { return new SqlServerCAReceiptDao(); } }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>The cash detail DAO.</value>
        public ICAReceiptDetailDao CAReceiptDetailDao { get { return new SqlServerCAReceiptDetailDao(); } }

        /// <summary>
        /// Gets the ca receipt detail tax DAO.
        /// </summary>
        /// <value>The ca receipt detail tax DAO.</value>
        public ICAReceiptDetailTaxDao CAReceiptDetailTaxDao { get { return new SqlServerCAReceiptDetailTaxDao(); } }

        /// <summary>
        /// Gets the activity DAO.
        /// </summary>
        /// <value>The activity DAO.</value>
        public IActivityDao ActivityDao { get { return new SqlServerActivityDao(); } }

        /// <summary>
        /// Gets the fund structure DAO.
        /// </summary>
        /// <value>The fund structure DAO.</value>
        public IFundStructureDao FundStructureDao { get { return new SqlServerFundStructureDao(); } }

        /// <summary>
        /// Gets the ca payment DAO.
        /// </summary>
        /// <value>The ca payment DAO.</value>
        public ICAPaymentDao CAPaymentDao
        {
            get { return new SqlServerCAPaymentDao(); }
        }

        /// <summary>
        /// Gets the ca payment detail DAO.
        /// </summary>
        /// <value>The ca payment detail DAO.</value>
        public ICAPaymentDetailDao CAPaymentDetailDao
        {
            get
            {
                return new SqlServerCAPaymentDetailDao();
            }
        }

        /// <summary>
        /// Gets the ca payment detail tax DAO.
        /// </summary>
        /// <value>The ca payment detail tax DAO.</value>
        public ICAPaymentDetailTaxDao CaPaymentDetailTaxDao
        {
            get
            {
                return new SqlSeverCAPaymentDetailTaxDao();
            }
        }

        /// <summary>
        /// Gets the in inward outward DAO.
        /// </summary>
        /// <value>The in inward outward DAO.</value>
        public IINInwardOutwardDao INInwardOutwardDao { get { return new SqlServerINInwardOutwardDao(); } }

        /// <summary>
        /// Gets the in inward outward detail DAO.
        /// </summary>
        /// <value>The in inward outward detail DAO.</value>
        public IINInwardOutwardDetailDao INInwardOutwardDetailDao { get { return new SqlServerINInwardOutwardDetailDao(); } }
        ///<summary>
        ///Gets the in inward outward detail parallel Dao.
        /// </summary>
        /// <value>
        /// the in inward outward detail parallel Dao.
        /// </value>
        public IINInwardOutwardDetailParallelDao IINInwardOutwardDetailParallelDao { get { return new SqlINInwardOutwardDetailParallelDao(); } }
        /// <summary>
        /// Gets the inventory ledger DAO.
        /// </summary>
        /// <value>The inventory ledger DAO.</value>
        public IInventoryLedgerDao InventoryLedgerDao { get { return new SqlServerInventoryLedgerDao(); } }

        /// <summary>
        /// Gets or sets the ca payment detail purchase.
        /// </summary>
        /// <value>The ca payment detail purchase.</value>
        public ICAPaymentDetailPurchaseDao CAPaymentDetailPurchaseDao
        {
            get
            {
                return new SqlServerCAPaymentDetailPurchaseDao();
            }
        }
        /// <summary>
        /// Gets the ca payment detail fixed asset DAO.
        /// </summary>
        /// <value>The ca payment detail fixed asset DAO.</value>
        public ICAPaymentDetailFixedAssetDao CAPaymentDetailFixedAssetDao
        {
            get
            {
                return new SqlServerCAPaymentDetailFixedAssetDao();
            }
        }

        /// <summary>
        /// Gets the inventory report DAO.
        /// </summary>
        /// <value>The inventory report DAO.</value>
        public IInventoryReportDao InventoryReportDao
        {
            get
            {
                return new SqlServerInventoryReportDao();
            }
        }

        /// <summary>
        /// Gets the tool increment decrement DAO.
        /// </summary>
        /// <value>The tool increment decrement DAO.</value>
        public IToolIncrementDecrementDao ToolIncrementDecrementDao
        {
            get
            { return new SqlServerToolIncrementDecrementDao(); }
        }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public IFixedAssetLedgerDao FixedAssetLedgerDao { get { return new SqlServerFixedAssetLedgerDao(); } }


        public IFAAdjustmentDetailFADao FAAdjustmentDetailFADao { get { return new SqlServerFAAdjustmentDetailFADao(); } }
        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        public ISupplyLedgerDao SupplyLedgerDao { get { return new SqlServerSupplyLedgerDao(); } }

        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        public IOpeningAccountEntryDao OpeningAccountEntryDao { get { return new SqlServerOpeningAccountEntryDao(); } }
        public IOpeningInventoryEntryDao OpeningInventoryEntryDao { get { return new SqlServerOpeningInventoryEntryDao(); } }

        /// <summary>
        /// Gets the opening fixed asset entry DAO.
        /// </summary>
        /// <value>The opening fixed asset entry DAO.</value>
        public IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao { get { return new SqlServerOpeningFixedAssetEntry(); } }

        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        public IOpeningSupplyEntryDao OpeningSupplyEntryDao { get { return new SqlServerOpeningSupplyEntryDao(); } }

        /// <summary>
        /// Gets the report ledger accounting DAO.
        /// </summary>
        /// <value>The report ledger accounting DAO.</value>
        public IReportLedgerAccountingDao ReportLedgerAccountingDao { get { return new SqlServerReportLedgerAccountingDao(); } }

        /// <summary>
        /// Gets the cash report DAO.
        /// </summary>
        /// <value>The cash report DAO.</value>
        public ICashReportDao CashReportDao { get { return new SqlServerCashReportDao(); } }

        /// <summary>
        /// Gets the treasuary report DAO.
        /// </summary>
        /// <value>The treasuary report DAO.</value>
        public ITreasuaryReportDao TreasuaryReportDao { get { return new SqlServerTreasuaryReportDao(); } }

        /// <summary>
        /// Gets the gl voucher list report DAO.
        /// </summary>
        /// <value>The gl voucher list report DAO.</value>
        public IGLVoucherListReportDao GLVoucherListReportDao { get { return new SqlGLVoucherListReportDao(); } }

        /// <summary>
        /// Gets the bu plan adjustment DAO.
        /// </summary>
        /// <value>The bu plan adjustment DAO.</value>
        public IBUPlanAdjustmentDao BUPlanAdjustmentDao
        {
            get
            {
                return new SqlServerBUPlanAdjustmentDao();
            }
        }

        /// <summary>
        /// Gets the bu plan adjustment detail DAO.
        /// </summary>
        /// <value>The bu plan adjustment detail DAO.</value>
        public IBUPlanAdjustmentDetailDao BuPlanAdjustmentDetailDao
        {
            get
            {
                return new SqlServerBUPlanAdjustmentDetailDao();
            }
        }

        /// <summary>
        /// Gets the gl voucher list detail DAO.
        /// </summary>
        /// <value>The gl voucher list detail DAO.</value>
        public IGLVoucherListDetailDao GlVoucherListDetailDao
        {
            get
            {
                return new SqlServerGLVoucherListDetailDao();
            }
        }

        /// <summary>
        /// Gets the gl voucher list DAO.
        /// </summary>
        /// <value>The gl voucher list DAO.</value>
        public IGLVoucherListDao GlVoucherListDao
        {
            get
            {
                return new SqlServerGLVoucherListDao();
            }
        }

        /// <summary>
        /// Gets the gl voucher list paramater DAO.
        /// </summary>
        /// <value>The gl voucher list paramater DAO.</value>
        public IGLVoucherListParamaterDao GlVoucherListParamaterDao
        {
            get
            {
                return new SqlServerGLVoucherListParamaterDao();
            }
        }

        /// <summary>
        /// Gets the ca payment detail parallel DAO.
        /// </summary>
        /// <value>The ca payment detail parallel DAO.</value>
        public ICAPaymentDetailParallelDao CAPaymentDetailParallelDao
        {
            get
            {
                return new SqlServerCAPaymentDetailParallelDao();
            }
        }

        /// <summary>
        /// Gets the ca receipt detail parallel DAO.
        /// </summary>
        /// <value>The ca receipt detail parallel DAO.</value>
        public ICAReceiptDetailParallelDao CAReceiptDetailParallelDao
        {
            get
            {
                return new SqlServerCAReceiptDetailParallelDao();
            }
        }

        /// <summary>
        /// Gets the ba deposit detail parallel DAO.
        /// </summary>
        /// <value>The ba deposit detail parallel DAO.</value>
        public IBADepositDetailParallelDao BADepositDetailParallelDao
        {
            get
            {
                return new SqlServerBADepositDetailParallelDao();
            }
        }

        /// <summary>
        /// Gets the ba with draw detail parallel DAO.
        /// </summary>
        /// <value>The ba with draw detail parallel DAO.</value>
        public IBAWithDrawDetailParallelDao BAWithDrawDetailParallelDao
        {
            get
            {
                return new SqlServerBAWithDrawDetailParallelDao();
            }
        }

        /// <summary>
        /// Gets the gl voucher detail parallel DAO.
        /// </summary>
        /// <value>The gl voucher detail parallel DAO.</value>
        public IGLVoucherDetailParallelDao GLVoucherDetailParallelDao
        {
            get
            {
                return new SqlServerGLVoucherDetailParallelDao();
            }
        }

        /// <summary>
        /// Gets the ba bank transfer detail parallel DAO.
        /// </summary>
        /// <value>The ba bank transfer detail parallel DAO.</value>
        public IBABankTransferDetailParallelDao BABankTransferDetailParallelDao
        {
            get
            {
                return new SqlServerBABankTransferDetailParallelDao();
            }
        }

        #endregion

        #region FixedAssetReportDao

        /// <summary>
        /// Gets the fixed asset report DAO.
        /// </summary>
        /// <value>
        /// The fixed asset report DAO.
        /// </value>
        public IFixedAssetReportDao FixedAssetReportDao { get { return new SqlServerFixedAssetReportDao(); } }

        IOpeningInventoryEntryDao IDaoFactory.OpeningInventoryEntryDao { get { return new SqlServerOpeningInventoryEntryDao(); } }

        public IUserProfileDao UserProfileDao { get { return new SqlServerUserProfileDao(); } }

        public IBUTransferDetailPurchaseDao BUTransferDetailPurchaseDao { get { return new SqlServerBUTransferDetailPurchaseDao(); } }

        public IFeatureDao FeatureDao
        {
            get { return new SqlServerFeatureDao(); }
        }

        public IFeaturePermisionDao FeaturePermisionDao
        {
            get { return new SqlServerFeaturePermisionDao(); }
        }

        public IUserFeaturePermisionDao UserFeaturePermisionDao
        {
            get { return new SqlServerUserFeaturePermisionDao(); }
        }

        public IUserPermisionDao UserPermisionDao { get { return new SqlServerUserPermisionDao(); } }
        #endregion

        #region Mua TSCĐ chưa thanh toán
        public IPUInvoiceDao PUInvoiceDao { get { return new SqlServerPUInvoiceDao(); } }
        public IPUInvoiceDetailFixedAssetDao PUInvoiceDetailFixedAssetDao { get { return new SqlServerPUInvoiceDetailFixedAssetDao(); } }
        #endregion

        public IExportXmlDao ExportXmlDao
        {
            get { return new SqlExportXmlDao(); }
        }
        public IReportDataTemplateDao ReportDataTemplateDao { get { return new SqlReportDataTemplateDao(); } }

        
    }
}