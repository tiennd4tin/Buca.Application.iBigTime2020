using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department
{
    /// <summary>
    ///     FrmDepartments
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseTreeList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    public partial class FrmDepartments : FrmBaseTreeList, IDepartmentsView
    {
        /// <summary>
        ///     The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmDepartments" /> class.
        /// </summary>
        public FrmDepartments()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        /// <summary>
        ///     Sets the departments.
        /// </summary>
        /// <value>
        ///     The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã phòng/ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên phòng ban",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnPosition = 3,
                    ColumnWith = 400,
                    AllowEdit = false,
                    ColumnCaption = @"Diễn giải"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnVisible = true,
                    ColumnPosition = 4,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Grade",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsParent",
                    ColumnVisible = false,
                    AllowEdit = false
                });
            }
        }

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            //PermissionUser(GlobalVariable.UserId);
            _departmentsPresenter.Display();
        }

        /// <summary>
        ///     Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new DepartmentPresenter(null).Delete(PrimaryKeyValue);
        }

        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteDepartmentHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmDepartmentDetail();
        }
    }
}