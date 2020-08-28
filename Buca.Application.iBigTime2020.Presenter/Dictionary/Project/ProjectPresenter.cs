/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Collections.Generic;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Project
{
    /// <summary>
    /// class ProjectPresenter
    /// </summary>
    public class ProjectPresenter : Presenter<IProjectView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ProjectPresenter(IProjectView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget item identifier.
        /// </summary>
        /// <param name="projectId">The budget item identifier.</param>
        public void Display(string projectId)
        {
            if (projectId == null) { View.ProjectId = null; return; }

            var project = Model.GetProject(projectId);
            View.ProjectId = project.ProjectId;
            View.ProjectCode = project.ProjectCode;
            View.ProjectNumber = project.ProjectNumber;
            View.ProjectName = project.ProjectName;
            View.ProjectEnglishName = project.ProjectEnglishName;
            View.BUCACodeID = project.BUCACodeID;
            View.StartDate = project.StartDate;
            View.FinishDate = project.FinishDate;
            View.ExecutionUnit = project.ExecutionUnit;
            View.DepartmentID = project.DepartmentID;
            View.TotalAmountApproved = project.TotalAmountApproved;
            View.ParentID = project.ParentID;
            View.Grade = project.Grade;
            View.IsParent = project.IsParent;
            View.IsDetailbyActivityAndExpense = project.IsDetailbyActivityAndExpense;
            View.IsSystem = project.IsSystem;
            View.IsActive = project.IsActive;
            View.ObjectType = project.ObjectType;
            View.ContractorID = project.ContractorID;
            View.ContractorName = project.ContractorName;
            View.ContractorAddress = project.ContractorAddress;
            View.Description = project.Description;
            View.ProjectSize = project.ProjectSize;
            View.BuildLocation = project.BuildLocation;
            View.InvestmentClass = project.InvestmentClass;
            View.CDCActivityType = project.CDCActivityType;
            View.BankId = project.BankId;
            View.Investment = project.Investment;
          //  View.ProjectBanks = project.ProjectBanks ?? new List<BankModel>();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var project = new ProjectModel
            {
                ProjectId = View.ProjectId,
                ProjectCode = View.ProjectCode,
                ProjectNumber = View.ProjectNumber,
                ProjectName = View.ProjectName,
                ProjectEnglishName = View.ProjectEnglishName,
                BUCACodeID = View.BUCACodeID,
                StartDate = View.StartDate,
                FinishDate = View.FinishDate,
                ExecutionUnit = View.ExecutionUnit,
                DepartmentID = View.DepartmentID,
                TotalAmountApproved = View.TotalAmountApproved,
                ParentID = View.ParentID,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsDetailbyActivityAndExpense = View.IsDetailbyActivityAndExpense,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive,
                ObjectType = View.ObjectType,
                ContractorID = View.ContractorID,
                ContractorName = View.ContractorName,
                ContractorAddress = View.ContractorAddress,
                Description = View.Description,
                ProjectSize = View.ProjectSize,
                BuildLocation = View.BuildLocation,
                InvestmentClass = View.InvestmentClass,
                CDCActivityType = View.CDCActivityType,
                BankId = View.BankId,
                Investment = View.Investment,
                ProjectBanks = View.ProjectBanks
            };
            if(project.ProjectBanks == null)
            {
                project.ProjectBanks = new List<BankModel>();
            }
            return View.ProjectId == null ? Model.AddProject(project) : Model.UpdateProject(project,View.EditBank);
        }
        public string SavePrograms()
        {
            var project = new ProjectModel
            {
                ProjectId = View.ProjectId,
                ProjectCode = View.ProjectCode,
                ProjectNumber = View.ProjectNumber,
                ProjectName = View.ProjectName,
                ProjectEnglishName = View.ProjectEnglishName,
                BUCACodeID = View.BUCACodeID,
                StartDate = View.StartDate,
                FinishDate = View.FinishDate,
                ExecutionUnit = View.ExecutionUnit,
                DepartmentID = View.DepartmentID,
                TotalAmountApproved = View.TotalAmountApproved,
                ParentID = View.ParentID,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsDetailbyActivityAndExpense = View.IsDetailbyActivityAndExpense,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive,
                ObjectType = View.ObjectType,
                ContractorID = View.ContractorID,
                ContractorName = View.ContractorName,
                ContractorAddress = View.ContractorAddress,
                Description = View.Description,
                ProjectSize = View.ProjectSize,
                BuildLocation = View.BuildLocation,
                InvestmentClass = View.InvestmentClass,
                CDCActivityType = View.CDCActivityType,
                BankId = View.BankId,
                Investment = View.Investment
            };
            if (project.ProjectBanks == null)
            {
                project.ProjectBanks = new List<BankModel>();
            }
            return View.ProjectId == null ? Model.AddProject(project) : Model.UpdateProject(project);
        }
        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="projectId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string projectId)
        {
            return Model.DeleteProject(projectId);
        }
        public void DisplayProject(string projectId)
        {
            View.ProjectBanks = Model.GetProjectBank(projectId);
        }
    }
}
