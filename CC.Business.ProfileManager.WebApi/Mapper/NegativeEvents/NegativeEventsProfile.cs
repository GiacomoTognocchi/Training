// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Linq;
using System.Xml;
using CC.Business.ProfileManager.Core.CribisComX;
using CC.Business.ProfileManager.POCO.BalanceSheet;
using CC.Business.ProfileManager.POCO.NegativeEvents;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// AntiFraudProfile
    /// AFP
    /// </summary>
    public static class NegativeEventsProfile
    {
        #region Public Properties

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static NegativeEventProfile Map(NEP input)
        {
            var retVal = new NegativeEventProfile();
            if (input?.NE != null)
                retVal.DirectEvents = new Direct() {Roles = input?.NE?.RL?.Split(',').ToList(), EquityPercentage = XmlConvert.ToInt16(input?.NE?.EP) };
            if (input?.INE != null)
                retVal.IndirectEvents = new Indirect() { Roles = input?.INE?.RL?.Split(',').ToList() };
            return retVal;
        }

        #endregion Public Properties
    }
}