/***********************************************************************
 * <copyright file="StockEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class StockEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockEntity"/> class.
        /// </summary>
        public StockEntity()
        {
            AddRule(new ValidateRequired("StockCode"));
            AddRule(new ValidateRequired("StockName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockEntity" /> class.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="stockCode">The stock code.</param>
        /// <param name="stockName">Name of the stock.</param>
        /// <param name="description">The description.</param>
        /// <param name="defaultAccountNumber">The default account number.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public StockEntity(string stockId, string stockCode, string stockName, string description,string defaultAccountNumber, bool isActive)
        {
            StockId = stockId;
            StockCode = stockCode;
            StockName = stockName;
            Description = description;
            DefaultAccountNumber = defaultAccountNumber;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
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
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
