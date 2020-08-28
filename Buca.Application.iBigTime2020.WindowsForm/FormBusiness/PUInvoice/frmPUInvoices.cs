using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.View.PUInvoice;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.PUInvoice;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.WindowsForm.Code;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice
{
    /// <summary>
    /// Mua TSCĐ chưa thanh toán : RefType: 251
    /// </summary>
    public partial class frmPUInvoices : FrmBaseVoucherList, IPUInvoicesView, IFixedAssetsView, IDepartmentsView, IBanksView
    {
        #region RepositoryItemGridLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;
        #endregion

        #region Presenter
        FixedAssetsPresenter _fixedAssetsPresenter;
        DepartmentsPresenter _departmentsPresenter;
        BanksPresenter _banksPresenter;
        PUInvoicesPresenter _pUInvoicesPresenter;

        IModel _model;
        #endregion

        public frmPUInvoices()
        {
            InitializeComponent();

            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _pUInvoicesPresenter = new PUInvoicesPresenter(this);

            this.RefTypeId = BuCA.Enum.RefType.PUInvoiceFixedAsset;
            this.FormDetail = nameof(FrmPUInvoiceDetailFixedAsset);
            this.FormCaption = CommonText.CaptionPUInvoices;
            this.TablePrimaryKey = nameof(PUInvoiceModel.RefId);
            this.NamespaceForm = this.GetType().Namespace;

            _model = new Model.Model();
        }

        #region Iviews
        IList<PUInvoiceModel> IPUInvoicesView.PUInvoices
        {
            set
            {
                if (value == null)
                    value = new List<PUInvoiceModel>();

                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.PostedDate), ColumnCaption = "Ngày HT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, IsDateTime = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.RefNo), ColumnCaption = "Số CT", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 2, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.RefDate), ColumnCaption = "Ngày CT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 3, IsDateTime = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.JournalMemo), ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 4 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.TotalAmount), ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 5, IsNumeric = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceModel.RefType), ColumnCaption = "Loại chứng từ", ColumnVisible = true, ColumnWith = 300, ColumnPosition = 6, RepositoryControl = GridLookUpEditRefType, });

                XtraColumnCollectionHelper<PUInvoiceModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
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

        #region Iview Detail
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                if (value == null)
                    value = new List<FixedAssetModel>();

                _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, nameof(FixedAssetModel.FixedAssetCode), nameof(FixedAssetModel.FixedAssetId));
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetCode), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetName), ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null)
                    value = new List<DepartmentModel>();

                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, nameof(DepartmentModel.DepartmentName), nameof(DepartmentModel.DepartmentId));

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentCode), ColumnCaption = "Mã phòng ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentName), ColumnCaption = "Tên phòng ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
            }
        }

        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, nameof(BankModel.BankAccount), nameof(BankModel.BankAccount));

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankAccount), ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankName), ColumnCaption = "Tên NH, KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }
        #endregion

        #region override
        protected override void LoadDataIntoGrid()
        {
            _fixedAssetsPresenter.DisplayByActive(true);
            _departmentsPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);

            bindingSource.AllowNew = true;

            _pUInvoicesPresenter.Display((int)this.RefTypeId);
        }

        protected override void DeleteGrid()
        {
            new PUInvoicePresenter(null).Delete(PrimaryKeyValue, (int)this.RefTypeId);
        }

        protected override void LoadDataIntoGridDetail(string refId)
        {
            var pUInvoice = _model.GetPUInvoice(refId, true);
            if (pUInvoice == null)
                return;

            var source = pUInvoice.PUInvoiceDetailFixedAssets ?? new List<PUInvoiceDetailFixedAssetModel>();
            bindingSourceDetail.DataSource = source.OrderBy(c => c.SortOrder).ToList(); ;
            gridViewDetail.PopulateColumns(source);

            var columnsCollection = new List<XtraColumn>();
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.FixedAssetId), ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Mã tài sản", ColumnPosition = 1, RepositoryControl = _gridLookUpEditFixedAsset });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.Description), ColumnVisible = true, ColumnWith = 320, ColumnCaption = "Diễn giải", ColumnPosition = 2, });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.DepartmentId), ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Phòng ban", ColumnPosition = 3, RepositoryControl = _gridLookUpEditDepartment });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.DebitAccount), ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Nợ", ColumnPosition = 4 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.CreditAccount), ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Có", ColumnPosition = 5 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.Amount), ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Số tiền", ColumnPosition = 6, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PUInvoiceDetailFixedAssetModel.BankAccount), ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Tài khoản NH, KB", ColumnPosition = 5, RepositoryControl = _gridLookUpEditBank });

            XtraColumnCollectionHelper<PUInvoiceDetailFixedAssetModel>.ShowXtraColumnInGridView(ColumnsCollection, gridViewDetail);
        }
        #endregion
    }
}
