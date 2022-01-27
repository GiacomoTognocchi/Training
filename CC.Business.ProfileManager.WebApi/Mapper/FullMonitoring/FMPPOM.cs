// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringPackage
    /// </summary>
    public static class FMPPOM
    {
        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.FMPPOM Map(Core.CribisComX.BusinessObjects.FMPPOM input)
        {
            if (input == null)
            {
                return null as POCO.FMPPOM;
            }

            return new POCO.FMPPOM
            {
                Name = input.Name,
                RN = input.RN
            };
        }

        #endregion Public Methods
    }
}