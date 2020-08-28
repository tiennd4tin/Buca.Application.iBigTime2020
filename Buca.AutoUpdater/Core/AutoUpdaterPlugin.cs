// ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 09-29-2018
//
// Last Modified By : thangnd
// Last Modified On : 09-29-2018
// ***********************************************************************
// <copyright file="AutoUpdater.cs" company="by adguard">
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
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Buca.AutoUpdater.Properties;
using log4net;
using Microsoft.Win32;
/*AnhNT
 * Quy chuẩn thực hiện hệ thống auto update, 
 * Link check update nằm ở GlobalVariable.LinkServerUpdate
 * Nội dung File AutoUpdate.xml:
 * Số version để trong note: version
 * Link download file udpate mới nhất để trong note: url
 * Link download file udpate các phiên bản cũ để trong note: url + version (VD: url150)
 * Link download file SQL để trong note: sql-<newviersion>-<oldversion> (Tạo nhiều file SQL cho các phiên bản cũ hơn => tối ưu hóa số lượng file update)
 * Nếu không update sql, vẫn phải tạo note trống
 * Thông tin phiên bản mới nhất trong note: changelog
 * Thông tin phiên bản cũ để trong note: changelog + version (VD: changelog230)
 * ------------------------------
 * Các File sql đặt trong thư mục tên SQL => Zip thư mục SQL
 * Các File Bin đặt trong thư mục Bin, các File báo cáo đặt trong thư mục Report => Zip cả 2 thư mục
 */
namespace Buca.AutoUpdater.Core
{
    /// <summary>
    /// Class AutoUpdater.
    /// </summary>
    public static class AutoUpdaterPlugin
    {
        private static readonly ILog LogAutoUpdater = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Configuration Properties

        /// <summary>
        /// Gets or sets the download path.
        /// </summary>
        /// <value>The download path.</value>
        public static string DownloadPath { get; set; }

        /// <summary>
        ///  Set Proxy server to use for all the web requests in BUCA AutoUpdater.NET.
        /// </summary>
        public static WebProxy Proxy;

        /// <summary>
        /// The report errors
        /// </summary>
        public static bool ReportErrors = false;

        /// <summary>
        /// Set this to false if your application doesn't need administrator privileges to replace the old version.
        /// </summary>
        public static bool RunUpdateAsAdmin = true;

        /// <summary>
        /// If this is true users can see the skip button.
        /// </summary>
        public static bool ShowSkipButton = true;

        /// <summary>
        /// If this is true users can see the Remind Later button.
        /// </summary>
        public static bool ShowRemindLaterButton = true;

        /// <summary>
        /// You can set this to true if you don't want user to skip this version. 
        /// This will ignore Remind Later and Skip options and hide both Skip and Remind Later button on update dialog.
        /// But in this case always required -> 
        /// </summary>
        /// <value><c>true</c> if mandatory; otherwise, <c>false</c>.</value>
        public static bool Mandatory = true;

        /// <summary>
        /// Opens the download url in default browser if true. Very usefull if you have portable application.
        /// </summary>
        public static bool OpenDownloadPage;

        /// <summary>
        /// If this is true users see dialog where they can set remind later interval otherwise it will take the interval from
        /// RemindLaterAt and RemindLaterTimeSpan fields.
        /// </summary>
        public static bool LetUserSelectRemindLater = true;

        /// <summary>
        /// Remind Later interval after user should be reminded of update.
        /// </summary>
        public static int RemindLaterAt = 2;

        /// <summary>
        ///     Set if RemindLaterAt interval should be in Minutes, Hours or Days.
        /// </summary>
        public static RemindLaterFormat RemindLaterTimeSpan = RemindLaterFormat.Days;

        #endregion

        #region private properties

        /// <summary>
        /// URL of the xml file that contains information about latest version of the application.
        /// </summary>
        private static string _appCastURL;

        /// <summary>
        /// The remind later timer
        /// </summary>
        private static System.Timers.Timer _remindLaterTimer;

        /// <summary>
        /// The application title
        /// </summary>
        private static string _appTitle;

        #endregion

        #region internal settings

        /// <summary>
        /// The changelog URL
        /// </summary>
        internal static string ChangelogURL;

        /// <summary>
        /// The download URL
        /// </summary>
        internal static string DownloadURL;

        internal static string SqlUrl;

        /// <summary>
        /// The installer arguments
        /// </summary>
        internal static string InstallerArgs;

        /// <summary>
        /// The registry location
        /// </summary>
        internal static string RegistryLocation;

        /// <summary>
        /// The checksum
        /// </summary>
        internal static string Checksum;

