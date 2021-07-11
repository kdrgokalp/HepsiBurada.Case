using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ResultBase
    {
        private List<string> error;
        public List<string> Errors
        {

            get
            {
                if (error == null)
                    error = new List<string>();
                return error;
            }
            set
            {
                error = value;
            }
        }
    }
}
