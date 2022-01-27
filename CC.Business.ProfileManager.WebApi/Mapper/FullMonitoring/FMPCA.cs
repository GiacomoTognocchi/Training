// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FMPCA
    /// FullMonitoringAlertConfiguration
    /// </summary>
    public static class FMPCA
    {

        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.FMPCA Map(Core.CribisComX.BusinessObjects.FMPCA input)
        {
            if (input == null)
            {
                return null as POCO.FMPCA;
            }

            return new POCO.FMPCA
            {
               CAlertMonitoring = input.CAlertMonitoring,
               CAlertUpgradeAllowed = input.CAlertUpgradeAllowed,
               CAlertUpgradeType = input.CAlertUpgradeType
            };
        }

        #endregion Public Methods

    }
}