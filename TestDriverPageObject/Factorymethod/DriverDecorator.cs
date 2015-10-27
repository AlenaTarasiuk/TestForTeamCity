using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace AutomatedTest.Factorymethod
{
    public class DriverDecorator : IWebDriver
    {
        protected IWebDriver driver;

        public bool IsElementPresent(By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        public DriverDecorator(IWebDriver driver)
        {
            Console.WriteLine("Create driver!");
            this.driver = driver;
        }

        public IWebElement FindElement(By by)
        {
            Console.WriteLine("Looking for element with locator: " + by);
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return driver.FindElements(by);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose driver!");
            driver.Dispose();
        }

        public void Close()
        {
            Console.WriteLine("Close driver!");
            driver.Close();
        }

        public void Quit()
        {
            Console.WriteLine("Quit driver!");
            driver.Quit();
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            Console.WriteLine("Looking where we navigated: " + driver.Navigate());
            return driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public string Url { get; set; }
        public string Title 
        {
            get { return driver.Title; } 
        }
        public string PageSource { get; private set; }
        public string CurrentWindowHandle { get; private set; }
        public ReadOnlyCollection<string> WindowHandles { get; private set; }
    }
}