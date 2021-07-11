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
    public class CampaignControllerTests
    {
        Mock<ICampaignBusiness> mock;
        CampaignController campaignControllerObj;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<ICampaignBusiness>();
            campaignControllerObj = new CampaignController(mock.Object);
        }

        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void Create_Method_Verify()
        {
            campaignControllerObj.Create(new CreateCampaignRequest());

            mock.Verify(m => m.Create(It.IsAny<CreateCampaignRequest>()), Times.Once);
        }

        [Test]
        public void GetInfo_Method_Verify()
        {
            campaignControllerObj.GetCampanignByName(new GetCampaignByNameRequest());

            mock.Verify(m => m.GetCampanignByName(It.IsAny<GetCampaignByNameRequest>()), Times.Once);
        }


    }
}
