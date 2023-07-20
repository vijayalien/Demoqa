using Demoqa.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class DemoQA_WidgetsStepDefinitions
    {

        private IWebDriver driver;
        WidgetsPageObject widgetsPageObject;

        public DemoQA_WidgetsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"We navigate to widgets tab")]
        public void WhenWeNavigateToWidgetsTab()
        {
            widgetsPageObject = new WidgetsPageObject(driver);
            widgetsPageObject.clickOnWidgetsTab();
        }

        [When(@"We click on auto complete tab")]
        public void WhenWeClickOnAutoCompleteTab()
        {
            widgetsPageObject.clickOnAutoCompleteTab();
        }

        [When(@"We input multiple color options inside text (.*) and (.*)")]
        public void WhenWeInputMultipleColorOptionsInsideTextWhiteAndBlack(String color1, String color2)
        {
            List<string> colorNamesList = new List<string>
            {color1,color2};

            foreach (string colorName in colorNamesList)
            {
                widgetsPageObject.autoCompleteMultipleColors(colorName);
            }
            
        }

        [When(@"We remove the individual color from the container (.*)")]
        public void WhenWeRemoveTheIndividualColorFromTheContainerWhite(string removeColor)
        {
            widgetsPageObject.removeInputColorFromContainer(removeColor);
        }

        [When(@"We input single color option inside text (.*)")]
        public void WhenWeInputSingleColorOptionInsideTextSingleColor(String singleColor)
        {
            widgetsPageObject.autoCompleteSingleInput(singleColor);
        }

        [Then(@"We validate the single color inside the container (.*)")]
        public void ThenWeValidateTheSingleColorInsideTheContainer(String validateColor)
        {
            widgetsPageObject.validateTheSingleInputContainer(validateColor);
        }

        [When(@"We click on date picker tab")]
        public void WhenWeClickOnDatePickerTab()
        {
            widgetsPageObject.clickOnDatePickerTab();
        }

        [Then(@"We add the number of days to the current date (.*)")]
        public void ThenWeAddTheNumberOfDaysToTheCurrentDate(int p0)
        {
            widgetsPageObject.selectDate(p0);
        }

        [Then(@"We validate the provided date (.*)")]
        public void ThenWeValidateTheProvidedDate(int p0)
        {
            widgetsPageObject.validateInputDate(p0);
        }

        [Then(@"We set the date and time (.*) and (.*)")]
        public void ThenWeSetTheDateAndTimeAnd(int p0, int p1)
        {
            widgetsPageObject.setDateAndTime(p0,p1);
        }

        [Then(@"We validate provided date and time (.*) and (.*)")]
        public void ThenWeValidateProvidedDateAndTimeAnd(int p0, int p1)
        {
            widgetsPageObject.validateInputDateTime(p0,p1);
        }

        [When(@"We click on tooltip tab")]
        public void WhenWeClickOnWidgetsTab()
        {
            widgetsPageObject.clickOnToolTipTab();
        }

        [Then(@"We test the tool tip button")]
        public void ThenWeTestTheToolTipButton()
        {
            widgetsPageObject.toolTipHover();
        }

        [Then(@"We test the tool tip text")]
        public void ThenWeTestTheToolTipText()
        {
           widgetsPageObject.toolTipTextHover();
        }

        [Then(@"We test the tool tip link")]
        public void ThenWeTestTheToolTipLink()
        {
            widgetsPageObject.toolTipLinkHover();
        }



    }
}