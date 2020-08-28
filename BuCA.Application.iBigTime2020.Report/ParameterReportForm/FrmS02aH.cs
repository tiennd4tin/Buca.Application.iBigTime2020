using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using DevExpress.XtraRichEdit.Layout;
using Microsoft.SqlServer.Management.Smo;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.View.General;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using DevExpress.Data;
using BuCA.Application.iBigTime2020.Session;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS02aH.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmS02aH : FrmXtraBaseParameter, IGLVoucherListsView
    {
        #region Presenter
        private readonly GLVoucherListsPresenter _glVoucherListsPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        #endregion
        #region Variable
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        /// <summary>
        /// Sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string ListRefId
        {
           get
            {
                var selectAccount = ",";
                if(Selection.SelectedCount > 0)
                {
                    for(int i = 0; i < gridAccountNumberView.RowCount;i++)
                    {
                        if(Selection.IsRowSelected(i))
                        {
                            selectAccount = selectAccount + gridAccountNumberView.GetRowCellValue(i, "RefId") +',';
                        }
                    }
                }
                return selectAccount;
            }
        }

        public string ListRefNo
        {
            get {
                var refno = "";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridAccountNumberView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            refno = refno + gridAccountNumberView.GetRowCellValue(i, "RefNo") + ',';
                        }
                    }
                }
                return refno;
            }
        }
        public bool isGroupSameRow
        {
            get { return CbxisGroupSameRow.Checked;}
        }

        public bool isShowOriginalCurrency
        {
            get { return CbxisShowOriginalCurrency.Checked; }
        }
        #endregion
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// The columns collection account
        /// </summary>
        public List<XtraColumn> ColumnsCollectionAccount = new List<XtraColumn>();
        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS02aH"/> class.
        /// </summary>
        public FrmS02aH()
        {
            InitializeComponent();
            //_accountsPresenter = new AccountsPresenter(this);
            _glVoucherListsPresenter = new GLVoucherListsPresenter(this);
        }

        #region IView


        protected void BindSelectDesignReport()
        {
            //var bankSource = new List<LookUpItem> { new LookUpItem { Id = 0, Name = "S31-H: Sổ chi tiết tài khoản(Mẫu theo QĐ 19)" }, new LookUpItem { Id = 1, Name = "S31-H: Sổ chi tiết tài khoản(Mẫu theo mã thống kê)" } };
            //cboSelectDesignReport.Properties.DataSource = bankSource;
            //cboSelectDesignReport.Properties.PopulateColumns();
            //var treeColumnsCollection = new List<XtraColumn> {
            //                                    new XtraColumn { ColumnName = "Id", ColumnVisible = false },
            //                                    new XtraColumn { ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true }
            //                                };
            //foreach (var column in treeColumnsCollection)
            //{
            //    if (column.ColumnVisible)
            //    {
            //        cboSelectDesignReport.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //        cboSelectDesignReport.Properties.SortColumnIndex = column.ColumnPosition;
            //    }
            //    else cboSelectDesignReport.Properties.Columns[column.ColumnName].Visible = false;
            //}
            //cboSelectDesignReport.Properties.ValueMember = "Id";
            //cboSelectDesignReport.Properties.DisplayMember = "Name";
        }

        #region GLVoucherList
        public IList<GLVoucherListModel> GlVoucherListModel
        {
            set
            {
                if (dateTimeRangeV1.cboDateRange.EditValue != null)
                {
                    bindingSourceAccount.DataSource = value.Where(x => x.RefDate >= dateTimeRangeV1.FromDate && x.RefDate <= dateTimeRangeV1.ToDate).ToList();
                    gridAccountNumberView.PopulateColumns(value.Where(x => x.RefDate >= dateTimeRangeV1.FromDate && x.RefDate <= dateTimeRangeV1.ToDate).ToList());
                }
                else
                {
                    bindingSourceAccount.DataSource = value;
                    gridAccountNumberView.PopulateColumns(value);
                }
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT ghi sổ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT ghi sổ",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SetupType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 4,
                    ColumnVisible = false,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Loại chứng từ",
                    ColumnPosition = 10,
                    ColumnVisible = false,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EditVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "GlVoucherListDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "GLVoucherDetailParallels", ColumnVisible = false });
                if (ColumnsCollectionAccount == null) return;
                foreach (var column in ColumnsCollection)
                {
                    if (gridAccountNumberView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridAccountNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridAccountNumberView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridAccountNumberView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridAccountNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridAccountNumberView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridAccountNumberView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridAccountNumberView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridAccountNumberView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridAccountNumberView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridAccountNumberView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }

        #endregion

        #endregion

        #region Event 
        /// <summary>
        /// Handles the Load event of the FrmS02aH control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS02aH_Load(object sender, EventArgs e)
        {
            //_accountsPresenter.DisplayActive();
            _glVoucherListsPresenter.Display();
            BindSelectDesignReport();

            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;

            Selection = new GridCheckMarksSelection(gridAccountNumberView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
            Selection.SelectAll();
        }

        private void cboDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            _glVoucherListsPresenter.Display();

        }

        private void ChangeDatetime(object sender, EventArgs e)
        {
          _glVoucherListsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridAccountNumberView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
            //Selection.SelectAll();
        }
        #endregion

    }
}
