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
    public class AlertPage : HelperClass
    {
        IWebDriver driver;
        public AlertPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        public ShoppingCartPage ClickOnShowCart()
        {

            //------------------Alert Page with other info. (I am considering this as page as there are other action we can perform on that alert)---------------------//
            //wait for alert screen and click on Show Cart link.
            WaitForVisibleElement("div[id='facebox']");
            WebDriverWait wt = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            IWebElement alert = driver.FindElement(By.Id("facebox"));
            alert.FindElement(By.LinkText("Show Cart")).Click();
            return new ShoppingCartPage(driver);
        }
    }

}
