using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UnitTestProject1
{
    class LoremIpsumPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"amount\"]")]
        private IWebElement numOfCharactersField;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bytes\"]")]
        private IWebElement selectedElementToGenerate;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"generate\"]")]
        private IWebElement generateTextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"lipsum\"]/p")]
        private IWebElement textField;

        public LoremIpsumPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
        }

        public string GenerateText(int numOfCharacters)
        {
            numOfCharactersField.Clear();
            numOfCharactersField.SendKeys(numOfCharacters.ToString());
            selectedElementToGenerate.Click();
            generateTextButton.Click();
            return textField.Text;
        }

    }
}
