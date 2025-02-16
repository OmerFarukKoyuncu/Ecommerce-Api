using BLL.DTO.Category;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface ICategoryManager : IManager<CategoryDTOModel, Category>
    {
    }
}
