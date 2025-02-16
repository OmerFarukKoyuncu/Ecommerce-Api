using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShopCart:BaseEntity
    {
        public string UserId { get; set; } // Alışveriş sepetini oluşturan müşteri
        virtual public User User { get; set; } // Customer ile ilişki

        virtual public List<ShopCartItem> Items { get; set; } // Sepetteki ürünler
    }

}
