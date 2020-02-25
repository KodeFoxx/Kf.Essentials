using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.System
{
    public sealed class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, "isNullOrEmpty")]
        [InlineData("", "isNullOrEmpty")]
        public void IfNullOrEmptyThen_returns_true_value_when_null_or_empty(
            string @string, string expected
        )
            => @string
                .IfNullOrEmptyThen("isNullOrEmpty", "isNotNullOrEmpty")
                .Should().Be(expected);

        [Theory]
        [InlineData(" ", "isNotNullOrEmpty")]
        [InlineData("This is a full string", "isNotNullOrEmpty")]
        public void IfNullOrEmptyThen_returns_false_value_when_not_null_or_empty(
            string @string, string expected
        )
            => @string
                .IfNullOrEmptyThen("isNullOrEmpty", "isNotNullOrEmpty")
                .Should().Be(expected);

        [Theory]
        [InlineData(null, "isNullOrWhiteSpace")]
        [InlineData("", "isNullOrWhiteSpace")]
        [InlineData(" ", "isNullOrWhiteSpace")]
        public void IfNullOrWhiteSpaceThen_returns_true_value_when_null_or_whitespace(
            string @string, string expected
        )
            => @string
                .IfNullOrWhiteSpaceThen("isNullOrWhiteSpace", "isNotNullOrWhiteSpace")
                .Should().Be(expected);

        [Theory]
        [InlineData("This is a full string", "isNotNullOrWhiteSpace")]
        public void IfNullOrWhiteSpaceThen_returns_false_value_when_not_null_or_whitespace(
            string @string, string expected
        )
            => @string
                .IfNullOrWhiteSpaceThen("isNullOrWhiteSpace", "isNotNullOrWhiteSpace")
                .Should().Be(expected);

        [Theory]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        [InlineData("0", true)]
        [InlineData("-1", true)]
        [InlineData("1.1", false)]
        [InlineData("1,1", false)]
        public void IsInteger_returns_true_when_Int32_else_false(
            string @string, bool expected
        )
            => @string
                .IsInteger()
                .Should().Be(expected);

        [Theory]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        [InlineData("0", true)]
        [InlineData("-1", true)]
        [InlineData("1.1", true)]
        [InlineData("1,1", true)]
        public void IsNumeric_returns_true_when_Double_else_false(
            string @string, bool expected
        )
            => @string
                .IsNumeric()
                .Should().Be(expected);

        [Theory]
        [InlineData(null, "")]
        [InlineData(" ", "")]
        [InlineData("", "")]
        [InlineData("     ", "")]
        [InlineData("This is a string", "Thisisastring")]
        [InlineData("This is a string, with punctuation.", "Thisisastring,withpunctuation.")]
        [InlineData("This   is    a      s tr ing", "Thisisastring")]
        public void RemoveAllWhiteSpaces_removes_all_occurences_of_WhiteSpace_characters(
            string @string, string expected
        )
            => @string
                .RemoveAllWhiteSpaces()
                .Should().Be(expected);
    }
}
