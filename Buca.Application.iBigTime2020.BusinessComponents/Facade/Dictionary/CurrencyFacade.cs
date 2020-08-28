/***********************************************************************
 * <copyright file="CurrencyFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class CurrencyFacade
    {
        private static readonly ICurrencyDao ICurrencyDao = DataAccess.DataAccess.CurrencyDao;

        public List<CurrencyEntity> GetCurrencies()
        {
            return ICurrencyDao.GetCurrencies();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;AccountCategoryEntity&gt;.</returns>
        public List<CurrencyEntity> GetCurrenciesByIsActive(bool isActive)
        {
            return ICurrencyDao.GetCurrenciesByActive();
        }
        public List<CurrencyEntity> GetCurrenciesByIsMain(bool isMain)
        {
            return ICurrencyDao.GetCurrenciesByIsMain();
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="currencyId">The account currency identifier.</param>
        /// <returns>AccountCategoryEntity.</returns>
        public CurrencyEntity GetCurrencyById(string currencyId)
        {
            return ICurrencyDao.GetCurrency(currencyId);
        }
        public CurrencyEntity GetCurrencyByCode(string currencyCode)
        {
            return ICurrencyDao.GetCurrenciesByCurrencyCode(currencyCode);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="currencyEntity">The account currency entity.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public CurrencyResponse InsertCurrency(CurrencyEntity currencyEntity)
        {
            var response = new CurrencyResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!currencyEntity.Validate())
                {
                    foreach (string error in currencyEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                currencyEntity.CurrencyId = Guid.NewGuid().ToString();
                var currencyExited = ICurrencyDao.GetCurrenciesByCurrencyCode(currencyEntity.CurrencyCode);
                if (currencyExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã tiền tệ " + currencyExited.CurrencyCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                currencyEntity.CurrencyId = ICurrencyDao.InsertCurrency(currencyEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CurrencyId = currencyEntity.CurrencyId;
                return response;
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
        /// <param name="accountCategoryEntity">The account category entity.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public CurrencyResponse UpdateCurrency(CurrencyEntity currencyEntity)
        {
            var response = new CurrencyResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!currencyEntity.Validate())
                {
                    foreach (string error in currencyEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var currencyExited = ICurrencyDao.GetCurrenciesByCurrencyCode(currencyEntity.CurrencyCode);
                if (currencyExited != null)
                {
                    if (!currencyExited.CurrencyId.Equals(currencyEntity.CurrencyId))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tiền tệ " + currencyExited.CurrencyCode.Trim() + @" đã tồn tại!";
                        return response;
                    }
                }

                response.Message = ICurrencyDao.UpdateCurrency(currencyEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CurrencyId = currencyEntity.CurrencyId;
                return response;
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
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public CurrencyResponse DeleteCurrency(string currencyId)
        {
            var response = new CurrencyResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var currencyEntity = ICurrencyDao.GetCurrency(currencyId);
                response.Message = ICurrencyDao.DeleteCurrency(currencyEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BABankTransfer_Currency") ||
                        response.Message.Contains("FK_BADeposit_Currency") ||
                        response.Message.Contains("FK_BAWithDraw_Currency") ||
                        response.Message.Contains("FK_BUBudgetReserve_Currency") ||
                        response.Message.Contains("FK_BUPlanReceipt_CurrencyCode") ||
                        response.Message.Contains("FK_BUPlanWithdraw_Currency") ||
                        response.Message.Contains("FK_CAReceipt_Currency_CurrenyID") ||
                        response.Message.Contains("FK_GLVoucher_Currency_CurrencyCode"))
                    {
                        response.Message = @"Bạn không thể xóa mã tiền tệ " + currencyEntity.CurrencyCode +
                                           " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CurrencyId = currencyEntity.CurrencyId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public CurrencyResponse DeleteCurrencyConvert()
        {
            var response = new CurrencyResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
          
                response.Message = ICurrencyDao.DeleteCurrencyConvert();

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
