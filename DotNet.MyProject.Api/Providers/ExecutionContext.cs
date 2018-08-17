using AutoMapper;
using DotNet.Core;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace DotNet.MyProject.Api
{
    public class ExecutionContext : ExecutionContextBase, IExecutionContext
    {
        public ExecutionContext() : base()
        {
            MapperConfiguration = resolver.GetService(typeof(MapperConfiguration)) as MapperConfiguration;
            Mapper = resolver.GetService(typeof(IMapper)) as IMapper;
        }

        private IDependencyResolver resolver => GlobalConfiguration.Configuration.DependencyResolver;
    }
}