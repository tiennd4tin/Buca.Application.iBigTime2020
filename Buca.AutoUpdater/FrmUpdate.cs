 // ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 09-29-2018
//
// Last Modified By : thangnd
// Last Modified On : 10-01-2018
// ***********************************************************************
// <copyright file="FrmUpdate.cs" company="by adguard">
//     Copyright © by adguard 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Buca.AutoUpdater.Core;

namespace Buca.AutoUpdater
{
    /// <summary>
    /// Class FrmUpdate.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmUpdate : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmUpdate"/> class.
        /// </summary>
        public FrmUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtPath.Text))
            //{
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description =
                    "Lựa chọn thư mục để tải bản cập nhật \nLưu ý: Không cần thiết phải là thư mục cài đặt phần mềm";
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                AutoUpdaterPlugin.DownloadPath = folderBrowserDialog.SelectedPath;
            //}
            //txtPath.Text = AutoUpdaterPlugin.DownloadPath.ToString();
            if (AutoUpdaterPlugin.OpenDownloadPage)
            {
                var processStartInfo = new ProcessStartInfo(AutoUpdaterPlugin.DownloadURL);
                Process.Start(processStartInfo);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (AutoUpdaterPlugin.DownloadUpdate())
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the FrmUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void FrmUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AutoUpdaterPlugin.Running = true;
        }

        /// <summary>
        /// Handles the Load event of the FrmUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            lblInstalledVersion.Text = AutoUpdaterPlugin.InstalledVersion == null ? null :
                string.Format("{0}.{1}.{2}", AutoUpdaterPlugin.InstalledVersion.Major, AutoUpdaterPlugin.InstalledVersion.Minor, AutoUpdaterPlugin.InstalledVersion.Build);

            lblUpdate.Text = string.Format("Phiên bản mới nhất {0} trên máy chủ đã sẵn sàng", AutoUpdaterPlugin.CurrentVersion);
            lblDescription.Text = string.Format("Phiên bản {0} cho sản phẩm I-BIGTIME đã sẵn sàng trên máy chủ, Bạn có thực sự muốn cập nhật phiên bản này?", AutoUpdaterPlugin.CurrentVersion);

            if (!string.IsNullOrEmpty(AutoUpdaterPlugin.ChangelogURL))
            {
                //webBrowser.Navigate(AutoUpdaterPlugin.ChangelogURL);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //txtPath.Text = "";
            AutoUpdaterPlugin.Running = false;
            Close();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description =
                "Lựa chọn thư mục để tải bản cập nhật \nLưu ý: Không cần thiết phải là thư mục cài đặt phần mềm";
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            AutoUpdaterPlugin.DownloadPath = folderBrowserDialog.SelectedPath;
            //txtPath.Text = AutoUpdaterPlugin.DownloadPath.ToString();
        }
    }
}
