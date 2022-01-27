// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringPackageShareholders
    /// FMPPOR
    /// </summary>
    public static class FMPPOR
    {
        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// </returns>
        public static POCO.FMPPOR Map(Core.CribisComX.BusinessObjects.FMPPOR input)
        {
            if (input == null)
            {
                return null as POCO.FMPPOR;
            }

            return new POCO.FMPPOR
            {
                Name = input.Name
            };
        }

        #endregion Public Methods
    }
}