using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainHomepageNavTabs
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void GetDomainHomePage()
        {
            driver.Navigate().GoToUrl("http://www.domain.com.au");
        }

        public void checkPageLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Assert.IsTrue(js.ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        //[Test]
        //public void ClickAllTab()
        //{
        //    //By Expected Result Array  
        //    string tabs = ["Buy","Rent"];

        //    //By selecting all nav links (inlcudes more such as those within dropdown)
        //    string tabs = driver.FindElement(By.CssSelector(".main-nav-ul a"));

        //    try (var tab in tabs)
        //    {   
        //        driver.FindElement(By.LinkText(tab)).Click();
        //        checkPageLoad();
        //    }

        //}

        [Test]
        public void ClickBuyTab()
        {
            driver.FindElement(By.LinkText("Buy")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickRentTab()
        {
            driver.FindElement(By.LinkText("Rent")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickNewHomesTab()
        {
            driver.FindElement(By.LinkText("New Homes")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickSoldTab()
        {
            driver.FindElement(By.LinkText("Sold")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickNewsTab()
        {
            driver.FindElement(By.LinkText("News")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickAdviceTab()
        {
            driver.FindElement(By.LinkText("Advice")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickAgentsTab()
        {
            driver.FindElement(By.LinkText("Agents")).Click();
            checkPageLoad();
        }

        [Test]
        public void ClickMoreTab()
        {
            driver.FindElement(By.LinkText("More")).Click();
            checkPageLoad();
        }

        //[TearDown] //need to tear down after all test...current behaviour is to tear down after first test.
        //public void CleanUp()
        //{
        //    driver.Close();
        //}
    }
}
