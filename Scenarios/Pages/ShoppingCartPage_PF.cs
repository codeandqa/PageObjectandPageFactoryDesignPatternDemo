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
    public class ShoppingCartPage_PF : HelperClass
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "input[class='quantity-input js-recalculate']")]
        [CacheLookup]
        private IWebElement quantityField;

        [FindsBy(How = How.Name, Using = "checkout")][CacheLookup]
        private IWebElement checkoutButton;

        [FindsBy(How = How.CssSelector, Using = "input[class='refresh-icon']")]
        [CacheLookup]
        private IWebElement refreshIcon;

        [FindsBy(How = How.CssSelector, Using = "div[class='message']")]
        [CacheLookup]
        private IWebElement emptyCartMsg;

        [FindsBy(How = How.CssSelector, Using = "input[value='Log out']")]
        [CacheLookup]
        private IWebElement logoutBtn;

        public ShoppingCartPage_PF(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Assert.AreEqual("Shopping cart", driver.Title);
        }

        public void verifyCartWithItems()
        {
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            WaitForVisibleElement("div[class='price-type']");
        }

        public YourAccountDetailPage_PF ProceedToCheckoutNow()
        {
            //Wait for Shopping Cart.Click on Checkout now button.
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            string qantity = quantityField.GetAttribute("value");
            Assert.AreEqual("1", qantity);
            checkoutButton.Click();
            return new YourAccountDetailPage_PF(driver);
        }

        public ShoppingCartPage_PF EmptyCart()
        {
            //Clear the cart. 
            quantityField.Clear();
            quantityField.SendKeys("0");
            refreshIcon.Click();

            //Verify empty Shopping Cart.
            WaitForVisibleElement("div[class='message']");
            Assert.AreEqual("There are no products in your cart.", emptyCartMsg.Text);
            return this;
        }

        public ShoppingCartPage_PF Logout()
        {
            //logout.
            logoutBtn.Click();
            //Wait for login/password input field appeared after click.
            WaitForVisibleElement("input[id='modlgn-username']");
            return this;
        }

       
    }

    
}
