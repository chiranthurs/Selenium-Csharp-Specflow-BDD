using BAF.CoreTestBase;
using BAF.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;


namespace BAF.PageObjects
{
    public class BasePage : SeleniumWait
    {
        public static ExtentTest test;
        protected IWebDriver driver;
        protected SeleniumWait expWait;

        public BasePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            expWait = new SeleniumWait(driver);
        }

        /**
 * Wait for sync page.
 */
        public void waitForSyncPage()
        {
            expWait.waitForDomToLoad();
        }


        public void launchApplication(string ApplicationName, string Environment)
        {
            if (ApplicationName.ToLower().Equals("productplan") && Environment.ToLower().Equals("sit"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getProductPlanSITUrl);
            }
            else if (ApplicationName.ToLower().Equals("productplan") && Environment.ToLower().Equals("dit"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getProductPlanDITUrl);
            }
            else if (ApplicationName.ToLower().Equals("productplan") && Environment.ToLower().Equals("at"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getProductPlanATUrl);
            }
            else if (ApplicationName.ToLower().Equals("castor") && Environment.ToLower().Equals("sit"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getCastorSITUrl);
            }
            else if (ApplicationName.ToLower().Equals("castor") && Environment.ToLower().Equals("dit"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getCastorDITUrl);
            }
            else if (ApplicationName.ToLower().Equals("castor") && Environment.ToLower().Equals("at"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getCastorATUrl);
            }
            else if (ApplicationName.ToLower().Equals("castor") && Environment.ToLower().Equals("test4"))
            {
                driver.Navigate().GoToUrl(UrlFactory.getCastorTest4Url);
            }
            else
            {
                reportInfoLog("No Application or Environment Selected");
            }

        }

        public void verifyEnviromentStatus(String ApplicationName, String env)
        {
            try
            {
                if (driver.FindElement(By.XPath("//h1[text()='...oops!']")).Displayed)
                {
                    reportFatalLog("'" + env + "' environment is down for '" + ApplicationName + "' ");
                }
            }

            catch
            {
                reportPassLog("'" + env + "' environment is up and running for '" + ApplicationName + "'");
            }

        }

        /**
 * Gets the page title.
 *
 * @return the page title
 */
        public String getPageTitle()
        {
            return driver.Title;
        }

        /**
 * Gets the element by text.
 *
 * @param elementlist
 *            the elementlist
 * @param elementtext
 *            the elementtext
 * @return the element by text
 */
        protected IWebElement getElementByText(List<IWebElement> elementlist, String elementtext)
        {
            IWebElement element = null;
            foreach (var elem in elementlist)
            {
                if (elem.Text.Equals(elementtext))
                {
                    element = elem;
                }
            }
            if (element == null)
            {
            }
            return element;
        }
        /**
 * Gets the window handle.
 *
 * @return the window handle
 */
        public void getWindowHandle()
        {
            foreach (var winHandle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(winHandle);
            }
            driver.Manage().Window.Maximize();
            reportInfoLog("Switch to new window. Title : " + driver.Title);
        }

        public String get_CurrentWindowHandle()
        {
            reportInfoLog("Get current window. Title : " + driver.Title);
            return driver.CurrentWindowHandle;
        }

        public void checkProductPlanSpinnerToDisappear()
        {
            try
            {
                expWait.waitForElementToDisappear(By.XPath("//div[@id='loadingSpinner']"), 120);
            }
            catch (Exception e)
            {
                try
                {
                    Thread.Sleep(10000);
                }
                catch (ThreadInterruptedException e1)
                {
                    Console.WriteLine(e1.StackTrace);
                }
            }
        }

        /**
 * Switch to default content.
 */
        public void switchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void SelectElementFromDropdown(IWebElement selectElement, String selectorType, String sel)
        {
            SelectElement select = new SelectElement(selectElement);
            if (selectorType.ToLower().Equals("index"))
            {
                select.SelectByIndex(int.Parse(sel));
            }
            if (selectorType.ToLower().Equals("visibletext"))
            {
                select.SelectByText(sel);
            }
            if (selectorType.ToLower().Equals("value"))
            {
                select.SelectByValue(sel);
            }
        }

        public void waitLong(int i)
        {
            try
            {
                Thread.Sleep(i * 1000);
            }
            catch
            {

            }
        }

        /**
 * Check week slider spinner to appear.
 */
        public void checkWeekSliderSpinnerToAppear()
        {
            try
            {
                waitLong(2);
                //expWait.waitForElementToDisappear(By.id("weekslider"), 2);
            }
            catch
            {
                waitLong(2);
            }
        }

        /**
 * Check week slider spinner to disappear.
 */
        public void checkWeekSliderSpinnerToDisappear()
        {
            try
            {
                waitLong(5);
            }
            catch
            {
                waitLong(5);
            }
        }

        /**
 * Execute javascript.
 *
 * @param script
 *            the script
 */
        public void executeJs(String script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, (Object)null);
        }

        public void scrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void switchToActiveElement()
        {
            driver.SwitchTo().ActiveElement();
        }

        public void reportInfoLog(String message)
        {
            TestInitiator.test.Log(LogStatus.Info, message, "INFO");
        }
        public void reportPassLog(String message)
        {
            TestInitiator.test.Log(LogStatus.Pass, message, "PASS");
        }
        public void reportSkipLog(String message)
        {
            TestInitiator.test.Log(LogStatus.Skip, message, "SKIP");
        }
        public void reportFailLog(String message)
        {
            TestInitiator.test.Log(LogStatus.Fail, message, "FAIL");
        }
        public void reportFatalLog(String message)
        {
            TestInitiator.test.Log(LogStatus.Fatal, message, "FATAL");
        }

    }
}
