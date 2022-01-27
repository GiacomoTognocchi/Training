// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Collections.Generic;

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// AntiFraudProfile
    /// AFP
    /// </summary>
    public class AntiFraudProfile
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public List<AFPPRODUCT> PRODUCT
        {
            get;set;
        }

        #endregion Public Properties
    }
}