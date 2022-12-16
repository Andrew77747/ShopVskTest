using NUnit.Framework;
using ShopVsk.Framework.Models;
using ShopVsk.Framework.PageObjects.Pages;
using System.Threading;
using Header = ShopVsk.Framework.PageObjects.Elements.Header;

namespace ShopVsk.Tests.Tests
{
    public class BuyingInsurance : TestBase
    {
        private Header _header;
        private TravelPage _travelPage;
        private BuyingInsurancePolicyPage _buyingInsurancePolicyPage;

        public BuyingInsurance()
        {
            _header = new Header(Manager);
            _travelPage = new TravelPage(Manager);
            _buyingInsurancePolicyPage = new BuyingInsurancePolicyPage(Manager);
        }

        [Test, TestCaseSource(typeof(DataProviders), "InsurancePolicyData")]
        [Description("Проверить оформление страхового полиса")]
        public void BuyingInsurancePolicy_Success(InsurancePolicy data)
        {
            _header.ClickTopMenuItem(Header.TopMenu.Travel);
            _travelPage.ClickTravelBannerBtn();
            _buyingInsurancePolicyPage.SelectCountry(data.Country);
            _buyingInsurancePolicyPage.SetStartDate(data.StartDate);
            _buyingInsurancePolicyPage.SetEndDate(data.EndDate);
            _buyingInsurancePolicyPage.ClickNextStepBtn();
        }
    }
}