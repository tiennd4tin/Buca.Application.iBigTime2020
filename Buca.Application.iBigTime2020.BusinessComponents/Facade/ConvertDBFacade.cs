/***********************************************************************
 * <copyright file="OriginalGeneralLedgerFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 *  
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Facade.Cash;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Deposit;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.FixedAsset;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.General;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.IncrementDecrement;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Inventory;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.PUInvoice;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert; 
using System.Linq; 

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class ConvertDBFacade
    {
        /// <summary>
        /// The original general ledger DAO
        /// </summary>
        private static readonly IEntityAccountDao convertDb = new AccountEntityDao();

        private static readonly AccountFacade AccountClient = new AccountFacade();

        private static readonly IEntityBudgetSourceDao convertBudgetSource = new BudgetSourceEntityDao();
        private static readonly BudgetSourceFacade BudgetSourceClient = new BudgetSourceFacade();

        private static readonly IEntityBudgetChapterDao convertBudgetChapter = new BudgetChapterEntityDao();
        private static readonly BudgetChapterFacade BudgetChapterClient = new BudgetChapterFacade();

        private static readonly IEntityBudgetKindItemDao convertBudgetKindItem = new BudgetKindItemEntityDao();
        private static readonly BudgetKindItemFacade BudgetKindItemClient = new BudgetKindItemFacade();

        private static readonly IEntityBudgetItemDao convertBudgetItem = new BudgetItemEntityDao();
        private static readonly BudgetItemFacade BudgetItemClient = new BudgetItemFacade();

        private static readonly IEntityFundStructureDao convertFundStructure = new FundStructureEntityDao();
        private static readonly FundStructureFacade FundStructureClient = new FundStructureFacade();

        private static readonly IEntityDepartmentDao convertDepartment = new DepartmentEntityDao();
        private static readonly DepartmentFacade DepartmentClient = new DepartmentFacade();

        private static readonly IEntityAccountingObjectDao convertAccountingObject = new AccountingObjectEntityDao();
        private static readonly EmployeeTypeFacade EmployeeTypeClient = new EmployeeTypeFacade();
        private static readonly AccountingObjectFacade AccountingObjectClient = new AccountingObjectFacade();

        private static readonly IEntityStockDao convertStock = new StockEntityDao();
        private static readonly StockFacade StockClient = new StockFacade();

        private static readonly IEntityInventoryCategoryDao convertInventoryCategory = new InventoryCategoryEntityDao();

        private static readonly InventoryItemCategoryFacade InventoryItemCategoryClient =
            new InventoryItemCategoryFacade();

        private static readonly IEntityInventoryItemDao convertInventoryItem = new InventoryItemEntityDao();
        private static readonly InventoryItemFacade InventoryItemClient = new InventoryItemFacade();

        private static readonly IEntityPurchasePurposeDao convertPurchasePurpose = new PurchasePurposeEntityDao();
        private static readonly PurchasePurposeFacade PurchasePurposeClient = new PurchasePurposeFacade();

        private static readonly IEntityFixedAssetCategoryDao convertFixedAssetCategory =
            new FixedAssetCategoryEntityDao();

        private static readonly FixedAssetCategoryFacade FixedAssetCategoryClient = new FixedAssetCategoryFacade();

        private static readonly IEntityFixedAssetDao convertFixedAsset = new FixedAssetEntityDao();
        private static readonly FixedAssetFacade FixedAssetClient = new FixedAssetFacade();

        private static readonly IEntityProjectDao convertProject = new ProjectEntityDao();
        private static readonly ProjectFacade ProjectClient = new ProjectFacade();

        private static readonly IEntityActivityDao convertActivity = new ActivityEntityDao();
        private static readonly ActivityFacade ActivityClient = new ActivityFacade();

        private static readonly IEntityBankDao convertBank = new BankEntityDao();
        private static readonly BankFacade BankClient = new BankFacade();

        private static readonly IEntityInvoiceFormNumberDao convertInvoice = new InvoiceFormNumberEntityDao();
        private static readonly InvoiceFormNumberFacade InvoiceClient = new InvoiceFormNumberFacade();

        private static readonly IEntityExpenseDao convertExpense = new ExpenseDao();
        private static readonly BudgetExpenseFacade ExpenseClient = new BudgetExpenseFacade();

        private static readonly IEntityCurrencyDao convertCurrency = new CurrencyEntityDao();
        private static readonly CurrencyFacade currencyClient = new CurrencyFacade();




        private static readonly IEntityOpeningInventoryEntryDao convertOpeningInventoryEntry =
            new OpeningInventoryEntryEntityDao();

        private static readonly OpeningInventoryEntryFacade OpeningInventoryEntryClient =
            new OpeningInventoryEntryFacade();

        private static readonly IEntityOpeningFixedAssetEntryDao convertOpeningFixedAssetEntry =
            new OpeningFixedAssetEntryEntityDao();

        private static readonly OpeningFixedAssetEntryFacade OpeningFixedAssetEntryClient =
            new OpeningFixedAssetEntryFacade();

        private static readonly IEntityBUBudgetReserveDao convertBUBudgetReserve = new BUBudgetReserveEntityDao();
        private static readonly BUBudgetReserveFacade BUBudgetReserveClient = new BUBudgetReserveFacade();

        private static readonly IEntityCAReceiptDao convertCAReceipt = new CAReceiptEntityDao();
        private static readonly CAReceiptFacade CAReceiptClient = new CAReceiptFacade();

        private static readonly IEntityBADepositDao convertBADeposit = new BADepositEntityDao();
        private static readonly BADepositFacade BADepositClient = new BADepositFacade();

        private static readonly IEntityBABankTransferDao convertBABankTransferDao = new BABankTransferEntityDao();
        private static readonly BABankTransferFacade BABankTransferClient = new BABankTransferFacade();

        private static readonly IEntityGLVoucherListDao convertGLVoucherListDao = new GLVoucherListEntityDao();
        private static readonly GLVoucherListFacade GLVoucherListClient = new GLVoucherListFacade();

        private static readonly IEntityGLVoucherDao convertGLVoucherDao = new GLVoucherEntityDao();
        private static readonly GLVoucherFacade GLVoucherClient = new GLVoucherFacade();

        private static readonly IEntityOpeningAccountEntryDao convertOpeningAccountEntryDao =
            new OpeningAccountEntryEntityDao();

        private static readonly OpeningAccountEntryFacade OpeningAccountEntryClient = new OpeningAccountEntryFacade();

        private static readonly IEntityFAAdjustmentDao convertFAAdjustmentDao = new FAAdjustmentEntityDao();
        private static readonly FAAdjustmentFacade FAAdjustmentClient = new FAAdjustmentFacade();

        private static readonly IEntityFADepreciationDao convertFADepreciationDao = new FADepreciationEntityDao();
        private static readonly FADepreciationFacade FADepreciationClient = new FADepreciationFacade();

        private static readonly IEntityFAIncrementDecrementDao convertFAIncrementDecrementDao =
            new FAIncrementDecrementEntityDao();

        private static readonly FAIncrementDecrementFacade FAIncrementDecrementClient = new FAIncrementDecrementFacade()
            ;

        private static readonly IEntityPUInvoiceDao convertPUInvoiceDao = new PUInvoiceEntityDao();
        private static readonly PUInvoiceFacade PUInvoiceClient = new PUInvoiceFacade();

        private static readonly IEntitySUTransferDao convertSUTransferDao = new SUTransferEntityDao();
        private static readonly SUTransferFacade SUTransferClient = new SUTransferFacade();

        private static readonly IEntitySUIncrementDecrementDao convertSUIncrementDecrementDao =
            new SUIncrementDecrementEntityDao();

        private static readonly SUIncrementDecrementFacade SUIncrementDecrementClient = new SUIncrementDecrementFacade()
            ;

        private static readonly IEntityOpeningSupplyEntryDao convertOpeningSupplyEntryDao =
            new OpeningSupplyEntryEntityDao();

        private static readonly OpeningSupplyEntryFacade OpeningSupplyEntryClient = new OpeningSupplyEntryFacade();

        private static readonly IEntityINInwardOutwardDao convertINInwardOutwardDao = new INInwardOutwardEntityDao();
        private static readonly INInwardOutwardFacade INInwardOutwardClient = new INInwardOutwardFacade();

        private static readonly IEntityBAWithDrawDao convertBAWithDrawDao = new BAWithDrawEntityDao();
        private static readonly BAWithDrawFacade BAWithDrawClient = new BAWithDrawFacade();

        private static readonly IEntityCAPaymentDao convertCAPaymentDao = new CAPaymentEntityDao();
        private static readonly CAPaymentFacade CAPaymentClient = new CAPaymentFacade();

        private static readonly IEntityBUVoucherListDao convertBUVoucherListDao = new BUVoucherListEntityDao();
        private static readonly BUVoucherListFacade BUVoucherListClient = new BUVoucherListFacade();

        private static readonly IEntityBUTransferDao convertBUTransferDao = new BUTransferEntityDao();
        private static readonly BUTransferFacade BUTransferClient = new BUTransferFacade();

        private static readonly IEntityOpeningCommitmentDao convertOpeningCommitmentDao =
            new OpeningCommitmentEntityDao();

        private static readonly OpeningCommitmentFacade OpeningCommitmentClient = new OpeningCommitmentFacade();

        private static readonly IEntityBUCommitmentAdjustmentDao convertBUCommitmentAdjustmentDao =
            new BUCommitmentAdjustmentEntityDao();

        private static readonly BUCommitmentAdjustmentFacade BUCommitmentAdjustmentClient =
            new BUCommitmentAdjustmentFacade();

        private static readonly IEntityBUCommitmentRequestDao convertBUCommitmentRequestDao =
            new BUCommitmentRequestEntityDao();

        private static readonly BUCommitmentRequestFacade BUCommitmentRequestClient = new BUCommitmentRequestFacade();

        private static readonly IEntityBUPlanAdjustmentDao convertBUPlanAdjustmentDao = new BUPlanAdjustmentEntityDao();
        private static readonly BUPlanAdjustmentFacade BUPlanAdjustmentClient = new BUPlanAdjustmentFacade();

        private static readonly IEntityBUPlanWithdrawDao convertBUPlanWithdrawDao = new BUPlanWithdrawEntityDao();
        private static readonly BUPlanWithdrawFacade BUPlanWithdrawClient = new BUPlanWithdrawFacade();

        private static readonly IEntityBUPlanReceiptDao convertBUPlanReceiptDao = new BUPlanReceiptEntityDao();
        private static readonly BUPlanReceiptFacade BUPlanReceiptClient = new BUPlanReceiptFacade();

        private static readonly IEntityAccountCategoryDao convertAccountCategoryDao = new AccountCategoryEntityDao();
        private static readonly AccountCategoryFacade AccountCategoryClient = new AccountCategoryFacade();

        private static readonly IEntityAccountTransferDao convertAccountTransferDao = new AccountTransferEntityDao();
        private static readonly AccountTransferFacade AccountTransferClient = new AccountTransferFacade();

        private static readonly IEntityAccountDefaultDao ConvertAccountDefaultDao = new AccountDefaultEntityDao();
        private static readonly RefTypeFacade AccountDefaultClient = new RefTypeFacade();

        private static readonly IEntityAutoBusiness ConvertAutoBusiness = new AutoBusinessEntityDao();
        private static readonly AutoBusinessFacade AutoBusinessClient = new AutoBusinessFacade();

        private static readonly AutoBusinessParallelFacade AutoBusinessPararellelClient =
            new AutoBusinessParallelFacade();

        private string result;

        public string ConvertDB(string connectionString, string action)
        {

            //Xóa hết dữ liệu chứng từ 

            #region xóa dữ liệu chứng từ 

            if (action == "DeleteVoucher")
            {
                var BuBudgetReserves = BUBudgetReserveClient.GetBUBudgetReserves();
                foreach (var buBudget in BuBudgetReserves)
                {
                    var response = BUBudgetReserveClient.DeleteBUBudgetReservet(buBudget.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }


                var CAReceiptsDelete = CAReceiptClient.GetCAReceipts();
                foreach (var caReceipt in CAReceiptsDelete)
                {
                    var response = CAReceiptClient.DeleteCAReceipt(caReceipt.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var BaBankDelete = BABankTransferClient.GetBABankTransfers();
                foreach (var baBank in BaBankDelete)
                {
                    var response = BABankTransferClient.DeleteBABankTransfer(baBank.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var BaDepositDelete = BADepositClient.GetBADeposits();
                foreach (var baDeposit in BaDepositDelete)
                {
                    var response = BADepositClient.DeleteBADeposit(baDeposit.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var faDecreDelete = FADepreciationClient.GetFADepreciations();

                foreach (var fa in faDecreDelete)
                {
                    var response = FADepreciationClient.DeleteFADepreciation(fa.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var faAdjusts = FAAdjustmentClient.GetFAAdjustments();
                foreach (var fa in faAdjusts)
                {
                    var response = FAAdjustmentClient.DeleteFAAdjustment(fa.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var faIncre = FAIncrementDecrementClient.GetFAIncrementDecrements();
                foreach (var fa in faIncre)
                {
                    var response = FAIncrementDecrementClient.DeleteFAIncrementDecrement(fa.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var glVoucherLists = GLVoucherListClient.GetGLVoucherList();
                foreach (var gl in glVoucherLists)
                {
                    var response = GLVoucherListClient.DeleteGLVoucherList(gl.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;

                }

                var glVouchers = GLVoucherClient.GetGLVouchers();
                foreach (var gl in glVouchers)
                {
                    var response = GLVoucherClient.DeleteGLVoucher(gl.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }


                var suTransfers = SUTransferClient.GetSUTransfers();
                foreach (var su in suTransfers)
                {
                    var response = SUTransferClient.DeleteSUTransfer(su.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }


                var suIncre = SUIncrementDecrementClient.GetSUIncrementDecrements();

                foreach (var su in suIncre)
                {
                    var response = SUIncrementDecrementClient.DeleteSUIncrementDecrement(su.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }


                var openningSupplys = OpeningSupplyEntryClient.GetOpeningSupplyEntry();

                foreach (var op in openningSupplys)
                {
                    var response = OpeningSupplyEntryClient.DeleteOpeningSupplyEntry(op.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var inInwardOutwards = INInwardOutwardClient.GetINInwardOutwards();
                foreach (var inIO in inInwardOutwards)
                {
                    var response = INInwardOutwardClient.DeleteINInwardOutward(inIO.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var baWithDraws = BAWithDrawClient.GetBAWithDraws();

                foreach (var inIO in baWithDraws)
                {
                    var response = BAWithDrawClient.DeleteBAWithDraw(inIO.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }


                var caPayments = CAPaymentClient.GetCAPayment();

                foreach (var ca in caPayments)
                {
                    var response = CAPaymentClient.DeleteCAPayment(ca.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var buVouchers = BUVoucherListClient.GetBUVoucherListEntities();

                foreach (var bu in buVouchers)
                {
                    var response = BUVoucherListClient.DeleteBUVoucherList(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var buTransfer = BUTransferClient.GetBUTransfer();

                foreach (var bu in buTransfer)
                {
                    var response = BUTransferClient.DeleteBUTransfer(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var opCommitment = OpeningCommitmentClient.GetOpeningCommitment();

                foreach (var op in opCommitment)
                {
                    var response = OpeningCommitmentClient.DeleteOpeningCommitment(op.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var buCommitment = BUCommitmentAdjustmentClient.GetBUCommitmentAdjustment();
                foreach (var bu in buCommitment)
                {
                    var response = BUCommitmentAdjustmentClient.DeleteBUCommitmentAdjustment(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var buCommitmentRequest = BUCommitmentRequestClient.GetBUCommitmentRequest();
                foreach (var bu in buCommitmentRequest)
                {
                    var response = BUCommitmentRequestClient.DeleteBUCommitmentRequest(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var bupPlans = BUPlanAdjustmentClient.GetBuPlanAdjustment();

                foreach (var bu in bupPlans)
                {
                    var response = BUPlanAdjustmentClient.DeleteBuPlanAdjustment(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var bupPlansWithDraw = BUPlanWithdrawClient.GetBUPlanWithdraws();
                foreach (var bu in bupPlansWithDraw)
                {
                    var response = BUPlanWithdrawClient.DeleteBUPlanWithdraw(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }

                var bupPlansReceipt = BUPlanReceiptClient.GetBUPlanReceip();
                foreach (var bu in bupPlansReceipt)
                {
                    var response = BUPlanReceiptClient.DeleteBUPlanReceipt(bu.RefId);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
                var puInvoiceFixedAsset = PUInvoiceClient.GetPUInvoices();
                foreach (var pu in puInvoiceFixedAsset)
                {
                    var response = PUInvoiceClient.DeletePUInvoice(pu.RefId,pu.RefType);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
                var openingFixedAsset = OpeningFixedAssetEntryClient.GetOpeningFixedAssetEntries();
                foreach (var op in openingFixedAsset)
                {
                    var response = OpeningFixedAssetEntryClient.DeleteOpeningFixedAssetEntry(op);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
                var openingAccount = OpeningAccountEntryClient.GetOpeningAccountEntriesConvert();
                foreach (var op in openingAccount)
                {
                    var response = OpeningAccountEntryClient.DeleteOpeningAccountEntryConvert(op.AccountNumber,op.RefType);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            if (action == "DeleteCategory")
            {
                //du an 
                var responseProject = ProjectClient.DeleteProjectConvert();
                if (!string.IsNullOrEmpty(responseProject.Message)) return result = responseProject.Message;
                //tscd
                var responseFixedAsset = FixedAssetClient.DeleteFixedAssetConvert();
                if (!string.IsNullOrEmpty(responseFixedAsset.Message)) return result = responseFixedAsset.Message;
                //nhom tscd
                var responseFixedAssetCategory = FixedAssetCategoryClient.DeleteFixedAssetCategoryConvert();
                if (!string.IsNullOrEmpty(responseFixedAssetCategory.Message))
                    return result = responseFixedAssetCategory.Message;

                //nhom hang hoa dich vu
                var responsePurchasePurpose = PurchasePurposeClient.DeletePurchasePurposeConvert();
                if (!string.IsNullOrEmpty(responsePurchasePurpose.Message))
                    return result = responsePurchasePurpose.Message;
                //cong cu dung cu
                var responseInventoryItem = InventoryItemClient.DeleteInventoryItemConvert();
                if (!string.IsNullOrEmpty(responseInventoryItem.Message)) return result = responseInventoryItem.Message;
                //nhom cong cu dung cu
                var responseInventoryCategory = InventoryItemCategoryClient.DeleteInventoryItemCategoryConvert();
                if (!string.IsNullOrEmpty(responseInventoryCategory.Message))
                    return result = responseInventoryCategory.Message;
                //kho 
                var responseStock = StockClient.DeleteStockConvert();
                if (!string.IsNullOrEmpty(responseStock.Message)) return result = responseStock.Message;
                //doi tuong 
                var responseaccountingObject = AccountingObjectClient.DeleteAccountingObjectConvert();
                if (!string.IsNullOrEmpty(responseaccountingObject.Message))
                    return result = responseaccountingObject.Message;
                //phong ban
                var responseDepartment = DepartmentClient.DeleteDepartmentConvert();
                if (!string.IsNullOrEmpty(responseDepartment.Message)) return result = responseDepartment.Message;
                //tai khoan ket chuyen 
                var responseAccounTransfer = AccountTransferClient.DeleteAccountTransferConvert();
                if (!string.IsNullOrEmpty(responseAccounTransfer.Message))
                    return result = responseAccounTransfer.Message;
                //dinh khoan dong thoi
                var responseAutoBusinessParallel = AutoBusinessPararellelClient.DeleteAutoBusinessParallelConvert();
                if (!string.IsNullOrEmpty(responseAutoBusinessParallel.Message))
                    return result = responseAutoBusinessParallel.Message;
                //dinh khoan tu dong
                var responseAutoBusiness = AutoBusinessClient.DeleteAutoBusinessConvert();
                if (!string.IsNullOrEmpty(responseAutoBusiness.Message))
                {
                    return result = responseAutoBusiness.Message;
                }

                //tai khoan ngam dinh
                var responseAccounDefault = AccountDefaultClient.DeleteAccountDefault();
                if (!string.IsNullOrEmpty(responseAccounDefault.Message)) return result = responseAccounDefault.Message;
                //he thong tai khoan
                var responseAccount = AccountClient.DeleteConvertAccount();
                if (!string.IsNullOrEmpty(responseAccount.Message)) return result = responseAccount.Message;
                //nhom tai khoan
                var responseAccountCategory = AccountCategoryClient.DeleteConvertAccountCategory();
                if (!string.IsNullOrEmpty(responseAccountCategory.Message)) return result = responseAccountCategory.Message;

                //muc tieu muc
                var responseBudgetItem = BudgetItemClient.DeleteBudgetItemConvert();
                if (!string.IsNullOrEmpty(responseBudgetItem.Message)) return result = responseBudgetItem.Message;

                //loai khoan 
                var responseBudgetKindItem = BudgetKindItemClient.DeleteBudgetKindItemConvert();
                if (!string.IsNullOrEmpty(responseBudgetKindItem.Message))
                    return result = responseBudgetKindItem.Message;
                //chuong
                var responseBudgetChapter = BudgetChapterClient.DeleteBudgetChapterConvert();
                if (!string.IsNullOrEmpty(responseBudgetChapter.Message)) return result = responseBudgetChapter.Message;

                //nguon von
                var responseBudgetSource = BudgetSourceClient.DeleteBudgetSourceConvert();
                if (!string.IsNullOrEmpty(responseBudgetSource.Message)) return result = responseBudgetSource.Message;

                //khoan muc chi phi
                var responseFundStructure = FundStructureClient.DeleteFundStructureConvert();
                if (!string.IsNullOrEmpty(responseFundStructure.Message)) return result = responseFundStructure.Message;

                //hoat dong su nghiep
                var responseActivity = ActivityClient.DeleteActivityConvert();
                if (!string.IsNullOrEmpty(responseActivity.Message)) return result = responseActivity.Message;

                //tai khoan ngan hang
                var responseBank = BankClient.DeleteBankConvert();
                if (!string.IsNullOrEmpty(responseBank.Message)) return result = responseBank.Message;
                //mau so hoa don
                var responseInvoiceFormNumber = InvoiceClient.DeleteInvoiceFormNumberConvert();
                if (!string.IsNullOrEmpty(responseInvoiceFormNumber.Message))
                    return result = responseInvoiceFormNumber.Message;
                //phi le phi
                var responseBudgetExpense = ExpenseClient.DeleteBudgetExpenseConvert();
                if (!string.IsNullOrEmpty(responseBudgetExpense.Message)) return result = responseBudgetExpense.Message;
                //tien te
                var responseCurrency = currencyClient.DeleteCurrencyConvert();
                if (!string.IsNullOrEmpty(responseCurrency.Message)) return result = responseCurrency.Message;

            }

            #endregion

            #region Danh mục

            #region tài khoản

            //Nhóm tài khoản

            if (action == "AccountCategory")
            {
                var lstAccountCategory = convertAccountCategoryDao.GetAccountsCategory(connectionString);

                //insert nhóm tài khoản
                foreach (var accountCategory in lstAccountCategory)
                {
                    var responseAccountCategory = AccountCategoryClient.InsertAccountCategory(accountCategory);
                    result = responseAccountCategory.Message;
                    if (!string.IsNullOrEmpty(responseAccountCategory.Message)) return result;

                }
            }

            //Hệ thống tài khoản
            if (action == "Account")
            {
                var lstAccount = convertDb.GetAccounts(connectionString);
                if (lstAccount != null)
                {
                    var lstAccountOrder = lstAccount.OrderBy(i => i.Grade);

                    //xoá toàn bộ tài khoản đã tồn tại

                    // insert dữ liệu chuyển đổi
                    foreach (var account in lstAccountOrder)
                    {
                        var responseAccount = AccountClient.InsertConvertAccount(account);
                        result = responseAccount.Message;
                        if (!string.IsNullOrEmpty(responseAccount.Message)) return result;
                    }

                }
            }

            //tài khoản kết chuyển 
            if (action == "AccountTransfer")
            {
                var lstAccountTransfer = convertAccountTransferDao.GetAccountsTransfer(connectionString);

                foreach (var accountTransfer in lstAccountTransfer)
                {
                    var responseAccounTransfer = AccountTransferClient.InsertAccountTransferConvert(accountTransfer);
                    result = responseAccounTransfer.Message;
                    if (!string.IsNullOrEmpty(responseAccounTransfer.Message))
                        return result;
                }
            }

            //tài khoản ngầm định 
            if (action == "AccountDefault")
            {
                var lstAccountDefault = ConvertAccountDefaultDao.GetAccountsDefault(connectionString);

                foreach (var accountDefault in lstAccountDefault)
                {
                    var responseAccounDefault = AccountDefaultClient.InsertAccountDefaultConvert(accountDefault);
                    result = responseAccounDefault.Message;
                    if (!string.IsNullOrEmpty(responseAccounDefault.Message)) return result;
                }
            }


            //định khoản tự động
            if (action == "AutoBusiness")
            {
                var lstAutoBusines = ConvertAutoBusiness.GetAutoBusiness(connectionString);

                foreach (var autoBusiness in lstAutoBusines)
                {
                    var responseAutoBusiness = AutoBusinessClient.InsertAutoBusinessConvert(autoBusiness);
                    result = responseAutoBusiness.Message;
                    if (!string.IsNullOrEmpty(responseAutoBusiness.Message))
                    {
                        return result;
                    }
                }
            }

            //định khoản đồng thời
            if (action == "AutoBusinessParallel")
            {
                var lstAutoBusinesParallel = ConvertAutoBusiness.GetAutoBusinessPararellel(connectionString);

                foreach (var autoBusinessParallel in lstAutoBusinesParallel)
                {
                    var responseAutoBusinessParallel =
                          AutoBusinessPararellelClient.InsertAutoBusinessParallelConvert(autoBusinessParallel);
                    result = responseAutoBusinessParallel.Message;
                    if (!string.IsNullOrEmpty(responseAutoBusinessParallel.Message))
                        return result;
                }
            }


            #endregion tài khoản

            #region mục lục ngân sách 

            //nguồn vốn 
            if (action == "BudgetSource")
            {
                var lstBudgetSource = convertBudgetSource.GetBudgetSource(connectionString);

                foreach (var budgetSource in lstBudgetSource)
                {
                    var responseBudgetSource = BudgetSourceClient.InsertBudgetSourceConvert(budgetSource);
                    result = responseBudgetSource.Message;
                    if (!string.IsNullOrEmpty(responseBudgetSource.Message)) return result;
                }
            }

            //khoản mục chi phí 

            if (action == "FundStructure")
            {
                var lstFundStructure = convertFundStructure.GetFundStructure(connectionString);

                foreach (var fundStructure in lstFundStructure)
                {
                    var responseFundStructure = FundStructureClient.InsertFundStructureConvert(fundStructure);
                    result = responseFundStructure.Message;
                    if (!string.IsNullOrEmpty(responseFundStructure.Message)) return result;
                }
            }
            //chương 

            if (action == "BudgetChapter")
            {
                var lstBudgetChapter = convertBudgetChapter.GetBudgetChapters(connectionString);

                foreach (var budgetChapter in lstBudgetChapter)
                {
                    var responseBudgetChapter = BudgetChapterClient.InsertBudgetChapterConvert(budgetChapter);
                    result = responseBudgetChapter.Message;
                    if (!string.IsNullOrEmpty(responseBudgetChapter.Message)) return result;
                }
            }

            //loại khoản
            if (action == "BudgetKindItem")
            {

                var lstBudgetKindItem = convertBudgetKindItem.GetBudgetKindItem(connectionString);

                foreach (var budgetKindItem in lstBudgetKindItem)
                {
                    var responseBudgetKindItem = BudgetKindItemClient.InsertBudgetKindItemConvert(budgetKindItem);
                    result = responseBudgetKindItem.Message;
                    if (!string.IsNullOrEmpty(responseBudgetKindItem.Message))
                        return result;
                }
            }
            //mục tiểu mục
            if (action == "BudgetItem")
            {

                var lstBudgetItem = convertBudgetItem.GetBudgetItem(connectionString);

                foreach (var budgetItem in lstBudgetItem)
                {
                    var responseBudgetItem = BudgetItemClient.InsertBudgetItemConvert(budgetItem);
                    result = responseBudgetItem.Message;
                    if (!string.IsNullOrEmpty(responseBudgetItem.Message)) return result;
                }
            }

            #endregion mục lục ngân sách 

            #region đối tượng 

            // phòng ban
            if (action == "Department")
            {
                var lstDepartment = convertDepartment.GetDepartments(connectionString);

                foreach (var Department in lstDepartment)
                {
                    var responseDepartment = DepartmentClient.InsertDepartmentConvert(Department);
                    result = responseDepartment.Message;
                    if (!string.IsNullOrEmpty(responseDepartment.Message)) return result;
                }
            }
            //đối tượng 
            if (action == "AccountingObject")
            {
                var lstaccountingObject = convertAccountingObject.GetAccountingObject(connectionString);

                foreach (var accountingObject in lstaccountingObject)
                {
                    var _employeeType = new EmployeeTypeEntity
                    {
                        EmployeeTypeId = accountingObject.EmployeeTypeId,
                        EmployeeTypeName = accountingObject.EmployeeTypeName,
                        EmployeeTypeCode = accountingObject.EmployeeTypeCode,
                        Description = accountingObject.EmployeeDescription,
                        IsActive = accountingObject.EmployeeIsActive,

                    };
                    var responseEmployee = EmployeeTypeClient.InsertEmployeeTypeConvert(_employeeType);
                    result = responseEmployee.Message;
                    if (!string.IsNullOrEmpty(responseEmployee.Message)) return result;
                    if (accountingObject.AccountingObjectId != null)
                    {
                        var _accountingObject = new AccountingObjectEntity
                        {
                            AccountingObjectId = accountingObject.AccountingObjectId,
                            AccountingObjectCode = accountingObject.AccountingObjectCode,
                            AccountingObjectCategoryId = accountingObject.AccountingObjectCategoryId,
                            AccountingObjectName = accountingObject.AccountingObjectName,
                            Address = accountingObject.Address,
                            Tel = accountingObject.Tel,
                            Fax = accountingObject.Fax,
                            Website = accountingObject.Website,
                            BankAccount = accountingObject.BankAccount,
                            BankName = accountingObject.BankName,
                            CompanyTaxCode = accountingObject.CompanyTaxCode,
                            BudgetCode = accountingObject.BudgetCode,
                            AreaCode = accountingObject.AreaCode,
                            Description = accountingObject.Description,
                            ContactName = accountingObject.ContactName,
                            ContactTitle = accountingObject.ContactTitle,
                            ContactSex = accountingObject.ContactSex,
                            ContactMobile = accountingObject.ContactMobile,
                            ContactEmail = accountingObject.ContactEmail,
                            ContactOfficeTel = accountingObject.ContactOfficeTel,
                            ContactHomeTel = accountingObject.ContactHomeTel,
                            ContactAddress = accountingObject.ContactAddress,
                            IsEmployee = accountingObject.IsEmployee,
                            IsPersonal = accountingObject.IsPersonal,
                            IdentificationNumber = accountingObject.IdentificationNumber,
                            IssueDate = accountingObject.IssueDate,
                            IssueBy = accountingObject.IssueBy,
                            DepartmentId = accountingObject.DepartmentId,
                            SalaryScaleId = accountingObject.SalaryScaleId,
                            Insured = accountingObject.Insured,
                            LabourUnionFee = accountingObject.LabourUnionFee,
                            FamilyDeductionAmount = accountingObject.FamilyDeductionAmount,
                            IsActive = accountingObject.IsActive,
                            ProjectId = accountingObject.ProjectId,
                            IsCustomerVendor = accountingObject.IsCustomerVendor,
                            SalaryCoefficient = accountingObject.SalaryCoefficient,
                            NumberFamilyDependent = accountingObject.NumberFamilyDependent,
                            SalaryForm = accountingObject.SalaryForm,
                            SalaryPercentRate = accountingObject.SalaryPercentRate,
                            SalaryAmount = accountingObject.SalaryAmount,
                            IsPayInsuranceOnSalary = accountingObject.IsPayInsuranceOnSalary,
                            InsuranceAmount = accountingObject.InsuranceAmount,
                            IsUnEmploymentInsurance = accountingObject.IsUnEmploymentInsurance,
                            RefTypeAO = accountingObject.RefTypeAO,
                            SalaryGrade = accountingObject.SalaryGrade,
                            CustomField1 = accountingObject.CustomField1,
                            CustomField2 = accountingObject.CustomField2,
                            CustomField3 = accountingObject.CustomField3,
                            CustomField4 = accountingObject.CustomField4,
                            CustomField5 = accountingObject.CustomField5,
                            IsPaidInsuranceForPayrollItem = accountingObject.IsPaidInsuranceForPayrollItem,
                            IsBornLeave = accountingObject.IsBornLeave,
                            TaxDepartmentName = accountingObject.TaxDepartmentName,
                            TreasuryName = accountingObject.TreasuryName,
                            EmployeeTypeId = accountingObject.EmployeeTypeId,
                            BudgetChapterId = accountingObject.BudgetChapterId,
                            OrganizationFeeCode = accountingObject.OrganizationFeeCode,
                            OrganizationManageFee = accountingObject.OrganizationManageFee,
                            TreasuryManageFee = accountingObject.TreasuryManageFee,
                        };

                        var responseaccountingObject = AccountingObjectClient.InsertAccountObjectConvert(_accountingObject);
                        result = responseaccountingObject.Message;
                        if (!string.IsNullOrEmpty(responseaccountingObject.Message))
                            return result;
                    }

                }

            }

            #endregion đối tượng 

            #region vật tư CCDC

            //kho 
            if (action == "Stock")
            {
                var lstStock = convertStock.GetStocks(connectionString);

                foreach (var Stock in lstStock)
                {
                    var responseStock = StockClient.InsertStockConvert(Stock);
                    result = responseStock.Message;
                    if (!string.IsNullOrEmpty(responseStock.Message)) return result;
                }
            }
            //nhóm vật tư CCDC
            if (action == "InventoryCategory")
            {
                //var lstInventoryCategory = convertInventoryCategory.GetInventoryItemsCategory(connectionString);

                //foreach (var _inventoryCategory in lstInventoryCategory)
                //{
                //    var responseInventoryCategory =
                //         InventoryItemCategoryClient.InsertInventoryItemCategoryConvert(_inventoryCategory);
                //    result = responseInventoryCategory.Message;
                //    if (!string.IsNullOrEmpty(responseInventoryCategory.Message))
                //        return result;
                //}
            }
            //danh mục vật tư CCDC
            if (action == "InventoryItem")


            {
                var lstInventoryCategory = convertInventoryCategory.GetInventoryItemsCategory(connectionString);

                foreach (var _inventoryCategory in lstInventoryCategory)
                {
                    var responseInventoryCategory =
                        InventoryItemCategoryClient.InsertInventoryItemCategoryConvert(_inventoryCategory);
                    result = responseInventoryCategory.Message;
                    if (!string.IsNullOrEmpty(responseInventoryCategory.Message))
                        return result;
                }

                var lstInventoryitem = convertInventoryItem.GetInventoryItem(connectionString);

                foreach (var _Inventoryitem in lstInventoryitem)
                {
                    var responseInventoryItem = InventoryItemClient.InsertInventoryItemConvert(_Inventoryitem);
                    result = responseInventoryItem.Message;
                    if (!string.IsNullOrEmpty(responseInventoryItem.Message)) return result;
                }
            }
            // nhóm hàng hóa dịch vụ
            if (action == "PurchasePurpose")
            {
                var lstPurchasePurpose = convertPurchasePurpose.GetPurchasePurpose(connectionString);

                foreach (var _purchasepurpose in lstPurchasePurpose)
                {
                    var responsePurchasePurpose = PurchasePurposeClient.InsertPurchasePurposeConvert(_purchasepurpose);
                    result = responsePurchasePurpose.Message;
                    if (!string.IsNullOrEmpty(responsePurchasePurpose.Message))
                        return result;
                }
            }

            #endregion vật tư CCDC

            #region Tài sản cố định

            //nhóm TSCĐ
            if (action == "FixedAssetCategory")
            {
                var lstFixedAssetCategory = convertFixedAssetCategory.GetFixedAssetCategory(connectionString);

                foreach (var _FixedAssetCategory in lstFixedAssetCategory)
                {
                    var responseFixedAssetCategory =
                           FixedAssetCategoryClient.InsertFixedAssetCategoryConvert(_FixedAssetCategory);
                    result = responseFixedAssetCategory.Message;
                    if (!string.IsNullOrEmpty(responseFixedAssetCategory.Message))
                        return result;
                }

            }

            //danh mục TSCĐ
            if (action == "FixedAsset")
            {
                var lstFixedAsset = convertFixedAsset.GetFixedAsset(connectionString);

                foreach (var _FixedAsset in lstFixedAsset)
                {
                    var responseFixedAsset = FixedAssetClient.InsertFixedAssetConvert(_FixedAsset);
                    result = responseFixedAsset.Message;
                    if (!string.IsNullOrEmpty(responseFixedAsset.Message)) return result;
                }

            }

            #endregion

            #region Danh mục khác 

            #region dự án 

            if (action == "Project")
            {
                var lstProject = convertProject.GetProject(connectionString);

                foreach (var _Project in lstProject)
                {
                    var responseProject = ProjectClient.InsertProjectConvert(_Project);
                    result = responseProject.Message;
                    if (!string.IsNullOrEmpty(responseProject.Message)) return result;
                }
            }


            #endregion

            #region hoạt động

            if (action == "CareerWork")
            {
                var lstActivity = convertActivity.GetActivity(connectionString);

                foreach (var _Activity in lstActivity)
                {
                    var responseActivity = ActivityClient.InsertActivityConvert(_Activity);
                    result = responseActivity.Message;
                    if (!string.IsNullOrEmpty(responseActivity.Message)) return result;
                }
            }

            #endregion

            #region ngân hàng

            if (action == "Bank")
            {
                var lstBank = convertBank.GetBank(connectionString);


                foreach (var _Bank in lstBank)
                {
                    var responseBank = BankClient.InsertBankConvert(_Bank);
                    result = responseBank.Message;
                    if (!string.IsNullOrEmpty(responseBank.Message)) return result;
                }
            }

            #endregion

            #region mẫu số hóa đơn

            if (action == "InvoiceFormNumber")
            {
                var lstInvoiceFormNumber = convertInvoice.GetInvoiceFormNumber(connectionString);

                foreach (var _InvoiceFormNumber in lstInvoiceFormNumber)
                {
                    var responseInvoiceFormNumber = InvoiceClient.InsertInvoiceFormNumberConvert(_InvoiceFormNumber);
                    result = responseInvoiceFormNumber.Message;
                    return result;
                }
            }

            #endregion

            #region phí lệ phí

            if (action == "BudgetExpense")
            {
                var lstBudgetExpense = convertExpense.GetExpense(connectionString);

                foreach (var _BudgetExpense in lstBudgetExpense)
                {
                    var responseBudgetExpense = ExpenseClient.InsertBudgetExpenseConvert(_BudgetExpense);
                    result = responseBudgetExpense.Message;
                    if (!string.IsNullOrEmpty(responseBudgetExpense.Message))
                        return result;
                }
            }

            #endregion

            #region tien te

            if (action == "Currency")
            {
                var lstCurrency = convertCurrency.GetCurrency(connectionString);

                foreach (var _Currency in lstCurrency)
                {
                    var responseCurrency = currencyClient.InsertCurrency(_Currency);
                    result = responseCurrency.Message;
                    if (!string.IsNullOrEmpty(responseCurrency.Message)) return result;
                }
            }

            #endregion

            #endregion Danh mục khác


            #endregion

            #region Chứng từ

            //FADepreciation Facade - Test OK
            if (action == "OpeningInventoryEntry")
            {
                //OpeningInventoryEntry Facade - Test OK
                var OpeningInventoryEntrys = convertOpeningInventoryEntry.GetOpeningInventoryEntrys(connectionString);

                //foreach (var OpeningInventoryEntry in OpeningInventoryEntrys)
                {
                    var response =
                        OpeningInventoryEntryClient.UpdateOpeningInventoryEntryConvertDB(OpeningInventoryEntrys);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //OpeningFixedAssetEntry Facade - Test OK
            if (action == "OpeningFixedAssetEntry")
            {
                var OpeningFixedAssetEntrys =
                    convertOpeningFixedAssetEntry.GetOpeningFixedAssetEntrys(connectionString);

                foreach (var OpeningFixedAssetEntry in OpeningFixedAssetEntrys)
                {
                    var response = OpeningFixedAssetEntryClient.UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntry);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //BUBudgetReserve Facade - Test OK

            if (action == "BUBudgetReserve")
            {
                var BUBudgetReserves = convertBUBudgetReserve.GetBUBudgetReserves(connectionString);
                foreach (var BUBudgetReserve in BUBudgetReserves)
                {
                    var response = BUBudgetReserveClient.InsertBUBudgetReserve(BUBudgetReserve);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //convertCAReceipt Facade - Test OK
            if (action == "CAReceipt")
            {
                var CAReceipts = convertCAReceipt.GetCAReceipts(connectionString);

                foreach (var CAReceipt in CAReceipts)
                {
                    var response = CAReceiptClient.InsertCAReceipt(CAReceipt, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //BABankTransferDao Facade - Test OK
            if (action == "BABankTransfers")
            {
                var BABankTransferDaos = convertBABankTransferDao.GetBABankTransfers(connectionString);
                foreach (var BABankTransferDao in BABankTransferDaos)
                {
                    var response = BABankTransferClient.InsertBABankTransfer(BABankTransferDao);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //BADeposit Facade - Test OK

            if (action == "BADeposit")
            {
                var convertBADeposits = convertBADeposit.GetBADeposits(connectionString);

                foreach (var convertBADeposit in convertBADeposits)
                {
                    var response = BADepositClient.InsertBADeposit(convertBADeposit);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //
            if (action == "FADepreciation")
            {
                var FADepreciations = convertFADepreciationDao.GetFADepreciations(connectionString);
                foreach (var FADepreciation in FADepreciations)
                {
                    var response = FADepreciationClient.InsertFADepreciation(FADepreciation);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //OpeningAccountEntry Facade - Test OK
            if (action == "OpeningAccountEntry")

            {
                var currency = currencyClient.GetCurrencies();
                var OpeningAccountEntrys =
                    convertOpeningAccountEntryDao.GetOpeningAccountEntrys(connectionString, currency);

                //foreach (var OpeningAccountEntry in OpeningAccountEntrys)
                //{
                var responsea = OpeningAccountEntryClient.UpdateOpeningAccountEntry(OpeningAccountEntrys);
                result = responsea.Message;
                if (!string.IsNullOrEmpty(responsea.Message))
                    return result;
                //}
            }
            //FAAdjustment Facade - Test OK
            if (action == "RevaluationOfFixedAssets")
            {
                var FAAdjustments = convertFAAdjustmentDao.GetFAAdjustments(connectionString);
                foreach (var FAAdjustment in FAAdjustments)
                {
                    var response = FAAdjustmentClient.InsertFAAdjustment(FAAdjustment,false);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //FAIncrementDecrement Facade - Test OK
            if (action == "FADecrement")
            {
                var FAIncrementDecrements = convertFAIncrementDecrementDao.GetFAIncrementDecrements(connectionString);
                foreach (var FAIncrementDecrement in FAIncrementDecrements)
                {
                    var response = FAIncrementDecrementClient.UpdateFAIncrementDecrement(FAIncrementDecrement, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //===============================================================================================
            //GLVoucherList Facade - chưa Test OK, chờ danh mục
            if (action == "GLVoucherList")
            {
                var GLVoucherLists = convertGLVoucherListDao.GetGLVoucherLists(connectionString);
                foreach (var GLVoucherList in GLVoucherLists)
                {
                    var response = GLVoucherListClient.InsertGLVoucherList(GLVoucherList);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //GLVoucher Facade - chưa Test OK, chờ danh mục
            if (action == "General")
            {
                var GLVouchers = convertGLVoucherDao.GetGLVouchers(connectionString);
                foreach (var GLVoucher in GLVouchers)
                {
                    var response = GLVoucherClient.InsertGLVoucher(GLVoucher, false);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }


            //PUInvoiceDao Facade - Test OK
            if (action == "PUDetailFixedAsset")
            {
                var PUInvoices = convertPUInvoiceDao.GetPUInvoices(connectionString);
                foreach (var PUInvoice in PUInvoices)
                {
                    var response = PUInvoiceClient.UpdatePUInvoice(PUInvoice);
                    if (!string.IsNullOrEmpty(response.Message))
                        return result = response.Message;
                }
            }

            //SUTransfer Facade - Test OK
            if (action == "SUTransfer")
            {
                var SUTransfers = convertSUTransferDao.GetSUTransfers(connectionString);
                foreach (var SUTransfer in SUTransfers)
                {
                    var response = SUTransferClient.InsertSUTransfer(SUTransfer, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //SUIncrementDecrement Facade - Test OK
            if (action == "SUIncrement")
            {
                var SUIncrementDecrements = convertSUIncrementDecrementDao.GetSUIncrementDecrements(connectionString);
                foreach (var SUIncrementDecrement in SUIncrementDecrements)
                {
                    var response = SUIncrementDecrementClient.InsertSUIncrementDecrement(SUIncrementDecrement, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result = response.Message;
                }
            }

            //OpeningSupplyEntryDao Facade - Test OK
            if (action == "OpeningSupplyEntry")
            {
                var OpeningSupplyEntrys = convertOpeningSupplyEntryDao.GetOpeningSupplyEntrys(connectionString);
                foreach (var OpeningSupplyEntry in OpeningSupplyEntrys)
                {
                    var response = OpeningSupplyEntryClient.InsertOpeningSupplyEntry(OpeningSupplyEntry);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //INInwardOutwardDao Facade - Test OK
            if (action == "INInward")
            {
                var INInwardOutwards = convertINInwardOutwardDao.GetINInwardOutwards(connectionString);

                foreach (var INInwardOutward in INInwardOutwards)
                {
                    var response = INInwardOutwardClient.InsertINInwardOutward(INInwardOutward, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //BAWithDraw Facade - Chưa test OK, đợi danh mục fixedasset được insert
            if (action == "BAWithDraw")
            {
                var BAWithDraws = convertBAWithDrawDao.GetBAWithDraws(connectionString);

                foreach (var BAWithDraw in BAWithDraws)
                {
                    var response = BAWithDrawClient.InsertBAWithDraw(BAWithDraw, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //CAPayment Facade - Chưa test OK, đợi danh mục fixedasset được insert
            if (action == "CAPayment")
            {
                var CAPayments = convertCAPaymentDao.GetCAPaymentLists(connectionString);

                foreach (var CAPayment in CAPayments)
                {
                    var response = CAPaymentClient.InsertCAPayment(CAPayment, true);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }



            //BUVoucherList Facade - Test OK
            if (action == "BUVoucherList")
            {
                var BUVoucherLists = convertBUVoucherListDao.GetBUVoucherLists(connectionString);

                foreach (var BUVoucherList in BUVoucherLists)
                {
                    var response = BUVoucherListClient.InsertBUVoucherList(BUVoucherList);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //BUTransfer Facade - Chưa test OK, đợi danh mục fixedasset được insert
            if (action == "BUTransfer")
            {
                var BUTransfers = convertBUTransferDao.GetBUTransfers(connectionString);
                foreach (var BUTransfer in BUTransfers)
                {
                    var response = BUTransferClient.InsertBUTransfer(BUTransfer, false);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }
            //OpeningCommitment Facade - Test OK
            if (action == "OpeningCommitment")
            {
                var OpeningCommitments = convertOpeningCommitmentDao.GetOpeningCommitments(connectionString);

                foreach (var OpeningCommitment in OpeningCommitments)
                {
                    var response = OpeningCommitmentClient.InsertOpeningCommitment(OpeningCommitment);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //BUCommitmentAdjustment Facade - Test OK
            if (action == "CommitmentAdjustment")
            {
                var BUCommitmentAdjustments =
                    convertBUCommitmentAdjustmentDao.GetBUCommitmentAdjustments(connectionString);

                foreach (var BUCommitmentAdjustment in BUCommitmentAdjustments)
                {
                    var response = BUCommitmentAdjustmentClient.InsertBUCommitmentAdjustment(BUCommitmentAdjustment);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //BUCommitmentRequests Facade - Test OK
            if (action == "CommitmentRequest")
            {
                var BUCommitmentRequests = convertBUCommitmentRequestDao.GetBUCommitmentRequests(connectionString);

                foreach (var BUCommitmentRequest in BUCommitmentRequests)
                {
                    var response = BUCommitmentRequestClient.InsertBUCommitmentRequest(BUCommitmentRequest);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //Điều chỉnh dự toán - Test OK
            if (action == "BUPlanAdjustment")
            {
                var BUPlanAdjustments = convertBUPlanAdjustmentDao.GetBUPlanAdjustments(connectionString);
                foreach (var BUPlanAdjustment in BUPlanAdjustments)
                {
                    var response = BUPlanAdjustmentClient.InsertBuPlanAdjustment(BUPlanAdjustment);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }

            //Nhóm rút dự toán - Test OK
            if (action == "BUPlanWithdraw")
            {
                var BUPlanWithdraws = convertBUPlanWithdrawDao.GetBUPlanWithdraws(connectionString);


                foreach (var BUPlanWithdraw in BUPlanWithdraws)
                {
                    var response = BUPlanWithdrawClient.InsertBUPlanWithdraw(BUPlanWithdraw);
                    result = response.Message;
                    if (!string.IsNullOrEmpty(response.Message))
                        return result;
                }
            }


            //Nhận dự toán, hủy dự toán - Test OK
            if (action == "BUPlanReceipt")
            {
                var BUPlanReceipts = convertBUPlanReceiptDao.GetBuPlanReceipts(connectionString);

                foreach (var BUPlanReceipt in BUPlanReceipts)
                {
                    var responseBUPlanReceipt = BUPlanReceiptClient.InsertBUPlanReceipt(BUPlanReceipt);
                    result = responseBUPlanReceipt.Message;
                    if (!string.IsNullOrEmpty(responseBUPlanReceipt.Message))
                        return result;
                }
            }


            #endregion

            return result;
        }

    }
}
