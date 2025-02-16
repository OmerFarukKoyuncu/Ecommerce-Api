using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SeedData
{
    public class SeedContent : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasData(
                new Content { Id=1, PageName="Home", ContentText=""},
                new Content { Id=2, PageName="AboutUs", ContentText=""},
                new Content { Id=3, PageName="ContactUs", ContentText=""}
                );
        }
    }
}
