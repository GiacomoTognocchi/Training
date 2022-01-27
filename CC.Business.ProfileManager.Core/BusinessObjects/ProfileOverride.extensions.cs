using System;

namespace CC.Business.ProfileManager.Core.CribisComX.ProfileOverride
{
    public partial class PO
    {
        public PO(String nameSpacePrefix, String nameSpace) : this()
        {
            AddNameSpace(nameSpacePrefix, nameSpace);
        }

        public void AddNameSpace(String nameSpacePrefix, String nameSpace)
        {
            if (String.IsNullOrEmpty(nameSpace)) return;
            ND.Add(new POND { N = nameSpace, P = nameSpacePrefix ?? String.Empty });
        }

        public void AddOverride(String xpath, String value)
        {
            if (String.IsNullOrEmpty(xpath)) return;
            O.Add(new POO { X = xpath, V = value ?? String.Empty });
        }

    }
}
