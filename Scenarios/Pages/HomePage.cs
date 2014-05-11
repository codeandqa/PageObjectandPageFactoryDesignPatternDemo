using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Scenario_ShoppingCart.Scenarios.Pages
{
    public class HomePage : HelperClass
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        public AlertPage selectItem(IWebDriver driver)
        {

            //Click on Computer Tab.
            driver.FindElement(By.CssSelector("div[id='product-presenter']>ul[id='category-names']>li:nth-child(2)")).Click();
            WaitForVisibleElement("div[id='product-container'][style='display: block;']");
            IWebElement rows = driver.FindElement(By.CssSelector("div[id='product-container'][style='display: block;']"));
            //click on add to cart button.
            rows.FindElement(By.CssSelector("input[class='btn btn-success addtocart-button']")).Click();
            return new AlertPage(driver);
        }


    }

}
