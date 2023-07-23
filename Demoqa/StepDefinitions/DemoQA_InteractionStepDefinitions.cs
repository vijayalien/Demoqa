using Demoqa.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demoqa.StepDefinitions
{
    [Binding]
    public sealed class InteractionStepDefinitions
    {

        private IWebDriver driver;
        InteractionPageObject interactionPageObject ;

        public InteractionStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"We navigate to interaction tab")]
        public void GivenWeNavigateToInteractionTab()
        {
            interactionPageObject = new InteractionPageObject(driver);
            interactionPageObject.clickOnInteractionTab();
        }

        [When(@"We click on sortable tab")]
        public void WhenWeClickOnSortableTab()
        {
            interactionPageObject.clickOnSortableTab();
        }

        [Then(@"We sort the list items")]
        public void ThenWeSortTheListItems()
        {
            interactionPageObject.sortListItems();
        }

        [Then(@"We log the values inside list items")]
        public void ThenWeLogTheValuesInsideListItems()
        {
            interactionPageObject.logSortedListItems();
        }

        [When(@"We click on droppable tab")]
        public void WhenWeClickOnDroppableTab()
        {
            interactionPageObject.clickOnDroppableTab();
        }

        [Then(@"We drag and drop the element inside simple tab")]
        public void ThenWeDragAndDropTheElementInsideSimpleTab()
        {
            interactionPageObject.simpleDragAndDrop();
        }

        [Then(@"We click on accept tab")]
        public void ThenWeClickOnAcceptTab()
        {
            interactionPageObject.clickAcceptTabDragAndDrop();
        }

        [Then(@"We drag and drop the element inside accept tab")]
        public void ThenWeDragAndDropTheElementInsideAcceptTab()
        {
            interactionPageObject.acceptDragAndDrop();
        }


    }
}