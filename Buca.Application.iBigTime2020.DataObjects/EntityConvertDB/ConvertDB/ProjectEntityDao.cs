using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class ProjectEntityDao : IEntityProjectDao
    {
       
       public  List<ProjectEntity> GetProject(string connectionString)
        {  
            List<ProjectEntity> listProject = new List<ProjectEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var deparrtment = context.Departments.ToList();
                var categories = context.Projects.ToList().OrderBy(x=>x.Grade);
                foreach (var result in categories)
                {
                    var project = new ProjectEntity();
                    project.ProjectId = result.ProjectID.ToString();
                    project.ProjectCode = result.ProjectCode;
                    project.ProjectNumber = result.ProjectNumber;
                    project.ProjectName = result.ProjectName;
                    project.ProjectEnglishName = result.ProjectEnglishName;
                    project.BUCACodeID = result.MISACodeID;
                    project.StartDate = result.StartDate;
                    project.FinishDate = result.FinishDate;
                    project.ExecutionUnit = result.ExecutionUnit;
                    project.DepartmentID = result.Department==null? null: result.Department.DepartmentID.ToString();
                    project.TotalAmountApproved = result.TotalAmountApproved;
                    project.ParentID = result.ParentID.ToString();
                    project.Grade = result.Grade;
                    project.IsParent = result.IsParent;
                    project.IsDetailbyActivityAndExpense = result.IsDetailbyActivityAndExpense;
                    project.IsSystem = result.IsSystem;
                    project.IsActive = result.Inactive !=true;
                    project.ObjectType = result.ObjectType;
                    project.ContractorID = result.ContractorID.ToString();
                    project.ContractorName = result.ContractorName;
                    project.ContractorAddress = result.ContractorAddress;
                    project.Description = result.Description;
                    project.ProjectSize = result.ProjectSize;
                    project.BuildLocation = result.BuildLocation;
                    project.InvestmentClass = result.InvestmentClass;
                    project.CDCActivityType = result.CDCActivityType;
                    project.Investment = "";


                    listProject.Add(project);

                }

               
            }

            return listProject;
        }

      
    }
}
