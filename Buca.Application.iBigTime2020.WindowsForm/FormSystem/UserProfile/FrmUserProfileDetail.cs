/***********************************************************************
 * <copyright file="FrmUserProfileDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 30 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.System.UserProfile;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.FormBase;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using System;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmUserProfileDetail : FrmXtraBaseCategoryDetail, IUserProfileView
    {
        #region Variables
        private readonly UserProfilePresenter _userProfilePresenter;
        #endregion

        #region UserProfile Member
        public string FullName
        {
            get { return txtFullName.Text; }
            set { txtFullName.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        string RePassword { get { return txtRePassword.Text; } }
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }
        string IUserProfileView.UserProfileId { get; set; }
        public string UserName
        {
            get { return txtUserProfileName.Text.Trim(); }
            set { txtUserProfileName.Text = value; }
        }
        public string JobTitle
        {
            get { return txtJobTitle.Text; }
            set { txtJobTitle.Text = value; }
        }
        public bool IsSystem { get; set; }
        #endregion

        #region Function Overrides
        protected override void InitControls()
        {

        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _userProfilePresenter.Display(KeyValue);
                txtRePassword.Text = Password;

                //// Tài khoản admin thì không cho sửa 1 số thông tin
                //if (this.UserName.Equals("admin"))
                //{
                //    txtUserProfileName.Enabled = false;
                //    txtPassword.Enabled = false;
                //    txtRePassword.Enabled = false;
                //    chkIsActive.Enabled = false;
                //}
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                XtraMessageBox.Show("Nhập tên đăng nhập", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserProfileName.Focus();
                return false;
            }

            //if (string.IsNullOrEmpty(Password))
            //{
            //    XtraMessageBox.Show("Nhập mật khẩu", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPassword.Focus();
            //    return false;
            //}

            if (!Password.Equals(RePassword))
            {
                XtraMessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRePassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(FullName))
            {
                XtraMessageBox.Show("Nhập tên người dùng", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
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
            return _userProfilePresenter.Save();
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmUserProfileDetail"/> class.
        /// </summary>
        public FrmUserProfileDetail()
        {
            InitializeComponent();
            _userProfilePresenter = new UserProfilePresenter(this);
        }

        #endregion
    }
}