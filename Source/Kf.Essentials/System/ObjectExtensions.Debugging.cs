using Kf.Essentials.Diagnostics.Debugging;
using LanguageExt;
using System;
using System.Linq.Expressions;

namespace Kf
{
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// Creates a debug string.
        /// </summary>
        public static string CreateDebugString(
            this object @this,
            params (string Variable, Option<object> Value)[] variablesAndValues
        )
            => DebugHelper.CreateDebugString(@this, variablesAndValues);

        /// <summary>
        /// Creates a debug string.
        /// </summary>
        public static string CreateDebugString<TObject>(
            this TObject @this,
            params Expression<Func<TObject, object>>[] propertySelectors
        )
            => DebugHelper.CreateDebugString(@this, propertySelectors);
    }
}
