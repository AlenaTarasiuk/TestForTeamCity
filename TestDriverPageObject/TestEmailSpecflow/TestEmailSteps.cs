using System;
using AutomatedTest.Factorymethod;
using AutomatedTest.Pages;
using AutomatedTest.Utilities;
using log4net;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace AutomatedTest.TestEmailSpecflow
{
    [Binding]
    public class TestEmailSteps
    {
        private static IWebDriver driver;
        private LoginPage loginPage;
        private InboxPage mainPage;
        private InboxPage createInboxPage;
        private DraftsPage draftsPage;
        private SentPage sentPage;
        private ILog log = LogManager.GetLogger(typeof(TestEmailSteps));

        [BeforeScenario]
        public void InitBrowser()
        {
            WebDriverCreator creator = new FirefoxDriverCreator();
            driver = creator.factoryMethod();
            log.Info("browser started");
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            driver.Close();
            driver = null;
            log.Info("browser closed");
        }

        [Given(@"I navigate on mailbox page")]
        public void NavigateOnMailboxPage()
        {
            loginPage = new LoginPage(driver);
            OpenPage();
            log.Debug("debug level");
            ScreenShots.ScreenShot();
        }

        [When(@"I go to created a mailbox")]
        public void WhenIGoToCreatedAMailbox()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login(Utils.username, Utils.password);
            log.Info("logged in as "+ Utils.username);
            ScreenShots.ScreenShot();
        }

        [When(@"I out of mailbox")]
        public void WhenIOutOfMailbox()
        {
            mainPage = new InboxPage(driver);
            mainPage.LogOut();
            log.Info("logouted of mailbox");
            ScreenShots.ScreenShot();
        }

        [Then(@"I check that logout made successfully")]
        public void ThenICheckThatLogoutMadeSuccessfully()
        {
            loginPage = new LoginPage(driver);
            Assert.That(loginPage.CheackLogout(), Is.True);
            log.Error("logout made not successful");
        }

        [When(@"I create a new message with data destination ""(.*)"", topic ""(.*)"" and data content ""(.*)""")]
        public void WhenICreateANewMessageWithDataDestinationTopicAndDataContent(string namesender, string themeLetter,
            string messageUser)
        {
            mainPage = new InboxPage(driver);
            mainPage.ClickOnCreateNewMessageButton();
            createInboxPage = new InboxPage(driver);
            createInboxPage.CreateNewMessage(namesender, themeLetter, messageUser);
            log.Info("create a new message");
            ScreenShots.ScreenShot();
        }

        [When(@"I move to the folder Drafts")]
        public void WhenIMoveToTheFolder()
        {
            draftsPage = new DraftsPage(driver);
            draftsPage.ClickOnDraftsItem();
            log.Debug("debug level");
            ScreenShots.ScreenShot();
        }

        [When(@"I open letter")]
        public void WhenIOpenLetter()
        {
            draftsPage.ClickOnDraftsItem();
            draftsPage.LetterOpenInDraftsFolder();
            log.Info("open letter");
            ScreenShots.ScreenShot();
        }

        [When(@"I send letter")]
        public void WhenISendLetter()
        {
            draftsPage.ClickOnDraftsItem();
            draftsPage.LetterOpenInDraftsFolder();
            draftsPage.ClickOnSentItem();
            log.Info("send letter");
            log.Debug("debug level");
            ScreenShots.ScreenShot();
        }

        [When(@"I move to the list of messages in the folder Drafts")]
        public void WhenIMoveToTheListOfMessagesInTheFolder()
        {
            draftsPage.ClickOnDraftsItem();
            ScreenShots.ScreenShot();
        }

        [Then(@"I check that entry carried out successfully")]
        public void ThenICheckThatEntryCarriedOutSuccessfully()
        {
            Assert.True(GetLoggedInUserName().Contains(Utils.username));
            log.Error("entry carried out not successful");
        }

        [Then(@"I see that letter in the list")]
        public void ThenISeeThatLetterInTheList()
        {
            draftsPage = new DraftsPage(driver);
            Assert.True(draftsPage.LetterIsMoveToFolderDrafts(Utils.themeLetter));
        }

        [Then(@"I check the contents of the letter data destination ""(.*)"" and data content ""(.*)""")]
        public void ThenICheckTheContentsOfTheLetterDataDestinationAndDataContent(string testuserMailRu, string message)
        {
            Assert.That(draftsPage.CheckContentsDataInLetter(testuserMailRu, message));
        }

        [Then(@"I check that the letter disappeared")]
        public void ThenICheckThatTheLetterDisappeared()
        {
            Assert.That(draftsPage.IsLetterDisappeared(), Is.True);
            log.Error("letter not disappeared");
        }

        [When(@"I move to the folder Sent")]
        public void WhenIMoveToTheFolderSent()
        {
            sentPage = new SentPage(driver);
            sentPage.ClickOnSentItem();
            log.Debug("debug level");
            ScreenShots.ScreenShot();
        }

        [Then(@"I check that the letter is in the list")]
        public void ThenICheckThatTheLetterIsInTheList()
        {
            Assert.True(sentPage.CheckLetterInList(Utils.themeLetter));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Utils.BaseUrlLoginPage);
            log.Info("open main page");
        }

        public string GetLoggedInUserName()
        {
            return driver.Title;
        }

        public static void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            String bgcolor = element.GetCssValue("background-color");
            js.ExecuteScript("arguments[0].style.compose__labels.background-color = '" + "red" + "'", element);
            ScreenShots.ScreenShot();
            js.ExecuteScript("arguments[0].style.compose__labels.background-color = '" + bgcolor + "'", element);
        }
    }
}