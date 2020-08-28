/***********************************************************************
 * <copyright file="RefTypeEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// RefTypeEntity
    /// </summary>
    public class RefTypeCategoryEntity : BusinessEntities
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
        /// Gets or sets the default debit account identifier.
        /// </summary>
        /// <value>The default debit account identifier.</value>
        public string DefaultDebitAccountId { get; set; }

        /// <summary>
        /// Gets or sets the default credit account identifier.
        /// </summary>
        /// <value>The default credit account identifier.</value>
        public string DefaultCreditAccountId { get; set; }
    }
}
