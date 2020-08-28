// ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 10-01-2018
//
// Last Modified By : thangnd
// Last Modified On : 10-01-2018
// ***********************************************************************
// <copyright file="FrmDownloadUpdateDialog.cs" company="by adguard">
//     Copyright © by adguard 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Buca.AutoUpdater.Core;
using Buca.AutoUpdater.Properties;
using log4net;

namespace Buca.AutoUpdater
{
    /// <summary>
    /// Class FrmDownloadUpdateDialog.
    /// </summary>
    public partial class FrmDownloadUpdateDialog : Form
    {
        private readonly string _downloadURL;
        private readonly string _sqlurl;
        private AutoUpdaterWebClient _webClient;
        private string _tempFile;
        private DateTime _startedAt;
        private string PathSqlFile;

        private static readonly ILog LogAutoUpdater = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDownloadUpdateDialog"/> class.
        /// </summary>
        public FrmDownloadUpdateDialog(string downloadURL, string sqlurl)
        {
            InitializeComponent();
            _downloadURL = downloadURL;
            _sqlurl = sqlurl;
        }

        /// <summary>
        /// Handles the Load event of the FrmDownloadUpdateDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmDownloadUpdateDialog_Load(object sender, EventArgs e)
        {
            lblInstalledVersion.Text = AutoUpdaterPlugin.InstalledVersion == null ? null :
                string.Format("{0}.{1}.{2}", AutoUpdaterPlugin.InstalledVersion.Major, AutoUpdaterPlugin.InstalledVersion.Minor, AutoUpdaterPlugin.InstalledVersion.Build);
            if (!string.IsNullOrEmpty(_sqlurl))
                DownloadSQL();//Start download SQL
            else
                DownloadUpdateDialogLoad();//Start download BIN
        }

        /// <summary>
        /// Handles the FormClosing event of the FrmDownloadUpdateDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FrmDownloadUpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_webClient == null)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (_webClient.IsBusy)
            {
                _webClient.CancelAsync();
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        #region events

        /// <summary>
        /// Handles the <see cref="E:DownloadProgressChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DownloadProgressChangedEventArgs"/> instance containing the event data.</param>
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_startedAt == default(DateTime))
            {
                _startedAt = DateTime.Now;
            }
            else
            {
                var timeSpan = DateTime.Now - _startedAt;
                var totalSeconds = (long)timeSpan.TotalSeconds;
                if (totalSeconds > 0)
                {
                    var bytesPerSecond = e.BytesReceived / totalSeconds;
                    lblInformation.Text = string.Format(Resources.DownloadSpeedMessage, BytesToString(bytesPerSecond));
                }
            }
            lblSize.Text = string.Format(@"{0} / {1}", BytesToString(e.BytesReceived), BytesToString(e.TotalBytesToReceive));
            progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Webs the client on download file completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="asyncCompletedEventArgs">The <see cref="AsyncCompletedEventArgs"/> instance containing the event data.</param>
        private void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            if (asyncCompletedEventArgs.Cancelled)
            {
                return;
            }
            if (asyncCompletedEventArgs.Error != null)
            {
                MessageBox.Show(asyncCompletedEventArgs.Error.Message, asyncCompletedEventArgs.Error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _webClient = null;
                Close();
                return;
            }
            if (!string.IsNullOrEmpty(AutoUpdaterPlugin.Checksum))
            {
                if (!CompareChecksum(_tempFile, AutoUpdaterPlugin.Checksum))
                {
                    _webClient = null;
                    Close();
                    return;
                }
            }

            string fileName;
            var contentDisposition = _webClient.ResponseHeaders["Content-Disposition"] ?? string.Empty;
            if (string.IsNullOrEmpty(contentDisposition))
            {
                fileName = Path.GetFileName(_webClient.ResponseUri.LocalPath);
            }
            else
            {
                fileName = TryToFindFileName(contentDisposition, "filename=");
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = TryToFindFileName(contentDisposition, "filename*=UTF-8''");
                }
            }
            var tempPath = Path.Combine(string.IsNullOrEmpty(AutoUpdaterPlugin.DownloadPath) ? Path.GetTempPath() : AutoUpdaterPlugin.DownloadPath, fileName);
            try
            {
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
                File.Move(_tempFile, tempPath);
            }
            catch (Exception e)
            {
                LogAutoUpdater.Error(e.Message);
                MessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _webClient = null;
                Close();
                return;
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = tempPath,
                UseShellExecute = true,
                Arguments = AutoUpdaterPlugin.InstallerArgs.Replace("%path%", Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName))
            };
            var extension = Path.GetExtension(tempPath);

            //tam thoi thangnd xu ly file zip truoc da
            if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
            {
                var installerPath = Path.Combine(Path.GetDirectoryName(tempPath), "ZipExtractor.exe");
                File.WriteAllBytes(installerPath, Resources.ZipExtractor);
                var arguments = new StringBuilder(string.Format("\"{0}\" \"{1}\" \"{2}\"", tempPath, Process.GetCurrentProcess().MainModule.FileName, PathSqlFile));
                var args = Environment.GetCommandLineArgs();
                for (var i = 1; i < args.Length; i++)
                {
                    if (i.Equals(1)) arguments.Append(" \"");
                    arguments.Append(args[i]);
                    arguments.Append(i.Equals(args.Length - 1) ? "\"" : " ");
                }
                processStartInfo = new ProcessStartInfo
                {
                    FileName = installerPath,
                    UseShellExecute = true,
                    Arguments = arguments.ToString()
                };
            }

            if (AutoUpdaterPlugin.RunUpdateAsAdmin)
            {
                processStartInfo.Verb = "runas";
            }

