using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    internal class DashBoard
    {
        IWebDriver driver = null;
        public DashBoard(IWebDriver driver)
        {
            this.driver = driver;
        }

        By Live = By.CssSelector("div[data-qa='sidebar-list-live']");
        By TestResults = By.XPath("(//li[@data-qa='sidebar-item-test_results'])[1]");
        By NewWebTest = By.XPath("//button[contains(text(),'New Live Web Test')]");
        By Browser = By.XPath("(//ul[@class='ManualList__container__AGKIk']/li/a[contains(text(),94)])[2]");
        By StartTest = By.CssSelector("button[data-qa='configs-container-start-test-button']");
        By TakeScreenshot = By.CssSelector("button[id='toolbar-button-screenshot']");
        By EndTest = By.CssSelector("button[data-qa='toolbar-btn-press-stop-session']");
        By BrowserVersion = By.XPath("(//span[@class='DSIconBrowser__version__18oRG'])[1]");

        public string NewTest = "//button[contains(text(),'New Live Web Test')]";
        public string startTest = "button[data-qa='configs-container-start-test-button']";
        public string screenshot = "button[id='toolbar-button-screenshot']";
        public string browserVersion = "(//span[@class='DSIconBrowser__version__18oRG'])[1]";

        public IWebElement getLive()
        {
            return driver.FindElement(Live);
        }
        public IWebElement getTestResults()
        {
            return driver.FindElement(TestResults);
        }
        public IWebElement getNewWebTest()
        {
            return driver.FindElement(NewWebTest);
        }
        public IWebElement getBrowser()
        {
            return driver.FindElement(Browser);
        }
        public IWebElement getStartTest()
        {
            return driver.FindElement(StartTest);
        }
        public IWebElement getScreenShot()
        {
            return driver.FindElement(TakeScreenshot);
        }
        public IWebElement getBrowserVersion()
        {
            return driver.FindElement(BrowserVersion);
        }
        public IWebElement getEndTest()
        {
            return driver.FindElement(EndTest);
        }


    }
}