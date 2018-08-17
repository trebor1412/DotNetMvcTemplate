using DotNet.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.MyProject.Entity
{
    [Table("OrderStatus")]
    public partial class OrderStatus : ModelEnumBase<OrderStatusEnum>
    {
    }
}