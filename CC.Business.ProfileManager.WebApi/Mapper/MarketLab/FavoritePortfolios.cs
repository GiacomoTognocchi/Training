// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FavoritePortfolios
    /// </summary>
    public static class FavoritePortfolios
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
        public static POCO.FavoritePortfolios Map(Core.CribisComX.FavoritePortfolios input)
        {
            if (input == null)
            {
                return null as POCO.FavoritePortfolios;
            }

            return new POCO.FavoritePortfolios
            {
                P1 = input.P1,
                P2 = input.P2,
                P3 = input.P3,
                P4 = input.P4,
                P5 = input.P5
            };
        }

        #endregion Public Methods
    }
}