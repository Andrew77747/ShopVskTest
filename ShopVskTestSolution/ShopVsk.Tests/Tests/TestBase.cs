using Infrastructure.Settings;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ShopVsk.Framework.Tools;
using System;
using ShopVsk.Framework.PageObjects.Pages;

namespace ShopVsk.Tests.Tests
{
    [TestFixture]
    public class TestBase
    {
        public readonly WebDriverManager Manager;
        public readonly AppSettings Settings;
        private readonly BasePage _basePage;

        public TestBase()
        {
            Manager = new WebDriverManager();
            Settings = new ConfigurationManager().GetSettings();
            _basePage = new BasePage(Manager, Settings);
        }

        [SetUp]
        public void Start()
        {
            _basePage.Open();
        }

        [TearDown]
        public void TeardownTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = new ScreenshotMaker(Manager.Driver, TestContext.CurrentContext.Test.Name);
                Console.WriteLine("The screen shot was made into " + screenshot.Path);
                TestContext.AddTestAttachment(screenshot.Path);
            }

            Manager.Dispose();
        }
    }
}