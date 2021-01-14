using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class MyStore : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By SignInElement =>  By.XPath("//a[@class='login']");


        public MyStore(IWebDriver driver)
        {
            Driver = driver;
        }

        public Login ClickOnSignIn(ref ErrorHandled error)
        {
            Login pageObject = null;
            error = ClickElement(Driver, SignInElement);
            if(error.valid)
            {
                pageObject = new Login(Driver);
            }             
            return pageObject;
        }
    }
}
