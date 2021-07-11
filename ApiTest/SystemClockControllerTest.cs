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
    public class SystemClockControllerTests
    {
        Mock<ISystemClockBusiness> mock;
        SystemClockController systemClockControllerObj;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<ISystemClockBusiness>();
            systemClockControllerObj = new SystemClockController(mock.Object);
        }

        [TearDown]
        public void CleanUp()
        {//It is run once after every test's running

        }

        [Test]
        public void GetIncreaseTime_Method_Verify()
        {
            systemClockControllerObj.GetIncreaseTime(new GetIncreaseTimeRequest());
            
            mock.Verify(m => m.GetIncreaseTime(It.IsAny<GetIncreaseTimeRequest>()), Times.Once);
        }
    }
}
