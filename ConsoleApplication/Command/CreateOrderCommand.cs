using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Command
{
    public class CreateOrderCommand : BaseCommand
    {
        public string ProductCode { get; private set; }
        public int Quentity { get; private set; }

        public override string ActionMetod => "api/Order/Create";
        public CreateOrderCommand(List<string> request)
        {
            this.Valid(request);
        }
        public override object GetRequest()
        {
            return new
            {
                ProductCode = this.ProductCode,
                Quentity = this.Quentity
            };
        }

        public override void Valid(List<string> request)
        {
            if (string.IsNullOrWhiteSpace(request[0]))
                throw new Exception("ProductCode is not valid");

            if (!int.TryParse(request[1], out int quentity))
                throw new Exception("Quentity must be greater than zero");

            this.ProductCode = request[0];
            this.Quentity = quentity;
        }
    }
}
