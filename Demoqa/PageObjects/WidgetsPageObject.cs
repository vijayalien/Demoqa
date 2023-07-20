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

namespace Demoqa.PageObjects
{
    public class WidgetsPageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public WidgetsPageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Auto Complete
        By widgetsTab = By.XPath("(//div[@class='card-up'])[4]");
        By mainPageHeader = By.XPath("//div[@class='main-header']");
        By autoCompleteTab = By.XPath("(//li[@class='btn btn-light '])[17]");
        By multipleColorNamesInput = By.Id("autoCompleteMultipleInput");
        By autoCompleteMultipleContainer = By.Id("autoCompleteMultipleContainer");
        By singleContainerColorInput = By.Id("autoCompleteSingleInput");
        By autoCompleteSingoleContainer = By.Id("autoCompleteSingleContainer");


        //Date Picker
        By datePickerTab = By.XPath("(//li[@class='btn btn-light '])[18]");
        By datePickerInput = By.Id("datePickerMonthYearInput");
        By dateTimePickerInput = By.Id("dateAndTimePickerInput");

        //ToolTip
        By toolTipTab = By.XPath("(//li[@class='btn btn-light '])[22]");
        By toolTipButton = By.Id("toolTipButton");
        By tootlTipText = By.Id("toolTipTextField");
        By toolTipLink = By.LinkText("Contrary"); 


        public void clickOnWidgetsTab()
        {
            WaitForPageToLoad();
            scrollIntoViewAndClick(widgetsTab);
        }
        public void WaitForPageToLoad()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void validateElementTitle()
        {
            WaitForPageToLoad();
            wait.Until(driver =>
            {
                try
                {
                    IWebElement element = driver.FindElement(mainPageHeader);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

        }

        public void scrollIntoViewAndClick(By element)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }

        public void scrollIntoView(By element)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
        }

        public void scrollIntoViewAndInput(By element,String input)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.SendKeys(input);
        }

        public void clickOnAutoCompleteTab()
        {
            scrollIntoViewAndClick(autoCompleteTab);
        }

        public void clickOnToolTipTab()
        {
            scrollIntoViewAndClick(toolTipTab);
        }

        public void clickOnDatePickerTab()
        {
            scrollIntoViewAndClick(datePickerTab);
        }

        public void autoCompleteMultipleColors(String inputColorNames)
        {

            IWebElement autoCompleteInput = driver.FindElement(multipleColorNamesInput);
            IWebElement autoCompleteMultipleBox = driver.FindElement(autoCompleteMultipleContainer);

            autoCompleteInput.SendKeys(inputColorNames);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                try
                {
                    autoCompleteInput.SendKeys(Keys.Enter);
                    return autoCompleteMultipleBox.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            Assert.IsTrue(autoCompleteMultipleBox.Text.ToLower().Contains(inputColorNames.ToLower()), "The provided color is not available");
        }

        public void removeInputColorFromContainer(String colorName)
        {
            string capitalizedColorName = char.ToUpper(colorName[0]) + colorName.Substring(1);
            IWebElement elementToRemove = driver.FindElement(By.XPath("//div[contains(@class, 'auto-complete__multi-value__label') and text()='"+ capitalizedColorName+"']"));

            IWebElement removeButton = elementToRemove.FindElement(By.XPath("./following-sibling::div[contains(@class, 'auto-complete__multi-value__remove')]"));
            removeButton.Click();

            IReadOnlyCollection<IWebElement> remainingValues = driver.FindElements(By.XPath("//div[contains(@class, 'auto-complete__multi-value__label')]"));
            foreach (IWebElement value in remainingValues)
            {
                if(value.Text == capitalizedColorName)
                {
                    Assert.Fail("The provided color is still present");
                }
                                   
                //Assert.Pass("The provided color is removed from the container");
                Console.WriteLine("Remaining Value: " + value.Text);
               
            }


        }

        public void autoCompleteSingleInput(String colorName)
        {
            IWebElement singleColorInput = driver.FindElement(singleContainerColorInput);

            scrollIntoViewAndInput(singleContainerColorInput, colorName);
            Thread.Sleep(3000);
            singleColorInput.SendKeys(Keys.Enter);
        }

        public void validateTheSingleInputContainer(String inputColor)
        {
            Thread.Sleep(3000);
            string capitalizedColorName = char.ToUpper(inputColor[0]) + inputColor.Substring(1);
            scrollIntoView(autoCompleteSingoleContainer);
            String text = driver.FindElement(autoCompleteSingoleContainer).Text;


            if (text.Contains(capitalizedColorName))
            {
                Assert.Pass("The provided color is available");
            }
            else
            {
                Assert.Fail("The provided color is not available");
            }

        }

        public string addDaysToCurrentDate(int daysToAdd)
        {
            DateTime today = DateTime.Today;
            string todayDate = today.ToString("MM/dd/yyyy");

            Console.WriteLine("Today's Date: " + todayDate);
            DateTime futureDate = today.AddDays(daysToAdd);
            string futureDateFormatted = futureDate.ToString("MM/dd/yyyy");

            Console.WriteLine("Future Date: " + futureDateFormatted);
            return futureDateFormatted;
        }

        public String addDateAndTimeToCurrentDate(int days, int hours)
        {
            DateTime currentDate = DateTime.Now;
            DateTime futureDate = currentDate.AddDays(days);
            TimeSpan futureTime = new TimeSpan(hours, 15, 0);
            DateTime futureDateTime = futureDate.Date + futureTime;
            string formattedFutureDateTime = futureDateTime.ToString("MMMM dd, yyyy hh:mm tt");
            Console.WriteLine("Future Date and Time: " + formattedFutureDateTime);
            return formattedFutureDateTime;

        }

        public void selectDate(int daysToAdd)
        {
            String futureDate = addDaysToCurrentDate(daysToAdd);
            driver.FindElement(datePickerInput).Clear();
            scrollIntoView(datePickerInput);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].value = arguments[1];",driver.FindElement(datePickerInput), futureDate);
            
        }

        public void validateInputDate(int inputDate)
        {
            String futureDate = addDaysToCurrentDate(inputDate);
            Assert.IsTrue(driver.FindElement(datePickerInput).GetAttribute("value").Contains(futureDate));
        }

        public void setDateAndTime(int days,int hours)
        {   
            IWebElement dateTimeInput= driver.FindElement(dateTimePickerInput);
            String futureDate = addDateAndTimeToCurrentDate(days,hours);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].value = arguments[1];", dateTimeInput, futureDate);

        }

        public void validateInputDateTime(int days, int hours)
        {
            String futureDate = addDateAndTimeToCurrentDate(days, hours);
            Assert.IsTrue(driver.FindElement(dateTimePickerInput).GetAttribute("value").Contains(futureDate));
        }

        public void toolTipMouseHover(By element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(element)).Perform();
            Thread.Sleep(2000);
        }

        public void toolTipHover()
        {
            toolTipMouseHover(toolTipButton);
        }

        public void toolTipTextHover()
        {

            toolTipMouseHover(tootlTipText);
        }

        public void toolTipLinkHover()
        {
            toolTipMouseHover(toolTipLink);
        }

    }
}
