/***********************************************************************
 * <copyright file="DBOptionsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption
{
    /// <summary>
    /// DBOptionsPresenter
    /// </summary>
    public class DBOptionsPresenter : Presenter<IDBOptionsView>
    {
        private CompanyProfileModel _companyProfile;

        /// <summary>
        /// DBOptionts the presenter.
        /// </summary>
        /// <param name="view">The view.</param>
        public DBOptionsPresenter(IDBOptionsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.DBOptions = Model.GetDBOptions();
        }

        /// <summary>
        /// Displays for database information.
        /// </summary>
        public void DisplayForDbInfo()
        {
            View.DBOptions = Model.GetOptionsForDbInfo();
        }

        /// <summary>
        /// Displays the is numeric.
        /// </summary>
        public void DisplayIsNumeric()
        {
            View.DBOptions = Model.GetDBOptionsIsNumeric();
        }

        /// <summary>
        /// Displays the is string.
        /// </summary>
        public void DisplayIsString()
        {
            View.DBOptions = Model.GetDBOptionsIsString();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var dbOptionModels = View.DBOptions;
            return Model != null ? Model.UpdateDBOption((List<DBOptionModel>)dbOptionModels) : null;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {
            //_companyProfile = Model.GetCompanyProfile(1);
            //var dbOptionModels = View.DBOptions;
            //string companyDirector = "";
            //string companyAccountant = "";
            //decimal baseOfSalary = 0;
            //string companyAdrress = "";
            //string companyCode = "";
            //foreach (var dbOptionModel in dbOptionModels)
            //{
            //    //if (dbOptionModel.OptionId == "CompanyDirector")
            //    //{
            //    //    companyDirector = dbOptionModel.OptionValue;
            //    //}
            //    if (dbOptionModel.OptionId == "CompanyAccountant")
            //    {
            //        companyAccountant = dbOptionModel.OptionValue;
            //    }

            //    if (dbOptionModel.OptionId == "BaseOfSalary")
            //    {
            //        baseOfSalary = Convert.ToDecimal(dbOptionModel.OptionValue);
            //    }

            //    if (dbOptionModel.OptionId == "CompanyAdrress")
            //    {
            //        companyAdrress = dbOptionModel.OptionValue;
            //    }

            //    if (dbOptionModel.OptionId == "CompanyAdrress")
            //    {
            //        companyAdrress = dbOptionModel.OptionValue;
            //    }

            //    if (dbOptionModel.OptionId == "CompanyCode")
            //    {
            //        companyCode = dbOptionModel.OptionValue;
            //    }

                
                 
            //}

            //var companyProfile = new CompanyProfileModel
            //{
            //    LineId = _companyProfile.LineId,
            //    AssetOwnArea = _companyProfile.AssetOwnArea,
            //    AssetOwnRoom = _companyProfile.AssetOwnRoom,
            //    AssetBuyDate = _companyProfile.AssetBuyDate,
            //    AssetOwnDescription = _companyProfile.AssetOwnDescription,
            //    AssetMutualArea = _companyProfile.AssetMutualArea,
            //    AssetMutualRoom = _companyProfile.AssetMutualRoom,
            //    AssetMutualMethod = _companyProfile.AssetMutualMethod,
            //    AssetMutualDescription = _companyProfile.AssetMutualDescription,
            //    AssetRentContractLen = _companyProfile.AssetRentContractLen,
            //    AssetRentPrice = _companyProfile.AssetRentPrice,
            //    AssetRentRoom = _companyProfile.AssetRentRoom,
            //    AssetRentArea = _companyProfile.AssetRentArea,
            //    AssetRentDescription = _companyProfile.AssetRentDescription,
            //    AssetNumberOfCars = _companyProfile.AssetNumberOfCars,
            //    AssetCarDetail = _companyProfile.AssetCarDetail,
            //    EmployeePayrollsTotal = _companyProfile.EmployeePayrollsTotal,
            //    EmployeeNumberOfWifeOrHusband = _companyProfile.EmployeeNumberOfWifeOrHusband,
            //    EmployeeNumberOfOfficers = _companyProfile.EmployeeNumberOfOfficers,
            //    EmployeeNumberOfStaff = _companyProfile.EmployeeNumberOfStaff,
            //    EmployeeOtherCompany = _companyProfile.EmployeeOtherCompany,
            //    EmployeeNumberOfSecondingOfficers = _companyProfile.EmployeeNumberOfSecondingOfficers,
            //    EmployeeDetail = _companyProfile.EmployeeDetail,
            //    EmployeeNumberOfRentLocal = _companyProfile.EmployeeNumberOfRentLocal,
            //    ProfileAddress = companyAdrress,
            //    ProfileFoundDate = _companyProfile.ProfileFoundDate,
            //    ProfileHeadPhone = _companyProfile.ProfileHeadPhone,
            //    ProfileAmbassadorName = companyDirector,
            //    ProfileAmbassadorPhone = _companyProfile.ProfileAmbassadorPhone,
            //    ProfileAmbassadorStartDate = _companyProfile.ProfileAmbassadorStartDate,
            //    ProfileAmbassadorFinishDate = _companyProfile.ProfileAmbassadorFinishDate,
            //    ProfileAccountingManagerName = _companyProfile.ProfileAccountingManagerName,
            //    ProfileAccountingManagerPhone = _companyProfile.ProfileAccountingManagerPhone,
            //    ProfileAccountingManagerStartDate = _companyProfile.ProfileAccountingManagerStartDate,
            //    ProfileAccountingManagerFinishDate = _companyProfile.ProfileAccountingManagerFinishDate,
            //    ProfileAccountantName = companyAccountant,
            //    ProfileAccountantPhone = _companyProfile.ProfileAccountantPhone,
            //    ProfileAccountantStartDate = _companyProfile.ProfileAccountantStartDate,
            //    ProfileAccountantFinishDate = _companyProfile.ProfileAccountantFinishDate,
            //    ProfileMinimumSalary = baseOfSalary,
            //    ProfileSalaryGroup = _companyProfile.ProfileSalaryGroup,
            //    ProfileWorkingArea = _companyProfile.ProfileWorkingArea,
            //    ProfileCurrencyCodeFinalization = _companyProfile.ProfileCurrencyCodeFinalization,
            //    ProfileServices = _companyProfile.ProfileServices,
            //    ProfileReportHeader = _companyProfile.ProfileReportHeader,
            //    ProfileBankName = _companyProfile.ProfileBankName,
            //    ProfileBankAddress = _companyProfile.ProfileBankAddress,
            //    ProfileBankAccount = _companyProfile.ProfileBankAccount,
            //    ProfileBankCIF = _companyProfile.ProfileBankCIF,
            //    OtherNote = _companyProfile.OtherNote
            //};
            //return Model.GetCompanyProfile(1) != null ? Model.UpdateCompanyProfile(companyProfile) : Model.AddCompanyProfile(companyProfile);
            return 0;
        }
    }
}