        /// <summary>
        /// The hashing algorithm
        /// </summary>
        internal static string HashingAlgorithm;

        /// <summary>
        /// The current version
        /// </summary>
        internal static Version CurrentVersion;

        /// <summary>
        /// The installed version
        /// </summary>
        internal static Version InstalledVersion;

        /// <summary>
        /// The is win forms application
        /// </summary>
        internal static bool IsWinFormsApplication;

        /// <summary>
        /// The running
        /// </summary>
        internal static bool Running;

        internal static Version LicenseLimit;
        #endregion

        #region public events

        /// <summary>
        /// Occurs when [parse update information event].
        /// </summary>
        public static event ParseUpdateInfoHandler ParseUpdateInfoEvent;

        /// <summary>
        /// Delegate ParseUpdateInfoHandler
        /// </summary>
        /// <param name="args">The <see cref="ParseUpdateInfoEventArgs"/> instance containing the event data.</param>
        public delegate void ParseUpdateInfoHandler(ParseUpdateInfoEventArgs args);

        /// <summary>
        /// A delegate type for hooking up update notifications.
        /// </summary>
        /// <param name="args">An object containing all the parameters recieved from AppCast XML file. 
        /// If there will be an error while looking for the XML file then this object will be null.</param>
        public delegate void CheckForUpdateEventHandler(UpdateInfoEventArgs args);

        /// <summary>
        /// An event that clients can use to be notified whenever the update is checked.
        /// </summary>
        public static event CheckForUpdateEventHandler CheckForUpdateEvent;

        /// <summary>
        /// A delegate type to handle how to exit the application after update is downloaded.
        /// </summary>
        public delegate void ApplicationExitEventHandler();

        /// <summary>
        /// An event that developers can use to exit the application gracefully.
        /// </summary>
        public static event ApplicationExitEventHandler ApplicationExitEvent;

        #endregion

        #region Core Methods

        /// <summary>
        /// Initializes static members of the <see cref="AutoUpdaterPlugin"/> class.
        /// </summary>
        static AutoUpdaterPlugin()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Starts the specified my assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public static void Start(Assembly assembly = null)
        {
            Start(_appCastURL, assembly, LicenseLimit);
        }

        /// <summary>
        /// Starts the specified application cast.
        /// </summary>
        /// <param name="appCast">The application cast.</param>
        /// <param name="assembly">The assembly.</param>
        public static void Start(string appCast, Assembly assembly, Version limitVersion)
        {
            LicenseLimit = limitVersion;
            if (Mandatory && _remindLaterTimer != null)
            {
                _remindLaterTimer.Stop();
                _remindLaterTimer.Close();
                _remindLaterTimer = null;
            }

            if (!Running && _remindLaterTimer == null)
            {
                Running = true;
                _appCastURL = appCast;
                IsWinFormsApplication = Application.MessageLoop;

                //call backgroundwoker to run background services
                var backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += BackgroundWorkerDoWork;
                backgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
                backgroundWorker.RunWorkerAsync(assembly ?? Assembly.GetEntryAssembly());
            }
        }

        #endregion

        #region backgroundworker

        /// <summary>
        /// Backgrounds the worker do work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Cancel = true;
            var mainAssembly = e.Argument as Assembly;
            var companyAttribute = (AssemblyCompanyAttribute)GetAttribute(mainAssembly, typeof(AssemblyCompanyAttribute));

            if (string.IsNullOrEmpty(_appTitle))
            {
                var titleAttribute = (AssemblyTitleAttribute)GetAttribute(mainAssembly, typeof(AssemblyTitleAttribute));
                if (mainAssembly != null) _appTitle = titleAttribute != null ? titleAttribute.Title : mainAssembly.GetName().Name;
            }

            var appCompany = companyAttribute != null ? companyAttribute.Company : "";

