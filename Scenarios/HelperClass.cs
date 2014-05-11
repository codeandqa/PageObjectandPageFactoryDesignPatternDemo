using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Scenario_ShoppingCart.Scenarios.Pages;
namespace Scenario_ShoppingCart.Scenarios
{
    /// <summary>
    /// This Class is to have all helpmer methods like wait for elements/verify etc.
    /// </summary>
    public class HelperClass
    {
        IWebDriver driver;
        public HelperClass(IWebDriver driver)
        {
            this.driver = driver;
        }

        ///<summary>
        ///This method is to wait for an element to be visible.
        ///<param name="locator">CssSelector: e.g.: "div[class='foo']"</param>
        ///</summary>
        public void WaitForVisibleElement(string locator)
        {
            //Wait for Shopping cart Page. Verify Items. and click on checkout button.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
        }
    }


    
}
