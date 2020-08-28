using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using BuCA.Application.iBigTime2020.Session;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class frmS33_H : FrmXtraBaseParameter, IAccountingObjectsView, IAccountsView
    {
        AccountingObjectsPresenter _accountingObjectsPresenter;
        AccountsPresenter _accountsPresenter;

        string _reportID;
        public frmS33_H(string ReportID)
        {
            InitializeComponent();

            _reportID = ReportID;

            switch (_reportID)
            {
                case CommonText.ReportS61H:
                    labelControl3.Location = labelControl2.Location;
                    lkAccount.Location = lkAccountingObject.Location;

                    labelControl2.Visible = false;
                    lkAccountingObject.Visible = false;
                    break;
            }
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                if (value == null)
                    value = new List<AccountingObjectModel>();
                value.Insert(0, new AccountingObjectModel() { AccountingObjectId = CommonText.AllText, AccountingObjectName = CommonText.AllText, AccountingObjectCode = CommonText.AllText });

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectCode), ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectName), ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                lkAccountingObject.Properties.DataSource = value;
                lkAccountingObject.Properties.PopulateColumns();
                lkAccountingObject.Properties.DisplayMember = nameof(AccountingObjectModel.AccountingObjectName);
                lkAccountingObject.Properties.ValueMember = nameof(AccountingObjectModel.AccountingObjectId);
                ShowXtraColumnInLookUpEdit<AccountingObjectModel>(gridColumnsCollection, lkAccountingObject);
                lkAccountingObject.ItemIndex = 0;
            }
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    value = new List<AccountModel>();
                value.Insert(0, new AccountModel() { AccountNumber = CommonText.AllText, AccountName = CommonText.AllText });

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountModel.AccountNumber), ColumnCaption = "Mã tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountModel.AccountName), ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                switch (_reportID)
                {
                    case CommonText.ReportS33_H:
                        lkAccount.Properties.DataSource = value.Where(m => m.AccountNumber.Equals(CommonText.AllText) || m.AccountNumber.Equals(CommonText.Account136) || m.AccountNumber.Equals(CommonText.Account336)).ToList();
                        break;
                    case CommonText.ReportS61H:
                        lkAccount.Properties.DataSource = value.Where(m => m.AccountNumber.Equals(CommonText.AllText) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account154) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account611) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account612) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account614) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account615) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account632) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account642) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account652) ||
                                                                        m.AccountNumber.StartsWith(CommonText.Account811)).ToList();
                        break;
                }

                lkAccount.Properties.PopulateColumns();
                lkAccount.Properties.DisplayMember = nameof(AccountModel.AccountNumber);
                lkAccount.Properties.ValueMember = nameof(AccountModel.AccountNumber);
                ShowXtraColumnInLookUpEdit<AccountModel>(gridColumnsCollection, lkAccount);
                lkAccount.ItemIndex = 0;
            }
        }

        public string AccountingObjectId
        {
            get { return Convert.ToString(lkAccountingObject.EditValue).Equals(CommonText.AllText) ? null : Convert.ToString(lkAccountingObject.EditValue); }
        }

        public string AccountList
        {
            get
            {
                string _value = null;
                switch (_reportID)
                {
                    case CommonText.ReportS33_H:
                        _value = Convert.ToString(lkAccount.EditValue).Equals(CommonText.AllText) ? null : Convert.ToString(lkAccount.EditValue);
                        break;
                    case CommonText.ReportS61H:
                        _value = Convert.ToString(lkAccount.EditValue).Equals(CommonText.AllText) ? null : CommonText.Comma + Convert.ToString(lkAccount.EditValue) + CommonText.Comma;
                        break;
                }
                return _value;
            }
        }

        private void frmS33_H_Load(object sender, EventArgs e)
        {
            switch (_reportID)
            {
                case CommonText.ReportS33_H:
                    _accountingObjectsPresenter.DisplayActive(true);
                    break;
            }
            _accountsPresenter.DisplayActive();
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }
    }
}