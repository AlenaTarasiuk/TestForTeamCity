using OpenQA.Selenium;

namespace AutomatedTest.Factorymethod
{
    public abstract class WebDriverCreator
    {
        protected IWebDriver driver;

        public abstract IWebDriver factoryMethod();
    }
}
