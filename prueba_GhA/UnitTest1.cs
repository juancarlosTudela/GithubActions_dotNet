using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using prueba_GhA.Factories;

namespace prueba_GhA
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        private IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void Setup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Enum.BrowserType.Chrome, hubUrl);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        [Category("SampleTag")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.Pass();
                
            }, "Google Search");
            
        }
    }
}