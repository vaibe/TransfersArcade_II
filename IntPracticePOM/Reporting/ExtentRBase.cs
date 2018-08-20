using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Reporting
{
    public class ExtentRBase
    {
        protected static ExtentReports _extent;
        protected static ExtentTest _test;
        private static string dir;

        public static void OneTimeSetup()
        {
            dir = NUnit.Framework.TestContext.CurrentContext.TestDirectory + @"\..\..\..\";
            //var fileName = _extent.GetType().ToString() + "TestResult.html";
            var htmlReporter = new ExtentHtmlReporter(dir + "TestReport.html");

            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            ICapabilities capabilities = ((RemoteWebDriver)PrePostTest.sWebDriver).Capabilities;

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Hostname", hostname);
            _extent.AddSystemInfo("Operating System", os.ToString());            
            _extent.AddSystemInfo("Browser", capabilities.BrowserName);

            htmlReporter.Configuration().Theme = Theme.Dark;
        }

        public static void OneTimeTearDown()
        {
            _extent.Flush();
        }

        //[TestFixture]
        //public class TestInitializeWithNullValues : ExtentRBase
        //{
        //    [Test]
        //    public void TestNameNull()
        //    {
        //        Assert.Throws(() => testNameNull());
        //    }
        //}
        
        public static void BeforeTest() //[SetUp]
        {
            _test = _extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name);
        }
        
        public static void AfterTest() //[TearDown]
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace + ". Message:- " + TestContext.CurrentContext.Result.Message);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    
                    //_test.Fail("Test '" + TestContext.CurrentContext.Test.Name +"' failure ").AddScreenCaptureFromPath("screenshot.jpeg");

                    _test.Fail(TestContext.CurrentContext.Test.Name + " failure screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            
            _extent.Flush();
        }

    }

    public class TestInitializeWithNullValues : ExtentRBase
    {
        [Test]
        public void TestNameNull()
        {
            //Assert.Throws(() => testNameNull());
        }
    }
}
