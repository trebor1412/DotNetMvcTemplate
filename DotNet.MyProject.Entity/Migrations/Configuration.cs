using System.Data.Entity.Migrations;
using DotNet.Entity;

namespace DotNet.MyProject.Entity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabaseContext context)
        {
            //Seed Enum Database Table
            context.OrderStatus.SeedEnumValues<OrderStatus, OrderStatusEnum>();
        }
    }
}