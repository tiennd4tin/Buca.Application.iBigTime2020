// ***********************************************************************
// Assembly         : Buca.Application.iBigTime2020.BusinessEntities
// Author           : thangnd
// Created          : 05-03-2018
//
// Last Modified By : thangnd
// Last Modified On : 05-03-2018
// ***********************************************************************
// <copyright file="MinutesGetCountFixedAssetModel.cs" company="BuCA JSC">
//     Copyright ©  2014 BuCA JSC
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// Class MinutesGetCountFixedAssetEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class MinutesGetCountFixedAssetEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>The fixed asset identifier.</value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>The fixed asset code.</value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>The name of the fixed asset.</value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the used date.
        /// </summary>
        /// <value>The used date.</value>
        public int UsedDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>To date.</value>
        public int ToDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [sum fixed asset category].
        /// </summary>
        /// <value><c>true</c> if [sum fixed asset category]; otherwise, <c>false</c>.</value>
        public bool SumFixedAssetCategory { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>The fixed asset category identifier.</value>
        public string FixedAssetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>The fixed asset category code.</value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>The name of the fixed asset category.</value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>The org price.</value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>The depreciation credit amount.</value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>The remaining amount.</value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the made in.
        /// </summary>
        /// <value>The made in.</value>
        public string MadeIn { get; set; }

        public decimal BookQuantity { get; set; }
    }
}
