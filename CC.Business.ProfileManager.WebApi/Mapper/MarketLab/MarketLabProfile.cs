// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// MarketLabProfile
    /// ML
    /// </summary>
    public static class MarketLabProfile
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
        public static POCO.MarketLabProfile Map(Core.CribisComX.ML input)
        {
            if (input == null)
            {
                return null as POCO.MarketLabProfile;
            }

            return new POCO.MarketLabProfile
            {
                PMP = MLPMP.Map(input.PMP)
            };
        }

        #endregion Public Methods
    }
}