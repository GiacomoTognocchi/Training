using System.Data;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public interface IRepoSession
	{
		void OpenConnection();
		void CloseConnection();

		void BeginTransaction();
		void CommitTransaction();
		void RollbackTransaction();

		bool IsTransactionRunning{ get;}

		IDbCommand CreateCommand();
	}
}