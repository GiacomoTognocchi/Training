using System;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions
{
    [Serializable()]
    public class RepositorySessionOpenException : Exception
    {
        public RepositorySessionOpenException(Exception innerException)
            : base("RepositorySessionOpenException", innerException)
        {

        }
    }
}
