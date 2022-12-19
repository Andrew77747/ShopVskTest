using OpenQA.Selenium;
using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Elements
{
    public enum TopMenu
    {
        Auto,
        Travel,
        Health,
        Estate,
        Mortgage
    }

    public class Header : BaseElement
    {
        public Header(IWebDriverManager manager) : base(manager){}

        #region Map of Elements

        private readonly By _topMenuItem = By.CssSelector(".nav.mx-auto a");

        #endregion

        public void ClickTopMenuItem(TopMenu menuItem)
        {
            var topMenuItemsList = Wrapper.FindElements(_topMenuItem);

            switch (menuItem)
            {
                case TopMenu.Auto:
                    topMenuItemsList[0].Click();
                    break;
                case TopMenu.Travel:
                    topMenuItemsList[1].Click();
                    break;
                case TopMenu.Health:
                    topMenuItemsList[2].Click();
                    break;
                case TopMenu.Estate:
                    topMenuItemsList[3].Click();
                    break;
                case TopMenu.Mortgage:
                    topMenuItemsList[4].Click();
                    break;
            }
        }
    }
}