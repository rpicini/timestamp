using System;
using System.Collections.Generic;
using System.Text;

namespace Timestamp.Core.Validation
{
    public static class Compare
    {
        public static int GetComparisonResult(IComparable value, IComparable valueToCompare)
        {
            if (TryCompare(value, valueToCompare, out var result))
            {
                return result;
            }

            return value.CompareTo(valueToCompare);
        }

        public static bool TryCompare(IComparable value, IComparable valueToCompare, out int result)
        {
            try
            {
                ValueCompare(value, valueToCompare, out result);
                return true;
            }
            catch (Exception)
            {
                result = 0;
            }

            return false;
        }

        private static void ValueCompare(IComparable value, IComparable valueToCompare, out int result)
        {
            try
            {
                result = value.CompareTo(valueToCompare);
            }
            catch (ArgumentException)
            {
                if (value is decimal || valueToCompare is decimal ||
                    value is double || valueToCompare is double ||
                    value is float || valueToCompare is float)
                {
                    result = Convert.ToDouble(value).CompareTo(Convert.ToDouble(valueToCompare));
                }
                else
                {
                    result = ((long)value).CompareTo((long)valueToCompare);
                }
            }
        }
    }
}
