/***********************************************************************
 * <copyright file="AutoNumberFacade.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// AutoNumberFacade
    /// </summary>
    public class AutoIDFacade
    {
        private static readonly IAutoIDDao AutoIDDao = DataAccess.DataAccess.AutoIDDao;
        private static readonly IRefTypeDao RefTypeDao = DataAccess.DataAccess.RefTypeDao;

        /// <summary>
        /// Gets the type of the automatic identifier by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>AutoIDEntity.</returns>
        public AutoIDEntity GetAutoIDByRefType(int refTypeId)
        {
            //get reftypecategory
            var refType = RefTypeDao.GetRefType(refTypeId);
            return refType != null ? AutoIDDao.GetAutoIDByRefTypeCategoryId((int)refType.RefTypeCategoryId) : new AutoIDEntity();
        }

        /// <summary>
        /// Gets the automatic i ds.
        /// </summary>
        /// <returns>IList&lt;AutoIDEntity&gt;.</returns>
        public IList<AutoIDEntity> GetAutoIDs()
        {
            return AutoIDDao.GetAutoIDs();
        }

        public AutoIDResponse UpdateAutoIDs(List<AutoIDEntity> autoIdEntityAutoIDEntities)
        {
            var response = new AutoIDResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                foreach (var autoIdEntity in autoIdEntityAutoIDEntities)
                {
                    if (!autoIdEntity.Validate())
                    {
                        foreach (var error in autoIdEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    using (var scope = new TransactionScope())
                    {
                        response.Message = AutoIDDao.UpdateAutoID(autoIdEntity);
                        if (!string.IsNullOrEmpty(response.Message))
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        scope.Complete();
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
