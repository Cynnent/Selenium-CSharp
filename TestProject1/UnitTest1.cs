using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
    public class UnitTest1
    {
        private IWebDriver driver;
         private WebDriverWait wait;
        

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void VerifyGoogleTitle()
        {
            driver.Url = "https://www.google.com";
            Assert.That(driver.Title, Is.EqualTo("Google"));
            driver.FindElement(By.Name("q")).SendKeys("Cynnent" + Keys.Return);
            
        }

        [Test]
        public void VerifyExplicitWait()
        {
           // Navigate to the demo URL
            driver.Navigate().GoToUrl("https://www.w3schools.com/js/tryit.asp?filename=tryjs_alert");

            driver.SwitchTo().Frame(driver.FindElement(By.Id("iframeResult")));

            // Wait for the button to be clickable
            IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Try it']")));

            // Click the button
            button.Click();

            // Wait for the alert to be displayed
            wait.Until(ExpectedConditions.AlertIsPresent());

            // Accept the alert
            IAlert alert = driver.SwitchTo().Alert();

            // Verify that the alert text is correct
            Assert.That(alert.Text, Is.EqualTo("I am an alert box!"));

            alert.Accept();

            
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();

        }
    }
}