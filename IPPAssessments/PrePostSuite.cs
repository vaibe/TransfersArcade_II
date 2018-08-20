using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using IntPracticePOM.Reporting;
using IntPracticePOM.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM
{
    [SetUpFixture]
    public class PrePostSuite
    {
        [OneTimeSetUp]
        public void Begin()
        {
            PrePostTest.StartExecution();
        }

        [OneTimeTearDown]
        public void Finish()
        {
            PrePostTest.EndExecution();
            
        }
    }
}
