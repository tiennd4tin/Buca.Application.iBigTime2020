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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using DevExpress.XtraEditors;

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
    public partial class FrmS51H : FrmXtraBaseParameter, IInventoryItemCategoriesView, IInventoryItemsView, IActivitysView
    {
       #region Presenter
        
        private readonly AccountsPresenter _accountsPresenter;	
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly ActivitysPresenter _activitiesPresenter;
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
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>
        public string InventoryItemIds
        {
            get
            {
                var selectInventoryItem = "";
                if (Selection.IsSelectedAll)
                    return selectInventoryItem;
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
                    selectInventoryItem +=  ',';
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
        /// Gets or sets the inventory item category identifier.
        /// </summary>
        /// <value>The inventory item category identifier.</value>
        public string InventoryItemCategoryId
        {
            get
            {
                if (cboInventoryType.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboInventoryType.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboInventoryType.EditValue.ToString();
            }
            set { }
        }

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>
        /// The activity identifier.
        /// </value>
        public string ActivityId
        {
            get
            {
                if (cboActivity.EditValue.ToString() == "00000000-0000-0000-0000-000000000000" ||
                    cboActivity.EditValue.ToString() == "10000000-0000-0000-0000-000000000000")
                {
                    return null;
                }
                return cboActivity.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary activity.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary activity; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryActivity
        {
            get
            {
                if (cboActivity.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary inventory.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary inventory; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryInventory
        {
            get
            {
                if (cboInventoryType.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        #endregion

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
                cboActivity.Properties.DataSource = result;
                cboActivity.Properties.ForceInitialize();
                cboActivity.Properties.PopulateColumns();
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


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboActivity.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboActivity.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboActivity.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboActivity.Properties.DisplayMember = "AccountNumber";
                cboActivity.Properties.ValueMember = "AccountNumber";
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
                    new InventoryItemCategoryModel {InventoryItemCategoryId = "00000000-0000-0000-0000-000000000000", InventoryItemCategoryCode = "<<Tổng hợp>>", InventoryItemCategoryName = "<<Tổng hợp>>"},
                    new InventoryItemCategoryModel {InventoryItemCategoryId = "10000000-0000-0000-0000-000000000000", InventoryItemCategoryCode = "<<Tất cả>>", InventoryItemCategoryName = "<<Tất cả>>"}
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
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryName",
                    ColumnCaption = "Tên loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 300,

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
                cboInventoryType.Properties.ValueMember = "InventoryItemCategoryId";
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
                if (InventoryItemCategoryId != null && InventoryItemCategoryId != "00000000-0000-0000-0000-000000000000" && InventoryItemCategoryId != "10000000-0000-0000-0000-000000000000")
                {
                    bindingSource.DataSource = value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList();
                    gridInventoryView.PopulateColumns(value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList());
                }
                else
                {
                    bindingSource.DataSource = value;
                    gridInventoryView.PopulateColumns(value);
                }

                //bindingSource.DataSource = value;
                //gridInventoryView.PopulateColumns(value);

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

        public IList<ActivityModel> Activitys {
            set
            {
                var result = new List<ActivityModel>
                {
                    new ActivityModel {ActivityId = "00000000-0000-0000-0000-000000000000", ActivityCode = "<<Tổng hợp>>", ActivityName = "<<Tổng hợp>>"},
                    new ActivityModel {ActivityId = "10000000-0000-0000-0000-000000000000", ActivityCode = "<<Tất cả>>", ActivityName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboActivity.Properties.DataSource = result;
                cboActivity.Properties.ForceInitialize();
                cboActivity.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityCode",
                    ColumnCaption = "Mã hoạt động",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityName",
                    ColumnCaption = "Tên hoạt động",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 300,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboActivity.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboActivity.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboActivity.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboActivity.Properties.DisplayMember = "ActivityName";
                cboActivity.Properties.ValueMember = "ActivityId";
            }
        }
        #endregion

        #region Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS51H"/> class.
        /// </summary>
        public FrmS51H()
        {
            InitializeComponent();
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _activitiesPresenter = new ActivitysPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmS51H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmS51H_Load(object sender, EventArgs e)
        {
            _inventoryItemCategoriesPresenter.Display(true);
            _activitiesPresenter.DisplayActive(true);
            cboActivity.EditValue = @"00000000-0000-0000-0000-000000000000";
            cboInventoryType.EditValue = @"00000000-0000-0000-0000-000000000000";
            _inventoryItemsPresenter.DisplayByIsActive(true);
            Selection = new GridCheckMarksSelection(gridInventoryView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            
            gridInventoryView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridInventoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboActivity.EditValue = @"10000000-0000-0000-0000-000000000000";
                cboInventoryType.EditValue = @"10000000-0000-0000-0000-000000000000";
            }
            else if (rndOption.SelectedIndex == 1)
            {
                cboActivity.EditValue = @"00000000-0000-0000-0000-000000000000";
                cboInventoryType.EditValue = @"00000000-0000-0000-0000-000000000000";
            }
            else
            {
                cboActivity.EditValue = "";
                cboInventoryType.EditValue = "";
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            //if (string.IsNullOrEmpty(InventoryItemIds))
            //{
            //    XtraMessageBox.Show("Bạn phải chọn ít nhất một vật tư để xem báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
           return true;
        }
        #endregion

        private void cboInventoryType_EditValueChanged(object sender, EventArgs e)
        {
            if (cboInventoryType.EditValue == null) return;

            if (cboInventoryType.EditValue.ToString() == @"10000000-0000-0000-0000-000000000000" || cboInventoryType.EditValue.ToString() == @"00000000-0000-0000-0000-000000000000")
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
            Selection.CheckMarkColumn.Width = 80;
            gridInventoryView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridInventoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
        }
    }
}
