/***********************************************************************
 * <copyright file="FrmEmployeeTypeDetail.cs" company="BUCA JSC">
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
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.EmployeeType
{
    /// <summary>
    ///     FrmEmployeeTypeDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseCategoryDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IEmployeeTypeView" />
    public partial class FrmEmployeeTypeDetail : FrmXtraBaseCategoryDetail, IEmployeeTypeView
    {
        /// <summary>
        ///     The employee type presenter
        /// </summary>
        private readonly EmployeeTypePresenter _employeeTypePresenter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmEmployeeTypeDetail" /> class.
        /// </summary>
        public FrmEmployeeTypeDetail()
        {
            InitializeComponent();
            _employeeTypePresenter = new EmployeeTypePresenter(this);
        }

        #region Event

        #endregion

        #region Overide

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            chkIsActive.Enabled = true;
            txtEmployeeTypeCode.Focus();
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _employeeTypePresenter.Display(KeyValue);
            }
            else
                chkIsActive.Checked = true;
        }

        /// <summary>
        ///     Valids the data.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(EmployeeTypeCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeTypeCodeRequired"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeTypeCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(EmployeeTypeCode) && _employeeTypePresenter.CodeIsExist(KeyValue, EmployeeTypeCode))
            {
                XtraMessageBox.Show(String.Format(ResourceHelper.GetResourceValueByName("ResEmployeeTypeCodeDuplicateE"), EmployeeTypeCode),
                    detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeTypeCode.Text = "";
                txtEmployeeTypeCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(EmployeeTypeName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeTypeNameRequired"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeTypeName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        protected override string SaveData()
        {
            return _employeeTypePresenter.Save();
        }

        #endregion

        #region Property

        /// <summary>
        ///     Gets or sets the employeeType identifier.
        /// </summary>
        /// <value>
        ///     The employeeType identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employeeType.
        /// </summary>
        /// <value>
        ///     The name of the employeeType.
        /// </value>
        public string EmployeeTypeName
        {
            get { return txtEmployeeTypeName.Text.Trim(); }
            set { txtEmployeeTypeName.Text = value; }
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
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public string EmployeeTypeCode
        {
            get { return txtEmployeeTypeCode.Text.Trim(); }
            set { txtEmployeeTypeCode.Text = value; }
        }

        #endregion
    }
}