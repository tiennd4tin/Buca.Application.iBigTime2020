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
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using System.Data;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Activity
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmActivityDetail : FrmXtraBaseCategoryDetail, IActivityView, IActivitysView
    {

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly ActivityPresenter _activityPresenter;
        private readonly ActivitysPresenter __activitysPresenter;

        public string ActivityId
        {
            get;

            set;
        }

        public string ActivityCode
        {
            get
            {
                return txtCareerWorkCode.Text.Trim();
            }

            set
            {
                txtCareerWorkCode.Text = value;
            }
        }

        public string ActivityName
        {
            get
            {
                return txtCareerWorkName.Text.Trim();
            }

            set
            {
                txtCareerWorkName.Text = value;
            }
        }

        public string ParentID
        {
            get
            {

                return lukParentID.EditValue == null ? "" : lukParentID.EditValue.ToString();
            }

            set
            {
                lukParentID.EditValue = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return cbIsActive.Checked;
            }

            set
            {
                cbIsActive.Checked = value;
            }
        }

        public IList<ActivityModel> Activitys
        {
            set
            {
                //lukParentID.Properties.DataSource = value;
                //lukParentID.Properties.PopulateColumns();
                //var treeColumnsCollection = new List<XtraColumn> {
                //                                new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnPosition = 1, ColumnVisible = true },
                //                                new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnPosition = 1, ColumnVisible = true },
                //                                new XtraColumn { ColumnName = "ParentID", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },
                //                            };
                //foreach (var column in treeColumnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        lukParentID.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        lukParentID.Properties.SortColumnIndex = column.ColumnPosition;
                //        lukParentID.Properties.PopupWidth = 500;
                //        lukParentID.Properties.Columns[2].Width = 300;
                //        lukParentID.Properties.Columns[1].Width = 100;
                //    }
                //    else lukParentID.Properties.Columns[column.ColumnName].Visible = false;
                //}
                //lukParentID.Properties.ValueMember = "ActivityId";
                //lukParentID.Properties.DisplayMember = "ActivityName";
            }
        }

        public bool IsParent
        {
            get;

            set;
        }

        public bool IsSystem
        {
            get;

            set;
        }

        public int Grade
        {
            get;

            set;
        }




        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBankDetail"/> class.
        /// </summary>
        public FrmActivityDetail()
        {
            InitializeComponent();
            _activityPresenter = new ActivityPresenter(this);
            __activitysPresenter = new ActivitysPresenter(this);
           
        }

        #region Property
       
        #endregion

       
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
                _activityPresenter.Display(KeyValue);        
            }

            __activitysPresenter.Display();
          
                            
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(ActivityCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResActivityCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCareerWorkCode.Focus();
                return false;
            }           
            if (string.IsNullOrEmpty(ActivityName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResActivityName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCareerWorkName.Focus();
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
            var result = _activityPresenter.Save();
            if (!string.IsNullOrEmpty(result))
                GlobalVariable.ActivityDtailIDActivityForm = result;
            return result;
        }
        #endregion

        private void lukParentID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmActivityDetail = new FrmActivityDetail();
                frmActivityDetail.ShowDialog();
                if (frmActivityDetail.CloseBox)
                {
                    if (!String.IsNullOrEmpty(GlobalVariable.ActivityDtailIDActivityForm))
                    {
                        __activitysPresenter.Display();
                        lukParentID.EditValue = GlobalVariable.ActivityDtailIDActivityForm;
                    }
                }
            }
        }
    }

}