using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FastJobsExam
{
    class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WaitToLoadHomePage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//span[@class='logo']")));
        }
        public void ClickLoginSignUpButton()
        {
            IWebElement loginsignupbutton = driver.FindElement(By.XPath("//a[@id='login-dropdown']"));
            loginsignupbutton.Click();
        }
        public void ClickLoginAsJobseekerButton()
        {
            IWebElement loginasjobseeker = driver.FindElement(By.XPath("//a[@class='fj-eventtag'][normalize-space()='Login as Jobseeker']"));
            loginasjobseeker.Click();
        }
    }
}
