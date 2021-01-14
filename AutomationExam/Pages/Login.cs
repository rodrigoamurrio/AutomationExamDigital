using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class Login : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By EmailAddress => By.Id("email");

        private By Password => By.Id("passwd");

        private By SingInButton => By.Id("SubmitLogin");


        public Login(IWebDriver driver)
        {
            Driver = driver;
        }

        public ErrorHandled SetEmailAddress(string email)
        {
            return SetElementText(Driver, EmailAddress, email);
        }

        public ErrorHandled SetPassword(string pass)
        {
            return SetElementText(Driver, Password, pass);
        }

        public MyAccount ClickOnSignIn(ref ErrorHandled error)
        {
            MyAccount pageObject = null;
            error = ClickElement(Driver, SingInButton);
            if (error.valid)
            {
                pageObject = new MyAccount(Driver);
            }
            return pageObject;           
        }
    }
}
