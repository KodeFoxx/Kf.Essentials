using System;
using System.Linq;
using System.Text;

namespace Kf.Essentials.Reflection
{
    public static class TypeHelper
    {
        /// <summary>
        /// Gets the name of a <see cref="Type"/> in a human-readible format.
        /// </summary>
        /// <param name="type">The type to get the name for.</param>
        public static string GetFriendlyName(Type type)
        {
            if (type == null)
                return Null.NullString;

            if (!type.IsGenericType)
                return type.Name;

            var typeName = type.Name;
            var typeGenericArguments = type.GetGenericArguments();

            return new StringBuilder()
                .Append(typeName.Substring(0, typeName.LastIndexOf('`')))
                .Append(typeGenericArguments.Aggregate(
                        seed: "<",
                        func: (aggregate, enclosedType)
                            => GenerateTypeStringPart(aggregate, enclosedType)
                    )
                 )
                .Append(">")
                .ToString();

            string CommaOrEmptyString(string aggregate)
                => aggregate == "<"
                    ? String.Empty
                    : ", ";

            string GenerateTypeStringPart(string aggregate, Type enclosedType)
                => $"{aggregate}{CommaOrEmptyString(aggregate)}{GetFriendlyName(enclosedType)}";
        }
    }
}
