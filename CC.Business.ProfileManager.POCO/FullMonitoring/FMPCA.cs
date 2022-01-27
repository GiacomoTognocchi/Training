// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// FullMonitoringAlertConfiguration
    /// FMPCA
    /// </summary>
    public class FMPCA
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [c alert monitoring].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [c alert monitoring]; otherwise, <c>false</c>.
        /// </value>
        public bool CAlertMonitoring
        {
            get;
            set;
        }

        /// <summary>
        /// Allow C-Alert automatic upgrade
        /// </summary>
        /// <value>
        ///   <c>true</c> if [c alert upgrade allowed]; otherwise, <c>false</c>.
        /// </value>
        public bool CAlertUpgradeAllowed
        {
            get;
            set;
        }

        /// <summary>
        /// C-Alert upgrade type
        /// </summary>
        /// <value>
        /// The type of the c alert upgrade.
        /// </value>
        public string CAlertUpgradeType
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}