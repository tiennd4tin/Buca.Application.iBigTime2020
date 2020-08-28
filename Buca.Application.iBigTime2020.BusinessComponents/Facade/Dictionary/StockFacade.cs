/***********************************************************************
 * <copyright file="StockFacade.cs" company="BUCA JSC">
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
    /// Class StockFacade.
    /// </summary>
  public class StockFacade
    {
        /// <summary>
        /// The stock DAO
        /// </summary>
        private static readonly IStockDao StockDao = DataAccess.DataAccess.StockDao;

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <returns>List&lt;StockEntity&gt;.</returns>
        public List<StockEntity> GetStocks()
        {
            return StockDao.GetStocks();
        }

        /// <summary>
        /// Gets the stocks by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;StockEntity&gt;.</returns>
        public List<StockEntity> GetStocksByIsActive(bool isActive)
        {
            return StockDao.GetStocksByIsActive(isActive);
        }

        /// <summary>
        /// Gets the stock by identifier.
        /// </summary>
        /// <param name="stockId">The budget chapter identifier.</param>
        /// <returns>StockEntity.</returns>
        public StockEntity GetStockById(string stockId)
        {
            return StockDao.GetStock(stockId);
        }

        public StockResponse InsertStock(StockEntity stockEntity)
        {
            var response = new StockResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!stockEntity.Validate())
                {
                    foreach (string error in stockEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                stockEntity.StockId = Guid.NewGuid().ToString();
                //check ma trung
                var stockEntityExited = StockDao.GetStocksByStockCode(stockEntity.StockCode);
                if (stockEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã kho {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", stockEntityExited.StockCode);
                    return response;
                }

                response.Message = StockDao.InsertStock(stockEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.StockId = stockEntity.StockId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public StockResponse InsertStockConvert(StockEntity stockEntity)
        {
            var response = new StockResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!stockEntity.Validate())
                {
                    foreach (string error in stockEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //check ma trung
                var stockEntityExited = StockDao.GetStocksByStockCode(stockEntity.StockCode);
                if (stockEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã kho {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", stockEntityExited.StockCode);
                    return response;
                }

                response.Message = StockDao.InsertStock(stockEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.StockId = stockEntity.StockId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public StockResponse UpdateStock(StockEntity stockEntity)
        {
            var response = new StockResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!stockEntity.Validate())
                {
                    foreach (string error in stockEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //check ma trung
                var stockEntityExited = StockDao.GetStocksByStockCode(stockEntity.StockCode);
                if (stockEntityExited != null && stockEntityExited.StockCode != stockEntity.StockCode)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã kho {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", stockEntityExited.StockCode);
                    return response;
                }
                response.Message = StockDao.UpdateStock(stockEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.StockId = stockEntity.StockId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public StockResponse DeleteStock(string stockId)
        {
            var response = new StockResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var stockEntity = StockDao.GetStock(stockId);
                response.Message = StockDao.DeleteStock(stockEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    if (response.Message.Contains("FK_INInwardOutwardDetail_Stock"))
                    {
                        response.Message = string.Format("Bạn không thể xóa kho {0} vì đã có phát sinh trong chứng từ nhập kho/xuất kho", stockEntity.StockCode);
                        return response;
                    }
                    return response;
                }
                response.StockId = stockEntity.StockId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public StockResponse DeleteStockConvert()
        {
            var response = new StockResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
            
                response.Message = StockDao.DeleteStockConvert();
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
