using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using IntPracticePOM;
using IntPracticePOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace IPPAssessments.FeatureSteps
{
    [Binding]
    public sealed class Hooks1 : PrePostTest
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            StartExecution();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            StartUp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TakeDown();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            EndExecution();
        }


        

    }
}
