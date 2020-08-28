/***********************************************************************
 * <copyright file="ReportListResponse.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;


namespace Buca.Application.iBigTime2020.BusinessComponents.Messages.Report
{
    /// <summary>
    /// class ReportListResponse
    /// </summary>
    public class ReportListResponse : ResponseBase
    {
        /// <summary>
        /// The report lists
        /// </summary>
        public List<ReportListEntity> ReportLists;

        /// <summary>
        /// The report list
        /// </summary>
        public ReportListEntity ReportList;

        public IList<ReportB04BCTCEntity> B04BCTC;


    }
}
