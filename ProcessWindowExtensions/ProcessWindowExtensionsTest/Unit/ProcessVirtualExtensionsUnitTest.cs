using FluentAssertions;
using ProcessWindowExtensions;
using Xunit;

namespace ProcessWindowExtensionsTest.Unit
{
    public class ProcessVirtualExtensionsUnitTest
    {
        [Fact]
        public void GetAvailableDesktopsGuids_ReturnsAtLeastOneValue()
        {
            var list = ProcessVirtualDesktopExtensions.GetAvailableDesktopsGuids();
            list.Should().HaveCountGreaterOrEqualTo(1);
        }
    }
}