using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
    public abstract class OleDbRowToObjectMapper<TObj> : RowToObjectMapper<TObj, OleDbDataReader>
    {
        protected OleDbRowToObjectMapper(OleDbDataReader reader, string fieldPrefix)
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

        protected string GetNullableValueConvertedToString(int i)
        {
            return !reader.IsDBNull(i) ? reader[i].ToString() : "";
        }

        protected string GetValueConvertedToString(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader[i].ToString();
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

        protected Double? GetNullableDouble(int i)
        {
            return !reader.IsDBNull(i) ? (Double?)reader.GetDouble(i) : null;
        }

        protected Double GetDouble(int i)
        {
            if (reader.IsDBNull(i))
            {
                throw new ArgumentNullException();
            }

            return reader.GetDouble(i);
        }


        #endregion
    }
}
