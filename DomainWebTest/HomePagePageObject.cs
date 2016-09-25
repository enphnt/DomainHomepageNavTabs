using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainWebTest
{
    public class HomePagePageObject
    {
        public string url = "http://www.domain.com.au";
        public string NavTabsFormat = "//*[@class='main-nav-ul']//a";
        public string NavTabsCssSelector = ".main-nav-ul a";

        public void getNavTabCount(IWebDriver driver)
        {
            int tabcount = driver.FindElements(By.CssSelector(".main-nav-ul a")).Count();
        }

        public void ClickMoreDropdown(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//*[@class='main-nav-ul']//li[@class='dropdown']")).Click();
        }

        public void ClickBuyLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Buy")).Click();
        }

        public void ClickRentLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Rent")).Click();
        }

        public void ClickNewHomesLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("New Homes")).Click();
        }

        public void ClickSoldLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Sold")).Click();
        }

        public void ClickNewsLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("News")).Click();
        }

        public void ClickAdviceLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Advice")).Click();
        }

        public void ClickAgentLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Agents")).Click();
        }

        public void ClickHomePriceGuideLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Home Price Guide")).Click();
        }

        public void ClickAuctionResultsLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Auction Results")).Click();
        }

        public void ClickSuburbProfileLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Suburb Profiles")).Click();
        }

        public void ClickHomeLoansLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Home Loans")).Click();
        }

        public void ClickPlaceAnAdLink(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Place an Ad")).Click();
        }
    }
}
