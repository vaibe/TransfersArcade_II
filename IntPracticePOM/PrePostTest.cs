using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using IntPracticePOM.Pages;
using IntPracticePOM.Reporting;
using IntPracticePOM.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM
{
    [TestFixture]
    public class PrePostTest
    {
        protected internal static IWebDriver sWebDriver;
        static string url       = ConfigurationManager.AppSettings["url"];
        static string browser   = ConfigurationManager.AppSettings["browser"];


        [SetUp]
        public void StartUp()
        {
            PageInitialiser.PagePrimer();

            sWebDriver.Url = url;
            //reports.verifyURL(url); // Verifying the URL
            sWebDriver.Navigate();

            ExtentRBase.BeforeTest();
        }

        [TearDown]
        public void TakeDown()
        {
            sWebDriver.Manage().Cookies.DeleteAllCookies();
            //sWebDriver.Close();

            ExtentRBase.AfterTest();
        }

        public static void StartExecution() 
        {
            switch(browser.ToLower())
            {
                case "ie":
                    sWebDriver = new InternetExplorerDriver();
                    break;
                case "chr":
                    sWebDriver = new ChromeDriver();
                    break;
                case "ff":
                    sWebDriver = new FirefoxDriver();
                    break;
            }

            sWebDriver.Navigate().GoToUrl(url);
            sWebDriver.Manage().Timeouts().ImplicitWait     = TimeSpan.FromSeconds(10);
            sWebDriver.Manage().Timeouts().PageLoad         = TimeSpan.FromSeconds(10);
            sWebDriver.Manage().Window.Maximize();

            ExtentRBase.OneTimeSetup();
        }

        public static void EndExecution()
        {
            ExtentRBase.OneTimeTearDown();

            int passCount = NUnit.Framework.TestContext.CurrentContext.Result.PassCount;
            int failCount = NUnit.Framework.TestContext.CurrentContext.Result.FailCount;

            if (sWebDriver != null)
            {
                sWebDriver.Quit();
            }
        }
    }
}
