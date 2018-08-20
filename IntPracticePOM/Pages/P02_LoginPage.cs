using IntPracticePOM.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class P02_LoginPage
    {
        public P02_LoginPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }
        
        protected IWebElement input_username        => PrePostTest.sWebDriver.FindElement(By.Id("UserNameInput"));
        protected IWebElement input_userpassword    => PrePostTest.sWebDriver.FindElement(By.Id("PasswordInput"));
        protected IWebElement btn_continue          => PrePostTest.sWebDriver.FindElement(By.Id("LoginButtonDiv"));

        public void EnterUsername(string username)
        {
            input_username.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            input_userpassword.SendKeys(password);
        }

        public P01_HomePage ClickContinue()
        {
            Synchroniser.ElementClickable(btn_continue);
            Synchroniser.ExplicitWait(By.XPath("//div[contains(text(), ':')]"));
            return PageInitialiser.HomePage;
        }

        

        
    }
}
