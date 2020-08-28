/***********************************************************************
 * <copyright file="frmfixedassetdecreaselist.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, May 4, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    ///     FrmFixedAssetDecreaseList
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmFixedAssetDecreaseList : FrmXtraBaseParameter
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmFixedAssetDecreaseList" /> class.
        /// </summary>
        public FrmFixedAssetDecreaseList()
        {
            InitializeComponent();
            var decreaseReason = new Dictionary<int, string>
            {
                {-1, "<<Tất cả>>"},
                {1, "Thanh lý"},
                {2, "Điều chuyển"},
                {3, "Bán"},
                {4, "Chuyển sang CCDC"},
                {5, "Chuyển nhượng"},
                {6, "Mất"},
                {7, "Tiêu hủy"},
                {8, "Hình thức khác"}
            };
            var repositoryDecreaseReason = new RepositoryItemLookUpEdit
            {
                DataSource = decreaseReason,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false,
                ShowFooter = false
            };
            repositoryDecreaseReason.PopulateColumns();
            repositoryDecreaseReason.Columns["Key"].Visible = false;
            cboDecreaseReason.Properties.Assign(repositoryDecreaseReason);
            cboDecreaseReason.EditValue = -1;
        }

        /// <summary>
        ///     Gets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }
        }

        /// <summary>
        ///     Sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public DateTime ToDate { get { return dateTimeRangeV1.ToDate; } }

        /// <summary>
        ///     Gets the decrease reason identifier.
        /// </summary>
        /// <value>
        ///     The decrease reason identifier.
        /// </value>
        public int DecreaseReasonId {get{return cboDecreaseReason.EditValue == null ? -1 : (int)cboDecreaseReason.EditValue; } } 
    }
}