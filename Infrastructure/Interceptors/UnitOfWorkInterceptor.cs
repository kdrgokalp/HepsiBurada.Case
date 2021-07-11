using Castle.DynamicProxy;

using Common.Interface;

using Data.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interceptors
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _uow;

        public UnitOfWorkInterceptor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            _uow.SaveChanges();
        }
    }
}
