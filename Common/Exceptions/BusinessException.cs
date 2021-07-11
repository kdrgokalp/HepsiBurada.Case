﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base()
        { }

        public BusinessException(string message) : base(message)
        { }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
