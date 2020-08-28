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
    /// class SqlServerProjectDao
    /// </summary>
    public class SqlServerProjectDao : IProjectDao
    {
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public ProjectEntity GetProject(string projectId)
        {
            const string sql = @"uspGet_Project_ByID";

            object[] parms = { "@ProjectID", projectId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        public List<ProjectEntity> GetProjects()
        {
            const string procedures = @"uspGet_All_Project";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the projects by project code.
        /// </summary>
        /// <param name="projectCode">The project code.</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByProjectCode(string projectCode)
        {
            const string sql = @"uspGet_Project_ByProjectCode";

            object[] parms = { "@ProjectCode", projectCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the type of the projects by object.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>List&lt;ProjectEntity&gt;.</returns>
        public List<ProjectEntity> GetProjectsByObjectType(string objectType)
        {
            const string sql = @"uspGet_Project_ByObjectType";

            object[] parms = { "@ObjectType", objectType };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the type of the projects by project code object.
        /// </summary>
        /// <param name="projectCode">The project code.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Dictionary.ProjectEntity&gt;.</returns>
        public ProjectEntity GetProjectsByProjectCodeObjectType(string projectCode, int? objectType)
        {
            const string sql = @"uspGet_Project_ByTypeCode";

            object[] parms = { "@ProjectCode", projectCode, "@ObjectType", objectType };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the projects by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByActive(bool isActive)
        {
            const string sql = @"uspGet_Project_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public string InsertProject(ProjectEntity project)
        {
            const string sql = @"uspInsert_Project";
            return Db.Insert(sql, true, Take(project));
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public string UpdateProject(ProjectEntity project)
        {
            const string sql = @"uspUpdate_Project";
            return Db.Update(sql, true, Take(project));
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public string DeleteProject(string projectId)
        {
            const string sql = @"uspDelete_Project";

            object[] parms = { "@ProjectId", projectId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteProjectConvert( )
        {
            const string sql = @"usp_ConvertProject";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ProjectEntity> Make = reader =>
            new ProjectEntity
            {
                ProjectId = reader["ProjectID"].AsString(),
                ProjectCode = reader["ProjectCode"].AsString(),
                ProjectNumber = reader["ProjectNumber"].AsString(),
                ProjectName = reader["ProjectName"].AsString(),
                ProjectEnglishName = reader["ProjectEnglishName"].AsString(),
                BUCACodeID = reader["BUCACodeID"].AsString(),
                StartDate = reader["StartDate"].AsString().AsDateTimeForNull(),
                FinishDate = reader["FinishDate"].AsString().AsDateTimeForNull(),
                ExecutionUnit = reader["ExecutionUnit"].AsString(),
                DepartmentID = reader["DepartmentID"].AsString(),
                TotalAmountApproved = reader["TotalAmountApproved"].AsDecimal(),
                ParentID = reader["ParentID"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                IsDetailbyActivityAndExpense = reader["IsDetailbyActivityAndExpense"].AsBool(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                ObjectType = reader["ObjectType"].AsInt(),
                ContractorID = reader["ContractorID"].AsString(),
                ContractorName = reader["ContractorName"].AsString(),
                ContractorAddress = reader["ContractorAddress"].AsString(),
                Description = reader["Description"].AsString(),
                ProjectSize = reader["ProjectSize"].AsString(),
                BuildLocation = reader["BuildLocation"].AsString(),
                InvestmentClass = reader["InvestmentClass"].AsString(),
                CDCActivityType = reader["CDCActivityType"].AsInt(),
                Investment = reader["Investment"].AsString(),
                BankId = reader["BankID"].AsString()
            };

        /// <summary>
        /// Takes the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        private object[] Take(ProjectEntity account)
        {
            return new object[]
            {
            "@ProjectID", account.ProjectId,
            "@ProjectCode", account.ProjectCode,
            "@ProjectNumber", account.ProjectNumber,
            "@ProjectName", account.ProjectName,
            "@ProjectEnglishName", account.ProjectEnglishName,
            "@BUCACodeID", account.BUCACodeID,
            "@StartDate", account.StartDate,
            "@FinishDate", account.FinishDate,
            "@ExecutionUnit", account.ExecutionUnit,
            "@DepartmentID", account.DepartmentID,
            "@TotalAmountApproved", account.TotalAmountApproved,
            "@ParentID", account.ParentID,
            "@Grade", account.Grade,
            "@IsParent", account.IsParent,
            "@IsDetailbyActivityAndExpense", account.IsDetailbyActivityAndExpense,
            "@IsSystem", account.IsSystem,
            "@IsActive", account.IsActive,
            "@ObjectType", account.ObjectType,
            "@ContractorID", account.ContractorID,
            "@ContractorName", account.ContractorName,
            "@ContractorAddress", account.ContractorAddress,
            "@Description", account.Description,
            "@ProjectSize", account.ProjectSize,
            "@BuildLocation", account.BuildLocation,
            "@InvestmentClass", account.InvestmentClass,
            "@CDCActivityType", account.CDCActivityType,
            "@BankID", account.BankId,
            "@Investment",account.Investment
            };
        }

    }
}
