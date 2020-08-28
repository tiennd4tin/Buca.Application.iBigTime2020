/***********************************************************************
 * <copyright file="AutoNumberModel.cs" company="BUCA JSC">
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
 * LinhMC: bổ sung thêm trường lấy số tự động cho loại tiền ĐP ValueLocalCurency
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AutoNumberModel
    /// </summary>
    public class AutoIDModel
    {
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
        public int Value { get; set; }

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
