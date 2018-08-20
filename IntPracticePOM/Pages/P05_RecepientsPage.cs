using IntPracticePOM.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P05_RecepientsPage
    {
        public P05_RecepientsPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }

        protected IWebElement radio_Recepient   => PrePostTest.sWebDriver.FindElement(By.CssSelector(".RecepientsTable > tbody tr:nth-child(4) td:nth-child(1) > input"));
        protected IWebElement btn_Continue      => PrePostTest.sWebDriver.FindElement(By.Id("SignInDivTwo"));
        protected IWebElement txt_TotalDue      => PrePostTest.sWebDriver.FindElement(By.Id("TotalDue"));
        protected IWebElement txt_AcNumber      => PrePostTest.sWebDriver.FindElement(By.Id("AccountTableBCellSix"));


        public void SelectRecepient(string recepient)
        {
            Synchroniser.ExplicitWait(By.XPath("//*[text() = '" + recepient + "']//preceding::td[1]"));
            PrePostTest.sWebDriver.FindElement(By.XPath("//*[text() = '" + recepient + "']//preceding::td[1]")).Click();
        }

        public P06_DetailsReviewPage ClickContinue()
        {
            Synchroniser.ElementClickable(btn_Continue);

            //Synchroniser.ElementContainsAnyText(txt_AcNumber);
            Synchroniser.ElementContainsAnyText(txt_TotalDue, "£");
            return PageInitialiser.DetailsReviewPage;
        }


    }
}
