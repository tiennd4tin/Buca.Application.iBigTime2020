using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC301NS : FrmXtraBaseParameter    {
        #region Variable
        private Enum.RefType _refType = Enum.RefType.BUPlanWithDrawCash;
        #endregion
        private static IModel Model { get; set; }

        public string RefId { get; set; }
        public int TMCK { get
            {
                return cbxHinhThucTT.SelectedIndex.Equals(2) ? 2 : cbxHinhThucTT.SelectedIndex.Equals(3) ? 3 : 0;
            } }
        public DateTime CanCuNgay { get
        {
            return Convert.ToDateTime(dateTimePicker1.Value);
        } }

        public string daCancuHdSo
        {
            get
            {
               return tbxGiayDeNghiSo.Text;
            }
        }
        public string daCkcHdk { get
        {
           return tbxHDK.Text;
        } }

        public  string daCkcHdth { get
        {
          return tbxHDTD.Text;
        } }

        public string dvNopthueChuong
        {
            get
            {
               return tbxMaChuong.Text;
            }
        }

        public string dvNopthueCqthuMa
        {
            get
            {
               return tbxMaCQThu.Text;
            }
        }

        public string dvNopthueCqthuTen
        {
            get { return tbxCQQLThu.Text; }
        }
        public string dvNopthueKbHachtoanTen
        { get
        {
           return tbxKBNNHachToanThu.Text;
        } }
        public string dvNopthueKythue
        { get { return tbxKyThue.Text; } }

        public string dvNopthueMasothue
        {
            get { return tbxMaSoThue.Text; }
        }
        public string dvNopthueNdkt
        { get { return tbxMaNDKT.Text; } }
        public string dvNopthueTen
        { get { return tbxDVNopThue.Text; } }

        public int TUTC
        {
            get
            {
                return cbxNghiepVu.SelectedIndex.Equals(2)
                    ? 1
                    : cbxNghiepVu.SelectedIndex.Equals(3)
                        ? 2
                        : cbxNghiepVu.SelectedIndex.Equals(4)
                            ? 3
                            : 0;
            }
        }
        public FrmC301NS(string refId)
        {
            InitializeComponent();
            cbxNghiepVu.SelectedIndex = 0;
            cbxHinhThucTT.SelectedIndex = 0;
            Model = new Model();
            //_refType = refType;
            InitData();
            RefId = refId;
            LoadDataIntoGridDetail(refId);

            gridDetailView.OptionsView.ShowGroupPanel = false;
            gridDetailView.OptionsView.ShowIndicator = false;
            for (int i = 0; i < gridDetailView.RowCount; i++)
            {
              
                    var Amount = gridDetailView.GetRowCellValue(i, "Amount") == null ? 0 :
                        (decimal)gridDetailView.GetRowCellValue(i, "Amount");
                    var AmountTax = gridDetailView.GetRowCellValue(i, "AmountTax") == null ? 0 :
                        (decimal)gridDetailView.GetRowCellValue(i, "AmountTax");
                    gridDetailView.SetRowCellValue(i, "AmountNet", Amount - AmountTax);
             
            }
        }

        private void InitData()
        {
            //_banksPresenter.DisplayActive(true);
            //_projectsPresenter.Display();
            //_accountingObjectsPresenter.Display();

        }
        public IList<C2_02a_NSDetailModel> DetailModels
        {
            get
            {
                var c402CkbModels = new List<C2_02a_NSDetailModel>();
                if (gridDetailView.RowCount > 0)
                {
                    for (int i = 0; i < gridDetailView.RowCount; i++)
                    {
                        var rowVoucher = (C2_02a_NSDetailModel)gridDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new C2_02a_NSDetailModel
                            {
                                Memo = rowVoucher.Memo,
                                Amount = rowVoucher.Amount,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetSourceCode = rowVoucher.BudgetSourceCode,
                                AmountTax = rowVoucher.AmountTax,
                                AmountNet = rowVoucher.AmountNet,
                                CashWithDrawType = rowVoucher.CashWithDrawType
                            };
                            c402CkbModels.Add(item);
                        }
                    }
                }

                return c402CkbModels;
            }
        }

        private void LoadDataIntoGridDetail(string refId)
        {
            
            var reports = //Model.GetBUPlanWithdrawByRefId(refId, true);
                Model.ReportBUPlanWithDraw(refId, 0, 1, 1, _refType).First();
            bindingSource.DataSource = reports.Details;
            gridDetail.ForceInitialize();
            gridDetailView.PopulateColumns(reports);

            
            var columnsCollection = new List<XtraColumn>
                {
                new XtraColumn
                    {
                    ColumnName = "BudgetSubItemCode",
                    ColumnVisible = true,
                    ColumnWith = 90,
                    ColumnCaption = "Mã NDKT",
                    ColumnPosition = 0,
                    AllowEdit = true,
                    },
                      new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 90,
                        ColumnCaption = "Mã Chương",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                      new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 90,
                        ColumnCaption = "Mã ngành KT",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "ColKHV",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Năm KHV",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountTax",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nộp thuế",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountNet",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TT cho DV hưởng",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        IsSummnary = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "Memo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},



                };
            gridDetailView = InitGridLayout(columnsCollection, gridDetailView);
            SetNumericFormatControl(gridDetailView, true);
            //gridDetailView.OptionsView.ShowFooter = false;

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
        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
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

        private void gridDetailView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Amount" || e.Column.FieldName == "AmountTax")
            {
                var Amount = gridDetailView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "Amount");
                var AmountTax = gridDetailView.GetRowCellValue(e.RowHandle, "AmountTax") == null ? 0 :
                     (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "AmountTax");
                gridDetailView.SetRowCellValue(e.RowHandle, "AmountNet", Amount - AmountTax);
            }
        }


        private void chkIsGroupDetail_CheckedChanged_1(object sender, EventArgs e)
        {
            LoadDataIntoGridDetail(RefId);

            for (int i = 0; i < gridDetailView.RowCount; i++)
            {

                var Amount = gridDetailView.GetRowCellValue(i, "Amount") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(i, "Amount");
                var AmountTax = gridDetailView.GetRowCellValue(i, "AmountTax") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(i, "AmountTax");
                gridDetailView.SetRowCellValue(i, "AmountNet", Amount - AmountTax);

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
    }
}
