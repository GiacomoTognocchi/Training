// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// User Preferences Profile
    /// UPP
    /// </summary>
    public class UserPreferencesProfile
    {

        #region Public Properties

        /// <summary>
        /// Customer Reference
        /// </summary>
        public string CustomerReference
        {
            get;
            set;
        }

        /// <summary>
        /// Date of Last Save on the profile
        /// </summary>
        public DateTime SaveDate
        {
            get;
            set;
        }

        /// <summary>
        /// Flag Saved by User
        /// </summary>
        public bool SavedByUser
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}