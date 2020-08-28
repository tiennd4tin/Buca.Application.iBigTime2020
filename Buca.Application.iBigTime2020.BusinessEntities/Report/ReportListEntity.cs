/***********************************************************************
 * <copyright file="ReportListEntity.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report
{
    public class ReportListEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListEntity"/> class.
        /// </summary>
        public ReportListEntity()
        {
            AddRule(new ValidateRequired("ReportId"));
            AddRule(new ValidateRequired("ReportName"));
        }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>The report identifier.</value>
        public string ReportId { get; set; }

        /// <summary>
        /// Gets or sets the name of the report.
        /// </summary>
        /// <value>The name of the report.</value>
        public string ReportName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the report file.
        /// </summary>
        /// <value>The report file.</value>
        public string ReportFile { get; set; }

        /// <summary>
        /// Gets or sets the output assembly.
        /// </summary>
        /// <value>The output assembly.</value>
        public string OutputAssembly { get; set; }

        /// <summary>
        /// Gets or sets the name of the input type.
        /// </summary>
        /// <value>The name of the input type.</value>
        public string InputTypeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the function report.
        /// </summary>
        /// <value>The name of the function report.</value>
        public string FunctionReportName { get; set; }

        /// <summary>
        /// Gets or sets the name of the procedure.
        /// </summary>
        /// <value>The name of the procedure.</value>
        public string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the type of the track.
        /// </summary>
        /// <value>The type of the track.</value>
        public int? TrackType { get; set; }

        /// <summary>
        /// Gets or sets the proc name by lot.
        /// </summary>
        /// <value>The proc name by lot.</value>
        public string ProcNameByLot { get; set; }

        /// <summary>
        /// Gets or sets the proc name voucher list.
        /// </summary>
        /// <value>The proc name voucher list.</value>
        public string ProcNameVoucherList { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ReportListEntity"/> is inactive.
        /// </summary>
        /// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
        public bool Inactive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [print voucher default].
        /// </summary>
        /// <value><c>null</c> if [print voucher default] contains no value, <c>true</c> if [print voucher default]; otherwise, <c>false</c>.</value>
        public bool PrintVoucherDefault { get; set; }

        /// <summary>
        /// Gets or sets the type of the licence.
        /// </summary>
        /// <value>The type of the licence.</value>
        public int? LicenceType { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int? RefType { get; set; }

        /// <summary>
        /// Gets or sets the particularity.
        /// </summary>
        /// <value>The particularity.</value>
        public int? Particularity { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is report be configured.
        /// </summary>
        /// <value><c>null</c> if [is report be configured] contains no value, <c>true</c> if [is report be configured]; otherwise, <c>false</c>.</value>
        public bool? IsReportBeConfigured { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ReportListEntity"/> is standard.
        /// </summary>
        /// <value><c>null</c> if [standard] contains no value, <c>true</c> if [standard]; otherwise, <c>false</c>.</value>
        public bool? Standard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow batch printing].
        /// </summary>
        /// <value><c>null</c> if [allow batch printing] contains no value, <c>true</c> if [allow batch printing]; otherwise, <c>false</c>.</value>
        public bool? AllowBatchPrinting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [get parameter from dialog].
        /// </summary>
        /// <value><c>null</c> if [get parameter from dialog] contains no value, <c>true</c> if [get parameter from dialog]; otherwise, <c>false</c>.</value>
        public bool? GetParamFromDialog { get; set; }

        /// <summary>
        /// Gets or sets the data band sort report identifier.
        /// </summary>
        /// <value>The data band sort report identifier.</value>
        public string DataBandSortReportId { get; set; }

        /// <summary>
        /// Gets or sets the type of the report.
        /// </summary>
        /// <value>The type of the report.</value>
        public int ReportType { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int? Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ReportListEntity"/> is visible.
        /// </summary>
        /// <value><c>null</c> if [visible] contains no value, <c>true</c> if [visible]; otherwise, <c>false</c>.</value>
        public bool? Visible { get; set; }
    }
}
