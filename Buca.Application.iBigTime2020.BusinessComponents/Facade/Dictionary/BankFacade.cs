/***********************************************************************
 * <copyright file="BankFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;



namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// BankFacade
    /// </summary>
    public class BankFacade
    {
        private static readonly IBankDao BankDao = DataAccess.DataAccess.BankDao;

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BankEntity GetBanks(string bankId)
        {

            return BankDao.GetBank(bankId);
        }
        public IList<BankEntity> GetBanks()
        {
            return BankDao.GetBanks();
        }
        public IList<BankEntity> GetBankByActive(bool isActive)
        {

            return BankDao.GetBanksByActive(isActive);
        }
        public IList<BankEntity> GetProjectBank(string projectId)
        {

            return BankDao.GetProjectBank(projectId);
        }
        public List<BankEntity> GetBanksByBankAccount(string bankAccount)
        {
            return BankDao.GetBanksByBankAccount(bankAccount);
        }
        public BankResponse InsertBank(BankEntity bank)
        {
            var response = new BankResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bank.Validate())
                {
                    foreach (string error in bank.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var banks = BankDao.GetBanksByBankAccount(bank.BankAccount);
                if (banks.Count > 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Số tài khoản " + bank.BankAccount + @" đã tồn tại !";
                    return response;
                }
                bank.BankId = Guid.NewGuid().ToString();
                response.Message = BankDao.InsertBank(bank);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BankId = bank.BankId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public BankResponse InsertBankConvert(BankEntity bank)
        {
            var response = new BankResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bank.Validate())
                {
                    foreach (string error in bank.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var banks = BankDao.GetBanksByBankAccount(bank.BankAccount);
                if (banks.Count > 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Số tài khoản " + bank.BankAccount + @" đã tồn tại !";
                    return response;
                }
                response.Message = BankDao.InsertBank(bank);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BankId = bank.BankId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public BankResponse UpdateBank(BankEntity bank)
        {
            var response = new BankResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bank.Validate())
                {
                    foreach (string error in bank.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = BankDao.UpdateBank(bank);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BankId = bank.BankId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public BankResponse DeleteBank(string bankId)
        {
            var response = new BankResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var bankEntity = BankDao.GetBank(bankId);
                response.Message = BankDao.DeleteBank(bankEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK"))
                    {
                        response.Message = @"Bạn không thể xóa tài khoản " + bankEntity.BankAccount + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                        response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BankId = bankEntity.BankId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }


            /// <summary>
            /// Sets the banks.
            /// </summary>
            /// <param name="request">The request.</param>
            /// <returns></returns>
            //public BankResponse SetBanks(BankRequest request)
            //{
            //    var response = new BankResponse();

            //    var bankEntity = request.Bank;
            //    if (request.Action != PersistType.Delete)
            //    {
            //        if (!bankEntity.Validate())
            //        {
            //            foreach (var error in bankEntity.ValidationErrors)
            //                response.Message += error + Environment.NewLine;
            //            response.Acknowledge = AcknowledgeType.Failure;
            //            return response;
            //        }
            //    }
            //    try
            //    {
            //        if (request.Action == PersistType.Insert)
            //        {
            //            var banks = BankDao.GetBanksByBankAccount(bankEntity.BankAccount);
            //            if (banks.Count > 0)
            //            {
            //                response.Acknowledge = AcknowledgeType.Failure;
            //                response.Message = @"Mã số tài khoản ngân hàng " + bankEntity.BankAccount + @" đã tồn tại !";
            //                return response;
            //            }
            //            bankEntity.BankId = BankDao.InsertBank(bankEntity);
            //            response.Message = null;
            //        }
            //        else if (request.Action == PersistType.Update) 
            //            response.Message = BankDao.UpdateBank(bankEntity);
            //        else
            //        {
            //            var bankForUpdate = BankDao.GetBank(request.BankId);
            //            response.Message = BankDao.DeleteBank(bankForUpdate);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        response.Acknowledge = AcknowledgeType.Failure;
            //        response.Message = ex.Message;
            //        return response;
            //    }
            //    response.BankId = bankEntity != null ? bankEntity.BankId : 0;
            //    if (response.Message == null)
            //    {
            //        response.Acknowledge = AcknowledgeType.Success;
            //        response.RowsAffected = 1;
            //    }
            //    else
            //    {
            //        response.Acknowledge = AcknowledgeType.Failure;
            //        response.RowsAffected = 0;
            //    }

            //    return response;
            //}
        }

        public BankResponse DeleteBankConvert( )
        {
            var response = new BankResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = BankDao.DeleteBankConvert();

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
