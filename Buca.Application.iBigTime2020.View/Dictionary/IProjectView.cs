/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// interface IProjectView
    /// </summary>
    public interface IProjectView : IView
    {
        string ProjectId { get; set; }

        string ProjectCode { get; set; }

        string ProjectNumber { get; set; }

        string ProjectName { get; set; }

        string ProjectEnglishName { get; set; }

        string BUCACodeID { get; set; }
        bool EditBank { get; set; }

        DateTime? StartDate { get; set; }

        DateTime? FinishDate { get; set; }

        string ExecutionUnit { get; set; }

        string DepartmentID { get; set; }

        decimal TotalAmountApproved { get; set; }

        string ParentID { get; set; }

        int Grade { get; set; }

        bool IsParent { get; set; }

        bool IsDetailbyActivityAndExpense { get; set; }

        bool IsSystem { get; set; }

        bool IsActive { get; set; }

        int? ObjectType { get; set; }

        string ContractorID { get; set; }

        string ContractorName { get; set; }

        string ContractorAddress { get; set; }

        string Description { get; set; }

        string ProjectSize { get; set; }

        string BuildLocation { get; set; }

        string InvestmentClass { get; set; }

        int? CDCActivityType { get; set; }
        string BankId { get; set; }
        string Investment { get; set; }

        IList<BankModel> ProjectBanks { get; set; }
    }
}
