using FluentAssertions;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Collections
{
    public sealed class ArrayExtensionsTests
    {
        [Fact]
        public void Null_array_returns_empty_array()
        {
            string[] nullArray = null;

            var sut = nullArray.IfNullThenEmpty();

            sut.Should().NotBeNull();
            sut.Should().BeEmpty();
            sut.Should().BeEquivalentTo(new string[] { });
        }

        [Fact]
        public void Instantiated_array_returns_the_original_array()
        {
            var array = new[] { "a", "b", "c" };

            var sut = array.IfNullThenEmpty();

            sut.Should().NotBeNull();
            sut.Should().NotBeEmpty();
            sut.Should().BeEquivalentTo(array);
        }
    }
}
