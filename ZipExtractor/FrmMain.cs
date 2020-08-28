// ***********************************************************************
// Assembly         : ZipExtractor
// Author           : thangnd
// Created          : 10-03-2018
//
// Last Modified By : thangnd
// Last Modified On : 10-03-2018
// ***********************************************************************
// <copyright file="FrmMain.cs" company="RBSoft">
//     Copyright © 2012-2018 RBSoft
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using ZipExtractor.Properties;
using System.Security.Cryptography;
using System.Text;

namespace ZipExtractor
{
    /// <summary>
    /// Class FrmMain.
    /// </summary>
    public partial class FrmMain : Form
    {
        private BackgroundWorker _backgroundWorker;
        private string PathExtractBIN;
        private string PathExtractSQL;
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Shown event of the FormMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length < 3) return;
            //for (int pp = 0; pp < args.Length; pp++)
            //{
            //    MessageBox.Show(args[pp]);
            //}
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (!process.MainModule.FileName.Equals(args[2])) continue;
                    lblInformation.Text = @"Đang đợi chương trình kết thúc...";
                    process.WaitForExit();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }
            }

            // Extract all the files.
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += (o, eventArgs) =>
            {
                var path = Path.GetDirectoryName(args[2]);//Path extract SQL
                var pathoutlevel1 = Path.GetDirectoryName(path);//Path extract BIN

                //Remove readonly các file báo cáo
                var di = new DirectoryInfo(pathoutlevel1 + @"/REPORT");
                foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
                    file.Attributes &= ~FileAttributes.ReadOnly;

                //MessageBox.Show(path);
                //MessageBox.Show(pathoutlevel1);
                PathExtractSQL = path.ToString();
                PathExtractBIN = pathoutlevel1.ToString();

                // Open an existing zip file for reading.
                var zip = ZipStorer.Open(args[1], FileAccess.Read);

                // Read the central directory collection.
                var dir = zip.ReadCentralDir();
                #region Extract SQL

                if (!string.IsNullOrEmpty(args[3]))
                {
                    //var dir = zip.ReadCentralDir();
                    if (args.Length >= 4)
                    {
                        // Open an existing zip file for reading.
                        zip = ZipStorer.Open(args[3], FileAccess.Read);

                        // Read the central directory collection.
                        dir = zip.ReadCentralDir();

                        for (var index = 0; index < dir.Count; index++)
                        {
                            if (_backgroundWorker.CancellationPending)
                            {
                                eventArgs.Cancel = true;
                                zip.Close();
                                return;
                            }
                            var entry = dir[index];
                            //can xu ly them thi xu ly o dau cap nhat hien tai duoc bin cac thu muc trong bin
                            zip.ExtractFile(entry, Path.Combine(path, entry.FilenameInZip));
                            _backgroundWorker.ReportProgress((index + 1) * 100 / dir.Count,
                                string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip));
                        }
                    }
                }

                #endregion

                #region Extract BIN
                zip = ZipStorer.Open(args[1], FileAccess.Read);

                try
                {
                    // Read the central directory collection.
                    dir = zip.ReadCentralDir();
                    for (var index = 0; index < dir.Count; index++)
                    {
                        if (_backgroundWorker.CancellationPending)
                        {
                            eventArgs.Cancel = true;
                            zip.Close();
                            return;
                        }
                        var entry = dir[index];
                        zip.ExtractFile(entry, Path.Combine(pathoutlevel1, entry.FilenameInZip));
                        _backgroundWorker.ReportProgress((index + 1) * 100 / dir.Count,
                            string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip));
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    throw;
                }
                #endregion

                
                zip.Close();
            };

            _backgroundWorker.ProgressChanged += (o, eventArgs) =>
            {
                progressBar.Value = eventArgs.ProgressPercentage;
                lblInformation.Text = eventArgs.UserState.ToString();
            };

            _backgroundWorker.RunWorkerCompleted += (o, eventArgs) =>
            {
                if (!eventArgs.Cancelled)
                {
                    lblInformation.Text = @"Hoàn thành";
                    try
                    {
                        //Tìm SQL file nếu có để thực hiện update sau khi phần mềm dc chạy lại
                        //if (!Directory.Exists(PathExtractSQL + @"\SQL\"))
                        //{
                        //    Directory.CreateDirectory(PathExtractSQL + @"\SQL\");
                        //}
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(args[2]);
                        try
                        {
                            string[] fileSq = Directory.GetFiles(PathExtractSQL + @"\SQL\");
                            string argadd = @"SQL";
                            if (fileSq.Length > 0)
                            {
                                for (int i = 0; i < fileSq.Length; i++)
                                    argadd += @";" + fileSq[i].ToString();
                            }
                            processStartInfo.Arguments = Enc(argadd);
                        }
                        catch
                        {
                        }
                        //MessageBox.Show(fileSq.Length.ToString());
                        //for (int i = 0; i < fileSq.Length; i++)
                        //{
                        //    MessageBox.Show(fileSq[i]);
                        //}
                        //===========================================
                        //MessageBox.Show("");
                        Process.Start(processStartInfo);
                    }
                    catch (Win32Exception exception)
                    {
                        if (exception.NativeErrorCode != 1223) throw;
                    }
                    Application.Exit();
                }
            };
            _backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the FormClosing event of the FormMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backgroundWorker?.CancelAsync();
        }

        #region Encode & Decode

        public static string Enc(string text)
        {
            string EncryptionKey = "BuCA";
            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return text;
        }
        public static string Dec(string text)
        {
            string EncryptionKey = "BuCA";
            text = text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    text = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return text;
        }
        #endregion
    }
}
