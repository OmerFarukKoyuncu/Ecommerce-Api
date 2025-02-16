using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShopCartItem:BaseEntity
    {
       
        public int ShopCartId { get; set; } // Hangi sepete ait olduğu
        virtual public ShopCart ShopCart { get; set; } // ShopCart ile ilişki

        public int ProductId { get; set; } // Sepete eklenen ürün
        virtual public Product Product { get; set; } // Product ile ilişki

        public int Quantity { get; set; } // Ürünün sepetteki miktarı

    }
}
