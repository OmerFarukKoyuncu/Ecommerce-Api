using BLL.DTO.Seller;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface ISellerManager : IManager<SellerDTOModel,Seller>
    {
         public List<SellerProductListDTOModel> GetAllProductWithSeller ();
        public SellerDTOModel ApprovedBySeller (int id);
        public int GetIdByUserId(string userId);
        public void UpdateProfile(SellerDTOModel sellerDto);

        public SellerDTOModel GetSellerByID (string userId);
        public void AddNewSeller (SellerDTOModel model);
    }

}
