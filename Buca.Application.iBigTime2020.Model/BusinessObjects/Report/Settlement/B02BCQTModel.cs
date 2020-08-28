/***********************************************************************
 * <copyright file="B02BCQTModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Monday, August 27, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
 
 namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Settlement
{
    /// <summary>
    /// B02BCQTModel
    /// </summary>
    public class B02BCQTModel
    {
        /// <summary>
        /// Gets or sets the index of the report item.
        /// </summary>
        /// <value>
        /// The index of the report item.
        /// </value>
        public string ReportItemIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the report item.
        /// </summary>
        /// <value>
        /// The name of the report item.
        /// </value>
        public string ReportItemName { get; set; }

        /// <summary>
        /// Gets or sets the report item code.
        /// </summary>
        /// <value>
        /// The report item code.
        /// </value>
        public string ReportItemCode { get; set; }
    }
}
