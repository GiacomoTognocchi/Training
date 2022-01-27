// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// Portfolio Marketing Profile
    /// MLPMP
    /// </summary>
    public static class MLPMP
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
        public static POCO.MLPMP Map(Core.CribisComX.MLPMP input)
        {
            if (input == null)
            {
                return null as POCO.MLPMP;
            }

            return new POCO.MLPMP
            {
                FP = FavoritePortfolios.Map(input.FP),
            };
        }

        #endregion Public Methods

    }
}