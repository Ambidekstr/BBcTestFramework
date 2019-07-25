using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class BBCTestCases
    {
        [TestMethod]
        public void HeadlineTitleValidation()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToNewsPage();
            bbcService.CheckHeadlineArticleTitle();
            driver.Quit();
        }

        [TestMethod]
        public void SecondaryTitlesValidation()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToNewsPage();
            bbcService.CheckSecondaryArticlesTitles();
            driver.Quit();
        }

        [TestMethod]
        public void SearchValidation()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToNewsPage();
            bbcService.SubmitSearchCategory();
            bbcService.CheckSearchedArticleTitle();
            driver.Quit();
        }

        [TestMethod]
        public void FillFormWithCorrectInfo()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToQuestionPage();

            IWebDriver driverForLoremIpsum = new ChromeDriver();
            LoremIpsumWebSiteService loremIpsumWebSiteService = 
                new LoremIpsumWebSiteService(driverForLoremIpsum);
            Dictionary<string, string> infoToFill = new Dictionary<string, string>
            {
                ["Name"] = "Lena",
                ["Email address"] = "123@i.ua",
                ["Age"] = "18",
                ["Postcode"] = "123123",
                ["Text to submit"] = loremIpsumWebSiteService.GenerateText(140),
                ["Error message"] = ""
            };

            driverForLoremIpsum.Quit();
            bbcService.FillFormAndTakeScreenShot(infoToFill);
            driver.Quit();
        }

        [TestMethod]
        public void ShouldCropTextWhenLengthMoreThan140()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToQuestionPage();

            IWebDriver driverForLoremIpsum = new ChromeDriver();
            LoremIpsumWebSiteService loremIpsumWebSiteService = 
                new LoremIpsumWebSiteService(driverForLoremIpsum);
            Dictionary<string, string> infoToFill = new Dictionary<string, string>
            {
                ["Name"] = "Lena",
                ["Email address"] = "123@i.ua",
                ["Age"] = "18",
                ["Postcode"] = "123123",
                ["Text to submit"] = loremIpsumWebSiteService.GenerateText(145),
                ["Error message"] = ""
            };

            driverForLoremIpsum.Quit();
            bbcService.FillFormAndTakeScreenShot(infoToFill);
            driver.Quit();
        }

        [TestMethod]
        public void ShouldShowErrorMessageWhenNameFieldEmpty()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToQuestionPage();

            IWebDriver driverForLoremIpsum = new ChromeDriver();
            LoremIpsumWebSiteService loremIpsumWebSiteService = 
                new LoremIpsumWebSiteService(driverForLoremIpsum);

            Dictionary<string, string> infoToFill = new Dictionary<string, string>
            {
                ["Name"] = "",
                ["Email address"] = "123@i.ua",
                ["Age"] = "18",
                ["Postcode"] = "123123",
                ["Text to submit"] = loremIpsumWebSiteService.GenerateText(145),
                ["Error message"] = "Name can't be blank"
            };

            driverForLoremIpsum.Quit();
            bbcService.FillFormAndPressSubmitButton(infoToFill);
            driver.Quit();
        }

        [TestMethod] 
        public void ShouldShowErrorMessageWhenEmailFieldEmpty()
        {
            IWebDriver driver = new ChromeDriver();
            BBCWebSiteService bbcService = new BBCWebSiteService(driver);
            bbcService.GoToQuestionPage();

            IWebDriver driverForLoremIpsum = new ChromeDriver();
            LoremIpsumWebSiteService loremIpsumWebSiteService = 
                new LoremIpsumWebSiteService(driverForLoremIpsum);

            Dictionary<string, string> infoToFill = new Dictionary<string, string>
            {
                ["Name"] = "Lena",
                ["Email address"] = "",
                ["Age"] = "18",
                ["Postcode"] = "123123",
                ["Text to submit"] = loremIpsumWebSiteService.GenerateText(145),
                ["Error message"] = "Email address can't be blank"
            };

            driverForLoremIpsum.Quit();
            bbcService.FillFormAndPressSubmitButton(infoToFill);
            driver.Quit();
        }
    }
}
