using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FastJobsExam
{
    class LogInPage
    {
        IWebDriver driver;
        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WaitToLoadLogInModal()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='modal-login']//span[@class='site-brand'][normalize-space()='FastJobs']")));
        }

        public void ClickLoginButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='btn-login']")));
            
            IWebElement loginbutton = driver.FindElement(By.XPath("//button[@id='btn-login']"));
            loginbutton.Click();
        }
        public void EnterEmailAddress(string emailInput)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='loginform-username']")));

            IWebElement email = driver.FindElement(By.XPath("//input[@id='loginform-username']"));
            email.SendKeys(emailInput);
        }
        public void EnterPassword(string passwordInput)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='loginform-password']")));

            IWebElement password = driver.FindElement(By.XPath("//input[@id='loginform-password']"));
            password.SendKeys(passwordInput);
        }
        public string GetValidationMessageFromEmailTextBox()
        {
            IWebElement geterrormessage = driver.FindElement(By.XPath("//input[@id='loginform-username']"));
            string errormessage = geterrormessage.GetAttribute("validationMessage");
            return errormessage;
        }
        public string GetValidationMessageFromPasswordTextBox()
        {
            IWebElement geterrormessage = driver.FindElement(By.XPath("//input[@id='loginform-password']"));
            string errormessage = geterrormessage.GetAttribute("validationMessage");
            return errormessage;
        }
        public string GetInvalidErrorMessage()
        {
            string xpathErrorMessage = "//body/div[@class='container main-content']/div[@class='row']/form[@id='login-form']/div[@class='col-xs-10 col-xs-push-1 col-sm-6 col-sm-push-3 col-md-6 col-md-push-3 text-center']/div[1]";
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath(xpathErrorMessage)));

            IWebElement invaliderrormessage = driver.FindElement(By.XPath(xpathErrorMessage));
            return invaliderrormessage.Text;
        }
        public string GetCurrentURL()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//span[@class='logo hidden-xs']")));

            string currentURL = driver.Url;
            return currentURL;
        }
        public void ClickFacebookLoginButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='fb-login-button-modal']")));
            string originalWindow = driver.CurrentWindowHandle;
            Assert.AreEqual(driver.WindowHandles.Count, 1);

            IWebElement facebookloginbutton = driver.FindElement(By.XPath("//button[@id='fb-login-button-modal']"));
            facebookloginbutton.Click();

            wait.Until(wd => wd.WindowHandles.Count == 2);

            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }
    }
}
