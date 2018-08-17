using DotNet.Core;
using DotNet.MyProject.Service;
using System.Web.Http;

namespace DotNet.MyProject.Api
{
    public class OrderController : ApiController
    {
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        private IOrderService orderService { get; }

        [HttpGet, Route("api/order")]
        public OrderListViewModel Index()
        {
            return orderService.GetOrderList();
        }

        [HttpPost, Route("api/order")]
        public IResult Create(OrderCreateViewModel viewModel)
        {
            return orderService.CreateOrder(viewModel);
        }
    }
}