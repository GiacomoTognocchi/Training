// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************


namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// UserPreferencesProfile
    /// UPP
    /// </summary>
    public static class UserPreferencesProfile
    {
        #region Public Methods


        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.UserPreferencesProfile Map(Core.CribisComX.BusinessObjects.UPP input)
        {
            if (input == null)
            {
                return null as POCO.UserPreferencesProfile;
            }

            return new POCO.UserPreferencesProfile
            {
                CustomerReference = input.CustomerReference,
                SaveDate = input.SaveDate,
                SavedByUser = input.SavedByUser
            };
        }

        #endregion Public Methods
    }
}