using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PNI.EShop.Tests.Base;

namespace PNI.EShop.Tests.Pages
{
    public class ProductsPage : PageBase
    {
        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public int GetProductsCount => _driver.FindElements(By.XPath("//table//a")).Count;

        [FindsBy(How = How.XPath, Using = "(//table//a)[1]")]
        internal IWebElement FirstProduct;
    }
}
