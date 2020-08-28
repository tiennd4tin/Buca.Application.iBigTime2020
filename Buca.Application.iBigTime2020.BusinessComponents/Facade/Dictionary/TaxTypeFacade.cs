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
   public class TaxTypeFacade
    {
        private static readonly ITaxTypeDao TaxTypeDao = DataAccess.DataAccess.TaxTypeDao;
        public TaxTypeEntity GetTaxType(string taxTypeId)
        {
            return TaxTypeDao.GetTaxType(taxTypeId);
        }
        public List<TaxTypeEntity> GetTaxTypes()
        {
            return TaxTypeDao.GetTaxTypes();
        }
        public List<TaxTypeEntity> GetTaxTypesByTaxTypeCode(string taxTypeCode)
        {
            return TaxTypeDao.GetTaxTypesByTaxTypeCode(taxTypeCode);
        }
        public List<TaxTypeEntity> GetTaxTypesByActive(bool isActive)
        {
            return TaxTypeDao.GetTaxTypesByActive(isActive);
        }
        public TaxTypeResponse InsertTaxType(TaxTypeEntity taxType)
        {
            var response = new TaxTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!taxType.Validate())
                {
                    foreach (string error in taxType.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                taxType.TaxTypeId = Guid.NewGuid().ToString();
                response.Message = TaxTypeDao.InsertTaxType(taxType);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxTypeId = taxType.TaxTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public TaxTypeResponse UpdateTaxType(TaxTypeEntity taxType)
        {
            var response = new TaxTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!taxType.Validate())
                {
                    foreach (string error in taxType.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = TaxTypeDao.UpdateTaxType(taxType);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxTypeId = taxType.TaxTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public TaxTypeResponse DeleteTaxType(string taxTypeId)
        {
            var response = new TaxTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = TaxTypeDao.DeleteTaxType(taxTypeId);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.TaxTypeId = taxTypeId;
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
