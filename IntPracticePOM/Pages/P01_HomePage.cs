using IntPracticePOM.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P01_HomePage 
    {
        public P01_HomePage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;            
        }

        protected IWebElement btn_signIn            => PrePostTest.sWebDriver.FindElement(By.Id("SignIn"));
        protected IWebElement select_continue       => PrePostTest.sWebDriver.FindElement(By.Id("FromInpSel"));
        protected IWebElement btn_SignOut           => PrePostTest.sWebDriver.FindElement(By.Id("SignOutText"));
        protected IWebElement gbpCcy                => PrePostTest.sWebDriver.FindElement(By.Id("ccyA"));
        protected IWebElement btn_signOut           => PrePostTest.sWebDriver.FindElement(By.Id("SignOutDiv"));
        protected IWebElement txt_TransferScenario  => PrePostTest.sWebDriver.FindElement(By.XPath("//a[text() = 'Transfer Scenarios']"));


        //test CI
        public void ClickSignIn()
        {
            btn_signIn.Click();
        }

        public void SelectToCountry(string toCountry)
        {
            var selectData = new SelectElement(select_continue);
            selectData.SelectByText(toCountry);
        }

        public string GetSignOutText()
        {
            var signOutText = btn_SignOut.Text;
            return signOutText;
        }

        public string GetCcy()
        {
            var ccy = gbpCcy.Text;
            return ccy;
        }

        public void ClickSignOut()
        {
            btn_signOut.Click();
        }

        public bool DropDownListCheck(string ListItem_1, string ListItem_2, string ListItem_3, int noOfUIOptions)
        {
            bool a_and_b_Checks = false;
            
            //A - Check.
            //1. drop down options expected / for verification
            string[] listToCheck = { ListItem_1, ListItem_2, ListItem_3 };

            //2. get drop down options 
            SelectElement DropDownListData = new SelectElement(select_continue);

            //translate 2. IWebElements into a collection of strings so they can be compared
            IEnumerable<string> actual = DropDownListData.Options.Select(i => i.Text);

            //determines, as bool, if items in 1 and 2 are the same
            var OptionsVerified = listToCheck.All(d => actual.Contains(d));

            //B - Check.
            IList<IWebElement> theOptions = PrePostTest.sWebDriver.FindElements(By.XPath("//select[@id='FromInpSel']/option")).ToList();
            int noOfDOMOptions = theOptions.Count;
            bool optionsEqual = false;

            if (noOfUIOptions == noOfDOMOptions)
            {
                optionsEqual = true;
            }

            if(OptionsVerified == true && optionsEqual == true)
            {
                a_and_b_Checks = true;
            }

            return a_and_b_Checks;
        }

        public void GoToScenariosPage()
        {
            txt_TransferScenario.Click();
        }

        public P02_LoginPage ClickContinue()
        {
            Synchroniser.ExplicitWait(By.XPath("//a[text() = 'Having problems signing in? ']"));
            return PageInitialiser.LoginPage;
        }
    }
}
