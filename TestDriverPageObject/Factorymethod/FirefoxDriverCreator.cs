using System;
using AutomatedTest.Pages;
using AutomatedTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomatedTest.Factorymethod
{
    public class FirefoxDriverCreator : WebDriverCreator
    {
        public LoginPage loginPage;

        public override IWebDriver factoryMethod()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver = new DriverDecorator(driver);
                loginPage = new LoginPage(driver);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Utils.timeout));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }
    }
}
