using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;

namespace Buca.Application.iBigTime2020.WindowsForm
{
    /// <summary>
    /// Chuyển khoản kho bạc mua vật tư hàng hóa: RefType: 57
    /// </summary>
    public partial class FrmBUTransferPurchases : FrmBaseVoucherList, IBUTransfersView, IInventoryItemsView, IStocksView
    {
        #region Presenter
        private readonly BUTransfersPresenter _bUTransfersPresenter;

        readonly InventoryItemsPresenter _nventoryItemsPresenter;
        readonly StocksPresenter _stocksPresenter;

        private readonly IModel _model;
        #endregion

        public FrmBUTransferPurchases()
        {
            InitializeComponent();
            _stocksPresenter = new StocksPresenter(this);
            _nventoryItemsPresenter = new InventoryItemsPresenter(this);
            _bUTransfersPresenter = new BUTransfersPresenter(this);

            _model = new Model.Model();
        }

        #region RepositoryItemLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;
        #endregion

        #region override
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            _nventoryItemsPresenter.DisplayByIsToolAndIsStock(true);
            _stocksPresenter.DisplayByIsActive(true);
            bindingSource.AllowNew = true;

            _bUTransfersPresenter.Display((int)RefType.BUTransferPurchase);
        }

        private void InitRepositoryControlData()
        {

        }

        protected override void DeleteGrid()
        {
            new BUTransferPresenter(null).Delete(PrimaryKeyValue);
        }

        protected override void LoadDataIntoGridDetail(string refId)
        {
            var buTransfer = _model.GetBUTransferVoucher(refId, true);
            if (buTransfer == null)
                return;

            bindingSourceDetail.DataSource = buTransfer.BUTransferDetailPurchases.OrderBy(c => c.SortOrder).ToList();
            gridViewDetail.PopulateColumns(buTransfer.BUTransferDetailPurchases);

            ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Mã VT,HH", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditInventoryItem });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "Kho", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditStock });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "TK nợ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 4, AllowEdit = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "TK có", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 5, AllowEdit = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnCaption = "ĐVT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 6, AllowEdit = true, });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 7, AllowEdit = true, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnCaption = "Đơn giá", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 8, AllowEdit = true, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Thành tiền", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 9, AllowEdit = true, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxAmount", ColumnCaption = "Giá trị nhập kho", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 10, AllowEdit = true, IsNumeric = true });

            XtraColumnCollectionHelper<BUTransferDetailPurchaselModel>.ShowXtraColumnInGridView(ColumnsCollection, gridViewDetail);
        }
        #endregion

        #region IView Extens
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (value == null)
                    return;
                //_listIventoryItem = value.ToList();

                _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, "InventoryItemCode", "InventoryItemId");
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
            }
        }

        public IList<StockModel> Stocks
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditStockView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
                _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, "StockName", "StockId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
            }
        }

        public IList<BUTransferModel> BUTransfers
        {
            set
            {
                if (value == null)
                    value = new List<BUTransferModel>();

                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 2, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 3, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 4 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 5, IsNumeric = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnCaption = "Loại chứng từ", ColumnVisible = true, ColumnWith = 300, ColumnPosition = 6, RepositoryControl = GridLookUpEditRefType, });

                XtraColumnCollectionHelper<BUTransferModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
            }
        }

        /// <summary>
        /// Override lại 2 hàm này để định dạng số tiền
        /// </summary>
        /// <param name="grdView"></param>
        /// <param name="isSummary"></param>
        protected override void SetNumericFormatControl(GridView grdView, bool isSummary)
        {

        }

        protected override void LoadGridLayout()
        {

        }
        #endregion
    }
}
