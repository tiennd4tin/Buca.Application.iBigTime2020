/***********************************************************************
 * <copyright file="FrmC205ANS_Params.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, December 19, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmC205ANS_Params : FrmXtraBaseParameter
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        private static IModel Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC205ANS_Params"/> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public FrmC205ANS_Params(string refId, string procedure)
        {
            InitializeComponent();
            Model = new Model();
            LoadDataIntoGridDetail(refId, procedure);
        }

        /// <summary>
        /// Handles the CellValueChanged event of the gridDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void gridDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Tax")
                {
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

     

        /// <summary>
        /// Gets the tax payers.
        /// </summary>
        /// <value>
        /// The tax payers.
        /// </value>
        public string TaxPayers { get { return txtCkcHdk.Text; } }

        /// <summary>
        /// Gets the tax code.
        /// </summary>
        /// <value>
        /// The tax code.
        /// </value>
        public string TaxCode { get { return txtCodeCtmtDa.Text; } }


        /// <summary>
        /// Gets the format number declaration.
        /// </summary>
        /// <value>
        /// The format number declaration.
        /// </value>
        public string FormatNumberDeclaration { get { return txtCkcHdth.Text; } }

        /// <summary>
        /// Gets the format number isssua tax.
        /// </summary>
        /// <value>
        /// The format number isssua tax.
        /// </value>
        public string CtmtDa { get { return txtCtmtDa.Text; } }
        public DateTime? DecisionDate { get { return txtDecisionDate.DateTime; } }
        public string DecisionNo { get { return txtDecisionNo.Text; } }
        public string CkcHdk { get { return txtCkcHdk.Text; } }
        public string CodeCtmtDa { get { return txtCodeCtmtDa.Text; } }
        public string CkcHdth { get { return txtCkcHdth.Text; } }

        /// <summary>
        /// Gets the organization code.
        /// </summary>
        /// <value>
        /// The organization code.
        /// </value>


        /// <summary>
        /// Gets the C402 CKB models.
        /// </summary>
        /// <value>
        /// The C402 CKB models.
        /// </value>
        public IList<C402CKBModel> C402CkbModels
        {
            get;
        }

        /// <summary>
        /// Gets the C402 CKB models.
        /// </summary>
        /// <value>
        /// The C402 CKB models.
        /// </value>
        public IList<C402CKBModel> C402CkbModelDetails
        {
            get;
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        private void LoadDataIntoGridDetail(string refId, string procedure)
        {
            var storeProcedure = procedure;// "uspReport_BAV_Withdraw_TT08_C402";
            var reports = Model.ReportC402CKB(storeProcedure, refId);
            bindingSource.DataSource = reports;
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (grdView.Columns[column.ColumnName] != null)
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
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            }
            return grdView;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }

        private void FrmC205ANS_Params_Load(object sender, EventArgs e)
        {

        }

        private void lblAcount_Click(object sender, EventArgs e)
        {

        }
    }
}
