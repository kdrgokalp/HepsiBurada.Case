using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CommonResult<TEntity> : ResultBase
    {
        public CommonResult()
        {

        }
        public CommonResult(bool succeeded, List<string> errors, TEntity data)
        {
            Succeeded = succeeded;
            base.Errors = errors;
            Data = data;
        }

        public TEntity Data { get; set; }
        public bool Succeeded { get; set; }

        public static CommonResult<TEntity> Errors(string errors)
        {
            return new CommonResult<TEntity>(false, new List<string> { errors }, default);
        }

        public static CommonResult<TEntity> Errors(List<string> errors)
        {
            return new CommonResult<TEntity>(false, errors, default);
        }

    }
}
