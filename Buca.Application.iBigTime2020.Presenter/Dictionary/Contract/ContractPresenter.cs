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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Contract
{
    /// <summary>
    /// class ContractPresenter
    /// </summary>
    public class ContractPresenter : Presenter<IContractView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ContractPresenter(IContractView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget item identifier.
        /// </summary>
        /// <param name="ContractId">The budget item identifier.</param>
        public void Display(string ContractId)
        {
            //if (ContractId == null) { View.ContractId = null; return; }
            if (ContractId != null)
            {
                var Contract = Model.GetContract(ContractId);
                Contract.ContractDetails = Model.GetContractDetail(ContractId);
                View.ContractId = Contract.ContractId;
                View.ContractNo = Contract.ContractNo;
                View.ContractName = Contract.ContractName;
                View.ContractNameEnglish = Contract.ContractNameEnglish;
                View.SignDate = Contract.SignDate;
                View.StartDate = Contract.StartDate;
                View.EndDate = Contract.EndDate;
                View.CurrencyCode = Contract.CurrencyCode;
                View.ExchangeRate = Contract.ExchangeRate;
                View.AmountOC = Contract.AmountOC;
                View.ProjectId = Contract.ProjectId;
                View.Description = Contract.Description;
                View.VendorId = Contract.VendorId;
                View.IsActive = Contract.IsActive;
                View.ContractDetails = Contract.ContractDetails;
                if (Contract.VendorBankAccountId != "")
                {
                    View.VendorBankAccountId = Contract.VendorBankAccountId;
                }
                
            }
            else View.ContractDetails = Model.GetContractDetail(ContractId);

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var Contract = new ContractModel
            {
                ContractId = View.ContractId,
                ContractNo = View.ContractNo,
                ContractName = View.ContractName,
                ContractNameEnglish = View.ContractNameEnglish,
                SignDate = View.SignDate,
                StartDate = View.StartDate,
                EndDate = View.EndDate,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                AmountOC = View.AmountOC,
                ProjectId = View.ProjectId,
                Description = View.Description,
                VendorId = View.VendorId,
                VendorBankAccountId = View.VendorBankAccountId,
                IsActive = View.IsActive,
                ContractDetails = View.ContractDetails,
                
            };

            return View.ContractId == null ? Model.AddContract(Contract) : Model.UpdateContract(Contract);
        }

        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="ContractId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string ContractId)
        {
            return Model.DeleteContract(ContractId);
        }
        public string DeleteContractDetail(string ContractDetailId)
        {
            return Model.DeleteContractDetail(ContractDetailId);
        }
    }
}
