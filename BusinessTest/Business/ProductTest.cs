using Business.Classes;

using Common.RequestDTO;

using Data.Interface;
using Data.Model;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessTest.Business
{
    public class CreateProductTest
    {
        [Test]
        public void CreateProductTestSuccesfully_ResultCodeMustBeTrue()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);

            var productBusiness = new ProductBusiness(mockUow.Object);

            var result = productBusiness.Create(new CreateProductRequest { Price = 10, ProductCode = "L1", Stock = 100 });

            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void UpdateProductPrice_Or_AddStock_ResultCodeMustBeTrue()
        {

            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            var product = new Product() { Id = 1, Price = 1000, ProductCode = "U5", ProductStocks = new List<ProductStock>() { new ProductStock() { Id = 1, ProductId = 1, Quantity= 10} } };
            mockProductRepo.Setup(m => m.GetProductByProductCode(product.ProductCode)).Returns(product);
            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);
            var productBusiness = new ProductBusiness(mockUow.Object);
            var result = productBusiness.Create(new CreateProductRequest { Price = 10, ProductCode = "U5", Stock = 300 });
            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void GetProductListInfo_NeverCampaign__ResultCodeMustBeTrue()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            Mock<IProductStockRepository> mockProductStockRepo = new Mock<IProductStockRepository>();
            Mock<IOrderProductRepository> mockOrderProductRepo = new Mock<IOrderProductRepository>();
            Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
            var productList = new List<Product> {
                new Product() { Id = 1, Price = 200, ProductCode = "U5"},
                new Product() { Id = 2, Price = 5000, ProductCode = "U6" },
                new Product() { Id = 3, Price = 7000, ProductCode = "U7"}
            };

            var productStockList = new List<ProductStock>()
            {
                new ProductStock() { Id = 1, ProductId = 1, Quantity = 10 },
                new ProductStock() { Id = 2, ProductId = 2, Quantity = 100 },
                new ProductStock() { Id = 3, ProductId = 3, Quantity = 500 }
            };
            var orderProductList = new List<OrderProduct>()
            {
                new OrderProduct() {Id= 1, OrderId = 1, Price = 200, Quantity = 2, Value = 400, DiscountedPrice = 10, ProductId = 1},
                new OrderProduct() {Id= 2, OrderId = 2, Price = 200, Quantity = 3, Value = 600, DiscountedPrice = 10, ProductId = 1}
            };

                mockProductRepo.Setup(m => m.GetAll()).Returns(productList.AsQueryable());
                mockProductStockRepo.Setup(m => m.GetAll()).Returns(productStockList.AsQueryable());
                mockOrderProductRepo.Setup(m => m.GetAll()).Returns(orderProductList.AsQueryable());
            

            mockUow.Setup(m => m.ProductRepository).Returns(mockProductRepo.Object);
            mockUow.Setup(m => m.ProductStockRepository).Returns(mockProductStockRepo.Object);
            mockUow.Setup(m => m.OrderProductRepository).Returns(mockOrderProductRepo.Object);
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);

            var productBusiness = new ProductBusiness(mockUow.Object);
            var result = productBusiness.GetProductByProductCode(new GetProductByProductCodeRequest { ProductCode = "U5" });
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Data.Stock == 15);
            Assert.IsTrue(result.Data.Price == 200);

        }
    }
}
