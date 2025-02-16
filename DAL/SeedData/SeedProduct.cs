using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SeedData
{
    public class SeedProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

               new Product { Id = 1, Name = "Notebook", Description = "Notebook Description", SellerId=1 },
                 new Product { Id = 2, Name = "Telephone", Description = "Telephone Description", SellerId=2 },
                 new Product { Id = 3, Name = "Modem", Description = "Modem Description" , SellerId = 3 }

               );
        }
    }
}
