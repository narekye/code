using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace sharp.Selenium.Test.Demo
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver ChromeDriver;


        public UnitTest1()
        {
            ChromeDriver = new ChromeDriver("C:\\");

        }
        [TestMethod]
        public void TestChromeDriver()
        {
            ChromeDriver.Navigate().GoToUrl("");
            // ChromeDriver.FindElement(By.Id("lst-id")).SendKeys("Selenium");
            // ChromeDriver.FindElement(By.Id("lst-id")).SendKeys(Keys.Enter);
            Assert.IsTrue(true);
        }
    }
}
