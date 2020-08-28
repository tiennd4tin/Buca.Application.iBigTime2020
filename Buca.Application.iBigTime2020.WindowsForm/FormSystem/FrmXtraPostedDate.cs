/***********************************************************************
 * <copyright file="FrmXtraPostedDate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraPostedDate
    /// </summary>
    public partial class FrmXtraPostedDate : XtraForm, IDBOptionsView
    {
        private readonly DBOptionsPresenter _dbOptionsPresenter;

        #region DBOption Members

        public IList<DBOptionModel> DBOptions
        {
            get
            {
                Buca.Application.iBigTime2020.Model.IModel model = new Model.Model();
                var lockData = model.GetLock();
                if(lockData.IsLock)
                {

                }


                var dbOptions = new List<DBOptionModel> 
                {
                    new DBOptionModel { OptionId = "DBPostedDate", OptionValue = dtPostedDate.Text, ValueType = 2,
                        Description = "Ngày hạch toán", IsSystem = true },
                  
                    //    Description = "Ngày bắt đầu năm tài chính - 01/tháng của năm tài chính/năm posteddate", IsSystem = true },
                    //new DBOptionModel { OptionId = "FinancialEndOfDate", OptionValue = "31/12/" + ((DateTime)dtPostedDate.EditValue).Year, 
                    //    ValueType = 2, Description = "Ngày cuối cùng của năm tài chính - 31/12/năm posteddate", IsSystem = true }
                };
                return dbOptions;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraPostedDate"/> class.
        /// </summary>
        public FrmXtraPostedDate()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraPostedDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraPostedDate_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(GlobalVariable.PostedDate))
            {
                dtPostedDate.EditValue = Convert.ToDateTime(GlobalVariable.PostedDate);
            }
            else
            {
                dtPostedDate.EditValue = DateTime.Now;
            }    

            //_financialMonth = _globalVariable.FinancialMonth;
            //if (_financialMonth.Length == 1)
            //    _financialMonth = "0" + _financialMonth;
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        
        
        {
            try
            {
                if (DateTime.Parse(dtPostedDate.Text) < DateTime.Parse(GlobalVariable.SystemDate))
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostedDateLessSysemDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var message = _dbOptionsPresenter.Save();
                    if (message != null)
                        XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GlobalVariable.PostedDate = dtPostedDate.Text;
                    GlobalVariable.StartedDate = dtPostedDate.Text;//LINHMC gan lai de luu lai gia tri thay doi ngay hach toan
                    //_dbOptionsPresenter.Display();
                    Close();
                }
                //else
                //{
                //    var message = _dbOptionsPresenter.Save();
                //    if (message != null)
                //        XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    _globalVariable.PostedDate = dtPostedDate.EditValue.ToString();
                //    GlobalVariable.StartedDate = dtPostedDate.EditValue.ToString();//LINHMC gan lai de luu lai gia tri thay doi ngay hach toan
                //    _dbOptionsPresenter.Display();
                //    Close();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}