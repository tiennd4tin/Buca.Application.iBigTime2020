/***********************************************************************
 * <copyright file="FrmXtraRegister.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, June 16, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Option;
using DevExpress.CodeParser;
using System.Configuration;
using Buca.Application.iBigTime2020.WindowsForm.Code;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// Register License info
    /// </summary>
    public partial class FrmXtraRegister : XtraForm
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid license.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid license; otherwise, <c>false</c>.
        /// </value>
        private bool IsValidLicense { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        private string FileName { get; set; }

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraRegister"/> class.
        /// </summary>
        public FrmXtraRegister()
        {
            InitializeComponent();
            _model = new Model.Model();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Dictionary<string, object> json_Dictionary;

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariable.IsValidLicense && IsValidLicense)
                {
                    if (FileName == System.Windows.Forms.Application.StartupPath + @"\License.lic")
                    {
                        XtraMessageBox.Show("Thông tin bản quyền này đang được sử dụng trong chương trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (
                        XtraMessageBox.Show("Thông tin bản quyền đã tồn tại. Bạn có muốn ghi đè dữ liệu không?",
                            "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                    FileHelper.CopyFileStream(FileName, System.Windows.Forms.Application.StartupPath + @"\License.lic");

                    //Gen lại file license (tạm thời chưa dùng)
                    //FileHelper.CreateFileLicense(
                    //    FileHelper.DecryptDataServer(json_Dictionary["companyCode"].ToString()),
                    //    FileHelper.DecryptDataServer(json_Dictionary["customerName"].ToString()),
                    //    FileHelper.DecryptDataServer(json_Dictionary["customerAddress"].ToString()),
                    //    FileHelper.DecryptDataServer(json_Dictionary["customerParent"].ToString()),
                    //    FileHelper.DecryptDataServer(json_Dictionary["directoryName"].ToString()),
                    //    "License.lic", "",
                    //    DateTime.ParseExact(FileHelper.DecryptDataServer(json_Dictionary["expriedDate"].ToString()), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //    FileHelper.DecryptDataServer(json_Dictionary["licenseNumber"].ToString())
                    //);

                    XtraMessageBox.Show("Cập nhật thông tin bản quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GlobalVariable.CompanyName = lblCompanyName.Text;
                    GlobalVariable.CompanyAddress = lblCompanyAddress.Text;
                    GlobalVariable.CompanyInCharge = lblCompanyInCharge.Text;
                    GlobalVariable.CompanyOwner = lblCompanyOwner.Text;
                    GlobalVariable.OwnerCompanyName = lblCompanyInCharge.Text;
                    GlobalVariable.LicenseNumber = lblLicenseNumber.Text;                                   
                    GlobalVariable.TimeExpried = DateTime.ParseExact(lblExpriedTime.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var dbOptions = new List<DBOptionModel>();

                    dbOptions.Add(
                        new DBOptionModel
                        {
                            OptionId = "CompanyName",
                            OptionValue = lblCompanyName.Text,
                            ValueType = 0,
                            IsSystem = true,
                            Description = @"Tên đơn vị"
                        }
                            );
                    dbOptions.Add(
                         new DBOptionModel
                         {
                             OptionId = "CompanyAdrress",
                             OptionValue = lblCompanyAddress.Text,
                             ValueType = 0,
                             IsSystem = true,
                             Description = @"Địa chỉ đơn vị"
                         }
                             );
                    dbOptions.Add(
                         new DBOptionModel
                         {
                             OptionId = "OwnerCompanyName",
                             OptionValue = lblCompanyInCharge.Text,
                             ValueType = 0,
                             IsSystem = true,
                             Description = @"Tên đơn vị chủ quản"
                         }
                             );

                    foreach (var dbOption in dbOptions)
                    {
                        _model.UpdateDBOption(dbOption);
                    }

                    //restart chuong trinhf
                    System.Windows.Forms.Application.Exit();
                    System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);

                }
                else
                {
                    if (!IsValidLicense) return;
                    FileHelper.CopyFileStream(FileName, System.Windows.Forms.Application.StartupPath + @"\License.lic");
                    XtraMessageBox.Show("Cập nhật thông tin bản quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Handles the ButtonClick event of the btnBrowseFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnBrowseFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = ResourceHelper.GetResourceValueByName("ResLicenseTitle");
                dlg.Filter = ResourceHelper.GetResourceValueByName("ResLicenseExtendFile");

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    btnBrowseFile.Text = dlg.FileName;
                    if (File.Exists(dlg.FileName))
                    {
                        FileName = dlg.FileName;
                        var s = FileHelper.DecryptFile(dlg.FileName);
                        if (string.IsNullOrEmpty(s))
                        {
                            btnBrowseFile.Focus();
                            return;
                        }
                        var info = new string[10];
                        var oCrypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
                        IsValidLicense = oCrypto.CheckLicense(s, true, ref info);
                        if (IsValidLicense)//Check file hợp lệ
                        {
                            try
                            {
                                //============Lấy thông tin từ server================Phần này tạm thời chưa dùng
                                //string urlData = String.Empty;
                                //urlData = CommonFunction.GetLicenseInforFromServer("ServerLicense",
                                //    info[4].ToString(CultureInfo.InvariantCulture));
                                //Đưa vào json
                                //json_Dictionary = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(urlData);
                                //if (json_Dictionary.Count >= 8)//8 là số field ít nhất trả về từ server
                                //{
                                //Đưa thông tin get dc về lên textbox (Phần này get online, tạm thời chưa dùng)
                                //lblCompanyInCharge.Text = FileHelper.DecryptDataServer(json_Dictionary["customerParent"].ToString());
                                //lblCompanyName.Text = FileHelper.DecryptDataServer(json_Dictionary["customerName"].ToString());
                                //lblCompanyAddress.Text = FileHelper.DecryptDataServer(json_Dictionary["customerAddress"].ToString());
                                //lblCompanyOwner.Text = FileHelper.DecryptDataServer(json_Dictionary["directoryName"].ToString());
                                //lblLicenseNumber.Text = FileHelper.DecryptDataServer(json_Dictionary["licenseNumber"].ToString()).ToUpper();
                                //lblExpriedTime.Text = FileHelper.DecryptDataServer(json_Dictionary["expriedDate"].ToString());

                                //Dùng cách cũ
                                lblCompanyInCharge.Text = info[0].ToString(CultureInfo.InvariantCulture);
                                lblCompanyName.Text = info[1].ToString(CultureInfo.InvariantCulture);
                                lblCompanyAddress.Text = info[2].ToString(CultureInfo.InvariantCulture);
                                lblCompanyOwner.Text = info[3].ToString(CultureInfo.InvariantCulture);
                                lblLicenseNumber.Text = info[4].ToString(CultureInfo.InvariantCulture).ToUpper();
                                lblExpriedTime.Text = info[5].ToString(CultureInfo.InvariantCulture);
                                GlobalVariable.IsValidLicense = true;

                                //}
                                //else
                                //{
                                //    XtraMessageBox.Show("Không lấy được thông tin bản quyền, vui lòng kiểm tra lại!", "Cảnh báo",
                                //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //}
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("Không lấy được thông tin bản quyền, vui lòng kiểm tra lại!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            //foreach (var item in json_Dictionary)
                            //{
                            //    MessageBox.Show(item.Key.ToString() + ": " + FileHelper.DecryptDataServer(item.Value.ToString()));
                            //    // parse here
                            //}
                        }
                        else
                        {
                            XtraMessageBox.Show("Thông tin bản quyền không đúng, vui lòng kiểm tra lại!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

            }
        }



        /// <summary>
        /// Handles the Load event of the FrmXtraRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraRegister_Load(object sender, EventArgs e)
        {
            lblCompanyName.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyName;
            lblCompanyAddress.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyAddress;
            lblCompanyInCharge.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyInCharge;
            lblCompanyOwner.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyOwner;
            lblLicenseNumber.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.LicenseNumber.ToUpper(); ;
            lblExpriedTime.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.TimeExpried.Year.Equals(0001) ? "" : GlobalVariable.TimeExpried.ToString("dd/MM/yyyy");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1050));
        }
    }
}