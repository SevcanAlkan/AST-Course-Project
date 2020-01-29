using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Validation
{
    public static partial class Validation
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNotValid(this Guid? value)
        {
            return value == null || value == Guid.Empty;
        }
        public static bool IsNotValid(this Guid value)
        {
            return value == null || value == Guid.Empty;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this int? value)
        {
            return value == null || value == 0;
        }

        public static bool IsNullOrEmpty(this DateTime? value)
        {
            return value == null || DateTime.MinValue == value;
        }

        private static bool IsNullOrEmptyEnum<T>(T value) where T : new()
        {
            byte val = Convert.ToByte(value);
            if (value == null || val == 0)
                return true;

            T result = new T();
            if (!Convert.TryParseEnum<T>(val, out result))
                return false;

            return false;
        }
    }
}
