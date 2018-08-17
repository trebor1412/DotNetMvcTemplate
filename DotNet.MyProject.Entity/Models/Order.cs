using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.MyProject.Entity
{
    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int Total { get; set; }

        public OrderStatusEnum Status { get; set; }

        public DateTime CreateTime { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("Status")]
        public virtual OrderStatus OrderStatus { get; set; }
    }
}