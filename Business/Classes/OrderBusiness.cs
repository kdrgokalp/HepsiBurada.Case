using Business.Interface;

using Common;
using Common.Exceptions;
using Common.Helper;
using Common.RequestDTO;

using Data.Interface;
using Data.Model;

using Microsoft.Extensions.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Classes
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IUnitOfWork _uow;
        public OrderBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public CommonResult<bool> Create(CreateOrderRequest request)
        {
            CommonResult<bool> result = new CommonResult<bool>();
            var product = _uow.ProductRepository.GetProductByProductCode(request.ProductCode);
            if (product == null)
                throw new BusinessException($"ProductCode don't find record. ProductCode: {request.ProductCode}");

            var campaign = _uow.CampaignRepository.GetAvailableCampaign(product.Id);
            

            var orderProductList = new List<OrderProduct>(); 
            if (campaign == null)
            {
               
                orderProductList.Add(ComputeOrderProduct(null, product.Id, request.Quentity, product.Price, null));
            }
            else
            {
                var currentDiscount = Helper.GetCurrentDiscountAmount(campaign.CampaignStartDate, campaign.PriceManipulationLimit, campaign.Duration);
                var remainingTargetSalesCount = GetRemainingTargetSalesCount(campaign.Id);
                if (remainingTargetSalesCount > request.Quentity)
                {
                    orderProductList.Add(ComputeOrderProduct(currentDiscount, product.Id, request.Quentity, product.Price, campaign.Id));
                }
                else
                {
                    orderProductList.Add(ComputeOrderProduct(currentDiscount, product.Id, remainingTargetSalesCount, product.Price, campaign.Id));
                    orderProductList.Add(ComputeOrderProduct(currentDiscount, product.Id, request.Quentity - remainingTargetSalesCount, product.Price, campaign.Id));
                }
            }

            var order = new Order() { OrderDate = Common.Helper.SystemClock.Now, OrderProducts = orderProductList, OrderValue = orderProductList.Sum(p => p.Value) };

            _uow.OrderRepository.Insert(order);
            result.Succeeded = result.Data = true;
            return result;
            
        }

        private OrderProduct ComputeOrderProduct(decimal? currentDiscount, int productId, int quantity, decimal productPrice, int? campaingId)
        {
            if (this.CheckStockControl(productId) < quantity)
            {
                throw new BusinessException("Order quantit can't exceed the product stock count");
            }

            var orderProduct = new OrderProduct();
            orderProduct.Price = productPrice;
            orderProduct.CampaignId = campaingId;
            orderProduct.ProductId = productId;
            orderProduct.DiscountedPrice = productPrice - (currentDiscount.HasValue ? currentDiscount.Value : 0);                
            orderProduct.Value = quantity * orderProduct.DiscountedPrice;
            orderProduct.Quantity = quantity;
            return orderProduct;
        }

        private int CheckStockControl(int productId)
        {
            var totalStock = _uow.ProductStockRepository.GetProductStockCount(productId);
            var usedStock = _uow.OrderProductRepository.GetOrderProductStockCount(productId);
            
            return totalStock - usedStock;
        }

        private int GetRemainingTargetSalesCount(int campaignId)
        {
            var salesCount = _uow.CampaignRepository.GetCampaignTargetSales(campaignId);
            var usedSalesCount = _uow.OrderProductRepository.GetCampaignSalesCount(campaignId);
            return salesCount - usedSalesCount;
        }

    }
}
