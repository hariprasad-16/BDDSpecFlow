using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace Assignment1.GeneralHooks
{
    [Binding]
    public sealed class Hooks1
    {
        public static ScenarioContext _sc;
        private static FeatureContext fc;
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            htmlReporter = new ExtentHtmlReporter(@"D:\ReportVS\");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

        }

        [BeforeFeature]
        public static void Beforefeaturestart(FeatureContext fc)
        {
            if (null != fc)
            {
                _feature = extentReports.CreateTest<Feature>(fc.FeatureInfo.Title, fc.FeatureInfo.Description);
            }
        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext sc)
        {
            _sc = sc;
            _scenario = _feature.CreateNode<Scenario>(sc.ScenarioInfo.Title, sc.ScenarioInfo.Description);
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {

        }

        [AfterStep]
        public void Afterstep()
        {
            ScenarioBlock scenarioBlock = _sc.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();

                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }

        }
        public void CreateNode<T>() where T : IGherkinFormatterModel
        {

            if (_sc.TestError != null)
            {

                _scenario.CreateNode<T>(_sc.StepContext.StepInfo.Text).Fail(_sc.TestError.Message + "\n" + _sc.TestError.StackTrace);


            }
            else
            {
                _scenario.CreateNode<T>(_sc.StepContext.StepInfo.Text).Pass("");
            }
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            BaseClass.tearDown();
        }
        [AfterTestRun]
        public static void AftertestRun()
        {
            extentReports.Flush();
        }
    }
}