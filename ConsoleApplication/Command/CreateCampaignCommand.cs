using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Command
{
    public class CreateCampaignCommand : BaseCommand
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public override string ActionMetod => "api/Campaign/Create";

        public CreateCampaignCommand(List<string> request)
        {
            this.Valid(request);
        }
        public override void Valid(List<string> request)
        {
            if (string.IsNullOrWhiteSpace(request[0]))
                throw new Exception("Name is not valid");

            if (string.IsNullOrWhiteSpace(request[1]))
                throw new Exception("ProductCode is not valid");

            if (!int.TryParse(request[2], out int duration))
                throw new Exception("Duration must be greater than zero");

            if (!int.TryParse(request[3], out int priceManipulationLimit))
                throw new Exception("PriceManipulationLimit must be greater than zero");

            if (!int.TryParse(request[4], out int targetSalesCount))
                throw new Exception("TargetSalesCount must be greater than zero");

            this.Name = request[0];
            this.ProductCode = request[1];
            this.Duration = duration;
            this.PriceManipulationLimit = priceManipulationLimit;
            this.TargetSalesCount = targetSalesCount;
        }

        public override object GetRequest()
        {
            return new
            {
                Name = this.Name,
                ProductCode = this.ProductCode,
                Duration = this.Duration,
                PriceManipulationLimit = this.PriceManipulationLimit,
                TargetSalesCount = this.TargetSalesCount
            };
        }
    }
}
