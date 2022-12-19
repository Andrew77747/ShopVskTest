using Infrastructure.Settings;
using OpenQA.Selenium;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Pages
{
    public class TravelInsurancePage : BasePage
    {
        public TravelInsurancePage(IWebDriverManager manager) : base(manager, new AppSettings()){}

        #region Map of Elements

        private readonly By _travelBannerBuyBtn = By.CssSelector(".d-desktop #travel_banner_button_buy");

        #endregion

        public void ClickTravelBannerBtn()
        {
            Wrapper.ClickElement(_travelBannerBuyBtn);
        }
    }
}