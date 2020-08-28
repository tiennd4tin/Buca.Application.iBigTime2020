/***********************************************************************
 * <copyright file="FrmS22H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, November 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, November 28, 2017Author SonTV  Description 
 * 
 * ************************************************************************/


using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using Buca.Application.iBigTime2020.Model;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraSplashScreen;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS22H.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IStocksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemCategoriesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    public partial class FrmS22H : FrmXtraBaseParameter, IStocksView, IInventoryItemCategoriesView, IAccountsView, IInventoryItemsView
    {
        private bool IsVisibleAccount = true;
        List<StockModel> _listStock;
        List<AccountModel> _listAccount;
        IList<InventoryItemModel> _listInventory;
        #region Presenter
        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;
        /// <summary>
        /// The inventory item categories presenter
        /// </summary>
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        /// <summary>
        /// The stocks presenter
        /// </summary>
        private readonly StocksPresenter _stocksPresenter;

        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        #endregion


        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }
        #region Variable
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        /// <summary>
        /// Gets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public string StockId
        {
            get
            {
                if (cboStock.EditValue.ToString() == "5860BBA4-4D5C-411C-A852-FE0DFAF50FD4")
                {
                    return null;
                }
                else
                {
                    return cboStock.EditValue == null ? null : cboStock.EditValue.ToString();
                }
            }
        }

        /// <summary>
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>
        public string InventoryItemIds
        {
            get
            {
                var selectInventoryItem = "";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridInventoryView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectInventoryItem += (selectInventoryItem != "") ? ",," + gridInventoryView.GetRowCellValue(i, "InventoryItemId") : "" + gridInventoryView.GetRowCellValue(i, "InventoryItemId");
                        }
                    }
                }
                if (selectInventoryItem != "")
                    selectInventoryItem += selectInventoryItem + ',';
                return selectInventoryItem;
            }
        }

        public string AllInventoryItemIds
        {
            get
            {
                var selectInventoryItem = "";
                Selection.SelectAll();
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridInventoryView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectInventoryItem += (selectInventoryItem != "") ? ",," + gridInventoryView.GetRowCellValue(i, "InventoryItemId") : "" + gridInventoryView.GetRowCellValue(i, "InventoryItemId");
                        }
                    }
                }
                if (selectInventoryItem != "")
                    selectInventoryItem += selectInventoryItem + ',';
                return selectInventoryItem;
            }
        }

        public string InventoryIDs
        {
            get
            {
                var selectInventoryItem = ",";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridInventoryView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (InventoryItemModel)gridInventoryView.GetRow(i);
                            selectInventoryItem = selectInventoryItem + row.InventoryItemId + ",";
                        }
                    }
                }
                return selectInventoryItem;
            }
        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber
        {
            get
            {
                if (cboAccountNumber.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                else
                {
                    return cboAccountNumber.EditValue.ToString();
                }

            }
        }

        /// <summary>
        /// Gets or sets the inventory item category identifier.
        /// </summary>
        /// <value>The inventory item category identifier.</value>
        public string InventoryItemCategoryId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is group by inventory item.
        /// </summary>
        /// <value><c>true</c> if this instance is group by inventory item; otherwise, <c>false</c>.</value>
        public bool isGroupByInventoryItem
        {
            get { return true; }
            //{
            //    //if (checkAddSameEntry.Checked)
            //    //    return true;
            //    //else
            //    //    return false;
            //}
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS22H" /> class.
        /// </summary>
        public FrmS22H(bool isVisibleAccount, bool isVisibleStock)
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            this.cboAccountNumber.Visible = isVisibleAccount;
            this.labelControl1.Visible = isVisibleAccount;
            this.labelControl5.Visible = isVisibleStock;
            this.cboStock.Visible = isVisibleStock;
            IsVisibleAccount = isVisibleAccount;
        }


        #region IView

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                var result = new List<AccountModel>
                {
                    new AccountModel {AccountNumber = "<<Tất cả>>", AccountName = "<<Tất cả>>"}
                };

                result.AddRange(value.Where(x => x.DetailByInventoryItem == true).ToList());
                cboAccountNumber.Properties.DataSource = result;
                cboAccountNumber.Properties.ForceInitialize();
                cboAccountNumber.Properties.PopulateColumns();
                _listAccount = result;
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnCaption = "Tên tài khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccountNumber.Properties.PopupWidth = 500;
                        cboAccountNumber.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountNumber.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboAccountNumber.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboAccountNumber.Properties.DisplayMember = "AccountNumber";
                cboAccountNumber.Properties.ValueMember = "AccountNumber";
            }
        }

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                var result = new List<InventoryItemCategoryModel>
                {
                    new InventoryItemCategoryModel {InventoryItemCategoryCode = "<<Tất cả>>", InventoryItemCategoryName = "<<Tất cả>>"}
                };
                //TinTV: chỉ lấy CCDC
                var data = value.Where(o => o.InventoryItemCategoryCode.Contains("VT") || o.InventoryItemCategoryCode.Contains("CCDC"));
                result.AddRange(data);
                cboInventoryType.Properties.DataSource = result;
                cboInventoryType.Properties.ForceInitialize();
                cboInventoryType.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryCode",
                    ColumnCaption = "Mã loại",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryName",
                    ColumnCaption = "Tên loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboInventoryType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboInventoryType.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboInventoryType.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboInventoryType.Properties.DisplayMember = "InventoryItemCategoryCode";
                cboInventoryType.Properties.ValueMember = "InventoryItemCategoryCode";
            }
        }

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                var result = new List<StockModel>
                {
                    new StockModel { StockId = "5860BBA4-4D5C-411C-A852-FE0DFAF50FD4", StockCode = "<<Tất cả>>", StockName= "<<Tất cả>>"}
                };
                result.AddRange(value.OrderBy(v => v.StockCode));
                cboStock.Properties.DataSource = result;
                cboStock.Properties.ForceInitialize();
                cboStock.Properties.PopulateColumns();
                _listStock = result;
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "StockCode",
                    ColumnCaption = "Mã kho",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "StockName",
                    ColumnCaption = "Tên kho",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboStock.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboStock.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboStock.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboStock.Properties.DisplayMember = "StockCode";
                if (IsVisibleAccount)
                {
                    cboStock.Properties.ValueMember = "StockId";
                }
                else
                {
                    cboStock.Properties.ValueMember = "StockId";
                }
            }
        }

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (AccountNumber != null)
                {
                    bindingSource.DataSource = value.Where(x => x.InventoryAccount == AccountNumber).ToList();
                    gridInventoryView.PopulateColumns(value.Where(x => x.InventoryAccount == AccountNumber).ToList());
                }
                else
                {
                    bindingSource.DataSource = value;
                    gridInventoryView.PopulateColumns(value);
                }
                _listInventory = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư/CCDC", ToolTip = "Tên vật tư/CCDC", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư/CCDC", ToolTip = "Mã vật tư/CCDC", ColumnPosition = 0, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });

                if (ColumnsCollection == null) return;
                foreach (var column in ColumnsCollection)
                {
                    if (gridInventoryView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridInventoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridInventoryView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridInventoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridInventoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridInventoryView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridInventoryView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridInventoryView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridInventoryView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridInventoryView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridInventoryView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Handles the Load event of the FrmS22H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmS22H_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
            _stocksPresenter.DisplayByIsActive(true);
            _inventoryItemCategoriesPresenter.Display(true);
            cboStock.EditValue = "5860BBA4-4D5C-411C-A852-FE0DFAF50FD4";
            cboInventoryType.EditValue = "<<Tất cả>>";
            cboAccountNumber.EditValue = "<<Tất cả>>";
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }
        #endregion

        #region Method
        /// <summary>
        /// Binds the select design report.
        /// </summary>
        protected void BindSelectDesignReport()
        {

        }
        #endregion

        /// <summary>
        /// Handles the EditValueChanged event of the cboInventoryType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboInventoryType_EditValueChanged(object sender, EventArgs e)
        {
            if (cboInventoryType.EditValue == null) return;
            if ((string)cboInventoryType.GetColumnValue("InventoryItemCategoryId") == "<<Tất cả>>")
            {
                InventoryItemCategoryId = null;
            }
            else
            {
                InventoryItemCategoryId = (string)cboInventoryType.GetColumnValue("InventoryItemCategoryId");
            }
            _inventoryItemsPresenter.DisplayByIsActive(true);

            Selection = new GridCheckMarksSelection(gridInventoryView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;

        }

        private void cboStock_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStock.EditValue != "5860BBA4-4D5C-411C-A852-FE0DFAF50FD4" && cboStock.EditValue != null)
            {
                var accountNumber = _listStock.FirstOrDefault(o => o.StockId == cboStock.EditValue).DefaultAccountNumber;
                if (accountNumber.StartsWith("152"))
                {
                    var data = _listAccount.Where(o => o.AccountNumber.StartsWith("152")).ToList();
                    cboAccountNumber.Properties.DataSource = data;
                    cboAccountNumber.EditValue = "152";

                }
                else if (accountNumber.StartsWith("153"))
                {
                    var data = _listAccount.Where(o => o.AccountNumber == "153").ToList();
                    cboAccountNumber.Properties.DataSource = data;
                    cboAccountNumber.EditValue = "153";

                }
            }
            else
                cboAccountNumber.EditValue = "<<Tất cả>>";

        }

        private void cboAccountNumber_EditValueChanged(object sender, EventArgs e)
        {
            IModel model = new Model();
            if (cboAccountNumber.EditValue.ToString() != "<<Tất cả>>" && cboAccountNumber.EditValue != null)
            {
                var inventoryItems = model.GetInventoryItemsByIsAtive(true);
                List<InventoryItemModel> _ListObjs = new List<InventoryItemModel>();
                if (cboAccountNumber.EditValue.ToString().StartsWith("152"))
                {
                    var data = inventoryItems.Where(o => o.InventoryAccount == "152");
                    foreach (var item in data)
                    {
                        _ListObjs.Add(item);
                    }
                }
                if (cboAccountNumber.EditValue.ToString() == "153")
                {
                    var data = inventoryItems.Where(o => o.InventoryAccount == "153");
                    foreach (var item in data)
                    {
                        _ListObjs.Add(item);
                    }
                }
                gridInventoryControl.DataSource = null;
                gridInventoryControl.DataSource = _ListObjs;
                gridInventoryControl.Refresh();
                gridInventoryView.RefreshData();
            }

            else
            {
                List<InventoryItemModel> _ListObjs = new List<InventoryItemModel>();
                var inventoryItems = model.GetInventoryItemsByIsAtive(true);
                foreach (var item in inventoryItems)
                {
                    _ListObjs.Add(item);
                }
                gridInventoryControl.DataSource = null;
                gridInventoryControl.DataSource = _ListObjs;
                gridInventoryControl.Refresh();
                gridInventoryView.RefreshData();
            }
        } 
        
    }
}
