using Assignment1.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Assignment1
{

   [Binding]
    public class StepDefinitions
    {
        IWebDriver driver;

        LandingPage l =null;
        HomePage h= null;
        string productName = null;
        string productName_After = null;
        PurchasePage p = null;



       [Given(@"user navigates to the url")]
        public void GivenNavigateToUrl()
        {

            driver = BaseClass.initWebDriver();
            driver.Navigate().GoToUrl(GenericHelper.GenericHelperClass.Url());
            

        }
        [Then(@"verify whether the home page is displayed with title ""(.*)""")]
        public void ThenVerifyWhetherTheHomePageIsDisplayedWithTitle(string title)
        {
            string pageTitle = driver.Title;
            Console.WriteLine(pageTitle);
            Assert.AreEqual(title, pageTitle);
        }
        [When(@"User enters username ""(.*)"" and password ""(.*)""")]
        public void WhenUserEntersUsernameAndPassword(string username, string password)
        {
            l = new LandingPage(driver);
            l.getUserName().SendKeys(username);
            l.getPassword().SendKeys(password);
            l.getLoginButton().Click(); 
        }
        [Then(@"verify the user is logged in successfully")]
        public void ThenVerifyTheUserIsLoggedInSuccessfully()
        {
            h=new HomePage(driver);
            try
            {
                string productsText=h.getProducts().Text;
                Console.WriteLine(productsText);
                
            }
            catch(Exception ex)
            {
                Assert.AreEqual("valid Credentials", "Invalid Credentials");
            }
          
        }

        [When(@"user selects first product before changing dropdown")]
        public void WhenUserSelectsFirstProductBeforeChangingDropdown()
        {
            h= new HomePage(driver);
            productName=h.getFirstProduct().Text;
            Console.WriteLine(productName);
        }
        [When(@"user changes the dropdown")]
        public void WhenUserChangesTheDropdown()
        {
            SelectElement select = new SelectElement(h.getProductDropdown());
            select.SelectByValue("za");
        }

        [When(@"user selects first product after changing dropdown")]
        public void WhenUserSelectsFirstProductAfterChangingDropdown()
        {
           productName_After=h.getFirstProduct().Text;
            Console.WriteLine(productName_After);
           
        }

        [Then(@"verify dropdown is working properly")]
        public void ThenVerifyDropdownIsWorkingProperly()
        {

            Assert.AreNotEqual(productName, productName_After);
            
        }
        [Then(@"User click on Logout")]
        public void ThenUserClickOnLogout()
        {
            h.getMenuButton().Click();
            h.getLogout().Click();
        }

        [Then(@"verify user logged out successfully")]
        public void ThenVerifyUserLoggedOutSuccessfully()
        {
            bool status=false;
            try
            {
                status = l.getLoginButton().Displayed;
                Assert.IsTrue(status);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(status);
            }

        }

        [When(@"User added products to cart")]
        public void WhenUserAddedProductsToCart()
        {
            h.getProduct_1().Click();
            h.getProduct_2().Click();
        }

        [When(@"User click on purchase")]
        public void WhenUserClickOnPurchase()
        {
            h.getPurchase().Click();
        }

        [When(@"user click on checkout")]
        public void WhenUserClickOnCheckout()
        {
            p = new PurchasePage(driver);
            p.getCheckout().Click();
           
          
        }

        [When(@"user fill the form and click on continue")]
        public void WhenUserFillTheFormAndClickOnContinue()
        {
            p.getfirstname().SendKeys("john");
            p.getLastname().SendKeys("j");
            p.getPostalcode().SendKeys("123");
            p.getProceed().Click();
        }

        [When(@"User click on finish")]
        public void WhenUserClickOnFinish()
        {
            p.getFinish().Click();
        }

        [Then(@"verify purchase is completed successfully")]
        public void ThenVerifyPurchaseIsCompletedSuccessfully()
        {
            string purchaseStatus_expected = "THANK YOU FOR YOUR ORDER";
            string purchasestatus=p.getPurchaseOver().Text;
            Console.WriteLine(purchasestatus);
            Assert.AreEqual(purchasestatus, purchaseStatus_expected);

        }

    }
}
