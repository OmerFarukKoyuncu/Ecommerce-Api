using AutoMapper;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{

    
      
            
    public class SellerManager : Manager<SellerDTOModel, Seller>, ISellerManager
    {
        private readonly Repository<Seller> _repository;
        private readonly IMapper _mapper;

        public SellerManager(Repository<Seller> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddNewSeller (SellerDTOModel model)
        {
             var x = _repository.Add (_mapper.Map<Seller> (model));
        }

        public SellerDTOModel ApprovedBySeller (int id)
        {
            try
            {
                var seller = _repository.GetById(id);
                if (seller != null)
                {
                    if (seller.IsApproved)
                    {
                        seller.IsApproved = false;
                    }
                    else
                    {
                        seller.IsApproved = true;
                    }
                    seller.UpdatedDate = DateTime.Now;
                    _repository.Update(seller);
                    return _mapper.Map<SellerDTOModel>(seller);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<SellerProductListDTOModel> GetAllProductWithSeller()
        {
            var sell = _repository.GetAll().Include(x => x.Products);
            List<SellerProductListDTOModel> seller = new();
            return seller;
        }

        public SellerDTOModel GetSellerByID (string userId)
        {
            return _mapper.Map<SellerDTOModel>(_repository.GetAll().FirstOrDefault(x=>x.UserId == userId));
        }
        public int GetIdByUserId(string userId)
        {
            return _repository.GetAll ().Where (x => x.UserId == userId).Select (x => x.Id).First ();
        }
        public  void UpdateProfile(SellerDTOModel sellerDto)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            _repository.Update(seller);
        }
    }
}