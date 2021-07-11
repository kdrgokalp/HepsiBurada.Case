using Business.Interface;

using Common;
using Common.Helper;
using Common.RequestDTO;
using Common.ResponseDTO;

using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Classes
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IUnitOfWork _uow;
        public ProductBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public CommonResult<bool> Create(CreateProductRequest request)
        {
            CommonResult<bool> result = new CommonResult<bool>();
            var product = _uow.ProductRepository.GetProductByProductCode(request.ProductCode);

            var productStock = new List<ProductStock> { new ProductStock() { Quantity = request.Stock } };
            if (product == null)
            {
                
                product = new Product { Price = request.Price, ProductCode = request.ProductCode, ProductStocks =  productStock };
                _uow.ProductRepository.Insert(product);
            }
            else
            {
                product.Price = request.Price;
                product.ProductStocks = productStock;
                _uow.ProductRepository.Update(product);
            }

            result.Succeeded = result.Data = true;
            return result;
        }

        public CommonResult<GetProductByProductCodeResponse> GetProductByProductCode(GetProductByProductCodeRequest request)
        {
            CommonResult<GetProductByProductCodeResponse> result = new CommonResult<GetProductByProductCodeResponse>();
            result.Data = _uow.ProductRepository.GetAll()
                .Join(_uow.ProductStockRepository.GetAll(), p => p.Id, ps => ps.ProductId, (p, ps) => new { p, ps })
                .GroupJoin(_uow.OrderProductRepository.GetAll(), pps => pps.p.Id, op => op.ProductId, (pps, op) => new { pps, op })
                .SelectMany(sm => sm.op.DefaultIfEmpty(), (x,y) => new { np = x.pps, nop = y })
                .GroupBy(g => new { g.np.p.Id, g.np.p.ProductCode, g.np.p.Price})
                .Select(s => new GetProductByProductCodeResponse() { Id = s.Key.Id, Price = s.Key.Price, ProductCode = s.Key.ProductCode, 
                    Stock = s.Sum(x => x.np.ps.Quantity) - s.Sum(y => y.nop.Quantity)
                })
                .FirstOrDefault(t => t.ProductCode == request.ProductCode);

            if (result.Data != null)
            {
                var campaign = _uow.CampaignRepository.GetAvailableCampaign(result.Data.Id);
                if (campaign != null)
                {
                    result.Data.Price -= Helper.GetCurrentDiscountAmount(campaign.CampaignStartDate, campaign.PriceManipulationLimit, campaign.Duration);
                }
                result.Succeeded = true;
            }
            
            return result;
        }
    }
}
