// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Collections.Generic;

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// FullMonitoringProfile
    /// FMP
    /// </summary>
    public class FullMonitoringProfile
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FullMonitoringProfile" /> is activation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activation; otherwise, <c>false</c>.
        /// </value>
        public bool Activation
        {
            get; set;
        }

        /// <summary>
        /// C-Alert configuration
        /// </summary>
        /// <value>
        /// The ca.
        /// </value>
        public FMPCA CA
        {
            get; set;
        }

        /// <summary>
        /// delayed purchase configuration
        /// </summary>
        /// <value>
        /// The dp.
        /// </value>
        public FMPDP DP
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [flag disable automatic renewal].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [flag disable automatic renewal]; otherwise, <c>false</c>.
        /// </value>
        public bool FlagDisableAutoRenewal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the frequence.
        /// </summary>
        /// <value>
        /// The frequence.
        /// </value>
        public FMPFrequence Frequence
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hide risk information].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hide risk information]; otherwise, <c>false</c>.
        /// </value>
        public bool HideRiskInformation
        {
            get; set;
        }

        /// <summary>
        /// Hides Risk Information elements in Web UI
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hide risk information specified]; otherwise, <c>false</c>.
        /// </value>
        public bool HideRiskInformationSpecified
        {
            get; set;
        }

        /// <summary>
        /// Service level
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public FMPLevel Level
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [manager can review other users].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [manager can review other users]; otherwise, <c>false</c>.
        /// </value>
        public bool ManagerCanReviewOtherUsers
        {
            get; set;
        }

        /// <summary>
        /// The manager can force Review Me for other users
        /// </summary>
        /// <value>
        ///   <c>true</c> if [manager can review other users specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ManagerCanReviewOtherUsersSpecified
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public FMPMode Mode
        {
            get; set;
        }

        /// <summary>
        /// Monitoring Mode
        /// </summary>
        /// <value>
        ///   <c>true</c> if [mode specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ModeSpecified
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the monitoring.
        /// </summary>
        /// <value>
        /// The monitoring.
        /// </value>
        public FMPMonitoring Monitoring
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the notification.
        /// </summary>
        /// <value>
        /// The type of the notification.
        /// </value>
        public FMPNotificationType NotificationType
        {
            get; set;
        }

        /// <summary>
        /// Monitoring enabling
        /// </summary>
        /// <value>
        ///   <c>true</c> if [notification type specified]; otherwise, <c>false</c>.
        /// </value>
        public bool NotificationTypeSpecified
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the pom.
        /// </summary>
        /// <value>
        /// The pom.
        /// </value>
        public List<FMPPOM> POM
        {
            get; set;
        }

        /// <summary>
        /// Package of representatives or shareholders
        /// </summary>
        /// <value>
        /// The por.
        /// </value>
        public FMPPOR POR
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [show excel upload].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show excel upload]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowExcelUpload
        {
            get; set;
        }

        /// <summary>
        /// Enabling the Bulkload funzionality
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show excel upload specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowExcelUploadSpecified
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show power monitor in search results].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show power monitor in search results]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowPowerMonitorInSearchResults
        {
            get; set;
        }

        /// <summary>
        /// ## DEPRECATED ## The Power Monitor button is hidden in Search Results
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show power monitor in search results specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowPowerMonitorInSearchResultsSpecified
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [supervisor can review other users].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [supervisor can review other users]; otherwise, <c>false</c>.
        /// </value>
        public bool SupervisorCanReviewOtherUsers
        {
            get; set;
        }

        /// <summary>
        /// The supervisor can force Review Me for other users
        /// </summary>
        /// <value>
        ///   <c>true</c> if [supervisor can review other users specified]; otherwise, <c>false</c>.
        /// </value>
        public bool SupervisorCanReviewOtherUsersSpecified
        {
            get; set;
        }

        /// <summary>
        /// Universal Monitoring
        /// </summary>
        /// <value>
        /// The um.
        /// </value>
        public FMPUM UM
        {
            get; set;
        }

        #endregion Public Properties
    }
}