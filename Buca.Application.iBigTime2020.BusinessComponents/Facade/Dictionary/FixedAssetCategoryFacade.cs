using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class FixedAssetCategoryFacade
    {
        private static readonly IFixedAssetCategoryDao FixedAssetCategoryDao = DataAccess.DataAccess.FixedAssetCategoryDao;
        public List<FixedAssetCategoryEntity> GetFixedAssetCategories()
        {
            return FixedAssetCategoryDao.GetFixedAssetCategories();
        }
        public FixedAssetCategoryEntity GetFixedAssetCategoryId(string fixedAssetCategoryId)
        {
            return FixedAssetCategoryDao.GetFixedAssetCategory(fixedAssetCategoryId);
        }

        public FixedAssetCategoryEntity GetFixedAssetCategoryCode(string fixedAssetCategoryCode)
        {
            return FixedAssetCategoryDao.GetFixedAssetCategorybyCode(fixedAssetCategoryCode);
        }
        public FixedAssetCategoryResponse InsertFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategoryEntity)
        {
            var response = new FixedAssetCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fixedAssetCategoryEntity.Validate())
                {
                    foreach (string error in fixedAssetCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }


                var fixedAssetCategoryCheck = FixedAssetCategoryDao.GetFixedAssetCategorybyCode(fixedAssetCategoryEntity.FixedAssetCategoryCode);
                if (fixedAssetCategoryCheck != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nhóm " + fixedAssetCategoryEntity.FixedAssetCategoryCode + " đã tồn tại";
                    return response;
                }

                fixedAssetCategoryEntity.FixedAssetCategoryId = Guid.NewGuid().ToString();

                response.fixedAssetCategoryId = fixedAssetCategoryEntity.FixedAssetCategoryId;
                response.Message = FixedAssetCategoryDao.InsertFixedAssetCategory(fixedAssetCategoryEntity);
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public FixedAssetCategoryResponse InsertFixedAssetCategoryConvert(FixedAssetCategoryEntity fixedAssetCategoryEntity)
        {
            var response = new FixedAssetCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fixedAssetCategoryEntity.Validate())
                {
                    foreach (string error in fixedAssetCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }


                var fixedAssetCategoryCheck = FixedAssetCategoryDao.GetFixedAssetCategorybyCode(fixedAssetCategoryEntity.FixedAssetCategoryCode);
                if (fixedAssetCategoryCheck != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nhóm " + fixedAssetCategoryEntity.FixedAssetCategoryCode + " đã tồn tại";
                    return response;
                }

                response.fixedAssetCategoryId = fixedAssetCategoryEntity.FixedAssetCategoryId;
                response.Message = FixedAssetCategoryDao.InsertFixedAssetCategory(fixedAssetCategoryEntity);
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public FixedAssetCategoryResponse UpdateFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategoryEntity)
        {
            var response = new FixedAssetCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!fixedAssetCategoryEntity.Validate())
                {
                    foreach (string error in fixedAssetCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var fixedAssetCategoryCheck = FixedAssetCategoryDao.GetFixedAssetCategorybyCode(fixedAssetCategoryEntity.FixedAssetCategoryCode);
                if (fixedAssetCategoryCheck != null)
                {
                    if (fixedAssetCategoryCheck.FixedAssetCategoryId !=
                        fixedAssetCategoryEntity.FixedAssetCategoryId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã nhóm " + fixedAssetCategoryEntity.FixedAssetCategoryCode + " đã tồn tại";
                        return response;
                    }
                }

                response.Message = FixedAssetCategoryDao.UpdateFixedAssetCategory(fixedAssetCategoryEntity);
                response.fixedAssetCategoryId = fixedAssetCategoryEntity.FixedAssetCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public FixedAssetCategoryResponse DeleteFixedAssetCategory(string fixedAssetCategoryId)
        {
            var response = new FixedAssetCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var fixedAssetCategoryEntity = FixedAssetCategoryDao.GetFixedAssetCategory(fixedAssetCategoryId);
                response.Message = FixedAssetCategoryDao.DeleteFixedAssetCategory(fixedAssetCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.fixedAssetCategoryId = fixedAssetCategoryEntity.FixedAssetCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Bạn không thế xóa nhóm TSCĐ cha";
                return response;
            }
        }
        public FixedAssetCategoryResponse DeleteFixedAssetCategoryConvert()
        {
            var response = new FixedAssetCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
                response.Message = FixedAssetCategoryDao.DeleteFixedAssetCategoryConvert();
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
                response.Message = "Bạn không thế xóa nhóm TSCĐ cha";
                return response;
            }
        }


    }


}
