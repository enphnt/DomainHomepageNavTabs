using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Linq;

namespace DomainWebTest
{
    [TestFixture]
    public class HomePageTests
    {
        IWebDriver driver = new ChromeDriver();
        HomePagePageObject page = new HomePagePageObject();

        [SetUp]
        public void GetDomainHomePage()
        {
            driver.Navigate().GoToUrl(page.url);
        }

        // Tests all tabs load based on number of main nav links
        [Test]
        public void VerifyAllHomePageMainNavLinks()
        {
            int count = driver.FindElements(By.CssSelector(page.NavTabsCssSelector)).Count();
            Console.WriteLine("Number of Nav Menu links: " + count);

            for (int i = 0; i < count; i++)
            {
                long startTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                string navTabXpath = String.Format(page.NavTabsFormat, i);

                // Workaround: Ensures the final few tabs aren't hidden in dropdown
                page.ClickMoreDropdown(driver);

                var tabs = driver.FindElements(By.XPath(navTabXpath));
                Console.WriteLine("About to click:  " + tabs[i].Text);

                tabs[i].Click();

                // 3. Verify Page load completes
                CheckPageLoad();

                // Calculate time to load (note: not a very high resolution timer)
                long finishTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                long totalTime_ms = finishTime - startTime;
                long totalTime_s = totalTime_ms / 1000;
                Console.WriteLine("  Total Time for page load - " + totalTime_ms + "ms (" + totalTime_s + "s)");

                // Clean Up for each iteration. Note: controls test to explicitly tests navigation FROM the homepage. 
                GetDomainHomePage();
            }
        }

        // Individual Tests for each tab load based on main nav link's text
        [Test]
        public void VerifyBuyLink()
        {
            page.ClickBuyLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyRentLink()
        {
            page.ClickRentLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyNewHomesLink()
        {
            page.ClickNewHomesLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifySoldLink()
        {
            page.ClickSoldLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyNewsLink()
        {
            page.ClickNewsLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyAdviceLink()
        {
            page.ClickAdviceLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyAgentsLink()
        {
            page.ClickAgentLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyMoreDropdown()
        {
            page.ClickMoreDropdown(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyHomePriceGuideLink()
        {
            page.ClickMoreDropdown(driver);
            page.ClickHomePriceGuideLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyAuctionResultsLink()
        {
            page.ClickMoreDropdown(driver);
            page.ClickAuctionResultsLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifySuburbProfilesLink()
        {
            page.ClickMoreDropdown(driver);
            page.ClickSuburbProfileLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyHomeLoansLink()
        {
            page.ClickMoreDropdown(driver);
            page.ClickHomeLoansLink(driver);
            CheckPageLoad();
        }

        [Test]
        public void VerifyPlaceAnAdLink()
        {
            page.ClickMoreDropdown(driver);
            page.ClickPlaceAnAdLink(driver);
            CheckPageLoad();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();

            foreach (var process in Process.GetProcessesByName("chromedriver.exe"))
            {
                process.Kill();
            }
        }

        public void CheckPageLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Assert.IsTrue(js.ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }
    }
}