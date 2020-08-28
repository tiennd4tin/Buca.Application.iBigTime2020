/***********************************************************************
 * <copyright file="DBOptionFacade.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// DBOptionFacade
    /// </summary>
    public class DBOptionFacade
    {
        private static readonly IDBOptionDao DBOptionDao = DataAccess.DataAccess.DBOptionDao;
        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <returns>List&lt;DBOptionEntity&gt;.</returns>
        public DBOptionEntity GetDBOption(string optionId)
        {
            return DBOptionDao.GetDBOption(optionId);
        }

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns>List&lt;DBOptionEntity&gt;.</returns>
        public List<DBOptionEntity> GetDBOptions()
        {
            return DBOptionDao.GetDBOptions();
        }

        /// <summary>
        /// Gets the database options by system.
        /// </summary>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <returns>List&lt;DBOptionEntity&gt;.</returns>
        public List<DBOptionEntity> GetDBOptionsBySystem(bool isSystem)
        {
            return DBOptionDao.GetDBOptionsBySystem(isSystem);
        }

        /// <summary>
        /// Gets the type of the database options by value.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>List&lt;DBOptionEntity&gt;.</returns>
        public List<DBOptionEntity> GetDBOptionsByValueType(int valueType)
        {
            return DBOptionDao.GetDBOptionsByValueType(valueType);
        }

        public DBOptionResponse UpdateDBOption(DBOptionEntity dbOptionEntity)
        {
            var response = new DBOptionResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!dbOptionEntity.Validate())
                {
                    foreach (string error in dbOptionEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = DBOptionDao.UpdateDBOption(dbOptionEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.OptionId = dbOptionEntity.OptionId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dbOptionEntities">The database option entities.</param>
        /// <returns>DBOptionResponse.</returns>
        public DBOptionResponse UpdateDBOption(List<DBOptionEntity> dbOptionEntities)
        {
            var response = new DBOptionResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                foreach (var dbOptionEntity in dbOptionEntities)
                {
                    if (!dbOptionEntity.Validate())
                    {
                        foreach (string error in dbOptionEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    response.Message = DBOptionDao.UpdateDBOption(dbOptionEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Gets the options for database information.
        /// </summary>
        /// <returns></returns>
        public List<DBOptionEntity> GetOptionsForDbInfo()
        {
            return DBOptionDao.GetOptionsForDbInfo();
        }
    }
}
