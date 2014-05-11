using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
namespace Scenario_ShoppingCart.Scenarios
{
   [TestClass()]
    public partial class Scenarios_Demo
    {

       private IWebDriver driver;
       private string baseURL;
        
       [TestInitialize]
       public void SetupTest()
        {
            string extension = @"C:\Users\Aditya\Documents\Visual Studio 2013\Projects\Scenario_ShoppingCart\packages\firebug.xpi";
            FirefoxProfile ffProfile = new FirefoxProfile();
            ffProfile.AddExtension(extension);
            driver = new FirefoxDriver(ffProfile);
            baseURL = "http://demo.virtuemart.net";
            driver.Navigate().GoToUrl(baseURL + "/");
        }
       [TestCleanup]
       public void CleanUpTest()
        {
            driver.Close();
            driver.Dispose();
        }

       public void WaitForVisibleElement(string locator)
        {
            //Wait for Shopping cart Page. Verify Items. and click on checkout button.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
        }
        

    }

   
}
