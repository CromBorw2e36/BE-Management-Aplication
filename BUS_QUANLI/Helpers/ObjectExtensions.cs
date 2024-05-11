using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Helpers
{
    public static class ObjectExtensions
    {
        public static void CopyProperties<TFrom, TTo>(this TFrom source, TTo destination)
        {
            var sourceProperties = typeof(TFrom).GetProperties();
            var destinationProperties = typeof(TTo).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
    }
}
