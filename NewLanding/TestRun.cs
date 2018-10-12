using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NewLanding.PageObjects;
using OpenQA.Selenium.Interactions;

namespace NewLanding
{
    [TestFixture]
    public class TestRun
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public ChromeOptions opt { get; set; }
        public Actions act { get; set; }

        [SetUp]
        public void Setup()
        {
            opt = new ChromeOptions();
            opt.AddArguments("--headless");
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            
        }

        [TearDown]
        public void TearDown()
        {
            //this.Driver.Manage().Cookies.DeleteAllCookies();
            this.Driver.Quit();
        }

         [Test, Retry(3)]
        public void Features()
        {
            string exp1 = "Professional Online Trading Software | Quantower — Quantower trading platform";
            string exp2 = "Prices & Licenses — Quantower trading platform";
            string exp3 = "List of available connections and data providers — Quantower trading platform";
            string exp4 = "Quantower roadmap - features that coming soon — Quantower trading platform";
            string exp5 = "B2B solutions for your business — Quantower trading platform";
            string exp6 = "News and updates — Quantower trading platform";


            NewHomepage newpage = new NewHomepage(this.Driver);
            newpage.Test(exp1, exp2, exp3, exp4, exp5, exp6);
            //    Driver.Navigate().GoToUrl("https://www.quantower.com/homepagenew");
            //    newpage.featuresLink.Click();
            //    Assert.AreEqual("Testy", this.Driver.Title);
        }

         [Test, Retry(3)]
        public void DownloadBtnCheck()
        {
            NewHomepage page = new NewHomepage(this.Driver);
            page.DownloadBtnTest("GET THE PLATFORM");
        }

         [Test, Retry(3)]
        public void GotoYoutubeWorkspacesWatching()
        {
            string title = "Quantower roadmap - features that coming soon — Quantower trading platform";
            string url = "https://www.quantower.com/roadmap";
            NewHomepage page = new NewHomepage(this.Driver);
            page.MoreInRoadmap(title, url);
        }
         [Test, Retry(3)]
        public void SocialsButtonsCheck()
        {
            NewHomepage page = new NewHomepage(this.Driver);
            page.SocialsButtons("Quantower - Главная | фейсбук", "Telegram: Contact @quantower");
        }

         [Test, Retry(3)]
        public void TotopButtonAppears()
        {
            NewHomepage page = new NewHomepage(Driver);
            Driver.Navigate().GoToUrl("https://www.quantower.com");
            page.ScrollOneFrame(3000);
            Thread.Sleep(300);
            Assert.IsTrue(page.toTopBtn.Displayed, "ToTop button is not visible");
            page.toTopBtn.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(page.toTopBtn.Displayed, "ToTop button is VISIBLE");
        }

        [Test, Retry(3)]
        public void FooterApplication_Column()
        {
            #region Expected strings
            string expected1, expected2, expected3, expected4, expected5, expected6, expected7;
            expected1 = "Professional Online Trading Software | Quantower — Quantower trading platform";
            expected2 = "List of available connections and data providers — Quantower trading platform";
            expected3 = "Quantower roadmap - features that coming soon — Quantower trading platform";
            expected4 = "Recent updates of Quantower platform — Quantower trading platform";
            expected5 = "Welcome to Quantower Help - Quantower";
            expected6 = "QUANTOWER API | Quantower API";
            expected7 = "Frequently asked questions — Quantower trading platform";
            #endregion

            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            NewHomepage q = new NewHomepage(Driver);
            q.ScrollOneFrame(10000);

            Driver.FindElement(footer.features).Click();
            Assert.IsTrue(Driver.Title == expected1, "Title isn't equal {0}", expected1);

            Driver.Navigate().Back();
            Driver.FindElement(footer.connections).Click();
            Assert.IsTrue(Driver.Title == expected2, "Title isn't equal {0}", expected2);

            Driver.Navigate().Back();
            Driver.FindElement(footer.roadmap).Click();
            Assert.IsTrue(Driver.Title == expected3, "Title isn't equal {0}", expected3);

            Driver.Navigate().Back();
            Driver.FindElement(footer.releaseNotes).Click();
            Assert.IsTrue(Driver.Title == expected4, "Title isn't equal {0}", expected4);

            Driver.Navigate().Back();
            Driver.FindElement(footer.documentation).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected5, "Title isn't equal {0}", expected5);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            
            Driver.FindElement(footer.apiReference).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected6, "Title isn't equal {0}", expected6);
            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            Driver.FindElement(footer.faq).Click();
            Assert.IsTrue(Driver.Title == expected7, "Title isn't equal {0}", expected7);
        }

        [Test, Retry(3)]
        public void FooterCompany_Column()
        {
            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            NewHomepage q = new NewHomepage(Driver);
            q.ScrollOneFrame(10000);

            #region Expected strings
            string expected1, expected2, expected3, expected4, expected5, expected6;
            expected1 = "Quantower team and values — Quantower trading platform";
            expected2 = "News and updates — Quantower trading platform";
            expected3 = "B2B solutions for your business — Quantower trading platform";
            expected4 = "Quantower, contact us — Quantower trading platform";
            expected5 = "Terms and policies — Quantower trading platform";
            expected6 = "Terms and policies — Quantower trading platform";
            #endregion

            Driver.FindElement(footer.team).Click();
            Assert.IsTrue(Driver.Title == expected1, "Title isn't equal {0}", expected1);
            Driver.Navigate().Back();

            Driver.FindElement(footer.blog).Click();
            Assert.IsTrue(Driver.Title == expected2, "Title isn't equal {0}", expected2);
            Driver.Navigate().Back();

            Driver.FindElement(footer.BtB).Click();
            Assert.IsTrue(Driver.Title == expected3, "Title isn't equal {0}", expected3);
            Driver.Navigate().Back();

            Driver.FindElement(footer.contactUs).Click();
            Assert.IsTrue(Driver.Title == expected4, "Title isn't equal {0}", expected4);
            Driver.Navigate().Back();

            Driver.FindElement(footer.termsAndConditions).Click();
            Assert.IsTrue(Driver.Title == expected5, "Title isn't equal {0}", expected5);
            Driver.Navigate().Back();

            Driver.FindElement(footer.privacyPolicy).Click();
            Assert.IsTrue(Driver.Title == expected6, "Title isn't equal {0}", expected6);
        }

        [Test, Retry(3)]
        public void FooterSocials_Column()
        {
            NewHomepageFooter footer = new NewHomepageFooter(Driver);
            NewHomepage q = new NewHomepage(Driver);
            q.ScrollOneFrame(10000);

            #region Expected strings
            string expected1, expected2, expected3, expected4, expected5;
            expected1 = "Quantower - Главная | фейсбук";
            expected2 = "Quantower | LinkedIn";
            expected3 = "Quantower (@Quantower_app) | Твиттер";
            expected4 = "Telegram: Contact @quantower_updates";
            expected5 = "Quantower trading platform - YouTube";
            #endregion

            Driver.FindElement(footer.facebookFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected1, "Title isn't equal {0}", expected1);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.linkedinFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected2, "Title isn't equal {0}", expected2);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.twitterFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected3, "Title isn't equal {0}", expected3);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.telgramFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected4, "Title isn't equal {0}", expected4);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            Driver.FindElement(footer.youtubeFooter).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Assert.IsTrue(Driver.Title == expected5, "Title isn't equal {0}", expected5);
        }
    }
}
