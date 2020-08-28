/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
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
    public class InvoiceFormNumberFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IInvoiceFormNumberDao InvoiceFormNumberDao = DataAccess.DataAccess.InvoiceFormNumberDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<InvoiceFormNumberEntity> GetInvoiceFormNumbers()
        {
            return InvoiceFormNumberDao.GetInvoiceFormNumbers();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<InvoiceFormNumberEntity> GetInvoiceFormNumbersByActive()
        {
            return InvoiceFormNumberDao.GetInvoiceFormNumbersByActive();
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public InvoiceFormNumberEntity GetInvoiceFormNumber(string invoiceFormNumberId)
        {
            return InvoiceFormNumberDao.GetInvoiceFormNumberById(invoiceFormNumberId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public InvoiceFormNumberResponse InsertInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            var response = new InvoiceFormNumberResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!invoiceFormNumberEntity.Validate())
                {
                    foreach (string error in invoiceFormNumberEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var voucherList = InvoiceFormNumberDao.GetInvoiceFormNumbersByCode(invoiceFormNumberEntity.InvoiceFormNumberCode.Trim());
                if (voucherList != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mẫu số hóa đơn mã " + invoiceFormNumberEntity.InvoiceFormNumberCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                invoiceFormNumberEntity.InvoiceFormNumberId = Guid.NewGuid().ToString();
                response.Message = InvoiceFormNumberDao.InsertInvoiceFormNumber(invoiceFormNumberEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InvoiceFormNumberId = invoiceFormNumberEntity.InvoiceFormNumberId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public InvoiceFormNumberResponse InsertInvoiceFormNumberConvert(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            var response = new InvoiceFormNumberResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!invoiceFormNumberEntity.Validate())
                {
                    foreach (string error in invoiceFormNumberEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var voucherList = InvoiceFormNumberDao.GetInvoiceFormNumbersByCode(invoiceFormNumberEntity.InvoiceFormNumberCode.Trim());
                if (voucherList != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mẫu số hóa đơn mã " + invoiceFormNumberEntity.InvoiceFormNumberCode.Trim() + @" đã tồn tại !";
                    return response;
                }
                response.Message = InvoiceFormNumberDao.InsertInvoiceFormNumber(invoiceFormNumberEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InvoiceFormNumberId = invoiceFormNumberEntity.InvoiceFormNumberId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }


        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public InvoiceFormNumberResponse UpdateInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            var response = new InvoiceFormNumberResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!invoiceFormNumberEntity.Validate())
                {
                    foreach (string error in invoiceFormNumberEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var voucherList = InvoiceFormNumberDao.GetInvoiceFormNumbersByCode(invoiceFormNumberEntity.InvoiceFormNumberCode.Trim());
                if (voucherList != null)
                {
                    if (voucherList.InvoiceFormNumberId != invoiceFormNumberEntity.InvoiceFormNumberId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mẫu số hóa đơn mã " + invoiceFormNumberEntity.InvoiceFormNumberCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = InvoiceFormNumberDao.UpdateInvoiceFormNumber(invoiceFormNumberEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InvoiceFormNumberId = invoiceFormNumberEntity.InvoiceFormNumberId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public InvoiceFormNumberResponse DeleteInvoiceFormNumber(string invoiceFormNumberId)
        {
            var response = new InvoiceFormNumberResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var invoiceFormNumberEntity = InvoiceFormNumberDao.GetInvoiceFormNumberById(invoiceFormNumberId);
                response.Message = InvoiceFormNumberDao.DeleteInvoiceFormNumber(invoiceFormNumberEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BADeposit_InvoiceFormNumber") ||
                        response.Message.Contains("FK_CAReceipt_InvoiceFormNumber"))
                    {
                        response.Message = @"Bạn không thể xóa mẫu số hóa đơn " + invoiceFormNumberEntity.InvoiceFormNumberCode + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.InvoiceFormNumberId = invoiceFormNumberEntity.InvoiceFormNumberId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public InvoiceFormNumberResponse DeleteInvoiceFormNumberConvert( )
        {
            var response = new InvoiceFormNumberResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
              
                response.Message = InvoiceFormNumberDao.DeleteInvoiceFormNumberConvert();
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

    }
}
