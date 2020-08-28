/***********************************************************************
 * <copyright file="InventoryItemFacade.cs" company="BUCA JSC">
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
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{

    /// <summary>
    /// Class InventoryItemFacade.
    /// </summary>
    public class InventoryItemFacade
    {
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItems()
        {
            return InventoryItemDao.GetInventoryItems();
        }

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>InventoryItemEntity.</returns>
        public InventoryItemEntity GetInventoryItem(string inventoryItemId)
        {
            return InventoryItemDao.GetInventoryItem(inventoryItemId);
        }

        /// <summary>
        /// Gets the inventory items by is ative.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsAtive(bool isActive)
        {
            return InventoryItemDao.GetInventoryItemsByIsActive(isActive);
        }

        /// <summary>
        /// Gets the inventory items by is tool.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsTool(bool isTool)
        {
            return InventoryItemDao.GetInventoryItemsByIsTool(isTool);
        }

        /// <summary>
        /// Gets the inventory items by is tool and is active.
        /// </summary>
        /// <param name="isTool">if set to <c>true</c> [is tool].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsToolAndIsActive(bool isTool, bool isActive)
        {
            return InventoryItemDao.GetInventoryItemsByIsToolAndIsActive(isTool, isActive);
        }

        public List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            return InventoryItemDao.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive, inventoryCategoryCode);
        }

        /// <summary>
        /// Gets the inventory items by inventory category code.
        /// </summary>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        public IList<InventoryItemEntity> GetInventoryItemsByInventoryCategoryCode(string inventoryCategoryCode)
        {
            return InventoryItemDao.GetInventoryItemsByInventoryCategoryCode(inventoryCategoryCode);
        }

        /// <summary>
        /// Gets the inventory items by inventory itemdestinations.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="RefDate">The reference date.</param>
        /// <param name="RefOrder">The reference order.</param>
        /// <param name="UnitPriceDecimalDigitNumber">The unit price decimal digit number.</param>
        /// <returns></returns>
        public IList<InventoryItemdestinationEntity> GetInventoryItemsByInventoryItemdestinations(string inventoryItemId, DateTime RefDate, int RefOrder, int UnitPriceDecimalDigitNumber)
        {
            return InventoryItemDao.GetInventoryItemsByInventoryItemdestinations(inventoryItemId, RefDate, RefOrder, UnitPriceDecimalDigitNumber);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="inventoryItemEntity">The account category entity.</param>
        /// <returns>InventoryItemResponse.</returns>
        public InventoryItemResponse InsertInventoryItem(InventoryItemEntity inventoryItemEntity)
        {
            var response = new InventoryItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var inventoryItemEntityExited = InventoryItemDao.GetInventoryItemByInventoryItemCode(inventoryItemEntity.InventoryItemCode, inventoryItemEntity.IsTool);
                if (inventoryItemEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(inventoryItemEntityExited.IsTool ?
                        @"Mã công cụ, dụng cụ {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác" :
                        @"Mã vật tư {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", inventoryItemEntityExited.InventoryItemCode);
                    return response;
                }

                //dm cai thang nao code cu insert 2 bang ma deo lam transaction code nhu cc
                using (var scope = new TransactionScope())
                {
                    inventoryItemEntity.InventoryItemId = Guid.NewGuid().ToString();
                    response.Message = InventoryItemDao.InsertInventoryItem(inventoryItemEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                    response.InventoryItemId = inventoryItemEntity.InventoryItemId;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public InventoryItemResponse InsertInventoryItemConvert(InventoryItemEntity inventoryItemEntity)
        {
            var response = new InventoryItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var inventoryItemEntityExited = InventoryItemDao.GetInventoryItemByInventoryItemCode(inventoryItemEntity.InventoryItemCode, inventoryItemEntity.IsTool);
                if (inventoryItemEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(inventoryItemEntityExited.IsTool ?
                        @"Mã công cụ, dụng cụ {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác" :
                        @"Mã vật tư {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", inventoryItemEntityExited.InventoryItemCode);
                    return response;
                }

                //dm cai thang nao code cu insert 2 bang ma deo lam transaction code nhu cc
                using (var scope = new TransactionScope())
                {
                   
                    response.Message = InventoryItemDao.InsertInventoryItem(inventoryItemEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                    response.InventoryItemId = inventoryItemEntity.InventoryItemId;
                    return response;
                }
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
        /// <returns>InventoryItemResponse.</returns>
        public InventoryItemResponse UpdateInventoryItem(InventoryItemEntity inventoryItemEntity)
        {
            var response = new InventoryItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!inventoryItemEntity.Validate())
                {
                    foreach (string error in inventoryItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                //check ma trung
                var inventoryItemEntityExited = InventoryItemDao.GetInventoryItemByInventoryItemCode(inventoryItemEntity.InventoryItemCode, inventoryItemEntity.IsTool);
                if (inventoryItemEntityExited != null && inventoryItemEntityExited.InventoryItemId != inventoryItemEntity.InventoryItemId)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(inventoryItemEntityExited.IsTool ?
                     @"Mã công cụ, dụng cụ {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác" :
                     @"Mã vật tư {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", inventoryItemEntityExited.InventoryItemCode);
                    return response;
                }

                //dm cai thang nao code cu insert 2 bang ma deo lam transaction code nhu cc
                using (var scope = new TransactionScope())
                {
                    response.Message = InventoryItemDao.UpdateInventoryItem(inventoryItemEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Nếu là công cụ dụng cụ thì Insert đồng thời vào bảng OpeningSupplyEntry
                    //if (inventoryItemEntity.IsTool && !inventoryItemEntity.IsStock)
                    //{
                    //    var openingSupplyEntry = new OpeningSupplyEntryEntity
                    //    {
                    //        RefId = inventoryItemEntity.InventoryItemId,
                    //        InventoryItemId = inventoryItemEntity.InventoryItemId,
                    //        InventoryItemCode = inventoryItemEntity.InventoryItemCode,
                    //        InventoryItemName = inventoryItemEntity.InventoryItemName,
                    //        DepartmentId = inventoryItemEntity.DepartmentId,
                    //        PostedDate = DateTime.Now,
                    //        RefType = 602
                    //    };

                    //    //xoa insert lai
                    //    var openingSupplyEntryEntity = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(inventoryItemEntity.InventoryItemId);
                    //    if (openingSupplyEntryEntity != null)
                    //    {
                    //        response.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntry(inventoryItemEntity.InventoryItemId);
                    //        if (!string.IsNullOrEmpty(response.Message))
                    //        {
                    //            response.Acknowledge = AcknowledgeType.Failure;
                    //            scope.Dispose();
                    //            return response;
                    //        }
                    //    }

                    //    response.Message = OpeningSupplyEntryDao.InsertOpeningSupplyEntry(openingSupplyEntry);
                    //    if (!string.IsNullOrEmpty(response.Message))
                    //    {
                    //        response.Acknowledge = AcknowledgeType.Failure;
                    //        scope.Dispose();
                    //        return response;
                    //    }
                    //}

                    response.InventoryItemId = inventoryItemEntity.InventoryItemId;
                    scope.Complete();
                    return response;
                }
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
        /// <returns>InventoryItemResponse.</returns>
        public InventoryItemResponse DeleteInventoryItem(string inventoryItemId)
        {
            var response = new InventoryItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var inventoryItemEntity = InventoryItemDao.GetInventoryItem(inventoryItemId);
                using (var scope = new TransactionScope())
                {
                    // Xóa trong bảng OpeningSupplyEntry
                    //var openingSupplyEntryEntity = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(inventoryItemEntity.InventoryItemId);
                    //if (openingSupplyEntryEntity != null)
                    //{
                    //    response.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntry(inventoryItemEntity.InventoryItemId);
                    //    if (!string.IsNullOrEmpty(response.Message))
                    //    {
                    //        response.Acknowledge = AcknowledgeType.Failure;
                    //        scope.Dispose();
                    //        return response;
                    //    }
                    //}
                    response.Message = InventoryItemDao.DeleteInventoryItem(inventoryItemEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        if (response.Message.Contains("FK_INInwardOutwardDetail_InventoryItem"))
                        {
                            response.Message = @"Bạn không thể xóa vật tư có mã " +
                                               inventoryItemEntity.InventoryItemCode +
                                               ", vì đã có phát sinh trong nghiệp vụ xuất nhập kho";
                        }
                        else
                        {
                            response.Message = @"Bạn không thể xóa vật tư có mã " + inventoryItemEntity.InventoryItemCode + ", vì đã có phát sinh trong chứng từ hoặc danh mục liên quan";
                        }
                        scope.Dispose();
                        return response;
                    }

                    response.InventoryItemId = inventoryItemEntity.InventoryItemId;
                    scope.Complete();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }


        public InventoryItemResponse DeleteInventoryItemConvert()
        {
            var response = new InventoryItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
              
                using (var scope = new TransactionScope())
                {
                    // Xóa trong bảng OpeningSupplyEntry
                    //var openingSupplyEntryEntity = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(inventoryItemEntity.InventoryItemId);
                    //if (openingSupplyEntryEntity != null)
                    //{
                    //    response.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntry(inventoryItemEntity.InventoryItemId);
                    //    if (!string.IsNullOrEmpty(response.Message))
                    //    {
                    //        response.Acknowledge = AcknowledgeType.Failure;
                    //        scope.Dispose();
                    //        return response;
                    //    }
                    //}
                    response.Message = InventoryItemDao.DeleteInventoryItemConvert();
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                      
                        scope.Dispose();
                        return response;
                    }

                   
                    scope.Complete();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        public InventoryItemEntity GetUnitsInStock(string inventoryItemId, string stockId, DateTime Todate )
        {
            return InventoryItemDao.GetUnitsInStock(inventoryItemId, stockId, Todate);
        }

        /// <summary>
        /// Calculates the outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        public string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            return InventoryItemDao.CalculateOutwardPrice(fromDate, toDate, inventoryItemId);
        }
    }
}
