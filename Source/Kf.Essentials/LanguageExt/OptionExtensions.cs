using LanguageExt;
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
            => option.Match(
                Some: value => value,
                None: valueIfNoneFunction());
    }
}
