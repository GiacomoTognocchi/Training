using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
    public abstract class OracleRowToObjectMapper<TObj> : RowToObjectMapper<TObj,OracleDataReader>
    {
        protected OracleRowToObjectMapper(OracleDataReader reader, string fieldPrefix)
            : base(reader, fieldPrefix)
        {
        }

        #region HelperMethods

        protected string GetNullableString(int i)
        {
            return !reader.IsDBNull(i) ? reader.GetString(i) : null;
        }

        protected string GetString(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetString(i);
        }

        protected Int32 GetInt32(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetInt32(i);
        }

        protected Int32? GetNullableInt32(int i)
        {
            return reader.IsDBNull(i) ? (int?)null : reader.GetInt32(i);
        }

        protected long GetInt64(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetInt64(i);
        }

        protected long? GetNullableInt64(int i)
        {
            return reader.IsDBNull(i) ? (long?)null : reader.GetInt64(i);
        }

        protected Decimal? GetNullableDecimal(int i)
        {
            return !reader.IsDBNull(i) ? (decimal?)reader.GetDecimal(i) : null;
        }

        protected Decimal GetDecimal(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetDecimal(i);
        }

        protected DateTime GetDateTime(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetDateTime(i);
        }

        protected DateTime? GetNullableDateTime(int i)
        {
            return !reader.IsDBNull(i) ? (DateTime?)reader.GetDateTime(i) : null;
        }

        protected TimeSpan GetTimeSpan(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetTimeSpan(i);
        }

        protected TimeSpan? GetNullableTimeSpan(int i)
        {
            return !reader.IsDBNull(i) ? (TimeSpan?)reader.GetTimeSpan(i) : null;
        }

        protected Guid GetGuid(int i)
        {
            byte[] buffer = new byte[16];

            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            reader.GetBytes(i, 0, buffer, 0, 16);

            return new Guid(buffer);
        }

        protected Guid? GetNullableGuid(int i)
        {
            byte[] buffer = new byte[16];
            if (reader.IsDBNull(i))
            {
                return null;
            }

            reader.GetBytes(i, 0, buffer, 0, 16);

            return new Guid(buffer);
        }

        protected bool GetBoolFromString(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            var flg = reader.GetString(i);
            switch (flg)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new ArgumentException();
            }
        }

        protected bool? GetNullableBoolFromString(int i)
        {
            if (!reader.IsDBNull(i))
            {
                var flg = reader.GetString(i);
                switch (flg)
                {
                    case "1":
                        return true;
                    case "0":
                        return false;
                    default:
                        return null;
                }
            }

            return null;
        }

        protected bool GetBoolFromInt(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            var flg = reader.GetInt16(i);
            switch (flg)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    throw new ArgumentException();
            }
        }

        protected string GetNullableClob(int i)
        {
            return !reader.IsDBNull(i) ? reader.GetOracleClob(i).Value : null;
        }

        protected string GetClob(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetOracleClob(i).Value;
        }

        protected Byte[] GetBlob(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetOracleBlob(i).Value;
        }

        protected Byte[] GetNullableBlob(int i)
        {
            return !reader.IsDBNull(i) ? reader.GetOracleBlob(i).Value : null;
        }


        protected Byte[] GetRaw(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetOracleBinary(i).Value;
        }

        protected Byte[] GetNullableRaw(int i)
        {
            return !reader.IsDBNull(i) ? reader.GetOracleBinary(i).Value : null;
        }

        protected Guid GetRawGuid(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return new Guid(reader.GetOracleBinary(i).Value);
        }

        protected XmlDocument GetNullableXmlDocument(int i)
        {
            return !reader.IsDBNull(i) ? reader.GetOracleXmlType(i).GetXmlDocument() : null;
        }

        protected XmlDocument GetXmlDocument(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetOracleXmlType(i).GetXmlDocument();
        }

        #endregion

    }
}
