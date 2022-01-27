// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// CompanyReportProfile
    /// CCRP
    /// </summary>
    public static class CompanyReportProfile
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
        public static POCO.CompanyReportProfile Map(Core.CribisComX.BusinessObjects.CCRP input)
        {
            if (input == null)
            {
                return null as POCO.CompanyReportProfile;
            }

            return new POCO.CompanyReportProfile
            {
                SLOT1 = ReportDefinition.Map(input.SLOT1),
                SLOT2 = ReportDefinition.Map(input.SLOT2),
                SLOT3 = ReportDefinition.Map(input.SLOT3),
                SLOT4 = ReportDefinition.Map(input.SLOT4),
                SLOT5 = ReportDefinition.Map(input.SLOT5),
                SLOT6 = ReportDefinition.Map(input.SLOT6),
                SLOT7 = ReportDefinition.Map(input.SLOT7),
                SLOT8 = ReportDefinition.Map(input.SLOT8),
                SLOT9 = ReportDefinition.Map(input.SLOT9),
                SLOT10 = ReportDefinition.Map(input.SLOT10),
                SLOT11 = ReportDefinition.Map(input.SLOT11),
                SLOT12 = ReportDefinition.Map(input.SLOT12),
                SLOT13 = ReportDefinition.Map(input.SLOT13),
                SLOT14 = ReportDefinition.Map(input.SLOT14),
                SLOT15 = ReportDefinition.Map(input.SLOT15),
                SLOT16 = ReportDefinition.Map(input.SLOT16),
                SLOT17 = ReportDefinition.Map(input.SLOT17),
                SLOT18 = ReportDefinition.Map(input.SLOT18),
                SLOT19 = ReportDefinition.Map(input.SLOT19),
                SLOT20 = ReportDefinition.Map(input.SLOT20),
                SLOT21 = ReportDefinition.Map(input.SLOT21),
                SLOT22 = ReportDefinition.Map(input.SLOT22),
                SLOT23 = ReportDefinition.Map(input.SLOT23),
                SLOT24 = ReportDefinition.Map(input.SLOT24),
                SLOT25 = ReportDefinition.Map(input.SLOT25)
            };
        }

        #endregion Public Methods
    }
}