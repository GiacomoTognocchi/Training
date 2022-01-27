// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// DBAIElegibilityProfile
    /// DBAIP
    /// </summary>
    public static class DBAIElegibilityProfile
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
        public static POCO.DBAIElegibilityProfile Map(Core.CribisComX.BusinessObjects.DBAIP input)
        {
            if (input == null)
            {
                return null as POCO.DBAIElegibilityProfile;
            }

            return new POCO.DBAIElegibilityProfile
            {
                Investigation = input.Investigation,
                Monitoring = input.Monitoring,
                ProductsProfile = (POCO.DBAIPProductsProfile)Enum.Parse(typeof(POCO.DBAIPProductsProfile), input.ProductsProfile.ToString()),
                UniversalMonitoring = input.UniversalMonitoring
            };
        }

        #endregion Public Methods
    }
}