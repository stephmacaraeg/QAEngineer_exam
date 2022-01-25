using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FastJobsExam
{
    class FacebookLogInPage
    {
        IWebDriver driver;
        public FacebookLogInPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public bool FacebookEmail()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//*[@id='email']")));

            IWebElement facebookusername = driver.FindElement(By.XPath("//*[@id='email']"));       
            return facebookusername.Displayed;
        }
        public bool FacebookPassword()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//*[@id='pass']")));

            IWebElement facebookpassword = driver.FindElement(By.XPath("//*[@id='pass']"));
            return facebookpassword.Displayed;
        }
    }
}
