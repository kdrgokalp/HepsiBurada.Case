using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Command
{
    public class CreateProductCommand : BaseCommand
    {
        public override string ActionMetod => "api/Product/Create";
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommand(List<string> request)
        {
            this.Valid(request);
        }
        public override object GetRequest()
        {
            return new
            {
                ProductCode = this.ProductCode,
                Price = this.Price,
                Stock = this.Stock
            };
        }

        public override void Valid(List<string> request)
        {
            if (string.IsNullOrWhiteSpace(request[0]))
                throw new Exception("ProductCode is not valid");

            if (!decimal.TryParse(request[1], out decimal price))
                throw new Exception($"Price must be greater than zero");

            if (!int.TryParse(request[2], out int stock))
                throw new Exception("Stock must be greater than zero");

            this.ProductCode = request[0];
            this.Price = price;
            this.Stock = stock;
        }
    }
}
