using Business.Classes;

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
    public class SystemClockTest
    {
        [Test]
        public void GetIncreaseTime_And_CampaignPasif_Succesfully_ResultCodeMustBeTrue ()
        {
            Mock<IUnitOfWork> mockUow = new Mock<IUnitOfWork>();
            Mock<ICampaignRepository> mockCampaignRepo = new Mock<ICampaignRepository>();
            var campaignList = new List<Campaign> {
                new Campaign() { Id = 1, Name ="C1", Duration= 4, PriceManipulationLimit = 5, CampaignStartDate = SystemClock.Now, ProductId = 1}
            };

            mockCampaignRepo.Setup(m => m.GetExpiredCampaigns(SystemClock.Now)).Returns(campaignList.AsQueryable());
            mockUow.Setup(m => m.CampaignRepository).Returns(mockCampaignRepo.Object);
            var systemClockBusiness = new SystemClockBusiness(mockUow.Object);
            var result = systemClockBusiness.GetIncreaseTime(new GetIncreaseTimeRequest { Hour = 1 });

            Assert.AreEqual(SystemClock.Now, result.Data);
        }
    }
}
