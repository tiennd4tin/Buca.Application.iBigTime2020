/***********************************************************************
 * <copyright file="IBudgetCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   AnhNT
 * Email:    anhnt@buca.vn
 * Website:
 * Create Date: 10 Jun 2020
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// interface IContractDao
    /// </summary>
    public interface IContractDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        ContractEntity GetContract(string contractId);
        List<ContractDetailEntity> GetContractDetail(string ContractId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractNo"></param>
        /// <returns></returns>
        ContractEntity GetContractByContractNo(string contractNo);
        List<ContractEntity> GetContractByProjectId(string projectId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ContractEntity> GetContracts();
        List<ContractDetailEntity> GetContractDetails();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        List<ContractEntity> GetContractsByActive(bool isActive);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contract"></param>
        /// <returns></returns>
        string InsertContract(ContractEntity Contract);
        string InsertContractDetail(ContractDetailEntity ContractDetail);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Contract"></param>
        /// <returns></returns>
        string UpdateContract(ContractEntity Contract);
        string UpdateContractDetail(ContractDetailEntity contractDetail);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContractId"></param>
        /// <returns></returns>
        string DeleteContract(string ContractId);
        string DeleteContractDetail(string ContractId);
        string DeleteDetail(string ContractDetail); // xoa 1 ban ghi contractdetail
    }
}
