// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringDelayedPurchaseConfiguration
    /// </summary>
    public static class FMPDP
    {

        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.FMPDP Map(Core.CribisComX.BusinessObjects.FMPDP input)
        {
            if (input == null)
            {
                return null as POCO.FMPDP;
            }

            return new POCO.FMPDP
            {
                AllowDelayedPurchase = input.AllowDelayedPurchase,
                CompanyReport = input.CompanyReport,
                PAReport = input.PAReport,
                PersonReport = input.PersonReport
            };
        }

        #endregion Public Methods

    }
}