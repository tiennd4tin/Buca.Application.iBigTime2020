/***********************************************************************
 * <copyright file="Program.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 03 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Globalization;
using System;
using System.Threading;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;


namespace Buca.Application.iBigTime2020.WindowsForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Tien1
        /// </summary>
        [STAThread]
        private static void Main()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            ResourceHelper.ResourceLanguage = "vi-VN";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ResourceHelper.ResourceLanguage);

            Initialize();
            System.Windows.Forms.Application.Run(new MainRibbonForm());
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Initialize()
        {
            ResourceHelper.InitResource();
            RegistryHelper.RemoveConnectionString();
            if (!RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master") && !string.IsNullOrEmpty(RegistryHelper.GetValueByRegistryKey("DatabasePath")))
                RegistryHelper.SaveConfigFile();
        }
    }
}