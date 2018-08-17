using DotNet.MyProject.Entity;
using System;

namespace DotNet.MyProject.Service
{
    public class OrderListItemViewModel
    {
        public int ID { get; set; }

        public int Total { get; set; }

        public OrderStatusEnum Status { get; set; }

        public string OrderUser { get; set; }

        public DateTime CreateTime { get; set; }
    }
}