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

namespace Demoqa.PageObjects
{
    public class BookStorePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BookStorePageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Login
        By bookStoreApplicationTab = By.XPath("(//div[@class='card-up'])[6]");
        By mainPageHeader = By.XPath("//div[@class='main-header']");
        By loginTab = By.XPath("(//li[@class='btn btn-light '])[30]");
        By newUserButton = By.Id("newUser");
        By firstName = By.Id("firstname");
        By lastName= By.Id("lastname");
        By userName= By.Id("userName");
        By password = By.Id("password");
        By captchaChexBox = By.XPath("//span[@role='checkbox']");
        By register = By.Id("register");



        public void clickOnBookStoreApplication()
        {
            WaitForPageToLoad();
            scrollIntoViewAndClick(bookStoreApplicationTab);
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

        public void clickOnLoginTab()
        {
            scrollIntoViewAndClick(loginTab);
        }

        public void clickOnNewUser()
        {
            scrollIntoViewAndClick(newUserButton);
        }

        public void registerNewUserDetails(String firstname, String lastname, String username, String pass)
        {
           
            scrollIntoViewAndInput(firstName, firstname);
            scrollIntoViewAndInput(lastName, lastname);
            scrollIntoViewAndInput(userName, username);
            scrollIntoViewAndInput(password, pass);
            scrollIntoViewAndClick(captchaChexBox);
            scrollIntoViewAndClick(register);
        }

        

    }
}
