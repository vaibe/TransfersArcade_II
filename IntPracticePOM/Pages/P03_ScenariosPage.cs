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
    public class P03_ScenariosPage
    {
        public P03_ScenariosPage(IWebDriver pDriver)
        {
            pDriver = PrePostTest.sWebDriver;
        }

        protected IWebElement btn_ScenarioAArrow => PrePostTest.sWebDriver.FindElement(By.Id("ScenarioAArrow"));


        public P04_ScenarioAPage GoToScenarioA()
        {
            Synchroniser.ElementClickable(btn_ScenarioAArrow);
            return PageInitialiser.ScenarioAPage;
        }
    }
}
