/***********************************************************************
 * <copyright file="DataAccess.cs" company="BUCA JSC">
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

using System.Configuration;
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
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;

namespace Buca.Application.iBigTime2020.DataAccess
{
    /// <summary>
    /// DataAccess class
    /// </summary>
    public static class DataAccess
    {
        private static readonly string ConnectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly IDaoFactory Factory = DaoFactories.GetFactory(ConnectionStringName);

        #region FixedAssetReportDao

        /// <summary>
        /// Gets the fixed asset report DAO.
        /// </summary>
        /// <value>
        /// The fixed asset report DAO.
        /// </value>
        public static IFixedAssetReportDao FixedAssetReportDao { get { return Factory.FixedAssetReportDao; } }

        #endregion

        #region FinacialReportDao

        /// <summary>
        /// Gets the finacial report DAO.
        /// </summary>
        /// <value>
        /// The finacial report DAO.
        /// </value>
        public static IFinacialReportDao FinacialReportDao { get { return Factory.FinacialReportDao; } }

        #endregion

        #region SettlementReport
        /// <summary>
        /// Gets the settlement report DAO.
        /// </summary>
        /// <value>
        /// The settlement report DAO.
        /// </value>
        public static ISettlementReportDao SettlementReportDao { get { return Factory.SettlememtReportDao; } }
        #endregion
        /// <summary> 
        /// Gets the Calculate Closing Dao
        /// </summary>
        /// <value>
        /// Calculate Closing Dao.
        /// </value>
        public static ICalculateClosingDao CalculateClosingDao
        {
            get { return Factory.CalculateClosingDao; }
        }
        /// <summary>
        /// Gets the bu voucher list detail parallel DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail parallel DAO.
        /// </value>
        public static IBUVoucherListDetailParallelDao BUVoucherListDetailParallelDao
        {
            get { return Factory.BUVoucherListDetailParallelDao; }
        }
        
        /// <summary>
        /// Gets the bu voucher list detail DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail DAO.
        /// </value>
        public static IBUVoucherListDetailDao BUVoucherListDetailDao { get { return Factory.BUVoucherListDetailDao; } }

        /// <summary>
        /// Gets the bu voucher list DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list DAO.
        /// </value>
        public static IBUVoucherListDao BUVoucherListDao { get { return Factory.BUVoucherListDao; } }

        /// <summary>
        /// Gets the bu voucher list detail transfer DAO.
        /// </summary>
        /// <value>
        /// The bu voucher list detail transfer DAO.
        /// </value>
        public static IBUVoucherListDetailTransferDao BUVoucherListDetailTransferDao { get
            {
                return Factory.BUVoucherListDetailTransferDao;
            } }

        /// <summary>
        /// Gets the budget expense DAO.
        /// </summary>
        /// <value>The budget expense DAO.</value>
        public static IBudgetExpenseDao BudgetExpenseDao
        {
            get { return Factory.BudgetExpenseDao; }
        }

        /// <summary>
        /// Gets the cash withdraw type DAO.
        /// </summary>
        /// <value>
        /// The cash withdraw type DAO.
        /// </value>
        public static ICashWithdrawTypeDao CashWithdrawTypeDao
        {
            get { return Factory.CashWithdrawTypeDao; }
        }

        /// <summary>
        /// Gets the budget providence DAO.
        /// </summary>
        /// <value>
        /// The budget providence DAO.
        /// </value>
        public static IBudgetProvidenceDao BudgetProvidenceDao
        {
            get { return Factory.BudgetProvidenceDao; }
        }

        /// <summary>
        /// Gets the fa increment decrement DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement DAO.
        /// </value>
        public static IFAIncrementDecrementDao FAIncrementDecrementDao
        {
            get { return Factory.FAIncrementDecrementDao; }
        }

        /// <summary>
        /// Gets the fa increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fa increment decrement detail DAO.
        /// </value>
        public static IFAIncrementDecrementDetailDao FAIncrementDecrementDetailDao
        {
            get { return Factory.FAIncrementDecrementDetailDao; }
        }

        /// <summary>
        /// Gets the su increment decrement DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement DAO.
        /// </value>
        public static ISUIncrementDecrementDao SUIncrementDecrementDao
        {
            get { return Factory.SUIncrementDecrementDao; }
        }

        /// <summary>
        /// Gets the su increment decrement detail DAO.
        /// </summary>
        /// <value>
        /// The su increment decrement detail DAO.
        /// </value>
        public static ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao
        {
            get { return Factory.SUIncrementDecrementDetailDao; }
        }

        /// <summary>
        /// Gets the su transfer DAO.
        /// </summary>
        /// <value>
        /// The su transfer DAO.
        /// </value>
        public static ISUTransferDao SUTransferDao
        {
            get { return Factory.SUTransferDao; }
        }

        /// <summary>
        /// Gets the su transfer detail DAO.
        /// </summary>
        /// <value>
        /// The su transfer detail DAO.
        /// </value>
        public static ISUTransferDetailDao SUTransferDetailDao
        {
            get { return Factory.SUTransferDetailDao; }
        }

        /// <summary>
        /// Gets the su transfer DAO.
        /// </summary>
        /// <value>
        /// The su transfer DAO.
        /// </value>
        public static IFADepreciationDao FADepreciationDao
        {
            get { return Factory.FADepreciationDao; }
        }

        /// <summary>
        /// Gets the su transfer detail DAO.
        /// </summary>
        /// <value>
        /// The su transfer detail DAO.
        /// </value>
        public static IFADepreciationDetailDao FADepreciationDetailDao
        {
            get { return Factory.FADepreciationDetailDao; }
        }

        /// <summary>
        /// Gets the ba deposit DAO.
        /// </summary>
        /// <value>
        /// The ba deposit DAO.
        /// </value>
        public static IBADepositDao BADepositDao
        {

            get { return Factory.BADepositDao; }
        }

        /// <summary>
        /// Gets the ba deposit detail DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail DAO.
        /// </value>
        public static IBADepositDetailDao BADepositDetailDao
        {
            get { return Factory.BADepositDetailDao; }
        }

        /// <summary>
        /// Gets the ba deposit detail fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail fixed asset DAO.
        /// </value>
        public static IBADepositDetailFixedAssetDao BADepositDetailFixedAssetDao
        {
            get { return Factory.BADepositDetailFixedAssetDao; }
        }

        /// <summary>
        /// Gets the ba deposit detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail tax DAO.
        /// </value>
        public static IBADepositDetailTaxDao BADepositDetailTaxDao
        {
            get { return Factory.BADepositDetailTaxDao; }
        }

        /// <summary>
        /// Gets the ba deposit detail sale sale DAO.
        /// </summary>
        /// <value>
        /// The ba deposit detail sale sale DAO.
        /// </value>
        public static IBADepositDetailSaleDao BADepositDetailSaleDao
        {
            get { return Factory.BADepositDetailSaleDao; }
        }

        /// <summary>
        /// Gets the ba with draw DAO.
        /// </summary>
        /// <value>
        /// The ba with draw DAO.
        /// </value>
        public static IBAWithDrawDao BAWithDrawDao
        {
            get
            {
                return Factory.BAWithDrawDao;

            }
        }

        /// <summary>
        /// Gets the ba with draw detail DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail DAO.
        /// </value>
        public static IBAWithDrawDetailDao BAWithDrawDetailDao
        {
            get
            {
                return Factory.BAWithDrawDetailDao;

            }
        }

        /// <summary>
        /// Gets the ba with draw detail fixed asset fixed asset DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail fixed asset fixed asset DAO.
        /// </value>
        public static IBAWithDrawDetailFixedAssetDao BAWithDrawDetailFixedAssetDao
        {
            get
            {
                return Factory.BAWithDrawDetailFixedAssetDao;
            }
        }

        /// <summary>
        /// Gets the ba with draw detail purchase DAO.
        /// </summary>
        /// <value>
        /// The ba with draw detail purchase DAO.
        /// </value>
        public static IBAWithDrawDetailPurchaseDao BAWithDrawDetailPurchaseDao
        {
            get
            {
                return Factory.BAWithDrawDetailPurchaseDao;
            }
        }

        /// <summary>
        /// Gets the ca payment detail fixed asset DAO.
        /// </summary>
        /// <value>The ca payment detail fixed asset DAO.</value>
        public static ICAPaymentDetailFixedAssetDao CAPaymentDetailFixedAssetDao
        {
            get
            {
                return Factory.CAPaymentDetailFixedAssetDao;
            }
        }

        /// <summary>
        /// Gets the ba withdraw detail salary DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail salary DAO.
        /// </value>
        public static IBAWithdrawDetailSalaryDao BAWithdrawDetailSalaryDao
        {
            get
            {
                return Factory.BAWithdrawDetailSalaryDao;
            }
        }

        /// <summary>
        /// Gets the ba withdraw detail tax DAO.
        /// </summary>
        /// <value>
        /// The ba withdraw detail tax DAO.
        /// </value>
        public static IBAWithdrawDetailTaxDao BAWithdrawDetailTaxDao
        {
            get
            {
                return Factory.BAWithdrawDetailTaxDao;
            }
        }

        /// <summary>
        /// Gets the purchase purpose DAO.
        /// </summary>
        /// <value>
        /// The purchase purpose DAO.
        /// </value>
        public static IPurchasePurposeDao PurchasePurposeDao
        {
            get { return Factory.PurchasePurposeDao; }
        }

        /// <summary>
        /// Gets the invoice form number DAO.
        /// </summary>
        /// <value>
        /// The invoice form number DAO.
        /// </value>
        public static IInvoiceFormNumberDao InvoiceFormNumberDao
        {
            get { return Factory.InvoiceFormNumberDao; }
        }

        /// <summary>
        /// Gets the ba bank transfer DAO.
        /// </summary>
        /// <value>
        /// The ba bank transfer DAO.
        /// </value>
        public static IBABankTransferDao BABankTransferDao
        {
            get { return Factory.BABankTransferDao; }
        }

        /// <summary>
        /// Gets the ba bank transfer detail DAO.
        /// </summary>
        /// <value>
        /// The ba bank transfer detail DAO.
        /// </value>
        public static IBABankTransferDetailDao BABankTransferDetailDao
        {
            get { return Factory.BABankTransferDetailDao; }
        }

        /// <summary>
        /// Gets the type of the invoice.
        /// </summary>
        /// <value>
        /// The type of the invoice.
        /// </value>
        public static IInvoiceTypeDao InvoiceTypeDao
        {
            get { return Factory.InvoiceTypeDao; }
        }

        /// <summary>
        /// Gets the bu commitment request DAO.
        /// </summary>
        /// <value>The bu commitment request DAO.</value>
        public static IBUCommitmentRequestDao BUCommitmentRequestDao
        {
            get { return Factory.BUCommitmentRequestDao; }
        }

        /// <summary>
        /// Gets the bu commitment request detail DAO.
        /// </summary>
        /// <value>The bu commitment request detail DAO.</value>
        public static IBUCommitmentRequestDetailDao BUCommitmentRequestDetailDao
        {
            get { return Factory.BUCommitmentRequestDetailDao; }
        }
        /// <summary>
        /// Gets the bu commitment adjustment DAO.
        /// </summary>
        /// <value>The bu commitment adjustment DAO.</value>
        public static IBUCommitmentAdjustmentDao BUCommitmentAdjustmentDao
        {
            get { return Factory.BUCommitmentAdjustmentDao; }
        }

        /// <summary>
        /// Gets the bu commitment adjustment detail DAO.
        /// </summary>
        /// <value>The bu commitment adjustment detail DAO.</value>
        public static IBUCommitmentAdjustmentDetailDao BUCommitmentAdjustmentDetailDao
        {
            get { return Factory.BUCommitmentAdjustmentDetailDao; }
        }

        /// <summary>
        /// Gets the opening commitment DAO.
        /// </summary>
        /// <value>The opening commitment DAO.</value>
        public static IOpeningCommitmentDao OpeningCommitmentDao
        {
            get { return Factory.OpeningCommitmentDao; }
        }

        /// <summary>
        /// Gets the opening commitment detail DAO.
        /// </summary>
        /// <value>The opening commitment detail DAO.</value>
        public static IOpeningCommitmentDetailDao OpeningCommitmentDetailDao
        {
            get { return Factory.OpeningCommitmentDetailDao; }
        }

        /// <summary>
        /// Gets the bu transfer DAO.
        /// </summary>
        /// <value>The bu transfer DAO.</value>
        public static IBUTransferDao BUTransferDao
        {
            get { return Factory.BUTransferDao; }
        }

        /// <summary>
        /// Gets the bu transfer detail DAO.
        /// </summary>
        /// <value>The bu transfer detail DAO.</value>
        public static IBUTransferDetailDao BUTransferDetailDao
        {
            get { return Factory.BUTransferDetailDao; }
        }

        public static IBUTransferDetailParallelDao BUTransferDetailParallelDao
        {
            get { return Factory.BUTransferDetailParallelDao; }
        }

        public static IBUTransferDetailPurchaseDao BUTransferDetailPurchaseDao
        {
            get { return Factory.BUTransferDetailPurchaseDao; }
        }

        /// <summary>
        /// Gets the automatic number DAO.
        /// </summary>
        /// <value>
        /// The automatic number DAO.
        /// </value>
        public static IAutoIDDao AutoIDDao
        {
            get { return Factory.AutoIDDao; }
        }
        public static ILockDao LockDao
        {
            get { return Factory.LockDao; }
        }

        /// <summary>
        /// Gets the account DAO.
        /// </summary>
        /// <value>
        /// The account DAO.
        /// </value>
        public static IAccountDao AccountDao
        {
            get { return Factory.AccountDao; }
        }
    
        //    public static ICalculateClosingDao CalculateClosingDao
        //    {
        //        get { return Factory.CalculateClosingDao; }
        //    }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        public static IDepartmentDao DepartmentDao
        {
            get { return Factory.DepartmentDao; }
        }

        /// <summary>
        /// Gets the employee type DAO.
        /// </summary>
        /// <value>
        /// The employee type DAO.
        /// </value>
        public static IEmployeeTypeDao EmployeeTypeDao
        {
            get { return Factory.EmployeeTypeDao; }
        }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        public static IBudgetItemDao BudgetItemDao
        {
            get { return Factory.BudgetItemDao; }
        }

        /// <summary>
        /// Gets the budget kind item DAO.
        /// </summary>
        /// <value>
        /// The budget kind item DAO.
        /// </value>
        public static IBudgetKindItemDao BudgetKindItemDao
        {
            get { return Factory.BudgetKindItemDao; }
        }

        public static IFeaturePermisionDao FeaturePermisionDao
        {
            get { return Factory.FeaturePermisionDao; }
        }

        public static IUserFeaturePermisionDao UserFeaturePermisionDao
        {
            get { return Factory.UserFeaturePermisionDao; }
        }

        public static IUserControlMainDesktopDao UserControlMainDesktopDao
        {
            get { return Factory.UserControlMainDesktopDao; }
        }
        public static IFeatureDao FeatureDao
        {
            get { return Factory.FeatureDao; }
        }

        public static IUserPermisionDao UserPermisionDao
        {
            get { return Factory.UserPermisionDao; }
        }
        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        public static IAccountCategoryDao AccountCategoryDao
        {
            get { return Factory.AccountCategoryDao; }
        }

        /// <summary>
        /// Gets the accounting object category DAO.
        /// </summary>
        /// <value>The accounting object category DAO.</value>
        public static IAccountingObjectCategoryDao AccountingObjectCategoryDao
        {
            get { return Factory.AccountingObjectCategoryDao; }
        }

        /// <summary>
        /// Gets the tax item DAO.
        /// </summary>
        /// <value>The tax item DAO.</value>
        public static ITaxItemDao TaxItemDao
        {
            get { return Factory.TaxItemDao; }
        }

        /// <summary>
        /// Gets the tax type DAO.
        /// </summary>
        /// <value>The tax type DAO.</value>
        public static ITaxTypeDao TaxTypeDao
        {
            get { return Factory.TaxTypeDao; }
        }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        public static IAccountingObjectDao AccountingObjectDao
        {
            get { return Factory.AccountingObjectDao; }
        }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        public static IVoucherListDao VoucherListDao
        {
            get { return Factory.VoucherListDao; }
        }

        //    /// <summary>
        //    /// Gets the other accouting object.
        //    /// </summary>
        //    /// <value>
        //    /// The other accouting object.
        //    /// </value>
        //    public static IAccountingObjectDao OtherAccoutingObject
        //    {
        //        get { return Factory.OtherAccoutingObjectDao; }
        //    }

        //    /// <summary>
        //    /// Gets the fixed asset category DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The fixed asset category DAO.
        //    /// </value>
        public static IFixedAssetCategoryDao FixedAssetCategoryDao
        {
            get { return Factory.FixedAssetCategoryDao; }
        }

        //    /// <summary>
        //    /// Gets the fixed asset DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The fixed asset DAO.
        //    /// </value>
        public static IFixedAssetDao FixedAssetDao
        {
            get { return Factory.FixedAssetDao; }
        }

        /// <summary>
        /// Gets the fund structure DAO.
        /// </summary>
        /// <value>
        /// The fund structure DAO.
        /// </value>
        public static IFundStructureDao FundStructureDao
        {
            get { return Factory.FundStructureDao; }
        }

        /// <summary>
        /// Gets the fixed asset detail accessory DAO.
        /// </summary>
        /// <value>
        /// The fixed asset detail accessory DAO.
        /// </value>
        public static IFixedAssetDetailAccessoryDao FixedAssetDetailAccessoryDao
        {
            get { return Factory.FixedAssetDetailAccessoryDao; }
        }

        //    /// <summary>
        //    /// Gets the pay item DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The pay item DAO.
        //    /// </value>
        //    public static IPayItemDao PayItemDao
        //    {
        //        get { return Factory.PayItemDao; }
        //    }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        public static IBudgetChapterDao BudgetChapterDao
        {
            get { return Factory.BudgetChapterDao; }
        }

        /// <summary>
        /// Gets the budget group item DAO.
        /// </summary>
        /// <value>
        /// The budget group item DAO.
        /// </value>
        public static IBudgetGroupItemDao BudgetGroupItemDao
        {
            get { return Factory.BudgetGroupItemDao; }
        }

        //    /// <summary>
        //    /// Gets the budget chapter DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The budget chapter DAO.
        //    /// </value>
        //    public static IFixedAssetHousingReportDao FixedAssetHousingReportDao
        //    {
        //        get { return Factory.FixedAssetHousingReportDao; }
        //    }

        //    /// <summary>
        //    /// Gets the budget category DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The budget category DAO.
        //    /// </value>
        //    public static IBudgetCategoryDao BudgetCategoryDao
        //    {
        //        get { return Factory.BudgetCategoryDao; }
        //    }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        public static IBudgetSourceDao BudgetSourceDao
        {
            get { return Factory.BudgetSourceDao; }
        }

        /// <summary>
        /// Gets the activity DAO.
        /// </summary>
        /// <value>The activity DAO.</value>
        public static IActivityDao ActivityDao
        {
            get { return Factory.ActivityDao; }
        }


        public static ICapitalPlanDao CapitalPlanDao
        {
            get { return Factory.CapitalPlanDao; }
        }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        public static IStockDao StockDao
        {
            get { return Factory.StockDao; }
        }
        public static IAudittingLogDao AudittingLogDao
        {
            get { return Factory.AudittingLogDao; }
        }
  
        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        public static IInventoryItemDao InventoryItemDao
        {
            get { return Factory.InventoryItemDao; }
        }

        /// <summary>
        /// Gets the i inventory item category DAO.
        /// </summary>
        /// <value>The i inventory item category DAO.</value>
        public static IInventoryItemCategoryDao InventoryItemCategoryDao
        {
            get { return Factory.InventoryItemCategoryDao; }
        }

        /// <summary>
        /// Gets the currency DAO.
        /// </summary>
        /// <value>
        /// The currency DAO.
        /// </value>
        public static ICurrencyDao CurrencyDao
        {
            get { return Factory.CurrencyDao; }
        }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        public static IBankDao BankDao
        {
            get { return Factory.BankDao; }
        }

        /// <summary>
        /// Gets the account tranfer DAO.
        /// </summary>
        /// <value>
        /// The account tranfer DAO.
        /// </value>
        public static IAccountTransferDao AccountTransferDao
        {
            get { return Factory.AccountTransferDao; }
        }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        public static IDBOptionDao DBOptionDao
        {
            get { return Factory.DBOptionDao; }
        }

        //    /// <summary>
        //    /// Gets the report list DAO.
        //    /// </summary>
        //    /// <value>
        //    /// The report list DAO.
        //    /// </value>
        public static IReportListDao ReportListDao
        {
            get { return Factory.ReportListDao; }
        }

        /// <summary>
        /// Gets the voucher report DAO.
        /// </summary>
        /// <value>The voucher report DAO.</value>
        public static IVoucherReportDao VoucherReportDao
        {
            get { return Factory.VoucherReportDao; }
        }

        /// <summary>
        /// Gets the deposit report DAO.
        /// </summary>
        /// <value>The deposit report DAO.</value>
        public static IDepositReportDao DepositReportDao
        {
            get { return Factory.DepositReportDao; }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public static IAutoBusinessDao AutoBusinessDao
        {
            get { return Factory.AutoBusinessDao; }
        }

        /// <summary>
        /// Gets the automatic business parallel DAO.
        /// </summary>
        /// <value>The automatic business parallel DAO.</value>
        public static IAutoBusinessParallelDao AutoBusinessParallelDao
        {
            get { return Factory.AutoBusinessParallelDao; }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public static IRefTypeDao RefTypeDao
        {
            get { return Factory.RefTypeDao; }
        }

        /// <summary>
        /// Gets the reference type category DAO.
        /// </summary>
        /// <value>The reference type category DAO.</value>
        public static IRefTypeCategoryDao RefTypeCategoryDao
        {
            get { return Factory.RefTypeCategoryDao; }
        }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        public static IProjectDao ProjectDao
        {
            get { return Factory.ProjectDao; }
        }

        /// <summary>
        /// Gets the Contract DAO.
        /// </summary>
        /// <value>
        /// The Contract DAO.
        /// </value>
        public static IContractDao ContractDao
        {
            get { return Factory.ContractDao; }
        }

        /// <summary>
        /// Gets the budget source category DAO.
        /// </summary>
        /// <value>
        /// The budget source category DAO.
        /// </value>
        public static IBudgetSourceCategoryDao BudgetSourceCategoryDao
        {
            get { return Factory.BudgetSourceCategory; }
        }

        /// <summary>
        /// Gets the journal entry account DAO.
        /// </summary>
        /// <value>
        /// The journal entry account DAO.
        /// </value>
        public static IGeneralLedgerDao GeneralLedgerDao
        {
            get { return Factory.GeneralLedgerDao; }
        }

        /// <summary>
        /// Gets the original general ledger DAO.
        /// </summary>
        /// <value>The original general ledger DAO.</value>
        public static IOriginalGeneralLedgerDao OriginalGeneralLedgerDao
        {
            get { return Factory.OriginalGeneralLedgerDao; }
        }

        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        public static IAccountBalanceDao AccountBalanceDao
        {
            get { return Factory.AccountBalanceDao; }
        }

        /// <summary>
        /// Gets the bu plan withdraw DAO.
        /// </summary>
        /// <value>The bu plan withdraw DAO.</value>
        public static IBUPlanWithdrawDao BUPlanWithdrawDao
        {
            get { return Factory.BUPlanWithdrawDao; }
        }

        /// <summary>
        /// Gets the bu plan withdraw detail DAO.
        /// </summary>
        /// <value>The bu plan withdraw detail DAO.</value>
        public static IBUPlanWithdrawDetailDao BUPlanWithdrawDetailDao
        {
            get { return Factory.BUPlanWithdrawDetailDao; }
        }

        /// <summary>
        /// Gets the ca receipt DAO.
        /// </summary>
        /// <value>The ca receipt DAO.</value>
        public static ICAReceiptDao CAReceiptDao
        {
            get { return Factory.CAReceiptDao; }
        }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>
        /// The cash detail DAO.
        /// </value>
        public static ICAReceiptDetailDao CAReceiptDetailDao
        {
            get { return Factory.CAReceiptDetailDao; }
        }

        /// <summary>
        /// Gets the ca receipt detail tax DAO.
        /// </summary>
        /// <value>The ca receipt detail tax DAO.</value>
        public static ICAReceiptDetailTaxDao CAReceiptDetailTaxDao
        {
            get { return Factory.CAReceiptDetailTaxDao; }
        }

        /// <summary>
        /// Gets the ca payment DAO.
        /// </summary>
        /// <value>
        /// The ca payment DAO.
        /// </value>
        public static ICAPaymentDao CAPaymentDao
        {
            get { return Factory.CAPaymentDao; }
        }

        /// <summary>
        /// Gets the ca payment detail DAO.
        /// </summary>
        /// <value>
        /// The ca payment detail DAO.
        /// </value>
        public static ICAPaymentDetailDao CAPaymentDetailDao
        {
            get { return Factory.CAPaymentDetailDao; }

        }

        /// <summary>
        /// Gets the ca payment detail tax DAO.
        /// </summary>
        /// <value>
        /// The ca payment detail tax DAO.
        /// </value>
        public static ICAPaymentDetailTaxDao CaPaymentDetailTaxDao
        {
            get { return Factory.CaPaymentDetailTaxDao; }
        }

        /// <summary>
        /// Gets the report ledger accounting DAO.
        /// </summary>
        /// <value>The report ledger accounting DAO.</value>
        public static IReportLedgerAccountingDao ReportLedgerAccountingDao
        {
            get { return Factory.ReportLedgerAccountingDao; }
        }
        /// <summary>
        /// Gets the ca payment detail purchase DAO.
        /// </summary>
        /// <value>The ca payment detail purchase DAO.</value>
        public static ICAPaymentDetailPurchaseDao CAPaymentDetailPurchaseDao
        {
            get { return Factory.CAPaymentDetailPurchaseDao; }
        }

        /// <summary>
        /// Gets the inventory report DAO.
        /// </summary>
        /// <value>The inventory report DAO.</value>
        public static IInventoryReportDao InventoryReportDao
        {
            get { return Factory.InventoryReportDao; }
        }

        /// <summary>
        /// Gets the tool increment decrement DAO.
        /// </summary>
        /// <value>The tool increment decrement DAO.</value>
        public static IToolIncrementDecrementDao ToolIncrementDecrementDao
        {
            get { return Factory.ToolIncrementDecrementDao; }
        }

        /// <summary>
        /// Gets the cash report DAO.
        /// </summary>
        /// <value>The cash report DAO.</value>
        public static ICashReportDao CashReportDao
        {
            get { return Factory.CashReportDao; }
        }
        /// <summary>
        /// Gets the report treasuary  DAO.
        /// </summary>
        /// <value>The report treasury  DAO.</value>
        public static ITreasuaryReportDao TreasuaryReportDao
        {
            get { return Factory.TreasuaryReportDao; }
        }

        /// <summary>
        /// Gets the gl voucher list report DAO.
        /// </summary>
        /// <value>The gl voucher list report DAO.</value>
        public static IGLVoucherListReportDao GLVoucherListReportDao
        {
            get { return Factory.GLVoucherListReportDao; }
        }
        
        /// <summary>
        /// Gets the in inward outward DAO.
        /// </summary>
        /// <value>The in inward outward DAO.</value>
        public static IINInwardOutwardDao INInwardOutwardDao
        {
            get { return Factory.INInwardOutwardDao; }
        }

        /// <summary>
        /// Gets the in inward outward detail DAO.
        /// </summary>
        /// <value>The in inward outward detail DAO.</value>
        public static IINInwardOutwardDetailDao INInwardOutwardDetailDao
        {
            get { return Factory.INInwardOutwardDetailDao; }
        }
        /// <summary>
        /// Gets the inward outward detail palallel Dao
        /// </summary>
        /// <value>The inward outward detail palallel Dao</value>
        public static IINInwardOutwardDetailParallelDao IINInwardOutwardDetailParallelDao
        {
            get { return Factory.IINInwardOutwardDetailParallelDao; }
        }
        public static IInventoryLedgerDao InventoryLedgerDao
        {
            get { return Factory.InventoryLedgerDao; }
        }

        /// <summary>
        /// Gets the bu plan receipt DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt DAO.
        /// </value>
        public static IBUPlanReceiptDao BuPlanReceiptDao
        {
            get { return Factory.BUPlanReceiptDao; }

        }

        /// <summary>
        /// Gets the bu plan receipt detail DAO.
        /// </summary>
        /// <value>
        /// The bu plan receipt detail DAO.
        /// </value>
        public static IBUPlanReceiptDetailDao BuPlanReceiptDetailDao
        {
            get { return Factory.BUPlanReceiptDetailDao; }
        }

        /// <summary>
        /// Gets the bu plan adjustment DAO.
        /// </summary>
        /// <value>The bu plan adjustment DAO.</value>
        public static IBUPlanAdjustmentDao BuPlanAdjustmentDao
        {
            get { return Factory.BUPlanAdjustmentDao; }
        }

        /// <summary>
        /// Gets the bu plan adjustment detail DAO.
        /// </summary>
        /// <value>The bu plan adjustment detail DAO.</value>
        public static IBUPlanAdjustmentDetailDao BuPlanAdjustmentDetailDao
        {
            get { return Factory.BuPlanAdjustmentDetailDao; }
        }

        /// <summary>
        /// Gets the gl voucher list DAO.
        /// </summary>
        /// <value>The gl voucher list DAO.</value>
        public static IGLVoucherListDao GlVoucherListDao
        {
            get { return Factory.GlVoucherListDao; }
        }

        /// <summary>
        /// Gets the gl voucher list detail DAO.
        /// </summary>
        /// <value>The gl voucher list detail DAO.</value>
        public static IGLVoucherListDetailDao GlVoucherListDetailDao
        {
            get { return Factory.GlVoucherListDetailDao; }
        }

        /// <summary>
        /// Gets the gl voucher list paramater.
        /// </summary>
        /// <value>The gl voucher list paramater.</value>
        public static IGLVoucherListParamaterDao GlVoucherListParamater
        {
            get { return Factory.GlVoucherListParamaterDao; }
        }

        /// <summary>
        /// Gets the bu budget reserve DAO.
        /// </summary>
        /// <value>The bu budget reserve DAO.</value>
        public static IBUBudgetReserveDao BUBudgetReserveDao
        {
            get { return Factory.BUBudgetReserveDao; }

        }

        /// <summary>
        /// Gets the bu budget reserve detail DAO.
        /// </summary>
        /// <value>
        /// The bu budget reserve detail DAO.
        /// </value>
        public static IBUBudgetReserveDetailDao BUBudgetReserveDetailDao
        {
            get { return Factory.BUBudgetReserveDetail; }
        }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public static IFixedAssetLedgerDao FixedAssetLedgerDao
        {
            get { return Factory.FixedAssetLedgerDao; }
        }

        public static IFAAdjustmentDetailFADao FAAdjustmentDetailFADao
        {
            get { return Factory.FAAdjustmentDetailFADao; }
        }

        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        public static ISupplyLedgerDao SupplyLedgerDao
        {
            get { return Factory.SupplyLedgerDao; }
        }

        /// <summary>
        /// Gets or sets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        public static IOpeningAccountEntryDao OpeningAccountEntryDao
        {
            get { return Factory.OpeningAccountEntryDao; }
        }

        public static IOpeningInventoryEntryDao OpeningInventoryEntryDao
        {
            get { return Factory.OpeningInventoryEntryDao; }
        }

        public static IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao
        {
            get { return Factory.OpeningFixedAssetEntryDao; }
        }

        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        public static IOpeningSupplyEntryDao OpeningSupplyEntryDao
        {
            get { return Factory.OpeningSupplyEntryDao; }
        }

        /// <summary>
        /// Gets the gl voucher DAO.
        /// </summary>
        /// <value>
        /// The gl voucher DAO.
        /// </value>
        public static IGLVoucherDao GLVoucherDao
        {
            get { return Factory.GLVoucherDao; }
        }

        /// <summary>
        /// Gets the gl voucher detail DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail DAO.
        /// </value>
        public static IGLVoucherDetailDao GLVoucherDetailDao
        {
            get { return Factory.GLVoucherDetailDao; }
        }

        /// <summary>
        /// Gets the gl voucher detail tax DAO.
        /// </summary>
        /// <value>
        /// The gl voucher detail tax DAO.
        /// </value>
        public static IGLVoucherDetailTaxDao GLVoucherDetailTaxDao
        {
            get { return Factory.GLVoucherDetailTaxDao; }
        }

        /// <summary>
        /// Gets the ca payment detail parallel DAO.
        /// </summary>
        /// <value>The ca payment detail parallel DAO.</value>
        public static ICAPaymentDetailParallelDao CAPaymentDetailParallelDao
        {
            get { return Factory.CAPaymentDetailParallelDao; }
        }

        /// <summary>
        /// Gets the ca receipt detail parallel DAO.
        /// </summary>
        /// <value>The ca receipt detail parallel DAO.</value>
        public static ICAReceiptDetailParallelDao CAReceiptDetailParallelDao
        {
            get { return Factory.CAReceiptDetailParallelDao; }
        }

        /// <summary>
        /// Gets the ba deposit detail parallel DAO.
        /// </summary>
        /// <value>The ba deposit detail parallel DAO.</value>
        public static IBADepositDetailParallelDao BADepositDetailParallelDao
        {
            get { return Factory.BADepositDetailParallelDao; }
        }

        /// <summary>
        /// Gets the ba with draw detail parallel DAO.
        /// </summary>
        /// <value>The ba with draw detail parallel DAO.</value>
        public static IBAWithDrawDetailParallelDao BAWithDrawDetailParallelDao
        {
            get { return Factory.BAWithDrawDetailParallelDao; }
        }

        /// <summary>
        /// Gets the ba bank transfer detail parallel DAO.
        /// </summary>
        /// <value>The ba bank transfer detail parallel DAO.</value>
        public static IBABankTransferDetailParallelDao BABankTransferDetailParallelDao
        {
            get { return Factory.BABankTransferDetailParallelDao; }
        }

        /// <summary>
        /// Gets the gl voucher detail parallel DAO.
        /// </summary>
        /// <value>The gl voucher detail parallel DAO.</value>
        public static IGLVoucherDetailParallelDao GLVoucherDetailParallelDao
        {
            get { return Factory.GLVoucherDetailParallelDao; }
        }

        public static IUserProfileDao UserProfileDao
        {
            get { return Factory.UserProfileDao; }
        }

        #region Mua TSCĐ chưa thanh toán
        public static IPUInvoiceDao PUInvoiceDao
        {
            get { return Factory.PUInvoiceDao; }
        }

        public static IPUInvoiceDetailFixedAssetDao PUInvoiceDetailFixedAssetDao
        {
            get { return Factory.PUInvoiceDetailFixedAssetDao; }
        }
        #endregion

        public static IExportXmlDao ExportXmlDao
        {
            get { return Factory.ExportXmlDao; }
        }
        public static IReportDataTemplateDao ReportDataTemplateDao
        {
            get { return Factory.ReportDataTemplateDao; }
        }

    }
}