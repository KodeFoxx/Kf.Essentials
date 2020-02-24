using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kf.Essentials.Diagnostics.Debugging
{
    public static class DebugHelper
    {
        /// <summary>
        /// Create a debug string for a given object.
        /// </summary>
        public static string CreateDebugString(
            object @this,
            params (string Variable, Option<object> Value)[] variablesAndValues
        )
            => variablesAndValues
                .IfNullThenEmpty()
                .Select(variableAndValue => Option<KeyValuePair<string, string>>.Some(
                    KeyValuePair.Create(
                        key: variableAndValue.Variable,
                        value: variableAndValue.Value.Some(x => x.ToString()).None(() => Null.NullString)))
                )
                .FormatDebugString(@this.GetType());

        /// <summary>
        /// Create a debug string for a given object.
        /// </summary>
        public static string CreateDebugString<TObject>(
            TObject @object,
            params Expression<Func<TObject, object>>[] propertySelectors
        )
            => propertySelectors
                .IfNullThenEmpty()
                .Select(propertySelector => @object.GetPropertyNameAndValue(propertySelector))
                .FormatDebugString(@object.GetType());

        /// <summary>
        /// Holds the logic on how to format a debug string.
        /// </summary>
        /// <param name="namesAndValues">Collection of property names with their values.</param>
        /// <param name="type">The type of the object.</param>
        private static string FormatDebugString(
            this IEnumerable<Option<KeyValuePair<string, string>>> namesAndValues,
            Type type
        )
            => $"{type.GetFriendlyName()} -> [ {FormatNamesAndValues(namesAndValues)} ]";

        /// <summary>
        /// Holds the logic on how to format the name and value pair of a property.
        /// </summary>
        private static string FormatNamesAndValues(
            IEnumerable<Option<KeyValuePair<string, string>>> namesAndValues
        )
            => String.Join(
                separator: ", ",
                values: namesAndValues
                    .Somes()
                    .Select(nameAndValue => $"{nameAndValue.Key}='{nameAndValue.Value}'"
                )
            );
    }
}
