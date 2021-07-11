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
    public class OrderControllerTests
    {
        Mock<IOrderBusiness> mock;
        OrderController orderControllerObj;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IOrderBusiness>();
            orderControllerObj = new OrderController(mock.Object);
        }

        [TearDown]
        public void CleanUp()
        {//It is run once after every test's running

        }

        [Test]
        public void Create_Method_Verify()
        {
            orderControllerObj.Create(new CreateOrderRequest());

            mock.Verify(m => m.Create(It.IsAny<CreateOrderRequest>()), Times.Once);
        }
    }
}
