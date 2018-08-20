using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Utilities
{
    public class ScreenMovements
    {
        //protected IWebElement => 

        public static void MoveToElement(IWebElement locator)
        {
            Actions action = new Actions(PrePostTest.sWebDriver);
            action.MoveToElement(locator);
        }

    }
}
