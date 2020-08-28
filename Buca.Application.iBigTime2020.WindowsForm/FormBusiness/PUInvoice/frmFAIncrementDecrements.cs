using System.Collections.Generic;
using System.Linq;
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
using Buca.Application.iBigTime2020.View.IncrementDecrement;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice
{
    /// <summary>
    /// Tăng TSCĐ nhận bằng hiện vật : RefType: 252
    /// </summary>
    public partial class frmFAIncrementDecrements : FrmBaseVoucherList, IFAIncrementDecrementsView, IFixedAssetsView, IDepartmentsView, IBanksView
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
        FAIncrementDecrementsPresenter _fAIncrementDecrementsPresenter;

        IModel _model;
        #endregion

        public frmFAIncrementDecrements()
        {
            InitializeComponent();

            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _fAIncrementDecrementsPresenter = new FAIncrementDecrementsPresenter(this);

            this.RefTypeId = BuCA.Enum.RefType.FAIncrementDecrement;
            this.FormDetail = nameof(frmFAIncrementDecrementDetail);
            this.FormCaption = CommonText.CaptionFAIncrementDecrement;
            this.TablePrimaryKey = nameof(FAIncrementDecrementModel.RefId);
            this.NamespaceForm = this.GetType().Namespace;

            _model = new Model.Model();
        }

        #region Iviews
        IList<FAIncrementDecrementModel> IFAIncrementDecrementsView.FAIncrementDecrements
        {
            set
            {
                if (value == null)
                    value = new List<FAIncrementDecrementModel>();

                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.PostedDate), ColumnCaption = "Ngày HT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, IsDateTime = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.RefNo), ColumnCaption = "Số CT", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 2, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.RefDate), ColumnCaption = "Ngày CT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 3, IsDateTime = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.JournalMemo), ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 4 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.TotalAmount), ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 5, IsNumeric = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementModel.RefType), ColumnCaption = "Loại chứng từ", ColumnVisible = true, ColumnWith = 300, ColumnPosition = 6, RepositoryControl = GridLookUpEditRefType, });

                XtraColumnCollectionHelper<FAIncrementDecrementModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
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
        IList<FixedAssetModel> IFixedAssetsView.FixedAssets
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

        IList<DepartmentModel> IDepartmentsView.Departments
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

        IList<BankModel> IBanksView.Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, nameof(BankModel.BankAccount), nameof(BankModel.BankId));

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

            _fAIncrementDecrementsPresenter.Display((int)this.RefTypeId);
        }

        protected override void DeleteGrid()
        {
            new FAIncrementDecrementPresenter(null).Delete(PrimaryKeyValue);
        }

        protected override void LoadDataIntoGridDetail(string refId)
        {
            var pUInvoice = _model.GetFAIncrementDecrement(refId, true);
            if (pUInvoice == null)
                return;

            var source = pUInvoice.FAIncrementDecrementDetails ?? new List<FAIncrementDecrementDetailModel>();
            bindingSourceDetail.DataSource = source.OrderBy(c => c.SortOrder).ToList(); ;
            gridViewDetail.PopulateColumns(source);

            var columnsCollection = new List<XtraColumn>();
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.FixedAssetId), ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Mã tài sản", ColumnPosition = 1, RepositoryControl = _gridLookUpEditFixedAsset });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Description), ColumnVisible = true, ColumnWith = 320, ColumnCaption = "Diễn giải", ColumnPosition = 2, });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.DepartmentId), ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Phòng ban", ColumnPosition = 3, RepositoryControl = _gridLookUpEditDepartment });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.DebitAccount), ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Nợ", ColumnPosition = 4 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.CreditAccount), ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Có", ColumnPosition = 5 });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Amount), ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Số tiền", ColumnPosition = 6, IsNumeric = true });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BankId), ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Tài khoản NH, KB", ColumnPosition = 5, RepositoryControl = _gridLookUpEditBank });

            XtraColumnCollectionHelper<FAIncrementDecrementDetailModel>.ShowXtraColumnInGridView(ColumnsCollection, gridViewDetail);
        }
        #endregion
    }
}
