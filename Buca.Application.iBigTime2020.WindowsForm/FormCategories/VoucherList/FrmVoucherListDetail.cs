/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.VoucherList;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.VoucherList
{
    /// <summary>
    /// FrmVoucherListDetail
    /// </summary>
    public partial class FrmVoucherListDetail : FrmXtraBaseCategoryDetail, IVoucherListView
    {
        private readonly VoucherListPresenter _voucherListPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmVoucherListDetail"/> class.
        /// </summary>
        public FrmVoucherListDetail()
        {
            InitializeComponent();
            _voucherListPresenter = new VoucherListPresenter(this);
        }

        #region IVoucherListView
        /// <summary>
        /// Gets or sets the voucher list identifier.
        /// </summary>
        /// <value>
        /// The voucher list identifier.
        /// </value>
        public string VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher list code.
        /// </summary>
        /// <value>
        /// The voucher list code.
        /// </value>
        public string VoucherListCode
        {
            get { return txtVoucherListCode.Text.Trim(); }
            set { txtVoucherListCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the voucher list.
        /// </summary>
        /// <value>
        /// The name of the voucher list.
        /// </value>
        public string VoucherListName
        {
            get { return txtVoucherListName.Text.Trim(); }
            set { txtVoucherListName.Text = value; }
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime? FromDate
        {
            get { return dtFromDate.EditValue == null || dtFromDate.Text == "" ? (DateTime?)null : (DateTime)dtFromDate.EditValue; }
            set
            {
                dtFromDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime? ToDate
        {
            get { return dtToDate.EditValue == null || dtToDate.Text == "" ? (DateTime?)null : (DateTime)dtToDate.EditValue; }
            set
            {
                dtToDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document attached.
        /// </summary>
        /// <value>
        /// The document attached.
        /// </value>
        public string DocumentAttached
        {
            get { return txtDocumentAttached.Text.Trim(); }
            set { txtDocumentAttached.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        #endregion

        #region Form Event

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _voucherListPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtVoucherListCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _voucherListPresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(VoucherListCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyVoucherListCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVoucherListCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(VoucherListName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyVoucherListName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVoucherListName.Focus();
                return false;
            }
            if (ToDate < FromDate)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResNotValidToDate"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtToDate.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region control events
        /// <summary>
        /// Handles the EditValueChanged event of the dtFromDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            //if (dtFromDate.Text == @"")
            //{
            //    dtFromDate.EditValue = null;
            //}
        }

        /// <summary>
        /// Handles the EditValueChanged event of the dtToDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dtToDate_EditValueChanged(object sender, EventArgs e)
        {
            //if (dtToDate.Text == @"")
            //{
            //    dtToDate.EditValue = null;
            //}
        }
        #endregion
    }
}
