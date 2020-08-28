using System;
using System.Linq;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Session;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC4_09 : FrmXtraBaseParameter
    {
        public FrmC4_09()
        {
            InitializeComponent();
            this.chkIsShowDate.Checked = true;
            this.chkIsShowAllDetail.Checked = true;
            txtAccountDebit.Focus();
        }

              public bool IsGroup
        {
            get { return chkIsGroup.Checked; }
        }

        public bool isshowdate
        {
            get { return chkIsShowDate.Checked; }
        }

        public bool isshowdetail
        {
            get { return chkIsShowAllDetail.Checked; }
        }

        public string accountdebit
        {
            get { return txtAccountDebit.EditValue == null ? "" : txtAccountDebit.EditValue.ToString(); }
        }

        public string accountcredit
        {
            get { return txtAccountCredit.EditValue == null ? "" : txtAccountCredit.EditValue.ToString(); }
        }
    }
}
