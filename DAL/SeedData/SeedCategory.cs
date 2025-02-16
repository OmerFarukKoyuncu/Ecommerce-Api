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
    public class SeedCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

               new Category {  Id=1, Name="Electronic", Description= "Electronic Description" },
                 new Category { Id = 2, Name = "Clothes", Description = "Clothes Description" },
                 new Category { Id = 3, Name = "Cosmetic", Description = "Cosmetic Description" }
              
               );
        }
    }
}
