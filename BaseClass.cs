using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Assignment1
{
    public class BaseClass
    {
        static IWebDriver webDriver;
        public static ChromeOptions getChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            return options;
        }
        public static IWebDriver initWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver(getChromeOptions());
            webDriver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(55);
            webDriver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);
            return webDriver;
        }

        public static void tearDown()
        {
            webDriver.Close();

        }
    }
}
