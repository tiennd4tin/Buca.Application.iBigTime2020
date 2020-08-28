/***********************************************************************
 * <copyright file="AccountCategoryCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
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
    /// class AccountCategoryCategoryEntity
    /// </summary>
    public class AccountCategoryEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoryEntity" /> class.
        /// </summary>
        public AccountCategoryEntity()
        {
            AddRule(new ValidateRequired("AccountCategoryId"));
            AddRule(new ValidateRequired("AccountCategoryName"));
        }

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public string AccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account category.
        /// </summary>
        /// <value>The name of the account category.</value>
        public string AccountCategoryName { get; set; }

        /// <summary>
        /// Gets the kind of the account category.
        /// </summary>
        /// <value>The kind of the account category.</value>
        public int AccountCategoryKind { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget source].
        /// </summary>
        /// <value><c>true</c> if [detail by budget source]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget chapter].
        /// </summary>
        /// <value><c>true</c> if [detail by budget chapter]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetChapter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget kind item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget kind item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetKindItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget sub item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget sub item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetSubItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by method distribute].
        /// </summary>
        /// <value><c>true</c> if [detail by method distribute]; otherwise, <c>false</c>.</value>
        public bool DetailByMethodDistribute { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by accounting object].
        /// </summary>
        /// <value><c>true</c> if [detail by accounting object]; otherwise, <c>false</c>.</value>
        public bool DetailByAccountingObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by activity].
        /// </summary>
        /// <value><c>true</c> if [detail by activity]; otherwise, <c>false</c>.</value>
        public bool DetailByActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by project].
        /// </summary>
        /// <value><c>true</c> if [detail by project]; otherwise, <c>false</c>.</value>
        public bool DetailByProject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by task].
        /// </summary>
        /// <value><c>true</c> if [detail by task]; otherwise, <c>false</c>.</value>
        public bool DetailByTask { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by supply].
        /// </summary>
        /// <value><c>true</c> if [detail by supply]; otherwise, <c>false</c>.</value>
        public bool DetailBySupply { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by inventory item].
        /// </summary>
        /// <value><c>true</c> if [detail by inventory item]; otherwise, <c>false</c>.</value>
        public bool DetailByInventoryItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by fixed asset].
        /// </summary>
        /// <value><c>true</c> if [detail by fixed asset]; otherwise, <c>false</c>.</value>
        public bool DetailByFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by bank account].
        /// </summary>
        /// <value><c>true</c> if [detail by bank account]; otherwise, <c>false</c>.</value>
        public bool DetailByBankAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by fund].
        /// </summary>
        /// <value><c>true</c> if [detail by fund]; otherwise, <c>false</c>.</value>
        public bool DetailByFund { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
