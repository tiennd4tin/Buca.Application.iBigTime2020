/***********************************************************************
 * <copyright file="CommonFunction.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Sunday, February 09, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Option;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Ionic.Zip;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.XtraEditors.Controls;
using System.Threading;
using System.Web.Script.Serialization;

namespace Buca.Application.iBigTime2020.WindowsForm.Code
{
    public class CommonFunction
    {

        public static XtraUserControl CommonUserControl;
        /// <summary>
        /// Using to add user control to panel
        /// </summary>
        /// <param name="oContainerPanel">Panel of Mainform contain UserControl </param>
        /// <param name="oXtraUserControl">UserControl to add Panel</param>
        /// <param name="oType">Type of UserControl</param>
        public static void AddCotrolToPanel(XtraPanel oContainerPanel, XtraUserControl oXtraUserControl, Type oType)
        {
            try
            {
                if (oContainerPanel.Controls.Count > 0)
                {
                    var no = false;
                    // ReSharper disable once UnusedVariable
                    foreach (var control in oContainerPanel.Controls.Cast<object>().Where(control => control.GetType() == oType))
                    {
                        no = true;
                    }
                    if (no == false)
                    {
                        oContainerPanel.Controls.Clear();
                        oContainerPanel.Controls.Add(oXtraUserControl);
                    }
                }
                else
                {
                    oContainerPanel.Controls.Add(oXtraUserControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Run User Control
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="oContainerPanel"></param>
        public static void RunUserControl(XtraUserControl userControl, XtraPanel oContainerPanel)
        {
            if (CommonUserControl == null)
            {
                CommonUserControl = userControl;
                AddCotrolToPanel(oContainerPanel, CommonUserControl, typeof(XtraUserControl));
            }
            else
            {
                if (CommonUserControl.GetType() != userControl.GetType())
                {
                    CommonUserControl = userControl;
                    AddCotrolToPanel(oContainerPanel, CommonUserControl, typeof(XtraUserControl));
                }
            }
        }

        private static Thread thr;
        public static bool GetLicenseInfo()
        {
            if (File.Exists("License.lic"))
            {
                var oCrypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
                var s = FileHelper.DecryptFile("License.lic");
                var info = new string[10];
                GlobalVariable.IsValidLicense = oCrypto.CheckLicense(s, true, ref info);
                if (GlobalVariable.IsValidLicense)
                {
                    GlobalVariable.CompanyInCharge = info[0].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyName = info[1].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyAddress = info[2].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyOwner = info[3].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.LicenseNumber = info[4].ToString(CultureInfo.InvariantCulture);
                    if (info[5] != null) //Nếu field này null => thuộc hệ thống license cũ
                    {
                        GlobalVariable.TimeExpried = DateTime.ParseExact(info[5].ToString(CultureInfo.InvariantCulture), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        //AnhNT: Tự động thực hiện update license mới cho hệ thống license cũ (tạm thời chưa dùng)
                        //thr =
                        //    new Thread(() => UpdateLicenseFromOldVersion(info[4].ToString(CultureInfo.InvariantCulture)));
                        //thr.Start();
                    }
                    return true;
                }
                GlobalVariable.CompanyInCharge = "Phiên bản chưa đăng ký bản quyền";
                GlobalVariable.CompanyName = "Vui lòng liên hệ với tác giả";
                GlobalVariable.CompanyAddress = "Công ty cổ phần BuCA";
                GlobalVariable.CompanyOwner = "Phiên bản chưa đăng ký bản quyền";
                GlobalVariable.LicenseNumber = "Phiên bản chưa đăng ký bản quyền";
                return false;
            }
            GlobalVariable.CompanyInCharge = "Phiên bản chưa đăng ký bản quyền";
            GlobalVariable.CompanyName = "Vui lòng liên hệ với tác giả";
            GlobalVariable.CompanyAddress = "Công ty cổ phần BuCA";
            GlobalVariable.CompanyOwner = "Phiên bản chưa đăng ký bản quyền";
            GlobalVariable.LicenseNumber = "Phiên bản chưa đăng ký bản quyền";
            return false;
        }

        /// <summary>
        /// Thực hiện update license với phiên bản phần mềm cũ
        /// </summary>
        private static void UpdateLicenseFromOldVersion(string keyID)
        {
            try
            {
                string urlData = String.Empty;
                urlData = CommonFunction.GetInforFromServer("ServerLicenseOld",
                    keyID);
                Dictionary<string, object>  json_Dictionary = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(urlData);
                if (json_Dictionary.Count >= 8) //8 là số field ít nhất trả về từ server
                {
                    FileHelper.CreateFileLicense(
                        FileHelper.DecryptDataServer(json_Dictionary["companyCode"].ToString()),
                        FileHelper.DecryptDataServer(json_Dictionary["customerName"].ToString()),
                        FileHelper.DecryptDataServer(json_Dictionary["customerAddress"].ToString()),
                        FileHelper.DecryptDataServer(json_Dictionary["customerParent"].ToString()),
                        FileHelper.DecryptDataServer(json_Dictionary["directoryName"].ToString()),
                        "License.lic", "",
                        DateTime.ParseExact(FileHelper.DecryptDataServer(json_Dictionary["expriedDate"].ToString()), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        FileHelper.DecryptDataServer(json_Dictionary["licenseNumber"].ToString())
                    );
                    GlobalVariable.CompanyName = FileHelper.DecryptDataServer(json_Dictionary["customerName"].ToString());
                    GlobalVariable.CompanyAddress = FileHelper.DecryptDataServer(json_Dictionary["customerAddress"].ToString());
                    GlobalVariable.CompanyInCharge = FileHelper.DecryptDataServer(json_Dictionary["customerParent"].ToString());
                    GlobalVariable.CompanyOwner = FileHelper.DecryptDataServer(json_Dictionary["directoryName"].ToString());
                    GlobalVariable.OwnerCompanyName = FileHelper.DecryptDataServer(json_Dictionary["customerParent"].ToString());
                    GlobalVariable.LicenseNumber = FileHelper.DecryptDataServer(json_Dictionary["licenseNumber"].ToString());
                    GlobalVariable.TimeExpried = DateTime.ParseExact(FileHelper.DecryptDataServer(json_Dictionary["expriedDate"].ToString()), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Lấy thông tin license từ server
        /// </summary>
        /// <param name="typeLink">lấy trong app config</param>
        /// <param name="keyID">company code hoặc license number</param>
        /// <returns></returns>
        public static string GetInforFromServer(string typeLink, string keyID)
        {
            try
            {
                WebClient wc = new WebClient();
                return wc.DownloadString(FileHelper.DecryptDataServer(ConfigurationManager.AppSettings[typeLink]) +
                                         FileHelper.EncryptDataServer(keyID));
            }
            catch (Exception e)
            {
                return "";
            }

        }

        /// <summary>
        /// LinhMC thay đổi cách list dữ liệu
        /// Cách cũ bị lỗi thiếu bộ nhớ
        /// Gets the database names.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="ownerName">Name of the owner.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static List<DatabaseModel> GetDatabaseNames(string serverName, string ownerName, string password)
        {
            var databaseNames = new List<DatabaseModel>();
            string connString;
            if (GlobalVariable.Server != null)
                connString = GlobalVariable.Server.ConnectionContext.ConnectionString;
            else
                connString = "Data Source=" + serverName + "; User Id = " + ownerName + "; Password= " + password;

            if (string.IsNullOrEmpty(connString))
                return databaseNames;
            using (var cn = new SqlConnection(connString))
            {
                cn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT SYSDATABASES.DBID,SYSDATABASES.Name, SYSDATABASES.CrDate, SYSDATABASES.FileName FROM SYSDATABASES " +
                                      "WHERE SYSDATABASES.Name NOT IN('master','tempdb','model','msdb') AND LEFT(SYSDATABASES.Name,13) <> 'ReportServer$'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while ((reader.Read()))
                        {
                            databaseNames.Add(new DatabaseModel(reader["Name"].ToString(), reader["FileName"].ToString()));
                        }
                    }
                }
                cn.Close();
            }
            return databaseNames;
        }

        /// <summary>
        /// Backups the database.
        /// </summary>
        /// <returns></returns>
        public static bool BackupDatabase(SplashScreenManager splashScreenManager, string backupName, bool openBackupFolder)
        {
            try
            {
                if (splashScreenManager != null)
                {
                    splashScreenManager.ShowWaitForm();
                    splashScreenManager.SetWaitFormCaption("Đang sao lưu dữ liệu");
                    splashScreenManager.SetWaitFormDescription("Vui lòng đợi ..");
                }

                var databaseNameForBackup = RegistryHelper.GetValueByRegistryKey("DatabaseName");
                var databaseForBackup = GlobalVariable.Server.Databases[databaseNameForBackup];
                var backup = new Backup
                {
                    //option for backup
                    Action = BackupActionType.Database,
                    BackupSetDescription = "Sao lưu CSDL, ngày " + DateTime.Now,
                    BackupSetName = databaseNameForBackup + " Backup",
                    Database = databaseForBackup.Name
                };

                //create backupdevice
                var folderBackup = GlobalVariable.DailyBackupPath;
                var dateTimeString = "NG" + DateTime.Now.Day.ToString(CultureInfo.InvariantCulture) +
                                     "T" + DateTime.Now.Month.ToString(CultureInfo.InvariantCulture) +
                                     "N" + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) +
                                     "_" + DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture) + "GI" +
                                     DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture) + "P";

                var databaseName = databaseNameForBackup + "_" + (string.IsNullOrEmpty(backupName) ? "" : backupName) + "_" + dateTimeString + ".bak";

                //LINHMC kiem tra neu folder ko ton tai thi tao
                if (string.IsNullOrEmpty(folderBackup))
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    if (allDrives.Length > 1)
                    {
                        folderBackup = allDrives[1].Name + @"BACKUP_A_BIGTIME";
                    }
                    else
                    {
                        folderBackup = allDrives[0].Name + @"BACKUP_A_BIGTIME";
                    }

                }
                if (!Directory.Exists(folderBackup))
                {
                    Directory.CreateDirectory(folderBackup);
                }

                var fileBackup = folderBackup + @"\" + databaseName;
                if (File.Exists(fileBackup))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFileBackupExits"),
                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                var backupDevice = new BackupDeviceItem(fileBackup, DeviceType.File);

                backup.Devices.Add(backupDevice);
                backup.Incremental = false;

                backup.SqlBackup(GlobalVariable.Server);

                //Cách nén file này chỉ dùng trong trường hợp hệ quản trị dữ liệu và chương trình cùng nằm trên 1 máy
                using (var zip = new ZipFile())
                {
                    zip.AddFile(fileBackup, "");
                    var zipFileName = fileBackup.Replace(".bak", ".zip");
                    zip.ParallelDeflateThreshold = -1;
                    zip.Save(zipFileName);
                    File.Delete(fileBackup);
                }
                if (splashScreenManager != null)
                {
                    splashScreenManager.CloseWaitForm();
                }

                if (openBackupFolder)
                {
                    Process.Start(folderBackup);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (splashScreenManager != null)
                {
                    splashScreenManager.CloseWaitForm();
                }
                XtraMessageBox.Show("Không thể sao lưu dữ liệu. Vui lòng kiểm tra lại đường dẫn sao lưu hoặc quyền thao tác chức năng này!",
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString(CultureInfo.InvariantCulture).ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Checks the permission use form master.
        /// </summary>
        /// <param name="barToolsItemLink">The bar tools item link.</param>
        /// <param name="userFeaturePermisions">The user feature permisions.</param>
        public static void CheckPermissionUseFormMaster(BarButtonItem barToolsItemLink, List<UserFeaturePermisionModel> userFeaturePermisions)
        {
            switch (barToolsItemLink.Name)
            {
                /*them*/
                case "barButtonAddNewItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("add")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*sua*/
                case "barButtonEditItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("edit")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*xoa*/
                case "barButtonDeleteItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("delete")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*in*/
                case "barButtonPrintItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("print")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*in the TSCD*/
                case "barButtonPrintFixedAssetItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("printfixedassetitem")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*phan quyen*/
                case "barButtonItemRole":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("userpermission")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*tim kiem*/
                case "barButtonFind":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("search")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*nhan ban*/
                case "barButtonDuplicate":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("duplicate")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*tinh gia*/
                case "barButtonCalculatePriceItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && x.UserPermisionModel.Code.ToLower().Equals("calculatepriceitem")) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                /*luu*/
                case "barButtonSaveItem":
                    barToolsItemLink.Visibility = userFeaturePermisions.Count(x => x.UserPermisionModel != null && (x.UserPermisionModel.Code.ToLower().Equals("edit") || x.UserPermisionModel.Code.ToLower().Equals("add"))) > 0
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
                    break;
                default:
                    barToolsItemLink.Visibility = BarItemVisibility.Always;
                    break;
            }
        }

        #region Thêm danh mục
        /// <summary>
        /// Thêm button vào lookupedit thêm mới 1 danh mục khác
        /// </summary>
        public static void AddButtonNew(LookUpEdit look, string CaptionButton, Type TypeFormDetail, Delegate RecallFunction)
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject = new DevExpress.Utils.SerializableAppearanceObject();
            look.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Plus, "", -1, true, true, false, ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject, CaptionButton, "Add", null, true) });
            _typeFormDetail = TypeFormDetail;
            _recallFunction = RecallFunction;
            look.ButtonClick += Look_ButtonClick;
        }
        static Delegate _recallFunction;
        static Type _typeFormDetail;
        private static void Look_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus && Convert.ToString(e.Button.Tag).Equals("Add"))
            {
                var form = (Form)Activator.CreateInstance(_typeFormDetail);
                if (form != null)
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        LookUpEdit look = sender as LookUpEdit;
                        if (look != null && look.TopLevelControl != null && _recallFunction != null)
                            look.TopLevelControl.Invoke(_recallFunction);
                    }
                }
            }
        }

        public static string ConvertToString(object obj)
        {
            if (obj == null)
                return null;
            return Convert.ToString(obj);
        }
        #endregion
    }

    /// <summary>
    /// Accounting BalanceSide
    /// </summary>
    public class BalanceSide
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BalanceSide(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class ObjectIdAndName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ObjectIdAndName(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
