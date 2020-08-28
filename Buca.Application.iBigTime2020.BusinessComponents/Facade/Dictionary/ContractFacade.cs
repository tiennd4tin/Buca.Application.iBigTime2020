/***********************************************************************
 * <copyright file="ContractFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
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
using System.Linq;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class ContractFacade
    {
        private static readonly IContractDao ContractDao = DataAccess.DataAccess.ContractDao;
        //private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns></returns>
        public ContractEntity GetContract(string ContractId)
        {
            return ContractDao.GetContract(ContractId);
        }
        public IList<ContractDetailEntity> GetContractDetail(string ContractId)
        {
            return ContractDao.GetContractDetail(ContractId);
        }

        /// <summary>
        /// Gets the Contracts.
        /// </summary>
        /// <returns></returns>
        public List<ContractEntity> GetContracts()
        {
            return ContractDao.GetContracts();
        }
        public List<ContractDetailEntity> GetContractDetails()
        {
            return ContractDao.GetContractDetails();
        }

        /// <summary>
        /// Gets the Contracts.
        /// </summary>
        /// <returns></returns>
        public List<ContractEntity> GetContractsActive(bool isActive)
        {
            return ContractDao.GetContractsByActive(isActive);
        }

        public ContractEntity GetContractByContractNo(string contractNo)
        {
            return ContractDao.GetContractByContractNo(contractNo);
        }

        public List<ContractEntity> GetContractByProjectId(string projectId)
        {
            return ContractDao.GetContractByProjectId(projectId);
        }

        /// <summary>
        /// Inserts the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public ContractResponse InsertContract(ContractEntity Contract)
        {
            var response = new ContractResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var Contracts = ContractDao.GetContractByContractNo(Contract.ContractNo);
                if (Contracts != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số hợp đồng " + Contract.ContractNo + @" đã tồn tại!";
                   
                    return response;
                }
                Contract.ContractId = Guid.NewGuid().ToString();
                response.Message = ContractDao.InsertContract(Contract);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ContractId = Contract.ContractId;
                foreach (var item in Contract.ContractDetails)
                {
                    item.ContractDetailID = Guid.NewGuid().ToString();
                    item.ContractID = Contract.ContractId;
                    item.Stt = Contract.ContractDetails.IndexOf(item);
                    ContractDao.InsertContractDetail(item);
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
        /// Updates the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public ContractResponse UpdateContract(ContractEntity Contract)
        {
            var response = new ContractResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var Contracts = ContractDao.GetContractByContractNo(Contract.ContractNo);
                if (Contracts != null && Contract.ContractId != Contracts.ContractId)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Số hợp đồng " + Contract.ContractNo + @" đã tồn tại!";

                    return response;
                }

                response.Message = ContractDao.UpdateContract(Contract);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ContractId = Contract.ContractId;
                foreach (var item in Contract.ContractDetails)
                {
                    if (item.ContractDetailID == null)
                    {
                        item.ContractDetailID = Guid.NewGuid().ToString();
                        item.ContractID = Contract.ContractId;
                        item.Stt = Contract.ContractDetails.IndexOf(item);
                        ContractDao.InsertContractDetail(item);
                    }
                    else ContractDao.UpdateContractDetail(item);
                    
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
        /// Deletes the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public ContractResponse DeleteContract(string ContractId)
        {
            var response = new ContractResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var Contract = ContractDao.GetContract(ContractId);
                var ContractDetail = ContractDao.GetContractDetail(ContractId);
                response.Message = ContractDao.DeleteContract(ContractId);
                
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK")
                        )
                        response.Message = @"Bạn không thể xóa hợp đồng " + Contract.ContractNo + " , vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ContractId = ContractId;
                foreach (var item in ContractDetail)
                {
                    ContractDao.DeleteContractDetail(ContractId);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public string DeleteContractDetail(string ContractDetailId)
        {           
            return ContractDao.DeleteDetail(ContractDetailId);
        }
    }
}
