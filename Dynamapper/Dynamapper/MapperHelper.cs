using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Dynamapper
{
    internal static class MapperHelper
    {
        /// <summary>
        /// Set Object value to Entity Property
        /// </summary>
        /// <param name="propertyName">Entity Property Name</param>
        /// <param name="value">Value to set</param>
        /// <param name="obj">Entity Object to Update</param>
        internal static void SetObjectProperty(string propertyName, object value, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

            if (propertyInfo != null)
            {
                var changedValue = ChangeType(value, propertyInfo);
                propertyInfo.SetValue(obj, changedValue, null);
            }
        }

        /// <summary>
        /// Convert value to it's property info value type. Manage nullable type.
        /// </summary>
        /// <param name="value">Value object to convert</param>
        /// <param name="propertyInfo">Property info</param>
        /// <returns>Converted object value</returns>
        private static object ChangeType(object value, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }

            return Convert.ChangeType(value, propertyType, CultureInfo.InvariantCulture);
        }
    }
}
