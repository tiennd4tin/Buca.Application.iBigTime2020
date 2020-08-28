/***********************************************************************
 * <copyright file="EmployeeTypeFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, September 28, 2017
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
    ///     EmployeeTypeFacade
    /// </summary>
    public class EmployeeTypeFacade
    {
        /// <summary>
        ///     The employeeType DAO
        /// </summary>
        private static readonly IEmployeeTypeDao EmployeeTypeDao = new SqlServerEmployeeTypeDao();

        /// <summary>
        ///     Gets the employeeType entities.
        /// </summary>
        /// <returns></returns>
        public IList<EmployeeTypeEntity> GetEmployeeTypeEntities()
        {
            return EmployeeTypeDao.GetEmployeeTypes();
        }

        /// <summary>
        /// Gets the employee type entities active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public IList<EmployeeTypeEntity> GetEmployeeTypeEntitiesActive(bool isActive)
        {
            return EmployeeTypeDao.GetEmployeeTypesByIsActive(isActive);
        }

        /// <summary>
        ///     Gets the employeeType entity.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns></returns>
        public EmployeeTypeEntity GetEmployeeTypeEntity(string employeeTypeId)
        {
            return EmployeeTypeDao.GetEmployeeType(employeeTypeId);
        }

        /// <summary>
        ///     Deletes the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns></returns>
        public EmployeeTypeResponse DeleteEmployeeType(string employeeTypeId)
        {
            var response = new EmployeeTypeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                var employeeTypeEntity = EmployeeTypeDao.GetEmployeeType(employeeTypeId);
                if (employeeTypeEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                
                    response.Message = EmployeeTypeDao.DeleteEmployeeType(employeeTypeEntity);
                    
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        if (response.Message.Contains("FK_AccountingObject_EmployeeType_EmployeeTypeID"))
                            response.Message = @"Bạn không thể xóa loại cán bộ  " + employeeTypeEntity.EmployeeTypeId + " , vì đã có phát sinh trong danh mục Cán bộ!";
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
               
                response.EmployeeTypeId = employeeTypeEntity.EmployeeTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public EmployeeTypeResponse DeleteEmployeeTypeConvert()
        {
            var response = new EmployeeTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
             

                response.Message = EmployeeTypeDao.DeleteEmployeeTypeConvert();

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

        /// <summary>
        ///     Inserts the employeeType.
        /// </summary>
        /// <param name="employeeTypeEntity">The employeeType entity.</param>
        /// <returns></returns>
        public EmployeeTypeResponse InsertEmployeeType(EmployeeTypeEntity employeeTypeEntity)
        {
            var response = new EmployeeTypeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!employeeTypeEntity.Validate())
                {
                    foreach (var error in employeeTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    employeeTypeEntity.EmployeeTypeId = Guid.NewGuid().ToString();
                    response.Message = EmployeeTypeDao.InsertEmployeeType(employeeTypeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.EmployeeTypeId = employeeTypeEntity.EmployeeTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public EmployeeTypeResponse InsertEmployeeTypeConvert(EmployeeTypeEntity employeeTypeEntity)
        {
            var response = new EmployeeTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!employeeTypeEntity.Validate())
                {
                    foreach (var error in employeeTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var result = EmployeeTypeDao.GetEmployeeType(employeeTypeEntity.EmployeeTypeId);
                if (result ==null)
                {
                    using (var scope = new TransactionScope())
                    {
                        response.Message = EmployeeTypeDao.InsertEmployeeType(employeeTypeEntity);
                        if (!string.IsNullOrEmpty(response.Message))
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        scope.Complete();
                    }
                }
                response.EmployeeTypeId = employeeTypeEntity.EmployeeTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Updates the employeeType.
        /// </summary>
        /// <param name="employeeTypeEntity">The employeeType entity.</param>
        /// <returns></returns>
        public EmployeeTypeResponse UpdateEmployeeType(EmployeeTypeEntity employeeTypeEntity)
        {
            var response = new EmployeeTypeResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!employeeTypeEntity.Validate())
                {
                    foreach (var error in employeeTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = EmployeeTypeDao.UpdateEmployeeType(employeeTypeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.EmployeeTypeId = employeeTypeEntity.EmployeeTypeId;
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