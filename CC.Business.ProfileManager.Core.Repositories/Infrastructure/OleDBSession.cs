using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public class OleDBSession : IRepoSession
	{
		private List<OleDbDataReader> readerList = new List<OleDbDataReader>();
		private readonly OleDbConnection connection;
		private OleDbTransaction transaction;

		public OleDBSession(string connectionString)
		{
			connection = new OleDbConnection(connectionString);
		}

		#region IRepoSession Members

		public void OpenConnection()
		{
			connection.Open();
		}

		public void CloseConnection()
		{
			foreach(var r in readerList)
			{
				if (!r.IsClosed)
				{
					r.Close();
				}
			}

			if (connection != null)
			{
				if (connection.State != ConnectionState.Closed)
				{
					connection.Close();
				}
			}
		}

		public void BeginTransaction()
		{
			transaction = connection.BeginTransaction();
		}

		public void CommitTransaction()
		{
			transaction.Commit();
			transaction.Dispose();
			transaction = null;
		}

		public void RollbackTransaction()
		{
			transaction.Rollback();
			transaction.Dispose();
			transaction = null;
		}

		public bool IsTransactionRunning
		{
			get
			{
				return transaction != null;
			}
		}

		public IDbCommand CreateCommand()
		{
			var cmd = new OleDbCommand
			          	{
			          		Connection = connection,
			          		Transaction = transaction
			          	};

			return cmd;
		}

		#endregion

		public OleDbDataReader ExecuteReader(OleDbCommand cmd)
		{
			var r = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			readerList.Add(r);
			return r;
		}
	}
}