using Kf.Essentials.Reflection;
using System;

namespace Kf
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the name of a <see cref="Type"/> in a human-readible format.
        /// </summary>
        /// <param name="type">The type to get the name for.</param>    
        public static string GetFriendlyName(this Type type)
            => TypeHelper.GetFriendlyTypeName(type);
    }
}
