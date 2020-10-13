using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using System;

namespace Kf
{
    public static class OptionExtensions
    {
        public static bool HasValue<T>(this Option<T> option)
            => option.IsSome;

        public static T GetValue<T>(
            this Option<T> option, T valueIfNone)
            => option.GetValue(() => valueIfNone);

        public static T GetValue<T>(
            this Option<T> option, Func<T> valueIfNoneFunction)
        {
            if (option.IsSome)
                return option.ValueUnsafe();

            return valueIfNoneFunction();
        }
    }
}
