using Xunit;

#if DEBUG

// The custom test framework enables the support
[assembly: TestFramework("MarcWittke.Xunit.AssemblyFixture.XunitTestFrameworkWithAssemblyFixture", "MarcWittke.Xunit.AssemblyFixture")]

// Add one of these for every fixture classes for the assembly.
// Just like other fixtures, you can implement IDisposable and it'll
// get cleaned up at the end of the test run.
[assembly: MarcWittke.Xunit.AssemblyFixture.AssemblyFixture(typeof(MarcWittke.Xunit.AssemblyFixture.MyAssemblyFixture))]

namespace MarcWittke.Xunit.AssemblyFixture
{
    public class Sample
    {
        [Fact]
        public void SampleTest()
        {
            Assert.Equal(1, MyAssemblyFixture.InstanceCount);
        }
    }

    public class MyAssemblyFixture
    {
        public static int InstanceCount { get; private set; }

        public MyAssemblyFixture()
        {
            InstanceCount++;
        }
    }
}
#endif