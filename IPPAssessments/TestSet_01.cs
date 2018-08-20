using IntPracticePOM.Pages;
using IntPracticePOM.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntPracticePOM
{
    public class TestSet_01 : PrePostTest
    {
        [Category ("TrArcTests")]
        [Test]
        public void T01_VerifyLogin()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();

            Assert.AreEqual("Sign Out", PageInitialiser.HomePage.GetSignOutText(), "This is not the Home page");
        }

        [Category("TrArcTests")]
        [Test]
        public void T02_VerifyCcyViaLogin()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();
            PageInitialiser.HomePage.SelectToCountry("United Kingdom");

            Assert.AreEqual("GBP - United Kingdom Pound", PageInitialiser.HomePage.GetCcy(), "Country ccy is incorrect");
        }

        [Category("TrArcTests")]
        [Test]
        public void T03_VerifyCcyViaHome()
        {
            PageInitialiser.HomePage.SelectToCountry("United Kingdom");

            Assert.AreEqual("GBP - United Kingdom Pound", PageInitialiser.HomePage.GetCcy(), "Country ccy is incorrect");
        }

        [Category("TrArcTests")]
        [Test]
        public void T04_VerifyDetailsReviewPage()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();
            PageInitialiser.HomePage.GoToScenariosPage();
            PageInitialiser.ScenariosPage.GoToScenarioA();
            PageInitialiser.ScenarioAPage.SelectToCountry("United Kingdom");
            PageInitialiser.ScenarioAPage.EnterAmountToSend("1250");
            PageInitialiser.ScenarioAPage.ClickProceed();
            PageInitialiser.RecepientsPage.SelectRecepient("Miss Lamide Akinwumi");
            PageInitialiser.RecepientsPage.ClickContinue();

            Assert.AreEqual("Details Review", PageInitialiser.DetailsReviewPage.GetPageTitle(), "Country ccy is incorrect");
        }

        [Category("TrArcTests")]
        [Test]
        public void T05_VerifyAmountForSending()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();
            PageInitialiser.HomePage.GoToScenariosPage();
            PageInitialiser.ScenariosPage.GoToScenarioA();
            PageInitialiser.ScenarioAPage.SelectToCountry("United Kingdom");
            PageInitialiser.ScenarioAPage.EnterAmountToSend("1250");
            PageInitialiser.ScenarioAPage.ClickProceed();
            PageInitialiser.RecepientsPage.SelectRecepient("Alhaja Kola Tafa");
            PageInitialiser.RecepientsPage.ClickContinue();

            Assert.AreEqual(P04_ScenarioAPage.amountForSending
                , PageInitialiser.DetailsReviewPage.GetTransferAmount(), "Amount for sending is incorrect");
        }

        [Category("TrArcTests")]
        [Test]
        public void T06_VerifyToCountry()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();
            PageInitialiser.HomePage.GoToScenariosPage();
            PageInitialiser.ScenariosPage.GoToScenarioA();
            PageInitialiser.ScenarioAPage.SelectToCountry("United Kingdom");
            PageInitialiser.ScenarioAPage.EnterAmountToSend("1250");
            PageInitialiser.ScenarioAPage.ClickProceed();
            PageInitialiser.RecepientsPage.SelectRecepient("Mr Victor Abegunde");
            PageInitialiser.RecepientsPage.ClickContinue();

            Assert.AreEqual(PageInitialiser.DetailsReviewPage.GetToCountry()
                , P04_ScenarioAPage.toCountry, "To country incorrect");
        }

        [Category("TrArcTests")]
        [Test]
        public void T07_VerifyDropDownOptions()
        {
            PageInitialiser.HomePage.DropDownListCheck("Select country", "Nigeria", "United Kingdom", 3);

            Assert.IsTrue(PageInitialiser.HomePage.DropDownListCheck("Select country", "Nigeria", "United Kingdom", 3));
        }

        [Category("TrArcTests")]
        [Test]
        public void T08_CompleteTransaction()
        {
            PageInitialiser.HomePage.ClickSignIn();
            PageInitialiser.LoginPage.EnterUsername("felab@gmail.com");
            PageInitialiser.LoginPage.EnterPassword("55555");
            PageInitialiser.LoginPage.ClickContinue();
            PageInitialiser.HomePage.GoToScenariosPage();
            PageInitialiser.ScenariosPage.GoToScenarioA();
            PageInitialiser.ScenarioAPage.SelectToCountry("United Kingdom");
            PageInitialiser.ScenarioAPage.EnterAmountToSend("10");
            PageInitialiser.ScenarioAPage.ClickProceed();
            PageInitialiser.RecepientsPage.SelectRecepient("Mr Victor Abegunde");
            PageInitialiser.RecepientsPage.ClickContinue();
            PageInitialiser.DetailsReviewPage.ClickContinue();
            PageInitialiser.PaymentTypesPage.PayWithCredit();
            PageInitialiser.TransferReceiptPage.GetTranferCompleteMsg();

            Assert.AreEqual("Transaction complete", PageInitialiser.TransferReceiptPage.GetTranferCompleteMsg(), "Transfer not successful");
        }
    }

}
