using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace ShopVsk.Framework.Tools
{
    public class SeleniumWrapper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SeleniumWrapper(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        #region Actions

        public IWebElement FindElement(By element)
        {
            WaitForElementDisplayed(element);
            return _driver.FindElement(element);
        }

        public List<IWebElement> FindElements(By element)
        {
            WaitForElementDisplayed(element);
            return new List<IWebElement>(_driver.FindElements(element)); 
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By element)
        {
            FindElement(element).Click();
        }

        public void TypeAndSend(By element, string text)
        {
            FindElement(element).SendKeys(text);
        }

        public void ClearTypeAndSend(By element, string text)
        {
            FindElement(element).Clear();
            FindElement(element).SendKeys(text);
        }

        public void ScrollIntoViewElement(By element)
        {
            var e = _driver.FindElement(element);
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        #endregion

        #region Validation

        public bool IsElementExists(By element)
        {
            try
            {
                _driver.FindElement(element);
                return true;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(By element)
        {
            try
            {
                return _driver.FindElement(element).Displayed;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementsNotDisplayed(By element)
        {
            var elements = _driver.FindElements(element);
            return elements.Count == 0 || !elements[0].Displayed;
        }


        #endregion

        #region Waiters

        public void WaitForElement(By element)
        {
            _wait.Until(_ => IsElementExists(element));
        }

        public void WaitForElementDisplayed(By element)
        {
            WaitForElement(element);
            _wait.Until(_ => IsElementDisplayed(element));
        }

        public void WaitForElementEnabled(By element)
        {
            _wait.Until(_ => FindElement(element).Enabled);
        }

        public void WaitForLoadingPage()
        {
            _wait.Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForElementNotDisplayed(By element)
        {
            _wait.Until(_ => IsElementsNotDisplayed(element));
        }

        #endregion
    }
}