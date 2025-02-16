using BLL.DTO.OrderDtos;
using BLL.DTO.PromotionsDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IPromotionsManager : IManager<PromotionDtoModel, Promotion>
    {
    }
}
