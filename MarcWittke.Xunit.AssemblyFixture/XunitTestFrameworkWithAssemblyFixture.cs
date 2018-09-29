using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MarcWittke.Xunit.AssemblyFixture
{
    public class XunitTestFrameworkWithAssemblyFixture : XunitTestFramework
    {
        public XunitTestFrameworkWithAssemblyFixture(IMessageSink messageSink)
            : base(messageSink)
        {
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            return new XunitTestFrameworkExecutorWithAssemblyFixture(assemblyName, SourceInformationProvider,
                DiagnosticMessageSink);
        }
    }
}