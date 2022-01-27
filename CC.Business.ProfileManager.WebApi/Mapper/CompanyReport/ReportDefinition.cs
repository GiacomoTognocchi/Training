// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// ReportDefinition
    /// </summary>
    public static class ReportDefinition
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
        public static POCO.ReportDefinition Map(Core.CribisComX.BusinessObjects.ReportDefinition input)
        {
            if (input == null)
            {
                return null as POCO.ReportDefinition;
            }

            return new POCO.ReportDefinition
            {
                PC = input.PC
            };
        }

        #endregion Public Methods

    }
}