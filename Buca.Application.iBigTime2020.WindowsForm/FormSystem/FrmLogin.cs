/***********************************************************************
 * <copyright file="FrmLogin.cs" company="BUCA JSC">
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

using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Annotations;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.DataHelpers.Encryption;
using BuCA.Option;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmLogin
    /// </summary>
    public partial class FrmLogin : XtraForm, IUserProfileView, IAudittingLogView
    {
        #region local variables

        [UsedImplicitly]
        //private readonly UserProfilePresenter _userProfilePresenter;
        private readonly AudittingLogPresenter _audittingLogPresenter;
        public delegate void EventPostLoginState(object sender, bool keyValue);
        public event EventPostLoginState PostLoginState;
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        IModel _model;
        #endregion

        #region UserProfile Members
        string IUserProfileView.UserProfileId { get; set; }

        public string UserName
        {
            get { return txtUserProfileName.Text; }
            set { txtUserProfileName.Text = value; }
        }

        public string JobTitle { get; set; }

        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmLogin"/> class.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            //_userProfilePresenter = new UserProfilePresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        /// Handles the Load event of the FrmLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (RegistryHelper.GetValueByRegistryKey("UserLogin") != null)
                txtUserProfileName.EditValue = RegistryHelper.GetValueByRegistryKey("UserLogin");
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (PostLoginState != null)
                PostLoginState(this, false);
            Close();
        }

        /// <summary>
        /// Có một lỗi hay xảy ra là trường hợp tên dữ liệu được lưu trong registry không đúng, không tồn tại
        /// dẫn đến việc phát sinh lỗi, không mở được dữ liệu. Phải can thiệp khó khăn
        /// Giải pháp là kiểm tra tên dữ liệu có tồn tại không, trước khi thực hiện các lệnh khác.
        /// 
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                    return;

                // Kiểm tra thông tin tài khoản đăng nhập
                var userProfileLogin = _model.GetUserProfileByUserName(this.UserName);
                if (userProfileLogin == null || !MD5Helper.VerifyMd5Hash(this.Password, userProfileLogin.Password))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResLoginFailded"), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserProfileName.Focus();
                    return;
                }

                if (PostLoginState != null)
                    PostLoginState(this, true);
                LoadOption();
                GlobalVariable.LoginName = UserName;
                GlobalVariable.PostedDate = DateTime.Now.ToShortDateString();
                IModel model = new Model.Model();
                GlobalVariable.LockVoucherDateFrom = model.GetLock().LockDate.Substring(0,10);
                GlobalVariable.LockVoucherDateTo = model.GetLock().LockDate.Substring(11, 10);

                _audittingLogPresenter.Save();
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
        }

        #endregion

        private void txtUserProfileName_EditValueChanged(object sender, EventArgs e)
        {

        }

        #region AuditingLog Member

        public string EventId { get; set; }

        public string LoginName
        {
            get { return GlobalVariable.LoginName; }
            set { }
        }
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }
        public string ComponentName
        {
            get { return "Đăng nhập"; }
            set { }
        }
        public int EventAction
        {
            get
            {
                return 7;
            }
            set { }
        }
        public string Reference
        {
            get
            {
                return "Đăng nhập";
            }
            set { }
        }

        public decimal Amount { get; set; }


        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1000));
        }

        #region private helper

        /// <summary>
        /// Valids the version.
        /// </summary>
        /// <param name="version">The version.</param>
        private bool ValidVersion(string version)
        {
            string[] versions = version.Split('.');
            string[] versionDBs = GlobalVariable.Version.Split('.');
            int versionWord1 = int.Parse(versions[0]);
            int versionDbWord1 = int.Parse(versionDBs[0]);
            int versionWord2 = int.Parse(versions[1]);
            int versionDbWord2 = int.Parse(versionDBs[1]);
            int versionWord3 = int.Parse(versions[2]);
            int versionDbWord3 = int.Parse(versionDBs[2]);

            if (versionWord1 > versionDbWord1)
            {
                XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (versionWord1 < versionDbWord1)
            {
                XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (versionWord1 == versionDbWord1)
            {
                if (versionWord2 > versionDbWord2)
                {
                    XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (versionWord2 < versionDbWord2)
                {
                    XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (versionWord2 == versionDbWord2)
                {

                    if (versionWord3 > versionDbWord3)
                    {
                        XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (versionWord3 < versionDbWord3)
                    {
                        XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + GlobalVariable.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// Loads the option.
        /// </summary>
        private static void LoadOption()
        {
            GlobalVariable.Register();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ResourceHelper.ResourceLanguage)
            {
                NumberFormat =
                    {
                        CurrencySymbol = GlobalVariable.CurrencySymbol ?? "" ,
                        CurrencyDecimalSeparator = GlobalVariable.GeneralDecimalSeparator??",",
                        CurrencyGroupSeparator = GlobalVariable.GeneralGroupSeparator??".",
                        CurrencyDecimalDigits = GlobalVariable.CurrencyDecimalDigits,

                        NumberDecimalSeparator = GlobalVariable.GeneralDecimalSeparator??",",
                        NumberGroupSeparator = GlobalVariable.GeneralGroupSeparator??"."
                    }
            };
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            var databaseName = RegistryHelper.GetValueByRegistryKey("DatabaseName");
            GlobalVariable.DatabaseName = databaseName;
            GlobalVariable.GetVersion();

            var serverConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
            {
                LoginSecure = false,
                Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
            };
            //create server
            var server = new Server(serverConnection);
            if (!server.Databases.Cast<Database>().Any(d => databaseName.Equals(d.Name)))
            {
                XtraMessageBox.Show("Dữ liệu bạn đang mở " + databaseName + " có thể bị lỗi, hoặc đã bị xóa không đúng quy cách. Vui lòng kiểm tra lại, hoặc chọn mở một cơ sở dữ liệu khác!",
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var filePath = server.Databases[databaseName].PrimaryFilePath + @"\" + databaseName + ".mdf";
            var ds = server.Databases["Master"].ExecuteWithResults("SET QUOTED_IDENTIFIER OFF EXEC xp_fileexist '" + filePath + "'");
            if (ds != null && Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
            {
                XtraMessageBox.Show("Tệp dữ liệu vật lý có đường dẫn [" + filePath + "] đã không tồn tại trên phân vùng ổ cứng. Vui lòng kiểm tra lại",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Check version 
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.ProductVersion;
            if (!GlobalVariable.IsAutoUpdateSQL && String.IsNullOrEmpty(GlobalVariable.FileListSQLUpdate))
            {
                if (version != GlobalVariable.Version)
                {
                    ValidVersion(version);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(this.UserName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResValidUserName"), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserProfileName.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}