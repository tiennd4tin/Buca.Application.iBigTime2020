/***********************************************************************
 * <copyright file="S26HModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, January 8, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, January 8, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory
{
    /// <summary>
    /// Class S26HModel.
    /// </summary>
    public class S26HModel
    {
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the inventory category.
        /// </summary>
        /// <value>The name of the inventory category.</value>
        public string InventoryCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the inventory category code.
        /// </summary>
        /// <value>The inventory category code.</value>
        public string InventoryCategoryCode { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime? PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime? RefDate { get; set; }
        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemName { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the decrement quantity.
        /// </summary>
        /// <value>The decrement quantity.</value>
        public decimal DecrementQuantity { get; set; }
        /// <summary>
        /// Gets or sets the decrement amount.
        /// </summary>
        /// <value>The decrement amount.</value>
        public decimal DecrementAmount { get; set; }
        /// <summary>
        /// Gets or sets the decrement unit price.
        /// </summary>
        /// <value>The decrement unit price.</value>
        public decimal DecrementUnitPrice { get; set; }
        /// <summary>
        /// Gets or sets the decrement description.
        /// </summary>
        /// <value>The decrement description.</value>
        public string DecrementDescription { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int RefOrder { get; set; }

    }
}
