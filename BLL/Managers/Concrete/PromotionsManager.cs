using AutoMapper;
using BLL.DTO.Category;
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
    public class PromotionsManager : Manager<PromotionDtoModel, Promotion>, IPromotionsManager
    {
        public PromotionsManager(Repository<Promotion> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
