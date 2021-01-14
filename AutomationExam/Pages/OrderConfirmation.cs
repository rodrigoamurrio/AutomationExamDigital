using AutomationExam.Selenium;
using AutomationExam.Utilities;
using OpenQA.Selenium;

namespace AutomationExam.Pages
{
    public class OrderConfirmation : SeleniumActions
    {
        private readonly IWebDriver Driver;

        private By OrderConfirmationMessage => By.XPath("//div[@id='center_column']/h1");

        private By OrderStatus => By.XPath("//div[@class='box']/p[@class='cheque-indent']");


        public OrderConfirmation(IWebDriver driver)
        {
            Driver = driver;
        }

        public ErrorHandled VerifyOrderConfirmationTitle(string confirmationMessage)
        {
            var error = new ErrorHandled();
            var elementText = GetElementText(Driver, OrderConfirmationMessage, ref error);
            if (!elementText.Equals(confirmationMessage))
            {
                error.valid = false;
                error.message = $"The order confirmation does not display correctly {elementText}"; 
            }
            return error;            
        }

        public ErrorHandled VerifyOrderStatus(string expectedStatus)
        {
            var error = new ErrorHandled();
            var elementText = GetElementText(Driver, OrderStatus, ref error);
            if (!elementText.Contains(expectedStatus))
            {
                error.valid = false;
                error.message = $"The buy product is not completed {elementText}";
            }
            return error;            
        }
    }
}
