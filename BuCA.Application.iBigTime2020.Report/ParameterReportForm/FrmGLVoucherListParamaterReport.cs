using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DateTimeRangeBlockDev.Helper;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmGLVoucherListParamaterReport : FrmXtraBaseParameter
    {
        public FrmGLVoucherListParamaterReport()
        {

            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }
        public DateTime fromDate { get { return dateTimeRangeV1.FromDate; } }
        public DateTime toDate { get { return dateTimeRangeV1.ToDate; } }

        public int AmountTypeReport { get { return GlobalVariable.AmountTypeViewReport; } }
        public string CurrencyCodeReport { get { return GlobalVariable.CurrencyViewReport; } }
        public bool isNotShowSignAccount { get { return CbxNotShowSignAccount.Checked; } }
    }
}
