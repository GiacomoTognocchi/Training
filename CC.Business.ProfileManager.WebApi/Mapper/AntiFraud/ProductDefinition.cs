// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Collections.Generic;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// ProductDefinition
    /// </summary>
    public class ProductDefinition
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the input item.
        /// </summary>
        /// <value>
        /// The input item.
        /// </value>
        public List<ProductDefinitionInputItem> InputItem
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets the mn.
        /// </summary>
        /// <value>
        /// The mn.
        /// </value>
        public string MN
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the pc.
        /// </summary>
        /// <value>
        /// The pc.
        /// </value>
        public string PC
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the pid.
        /// </summary>
        /// <value>
        /// The pid.
        /// </value>
        public string PID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the PNS.
        /// </summary>
        /// <value>
        /// The PNS.
        /// </value>
        public string PNS
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        /// <value>
        /// The sid.
        /// </value>
        public string SID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the tp.
        /// </summary>
        /// <value>
        /// The tp.
        /// </value>
        public string TP
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TPR.
        /// </summary>
        /// <value>
        /// The TPR.
        /// </value>
        public string TPR
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the vn.
        /// </summary>
        /// <value>
        /// The vn.
        /// </value>
        public string VN
        {
            get; set;
        }

        #endregion Public Properties
    }
}