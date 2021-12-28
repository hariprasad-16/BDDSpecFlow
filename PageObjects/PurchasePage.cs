using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    internal class PurchasePage
    {
        IWebDriver driver = null;
        public PurchasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By Checkout = By.Id("checkout");
        By firstName = By.Id("first-name");
        By lastName = By.Id("last-name");
        By Postalcode = By.Id("postal-code");
        By Proceed = By.Id("continue");
        By Finish = By.Id("finish");
        By Purchase_over = By.XPath("//h2[contains(text(),'THANK YOU FOR YOUR ORDER')]");
        By BacktoProducts = By.Id("back-to-products");
        public IWebElement getCheckout()
        {
            return driver.FindElement(Checkout);
        }
        public IWebElement getfirstname()
        {
            return driver.FindElement(firstName);
        }
        public IWebElement getLastname()
        {
            return driver.FindElement(lastName);
        }
        public IWebElement getPostalcode()
        {
            return driver.FindElement(Postalcode);
        }
        public IWebElement getProceed()
        {
            return driver.FindElement(Proceed);
        }
        public IWebElement getFinish()
        {
            return driver.FindElement(Finish);
        }
        public IWebElement getPurchaseOver()
        {
            return driver.FindElement(Purchase_over);
        }
        public IWebElement getBacktoProducts()
        {
            return driver.FindElement(BacktoProducts);
        }

    }
}
