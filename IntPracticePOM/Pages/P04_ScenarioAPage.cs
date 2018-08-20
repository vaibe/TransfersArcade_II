using IntPracticePOM.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P04_ScenarioAPage
    {
        public P04_ScenarioAPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }

        protected IWebElement sel_FromCountry   => PrePostTest.sWebDriver.FindElement(By.Id("FromInpSel"));
        protected IWebElement inp_AmountToSend  => PrePostTest.sWebDriver.FindElement(By.Id("TransferAmount"));
        protected IWebElement btn_Proceed       => PrePostTest.sWebDriver.FindElement(By.Id("TransferText"));
        protected IWebElement table_Recepient   => PrePostTest.sWebDriver.FindElement(By.CssSelector(".RecepientsTable > tbody tr:nth-child(2) td:nth-child(2)"));
        protected IWebElement txt_ToCountry     => PrePostTest.sWebDriver.FindElement(By.Id("toCountryText"));


        public static string amountForSending { get; set; }

        public static string toCountry { get; set; }

        public void SelectToCountry(string toCountry)
        {
            Synchroniser.ElementVisible("#FromInpSel");

            var textToSelect = new SelectElement(sel_FromCountry);
            textToSelect.SelectByText(toCountry);
        }

        public void getToCountry()
        {
            toCountry = txt_ToCountry.Text;
        }

        public void EnterAmountToSend(string amountToSend)
        {
            //Synchroniser.ElementVisible("#TransferAmount");
            Synchroniser.ExplicitWait(By.CssSelector("#TransferAmount"));
            //for the object above 'amountForSending'
            amountForSending = amountToSend;
            inp_AmountToSend.SendKeys(amountToSend);

            getToCountry();
        }

        public P05_RecepientsPage ClickProceed()
        {
            btn_Proceed.Click();
            //Synchroniser.ElementContainsAnyText(table_Recepient);
            return PageInitialiser.RecepientsPage;
        }
    }
}
