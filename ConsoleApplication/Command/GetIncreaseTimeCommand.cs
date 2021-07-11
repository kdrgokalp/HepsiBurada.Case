using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Command
{
    public class GetIncreaseTimeCommand : BaseCommand
    {
        public override string ActionMetod => "api/SystemClock/GetIncreaseTime";

        public int Hour { get; set; }
        public GetIncreaseTimeCommand(List<string> request)
        {
            this.Valid(request);
        }
        public override object GetRequest()
        {
            return new
            {
                Hour = this.Hour
            };
        }

        public override void Valid(List<string> request)
        {
            if (!int.TryParse(request[0], out int hour))
                throw new Exception("Hour must be greater than zero");

            this.Hour = hour;
        }
    }
}
