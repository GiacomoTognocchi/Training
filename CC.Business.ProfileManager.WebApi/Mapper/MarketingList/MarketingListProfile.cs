// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************


namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// Marketing List Profile
    /// MLP
    /// </summary>
    public static class MarketingListProfile
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
        public static POCO.MarketingListProfile Map(Core.CribisComX.BusinessObjects.MLP input)
        {
            if (input == null)
            {
                return null as POCO.MarketingListProfile;
            }

            return new POCO.MarketingListProfile
            {
                TP = Profile.Map(input.TP),
                BC = Profile.Map(input.BC)
            };
        }

        #endregion Public Methods
    }
}