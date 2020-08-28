using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.View.OpeningSupplyEntry;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    /// <summary>
    /// Số sư đầu kì CCDC không qua kho
    /// </summary>
    public partial class FrmOpeningSupplyEntries : FrmBaseVoucherList, IOpeningSupplyEntriesView, IDepartmentsView
    {
        #region Presenter
        private readonly OpeningSupplyEntriesPresenter _openingSupplyEntriesPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        #endregion

        #region ReponsitoryControl
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;
        #endregion

        public FrmOpeningSupplyEntries()
        {
            InitializeComponent();
            _openingSupplyEntriesPresenter = new OpeningSupplyEntriesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        #region Hiển thị danh sách lên grid
        public IList<OpeningSupplyEntryModel> OpeningSupplyEntries
        {
            get
            {
                return new List<OpeningSupplyEntryModel>();
            }
            set
            {
                if (value == null)
                    return;

                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Mã CCDC", ColumnPosition = 1, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Tên CCDC", ColumnPosition = 2, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Phòng ban", ColumnPosition = 3, RepositoryControl = _gridLookUpEditDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = true, ColumnWith = 80, ColumnCaption = "Số lượng tồn", ColumnPosition = 3, ColumnType = UnboundColumnType.Decimal, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOC", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Đơn giá tồn", ColumnPosition = 4, ColumnType = UnboundColumnType.Decimal, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Giá trị tồn", ColumnPosition = 5, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });
                XtraColumnCollectionHelper<OpeningSupplyEntryModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
            }
        }
        #endregion

        #region InitLayout từ form base
        protected override void LoadDataIntoGrid()
        {
            _departmentsPresenter.DisplayActive();
            _openingSupplyEntriesPresenter.Display();
            bindingSource.AllowNew = true;
        }

        protected override void InitControls()
        {
            splitContainerControl.PanelVisibility = SplitPanelVisibility.Panel1;
        }
        #endregion

        #region Show form detail
        public override void AddData()
        {
            ShowFormDetail(BuCA.Enum.ActionModeVoucherEnum.AddNew);
        }

        protected override void EditData()
        {
            ShowFormDetail(BuCA.Enum.ActionModeVoucherEnum.Edit);
        }

        protected override void ShowData()
        {
            ShowFormDetail(BuCA.Enum.ActionModeVoucherEnum.Edit);
        }

        void ShowFormDetail(BuCA.Enum.ActionModeVoucherEnum actionMode)
        {
            try
            {
                var frmDetail = new FrmOpeningSupplyEntryDetail();
                frmDetail.ActionMode = actionMode;
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    _openingSupplyEntriesPresenter.Display();
                    //SetNumericFormatControl(gridView, true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Danh sách phòng ban
        public IList<DepartmentModel> Departments
        {
            set
            {
                try
                {
                    if (value == null)
                        return;

                    _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, "DepartmentName", "DepartmentId");
                    XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(new List<XtraColumn>(), _gridLookUpEditDepartmentView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Xóa trên grid
        protected override void DeleteGrid()
        {
            new OpeningSupplyEntriesPresenter(null).Delete(PrimaryKeyValue);
        }
        #endregion
    }
}
