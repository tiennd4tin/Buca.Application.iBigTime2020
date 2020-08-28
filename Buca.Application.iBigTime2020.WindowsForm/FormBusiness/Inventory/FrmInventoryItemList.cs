/***********************************************************************
 * <copyright file="FrmInventoryItems.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, May 25, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// Class FrmInventoryItems.
    /// </summary>
    public partial class FrmInventoryItemList : FrmXtraBaseParameter, IInventoryItemsView, IInventoryItemCategoriesView
    {
        #region Variables

        public string InventoryItemCodes;
        internal GridCheckMarksSelection Selection { get; set; }
        public bool StateCheck { get; set; } //Khi người dùng thao tác chọn trên Lưới IsActive = false, IsNotAcctive =false
        private string Condition = "";

        #endregion

        #region Presenters

        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItemCategory;
        private GridView _gridLookUpEditInventoryItemCategoryView;
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        private List<InventoryItemCategoryModel> InventoryItemCategoryModels;
        #endregion

        #region Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmInventoryItemList"/> class.
        /// </summary>
        public FrmInventoryItemList()
        {
            InitializeComponent();
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
        }
        private void FrmInventoryItemList_Load(object sender, EventArgs e)
        {
            _inventoryItemCategoriesPresenter.Display(true);
            _inventoryItemsPresenter.DisplayByIsActive(true);
            Selection = new GridCheckMarksSelection(gridViewInventoryItem);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            StateCheck = true;
            SetChecked();
            gridViewInventoryItem.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewInventoryItem.OptionsSelection.EnableAppearanceFocusedCell = false;
        }
        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                try
                {
                    InventoryItemCategoryModels = value.ToList();
                    _gridLookUpEditInventoryItemCategoryView = new GridView();
                    _gridLookUpEditInventoryItemCategoryView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItemCategory = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemCategoryView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditInventoryItemCategory.View.BestFitColumns();

                    _gridLookUpEditInventoryItemCategory.DataSource = value;
                    _gridLookUpEditInventoryItemCategoryView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {
                            ColumnName = "InventoryItemCategoryName", ColumnCaption = "Tên nhóm vật tư, CCDC",
                            ColumnPosition = 1,
                            ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInventoryItemCategory.DisplayMember = "InventoryItemCategoryName";
                    _gridLookUpEditInventoryItemCategory.ValueMember = "InventoryItemCategoryId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    var vatTu = InventoryItemCategoryModels.Where(o => o.InventoryItemCategoryCode =="VT").FirstOrDefault();
                    var data = value.Where(x => x.IsActive && x.InventoryCategoryId == vatTu.InventoryItemCategoryId).ToList();
                    gridInventoryItem.DataSource = data;
                    var ColumnsCollection = new List<XtraColumn>();
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
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
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã nguyên, vật liệu",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 150
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên nguyên, vật liệu",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 350
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryCategoryId",
                        ColumnCaption = "Loại vật tư, hàng hóa",
                        ColumnPosition = 3,
                        ColumnVisible = false,
                        ColumnWith = 200,
                        RepositoryControl = _gridLookUpEditInventoryItemCategory
                    });
                    gridViewInventoryItem = InitGridLayout(ColumnsCollection, gridViewInventoryItem);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            InventoryItemCodes = GetWhereInventoryItem();
        }

        /// <summary>
        /// Gets the where inventory item.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetWhereInventoryItem()
        {
            string whereClause = "";

            if (gridViewInventoryItem.DataSource != null && gridViewInventoryItem.RowCount > 0)
            {
                for (var i = 0; i < gridViewInventoryItem.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (InventoryItemModel)gridViewInventoryItem.GetRow(i);
                        whereClause = whereClause + row.InventoryItemId + ";";
                    }
                }
            }
            if (whereClause != "")
            {
                whereClause = whereClause.Substring(0, whereClause.Length - 1) + ";";
            }
            return whereClause;
        }

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        

        /// <summary>
        /// Handles the Load event of the FrmInventoryItemList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>


        /// <summary>
        /// Sets the checked.
        /// </summary>
        private void SetChecked()
        {
            if (gridViewInventoryItem.RowCount > 0)
            {
                for (int i = 0; i < gridViewInventoryItem.RowCount; i++)
                {
                    var inventoryItemCode = gridViewInventoryItem.GetRowCellValue(i, "InventoryItemCode");
                    Selection.SelectRow(i, (";" + Condition + ";").Contains(";" + inventoryItemCode + ";"));
                }
            }
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="gridView">The grid view.</param>
        /// <returns></returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView gridView)
        {
            foreach (var column in columnsCollection)
            {
                if (gridView.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        if (column.IsSummaryText)
                        {
                            gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        gridView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            return gridView;
        }

        #endregion
    }
}
