using FluentAssertions;
using Kf.Essentials.Comparison.Ranges;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Comparison.Ranges.Time
{
    public sealed class DateTimeRangeExtensionsTests
    {
        [Theory, MemberData(nameof(AsEnumerable_returns_correct_collection_TestData))]
        public void AsEnumerable_returns_correct_collection(
            IRange<DateTime> dateTimeRange,
            Func<DateTime, DateTime> calculateNextValue,
            long amountOfValues)
        {
            var dateTimeValues = dateTimeRange.AsEnumerable(calculateNextValue).ToList();
            dateTimeValues.First().Should().Be(dateTimeRange.Minimum);
            dateTimeValues.Last().Should().Be(dateTimeRange.Maximum);
            dateTimeValues.LongCount().Should().Be(amountOfValues);
            dateTimeValues.Distinct().LongCount().Should().Be(amountOfValues);
        }

        public static IEnumerable<object[]> AsEnumerable_returns_correct_collection_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 01)
                    ),
                    null,
                    1 // always take in account the maximum T-value in the calculation
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 02)
                    ),
                    null,
                    2
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 03)
                    ),
                    null,
                    3
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 02)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByHours,
                    (1 * 24) + 1
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 02).AddHours(-1)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByHours,
                    (1 * 24)
                },
                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 01).AddHours(1)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByHours,
                    2
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByHours,
                    (6 * 24) + 1
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByMinutes,
                    (6 * 24 * 60) + 1
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueBySeconds,
                    (6 * 24 * 60 * 60) + 1
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    DateTimeRangeExtensions.CalculateNextValueByMilliseconds,
                    ((6 * 24 * 60 * 60) * 1000L) + 1
                },
            };

        [Theory, MemberData(nameof(IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included_TestData))]
        public void IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included(
            IRange<DateTime> dateTimeRange,
            DateTime value,
            bool expected
        )
            => value.IsInRange(dateTimeRange).Should().Be(expected);

        public static IEnumerable<object[]> IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01),
                    true
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07),
                    true
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01).AddMilliseconds(1),
                    true
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01).AddMilliseconds(-1),
                    false
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07).AddMilliseconds(1),
                    false
                },

                new object[]
                {
                    new Range<DateTime>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07).AddMilliseconds(-1),
                    true
                },
            };

        [Theory, MemberData(nameof(Nullable_IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included_TestData))]
        public void Nullable_IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included(
            IRange<DateTime?> dateTimeRange,
            DateTime? value,
            bool expected
        )
            => value.IsInRange(dateTimeRange).Should().Be(expected);

        public static IEnumerable<object[]> Nullable_IsInRange_returns_true_when_between_minimum_and_maximum_bounds_included_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new Range<DateTime?>(
                        null,
                        null
                    ),
                    null,
                    false
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    null,
                    false
                },

                new object[]
                {
                    new Range<DateTime?>(
                        null,
                        null
                    ),
                    new DateTime(2000, 01, 01),
                    true
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01),
                    true
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07),
                    true
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01).AddMilliseconds(1),
                    true
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 01).AddMilliseconds(-1),
                    false
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07).AddMilliseconds(1),
                    false
                },

                new object[]
                {
                    new Range<DateTime?>(
                        minimum: new DateTime(2000, 01, 01),
                        maximum: new DateTime(2000, 01, 07)
                    ),
                    new DateTime(2000, 01, 07).AddMilliseconds(-1),
                    true
                },
            };
    }
}
