using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timestamp.Core.Validation;

namespace Timestamp.Core.Exceptions
{
    [Serializable]
    public class FieldsValidationException : Exception
    {
        public int Status { get; set; } = 400;
        public IList<FieldValidationInfo> FieldsValidation { get; }
        public FieldsValidationException(string message) : base(message)
        {
            FieldsValidation = new List<FieldValidationInfo>
            {
                new FieldValidationInfo(string.Empty, message, false)
            };
        }

        public FieldsValidationException(string message, IList<FieldValidationInfo> fieldsValidation) : base(message)
        {
            FieldsValidation = fieldsValidation;
        }

        public override string Message => GetErrorSummary();

        private string GetErrorSummary()
        {
            var sb = new StringBuilder();

            sb.Append("The following fields entered are not valid\n");

            foreach (var val in FieldsValidation.Where(c => !c.IsValid))
            {
                sb.Append($"{val.Field} : {val.Message}\n");
            }
            return sb.ToString();
        }
    }
}
