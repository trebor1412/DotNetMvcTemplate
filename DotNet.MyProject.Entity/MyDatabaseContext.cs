using System.Data.Entity;

namespace DotNet.MyProject.Entity
{
    //TODO: Change to your own databasecontext type name and connectionstring name
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Order> Order { get; set; }

        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}