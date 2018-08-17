using AutoMapper;
using System;
using System.Collections.Generic;

namespace DotNet.Core
{
    public abstract class ExecutionContextBase : IExecutionContext
    {
        public virtual DateTime Now => DateTime.Now;
        public virtual string AppRootPath => AppDomain.CurrentDomain.BaseDirectory;

        public IMapper Mapper { get; set; }

        public MapperConfiguration MapperConfiguration { get; set; }

        public virtual object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public virtual T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<object> Resolves(Type type)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Resolves<T>()
        {
            throw new NotImplementedException();
        }
    }
}