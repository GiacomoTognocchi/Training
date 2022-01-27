using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions
{
    [Serializable()]
    public class IdentityNotDefinedException : Exception
    {
        public IdentityNotDefinedException(Exception innerException)
            : base("IdentityNotDefinedException", innerException)
        {

        }

        public IdentityNotDefinedException()
            : base("IdentityNotDefinedException")
        {

        }
    }
}
