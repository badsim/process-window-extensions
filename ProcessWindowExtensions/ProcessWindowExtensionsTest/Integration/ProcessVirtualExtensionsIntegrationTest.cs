using System;
using System.Diagnostics;
using System.Threading;
using FluentAssertions;
using ProcessWindowExtensions;
using Xunit;

namespace ProcessWindowExtensionsTest.Integration
{
    public class ProcessVirtualExtensionsIntegrationTest
    {
        private readonly string _testProcessName = "notepad";

        [Fact]
        public void ProcessReturnsValidDesktopGuid()
        {
            var process = Process.Start(_testProcessName);
            Thread.Sleep(100);
            var guid = process?.GetVirtualDesktopGuid();
            process?.Kill();
            guid.Should().NotBe(Guid.Empty);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void MoveToDesktop_MovesWindowToSelectedDesktop(int desktopId)
        {
            var process = Process.Start(_testProcessName);
            Thread.Sleep(100);
            var guid = process?.MoveToDesktop(desktopId);
            process?.Kill();
            guid.Should().NotBe(Guid.Empty);
        }
    }
}