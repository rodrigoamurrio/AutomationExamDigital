using AutomationExam.API_Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AutomationExam.AutomationTestCases.APITesting
{
    [TestClass]
    public class UserTest
    {

        private readonly API_WorkFlow _apiWorkflow = new API_WorkFlow();        

        /// <summary>
        /// Test Case Id: 002
        /// Test Description: Verify if the "michael.lawson@reqres.in" exist in response
        /// </summary>
        [TestMethod]
        public void API_VerifyEmailExistInResponse()
        {
            var email = "michael.lawson@reqres.in";
            Assert.IsTrue(_apiWorkflow.VerifyEmailExistInResponse(email), $"The email {email} does not exist in the response");
        }
    }
}
