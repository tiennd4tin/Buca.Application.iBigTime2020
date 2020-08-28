using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class FundStructureFacade
    {
        private static readonly IFundStructureDao FundStructureDao = DataAccess.DataAccess.FundStructureDao;

        public FundStructureEntity GetFundStructure(string fundStructureId)
        {
            return FundStructureDao.GetFundStructure(fundStructureId);
        }
        public List<FundStructureEntity> GetFundStructures()
        {
            return FundStructureDao.GetFundStructures();
        }

        public List<FundStructureEntity> GetFundStructuresByFundStructureCode(string fundStructureCode)
        {
            return FundStructureDao.GetFundStructuresByFundStructureCode(fundStructureCode);
        }
        public List<FundStructureEntity> GetProjectsByActive(bool isActive)
        {
            return FundStructureDao.GetFundStructuresByActive(isActive);
        }
        public FundStructureResponse InsertFundStructure(FundStructureEntity fundStructure)
        {
            var response = new FundStructureResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var fundStructureEntity = FundStructureDao.GetFundStructuresByFundStructureCode(fundStructure.FundStructureCode.Trim()).ToList();
                if(fundStructureEntity.Count != 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã khoản chi " +fundStructure.FundStructureCode.Trim()+ @" đã tồn tại!";
                    return response;
                }
                if (!fundStructure.Validate())
                {
                    foreach (string error in fundStructure.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                fundStructure.FundStructureId = Guid.NewGuid().ToString();
                response.Message = FundStructureDao.InsertFundStructure(fundStructure);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.FundStructureId = fundStructure.FundStructureId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public FundStructureResponse InsertFundStructureConvert(FundStructureEntity fundStructure)
        {
            var response = new FundStructureResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var fundStructureEntity = FundStructureDao.GetFundStructuresByFundStructureCode(fundStructure.FundStructureCode.Trim()).ToList();
                if (fundStructureEntity.Count != 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã khoản chi " + fundStructure.FundStructureCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!fundStructure.Validate())
                {
                    foreach (string error in fundStructure.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
               
                response.Message = FundStructureDao.InsertFundStructure(fundStructure);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.FundStructureId = fundStructure.FundStructureId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public FundStructureResponse UpdateFundStructure(FundStructureEntity fundStructure)
        {
            var response = new FundStructureResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fundStructure.Validate())
                {
                    foreach (string error in fundStructure.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = FundStructureDao.UpdateFundStructure(fundStructure);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.FundStructureId = fundStructure.FundStructureId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public FundStructureResponse DeleteFundStructure(string fundStructureId)
        {
            var response = new FundStructureResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var fundStructureEntity = FundStructureDao.GetFundStructure(fundStructureId);
                response.Message = FundStructureDao.DeleteFundStructure(fundStructureId);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_OriginalGeneralLedger_FundStructure") || (response.Message.Contains("FK_AccountingObject_FundStructure")))
                        response.Message = @"Bạn không thể xóa khoản chi " + fundStructureEntity.FundStructureCode + " , vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.FundStructureId = fundStructureId;
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public FundStructureResponse DeleteFundStructureConvert()
        {
            var response = new FundStructureResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
              
                response.Message = FundStructureDao.DeleteFundStructureConvert();
             
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
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
