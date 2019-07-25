using OpenQA.Selenium;

namespace UnitTestProject1
{
    class LoremIpsumWebSiteService
    {
        private IWebDriver driver;

        public LoremIpsumWebSiteService(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GenerateText(int numOfCharacters)
        {
            LoremIpsumPage loremIpsum = new LoremIpsumPage(driver);
            return loremIpsum.GenerateText(numOfCharacters);
        }
    }
}
