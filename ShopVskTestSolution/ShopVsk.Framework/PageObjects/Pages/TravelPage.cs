using Infrastructure.Settings;
using OpenQA.Selenium;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Pages
{
    public class TravelPage : BasePage
    {
        public TravelPage(IWebDriverManager manager) : base(manager, new AppSettings())
        {

        }

        #region Map of Elements

        private readonly By _travelBannerBtn = By.CssSelector(".d-desktop #travel_banner_button_buy");

        #endregion

        public void ClickTravelBannerBtn()
        {
            Wrapper.ClickElement(_travelBannerBtn);
        }
    }
}