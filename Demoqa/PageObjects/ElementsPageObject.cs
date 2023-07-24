using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoqa.PageObjects
{
    public class ElementsPageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ElementsPageObject(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        By searchTextbox = By.XPath("(//div[@class='card-up'])[1]");
        By elementsHeader = By.XPath("//div[@class='main-header']");
        By textBox = By.XPath("(//li[@class='btn btn-light '])[1]");
        //Text Box Form xpaths
        By fullName = By.XPath("//input[@id='userName']");
        By email = By.XPath("//input[@id='userEmail']");
        By currentAddress = By.XPath("//textarea[@id='currentAddress']");
        By permanentAddress = By.XPath("//textarea[@id='permanentAddress']");
        By submitButton = By.XPath("//button[@id='submit']");
        By validateResults = By.XPath("//div[@id='output']");

        //Check Box
        By checkBox = By.XPath("(//li[@class='btn btn-light '])[2]");
        By homeCheckBox = By.XPath("//span[@class='rct-checkbox']");
        By checkBoxResults = By.XPath("//div[@id='result']");

        //WebTables
        By webTables = By.XPath("(//li[@class='btn btn-light '])[4]");
        By webTableRow = By.CssSelector(".rt-tr-group .rt-tr");
        By WebTableCells = By.CssSelector(".rt-td");
        By webTableSubmitButton = By.CssSelector("#submit");


        //Buttons
        By buttons = By.XPath("(//li[@class='btn btn-light '])[5]");
        By doubleClick = By.CssSelector("#doubleClickBtn");
        By rightClick = By.CssSelector("#rightClickBtn");
        By singleClick = By.XPath("(//button[@class='btn btn-primary'])[3]");
        By doubleClickMessage = By.Id("doubleClickMessage");
        By rightClickMessage = By.Id("rightClickMessage");
        By dynamicClickMessage = By.Id("dynamicClickMessage");

        //Upload & Download 
        By uploadDownloadTab = By.XPath("(//li[@class='btn btn-light '])[8]");
        By downloadButton = By.Id("downloadButton");
        By uploadButton = By.Id("uploadFile");
        By filePath = By.Id("uploadedFilePath");


        public void clickOnElementsTab()
        {
            Thread.Sleep(10000);
            driver.FindElement(searchTextbox).Click();
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
                    IWebElement element = driver.FindElement(elementsHeader);
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
        public void clickCheckBox()
        {
            validateElementTitle();

            driver.FindElement(checkBox).Click();

        }

        public void clickTextBox()
        {
            validateElementTitle();

            driver.FindElement(textBox).Click();
        }

        public void clickWebTables()
        {
            validateElementTitle();
            driver.FindElement(webTables).Click();
        }

        public void scrollIntoView(By element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void clickButtons()
        {
            validateElementTitle();
            
            IWebElement buttonTab = driver.FindElement(buttons);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", buttonTab);

            buttonTab.Click();

        }

        public void clickUploadDownloadTab()
        {
            validateElementTitle();

            IWebElement uploadDownTab = driver.FindElement(uploadDownloadTab);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", uploadDownTab);

            uploadDownTab.Click();

        }

        public void fillTextBox()
        {
           
            driver.FindElement(fullName).SendKeys("Testing");
            driver.FindElement(email).SendKeys("Automation@test.com");
            driver.FindElement(currentAddress).SendKeys("Melbourne");
            driver.FindElement(permanentAddress).SendKeys("Melbourne City");

        }

        public void clickOnSubmit()
        {
            By buttonLocator = By.Id("submit");
            IWebElement button = driver.FindElement(buttonLocator);

            // Scroll the page to bring the button into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);

            // Click the button
            button.Click();
        
        }

        public void ValidateResultOutput()
        {
            Assert.True(driver.FindElement(validateResults).Displayed);

        }

        public void selectHomeCheckBox()
        {
            if (!driver.FindElement(homeCheckBox).Selected)
            {
                driver.FindElement(homeCheckBox).Click();
            }
        }

        public void validateCheckBoxResults()
        {
            Assert.True(driver.FindElement(checkBoxResults).Displayed);
        }

        public void logWebTableValues()
        {
            var rows = driver.FindElements(webTableRow);
            foreach (var row in rows)
            {
          
                var cells = row.FindElements(WebTableCells);
                foreach (var cell in cells)
                {
                    Console.WriteLine(cell.Text);
                }
            }

        }

        public void EditWebTableValues(String tableValue,String newValue)
        {
            var rows = driver.FindElements(webTableRow);
            foreach (var row in rows)
            {

                var cells = row.FindElements(WebTableCells);
                foreach (var cell in cells)
                {
                    if(cell.Text == tableValue)
                    {
                        var editButton = row.FindElement(By.CssSelector(".action-buttons #edit-record-2"));
                        editButton.Click();

                        Thread.Sleep(2000);

                        var valueInput = driver.FindElement(By.XPath("//input[@value='"+tableValue+"']"));

                        valueInput.Clear();
                        valueInput.SendKeys(newValue);

                        driver.FindElement(webTableSubmitButton).Click();
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The value is not present");
                        Assert.False(false);
                    }
                }
            }

        }


        public void doubleClickButton()
        {
            Actions actions = new Actions(driver);
            // scrollIntoView(doubleClick);
            Thread.Sleep(3000);
            actions.DoubleClick(driver.FindElement(doubleClick)).Perform();
        }
        public void rightClickButton()
        {
            Actions actions = new Actions(driver);
            Thread.Sleep(3000);
            actions.ContextClick(driver.FindElement(rightClick)).Perform();
        }

        public void dynamicClickButton()
        {
            Thread.Sleep(3000);
            scrollIntoViewAndClick(singleClick);
            //driver.FindElement(singleClick).Click();
        }

        public void validateDoubleClickMessage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(driver.FindElement(doubleClickMessage).Text, "You have done a double click");
        }

        public void validateRightClickMessage()
        {
            Thread.Sleep(3000);
            IWebElement rightClickMess = driver.FindElement(rightClickMessage);

            // Scroll the page to bring the button into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", rightClickMess);

            Assert.AreEqual(rightClickMess.Text, "You have done a right click");
        }

        public void validateDynamicClickMessage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(driver.FindElement(dynamicClickMessage).Text, "You have done a dynamic click");
        }

        public void clickOnDownloadButton()
        {
            driver.FindElement(downloadButton).Click();

        }

        public void uploadSampleFile()
        {
            var upload = driver.FindElement(uploadButton);
           // upload.Click();
            string rootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(rootDirectory, @"Properties\sampleFile.jpeg");
            upload.SendKeys(filePath);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                try
                {
                    return upload.Enabled && upload.GetAttribute("value") != string.Empty;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }

        public void validatePathLocation()
        {
            Assert.IsTrue(driver.FindElement(filePath).Displayed);

        }
    }

}
