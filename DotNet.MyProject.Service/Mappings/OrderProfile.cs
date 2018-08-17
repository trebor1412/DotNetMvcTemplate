using AutoMapper;
using DotNet.MyProject.Entity;

namespace DotNet.MyProject.Service
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListItemViewModel>()
                .ForMember(x => x.OrderUser, y => y.MapFrom(z => z.User.Name));
        }
    }
}