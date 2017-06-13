using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PNI.EShop.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            _driver = CreateChromeDriver();
        }

        [OneTimeTearDown]
        public virtual void AfterAll()
        {
            _driver.Quit();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AfterEachFailed();
            }
        }

        private void AfterEachFailed()
        {
            SaveScreenshot();
        }

        private void SaveScreenshot()
        {
            throw new NotImplementedException();
        }

        #region  Methods to initiate Chrome driver

        protected static IWebDriver CreateChromeDriver()
        {
            string chromeDriverPath = GetAssemblyLocation();
            chromeDriverPath += @"..\..\..\packages\Selenium.WebDriver.ChromeDriver.2.29.0\driver\win32";

            return new ChromeDriver();
        }

        private static string GetAssemblyLocation()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var codebase = new Uri(assembly.CodeBase);
            var path = codebase.LocalPath;
            var pathParts = path.Split('\\');
            path = path.Replace(pathParts.Last(), string.Empty);
            return path;
        }

        #endregion

    }
}
