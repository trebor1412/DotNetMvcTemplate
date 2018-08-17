using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DotNet.Entity
{
    public static class DbSetExtensions
    {
        private static string GetEnumDescription<TEnum>(TEnum item)
        {
            Type type = item.GetType();
            var attribute = type.GetField(item.ToString())
                                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                .Cast<DescriptionAttribute>().FirstOrDefault();

            return attribute == null ? string.Empty : attribute.Description;
        }

        public static void SeedEnumValues<T, TEnum>(this IDbSet<T> dbSet) where T : ModelEnumBase<TEnum> where TEnum : struct
        {
            var enumType = typeof(TEnum);
            if (enumType.IsEnum == false)
            {
                throw new ArgumentException(string.Format("Type '{0}' must be enum", enumType.AssemblyQualifiedName));
            }

            foreach (TEnum evalue in Enum.GetValues(enumType))
            {
                var item = Activator.CreateInstance<T>();
                item.Id = evalue;
                item.Name = Enum.GetName(enumType, evalue);
                item.Description = GetEnumDescription(evalue);
                dbSet.AddOrUpdate(item);
            }
        }
    }
}