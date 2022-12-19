using Infrastructure.Settings;
using OpenQA.Selenium;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Pages
{
    public class BuyingTravelInsurancePage : BasePage
    {
        public BuyingTravelInsurancePage(IWebDriverManager manager) : base(manager, new AppSettings()){}

        #region Map of Elements

        private readonly By _countriesDropdown = By.CssSelector("tui-multi-select .t-native");
        private readonly By _startDateInput = By.CssSelector("[label='Дата начала'] .t-input");
        private readonly By _endDateInput = By.CssSelector("[label='Дата окончания'] .t-input");
        private readonly By _nextStepBtn = By.Id("sidebar_step_next");
        private readonly By _priceLoader = By.CssSelector(".sidebar-travel .sidebar-travel__price-loader");

        #endregion

        private void WaitForPriceLoaderInvisible()
        {
            Wrapper.WaitForElementDisplayed(_priceLoader);
            Wrapper.WaitForElementNotDisplayed(_priceLoader);
        }

        public void SelectCountry(string countryName)
        {
            Wrapper.ClickElement(_countriesDropdown);
            Wrapper.FindElement(By.XPath($"//button[contains(text(), '{countryName}')]")).Click();
            Wrapper.ClickElement(_countriesDropdown);
        }

        public void SetStartDate(string startDate)
        {
            WaitForPriceLoaderInvisible();
            Wrapper.ClearTypeAndSend(_startDateInput, startDate);
        }

        public void SetEndDate(string endDate)
        {
            WaitForPriceLoaderInvisible();
            Wrapper.ClearTypeAndSend(_endDateInput, endDate);
        }

        public void ClickNextStepBtn()
        {
            WaitForPriceLoaderInvisible();
            Wrapper.ClickElement(_nextStepBtn);
        }
    }
}