﻿
namespace Timestamp.Core.Validation
{
    public sealed class FieldValidationInfo
    {
        public string Field { get; private set; }
        public string Message { get; private set; }
        public bool IsValid { get; private set; }

        public FieldValidationInfo(string field, string message, bool isValid)
        {
            Field = field;
            IsValid = isValid;
            Message = message;
        }
    }
}
