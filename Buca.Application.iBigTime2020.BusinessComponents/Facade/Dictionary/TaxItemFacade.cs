using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class TaxItemFacade
    {
        /// <summary>
        /// The tax item DAO
        /// </summary>
        private static readonly ITaxItemDao TaxItemDao = DataAccess.DataAccess.TaxItemDao;
        /// <summary>
        /// Gets the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>TaxItemEntity.</returns>
        public TaxItemEntity GetTaxItem(string taxItemId)
        {
            return TaxItemDao.GetTaxItem(taxItemId);
        }
        /// <summary>
        /// Gets the tax items.
        /// </summary>
        /// <returns>List&lt;TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItems()
        {
            return TaxItemDao.GetTaxItems();
        }
        /// <summary>
        /// Gets the tax items by tax item code.
        /// </summary>
        /// <param name="taxItemCode">The tax item code.</param>
        /// <returns>List&lt;TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItemsByTaxItemCode(string taxItemCode)
        {
            return TaxItemDao.GetTaxItemsByTaxItemCode(taxItemCode);
        }
        /// <summary>
        /// Gets the tax items by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItemsByActive(bool isActive)
        {
            return TaxItemDao.GetTaxItemsByActive(isActive);
        }
        /// <summary>
        /// Inserts the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>TaxItemResponse.</returns>
        public TaxItemResponse InsertTaxItem(TaxItemEntity taxItem)
        {
            var response = new TaxItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!taxItem.Validate())
                {
                    foreach (string error in taxItem.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                taxItem.TaxItemId = Guid.NewGuid().ToString();
                response.Message = TaxItemDao.InsertTaxItem(taxItem);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxItemId = taxItem.TaxItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        /// <summary>
        /// Updates the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>TaxItemResponse.</returns>
        public TaxItemResponse UpdateTaxItem(TaxItemEntity taxItem)
        {
            var response = new TaxItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!taxItem.Validate())
                {
                    foreach (string error in taxItem.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = TaxItemDao.UpdateTaxItem(taxItem);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxItemId = taxItem.TaxItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        /// <summary>
        /// Deletes the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>TaxItemResponse.</returns>
        public TaxItemResponse DeleteTaxItem(string taxItemId)
        {
            var response = new TaxItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = TaxItemDao.DeleteTaxItem(taxItemId);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxItemId = taxItemId;
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
