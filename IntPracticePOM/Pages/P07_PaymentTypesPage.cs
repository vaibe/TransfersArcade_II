using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P07_PaymentTypesPage
    {
        public P07_PaymentTypesPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }

        protected IWebElement payWithCredit => PrePostTest.sWebDriver.FindElement(By.Id("PayWithCredit"));


        public void PayWithCredit()
        {
            payWithCredit.Click();
        }
    }
}