            RegistryLocation = !string.IsNullOrEmpty(appCompany) ? $@"Software\{appCompany}\{_appTitle}\AutoUpdater" : $@"Software\{_appTitle}\AutoUpdater";
            if (mainAssembly != null)
            {
                InstalledVersion = mainAssembly.GetName().Version;

                var webRequest = WebRequest.Create(_appCastURL);
                WebResponse webResponse;

                webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                if (Proxy != null)
                {
                    webRequest.Proxy = Proxy;
                }
                try
                {
                    webResponse = webRequest.GetResponse();
                }
                catch (Exception ex)
                {
                    LogAutoUpdater.Error("webResponse - " + ex.Message);
                    e.Cancel = false;
                    return;
                }
                UpdateInfoEventArgs args;
                using (var appCastStream = webResponse.GetResponseStream())
                {
                    if (appCastStream != null)
                    {
                        //when you have self event to excute get information from url
                        if (ParseUpdateInfoEvent != null)
                        {
                            using (var streamReader = new StreamReader(appCastStream))
                            {
                                var data = streamReader.ReadToEnd();
                                ParseUpdateInfoEventArgs parseArgs = new ParseUpdateInfoEventArgs(data);
                                ParseUpdateInfoEvent(parseArgs);
                                args = parseArgs.UpdateInfo;
                            }
                        }
                        else
                        {
                            //default data from url is xml
                            try
                            {
                                args = ParseInfoFromUrl(appCastStream);
                            }
                            catch (XmlException ex)
                            {
                                LogAutoUpdater.Error("ParseInfoFromUrl - " + ex.Message);
                                e.Cancel = false;
                                webResponse.Close();
                                return;
                            }
                        }
                    }
                    else
                    {
                        e.Cancel = false;
                        webResponse.Close();
                        return;
                    }
                }

                if (args.CurrentVersion == null || string.IsNullOrEmpty(args.DownloadURL))
                {
                    webResponse.Close();
                    if (ReportErrors)
                    {
                        throw new InvalidDataException();
                    }
                    return;
                }

                CurrentVersion = args.CurrentVersion;// <= LicenseLimit && args.CurrentVersion <= LicenseLimit ? args.CurrentVersion : InstalledVersion;
                ChangelogURL = args.ChangelogURL = GetURL(webResponse.ResponseUri, args.ChangelogURL);
                DownloadURL = args.DownloadURL = GetURL(webResponse.ResponseUri, args.DownloadURL);
                SqlUrl = args.SqlUrl = GetURL(webResponse.ResponseUri, args.SqlUrl);
                Mandatory = args.Mandatory;
                InstallerArgs = args.InstallerArgs ?? string.Empty;
                HashingAlgorithm = args.HashingAlgorithm ?? "MD5";
                Checksum = args.Checksum ?? string.Empty;

                webResponse.Close();

                if (Mandatory)
                {
                    ShowRemindLaterButton = false;
                    ShowSkipButton = false;
                }
                else
                {
                    using (var updateKey = Registry.CurrentUser.OpenSubKey(RegistryLocation))
                    {
                        if (updateKey != null)
                        {
                            var skip = updateKey.GetValue("skip");
                            var applicationVersion = updateKey.GetValue("version");
                            if (skip != null && applicationVersion != null)
                            {
                                var skipValue = skip.ToString();
                                var skipVersion = new Version(applicationVersion.ToString());
                                if (skipValue.Equals("1") && CurrentVersion <= skipVersion) return;
                                if (CurrentVersion > skipVersion)
                                {
                                    using (var updateKeyWrite = Registry.CurrentUser.CreateSubKey(RegistryLocation))
                                    {
                                        if (updateKeyWrite != null)
                                        {
                                            updateKeyWrite.SetValue("version", CurrentVersion.ToString());
                                            updateKeyWrite.SetValue("skip", 0);
                                        }
                                    }
                                }

                                var remindLaterTime = updateKey.GetValue("remindlater");
                                if (remindLaterTime != null)
                                {
                                    var remindLater = Convert.ToDateTime(remindLaterTime.ToString(), CultureInfo.CreateSpecificCulture("vi-VN").DateTimeFormat);
                                    var compareResult = DateTime.Compare(DateTime.Now, remindLater);
                                    if (compareResult < 0)
                                    {
                                        e.Cancel = false;
                                        e.Result = remindLater;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                args.IsUpdateAvailable = CurrentVersion > InstalledVersion;
                args.InstalledVersion = InstalledVersion;

                e.Cancel = false;
                e.Result = args;
            }
            else
            {
                e.Cancel = true;
                e.Result = null;
            }
        }

        /// <summary>
        /// Backgrounds the worker on run worker completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="runWorkerCompletedEventArgs">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private static void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (!runWorkerCompletedEventArgs.Cancelled)
            {
                //case khi nguoi dung an vao remind later
                if (runWorkerCompletedEventArgs.Result is DateTime)
                {
                    SetTimer((DateTime)runWorkerCompletedEventArgs.Result);
                }
                else
                {
                    var args = runWorkerCompletedEventArgs.Result as UpdateInfoEventArgs;
                    if (CheckForUpdateEvent != null)
                    {
                        CheckForUpdateEvent(args);
                    }
                    else
                    {
                        if (args != null)
                        {
                            if (args.IsUpdateAvailable)
                            {
                                if (!IsWinFormsApplication)
                                {
                                    Application.EnableVisualStyles();
                                }
                                if (Thread.CurrentThread.GetApartmentState().Equals(ApartmentState.STA))
                                {
                                    ShowUpdateForm();
                                }
                                else
                                {
                                    var thread = new Thread(ShowUpdateForm);
                                    thread.CurrentCulture = thread.CurrentUICulture = CultureInfo.CurrentCulture;
                                    thread.SetApartmentState(ApartmentState.STA);
                                    thread.Start();
                                    thread.Join();
                                }
                                return;
                            }
                            if (ReportErrors)
                            {
                                MessageBox.Show(Resources.UpdateUnavailableMessage, Resources.UpdateUnavailableCaption,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (ReportErrors)
                            {
                                MessageBox.Show(Resources.UpdateCheckFailedMessage, Resources.UpdateCheckFailedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            Running = false;
        }

        #endregion

        #region private helper

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns>Attribute.</returns>
        private static Attribute GetAttribute(Assembly assembly, Type attributeType)
        {
            var attributes = assembly.GetCustomAttributes(attributeType, false);
            if (attributes.Length == 0)
            {
                return null;
            }
            return (Attribute)attributes[0];
        }

        /// <summary>
        /// Parses the information from URL.
        /// </summary>
        /// <param name="appCastStream">The application cast stream.</param>
        /// <returns>UpdateInfoEventArgs.</returns>
        private static UpdateInfoEventArgs ParseInfoFromUrl(Stream appCastStream)
        {
            var receivedAppCastDocument = new XmlDocument();
            var args = new UpdateInfoEventArgs();
            Version newestversion = new Version(1, 0, 0);
            receivedAppCastDocument.Load(appCastStream);
            var appCastItems = receivedAppCastDocument.SelectNodes("item");
            if (appCastItems != null)
            {
                foreach (XmlNode item in appCastItems)
                {
                    var appCastVersion = item.SelectSingleNode("version");
                    try
                    {
                        if (appCastVersion != null)
                        {
                            CurrentVersion = new Version(appCastVersion.InnerText);
                            newestversion = CurrentVersion;
                            CurrentVersion = CurrentVersion <= LicenseLimit && CurrentVersion <= LicenseLimit
                                ? CurrentVersion
                                : LicenseLimit;
                        }

                    }
                    catch (Exception ex)
                    {
                        //write log4net
                        LogAutoUpdater.Error("XmlNode - " + ex.Message);
                        CurrentVersion = null;
                    }

                    args.CurrentVersion = CurrentVersion;

                    var appCastChangeLog = item.SelectSingleNode("changelog" + (newestversion <= LicenseLimit ? "" : CurrentVersion.ToString().Replace(".", "")));
                    args.ChangelogURL = appCastChangeLog != null ? appCastChangeLog.InnerText : null;

                    string versionOrigin = InstalledVersion.ToString().Substring(0, CurrentVersion.ToString().Length);//AnhNT: Cắt version do hệ thống sử dụng Fileversion, sẽ thành version 4 số

                    var appCastUrl = item.SelectSingleNode("url" + (newestversion <= LicenseLimit ? "" : CurrentVersion.ToString().Replace(".", "")));
                    var sqlCastUrl = item.SelectSingleNode("sql-" + CurrentVersion.ToString().Replace(".", "") + "-" + versionOrigin.Replace(".", ""));

                    args.DownloadURL = appCastUrl != null ? appCastUrl.InnerText : null;//Link download BIN
                    args.SqlUrl = sqlCastUrl != null ? sqlCastUrl.InnerText : null;//Link download SQL

                    var appArgs = item.SelectSingleNode("args");
                    args.InstallerArgs = appArgs != null ? appArgs.InnerText : null;

                    var checksum = item.SelectSingleNode("checksum");
                    if (checksum != null && checksum.Attributes != null)
                    {
                        var algorithm = checksum.Attributes["algorithm"];

                        args.Checksum = checksum.InnerText;
                        args.HashingAlgorithm = algorithm != null ? algorithm.InnerText : null;
                    }

                    if (!Mandatory)
                    {
                        var mandatory = item.SelectSingleNode("mandatory");
                        bool.TryParse(mandatory != null ? mandatory.InnerText : null, out Mandatory);
                    }

                    args.Mandatory = Mandatory;

                }
            }
            return args;
        }

        /// <summary>
        /// Shows the update form.
        /// </summary>
        private static void ShowUpdateForm()
        {
            var updateForm = new FrmUpdate();
            if (updateForm.ShowDialog().Equals(DialogResult.OK))
            {
                Exit();
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        private static string GetURL(Uri baseUri, String url)
        {
            if (string.IsNullOrEmpty(url) || !Uri.IsWellFormedUriString(url, UriKind.Relative)) return url;
            var uri = new Uri(baseUri, url);
            if (uri.IsAbsoluteUri)
            {
                url = uri.AbsoluteUri;
            }

            return url;
        }

        /// <summary>
        /// Sets the timer.
        /// </summary>
        /// <param name="remindLater">The remind later.</param>
        internal static void SetTimer(DateTime remindLater)
        {
            var timeSpan = remindLater - DateTime.Now;
            var context = SynchronizationContext.Current;

            _remindLaterTimer = new System.Timers.Timer
            {
                Interval = (int)timeSpan.TotalMilliseconds,
                AutoReset = false
            };

            _remindLaterTimer.Elapsed += delegate
            {
                _remindLaterTimer = null;
                if (context != null)
                {
                    try
                    {
                        context.Send(state => Start(), null);
                    }
                    catch (Exception ex)
                    {
                        LogAutoUpdater.Error("Remind Later - " + ex.Message);
                        Start();
                    }
                }
                else
                {
                    Start();
                }
            };

            _remindLaterTimer.Start();
        }

        /// <summary>
        /// Exits this instance.
        /// </summary>
        private static void Exit()
        {
            if (ApplicationExitEvent != null)
            {
                ApplicationExitEvent();
            }
            else
            {
                var currentProcess = Process.GetCurrentProcess();
                foreach (var process in Process.GetProcessesByName(currentProcess.ProcessName))
                {
                    string processPath;
                    try
                    {
                        processPath = process.MainModule.FileName;
                    }
                    catch (Win32Exception ex)
                    {
                        // Current process should be same as processes created by other instances of the application so it should be able to access modules of other instances. 
                        // This means this is not the process we are looking for so we can safely skip this.
                        LogAutoUpdater.Error("processPath - " + ex.Message);
                        continue;
                    }

                    if (process.Id == currentProcess.Id || currentProcess.MainModule.FileName != processPath) continue;
                    //get all instances of assembly except current
                    if (process.CloseMainWindow())
                    {
                        process.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds); //give some time to process message
                    }
                    if (!process.HasExited)
                    {
                        process.Kill(); //TODO show UI message asking user to close program himself instead of silently killing it
                    }
                }

                if (IsWinFormsApplication)
                {
                    MethodInvoker methodInvoker = Application.Exit;
                    methodInvoker.Invoke();
                }
#if NETWPF
                else if (System.Windows.Application.Current != null)
                {
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        System.Windows.Application.Current.Shutdown()));
                }
#endif
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        #endregion

        #region Public method
        public static bool IsAutoUpdate = false;

        /// <summary>
        /// Downloads the update.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DownloadUpdate()
        {
            var downloadDialog = new FrmDownloadUpdateDialog(DownloadURL, SqlUrl);

            try
            {
                IsAutoUpdate = true;
                return downloadDialog.ShowDialog().Equals(DialogResult.OK);
            }
            catch (TargetInvocationException ex)
            {
                LogAutoUpdater.Error(ex.Message);
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Check new version for autoupdate
        /// </summary>
        /// <param name="url"></param>
        /// <param name="limitVersion"></param>
        /// <returns></returns>
        public static bool CheckForNewVersion(string url, Version limitVersion,bool isAutoUpdate)
        {
            LicenseLimit = limitVersion;
            var webRequest = WebRequest.Create(url);
            WebResponse webResponse;

            webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch 
            {
                if (!isAutoUpdate)
                    MessageBox.Show("Không kết nối được máy chủ.", Resources.UpdateCheckFailedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            using (var appCastStream = webResponse.GetResponseStream())
            {
                if (appCastStream != null)
                {
                    try
                    {
                        var receivedAppCastDocument = new XmlDocument();

                        receivedAppCastDocument.Load(appCastStream);
                        var appCastItems = receivedAppCastDocument.SelectNodes("item");
                        if (appCastItems != null)
                        {
                            foreach (XmlNode item in appCastItems)
                            {
                                var appCastVersion = item.SelectSingleNode("version");
                                var curentversion = new Version(appCastVersion.InnerText);
                                Version thisversion = new Version(Assembly.GetEntryAssembly().GetName().Version.ToString().Substring(0, curentversion.ToString().Length));
                                curentversion = curentversion <= LicenseLimit && thisversion <= LicenseLimit ? curentversion : LicenseLimit;
                                if (thisversion < curentversion)
                                {
                                    return true;
                                }
                                else if (thisversion == curentversion && !isAutoUpdate)
                                {
                                    MessageBox.Show(Resources.UpdateUnavailableMessage, Resources.UpdateUnavailableCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}
