// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// NotificationsProfile
    /// NTP
    /// </summary>
    public class NotificationsProfile
    {

        #region Public Properties

        /// <summary>
        /// Notifications Type
        /// </summary>
        public NotificationType NT
        {
            get; set;
        }

        /// <summary>
        /// Power Monitor Email
        /// </summary>
        public string PME
        {
            get; set;
        }

        /// <summary>
        /// Power Monitor Administrator Distribution List
        /// </summary>
        public string PMADL
        {
            get; set;
        }

        /// <summary>
        /// Attachment Type
        /// </summary>
        public NTPAT AT
        {
            get; set;
        }

        public bool ATSpecified
        {
            get; set;
        }

        /// <summary>
        /// Sending Attachment Email
        /// </summary>
        public string SAE
        {
            get; set;
        }

        /// <summary>
        /// Sending Attachment Start
        /// </summary>
        public System.DateTime SAS
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [sas specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sas specified]; otherwise, <c>false</c>.
        /// </value>
        public bool SASSpecified
        {
            get; set;
        }

        /// <summary>
        /// Send Attachment On Renew
        /// </summary>
        public NTPSAOR SAOR
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [saor specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [saor specified]; otherwise, <c>false</c>.
        /// </value>
        public bool SAORSpecified
        {
            get; set;
        }

        
        #endregion Public Properties
    }
}