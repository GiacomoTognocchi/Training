// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.POCO
{

    /// <summary>
    /// FullMonitoringPNotificationType
    /// FMPNotificationType
    /// </summary>
    public enum FMPNotificationType
    {

        /// <summary>
        /// The single
        /// </summary>
        Single,

        /// <summary>
        /// The aggregate
        /// </summary>
        Aggregate,
    }

    /// <summary>
    /// FullMonitoringFrequence
    /// FMPFrequence
    /// </summary>
    public enum FMPFrequence
    {

        /// <summary>
        /// The daily
        /// </summary>
        Daily,

        /// <summary>
        /// The weekly
        /// </summary>
        Weekly,
    }

    /// <summary>
    /// FullMonitoringLevel
    /// FMPLevel
    /// </summary>
    public enum FMPLevel
    {
        /// <summary>
        /// The alert
        /// </summary>
        Alert,

        /// <summary>
        /// The full
        /// </summary>
        Full
    }

    /// <summary>
    /// FullMonitoringPMode
    /// FMPMode
    /// </summary>
    public enum FMPMode
    {

        /// <summary>
        /// The product
        /// </summary>
        PRODUCT,

        /// <summary>
        /// The standalone
        /// </summary>
        STANDALONE
    }


    /// <summary>
    /// FullMonitoringPUMRMT
    /// FMPUMRMT
    /// </summary>
    public enum FMPUMRMT
    {

        /// <summary>
        /// The automatic
        /// </summary>
        Automatic,

        /// <summary>
        /// The manual
        /// </summary>
        Manual
    }

    /// <summary>
    /// FullMonitoringPMonitoring
    /// FMPMonitoring
    /// </summary>
    public enum FMPMonitoring
    {

        /// <summary>
        /// The on demand
        /// </summary>
        OnDemand,

        /// <summary>
        /// The automatic
        /// </summary>
        Auto
    }
}