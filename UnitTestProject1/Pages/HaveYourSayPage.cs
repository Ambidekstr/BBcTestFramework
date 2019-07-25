using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UnitTestProject1
{
    class HaveYourSayPage
    {
        [FindsBy(How = How.XPath, Using = "(//a[@href=\"/news/uk-47933096\"]/h3)[1]")]     
            private IWebElement doYouhaveQuestionsTab;


        public HaveYourSayPage(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
        }

        public void GoToQuestionToBBCPage()
        {
            doYouhaveQuestionsTab.Click();
        }

    }
}
