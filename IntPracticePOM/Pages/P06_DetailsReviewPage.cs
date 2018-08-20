using IntPracticePOM.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P06_DetailsReviewPage
    {
        public P06_DetailsReviewPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;

            //Synchroniser.WaitForAjax_I();
        }

        protected IWebElement pageTitle             => PrePostTest.sWebDriver.FindElement(By.Id("TransferDetailsTitle"));
        protected IWebElement txt_TotalDue          => PrePostTest.sWebDriver.FindElement(By.Id("TotalDue"));
        protected IWebElement txt_AmountToBeSent    => PrePostTest.sWebDriver.FindElement(By.Id("TransferAmount"));
        protected IWebElement txt_ToCountry         => PrePostTest.sWebDriver.FindElement(By.Id("ToCountry"));
        protected IWebElement sendMoney             => PrePostTest.sWebDriver.FindElement(By.Id("SendMoney"));

        Regex forReplacement = new Regex("[.,£]");

        public string GetPageTitle()
        {
            Synchroniser.ElementContainsAnyText(pageTitle);
            return pageTitle.Text;
        }        

        public string GetTransferAmount()
        {
            //Synchroniser.WaitForAjax_I();
            //Synchroniser.WaitForAjax_II();
            //Synchroniser.WaitForAjax_III(PrePostTest.sWebDriver);
            //Synchroniser.WaitForAjax(PrePostTest.sWebDriver);
            //Synchroniser.ExplicitWait(By.Id("TransferAmount"));
            Thread.Sleep(1500);
            string replacement = forReplacement.Replace(txt_AmountToBeSent.Text, "");
            string theText     = replacement.Substring(0, replacement.Length - 2);

            return theText;
        }

        public string GetToCountry()
        {
            Synchroniser.ElementContainsAnyText(txt_ToCountry);
            return txt_ToCountry.Text;
        }

        public void ClickContinue()
        {
            ScreenMovements.MoveToElement(sendMoney);
            sendMoney.Click();
        }

    }
}
