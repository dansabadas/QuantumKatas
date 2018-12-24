// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

//////////////////////////////////////////////////////////////////////
// This file contains parts of the testing harness. 
// You should not modify anything in this file.
// The tasks themselves can be found in Tasks.qs file.
//////////////////////////////////////////////////////////////////////

using System.Diagnostics;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.XUnit;
using Xunit.Abstractions;

namespace Quantum.Kata.BasicGates
{
    public class TestSuiteRunner
    {
        private readonly ITestOutputHelper _output;

        public TestSuiteRunner(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>
        /// This driver will run all Q# tests (operations named "...Test") 
        /// that belong to namespace Quantum.Kata.BasicGates.
        /// </summary>
        [OperationDriver(TestNamespace = "Quantum.Kata.BasicGates")]
        public void TestTarget(TestOperation op)
        {
            using (var sim = new QuantumSimulator())
            {
                // OnLog defines action(s) performed when Q# test calls function Message
                sim.OnLog += msg => { _output.WriteLine(msg); };
                sim.OnLog += msg => { Debug.WriteLine(msg); };
                op.TestOperationRunner(sim);
            }
        }
    }
}
