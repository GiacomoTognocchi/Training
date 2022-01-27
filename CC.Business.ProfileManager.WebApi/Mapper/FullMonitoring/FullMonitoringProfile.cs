// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;
using System.Linq;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringProfile
    /// FMP
    /// </summary>
    public static class FullMonitoringProfile
    {
        #region Public Methods

        /// <summary>
        /// Maps the specified profile.
        /// </summary>
        /// <param name="input">
        /// The profile.
        /// </param>
        /// <returns>
        /// </returns>
        public static POCO.FullMonitoringProfile Map(Core.CribisComX.BusinessObjects.FMP input)
        {
            if (input == null)
            {
                return null as POCO.FullMonitoringProfile;
            }

            return new POCO.FullMonitoringProfile
            {
                Activation = input.Activation,
                CA = FMPCA.Map(input.CA),
                DP = FMPDP.Map(input.DP),
                FlagDisableAutoRenewal = input.FlagDisableAutoRenewal,
                Frequence = (POCO.FMPFrequence)Enum.Parse(typeof(POCO.FMPFrequence),input.Frequence.ToString()),
                HideRiskInformation = input.HideRiskInformation,
                HideRiskInformationSpecified = input.HideRiskInformationSpecified,
                Level = (POCO.FMPLevel)Enum.Parse(typeof(POCO.FMPLevel), input.Level.ToString()),
                ManagerCanReviewOtherUsers = input.ManagerCanReviewOtherUsers,
                ManagerCanReviewOtherUsersSpecified = input.ManagerCanReviewOtherUsersSpecified,
                Mode = (POCO.FMPMode)Enum.Parse(typeof(POCO.FMPMode), input.Mode.ToString()),
                ModeSpecified = input.ModeSpecified,
                Monitoring = (POCO.FMPMonitoring)Enum.Parse(typeof(POCO.FMPMonitoring), input.Monitoring.ToString()),
                NotificationType = (POCO.FMPNotificationType)Enum.Parse(typeof(POCO.FMPNotificationType), input.NotificationType.ToString()),
                NotificationTypeSpecified = input.NotificationTypeSpecified,
                POM = input.POM?.Select(FMPPOM.Map)?.ToList(),
                POR = FMPPOR.Map(input.POR),
                ShowExcelUpload = input.ShowExcelUpload,
                ShowExcelUploadSpecified = input.ShowExcelUploadSpecified,
                ShowPowerMonitorInSearchResults = input.ShowPowerMonitorInSearchResults,
                ShowPowerMonitorInSearchResultsSpecified = input.ShowPowerMonitorInSearchResultsSpecified,
                SupervisorCanReviewOtherUsers = input.SupervisorCanReviewOtherUsers,
                SupervisorCanReviewOtherUsersSpecified = input.SupervisorCanReviewOtherUsersSpecified,
                UM = FMPUM.Map(input.UM)
            };
        }

        #endregion Public Methods
    }
}