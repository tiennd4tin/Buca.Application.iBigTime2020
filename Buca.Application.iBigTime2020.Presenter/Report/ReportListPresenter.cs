/***********************************************************************
 * <copyright file="ReportListPresenter.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.View.Report;


namespace Buca.Application.iBigTime2020.Presenter.Report
{
    /// <summary>
    /// Report List Presenter
    /// </summary>
    public class ReportListPresenter : Presenter<IReportsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReportListPresenter(IReportsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Gets all report list.
        /// </summary>
        /// <returns></returns>
        public List<ReportListModel> GetAllReportList()
        {
            return null;
        }

        /// <summary>
        /// Gets the reports by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;ReportListModel&gt;.</returns>
        public void GetReportsByIsActive(bool isActive, string loginName)
        {
            View.ReportLists = Model.GetReportListsByIsActive(isActive, loginName);
        }

        /// <summary>
        /// Gets the type of the reports by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>List&lt;ReportListModel&gt;.</returns>
        public List<ReportListModel> GetReportsByRefType(int refType)
        {
            return View.ReportLists = Model.GetReportsByRefType(refType);
        }

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns></returns>
        public List<ReportListModel> GetReportListsByReportGroup(string parentId)
        {
            return View.ReportLists = Model.GetReportListsByParentId(parentId);
        }

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportId">The report identifier.</param>
        /// <returns></returns>
        public ReportListModel GetReportListById(string reportId)
        {
            return null;
            //return Model.GetReportListById(reportId);
        }

        /// <summary>
        /// Updates the report list.
        /// </summary>
        /// <param name="reportListModel">The report list model.</param>
        /// <returns></returns>
        public string UpdateReportList(ReportListModel reportListModel)
        {
            return null;
            //return Model.UpdateReportList(reportListModel);
        }

    }
}
