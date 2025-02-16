using DAL.Entities;
using DAL.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RefundChange> RefundChanges { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Seller>().HasOne(x => x.User).WithOne().HasForeignKey<Seller>(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Product>().HasMany(x => x.Promotions).WithOne().OnDelete(DeleteBehavior.NoAction);

     
            builder.ApplyConfiguration(new SeedProduct());
            builder.ApplyConfiguration(new SeedCategory());
            builder.ApplyConfiguration(new SeedSeller());
            builder.ApplyConfiguration(new SeedContent());

            builder.Entity<Order>()
             .HasOne(o => o.Seller)
             .WithMany()
             .HasForeignKey(o => o.SellerId)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);

        }
        public override int SaveChanges()
        {

            var datas = ChangeTracker
               .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var entity = data.Entity;
                var entityType = entity.GetType();
                switch (data.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        data.State = EntityState.Modified;
                        entity.DeletedDate = DateTime.Now;
                        entity.IsDeleted = true;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChanges();
        }
    }
}
