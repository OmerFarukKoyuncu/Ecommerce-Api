using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product: BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? PhotoUrl { get; set; }
        public int SellerId { get; set; }
        virtual public Seller Seller { get; set; }
        virtual public List<ProductCategory> ProductCategories { get; set; }

        virtual public List<Promotion> Promotions { get; set; }


        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
