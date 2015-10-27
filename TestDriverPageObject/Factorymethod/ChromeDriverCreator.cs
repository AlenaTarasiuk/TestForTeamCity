using System;
using AutomatedTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedTest.Factorymethod
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        public override IWebDriver factoryMethod()
        {
            if (driver == null)
            {
                var optn = new ChromeOptions();
                var service = ChromeDriverService.CreateDefaultService(@"C:\");
                service.LogPath = "chromedriver.log";
                service.EnableVerboseLogging = true;
                service.Start();
                driver = new ChromeDriver(service, optn);
                driver = new DriverDecorator(driver);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Utils.timeout));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }
    }
}