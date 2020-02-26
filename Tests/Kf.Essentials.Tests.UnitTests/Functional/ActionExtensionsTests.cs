using FluentAssertions;
using LanguageExt;
using System;
using System.Linq;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Functional
{
    public sealed class ActionExtensionsTests
    {
        [Fact]
        public void Executes_action_while_converted_to_func()
        {
            var result = String.Empty;
            var expected = "executed";
            var action = new Action(() => result = expected);

            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<Unit>>();
            sut().Should().Be(Unit.Default);
            result.Should().Be(expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_one_parameter()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(1);

            var action = new Action<string>(s => result = $"{s}");
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, Unit>>();
            sut(testData.Parameters[0]).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_two_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(2);

            var action = new Action<string, string>(
                (s1, s2) 
                    => result = String.Join(
                        separator: "", 
                        value: new[] { s1, s2 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_three_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(3);

            var action = new Action<string, string, string>(
                (s1, s2, s3)
                    => result = String.Join(
                        separator: "",
                        value: new[] { s1, s2, s3 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1],
                testData.Parameters[2]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_four_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(4);

            var action = new Action<string, string, string, string>(
                (s1, s2, s3, s4)
                    => result = String.Join(
                        separator: "",
                        value: new[] { s1, s2, s3, s4 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1],
                testData.Parameters[2],
                testData.Parameters[3]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_five_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(5);

            var action = new Action<string, string, string, string, string>(
                (s1, s2, s3, s4, s5)
                    => result = String.Join(
                        separator: "",
                        value: new[] { s1, s2, s3, s4, s5 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, string, string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1],
                testData.Parameters[2],
                testData.Parameters[3],
                testData.Parameters[4]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_six_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(6);

            var action = new Action<string, string, string, string, string, string>(
                (s1, s2, s3, s4, s5, s6)
                    => result = String.Join(
                        separator: "",
                        value: new[] { s1, s2, s3, s4, s5, s6 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, string, string, string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1],
                testData.Parameters[2],
                testData.Parameters[3],
                testData.Parameters[4],
                testData.Parameters[5]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        [Fact]
        public void Executes_action_while_converted_to_func_with_seven_parameters()
        {
            var result = String.Empty;
            var testData = GetParametersAndExpectedResult(7);

            var action = new Action<string, string, string, string, string, string, string>(
                (s1, s2, s3, s4, s5, s6, s7)
                    => result = String.Join(
                        separator: "",
                        value: new[] { s1, s2, s3, s4, s5, s6, s7 }
                    )
            );
            var sut = action.ToFunc();

            result.Should().BeNullOrEmpty();
            sut.Should().BeOfType<Func<string, string, string, string, string, string, string, Unit>>();
            sut(
                testData.Parameters[0],
                testData.Parameters[1],
                testData.Parameters[2],
                testData.Parameters[3],
                testData.Parameters[4],
                testData.Parameters[5],
                testData.Parameters[6]
            ).Should().Be(Unit.Default);
            result.Should().Be(testData.Expected);
        }

        private static (string[] Parameters, string Expected) GetParametersAndExpectedResult(
            int amount, char character = '.'
        )
        {
            var parameters = GetParameters(amount)
                .Select(c => c.ToString())
                .ToArray();

            return (parameters, String.Join("", parameters));
        }

        private static char[] GetParameters(int amount)
            => new string('.', amount).ToCharArray();
            
    }
}
