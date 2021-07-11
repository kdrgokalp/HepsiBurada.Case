using Castle.DynamicProxy;

using Common;
using Common.Exceptions;

using Microsoft.Extensions.Logging;


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Infrastructure.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly Serilog.ILogger _logger;
        public LoggingInterceptor(Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            var stopWacth = new Stopwatch();
            stopWacth.Start();
            try
            {
                
                invocation.Proceed();

            }
            catch (BusinessException ex)
            {
                _logger.Warning("Message: {@Message}, Method Name: {Name}, Request: {@Request}", ex.Message, invocation.Method.Name, Helper.Helper.GetMethodParameterJson(invocation.Arguments, invocation.Method.GetParameters()));
                Helper.Helper.AddErrorMessage(invocation, ex.Message);
            }
            catch(Exception ex)
            {
                _logger.Error("Message: {@Message}, StackTrace: {StackTrace} Method Name: {Name}, Request: {@Request}", ex.Message, ex.StackTrace, invocation.Method.Name, Helper.Helper.GetMethodParameterJson(invocation.Arguments, invocation.Method.GetParameters()));
                Helper.Helper.AddErrorMessage(invocation, "General System Warning!");
            }
            finally
            {
                stopWacth.Stop();
                
                _logger.Information("ProcessTime: {ProcessTime}", stopWacth.ElapsedMilliseconds);
            }
            
        }
    }
}
