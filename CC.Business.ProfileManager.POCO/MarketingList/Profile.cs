// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// Profile
    /// Profile
    /// </summary>
    public class Profile
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Profile"/> is anagrafica.
        /// </summary>
        /// <value>
        ///   <c>true</c> if anagrafica; otherwise, <c>false</c>.
        /// </value>
        public bool Anagrafica
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [esteso cribis].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [esteso cribis]; otherwise, <c>false</c>.
        /// </value>
        public bool EstesoCribis
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Profile"/> is etichetta.
        /// </summary>
        /// <value>
        ///   <c>true</c> if etichetta; otherwise, <c>false</c>.
        /// </value>
        public bool Etichetta
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [scheda base].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [scheda base]; otherwise, <c>false</c>.
        /// </value>
        public bool SchedaBase
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [scheda strategica].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [scheda strategica]; otherwise, <c>false</c>.
        /// </value>
        public bool SchedaStrategica
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [scheda strategica bilancio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [scheda strategica bilancio]; otherwise, <c>false</c>.
        /// </value>
        public bool SchedaStrategicaBilancio
        {
            get; set;
        }

        #endregion Public Properties
    }
}