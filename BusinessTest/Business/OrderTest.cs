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
using System.Text;
using System.Threading.Tasks;

namespace BusinessTest.Business
{
    public class OrderTest
    {
        Product product = new Product() { Id = 1, Price = 1000, ProductCode = "U5", ProductStocks = new List<ProductStock>() { new ProductStock() { Id = 1, ProductId = 1, Quantity = 10 } } };
        Campaign campaign = new Campaign() { Id = 1, Name = "C1", Duration = 4, PriceManipulationLimit = 5, CampaignStartDate = SystemClock.Now, ProductId = 1 };
        Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
        Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
        Mock<IProductStockRepository> mockProductStockRepo = new Mock<IProductStockRepository>();
        Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
        Mock<IOrderProductRepository> mockOrderProductRepo = new Mock<IOrderProductRepository>();
        Mock<IOrderRepository> mockOrderRepo = new Mock<IOrderRepository>();

        [Test] 
        public void CreateOrder_Campaign_TestSuccesfully_ResultCodeMustBeTrue()
        {
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockCampaignRepo.Setup(m => m.GetAvailableCampaign(product.Id)).Returns(campaign);
            mockCampaignRepo.Setup(m => m.GetCampaignTargetSales(campaign.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetCampaignSalesCount(campaign.Id)).Returns(10);
            mockProductStockRepo.Setup(m => m.GetProductStockCount(product.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetOrderProductStockCount(product.Id)).Returns(10);

            repository_setup();

            var orderBusiness = new OrderBusiness(mockUow.Object);
            var result = orderBusiness.Create(new CreateOrderRequest {  ProductCode = "U5", Quentity = 5 });
            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void CreateOrder_Campaign_Null_TestSuccesfully_ResultCodeMustBeTrue()
        {
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockCampaignRepo.Setup(m => m.GetAvailableCampaign(product.Id)).Equals(null);
            mockCampaignRepo.Setup(m => m.GetCampaignTargetSales(campaign.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetCampaignSalesCount(campaign.Id)).Returns(10);
            mockProductStockRepo.Setup(m => m.GetProductStockCount(product.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetOrderProductStockCount(product.Id)).Returns(10);

            repository_setup();

            var orderBusiness = new OrderBusiness(mockUow.Object);
            var result = orderBusiness.Create(new CreateOrderRequest { ProductCode = "U5", Quentity = 5 });
            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void CreateOrder_Campaign_TestFaill_BusinessExceptionProdut()
        {
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockCampaignRepo.Setup(m => m.GetAvailableCampaign(product.Id)).Equals(null);
            mockCampaignRepo.Setup(m => m.GetCampaignTargetSales(campaign.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetCampaignSalesCount(campaign.Id)).Returns(10);
            mockProductStockRepo.Setup(m => m.GetProductStockCount(product.Id)).Returns(20);
            mockOrderProductRepo.Setup(m => m.GetOrderProductStockCount(product.Id)).Returns(10);

            repository_setup();

            var orderBusiness = new OrderBusiness(mockUow.Object);
            Assert.Throws<BusinessException>(() => orderBusiness.Create(new CreateOrderRequest { ProductCode = "U7", Quentity = 5 }));
        }

        private void repository_setup()
        {
            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);
            mockUow.Setup(m => m.ProductStockRepository).Returns(mockProductStockRepo.Object);
            mockUow.Setup(m => m.OrderProductRepository).Returns(mockOrderProductRepo.Object);
            mockUow.Setup(m => m.OrderRepository).Returns(mockOrderRepo.Object);
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);
        }
    }





}
