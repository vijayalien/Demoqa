using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.ObjectModel;
using AventStack.ExtentReports.Gherkin.Model;
using FluentAssertions;
using MongoDB.Driver.Core.Misc;
using System.Buffers.Text;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace Demoqa.PageObjects
{
    public class InteractionPageObject : BasePageObject
    {

        public InteractionPageObject(IWebDriver driver) : base(driver)
        {
            
        }

        //Sortable
        By interactionTab = By.XPath("(//div[@class='card-up'])[5]");
        By mainPageHeader = By.XPath("//div[@class='main-header']");
        By sortableTab = By.XPath("(//li[@class='btn btn-light '])[25]");
        By sortableListItems = By.CssSelector(".vertical-list-container >*");


        //Droppable
        By dropabbleTab = By.XPath("(//li[@class='btn btn-light '])[28]");
        By simpleDraggable = By.Id("draggable");
        By simpleDroppable = By.Id("droppable");
        By acceptDragAndDropTab = By.XPath("//a[@id='droppableExample-tab-accept']");
        By acceptDraggable = By.Id("acceptable");
        By acceptDroppable = By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']");





        public void clickOnInteractionTab()
        {
            WaitForPageToLoad();
            scrollIntoViewAndClick(interactionTab);
        }
       
        public void validateEleTitle()
        {
            validateElementTitle(mainPageHeader);
        }

        public void clickOnSortableTab()
        {
            validateEleTitle();
            scrollIntoViewAndClick(sortableTab);
        }

        public void clickOnDroppableTab() {
            validateEleTitle();
            scrollIntoViewAndClick(dropabbleTab);
        }


        public void sortListItems()
        {
           
            var listElements = driver.FindElements(sortableListItems);
            var mapping = new Dictionary<string, int>
            {
                {"One", 1},
                {"Two", 2},
                {"Three", 3},
                {"Four", 4},
                {"Five", 5},
                {"Six", 6}
            };
            var sortedElements = listElements.OrderByDescending(element => mapping[element.Text]).ToList();

            var actions = new Actions(driver);
            var topElement = sortedElements.FirstOrDefault();
            foreach (var element in sortedElements.Skip(1))
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                actions.ClickAndHold(element).MoveToElement(topElement).Release().Perform();
            }

        }

        public void logSortedListItems()
        {
            var listElements = driver.FindElements(sortableListItems);

            foreach (var element in listElements)
            {
                Console.WriteLine(element.Text);
            }
        }

        public void simpleDragAndDrop()
        {
            var draggableElement = driver.FindElement(simpleDraggable);
            var droppableElement = driver.FindElement(simpleDroppable);

            scrollIntoView(simpleDraggable);
            var actions = new Actions(driver);
            Thread.Sleep(3000);
            actions.DragAndDrop(draggableElement, droppableElement).Perform();

            Thread.Sleep(3000);
            var dropResult = droppableElement.Text;
            Console.WriteLine($"Dropped text: {dropResult}");
            Assert.IsTrue(dropResult.Equals("Dropped!"));
        }

        public void clickAcceptTabDragAndDrop()
        {
            scrollIntoViewAndClick(acceptDragAndDropTab);

        }

        public void acceptDragAndDrop()
        {
          
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var draggableElement = driver.FindElement(acceptDraggable);
            var droppableElement = driver.FindElement(acceptDroppable);

            scrollIntoView(acceptDraggable);
            var actions = new Actions(driver);
            Thread.Sleep(3000);
            actions.DragAndDrop(draggableElement, droppableElement).Perform();
            
            Thread.Sleep(4000);
            var dropResult = droppableElement.Text;
            Console.WriteLine($"Dropped text: {dropResult}");
            Assert.IsTrue(dropResult.Equals("Dropped!"));
        }

      
    }
}
