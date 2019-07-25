using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestProject1
{
    class QuestionToBBCPage
    {
        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement textInputField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        private IWebElement nameInputField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        private IWebElement emailInputField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Age']")]
        private IWebElement ageInputField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Postcode']")]
        private IWebElement postcodeInputField;

        [FindsBy(How = How.XPath, Using = "//span//p[text()='Sign me up for BBC News Daily']")]
        private IWebElement signforDailyCheckBox;

        [FindsBy(How = How.XPath, Using = "//div/button[@class='button']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IWebElement errorMessage;

        public QuestionToBBCPage(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(2)));
            //PageFactory.InitElements(driver, this);
        }

        public void FillInForm(Dictionary<string, string> infoToFill)
        {
            signforDailyCheckBox.Click();
            textInputField.SendKeys(infoToFill["Text to submit"]);
            nameInputField.SendKeys(infoToFill["Name"]);
            emailInputField.SendKeys(infoToFill["Email address"]);
            ageInputField.SendKeys(infoToFill["Age"]);
            postcodeInputField.SendKeys(infoToFill["Postcode"]);
        }

        public void PressSubmitButton()
        {
            submitButton.Click();
            Thread.Sleep(2000);
        }

        public void TakeScreenShot(IWebDriver driver)
        {
            Random random = new Random();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile
                ("C:\\Users\\Lena\\Desktop\\screen" + random.Next(99) + ".jpeg", ScreenshotImageFormat.Jpeg);
        }

        public bool IsDisplayedErrorMessage()
        {
            return errorMessage.Displayed;
        }

        public string GetErrorMessageText()
        {
            return errorMessage.Text;
        }

    }
}
