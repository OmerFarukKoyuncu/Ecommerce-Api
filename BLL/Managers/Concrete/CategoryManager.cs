using AutoMapper;
using BLL.DTO.Category;
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
    public class CategoryManager : Manager<CategoryDTOModel, Category>, ICategoryManager
    {
        public CategoryManager(Repository<Category> repository,IMapper mapper) : base(repository,mapper)
        {
        }
    }
}
