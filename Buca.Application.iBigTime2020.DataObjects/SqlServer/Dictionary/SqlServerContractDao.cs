/***********************************************************************
 * <copyright file="SqlServerAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// class SqlServerContractDao
    /// </summary>
    public class SqlServerContractDao : DaoBase, IContractDao
    {
        /// <summary>
        /// Gets the Contract.
        /// </summary>
        /// <param name="ContractId">The Contract identifier.</param>
        /// <returns></returns>
        public ContractEntity GetContract(string ContractId)
        {
            const string sql = @"uspGet_Contract_ByID";

            object[] parms = { "@ContractID", ContractId };
            return Db.Read(sql, true, Make<ContractEntity>, parms);
        }
        public List<ContractDetailEntity> GetContractDetail(string ContractId)
        {
            const string sql = @"uspGet_ContractDetail_ByID";
            object[] parms = { "@ContractID", ContractId };
            return Db.ReadList(sql, true, Make<ContractDetailEntity>, parms);
        }
        public ContractEntity GetContractByContractNo(string contractNo)
        {
            const string sql = @"uspGet_Contract_ByNo";

            object[] parms = { "@ContractNo", contractNo };
            return Db.Read(sql, true, Make<ContractEntity>, parms);
        }

        public List<ContractEntity> GetContractByProjectId(string projectId)
        {
            const string sql = @"uspGet_Contract_ByProjectID";

            object[] parms = { "@ProjectID", projectId };
            return Db.ReadList(sql, true, Make<ContractEntity>, parms);
        }

        /// <summary>
        /// Gets the Contracts.
        /// </summary>
        /// <returns></returns>
        public List<ContractEntity> GetContracts()
        {
            const string procedures = @"uspGet_All_Contract";
            return Db.ReadList(procedures, true, Make<ContractEntity>);
        }
        public List<ContractDetailEntity> GetContractDetails()
        {
            const string sql = @"uspGet_All_ContractDetail";
            return Db.ReadList(sql, true, Make<ContractDetailEntity>);
        }
        /// <summary>
        /// Gets the Contracts by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<ContractEntity> GetContractsByActive(bool isActive)
        {
            const string sql = @"uspGet_Contract_IsActive";

            //object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make<ContractEntity>);
        }

        /// <summary>
        /// Inserts the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public string InsertContract(ContractEntity Contract)
        {
            const string sql = @"uspInsert_Contract";
            return Db.Insert(sql, true, Take(Contract));
        }
        public string InsertContractDetail(ContractDetailEntity ContractDetail)
        {
            const string sql = @"uspInsert_ContractDetail";
            return Db.Insert(sql, true, Take(ContractDetail));
        }


        /// <summary>
        /// Updates the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public string UpdateContract(ContractEntity Contract)
        {
            const string sql = @"uspUpdate_Contract";
            return Db.Update(sql, true, Take(Contract));
        }
        public string UpdateContractDetail(ContractDetailEntity contractDetail)
        {
            const string sql = @"uspUpdate_ContractDetail";
            return Db.Update(sql, true, Take(contractDetail));
        }        

        /// <summary>
        /// Deletes the Contract.
        /// </summary>
        /// <param name="Contract">The Contract.</param>
        /// <returns></returns>
        public string DeleteContract(string ContractId)
        {
            const string sql = @"uspDelete_Contract";

            object[] parms = { "@ContractId", ContractId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteContractDetail(string ContractId)
        {
            const string sql = @"uspDelete_ContractDetail";
            object[] parms = { "@ContractId", ContractId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteDetail(string ContractDetailId)
        {
            const string sql = @"uspDelete_DetailContract";
            object[] parms = { "@ContractDetailId", ContractDetailId };
            return Db.Delete(sql, true, parms);
        }


    }
}
