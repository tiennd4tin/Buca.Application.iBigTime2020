/***********************************************************************
 * <copyright file="AutoNumberEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// AutoNumberEntity
    /// </summary>
    public class AutoIDEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoIDEntity"/> class.
        /// </summary>
        public AutoIDEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoIDEntity" /> class.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refTypeCategoryName">Name of the reference type category.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="value">The value.</param>
        /// <param name="isSystem">The is system.</param>
        /// <param name="lengthOfValue">The length of value.</param>
        public AutoIDEntity(int refTypeId, string refTypeCategoryName, string prefix, string suffix, decimal value, bool isSystem, int lengthOfValue)
            : this()
        {
            RefTypeCategoryId = refTypeId;
            RefTypeCategoryName = refTypeCategoryName;
            Prefix = prefix;
            Suffix = suffix;
            Value = value;
            IsSystem = isSystem;
            LengthOfValue = lengthOfValue;
        }

        /// <summary>
        /// Gets or sets the reference type category identifier.
        /// </summary>
        /// <value>The reference type category identifier.</value>
        public int RefTypeCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference type category.
        /// </summary>
        /// <value>The name of the reference type category.</value>
        public string RefTypeCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the length of value.
        /// </summary>
        /// <value>The length of value.</value>
        public int LengthOfValue { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }
    }
}
