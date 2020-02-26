using System;

namespace Kf
{
    public static partial class Functional
    {
        public static TResult Using<TDisposable, TResult>(
           TDisposable disposable,
           Func<TDisposable, TResult> function
        )
            where TDisposable : IDisposable
        {
            if (function == null) return default;

            using (disposable) { return function(disposable); }
        }

        public static void Using<TDisposable>(
           TDisposable disposable,
           Action<TDisposable> action
        )
            where TDisposable : IDisposable
        {
            if (action == null) return;

            using (disposable) { action(disposable); }
        }
    }
}
