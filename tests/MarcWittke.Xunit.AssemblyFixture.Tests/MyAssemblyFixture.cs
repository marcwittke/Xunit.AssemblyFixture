namespace MarcWittke.Xunit.AssemblyFixture.Tests
{
    public class MyAssemblyFixture
    {
        public static int InstanceCount { get; private set; }

        public MyAssemblyFixture()
        {
            InstanceCount++;
        }
    }
}