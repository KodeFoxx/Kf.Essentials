using System;
using System.Collections.Generic;
using System.Linq;

namespace Kf
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> IfNullThen<T>(
            this IEnumerable<T> enumerable,
            Func<IEnumerable<T>> valueIfNullFactory
        )
            => enumerable ?? valueIfNullFactory();

        public static IEnumerable<T> IfNullThen<T>(
            this IEnumerable<T> enumerable,
            IEnumerable<T> valueIfNull
        )
            => enumerable.IfNullThen(() => valueIfNull);

        public static IEnumerable<T> IfNullThenEmpty<T>(
            this IEnumerable<T> enumerable
        )
            => enumerable.IfNullThen(Enumerable.Empty<T>());
    }
}
