using AutomatedTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedTest.Pages
{
    public class SentPage
    {
        private readonly By itemList = By.CssSelector(".b-datalist__item__subj");

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-nav_folders']/div/div[2]")]
        private IWebElement sentItem;

        [FindsBy(How = How.CssSelector, Using = ".b-nav__item__count")]
        private IWebElement itemElements;

        private IWebDriver driver;

        public SentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Utils.BaseUrlSentPage);
        }

        public void ClickOnSentItem()
        {
            sentItem.Click();
        }

        public bool CheckLetterInList(string themeLetter)
        {
            var elementsLetters = itemElements;
            var quantity = elementsLetters.Displayed ? int.Parse(elementsLetters.Text) : 0;
            var massItems = driver.FindElements(itemList);
            return (massItems[massItems.Count - quantity].Text.Contains(themeLetter));
        }
    }
}