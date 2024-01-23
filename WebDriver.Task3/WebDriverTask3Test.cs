using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriver.Task3
{
    class WebDriverTask3Test
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-popup-blocking");

            // Then, pass options while initializing the WebDriver
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("https://cloudpricingcalculator.appspot.com/");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void webDriverTask3()
        {
            driver.FindElement(By.Id("tab-item-1")).Click();

            driver.FindElement(By.CssSelector("input[name='quantity']")).SendKeys("4");
            driver.FindElement(By.CssSelector("input[name='label']")).SendKeys(string.Empty);

            driver.FindElement(By.CssSelector("#select_value_label_92 .md-text")).Click();
            IWebElement optionToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_102")));
            optionToSelect.Click();

            driver.FindElement(By.CssSelector("#select_value_label_93 > span:nth-child(1)")).Click();
            IWebElement optionPMSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_115']")));
            optionPMSelect.Click();

            driver.FindElement(By.Id("select_value_label_94")).Click();
            IWebElement optionMFSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_119']")));
            optionMFSelect.Click();

            driver.FindElement(By.CssSelector("#select_value_label_95 > span:nth-child(1)")).Click();
            IWebElement optionSSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_224']")));
            optionSSelect.Click();
            
            driver.FindElement(By.CssSelector("#select_value_label_96 .md-text")).Click();
            IWebElement optionMTSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_474']")));
            optionMTSelect.Click();

            driver.FindElement(By.CssSelector(".layout-row:nth-child(15) .md-label")).Click();

            driver.FindElement(By.Id("select_510")).Click();
            IWebElement optionGPUSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_517']")));
            optionGPUSelect.Click();

            driver.FindElement(By.Id("select_512")).Click();
            IWebElement optionNGPUsSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_520']")));
            optionNGPUsSelect.Click();

            driver.FindElement(By.CssSelector("#select_value_label_468 > span:nth-child(1)")).Click();
            IWebElement optionSSDSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_495']")));
            optionSSDSelect.Click();

            driver.FindElement(By.CssSelector("#select_value_label_98 .md-text")).Click();
            IWebElement optionSrSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_268']")));
            optionSrSelect.Click();

            driver.FindElement(By.Id("select_value_label_99")).Click();
            IWebElement optionCuSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_138']")));
            optionCuSelect.Click();

            driver.FindElement(By.CssSelector(".layout-align-end-start:nth-child(22) > .md-raised")).Click();

            IWebElement totalCostElement = driver.FindElement(By.CssSelector("#resultBlock > md-card > md-card-content > div > div > div > div.cpc-cart-total > h2 > b"));
            string fullString = totalCostElement.Text;
            int colonIndex = fullString.IndexOf(':');
            string substringAfterColon = fullString.Substring(colonIndex + 2);
            int perIndex = substringAfterColon.IndexOf("per");
            string result = substringAfterColon.Substring(0, perIndex);
            string totalCostString = result.Trim();

            js.ExecuteScript("window.open();");

            List<string> tabs = new List<string>(driver.WindowHandles);

            driver.SwitchTo().Window(tabs[1]);
            driver.Navigate().GoToUrl("https://yopmail.com/");

            driver.FindElement(By.CssSelector("#listeliens > a:nth-child(1)")).Click();

            IWebElement buttonNew = driver.FindElement(By.CssSelector("body button:nth-child(1)"));
            buttonNew.Click();

            IWebElement divElement = driver.FindElement(By.Id("geny"));
            string divText = divElement.Text;

            driver.SwitchTo().Window(tabs[0]);

            IWebElement buttonEmail = driver.FindElement(By.Id("Email Estimate"));
            buttonEmail.Click();

            driver.FindElement(By.Id("input_620")).SendKeys(divText);

            IWebElement buttonEmailSend = driver.FindElement(By.CssSelector("#dialogContent_626 > form > md-dialog-actions > button.md-raised.md-primary.cpc-button.md-button.md-ink-ripple"));
            buttonEmailSend.Click();

            driver.SwitchTo().Window(tabs[1]);
            IWebElement buttonInbox = driver.FindElement(By.CssSelector("body button:nth-child(3)"));
            buttonInbox.Click();

            driver.SwitchTo().Frame("ifmail");
            IWebElement totalCostFromEmailElement = driver.FindElement(By.CssSelector("#mail td:nth-child(2) > h3"));

            Assert.That(totalCostFromEmailElement.Text, Is.EqualTo(totalCostString));
        }
    }
}
