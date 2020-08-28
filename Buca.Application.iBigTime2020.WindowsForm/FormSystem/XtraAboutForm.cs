﻿/***********************************************************************
 * <copyright file="XtraAboutForm.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Thursday, August 29, 2013
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// About form
    /// </summary>
    public partial class XtraAboutForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XtraAboutForm"/> class.
        /// </summary>
        public XtraAboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the XtraAboutForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void XtraAboutForm_Load(object sender, EventArgs e)
        {
            //lblTitle.Text = CommonClass.AssemblyInfomation.Title;
            //lblVersion.Text = String.Format("Version {0} (R{1})", CommonClass.AssemblyInfomation.AssemblyVersion, CommonClass.AssemblyInfomation.FileVersion);
            //lblCopyright.Text = CommonClass.AssemblyInfomation.Copyright;
            //lblDescription.Text = CommonClass.AssemblyInfomation.Description;

            lblTitle.Text = @"I-BIGTIME TT79";
            lblVersion.Text = AssemblyInfomation.AssemblyVersion;
            lblCopyright.Text = AssemblyInfomation.Copyright;
            lblDescription.Text = @"PHẦN MỀM KẾ TOÁN CHỦ ĐẦU TƯ";


            lblCompanyName.Text = GlobalVariable.CompanyName;
            lblCompanyAddress.Text = GlobalVariable.CompanyAddress;
            lblLicenseNumber.Text = GlobalVariable.LicenseNumber;
            LoadVersionInfo();
        }

        private void LoadVersionInfo()
        {
            //var versionInfoPath = System.Windows.Forms.Application.StartupPath + @"\VersionInfo.rtf";
            //if(!string.IsNullOrEmpty(versionInfoPath))
            //    richVersionInfoTextBox.LoadFile(versionInfoPath);
            //else
            //{
            //    richVersionInfoTextBox.Text = @"Tệp thông tin cập nhật không tồn tại. Vui lòng kiểm tra lại";
            //}
        }

        /// <summary>
        /// Handles the LinkClicked event of the lblWebsite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lblWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.buca.vn");
        }

        /// <summary>
        /// Handles the LinkClicked event of the lblEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lblEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string sbodytext = "Xin chao! %0AChung toi muon mua san pham phan mem cua quy cong ty, hay goi lai cho chung toi theo so dien thoai: %0A";
            System.Diagnostics.Process.Start("mailto:head@buca.vn?subject=CHUNG TOI MUON MUA SAN PHAM NAY &body=" + sbodytext);
        }

        /// <summary>
        /// Handles the SelectedPageChanged event of the xtraTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTab.TabPageChangedEventArgs"/> instance containing the event data.</param>
        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == xtraTabContactPage.Name)
            {
                btnContact.Visible = false;
                btnBack.Visible = true;
                btnBack.Focus();
            }
            else
            {
                btnContact.Visible = true;
                btnBack.Visible = false;
                btnContact.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            xtraTabAboutPage.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the btnContact control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnContact_Click(object sender, EventArgs e)
        {
            xtraTabContactPage.Visible = true;
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

        private void btnVersionInfo_Click(object sender, EventArgs e)
        {
            xtraTabVersionInfoPage.Visible = true;
        }
    }
}