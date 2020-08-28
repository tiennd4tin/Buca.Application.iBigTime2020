﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace BuCA.Application.iBigTime2020.Report.CommonClass
{
    public class XtraColumn
    {
        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        [Category("XtraColumn")]
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the column caption.
        /// </summary>
        /// <value>
        /// The column caption.
        /// </value>
        [Category("XtraColumn")]
        public string ColumnCaption { get; set; }

        /// <summary>
        /// Gets or sets the column position.
        /// </summary>
        /// <value>
        /// The column position.
        /// </value>
        [Category("XtraColumn")]
        public int ColumnPosition { get; set; }

        /// <summary>
        /// Gets or sets the column visible.
        /// </summary>
        /// <value>
        /// The column visible.
        /// </value>
        [Category("XtraColumn")]
        public bool ColumnVisible { get; set; }

        /// <summary>
        /// Gets or sets the column with.
        /// </summary>
        /// <value>
        /// The column with.
        /// </value>
        [Category("XtraColumn")]
        public int ColumnWith { get; set; }

        /// <summary>
        /// Gets or sets the binding control.
        /// </summary>
        /// <value>
        /// The binding control.
        /// </value>
        [Category("XtraColumn")]
        public RepositoryItem RepositoryControl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is summnary].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is summnary]; otherwise, <c>false</c>.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue(false)]
        public bool IsSummnary { get; set; }

        /// <summary>
        /// Gets or sets the display format.
        /// </summary>
        /// <value>
        /// The display format.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue("Tổng")]
        public string DisplayFormat { get; set; }

        /// <summary>
        /// Gets or sets the type of the summary.
        /// </summary>
        /// <value>
        /// The type of the summary.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue(SummaryItemType.Sum)]
        public SummaryItemType SummaryType { get; set; }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>
        /// The alignment.
        /// </value>
        [Category("XtraColumn")]
        public HorzAlignment Alignment { get; set; }

        /// <summary>
        /// Gets or sets the type of the column.
        /// </summary>
        /// <value>
        /// The type of the column.
        /// </value>
        [Category("ColumnType")]
        public UnboundColumnType ColumnType { get; set; }

        /// <summary>
        /// Gets or sets the fixed column.
        /// </summary>
        /// <value>
        /// The fixed column.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue(FixedStyle.None)]
        public FixedStyle FixedColumn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow edit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow edit]; otherwise, <c>false</c>.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue(true)]
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow edit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow edit]; otherwise, <c>false</c>.
        /// </value>
        [Category("XtraColumn")]
        [DefaultValue(true)]
        public string ToolTip { get; set; }
        public bool IsSummaryText { get; internal set; }
        public bool IsNumeric { get; set; }
    }
}
