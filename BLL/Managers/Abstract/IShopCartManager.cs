using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IShopCartManager : IManager<ShopCartDto, ShopCart>
    {
        ShopCartDto GetByUserId(string userId); // Change int to string   
        void EmptyById(int id);
        void AddItemById(int id, int productId,int quantity);
        void RemoveItemById(int id, int itemId);
        void IncrementItemById(int id, int itemId);
        void DecrementItemById(int id, int itemId);
        int GetIdByUserId(string userId);

        List<string> CheckStock(ShopCartDto shopCart);

    }
}
