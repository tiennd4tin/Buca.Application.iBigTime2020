/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Project
{
    /// <summary>
    /// class ProjectsPresenter
    /// </summary>
    public class ProjectsPresenter : Presenter<IProjectsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ProjectsPresenter(IProjectsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Projects = Model.GetProjects();
        }

        public void DisplayActive()
        {
            View.Projects = Model.GetProjectsActive(true);
        }

        /// <summary>
        /// Displays the type of the by object.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        public void DisplayByObjectType(string objectType)

        {
            View.Projects = Model.GetProjectsByObjectType(objectType);
        }

        /// <summary>
        /// Dises the play for fa increment decrement.
        /// </summary>
        public void DisPlayForFAIncrementDecrement()
        {
            var projects = Model.GetProjectsByObjectType("2");
            if (projects == null)
            {
                projects = new List<ProjectModel>();
            }
            projects.ToList().AddRange(Model.GetProjectsByObjectType("1"));
            View.Projects = projects.OrderBy(x => x.ProjectCode).ToList();
        }

    }
}
