using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UnitTestProject1
{
    class SearchResultsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"search-content\"]/ol[2]/li[1]/article/div/h1/a")]
        private IWebElement firstArticleTitle;

        public SearchResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
        }

        public string GetArticleTitle()
        {
            return firstArticleTitle.Text;
        }

    }
}
