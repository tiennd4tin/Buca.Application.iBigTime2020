using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerFundStructureDao : IFundStructureDao
    {
        public FundStructureEntity GetFundStructure(string fundStructureId)
        {
            const string sql = @"uspGet_FundStructure_ByID";

            object[] parms = { "@FundStructureID", fundStructureId };
            return Db.Read(sql, true, Make, parms);
        }
        public List<FundStructureEntity> GetFundStructures()
        {
            const string procedures = @"uspGet_All_FundStructure";
            return Db.ReadList(procedures, true, Make);
        }
        public List<FundStructureEntity> GetFundStructuresByFundStructureCode(string fundStructureCode)
        {
            const string sql = @"uspGet_FundStructure_ByFundStructureCode";

            object[] parms = { "@FundStructureCode", fundStructureCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        public List<FundStructureEntity> GetFundStructuresByActive(bool isActive)
        {
            const string sql = @"uspGet_FundStructure_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        public string InsertFundStructure(FundStructureEntity fundStructure)
        {
            const string sql = @"uspInsert_FundStructure";
            return Db.Insert(sql, true, Take(fundStructure));
        }
        public string UpdateFundStructure(FundStructureEntity fundStructure)
        {
            const string sql = @"uspUpdate_FundStructure";
            return Db.Update(sql, true, Take(fundStructure));
        }
        public string DeleteFundStructure(string fundStructureId)
        {
            const string sql = @"uspDelete_FundStructure";

            object[] parms = { "@FundStructureId", fundStructureId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteFundStructureConvert()
        {
            const string sql = @"usp_ConvertFundStructure";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        private static readonly Func<IDataReader, FundStructureEntity> Make = reader =>
           new FundStructureEntity
           {
               FundStructureId = reader["FundStructureID"].AsString(),
               FundStructureCode = reader["FundStructureCode"].AsString(),
               FundStructureName = reader["FundStructureName"].AsString(),
               BUCACodeId = reader["BUCACodeID"].AsString(),
               ParentId = reader["ParentID"].AsString(),
               Grade = reader["Grade"].AsInt(),
               IsParent = reader["IsParent"].AsBool(),
               Inactive = reader["Inactive"].AsBool(),
               IsSystem = reader["IsSystem"].AsBool(),
               InvestmentPeriod = reader["InvestmentPeriod"].AsIntForNull(),
               BudgetItemId = reader["BudgetItemID"].AsString(),
               CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
               IsProjectExpense = reader["IsProjectExpense"].AsBool(),
               IsAllocateExpense = reader["IsAllocateExpense"].AsBool(),
               IsExpenseNoBuilding = reader["IsExpenseNoBuilding"].AsBool(),
           };

        private object[] Take(FundStructureEntity fundStructureEntity)
        {
            return new object[]
            {
                "@FundStructureID",fundStructureEntity.FundStructureId,
                "@FundStructureCode",fundStructureEntity.FundStructureCode,
                "@FundStructureName",fundStructureEntity.FundStructureName,
                "@BUCACodeID",fundStructureEntity.BUCACodeId,
                "@ParentID",fundStructureEntity.ParentId,
                "@Grade",fundStructureEntity.Grade,
                "@IsParent",fundStructureEntity.IsParent,
                "@Inactive",fundStructureEntity.Inactive,
                "@IsSystem",fundStructureEntity.IsSystem,
                "@InvestmentPeriod",fundStructureEntity.InvestmentPeriod,
                "@BudgetItemID",fundStructureEntity.BudgetItemId    ,
                "@CashWithdrawTypeID",fundStructureEntity.CashWithdrawTypeId    ,
                "@IsProjectExpense",fundStructureEntity.IsProjectExpense    ,
                "@IsAllocateExpense",fundStructureEntity.IsAllocateExpense  ,
                "@IsExpenseNoBuilding",fundStructureEntity.IsExpenseNoBuilding,
            };
        }
    }
}
