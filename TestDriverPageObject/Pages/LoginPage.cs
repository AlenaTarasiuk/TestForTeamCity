using OpenQA.Selenium;
using Yandex.HtmlElements.Loaders;

namespace AutomatedTest.Pages
{
    public class LoginPage
    {
        private LoginPageData loginPageData;

        public LoginPage(IWebDriver driver)
        {
            HtmlElementLoader.PopulatePageObject(this, driver);
        }

        public void Login(string username, string password)
        {
            loginPageData.Login(username, password);
        }

        public bool CheackLogout()
        {
            return loginPageData.CheackLogout();
        }
    }
}