/***********************************************************************
 * <copyright file="DepartmentFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, September 26, 2017
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
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    ///     DepartmentFacade
    /// </summary>
    public class DepartmentFacade
    {
        /// <summary>
        ///     The department DAO
        /// </summary>
        private static readonly IDepartmentDao DepartmentDao = new SqlServerDepartmentDao();

        /// <summary>
        ///     Gets the department entities.
        /// </summary>
        /// <returns></returns>
        public IList<DepartmentEntity> GetDepartmentEntities()
        {
            return DepartmentDao.GetDepartments();
        }

        /// <summary>
        ///     Gets the department entity.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string departmentId)
        {
            return DepartmentDao.GetDepartment(departmentId);
        }

        /// <summary>
        /// Gets the department entity by code.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <returns>DepartmentEntity.</returns>
        public DepartmentEntity GetDepartmentEntityByCode(string departmentCode)
        {
            return DepartmentDao.GetDepartmentByDepartmentCode(departmentCode);
        }

        /// <summary>
        /// Gets the department entities active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<DepartmentEntity> GetDepartmentEntitiesActive(bool isActive)
        {
            return DepartmentDao.GetDepartmentsByActive(isActive);
        }

        /// <summary>
        ///     Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public DepartmentResponse DeleteDepartment(string departmentId)
        {
            var response = new DepartmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var departmentEntity = DepartmentDao.GetDepartment(departmentId);
                if (departmentEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = DepartmentDao.DeleteDepartment(departmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Message = @"Bạn không thể xóa phòng ban '" + departmentEntity.DepartmentCode + "' vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.DepartmentId = departmentEntity.DepartmentId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public DepartmentResponse DeleteDepartmentConvert()
        {
            var response = new DepartmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
              
                using (var scope = new TransactionScope())
                {
                    response.Message = DepartmentDao.DeleteDepartmentConvert();
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                     
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
             
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }




        /// <summary>
        ///     Inserts the department.
        /// </summary>
        /// <param name="departmentEntity">The department entity.</param>
        /// <returns></returns>
        public DepartmentResponse InsertDepartment(DepartmentEntity departmentEntity)
        {
            var response = new DepartmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!departmentEntity.Validate())
                {
                    foreach (var error in departmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    departmentEntity.DepartmentId = Guid.NewGuid().ToString();
                    response.Message = DepartmentDao.InsertDepartment(departmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.DepartmentId = departmentEntity.DepartmentId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public DepartmentResponse InsertDepartmentConvert(DepartmentEntity departmentEntity)
        {
            var response = new DepartmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!departmentEntity.Validate())
                {
                    foreach (var error in departmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = DepartmentDao.InsertDepartment(departmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.DepartmentId = departmentEntity.DepartmentId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Updates the department.
        /// </summary>
        /// <param name="departmentEntity">The department entity.</param>
        /// <returns></returns>
        public DepartmentResponse UpdateDepartment(DepartmentEntity departmentEntity)
        {
            var response = new DepartmentResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!departmentEntity.Validate())
                {
                    foreach (var error in departmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = DepartmentDao.UpdateDepartment(departmentEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.DepartmentId = departmentEntity.DepartmentId;
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