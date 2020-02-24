using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Reflection
{
    public sealed class TypeExtensionsTests
    {
        [Fact]
        public void Returns_null_string_when_target_type_is_null()
            => ((Type)null).GetFriendlyName()
                .Should().Be(Null.NullString);

        [Theory, MemberData(nameof(Returns_friendly_name_of_given_type_TestData))]
        public void Returns_friendly_name_of_given_type(
            object @object, string expected
        )
            => @object.GetType().GetFriendlyName()
                .Should().Be(expected);

        public static IEnumerable<object[]> Returns_friendly_name_of_given_type_TestData()
            => new List<object[]>
            {
                new object[]
                {
                    new List<string>(),
                    "List<String>"
                },

                new object[]
                {
                    new HashSet<KeyValuePair<string, List<int>>>(),
                    "HashSet<KeyValuePair<String, List<Int32>>>"
                },
            };

    }
}
