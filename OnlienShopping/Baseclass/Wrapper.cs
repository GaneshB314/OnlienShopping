using NUnit.Framework;
using OnlienShopping.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlienShopping.Baseclass
{
    class Wrapper
    {

        public IWebDriver driver;
        public WebDriverWait wait;





        [SetUp]
        public void initial()
        {
            driver = new ChromeDriver();

            driver.Url = "https://www.demoblaze.com/";

            driver.Manage().Window.Maximize();

            
        }

        [TearDown]
        public void Final()
        {
            Screenshot se = ((ITakesScreenshot)driver).GetScreenshot();
            se.SaveAsFile(@"E:\\Ganesh-Selenium Files\\Selenium_Training-fail" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + Signup.username+".png");
            driver.Quit();
        }
    }
}
