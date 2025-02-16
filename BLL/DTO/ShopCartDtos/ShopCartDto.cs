using BLL.DTO;
using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShopCartDto:BaseDTOModel
    {
        public string UserId { get; set; } // Alışveriş sepetini oluşturan müşteri
        virtual public UserDto User { get; set; } // User ile ilişki

        virtual public List<ShopCartItemDto> Items { get; set; } // Sepetteki ürünler
    }

}
