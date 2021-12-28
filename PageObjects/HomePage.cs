using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver = null;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By Products = By.XPath("//span[contains(text(),'Products')]");
        By First_Product = By.XPath("(//div[@class='inventory_item_name'])[1]");
        By Product_Dropdown = By.ClassName("product_sort_container");
        By MenuButton = By.XPath("//button[@id='react-burger-menu-btn']");
        By Logout = By.XPath("//a[@id='logout_sidebar_link']");
        By Product_1 = By.Id("add-to-cart-sauce-labs-backpack");
        By Product_2 = By.Id("add-to-cart-sauce-labs-bike-light");
        By Purchase = By.CssSelector("a[class='shopping_cart_link']");
        By Username_S = By.XPath("(//div[@class='Filters__filter-text__1KiMt'])[1]");
        public string username = "(//div[@class='Filters__filter-text__1KiMt'])[1]";






        public IWebElement getProducts()
        {
            return driver.FindElement(Products);
        }
        public IWebElement getFirstProduct()
        {
            return driver.FindElement(First_Product);
        }
        public IWebElement getProductDropdown()
        {
            return driver.FindElement(Product_Dropdown);
        }
        public IWebElement getMenuButton()
        {
            return driver.FindElement(MenuButton);
        }
        public IWebElement getLogout()
        {
            return driver.FindElement(Logout);
        }
        public IWebElement getProduct_1()
        {
            return driver.FindElement(Product_1);
        }
        public IWebElement getProduct_2()
        {
            return driver.FindElement(Product_2);
        }
        public IWebElement getPurchase()
        {
            return driver.FindElement(Purchase);
        }
        public IWebElement getUsername_S()
        {
            return driver.FindElement(Username_S);
        }
    }
}
