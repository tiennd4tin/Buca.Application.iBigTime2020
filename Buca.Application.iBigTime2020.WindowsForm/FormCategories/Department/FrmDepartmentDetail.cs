/***********************************************************************
 * <copyright file="FrmDepartmentDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, September 29, 2017
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department
{
    /// <summary>
    /// FrmDepartmentDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseTreeDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    public partial class FrmDepartmentDetail : FrmXtraBaseTreeDetail, IDepartmentView, IDepartmentsView
    {
        /// <summary>
        ///     The department presenter
        /// </summary>
        private readonly DepartmentPresenter _departmentPresenter;

        /// <summary>
        ///     The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmDepartmentDetail" /> class.
        /// </summary>
        public FrmDepartmentDetail()
        {
            InitializeComponent();
            _departmentPresenter = new DepartmentPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);

        }

        #region IDepartmentsView

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
                cboParentId.Properties.DataSource = value.Where(x => x.DepartmentId != KeyValue && x.IsActive).ToList();
                cboParentId.Properties.PopulateColumns();
                cboParentId.Properties.BestFitMode = BestFitMode.None;
                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        //ColumnWith = 30
                    },
                    new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên phòng ban",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                       // ColumnWith = 270
                    },
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false}
                };
                foreach (var column in treeColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        cboParentId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboParentId.Properties.SortColumnIndex = column.ColumnPosition;
                        cboParentId.Properties.PopupWidth = 350;
                        cboParentId.Properties.Columns[3].Width = 70;
                        cboParentId.Properties.Columns[2].Width = 280;
                    }
                    else
                    {
                        cboParentId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                cboParentId.Properties.DisplayMember = "DepartmentName";
                cboParentId.Properties.ValueMember = KeyFieldName;
                cboParentId.Properties.NullText = string.Empty;
                cboParentId.Properties.ShowFooter = false;
            }
        }

        #endregion

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _departmentsPresenter.Display();
            if (KeyValue != null)
            {
                _departmentPresenter.Display(KeyValue);
            }
            else
            {
                if (CurrentNode != null)
                {
                    chkIsActive.Checked = true;
                    cboParentId.Text = ((DepartmentModel)CurrentNode).ParentId;
                    txtDepartmentCode.Text = ((DepartmentModel)CurrentNode).DepartmentCode;
                }
            }
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            cboParentId.Properties.Enabled = ActionMode != ActionModeEnum.Edit || !HasChildren;
        }

        /// <summary>
        ///     Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(DepartmentCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentCodeE"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtDepartmentCode.Focus();
                return false;
            }

            if (!_departmentPresenter.CodeIsExist(DepartmentId, DepartmentCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentCodeDuplicate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtDepartmentCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(DepartmentName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentNameE"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtDepartmentName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _departmentPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.DepartmentIDEmployeeDetailForm = result;
            return result;
        }

        /// <summary>
        ///     Handles the KeyDown event of the cboParentId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void cboParentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboParentId.SelectionLength == cboParentId.Text.Length &&
                (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                cboParentId.EditValue = null;
                e.Handled = true;
            }
        }

        #region IDepartmentView

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode
        {
            get { return txtDepartmentCode.Text.Trim(); }
            set { txtDepartmentCode.Text = value; }
        }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        public string DepartmentName
        {
            get { return txtDepartmentName.Text.Trim(); }
            set { txtDepartmentName.Text = value; }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        ///     Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        ///     The parent identifier.
        /// </value>
        public string ParentId
        {
            get
            {
                if (cboParentId.EditValue == null) return null;
                return cboParentId.GetColumnValue("DepartmentId").ToString(); // KeyFieldName change by DepartmentId 
            }
            set { cboParentId.EditValue = value; }
        }

        #endregion


        private void cboParentId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmDepartmentDetail frmDepartmentDetail = new FrmDepartmentDetail();
                frmDepartmentDetail.ShowDialog();
                if (frmDepartmentDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.DepartmentIDEmployeeDetailForm))
                    {
                        _departmentsPresenter.Display();
                        cboParentId.EditValue = GlobalVariable.DepartmentIDEmployeeDetailForm;
                    }
                }
            }
        }
    }
}