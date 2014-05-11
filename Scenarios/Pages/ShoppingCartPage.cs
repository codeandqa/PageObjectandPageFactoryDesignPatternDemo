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
    public class ShoppingCartPage : HelperClass
    {
        IWebDriver driver;
        public ShoppingCartPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            Assert.AreEqual("Shopping cart", driver.Title);
        }

        public void verifyCartWithItems()
        {
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            WaitForVisibleElement("div[class='price-type']");
        }

        public YourAccountDetailPage ProceedToCheckoutNow()
        {
            //Wait for Shopping Cart.Click on Checkout now button.
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            string qantity = driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).GetAttribute("value");
            Assert.AreEqual("1", qantity);
            driver.FindElement(By.Name("checkout")).Click();
            return new YourAccountDetailPage(driver);
        }

        public ShoppingCartPage EmptyCart()
        {
            //Clear the cart. 
            driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).Clear();
            driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).SendKeys("0");
            driver.FindElement(By.CssSelector("input[class='refresh-icon']")).Click();

            //Verify empty Shopping Cart.
            WaitForVisibleElement("div[class='message']");
            Assert.AreEqual("There are no products in your cart.", driver.FindElement(By.CssSelector("div[class='message']")).Text);
            return this;
        }

        public ShoppingCartPage Logout()
        {
            //logout.
            driver.FindElement(By.CssSelector("input[value='Log out']")).Click();
            //Wait for login/password input field appeared after click.
            WaitForVisibleElement("input[id='modlgn-username']");
            return this;
        }
    }
    
}
