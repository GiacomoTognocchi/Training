// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;
using System.Linq;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// FullMonitoringUniversalMonitoring
    /// FMPUM
    /// </summary>
    public static class FMPUM
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
        public static POCO.FMPUM Map(Core.CribisComX.BusinessObjects.FMPUM input)
        {
            if (input == null)
            {
                return null as POCO.FMPUM;
            }

            return new POCO.FMPUM
            {
                RMT = (POCO.FMPUMRMT)Enum.Parse(typeof(POCO.FMPUMRMT), input.RMT.ToString()),
                RMTSpecified = input.RMTSpecified,
                RUM = input.RUM?.Select(FMPUMRUM.Map)?.ToList()
            };
        }

        #endregion Public Methods
    }
}