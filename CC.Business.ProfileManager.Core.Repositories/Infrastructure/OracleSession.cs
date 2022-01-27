using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public class OracleSession : IRepoSession
	{
		private List<OracleCommand> commandList = new List<OracleCommand>();
		private List<OracleDataReader> oracleDataReaderList = new List<OracleDataReader>();

		private readonly OracleConnection connection;
		private OracleTransaction transaction;

		public OracleSession(string connectionString)
		{
			connection = new OracleConnection(connectionString);
		}

		#region IRepoSession Members

		public void OpenConnection()
		{
            if (connection.State != ConnectionState.Open)
                connection.Open();
		}

		public void CloseConnection()
		{
			if (IsTransactionRunning)
			{
				RollbackTransaction();
			}

			// First of all: Close every used Datareaders
			foreach (var odr in oracleDataReaderList)
			{
				if (odr != null)
				{
					if (!odr.IsClosed)
					{
						odr.Close();
					}
					odr.Dispose();
				}
			}

			// Second: Close every used Commands
			foreach (var cmd in commandList)
			{
				if (cmd != null)
				{
					if (cmd.Parameters != null)
					{
						foreach (OracleParameter oracleParameterToDispose in cmd.Parameters)
						{
							if (oracleParameterToDispose.OracleDbType == OracleDbType.RefCursor)
							{
								if (oracleParameterToDispose.Value != null && !(oracleParameterToDispose.Value is DBNull))
								{
									((OracleRefCursor) oracleParameterToDispose.Value).Dispose();
								}
							}
							oracleParameterToDispose.Dispose();
						}
					}
					cmd.Dispose();
				}
			}

			// In the end Close the connection
			if (connection != null && connection.State != ConnectionState.Closed)
			{
				connection.Close();
			}
			if (connection != null)
			{
				connection.Dispose();
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
			var cmd = new OracleCommand
			          	{
			          		Connection = connection,
			          		Transaction = transaction
			          	};

			commandList.Add(cmd);
			return cmd;
		}

		#endregion

		public void AddOracleDataReader(OracleDataReader dataReader)
		{
			oracleDataReaderList.Add(dataReader);
		}
	}
}