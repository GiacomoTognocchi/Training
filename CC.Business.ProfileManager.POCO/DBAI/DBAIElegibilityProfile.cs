// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// DBAIElegibilityProfile
    /// DBAIP
    /// </summary>
    public class DBAIElegibilityProfile
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the products profile.
        /// </summary>
        /// <value>
        /// The products profile.
        /// </value>
        public DBAIPProductsProfile ProductsProfile
        {
            get; set;
        }



        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DBAIElegibilityProfile"/> is investigation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if investigation; otherwise, <c>false</c>.
        /// </value>
        public bool Investigation
        {
            get; set;
        }



        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DBAIElegibilityProfile"/> is monitoring.
        /// </summary>
        /// <value>
        ///   <c>true</c> if monitoring; otherwise, <c>false</c>.
        /// </value>
        public bool Monitoring
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [universal monitoring].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [universal monitoring]; otherwise, <c>false</c>.
        /// </value>
        public bool UniversalMonitoring
        {
            get; set;
        }

       


        #endregion Public Properties
    }
}