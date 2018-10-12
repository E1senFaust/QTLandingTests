using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using NUnit.Framework;


namespace NewLanding.PageObjects
{
    class NewHomepageFooter
    {
        public readonly IWebDriver driver;

        public NewHomepageFooter(IWebDriver chrome)
        {
            this.driver = chrome;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
        }
        //APPLICATION COLUMN
        #region =============Application column=============
        //features from footer
        public By features = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(1)");
        //connections
        public By connections = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(3)");
        //roadmap
        public By roadmap = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(5)");

        //release notes
        public By releaseNotes = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(7)");

        //documentation
        public By documentation = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(9)");

        //api reference
        public By apiReference = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(11)");

        //FAQ
        public By faq = By.CssSelector("body > div.footer > div > div.top > div:nth-child(3) > p > a:nth-child(13)");
        #endregion

        //COMPANY COLUMN
        #region =============Company column=============
        //team
        public By team = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(1)");

        //blog
        public By blog = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(3)");

        //BtB
        public By BtB = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(5)");

        //contuct us
        public By contactUs = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(7)");

        //terms & conditions
        public By termsAndConditions = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(9)");
        //privacy policy
        public By privacyPolicy = By.CssSelector("body > div.footer > div > div.top > div:nth-child(4) > p > a:nth-child(11)");
        #endregion

        //SOCIALS COLUMN
        #region Join us in socials
            //facebook
        public By facebookFooter = By.CssSelector("body > div.footer > div > div.top > div:nth-child(5) > ul > li:nth-child(1) > a");

            //linkedin
            public By linkedinFooter = By.CssSelector("body > div.footer > div > div.top > div:nth-child(5) > ul > li:nth-child(2) > a");

            //twitter
            public By twitterFooter = By.CssSelector("body > div.footer > div > div.top > div:nth-child(5) > ul > li:nth-child(3) > a");

            //teelgram
            public By telgramFooter = By.CssSelector("body > div.footer > div > div.top > div:nth-child(5) > ul > li:nth-child(4) > a");

            //youtube
            public By youtubeFooter = By.CssSelector("body > div.footer > div > div.top > div:nth-child(5) > ul > li:nth-child(5) > a");
        #endregion
    }
}
