using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class DepartmentEntityDao : IEntityDepartmentDao
    {
       
       public  List<DepartmentEntity> GetDepartments(string connectionString)
        {  
            List<DepartmentEntity> listDepartment = new List<DepartmentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.Departments.ToList().OrderBy(x=>x.Grade);
                foreach (var result in categories)
                {
                    var department = new DepartmentEntity();
                    department.DepartmentId = result.DepartmentID.ToString();
                    department.DepartmentCode = result.DepartmentCode;
                    department.DepartmentName = result.DepartmentName;
                    department.ParentId = result.ParentID.ToString();
                    department.Grade = result.Grade;
                    department.IsParent = result.IsParent;
                    department.Description = result.Description;
                    department.IsActive = result.Inactive == true ? false : true;


                    listDepartment.Add(department);

                }

               
            }

            return listDepartment;
        }

      
    }
}
