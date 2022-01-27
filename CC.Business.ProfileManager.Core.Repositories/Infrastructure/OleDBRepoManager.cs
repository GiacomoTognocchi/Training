using System;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public class OleDBRepoManager : RepoManagerBase
	{
		public OleDBRepoManager(string connectionStringKey)
		{
			session = new OleDBSession(connectionStringKey);
		}

		public OleDBRepoManager OpenSession
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

		public OleDBRepoManager OpenTransaction
		{
			get
			{
				try
				{
					session.OpenConnection();
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