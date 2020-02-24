using System;

namespace Kf
{
    public static class ArrayExtensions
    {
        public static T[] IfNullThenEmpty<T>(
            this T[] array
        )
            => array ?? Array.Empty<T>();
    }
}
