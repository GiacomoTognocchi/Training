using System;

namespace CC.Business.ProfileManager.Core.Repositories.CribisComX.Exceptions
{
    public class FieldNotExistsException : Exception
    {
        private readonly string fieldName;
        private readonly string fieldGroup;

        public FieldNotExistsException(string fieldName, string fieldGroup)
        {
            this.fieldName = fieldName;
            this.fieldGroup = fieldGroup;
        }

        public FieldNotExistsException(string fieldName, string fieldGroup, Exception innerException):base(innerException.Message,innerException)
        {
            this.fieldName = fieldName;
            this.fieldGroup = fieldGroup;
        }


        public override string Message
        {
            get { return string.Format("fieldGroup:{0}, fieldName:{1}", fieldGroup, fieldName); }
        }

        public string FieldName
        {
            get { return fieldName; }
        }

        public string FieldGroup
        {
            get { return fieldGroup; }
        }
    }

}
