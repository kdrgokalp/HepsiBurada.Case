using Business.Interface;

using Common;
using Common.Exceptions;
using Common.Helper;
using Common.RequestDTO;
using Common.ResponseDTO;

using Data.Enums;
using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Classes
{
    public class CampaignBusiness : ICampaignBusiness
    {
        private readonly IUnitOfWork _uow;
        public CampaignBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public CommonResult<bool> Create(CreateCampaignRequest request)
        {
            CommonResult<bool> result = new CommonResult<bool>();
            var product = _uow.ProductRepository.GetProductByProductCode(request.ProductCode);
            if (product == null)
                throw new BusinessException($"ProductCode don't find record. ProductCode: {request.ProductCode}");

            var campaign = new Campaign() { Name = request.Name, ProductId = product.Id, Duration = request.Duration, PriceManipulationLimit = request.PriceManipulationLimit, TargetSalesCount = request.TargetSalesCount, CampaignStartDate = SystemClock.Now };
            _uow.CampaignRepository.Insert(campaign);
            result.Succeeded = result.Data = true;
            return result;
        }

        public CommonResult<GetCampaignResponse> GetCampanignByName(GetCampaignByNameRequest request)
        {
            CommonResult<GetCampaignResponse> result = new CommonResult<GetCampaignResponse>();
            var campaign = _uow.CampaignRepository.GetAll()
                .Join(_uow.OrderProductRepository.GetAll(), c => c.Id, op => op.CampaignId, (c, op) => new { c, op })
                .Where(p => p.c.Name.ToLower() == request.Name.ToLower())
                .GroupBy(g => new { g.c.Id, g.c.Name, g.c.TargetSalesCount, g.c.Status, })
                .Select(s => new GetCampaignResponse
                {
                    Name = s.Key.Name,
                    TargetSales = s.Key.TargetSalesCount,
                    TotalSales = s.Sum(x => x.op.Quantity),
                    AverageItemPrice = s.Average(x => x.op.DiscountedPrice),
                    TurnOver = s.Sum(x => x.op.DiscountedPrice * x.op.Quantity),
                    Status = s.Key.Status == Status.Active ? "Active" : "Ended"
                }).FirstOrDefault();

            if (campaign == null)
            {
                campaign = _uow.CampaignRepository.Where(p => p.Name == request.Name)
                     .Select(s => new GetCampaignResponse
                     {
                         Name = s.Name,
                         TargetSales = s.TargetSalesCount,
                         TotalSales = 0,
                         AverageItemPrice = 0,
                         TurnOver = 0,
                         Status = s.Status == Status.Active ? "Active" : "Ended"
                     }).FirstOrDefault();
            }

            result.Data = campaign;
            result.Succeeded = true;
            return result;
        }
    }
}
