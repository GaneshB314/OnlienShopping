using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlienShopping.Pages
{
    class Signup
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public static string username = "saravanaselve";
        public static string passwords = "123";


        public Signup(IWebDriver d)
        {
            driver = d;
        }

        public void Signups()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement Signup = driver.FindElement(By.LinkText("Sign up"));
            Signup.Click();

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("sign-username")));
            IWebElement Username = driver.FindElement(By.Id("sign-username"));
            Username.SendKeys(username);


            IWebElement Password = driver.FindElement(By.Id("sign-password"));
            Password.SendKeys(passwords);

            IWebElement SignupButton = driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]"));
            SignupButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());

            String AlertMsg = driver.SwitchTo().Alert().Text;

            Console.WriteLine(AlertMsg);

            Thread.Sleep(3000);

            Assert.AreEqual("Sign up successful.", AlertMsg);

            driver.SwitchTo().Alert().Accept();
        }
    }
}
