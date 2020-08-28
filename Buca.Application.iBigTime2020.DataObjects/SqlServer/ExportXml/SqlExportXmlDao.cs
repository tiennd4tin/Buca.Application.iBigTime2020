using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Report.ExportXml;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.ExportXml;
using Buca.Application.iBigTime2020.DataHelpers;
namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.ExportXml
{
    public class SqlExportXmlDao : DaoBase, IExportXmlDao
    {
        public IList<ExportXmlEntity> GetExportXmlEntities()
        {
            const string procedures = @"uspGet_All_ExportXml";
            return Db.ReadList(procedures, true, Make);
        }

        public IList<ExportXmlBCTCEntiry> GetExportXmlBCTCEntities()
        {
            const string procedures = @"usp_Get_ExportXmlBCTC";
            return Db.ReadList(procedures, true, Make<ExportXmlBCTCEntiry>);
        }

        public IList<ExportXmlBCTCBudgetSourceEntity> GetExportXmlBCTCBudgetSourceEntity()
        {
            const string procedures = @"usp_Get_BudgetSourceExportXmlBCTC";
            return Db.ReadList(procedures, true, Make<ExportXmlBCTCBudgetSourceEntity>);
        }

        public string Delete_BudgetSourceMappingToExport()
        {
            const string sql = @"Delete_BudgetSourceMappingToExport";
            object[] parms = null;
            return Db.Delete(sql, true, parms);
        }

        public string InsertBudgetSourceMappingToExport(ExportXmlBCTCBudgetSourceEntity entity)
        {
            const string sql = @"Insert_BudgetSourceMappingToExport";
            return Db.Insert(sql, true, Take(entity));
        }

        public IList<ExportXmlDetailEntity> GetExportXmlDetailEntities(string refType)
        {
            const string procedures = @"uspGet_All_ExportXmlDetail";
            object[] parms = { "@RefType", refType };
            return Db.ReadList(procedures, true, MakeDetail, parms);
        }

        private static readonly Func<IDataReader, ExportXmlEntity> Make = reader =>
            new ExportXmlEntity
            {
                ExportID = reader["ExportID"].AsString(),
                ExportName = reader["ExportName"].AsString(),
                RefType = reader["RefType"].AsString(),
                Description = reader["Description"].AsString(),
                InputTypeName = reader["InputTypeName"].AsString(),
                FuntionName = reader["FuntionName"].AsString(),
                DefaultParamater = reader["DefaultParamater"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                IsVisible = reader["IsVisible"].AsBool(),
                IsParamater =reader["IsParamater"].AsBool()

            };

        private static readonly Func<IDataReader, ExportXmlDetailEntity> MakeDetail = reader =>
            new ExportXmlDetailEntity
            {
                RefType = reader["RefType"].AsInt(),
                RefID = reader["RefID"].AsString(),
                RefDetailID = reader["RefDetailID"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefDate = reader["RefDate"].AsDateTime(),
                Description = reader["Description"].AsString(),
                Amount = reader["Amount"].AsDecimal(),


            };

        private static object[] Take(ExportXmlBCTCBudgetSourceEntity entity)
        {
            return new object[]
            {

                "@BudgetSourceMappingToExportID", Guid.NewGuid(),
                "@BudgetSourceID", entity.BudgetSourceId,
                "@BudgetSourceCode", entity.BudgetSourceCode,
                "@BudgetSourceName", entity.BudgetSourceName,
                "@OwnerBudgetSourceID", entity.BudgetSourceId,
                "@OwnerBudgetSourceCode", entity.BudgetSourceCodeOwner,
                "@OwnerBudgetSourceName", entity.BudgetSourceNameOwner,
            };
        }
    }
}
