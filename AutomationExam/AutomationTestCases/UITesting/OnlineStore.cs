using AutomationExam.Utilities;
using AutomationExam.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTestCases
{
    [TestClass]
    public class BuyProduct
    {
        private BuyWorkFlow _buyWorkflow = new BuyWorkFlow();
        private ErrorHandled result;

        /// <summary>
        /// Test Case Id: 001
        /// Test Description: Buy Product 
        /// </summary>
        [TestMethod]
        public void OnlineStore_VerifyIfBuyProductCorrectly()
        {
            result = _buyWorkflow.BuyTshirt();
            Assert.IsTrue(result.valid, result.message);
        }
    }
}
