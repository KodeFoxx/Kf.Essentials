using FluentAssertions;
using System;
using System.Threading;
using Xunit;

namespace Kf.Essentials.Tests.UnitTests.Functional
{
    public sealed class Functional_UsingTests
    {
        [Fact]
        public void Wrap_action_into_using_statement()
        {
            var result = String.Empty;
            
            Kf.Functional
                .Using(
                    GetDisposable(), 
                    d => { result = d.GetType().GetFriendlyName(); }
                );

            result.Should().Be(typeof(Timer).GetFriendlyName());
        }

        [Fact]
        public void Wrap_function_into_using_statement()
            => Kf.Functional
                .Using(
                    GetDisposable(), 
                    d => d.GetType()
                )
                .Should().Be(typeof(Timer));        

        private static Timer GetDisposable()
            => new Timer(new TimerCallback(o => { }));
    }
}
