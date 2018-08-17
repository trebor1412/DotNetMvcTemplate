using System.ComponentModel;

namespace DotNet.MyProject.Entity
{
    public enum OrderStatusEnum
    {
        [Description("Created")]
        Created = 1,

        [Description("CheckOut")]
        CheckOut = 2,

        [Description("Cancelled")]
        Cancelled = 3
    }
}