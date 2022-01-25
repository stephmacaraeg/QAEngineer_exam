using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace FastJobsExam
{
    public class MainTest
    {
        IWebDriver driver;
        HomePage homePage;
        LogInPage loginPage;
        FacebookLogInPage facebookLogInPage;

        private const string validationMessage = "Please fill out this field.";
        private const string errorMessage = "Invalid username and/or password.";
        private const string jobsURL = "https://www.fastjobs.sg/singapore-jobs?ul=1";
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            
            homePage = new HomePage(driver);
            loginPage = new LogInPage(driver);
            facebookLogInPage = new FacebookLogInPage(driver);
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.fastjobs.sg/");

        }

        [Test]
        //Check that a validation message/tooltip will appear when the user inputs a blank email and password.
        public void CheckBlankEmailAndPassword()
        {
            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationMessageFromEmailTextBox(), validationMessage);
        }
        [Test]
        //Check that a validation message/tooltip will appear when the user inputs a blank email and VALID password.
        public void CheckBlankEmailAndValidPassword()
        {
            string validPassword = "samplevalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationMessageFromEmailTextBox(), validationMessage);
        }
        [Test]
        //Check that a validation message/tooltip will appear when the user inputs a VALID email and BLANK password.
        public void CheckValidEmailAndBlankPassword()
        {
            string validEmail = "samplevalidemail@gmail.com";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationMessageFromPasswordTextBox(), validationMessage);
        }
        [Test]
        //Check that an error message will appear when the user inputs an INVALID email and INVALID password.
        public void CheckInvalidEmailAndInvalidPassword()
        {
            string invalidEmail = "sampleinvalidemail@gmail.com";
            string invalidPassword = "sampleinvalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterEmailAddress(invalidEmail);
            loginPage.EnterPassword(invalidPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidErrorMessage(), errorMessage);
        }
        [Test]
        //Check that an error message will appear when the user inputs an email without domain and VALID password.
        public void CheckInvalidEmailWithoutEmailDomainAndValidPassword()
        {
            string emailWithoutDomain = "sampleinvalidemailwithoutemaildomain";
            string validPassword = "samplevalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterEmailAddress(emailWithoutDomain);
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidErrorMessage(), errorMessage);
        }
        [Test]
        //Check that an error message will appear when the user inputs a VALID email and INVALID password.
        public void CheckValidEmailAndInvalidPassword()
        {
            string validEmail = "samplevalidemail@gmail.com";
            string invalidPassword = "sampleinvalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.EnterPassword(invalidPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidErrorMessage(), errorMessage);
        }
        [Test]
        //Check that the user will directed to the jobs page when the user inputs a valid email valid password.
        public void CheckValidEmailAndValidPassword()
        {
            string validEmail = "validtestemail95@gmail.com";
            string validPassword = "r!chPanda50";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetCurrentURL(), jobsURL);
        }
        [Test]
        //Check that a new window will appear containing facebook textbox login credentials when user clicks the Login with facebook button.
        public void CheckLogInWithFacebook()
        {
            homePage.WaitToLoadHomePage();
            homePage.ClickLoginSignUpButton();
            homePage.ClickLoginAsJobseekerButton();
            loginPage.ClickFacebookLoginButton();
            Assert.IsTrue(facebookLogInPage.FacebookEmail());
            Assert.IsTrue(facebookLogInPage.FacebookPassword());
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}