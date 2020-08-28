using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset
{
    /// <summary>
    /// Class MinutesGetCountFixedAssetModel.
    /// </summary>
    public class MinutesGetCountFixedAssetModel
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

        /// <summary>
        /// Gets or sets the book quantity.
        /// </summary>
        /// <value>The book quantity.</value>
        public decimal BookQuantity { get; set; }
    }
}
