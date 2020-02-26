using LanguageExt;
using System;

namespace Kf
{
    public static class ActionExtensions
    {
        public static Func<Unit> ToFunc(this Action action)
            => () => { 
                action(); 
                return Unit.Default; 
            };

        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => t => { 
                action(t); 
                return Unit.Default; 
            };

        public static Func<T1, T2, Unit> ToFunc<T1, T2>(
            this Action<T1, T2> action
        )
            => (t1, t2) => {
                action(t1, t2);
                return Unit.Default;
            };

        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(
            this Action<T1, T2, T3> action
        )
            => (t1, t2, t3) => {
                action(t1, t2, t3);
                return Unit.Default;
            };

        public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action
        )
            => (t1, t2, t3, t4) => {
                action(t1, t2, t3, t4);
                return Unit.Default;
            };

        public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> action
        )
            => (t1, t2, t3, t4, t5) => {
                action(t1, t2, t3, t4, t5);
                return Unit.Default;
            };

        public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> action
        )
            => (t1, t2, t3, t4, t5, t6) => {
                action(t1, t2, t3, t4, t5, t6);
                return Unit.Default;
            };

        public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> action
        )
            => (t1, t2, t3, t4, t5, t6, t7) => {
                action(t1, t2, t3, t4, t5, t6, t7);
                return Unit.Default;
            };
    }
}
