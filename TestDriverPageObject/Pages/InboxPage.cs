using System;
using AutomatedTest.TestEmailSpecflow;
using AutomatedTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedTest.Pages
{
    public class InboxPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__left']//..//div/a")] 
        private IWebElement buttonCreateNew;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']//..//div[1]/textarea")]
        private IWebElement whom;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']/div[2]/div[2]/div[1]")]
        private IWebElement whom2;

        [FindsBy(How = How.XPath, Using = ".//*[@id='compose__header__content']//..//div[2]/input")]
        private IWebElement theme;

        [FindsBy(How = How.CssSelector, Using = "#tinymce")]
        private IWebElement frame;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__right']/div[3]/div/div[2]/div[2]/div/div[3]/div[1]")]
        private IWebElement dropdown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='b-toolbar__right']/div[3]/div/div[2]/div[2]/div/div[3]/div[2]/a[1]")]
        private IWebElement saveDraft;

        [FindsBy(How = How.CssSelector, Using = "#PH_logoutLink")]
        private IWebElement outButton;

        private IWebDriver driver;

        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Utils.BaseUrlIndoxPage);
        }

        public void ClickOnCreateNewMessageButton()
        {
            buttonCreateNew.Click();
        }

        public void CreateNewMessage(string namesender, string themeLetter, string messageUser)
        {
            whom.SendKeys(namesender);
            TestEmailSteps.HighlightElement(whom2);
            ScreenShots.ScreenShot();
            theme.SendKeys(themeLetter);
            GoToFrameSendKeys(messageUser);
            driver.SwitchTo().DefaultContent();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            dropdown.Click();
            saveDraft.Click();
        }

        private void GoToFrameSendKeys(string messageUser)
        {
            driver.SwitchTo().Frame(3);
            try
            {
                SendValueToMessage(messageUser);
            }
            catch (Exception)
            {
                driver.SwitchTo().DefaultContent();
                try
                {
                    driver.SwitchTo().Frame(2);
                    SendValueToMessage(messageUser);
                }
                catch (Exception)
                {
                    driver.SwitchTo().DefaultContent();
                    try
                    {
                        driver.SwitchTo().Frame(1);
                        SendValueToMessage(messageUser);
                    }
                    catch (Exception)
                    {
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame(0);
                        SendValueToMessage(messageUser);
                    }
                }
            }
        }

        private void SendValueToMessage(string messageUser)
        {
            frame.SendKeys(messageUser);
        }

        public void LogOut()
        {
            outButton.Click();
        }
    }
}
