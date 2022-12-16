using Infrastructure.Settings;
using ShopVsk.Framework.PageObjects.Elements;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Pages
{
    public class BasePage : BaseElement
    {
        private AppSettings _settings;

        public BasePage(IWebDriverManager manager, AppSettings settings) : base(manager)
        {
            _settings = settings;
        }

        public void Open()
        {
            Wrapper.NavigateToUrl(_settings.BaseUrl);
        }
    }
}