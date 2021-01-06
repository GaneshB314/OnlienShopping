using NUnit.Framework;
using OnlienShopping.Baseclass;
using OnlienShopping.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace OnlienShopping
{
    
     class UnitTest1 : Wrapper
    {


        [Test]
        public void TestMethod1()
        {


            
            Signup sp = new Signup(driver);
            sp.Signups();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.LinkText("Log in")));
            driver.FindElement(By.LinkText("Log in")).Click();

            Thread.Sleep(3000);

            String name = Signup.username;

            driver.FindElement(By.Id("loginusername")).SendKeys(name);

            driver.FindElement(By.Id("loginpassword")).SendKeys(Signup.passwords);

            driver.FindElement(By.XPath("//button[contains(text(),'Log in')]")).Click();

            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id='nameofuser']")));

            Thread.Sleep(5000);

            String WelcomeName = driver.FindElement(By.XPath("//*[@id='nameofuser']")).Text;

            Thread.Sleep(3000);

            Assert.True(WelcomeName.Contains(name));

        

            String[] se = new String[] { "Phones", "Laptops", "Monitors" };

            foreach(var sa in se)
            {
                Console.WriteLine("Product Type is " + sa);

                driver.FindElement(By.XPath("//*[@id='navbarExample']/ul/li[1]/a")).Click();

                if (sa.Equals("Phones"))
                {
                    driver.FindElement(By.LinkText("Phones")).Click();

                    Thread.Sleep(3000);

                    driver.FindElement(By.LinkText("Samsung galaxy s6")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.LinkText("Add to cart")).Click();
                    Thread.Sleep(3000);
                    driver.SwitchTo().Alert().Accept();
                }

                if (sa.Equals("Monitors"))
                {
                    driver.FindElement(By.LinkText("Monitors")).Click();

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                    js.ExecuteScript("window.scrollBy(0,200)","");

                    Thread.Sleep(4000);
                    driver.FindElement(By.LinkText("ASUS Full HD")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.LinkText("Add to cart")).Click();
                    Thread.Sleep(3000);
                    driver.SwitchTo().Alert().Accept();
                }

                if (sa.Equals("Laptops")) 
                {

                    String Lpts = "Iphone 6 32gb";
                    Thread.Sleep(3000);
                 
                    
                   int cnt= driver.FindElements(By.XPath("//*[@id='tbodyid']/div/div/div/h4/a")).Count;



                    for(int i=1;i<=cnt;i++)
                    {
                        String prodt = driver.FindElement(By.XPath("//*[@id='tbodyid']/div["+i+"]/div/div/h4/a")).Text;
                      
                        string ses= driver.PageSource;

                        if (ses.Contains(Lpts))
                        {
                            var Laptopss = driver.FindElement(By.LinkText("Iphone 6 32gb"));
                            Laptopss.Click();
                            Thread.Sleep(3000);
                            driver.FindElement(By.LinkText("Add to cart")).Click();
                            Thread.Sleep(3000);
                            driver.SwitchTo().Alert().Accept();
                            break;


                        }
                       else
                       {
                            driver.FindElement(By.XPath("//button[contains(text(),'Next')]")).Click();
                            
                                 

                            
                       }



                    }
                       

                }

                







                
            }
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id='cartur']")));
            driver.FindElement(By.XPath("//*[@id='cartur']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[contains(text(),'Place Order')]")).Click();
            Thread.Sleep(100000);
        }
    }
}
