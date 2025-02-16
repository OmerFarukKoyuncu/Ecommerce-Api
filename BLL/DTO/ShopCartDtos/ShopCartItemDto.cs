using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShopCartItemDto: BaseDTOModel
    {
       
        public int ShopCartId { get; set; } // Hangi sepete ait olduğu
        virtual public ShopCartDto ShopCart { get; set; } // ShopCart ile ilişki

        public int ProductId { get; set; } // Sepete eklenen ürün
        virtual public GetAllProductsDtoModel Product { get; set; } // Product ile ilişki

        public int Quantity { get; set; } // Ürünün sepetteki miktarı
        public decimal TotalPrice => (decimal)(Product.Price * Quantity); // Ürünün toplam fiyatı (miktar * birim fiyat)
    }
}
