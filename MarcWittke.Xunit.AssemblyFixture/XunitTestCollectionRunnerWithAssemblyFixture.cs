﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MarcWittke.Xunit.AssemblyFixture
{

    public class XunitTestCollectionRunnerWithAssemblyFixture : XunitTestCollectionRunner
    {
        readonly Dictionary<Type, object> _assemblyFixtureMappings;
        readonly IMessageSink _diagnosticMessageSink;

        public class XunitTestFrameworkWithAssemblyFixture : XunitTestFramework
        {
            public XunitTestFrameworkWithAssemblyFixture(IMessageSink messageSink)
                : base(messageSink)
            { }

            protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
                => new XunitTestFrameworkExecutorWithAssemblyFixture(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }
        
        public XunitTestCollectionRunnerWithAssemblyFixture(Dictionary<Type, object> assemblyFixtureMappings,
            ITestCollection testCollection,
            IEnumerable<IXunitTestCase> testCases,
            IMessageSink diagnosticMessageSink,
            IMessageBus messageBus,
            ITestCaseOrderer testCaseOrderer,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource)
            : base(testCollection, testCases, diagnosticMessageSink, messageBus, testCaseOrderer, aggregator, cancellationTokenSource)
        {
            this._assemblyFixtureMappings = assemblyFixtureMappings;
            this._diagnosticMessageSink = diagnosticMessageSink;
        }

        protected override Task<RunSummary> RunTestClassAsync(ITestClass testClass, IReflectionTypeInfo @class, IEnumerable<IXunitTestCase> testCases)
        {
            // Don't want to use .Concat + .ToDictionary because of the possibility of overriding types,
            // so instead we'll just let collection fixtures override assembly fixtures.
            var combinedFixtures = new Dictionary<Type, object>(_assemblyFixtureMappings);
            foreach (var kvp in CollectionFixtureMappings)
                combinedFixtures[kvp.Key] = kvp.Value;

            // We've done everything we need, so let the built-in types do the rest of the heavy lifting
            return new XunitTestClassRunner(testClass, @class, testCases, _diagnosticMessageSink, MessageBus, TestCaseOrderer, new ExceptionAggregator(Aggregator), CancellationTokenSource, combinedFixtures).RunAsync();
        }
    }
}