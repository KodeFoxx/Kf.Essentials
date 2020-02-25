using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.System
{
    public sealed class ObjectExtenions_DebuggingTests
    {
        [Theory, MemberData(nameof(CreateDebugString_with_expressions_creates_correct_string_TestData))]
        public void CreateDebugString_with_expressions_creates_correct_string(
            string actual, string expected)
            => actual
                .Should().Be(expected);

        public static IEnumerable<object[]> CreateDebugString_with_expressions_creates_correct_string_TestData()
            => new List<object[]>
            {
                new object[] {
                    KeyValuePair.Create("key", "value")
                        .CreateDebugString(kvp => kvp.Key, kvp => kvp.Value),
                    "KeyValuePair<String, String> -> [ Key='key', Value='value' ]"
                },
                new object[] {
                    KeyValuePair.Create("key", (string)null)
                        .CreateDebugString(kvp => kvp.Key, kvp => kvp.Value),
                    $"KeyValuePair<String, String> -> [ Key='key', Value='' ]"
                },
                new object[] {
                    KeyValuePair.Create("key", KeyValuePair.Create("number", 1))
                        .CreateDebugString(kvp => kvp.Key),
                    $"KeyValuePair<String, KeyValuePair<String, Int32>> -> [ Key='key' ]"
                },
                new object[] {
                    new Exception("message", null)
                        .CreateDebugString(ex => ex.Message, ex => ex.InnerException),
                    $"Exception -> [ Message='message', InnerException='' ]"
                }
            };
    }
}
