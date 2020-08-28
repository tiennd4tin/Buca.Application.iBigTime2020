/***********************************************************************
 * <copyright file="ReportListFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    public class ReportListFacade
    {
        private static readonly IReportListDao ReportListDao = DataAccess.DataAccess.ReportListDao;
        //private static readonly IEmployeeLeasingDao EmployeeLeasingDao = DataAccess.DataAccess.EmployeeLeasingDao;
        //private static readonly IBuildingDao BuildingDao = DataAccess.DataAccess.BuildingDao;
        //private static readonly IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao = DataAccess.DataAccess.EstimateDetailStatementPartBDao;
        //private static readonly IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao = DataAccess.DataAccess.EstimateDetailStatementFixedAssetDao;
        //private static readonly IMutualDao MutualDao = DataAccess.DataAccess.MutualDao;
        //private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;

        /// <summary>
        /// Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        public List<ReportListEntity> GetReportsByRefType(int refType)
        {
            return ReportListDao.GetReportsByRefType(refType);
        }

        /// <summary>
        /// Gets the reports by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;ReportListEntity&gt;.</returns>
        public List<ReportListEntity> GetReportsByIsActive(bool isActive,string loginName)
        {
            return ReportListDao.GetReportsByIsActive(isActive, loginName);
        }

        public ReportListEntity GetReportListByReportId(string reportId)
        {
            return ReportListDao.GetReportListByReportId(reportId);
        }

        public List<ReportListEntity> GetReportListByParentId(string parentId)
        {
            return ReportListDao.GetReportListByParentId(parentId);
        }
        public ReportListResponse GetReportLists(ReportListRequest request)
        {
            var response = new ReportListResponse();
            if (request.LoadOptions.Contains("Reports"))
            {
                if (request.LoadOptions.Contains("B04BCTC"))
                {
                    response.B04BCTC = ReportListDao.GetReportB04BCTC(request.StoreProdure, request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate));
                }

            }
            return response;
        }
    }
}