using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timestamp.Core.Exceptions;

namespace Timestamp.Core.Validation
{
    public class Guard
    {
        private readonly IList<FieldValidationInfo> _validations;

        public Guard()
        {
            _validations = new List<FieldValidationInfo>();
        }

        public void Validate(string message = "Errors Occurred")
        {
            if (_validations.Any(x => !x.IsValid))
                throw new FieldsValidationException(message, _validations.Where(c => !c.IsValid).ToList());
        }

        public Guard NotNull(string field, object obj)
        {
            _validations.Add(obj == null
                ? new FieldValidationInfo(field, $"The field {field} is mandatory", false)
                : ValidationOk());

            return this;
        }

        public Guard NotNullOrEmpty(string field, string value)
        {
            _validations.Add(string.IsNullOrEmpty(value)
                ? new FieldValidationInfo(field, $"The field  {field} not be null", false)
                : ValidationOk());

            return this;
        }

        public Guard GreaterThan(string field, IComparable number, IComparable greaterThanNumber)
        {
            _validations.Add(Compare.GetComparisonResult(number, greaterThanNumber) > 0
                ? ValidationOk()
                : new FieldValidationInfo(field, $"The field {field} must be greater than {greaterThanNumber}.", false));

            return this;
        }

        public Guard EnumValidate(TypeEnum field)
        {
            _validations.Add(Enum.IsDefined(typeof(TypeEnum), field) == true
                ? ValidationOk()
                : new FieldValidationInfo(Enum.GetName(typeof(TypeEnum), field), $"The field {field} is not valid.", false));

            return this;
        }

        private FieldValidationInfo ValidationOk()
        {
            return new FieldValidationInfo("", "", true);
        }
    }
}
