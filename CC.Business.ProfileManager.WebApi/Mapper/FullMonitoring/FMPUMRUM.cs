// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringReportsUniversalMonitoring
    /// FMPUMRUM
    /// </summary>
    public static class FMPUMRUM
    {
        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.FMPUMRUM Map(Core.CribisComX.BusinessObjects.FMPUMRUM input)
        {
            if (input == null)
            {
                return null as POCO.FMPUMRUM;
            }

            return new POCO.FMPUMRUM
            {
                RC = input.RC
            };
        }

        #endregion Public Methods
    }
}