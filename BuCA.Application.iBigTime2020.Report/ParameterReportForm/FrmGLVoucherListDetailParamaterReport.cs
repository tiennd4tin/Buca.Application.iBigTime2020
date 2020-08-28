using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmGLVoucherListDetailParamaterReport : FrmXtraBaseParameter
    {
        public FrmGLVoucherListDetailParamaterReport()
        {
            InitializeComponent();
        }

        public bool isGroupSameRow { get { return IsGroupSameRow.Checked; } }
        public bool isShowOriginalCurrency { get { return IsOriginalCurrency.Checked; } }
        public bool isNotShowSingleAccount { get { return IsNotShowSingleAccount.Checked; } }
        public bool isNotShowTotalSingleAccount { get { return IsNotTotalSingleAccount.Checked; } }
        public bool isShowRefNo { get { return IsViewRefNo.Checked; } }
    }
}
