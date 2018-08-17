using AutoMapper.QueryableExtensions;
using DotNet.Core;
using DotNet.MyProject.Entity;
using DotNet.MyProject.Repository;
using DotNet.Service;
using System;
using System.Linq;

namespace DotNet.MyProject.Service
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(
            IOrderRepository orderRepository,
            IUserService userService,
            IExecutionContext executionContext) : base(executionContext)
        {
            this.orderRepository = orderRepository;
            this.userService = userService;
        }

        private IOrderRepository orderRepository { get; }

        private IUserService userService { get; }

        public IResult CreateOrder(OrderCreateViewModel viewModel)
        {
            var user = userService.GetUser(viewModel.UserID);
            if (user == null)
            {
                return new Result { Message = "User does not exist" };
            }

            var newOrder = new Order
            {
                Total = viewModel.Total,
                Status = OrderStatusEnum.Created,
                UserID = viewModel.UserID,
                CreateTime = executionContext.Now
            };

            try
            {
                orderRepository.Add(newOrder);
                return new Result { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message };
            }
        }

        public OrderListViewModel GetOrderList()
        {
            var viewModel = new OrderListViewModel
            {
                Orders = orderRepository.GetAll()
                                        .ProjectTo<OrderListItemViewModel>(executionContext.MapperConfiguration)
                                        .ToList()
            };

            return viewModel;
        }
    }
}