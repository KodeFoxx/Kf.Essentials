using System.Collections.Generic;
using System.Linq;

namespace Kf
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> IfNullThenEmpty<T>(
            this IEnumerable<T> enumerable
        )
            => enumerable ?? Enumerable.Empty<T>();
    }
}
