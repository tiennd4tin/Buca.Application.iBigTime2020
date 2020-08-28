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

using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// class ProjectModel
    /// </summary>
    public class ProjectModel
    {
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

      

        public int? ObjectType { get; set; }
        public bool IsActive { get; set; }

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
        public IList<BankModel> ProjectBanks { get; set; }
        public string ObjectTypeName
        {
            get
            {
                var objectTypeName = "";
                switch (ObjectType)
                {
                    case 1:
                        objectTypeName = "Chương trình mục tiêu";
                        break;
                    case 2:
                        objectTypeName = "Dự án";
                        break;
                    case 3:
                        objectTypeName = "Hạng mục công trình";
                        break;
                }
                return objectTypeName;
            }
        }
    }
}
