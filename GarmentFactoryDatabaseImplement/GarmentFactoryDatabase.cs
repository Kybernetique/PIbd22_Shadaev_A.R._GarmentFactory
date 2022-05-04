using GarmentFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GarmentFactoryDatabaseImplement
{
    public class GarmentFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8RJEJL3\SQLEXPRESS;Initial Catalog=GarmentFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Textile> Textiles { set; get; }

        public virtual DbSet<Garment> Garments { set; get; }

        public virtual DbSet<GarmentTextile> GarmentTextiles { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Warehouse> Warehouses { set; get; }
        public virtual DbSet<WarehouseTextile> WarehouseTextiles { set; get; }
    }
}
