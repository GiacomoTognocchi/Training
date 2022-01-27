// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// ITrade Profile
    /// TRP
    /// </summary>
    public static class TradeProfile
    {
        #region Public Methods


        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.TradeProfile Map(Core.CribisComX.BusinessObjects.TRP input)
        {
            if (input == null)
            {
                return null as POCO.TradeProfile;
            }

            return new POCO.TradeProfile
            {
                DSO = (POCO.TRPDSO)Enum.Parse(typeof(POCO.TRPDSO), input.DSO.ToString())
            };
        }

        #endregion Public Methods
    }
}