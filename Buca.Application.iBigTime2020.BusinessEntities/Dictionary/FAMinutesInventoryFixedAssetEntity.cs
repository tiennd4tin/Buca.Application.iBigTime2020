// ***********************************************************************
// Assembly         : Buca.Application.iBigTime2020.BusinessEntities
// Author           : thangnd
// Created          : 05-04-2018
//
// Last Modified By : thangnd
// Last Modified On : 05-04-2018
// ***********************************************************************
// <copyright file="FAMinutesInventoryFixedAssetEntity.cs" company="BuCA JSC">
//     Copyright ©  2014 BuCA JSC
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class FAMinutesInventoryFixedAssetEntity.
    /// </summary>
    public class FAMinutesInventoryFixedAssetEntity : BusinessEntities
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
