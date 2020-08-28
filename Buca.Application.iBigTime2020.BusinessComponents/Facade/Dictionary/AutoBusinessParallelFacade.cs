using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class AutoBusinessParallelFacade
    {

        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AutoBusinessParallelEntity> GetAutoBusinessParallels()
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallels();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive)
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallelsByActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="autoBusinessId">The automatic business identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public AutoBusinessParallelEntity GetAutoBusinessParallel(string autoBusinessId)
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallel(autoBusinessId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="autoBusinessEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AutoBusinessParallelResponse InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessEntity)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                autoBusinessEntity.AutoBusinessParallelId = Guid.NewGuid().ToString();
                response.Message = AutoBusinessParallelDao.InsertAutoBusinessParallel(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AutoBusinessParallelResponse InsertAutoBusinessParallelConvert(AutoBusinessParallelEntity autoBusinessEntity)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

               
                response.Message = AutoBusinessParallelDao.InsertAutoBusinessParallel(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="autoBusinessEntity">The automatic business entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AutoBusinessParallelResponse UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessEntity)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.Message = AutoBusinessParallelDao.UpdateAutoBusinessParallel(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="autoBusinessParallelId">The automatic business parallel identifier.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public AutoBusinessParallelResponse DeleteAutoBusinessParallel(string autoBusinessParallelId)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var autoBusinessParallelEntity = AutoBusinessParallelDao.GetAutoBusinessParallel(autoBusinessParallelId);
                response.Message = AutoBusinessParallelDao.DeleteAutoBusinessParallel(autoBusinessParallelEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessParallelEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
            
        }

        public AutoBusinessParallelResponse DeleteAutoBusinessParallelConvert()
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                
                response.Message = AutoBusinessParallelDao.DeleteAutoBusinessParallelConvert();
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
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
