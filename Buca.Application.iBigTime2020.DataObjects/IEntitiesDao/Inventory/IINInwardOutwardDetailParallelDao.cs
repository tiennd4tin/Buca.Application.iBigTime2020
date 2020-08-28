using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory
{
   public interface IINInwardOutwardDetailParallelDao
    {
        /// <summary>
        /// Deletes the INInwardOutwardDetailParallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteINInwardOutwardDetailParallelId(string refId);

        /// <summary>
        /// Gets the INInwardOutwardDetailParallel reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;INInwardOutwardDetailParallelEntity&gt;.</returns>
        List<INInwardOutwardDetailParallelEntity> GetINInwardOutwardDetailParallelbyRefId(string refId);

        /// <summary>
        /// Inserts the INInwardOutwardDetailParallel.
        /// </summary>
        /// <param name="InwardOutwardDetail">The INInwardOutwardDetailParallel.</param>
        /// <returns>System.String.</returns>
        string InsertINInwardOutwardDetailParallel(INInwardOutwardDetailParallelEntity InwardOutwardDetail);

        /// <summary>
        /// Updates the INInwardOutwardDetailParallel.
        /// </summary>
        /// <param name="InwardOutwardDetail">The INInwardOutwardDetailParallel.</param>
        /// <returns>System.String.</returns>
        string UpdateINInwardOutwardDetailParallel(INInwardOutwardDetailParallelEntity InwardOutwardDetail);

    }

}