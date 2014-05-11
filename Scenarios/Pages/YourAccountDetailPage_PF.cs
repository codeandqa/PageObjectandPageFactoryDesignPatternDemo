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
    public class YourAccountDetailPage_PF : HelperClass
    {
        IWebDriver driver;

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "div[class='login-greeting']")]
        private IWebElement loginGreeting;

        public YourAccountDetailPage_PF(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            Assert.AreEqual("Your account details", driver.Title);
        }

        public void LoginToAccount()
        {
            //wait for your Account Detail Page. Enter Demo demo and click login. return as 
            WaitForVisibleElement("div[class='vm-login-form']");
            username.SendKeys("demo");
            password.SendKeys("demo" + Keys.Enter);

            //------------------Your Account Details Page.---------------------//
            //wait for login greeting text that you are logged in.
            WaitForVisibleElement("div[class='login-greeting']");
            //Verify the Hi demo text as greeting. 
            Assert.AreEqual("Hi demo,", loginGreeting.Text);
        }

        public ShoppingCartPage_PF GoToShoppingCartViaLink()
        {
            //VerifyAccount detail Page. CLick on Shopping Cart Link on the page. Change the quanitity 
            driver.FindElement(By.LinkText("Shopping Cart")).Click();
            return new ShoppingCartPage_PF(driver);

        }
    }


}
