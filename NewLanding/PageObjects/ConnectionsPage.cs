using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLanding.PageObjects
{
    class ConnectionsPage
    {
        public IWebDriver driver;

        public ConnectionsPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
        }

        public By oanda = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(1)");

        public By lmax = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(2) > a");

        public By fxmtf = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(3) > a");

        public By ctrader = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(4) > a");

        public By tradeview = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(5) > a");

        public By poloniex = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(6) > a");

        public By binance = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(7) > a");

        public By hitBTC = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(8) > a");

        public By kraken = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(9) > a");

        public By bitfinex = By.CssSelector("body > div.main > div > div > div > div.block.available > div > div > div:nth-child(10) > a");

        public By contactUs = By.LinkText("send us an email request");

        public By downloadBtn = By.CssSelector("body > div.getApp > div > div.left > a");

        public By downloadScreen = By.CssSelector("#version");


    }
}
