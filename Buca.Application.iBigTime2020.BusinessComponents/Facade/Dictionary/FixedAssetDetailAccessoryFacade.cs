using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class FixedAssetDetailAccessoryFacade
    {
        private static readonly IFixedAssetDetailAccessoryDao FixedAssetDetailAccessoryDao = DataAccess.DataAccess.FixedAssetDetailAccessoryDao;

        /// <summary>
        /// Gets the by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetDetailAccessoryEntity> GetByFixedAssetId(string fixedAssetId)
        {
            return FixedAssetDetailAccessoryDao.GetFixedAssetByFixedAssetId(fixedAssetId);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FixedAssetDetailAccessoryResponse Delete(int id)
        {
            var response = new FixedAssetDetailAccessoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = FixedAssetDetailAccessoryDao.DeleteFixedAssetDetailAccessory(id);
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
        /// Inserts the specified fixed asset detail accessory entity.
        /// </summary>
        /// <param name="fixedAssetDetailAccessoryEntity">The fixed asset detail accessory entity.</param>
        /// <returns></returns>
        public FixedAssetDetailAccessoryResponse Insert(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessoryEntity)
        {
            var response = new FixedAssetDetailAccessoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fixedAssetDetailAccessoryEntity.Validate())
                {
                    foreach (string error in fixedAssetDetailAccessoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = FixedAssetDetailAccessoryDao.InsertFixedAssetDetailAccessory(fixedAssetDetailAccessoryEntity);
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
        /// Updates the specified fixed asset detail accessory entity.
        /// </summary>
        /// <param name="fixedAssetDetailAccessoryEntity">The fixed asset detail accessory entity.</param>
        /// <returns></returns>
        public FixedAssetDetailAccessoryResponse Update(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessoryEntity)
        {
            var response = new FixedAssetDetailAccessoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fixedAssetDetailAccessoryEntity.Validate())
                {
                    foreach (string error in fixedAssetDetailAccessoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = FixedAssetDetailAccessoryDao.UpdateFixedAssetDetailAccessory(fixedAssetDetailAccessoryEntity);
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
    }

    public class FixedAssetDetailAccessoryResponse : ResponseBase
    {
        public FixedAssetDetailAccessoryEntity FixedAssetDetailAccessoryEntity { get; set; }
        public string FixedAssetDetailAccessoryId { get; set; }
    }
}
