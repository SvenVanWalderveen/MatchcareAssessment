using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SamburingaUITestNetCore
{
    [TestClass]
    public class UITests
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WpfAppId = @"D:\Git\MatchcareAssessment\SamburingaUI\bin\Debug\netcoreapp3.1\SamburingaUI.exe";

        protected static OpenQA.Selenium.Appium.Windows.WindowsDriver<OpenQA.Selenium.Appium.Windows.WindowsElement> session;


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (session == null)
            {
                var appiumOptions = new OpenQA.Selenium.Appium.AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new OpenQA.Selenium.Appium.Windows.WindowsDriver<OpenQA.Selenium.Appium.Windows.WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

            }
        }


        [TestMethod]
        public void TestForFirstPit()
        {

            session.FindElementByAccessibilityId("lblPlayer1Pit0").Click();
            var txtResult = session.FindElementByAccessibilityId("lblPlayer1Pit0");
            Assert.AreEqual("0", txtResult.Text);
        }
        [TestMethod]
        public void TestForSecondPit()
        {

            session.FindElementByAccessibilityId("lblPlayer1Pit0").Click();
            session.FindElementByAccessibilityId("lblPlayer1Pit1").Click();
            var txtResult = session.FindElementByAccessibilityId("lblPlayer1Pit6");
            Assert.AreEqual("9", txtResult.Text);
        }
    }
}
