// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// Notifications Profile
    /// NTP
    /// </summary>
    public static class NotificationsProfile
    {
        #region Public Methods


        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.NotificationsProfile Map(Core.CribisComX.BusinessObjects.NTP input)
        {
            if (input == null)
            {
                return null as POCO.NotificationsProfile;
            }

            return new POCO.NotificationsProfile
            {
                AT = (POCO.NTPAT)Enum.Parse(typeof(POCO.NTPAT), input.AT.ToString()),
                ATSpecified = input.ATSpecified,
                NT = (POCO.NotificationType)Enum.Parse(typeof(POCO.NotificationType), input.NT.ToString()),
                PMADL = input.PMADL,
                PME = input.PME,
                SAE = input.SAE,
                SAOR = (POCO.NTPSAOR)Enum.Parse(typeof(POCO.NTPSAOR), input.SAOR.ToString()),
                SAORSpecified = input.SAORSpecified,
                SAS = input.SAS,
                SASSpecified = input.SASSpecified
            };
        }

        #endregion Public Methods
    }
}