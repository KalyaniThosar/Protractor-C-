using System;
using Protractor;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ProtractorDemo
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupMethod()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestMethod1()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("http://www.angularjs.org");
            ngDriver.FindElement(NgBy.Model("yourName")).SendKeys("Kalyani");
            Assert.AreEqual("Hello Kalyani!", ngDriver.FindElement(NgBy.Binding("yourName")).Text);
        }

        [Test]
        public void TestMethod2()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Manage().Window.Maximize();
            ngDriver.Navigate().GoToUrl("https://danielykpan.github.io/ng2-fan-menu/");
            ngDriver.FindElement(By.ClassName("menu-btn")).Click();
        }

        [Test]
        public void TestMethod3()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/banking");
            

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
