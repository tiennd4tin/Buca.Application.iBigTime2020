/***********************************************************************
 * <copyright file="FrmC206NS.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Monday, July 09, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

 using System;
 using System.Windows.Forms;
 using BuCA.Application.iBigTime2020.Report.BaseParameterForm;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// FrmC206NS
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmC206NS : FrmXtraBaseParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC206NS"/> class.
        /// </summary>
        public FrmC206NS()
        {
            InitializeComponent();
        }
        public int RealytoPay
        {
            get
            {
                int result = 0;
                if (radioButton1.Checked)
                    result = 1;
                else
                {
                    if (radioButton2.Checked)
                        result = 2;

                }
                return result;


            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is print book quantity.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is print book quantity; otherwise, <c>false</c>.
        /// </value>
        public bool IsDetailByFixedAsset
        {
            get { return chkIsDetailByFixedAsset.EditValue == null ? false : (bool)chkIsDetailByFixedAsset.EditValue; }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
    }
}
