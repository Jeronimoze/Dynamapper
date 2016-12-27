using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Dynamapper.Attributes;

namespace Dynamapper
{
    /// <summary>
    /// Mapper Extension to dynamically map Sql dynamic Query results to Entity
    /// </summary>
    public static class MapperExtension
    {
        /// <summary>
        /// Map method Extension for dynamic item list
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="items">Dynamic list to map</param>
        /// <returns>List of mapped entity items</returns>
        public static IEnumerable<T> Map<T>(this IEnumerable<dynamic> items) where T : class
        {
            var listType = typeof(List<>).MakeGenericType(new[] { typeof(T) });
            var list = (List<T>)Activator.CreateInstance(listType);

            if (items == null || items.Count() == 0)
            {
                return list;
            }

            foreach (var row in items)
            {
                var rowItems = new List<MappingRow>();
                var rowItem = (IDictionary<string, object>)row;

                var keyList = rowItem.Keys.ToList();
                var objectValues = rowItem.Values.ToList();

                keyList.ForEach(k =>
                {
                    rowItems.Add(new MappingRow
                    {
                        KeyName = k,
                        Index = keyList.IndexOf(k)
                    });
                });

                // Set item values from dynamic object values
                foreach (var itemRow in rowItems)
                {
                    itemRow.Value = objectValues[itemRow.Index];
                }

                var entityy = (T)Activator.CreateInstance(typeof(T));
                MapColumnToEntity<T>(entityy, rowItems);
                list.Add(entityy);
            }

            return list;
        }

        /// <summary>
        /// Map Result Columns To Entity
        /// </summary>
        /// <typeparam name="T">Entity Item Type</typeparam>
        /// <param name="item">Entity Item</param>
        /// <param name="rows">Result rows</param>
        private static void MapColumnToEntity<T>(T item, List<MappingRow> rows) where T : class
        {
            var properties = item.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute));
                var storedAsMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(StoredAs));

                var mappingName = string.Empty;

                if (columnMapping != null)
                {
                    var mapsto = columnMapping as ColumnAttribute;
                    mappingName = mapsto.Name;
                }
                else if (storedAsMapping != null)
                {
                    var mapsto = storedAsMapping as StoredAs;
                    mappingName = mapsto.Value;
                }
                else
                {
                    mappingName = property.Name;
                }

                var propertyData = rows.FirstOrDefault(r => r.KeyName.Equals(mappingName, StringComparison.OrdinalIgnoreCase));

                if (propertyData != null && propertyData.Value != null)
                {
                    MapperHelper.SetObjectProperty(property.Name, propertyData.Value, item);
                }
            }
        }

    }
}
