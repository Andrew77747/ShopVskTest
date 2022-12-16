using Infrastructure.Settings;
using OpenQA.Selenium;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Pages
{
    public class BuyingInsurancePolicyPage : BasePage
    {
        public BuyingInsurancePolicyPage(IWebDriverManager manager) : base(manager, new AppSettings())
        {

        }

        #region Map of Elements

        private readonly By _countriesDropdown = By.CssSelector("tui-multi-select._editable");
        private readonly By _startDateInput = By.CssSelector("[label='Дата начала'] .t-input");
        private readonly By _endDateInput = By.CssSelector("[label='Дата окончания'] .t-input");
        private readonly By _nextStepBtn = By.Id("sidebar_step_next");

        #endregion

        public void SelectCountry(string countryName)
        {
            Wrapper.ClickElement(_countriesDropdown);
            Wrapper.FindElement(By.XPath($"//button[contains(text(), '{countryName}')]")).Click();
            Wrapper.ClickElement(_countriesDropdown);
        }

        public void SetStartDate(string startDate)
        {
            Wrapper.WaitForElementEnabled(_nextStepBtn);
            Wrapper.ClearTypeAndSend(_startDateInput, startDate);
        }

        public void SetEndDate(string endDate)
        {
            Wrapper.WaitForElementEnabled(_nextStepBtn);
            Wrapper.ClearTypeAndSend(_endDateInput, endDate);
        }

        public void ClickNextStepBtn()
        {
            Wrapper.ClickElement(_nextStepBtn);
        }
    }
}