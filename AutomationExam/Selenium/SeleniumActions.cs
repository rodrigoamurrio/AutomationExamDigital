using AutomationExam.Utilities;
using OpenQA.Selenium;
using System;

namespace AutomationExam.Selenium
{
    public class SeleniumActions
    {
        public SeleniumActions()
        {

        }

        public ErrorHandled ClickElement(IWebDriver driver, By element)
        {
            var error = new ErrorHandled();
            try
            {
                driver.FindElement(element).Click();
            }
            catch (Exception e)
            {
                error.valid = false;
                error.message = $"The element is not clickable - {e}";                
            }
            return error;
        }

        public ErrorHandled SetElementText(IWebDriver driver, By element, string text)
        {
            var error = new ErrorHandled();
            try
            {
                driver.FindElement(element).SendKeys(text);
            }
            catch (Exception e)
            {
                error.valid = false;
                error.message = $"The element is not clickable - {e}";
            }
            return error;
        }

        public string GetElementText(IWebDriver driver, By element, ref ErrorHandled error)
        {
            var elementText = string.Empty;
            try
            {
                elementText = driver.FindElement(element).Text;
            }
            catch (Exception e)
            {
                error.valid = false;
                error.message = $"Cannot get text of the element - {e}";
            }
            return elementText;
        }

    }
}
