using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class Order : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By AgreeCheckBox => By.Id("cgv");

        private By ProceedCheckoutWithAgree => By.XPath("//button[@name='processCarrier']");
        private By ProceedCheckout => By.XPath("//span[text()='Proceed to checkout']");

        private By PayByBank => By.XPath("//a[@class='bankwire']");

        private By ConfirmOrder => By.XPath("//button/span[contains(text(),'I confirm')]");


        public Order(IWebDriver driver)
        {
            Driver = driver;
        }

        public ErrorHandled ClickOnProceedCheckout()
        {
            return ClickElement(Driver, ProceedCheckout);      
        }

        public ErrorHandled ClickOnProceedCheckoutWithAgree()
        {
            return ClickElement(Driver, ProceedCheckoutWithAgree);            
        }

        public ErrorHandled ClickOnAgreeCheckBox()
        {
            return ClickElement(Driver, AgreeCheckBox);
        }

        public OrderConfirmation ClickOnConfirmOrder(ref ErrorHandled error)
        {
            OrderConfirmation pageObject = null;
            error = ClickElement(Driver, ConfirmOrder);
            if (error.valid)
            {
                pageObject = new OrderConfirmation(Driver);
            }
            return pageObject;            
        }

        public ErrorHandled ClickOnpayByBank()
        {
            return ClickElement(Driver, PayByBank);
        }
    }
}
