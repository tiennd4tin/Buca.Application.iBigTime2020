// ***********************************************************************
// Assembly         : Buca.Application.iBigTime2020.Model
// Author           : thangnd
// Created          : 05-03-2018
//
// Last Modified By : thangnd
// Last Modified On : 05-03-2018
// ***********************************************************************
// <copyright file="FAMinutesInventoryFixedAsset.cs" company="by adguard">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset
{
    /// <summary>
    /// Class FAMinutesInventoryFixedAsset.
    /// </summary>
    public class FAMinutesInventoryFixedAssetModel
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the representation.
        /// </summary>
        /// <value>The representation.</value>
        public string Representation { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }
    }
}
