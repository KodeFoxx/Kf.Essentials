using FluentAssertions;
using LanguageExt;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.LanguageExt
{
    public sealed class OptionExtensions
    {
        [Theory, MemberData(nameof(HasValue_returns_true_when_some_false_when_none_TestData))]
        public void HasValue_returns_true_when_some_false_when_none(
            Option<object> option, bool hasValue
        )
            => option.HasValue().Should().Be(hasValue);

        public static IEnumerable<object[]> HasValue_returns_true_when_some_false_when_none_TestData()
            => Option_of_Object_TestData();

        [Theory, MemberData(nameof(GetValue_returns_original_value_when_some_defaultvalue_when_none_TestData))]
        public void GetValue_returns_original_value_when_some_defaultvalue_when_none(
            Option<string> option, string expectedValue
        )
            => option.GetValue("defaultValue").Should().Be(expectedValue);

        public static IEnumerable<object[]> GetValue_returns_original_value_when_some_defaultvalue_when_none_TestData()
            => Option_of_Object_TestData()
                .Select(array => new object[] 
                { 
                    ((Option<object>)array[0]).Map(f => f.ToString()),
                    ((bool)array[1]) ? ((Option<object>)array[0]).Map(f => f.ToString()) : "defaultValue"
                });

        public static List<object[]> Option_of_Object_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    (Option<object>)null,
                    false
                },
                new object[]
                {
                    Option<object>.None,
                    false
                },
                new object[]
                {
                    Option<object>.Some(""),
                    true
                },
                new object[]
                {
                    Option<object>.Some("  "),
                    true
                },
                new object[]
                {
                    Option<object>.Some("value"),
                    true
                },
            };
    }
}
