// ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 09-29-2018
//
// Last Modified By : thangnd
// Last Modified On : 09-29-2018
// ***********************************************************************
// <copyright file="UpdateInfoEventArgs.cs" company="by adguard">
//     Copyright © by adguard 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Buca.AutoUpdater.Core
{
    /// <summary>
    /// Class UpdateInfoEventArgs.
    /// </summary>
    public class UpdateInfoEventArgs : EventArgs
    {

        public string UpdateTime { get; set; }
        /// <summary>
        /// If new update is available then returns true otherwise false.
        /// </summary>
        /// <value><c>true</c> if this instance is update available; otherwise, <c>false</c>.</value>
        public bool IsUpdateAvailable { get; set; }

        /// <summary>
        /// Download URL of the update file.
        /// </summary>
        /// <value>The download URL.</value>
        public string DownloadURL { get; set; }

        /// <summary>
        /// Download SQL 
        /// </summary>
        public string SqlUrl { get; set; }
        /// <summary>
        /// URL of the webpage specifying changes in the new update.
        /// </summary>
        /// <value>The changelog URL.</value>
        public string ChangelogURL { get; set; }

        /// <summary>
        /// Returns newest version of the application available to download.
        /// </summary>
        /// <value>The current version.</value>
        public Version CurrentVersion { get; set; }

        /// <summary>
        /// Returns version of the application currently installed on the user's PC.
        /// </summary>
        /// <value>The installed version.</value>
        public Version InstalledVersion { get; set; }

        /// <summary>
        /// Shows if the update is required or optional.
        /// </summary>
        /// <value><c>true</c> if mandatory; otherwise, <c>false</c>.</value>
        public bool Mandatory { get; set; }

        /// <summary>
        /// Command line arguments used by Installer.
        /// </summary>
        /// <value>The installer arguments.</value>
        public string InstallerArgs { get; set; }

        /// <summary>
        /// Checksum of the update file.
        /// </summary>
        /// <value>The checksum.</value>
        public string Checksum { get; set; }

        /// <summary>
        /// Hash algorithm that generated the checksum provided in the XML file.
        /// </summary>
        /// <value>The hashing algorithm.</value>
        public string HashingAlgorithm { get; set; }
    }
}
