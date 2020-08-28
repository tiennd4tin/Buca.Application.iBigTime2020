/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.InvoiceFormNumber
{
    public partial class FrmInvoiceFormNumberDetail : FrmXtraBaseCategoryDetail, IInvoiceFormNumberView, IInvoiceTypiesView
    {
        private readonly InvoiceFormNumberPresenter _invoiceFormNumberPresenter;
        private readonly InvoiceTypiesPresenter _invoiceTypiesPresenter;

        public FrmInvoiceFormNumberDetail()
        {
            InitializeComponent();
            _invoiceFormNumberPresenter = new InvoiceFormNumberPresenter(this);
            _invoiceTypiesPresenter = new InvoiceTypiesPresenter(this);
        }

        public string InvoiceFormNumberId { get; set; }

        public string InvoiceFormNumberCode
        {
            get { return txtInvoiceFormNumberCode.Text.Trim(); }
            set { txtInvoiceFormNumberCode.Text = value; }
        }

        public string InvoiceFormNumberName
        {
            get { return txtInvoiceFormNumberName.Text.Trim(); }
            set { txtInvoiceFormNumberName.Text = value; }
        }

        public int InvoiceType
        {
            get { return grdInvoiceFormNumberCategoryID.EditValue == null ? 0 : (int)grdInvoiceFormNumberCategoryID.GetColumnValue("InvoiceTypeId"); }
            set { grdInvoiceFormNumberCategoryID.EditValue = value; }
        }

        public bool IsSystem { get; set; }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        public IList<InvoiceTypeModel> InvoiceTypies
        {
            set
            {
                grdInvoiceFormNumberCategoryID.Properties.DataSource = value;
                grdInvoiceFormNumberCategoryID.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "InvoiceTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "InvoiceTypeCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "InvoiceTypeName", ColumnCaption = "Loại hóa đơn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 400  },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdInvoiceFormNumberCategoryID.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdInvoiceFormNumberCategoryID.Properties.SortColumnIndex = column.ColumnPosition;
                        grdInvoiceFormNumberCategoryID.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdInvoiceFormNumberCategoryID.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdInvoiceFormNumberCategoryID.Properties.DisplayMember = "InvoiceTypeName";
                grdInvoiceFormNumberCategoryID.Properties.ValueMember = "InvoiceTypeId";
            }
        }

        #region Form Event

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _invoiceTypiesPresenter.Display();
            if (KeyValue != null)
                _invoiceFormNumberPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtInvoiceFormNumberCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _invoiceFormNumberPresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(InvoiceFormNumberCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyInvoiceFormNumberCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceFormNumberCode.Focus();
                return false;
            }
            if (grdInvoiceFormNumberCategoryID.EditValue == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyInvoiceFormNumberCategory"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdInvoiceFormNumberCategoryID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(InvoiceFormNumberName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyInvoiceFormNumberName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceFormNumberName.Focus();
                return false;
            }
            return true;
        }
        #endregion
    }
}
