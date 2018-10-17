using BAF.StepDefinitions;
using BAF.Utilities;
using BoDi;
using HP.LFT.Report;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace BAF

{
    [Binding]
    public class TestInitiator : Steps
    {
        private readonly IObjectContainer _objectContainer;
        protected IWebDriver WebDriver;
        private BrowserDriverType _browserDriverType;
        protected ProductPlanSteps productPlan;
        protected QPTSteps QPT;
        public static ExtentReports extent;
        public static ExtentTest test;
        //public static ScreenCaptureJob scj;
        protected readonly string HubUri = BAF.Properties.Settings.Default.Remote_VDISE01065;
        public static IDictionary<string, string> dependsOnScenario = new Dictionary<string, string>();

        public TestInitiator(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /*============================================================================================================================================
                                                                TEST SETUP DELEGATES
        ==============================================================================================================================================*/
        [BeforeTestRun, Order(1)]
        public static void CleanEnvironment() => _cleanUpEnvironmentProcessesAndFolders();

        [BeforeTestRun, Order(3)]
        public static void ReadTestDataFromExcel() => _readTestDataFromExcel();
        [BeforeTestRun, Order(3)]
        public static void ReportStartUp() => _configureReport();

        [BeforeScenario, Order(1)]
        public void ReportGenerationStartUp() => _startReport();

        //[BeforeScenario, Order(2)]
        //public void VideoStartUp() => _startVideo();

        [BeforeScenario, Order(3)]
        public void BrowserSetup() => _configureBrowser();

        [AfterStep]
        public void RunLog() => _reportStepLog();

        [AfterScenario, Order(1)]
        public void ShutDown() => _cleanUp();

        [AfterTestRun, Order(1)]
        public static void ReportShutDown() => _endReport();

        /*============================================================================================================================================
                                                                  TEST SETUP METHODS
        ==============================================================================================================================================*/
        public static void _cleanUpEnvironmentProcessesAndFolders()
        {
            string imageFilesToDelete = @"*.Jpeg";
            string videoFilesToDelete = @"*.wmv";
            string projectPath = System.IO.Directory.GetCurrentDirectory();
            string deleteScreensFolderPath = projectPath + "\\BAF\\Reports\\Screens\\";
            string deleteVideosFolderPath = projectPath + "\\BAF\\Reports\\Videos\\";
            string[] imageFileList = System.IO.Directory.GetFiles(deleteScreensFolderPath, imageFilesToDelete);
            string[] videoFileList = System.IO.Directory.GetFiles(deleteVideosFolderPath, videoFilesToDelete);


            try
            {
                foreach (Process process in Process.GetProcessesByName("chromedriver"))
                {
                    //kill the process 
                    process.Kill();
                }

                foreach (Process process in Process.GetProcessesByName("EXCEL"))
                {
                    //kill the process 
                    process.Kill();
                }

                foreach (string file in imageFileList)
                {
                    System.IO.File.Delete(file);
                }
                foreach (string file in videoFileList)
                {
                    System.IO.File.Delete(file);
                }

            }
            catch (Exception ex)
            {
                //show the exceptions if any here
                Console.WriteLine(ex.ToString());
            };

        }

        public static void _readTestDataFromExcel()
        {
            string testDataPath = System.IO.Directory.GetCurrentDirectory() + "\\BAF\\Resources\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(testDataPath);
        }
        public static void _configureReport()
        {
            string Ereportspath = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\BAF\Reports\";
            string projectPath = System.IO.Directory.GetCurrentDirectory();
            string reportPath = Ereportspath + "Report.html";
            extent = new ExtentReports(reportPath, true);

            extent
          .AddSystemInfo("Host Name", "Chiranth")
          .AddSystemInfo("Environment", "devtest2")
          .AddSystemInfo("User Name", "TEMPCHURS");
            extent.LoadConfig(projectPath + "extent-config.xml");
        }

        public static void _startReport()
        {
            test = extent.StartTest(ScenarioContext.Current.ScenarioInfo.Title.ToString());

        }
        //public void _startVideo()

        //{
        //    var Video = BAF.Properties.Settings.Default.UseVideoRecording;
        //    if (Video)
        //    {
        //        scj = new ScreenCaptureJob();
        //        string timestamp = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        //        string VideoFolderPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\BAF\Reports\Videos\";
        //        scj.OutputScreenCaptureFileName = VideoFolderPath + ScenarioContext.Current.ScenarioInfo.Title.ToString() + "_" + timestamp + ".wmv";
        //        scj.Start();
        //    }
        //}
        public void _reportStepLog()
        {
            test.Log(LogStatus.Info, ScenarioContext.StepContext.StepInfo.Text.ToString(), "INFO");
            Reporter.ReportEvent(ScenarioContext.StepContext.StepInfo.Text.ToString(), "INFO", HP.LFT.Report.Status.Passed);
            System.Environment.SetEnvironmentVariable("CurrentExecutionStep", ScenarioContext.StepContext.StepInfo.Text.ToString());
        }

        public void _configureBrowser()
        {

            var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            var featureTags = FeatureContext.Current.FeatureInfo.Tags;
            var featureDescription = FeatureContext.Current.FeatureInfo.Description;
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            var scenarioTags = ScenarioContext.Current.ScenarioInfo.Tags.ToString();

            test.Log(LogStatus.Info, "I am running the Feature: '" + featureTitle + "' ", "INFO");
            test.Log(LogStatus.Info, "I am running the Scenario: '" + scenarioTitle + "' ", "INFO");

            if (scenarioTitle.ToLower().Contains("chrome"))
            {
                test.Log(LogStatus.Info, "I have selected my browser as Chrome", "INFO");
                _selectBrowser(BrowserDriverType.Chrome);
            }
            else if (scenarioTitle.ToLower().Contains("firefox"))
            {
                test.Log(LogStatus.Info, "I have selected my browser as Firefox", "INFO");
                _selectBrowser(BrowserDriverType.Firefox);
            }
            else if (scenarioTitle.ToLower().Contains("qpt"))
            {
                test.Log(LogStatus.Info, "I have selected QPT", "INFO");
                _selectBrowser(BrowserDriverType.QPT);
            }
            else if (scenarioTitle.ToLower().Contains("hmorder"))
            {
                test.Log(LogStatus.Info, "I have selected HM ORDER", "INFO");
                _selectBrowser(BrowserDriverType.HMOrder);
            }
            else
            {
                test.Log(LogStatus.Fatal, "Oops!!...The browser is not specified for scenario title:  '" + scenarioTitle + "'", "INFO");
                Assert.Fail("Oops!!...The browser is not specified for scenario title:  '" + scenarioTitle + "'");
            }

        }
        public void _selectBrowser(BrowserDriverType browserDriverType)
        {
            _browserDriverType = browserDriverType;
            IWebDriver webDriver = null;
            {
                var useRemoteGrid = BAF.Properties.Settings.Default.UseRemoteGrid;
                if (useRemoteGrid)
                {
                    switch (_browserDriverType)
                    {
                        case BrowserDriverType.Chrome:
                            webDriver = new RemoteWebDriver(new Uri(HubUri), new ChromeOptions().ToCapabilities());
                            break;

                        case BrowserDriverType.Firefox:
                            var firefoxOptions = new FirefoxOptions
                            {
                                UseLegacyImplementation = true,
                                BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe",
                                Profile = new FirefoxProfile()
                            };
                            webDriver = new RemoteWebDriver(new Uri(HubUri), firefoxOptions.ToCapabilities());
                            webDriver.Manage().Cookies.DeleteAllCookies();
                            webDriver.Manage().Window.Maximize();
                            break;
                    }
                }
                else
                {
                    switch (_browserDriverType)
                    {
                        case BrowserDriverType.Chrome:
                            webDriver = new ChromeDriver();
                            webDriver.Manage().Cookies.DeleteAllCookies();
                            webDriver.Manage().Window.Maximize();
                            test.Log(LogStatus.Info, "I have launched the Chrome browser Successfully", "INFO");
                            break;

                        case BrowserDriverType.Firefox:
                            var options = new FirefoxOptions
                            {
                                UseLegacyImplementation = true,
                                BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe",
                                Profile = new FirefoxProfile()
                            };
                            webDriver = new FirefoxDriver(options);
                            webDriver.Manage().Cookies.DeleteAllCookies();
                            webDriver.Manage().Window.Maximize();
                            test.Log(LogStatus.Info, "I have launched the Firefox browser Successfully", "INFO");
                            break;

                        case BrowserDriverType.QPT:
                            ChromeOptions option = new ChromeOptions();
                            option.AddArgument("--headless");
                            webDriver = new ChromeDriver(option);
                            webDriver.Manage().Cookies.DeleteAllCookies();
                            Process QPT = Process.Start(@"C:\\Program Files (x86)\\H & M Hennes & Mauritz AB\\H & M QPT Client\\HM.Plan.QPT.Client.UI.WPF.exe");
                            test.Log(LogStatus.Info, "I have launched QPT Successfully", "INFO");
                            break;

                        case BrowserDriverType.HMOrder:
                            ChromeOptions option1 = new ChromeOptions();
                            option1.AddArgument("--headless");
                            webDriver = new ChromeDriver(option1);
                            webDriver.Manage().Cookies.DeleteAllCookies();
                            Process HMOrder = Process.Start("C:\\Program Files (x86)\\H & M Hennes & Mauritz AB\\HMOrder Client\\HM.HMOrder.ManagerClient.UserInterface.Windows.exe");
                            test.Log(LogStatus.Info, "I have launched HM ORDER Successfully", "INFO");
                            break;
                    }
                }

            }
            WebDriver = webDriver;
            var firingDriver = new EventFiringWebDriver(WebDriver);
            _objectContainer.RegisterInstanceAs<IWebDriver>(WebDriver);
            _initPages();
        }
        private void _initPages()
        {
            productPlan = new ProductPlanSteps(WebDriver);

        }

        public static void _endReport()
        {
            extent.Flush();
        }
        //public void _endVideo()
        //{
        //    var Video = BAF.Properties.Settings.Default.UseVideoRecording;
        //    if (Video)
        //    {
        //        scj.Stop();
        //    }
        //}
        public void _cleanUp()
        {

            if (!(dependsOnScenario.ContainsKey(ScenarioContext.Current.ScenarioInfo.Title)))
            {
                dependsOnScenario.Add(ScenarioContext.Current.ScenarioInfo.Title, TestContext.CurrentContext.Result.Outcome.ToString());
            }
            _takeScreenshot(WebDriver);
            WebDriver?.Dispose();
            //_endVideo();
        }

        private void _takeScreenshot(IWebDriver driver)
        {
            var ScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            var testresult = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().ToLower().Contains("fail"))
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    var bytes = Convert.FromBase64String(screenshot);
                    string timestamp = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                    var imageName = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                    using (var image = new FileStream(
                        $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\BAF\Reports\Screens\{imageName}.Jpeg",
                        FileMode.Create))
                    {
                        image.Write(bytes, 0, bytes.Length);
                        image.Flush();
                    }

                    var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                    var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                    test.Log(LogStatus.Fail, "'" + System.Environment.GetEnvironmentVariable("CurrentExecutionStep") + "' step has failed due to =====>", test.AddScreenCapture($@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\Reports\Screens\{imageName}.Jpeg"));
                    test.Log(LogStatus.Error, errorMessage + stackTrace, "EXCEPTION");

                    Reporter.ReportEvent(System.Environment.GetEnvironmentVariable("CurrentExecutionStep"), "FAIL", HP.LFT.Report.Status.Failed);
                    //Reporter.GenerateReport();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status.ToString().ToLower().Contains("skip"))
            {
                test.Log(LogStatus.Skip, "Scenario: '" + ScenarioTitle + "' has skipped due to failure of its dependent scenarios", "SKIPPED");

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status.ToString().ToLower().Contains("pass"))
            {
                test.Log(LogStatus.Pass, "Scenario: '" + ScenarioTitle + "' has passed", "PASS");
                Reporter.ReportEvent("Scenario: '" + ScenarioTitle + "' has passed", "PASS", HP.LFT.Report.Status.Passed);
            }
            else
            {
                test.Log(LogStatus.Unknown, "Scenario: '" + ScenarioTitle + "' status is Unknown", "UNKNOWN");
                Reporter.ReportEvent("Scenario: '" + ScenarioTitle + "' status is unknown", "PASS", HP.LFT.Report.Status.Warning);
            }
            extent.EndTest(test);
        }
    }
    public enum BrowserDriverType
    {
        Chrome,
        Firefox,
        QPT,
        HMOrder
    }

}


