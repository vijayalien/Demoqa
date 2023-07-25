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
using MongoDB.Driver.Core.Authentication;
using System.Drawing;
using SeleniumExtras.WaitHelpers;

namespace Demoqa.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

       
        public void WaitForPageToLoad()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void validateElementTitle(By ele)
        {
            WaitForPageToLoad();
            wait.Until(driver =>
            {
                try
                {
                    IWebElement element = driver.FindElement(ele);
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

        public void WaitForElementToBeVisible(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitForElementToBeClickable(By ele)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
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

    }
}
