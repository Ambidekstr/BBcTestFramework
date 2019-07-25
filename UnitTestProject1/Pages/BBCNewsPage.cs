using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    class BBCNewsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"orb-search-q\"]")]
        private IWebElement searchTab;

        [FindsBy(How = How.XPath, Using = "//*/div/div/div/div[1]/div/div/div[3]/ul/li[2]/a/span")]
        private IWebElement categoryLink;

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid=\"container-top-stories#1\"]/div/div/a")]
        private IWebElement headlineArticleTitle;

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid=\"container-top-stories#2\"]/div/div/a")]
        private IWebElement firstSecondaryArticleTitle;

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid=\"container-top-stories#3\"]/div/div/a")]
        private IWebElement secondSecondaryArticleTitle;

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid=\"container-top-stories#5\"]/div/div/a")]
        private IWebElement thirdSecondaryArticleTitle;

        [FindsBy(How = How.XPath, Using = "//span[@class='gel-long-primer gs-u-ph']")]
        private IWebElement moreTab;

        [FindsBy(How = How.XPath, Using = "//span[text()='Have Your Say']")]
        private IWebElement haveYourSayTab;

        public BBCNewsPage(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
        }

        public List<string> GetFirstThreeSecondaryArticleTitles()
        {
            return new List<string> {firstSecondaryArticleTitle.Text,
                secondSecondaryArticleTitle.Text,
                thirdSecondaryArticleTitle.Text};
        }

        public string GetHeadlineArticleTitle()
        {
            string headlineTitle = headlineArticleTitle.Text;
            return headlineTitle;
        }

        public string GetCategoryLinkText()
        {
            return categoryLink.GetAttribute("innerText");
        }

        public void EnterSearchedText(string searchedText)
        {
            searchTab.SendKeys(searchedText);
        }

        public void SubmitSearchRequest()
        {
            searchTab.Submit();
        }

        public void GoToHaveYourSayPage()
        {
            moreTab.Click();
            haveYourSayTab.Click();
        }
    }
}
