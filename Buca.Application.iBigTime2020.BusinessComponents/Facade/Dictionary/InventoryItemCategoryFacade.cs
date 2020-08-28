/***********************************************************************
 * <copyright file="InventoryItemCategoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
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
    /// Class InventoryItemCategoryFacade.
    /// </summary>
    public class InventoryItemCategoryFacade
    {
        private static readonly IInventoryItemCategoryDao InventoryItemCategoryDao = DataAccess.DataAccess.InventoryItemCategoryDao;

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategories()
        {
            return InventoryItemCategoryDao.GetInventoryItemCategories();
        }

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>InventoryItemCategoryEntity.</returns>
        public InventoryItemCategoryEntity GetInventoryItemCategory(string inventoryItemId)
        {
            return InventoryItemCategoryDao.GetGetInventoryItemCategory(inventoryItemId);
        }

        /// <summary>
        /// Gets the inventory items by is ative.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsAtive(bool isActive)
        {
            return InventoryItemCategoryDao.GetInventoryItemCategoriesByIsActive(isActive);
        }

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool)
        {
            return InventoryItemCategoryDao.GetInventoryItemCategoriesByIsTool(isTool);
        }

        /// <summary>
        /// Gets the inventory item categories by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemCategoryEntity&gt;.</returns>
        public List<InventoryItemCategoryEntity> GetInventoryItemCategoriesByIsTool(bool isTool, bool isActive)
        {
            return InventoryItemCategoryDao.GetInventoryItemCategoriesByIsTool(isTool, isActive);
        }

        public List<InventoryItemCategoryEntity> GetInventoryItemCategories(bool isActive)
        {
            return InventoryItemCategoryDao.GetInventoryItemCategories( isActive);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="inventoryItemEntity">The account category entity.</param>
        /// <returns>InventoryItemCategoryResponse.</returns>
        public InventoryItemCategoryResponse InsertInventoryItemCategory(InventoryItemCategoryEntity inventoryItemEntity)
        {
            var response = new InventoryItemCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //inventoryItemEntity.InventoryItemCategoryId = InventoryItemCategoryDao.InsertInventoryItemCategory(inventoryItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InventoryItemCategoryId = inventoryItemEntity.InventoryItemCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public InventoryItemCategoryResponse InsertInventoryItemCategoryConvert(InventoryItemCategoryEntity inventoryItemEntity)
        {
            var response = new InventoryItemCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                inventoryItemEntity.InventoryItemCategoryId = InventoryItemCategoryDao.InsertInventoryItemCategory(inventoryItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //response.InventoryItemCategoryId = inventoryItemEntity.InventoryItemCategoryId;
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
        /// Updates the account category.
        /// </summary>
        /// <param name="inventoryItemEntity">The account category entity.</param>
        /// <returns>InventoryItemCategoryResponse.</returns>
        public InventoryItemCategoryResponse UpdateInventoryItemCategory(InventoryItemCategoryEntity inventoryItemEntity)
        {
            var response = new InventoryItemCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //response.Message = InventoryItemCategoryDao.UpdateInventoryItemCategory(inventoryItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InventoryItemCategoryId = inventoryItemEntity.InventoryItemCategoryId;
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
        /// Deletes the account category.
        /// </summary>
        /// <param name="inventoryItemId">The account category identifier.</param>
        /// <returns>InventoryItemCategoryResponse.</returns>
        public InventoryItemCategoryResponse DeleteInventoryItemCategory(string inventoryItemId)
        {
            var response = new InventoryItemCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var inventoryItemEntity = InventoryItemCategoryDao.GetGetInventoryItemCategory(inventoryItemId);
                //response.Message = InventoryItemCategoryDao.DeleteInventoryItemCategory(inventoryItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InventoryItemCategoryId = inventoryItemEntity.InventoryItemCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public InventoryItemCategoryResponse DeleteInventoryItemCategoryConvert()
        {
            var response = new InventoryItemCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
                response.Message = InventoryItemCategoryDao.DeleteInventoryItemCategoryConvert();
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
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

    }
}
