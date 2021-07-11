using Business.Classes;

using Common.Exceptions;
using Common.Helper;
using Common.RequestDTO;

using Data.Interface;
using Data.Model;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessTest.Business
{
    public class CampaignTest
    {
        [Test]
        public void CreateProductTestSuccesfully_ResultCodeMustBeTrue()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
            var product = new Product() { Id = 1, Price = 1000, ProductCode = "U5", ProductStocks = new List<ProductStock>() { new ProductStock() { Id = 1, ProductId = 1, Quantity = 10 } } };
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);

            var campaignBusiness = new CampaignBusiness(mockUow.Object);

            var result = campaignBusiness.Create(new CreateCampaignRequest { Name = "C1", Duration= 1, PriceManipulationLimit = 5, ProductCode = "U5", TargetSalesCount= 5 });

            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void CreateProductTestFail_ResultCodeMustBeFalse()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
            var product = new Product() { Id = 1, Price = 1000, ProductCode = "U5", ProductStocks = new List<ProductStock>() { new ProductStock() { Id = 1, ProductId = 1, Quantity = 10 } } };
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);

            var campaignBusiness = new CampaignBusiness(mockUow.Object);

            Assert.Throws<BusinessException>(() => campaignBusiness.Create(new CreateCampaignRequest { Name = "C1", Duration = 1, PriceManipulationLimit = 5, ProductCode = "U7", TargetSalesCount = 5 }));
        }

        [Test]
        public void GetCampaignByNameInfo()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IOrderProductRepository> mockOrderProductRepo = new Mock<IOrderProductRepository>();
            Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
            var campaignList = new List<Campaign> {
                new Campaign() { Id = 1, Name ="C1", Duration= 4, PriceManipulationLimit = 5, CampaignStartDate = SystemClock.Now, ProductId = 1}
            };

            var orderProductList = new List<OrderProduct>()
            {
                new OrderProduct() {Id= 1, OrderId = 1, Price = 200, Quantity = 2, Value = 400, DiscountedPrice = 10, ProductId = 1, CampaignId = 1},
                new OrderProduct() {Id= 2, OrderId = 2, Price = 200, Quantity = 3, Value = 600, DiscountedPrice = 10, ProductId = 1, CampaignId = 1}
            };

            mockOrderProductRepo.Setup(m => m.GetAll()).Returns(orderProductList.AsQueryable());
            mockCampaignRepo.Setup(m => m.GetAll()).Returns(campaignList.AsQueryable());

            mockUow.Setup(m => m.OrderProductRepository).Returns(mockOrderProductRepo.Object);
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);

            var campaignBusiness = new CampaignBusiness(mockUow.Object);
            var result = campaignBusiness.GetCampanignByName(new GetCampaignByNameRequest { Name = "C1" });
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Data.TotalSales == 5);
            Assert.IsTrue(result.Data.Name == "C1");

        }
    }
}
