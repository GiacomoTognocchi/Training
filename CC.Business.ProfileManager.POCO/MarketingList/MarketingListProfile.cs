// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// MarketingListProfile
    /// MLP
    /// </summary>
    public class MarketingListProfile
    {

        #region Public Properties

        /// <summary>
        /// Business Catalog
        /// </summary>
        public Profile BC
        {
            get; set;
        }

        /// <summary>
        /// Target Profile
        /// </summary>
        public Profile TP
        {
            get; set;
        }

        #endregion Public Properties
    }
}