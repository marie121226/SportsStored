using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Controllers;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
new Product {ProductId = 1, Name = "P1",Category="Fruit"},
new Product {ProductId = 2, Name = "P2",Category="Fruit"},
new Product {ProductId = 3, Name = "P3",Category="Fruit"},
new Product {ProductId = 4, Name = "P4",Category="Fruit"},
new Product {ProductId = 5, Name = "P5",Category="Fruit"}
});
            ProductController controller = new ProductController();
            controller.ProductsRepository = mock.Object;
            controller.PageSize = 3;
            // Act
            var resultModel = (ProductsListViewModel)controller.List("Fruit",1).Model;
            var result = resultModel.Products;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
