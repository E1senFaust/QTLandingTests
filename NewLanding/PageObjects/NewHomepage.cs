using OpenQA.Selenium;
using System;

namespace NewLanding.PageObjects
{
    class NewHomepage
    {
        public readonly IWebDriver driver;
        
        public NewHomepage(IWebDriver chrome)
        {
            this.driver = chrome;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
        }

        #region =============Elements in header=============
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

        #region =============Elements on page=============
        public By youtubeWrkWorks = By.CssSelector("body > div.block.customization > a");
        
        public By moreInRoadmap = By.CssSelector("body > div.block.richest > div > div.left > a");
        
        public By facebookBtn = By.XPath("/html/body/div[10]/div/div[2]/div[3]/a[1]");
        
        public By telegramBtn = By.CssSelector("body > div.block.brokers > div > div.right > div.buttonsBlock > a:nth-child(2) > span");
        
        public By toTopBtn = By.Id("toTop");
        #endregion
        
        
    }
}
