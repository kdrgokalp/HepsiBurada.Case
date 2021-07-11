using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Command
{
    public class GetProductInfoCommand : BaseCommand
    {
        public override string ActionMetod => "api/Product/GetProductByProductCode";

        public string ProductCode { get; set; }
        public GetProductInfoCommand(List<string> request)
        {
            this.Valid(request);
        }
        public override object GetRequest()
        {
            return new
            {
                ProductCode = this.ProductCode
            };
        }

        public override void Valid(List<string> request)
        {
            if (string.IsNullOrWhiteSpace(request[0]))
                throw new Exception("ProductCode is not valid");

            this.ProductCode = request[0];
        }
    }
}
