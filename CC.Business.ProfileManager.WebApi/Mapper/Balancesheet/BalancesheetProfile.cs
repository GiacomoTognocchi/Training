// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Linq;
using CC.Business.ProfileManager.Core.CribisComX;
using CC.Business.ProfileManager.POCO.BalanceSheet;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// AntiFraudProfile
    /// AFP
    /// </summary>
    public static class BalancesheetProfile
    {
        #region Public Properties

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static BalanceTypeEnum Map(BP input)
        {
            return input?.B?.T == BPBT.INT ? BalanceTypeEnum.RIC : BalanceTypeEnum.INT;
        }

        #endregion Public Properties
    }
}