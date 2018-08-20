using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM.Pages
{
    public class PageInitialiser
    {
        public static P01_HomePage HomePage { get; set; }
        public static P02_LoginPage LoginPage { get; set; }        
        public static P03_ScenariosPage ScenariosPage { get; set; }
        public static P04_ScenarioAPage ScenarioAPage { get; set; }
        public static P05_RecepientsPage RecepientsPage { get; set; }
        public static P06_DetailsReviewPage DetailsReviewPage { get; set; }
        public static P07_PaymentTypesPage PaymentTypesPage { get; set; }
        public static P08_TransferReceiptPage TransferReceiptPage { get; set; }

        public static void PagePrimer()
        {
            HomePage            = new P01_HomePage(PrePostTest.sWebDriver);
            LoginPage           = new P02_LoginPage(PrePostTest.sWebDriver);
            ScenariosPage       = new P03_ScenariosPage(PrePostTest.sWebDriver);
            ScenarioAPage       = new P04_ScenarioAPage(PrePostTest.sWebDriver);
            RecepientsPage      = new P05_RecepientsPage(PrePostTest.sWebDriver);
            DetailsReviewPage   = new P06_DetailsReviewPage(PrePostTest.sWebDriver);
            PaymentTypesPage    = new P07_PaymentTypesPage(PrePostTest.sWebDriver);
            TransferReceiptPage = new P08_TransferReceiptPage(PrePostTest.sWebDriver);
        }
    }
}
