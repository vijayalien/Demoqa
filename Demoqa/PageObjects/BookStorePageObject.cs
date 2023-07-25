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
    public class BookStorePageObject : BasePageObject
    {
      
        public BookStorePageObject(IWebDriver driver) : base(driver)
        {
            //this.driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
        By captchaChexBox = By.XPath("//div[@class='recaptcha-checkbox-border']");
        By register = By.Id("register");
        By backToLogin = By.Id("gotologin");
        By login = By.Id("login");
        By userValue = By.Id("userName-value");



        public void clickOnBookStoreApplication()
        {
            WaitForPageToLoad();
            scrollIntoViewAndClick(bookStoreApplicationTab);
        }
       
        public void validateTitle()
        {
            validateElementTitle(mainPageHeader);

        }

        public void clickOnLoginTab()
        {
            validateTitle();
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
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@title='reCAPTCHA']")));
            driver.FindElement(captchaChexBox).Click();
            Thread.Sleep(9000);
            driver.SwitchTo().DefaultContent();
            scrollIntoViewAndClick(register);
        }

        public void clickBackToLogin()
        {
            scrollIntoViewAndClick(backToLogin);
        }
       

        public void acceptUserCreatedAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            bool isAlertVisible = wait.Until(driver => IsAlertPresent());

            if (isAlertVisible)
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }


        public void loginUsingExistingUser(String username, String pass)
        {
            scrollIntoViewAndInput(userName, username);
            scrollIntoViewAndInput(password, pass);
            scrollIntoViewAndClick(login);
        }

        public void validateLoginCreds(String user)
        {
            WaitForElementToBeVisible(userValue);
            Assert.IsTrue(driver.FindElement(userValue).Text.Equals(user));
        }
    }
}
