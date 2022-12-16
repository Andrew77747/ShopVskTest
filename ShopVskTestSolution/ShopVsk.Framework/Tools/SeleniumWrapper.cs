using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace ShopVsk.Framework.Tools
{
    public class SeleniumWrapper
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SeleniumWrapper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        #region Actions

        public IWebElement FindElement(By by)
        {
            WaitForElementDisplayed(by);
            return _driver.FindElement(by);
        }

        public List<IWebElement> FindElements(By by)
        {
            return new List<IWebElement>(_driver.FindElements(by)); 
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public void TypeAndSend(By by, string text)
        {
            FindElement(by).SendKeys(text);
        }

        public void ClearTypeAndSend(By by, string text)
        {
            FindElement(by).Clear();
            FindElement(by).SendKeys(text);
        }

        public void ScrollIntoViewElement(By by)
        {
            var e = _driver.FindElement(by);
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        #endregion

        #region Validation

        public bool IsElementExists(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                return _driver.FindElement(by).Displayed;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }


        #endregion

        #region Waiters

        public void WaitForElement(By by)
        {
            _wait.Until(_ => IsElementExists(by));
        }

        public void WaitForElementDisplayed(By by)
        {
            WaitForElement(by);
            _wait.Until(_ => IsElementDisplayed(by));
        }

        public void WaitForElementEnabled(By by)
        {
            _wait.Until(_ => FindElement(by).Enabled);
        }

        #endregion

    }
}