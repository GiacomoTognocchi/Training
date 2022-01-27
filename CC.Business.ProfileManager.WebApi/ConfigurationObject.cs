using CC.Core.Business.Configuration;

namespace CC.Business.ProfileManager.WebApi.CribisComX
{
    public class ConfigurationObject : ConfigurationObjectBase
    {        
        public string ProfileStoreConnectionString { get; set; }
		public string VariationPackagesConnectionString { get; set; }
		public string BalancesheetProfileNamespace { get; set; }
        public string ClustersProfileNamespace { get; set; }
        public string VirtualDeskProfileNamespace { get; set; }
        public string ReportPurchaseProfileNamespace { get; set; }
        public string ProductsPurchaseProfileNamespace { get; set; }  
        public string CompanyReportProfileNamespace { get; set;}
        public string FullMonitoringProfileNamespace { get; set; }
        public string StorageProfileNamespace { get; set; }
        public string NegativeEventsProfileNamespace { get; set; }
        public string DBAIProfileNamespace { get; set; }


        //TODO metodi per accounting price
        /*
     
     

        

        /// <summary>
        /// Gets or sets the anti fraud profile namespace.
        /// </summary>
        /// <value>
        /// The anti fraud profile namespace.
        /// </value>
        public string AntiFraudProfileNamespace
        {
            get;set;
        }

    
        /// <summary>
        /// Gets or sets the market lab profile namespace.
        /// </summary>
        /// <value>
        /// The market lab profile namespace.
        /// </value>
        public string MarketLabProfileNamespace
        {
            get; set;
        }

    
        /// <summary>
        /// Gets or sets the dbai profile namespace.
        /// </summary>
        /// <value>
        /// The dbai profile namespace.
        /// </value>
        public string DBAIProfileNamespace
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the i trade profile namespace.
        /// </summary>
        /// <value>
        /// The i trade profile namespace.
        /// </value>
        public string TradeProfileNamespace
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the marketing list profile namespace.
        /// </summary>
        /// <value>
        /// The marketing list profile namespace.
        /// </value>
        public string MarketingListProfileNamespace
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the notifications profile namespace.
        /// </summary>
        /// <value>
        /// The notifications profile namespace.
        /// </value>
        public string NotificationsProfileNamespace
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the user preferences profile namespace.
        /// </summary>
        /// <value>
        /// The user preferences profile namespace.
        /// </value>
        public string UserPreferencesProfileNamespace
        {
            get; set;
        }
     */
    }
}
