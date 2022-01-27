// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Linq;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// AntiFraudProfile
    /// AFP
    /// </summary>
    public static class AntiFraudProfile
    {
        #region Public Properties

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.AntiFraudProfile Map(Core.CribisComX.BusinessObjects.AFP input)
        {
            if (input == null)
            {
                return null as POCO.AntiFraudProfile;
            }

            return new POCO.AntiFraudProfile
            {
               PRODUCT = input.PRODUCT?.Select(AFPPRODUCT.Map)?.ToList()
            };
        }

        #endregion Public Properties
    }
}