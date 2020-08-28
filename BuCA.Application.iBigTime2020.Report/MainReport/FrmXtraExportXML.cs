/***********************************************************************
 * <copyright file="FrmXtraReportList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Report;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.ExportXml;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;
using Buca.Application.iBigTime2020.Presenter.ExportXml;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using RSSHelper;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    /// <summary>
    /// FrmXtraReportList
    /// </summary>
    public partial class FrmXtraExportXML : XtraForm, IExportXmlViews, IExportXmlDetailViews, ICurrenciesView
    {
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        private readonly ExportXmlPresenter _exportXmlPresenter;
        private readonly ExportXmlDetailPresenter _exportXmlDetailPresenter;

        internal GridCheckMarksSelection Selection { get; private set; }
        internal GridCheckMarksSelection SelectionDetail { get; private set; }

        private readonly CurrenciesPresenter _currenciesPresenter;

        private ReportSharpHelper _rsTool;

        public List<ExportXmlModel> LstXmlSelected = new List<ExportXmlModel>();

        public List<ExportXmlDetailModel> lstXmlDetailSelected()
        {
            var lstResult = new List<ExportXmlDetailModel>();

            if (SelectionDetail.SelectedCount > 0)
            {
                lstResult.Clear();
                for (int i = 0; i < grdXmlDetailView.RowCount; i++)
                {
                    if (SelectionDetail.IsRowSelected(i))
                    {
                        var row = (ExportXmlDetailModel)grdXmlDetailView.GetRow(i);
                        lstResult.Add(row);
                    }
                }
            }

            return lstResult;
        }

        private static IModel Model { get; set; }
        /// <summary>
        /// The _report list
        /// </summary>


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraReportList"/> class.
        /// </summary>
        public FrmXtraExportXML()
        {
            InitializeComponent();
            
            _currenciesPresenter = new CurrenciesPresenter(this);

            _exportXmlPresenter = new ExportXmlPresenter(this);

            dtReportPeriod.DateRangePeriodMode = DateRangeMode.Reduce;

            dtReportPeriod.InitSelectedIndex = 0;
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
            Model = new Model();
        }



        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            try
            {
                _currenciesPresenter.DisplayActive();
                //cboCurrencyCode.Properties.Items.Add(GlobalVariable.MainCurrencyId);
                cboCurrencyCode.EditValue = GlobalVariable.MainCurrencyId;//cboCurrencyCode.Properties.Items[0];
                //_reportListPresenter.GetReportsByIsActive(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ListExportXml()
        {

            var selectXmlItem = "";
            if (Selection.SelectedCount > 0)
            {
                LstXmlSelected.Clear();
                for (int i = 0; i < grdXmlGroupView.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (ExportXmlModel)grdXmlGroupView.GetRow(i);
                        selectXmlItem = selectXmlItem + row.RefType.Trim() + ",";
                        LstXmlSelected.Add(row);
                    }
                }
                LoadDataIntoGridDetail(selectXmlItem);
            }


        }

        public void LoadDataIntoGridDetail(string RefType)
        {
            var xmlDetailModels = Model.GetExportXmlDetail(RefType);
            bindingSourceDetail.DataSource = xmlDetailModels;
            grdXmlDetailView.PopulateColumns(xmlDetailModels);


            var columnsCollection = new List<XtraColumn>
            {   new XtraColumn {ColumnName = "RefType",ColumnVisible = false},
                new XtraColumn {ColumnName = "RefID",ColumnVisible = false},
                new XtraColumn {ColumnName = "RefDetailID",ColumnVisible = false},
                new XtraColumn {ColumnName = "RefNo",ColumnVisible = true,ColumnWith = 90,ColumnCaption = "Số CT",ColumnPosition = 1,AllowEdit = false,},
                new XtraColumn {ColumnName = "RefDate",ColumnVisible = true,ColumnWith =90,ColumnCaption = "Ngày CT",ColumnPosition = 2,AllowEdit = false,},
                new XtraColumn {ColumnName = "PostedDate",ColumnVisible = true,ColumnWith = 90,ColumnCaption = "Ngày HT",ColumnPosition = 3,AllowEdit = false,},
                new XtraColumn {ColumnName = "Description",ColumnVisible = true,ColumnWith = 185,ColumnCaption = "Diễn giải",ColumnPosition = 4,AllowEdit = true,},
                new XtraColumn {ColumnName = "Amount",ColumnVisible = true,ColumnWith = 100,ColumnCaption = "Số tiền",ColumnPosition = 5,IsSummnary = true,AllowEdit = true,ColumnType = UnboundColumnType.Decimal},

            };

            grdXmlDetailView = InitGridLayout(columnsCollection, grdXmlDetailView);
            SetNumericFormatControl(grdXmlDetailView, false);
            grdXmlDetailView.OptionsView.ShowFooter = true;
            SelectionDetail = new GridCheckMarksSelection(grdXmlDetailView);
            SelectionDetail.CheckMarkColumn.VisibleIndex = 0;
            SelectionDetail.CheckMarkColumn.Width = 50;
        }



        private void ViewReport(bool isPrint)
        {
            try
            {

                GlobalVariable.DateRangeSelectedIndex = dtReportPeriod.cboDateRange.SelectedIndex;
                GlobalVariable.FromDate = dtReportPeriod.FromDate;
                GlobalVariable.ToDate = dtReportPeriod.ToDate;
                GlobalVariable.AmountTypeViewReport = cboAmountType.SelectedIndex + 1;
                GlobalVariable.CurrencyViewReport = cboCurrencyCode.EditValue.ToString();
                dtReportPeriod.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Views the report.
        /// </summary>
        public void ViewReport(bool isPrint, string reportId)
        {
            try
            {
                GlobalVariable.DateRangeSelectedIndex = dtReportPeriod.cboDateRange.SelectedIndex;
                GlobalVariable.FromDate = dtReportPeriod.FromDate;
                GlobalVariable.ToDate = dtReportPeriod.ToDate;
                GlobalVariable.AmountTypeViewReport = cboAmountType.SelectedIndex + 1;
                GlobalVariable.CurrencyViewReport = cboCurrencyCode.EditValue.ToString();

                dtReportPeriod.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }



        #region IReportView Members

        #endregion

        #region ICurrenciesView Members
        public IList<CurrencyModel> Currencies
        {
            set
            {
                foreach (var item in value)
                {
                    cboCurrencyCode.Properties.Items.Add(item.CurrencyCode);
                }

            }
        }
        #endregion

        private void FrmXtraReportList_Load(object sender, EventArgs e)
        {
            LoadData();
            _exportXmlPresenter.GetExportXml();
            Selection = new GridCheckMarksSelection(grdXmlGroupView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 50;
            LoadDataIntoGridDetail("");
            XmlPathtxt.Text = GlobalVariable.PathXML;
        }

        private void gridReportDetailView_DoubleClick(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        #region IReportGroupView Members

        /// <summary>
        /// Sets the report groups.
        /// </summary>
        /// <value>
        /// The report groups.
        /// </value>
        public List<ReportGroupModel> ReportGroups
        {
            get { return new List<ReportGroupModel>(); }
            set { grdXmlGroup.DataSource = value; }
        }

        public IList<ExportXmlModel> ExportXml
        {
            set
            {
                try
                {
                    var lstXmlGroup = value.Where(x => x.IsVisible).ToList();
                    grdXmlGroup.ForceInitialize();
                    bindingSource.DataSource = lstXmlGroup;
                    grdXmlGroupView.PopulateColumns(lstXmlGroup);

                    var columnsCollection = new List<XtraColumn>
                    {new XtraColumn{

                        ColumnName = "Description",
                        ColumnCaption = "Tên mẫu chứng từ",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 550,


                        },
                        new XtraColumn {ColumnName = "ExportID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExportName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InputTypeName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FuntionName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DefaultParamater", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsVisible", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParamater", ColumnVisible = false},

                    };


                    grdXmlGroupView = InitGridLayout(columnsCollection, grdXmlGroupView);
                    grdXmlGroupView.Columns[0].OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public IList<ExportXmlDetailModel> ExportXmlDetail { set => throw new NotImplementedException(); }

        public IList<ExportXmlBCTCModel> ExportXmlBCTC { set => throw new NotImplementedException(); }
        public IList<ExportXmlBCTCBudgetSourceModel> ExportXmlBCTCBudgetSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        #endregion

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CallExportMethod();
        }

        private void cboAmountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboAmountType.SelectedIndex == 0)
            {
                cboCurrencyCode.EditValue = GlobalVariable.MainCurrencyId;
                cboCurrencyCode.Enabled = false;
            }
            else
            {
                cboCurrencyCode.Enabled = true;

            }

        }
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
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                        if (column.ColumnPosition == 1)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Count;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Số dòng = {0:n0}";
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            }
            return grdView;
        }


        private void gridXmlGroupView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ListExportXml();
        }



        private void grdXmlGroup_Click(object sender, EventArgs e)
        {
            ListExportXml();
        }
        public void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode)
                return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;
                        break;

                    case UnboundColumnType.DateTime:
                        break;
                }
            }
        }

        public bool CallExportMethod()


        {
            var lstXmlDetail = lstXmlDetailSelected();
            foreach (var xmlExport in LstXmlSelected)
            {
                var type = Assembly.GetExecutingAssembly()
                    .GetType("BuCA.Application.iBigTime2020.Report.ReportClass" + "." + xmlExport.InputTypeName);
                var target = (BaseReport)Activator.CreateInstance(type);
                //check có tồn tại hàm không 
                MethodInfo myMethod = type.GetMethod(xmlExport.FuntionName);
                if (myMethod == null) continue;

                var lstDetail = from p in lstXmlDetail
                                where xmlExport.RefType.Contains(p.RefType.ToString())
                    select p;
                foreach (var xmlDetail in lstDetail.ToList())
                {


                    var reportParamater = new ReportParameter {RefType = xmlDetail.RefType, RefId = xmlDetail.RefID};
                   
                    if (!string.IsNullOrEmpty(xmlExport.FuntionName))
                    {

                        var args = new object[] {reportParamater, _rsTool, null, xmlExport.IsParamater};
                        var result = (IList) (type.InvokeMember(xmlExport.FuntionName, BindingFlags.InvokeMethod,
                            null, target, args));
                    }
                }
            }

            return true;

        }
        private void SelectPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = fbd.ShowDialog();
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = fbd.SelectedPath;
                    XmlPathtxt.Text = GlobalVariable.PathXML;
                }
            }
        }
    }
}