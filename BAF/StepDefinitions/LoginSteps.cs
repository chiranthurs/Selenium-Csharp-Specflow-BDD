using BAF.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BAF.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps : Steps
    {

        private IWebDriver driver;

        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            launchApplication("Login");
        }

        [Given(@"I login with user credentials")]
        public void GivenILoginWithUserCredentials()
        {
            driver.FindElement(By.Name("UserName")).SendKeys(ExcelUtil.getExcelValues(1, "Username"));
            driver.FindElement(By.Name("Password")).SendKeys(ExcelUtil.getExcelValues(1, "Password"));
        }


        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            driver.FindElement(By.Name("UserName")).SendKeys((String)data.UserName);
            driver.FindElement(By.Name("Password")).SendKeys((String)data.Password);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Name("Login")).Submit();
            Thread.Sleep(2000);
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            var element = driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation Selenium')]"));

            //An way to assert multiple properties of single test
            Assert.Multiple(() =>
            {
                //Assert.That(element.Text, Is.Null, "Header text not found !!!");
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
            });
        }


        //--------------------------------------------------------------------------------------

        public void launchApplication(String ApplicationName)
        {
            if (ApplicationName.ToLower().Equals("login"))
            {
                driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            }
            else
            {
                Console.WriteLine("No Application or Environment Selected");
            }


        }

    }
}
