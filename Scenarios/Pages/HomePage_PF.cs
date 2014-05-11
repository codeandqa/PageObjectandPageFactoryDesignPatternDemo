using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Scenario_ShoppingCart.Scenarios.Pages
{
    public class HomePage_PF : HelperClass
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "div[id='product-presenter']>ul[id='category-names']>li:nth-child(2)")]
        private IWebElement computerTab;

        [FindsBy(How = How.CssSelector, Using = "div[id='product-container'][style='display: block;']")]
        private IWebElement firstComptuerItemInGrid;

        [FindsBy(How = How.CssSelector, Using = "input[class='btn btn-success addtocart-button']")]
        private IWebElement AddCartButton;

        public HomePage_PF(IWebDriver driver): base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public AlertPage_PF selectItem(IWebDriver driver)
        {

            //Click on Computer Tab.
            computerTab.Click();
            WaitForVisibleElement("div[id='product-container'][style='display: block;']");
            //click on add to cart button.
            firstComptuerItemInGrid.FindElement(By.CssSelector("input[class='btn btn-success addtocart-button']")).Click();
            //AddCartButton.Click();
            return new AlertPage_PF(driver);
        }


    }

}
