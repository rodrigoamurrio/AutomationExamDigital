using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class Tshirt : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By TshirtsProduct => By.XPath("//a[@class='product_img_link']");

        private By AddTocartButton => By.XPath("//button[@name='Submit']");

        private By ProceedCheckout => By.XPath("//div[@class='button-container']/a[@title='Proceed to checkout']");

        private By IFrameTshirt => By.XPath("//iframe[@class='fancybox-iframe']");


        public Tshirt(IWebDriver driver)
        {
            Driver = driver;
        }

        public ErrorHandled ClickOntshirtOption()
        {
            return ClickElement(Driver, TshirtsProduct);            
        }

        public ErrorHandled ClickOnAddToCart()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(IFrameTshirt));
            return ClickElement(Driver, AddTocartButton);
        }

        public Order ClickOnProceedCheckout(ref ErrorHandled error)
        {
            Order pageObject = null;
            error = ClickElement(Driver, ProceedCheckout);
            if (error.valid)
            {
                pageObject = new Order(Driver);
            }
            return pageObject;            
        }
    }
}
