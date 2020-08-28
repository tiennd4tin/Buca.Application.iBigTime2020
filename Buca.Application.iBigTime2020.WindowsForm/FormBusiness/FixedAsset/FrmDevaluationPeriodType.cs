/***********************************************************************
 * <copyright file="FrmDevaluationPeriodType.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Globalization;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset
{
    /// <summary>
    /// FrmDevaluationPeriodType
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmDevaluationPeriodType : Form
    {
        #region Properties

        /// <summary>
        /// The period type
        /// </summary>
        public int PeriodType;

        /// <summary>
        /// The period type name
        /// </summary>
        public string PeriodTypeName;

        /// <summary>
        /// The devaluation period type
        /// </summary>
        public int DevaluationPeriodType;

        /// <summary>
        /// From date
        /// </summary>
        public DateTime FromDate;

        /// <summary>
        /// To date
        /// </summary>
        public DateTime ToDate;

        /// <summary>
        /// The base posted date
        /// </summary>
        public DateTime BasePostedDate;

        #endregion

        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDevaluationPeriodType"/> class.
        /// </summary>
        public FrmDevaluationPeriodType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            PeriodType = cboPeriodType.SelectedIndex;
            PeriodTypeName = cboPeriodType.Text.Trim();
            GlobalVariable.DevaluationPeriod = cboPeriodType.SelectedIndex;

            //if (cboPeriodType.SelectedIndex == 0)
            //    DevaluationPeriodType = 0;
            //else if (cboPeriodType.SelectedIndex >= 1 && cboPeriodType.SelectedIndex <= 4)
            //    DevaluationPeriodType = 1;
            //else
            //    DevaluationPeriodType = 2;

            Dispose();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPeriodType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboPeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            switch (cboPeriodType.SelectedIndex)
            {
                case 0: //Năm
                    FromDate = new DateTime(BasePostedDate.Year, 1, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 12, 31);
                    break;
                case 1: // Quý I
                    FromDate = new DateTime(BasePostedDate.Year, 1, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 3, 31);
                    break;
                case 2: // Quý II
                    FromDate = new DateTime(BasePostedDate.Year, 4, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 6, 30);
                    break;
                case 3: // Quý III
                    FromDate = new DateTime(BasePostedDate.Year, 7, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 9, 30);
                    break;
                case 4: // Quý IV
                    FromDate = new DateTime(BasePostedDate.Year, 10, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 12, 31);
                    break;
                case 5: //Tháng 1
                    FromDate = new DateTime(BasePostedDate.Year, 1, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 1, 31);
                    break;
                case 6: //Tháng 2
                    FromDate = new DateTime(BasePostedDate.Year, 2, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 2, BasePostedDate.Year % 4 == 0 ? 29 : 28);
                    break;
                case 7: //Tháng 3
                    FromDate = new DateTime(BasePostedDate.Year, 3, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 3, 31);
                    break;
                case 8: //Tháng 4
                    FromDate = new DateTime(BasePostedDate.Year, 4, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 4, 30);
                    break;
                case 9: //Tháng 5
                    FromDate = new DateTime(BasePostedDate.Year, 5, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 5, 31);
                    break;
                case 10: //Tháng 6
                    FromDate = new DateTime(BasePostedDate.Year, 6, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 6, 30);
                    break;
                case 11: //Tháng 7
                    FromDate = new DateTime(BasePostedDate.Year, 7, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 7, 31);
                    break;
                case 12: //Tháng 8
                    FromDate = new DateTime(BasePostedDate.Year, 8, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 8, 31);
                    break;
                case 13: //Tháng 9
                    FromDate = new DateTime(BasePostedDate.Year, 9, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 9, 30);
                    break;
                case 14: //Tháng 10
                    FromDate = new DateTime(BasePostedDate.Year, 10, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 10, 31);
                    break;
                case 15: //Tháng 11
                    FromDate = new DateTime(BasePostedDate.Year, 11, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 11, 30);
                    break;
                case 16: //Tháng 12
                    FromDate = new DateTime(BasePostedDate.Year, 12, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 12, 31);
                    break;
                default:
                    FromDate = new DateTime(BasePostedDate.Year, 1, 1);
                    ToDate = new DateTime(BasePostedDate.Year, 3, 31);
                    break;
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmDevaluationPeriodType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmDevaluationPeriodType_Load(object sender, EventArgs e)
        {
            BasePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cboPeriodType.SelectedIndex = 0;
        }

        #endregion
    }
}
