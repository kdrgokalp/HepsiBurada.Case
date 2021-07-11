using Castle.DynamicProxy;

using Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Helper
{
    public class Helper
    {
        internal static string GetMethodParameterJson(object[] arguments, ParameterInfo[] methodInfo)
        {
            string retVal = null;
            try
            {
                if (arguments != null && arguments.Any())
                {
                    var methodParameterResult = arguments.Where(p => p != null).ToList();
                    var methodInfoResult = methodInfo.Where(p => p != null).ToList();
                    List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                    result.Add(new Dictionary<string, object>() { { "ParameterName", methodInfoResult.Select(p => p.Name) }, { "ParameterValue", methodParameterResult } });
                    retVal = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            catch { }
            return retVal;
        }

        public static void AddErrorMessage (IInvocation invocation, string message) {
            invocation.ReturnValue = Activator.CreateInstance(invocation.Method.ReturnType);
            var baseMessage = invocation.ReturnValue as ResultBase;
            if (baseMessage == null)
            {
                baseMessage = new ResultBase();
            }
            baseMessage.Errors.Add(message);
        }
    }
}
