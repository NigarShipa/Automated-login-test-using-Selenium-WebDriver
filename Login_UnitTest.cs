using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace DotnetSelenium
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Login_Successful()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            IWebElement userNameField = driver.FindElement(By.Id("username"));
            userNameField.SendKeys("student");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("Password123");
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();
            Thread.Sleep(2000);

        }
        [Test]
        public void Login_Failed_With_Invalid_Username()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys("wrongUser");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);

        }
        [Test]
        public void Lgin_Failed_With_Invalid_Password()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("wrongpassword");
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }

}
