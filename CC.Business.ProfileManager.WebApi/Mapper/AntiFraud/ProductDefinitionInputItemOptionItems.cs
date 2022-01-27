// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// ProductDefinitionInputItemOptionItems
    /// </summary>
    public static class ProductDefinitionInputItemOptionItems
    {
        #region Public Methods

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.ProductDefinitionInputItemOptionItems Map(Core.CribisComX.BusinessObjects.ProductDefinitionInputItemOptionItems input)
        {
            if (input == null)
            {
                return null as POCO.ProductDefinitionInputItemOptionItems;
            }

            return new POCO.ProductDefinitionInputItemOptionItems
            {
               CodeLabel = input.CodeLabel,
               Key=input.Key,
               Value=input.Value
            };
        }

        #endregion Public Methods
    }
}