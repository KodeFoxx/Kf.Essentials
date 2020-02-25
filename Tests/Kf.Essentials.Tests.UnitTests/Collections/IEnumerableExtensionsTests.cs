using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Collections
{
    public sealed class IEnumerableExtensionsTests
    {
        [Fact]
        public void Null_IEnumerable_returns_empty_array()
        {
            IEnumerable<string> nullIEnumerable = null;

            var sut = nullIEnumerable.IfNullThenEmpty();

            sut.Should().NotBeNull();
            sut.Should().BeEmpty();
            sut.Should().BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void Instantiated_IEnumerable_returns_the_original_array()
        {
            var enumerable = new[] { "a", "b", "c" }.ToList();

            var sut = enumerable.IfNullThenEmpty();

            sut.Should().NotBeNull();
            sut.Should().NotBeEmpty();
            sut.Should().BeEquivalentTo(enumerable);
        }
    }
}
