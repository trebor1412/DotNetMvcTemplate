using DotNet.Core;

namespace DotNet.MyProject.Service
{
    public interface IOrderService
    {
        OrderListViewModel GetOrderList();

        IResult CreateOrder(OrderCreateViewModel viewModel);
    }
}