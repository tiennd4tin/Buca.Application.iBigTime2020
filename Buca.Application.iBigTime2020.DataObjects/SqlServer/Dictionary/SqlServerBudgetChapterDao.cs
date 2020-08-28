/***********************************************************************
 * <copyright file="SqlServerBudgetChapterDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerBudgetChapterDao.
    /// </summary>
    public class SqlServerBudgetChapterDao : IBudgetChapterDao
    {

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>BudgetChapterEntity.</returns>
        public BudgetChapterEntity GetBudgetChapter(string budgetChapterId)
        {
            const string sql = @"uspGet_BudgetChapter_ByID";

            object[] parms = { "@BudgetChapterID", budgetChapterId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>List{BudgetChapterEntity}.</returns>
        public List<BudgetChapterEntity> GetBudgetChapters()
        {
            const string procedures = @"uspGet_All_BudgetChapter";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget chapters by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{BudgetChapterEntity}.</returns>
        public List<BudgetChapterEntity> GetBudgetChaptersByActive(bool isActive)
        {
            const string sql = @"uspGet_BudgetChapter_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetChapters by budgetChapter code.
        /// </summary>
        /// <param name="budgetChapterCode">The budgetChapter code.</param>
        /// <returns>List{BudgetChapterEntity}.</returns>
        public BudgetChapterEntity GetBudgetChaptersByBudgetChapterCode(string budgetChapterCode)
        {
            const string sql = @"uspGet_BudgetChapter_ByBudgetChapterCode";

            object[] parms = { "@BudgetChapterCode", budgetChapterCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.Int32.</returns>
        public string InsertBudgetChapter(BudgetChapterEntity budgetChapter)
        {
            const string sql = "uspInsert_BudgetChapter";
            return Db.Insert(sql, true, Take(budgetChapter));
        }


        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetChapter(BudgetChapterEntity budgetChapter)
        {
            const string sql = "uspUpdate_BudgetChapter";
            return Db.Update(sql, true, Take(budgetChapter));
        }

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetChapter(BudgetChapterEntity budgetChapter)
        {
            const string sql = @"uspDelete_BudgetChapter";

            object[] parms = { "@BudgetChapterID", budgetChapter.BudgetChapterId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteBudgetChapterConvert()
        {
            const string sql = @"usp_ConvertBudgetChapter";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetChapterEntity> Make = reader =>
            new BudgetChapterEntity
            {
                BudgetChapterId = reader["BudgetChapterID"].AsGuid().AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetChapterName = reader["BudgetChapterName"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
            };


        /// <summary>
        /// Takes the specified budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(BudgetChapterEntity budgetChapter)
        {
            return new object[]  
            {
                "@BudgetChapterID", budgetChapter.BudgetChapterId,
                "@BudgetChapterCode", budgetChapter.BudgetChapterCode,
                "@BudgetChapterName", budgetChapter.BudgetChapterName,
                "@IsActive", budgetChapter.IsActive,
            };
        }
    }
}
