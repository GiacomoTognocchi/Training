// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System;
using System.Linq;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// ProductDefinitionInputItem
    /// </summary>
    public class ProductDefinitionInputItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDefinitionInputItem"/> class.
        /// </summary>
        protected ProductDefinitionInputItem()
        {
        }

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static POCO.ProductDefinitionInputItem Map(Core.CribisComX.BusinessObjects.ProductDefinitionInputItem input)
        {
            if (input == null)
            {
                return null as POCO.ProductDefinitionInputItem;
            }

            return new POCO.ProductDefinitionInputItem
            {
                DefaultValue = input.DefaultValue,
                InputLabel = input.InputLabel,
                InputType= (POCO.ProductDefinitionInputItemInputType)Enum.Parse(
                    typeof(POCO.ProductDefinitionInputItemInputType), input.InputType.ToString(), true),
                Key= input.Key,
                OptionItems = input.OptionItems?.Select(ProductDefinitionInputItemOptionItems.Map)?.ToList()
            };
        }

    }
}