using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace PNI.EShop.Tests
{
    public class MainTests : TestBase
    {
       [Test]
       public void Can_view_products_list()
        {
            _driver.Navigate().GoToUrl("http://localhost:8507/products");
        }

    }
}