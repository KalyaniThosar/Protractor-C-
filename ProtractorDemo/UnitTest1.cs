using System;
using Protractor;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace ProtractorDemo
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        public WebDriverWait wait;

        [SetUp]
        public void SetupMethod()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
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
            ngDriver.Manage().Window.Maximize();
            ngDriver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/banking");
            wait.Until(ExpectedConditions.ElementExists(NgByBinding.XPath("//button[text()='Customer Login']")));
            ngDriver.FindElement(NgByBinding.XPath("//button[text()='Customer Login']")).Click();
            wait.Until(ExpectedConditions.ElementExists(NgBy.Model("custId")));
            ReadOnlyCollection<NgWebElement> customers = ngDriver.FindElement(NgBy.Model("custId")).FindElements(NgBy.Repeater("cust in Customers"));
            foreach (NgWebElement cust in customers)
            {
                if (cust.Text.Contains("Harry Potter"))
                {
                    cust.Click();
                    break;
                }
                
            }
            wait.Until(ExpectedConditions.ElementExists(NgByBinding.XPath("//button[text()='Login']")));
            ngDriver.FindElement(NgByBinding.XPath("//button[text()='Login']")).Click();
            wait.Until(ExpectedConditions.ElementExists(NgByBinding.XPath("//button[contains(text(),'Deposit')]")));
            ngDriver.FindElement(NgByBinding.XPath("//button[contains(text(),'Deposit')]")).Click();
            ngDriver.FindElement(NgBy.Model("amount")).SendKeys("100");
            ngDriver.FindElement(NgByBinding.XPath("//button[contains(@class,'btn btn-default')]")).Click();


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
