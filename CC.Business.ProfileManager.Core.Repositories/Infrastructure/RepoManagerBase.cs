using System;
using System.Collections.Generic;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public abstract class RepoManagerBase : IDisposable
	{
		protected static readonly Dictionary<String, String> connectionStrings;
		protected IRepoSession session;
		// Track whether Dispose has been called.
		private bool disposed;

		static RepoManagerBase()
		{
			connectionStrings = new Dictionary<string, string>();
		}

		// Use C# destructor syntax for finalization code.
		// This destructor will run only if the Dispose method 
		// does not get called.
		// It gives your base class the opportunity to finalize.
		// Do not provide destructors in types derived from this class.
		~RepoManagerBase()
		{
			// Do not re-create Dispose clean-up code here.
			// Calling Dispose(false) is optimal in terms of
			// readability and maintainability.
			Dispose(false);
		}

		public static void AddConnectionString(string key, string connectionString)
		{
			connectionStrings[key] = connectionString;
		}

		public IRepoSession Session
		{
			get
			{
				return session;
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly
		// or indirectly by a user's code. Managed and unmanaged resources
		// can be disposed.
		// If disposing equals false, the method has been called by the 
		// runtime from inside the finalizer and you should not reference 
		// other objects. Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!disposed)
			{
				// If disposing equals true, dispose all managed 
				// and unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
				}

				// Call the appropriate methods to clean up unmanaged resources here.
				// If disposing is false, only the following code is executed.
				if (session != null)
				{
					if (session.IsTransactionRunning)
					{
						session.RollbackTransaction();
					}

					session.CloseConnection();
				}
			}
			disposed = true;
		}
	}
}