            try
            {
                Process.Start(processStartInfo);
            }
            catch (Win32Exception exception)
            {
                _webClient = null;
                if (exception.NativeErrorCode != 1223) throw;
            }

            Close();
        }

        #endregion

        #region private helper

        private void DownloadSQL()
        {
            _webClient = new AutoUpdaterWebClient { CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore) };
            var uri = new Uri(_sqlurl);
            if (AutoUpdaterPlugin.Proxy != null) _webClient.Proxy = AutoUpdaterPlugin.Proxy;

            if (string.IsNullOrEmpty(AutoUpdaterPlugin.DownloadPath))
            {
                _tempFile = Path.GetTempFileName();
            }
            else
            {
                _tempFile = Path.Combine(AutoUpdaterPlugin.DownloadPath, string.Format("{0}.tmp", Guid.NewGuid()));
                if (!Directory.Exists(AutoUpdaterPlugin.DownloadPath))
                {
                    Directory.CreateDirectory(AutoUpdaterPlugin.DownloadPath);
                }
            }
            _webClient.DownloadProgressChanged += OnDownloadProgressChanged;
            _webClient.DownloadFileCompleted += DownloadSQLCompleted;
            _webClient.DownloadFileAsync(uri, _tempFile);
        }

        private void DownloadSQLCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {

            string fileName;
            var contentDisposition = _webClient.ResponseHeaders["Content-Disposition"] ?? string.Empty;
            if (string.IsNullOrEmpty(contentDisposition))
            {
                fileName = Path.GetFileName(_webClient.ResponseUri.LocalPath);
            }
            else
            {
                fileName = TryToFindFileName(contentDisposition, "filename=");
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = TryToFindFileName(contentDisposition, "filename*=UTF-8''");
                }
            }
            var tempPath = Path.Combine(string.IsNullOrEmpty(AutoUpdaterPlugin.DownloadPath) ? Path.GetTempPath() : AutoUpdaterPlugin.DownloadPath, fileName);
            try
            {
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
                File.Move(_tempFile, tempPath);
                PathSqlFile = tempPath.ToString();
            }
            catch (Exception e)
            {
                LogAutoUpdater.Error(e.Message);
                MessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _webClient = null;
                Close();
                return;
            }
            DownloadUpdateDialogLoad();//Start download BIN
        }
        /// <summary>
        /// Downloads the update dialog load.
        /// </summary>
        private void DownloadUpdateDialogLoad()
        {
            _webClient = new AutoUpdaterWebClient { CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore) };
            var uri = new Uri(_downloadURL);
            if (AutoUpdaterPlugin.Proxy != null) _webClient.Proxy = AutoUpdaterPlugin.Proxy;

            if (string.IsNullOrEmpty(AutoUpdaterPlugin.DownloadPath))
            {
                _tempFile = Path.GetTempFileName();
            }
            else
            {
                _tempFile = Path.Combine(AutoUpdaterPlugin.DownloadPath, string.Format("{0}.tmp", Guid.NewGuid()));
                if (!Directory.Exists(AutoUpdaterPlugin.DownloadPath))
                {
                    Directory.CreateDirectory(AutoUpdaterPlugin.DownloadPath);
                }
            }
            _webClient.DownloadProgressChanged += OnDownloadProgressChanged;
            _webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;
            _webClient.DownloadFileAsync(uri, _tempFile);
        }

        /// <summary>
        /// Byteses to string.
        /// </summary>
        /// <param name="byteCount">The byte count.</param>
        /// <returns>System.String.</returns>
        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0) return "0" + suf[0];
            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            var num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return string.Format("{0} {1}", (Math.Sign(byteCount) * num).ToString(CultureInfo.InvariantCulture), suf[place]);
        }

        /// <summary>
        /// Compares the checksum.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="checksum">The checksum.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool CompareChecksum(string fileName, string checksum)
        {
            using (var hashAlgorithm = HashAlgorithm.Create(AutoUpdaterPlugin.HashingAlgorithm))
            {
                using (var stream = File.OpenRead(fileName))
                {
                    if (hashAlgorithm != null)
                    {
                        var hash = hashAlgorithm.ComputeHash(stream);
                        var fileChecksum = BitConverter.ToString(hash).Replace("-", String.Empty).ToLowerInvariant();

                        if (fileChecksum == checksum.ToLower()) return true;

                        MessageBox.Show(Resources.FileIntegrityCheckFailedMessage, Resources.FileIntegrityCheckFailedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (AutoUpdaterPlugin.ReportErrors)
                        {
                            MessageBox.Show(Resources.HashAlgorithmNotSupportedMessage, Resources.HashAlgorithmNotSupportedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Tries the name of to find file.
        /// </summary>
        /// <param name="contentDisposition">The content disposition.</param>
        /// <param name="lookForFileName">Name of the look for file.</param>
        /// <returns>System.String.</returns>
        private static string TryToFindFileName(string contentDisposition, string lookForFileName)
        {
            var fileName = string.Empty;
            if (string.IsNullOrEmpty(contentDisposition)) return fileName;
            var index = contentDisposition.IndexOf(lookForFileName, StringComparison.CurrentCultureIgnoreCase);
            if (index >= 0) fileName = contentDisposition.Substring(index + lookForFileName.Length);
            if (!fileName.StartsWith("\"")) return fileName;
            var file = fileName.Substring(1, fileName.Length - 1);
            var i = file.IndexOf("\"", StringComparison.CurrentCultureIgnoreCase);
            if (i != -1)
            {
                fileName = file.Substring(0, i);
            }
            return fileName;
        }

        #endregion
    }
}
