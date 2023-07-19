using Demoqa.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class DemoQA_AlertsFramesWindowsStepDefinition
    {

        private IWebDriver driver;
        AlertsFramesWindowsPageObject alertsFramesWindowsPageObj;

        public DemoQA_AlertsFramesWindowsStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"We open the browser and pass URL")]
        public void GivenWeOpenTheBrowserAndPassURL()
        {
            alertsFramesWindowsPageObj = new AlertsFramesWindowsPageObject(driver);
           
        }


        [When(@"We navigate to alert frames and windows tab")]
        public void WhenWeNavigateToAlertFramesAndWindowsTab()
        {
            alertsFramesWindowsPageObj.WaitForPageToLoad();
            alertsFramesWindowsPageObj.clickOnAlertsFramesWindowsTab();

        }

        [When(@"We navigate to alerts tab")]
        public void WhenWeNavigateToAlertsTab()
        {
            alertsFramesWindowsPageObj.clickAlertTab();
        }

        [Then(@"We click on alert button and close the alert popup")]
        public void ThenWeClickOnAlertButtonAndCloseTheAlertPopup()
        {
            alertsFramesWindowsPageObj.clickOnAlertButton();
        }

        [Then(@"We click on delayed alert button and close the alert popup")]
        public void ThenWeClickOnDelayedAlertButtonAndCloseTheAlertPopup()
        {
            alertsFramesWindowsPageObj.clickAndAcceptDelayedAlertButton();
        }

        [Then(@"We click on third alert box and perform confirm action")]
        public void ThenWeClickOnThirdAlertBoxAndPerformConfirmAction()
        {
            alertsFramesWindowsPageObj.clickOnConfirmAlertAndAccept();
        }

        [Then(@"We validate the ok message")]
        public void ThenWeValidateTheOkMessage()
        {
            alertsFramesWindowsPageObj.validateConfirmBoxOkMessage();
        }

        [Then(@"We click on third alert box and perform cancel action")]
        public void ThenWeClickOnThirdAlertBoxAndPerformCancelAction()
        {
            alertsFramesWindowsPageObj.clickOnConfirmAlertAndReject();
        }

        [Then(@"We validate the cancel message")]
        public void ThenWeValidateTheCancelMessage()
        {
            alertsFramesWindowsPageObj.validateConfirmBoxCancelMessage();
        }

        [Then(@"We click on prompt alert box and enter text (.*)")]
        public void ThenWeClickOnPromptAlertBoxAndEnterTextAutomationTest(String promptText)
        {
            alertsFramesWindowsPageObj.clickPromptAlertAndPassText(promptText);
        }

        [Then(@"we validate the prompt alert text (.*)")]
        public void ThenWeValidateThePromptAlertText(String promptMessage)
        {
            alertsFramesWindowsPageObj.validatePromptAlertText(promptMessage);
        }


    }
}