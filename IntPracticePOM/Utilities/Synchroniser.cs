using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntPracticePOM.Utilities
{
    public static class Synchroniser
    {
        public static void ElementClickable(IWebElement locator)
        {
            IWebElement element = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(locator));

            locator.Click();
        }

        public static void ElementVisible(string CssSelector)
        {
            WebDriverWait wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CssSelector)));
        }

        public static void ElementContainsText(string locator, string theText)
        {
            var wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName(locator)).Text.Contains(theText));
        }

        public static void ElementContainsAnyText(IWebElement locator, string anyText = "a")
        {
            WebDriverWait wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(locator, anyText));
        }


        public static void WaitForAjax_I()
        {
            WebDriverWait wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
        }

        public static void WaitForAjax_II()
        {
            WebDriverWait wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor jsScript = PrePostTest.sWebDriver as IJavaScriptExecutor;
            wait.Until((d) => (bool)jsScript.ExecuteScript("return jQuery.active == 0"));
        }

        public static void WaitForAjax_III(this IWebDriver driver, int timeoutSecs = 15, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }

            if (throwException)
            {
                throw new Exception("WebDriver timed out");
            }
        }

        //WebDriverWait replacement
        public static void ExplicitWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(PrePostTest.sWebDriver, TimeSpan.FromSeconds(15));
            IWebElement element = wait.Until((d) =>
            {
                return d.FindElement(locator);
            });
        }
        


    }
}
