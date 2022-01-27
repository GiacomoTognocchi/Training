// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// FullMonitoringPackage
    /// FMPPOM
    /// </summary>
    public class FMPPOM
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Receive notifications
        /// </summary>
        /// <value>
        /// <c>true</c> if rn; otherwise, <c>false</c>.
        /// </value>
        public bool RN
        {
            get; set;
        }

        #endregion Public Properties
    }
}