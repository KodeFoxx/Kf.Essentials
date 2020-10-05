using FluentAssertions;
using System;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.System
{
    public sealed class ObjectExtenions_ReflectionTests
    {
        [Fact]
        public void GetPropertyInfo_returns_the_selected_PropertyInfo()
        {
            var stringObject = "stringObject";

            var sut = stringObject.GetPropertyInfo(p => p.Length)
                .Some(v => v)
                .None(() => null);

            sut.Should().NotBeNull();
            sut.Name.Should().Be(nameof(stringObject.Length));
        }

        [Fact]
        public void GetPropertyNameAndValue_returns_the_name_and_value_of_the_property()
        {
            var stringObject = "stringObject";

            var sut = stringObject.GetPropertyNameAndValue(p => p.Length)
                .Some(v => v)
                .None(Null.NullStringKeyValuePair);

            sut.Should().NotBeNull();
            sut.Key.Should().Be(nameof(stringObject.Length));
            sut.Value.Should().Be(stringObject.Length.ToString());
        }

        [Fact]
        public void GetPropertyNameAndValue_returns_NullKeyValuePair_when_not_found()
        {
            var stringObject = "stringObject";

            var sut = stringObject.GetPropertyNameAndValue<string, object>(null)
                .Some(v => v)
                .None(Null.NullStringKeyValuePair);

            sut.Should().NotBeNull();
            sut.Should().Be(Null.NullStringKeyValuePair);
        }

        [Fact]
        public void GetPropertyName_returns_the_name_of_the_property()
        {
            var stringObject = "stringObject";

            var sut = stringObject.GetPropertyName(p => p.Length);

            sut.IsNullOrWhiteSpace().Should().BeFalse();
            sut.Should().Be(nameof(stringObject.Length));
        }

        [Fact]
        public void GetPropertyName_returns_empty_string_when_not_found()
        {
            var stringObject = "stringObject";

            var sut = stringObject.GetPropertyName<string, object>(null);

            sut.IsNullOrWhiteSpace().Should().BeTrue();
            sut.Should().Be(String.Empty);
        }
    }
}
