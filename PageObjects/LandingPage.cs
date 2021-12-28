using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.PageObjects
{
    internal class LandingPage
    {
        IWebDriver driver=null;
        public LandingPage(IWebDriver driver)
        {
            this.driver=driver; 
        }

        By Username = By.XPath("//input[@id='user-name']");
        By Password = By.XPath("//input[@id='password']");
        By Login = By.Id("login-button");
        By Errormsg = By.CssSelector("h3[data-test='error']");
        By sign_in_S = By.XPath("//span[contains(text(),'Sign in')]");
        By TestcompletedCnt = By.CssSelector("p[class='ticker']");
        By PricingTag = By.XPath("(//div[@class='nav-menu-main-link'])[2]");
        By Logonext = By.XPath("(//a[@class='carousel-next'])[2]");
        By AcceptCookie = By.XPath("//button[@id='onetrust-accept-btn-handler']");
        By scroll = By.XPath("(//div[@class='link-list']/a[@class='button is-rounded is-primary'])[1]");
        By PlayButton = By.CssSelector("i[class='svg svg-video']");
        By YtPlayButton = By.ClassName("lty-playbtn");
        By Frame = By.CssSelector("iframe[title='Play']");
        By replayButton = By.XPath("//button[@aria-label='Replay']");
        By ClosePlayer = By.XPath("//button[@aria-label='close']");
        public string  replay = "//button[@aria-label='Replay']";


        public string expectedTitle = "Cross Browser Testing, Selenium Testing, Mobile Testing | Sauce Labs";
        public string cookie = "//button[@id='onetrust-accept-btn-handler']";

        public IWebElement getUserName()
        {
            return driver.FindElement(Username);
        }
        public IWebElement getPassword()
        {
            return driver.FindElement(Password);
        }
        public IWebElement getLoginButton()
        {
            return driver.FindElement(Login);
        }
        public IWebElement getErrormsg()
        {
            return driver.FindElement(Errormsg);
        }
        public IWebElement getSignin()
        {
            return driver.FindElement(sign_in_S);
        }
        public IWebElement getTestCompleted_cnt()
        {
            return driver.FindElement(TestcompletedCnt);
        }
        public IWebElement getPriceTag()
        {
            return driver.FindElement(PricingTag);
        }
        public List<string> getLogoList()
        {
            string[] logos = new string[] { "Visa logo", "Splunk logo", "Walmart logo", "Zillow logo",
          "Apollo Education Group Logo","DoorDash Logo","Stripe logo","Kaiser Permanente logo"
            ,"Labcorp 100px","Alaska Air logo","Deutsche Bank logo","Buzzfeed logo"};
            List<string> list = logos.OfType<string>().ToList();
            return list;


        }
        public IWebElement getLogonext()
        {
            return driver.FindElement(Logonext);
        }
        public IWebElement getAcceptCookie()
        {
            return driver.FindElement(AcceptCookie);
        }
        public IWebElement getScroll()
        {
            return driver.FindElement(scroll);
        }
        public IWebElement getPlayButton()
        {
            return driver.FindElement(PlayButton);
        }
        public IWebElement getYTPlayButton()
        {
            return driver.FindElement(YtPlayButton);
        }
        public IWebElement getFrame()
        {
            return driver.FindElement(Frame);
        }
        public IWebElement getReplayButton()
        {
            return driver.FindElement(replayButton);
        }
        public IWebElement getClosePlayer()
        {
            return driver.FindElement(ClosePlayer);
        }
    }
}
