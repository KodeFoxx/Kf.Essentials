using System.Collections.Generic;

namespace Kf
{
    public static class Null
    {
        /// <summary>
        /// Represents null as a string value.
        /// </summary>
        public static string NullString 
            => "(*null)";

        /// <summary>
        /// Represents an empty <see cref="NullStringKeyValuePair"/>.
        /// </summary>
        public static KeyValuePair<string, string> NullStringKeyValuePair
            => KeyValuePair.Create(NullString, NullString);
    }
}
