using System.Data;
using CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Infrastructure
{
	public abstract class RowToObjectMapper<TObj, IReader> where IReader : IDataReader
	{
		private readonly int fieldOffset;
		private readonly string fieldPrefix;
		protected readonly IReader reader;

		protected RowToObjectMapper(IReader reader, string fieldPrefix)
		{
			this.reader = reader;
			this.fieldPrefix = fieldPrefix;
			fieldOffset = string.IsNullOrEmpty(this.fieldPrefix) ? 0 : this.reader.GetOrdinal(this.fieldPrefix) + 1;
		}

		public abstract TObj Map(TObj obj);

		protected int GetFieldIndex(string fieldBaseName)
		{
			DataTable schema = reader.GetSchemaTable();
			int fieldIndex = -1;
			for (int i = fieldOffset; i < schema.Rows.Count; i++)
			{
				DataRow row = schema.Rows[i];
				string columnName = row["ColumnName"].ToString().ToLower();
				if (columnName.Equals(fieldBaseName.ToLower()))
				{
					fieldIndex = int.Parse(row["ColumnOrdinal"].ToString());
					break;
				}
				if (columnName.Contains("_"))
				{
					throw new FieldNotExistsException(fieldBaseName, fieldPrefix);
				}
			}
			return fieldIndex;
		}

		protected string getChildFieldPrefix(string child)
		{
			return (string.IsNullOrEmpty(fieldPrefix) ? child : string.Format("{0}_{1}", fieldPrefix, child));
		}
	}
}
