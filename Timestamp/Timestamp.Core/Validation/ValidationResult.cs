using System;
using System.Collections.Generic;
using System.Text;

namespace Timestamp.Core.Validation
{
    public class ValidationResult
    {
        public string Target { get; set; }
        public string Value { get; set; }

        public ValidationResult(string target, string value)
        {
            Target = target;
            Value = value;
        }
    }
}
