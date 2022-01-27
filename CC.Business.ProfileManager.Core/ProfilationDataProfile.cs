using System;

namespace CC.Business.ProfileManager.Core.CribisComX 
{
    public class ProfilationDataProfile : ProfilationDataKey
    {
        public string ProfileXml { get; private set; }

        public ProfilationDataProfile(ProfileKey key, String profileXml) 
            : base(key)
        {
            ProfileXml = profileXml;
        }
    }
}
