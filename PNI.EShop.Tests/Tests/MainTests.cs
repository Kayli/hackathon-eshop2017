using NUnit.Framework;
using OpenQA.Selenium;
using System;
using NUnit.Framework.Internal;
using PNI.EShop.Tests.Pages;

namespace PNI.EShop.Tests
{
    public class MainTests : TestBase
    {
        public ProductsPage _productsPage;

        public override void BeforeAll()
        {
            base.BeforeAll();
            _productsPage = new ProductsPage(_driver);
        }

       [Test]
       public void Can_view_products_list()
       {
           Assert.AreEqual(5, _productsPage.GetProductsCount);
       }

    }
}