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
using System.Data;
using System.Diagnostics;
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
using System.Xml;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using DevExpress.XtraGrid;
using RSSHelper;
using System.Net;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    /// <summary>
    /// FrmXtraReportList
    /// </summary>
    public partial class FrmXtraExportBCTC : XtraForm, IExportXmlViews, IExportXmlDetailViews
    {
        #region Variable
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        private readonly ExportXmlPresenter _exportXmlPresenter;
        private readonly ExportXmlDetailPresenter _exportXmlDetailPresenter;

        internal GridCheckMarksSelection Selection { get; private set; }

        private int ProcessExport = 0;

        private ReportSharpHelper _rsTool;

        public List<ExportXmlBCTCModel> LstXmlSelected = new List<ExportXmlBCTCModel>();


        private static IModel Model { get; set; }
        private int Step = 0;

        public FrmXtraExportBCTC()
        {
            InitializeComponent();
            txtPath.Text = @"C:\";
            cbxReportTime.SelectedIndex = 0;
            cbxYear.SelectedIndex = 0;
            _exportXmlPresenter = new ExportXmlPresenter(this);
            Model = new Model();
        }
        public int ReportTime()
        {
            if (cbxReportTime.InvokeRequired)
                return (int)cbxReportTime.Invoke(new Func<int>(ReportTime));
            else
                return cbxReportTime.SelectedIndex;
        }
        public DateTime FromDate
        {
            get
            {
                var _time = DateTime.Now;
                _time = ReportTime().Equals(0) || ReportTime().Equals(4)
                    ? new DateTime(ReportYear(), 1, 1)
                    : ReportTime().Equals(1) ? new DateTime(ReportYear(), 4, 1)
                    : ReportTime().Equals(2) ? new DateTime(ReportYear(), 7, 1)
                    : new DateTime(ReportYear(), 10, 1);
                return _time;
            }
        }
        public DateTime ToDate
        {
            get
            {
                var _time = DateTime.Now;
                _time = ReportTime().Equals(0) || ReportTime().Equals(4)
                    ? new DateTime(ReportYear(), 12, 31)
                    : ReportTime().Equals(1) ? new DateTime(ReportYear(), 4, 31)
                        : ReportTime().Equals(2) ? new DateTime(ReportYear(), 7, 31)
                            : new DateTime(ReportYear(), 10, 31);
                return _time;
            }
        }

        public int ReportYear()
        {
            if (cbxYear.InvokeRequired)
                return (int)cbxYear.Invoke(new Func<int>(ReportYear));
            else
                return Convert.ToInt32(cbxYear.SelectedItem);
        }
        #endregion

        private void FrmXtraReportList_Load(object sender, EventArgs e)
        {
            _exportXmlPresenter.GetExportXmlBCTC();
            _exportXmlPresenter.GetExportXmlBCTCBudgetSource();
            Selection = new GridCheckMarksSelection(grdXmlGroupView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 50;
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

        public IList<ExportXmlModel> ExportXml { set => throw new NotImplementedException(); }
        public IList<ExportXmlDetailModel> ExportXmlDetail { set => throw new NotImplementedException(); }

        public IList<ExportXmlBCTCModel> ExportXmlBCTC
        {
            set
            {
                try
                {
                    var lstXmlGroup = value;
                    grdXmlGroup.ForceInitialize();
                    bindingSource.DataSource = lstXmlGroup;
                    grdXmlGroupView.PopulateColumns(lstXmlGroup);


                    var columnsCollection = new List<XtraColumn>
                    {new XtraColumn{

                            ColumnName = "ParentName",
                            ColumnCaption = "Nhóm báo cáo",
                            ColumnPosition = 3,
                            ColumnVisible = true,
                            ColumnWith = 250,


                        },new XtraColumn{

                            ColumnName = "ReportName",
                            ColumnCaption = "Tên báo cáo",
                            ColumnPosition = 3,
                            ColumnVisible = true,
                            ColumnWith = 500,


                        },
                        new XtraColumn {ColumnName = "ReportId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProcedureName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InputTypeName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FunctionName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ReportNameId", ColumnVisible = false},

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

        public IList<ExportXmlBCTCBudgetSourceModel> ExportXmlBCTCBudgetSource
        {
            get
            {
                var _list = new List<ExportXmlBCTCBudgetSourceModel>();
                var count = grdXmlBudgetSourceView.RowCount;
                for (int i = 0; i < count; i++)
                {
                    var _item = (ExportXmlBCTCBudgetSourceModel)grdXmlBudgetSourceView.GetRow(i);
                    if (_item != null)
                    {
                        var item = new ExportXmlBCTCBudgetSourceModel
                        {
                            BudgetSourceId = _item.BudgetSourceId,
                            BudgetSourceCode = _item.BudgetSourceCode,
                            BudgetSourceName = _item.BudgetSourceName,
                            BudgetSourceCodeOwner = _item.BudgetSourceCodeOwner,
                            BudgetSourceNameOwner = _item.BudgetSourceNameOwner
                        };
                        _list.Add(item);
                    }
                }
                return _list;
            }
            set
            {
                try
                {
                    bindingSourceDetail.DataSource = value;
                    grdXmlBudgetSourceView.PopulateColumns(value);


                    var columnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetSourceId",ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceCode",ColumnVisible = true,ColumnWith = 100,ColumnCaption = "Mã nguồn",ColumnPosition = 1,AllowEdit = false,},
                        new XtraColumn {ColumnName = "BudgetSourceName",ColumnVisible = true,ColumnWith =300,ColumnCaption = "Tên nguồn",ColumnPosition = 2,AllowEdit = false,},
                        new XtraColumn {ColumnName = "BudgetSourceCodeOwner",ColumnVisible = true,ColumnWith = 100,ColumnCaption = "Mã nguồn",ColumnPosition = 3,AllowEdit = true,},
                        new XtraColumn {ColumnName = "BudgetSourceNameOwner",ColumnVisible = true,ColumnWith =300,ColumnCaption = "Tên nguồn",ColumnPosition = 4,AllowEdit = true,},
                    };

                    grdXmlBudgetSourceView = InitGridLayout(columnsCollection, grdXmlBudgetSourceView);
                    SetNumericFormatControl(grdXmlBudgetSourceView, false);
                    grdXmlBudgetSourceView.OptionsView.ShowFooter = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
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

        #endregion

        #region Functions

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

        /// <summary>
        /// Valid dữ liệu trước khi xuất báo cáo
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                XtraMessageBox.Show("Hãy chọn nơi lưu tệp trước khi xuất khẩu dữ liệu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnExport.Enabled = true;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn mở thư mục xuất dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start(txtPath.Text);
            }
        }

        /// <summary>
        /// Thực hiện get và xuất dữ liệu ra xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int currentProcess = 0;
            Model model = new Model();
            model.Delete_BudgetSourceMappingToExport();
            var count = ExportXmlBCTCBudgetSource.Count;
            for (int i = 0; i < count; i++)
            {
                model.InsertBudgetSourceMappingToExport(ExportXmlBCTCBudgetSource[i]);
            }
            DataSet[] resultReports = new DataSet[count];
            count = LstXmlSelected.Count;
            //foreach (var xmlExport in LstXmlSelected)
            for (int i = 0; i < count; i++)
            {
                #region Chạy function get dữ liệu về dataset
                var type = Assembly.GetExecutingAssembly()
                                .GetType("BuCA.Application.iBigTime2020.Report.ReportClass" + "." + LstXmlSelected[i].InputTypeName);
                var target = (BaseReport)Activator.CreateInstance(type);
                //check có tồn tại hàm không 
                MethodInfo myMethod = type.GetMethod(LstXmlSelected[i].FunctionName);
                if (myMethod == null) continue;
                if (!string.IsNullOrEmpty(LstXmlSelected[i].FunctionName))
                {
                    var args = new object[] { Convert.ToDateTime(GlobalVariable.DBStartDate), FromDate, ToDate, LstXmlSelected[i].ProcedureName };
                    resultReports[i] = (DataSet)(type.InvokeMember(LstXmlSelected[i].FunctionName, BindingFlags.InvokeMethod,
                        null, target, args));
                }
                currentProcess++;
                var a = currentProcess * 100 / ProcessExport;
                backgroundWorker.ReportProgress(a);
                #endregion
            }

            #region Dữ liệu xml

            string reportName = GlobalVariable.CompanyName;
            string savepath = reportName + (ReportTime().Equals(4) ? "_Cả năm" : "_Quý " + (1 + ReportTime()).ToString()) + "_" + ReportYear() + @".xml";
            Cursor.Current = Cursors.WaitCursor;
            XmlTextWriter writer = new XmlTextWriter(txtPath.Text + @"/" + savepath, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(true);


            writer.WriteStartElement("DataSetExportToX12010");
            writer.WriteAttributeString("xmlns", GlobalVariable.CompanyName);

            #region Phần chèn master, chương
            for (int i = 0; i < count; i++)
            {
                foreach (DataRow dtRow in resultReports[i].Tables[0].Rows) //Lặp master của từng bảng báo cáo
                {
                    writer.WriteStartElement("ReportHeader"); //Start header
                                                              //RefID
                    writer.WriteStartElement("RefID");
                    writer.WriteString(dtRow.ItemArray[0].ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //ReportID
                    writer.WriteStartElement("ReportID");
                    writer.WriteString(LstXmlSelected[i].ReportNameId);
                    writer.WriteEndElement();
                    //-------------------------
                    //ReportPeriod
                    writer.WriteStartElement("ReportPeriod");
                    writer.WriteString(ReportTime().Equals(4) ? 0.ToString() : (101 + ReportTime()).ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //ReportYear
                    writer.WriteStartElement("ReportYear");
                    writer.WriteString(FromDate.Year.ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //CompanyID
                    writer.WriteStartElement("CompanyID");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    //-------------------------
                    //CompanyName
                    writer.WriteStartElement("CompanyName");
                    writer.WriteString(GlobalVariable.CompanyName);
                    writer.WriteEndElement();
                    //-------------------------
                    //ProductID
                    writer.WriteStartElement("ProductID");
                    writer.WriteString(GlobalVariable.ProducName);
                    writer.WriteEndElement();
                    //-------------------------
                    //AccountSystem
                    writer.WriteStartElement("AccountSystem");
                    writer.WriteString("QĐ 107/2017/TT-BTC");
                    writer.WriteEndElement();
                    //-------------------------
                    //BudgetChapterID
                    writer.WriteStartElement("BudgetChapterID");
                    writer.WriteString(dtRow[1].ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //ExportDate
                    writer.WriteStartElement("ExportDate");
                    writer.WriteString(DateTime.Now.ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //Version
                    writer.WriteStartElement("Version");
                    writer.WriteString(System.Windows.Forms.Application.ProductVersion);
                    writer.WriteEndElement();
                    //-------------------------
                    //ExportVersion
                    writer.WriteStartElement("ExportVersion");
                    writer.WriteString(DateTime.Now.Year.ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //ParticularID
                    writer.WriteStartElement("ParticularID");
                    writer.WriteString(0.ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    writer.WriteEndElement(); //End header
                }
            }
            #endregion

            #region Phần company
            //================================================
            writer.WriteStartElement("Company"); //Start Company

            //CompanyID
            writer.WriteStartElement("CompanyID");
            writer.WriteString(GlobalVariable.CompanyCode);
            writer.WriteEndElement();
            //-------------------------
            //CompanyName
            writer.WriteStartElement("CompanyName");
            writer.WriteString(GlobalVariable.CompanyName);
            writer.WriteEndElement();
            //-------------------------
            //CompanyAddress
            writer.WriteStartElement("CompanyAddress");
            writer.WriteString(GlobalVariable.CompanyAddress);
            writer.WriteEndElement();
            //-------------------------
            //EstimateGrade
            writer.WriteStartElement("EstimateGrade");
            writer.WriteString(3.ToString());
            writer.WriteEndElement();
            //-------------------------
            //Telephone
            writer.WriteStartElement("Telephone");
            writer.WriteString("");
            writer.WriteEndElement();
            //-------------------------
            //Fax
            writer.WriteStartElement("Fax");
            writer.WriteString(GlobalVariable.CompanyFax);
            writer.WriteEndElement();
            //-------------------------
            //InActive
            writer.WriteStartElement("InActive");
            writer.WriteString("false");
            writer.WriteEndElement();
            //-------------------------
            //ParticularID
            writer.WriteStartElement("ParticularID");
            writer.WriteString(0.ToString());
            writer.WriteEndElement();
            //-------------------------

            writer.WriteEndElement(); //End Company
                                      //================================================ 
            #endregion

            #region Phần details
            for (int i = 0; i < count; i++)
            {
                switch (LstXmlSelected[i].ReportNameId)
                {
                    #region B01/BCQT: Báo cáo quyết toán kinh phí hoạt động
                    case "B01BCQT":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("B01BCQTDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSourceID
                            writer.WriteStartElement("BudgetSourceID");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetKindItemID
                            writer.WriteStartElement("BudgetKindItemID");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSubKindItemID
                            writer.WriteStartElement("BudgetSubKindItemID");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemAlias
                            writer.WriteStartElement("ReportItemAlias");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemName
                            writer.WriteStartElement("ReportItemName");
                            writer.WriteString(dtRowDetail[5].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemIndex
                            writer.WriteStartElement("ReportItemIndex");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemCode
                            writer.WriteStartElement("ReportItemCode");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount
                            writer.WriteStartElement("Amount");
                            writer.WriteString(dtRowDetail[8].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
                    case "F0101BCQT":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("F0101BCQTDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSourceID
                            writer.WriteStartElement("BudgetSourceID");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ExpenseType
                            writer.WriteStartElement("ExpenseType");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetKindItemID
                            writer.WriteStartElement("BudgetKindItemID");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetKindItemName
                            writer.WriteStartElement("BudgetKindItemName");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSubKindItemID
                            writer.WriteStartElement("BudgetSubKindItemID");
                            writer.WriteString(dtRowDetail[5].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSubKindItemName
                            writer.WriteStartElement("BudgetSubKindItemName");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetItemID
                            writer.WriteStartElement("BudgetItemID");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetItemName
                            writer.WriteStartElement("BudgetItemName");
                            writer.WriteString(dtRowDetail[8].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSubItemID
                            writer.WriteStartElement("BudgetSubItemID");
                            writer.WriteString(dtRowDetail[9].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSubItemName
                            writer.WriteStartElement("BudgetSubItemName");
                            writer.WriteString(dtRowDetail[10].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //BudgetSourceAmount
                            writer.WriteStartElement("BudgetSourceAmount");
                            writer.WriteString(dtRowDetail[11].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //AidAmount
                            writer.WriteStartElement("AidAmount");
                            writer.WriteString(dtRowDetail[12].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //DebitAmount
                            writer.WriteStartElement("DebitAmount");
                            writer.WriteString(dtRowDetail[13].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //DeductAmount
                            writer.WriteStartElement("DeductAmount");
                            writer.WriteString(dtRowDetail[14].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //OtherAmount
                            writer.WriteStartElement("OtherAmount");
                            writer.WriteString(dtRowDetail[15].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region BCQT-03: Thuyết minh báo cáo quyết toán 
                    case "B03BCQT":
                        if (resultReports[i].Tables.Count >= 5)
                        {
                            #region Bảng 1
                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B03BCQTDetailGeneral"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Code
                                writer.WriteStartElement("Code");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Value
                                writer.WriteStartElement("Value");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DetailID
                                writer.WriteStartElement("DetailID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                writer.WriteEndElement(); //End Detail
                            }
                            #endregion

                            #region Bảng 2
                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B03BCQTDetailBudget"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Type
                                writer.WriteStartElement("Type");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount
                                writer.WriteStartElement("Amount");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //PersonNumber
                                writer.WriteStartElement("PersonNumber");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemContent
                                writer.WriteStartElement("ReportItemContent");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DetailID
                                writer.WriteStartElement("DetailID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //IsBold
                                writer.WriteStartElement("IsBold");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //IsItalic
                                writer.WriteStartElement("IsItalic");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndexRoot
                                writer.WriteStartElement("ReportItemIndexRoot");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                writer.WriteEndElement(); //End Detail
                            }
                            #endregion

                            #region Bảng 3
                            foreach (DataRow dtRowDetail in resultReports[i].Tables[3].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B03BCQTDetailReceipt"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //TotalReceiptAmount
                                writer.WriteStartElement("TotalReceiptAmount");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //PaymentAmount
                                writer.WriteStartElement("PaymentAmount");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DeductAmount
                                writer.WriteStartElement("DeductAmount");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Description
                                writer.WriteStartElement("Description");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetExpenseType
                                writer.WriteStartElement("BudgetExpenseType");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DetailID
                                writer.WriteStartElement("DetailID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //IsBold
                                writer.WriteStartElement("IsBold");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //IsItalic
                                writer.WriteStartElement("IsItalic");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //StateRow
                                writer.WriteStartElement("StateRow");
                                writer.WriteString(dtRowDetail[12].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndexRoot
                                writer.WriteStartElement("ReportItemIndexRoot");
                                writer.WriteString(dtRowDetail[13].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                writer.WriteEndElement(); //End Detail
                            }
                            #endregion

                            #region Bảng 4
                            foreach (DataRow dtRowDetail in resultReports[i].Tables[4].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B03BCQTDetailUseSource"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //TotalAmount
                                writer.WriteStartElement("TotalAmount");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSourceAmount
                                writer.WriteStartElement("BudgetSourceAmount");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DeductAmount
                                writer.WriteStartElement("DeductAmount");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ServiceAmount
                                writer.WriteStartElement("ServiceAmount");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OtherAmount
                                writer.WriteStartElement("OtherAmount");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DetailID
                                writer.WriteStartElement("DetailID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                writer.WriteEndElement(); //End Detail
                            }
                            #endregion
                        }
                        break;
                    #endregion

                    #region B01/BCTC: Báo cáo tình hình tài chính
                    case "B01BCTC":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("B01BCTCDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemCode
                            writer.WriteStartElement("ReportItemCode");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemName
                            writer.WriteStartElement("ReportItemName");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount
                            writer.WriteStartElement("Amount");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //PrevAmount
                            writer.WriteStartElement("PrevAmount");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemAlias
                            writer.WriteStartElement("ReportItemAlias");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemIndex
                            writer.WriteStartElement("ReportItemIndex");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region B02/BCTC: Báo cáo kết quả hoạt động
                    case "B02BCTC":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("B02BCTCDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemAlias
                            writer.WriteStartElement("ReportItemAlias");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemName
                            writer.WriteStartElement("ReportItemName");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemIndex
                            writer.WriteStartElement("ReportItemIndex");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemCode
                            writer.WriteStartElement("ReportItemCode");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemDescription
                            writer.WriteStartElement("ReportItemDescription");
                            writer.WriteString(dtRowDetail[5].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //PreviousPeriodAmount
                            writer.WriteStartElement("PreviousPeriodAmount");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //CurrentPeriodAmount
                            writer.WriteStartElement("CurrentPeriodAmount");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region B04/BCTC: Thuyết minh báo cáo tài chính
                    case "B04BCTC":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("B04BCTCDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemName
                            writer.WriteStartElement("ReportItemName");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemIndex
                            writer.WriteStartElement("ReportItemIndex");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemCode
                            writer.WriteStartElement("ReportItemCode");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ContentString
                            writer.WriteStartElement("ContentString");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //GroupType
                            writer.WriteStartElement("GroupType");
                            writer.WriteString(dtRowDetail[5].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount1
                            writer.WriteStartElement("Amount1");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount2
                            writer.WriteStartElement("Amount2");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount3
                            writer.WriteStartElement("Amount3");
                            writer.WriteString(dtRowDetail[8].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount4
                            writer.WriteStartElement("Amount4");
                            writer.WriteString(dtRowDetail[9].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount5
                            writer.WriteStartElement("Amount5");
                            writer.WriteString(dtRowDetail[10].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount6
                            writer.WriteStartElement("Amount6");
                            writer.WriteString(dtRowDetail[11].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount7
                            writer.WriteStartElement("Amount7");
                            writer.WriteString(dtRowDetail[12].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount8
                            writer.WriteStartElement("Amount8");
                            writer.WriteString(dtRowDetail[13].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount9
                            writer.WriteStartElement("Amount9");
                            writer.WriteString(dtRowDetail[14].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount10
                            writer.WriteStartElement("Amount10");
                            writer.WriteString(dtRowDetail[15].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount11
                            writer.WriteStartElement("Amount11");
                            writer.WriteString(dtRowDetail[16].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount12
                            writer.WriteStartElement("Amount12");
                            writer.WriteString(dtRowDetail[17].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
                    case "B03bBCTC":
                        //Detail
                        foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                        {
                            writer.WriteStartElement("B03bBCTCDetail"); //Start Detail

                            //-------------------------
                            //RefID
                            writer.WriteStartElement("RefID");
                            writer.WriteString(dtRowDetail[0].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemName
                            writer.WriteStartElement("ReportItemName");
                            writer.WriteString(dtRowDetail[1].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemCode
                            writer.WriteStartElement("ReportItemCode");
                            writer.WriteString(dtRowDetail[2].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemAlias
                            writer.WriteStartElement("ReportItemAlias");
                            writer.WriteString(dtRowDetail[3].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemIndex
                            writer.WriteStartElement("ReportItemIndex");
                            writer.WriteString(dtRowDetail[4].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //ReportItemDescription
                            writer.WriteStartElement("ReportItemDescription");
                            writer.WriteString(dtRowDetail[5].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //PrevAmount
                            writer.WriteStartElement("PrevAmount");
                            writer.WriteString(dtRowDetail[6].ToString());
                            writer.WriteEndElement();
                            //-------------------------
                            //Amount
                            writer.WriteStartElement("Amount");
                            writer.WriteString(dtRowDetail[7].ToString());
                            writer.WriteEndElement();
                            //-------------------------

                            writer.WriteEndElement(); //End Detail
                        }
                        break;
                    #endregion

                    #region B05/BCTC: Báo cáo tài chính mẫu đơn giản
                    case "B05BCTC":
                        //Detail
                        if (resultReports[i].Tables.Count >= 3)
                        {
                            #region Bảng 1

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B05BCTCDetailGeneral"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Code
                                writer.WriteStartElement("Code");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Value
                                writer.WriteStartElement("Value");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion

                            #region Bảng 2

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B05BCTCDetailBudget"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount1
                                writer.WriteStartElement("Amount1");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount2
                                writer.WriteStartElement("Amount2");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion
                        }
                        break;
                    #endregion

                    #region Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
                    case "F0102BCQTP1":
                        //Detail
                        if (resultReports[i].Tables.Count >= 3)
                        {
                            #region Bảng 2 (Báo cáo này bảng detail thứ 2 insert trước bảng detail 1)

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("Project"); //Start Detail

                                //-------------------------
                                //ProjectID
                                writer.WriteStartElement("ProjectID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[1].ToString()))
                                {
                                    //ProjectNumber
                                    writer.WriteStartElement("ProjectNumber");
                                    writer.WriteString(dtRowDetail[1].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //ProjectName
                                writer.WriteStartElement("ProjectName");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[3].ToString()))
                                {
                                    //ProgramName
                                    writer.WriteStartElement("ProgramName");
                                    writer.WriteString(dtRowDetail[3].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //ObjectType
                                writer.WriteStartElement("ObjectType");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[5].ToString()))
                                {
                                    //StartDate
                                    writer.WriteStartElement("StartDate");
                                    writer.WriteString(dtRowDetail[5].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[6].ToString()))
                                {
                                    //FinishDate
                                    writer.WriteStartElement("FinishDate");
                                    writer.WriteString(dtRowDetail[6].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[7].ToString()))
                                {
                                    //ExecutionUnit
                                    writer.WriteStartElement("ExecutionUnit");
                                    writer.WriteString(dtRowDetail[7].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[8].ToString()))
                                {
                                    //ParentID
                                    writer.WriteStartElement("ParentID");
                                    writer.WriteString(dtRowDetail[8].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //IsDetail
                                writer.WriteStartElement("IsDetail");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion

                            #region Bảng 1

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("F0102BCQTP1Detail"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ProjectID
                                writer.WriteStartElement("ProjectID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //MethodDistributeID
                                writer.WriteStartElement("MethodDistributeID");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSourceID
                                writer.WriteStartElement("BudgetSourceID");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetKindItemID
                                writer.WriteStartElement("BudgetKindItemID");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSubKindItemID
                                writer.WriteStartElement("BudgetSubKindItemID");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemCode
                                writer.WriteStartElement("ReportItemCode");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //TotalAmountApproved
                                writer.WriteStartElement("TotalAmountApproved");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount
                                writer.WriteStartElement("Amount");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccAmount
                                writer.WriteStartElement("AccAmount");
                                writer.WriteString(dtRowDetail[12].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion
                        }
                        break;
                    #endregion

                    #region Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
                    case "F0102BCQTP2":
                        //Detail
                        if (resultReports[i].Tables.Count >= 3)
                        {
                            #region Bảng 2 (Báo cáo này bảng detail thứ 2 insert trước bảng detail 1)

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("Project"); //Start Detail

                                //-------------------------
                                //ProjectID
                                writer.WriteStartElement("ProjectID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[1].ToString()))
                                {
                                    //ProjectNumber
                                    writer.WriteStartElement("ProjectNumber");
                                    writer.WriteString(dtRowDetail[1].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //ProjectName
                                writer.WriteStartElement("ProjectName");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[3].ToString()))
                                {
                                    //ProgramName
                                    writer.WriteStartElement("ProgramName");
                                    writer.WriteString(dtRowDetail[3].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //ObjectType
                                writer.WriteStartElement("ObjectType");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[5].ToString()))
                                {
                                    //StartDate
                                    writer.WriteStartElement("StartDate");
                                    writer.WriteString(dtRowDetail[5].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[6].ToString()))
                                {
                                    //FinishDate
                                    writer.WriteStartElement("FinishDate");
                                    writer.WriteString(dtRowDetail[6].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[7].ToString()))
                                {
                                    //ExecutionUnit
                                    writer.WriteStartElement("ExecutionUnit");
                                    writer.WriteString(dtRowDetail[7].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                if (!string.IsNullOrEmpty(dtRowDetail[8].ToString()))
                                {
                                    //ParentID
                                    writer.WriteStartElement("ParentID");
                                    writer.WriteString(dtRowDetail[8].ToString());
                                    writer.WriteEndElement();
                                }
                                //-------------------------
                                //IsDetail
                                writer.WriteStartElement("IsDetail");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion

                            #region Bảng 1

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("F0102BCQTP1Detail"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ProjectID
                                writer.WriteStartElement("ProjectID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //MethodDistributeID
                                writer.WriteStartElement("MethodDistributeID");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSourceID
                                writer.WriteStartElement("BudgetSourceID");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetKindItemID
                                writer.WriteStartElement("BudgetKindItemID");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSubKindItemID
                                writer.WriteStartElement("BudgetSubKindItemID");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemCode
                                writer.WriteStartElement("ReportItemCode");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //TotalAmountApproved
                                writer.WriteStartElement("TotalAmountApproved");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount
                                writer.WriteStartElement("Amount");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccAmount
                                writer.WriteStartElement("AccAmount");
                                writer.WriteString(dtRowDetail[12].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion
                        }
                        break;
                    #endregion

                    #region B01/BSTT: Báo cáo bổ sung thông tin tài chính
                    case "B01BSTT":
                        //Detail
                        if (resultReports[i].Tables.Count >= 3)
                        {
                            #region Bảng 1

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B01BSTTDetail"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemCode
                                writer.WriteStartElement("ReportItemCode");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount
                                writer.WriteStartElement("Amount");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //MediateUnit2Amount
                                writer.WriteStartElement("MediateUnit2Amount");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //MediateUnit1Amount
                                writer.WriteStartElement("MediateUnit1Amount");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //EstimateUnit1Amount
                                writer.WriteStartElement("EstimateUnit1Amount");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //EstimateUnitOut1Amount
                                writer.WriteStartElement("EstimateUnitOut1Amount");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OherEstimateUnitOut1Amount
                                writer.WriteStartElement("OherEstimateUnitOut1Amount");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //NationalOutAmount
                                writer.WriteStartElement("NationalOutAmount");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion

                            #region Bảng 2

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("B01BSTTDetailP2"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemName
                                writer.WriteStartElement("ReportItemName");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemCode
                                writer.WriteStartElement("ReportItemCode");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemAlias
                                writer.WriteStartElement("ReportItemAlias");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //ReportItemIndex
                                writer.WriteStartElement("ReportItemIndex");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //Amount
                                writer.WriteStartElement("Amount");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion
                        }
                        break;
                    #endregion

                    #region S05H: Bảng cân đối số phát sinh
                    case "S05H":
                        //Detail
                        if (resultReports[i].Tables.Count >= 3)
                        {
                            #region Bảng 1

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[1].Rows) //Lặp details
                            {
                                writer.WriteStartElement("S05HDetail"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccountID
                                writer.WriteStartElement("AccountID");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccountName
                                writer.WriteStartElement("AccountName");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OpenDebitAmount
                                writer.WriteStartElement("OpenDebitAmount");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OpenCreditAmount
                                writer.WriteStartElement("OpenCreditAmount");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DebitAmount
                                writer.WriteStartElement("DebitAmount");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CreditAmount
                                writer.WriteStartElement("CreditAmount");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccumDebitAmount
                                writer.WriteStartElement("AccumDebitAmount");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccumCreditAmount
                                writer.WriteStartElement("AccumCreditAmount");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CloseDebitAmount
                                writer.WriteStartElement("CloseDebitAmount");
                                writer.WriteString(dtRowDetail[12].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CloseCreditAmount
                                writer.WriteStartElement("CloseCreditAmount");
                                writer.WriteString(dtRowDetail[13].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSourceID
                                writer.WriteStartElement("BudgetSourceID");
                                writer.WriteString(dtRowDetail[1].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetKindItemID
                                writer.WriteStartElement("BudgetKindItemID");
                                writer.WriteString(dtRowDetail[2].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //BudgetSubKindItemID
                                writer.WriteStartElement("BudgetSubKindItemID");
                                writer.WriteString(dtRowDetail[3].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion

                            #region Bảng 2

                            foreach (DataRow dtRowDetail in resultReports[i].Tables[2].Rows) //Lặp details
                            {
                                writer.WriteStartElement("S05HDetailSumary"); //Start Detail

                                //-------------------------
                                //RefID
                                writer.WriteStartElement("RefID");
                                writer.WriteString(dtRowDetail[0].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccountID
                                writer.WriteStartElement("AccountID");
                                writer.WriteString(dtRowDetail[4].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccountName
                                writer.WriteStartElement("AccountName");
                                writer.WriteString(dtRowDetail[5].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OpenDebitAmount
                                writer.WriteStartElement("OpenDebitAmount");
                                writer.WriteString(dtRowDetail[6].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //OpenCreditAmount
                                writer.WriteStartElement("OpenCreditAmount");
                                writer.WriteString(dtRowDetail[7].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //DebitAmount
                                writer.WriteStartElement("DebitAmount");
                                writer.WriteString(dtRowDetail[8].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CreditAmount
                                writer.WriteStartElement("CreditAmount");
                                writer.WriteString(dtRowDetail[9].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccumDebitAmount
                                writer.WriteStartElement("AccumDebitAmount");
                                writer.WriteString(dtRowDetail[10].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //AccumCreditAmount
                                writer.WriteStartElement("AccumCreditAmount");
                                writer.WriteString(dtRowDetail[11].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CloseDebitAmount
                                writer.WriteStartElement("CloseDebitAmount");
                                writer.WriteString(dtRowDetail[12].ToString());
                                writer.WriteEndElement();
                                //-------------------------
                                //CloseCreditAmount
                                writer.WriteStartElement("CloseCreditAmount");
                                writer.WriteString(dtRowDetail[13].ToString());
                                writer.WriteEndElement();
                                //-------------------------

                                writer.WriteEndElement(); //End Detail
                            }

                            #endregion
                        }
                        break;
                    #endregion

                    default: break;
                }
            }
            #endregion

            writer.WriteEndElement(); //java
            writer.WriteEndDocument();
            writer.Close();

            currentProcess++;
            var b = currentProcess * 100 / ProcessExport;
            backgroundWorker.ReportProgress(b);
            #endregion
        }

        #endregion

        #region Interface control


        /// <summary>
        /// Nút next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Step == 0)
                ListExportXml();
            if (LstXmlSelected.Count <= 0)
            {
                XtraMessageBox.Show("Hãy chọn báo cáo để xuất khẩu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Step++;
                ControlInterface(Step);
            }
        }

        /// <summary>
        /// Nút lùi về trước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            Step--;
            ControlInterface(Step);
        }

        /// <summary>
        /// Điều chỉnh giao diện
        /// </summary>
        /// <param name="step"></param>
        private void ControlInterface(int step)
        {
            lblTitle.Text = step.Equals(0) ? "Chọn báo cáo để xuất" : step.Equals(1) ? "Đối chiếu với danh mục nguồn của đơn vị cấp trên" : "Chọn nơi lưu trữ tệp dữ liệu";
            groupBox1.Visible = step <= 0 ? true : false;
            groupBox2.Visible = step.Equals(1) ? true : false;
            btnPrev.Enabled = step <= 0 ? false : true;
            btnNext.Enabled = step >= 2 ? false : true;
            groupBox3.Visible = step >= 2 ? true : false;
            grdXmlSource.Visible = step.Equals(1) ? true : false;
            grdXmlGroup.Visible = step.Equals(0) ? true : false;
            btnExport.Enabled = step >= 2 ? true : false;
            groupBox4.Visible = step >= 2 ? true : false;
        }

        /// <summary>
        /// Nút chọn nơi lưu tệp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                results = fbd.ShowDialog();
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        /// <summary>
        /// <summary>
        /// Nút xuất báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            ProcessExport = LstXmlSelected.Count + 1;
            if (Valid())
            {
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Lọc ra những dòng được tick
        /// </summary>
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
                        var row = (ExportXmlBCTCModel)grdXmlGroupView.GetRow(i);
                        //selectXmlItem = selectXmlItem + row.RefType.Trim() + ",";
                        LstXmlSelected.Add(row);
                    }
                }
            }
        }
        /// <summary>
        /// Thoát form khi bấm ESC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmXtraExportBCTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

    }

}