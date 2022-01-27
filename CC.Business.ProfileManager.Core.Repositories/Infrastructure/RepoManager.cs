using System;
using System.Collections.Generic;
using System.Configuration;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public class RepoManager : RepoManagerBase
	{
		public RepoManager(string connectionStringKey)
		{
			if (connectionStrings.ContainsKey(connectionStringKey))
			{
				session = new OracleSession(connectionStrings[connectionStringKey]);
			}
			else
			{
				throw new ConfigurationErrorsException(String.Format("No connectionString found in RepoManager collection for key {0}.", connectionStringKey));
			}
		}

		public RepoManager OpenSession
		{
			get
			{
				try
				{
					session.OpenConnection();
				}
				catch (System.InvalidOperationException ex)
				{
					throw new RepositorySessionOpenException(ex);
				}

				return this;
			}
		}

		public RepoManager OpenTransaction
		{
			get
			{
				try
				{
					session.OpenConnection();
                    if (! session.IsTransactionRunning)
					    session.BeginTransaction();
				}
				catch (System.InvalidOperationException ex)
				{
					throw new RepositorySessionOpenException(ex);
				}

				return this;
			}
		}
	}
}