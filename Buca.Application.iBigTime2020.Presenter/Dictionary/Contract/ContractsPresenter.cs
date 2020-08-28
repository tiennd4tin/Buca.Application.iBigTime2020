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


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Contract
{
    /// <summary>
    /// class ContractsPresenter
    /// </summary>
    public class ContractsPresenter : Presenter<IContractsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ContractsPresenter(IContractsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Contracts = Model.GetContracts();            
        }

        public void DisplayActive()
        {
            View.Contracts = Model.GetContractsActive(true);
        }

        public void DisplayByProjetId(string projectId)
        {
            View.Contracts = Model.GetContractByProjectId(projectId);
        }
    }
}
