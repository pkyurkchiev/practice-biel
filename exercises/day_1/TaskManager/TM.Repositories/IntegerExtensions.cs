using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Repositories
{
    public static class IntegerExtensions
    {
        public static bool IsAnyNullOrEmpty(this object obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return false;

            return obj.GetType().GetProperties()
                .Any(x => IsNullOrEmpty(x.GetValue(obj)));
        }

        private static bool IsNullOrEmpty(this object value)
        {
            if (Object.ReferenceEquals(value, null))
                return false;

            var type = value.GetType();
            return type.IsValueType
                && Object.Equals(value, Activator.CreateInstance(type));
        }
    }
}
