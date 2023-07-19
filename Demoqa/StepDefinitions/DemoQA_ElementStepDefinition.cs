using Demoqa.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class DemoQA_ElementStepDefinition
    {
        private IWebDriver driver;
        ElementsPageObject elementsPOJ;

        public DemoQA_ElementStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"We open the browser and pass the URL")]
        public void GivenWeOpenTheBrowserAndPassTheURL()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [When(@"We navigate to Elements tab")]
        public void WhenWeNavigateToElementsTab()
        {
            elementsPOJ = new ElementsPageObject(driver);
            elementsPOJ.WaitForPageToLoad();
            elementsPOJ.clickOnElementsTab();
        }

        [When(@"We navigate to text box tab inside elements")]
        public void WhenWeNavigateToTextBoxTabInsideElements()
        {
            elementsPOJ.clickTextBox();
        }

        [Then(@"We pass value to text box form")]
        public void ThenWePassValueToTextBoxForm()
        {
            elementsPOJ.fillTextBox();
        }

        [Then(@"We click on submit button")]
        public void ThenWeClickOnSubmitButton()
        {
            elementsPOJ.clickOnSubmit();
        }

        [Then(@"We validate results of text box")]
        public void ThenWeValidateResultsOfTextBox()
        {
            elementsPOJ.ValidateResultOutput();
        }

        [When(@"We navigate to chekbox tab inside elements")]
        public void WhenWeNavigateToChekboxTabInsideElements()
        {
            elementsPOJ.clickCheckBox();
        }

        [Then(@"We click on home checkbox")]
        public void ThenWeClickOnHomeCheckbox()
        {
            elementsPOJ.selectHomeCheckBox();
        }

        [Then(@"We validate results of checkbox box")]
        public void ThenWeValidateResultsOfCheckboxBox()
        {
            elementsPOJ.validateCheckBoxResults();
        }


        [When(@"We navigate to webtable tab inside elements")]
        public void WhenWeNavigateToWebtableTabInsideElements()
        {
           elementsPOJ.clickWebTables();
        }

        [Then(@"We log the values inside the table")]
        public void ThenWeLogTheValuesInsideTheTable()
        {
            elementsPOJ.logWebTableValues();
        }

        [Then(@"We edit value ""([^""]*)"" with ""([^""]*)""")]
        public void ThenWeEditValueWith(string tableValue, string newValue)
        {
           elementsPOJ.EditWebTableValues(tableValue, newValue);
        }

        [When(@"We navigate to buttons tab inside elements")]
        public void WhenWeNavigateToButtonsTabInsideElements()
        {
            elementsPOJ.clickButtons();
        }

        [When(@"We click double click button")]
        public void WhenWeClickDoubleClickButton()
        {
            elementsPOJ.doubleClickButton();
        }

        [Then(@"We validate the double click message")]
        public void ThenWeValidateTheDoubleClickMessage()
        {
            elementsPOJ.validateDoubleClickMessage();
        }

        [Then(@"We click right click button")]
        public void ThenWeClickRightClickButton()
        {
            elementsPOJ.rightClickButton();
        }

        [Then(@"We validate the right click message")]
        public void ThenWeValidateTheRightClickMessage()
        {
            elementsPOJ.validateRightClickMessage();
        }

        [Then(@"We click dynamic click button")]
        public void ThenWeClickDynamicClickButton()
        {
            elementsPOJ.dynamicClickButton();
        }

        [Then(@"We validate the dynamic click message")]
        public void ThenWeValidateTheDynamicClickMessage()
        {
            elementsPOJ.validateDynamicClickMessage();
        }

        [When(@"We navigate to upload and download tab inside element")]
        public void WhenWeNavigateToUploadAndDownloadTabInsideElement()
        {
            elementsPOJ.clickUploadDownloadTab();
        }

        [When(@"We click on download button")]
        public void WhenWeClickOnDownloadButton()
        {
            elementsPOJ.clickOnDownloadButton();
        }

        [Then(@"We upload a sample file")]
        public void ThenWeUploadASampleFile()
        {
            elementsPOJ.uploadSampleFile();
        }

        [Then(@"We validate the file path location")]
        public void ThenWeValidateTheFilePathLocation()
        {
            elementsPOJ.validatePathLocation();
        }

    }
}