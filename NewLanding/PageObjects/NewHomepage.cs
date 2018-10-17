//This PageObject example uses PageFactory. And it is obsolete. So it will be deleted in nearby future (i mean PageFactory).

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System;
using System.IO;
using RelevantCodes.ExtentReports;

namespace NewLanding.PageObjects
{
    class NewHomepage
    {
        public readonly IWebDriver driver;
        public Screenshot screen;
        public NewHomepage(IWebDriver chrome)
        {
            this.driver = chrome;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);

        }

        #region Elements in header
        //Features
        public By featuresLink = By.CssSelector("body > div.header > div > ul > li:nth-child(2) > a");

        //Pricing
        public By pricingLink = By.CssSelector("body > div.header > div > ul > li:nth-child(3) > a");

        //Connections
        public By connectionsLink = By.CssSelector("body > div.header > div > ul > li:nth-child(4) > a");

        //Roadmap
        public By roadmapLink = By.CssSelector("body > div.header > div > ul > li:nth-child(5) > a");
        
        //B2B
        public By btbLink = By.CssSelector("body > div.header > div > ul > li:nth-child(6) > a");

        //Blog
        public By blogLink = By.CssSelector("body > div.header > div > ul > li:nth-child(7) > a");

        //Download button
        public By downloadBtn = By.XPath("/html/body/div[6]/div/div[1]/a");
        #endregion

        #region Elements on page
        public By youtubeWrkWorks = By.CssSelector("body > div.block.customization > a");
        
        public By moreInRoadmap = By.CssSelector("body > div.block.richest > div > div.left > a");
        
        public By facebookBtn = By.XPath("/html/body/div[10]/div/div[2]/div[3]/a[1]");
        
        public By telegramBtn = By.CssSelector("body > div.block.brokers > div > div.right > div.buttonsBlock > a:nth-child(2) > span");
        
        public By toTopBtn = By.Id("toTop");
        #endregion

        //Checking links in header
        /*public void MainPageLinks(string expected1, string expected2, string expected3, string expected4, string expected5, string expected6)
        {
            //Clicking on features, then we do assertions and go to previous page (Main page) 
            featuresLink.Click();
            Assertions(expected1, "Features page", "Current page is not a FEATURES");
            this.driver.Navigate().Back();

            //Clicking on pricing, then we do assertions and go to previous page (Main page) 
            pricingLink.Click();
            Assertions(expected2, "pricingLink", "Current page is not a PRICING");
            //Assert.AreEqual(expected2, this.driver.Title);

            this.driver.Navigate().Back();

            //Clicking on connections, then we do assertions and go to previous page(Main page)
            connectionsLink.Click();
            Assertions(expected3, "connectionsLink", "Current page is not a CONNECTIONS");
            this.driver.Navigate().Back();

            //Clicking on roadmap, then we do assertions and go to previous page(Main page)
            roadmapLink.Click();
            Assertions(expected4, "roadmapLink", "Current page is not a ROADMAP");
            this.driver.Navigate().Back();

            //Clicking on B2B, then we do assertions and go to previous page (Main page)
            btbLink.Click();
            Assertions(expected5, "btbLink", "Current page is not a B2B");
            this.driver.Navigate().Back();
            //Clicking on blog, then we do assertions
            blogLink.Click();
            Assertions(expected6, "blogLink", "Current page is not a BLOG");

            //Yippee-ki-yay!!! We did it ;)
        }
        */
        /*public void DownloadBtnTest(string expected)
        {
            test.Log(LogStatus.Info, "Download button existing test started.");
            try
            {
                Assert.IsNotNull(downloadBtn);
                Assert.AreEqual(expected, downloadBtn.Text);
                test.Log(LogStatus.Pass, "Download button exist");
            }
            catch { test.Log(LogStatus.Fail, "Download button is null"); }
        }
        */
        /*public void MoreInRoadmap(string expected, string expectedURL)
        {

            //ScrollOneFrame(500);
            moreInRoadmap.Click();
            try {
                Assert.IsTrue(this.driver.Title == expected && this.driver.Url == expectedURL);
                test.Log(LogStatus.Pass, "GoTo roadmap link is working");
            }
            catch { test.Log(LogStatus.Fail, "Step failed"); }
            }
            */
       /* public void SocialsButtons(string facebook, string telegram)
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            ScrollOneFrame(3500);
           // Thread.Sleep(100);
            facebookBtn.Click();
            this.driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assertions(facebook, "Facebook button click");
            //Assert.IsTrue(this.driver.Title == facebook);
            this.driver.Close();
            this.driver.SwitchTo().Window(driver.WindowHandles[0]);
            telegramBtn.Click();
            this.driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assertions(telegram, "Telegram button click");
           // Assert.IsTrue(this.driver.Title == telegram);
        }
        */
       /* public void ToTop()
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            ScrollOneFrame(3000);
            Thread.Sleep(300);
            Assert.IsTrue(toTopBtn.Displayed, "ToTop button is not visible");
            toTopBtn.Click();
            Thread.Sleep(1500);
            Assert.IsFalse(toTopBtn.Displayed, "ToTop button is VISIBLE");
            
            
        }
        */

        #region Misc methods
        public void ScrollOneFrame(int scroll)
        {
            string jsScroll = "window.scrollBy(0, " + scroll + ");";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(jsScroll);
        }

#warning Need to add some switch
        /// <summary>
        /// Assertion with AreEqual
        /// </summary>
        public void Assertions(string expected, string screenshotName, string message="title")
        {
            screen = ((ITakesScreenshot)driver).GetScreenshot();
            string dir = @"C:\TestData\";

            try
            {
                Assert.AreEqual(expected, this.driver.Title, message);
            }
            catch
            {
                screen.SaveAsFile(dir + screenshotName+".jpg", ScreenshotImageFormat.Jpeg);
                Exception e;
            }
        }
        /// <summary>
        /// Assertion with IsTrue
        /// </summary>
        /*public void Assertions(string expected, string StepAndScreenshot)
        {
            try
            {
                Assert.IsTrue(driver.Title == expected, "Title isn't equal {0}", expected);
                test.Log(LogStatus.Pass, StepAndScreenshot + " passed");
            }
            catch
            {
                string screenShotPath = Capture(driver, StepAndScreenshot);
                test.Log(LogStatus.Fail, StepAndScreenshot + " failed" + test.AddScreenCapture(screenShotPath));
            }
        }

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = @"C:\TestData\" + screenShotName + ".jpeg";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Jpeg);
            return localpath;
        }*/
        #endregion
    }
}
