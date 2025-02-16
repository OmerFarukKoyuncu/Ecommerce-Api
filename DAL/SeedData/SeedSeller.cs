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
    public class SeedSeller : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(

             new Seller { Id = 1, Name = "Seller 1",  ContactInfo="Seller 1 Contact", UserId= "9d301b17-778d-43f9-a78a-6da416001618" },
               new Seller { Id = 2, Name = "Seller 2", ContactInfo = "Seller 2 Contact", UserId = null },
               new Seller { Id = 3, Name = "Seller 3", ContactInfo = "Seller 3 Contact", UserId = null }

             );
        }
    }
}
