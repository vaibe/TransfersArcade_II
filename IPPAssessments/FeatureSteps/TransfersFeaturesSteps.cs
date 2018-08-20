using IntPracticePOM;
using IntPracticePOM.Pages;
using IntPracticePOM.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IPPAssessments.FeatureSteps
{
    [Binding]
    public class TransfersFeaturesSteps : PrePostTest
    {
        [Given(@"the user is at the Login page")]
        public void GivenTheUserIsAtTheLoginPage()
        {
            
            //StartUp();
            //Navigation.UrlToHomePage();
            PageInitialiser.HomePage.ClickSignIn();
        }

        [Given(@"the User enters ""(.*)"" as Username")]
        public void GivenTheUserEntersAsUsername(string username)
        {
            PageInitialiser.LoginPage.EnterUsername(username);
        }

        [Given(@"the User enters ""(.*)"" as Password")]
        public void GivenTheUserEntersAsPassword(string password)
        {
            PageInitialiser.LoginPage.EnterPassword(password);
        }

        [When(@"the User clicks Continue")]
        public void WhenTheUserClicksContinue()
        {
            PageInitialiser.LoginPage.ClickContinue();
        }

        [Then(@"the User is navigated to the Home page")]
        public void ThenTheUserIsNavigatedToTheHomePage()
        {
            Assert.AreEqual("Sign Out", PageInitialiser.HomePage.GetSignOutText(), "This is not the Home page");
        }

        [Given(@"the User clicks Continue")]
        public void GivenTheUserClicksContinue()
        {
            PageInitialiser.LoginPage.ClickContinue();
        }

        [When(@"the User select ""(.*)"" as the From country")]
        public void WhenTheUserSelectAsTheFromCountry(string fromCountry)
        {
            PageInitialiser.HomePage.SelectToCountry(fromCountry);
        }

        [Then(@"the Ccy displayed for United Kingdom is ""(.*)""")]
        public void ThenTheCcyDisplayedForUnitedKingdomIs(string fromCountry)
        {
            Assert.AreEqual(fromCountry, PageInitialiser.HomePage.GetCcy(), "Country ccy is incorrect");
        }

        [Given(@"the user is at the Home page")]
        public void GivenTheUserIsAtTheHomePage()
        {
            //Navigation.UrlToHomePage();
        }

        [When(@"the User select ""(.*)"" as the To country")]
        public void WhenTheUserSelectAsTheToCountry(string fromCountry)
        {
            PageInitialiser.HomePage.SelectToCountry(fromCountry);
        }

        [Given(@"the User clicks on the Scenarios page")]
        public void GivenTheUserClicksOnTheScenariosPage()
        {
            PageInitialiser.HomePage.GoToScenariosPage();
        }

        [Given(@"the User navigates to Scenario A page")]
        public void GivenTheUserNavigatesToScenarioAPage()
        {
            PageInitialiser.ScenariosPage.GoToScenarioA();
        }

        
        [Given(@"the User select ""(.*)"" as the From country")]
        public void GivenTheUserSelectAsTheFromCountry(string fromCountry)
        {
            PageInitialiser.ScenarioAPage.SelectToCountry(fromCountry);
        }

        [Given(@"the User enters ""(.*)"" as the amount to send")]
        public void GivenTheUserEntersAsTheAmountToSend(string amountToSend)
        {
            PageInitialiser.ScenarioAPage.EnterAmountToSend(amountToSend);
        }

        [Given(@"the User clicks Proceed")]
        public void GivenTheUserClicksProceed()
        {
            PageInitialiser.ScenarioAPage.ClickProceed();
        }
        
        ////#
        //[Given(@"the User selects a Recepient")]
        //public void GivenTheUserSelectsARecepient()
        //{
        //    PageInitialiser.RecepientsPage.SelectRecepient("Alhaja Kola Tafa");
        //}

        [Given(@"the User selects Recepient ""(.*)""")]
        public void GivenTheUserSelectsRecepient(string recepient)
        {
            PageInitialiser.RecepientsPage.SelectRecepient(recepient);
        }


        [When(@"the User clicks Continue on the Recepients page")]
        public void WhenTheUserClicksContinueOnTheRecepientsPage()
        {
            PageInitialiser.RecepientsPage.ClickContinue();
        }

        [Then(@"the User is navigated to the Details Review page")]
        public void ThenTheUserIsNavigatedToTheDetailsReviewPage()
        {
            Assert.AreEqual("Details Review", PageInitialiser.DetailsReviewPage.GetPageTitle(), "Country ccy is incorrect");
        }

        [Then(@"the amount entered on the Scenarios page is displayed on the Details Review page")]
        public void ThenTheAmountEnteredOnTheScenariosPageIsDisplayedOnTheDetailsReviewPage()
        {
            Assert.AreEqual(PageInitialiser.DetailsReviewPage.GetTransferAmount()
                , P04_ScenarioAPage.amountForSending, "Amount for sending is incorrect");
        }

        [Then(@"the to Country shown on the Scenarios page is displayed on the Details Review page")]
        public void ThenTheToCountryShownOnTheScenariosPageIsDisplayedOnTheDetailsReviewPage()
        {
            Assert.AreEqual(PageInitialiser.DetailsReviewPage.GetToCountry()
                , P04_ScenarioAPage.toCountry, "To country incorrect");
        }

        [Then(@"verify that the Transfer money from drop down list contains the following ""(.*)"" options ""(.*)"", ""(.*)"" and ""(.*)""\.")]
        public void ThenVerifyThatTheTransferMoneyFromDropDownListContainsTheFollowingOptionsAnd_(int noOfOptions, string listItem1, string listItem2, string listItem3)
        {
            Assert.IsTrue(PageInitialiser.HomePage.DropDownListCheck(listItem1, listItem2, listItem3, noOfOptions));
        }

        //SC08
        [Given(@"the User provides (.*) as Username")]
        public void GivenTheUserProvidesAsUsername(string username)
        {
            PageInitialiser.LoginPage.EnterUsername(username);
        }


        [Given(@"the User provides (.*) as Password")]
        public void GivenTheUserProvidesAsPassword(string password)
        {
            PageInitialiser.LoginPage.EnterPassword(password);
        }


        [Given(@"the User selects (.*) as the From country")]
        public void GivenTheUserSelectsAsTheFromCountry(string fromCountry)
        {
            PageInitialiser.ScenarioAPage.SelectToCountry(fromCountry);
        }

        [Given(@"the User provides (.*) as the amount to send")]
        public void GivenTheUserProvidesAsTheAmountToSend(string amountToSend)
        {
            PageInitialiser.ScenarioAPage.EnterAmountToSend(amountToSend);
        }

        [Given(@"the User chooses Recepient (.*)")]
        public void GivenTheUserChoosesRecepient(string recepient)
        {
            PageInitialiser.RecepientsPage.SelectRecepient(recepient);
        }

        [Given(@"the User clicks Continue on the Recepients page")]
        public void GivenTheUserClicksContinueOnTheRecepientsPage()
        {
            PageInitialiser.RecepientsPage.ClickContinue();
        }

        [Given(@"the User clicks Continue on the Details Review page")]
        public void GivenTheUserClicksContinueOnTheDetailsReviewPage()
        {
            PageInitialiser.DetailsReviewPage.ClickContinue();
        }

        [When(@"the User clicks Pay with credit on the Payment Types page")]
        public void WhenTheUserClicksPayWithCreditOnThePaymentTypesPage()
        {
            PageInitialiser.PaymentTypesPage.PayWithCredit();
        }

        [Then(@"Transaction Complete is displayed on the Transfer Receipt page")]
        public void ThenTransactionCompleteIsDisplayedOnTheTransferReceiptPage()
        {
            Assert.AreEqual("Transaction complete"
                , PageInitialiser.TransferReceiptPage.GetTranferCompleteMsg()
                , "Transaction incomplete");
        }





    }
}
