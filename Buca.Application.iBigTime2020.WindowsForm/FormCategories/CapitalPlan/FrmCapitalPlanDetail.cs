/***********************************************************************
 * <copyright file="FrmXtraAccountingObjectDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.CapitalPlan
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmCapitalPlanDetail : FrmXtraBaseCategoryDetail, ICapitalPlanView
    {

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly CapitalPlanPresenter _CapitalPlanPresenter;
        private readonly CapitalPlansPresenter __CapitalPlansPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBankDetail"/> class.
        /// </summary>
        public FrmCapitalPlanDetail()
        {
            InitializeComponent();
            capTypeId.Properties.Items.Insert(0, "Không áp dụng");
            capTypeId.Properties.Items.Insert(1, "Kế hoạch trong năm");
            capTypeId.Properties.Items.Insert(2, "Kế hoạch ứng trước");
            capTypeId.Properties.Items.Insert(3, "Kế hoạch kéo dài");

            _CapitalPlanPresenter = new CapitalPlanPresenter(this);

        }

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");

            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _CapitalPlanPresenter.Display(KeyValue);
            }
            else
            {
                capTypeId.SelectedIndex = 0;
                dateStartDate.DateTime = DateTime.Now;
                dateToDate.DateTime = DateTime.Now;
                CapYear.Value = DateTime.Now.Year;
            }

            //__CapitalPlansPresenter.Display();


        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(CapitalPlanCode))
            {
                XtraMessageBox.Show("Bạn chưa nhập mã KH vốn",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CapitalPlanName))
            {
                XtraMessageBox.Show("Bạn chưa nhập tên KH vốn",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _CapitalPlanPresenter.Save();
            if (!string.IsNullOrEmpty(result))
                GlobalVariable.ActivityDtailIDActivityForm = result;
            return result;
        }
        #endregion

        #region Events

        private void lukParentID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmCapitalPlanDetail = new FrmCapitalPlanDetail();
                frmCapitalPlanDetail.ShowDialog();
                if (frmCapitalPlanDetail.CloseBox)
                {
                    if (!String.IsNullOrEmpty(GlobalVariable.ActivityDtailIDActivityForm))
                    {
                        __CapitalPlansPresenter.Display();
                        capTypeId.EditValue = GlobalVariable.ActivityDtailIDActivityForm;
                    }
                }
            }
        } 
        #endregion

        #region Implements
        public string CapitalPlanId { get; set; }

        public string CapitalPlanCode
        {
            get { return txtCapCode.Text; }
            set { txtCapCode.Text = value; }

        }

        public string CapitalPlanName
        {
            get { return txtCapName.Text; }
            set { txtCapName.Text = value; }

        }

        public int PlanYear
        {
            get { return (int)CapYear.Value; }
            set { CapYear.Value = value; }

        }

        public int PlanTypeId
        {
            get { return (int)capTypeId.SelectedIndex; }
            set { capTypeId.SelectedIndex = value; }

        }

        public DateTime? FromDate
        {
            get { return (DateTime?)dateStartDate.EditValue; }
            set { dateStartDate.EditValue = value; }

        }

        public DateTime? ToDate
        {
            get { return (DateTime?)dateToDate.EditValue; }
            set { dateToDate.EditValue = value; }

        }

        public bool IsActive
        {
            get { return cbIsActive.Checked; }
            set { cbIsActive.Checked = value; }

        }
        #endregion
    }

}