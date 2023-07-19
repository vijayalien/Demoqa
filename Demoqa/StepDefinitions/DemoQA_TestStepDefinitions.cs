using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class DemoQA_TestStepDefinitions
    {

        private IWebDriver driver;

        public DemoQA_TestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open the brwoser")]
        public void GivenOpenTheBrwoser()
        {
           

        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [Then(@"Validate the title")]
        public void ThenValidateTheTitle()
        {
            Assert.True(driver.FindElement(By.XPath("//a[@href='https://demoqa.com']")).Displayed);
        }

    }
}