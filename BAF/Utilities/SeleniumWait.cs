using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace BAF.Utilities
{
    public class SeleniumWait
    {
        IWebDriver driver;

        /**
         * Instantiates a new selenium wait.
         * 
         * @param driver
         *            the driver
         */
        public SeleniumWait(IWebDriver driver)
        {
            this.driver = driver;
        }

        /**
 * Gets the when clickable.
 * 
 * @param locator
 *            the locator
 * @param timeout
 *            the timeout
 * @return the when clickable
 */
        public IWebElement getWhenClickable(By locator, Double timeout)
        {
            IWebElement element;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            return element;
        }

        public IWebElement getWhenVisible(By locator, Double timeout)
        {
            IWebElement element;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }
        public void waitForElementToDisappear(By locator, Double timeOut)
        {
            //driver.Manage().Timeouts().ImplicitWait.Seconds.Equals(timeOut);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            //driver.Manage().Timeouts().ImplicitWait.Seconds.Equals(timeOut);
        }
        /**
 * Wait for dom to load.
 */
        public void waitForDomToLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*")));
        }

        public void waitForPageTitle(String title, Double timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.TitleContains(title));
        }

        /**
 * Click when ready.
 * 
 * @param locator
 *            the locator
 * @param timeout
 *            the timeout
 */
        public void clickWhenReady(By locator, Double timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public void highlightElement(IWebElement element)
        {
            var javaScriptDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

        public void type(IWebElement element, String textToType)
        {
            Actions act = new Actions(driver);
            act.SendKeys(element, textToType).Build().Perform();
        }
        public void doubleClick(IWebElement element)
        {
            Actions oAction = new Actions(driver);
            oAction.DoubleClick(element).Build().Perform();
        }

        public void mouseHover(IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();

        }
        public void rightClickOptionSelect(IWebElement selectElement, String contextMenuOption)
        {
            Actions oAction = new Actions(driver);
            oAction.MoveToElement(selectElement);
            oAction.ContextClick(selectElement).Build().Perform(); /* this will perform right click */
            IWebElement elementOpen = driver.FindElement(By.LinkText(contextMenuOption)); /* This will select menu after right click */
            elementOpen.Click();
        }

        public enum ActionType
        {
            up, down, pagedown, enter, tab
        }

        public void keyBoardActions(String actionType)
        {
            Actions actions = new Actions(driver);
            switch (actionType.ToLower())
            {
                case "up":
                    actions.KeyDown(Keys.Control).SendKeys(Keys.Up).Perform();
                    break;
                case "down":
                    actions.KeyDown(Keys.Control).SendKeys(Keys.Down).Perform();
                    break;
                case "pagedown":
                    actions.KeyDown(Keys.Control).SendKeys(Keys.PageDown).Perform();
                    break;
                case "enter":
                    actions.KeyDown(Keys.Control).SendKeys(Keys.Enter).Perform();
                    break;
                case "tab":
                    actions.KeyDown(Keys.Control).SendKeys(Keys.Tab).Perform();
                    break;
                default:
                    break;
            }
        }


    }
}
