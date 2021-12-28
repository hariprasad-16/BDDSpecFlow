using Assignment1.GenericHelper;
using Assignment1.PageObjects;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Assignment1
{
    [Binding]
    public class SauceLabs
    {
        ILog logger = Log4NetHelper.GetLog(typeof(SauceLabs));

        IWebDriver driver;

        LandingPage l = null;
        HomePage h = null;
        PurchasePage p = null;
        LoginPage login = null;
        PricingPage pp = null;
        DashBoard d = null;
        SelectElement element = null;
        String expectedDD = null;
        string expectedBversion = null;
        [Given(@"User navigates into the URL")]
        public void GivenUserNavigatesIntoTheURL()
        {
            driver = BaseClass.initWebDriver();
            driver.Navigate().GoToUrl(GenericHelper.GenericHelperClass.Url_S());
            l = new LandingPage(driver);
            logger.Info("Navigated to the URL");
            driver.Manage()
            .Timeouts()
            .ImplicitWait = TimeSpan.FromSeconds(15);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForCookie());
            l.getAcceptCookie().Click();

        }

        [When(@"User click on sign in button")]
        public void WhenUserClickOnSignInButton()
        {
            l = new LandingPage(driver);
            l.getSignin().Click();
            logger.Info("Clicked on signin");

        }

        [When(@"User enter a username ""(.*)"" and password ""(.*)""")]
        public void WhenUserEnterAUsernameAndPassword(string username, string password)
        {
            login = new LoginPage(driver);
            login.getUsername().SendKeys(username);
            login.getPassword().SendKeys(password);
            logger.Info("Entered username and password");

        }

        [When(@"User click on log-in button")]
        public void WhenUserClickOnSubmitButton()
        {
            login.getLogin().Click();
            logger.Info("Clicked on sign in");
        }

        [Then(@"verify that the user is logged in successfully")]
        public void ThenVerifyThatTheUserIsLoggedInSuccessfully()
        {
            string expectedUsername = "Owner: My Tests (Oauth-Hariprasad19990916-5afd2)";
            h = new HomePage(driver);
            driver.Manage()
           .Timeouts()
           .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForUserName());
            string actualUsername = h.getUsername_S().Text;
            Assert.AreEqual(expectedUsername, actualUsername);
            Console.WriteLine(actualUsername);
            logger.Info("Verified that user is logged in successfully");


        }
        [Then(@"Verify the test completed count is working")]
        public void ThenVerifyTheTestCompletedCountIsWorking()
        {
            l = new LandingPage(driver);
            String count1 = l.getTestCompleted_cnt().Text;
            Console.WriteLine(count1);
            Thread.Sleep(1000);
            String count2 = l.getTestCompleted_cnt().Text;
            Console.WriteLine(count2);
            Assert.AreNotEqual(count1, count2);
            logger.Info("Verified that test completion count is working");


        }

        [When(@"User click on price tag")]
        public void WhenUserClickOnPriceTag()
        {
            l = new LandingPage(driver);
            l.getPriceTag().Click();
            logger.Info("Clicked on price tag");

        }

        [When(@"user selected the ""([^""]*)"" parallel test from dropdown")]
        public void WhenUserSelectedTheParallelTestFromDropdown(string parallelTestno)
        {
            pp = new PricingPage(driver);
            Assert.IsTrue(pp.getParallelTestDD().Displayed);
            element = new SelectElement(pp.getParallelTestDD());
            element.SelectByValue(parallelTestno);
            expectedDD = parallelTestno;
            logger.Info("Selected parallel tests from drop down");



        }


        [Then(@"verify parallel test is selected successfully")]
        public void ThenVerifyParallelTestIsSelectedSuccessfully()
        {
            var actualDD = element.SelectedOption.GetAttribute("value");
            Console.WriteLine(actualDD);
            Assert.AreEqual(expectedDD, actualDD);
            logger.Info("verified parallel test is selected successfully");
        }
        [When(@"user change the pricing plan to Monthly")]
        public void WhenUserChangeThePricingPlanToMonthly()
        {
            pp = new PricingPage(driver);
            Console.WriteLine(driver.FindElement(By.XPath("//div[@class='switch']/label")).Text);
            pp.getPriceSwitch().Click();
            Console.WriteLine(driver.FindElement(By.XPath("//div[@class='switch']/label")).Text);
            logger.Info("User change the pricing plan to monthly");


        }
        [Then(@"verify the prie plan status is ""([^""]*)""")]
        public void ThenVerifyThePriePlanStatusIs(string pricePlanStatus)
        {
            string actualpriePlanStatus = pp.getPricePlan().Text;
            Console.WriteLine(actualpriePlanStatus);
            Assert.AreEqual(pricePlanStatus, actualpriePlanStatus);
            logger.Info("verified that price plan status");
        }
        [Then(@"verify the log's are displayed")]
        public void ThenVerifyTheLogsAreDisplayed()
        {
            l = new LandingPage(driver);
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            IWebElement e = driver.FindElement(By.XPath("(//div[@class='link-list']/a[@class='button is-rounded is-primary'])[1]"));
            je.ExecuteScript("arguments[0].scrollIntoView(true);", l.getScroll());
            Thread.Sleep(1000);
            int c = 0;
            Console.WriteLine(l.getLogonext().Displayed);
            List<string> logos = l.getLogoList();
            foreach (string str in logos)
            {

                c = c + 1;
                string xpathL = $"img[title='{str}']";
                if (c == 5 || c == 9)
                {

                    Console.WriteLine(l.getLogonext().Enabled);
                    l.getLogonext().Click();
                    Thread.Sleep(1000);
                    if (driver.FindElement(By.CssSelector(xpathL)).Displayed)
                    {
                        Console.WriteLine(driver.FindElement(By.CssSelector(xpathL)).GetAttribute("title"));
                    }
                }
                else
                {
                    if (driver.FindElement(By.CssSelector(xpathL)).Displayed)
                    {
                        Console.WriteLine(driver.FindElement(By.CssSelector(xpathL)).GetAttribute("title"));
                    }
                }


            }
            logger.Info("Verified that logo's are displayed");

        }
        [Then(@"verify user navigates to the URL successfully")]
        public void ThenVerifyUserNavigatesToTheURLSuccessfully()
        {
            string actualTitle = driver.Title;
            Assert.AreEqual(l.expectedTitle, actualTitle);
            logger.Info("verified that user navigates to the url");
        }

        [When(@"user click on play button")]
        public void WhenUserClickOnPlayButton()
        {
            l.getPlayButton().Click();
            logger.Info("User clicked video play button");
            l.getYTPlayButton().Click();
            logger.Info("User clicked on Youtube video play button");

        }
        [Then(@"verify the video is playing successfully")]
        public void ThenVerifyTheVideoIsPlayingSuccessfully()
        {
            driver.SwitchTo().Frame(l.getFrame());
            Console.WriteLine(driver.FindElement(By.ClassName("ytp-time-current")).Displayed);
            driver.Manage()
           .Timeouts()
           .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(7));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForVideoEnd());
            Console.WriteLine(l.getReplayButton().Displayed);
            if (l.getReplayButton().Displayed)
            {
                driver.SwitchTo().ParentFrame();
                l.getClosePlayer().Click();

            }
            logger.Info("Verified that video is playing successfully");

        }
        [When(@"user click on new live web test")]
        public void WhenUserClickOnNewLiveWebTest()
        {
            d = new DashBoard(driver);
            d.getLive().Click();
            d.getTestResults().Click();
            driver.Manage()
            .Timeouts()
            .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForTest());
            d.getNewWebTest().Click();
            logger.Info("user clicked on new web test");
        }
        [When(@"user selects browser")]
        public void WhenUserSelectsBrowser()
        {
            driver.Manage()
           .Timeouts()
           .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForStart());
            expectedBversion = d.getBrowser().Text;
            d.getBrowser().Click();
            logger.Info("User selects a browser and version");
        }
        [When(@"user start the new web test")]
        public void WhenUserStartTheNewWebTest()
        {
            d.getStartTest().Click();
            logger.Info("User starts the new web test");
        }
        [When(@"user takes the screenshot")]
        public void WhenUserTakesTheScreenshot()
        {
            driver.Manage()
           .Timeouts()
           .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForScreenshot());
            Thread.Sleep(10000);
            d.getScreenShot().Click();
            logger.Info("User clicked screenshot");
        }
        [When(@"user ends the test")]
        public void WhenUserEndsTheTest()
        {
            d.getEndTest().Click();
            logger.Info("User ends the test");
        }
        [Then(@"verify the test was completed successfully")]
        public void ThenVerifyTheTestWasCompletedSuccessfully()
        {
            d.getTestResults().Click();
            driver.Manage()
           .Timeouts()
           .ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NoSuchElementException));
            wait.Until(waitForBrowserVersion());
            Console.WriteLine(d.getBrowserVersion().Text);
            string actualBVersion = d.getBrowserVersion().Text;
            Assert.AreEqual(expectedBversion, actualBVersion);
            logger.Info("Verified the test was completed successfully");
        }





        private Func<IWebDriver, bool> waitForCookie()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For cookie to display");
                return x.FindElements(By.XPath(l.cookie)).Count == 1;


            });
        }


        private Func<IWebDriver, bool> waitForUserName()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For Username to display");
                return x.FindElements(By.XPath(h.username)).Count == 1;


            });
        }
        private Func<IWebDriver, bool> waitForVideoEnd()
        {
            return ((x) =>
            {
                //Console.WriteLine("Waiting For Video to complete");
                return x.FindElements(By.XPath(l.replay)).Count == 1;


            });
        }
        private Func<IWebDriver, bool> waitForTest()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For Test");
                return x.FindElements(By.XPath(d.NewTest)).Count == 1;


            });
        }
        private Func<IWebDriver, bool> waitForStart()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For start");
                return x.FindElements(By.CssSelector(d.startTest)).Count == 1;


            });
        }
        private Func<IWebDriver, bool> waitForScreenshot()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For screenshot");
                return x.FindElements(By.CssSelector(d.screenshot)).Count == 1;


            });
        }
        private Func<IWebDriver, bool> waitForBrowserVersion()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For browser version");
                return x.FindElements(By.XPath(d.browserVersion)).Count == 1;


            });
        }
    }
}
