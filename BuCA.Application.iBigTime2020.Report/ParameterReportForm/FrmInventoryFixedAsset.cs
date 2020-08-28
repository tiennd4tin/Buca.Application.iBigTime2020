using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmInventoryFixedAsset : FrmXtraBaseParameter
    {
        public FrmInventoryFixedAsset()
        {
            InitializeComponent();
            //checkIsPrintBookQuantity.EditValue = true;
        }

        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public DateTime ToDate
        {
            get { return dateTimeRangeV1.ToDate; }
        }

        public bool IsPrintBookQuantity
        {
            get;
            //get { return checkIsPrintBookQuantity.EditValue == null ? false : (bool)checkIsPrintBookQuantity.EditValue; }
        }
    }
}
