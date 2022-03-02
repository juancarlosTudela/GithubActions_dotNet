using NUnit.Framework;
using OpenQA.Selenium;
using prueba_GhA.Factories;

namespace prueba_GhA
{
    public class Tests
    {
        private IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void Setup()
        {
            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Enum.BrowserType.Chrome, hubUrl);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
            Assert.Pass();
        }
    }
}