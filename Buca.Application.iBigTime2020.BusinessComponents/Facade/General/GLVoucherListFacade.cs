using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.General;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.General;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.General
{
    public class GLVoucherListFacade
    {

        private static readonly IGLVoucherListDao GlVoucherListDao = DataAccess.DataAccess.GlVoucherListDao;

        private static readonly IGLVoucherListDetailDao GlVoucherListDetailDao =
            DataAccess.DataAccess.GlVoucherListDetailDao;

        private static readonly IGLVoucherListParamaterDao GlVoucherListParamaterDao =
            DataAccess.DataAccess.GlVoucherListParamater;

        public List<GLVoucherListEntity> GetGLVoucherList()
        {
            return GlVoucherListDao.GetGLVoucherList();
        }

        public List<GLPaymentListEntity> GetGLPaymentList()
        {
            return GlVoucherListDao.GetGLPaymentList();
        }

        public List<GLVoucherListParamaterEntity> GetVoucherListParamater(int type)
        {
            return GlVoucherListParamaterDao.GetGlVoucherListParamater(type);
        }
        public GLVoucherListEntity GetVoucherListbyRefNo(string refNo)
        {
            return GlVoucherListDao.GetGLVoucherListByRefNo(refNo);
        }

        public GLVoucherListEntity GetVoucherLisbyRefId(string refId)
        {
            var glVoucher = GlVoucherListDao.GetGLVoucherListByRefId(refId);
            if (glVoucher != null)
            {
                glVoucher.GlVoucherListDetails =
                    GlVoucherListDetailDao.GetGLVoucherListDetailByRefId(glVoucher.RefId);
            }
            return glVoucher;
        }
        public GLPaymentListEntity GetPaymentLisbyRefId(string refId)
        {
            var glPayment = GlVoucherListDao.GetGLPaymentListByRefId(refId);
            if (glPayment != null)
            {
                glPayment.GLPaymentListDetails =
                    GlVoucherListDetailDao.GetGLPaymentListDetailByRefId(glPayment.RefId);
            }
            return glPayment;
        }

        public GLVoucherListResponse InsertGLVoucherList(GLVoucherListEntity glVoucherListEntity)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherListEntity.Validate())
                {
                    foreach (var error in glVoucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = GlVoucherListDao.GetGLVoucherListByRefNo(glVoucherListEntity.RefNo.Trim(), glVoucherListEntity.RefDate);
                    if (faDepreciation != null && faDepreciation.RefDate.Year == glVoucherListEntity.RefDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ " + glVoucherListEntity.RefNo + @" đã tồn tại !";
                        return response;
                    }

                    glVoucherListEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = GlVoucherListDao.InsertGLVoucherList(glVoucherListEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Insert detail
                    if (glVoucherListEntity.GlVoucherListDetails != null)
                    {
                        foreach (var glVoucherListDetail in glVoucherListEntity.GlVoucherListDetails)
                        {
                            glVoucherListDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherListDetail.RefId = glVoucherListEntity.RefId;
                            response.Message = GlVoucherListDetailDao.InsertGLVoucherListDetail(glVoucherListDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                    }
                    #endregion

                    scope.Complete();
                }
                response.RefId = glVoucherListEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public GLVoucherListResponse InsertGLPaymentList(GLPaymentListEntity glVoucherListEntity)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherListEntity.Validate())
                {
                    foreach (var error in glVoucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = GlVoucherListDao.GetGLPaymentListByRefNo(glVoucherListEntity.RefNo.Trim(), glVoucherListEntity.RefDate);
                    if (faDepreciation != null && faDepreciation.RefDate.Year == glVoucherListEntity.RefDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ " + glVoucherListEntity.RefNo + @" đã tồn tại !";
                        return response;
                    }

                    glVoucherListEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = GlVoucherListDao.InsertGLPaymentList(glVoucherListEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Insert detail
                    if (glVoucherListEntity.GLPaymentListDetails != null)
                    {
                        foreach (var glVoucherListDetail in glVoucherListEntity.GLPaymentListDetails)
                        {
                            glVoucherListDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherListDetail.RefId = glVoucherListEntity.RefId;
                            response.Message = GlVoucherListDetailDao.InsertGLPaymentListDetail(glVoucherListDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                    }
                    #endregion

                    scope.Complete();
                }
                response.RefId = glVoucherListEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public GLVoucherListResponse UpdateGlVoucherList(GLVoucherListEntity glVoucherListEntity)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherListEntity.Validate())
                {
                    foreach (var error in glVoucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = GlVoucherListDao.GetGLVoucherListByRefNo(glVoucherListEntity.RefNo.Trim(), glVoucherListEntity.RefDate);
                    if (faDepreciation != null && faDepreciation.RefDate.Year == glVoucherListEntity.RefDate.Year)
                    {
                        if (faDepreciation.RefId != glVoucherListEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ " + glVoucherListEntity.RefNo + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = GlVoucherListDao.UpdateGLVoucherList(glVoucherListEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }



                    #region Delete detail 
                    // Xóa bảng glVoucherDetail
                    response.Message = GlVoucherListDetailDao.DeleteGLVoucherListDetailByRefId(glVoucherListEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }



                    if (glVoucherListEntity.GlVoucherListDetails != null)
                        foreach (var glVoucherListDetail in glVoucherListEntity.GlVoucherListDetails)
                        {
                            glVoucherListDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherListDetail.RefId = glVoucherListEntity.RefId;
                            response.Message = GlVoucherListDetailDao.InsertGLVoucherListDetail(glVoucherListDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion



                    scope.Complete();
                }
                response.RefId = glVoucherListEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }


        public GLVoucherListResponse UpdateGlPaymentList(GLPaymentListEntity glVoucherListEntity)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!glVoucherListEntity.Validate())
                {
                    foreach (var error in glVoucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var faDepreciation = GlVoucherListDao.GetGLPaymentListByRefNo(glVoucherListEntity.RefNo.Trim(), glVoucherListEntity.RefDate);
                    if (faDepreciation != null && faDepreciation.RefDate.Year == glVoucherListEntity.RefDate.Year)
                    {
                        if (faDepreciation.RefId != glVoucherListEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ " + glVoucherListEntity.RefNo + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = GlVoucherListDao.UpdateGLPaymentList(glVoucherListEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }



                    #region Delete detail 
                    // Xóa bảng glVoucherDetail
                    //response.Message = GlVoucherListDetailDao.DeleteGLVoucherListDetailByRefId(glVoucherListEntity.RefId);
                    response.Message = GlVoucherListDetailDao.DeleteGLPaymentListDetailByRefId(glVoucherListEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }



                    if (glVoucherListEntity.GLPaymentListDetails != null)
                        foreach (var glVoucherListDetail in glVoucherListEntity.GLPaymentListDetails)
                        {
                            glVoucherListDetail.RefDetailId = Guid.NewGuid().ToString();
                            glVoucherListDetail.RefId = glVoucherListEntity.RefId;
                            response.Message = GlVoucherListDetailDao.InsertGLPaymentListDetail(glVoucherListDetail);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion



                    scope.Complete();
                }
                response.RefId = glVoucherListEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public GLVoucherListResponse DeleteGLVoucherList(string refId)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var glVoucherEntity = GlVoucherListDao.GetGLVoucherListByRefId(refId);
                if (glVoucherEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {


                    // Xóa Detail
                    response.Message = GlVoucherListDetailDao.DeleteGLVoucherListDetailByRefId(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = GlVoucherListDao.DeleteGLVoucherList(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        

        public GLVoucherListResponse DeleteGLPaymentList(string refId)
        {
            var response = new GLVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var glVoucherEntity = GlVoucherListDao.GetGLPaymentListByRefId(refId);
                if (glVoucherEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {

                    // Xóa Detail
                    response.Message = GlVoucherListDetailDao.DeleteGLPaymentListDetailByRefId(glVoucherEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = GlVoucherListDao.DeleteGLPaymentList(glVoucherEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefId = glVoucherEntity.RefId;
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
