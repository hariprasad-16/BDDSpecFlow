using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver = null;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

       
        By username = By.Id("idToken1");
        By password=By.Id("idToken2");
        By login = By.Id("loginButton_0");
  





        public IWebElement getUsername()
        {
            return driver.FindElement(username);
        }
        public IWebElement getPassword()
        {
            return driver.FindElement(password);
        }
        public IWebElement getLogin()
        {
            return driver.FindElement(login);
        }
    }
}
