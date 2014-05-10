using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Scenario_ShoppingCart.Scenarios
{
    public partial class Scenarios_Demo
    {
        [TestMethod]
        public void VerifyShoppingCartBehavior1()
        {
                        
            #region Home page
            //Open URL
            driver.Navigate().GoToUrl(baseURL + "/");
            //Click on Computer Tab.
            driver.FindElement(By.CssSelector("div[id='product-presenter']>ul[id='category-names']>li:nth-child(2)")).Click();
            System.Threading.Thread.Sleep(2000);
            #endregion
            
            #region Item Page.
            //Get the first row from the computer Item grid.
            IWebElement rows = driver.FindElement(By.CssSelector("div[id='product-container'][style='display: block;']")); 
            //click on add to cart button.
            rows.FindElement(By.CssSelector("input[class='btn btn-success addtocart-button']")).Click();
            
            //------------------Alert Page with other info. (I am considering this as page as there are other action we can perform on that alert)---------------------//
            //wait for alert screen and click on Show Cart link.
            System.Threading.Thread.Sleep(2000);
            IWebElement alert = driver.FindElement(By.Id("facebox"));
            alert.FindElement(By.LinkText("Show Cart")).Click();
            #endregion

            #region Shopping Cart Page.
            //Wait for Shopping Cart.Click on Checkout now button.
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            string qantity = driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).GetAttribute("value");
            Assert.AreEqual("1", qantity);
            driver.FindElement(By.Name("checkout")).Click();
            //------------------Your Account Details Page.---------------------//
            #endregion

            #region Your Account Details Page.
            //wait for your Account Detail Page. Enter Demo demo and click login. return as 
            WaitForVisibleElement("div[class='vm-login-form']");
            driver.FindElement(By.Name("username")).SendKeys("demo");
            driver.FindElement(By.Name("password")).SendKeys("demo" + Keys.Enter);
            
            //------------------Your Account Details Page.---------------------//
            //wait for login greeting text that you are logged in.
            WaitForVisibleElement("div[class='login-greeting']");
            //Verify the Hi demo text as greeting. 
            Assert.AreEqual("Hi demo,", driver.FindElement(By.CssSelector("div[class='login-greeting']")).Text);
            
            //VerifyAccount detail Page. CLick on Shopping Cart Link on the page. Change the quanitity 
            driver.FindElement(By.LinkText("Shopping Cart")).Click();
            #endregion
            
            //Verify Shopping Cart Page. with Item.
            #region Shopping Cart Page.
            Assert.AreEqual("Shopping cart", driver.Title);
            WaitForVisibleElement("div[id='rt-mainbody-custom']");
            WaitForVisibleElement("div[class='price-type']");

            //Clear the cart. 
            driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).Clear();
            driver.FindElement(By.CssSelector("input[class='quantity-input js-recalculate']")).SendKeys("0");
            driver.FindElement(By.CssSelector("input[class='refresh-icon']")).Click();
            
            //Verify empty Shopping Cart.
            WaitForVisibleElement("div[class='message']");
            Assert.AreEqual("There are no products in your cart.", driver.FindElement(By.CssSelector("div[class='message']")).Text);
            
            //logout.
            driver.FindElement(By.CssSelector("input[value='Log out']")).Click();
            //Wait for login/password input field appeared after click.
            WaitForVisibleElement("input[id='modlgn-username']");
            #endregion
        }
    }
}
