using DotNet.Core;

namespace DotNet.Service
{
    public abstract class ServiceBase
    {
        public ServiceBase(IExecutionContext executionContext)
        {
            this.executionContext = executionContext;
        }

        protected IExecutionContext executionContext { get; }
    }
}