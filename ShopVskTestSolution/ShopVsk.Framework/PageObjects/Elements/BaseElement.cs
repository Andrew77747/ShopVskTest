using ShopVsk.Framework.Tools;

namespace ShopVsk.Framework.PageObjects.Elements
{
    public class BaseElement
    {
        protected SeleniumWrapper Wrapper;

        public BaseElement(IWebDriverManager manager)
        {
            Wrapper = new SeleniumWrapper(manager.GetDriver(), manager.GetWaiter());
        }

        #region Map of Elements

        

        #endregion

    }
}