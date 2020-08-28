using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;   
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmB01KB_Param : XtraForm
    {
        private readonly BanksPresenter _banksPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BUTransferPresenter _bUTransferPresenter;
        private List<BUTransferDetailModel> GetListData = new List<BUTransferDetailModel>();
        public string KeyValue { get; set; }
        #region Variables
        public decimal TGTNN
        {
            get { return txtTGTNN.Text == "" ? 0 : decimal.Parse(txtTGTNN.Text); }
        }
        public decimal TGTTN
        {
            get { return txtTGTTN.Text == "" ? 0 : decimal.Parse(txtTGTTN.Text); }
        }
        public decimal TBHNN
        {
            get { return txtTBHNN.Text == "" ? 0 : decimal.Parse(txtTBHNN.Text); }
        }
        public decimal TBHTN
        {
            get { return txtTBHTN.Text == "" ? 0 : decimal.Parse(txtTBHTN.Text); }
        }
        private GridView InitColumn(List<XtraColumn> columnsCollections, GridView grdView)
        {
            for(var i=0;i < grdView.Columns.Count; i++)
            {
                var column = grdView.Columns[i];
                var columnsCollection = columnsCollections.FirstOrDefault(c => c.ColumnName == column.FieldName);

                if (columnsCollection != null)
                {
                    column.Visible = true;
                    column.Caption = columnsCollection.ColumnCaption;
                    column.VisibleIndex = columnsCollection.ColumnPosition;
                    column.Width = columnsCollection.ColumnWith;
                    column.UnboundType = columnsCollection.ColumnType;
                    column.Fixed = columnsCollection.FixedColumn;
                    column.OptionsColumn.AllowEdit = columnsCollection.AllowEdit;
                    column.ToolTip = columnsCollection.ToolTip;
                    column.ColumnEdit = columnsCollection.RepositoryControl;
                    column.OptionsColumn.AllowSort = DefaultBoolean.False;
                }
                else
                {
                    column.Visible = false;
                }
               
            }
            foreach (var column in grdView.Columns)
            {
                  
            }
            return grdView;
        }
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                    grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                    grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }
            return grdView;
        }
        public IList<BUTransferDetailParallelModel> BuTransferDetailParallel { get; set; }
        public IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }
        public IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets { get; set; }
        public string BUPlanWithdrawRefId { get; set; }

        #endregion

        public FrmB01KB_Param()
        {
            InitializeComponent();
        }
        public FrmB01KB_Param(string keyValue)
        {
            InitializeComponent();

        }
            #region Events

            private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Valid chỉ gõ number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void grdAccountingParallel_Click(object sender, EventArgs e)
        {

        }

        private void FormatNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            txtTBHNN.Text = txtTBHNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHNN.Text)) : "";
            txtTBHTN.Text = txtTBHTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHTN.Text)) : "";
            txtTGTNN.Text = txtTGTNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTNN.Text)) : "";
            txtTGTTN.Text = txtTGTTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTTN.Text)) : "";
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtTBHNN.Text = txtTBHNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHNN.Text)) : "";
                txtTBHTN.Text = txtTBHTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHTN.Text)) : "";
                txtTGTNN.Text = txtTGTNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTNN.Text)) : "";
                txtTGTTN.Text = txtTGTTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTTN.Text)) : "";
            }
            txtTBHNN.SelectionStart = txtTBHNN.Text.Length;
            txtTBHTN.SelectionStart = txtTBHTN.Text.Length;
            txtTGTNN.SelectionStart = txtTGTNN.Text.Length;
            txtTGTTN.SelectionStart = txtTGTTN.Text.Length;
        }

        private void txtTGTTN_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void FormatNumber_KeyDown(object sender, KeyEventArgs e)
        {
            txtTBHNN.Text = txtTBHNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHNN.Text)) : "";
            txtTBHTN.Text = txtTBHTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHTN.Text)) : "";
            txtTGTNN.Text = txtTGTNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTNN.Text)) : "";
            txtTGTTN.Text = txtTGTTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTTN.Text)) : "";

            txtTBHNN.SelectionStart = txtTBHNN.Text.Length;
            txtTBHTN.SelectionStart = txtTBHTN.Text.Length;
            txtTGTNN.SelectionStart = txtTGTNN.Text.Length;
            txtTGTTN.SelectionStart = txtTGTTN.Text.Length;
        }

        private void FormatNumber_KeyUp(object sender, KeyEventArgs e)
        {
            txtTBHNN.Text = txtTBHNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHNN.Text)) : "";
            txtTBHTN.Text = txtTBHTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTBHTN.Text)) : "";
            txtTGTNN.Text = txtTGTNN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTNN.Text)) : "";
            txtTGTTN.Text = txtTGTTN.Text != "" ? string.Format("{0:n0}", double.Parse(txtTGTTN.Text)) : "";

            txtTBHNN.SelectionStart = txtTBHNN.Text.Length;
            txtTBHTN.SelectionStart = txtTBHTN.Text.Length;
            txtTGTNN.SelectionStart = txtTGTNN.Text.Length;
            txtTGTTN.SelectionStart = txtTGTTN.Text.Length;
        }
    }
}
