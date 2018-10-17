using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NewLanding.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Interfaces;
using System.IO;
using RelevantCodes.ExtentReports;

namespace NewLanding
{
    [TestFixture]

    public class TestRun
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;
        public ChromeOptions opt;
        public Actions act;
        public ExtentReports extent;
        public ExtentTest test;
        string formatedBegin;
        string formatedEnd;
        string expected1, expected2, expected3, expected4, expected5, expected6, expected7;

        #region +++++Test initialization+++++
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            CheckTestdataDirectory();
            string reportPath = @"C:\TestData\TestReport.html";
            extent = new ExtentReports(reportPath, true);
            extent.AddSystemInfo("Environment", System.Environment.OSVersion.ToString() + "<br>Processors count "+System.Environment.ProcessorCount.ToString() + "<br>Windows 8.1,  Chrome, x64OS")
                  .AddSystemInfo("Username", System.Environment.UserName.ToString());
            
        }

        [SetUp]
        public void Setup()
        {
            formatedBegin = $"<font color='blue'><kbd>Test case {TestContext.CurrentContext.Test.Name} started</kbd></font>";
            formatedEnd = $"<font color='blue'><kbd>Test case {TestContext.CurrentContext.Test.Name} ended</kbd></font>";
            //opt = new ChromeOptions();
            //opt.AddArguments("--headless");
            
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            if (status == TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, status + errorMessage);
            }
            extent.EndTest(test);

            //this.Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
            extent.Close();
        }
        #endregion

        #region =====MainPage basic tests=====
        [Test, Category("MainPage")]
        public void Features()
        {
            #region Expected strings
            expected1 = "Professional Online Trading Software | Quantower — Quantower trading platform";
            expected2 = "Prices & Licenses — Quantower trading platform";
            expected3 = "List of available connections and data providers — Quantower trading platform";
            expected4 = "Quantower roadmap - features that coming soon — Quantower trading platform";
            expected5 = "B2B solutions for your business — Quantower trading platform";
            expected6 = "News and updates — Quantower trading platform";
            #endregion

            test = extent.StartTest("Features");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            NewHomepage newpage = new NewHomepage(this.Driver);
            //Clicking on features, then we do assertions and go to previous page (Main page) 
            Driver.FindElement(newpage.featuresLink).Click();
            Assertions(expected1, "Features page", "Current page is not a FEATURES");
            Driver.Navigate().Back();

            //Clicking on pricing, then we do assertions and go to previous page (Main page) 
            Driver.FindElement(newpage.pricingLink).Click();
            Assertions(expected2, "Pricing page", "Current page is not a PRICING");
            //Assert.AreEqual(expected2, this.driver.Title);
            Driver.Navigate().Back();

            //Clicking on connections, then we do assertions and go to previous page(Main page)
            Driver.FindElement(newpage.connectionsLink).Click();
            Assertions(expected3, "Connections page", "Current page is not a CONNECTIONS");
            Driver.Navigate().Back();

            //Clicking on roadmap, then we do assertions and go to previous page(Main page)
            Driver.FindElement(newpage.roadmapLink).Click();
            Assertions(expected4, "Roadmap page", "Current page is not a ROADMAP");
            Driver.Navigate().Back();

            //Clicking on B2B, then we do assertions and go to previous page (Main page)
            Driver.FindElement(newpage.btbLink).Click();
            Assertions(expected5, "B2B page", "Current page is not a B2B");
            Driver.Navigate().Back();

            //Clicking on blog, then we do assertions
            Driver.FindElement(newpage.blogLink).Click();
            Assertions(expected6, "Blog page", "Current page is not a BLOG");
            test.Log(LogStatus.Info, formatedEnd);

            //Yippee-ki-yay!!! We did it ;)
        }

        [Test, Category("MainPage")]
        public void DownloadBtnCheck()
        {
            test = extent.StartTest("DownloadBtnCheck");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            NewHomepage page = new NewHomepage(this.Driver);
            
            try
            {
                Assert.IsNotNull(Driver.FindElement(page.downloadBtn));
                //Expected result was changed for making test fail. Under normal conditions should be "GET THE PLATFORM"
                Assert.AreEqual("GET THE APP", Driver.FindElement(page.downloadBtn).Text);
                test.Log(LogStatus.Pass, "<font color='green'><b>Download button exist & text displays normally</b></font>");
            }
            catch { test.Log(LogStatus.Fail, "<font color='red'><b>Download button is null</font>"); }
            test.Log(LogStatus.Info, formatedEnd);
        }

        [Test, Category("MainPage")]
        public void GotoYoutubeWorkspacesWatching()
        {
            string title = "Quantower roadmap - features that coming soon — Quantower trading platform";
            test = extent.StartTest("GotoYoutubeWorkspacesWatching");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            
            NewHomepage page = new NewHomepage(this.Driver);
            Driver.FindElement(page.moreInRoadmap).Click();
            Assertions(title, "GoTo Roadmap");
            test.Log(LogStatus.Info, formatedEnd);
        }

        [Test, Category("MainPage")]
        public void SocialsButtonsCheck()
        {
            expected1 = "Quantower - Главная | фейсбук";
            expected2 = "Telegram: Contact @quantower";
            test = extent.StartTest("SocialsButtonsCheck");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            
            NewHomepage page = new NewHomepage(this.Driver);
            PixelScroller(3500);
            Driver.FindElement(page.facebookBtn).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected1, "Facebook button click");
            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            Driver.FindElement(page.telegramBtn).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected2, "Telegram button click");

            test.Log(LogStatus.Info, formatedEnd);
        }

        [Test, Category("MainPage")]
        public void TotopButtonAppears()
        {
            test = extent.StartTest("TotopButtonAppears");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");

            NewHomepage page = new NewHomepage(Driver);
            PixelScroller(3000);
            Thread.Sleep(300);
            try
            {
                Assert.IsTrue(Driver.FindElement(page.toTopBtn).Displayed);
                test.Log(LogStatus.Pass, "ToTop button is not visible");
            }
            catch
            {
                string screenShotPath = Capture(Driver, "ToTop button is not visible");
                Capture(Driver, "Totop button");
                test.Log(LogStatus.Fail, test.AddScreenCapture(screenShotPath));
            }

            Driver.FindElement(page.toTopBtn).Click();
            Thread.Sleep(1000);

            try
            {
                Assert.IsFalse(Driver.FindElement(page.toTopBtn).Displayed);
                test.Log(LogStatus.Pass, "ToTop button is not visible");
            }
            catch
            {
                string screenShotPath = Capture(Driver, "ToTop button is not visible");
                Capture(Driver, "Totop button");
                test.Log(LogStatus.Fail, test.AddScreenCapture(screenShotPath));
            }
            test.Log(LogStatus.Info, formatedEnd);
        }
        #endregion

        #region =====Main page footer tests=====
        [Test, Category("Footer")]
        public void FooterApplication_Column()
        {
            #region Expected strings
            expected1 = "Professional Online Trading Software | Quantower — Quantower trading platform";
            expected2 = "List of available connections and data providers — Quantower trading platform";
            expected3 = "Quantower roadmap - features that coming soon — Quantower trading platform";
            expected4 = "Recent updates of Quantower platform — Quantower trading platform";
            expected5 = "Welcome to Quantower Help - Quantower";
            expected6 = "QUANTOWER API | Quantower API";
            expected7 = "Frequently asked questions — Quantower trading platform";
            #endregion

            test = extent.StartTest("FooterApplication_Column");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");

            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            PixelScroller(10000);

            Driver.FindElement(footer.features).Click();
            Assertions(expected1, "Features");

            Driver.Navigate().Back();
            Driver.FindElement(footer.connections).Click();
            Assertions(expected2, "Connections");

            Driver.Navigate().Back();
            Driver.FindElement(footer.roadmap).Click();
            Assertions(expected3, "Roadmap");

            Driver.Navigate().Back();
            Driver.FindElement(footer.releaseNotes).Click();
            Assertions(expected4, "Release notes");

            Driver.Navigate().Back();
            Driver.FindElement(footer.documentation).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected5, "Documentation");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.apiReference).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected6, "API references");
            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            Driver.FindElement(footer.faq).Click();
            Assertions(expected7, "FAQ");

            test.Log(LogStatus.Info, formatedEnd);
        }
        
        [Test, Category("Footer")]
        public void FooterCompany_Column()
        {
            #region Expected strings
            expected1 = "Quantower team and values — Quantower trading platform";
            expected2 = "News and updates — Quantower trading platform";
            expected3 = "B2B solutions for your business — Quantower trading platform";
            expected4 = "Quantower, contact us — Quantower trading platform";
            expected5 = "Terms and policies — Quantower trading platform";
            expected6 = "Terms and policies — Quantower trading platform";
            #endregion
            test = extent.StartTest("FooterCompany_Column");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");

            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            
            PixelScroller(10000);
            
            //click on team link in footer and do assertion
            Driver.FindElement(footer.team).Click();
            Assertions(expected1, "Team");
            Driver.Navigate().Back();

            //click on blog link in footer and do assertion
            Driver.FindElement(footer.blog).Click();
            Assertions(expected2, "Blog");
            Driver.Navigate().Back();

            //click on B2B link in footer and do assertion
            Driver.FindElement(footer.BtB).Click();
            Assertions(expected3, "B2B");
            Driver.Navigate().Back();

            //click on Contact Us link in footer and do assertion
            Driver.FindElement(footer.contactUs).Click();
            Assertions(expected4, "ContactUs");
            Driver.Navigate().Back();

            //click on Terms link in footer and do assertion
            Driver.FindElement(footer.termsAndConditions).Click();
            Assertions(expected5, "Terms and Conditions");
            Driver.Navigate().Back();

            //click on Privacy link in footer and do assertion
            Driver.FindElement(footer.privacyPolicy).Click();
            Assertions(expected6, "Privacy policy");

            test.Log(LogStatus.Info, formatedEnd);
        }

        [Test, Category("Footer")]
        public void FooterSocials_Column()
        {
            #region Expected strings
            string expected1, expected2, expected3, expected4, expected5;
            expected1 = "Quantower - Главная | фейсбук";
            expected2 = "LinkedIn: Log In or Sign Up";
            expected3 = "Quantower (@Quantower_app) | Твиттер";
            expected4 = "Telegram: Contact @quantower_updates";
            expected5 = "Quantower trading platform - YouTube";
            #endregion

            test = extent.StartTest("FooterSocials_Column");
            test.Log(LogStatus.Info, formatedBegin);
            Driver.Navigate().GoToUrl("https://www.quantower.com");

            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            PixelScroller(10000);
            
            Driver.FindElement(footer.facebookFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected1, "Facebook");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.linkedinFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected2, "LinkedIn");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.twitterFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected3, "Twitter");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.telgramFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected4, "Telegram");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.youtubeFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assertions(expected5, "Youtube");

            test.Log(LogStatus.Info, formatedEnd);
        }
        #endregion

        #region =====Misc methods=====
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = @"C:\TestData\" + screenShotName + ".jpeg";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Jpeg);
            return localpath;
        }

        /// <summary>
        /// Assertion with AreEqual()
        /// </summary>
        public void Assertions(string expected, string StepAndScreenshot, string message = "title")
        {
            string formatedMessagePass = $"<font color='green'><b>{StepAndScreenshot} passed</b></font>";
            string formatedMessageFail = $"<font color='red'><b>{StepAndScreenshot} failed</b></font>";
            try
            {
                Assert.AreEqual(expected, Driver.Title, StepAndScreenshot);
                test.Log(LogStatus.Pass, formatedMessagePass);
            }
            catch
            {
                string screenShotPath = Capture(Driver, StepAndScreenshot);
                test.Log(LogStatus.Fail, formatedMessageFail + test.AddScreenCapture(screenShotPath));
                
            }
        }
        /// <summary>
        /// Assertion with IsTrue()
        /// </summary>
        public void Assertions(string expected, string StepAndScreenshot)
        {
            string formatedMessagePass = $"<font color='green'><b>{StepAndScreenshot} passed</b></font>";
            string formatedMessageFail = $"<font color='red'><b>{StepAndScreenshot} failed</b></font>";
            try
            {
                Assert.IsTrue(Driver.Title == expected, "Title isn't equal {0}", expected);
                test.Log(LogStatus.Pass, formatedMessagePass);
            }
            catch
            {
                string screenShotPath = Capture(Driver, StepAndScreenshot);
                test.Log(LogStatus.Fail, formatedMessageFail + test.AddScreenCapture(screenShotPath));
            }
        }
        public void CheckTestdataDirectory()
        {
            string directory = @"C:\TestData\";
            bool testDataDirectory = Directory.Exists(directory);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        public void PixelScroller(int scroll)
        {
            string jsScroll = "window.scrollBy(0, " + scroll + ");";
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(jsScroll);
        }
        #endregion
    }
}
