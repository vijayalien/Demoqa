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

namespace Demoqa.PageObjects
{
    public class AlertsFramesWindowsPageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string mainWindowHandle = null;
        public AlertsFramesWindowsPageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Alert
        By alertsFramesWindowsTab = By.XPath("(//div[@class='card-up'])[3]");
        By mainPageHeader = By.XPath("//div[@class='main-header']");
        By alertsTab = By.XPath("(//li[@class='btn btn-light '])[12]");
        By alertButton = By.Id("alertButton");
        By delayedAlertButton = By.Id("timerAlertButton");
        By confirmAlertButton = By.Id("confirmButton");
        By promptAlertButton = By.Id("promtButton");
        By confirmMessage = By.Id("confirmResult");
        By promptMessage = By.Id("promptResult");

        //Browser Windows
        By browserWindowTab = By.XPath("(//li[@class='btn btn-light '])[11]");
        By newTabButton = By.Id("tabButton");
        By newWindowButton = By.Id("windowButton");
        By newWindowMessageButton = By.Id("messageWindowButton");
        By newTabSampleHeading = By.Id("sampleHeading");
        By messageWindowBodyMessage = By.TagName("body");


        public void clickOnAlertsFramesWindowsTab()
        {
            Thread.Sleep(8000);
            driver.FindElement(alertsFramesWindowsTab).Click();
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

        public void clickAlertTab()
        {
            validateElementTitle();

            scrollIntoViewAndClick(alertsTab);

        }

        public void clickBrowserWindowTab()
        {
            validateElementTitle();

            scrollIntoViewAndClick(browserWindowTab);

        }


        public void clickOnAlertButton()
        {
            scrollIntoViewAndClick(alertButton);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            
        }

       

        public void clickAndAcceptDelayedAlertButton()
        {

            scrollIntoViewAndClick(delayedAlertButton);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            bool isAlertVisible = wait.Until(driver => IsAlertPresent());

            if (isAlertVisible)
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }


        public void clickOnConfirmAlertAndAccept()
        {

            scrollIntoViewAndClick(confirmAlertButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            bool isAlertVisible = wait.Until(driver => IsAlertPresent());

            if (isAlertVisible)
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }

        public void clickOnConfirmAlertAndReject()
        {

            scrollIntoViewAndClick(confirmAlertButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            bool isAlertVisible = wait.Until(driver => IsAlertPresent());

            if (isAlertVisible)
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
        }

        public void validateConfirmBoxOkMessage()
        {
            Assert.IsTrue(driver.FindElement(confirmMessage).Text.Contains("You selected Ok"));
        }

        public void validateConfirmBoxCancelMessage()
        {
            Assert.IsTrue(driver.FindElement(confirmMessage).Text.Contains("You selected Cancel"));
        }

        public void clickPromptAlertAndPassText(string prompt)
        {
            scrollIntoViewAndClick(promptAlertButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            bool isAlertVisible = wait.Until(driver => IsAlertPresent());

            if (isAlertVisible)
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.SendKeys(prompt);
                alert.Accept();
            }
        }

        public void validatePromptAlertText(String alertText)
        {
            Assert.IsTrue(driver.FindElement(promptMessage).Text.Contains("You entered "+alertText));

        }

        public void clickOnNewTabButton()
        {
            scrollIntoViewAndClick(newTabButton);
        }

        public void switchToNewTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
           
        }

        public void closeNewTabAndSwitchToOriginal()
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }


        public void validateNewTabTitle()
        {
            Assert.IsTrue(driver.Url.Contains("sample"));
            Assert.IsTrue(driver.FindElement(newTabSampleHeading).Text.Contains("This is a sample page"));
        }

        public void clickOnNewWindowButton()
        {
            scrollIntoViewAndClick(newWindowButton);
        }

        public void switchToNewWIndow()
        {
            mainWindowHandle = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> allWindowHandles = driver.WindowHandles;
            foreach (string windowHandle in allWindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }

        public void closeNewWindow()
        { 
            driver.Close();
            driver.SwitchTo().Window(mainWindowHandle);
        }

        public void clickOnMessageWindowButton()
        {
            scrollIntoViewAndClick(newWindowMessageButton);
        }

        public void validateMessageWindow()
        {
            Assert.IsTrue(driver.FindElement(messageWindowBodyMessage).Text.Contains("Knowledge increases by sharing but not by saving"));
        }

        public void switchToMessageWindow()
        {
            String messageWindowHandle = driver.CurrentWindowHandle;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);
            ReadOnlyCollection<string> allWindowHandles = driver.WindowHandles;
            foreach (string windowHandle in allWindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);

                    string jsCode = "return document.getElementsByTagName('body').textContent;";
                    driver.ExecuteJavaScript(jsCode);
                    break;
                }
            }

        }

    }
}
