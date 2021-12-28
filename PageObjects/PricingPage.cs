using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    internal class PricingPage
    {
        IWebDriver driver = null;
        public PricingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By parallelTestDD = By.XPath("//p[@class='plan-select']/select[@class='browser-default']");
        By PricingCheckBox = By.XPath("//div[@class='switch']/label/input[@type='checkbox']");
        By PriceSwitch = By.ClassName("lever");
        By PlanStatus = By.XPath("(//span[contains(text(),'Billed monthly')])[1]");

        public IWebElement getParallelTestDD()
        {
            return driver.FindElement(parallelTestDD);
        }
        public IWebElement getPricingCheckBox()
        {
            return driver.FindElement(PricingCheckBox);
        }
        public IWebElement getPriceSwitch()
        {
            return driver.FindElement(PriceSwitch);
        }
        public IWebElement getPricePlan()
        {
            return driver.FindElement(PlanStatus);
        }
    }
}
