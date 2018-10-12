//This PageObject example uses PageFactory. And it is obsolete. So it will be deleted in nearby future (i mean PageFactory).

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System;

namespace NewLanding.PageObjects
{
    class NewHomepage
    {
        public readonly IWebDriver driver;

        public NewHomepage(IWebDriver chrome)
        {
            this.driver = chrome;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            PageFactory.InitElements(chrome, this);
            
        }

        #region Elements in header
        //Features
        [FindsBy(How =How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(2) > a")]
        public IWebElement featuresLink { get; set; }

        //Pricing
        [FindsBy(How = How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(3) > a")]
        public IWebElement pricingLink { get; set; }

        //Connections
        [FindsBy(How = How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(4) > a")]
        public IWebElement connectionsLink { get; set; }

        //Roadmap
        [FindsBy(How = How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(5) > a")]
        public IWebElement roadmapLink { get; set; }


        //B2B
        [FindsBy(How = How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(6) > a")]
        public IWebElement btbLink { get; set; }

        //Blog
        [FindsBy(How = How.CssSelector, Using = "body > div.header > div > ul > li:nth-child(7) > a")]
        public IWebElement blogLink { get; set; }

        //Download button
        [FindsBy(How=How.XPath, Using = "/html/body/div[6]/div/div[1]/a")]
        public IWebElement downloadBtn { get; set; }
        #endregion

        #region Elements on page
        [FindsBy(How = How.CssSelector, Using = "body > div.block.customization > a")]
        public IWebElement youtubeWrkWorks { get; set; }

        [FindsBy(How=How.CssSelector, Using = "body > div.block.richest > div > div.left > a")]
        public IWebElement moreInRoadmap { get; set; }

        [FindsBy(How=How.XPath, Using = "/html/body/div[10]/div/div[2]/div[3]/a[1]")]
        public IWebElement facebookBtn { get; set; }

        [FindsBy(How=How.CssSelector, Using = "body > div.block.brokers > div > div.right > div.buttonsBlock > a:nth-child(2) > span")]
        public IWebElement telegramBtn { get; set; }

        [FindsBy(How=How.Id, Using = "toTop")]
        public IWebElement toTopBtn { get; set; }
        #endregion

        //Checking links in header
        public void Test(string expected1, string expected2, string expected3, string expected4, string expected5, string expected6)
        {
            //Clicking on features, then we do assertions and go to previous page (Main page) 
            featuresLink.Click();
            Assert.AreEqual(expected1, this.driver.Title);
            this.driver.Navigate().Back();

            //Clicking on pricing, then we do assertions and go to previous page (Main page) 
            pricingLink.Click();
            Assert.AreEqual(expected2, this.driver.Title);
            this.driver.Navigate().Back();

            //Clicking on connections, then we do assertions and go to previous page(Main page)
            connectionsLink.Click();
            Assert.AreEqual(expected3, this.driver.Title);
            this.driver.Navigate().Back();

            //Clicking on roadmap, then we do assertions and go to previous page(Main page)
            roadmapLink.Click();
            Assert.AreEqual(expected4, this.driver.Title);
            this.driver.Navigate().Back();

            //Clicking on B2B, then we do assertions and go to previous page (Main page)
            btbLink.Click();
            Assert.AreEqual(expected5, this.driver.Title);
            this.driver.Navigate().Back();
            //Clicking on blog, then we do assertions
            blogLink.Click();
            Assert.AreEqual(expected6, this.driver.Title);

            //Yippee-ki-yay!!! We did it ;)
        }

        public void DownloadBtnTest(string expected)
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            Assert.IsNotNull(downloadBtn);
            Assert.AreEqual(expected, downloadBtn.Text);
        }

        public void MoreInRoadmap(string expected, string expectedURL)
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            //ScrollOneFrame(500);
            moreInRoadmap.Click();
            Assert.IsTrue(this.driver.Title == expected && this.driver.Url == expectedURL);
        }

        public void SocialsButtons(string facebook, string telegram)
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            ScrollOneFrame(3500);
           // Thread.Sleep(100);
            facebookBtn.Click();
            this.driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.IsTrue(this.driver.Title == facebook);
            this.driver.Close();
            this.driver.SwitchTo().Window(driver.WindowHandles[0]);
            telegramBtn.Click();
            this.driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.IsTrue(this.driver.Title == telegram);
        }

        public void ToTop()
        {
            this.driver.Navigate().GoToUrl("https://www.quantower.com");
            ScrollOneFrame(3000);
            Thread.Sleep(300);
            Assert.IsTrue(toTopBtn.Displayed, "ToTop button is not visible");
            toTopBtn.Click();
            Thread.Sleep(1500);
            Assert.IsFalse(toTopBtn.Displayed, "ToTop button is VISIBLE");
            
            
        }


        #region Misc methods
        public void ScrollOneFrame(int scroll)
        {
            string jsScroll = "window.scrollBy(0, " + scroll + ");";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(jsScroll);
        }
        #endregion
    }
}
