using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Helper;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CC.Business.ProfileManager.Core.CribisComX
{
	public static class DBHelper
	{
		private const string CONNECTION_KEY = "ProfileManagerConnectionString";

		public static ProfileData GetProfile(string connectionString, ProfileKey key)
		{
			OracleCommand cmd = null;
			OracleDataReader odrProfile = null;
			OracleDataReader odrOverrides = null;
			Dictionary<string, OracleDataReader> vodrOutParameters = null;

			ProfileData retVal = null;

			try
			{
				RepoManager.AddConnectionString(CONNECTION_KEY, connectionString);
				RepoManager dbManager = new RepoManager(CONNECTION_KEY);

				cmd = OraHelper.CreateOracleSPCommand(dbManager.Session as OracleSession, "pkgCCP_Profilations", "prGetProfilation");
				cmd.BindByName = true;

				//-- ********************************************************************************************************************************
				//PROCEDURE prGetProfilation (  pCodGateway                     IN     CCPE_PROFILATIONS.CODGATEWAY%TYPE                     -- VARCHAR2(50)
				//                             ,pCodProfilationObjectNamespace  IN     CCPE_PROFILATIONS.CODPROFILATIONOBJECTNAMESPACE%TYPE  -- VARCHAR2(50)
				//                             ,pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODHIERARCHYDISTINGUISHEDNAME%TYPE  -- VARCHAR2(2000)
				//                             ,pRcProfile                         OUT SYS_REFCURSOR
				//                             ,pRcOverrides                       OUT SYS_REFCURSOR
				//                           );
				//-- ********************************************************************************************************************************

				cmd.AddStringInputParam("pCodGateway", key.Gateway);
				cmd.AddStringInputParam("pCodProfilationObjectNamespace", key.Namespace);
				cmd.AddStringInputParam("pCodHierarchyDistinguishedName", key.HierarchyDN);
				var pRcProfile = cmd.AddOutputParam("pRcProfile", OracleDbType.RefCursor);
				var pRcOverrides = cmd.AddOutputParam("pRcOverrides", OracleDbType.RefCursor);

				using (dbManager = dbManager.OpenTransaction)
				{

					vodrOutParameters = cmd.ExecNonQueryBatchGetReader((OracleSession)dbManager.Session);
					odrProfile = vodrOutParameters["pRcProfile"];
					while (odrProfile.Read())
					{
						var profileId = new Guid(odrProfile.GetOracleBinary(odrProfile.GetOrdinal("UIDPROFILE")).Value);
						var profilationObjectNamespace = odrProfile.GetOracleString(odrProfile.GetOrdinal("CODPROFILATIONOBJECTNAMESPACE")).Value;

						var profileName = "";
						var osProfileName = odrProfile.GetOracleString(odrProfile.GetOrdinal("CODPROFILENAME"));
						if (osProfileName != null && osProfileName.IsNull == false)
						{
							profileName = osProfileName.Value;
						}

						var xmlProfile = "";
						var obXmlProfile = odrProfile.GetOracleBlob(odrProfile.GetOrdinal("LOBXMLPROFILE"));
						if (obXmlProfile != null && obXmlProfile.IsNull == false && obXmlProfile.IsEmpty == false)
						{
							xmlProfile = Encoding.UTF8.GetString(obXmlProfile.Value);
						}

						var expiryInterval = odrProfile.GetOracleIntervalDS(odrProfile.GetOrdinal("INTEXPIRYCACHE")).Value;

						bool renewable = OraHelper.RawToBoolean(odrProfile.GetOracleBinary(odrProfile.GetOrdinal("FLGRENEWABLECACHE")).Value);

						var xmlOverrides = new Dictionary<string, string>();
						odrOverrides = vodrOutParameters["pRcOverrides"];
						while (odrOverrides.Read())
						{
							var hierarchyDN = odrOverrides.GetOracleString(odrOverrides.GetOrdinal("CODUSERFULLNAME")).Value;
							var obXmlOverride = odrOverrides.GetOracleBlob(odrOverrides.GetOrdinal("LOBXMLOVERRIDE"));
							if (obXmlOverride != null && obXmlOverride.IsNull == false && obXmlOverride.IsEmpty == false)
							{
								xmlOverrides.Add(hierarchyDN, Encoding.UTF8.GetString(obXmlOverride.Value));
							}
						}

						retVal = new ProfileData(key)
						{
							Overrides = xmlOverrides,
							Xml = xmlProfile,
							Expiry = new ExpiryData(expiryInterval, renewable)
						};
					}
					dbManager.Session.CommitTransaction();
				}
			}
			finally
			{
				//OracleConnectionHelper.CloseCommandAndConnection(cmd);
			}

			return retVal;
		}
		public static List<string> GetVariationPackages(string connectionString, string userFullName, bool isPerson = false)
		{
			OracleConnection cn = null;
			OracleCommand cmd = null;
			List<OracleParameter> parameters = new List<OracleParameter>();
			var ret = new List<string>();
			using (cn = new OracleConnection(connectionString))
			{
				try
				{
					cn.Open();
					using (cmd = new OracleCommand("PKGCCO_POWERMONITOR_HLP.prGetEntityMonitorPackages", cn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.BindByName = true;

						byte[] flagPerson = isPerson ? new byte[] { 01 } : new byte[] { 00 };
						cmd.Parameters.Add("pflgPerson", OracleDbType.Raw, flagPerson, ParameterDirection.Input);
						cmd.Parameters.Add("pUserFullName", OracleDbType.Varchar2, userFullName, ParameterDirection.Input);

						cmd.Parameters.Add("pRcMonPackages", OracleDbType.RefCursor, ParameterDirection.Output);

						cmd.ExecuteNonQuery();

						var refCursor = (OracleRefCursor)cmd.Parameters["pRcMonPackages"].Value;
						var dataReader = refCursor != null && !refCursor.IsNull ? refCursor.GetDataReader() : null;

						if (dataReader != null)
						{
							var read = dataReader.Read();

							while (read)
							{
								var codPacakgeCode = dataReader.GetString(dataReader.GetOrdinal("CODPACKAGECODE"));
								ret.Add(codPacakgeCode);

								read = dataReader.Read();
							}
						}

						return ret;
					}
				}
				finally
				{
					#region Dispose
					if (cmd != null)
					{
						foreach (OracleParameter p in cmd.Parameters)
							p.Dispose();
						cmd.Dispose();
					}
					if (cn != null)
						cn.Dispose();
					#endregion
				}
			}
		}
		public static List<string> GetVariationPackagesPA(string connectionString)
		{
			OracleConnection cn = null;
			OracleCommand cmd = null;
			List<OracleParameter> parameters = new List<OracleParameter>();
			var ret = new List<string>();
			using (cn = new OracleConnection(connectionString))
			{
				try
				{
					cn.Open();
					using (cmd = new OracleCommand("PKGCCO_POWERMONITOR_HLP.prGetCodeProductMonPackages", cn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.BindByName = true;
						
						cmd.Parameters.Add("pCodGroupProductType", OracleDbType.Varchar2, "RepImpPA", ParameterDirection.Input);

						cmd.Parameters.Add("pRcCodeProductMonPackages", OracleDbType.RefCursor, ParameterDirection.Output);

						cmd.ExecuteNonQuery();

						var refCursor = (OracleRefCursor)cmd.Parameters["pRcCodeProductMonPackages"].Value;
						var dataReader = refCursor != null && !refCursor.IsNull ? refCursor.GetDataReader() : null;

						if (dataReader != null)
						{
							var read = dataReader.Read();

							while (read)
							{
								var codPacakgeCode = dataReader.GetString(dataReader.GetOrdinal("CODPACKAGECODE"));
								ret.Add(codPacakgeCode);

								read = dataReader.Read();
							}
						}

						return ret;
					}
				}
				finally
				{
					#region Dispose
					if (cmd != null)
					{
						foreach (OracleParameter p in cmd.Parameters)
							p.Dispose();
						cmd.Dispose();
					}
					if (cn != null)
						cn.Dispose();
					#endregion
				}
			}
		}
		[Obsolete]
		public static bool SetProfilation(string connectionString, ProfilationDataOverride data)
		{
			return SetProfilationOverride(connectionString, data);
		}

		public static bool SetProfilationOverride(string connectionString, ProfilationDataOverride data)
		{
			int result;

			RepoManagerBase.AddConnectionString(CONNECTION_KEY, connectionString);
			RepoManager dbManager = new RepoManager(CONNECTION_KEY);

			OracleCommand cmd = dbManager.Session.CreateOracleSPCommand("pkgCCP_Profilations", "prSetProfilation");
			cmd.BindByName = true;

			//-- ********************************************************************************************************************************
			//PROCEDURE prSetProfilation (  pCodGateway                     IN     CCPE_PROFILATIONS.CODGATEWAY%TYPE                     -- VARCHAR2(50)
			//                             ,pCodProfilationObjectNamespace  IN     CCPE_PROFILATIONS.CODPROFILATIONOBJECTNAMESPACE%TYPE  -- VARCHAR2(50)
			//                             ,pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODHIERARCHYDISTINGUISHEDNAME%TYPE  -- VARCHAR2(2000)
			//                             ,pLobXmlOverride  IN     CCPE_PROFILATIONS.LOBXMLOVERRIDE%TYPE  -- BLOB(4000)
			//                           );
			//-- ********************************************************************************************************************************

			cmd.AddStringInputParam("pCodGateway", data.Channel);
			cmd.AddStringInputParam("pCodProfilationObjectNamespace", data.Namespace);
			cmd.AddStringInputParam("pCodHierarchyDistinguishedName", data.HierarchyDN);
			cmd.AddBlobInputParam("pLobXmlOverride", Encoding.UTF8.GetBytes(data.OverrideXml));

			using (dbManager = dbManager.OpenTransaction)
			{
				result = cmd.ExecuteNonQuery();
				dbManager.Session.CommitTransaction();
			}

			return result > 0;
		}

		public static bool SetProfilationProfile(string connectionString, ProfilationDataProfile data)
		{
			int result;

			RepoManagerBase.AddConnectionString(CONNECTION_KEY, connectionString);
			RepoManager dbManager = new RepoManager(CONNECTION_KEY);

			OracleCommand cmd = dbManager.Session.CreateOracleSPCommand("pkgCCP_Profilations", "prSetProfilationProfile");
			cmd.BindByName = true;

			//-- ********************************************************************************************************************************
			//   PROCEDURE prSetProfilationProfile 
			//               (  pCodGateway                     IN     CCPE_PROFILATIONS.CODGATEWAY%TYPE                     -- VARCHAR2(50)
			//                 ,pCodProfilationObjectNamespace  IN     CCPE_PROFILATIONS.CODPROFILATIONOBJECTNAMESPACE%TYPE  -- VARCHAR2(50)
			//                 ,pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODUSERFULLNAME%TYPE  -- VARCHAR2(2000)
			//                 ,pLOBXMLPROFILE                  IN     CCPE_PROFILES.LOBXMLPROFILE%TYPE  -- BLOB(4000)
			//               )
			//-- ********************************************************************************************************************************

			cmd.AddStringInputParam("pCodGateway", data.Channel);
			cmd.AddStringInputParam("pCodProfilationObjectNamespace", data.Namespace);
			cmd.AddStringInputParam("pCodHierarchyDistinguishedName", data.HierarchyDN);
			cmd.AddBlobInputParam("pLOBXMLPROFILE", Encoding.UTF8.GetBytes(data.ProfileXml));

			using (dbManager = dbManager.OpenTransaction)
			{
				result = cmd.ExecuteNonQuery();
				dbManager.Session.CommitTransaction();
			}

			return result > 0;
		}

		public static bool UpdateProfilationProfile(string connectionString, ProfilationDataProfile data)
		{
			int result;

			RepoManagerBase.AddConnectionString(CONNECTION_KEY, connectionString);
			RepoManager dbManager = new RepoManager(CONNECTION_KEY);

			OracleCommand cmd = dbManager.Session.CreateOracleSPCommand("pkgCCP_Profilations", "prUpdateProfilationProfile");
			cmd.BindByName = true;

			//-- ********************************************************************************************************************************
			//   PROCEDURE prUpdateProfilationProfile 
			//               (  pCodGateway                     IN     CCPE_PROFILATIONS.CODGATEWAY%TYPE                     -- VARCHAR2(50)
			//                 ,pCodProfilationObjectNamespace  IN     CCPE_PROFILATIONS.CODPROFILATIONOBJECTNAMESPACE%TYPE  -- VARCHAR2(50)
			//                 ,pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODUSERFULLNAME%TYPE  -- VARCHAR2(2000)
			//                 ,pLOBXMLPROFILE                  IN     CCPE_PROFILES.LOBXMLPROFILE%TYPE  -- BLOB(4000)
			//               )
			//-- ********************************************************************************************************************************

			cmd.AddStringInputParam("pCodGateway", data.Channel);
			cmd.AddStringInputParam("pCodProfilationObjectNamespace", data.Namespace);
			cmd.AddStringInputParam("pCodHierarchyDistinguishedName", data.HierarchyDN);
			cmd.AddBlobInputParam("pLOBXMLPROFILE", Encoding.UTF8.GetBytes(data.ProfileXml));

			using (dbManager = dbManager.OpenTransaction)
			{
				result = cmd.ExecuteNonQuery();
				dbManager.Session.CommitTransaction();
			}

			return result > 0;
		}

		public static bool DeleteProfilation(string connectionString, ProfileKey key)
		{
			int result;

			RepoManagerBase.AddConnectionString(CONNECTION_KEY, connectionString);
			RepoManager dbManager = new RepoManager(CONNECTION_KEY);

			OracleCommand cmd = dbManager.Session.CreateOracleSPCommand("pkgCCP_Profilations", "prDeleteProfilation");
			cmd.BindByName = true;

			//-- ********************************************************************************************************************************
			//  PROCEDURE prDeleteProfilation (  pCodGateway                     IN     CCPE_PROFILATIONS.CODGATEWAY%TYPE                     -- VARCHAR2(50)
			//                  ,pCodProfilationObjectNamespace  IN     CCPE_PROFILATIONS.CODPROFILATIONOBJECTNAMESPACE%TYPE      -- VARCHAR2(50)
			//                  ,pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODUSERFULLNAME%TYPE  -- VARCHAR2(2000)
			//                 );
			//-- ********************************************************************************************************************************

			cmd.AddStringInputParam("pCodGateway", key.Gateway);
			cmd.AddStringInputParam("pCodProfilationObjectNamespace", key.Namespace);
			cmd.AddStringInputParam("pCodHierarchyDistinguishedName", key.HierarchyDN);

			using (dbManager = dbManager.OpenTransaction)
			{
				result = cmd.ExecuteNonQuery();
				dbManager.Session.CommitTransaction();
			}

			return result > 0;
		}

		public static bool InsertOrDeleteActions(string connectionString, string actionFOfNotify, string hierarchyDN, int insertOrDelete)
		{
			int result;

			RepoManagerBase.AddConnectionString(CONNECTION_KEY, connectionString);
			RepoManager dbManager = new RepoManager(CONNECTION_KEY);

			OracleCommand cmd = dbManager.Session.CreateOracleSPCommand("PKGCCO_PM_BASE", "prInsertOrDeleteActions");

			cmd.BindByName = true;

			//-- ********************************************************************************************************************************
			//      PROCEDURE prInsertOrRemoveActions 
			//                  (
			//                      pCodHierarchyDistinguishedName  IN     CCPE_PROFILATIONS.CODUSERFULLNAME%TYPE  -- VARCHAR2(2000)
			//                      ,actionFOfNotify                IN     VARCHAR2
			//                      ,insertOrDelete                 IN     number                                  -- 1 = insert, 0 = Delete 
			//                  );
			//-- ********************************************************************************************************************************

			cmd.AddStringInputParam("pCodHierarchyDistinguishedName", hierarchyDN + "%");
			cmd.AddStringInputParam("actionFOfNotify", actionFOfNotify.ToUpper());
			cmd.AddIntInputParam("insertOrDelete", insertOrDelete); // insertOrDelete = 1 = insert, insertOrDelete = 0 = Delete

			using (dbManager = dbManager.OpenTransaction)
			{
				result = cmd.ExecuteNonQuery();
				dbManager.Session.CommitTransaction();
			}

			return result > 0;
		}
	}
}
