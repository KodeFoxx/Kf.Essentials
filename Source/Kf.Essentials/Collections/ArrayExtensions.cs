using System;

namespace Kf
{
    public static class ArrayExtensions
    {
        public static T[] IfNullThen<T>(
            this T[] array,
            Func<T[]> valueIfNullFactory
        )
            => array ?? valueIfNullFactory();

        public static T[] IfNullThen<T>(
            this T[] enumerable,
            T[] valueIfNull
        )
            => enumerable.IfNullThen(() => valueIfNull);

        public static T[] IfNullThenEmpty<T>(
            this T[] array
        )
            => array.IfNullThen(Array.Empty<T>());
    }
}
