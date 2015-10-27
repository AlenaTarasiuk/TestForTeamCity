using System;
using System.Linq;
using AutomatedTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTest.Pages
{
    public class DraftsPage
    {
        private readonly By itemList = By.CssSelector(".b-datalist__item__subj");

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-nav_folders']/div/div[3]")] private IWebElement drafts;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']/div[2]/div[2]/div[1]/span[3]")] private
            IWebElement whomLetter;

        [FindsBy(How = How.CssSelector, Using = "#tinymce")] private IWebElement frame;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__right']/div[3]/div/div[2]/div[1]/div")] private
            IWebElement sentButton;

        [FindsBy(How = How.CssSelector, Using = ".b-datalist__empty__text")] private IWebElement pointItem;

        private IWebDriver driver;

        public DraftsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Utils.BaseUrl);
        }

        public void ClickOnDraftsItem()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => drafts);
            drafts.Click();
        }

        public bool LetterIsMoveToFolderDrafts(string themeLetter)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var massItems = driver.FindElements(itemList);
            return (massItems.Last().Text.Contains(themeLetter));
        }

        public void LetterOpenInDraftsFolder()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));
            var massItems = driver.FindElements(itemList);
            massItems.Last().Click();

        }

        public bool CheckContentsDataInLetter(string testuserMailRu, string message)
        {
            var flag = whomLetter.Text.Equals(testuserMailRu);
            GoToFrameAssertValue(message);
            driver.SwitchTo().DefaultContent();
            return flag;
        }

        public void ClickOnSentItem()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            sentButton.Click();

        }

        private void GoToFrameAssertValue(string message)
        {
            driver.SwitchTo().Frame(3);
            try
            {
                AssertMessageValue(message);
            }
            catch (Exception)
            {
                driver.SwitchTo().DefaultContent();
                try
                {
                    driver.SwitchTo().Frame(2);
                    AssertMessageValue(message);
                }
                catch (Exception)
                {
                    driver.SwitchTo().DefaultContent();
                    try
                    {
                        driver.SwitchTo().Frame(1);
                        AssertMessageValue(message);
                    }
                    catch (Exception)
                    {
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame(0);
                        AssertMessageValue(message);
                    }
                }
            }
        }

        private void AssertMessageValue(string messageUser)
        {
            Assert.That(frame.Text.Contains(messageUser), Is.True);
        }

        public bool IsLetterDisappeared()
        {
            return pointItem.Text.Equals(Utils.emptyMessage);
        }
    }
}