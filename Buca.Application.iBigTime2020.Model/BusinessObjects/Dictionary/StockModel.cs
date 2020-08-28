/***********************************************************************
 * <copyright file="StockModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class StockModel.
    /// </summary>
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the StockId identifier.
        /// </summary>
        /// <value>
        /// The StockId identifier.
        /// </value>
        public string StockId { get; set; }

        /// <summary>
        /// Gets or sets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        public string StockCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the default account number.
        /// </summary>
        /// <value>The default account number.</value>
        public string DefaultAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>The is active.</value>
        public bool IsActive { get; set; }
    }
}
