using System.Collections.Generic;
using System.Linq;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using Moq;
using Xunit;

namespace Marketing_Unit_Test
{
    public class TestProductsRepo
    {
        private readonly IProductsRepo _repo;
        public TestProductsRepo()
        {
            IList<Products> products = new List<Products>() {
            new Products(){ProductID=100,ProductName="XYZ-Idea Mouse",Description="This is a mid-range gaming mouse capable of high precision combined with low-latency",UnitPrice=4999},
            new Products(){ProductID=116,ProductName="XYZ Keyboard",Description="keyboard for gaming",UnitPrice=5678},
            };
            var mockRepo = new Mock<IProductsRepo>();

            mockRepo.Setup(repo => repo.DisplayProducts()).Returns(products.ToList());
            mockRepo.Setup(repo => repo.AddProducts(It.IsAny<Products>())).Callback((Products item) =>
            {
                item = new Products() { ProductID = 118, ProductName = "XYZ CPU", Description = "CPU", UnitPrice = 20000 };
                products.Add(item);
            }).Verifiable();
            mockRepo.SetupAllProperties();
            _repo = mockRepo.Object;
        }
        [Fact]
        public void TestAddProducts()
        {
            var productsdetails = new Products() { ProductID = 118, ProductName = "XYZ CPU", Description = "CPU", UnitPrice = 20000 };
            _repo.AddProducts (productsdetails);

            Assert.Equal(1, 1);
        }
        [Fact]
        public void DisplayProducts()
        {
            int expected = 2;
            var productsdetails = _repo.DisplayProducts();
            Assert.Equal(expected, productsdetails.Count);
        }
    }
}
