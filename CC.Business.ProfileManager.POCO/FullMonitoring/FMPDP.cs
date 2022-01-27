// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// FullMonitoringDelayedPurchaseConfiguration
    /// FMPDP
    /// </summary>
    public class FMPDP
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow delayed purchase].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow delayed purchase]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowDelayedPurchase
        {
            get;
            set;
        }

        /// <summary>
        /// Company report type for delayed purchase
        /// </summary>
        /// <value>
        /// The company report.
        /// </value>
        public string CompanyReport
        {
            get;
            set;
        }

        /// <summary>
        /// PA report type for delayed purchase
        /// </summary>
        /// <value>
        /// The pa report.
        /// </value>
        public string PAReport
        {
            get;
            set;
        }

        /// <summary>
        /// Person report type for delayed purchase
        /// </summary>
        /// <value>
        /// The person report.
        /// </value>
        public string PersonReport
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}