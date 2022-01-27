using System;

namespace CC.Business.ProfileManager.Core.CribisComX 
{
    public class ProfilationDataOverride : ProfilationDataKey
    {
        public string OverrideXml { get; private set; }

        public ProfilationDataOverride(ProfileKey key, String overrideXml)
            : base(key)
        {
            OverrideXml = overrideXml;
        }
    }
}
