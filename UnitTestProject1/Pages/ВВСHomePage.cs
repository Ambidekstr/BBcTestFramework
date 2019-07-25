using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UnitTestProject1
{
    class ВВСHomePage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='News']")]
        private IWebElement newsTab;

        public ВВСHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
        }

        public void GoToNewsPage()
        {
            newsTab.Click();
        }

    }
}
