// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

using System.Linq;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Mapper
{
    /// <summary>
    /// AFPPRODUCT
    /// </summary>
    public class AFPPRODUCT : ProductDefinition
    {
        public static POCO.AFPPRODUCT Map(Core.CribisComX.BusinessObjects.AFPPRODUCT input)
        {
            if (input == null)
            {
                return null as POCO.AFPPRODUCT;
            }

            return new POCO.AFPPRODUCT
            {
                InputItem = input.InputItem?.Select(ProductDefinitionInputItem.Map)?.ToList(),
                MN = input.MN,
                PC = input.PC,
                PID = input.PID,
                PNS = input.PNS,
                SID = input.SID,
                TP = input.TP,
                TPR = input.TPR,
                VN = input.VN
            };
        }
    }
}