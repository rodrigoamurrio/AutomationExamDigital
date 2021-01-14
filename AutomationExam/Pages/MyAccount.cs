using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class MyAccount : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By TshirtsOption => By.XPath("//div[@id='block_top_menu']/ul/li/a[@title='T-shirts']");


        public MyAccount(IWebDriver driver)
        {
            Driver = driver;
        }

        public Tshirt ClickOntshirtOption(ref ErrorHandled error)
        {
            Tshirt pageObject = null;
            error = ClickElement(Driver, TshirtsOption);
            if (error.valid)
            {
                pageObject = new Tshirt(Driver);
            }
            return pageObject;            
        }
    }
}
