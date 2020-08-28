/***********************************************************************
 * <copyright file="GridLookUpItem.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace BuCA.Application.iBigTime2020.Report.CommonClass 
{
    /// <summary>
    /// GridLookUpItem class
    /// </summary>
    internal sealed class GridLookUpItem
    {
        /// <summary>
        /// Gets or sets the data value.
        /// </summary>
        /// <value>
        /// The data value.
        /// </value>
        public object DataValue { get; set; }

        /// <summary>
        /// Gets or sets the data member.
        /// </summary>
        /// <value>
        /// The data member.
        /// </value>
        public object DataMember { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridLookUpItem"/> class.
        /// </summary>
        /// <param name="dataValue">The data value.</param>
        /// <param name="dataMember">The data member.</param>
        public GridLookUpItem(string dataValue, string dataMember)
        {
            DataValue = dataValue;
            DataMember = dataMember;
        }
    }
}
