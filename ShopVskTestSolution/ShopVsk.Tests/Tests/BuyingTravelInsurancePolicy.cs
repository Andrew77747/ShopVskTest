using NUnit.Framework;
using ShopVsk.Framework.Models;
using ShopVsk.Framework.PageObjects.Elements;
using ShopVsk.Framework.PageObjects.Pages;

namespace ShopVsk.Tests.Tests
{
    public class BuyingTravelInsurancePolicy : TestBase
    {
        private readonly Header _header;
        private readonly TravelInsurancePage _travelInsurancePage;
        private readonly BuyingTravelInsurancePage _buyingInsurancePolicyPage;

        public BuyingTravelInsurancePolicy()
        {
            _header = new Header(Manager);
            _travelInsurancePage = new TravelInsurancePage(Manager);
            _buyingInsurancePolicyPage = new BuyingTravelInsurancePage(Manager);
        }

        [Test, TestCaseSource(typeof(DataProviders), "InsurancePolicyData")]
        [Description("Проверить оформление страхового полиса")]
        public void BuyingInsurancePolicy_Success(InsurancePolicy data)
        {
            _header.ClickTopMenuItem(TopMenu.Travel);
            _travelInsurancePage.ClickTravelBannerBtn();
            _buyingInsurancePolicyPage.SelectCountry(data.Country);
            _buyingInsurancePolicyPage.SetStartDate(data.StartDate);
            _buyingInsurancePolicyPage.SetEndDate(data.EndDate);
            _buyingInsurancePolicyPage.ClickNextStepBtn();
        }
    }
}