/***********************************************************************
 * <copyright file="FrmC55HD.cs" company="BUCA JSC">
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
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// FrmC55HD
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmC55HD : FrmXtraBaseParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC55HD"/> class.
        /// </summary>
        public FrmC55HD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate
        {
            get { return dateTimeRangeV1.ToDate; }
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
    }
}
