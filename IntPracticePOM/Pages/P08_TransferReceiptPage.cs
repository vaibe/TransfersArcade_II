using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P08_TransferReceiptPage
    {
        public P08_TransferReceiptPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }

        protected IWebElement transferReceipt => PrePostTest.sWebDriver.FindElement(By.Id("TransactionComplete"));


        public string GetTranferCompleteMsg()
        {
            var msg = transferReceipt.Text;
            return msg;
        }

    }
}
