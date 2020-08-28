/***********************************************************************
 * <copyright file="BudgetCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// class ProjectEntity
    /// </summary>
    public class ProjectEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        public ProjectEntity()
        {
            AddRule(new ValidateRequired("ProjectCode"));
            AddRule(new ValidateRequired("ProjectName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        public ProjectEntity(string projectId, string projectCode, string projectName, bool isParent,
            bool isActive, string description, int grade, string foreignName)
            : this()
        {
            ProjectId = projectId;
            ProjectCode = projectCode;
            ProjectName = projectName;
            IsParent = isParent;
            IsActive = isActive;
            Description = description;
            Grade = grade;
        }

        public string ProjectId { get; set; }

        public string ProjectCode { get; set; }

        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }

        public string ProjectEnglishName { get; set; }

        public string BUCACodeID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public string ExecutionUnit { get; set; }

        public string DepartmentID { get; set; }

        public decimal TotalAmountApproved { get; set; }

        public string ParentID { get; set; }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public bool IsDetailbyActivityAndExpense { get; set; }

        public bool IsSystem { get; set; }

        public bool IsActive { get; set; }

        public int? ObjectType { get; set; }

        public string ContractorID { get; set; }

        public string ContractorName { get; set; }

        public string ContractorAddress { get; set; }

        public string Description { get; set; }

        public string ProjectSize { get; set; }

        public string BuildLocation { get; set; }

        public string InvestmentClass { get; set; }

        public int? CDCActivityType { get; set; }
        public string Investment { get; set; }
        public string BankId { get; set; }
        public List<BankEntity> ProjectBanks { get; set; }
    }
}
