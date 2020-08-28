/***********************************************************************
 * <copyright file="MinutesInventoryToolModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, January 11, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, January 11, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory
{
    /// <summary>
    /// Class MinutesInventoryToolModel.
    /// </summary>
    public class MinutesInventoryToolModel
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentId { get; set; }
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Gets or sets the sum inventory category.
        /// </summary>
        /// <value>The sum inventory category.</value>
        public string SumInventoryCategory { get; set; }
        /// <summary>
        /// Gets or sets the inventory category identifier.
        /// </summary>
        /// <value>The inventory category identifier.</value>
        public string InventoryCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the name of the inventory category.
        /// </summary>
        /// <value>The name of the inventory category.</value>
        public string InventoryCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        public string InventoryItemId { get; set; }
        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemName { get; set; }
        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }
        /// <summary>
        /// Gets or sets the quantity book.
        /// </summary>
        /// <value>The quantity book.</value>
        public decimal QuantityBook { get; set; }
        /// <summary>
        /// Gets or sets the amount book.
        /// </summary>
        /// <value>The amount book.</value>
        public decimal AmountBook { get; set; }
        /// <summary>
        /// Gets or sets the quantity minutes.
        /// </summary>
        /// <value>The quantity minutes.</value>
        public decimal QuantityMinutes { get; set; }
        /// <summary>
        /// Gets or sets the amount minutes.
        /// </summary>
        /// <value>The amount minutes.</value>
        public decimal AmountMinutes { get; set; }

    }
}
