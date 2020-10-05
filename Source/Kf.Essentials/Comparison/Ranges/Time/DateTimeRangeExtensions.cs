using Kf.Essentials.Comparison.Ranges;
using System;
using System.Collections.Generic;

namespace Kf
{
    public static class DateTimeRangeExtensions
    {
        /// <summary>
        /// Increments a <see cref="DateTime"/> by one millisecond.
        /// </summary>
        public static Func<DateTime, DateTime> CalculateNextValueByMilliseconds
            => new Func<DateTime, DateTime>(dt => dt.AddMilliseconds(1));

        /// <summary>
        /// Increments a <see cref="DateTime"/> by one second.
        /// </summary>
        public static Func<DateTime, DateTime> CalculateNextValueBySeconds
            => new Func<DateTime, DateTime>(dt => dt.AddSeconds(1));

        /// <summary>
        /// Increments a <see cref="DateTime"/> by one minute.
        /// </summary>
        public static Func<DateTime, DateTime> CalculateNextValueByMinutes
            => new Func<DateTime, DateTime>(dt => dt.AddMinutes(1));

        /// <summary>
        /// Increments a <see cref="DateTime"/> by one hour.
        /// </summary>
        public static Func<DateTime, DateTime> CalculateNextValueByHours
            => new Func<DateTime, DateTime>(dt => dt.AddHours(1));

        /// <summary>
        /// Increments a <see cref="DateTime"/> by one day.
        /// </summary>
        public static Func<DateTime, DateTime> CalculateNextValueByDays
            => new Func<DateTime, DateTime>(dt => dt.AddDays(1));

        /// <summary>
        /// Converts a <see cref="IRange{DateTime}"/> to an <see cref="IEnumerable{DateTime}"/>.
        /// </summary>
        /// <param name="dateTimeRange">The <see cref="IRange{DateTime}"/> to use.</param>
        /// <param name="calculateNextValue">The calculation logic, defaults to <see cref="CalculateNextValueByDays"/>.</param>
        /// <returns>An <see cref="IEnumerable{DateTime}"/>.</returns>
        public static IEnumerable<DateTime> AsEnumerable(
            this IRange<DateTime> dateTimeRange,
            Func<DateTime, DateTime> calculateNextValue = null
        )
        {
            if (calculateNextValue == null)
                calculateNextValue = CalculateNextValueByDays;

            var currentValue = dateTimeRange.Minimum;
            while (currentValue <= dateTimeRange.Maximum)
            {
                yield return currentValue;
                currentValue = calculateNextValue(currentValue);
            }
        }

        /// <summary>
        /// Determines whether a given <see cref="DateTime"/> falls within the given range.
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <param name="dateTimeRange">The range to evaluate against.</param>
        /// <returns>True when in range; false when out of range.</returns>
        public static bool IsInRange(
            this DateTime value,
            IRange<DateTime> dateTimeRange
        )
            => value >= dateTimeRange.Minimum
            && value <= dateTimeRange.Maximum;

        /// <summary>
        /// Determines whether a given <see cref="DateTime?"/> falls within the given range.
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <param name="dateTimeRange">The range to evaluate against.</param>
        /// <returns>True when in range; false when out of range.</returns>
        public static bool IsInRange(
            this DateTime value,
            IRange<DateTime?> dateTimeRange
        )
            => value >= dateTimeRange.Minimum.GetValueOrDefault(DateTime.MinValue)
            && value <= dateTimeRange.Maximum.GetValueOrDefault(DateTime.MaxValue);

        /// <summary>
        /// Determines whether a given <see cref="DateTime?"/> falls within the given range.
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <param name="dateTimeRange">The range to evaluate against.</param>
        /// <returns>True when in range; false when out of range.</returns>
        public static bool IsInRange(
            this DateTime? value,
            IRange<DateTime?> dateTimeRange
        )
            => value.HasValue
                ? value.GetValueOrDefault(DateTime.MinValue).IsInRange(dateTimeRange)
                : false;
    }
}
