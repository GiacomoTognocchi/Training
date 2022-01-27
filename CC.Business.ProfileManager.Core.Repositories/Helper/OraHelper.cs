using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Helper {
    public static class OraHelper {
        public static OracleParameter AddBoolInputParam(this OracleCommand cmd, string paramName, bool? value) {
            return AddBoolInputParam(cmd, paramName, value, !value.HasValue);
        }

        public static OracleParameter AddBoolInputParam(this OracleCommand cmd, string paramName, bool? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Char, isNull ? null : (value.Value ? "1" : "0"));
        }

        public static OracleParameter AddIntBoolInputParam(this OracleCommand cmd, string paramName, bool? value) {
            return AddIntBoolInputParam(cmd, paramName, value, !value.HasValue);
        }

        public static OracleParameter AddIntBoolInputParam(this OracleCommand cmd, string paramName, bool? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Int16, isNull ? (int?)null : (value.Value ? 1 : 0));
        }

        public static OracleParameter AddStringInputParam(this OracleCommand cmd, string paramName, string value) {
            return AddStringInputParam(cmd, paramName, value, null == value);
        }

        public static OracleParameter AddStringInputParam(this OracleCommand cmd, string paramName, string value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Varchar2, isNull ? null : value);
        }

        public static OracleParameter AddStringArrayInputParam(this OracleCommand cmd, string paramName, string[] value) {
            return AddInputParam(cmd, paramName, OracleDbType.Varchar2, value);
        }

        public static OracleParameter AddDateTimeInputParam(this OracleCommand cmd, string paramName, DateTime? value) {
            return AddDateTimeInputParam(cmd, paramName, value, !value.HasValue || DateTime.MinValue == value);
        }

        public static OracleParameter AddDateTimeInputParam(this OracleCommand cmd, string paramName, DateTime? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Date, isNull ? null : value);
        }

        public static OracleParameter AddIntInputParam(this OracleCommand cmd, string paramName, int? value) {
            return AddIntInputParam(cmd, paramName, value, !value.HasValue || int.MinValue == value);
        }

        public static OracleParameter AddIntInputParam(this OracleCommand cmd, string paramName, int? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Decimal, isNull ? null : value);
        }

        public static OracleParameter AddIntArrayInputParam(this OracleCommand cmd, string paramName, int[] value) {
            return AddInputParam(cmd, paramName, OracleDbType.Decimal, value);
        }

        public static OracleParameter AddLongInputParam(this OracleCommand cmd, string paramName, long? value) {
            return AddLongInputParam(cmd, paramName, value, !value.HasValue || long.MinValue == value);
        }

        public static OracleParameter AddLongInputParam(this OracleCommand cmd, string paramName, long? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Int64, isNull ? null : value);
        }

        public static OracleParameter AddDecimalInputParam(this OracleCommand cmd, string paramName, decimal? value) {
            return AddDecimalInputParam(cmd, paramName, value, !value.HasValue || decimal.MinValue == value);
        }

        public static OracleParameter AddDecimalInputParam(this OracleCommand cmd, string paramName, decimal? value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.Decimal, isNull ? null : value);
        }

        public static OracleParameter AddNClobInputParam(this OracleCommand cmd, string paramName, string value) {
            return AddNClobInputParam(cmd, paramName, value, null == value);
        }

        public static OracleParameter AddNClobInputParam(this OracleCommand cmd, string paramName, string value, bool isNull) {
            return AddInputParam(cmd, paramName, OracleDbType.NClob, isNull ? null : value);
        }

        public static OracleParameter AddRawInputParam(this OracleCommand cmd, string paramName, Byte[] value) {
            return AddInputParam(cmd, paramName, OracleDbType.Raw, value);
        }

        public static OracleParameter AddBlobInputParam(this OracleCommand cmd, string paramName, Byte[] value) {
            return AddInputParam(cmd, paramName, OracleDbType.Blob, value);
        }

        public static OracleParameter AddGuidInputParam(this OracleCommand cmd, string paramName, Guid guid) {
            return AddInputParam(cmd, paramName, OracleDbType.Raw, guid.ToByteArray() );
        }

        public static OracleParameter AddGuidArrayInputParam(this OracleCommand cmd, string paramName, Byte[][] guids) {
            return AddInputParam(cmd, paramName, OracleDbType.Raw, guids);
        }

        public static OracleParameter AddInputParam(this OracleCommand cmd, string paramName, OracleDbType dataType, object value, bool isNull) {
            return AddInputParam(cmd, paramName, dataType, isNull ? null : value);
        }

        public static OracleParameter AddIntOutputParam(this OracleCommand cmd, string paramName) {
            var param = new OracleParameter(paramName, OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add(param);

            return param;
        }

        public static OracleParameter AddInputParam(this OracleCommand cmd, string paramName, OracleDbType dataType, object value) {
            var param = new OracleParameter(paramName, dataType, ParameterDirection.Input);
            cmd.Parameters.Add(param);
            param.Value = value;

            return param;
        }

        public static OracleParameter AddInputCollectionParam(this OracleCommand cmd, string paramName, OracleDbType dataType, OracleCollectionType collectionType, int arraySize, object value) {
            var param = new OracleParameter(paramName, dataType, ParameterDirection.Input);
            cmd.Parameters.Add(param);

            param.CollectionType = collectionType;
            param.Size = arraySize;
            param.Value = value;

            if (value is string[] && arraySize > 0) {
                param.ArrayBindSize = new int[arraySize];
                for (int i = 0; i < arraySize; i++) {
                    param.ArrayBindSize[i] = ((string[])value)[i].Length;
                }
            }

            return param;
        }

        public static OracleParameter AddInputNullCollectionParam(this OracleCommand cmd, string paramName, OracleDbType dataType, OracleCollectionType collectionType, int arraySize, object value) {
            var param = new OracleParameter(paramName, dataType, ParameterDirection.Input);
            cmd.Parameters.Add(param);

            param.OracleDbType = dataType;
            param.CollectionType = collectionType;
            param.Size = 1;
            param.Value = new object[] { null };

            return param;
        }

        public static OracleParameter AddInputCollectionParam(this OracleCommand cmd, string paramName, OracleDbType dataType, OracleCollectionType collectionType, int arraySize, object value, bool isNull) {
            return isNull ? AddInputNullCollectionParam(cmd, paramName, dataType, collectionType, arraySize, isNull ? null : value)
                : AddInputCollectionParam(cmd, paramName, dataType, collectionType, arraySize, isNull ? null : value);
        }

        public static OracleParameter AddStringInputCollectionParam(this OracleCommand cmd, string paramName, string[] value) {
            return AddInputCollectionParam(cmd, paramName, OracleDbType.Varchar2, OracleCollectionType.PLSQLAssociativeArray, null == value ? 0 : value.Length, value, null == value);
        }

        public static OracleParameter AddDecimalInputCollectionParam(this OracleCommand cmd, string paramName, decimal[] value)
        {
            return AddInputCollectionParam(cmd, paramName, OracleDbType.Decimal, OracleCollectionType.PLSQLAssociativeArray, null == value ? 0 : value.Length, value, null == value);
        }

        public static OracleParameter AddBooleanInputCollectionParam(this OracleCommand cmd, string paramName, bool[] value) {
            byte[][] oraValue = null;
            if (value != null) {
                oraValue = new byte[value.Length][];
                for (int i = 0; i < value.Length; i++) {
                    oraValue[i] = OraHelper.BooleanToRaw(value[i]);
                }
            }

            return AddInputCollectionParam(cmd, paramName, OracleDbType.Raw, OracleCollectionType.PLSQLAssociativeArray, null == oraValue ? 0 : oraValue.Length, oraValue, null == oraValue);
        }
        public static OracleParameter AddEnumInputCollectionParam(this OracleCommand cmd, string paramName, object value) {
            string[] stringValue = null;
            if (value != null && value is Array) {
                stringValue = new string[((Array)value).Length];
                int cnt = 0;
                foreach(object o in ((Array)value)) {
                    stringValue[cnt++] = o.ToString();
                }
            }
            return AddStringInputCollectionParam(cmd, paramName, stringValue);
        }

        public static OracleParameter AddCursorOutputParam(this OracleCommand cmd, string paramName) {
            return AddOutputParam(cmd, paramName, OracleDbType.RefCursor);
        }

        public static OracleParameter AddBlobOutputParam(this OracleCommand cmd, string paramName) {
            return AddOutputParam(cmd, paramName, OracleDbType.Blob);
        }

        public static OracleParameter AddOutputParam(this OracleCommand cmd, string paramName, OracleDbType dataType) {
            var param = new OracleParameter(paramName, dataType, ParameterDirection.Output);
            cmd.Parameters.Add(param);

            return param;
        }

        public static OracleParameter AddOutputParam(this OracleCommand cmd, string paramName, OracleDbType dataType, int size) {
            var param = new OracleParameter(paramName, dataType, ParameterDirection.Output);
            param.Size = size;
            cmd.Parameters.Add(param);

            return param;
        }

        public static OracleCommand CreateOracleSPCommand(this IRepoSession session, string packageName, string spName) {
            return CreateOracleSPCommand(session, string.Format("{0}.{1}", packageName, spName));
        }

        public static OracleCommand CreateOracleSPCommand(this IRepoSession session, string spName) {
            var cmd = (OracleCommand)session.CreateCommand();
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            return cmd;
        }

        public static OracleDataReader ExecNonQueryGetReader(this OracleCommand cmd, OracleParameter readerParam) {
            cmd.ExecuteNonQuery();
            return ((OracleRefCursor)readerParam.Value).GetDataReader();
        }

        public static OracleDataReader ExecNonQueryGetReader(this OracleSession session, OracleCommand cmd, OracleParameter readerParam) {
            OracleDataReader retVal;
            cmd.ExecuteNonQuery();
            retVal = ((OracleRefCursor)readerParam.Value).GetDataReader();
            session.AddOracleDataReader(retVal);
            return retVal;
        }

		public static OracleDataReader GetCursorReader(this OracleCommand cmd, OracleParameter readerParam)
		{
			return ((OracleRefCursor)readerParam.Value).GetDataReader();
		}

		public static Dictionary<string, OracleDataReader> ExecNonQueryBatchGetReader(this OracleCommand cmd, OracleSession session)
		{
            cmd.ExecuteNonQuery();

            var result = new Dictionary<string, OracleDataReader>();

            foreach (OracleParameter param in cmd.Parameters) {
                if (param.OracleDbType == OracleDbType.RefCursor) {
                    var odr = ((OracleRefCursor)param.Value).GetDataReader();
                    session.AddOracleDataReader(odr);
                    result.Add(param.ParameterName, odr);
                }
            }

            return result;
        }

        public static byte[] BooleanToRaw(bool input) {
            byte[] retVal = new byte[1];
            if (input) {
                retVal[0] = 1;
            }
            else {
                retVal[0] = 0;
            }
            return retVal;
        }

        public static bool RawToBoolean(byte[] input) {
            bool retVal = false;
            if (input != null) {
                if (input[0] == 1) {
                    retVal = true;
                }
            }
            return retVal;
        }

        public static void SetOracleCollectionParamenterNull(ref OracleParameter opCollection) {
            opCollection.Size = 1;
            opCollection.ArrayBindStatus = new OracleParameterStatus[] { OracleParameterStatus.NullInsert };
            string[] oracleCollectionNull = { null };
            opCollection.Value = oracleCollectionNull;
        }
    }
}
