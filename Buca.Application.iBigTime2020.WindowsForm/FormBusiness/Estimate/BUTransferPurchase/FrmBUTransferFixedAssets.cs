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

namespace Buca.Application.iBigTime2020.WindowsForm
{
    /// <summary>
    /// Chuyển khoản kho bạc mua TSCD: RefType: 58
    /// </summary>
    public partial class FrmBUTransferFixedAssets : FrmBaseVoucherList, IBUTransfersView, IBudgetSourcesView
    {
        public FrmBUTransferFixedAssets()
        {
            InitializeComponent();
            _bUTransfersPresenter = new BUTransfersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);

            _model = new Model.Model();

            this.RefTypeId = RefType.BUTransferFixedAsset;
            this.FormDetail = "FrmBUTransferDetailFixedAsset";
        }

        #region Presenter
        private readonly BUTransfersPresenter _bUTransfersPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        private readonly IModel _model;
        #endregion

        #region RepositoryItemLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;
        #endregion

        #region override
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();

            _budgetSourcesPresenter.DisplayActive();
            bindingSource.AllowNew = true;

            _bUTransfersPresenter.Display((int)this.RefTypeId);
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

            bindingSourceDetail.DataSource = buTransfer.BUTransferDetailFixedAssets.OrderBy(c => c.SortOrder).ToList();
            gridViewDetail.PopulateColumns(buTransfer.BUTransferDetailFixedAssets);

            var columnsCollection = new List<XtraColumn>();
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = true, ColumnWith = 320, ColumnCaption = "Diễn giải", ColumnPosition = 1, });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Nợ", ColumnPosition = 2 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Có", ColumnPosition = 3 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Số tiền", ColumnPosition = 4, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Nguồn", ColumnPosition = 5, RepositoryControl = _gridLookUpEditBudgetSource });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Chương", ColumnPosition = 6 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Khoản", ColumnPosition = 7 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Tiểu mục", ColumnPosition = 8 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Mục", ColumnPosition = 9 });

            XtraColumnCollectionHelper<BUTransferDetailFixedAssetlModel>.ShowXtraColumnInGridView(ColumnsCollection, gridViewDetail);
        }
        #endregion

        #region IView Extens
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
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
