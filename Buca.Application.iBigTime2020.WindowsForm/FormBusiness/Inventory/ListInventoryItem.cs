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
using System.Drawing;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// Class FrmInventoryItems.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsdestinationView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    public partial class ListInventoryItem : FrmXtraBaseParameter, IInventoryItemsdestinationView, IInventoryItemsView
    {
        #region Variables
        /// <summary>
        /// The inventory items identifier
        /// </summary>
        public string InventoryItemsId;
        /// <summary>
        /// The reference date
        /// </summary>
        public DateTime RefDate;
        /// <summary>
        /// The reference order
        /// </summary>
        public int RefOrder;
        /// <summary>
        /// The unit price decimal digit number
        /// </summary>
        public int UnitPriceDecimalDigitNumber;
        /// <summary>
        /// The reference no
        /// </summary>
        public string RefNo;
        /// <summary>
        /// The reference detail identifier
        /// </summary>
        public string RefDetailID;

        public decimal Quantity;

        #endregion

        #region Presenters
        /// <summary>
        /// The inventory itemdestinations presenter
        /// </summary>
        private readonly InventoryItemdestinationsPresenter _InventoryItemdestinationsPresenter;
        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditInventoryItemView;
        #endregion

        #region Event
        /// <summary>
        /// Initializes a new instance of the <see cref="ListInventoryItem"/> class.
        /// </summary>
        public ListInventoryItem()
        {
            InitializeComponent();
            _InventoryItemdestinationsPresenter = new InventoryItemdestinationsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);

        }

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>
        /// The inventory items.
        /// </value>
        public IList<InventoryItemdestinationModel> InventoryItemdestinations
        {
            set
            {
                try
                {
                    gridInventoryItem.DataSource = value;
                    var ColumnsCollection = new List<XtraColumn>();
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ExpiryDate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "LotNo", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "MainUnitPrice", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefNo",
                        ColumnCaption = "Số CT",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 150
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefDate",
                        ColumnCaption = "Ngày CT",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockCode",
                        ColumnCaption = "Mã kho",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 180
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnCaption = "Mã VT, HH",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 180,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 150
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnCaption = "Giá trị tồn",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 150
                    });
                    //gridViewInventoryItem = InitGridLayout(ColumnsCollection, gridViewInventoryItem);
                    gridViewInventoryItem.InitGridLayout(ColumnsCollection);
                    SetNumericFormatControl(gridViewInventoryItem, true);
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
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string RefNo_ = gridViewInventoryItem.GetFocusedRowCellValue("RefNo").ToString();
            RefNo = RefNo_;
            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the ListInventoryItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListInventoryItem_Load(object sender, EventArgs e)
        {
            _inventoryItemsPresenter.Display();
            _InventoryItemdestinationsPresenter.DisplaybyInventoryItemdestinations(InventoryItemsId, RefDate, RefOrder, UnitPriceDecimalDigitNumber);
        }

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>
        /// The inventory items.
        /// </value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    _gridLookUpEditInventoryItemView = new GridView();
                    _gridLookUpEditInventoryItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInventoryItem.View.BestFitColumns();

                    _gridLookUpEditInventoryItem.DataSource = value;
                    _gridLookUpEditInventoryItemView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã hàng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên hàng",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInventoryItem.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditInventoryItem.ValueMember = "InventoryItemId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Handles the DoubleClick event of the gridViewInventoryItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void gridViewInventoryItem_DoubleClick(object sender, EventArgs e)
        {
            string RefNo_ = gridViewInventoryItem.GetFocusedRowCellValue("RefNo").ToString();
            string RefDetailID_ = gridViewInventoryItem.GetFocusedRowCellValue("RefDetailId").ToString();
            decimal Quantity_ = Convert.ToDecimal(gridViewInventoryItem.GetFocusedRowCellValue("Quantity").ToString());
            RefDetailID = RefDetailID_;
            RefNo = RefNo_;
            Quantity = Quantity_;
            this.Close();
        }

        #endregion
    }
}
