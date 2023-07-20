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

        [When(@"We navigate to browser window tab")]
        public void WhenWeNavigateToBrowserWindowTab()
        {
            alertsFramesWindowsPageObj.clickBrowserWindowTab();
        }

        [When(@"We click on new tab button")]
        public void WhenWeClickOnNewTabButton()
        {
            alertsFramesWindowsPageObj.clickOnNewTabButton();
        }

        [When(@"We switch to new tab")]
        public void WhenWeSwitchToNewTab()
        {
            alertsFramesWindowsPageObj.switchToNewTab();
        }

        [Then(@"We validate the new tab url and message")]
        public void ThenWeValidateTheNewTabTitleAndMessage()
        {
            alertsFramesWindowsPageObj.validateNewTabTitle();
        }


        [Then(@"We close the new tab and switch back to original tab")]
        public void ThenWeCloseTheNewTabAndSwitchBackToOriginalTab()
        {
            alertsFramesWindowsPageObj.closeNewTabAndSwitchToOriginal();
        }

        [Then(@"We click on new window button")]
        public void ThenWeClickOnNewWindowButton()
        {
            alertsFramesWindowsPageObj.clickOnNewWindowButton();
        }

        [Then(@"We validate the new window message")]
        public void ThenWeValidateTheNewWindowMessage()
        {
            alertsFramesWindowsPageObj.switchToNewWIndow();
            alertsFramesWindowsPageObj.validateNewTabTitle();
           
        }

        [Then(@"We close the new window and switch back to original window")]
        public void ThenWeCloseTheNewWindowAndSwitchBackToOriginalWindow()
        {
            alertsFramesWindowsPageObj.closeNewWindow();
        }

        [Then(@"We click on message window button")]
        public void ThenWeClickOnMessageWindowButton()
        {
            alertsFramesWindowsPageObj.clickOnMessageWindowButton();
        }

        [Then(@"We validate the message window message")]
        public void ThenWeValidateTheMessageWindowMessage()
        {
            alertsFramesWindowsPageObj.switchToMessageWindow();
            alertsFramesWindowsPageObj.validateMessageWindow();

        }

        [Then(@"We close the message window and switch back to original window")]
        public void ThenWeCloseTheMessageWindowAndSwitchBackToOriginalWindow()
        {
            alertsFramesWindowsPageObj.closeNewWindow();
        }



    }
}