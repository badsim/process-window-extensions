using ProcessWindowExtensions.COM;
using Xunit;

namespace ProcessWindowExtensionsTest.Unit
{
    public class ComObjectFactoryUnitTests
    {
        [Fact]
        public void GetImmersiveShell_ReturnsValidComObject()
        {
            var factory = new ComObjectFactory();
            var result = factory.GetImmersiveShell();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetIApplicationViewCollection_ReturnsValidComObject()
        {
            var factory = new ComObjectFactory();
            var result = factory.GetIApplicationViewCollection();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetIVirtualDesktopManager_ReturnsValidComObject()
        {
            var factory = new ComObjectFactory();
            var result = factory.GetIVirtualDesktopManager();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetVirtualDesktopManagerInternal_ReturnsValidComObject()
        {
            var factory = new ComObjectFactory();
            var result = factory.GetVirtualDesktopManagerInternal();
            Assert.NotNull(result);
        }
    }
}