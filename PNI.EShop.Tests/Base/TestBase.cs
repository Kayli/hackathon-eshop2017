using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using System.Threading;
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
            if (_driver == null)
                return;

            var path = @"C:\Projects\screenshots\";
            Directory.CreateDirectory(path);
            var testName = TestContext.CurrentContext.Test.Name;

            var fileName = $"{DateTime.Now:yyyy-MM-dd_hh-mm}-{testName}.{"png"}";
            var fullPath = Path.Combine(path, fileName);

            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            //need to wait until the screenshot is taken
            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            //need to wait until the screenshot is saved as a file
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
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
