using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Buca.Application.iBigTime2020.WindowsForm.Code
{
    /// <summary>
    /// Class BusinessExtension.
    /// </summary>
    public static class BusinessExtension
    {
        /// <summary>
        /// Gets the debi account.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refTypeModels">The reference type models.</param>
        /// <returns>System.Int64.</returns>
        public static List<AccountModel> DebitAccounts(this List<AccountModel> item, int refTypeId, List<RefTypeModel> refTypeModels)
        {
            var debitAccounts = new List<AccountModel>();
            var refType = refTypeModels.FirstOrDefault(r => r.RefTypeId == refTypeId);
            if (refType != null && !string.IsNullOrEmpty(refType.DefaultDebitAccountCategoryId))
            {
                var defaultDebitAccountCategoryIds = refType.DefaultDebitAccountCategoryId.Split(';');
                foreach (var defaultDebitAccountCategoryId in defaultDebitAccountCategoryIds)
                {
                    debitAccounts.AddRange(item.Where(v => (v.AccountCategoryId == defaultDebitAccountCategoryId || v.AccountNumber == defaultDebitAccountCategoryId) && debitAccounts.Count(x => x.AccountId == v.AccountId) == 0));
                }
            }
            else
            {
                return item;
            }
            return debitAccounts;
        }

        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        public static AccountModel DefaultDebitAccount(List<AccountModel> listAccounts, int refTypeId, List<RefTypeModel> refTypeModels)
        {
            var refType = refTypeModels.FirstOrDefault(r => r.RefTypeId == refTypeId);
            if (refType != null && !string.IsNullOrEmpty(refType.DefaultDebitAccountId))
                return listAccounts?.FirstOrDefault(v => v.AccountNumber.Equals(refType.DefaultDebitAccountId));
            else
                return null;
        }

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        public static AccountModel DefaultCreditAccount(List<AccountModel> listAccounts, int refTypeId, List<RefTypeModel> refTypeModels)
        {
            var refType = refTypeModels.FirstOrDefault(r => r.RefTypeId == refTypeId);
            if (refType != null && !string.IsNullOrEmpty(refType.DefaultCreditAccountId))
                return listAccounts?.FirstOrDefault(v => v.AccountNumber.Equals(refType.DefaultCreditAccountId));
            else
                return null;
        }

        public static List<string> GetListAccountDetailBy(AccountModel account)
        {
            // Lấy theo hệ thống tài khoản
            var listDetailBy = Enum.GetNames(typeof(BuCA.Enum.AccountDetailByEnum)).ToList();
            Type myType = account.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            List<string> listField = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                if (listDetailBy.Exists(m => m.Equals(prop.Name)))
                {
                    var objValue = prop.GetValue(account, null);
                    bool result;
                    if (bool.TryParse(Convert.ToString(objValue), out result) && result)
                        listField.Add(prop.Name);
                }
            }
            return listField;
        }

        /// <summary>
        /// Credits the accounts.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refTypeModels">The reference type models.</param>
        /// <returns>List&lt;AccountModel&gt;.</returns>
        public static List<AccountModel> CreditAccounts(this List<AccountModel> item, int refTypeId, List<RefTypeModel> refTypeModels)
        {
            var debitAccounts = new List<AccountModel>();
            var refType = refTypeModels.FirstOrDefault(r => r.RefTypeId == refTypeId);
            if (refType != null && !string.IsNullOrEmpty(refType.DefaultCreditAccountCategoryId))
            {
                var defaultCreditAccountCategoryIds = refType.DefaultCreditAccountCategoryId.Split(';');
                foreach (var defaultCreditAccountCategoryId in defaultCreditAccountCategoryIds)
                {
                    debitAccounts.AddRange(item.Where(v => (v.AccountCategoryId == defaultCreditAccountCategoryId || v.AccountNumber == defaultCreditAccountCategoryId) && debitAccounts.Count(x => x.AccountId == v.AccountId) == 0));
                }
            }
            else
            {
                return item;
            }
            return debitAccounts;
        }

        /// <summary>
        /// Parallels the accounts.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>List&lt;AccountModel&gt;.</returns>
        public static List<AccountModel> ParallelAccounts(this List<AccountModel> item)
        {
            var parallelAccounts = item.ToList();//.Where(i => i.AccountNumber.StartsWith("0")).ToList();
            return parallelAccounts;
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="columnsCollection">The columns collection.</param>
        public static void InitGridLayout(this GridView grdView, List<XtraColumn> columnsCollection)
        {
            foreach (GridColumn grd in grdView.Columns)
            {
                //Check column có tồn tại k nếu k thì add thêm -KienNT
                var columnCheckExits = columnsCollection.FirstOrDefault(r => r.ColumnName == grd.FieldName);

                if (columnCheckExits == null)
                {
                    columnsCollection.Add(new XtraColumn { ColumnName = grd.FieldName, ColumnVisible = false });
                }

                //check lại so sánh grid với columnsCollection nếu có thì mới cho bin template -KienNT
                var column = columnsCollection.FirstOrDefault(r => r.ColumnName == grd.FieldName);
                if (column != null)
                {
                    if (grdView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            try
                            {
                                grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                                grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                                //grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                                grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                                grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                                grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                                if (column.IsSummnary)
                                {
                                    grdView.Columns[column.ColumnName].SummaryItem.SummaryType = column.SummaryType;
                                    grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = column.DisplayFormat;
                                }

                                //default summary in some below cases
                                if (column.ColumnName.Contains("AmountOC") || column.ColumnName.Contains("Amount"))
                                {
                                    grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Sum;
                                    grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                        GlobalVariable.CurrencyDisplayString;
                                    grdView.Columns[column.ColumnName].SummaryItem.Format =
                                        Thread.CurrentThread.CurrentCulture;
                                }
                                if (column.ColumnPosition == 1)
                                {
                                    grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Count;
                                    grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Số dòng = {0:n0}";
                                }
                                //if (column.ColumnName.Contains("Amount") || column.ColumnName.Contains("Quantity"))
                                //{
                                //    grdView.Columns[column.ColumnName].DisplayFormat.FormatString = column.DisplayFormat;
                                //}
                            }

                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message, column.ColumnName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else
                        {
                            try
                            {
                                grdView.Columns[column.ColumnName].Visible = false;
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message, column.ColumnName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the numeric format control.
        /// LinhMC bo sung them dieu kien:
        /// repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.ExchangeRateDecimalDigits)/ int.Parse(DBOptionHelper.CurrencyDecimalDigits);
        /// mục đích của thằng này là để làm tròn đúng số thập phân như định dạng khi người dùng nhấn công cụ tính toán
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        public static void SetNumericFormatControl(this GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {

                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                        }

                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
                        }
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (oCol.Name.ToLower().Contains("quantity"))
                        {
                            var _numberDecimalDigits = string.IsNullOrEmpty(GlobalVariable.NumberDecimalDigits) ? "0" : GlobalVariable.NumberDecimalDigits;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"n" + _numberDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(_numberDecimalDigits);
                        }

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;

                        //oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        //oCol.DisplayFormat.FormatType = FormatType.DateTime;
                        //oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Valids the detail gl voucher last year.
        /// </summary>
        /// <param name="accountModel">The account model.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="budgetSubItemCode">The budget sub item code.</param>
        /// <param name="methodDistributeId">The method distribute identifier.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValidDetailGLVoucherLastYear(this AccountModel accountModel, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode,
       string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, string accountingObjectId, string activityId,
       string projectId, string bankId, string inventoryItemId, string fixedAssetId, string currencyId = null)
        {
            if (accountModel != null)
            {
                // Nguồn
                if (accountModel.DetailByBudgetSource && string.IsNullOrEmpty(budgetSourceId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetSourceId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Chương
                if (accountModel.DetailByBudgetChapter && string.IsNullOrEmpty(budgetChapterCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetChapterCode"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Loại khoản
                if (accountModel.DetailByBudgetKindItem && string.IsNullOrEmpty(budgetKindItemCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetKindItemCode"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Mục
                if (accountModel.DetailByBudgetItem && string.IsNullOrEmpty(budgetItemCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetItemCode"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Tiểu mục - loại mục
                if (accountModel.DetailByBudgetSubItem && string.IsNullOrEmpty(budgetSubItemCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetSubItemCode"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Dự án 
                if (accountModel.DetailByProject && string.IsNullOrEmpty(projectId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyProjectId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Đối tượng
                if (accountModel.DetailByAccountingObject && string.IsNullOrEmpty(accountingObjectId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyAccountingObjectId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Hoạt động
                if (accountModel.DetailByActivity && string.IsNullOrEmpty(activityId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyActivityId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Vật tư
                //if (accountModel.DetailByInventoryItem && string.IsNullOrEmpty(inventoryItemId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyInventoryItemId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Tài sản
                //if (accountModel.DetailByFixedAsset && string.IsNullOrEmpty(fixedAssetId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyFixedAssetId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Ngân hàng, kho bạc
                if (accountModel.DetailByBankAccount && string.IsNullOrEmpty(bankId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBankAccountId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                // Tiền tệ
                //if (accountModel.DetailByCurrency && string.IsNullOrEmpty(currencyId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyCurrencyId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Hình thức cấp phát
                if (accountModel.DetailByMethodDistribute && methodDistributeId == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyMethodDistributeId"),
                                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }


        public static List<String> ValidDetailGLVoucherLastYearByAccount(this AccountModel accountModel, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode,
      string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, string accountingObjectId, string activityId,
      string projectId, string bankId, string inventoryItemId, string fixedAssetId, string currencyId = null)
        {
            List<String> result = new List<string>();
            if (accountModel != null)
            {
                // Nguồn
                if (accountModel.DetailByBudgetSource && string.IsNullOrEmpty(budgetSourceId))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetSourceId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BudgetSourceId");
                }

                // Chương
                if (accountModel.DetailByBudgetChapter && string.IsNullOrEmpty(budgetChapterCode))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetChapterCode"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BudgetChapterCode");
                }

                // Loại khoản
                if (accountModel.DetailByBudgetKindItem && string.IsNullOrEmpty(budgetKindItemCode))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetKindItemCode"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BudgetSubKindItemCode");
                }

                // Mục
                if (accountModel.DetailByBudgetItem && string.IsNullOrEmpty(budgetItemCode))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetItemCode"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BudgetItemCode");
                }

                // Tiểu mục - loại mục
                if (accountModel.DetailByBudgetSubItem && string.IsNullOrEmpty(budgetSubItemCode))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetSubItemCode"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BudgetSubItemCode");
                }

                // Dự án 
                if (accountModel.DetailByProject && string.IsNullOrEmpty(projectId))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyProjectId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("ProjectId");
                }

                // Đối tượng
                if (accountModel.DetailByAccountingObject && string.IsNullOrEmpty(accountingObjectId))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyAccountingObjectId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("AccountingObjectId");
                }

                // Hoạt động
                if (accountModel.DetailByActivity && string.IsNullOrEmpty(activityId))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyActivityId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("ActivityId");
                }

                // Vật tư
                //if (accountModel.DetailByInventoryItem && string.IsNullOrEmpty(inventoryItemId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyInventoryItemId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Tài sản
                //if (accountModel.DetailByFixedAsset && string.IsNullOrEmpty(fixedAssetId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyFixedAssetId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Ngân hàng, kho bạc
                if (accountModel.DetailByBankAccount && string.IsNullOrEmpty(bankId))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBankAccountId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("BankAccountId");
                }

                // Tiền tệ
                //if (accountModel.DetailByCurrency && string.IsNullOrEmpty(currencyId))
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyCurrencyId"),
                //                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                   MessageBoxIcon.Error);
                //    return false;
                //}

                // Hình thức cấp phát
                if (accountModel.DetailByMethodDistribute && methodDistributeId == null)
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyMethodDistributeId"),
                    //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //               MessageBoxIcon.Error);
                    result.Add("MethodDistributeId");
                }
            }
            return result;
        }

    }
}
