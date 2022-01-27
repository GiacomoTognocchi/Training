// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************


namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// Marketing List Profile
    /// Profile
    /// </summary>
    public static class Profile
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
        public static POCO.Profile Map(Core.CribisComX.BusinessObjects.Profile input)
        {
            if (input == null)
            {
                return null as POCO.Profile;
            }

            return new POCO.Profile
            {
                Anagrafica = input.Anagrafica,
                EstesoCribis = input.EstesoCribis,
                Etichetta = input.Etichetta,
                SchedaBase = input.SchedaBase,
                SchedaStrategica = input.SchedaStrategica,
                SchedaStrategicaBilancio = input.SchedaStrategicaBilancio
            };
        }

        #endregion Public Methods
    }
}