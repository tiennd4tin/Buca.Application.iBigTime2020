/***********************************************************************
 * <copyright file="C21HDDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 9, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 9, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C20HDDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the price unit.
        /// </summary>
        /// <value>The price unit.</value>
        public decimal PriceUnit { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>The item code.</value>
        public string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>The item identifier.</value>
        public string InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the STT.
        /// </summary>
        /// <value>The STT.</value>
        public int Stt { get; set; }
    }
}
