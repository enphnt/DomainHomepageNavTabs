using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [Test]
        public void VerifyHomePageNavLinks()
        {
            int count = driver.FindElements(By.CssSelector(".main-nav-ul a")).Count();
            Console.WriteLine("Number of Nav Menu links: " + count);

            for (int i = 0; i < count; i++)
            {
                long startTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                string navTab = String.Format("//*[@class='main-nav-ul']//a", i);

                //Workaround: Ensures the final few tabs aren't hidden in dropdown
                driver.FindElement(By.XPath("//*[@class='main-nav-ul']//li[@class='dropdown']")).Click();

                //1. Find tab name in Nav Menu
                var tabs = driver.FindElements(By.XPath(navTab));
                Console.WriteLine("About to click:  " + tabs[i].Text);

                //2. Click the tab in current iteration
                tabs[i].Click();

                //3. Verify Page load completes
                checkPageLoad();

                //Calculate time to load (note: not a very high resolution timer)
                long finishTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                long totalTime_ms = finishTime - startTime;
                long totalTime_s = totalTime_ms / 1000;
                Console.WriteLine("  Total Time for page load - " + totalTime_ms + "ms (" + totalTime_s + "s)");

                //Clean Up: This test explicitly tests navigation FROM the homepage. 
                driver.Navigate().GoToUrl("http://www.domain.com.au");

                //todo: ask devs if worth testing from any other pages (some lack Nav Menu).
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();

            foreach (var process in Process.GetProcessesByName("chromedriver.exe"))
            {
                process.Kill();
            }
        }
    }
}
