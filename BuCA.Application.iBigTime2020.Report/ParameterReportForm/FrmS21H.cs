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
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using DateTimeRangeBlockDev.Helper;
using BuCA.Application.iBigTime2020.Session;
using Microsoft.SqlServer.Management.Smo;

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
    public partial class FrmS21H : FrmXtraBaseParameter, IStocksView, IInventoryItemCategoriesView, IAccountsView, IInventoryItemsView
    {
        private bool IsVisibleAccount = true;
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

                if ((cboStock.EditValue.ToString() == "a7f14b9e-71a8-42fd-9cfc-9315e6551a03"))
                {
                    return "";
                }
                return cboStock.EditValue == null ? "" : cboStock.EditValue.ToString();
            }
        }

        public bool IsDetailMonth
        {
            get
            { return chkDetailMonth.Checked; }
        }

        /// <summary>
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>
        
      

        public string InventoryIDs
        {
            get
            {
                var selectInventoryItem = ",";
                if (Selection.IsSelectedAll || Selection.SelectedCount <1)
                    return null;
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
      
        /// <summary>
        /// Gets or sets the inventory item category identifier.
        /// </summary>
        /// <value>The inventory item category identifier.</value>
        public string InventoryItemCategoryId
        {
            get; set;
        }
        public string StockID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is group by inventory item.
        /// </summary>
        /// <value><c>true</c> if this instance is group by inventory item; otherwise, <c>false</c>.</value>
        public bool isGroupByInventoryItem { get; }

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS22H" /> class.
        /// </summary>
        public FrmS21H(bool isVisibleAccount, bool isVisibleStock)
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            //this.cboAccountNumber.Visible = isVisibleAccount;
            //this.labelControl1.Visible = isVisibleAccount;                        
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
                //cboAccountNumber.Properties.DataSource = result;
                //cboAccountNumber.Properties.ForceInitialize();
                //cboAccountNumber.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
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


                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboAccountNumber.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboAccountNumber.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboAccountNumber.Properties.Columns[column.ColumnName].Visible = false;
                //}
                //cboAccountNumber.Properties.DisplayMember = "AccountNumber";
                //cboAccountNumber.Properties.ValueMember = "AccountNumber";
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
                result.AddRange(value);
                
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
                    new StockModel {StockId = "a7f14b9e-71a8-42fd-9cfc-9315e6551a03", StockCode = "<<Tất cả>>"}
                };
                result.AddRange(value.OrderBy(v => v.StockCode));
                cboStock.Properties.DataSource = result;
                cboStock.Properties.ForceInitialize();
                cboStock.Properties.PopulateColumns();
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
                //if (InventoryItemCategoryId != null)
                //{
                //    bindingSource.DataSource = value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList();
                //    gridInventoryView.PopulateColumns(value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList());
                //}
                if (StockID != null)
                {
                    bindingSource.DataSource = value.Where(x => x.DefaultStockId == StockID).ToList();
                    gridInventoryView.PopulateColumns(value.Where(x => x.DefaultStockId == StockID).ToList());
                }
                else
                {
                    bindingSource.DataSource = value;
                    gridInventoryView.PopulateColumns(value);
                }
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư/CCDC", ToolTip = "Tên vật tư/CCDC", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư/CCDC", ToolTip = "Mã vật tư/CCDC", ColumnPosition = 0, ColumnVisible = true, ColumnWith = 260 });
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
            BindSelectDesignReport();
            //cboSelectDesignReport.EditValue = 0;
            //checkAddSameEntry.Checked = true;
            dateTimeRangeV1.cboDateRange.SelectedItem = GlobalVariable.DateRangeSelected;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            cboStock.EditValue = "a7f14b9e-71a8-42fd-9cfc-9315e6551a03";
            cboInventoryType.EditValue = "<<Tất cả>>";
            cboInventoryType.Visible = false;
            labelControl6.Visible = false;          // ẩn 2 thằng này theo yêu cầu của chị Mai và chị Trinh ngày 21/7
        }
        #endregion

        #region Method
        /// <summary>
        /// Binds the select design report.
        /// </summary>
        protected void BindSelectDesignReport()
        {
            //var bankSource = new List<LookUpItem> { new LookUpItem { Id = 0, Name = "Thông tư 107/2017/TT-BTC" }};
            //cboSelectDesignReport.Properties.DataSource = bankSource;
            //cboSelectDesignReport.Properties.PopulateColumns();
            //var treeColumnsCollection = new List<XtraColumn> {
            //                                    new XtraColumn { ColumnName = "Id", ColumnVisible = false },
            //                                    new XtraColumn { ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true }
            //                                };
            //foreach (var column in treeColumnsCollection)
            //{
            //    if (column.ColumnVisible)
            //    {
            //        cboSelectDesignReport.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //        cboSelectDesignReport.Properties.SortColumnIndex = column.ColumnPosition;
            //    }
            //    else cboSelectDesignReport.Properties.Columns[column.ColumnName].Visible = false;
            //}
            //cboSelectDesignReport.Properties.ValueMember = "Id";
            //cboSelectDesignReport.Properties.DisplayMember = "Name";
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
            Selection.CheckMarkColumn.Width = 55;
            //  Selection.SelectAll();
        }

        private void cboStock_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStock.EditValue == null) return;
            if ((string)cboStock.GetColumnValue("StockCode") == "<<Tất cả>>")
            {
                StockID = null;
            }
            else
            {
                StockID = (string)cboStock.GetColumnValue("StockId");
            }
            _inventoryItemsPresenter.DisplayByIsActive(true);

            Selection = new GridCheckMarksSelection(gridInventoryView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 55;
        }
    }
}
