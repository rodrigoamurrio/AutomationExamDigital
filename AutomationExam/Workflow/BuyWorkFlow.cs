using AutomationExam.Pages;
using AutomationExam.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationExam.Workflow
{
    public class BuyWorkFlow
    {
        protected IWebDriver driver;
        private ErrorHandled error;

        public BuyWorkFlow()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();            
        }

        public MyStore GotoMainPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            return new MyStore(driver);
        }

        private void FinallyTest()
        {
            driver.Close();
            driver.Quit();
        }

        public ErrorHandled BuyTshirt()
        {
            var mainPage = GotoMainPage(driver);
            if(mainPage != null)
            {
                var loginPage = mainPage.ClickOnSignIn(ref error);
                if(loginPage != null && error.valid)
                {
                    error = loginPage.SetEmailAddress("rodrigoamurrio@gmail.com");
                    if(error.valid)
                    {
                        error = loginPage.SetPassword("12345678");
                        if (error.valid)
                        {
                            var MyAccountPage = loginPage.ClickOnSignIn(ref error);
                            if (MyAccountPage != null && error.valid)
                            {
                                var tshirtPage = MyAccountPage.ClickOntshirtOption(ref error);
                                if (tshirtPage != null && error.valid)
                                {
                                    error = tshirtPage.ClickOntshirtOption();
                                    Thread.Sleep(5000);
                                    if(error.valid)
                                    {
                                        error = tshirtPage.ClickOnAddToCart();
                                        Thread.Sleep(3000);
                                        if(error.valid)
                                        {
                                            var orderPage = tshirtPage.ClickOnProceedCheckout(ref error);
                                            if (orderPage != null && error.valid)
                                            {
                                                error = orderPage.ClickOnProceedCheckout();
                                                Thread.Sleep(3000);
                                                if(error.valid)
                                                {
                                                    error = orderPage.ClickOnProceedCheckout();
                                                    Thread.Sleep(3000);
                                                    if(error.valid)
                                                    {
                                                        error = orderPage.ClickOnAgreeCheckBox();
                                                        Thread.Sleep(3000);
                                                        if(error.valid)
                                                        {
                                                            error = orderPage.ClickOnProceedCheckoutWithAgree();
                                                            Thread.Sleep(3000);
                                                            if(error.valid)
                                                            {
                                                                error = orderPage.ClickOnpayByBank();
                                                                Thread.Sleep(3000);
                                                                if(error.valid)
                                                                {
                                                                    var orderConfirmationPage = orderPage.ClickOnConfirmOrder(ref error);
                                                                    if (orderConfirmationPage != null && error.valid)
                                                                    {
                                                                        Thread.Sleep(3000);
                                                                        error = orderConfirmationPage.VerifyOrderConfirmationTitle("ORDER CONFIRMATION");
                                                                        if (error.valid)
                                                                        {
                                                                            error = orderConfirmationPage.VerifyOrderStatus("complete.");
                                                                        }
                                                                    }
                                                                }                                                                
                                                            }                                                            
                                                        }                                                        
                                                    }                                                   
                                                }                                                
                                            }
                                        }
                                    }                                                                                                                                               
                                }
                            }
                        }                        
                    }                    
                }
            }
            FinallyTest();
            return error;
        }
    }
}
