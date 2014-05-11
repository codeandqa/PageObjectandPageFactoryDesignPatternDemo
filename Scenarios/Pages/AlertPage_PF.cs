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
    public class AlertPage_PF : HelperClass
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "facebox")]
        private IWebElement alert;

        public AlertPage_PF(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ShoppingCartPage_PF ClickOnShowCart()
        {
            //wait for alert screen and click on Show Cart link.
            WaitForVisibleElement("div[id='facebox']");
            alert.FindElement(By.LinkText("Show Cart")).Click();
            return new ShoppingCartPage_PF(driver);
        }
    }


}
