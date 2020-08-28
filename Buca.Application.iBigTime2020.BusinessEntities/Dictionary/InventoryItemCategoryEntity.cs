/***********************************************************************
 * <copyright file="InventoryItemCategoryEntity.cs" company="BUCA JSC">
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
    /// <summary>
    /// Class InventoryItemCategoryEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class InventoryItemCategoryEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemCategoryEntity" /> class.
        /// </summary>
        public InventoryItemCategoryEntity()
        {
            AddRule(new ValidateRequired("InventoryItemCategoryCode"));
            AddRule(new ValidateRequired("InventoryItemCategoryName"));
        }

        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        public string InventoryItemCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value><c>true</c> if this instance is parent; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is tool.
        /// </summary>
        /// <value><c>true</c> if this instance is tool; otherwise, <c>false</c>.</value>
        public bool IsTool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
