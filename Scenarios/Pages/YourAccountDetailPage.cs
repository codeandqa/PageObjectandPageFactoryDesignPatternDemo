using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Scenario_ShoppingCart.Scenarios.Pages;

namespace Scenario_ShoppingCart.Scenarios.Pages
{
    public class YourAccountDetailPage : HelperClass
    {
        IWebDriver driver;
        public YourAccountDetailPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            Assert.AreEqual("Your account details", driver.Title);
        }

        public void LoginToAccount()
        {
            //wait for your Account Detail Page. Enter Demo demo and click login. return as 
            WaitForVisibleElement("div[class='vm-login-form']");
            driver.FindElement(By.Name("username")).SendKeys("demo");
            driver.FindElement(By.Name("password")).SendKeys("demo" + Keys.Enter);

            //------------------Your Account Details Page.---------------------//
            //wait for login greeting text that you are logged in.
            WaitForVisibleElement("div[class='login-greeting']");
            //Verify the Hi demo text as greeting. 
            Assert.AreEqual("Hi demo,", driver.FindElement(By.CssSelector("div[class='login-greeting']")).Text);
        }

        public ShoppingCartPage GoToShoppingCartViaLink()
        {
            //VerifyAccount detail Page. CLick on Shopping Cart Link on the page. Change the quanitity 
            driver.FindElement(By.LinkText("Shopping Cart")).Click();
            return new ShoppingCartPage(driver);

        }
    }

}
