using System;
using Xunit;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.Models.Entities;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace MarketingManagement.API
{
    public class TestSalesRepo
    {
        private readonly ISalesRepo _repo;
        public TestSalesRepo()
        {
            IList<Sales> sales = new List<Sales>()
            {
                new Sales() { OrderID = 100,LeadID= 100 ,ShippingAddress="Hyderabad",BillingAddress="Hyderabad",CreatedON = Convert.ToDateTime("23-06-2021"), PaymentMode = "CashonDelivery"},
                new Sales() { OrderID = 109,LeadID= 104 ,ShippingAddress="Vizag",BillingAddress="Vizag",CreatedON = Convert.ToDateTime("03-04-2021"), PaymentMode = "Debit Card" }
            };
            var mockRepo = new Mock<ISalesRepo>();

            mockRepo.Setup(repo => repo.ViewSales()).Returns(sales.ToList());
            mockRepo.SetupAllProperties();
            _repo = mockRepo.Object;
        }
        [Fact]
        public void TestViewSales()
        {
            int expected = 2;
            var salesdetails = _repo.ViewSales();
            Assert.Equal(expected, salesdetails.Count);
        }
    }
}
