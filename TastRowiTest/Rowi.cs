using NUnit.Framework;
using OpenQA.Selenium;

namespace TastRowiTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _searchInputButton = By.XPath("//input[@name='text']");
        private readonly By _clicksearchButton = By.XPath("//button[@role='button']");
        private readonly By _rowi = By.XPath("//a[@role='text']");

        private const string _search = "rowi";
        private const string _expectedRowi = "rowi.com";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ya.ru");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var search = driver.FindElement(_searchInputButton);
            search.SendKeys(_search);

            var clicksearch = driver.FindElement(_clicksearchButton);
            clicksearch.Click();

            var actualRowi = driver.FindElement(_rowi).Text;

            Assert.AreEqual(_expectedRowi, actualRowi, "No result");
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}