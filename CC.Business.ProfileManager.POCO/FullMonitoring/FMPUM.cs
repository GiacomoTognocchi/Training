// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Collections.Generic;

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// FullMonitoringUniversalMonitoring
    /// FMPUM
    /// </summary>
    public class FMPUM
    {
        #region Public Properties

        /// <summary>
        /// Report monitoring type
        /// </summary>
        /// <value>
        /// The RMT.
        /// </value>
        public FMPUMRMT RMT
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [RMT specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [RMT specified]; otherwise, <c>false</c>.
        /// </value>
        public bool RMTSpecified
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rum.
        /// </summary>
        /// <value>
        /// The rum.
        /// </value>
        public List<FMPUMRUM> RUM
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}