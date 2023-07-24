using Demoqa.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class DemoQA_BookStoreApplicationStepDefinitions
    {

        private IWebDriver driver;
        BookStorePageObject bookStorePageObject ;

        public DemoQA_BookStoreApplicationStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"We navigate to book store application tab")]
        public void GivenWeNavigateToBookStoreApplicationTab()
        {
            bookStorePageObject = new BookStorePageObject(driver);
            bookStorePageObject.clickOnBookStoreApplication();
        }

        [When(@"We click on login tab")]
        public void WhenWeClickOnLoginTab()
        {
            bookStorePageObject.clickOnLoginTab();
        }

        [Then(@"We click on new user button")]
        public void ThenWeClickOnNewUserButton()
        {
            bookStorePageObject.clickOnNewUser();
        }

        [Then(@"We pass the (.*) (.*) (.*) and (.*)")]
        public void ThenWePassTheVjtestTestautomationVjtestAndTest(string firstname, string lastname, string username, string password)
        {
            bookStorePageObject.registerNewUserDetails(firstname, lastname, username, password);
        }

        [Then(@"We click on back to login")]
        public void ThenWeClickOnBackToLogin()
        {
            bookStorePageObject.clickBackToLogin();
        }

        [Then(@"We accept user created successfull alert")]
        public void ThenWeAcceptUserCreatedSuccessfullAlert()
        {
            bookStorePageObject.acceptUserCreatedAlert();
        }

        [Then(@"We login into the book store with (.*) and (.*)")]
        public void ThenWeLoginIntoTheBookStoreWithVjtestAndTest(String p0, String p1)
        {
            bookStorePageObject.loginUsingExistingUser(p0, p1);
        }

        [Then(@"We validate the login (.*)")]
        public void ThenWeValidateTheLoginVjtest(String p0)
        {
            bookStorePageObject.validateLoginCreds(p0);
        }


    }
}