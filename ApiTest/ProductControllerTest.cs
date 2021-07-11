using Business.Interface;

using Common.RequestDTO;

using HepsiBurada.Case.Controllers;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessTest.Api
{
    [TestFixture]
    public class ProductControllerTests
    {
        Mock<IProductBusiness> mock;
        ProductController productControllerObj;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IProductBusiness>();
            productControllerObj = new ProductController(mock.Object);
        }

        [TearDown]
        public void CleanUp()
        {//It is run once after every test's running

        }

        [Test]
        public void Create_Method_Verify()
        {
            productControllerObj.Create(new CreateProductRequest());
            
            mock.Verify(m => m.Create(It.IsAny<CreateProductRequest>()), Times.Once);
        }

        [Test]
        public void GetProductName_Method_Verify()
        {
            productControllerObj.GetProductByProductCode(new GetProductByProductCodeRequest());

            mock.Verify(m => m.GetProductByProductCode(It.IsAny<GetProductByProductCodeRequest>()), Times.Once);
        }


    }
}
