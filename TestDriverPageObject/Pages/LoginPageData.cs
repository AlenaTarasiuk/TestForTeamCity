using OpenQA.Selenium.Support.PageObjects;
using Yandex.HtmlElements.Attributes;
using Yandex.HtmlElements.Elements;

namespace AutomatedTest.Pages
{
    [Block(How = How.CssSelector, Using = MailBoxData.Name)]
    public class LoginPageData : HtmlElement
    {
        [FindsBy(How = How.ClassName, Using = MailBoxData.Login)] 
        private TextInput inputLogin;

        [FindsBy(How = How.ClassName, Using = MailBoxData.Password)] 
        private TextInput inputPassword;

        [FindsBy(How = How.ClassName, Using = MailBoxData.ButtonLog)] 
        private Button buttonSubmit;

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();    
        }
      
        public bool CheackLogout()
        {
            return buttonSubmit.Displayed;
        }
    }
}
