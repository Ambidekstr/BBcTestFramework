using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace UnitTestProject1
{
    class BBCWebSiteService
    {
        private IWebDriver driver;

        public BBCWebSiteService(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckHeadlineArticleTitle()
        {
            BBCNewsPage newsPage = new BBCNewsPage(driver);
            string headlineArticle = newsPage.GetHeadlineArticleTitle();

            Assert.AreEqual("Boris Johnson promises start of 'golden age'", headlineArticle);
        }

        public void CheckSecondaryArticlesTitles()
        {
            BBCNewsPage newsPage = new BBCNewsPage(driver);

            List<string> expectedTitles = new List<string>() {
                "Second Europe heatwave breaks more records",
                "Why is it so hot and is climate change to blame?",
                "US government orders first executions since 2003" };

            List<string> actualTitles = newsPage.GetFirstThreeSecondaryArticleTitles();

            Assert.AreEqual(expectedTitles[0], actualTitles[0]);
            Assert.AreEqual(expectedTitles[1], actualTitles[1]);
            Assert.AreEqual(expectedTitles[2], actualTitles[2]);
        }

        public void GoToNewsPage()
        {
            ВВСHomePage homePage = new ВВСHomePage(driver);
            homePage.GoToNewsPage();
        }

        public void SubmitSearchCategory()
        {
            BBCNewsPage bBCNewsPage = new BBCNewsPage(driver);

            bBCNewsPage.EnterSearchedText(bBCNewsPage.GetCategoryLinkText());
            bBCNewsPage.SubmitSearchRequest();
        }

        public void CheckSearchedArticleTitle()
        {
            SearchResultsPage searchResults = new SearchResultsPage(driver);

            Assert.AreEqual("Drivetime with Eddie Nestor: UK politics and new drivers", 
                searchResults.GetArticleTitle());
        }

        public void GoToHaveYourSayPage()
        {
            GoToNewsPage();
            BBCNewsPage bBCNewsPage = new BBCNewsPage(driver);
            bBCNewsPage.GoToHaveYourSayPage();
        }

        public void GoToQuestionPage()
        {
            GoToHaveYourSayPage();
            HaveYourSayPage haveYourSay = new HaveYourSayPage(driver);
            haveYourSay.GoToQuestionToBBCPage();
        }

        public void FillFormAndPressSubmitButton(Dictionary<string, string> infoToFill)
        {
            QuestionToBBCPage questionToBBC = new QuestionToBBCPage(driver);
            questionToBBC.FillInForm(infoToFill);

            questionToBBC.PressSubmitButton();
            Assert.IsTrue(questionToBBC.IsDisplayedErrorMessage());
            Assert.AreEqual(infoToFill["Error message"], questionToBBC.GetErrorMessageText());
        }

        public void FillFormAndTakeScreenShot(Dictionary<string, string> infoToFill)
        {
            QuestionToBBCPage questionToBBC = new QuestionToBBCPage(driver);
            questionToBBC.FillInForm(infoToFill);

            questionToBBC.TakeScreenShot(driver);
        }

        public void FillForm(Dictionary<string, string> infoToFill, bool pressSubmitButton)
        {
            QuestionToBBCPage questionToBBC = new QuestionToBBCPage(driver);
            questionToBBC.FillInForm(infoToFill);

            if (pressSubmitButton) //validate error message
            {
                questionToBBC.PressSubmitButton();
                Assert.IsTrue(questionToBBC.IsDisplayedErrorMessage());
                Assert.AreEqual(infoToFill["Error message"], questionToBBC.GetErrorMessageText());
            }
            else  //if submitted text is more than 140 characters, takes screenshot
            {
                questionToBBC.TakeScreenShot(driver);
            }
        }
    }
}
