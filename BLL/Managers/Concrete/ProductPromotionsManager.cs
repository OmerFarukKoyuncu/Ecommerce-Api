using AutoMapper;
using BLL.DTO;
using BLL.DTO.PromotionsDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class ProductPromotionsManager : Manager<ProductPromotionDtoModel, ProductPromotion>, IProductPromotionsManager
    {
        public ProductPromotionsManager(Repository<ProductPromotion> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
