/***********************************************************************
 * <copyright file="B03b_BCTCModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// B03b_BCTCModel
    /// </summary>
    public class B03b_BCTCModel
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

        public decimal Col1 { get; set; }
        public decimal Col2 { get; set; }
    }
}
