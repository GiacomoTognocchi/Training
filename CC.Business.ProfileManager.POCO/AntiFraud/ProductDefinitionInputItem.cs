// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Collections.Generic;

namespace CC.Business.ProfileManager.POCO
{
    /// <summary>
    /// ProductDefinitionInputItem
    /// </summary>
    public class ProductDefinitionInputItem
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public string DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the input label.
        /// </summary>
        /// <value>
        /// The input label.
        /// </value>
        public string InputLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the input.
        /// </summary>
        /// <value>
        /// The type of the input.
        /// </value>
        public ProductDefinitionInputItemInputType InputType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the option items.
        /// </summary>
        /// <value>
        /// The option items.
        /// </value>
        public List<ProductDefinitionInputItemOptionItems> OptionItems
        {
            get;
            set;
        }

        #endregion Public Properties

    }
}